using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductionServices;

public partial class Production_FinalLine_ReportProductOutDataByLabelLine4 : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    ConnectDBFac3 oConFac3IoT = new ConnectDBFac3();
    ConnectDBSCM oConnSCM = new ConnectDBSCM();
    ProductionService oPrdSrv = new ProductionService();
    ConnectDB oConIoT = new ConnectDB();
    string _EmpCode = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
        
        //string txtOld = Request.Form[txtSerialOld.UniqueID];
        //txtSerialOld.Text = txtOld;

        //string txtNew = Request.Form[txtSerialNew.UniqueID];
        //txtSerialNew.Text = txtNew;

        try
        {
            _EmpCode = Page.Request.QueryString["EmpCode"].ToString();
        }
        catch
        {
            _EmpCode = "";
        }

        if (_EmpCode.Length == 0)
        {
            //Response.Redirect(@"http://websrv01.dci.daikin.co.jp/iotweb/");
        }
        else {
            DataTable dtEmp = new DataTable();
            string StrEmp = @"SELECT CODE,NAME,SURN,POSIT FROM Employee WHERE CODE=@CODE ";
            SqlCommand cmdEmp = new SqlCommand();
            cmdEmp.CommandText = StrEmp;
            cmdEmp.CommandTimeout = 180;
            cmdEmp.Parameters.Add(new SqlParameter("@CODE", _EmpCode));
            dtEmp = oConDCI.Query(cmdEmp);
            try
            {
                lblEmployee.Text = (dtEmp.Rows.Count > 0) ? _EmpCode + " : "+dtEmp.Rows[0]["NAME"].ToString() + "." + dtEmp.Rows[0]["SURN"].ToString().Substring(0, 1) : _EmpCode;
            }
            catch { lblEmployee.Text = _EmpCode; }
        }
    }

    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString();
    }

    
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltrSerialNo = (Literal)e.Item.FindControl("ltrSerialNo") as Literal;
            Literal ltrModel = (Literal)e.Item.FindControl("ltrModel") as Literal;
            Literal ltrRecordBy = (Literal)e.Item.FindControl("ltrRecordBy") as Literal;
            Literal ltrRecordDate = (Literal)e.Item.FindControl("ltrRecordDate") as Literal;


        }
    }
    



    protected void txtSerialNo_TextChanged(object sender, EventArgs e)
    {
        rptData.DataSource = null;
        rptData.DataBind();

        if (txtSerialNo.Text.Trim().Length >= 11)
        {
            DataTable dt = GetDataHistory(txtSerialNo.Text.Trim().ToUpper());

            rptData.DataSource = dt;
            rptData.DataBind();


            btnTransfer.Enabled = true;
            btnReset.Enabled = true;
        }
        else
        {
            btnTransfer.Enabled = false;
            btnReset.Enabled = true;
        }
    }


    


    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        btnTransfer.Enabled = false;
        btnReset.Enabled = false;

        if (txtSerialNo.Text.Trim().Length >= 11) {

            if(txtOutTo.Text.Trim().Length >= 4)
            {
                string _SerialNo = "";
                _SerialNo = txtSerialNo.Text.Trim().ToUpper();
                //string _YearNew = _SerialNew.Substring(1, 1);
                //string _MonthNew = _SerialNew.Substring(2, 1);
                string _DataModelNo = txtSerialNo.Text.Substring(0, 4);
                //string _DataYearNew = DateTime.Now.Year.ToString().Substring(0, 3) + _YearNew;
                if (txtSerialNo.Text.Trim().Length == 15)
                {
                    _DataModelNo = txtSerialNo.Text.Substring(3, 4);
                }
                else
                {
                    _DataModelNo = txtSerialNo.Text.Substring(0, 4);
                }

                string _Line = "0";
                //*********************************************
                //            CHECK LINE 4
                //*********************************************
                DataTable dtLabel = new DataTable();
                string strLabel = @"SELECT PrdDate, LocalDate, Model, ModelCode, Temp, PipeNo, SerialNumber 
                                     FROM PD_LabelLine4 
                                     WHERE SerialNumber=@SerialNumber ";
                SqlCommand cmdLabel = new SqlCommand();
                cmdLabel.CommandText = strLabel;
                cmdLabel.CommandTimeout = 180;
                cmdLabel.Parameters.Add(new SqlParameter("SerialNumber", _SerialNo));
                dtLabel = oConDCI.Query(cmdLabel);

                if (dtLabel.Rows.Count > 0)
                {
                    _Line = "4";
                }
                //*********************************************
                //           END CHECK LINE 4
                //*********************************************



                if (_Line != "0")
                {
                    string Shift = "D";
                    if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
                    {
                        Shift = "D";
                    }
                    else
                    {
                        Shift = "N";
                    }

                    DataTable dtCheck = new DataTable();
                    string SQLCheck = @"SELECT ISNULL(COUNT(Nbr),0) AS dataQty 
                                    FROM FG_ReportProductOut 
                                    WHERE dataLine=@dataLine AND SerialNo=@SerialNo ";
                    SqlCommand cmdCheck = new SqlCommand();
                    cmdCheck.CommandText = SQLCheck;
                    cmdCheck.CommandTimeout = 180;
                    cmdCheck.Parameters.Add(new SqlParameter("@dataLine", _Line));
                    cmdCheck.Parameters.Add(new SqlParameter("@SerialNo", _SerialNo));
                    dtCheck = oConIoT.Query(cmdCheck);

                    int _check = 1;
                    try
                    {
                        _check = Convert.ToInt16(dtCheck.Rows[0]["dataQty"].ToString());
                    }
                    catch { }

                    if (_check == 0)
                    {
                        //----------- GET Model Name -------------
                        string ModelName = "";
                        DataTable dtModel = new DataTable();
                        string strModel = @"SELECT TOP 1 Model, rmk1 
                                    FROM PN_Compressor 
                                    WHERE [Status]='ACTIVE' AND Line IN ('4') AND ModelCode=@ModelCode ";
                        SqlCommand cmdModel = new SqlCommand();
                        cmdModel.CommandText = strModel;
                        cmdModel.CommandTimeout = 180;
                        cmdModel.Parameters.Add(new SqlParameter("@ModelCode", _DataModelNo));
                        dtModel = oConnSCM.Query(cmdModel);
                        if (dtModel.Rows.Count > 0)
                        {
                            try
                            {
                                ModelName = dtModel.Rows[0]["Model"].ToString();
                            }
                            catch { }
                        }
                        //----------- GET Model Name -------------

                        string SQLInsert = @"INSERT INTO FG_ReportProductOut (dataSet,dataDate,dataShift,
                                                dataLine,dataModelCode,dataModel,SerialNo,ReportBy,
                                                ReportDate,OutType,OutTo,OutDetail,Remark1,Remark2,Remark3)
                                                  VALUES (@dataSet,@dataDate,@dataShift,@dataLine,
                                                @dataModelCode,@dataModel,@SerialNo,@ReportBy,@ReportDate,
                                                @OutType,@OutTo,@OutDetail,@Remark1,@Remark2,@Remark3) ";
                        SqlCommand cmdInsert = new SqlCommand();
                        cmdInsert.CommandText = SQLInsert;
                        cmdInsert.CommandTimeout = 180;
                        cmdInsert.Parameters.Add(new SqlParameter("@dataSet", DateTime.Now.ToString("yyyyMMddHHmm")));
                        cmdInsert.Parameters.Add(new SqlParameter("@dataDate", DateTime.Now.ToString("yyyy-MM-dd")));
                        cmdInsert.Parameters.Add(new SqlParameter("@dataShift", Shift));
                        cmdInsert.Parameters.Add(new SqlParameter("@dataLine", _Line));
                        cmdInsert.Parameters.Add(new SqlParameter("@dataModelCode", _DataModelNo));
                        cmdInsert.Parameters.Add(new SqlParameter("@dataModel", ModelName));
                        cmdInsert.Parameters.Add(new SqlParameter("@SerialNo", _SerialNo));
                        cmdInsert.Parameters.Add(new SqlParameter("@ReportBy", _EmpCode));
                        cmdInsert.Parameters.Add(new SqlParameter("@ReportDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                        cmdInsert.Parameters.Add(new SqlParameter("@OutType", "COMPRESSOR_OUT"));
                        cmdInsert.Parameters.Add(new SqlParameter("@OutTo", txtOutTo.Text.Trim()));
                        cmdInsert.Parameters.Add(new SqlParameter("@OutDetail", txtRemark.Text.Trim()));
                        cmdInsert.Parameters.Add(new SqlParameter("@Remark1", ""));
                        cmdInsert.Parameters.Add(new SqlParameter("@Remark2", ""));
                        cmdInsert.Parameters.Add(new SqlParameter("@Remark3", ""));
                        oConIoT.ExecuteCommand(cmdInsert);



                        rptData.DataSource = null;
                        rptData.DataBind();

                        txtSerialNo.Text = "";
                        DataTable dt = GetDataHistory(_SerialNo);

                        rptData.DataSource = dt;
                        rptData.DataBind();

                        btnTransfer.Enabled = false;
                        btnReset.Enabled = true;


                    }
                    else
                    {
                        lblError.Text = "มีข้อมูล Serial นี้ในระบบอยู่แล้ว";
                    }
                }
                else
                {
                    lblError.Text = "ไม่พบข้อมูลของ หมายเลข Serial ในระบบ Label Printing";
                }

            } // check cost center
            else
            {
                lblError.Text = "กรุณาระบบข้อมูล Cost Center";
            }
        }// end if check
        else {
            lblError.Text = "กรุณาระบบหมายเลข Serial ที่ถูกต้อง";
        }

        btnReset.Enabled = true;
    }


    private DataTable GetDataHistory(string PrdSerial)
    {

        DataTable dtDataList = new DataTable();

        if (PrdSerial.Trim().Length >= 11)
        {
            lblError.Text = "";
            string _Line = "0";

            DataTable dtLabel = new DataTable();
            string strLabel = @"SELECT PrdDate, LocalDate, Model, ModelCode, Temp, PipeNo, SerialNumber 
                 FROM PD_LabelLine4 
                 WHERE SerialNumber=@SerialNumber ";
            SqlCommand cmdLabel = new SqlCommand();
            cmdLabel.CommandText = strLabel;
            cmdLabel.CommandTimeout = 180;
            cmdLabel.Parameters.Add(new SqlParameter("SerialNumber", PrdSerial.Trim()));
            dtLabel = oConDCI.Query(cmdLabel);

            if (dtLabel.Rows.Count > 0)
            {
                _Line = "4";
            }

            if (_Line != "0")
            {
                lblTitle.Text = "List ข้อมูล Line "+ _Line + ":";

                string strQuery = @"SELECT Nbr,dataSet,dataDate,dataShift,dataLine,
                                    dataModelCode,dataModel,SerialNo,ReportBy,ReportDate,
                                    OutType,OutTo,OutDetail,Remark1,Remark2,Remark3,
                                    CONCAT([dataModelCode],' : ',[dataModel]) AS Model 
                                FROM FG_ReportProductOut 
                                WHERE dataLine=@dataLine 
                                ORDER BY dataDate DESC ";
                SqlCommand cmdQuery = new SqlCommand();
                cmdQuery.CommandText = strQuery;
                cmdQuery.CommandTimeout = 180;
                cmdQuery.Parameters.Add(new SqlParameter("@dataLine", _Line));
                dtDataList = oConIoT.Query(cmdQuery);
            }
            else
            {
                lblTitle.Text = "List ข้อมูล :";
                lblError.Text = "ไม่พบข้อมูลของ หมายเลข Serial ในระบบ Label Printing.";
            }
        } // end if
        else {
            lblError.Text = "Serial number is invalid.";
        }

        return dtDataList;
    }
   
    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        txtSerialNo.Text = "";
        txtOutTo.Text = "";
        txtRemark.Text = "";

        btnTransfer.Enabled = false;
        btnReset.Enabled = true;

        rptData.DataSource = null;
        rptData.DataBind();
    }

    


}