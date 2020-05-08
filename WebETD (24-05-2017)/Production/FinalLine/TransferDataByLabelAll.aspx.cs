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

public partial class Production_FinalLine_TransferDataByLabelAll : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    ConnectDBFac3 oConFac3IoT = new ConnectDBFac3();
    ConnectDBSCM oConnSCM = new ConnectDBSCM();
    ProductionService oPrdSrv = new ProductionService();
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


    public string GetProcessData(string PrdSerial)
    {
        //*********************************
        //         Line Master
        //*********************************
        string LineMstr = "SCROLL FINAL";
        //case "1": LineMstr = "1YC FINAL"; break;
        //case "2": LineMstr = "1YC FINAL"; break;
        //case "3": LineMstr = "2YC FINAL"; break;
        //case "4": LineMstr = "SCROLL FINAL"; break;
        //case "5": LineMstr = "2YC FINAL"; break;
        //case "6": LineMstr = "1YC/3 FINAL"; break;


        DataTable dtLineMstr = new DataTable();
        string StrLineMstr = @"SELECT ProcessCode, ProcessName FROM PD_Hold_Mstr WHERE Line=@Line ORDER BY ProcessOrder ASC ";
        SqlCommand cmdLineMstr = new SqlCommand();
        cmdLineMstr.CommandText = StrLineMstr;
        cmdLineMstr.CommandTimeout = 180;
        cmdLineMstr.Parameters.Add(new SqlParameter("@Line", LineMstr));
        dtLineMstr = oConDCI.Query(cmdLineMstr);
        //*********************************


        string _html = "<table  width='50%' class='tbl'>";
        _html += "<thead><tr>";
        if (dtLineMstr.Rows.Count > 0)
        {
            foreach (DataRow drMstr in dtLineMstr.Rows)
            {
                _html += "<th align='center'>" + drMstr["ProcessName"].ToString() + "</th>";
            }
        }
        _html += "</tr></thead>";
        _html += "<tbody>";

        DataTable dtHead = new DataTable();
        SqlCommand sql = new SqlCommand();
        string strSQL = @"SELECT HoldNbr, LotUnholdNbr, LotNbr, prd_serial, prd_line, prd_model_code, 
                    prd_model, pl_no, prd_pipe_no, HoldBy, HoldDate, prd_status, RequestBy, 
                    RequestDate, AllowBy, AllowDate, remark1, remark2, remark3 
            FROM PD_Hold 
            WHERE prd_serial=@prd_serial 
            ORDER BY HoldDate DESC ";
        sql.CommandText = strSQL;
        sql.Parameters.Add(new SqlParameter("@prd_serial", PrdSerial));
        dtHead = oConDCI.Query(sql);

        if (dtHead.Rows.Count > 0)
        {
            foreach (DataRow drHead in dtHead.Rows)
            {
                _html += "<tr>";

                //******** LineOut Detial ********
                foreach (DataRow drMstr in dtLineMstr.Rows)
                {
                    DataTable dtLineDet = new DataTable();
                    string StrLineDet = @"SELECT ProcessStatus,ProcessDate,UpdateBy,UpdateDate 
                        FROM PD_Hold_Detail 
                        WHERE HoldNbr=@HoldNbr AND ProcessCode=@ProcessCode ";
                    SqlCommand cmdLineDet = new SqlCommand();
                    cmdLineDet.CommandText = StrLineDet;
                    cmdLineDet.CommandTimeout = 180;
                    cmdLineDet.Parameters.Add(new SqlParameter("@HoldNbr", drHead["HoldNbr"].ToString()));
                    cmdLineDet.Parameters.Add(new SqlParameter("@ProcessCode", drMstr["ProcessCode"].ToString()));
                    dtLineDet = oConDCI.Query(cmdLineDet);
                    if (dtLineDet.Rows.Count > 0)
                    {
                        _html += "<td align='center'>" + dtLineDet.Rows[0]["ProcessStatus"].ToString() + "</td>";
                    }
                    else
                    {
                        _html += "<td></td>";
                    }
                }
                //******** LineOut Detial ********
                _html += "</tr>";
            }
        }

        _html += "</tbody></table>";


        return _html;

    }



   


    protected void txtSerialOld_TextChanged(object sender, EventArgs e)
    {
        TableDataOld.Text = "";

        if (txtSerialOld.Text.Trim().Length >= 11)
        {
            TableDataOld.Text = GetProcessData(txtSerialOld.Text.Trim());

            btnTransfer.Enabled = true;
            btnReset.Enabled = true;
        }
        else
        {
            btnTransfer.Enabled = false;
            btnReset.Enabled = true;
        }
    }

    protected void txtSerialNew_TextChanged(object sender, EventArgs e)
    {
        TableDataNew.Text = "";

        if (txtSerialNew.Text.Trim().Length >= 11)
        {
            TableDataNew.Text = GetProcessData(txtSerialNew.Text.Trim());
            
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

        if (txtSerialNew.Text.Trim().Length >= 11 && txtSerialOld.Text.Trim().Length >= 11) {


            DataTable dtHead = new DataTable();
            SqlCommand sql = new SqlCommand();
            string strSQL = @"SELECT HoldNbr, LotUnholdNbr, LotNbr, prd_serial, prd_line, prd_model_code, 
                    prd_model, pl_no, prd_pipe_no, HoldBy, HoldDate, prd_status, RequestBy, 
                    RequestDate, AllowBy, AllowDate, Location, remark1, remark2, remark3
            FROM PD_Hold 
            WHERE prd_serial=@prd_serial 
            ORDER BY HoldDate DESC ";
            sql.CommandText = strSQL;
            sql.Parameters.Add(new SqlParameter("@prd_serial", txtSerialOld.Text.Trim()));
            dtHead = oConDCI.Query(sql);
            
            

            if (dtHead.Rows.Count > 0)
            {
                if (isCanTransferLabel(txtSerialOld.Text.Trim()))
                {

                    foreach (DataRow drHead in dtHead.Rows)
                    {

                        string HoldNbr = oPrdSrv.GetRunningNumber("HOLD_HEAD");
                        string StrInsert = @"INSERT INTO PD_Hold (HoldNbr,LotUnholdNbr,LotNbr,prd_serial,
                    prd_line,prd_model_code,prd_model,pl_no,prd_pipe_no,HoldBy,HoldDate,prd_status,
                    RequestBy,RequestDate,AllowBy,AllowDate,Location,remark1,remark2,remark3) VALUES 
                    (@HoldNbr, @LotUnholdNbr, @LotNbr, @prd_serial, @prd_line, @prd_model_code, 
                    @prd_model, @pl_no, @prd_pipe_no, @HoldBy, @HoldDate, @prd_status, @RequestBy, 
                    @RequestDate, @AllowBy, @AllowDate,@Location, @remark1, @remark2, @remark3) ";
                        SqlCommand cmdInsert = new SqlCommand();
                        cmdInsert.CommandText = StrInsert;
                        cmdInsert.CommandTimeout = 180;
                        cmdInsert.Parameters.Add(new SqlParameter("@HoldNbr", HoldNbr));
                        cmdInsert.Parameters.Add(new SqlParameter("@LotUnholdNbr", drHead["LotUnholdNbr"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@LotNbr", drHead["LotNbr"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@prd_serial", txtSerialNew.Text.Trim()));
                        cmdInsert.Parameters.Add(new SqlParameter("@prd_line", drHead["prd_line"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@prd_model_code", drHead["prd_model_code"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@prd_model", drHead["prd_model"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@pl_no", drHead["pl_no"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@prd_pipe_no", drHead["prd_pipe_no"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@HoldBy", drHead["HoldBy"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@HoldDate", drHead["HoldDate"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@prd_status", drHead["prd_status"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@RequestBy", drHead["RequestBy"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@RequestDate", drHead["RequestDate"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@AllowBy", drHead["AllowBy"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@AllowDate", drHead["AllowDate"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@Location", drHead["Location"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@remark1", drHead["remark1"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@remark2", drHead["remark2"].ToString()));
                        cmdInsert.Parameters.Add(new SqlParameter("@remark3", drHead["remark3"].ToString()));
                        oConDCI.ExecuteCommand(cmdInsert);


                        //************** Hold Detail *****************
                        DataTable dtLineDet = new DataTable();
                        string StrLineDet = @"SELECT Nbr, HoldNbr, ProcessCode, ProcessStatus, 
                            ProcessDate, UpdateBy, UpdateDate, remark1, remark2, remark3  
                        FROM PD_Hold_Detail 
                        WHERE HoldNbr=@HoldNbr ";
                        SqlCommand cmdLineDet = new SqlCommand();
                        cmdLineDet.CommandText = StrLineDet;
                        cmdLineDet.CommandTimeout = 180;
                        cmdLineDet.Parameters.Add(new SqlParameter("@HoldNbr", drHead["HoldNbr"].ToString()));
                        dtLineDet = oConDCI.Query(cmdLineDet);
                        //******** LineOut Detial ********
                        foreach (DataRow drDet in dtLineDet.Rows)
                        {

                            string Nbr = oPrdSrv.GetRunningNumber("HOLD_DETAIL");
                            string StrInsertDet = @"INSERT INTO PD_Hold_Detail (Nbr,HoldNbr,ProcessCode,
                            ProcessStatus,ProcessDate,UpdateBy,UpdateDate,remark1,remark2,remark3) VALUES 
                            (@Nbr,@HoldNbr,@ProcessCode,@ProcessStatus,@ProcessDate,@UpdateBy,
                            @UpdateDate,@remark1,@remark2,@remark3)  ";
                            SqlCommand cmdInsertDet = new SqlCommand();
                            cmdInsertDet.CommandText = StrInsertDet;
                            cmdInsertDet.CommandTimeout = 180;
                            cmdInsertDet.Parameters.Add(new SqlParameter("@Nbr", Nbr));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@HoldNbr", HoldNbr));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@ProcessCode", drDet["ProcessCode"].ToString()));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@ProcessStatus", drDet["ProcessStatus"].ToString()));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@ProcessDate", drDet["ProcessDate"].ToString()));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@UpdateBy", drDet["UpdateBy"].ToString()));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@UpdateDate", drDet["UpdateDate"].ToString()));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@remark1", drDet["remark1"].ToString()));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@remark2", drDet["remark2"].ToString()));
                            cmdInsertDet.Parameters.Add(new SqlParameter("@remark3", drDet["remark3"].ToString()));
                            oConDCI.ExecuteCommand(cmdInsertDet);
                        } // end foreach detail

                        try
                        {
                            string StrUpdateHeadOld = "UPDATE  PD_Hold SET prd_status = @prd_status WHERE HoldNbr = @HoldNbr ";
                            SqlCommand cmdUpdateHeadOld = new SqlCommand();
                            cmdUpdateHeadOld.CommandText = StrUpdateHeadOld;
                            cmdUpdateHeadOld.CommandTimeout = 180;
                            cmdUpdateHeadOld.Parameters.Add(new SqlParameter("@prd_status", "RELABEL"));
                            cmdUpdateHeadOld.Parameters.Add(new SqlParameter("@HoldNbr", drHead["HoldNbr"].ToString()));
                            oConDCI.ExecuteCommand(cmdUpdateHeadOld);
                        }
                        catch { }


                    } // end foreach head


                    // Reload Data 
                    TableDataNew.Text = GetProcessData(txtSerialNew.Text.Trim());

                }
                else {
                    lblError.Text = "Serial นี้ถูก Packing ไปแล้วไม่สามารถทำการโอนถ่ายข้อมูลได้";
                }
            }
            else
            {
                lblError.Text = "ไม่พบข้อมูลที่จะทำการโอนถ่ายข้อมูล";
            }

            
        }// end if check
        else {
            lblError.Text = "กรุณาระบบหมายเลข Serial ที่ถูกต้อง";
        }


        btnTransfer.Enabled = false;
        btnReset.Enabled = true;

    }

    public bool isCanTransferLabel(string PrdSerial)
    {
        bool isCanTransferLabel = false;
        DataTable dtPrd = new DataTable();
        string strPrd = "SELECT COUNT(prd_serial) AS COUNTS FROM PD_PackPrd WHERE prd_serial=@prd_serial ";
        SqlCommand cmdPrd = new SqlCommand();
        cmdPrd.CommandText = strPrd;
        cmdPrd.CommandTimeout = 180;
        cmdPrd.Parameters.Add(new SqlParameter("@prd_serial", PrdSerial));
        dtPrd = oConDCI.Query(cmdPrd);

        try
        {
            if (Convert.ToInt16(dtPrd.Rows[0]["COUNTS"].ToString()) == 0) { isCanTransferLabel = true; }
        }
        catch { isCanTransferLabel = false; }

        return isCanTransferLabel;
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        txtSerialOld.Text = "";
        txtSerialNew.Text = "";

        btnTransfer.Enabled = false;
        btnReset.Enabled = true;

        txtSerialOld.Focus();
    }



}