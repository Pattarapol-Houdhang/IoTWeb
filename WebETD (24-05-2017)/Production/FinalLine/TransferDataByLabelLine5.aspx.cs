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

public partial class Production_FinalLine_TransferDataByLabelLine5 : System.Web.UI.Page
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


    public string GetProcessData(string PrdSerial)
    {
        //*********************************
        //         Line Master
        //*********************************
        string LineMstr = "2YC FINAL";
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


    protected void rptSerialNew_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltrOil = (Literal)e.Item.FindControl("ltrOil") as Literal;
            Literal ltrRun = (Literal)e.Item.FindControl("ltrRun") as Literal;
            Literal ltrLow = (Literal)e.Item.FindControl("ltrLow") as Literal;
            Literal ltrApp = (Literal)e.Item.FindControl("ltrApp") as Literal;
            Literal ltrWeight = (Literal)e.Item.FindControl("ltrWeight") as Literal;


        }
    }

    protected void rptSerialOld_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltrOil = (Literal)e.Item.FindControl("ltrOil") as Literal;
            Literal ltrRun = (Literal)e.Item.FindControl("ltrRun") as Literal;
            Literal ltrLow = (Literal)e.Item.FindControl("ltrLow") as Literal;
            Literal ltrApp = (Literal)e.Item.FindControl("ltrApp") as Literal;
            Literal ltrWeight = (Literal)e.Item.FindControl("ltrWeight") as Literal;


        }
    }



    protected void txtSerialOld_TextChanged(object sender, EventArgs e)
    {
        rptSerialOld.DataSource = null;
        rptSerialOld.DataBind();

        if (txtSerialOld.Text.Trim().Length >= 15)
        {
            DataTable dt = GetDataHistory(txtSerialOld.Text.Trim().Substring(0, 15).ToUpper());

            rptSerialOld.DataSource = dt;
            rptSerialOld.DataBind();


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
        rptSerialNew.DataSource = null;
        rptSerialNew.DataBind();

        if (txtSerialNew.Text.Trim().Length >= 15)
        {
            DataTable dt = GetDataHistory(txtSerialNew.Text.Trim().Substring(0, 15).ToUpper());

            rptSerialNew.DataSource = dt;
            rptSerialNew.DataBind();

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

        if (txtSerialNew.Text.Trim().Length >= 15 && txtSerialOld.Text.Trim().Length >= 15) {


            if (rptSerialOld.Items.Count > 0)
            {
                if (isCanTransferLabel(txtSerialOld.Text.Trim().Substring(0, 15)))
                {
                    string _SerialNew = "";
                    string _SerialOld = "";

                    _SerialNew = txtSerialNew.Text.Trim();
                    //string _YearNew = _SerialNew.Substring(1, 1);
                    //string _MonthNew = _SerialNew.Substring(2, 1);
                    string _DataModelNew = _SerialNew.Substring(3, 4);
                    //string _DataYearNew = DateTime.Now.Year.ToString().Substring(0, 3) + _YearNew;

                    _SerialOld = txtSerialOld.Text.Trim();
                    //string _YearOld = _SerialOld.Substring(1, 1);
                    //string _MonthOld = _SerialOld.Substring(2, 1);
                    string _DataModelOld = _SerialOld.Substring(3, 4);
                    //string _DataYearOld = DateTime.Now.Year.ToString().Substring(0, 3) + _YearOld;


                    //----- Check Same Model ------
                    if (_DataModelNew == _DataModelOld)
                    {

                        string PipeNew = GetPipeNo(_SerialNew);
                        string PipeOld = GetPipeNo(_SerialOld);
                        //----- Check Pipe No ------
                        if (PipeNew == PipeOld)
                        {

                            #region Oil Charge
                            //************* Oil Charge Data History List ****************
                            DataTable dtOil = new DataTable();
                        string SQLOil = @"SELECT L5O_ID, SerialNo, ModelNo, ModelName, BeforeWeight, 
                            AfterWeight, OilChargeValue, Judgement, InsertDate, MFGDate
                        FROM Line5_OilCharge 
                        WHERE SerialNo=@SerialNo 
                        ORDER BY MFGDate DESC ";
                        SqlCommand cmdOil = new SqlCommand();
                        cmdOil.CommandText = SQLOil;
                        cmdOil.CommandTimeout = 180;
                        cmdOil.Parameters.Add(new SqlParameter("SerialNo", _SerialOld));
                        dtOil = oConIoT.Query(cmdOil);

                        if (dtOil.Rows.Count > 0)
                        {
                            foreach (DataRow drOil in dtOil.Rows)
                            {
                                try
                                {
                                    string SQLInsert = @"INSERT INTO Line5_OilCharge (SerialNo, ModelNo, 
                                    ModelName, BeforeWeight, AfterWeight, OilChargeValue, Judgement, 
                                    InsertDate, MFGDate) VALUES (@SerialNo, @ModelNo, @ModelName, 
                                    @BeforeWeight, @AfterWeight, @OilChargeValue, @Judgement, 
                                    @InsertDate, @MFGDate) ";
                                    SqlCommand cmdInsert = new SqlCommand();
                                    cmdInsert.CommandText = SQLInsert;
                                    cmdInsert.CommandTimeout = 180;
                                    cmdInsert.Parameters.Add(new SqlParameter("@SerialNo", _SerialNew));
                                    cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", drOil["ModelNo"].ToString()));
                                    cmdInsert.Parameters.Add(new SqlParameter("@ModelName", drOil["ModelName"].ToString()));
                                    cmdInsert.Parameters.Add(new SqlParameter("@BeforeWeight", drOil["BeforeWeight"].ToString()));
                                    cmdInsert.Parameters.Add(new SqlParameter("@AfterWeight", drOil["AfterWeight"].ToString()));
                                    cmdInsert.Parameters.Add(new SqlParameter("@OilChargeValue", drOil["OilChargeValue"].ToString()));
                                    cmdInsert.Parameters.Add(new SqlParameter("@Judgement", drOil["Judgement"].ToString()));
                                    cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", drOil["InsertDate"].ToString()));
                                    cmdInsert.Parameters.Add(new SqlParameter("@MFGDate", drOil["MFGDate"].ToString()));
                                    oConIoT.ExecuteCommand(cmdInsert);
                                }
                                catch { }



                                //******************************************
                                //            Insert Log Data
                                //******************************************
                                try
                                {
                                    string SQLLog = "INSERT INTO FN_ManualDataLog (DateShift, ModelNo, " +
                                        " MachineNo, PartSerialNo, DataProcess, DataValue1, DataValue2, " +
                                        " DataValue3, DataValue4, DataValue5, DataValue6, DataValue7, " +
                                        " DataValue8, DataValue9, DataValue10, DataValue11, DataValue12, " +
                                        " DataValue13, DataValue14, DataValue15, IntegratedJudgementResult, " +
                                        " InsertBy, InsertDate) VALUES (@DateShift, @ModelNo, @MachineNo, " +
                                        " @PartSerialNo, @DataProcess, @DataValue1, @DataValue2, @DataValue3, " +
                                        " @DataValue4, @DataValue5, @DataValue6, @DataValue7, @DataValue8, " +
                                        " @DataValue9, @DataValue10, @DataValue11, @DataValue12, @DataValue13, " +
                                        " @DataValue14, @DataValue15, @IntegratedJudgementResult, @InsertBy, @InsertDate) ";
                                    SqlCommand cmdLog = new SqlCommand();
                                    cmdLog.CommandText = SQLLog;
                                    cmdLog.CommandTimeout = 180;
                                    cmdLog.Parameters.Add(new SqlParameter("@DateShift", drOil["InsertDate"].ToString()));
                                    cmdLog.Parameters.Add(new SqlParameter("@ModelNo", drOil["ModelNo"].ToString()));
                                    cmdLog.Parameters.Add(new SqlParameter("@MachineNo", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataProcess", "TRANSFER_OIL_CHARGE"));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue1", _SerialNew));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue2", _SerialOld));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue3", drOil["BeforeWeight"].ToString()));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue4", drOil["AfterWeight"].ToString()));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue5", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue6", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue7", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue8", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue9", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue10", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue11", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue12", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue13", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue14", "LINE 5"));
                                    cmdLog.Parameters.Add(new SqlParameter("@DataValue15", ""));
                                    cmdLog.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drOil["Judgement"].ToString()));
                                    cmdLog.Parameters.Add(new SqlParameter("@InsertBy", _EmpCode));
                                    cmdLog.Parameters.Add(new SqlParameter("@InsertDate", DateTime.Now));
                                    oConFac3IoT.ExecuteCommand(cmdLog);
                                }
                                catch { }
                                //******************************************
                                //        End Insert Log Data
                                //******************************************
                            }
                        }
                        #endregion


                            #region Running Test
                            //***************** Check Running Test Data **********************
                            DataTable dtRunTest = new DataTable();
                            string StrRunTest = @"SELECT L52YC_ID, SerialNo, MachineNo, ModelNo, ModelName, 
                                CurrentLower, CurrentValue, CurrentUpper, VacuumLower, Vacuum, VacuumUpper, 
                                Leak, LeakUpper, FrequencyJudgement, RunningJudgement, VacuumCapJudgement, 
                                VacuumLeakJudgement, TotalJudgement, InsertDate, MFGDate
                            FROM Line5_RunningTest 
                            WHERE (SerialNo = @SerialNo)  
                            ORDER BY MFGDate DESC ";
                            SqlCommand cmdRunTest = new SqlCommand();
                            cmdRunTest.CommandText = StrRunTest;
                            cmdRunTest.CommandTimeout = 180;
                            cmdRunTest.Parameters.Add(new SqlParameter("SerialNo", _SerialOld));
                            dtRunTest = oConIoT.Query(cmdRunTest);
                            //***************** End Check Running Test Data **********************
                            if (dtRunTest.Rows.Count > 0)
                            {
                                foreach (DataRow drRunTest in dtRunTest.Rows)
                                {
                                    try
                                    {
                                        string SQLInsert = @"INSERT INTO Line5_RunningTest 
                                        (SerialNo, MachineNo, ModelNo, ModelName, CurrentLower, CurrentValue, 
                                        CurrentUpper, VacuumLower, Vacuum, VacuumUpper, Leak, LeakUpper, 
                                        FrequencyJudgement, RunningJudgement, VacuumCapJudgement, 
                                        VacuumLeakJudgement, TotalJudgement, InsertDate, MFGDate) 
                                        VALUES (@SerialNo, @MachineNo, @ModelNo, @ModelName, @CurrentLower, 
                                        @CurrentValue, @CurrentUpper, @VacuumLower, @Vacuum, @VacuumUpper, 
                                        @Leak, @LeakUpper, @FrequencyJudgement, @RunningJudgement, 
                                        @VacuumCapJudgement, @VacuumLeakJudgement, @TotalJudgement, 
                                        @InsertDate, @MFGDate) ";
                                        SqlCommand cmdInsert = new SqlCommand();
                                        cmdInsert.CommandText = SQLInsert;
                                        cmdInsert.CommandTimeout = 180;
                                        cmdInsert.Parameters.Add(new SqlParameter("@SerialNo", _SerialNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MachineNo", drRunTest["MachineNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", drRunTest["ModelNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelName", drRunTest["ModelName"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CurrentLower", drRunTest["CurrentLower"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CurrentValue", drRunTest["CurrentValue"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CurrentUpper", drRunTest["CurrentUpper"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@VacuumLower", drRunTest["VacuumLower"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@Vacuum", drRunTest["Vacuum"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@VacuumUpper", drRunTest["VacuumUpper"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@Leak", drRunTest["Leak"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@LeakUpper", drRunTest["LeakUpper"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@FrequencyJudgement", drRunTest["FrequencyJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@RunningJudgement", drRunTest["RunningJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@VacuumCapJudgement", drRunTest["VacuumCapJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@VacuumLeakJudgement", drRunTest["VacuumLeakJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@TotalJudgement", drRunTest["TotalJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", drRunTest["InsertDate"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MFGDate", drRunTest["MFGDate"].ToString()));
                                        oConIoT.ExecuteCommand(cmdInsert);
                                    }
                                    catch { }


                                    //******************************************
                                    //            Insert Log Data
                                    //******************************************
                                    try
                                    {
                                        string SQLLog = "INSERT INTO FN_ManualDataLog (DateShift, ModelNo, " +
                                            " MachineNo, PartSerialNo, DataProcess, DataValue1, DataValue2, " +
                                            " DataValue3, DataValue4, DataValue5, DataValue6, DataValue7, " +
                                            " DataValue8, DataValue9, DataValue10, DataValue11, DataValue12, " +
                                            " DataValue13, DataValue14, DataValue15, IntegratedJudgementResult, " +
                                            " InsertBy, InsertDate) VALUES (@DateShift, @ModelNo, @MachineNo, " +
                                            " @PartSerialNo, @DataProcess, @DataValue1, @DataValue2, @DataValue3, " +
                                            " @DataValue4, @DataValue5, @DataValue6, @DataValue7, @DataValue8, " +
                                            " @DataValue9, @DataValue10, @DataValue11, @DataValue12, @DataValue13, " +
                                            " @DataValue14, @DataValue15, @IntegratedJudgementResult, @InsertBy, @InsertDate) ";
                                        SqlCommand cmdLog = new SqlCommand();
                                        cmdLog.CommandText = SQLLog;
                                        cmdLog.CommandTimeout = 180;
                                        cmdLog.Parameters.Add(new SqlParameter("@DateShift", drRunTest["InsertDate"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@ModelNo", drRunTest["ModelNo"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@MachineNo", drRunTest["MachineNo"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataProcess", "TRANSFER_RUNNING_TEST"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue1", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue2", _SerialOld));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue3", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue4", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue5", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue6", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue7", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue8", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue9", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue10", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue11", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue12", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue13", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue14", "LINE 5"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue15", drRunTest["RunningJudgement"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drRunTest["TotalJudgement"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@InsertBy", _EmpCode));
                                        cmdLog.Parameters.Add(new SqlParameter("@InsertDate", DateTime.Now));
                                        oConFac3IoT.ExecuteCommand(cmdLog);
                                    }
                                    catch { }
                                    //******************************************
                                    //        End Insert Log Data
                                    //******************************************

                                }
                            }
                            #endregion


                            #region High Voltage
                            //***************** Check Low Voltage Data **********************
                            DataTable dtLowVoltage = new DataTable();
                            string StrLowVoltage = @"SELECT L5HV_ID, SerialNo, ModelNo, ModelName, 
                                MOhmTestJudgement, HVTestJudgement, MagTestJudgement, 
                                OhmTest2ndJudgement, TotalJudgement, InsertDate, MFGDate
                            FROM Line5_HVTest 
                            WHERE SerialNo=@SerialNo 
                            ORDER BY InsertDate DESC ";
                            SqlCommand cmdLowVoltage = new SqlCommand();
                            cmdLowVoltage.CommandText = StrLowVoltage;
                            cmdLowVoltage.CommandTimeout = 180;
                            cmdLowVoltage.Parameters.Add(new SqlParameter("SerialNo", _SerialOld));
                            dtLowVoltage = oConIoT.Query(cmdLowVoltage);
                            //***************** End Check Low Voltage Data **********************
                            if (dtLowVoltage.Rows.Count > 0)
                            {
                                foreach (DataRow drLowVoltage in dtLowVoltage.Rows)
                                {
                                    try
                                    {
                                        string SQLInsert = @"INSERT INTO Line5_HVTest (SerialNo, 
                                        ModelNo, ModelName, MOhmTestJudgement, HVTestJudgement, 
                                        MagTestJudgement, OhmTest2ndJudgement, TotalJudgement, 
                                        InsertDate, MFGDate) VALUES (@SerialNo, @ModelNo, @ModelName, 
                                        @MOhmTestJudgement, @HVTestJudgement, @MagTestJudgement, 
                                        @OhmTest2ndJudgement, @TotalJudgement, @InsertDate, @MFGDate) ";
                                        SqlCommand cmdInsert = new SqlCommand();
                                        cmdInsert.CommandText = SQLInsert;
                                        cmdInsert.CommandTimeout = 180;
                                        cmdInsert.Parameters.Add(new SqlParameter("@SerialNo", _SerialNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", drLowVoltage["ModelNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MOhmTestJudgement", drLowVoltage["MOhmTestJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelName", drLowVoltage["ModelName"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@HVTestJudgement", drLowVoltage["HVTestJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MagTestJudgement", drLowVoltage["MagTestJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@OhmTest2ndJudgement", drLowVoltage["OhmTest2ndJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@TotalJudgement", drLowVoltage["TotalJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", drLowVoltage["InsertDate"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MFGDate", drLowVoltage["MFGDate"].ToString()));
                                        oConIoT.ExecuteCommand(cmdInsert);
                                    }
                                    catch { }



                                    //******************************************
                                    //            Insert Log Data
                                    //******************************************
                                    try
                                    {
                                        string SQLLog = "INSERT INTO FN_ManualDataLog (DateShift, ModelNo, " +
                                            " MachineNo, PartSerialNo, DataProcess, DataValue1, DataValue2, " +
                                            " DataValue3, DataValue4, DataValue5, DataValue6, DataValue7, " +
                                            " DataValue8, DataValue9, DataValue10, DataValue11, DataValue12, " +
                                            " DataValue13, DataValue14, DataValue15, IntegratedJudgementResult, " +
                                            " InsertBy, InsertDate) VALUES (@DateShift, @ModelNo, @MachineNo, " +
                                            " @PartSerialNo, @DataProcess, @DataValue1, @DataValue2, @DataValue3, " +
                                            " @DataValue4, @DataValue5, @DataValue6, @DataValue7, @DataValue8, " +
                                            " @DataValue9, @DataValue10, @DataValue11, @DataValue12, @DataValue13, " +
                                            " @DataValue14, @DataValue15, @IntegratedJudgementResult, @InsertBy, @InsertDate) ";
                                        SqlCommand cmdLog = new SqlCommand();
                                        cmdLog.CommandText = SQLLog;
                                        cmdLog.CommandTimeout = 180;
                                        cmdLog.Parameters.Add(new SqlParameter("@DateShift", drLowVoltage["InsertDate"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@ModelNo", drLowVoltage["ModelNo"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@MachineNo", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataProcess", "TRANSFER_HIGH_VOLTAGE"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue1", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue2", _SerialOld));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue3", drLowVoltage["TotalJudgement"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue4", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue5", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue6", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue7", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue8", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue9", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue10", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue11", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue12", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue13", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue14", "LINE 5"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue15", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drLowVoltage["TotalJudgement"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@InsertBy", _EmpCode));
                                        cmdLog.Parameters.Add(new SqlParameter("@InsertDate", DateTime.Now));
                                        oConFac3IoT.ExecuteCommand(cmdLog);
                                    }
                                    catch { }
                                    //******************************************
                                    //        End Insert Log Data
                                    //******************************************

                                }
                            }
                            #endregion

                        
                            #region Weight Check
                            //***************** Check Weight Check Data **********************
                            DataTable dtWeight = new DataTable();
                            string StrWeight = @"SELECT L5W_ID, SerialNo, ModelNo, ModelName, 
                                WeightCheckJudgement, WeightMeasured, TerminalCover, InsertDate, MFGDate 
                            FROM Line5_WeightCheck 
                            WHERE SerialNo=@SerialNo 
                            ORDER BY InsertDate DESC ";
                            SqlCommand cmdWeight = new SqlCommand();
                            cmdWeight.CommandText = StrWeight;
                            cmdWeight.CommandTimeout = 180;
                            cmdWeight.Parameters.Add(new SqlParameter("SerialNo", _SerialOld));
                            dtWeight = oConIoT.Query(cmdWeight);
                            //***************** End Check Running Test Data **********************
                            if (dtWeight.Rows.Count > 0)
                            {
                                foreach (DataRow drWeight in dtWeight.Rows)
                                {
                                    try
                                    {
                                        string SQLInsert = @"INSERT INTO Line5_WeightCheck (SerialNo, ModelNo, 
                                            ModelName, WeightCheckJudgement, WeightMeasured, TerminalCover, 
                                            InsertDate, MFGDate) VALUES (@SerialNo, @ModelNo, @ModelName, 
                                            @WeightCheckJudgement, @WeightMeasured, @TerminalCover, 
                                            @InsertDate, @MFGDate) ";
                                        SqlCommand cmdInsert = new SqlCommand();
                                        cmdInsert.CommandText = SQLInsert;
                                        cmdInsert.CommandTimeout = 180;
                                        cmdInsert.Parameters.Add(new SqlParameter("@SerialNo", _SerialNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", drWeight["ModelNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelName", drWeight["ModelName"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@WeightCheckJudgement", drWeight["WeightCheckJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@WeightMeasured", drWeight["WeightMeasured"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@TerminalCover", drWeight["TerminalCover"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", drWeight["InsertDate"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MFGDate", drWeight["MFGDate"].ToString()));
                                        oConIoT.ExecuteCommand(cmdInsert);
                                    }
                                    catch { }



                                    //******************************************
                                    //            Insert Log Data
                                    //******************************************
                                    try
                                    {
                                        string SQLLog = "INSERT INTO FN_ManualDataLog (DateShift, ModelNo, " +
                                            " MachineNo, PartSerialNo, DataProcess, DataValue1, DataValue2, " +
                                            " DataValue3, DataValue4, DataValue5, DataValue6, DataValue7, " +
                                            " DataValue8, DataValue9, DataValue10, DataValue11, DataValue12, " +
                                            " DataValue13, DataValue14, DataValue15, IntegratedJudgementResult, " +
                                            " InsertBy, InsertDate) VALUES (@DateShift, @ModelNo, @MachineNo, " +
                                            " @PartSerialNo, @DataProcess, @DataValue1, @DataValue2, @DataValue3, " +
                                            " @DataValue4, @DataValue5, @DataValue6, @DataValue7, @DataValue8, " +
                                            " @DataValue9, @DataValue10, @DataValue11, @DataValue12, @DataValue13, " +
                                            " @DataValue14, @DataValue15, @IntegratedJudgementResult, @InsertBy, @InsertDate) ";
                                        SqlCommand cmdLog = new SqlCommand();
                                        cmdLog.CommandText = SQLLog;
                                        cmdLog.CommandTimeout = 180;
                                        cmdLog.Parameters.Add(new SqlParameter("@DateShift", drWeight["InsertDate"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@ModelNo", drWeight["ModelNo"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@MachineNo", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataProcess", "TRANSFER_WEIGHT_CHECK"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue1", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue2", _SerialOld));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue3", drWeight["WeightMeasured"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue4", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue5", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue6", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue7", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue8", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue9", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue10", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue11", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue12", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue13", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue14", "LINE 5"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue15", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drWeight["WeightCheckJudgement"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@InsertBy", _EmpCode));
                                        cmdLog.Parameters.Add(new SqlParameter("@InsertDate", DateTime.Now));
                                        oConFac3IoT.ExecuteCommand(cmdLog);
                                    }
                                    catch { }
                                    //******************************************
                                    //        End Insert Log Data
                                    //******************************************

                                }
                            }
                            #endregion


                            #region Copy DataTo FinalLine DataCenter
                            //************* Copy DataTo FinalLine DataCenter ****************
                            DataTable dtCenter = new DataTable();
                            string SQLCenter = @"SELECT Serial, Line, LB_InsertDate, LB_MFGDate, 
                                        OC_Judgement, OC_InsertDate, RT_Station, RT_Judgement, 
                                        RT_InsertDate, HV_Judgement, HV_InsertDate, LW_Judgement, 
                                        LW_InsertDate, N2_Judgement, N2_InsertDate, WC_Judgement, WC_InsertDate,
                                        [AP_Judgement],[AP_InsertDate],[ReLabel_Status],[ReLabel_Serial],[TerminalCover]
                                    FROM FN_DataCenter 
                                    WHERE Serial=@Serial ";
                            SqlCommand cmdCenter = new SqlCommand();
                            cmdCenter.CommandText = SQLCenter;
                            cmdCenter.CommandTimeout = 180;
                            cmdCenter.Parameters.Add(new SqlParameter("Serial", _SerialOld));
                            dtCenter = oConDCI.Query(cmdCenter);

                            if (dtCenter.Rows.Count > 0)
                            {
                                foreach (DataRow drCenter in dtCenter.Rows)
                                {
                                    DataTable dtCenterNew = new DataTable();
                                    string SQLCenterNew = @"SELECT Serial, Line, LB_InsertDate, LB_MFGDate, 
                                        OC_Judgement, OC_InsertDate, RT_Station, RT_Judgement, 
                                        RT_InsertDate, HV_Judgement, HV_InsertDate, LW_Judgement, 
                                        LW_InsertDate, N2_Judgement, N2_InsertDate, WC_Judgement, WC_InsertDateม
                                        [AP_Judgement],[AP_InsertDate],[ReLabel_Status],[ReLabel_Serial],[TerminalCover]
                                    FROM FN_DataCenter 
                                    WHERE Serial=@Serial ";
                                    SqlCommand cmdCenterNew = new SqlCommand();
                                    cmdCenterNew.CommandText = SQLCenterNew;
                                    cmdCenterNew.CommandTimeout = 180;
                                    cmdCenterNew.Parameters.Add(new SqlParameter("Serial", _SerialNew));
                                    dtCenterNew = oConDCI.Query(cmdCenterNew);

                                    if (dtCenterNew.Rows.Count == 0)
                                    {
                                        string strCenterInstr = "INSERT INTO [dbDCI].[dbo].[FN_DataCenter] ([Serial],";
                                        strCenterInstr += " [ModelCode],[PipeNo],[Line],[LB_InsertDate],[LB_MFGDate],[OC_Judgement], ";
                                        strCenterInstr += " [OC_InsertDate],[RT_Station],[RT_Judgement],[RT_InsertDate], ";
                                        strCenterInstr += " [HV_Judgement],[HV_InsertDate],[LW_Judgement],[LW_InsertDate], ";
                                        strCenterInstr += " [N2_Judgement],[N2_InsertDate],[WC_Judgement],[WC_InsertDate], ";
                                        strCenterInstr += " [ReLabel_Status],[ReLabel_Serial],[AP_Judgement],[AP_InsertDate],[TerminalCover]) ";
                                        strCenterInstr += "  SELECT '" + _SerialNew + "', ModelCode,PipeNo, Line, LB_InsertDate, ";
                                        strCenterInstr += "   LB_MFGDate, OC_Judgement, OC_InsertDate, RT_Station, RT_Judgement, ";
                                        strCenterInstr += "   RT_InsertDate, HV_Judgement, HV_InsertDate, LW_Judgement, ";
                                        strCenterInstr += "   LW_InsertDate, N2_Judgement, N2_InsertDate, WC_Judgement, ";
                                        strCenterInstr += "   WC_InsertDate, 're_new', '" + _SerialOld + "',AP_Judgement,AP_InsertDate,TerminalCover FROM [dbDCI].[dbo].[FN_DataCenter] ";
                                        strCenterInstr += "   WHERE Serial=@Serial ";
                                        SqlCommand cmdCenterInstr = new SqlCommand();
                                        cmdCenterInstr.CommandText = strCenterInstr;
                                        cmdCenterInstr.Parameters.Add(new SqlParameter("@Serial", _SerialOld));
                                        oConDCI.ExecuteCommand(cmdCenterInstr);
                                    }
                                    else
                                    {
                                        try
                                        {
                                            string Oil = "";
                                            string Run = "";
                                            string Weight = "";
                                            string App = "";
                                            //------ Oil ------
                                            if (drCenter["OC_Judgement"].ToString() == "OK")
                                            {
                                                Oil = "OK";
                                            }
                                            else {
                                                if (dtCenterNew.Rows[0]["OC_Judgement"].ToString() == "OK")
                                                {
                                                    Oil = "OK";
                                                }
                                                else {
                                                    Oil = drCenter["OC_Judgement"].ToString();
                                                }
                                            }
                                            
                                            //------ RUn ------
                                            if (drCenter["RT_Judgement"].ToString() == "OK")
                                            {
                                                Run = "OK";
                                            }
                                            else
                                            {
                                                if (dtCenterNew.Rows[0]["RT_Judgement"].ToString() == "OK")
                                                {
                                                    Run = "OK";
                                                }
                                                else
                                                {
                                                    Run = drCenter["RT_Judgement"].ToString();
                                                }
                                            }

                                            //------ Weight ------
                                            if (drCenter["WC_Judgement"].ToString() == "OK")
                                            {
                                                Weight = "OK";
                                            }
                                            else
                                            {
                                                if (dtCenterNew.Rows[0]["WC_Judgement"].ToString() == "OK")
                                                {
                                                    Weight = "OK";
                                                }
                                                else
                                                {
                                                    Weight = drCenter["WC_Judgement"].ToString();
                                                }
                                            }

                                            //------ Weight ------
                                            if (drCenter["AP_Judgement"].ToString() == "OK")
                                            {
                                                App = "OK";
                                            }
                                            else
                                            {
                                                if (dtCenterNew.Rows[0]["AP_Judgement"].ToString() == "OK")
                                                {
                                                    App = "OK";
                                                }
                                                else
                                                {
                                                    App = drCenter["AP_Judgement"].ToString();
                                                }
                                            }


                                            string SQLInsert = @"UPDATE FN_DataCenter SET
                                                LB_InsertDate=@LB_InsertDate, LB_MFGDate=@LB_MFGDate, 
                                                OC_Judgement=@OC_Judgement, OC_InsertDate=@OC_InsertDate, 
                                                RT_Station=@RT_Station, RT_Judgement=@RT_Judgement, 
                                                RT_InsertDate=@RT_InsertDate, HV_Judgement=@HV_Judgement, 
                                                HV_InsertDate=@HV_InsertDate, LW_Judgement=@LW_Judgement, 
                                                LW_InsertDate=@LW_InsertDate, N2_Judgement=@N2_Judgement, 
                                                N2_InsertDate=@N2_InsertDate, AP_Judgement=@AP_Judgement, 
                                                AP_InsertDate=@AP_InsertDate, WC_Judgement=@WC_Judgement, 
                                                WC_InsertDate=@WC_InsertDate, [ReLabel_Status]=@ReLabel_Status, 
                                                [ReLabel_Serial]=@ReLabel_Serial,TerminalCover=@TerminalCover
                                                WHERE Serial=@Serial ";
                                            SqlCommand cmdInsert = new SqlCommand();
                                            cmdInsert.CommandText = SQLInsert;
                                            cmdInsert.CommandTimeout = 180;
                                            cmdInsert.Parameters.Add(new SqlParameter("@Serial", _SerialNew));
                                            //cmdInsert.Parameters.Add(new SqlParameter("@Line", drCenter["Line"].ToString()));
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@LB_InsertDate", Convert.ToDateTime(drCenter["LB_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@LB_InsertDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@LB_MFGDate", Convert.ToDateTime(drCenter["LB_MFGDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@LB_MFGDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@OC_Judgement", Oil));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@OC_Judgement", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@OC_InsertDate", Convert.ToDateTime(drCenter["OC_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@OC_InsertDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@RT_Station", drCenter["RT_Station"].ToString()));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@RT_Station", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@RT_Judgement", Run));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@RT_Judgement", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@RT_InsertDate", Convert.ToDateTime(drCenter["RT_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@RT_InsertDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@HV_Judgement", drCenter["HV_Judgement"].ToString()));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@HV_Judgement", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@HV_InsertDate", Convert.ToDateTime(drCenter["HV_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@HV_InsertDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@LW_Judgement", drCenter["LW_Judgement"].ToString()));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@LW_Judgement", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@LW_InsertDate", Convert.ToDateTime(drCenter["LW_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@LW_InsertDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@N2_Judgement", drCenter["N2_Judgement"].ToString()));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@N2_Judgement", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@N2_InsertDate", Convert.ToDateTime(drCenter["N2_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@N2_InsertDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@AP_Judgement", App));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@AP_Judgement", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@AP_InsertDate", Convert.ToDateTime(drCenter["AP_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@AP_InsertDate", DBNull.Value)); }

                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@WC_Judgement", Weight));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@WC_Judgement", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@WC_InsertDate", Convert.ToDateTime(drCenter["WC_InsertDate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@WC_InsertDate", DBNull.Value)); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@ReLabel_Status", "re_new"));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@ReLabel_Status", "re_new")); }
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@ReLabel_Serial", _SerialOld));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@ReLabel_Serial", DBNull.Value)); }
                                            
                                            try
                                            {
                                                cmdInsert.Parameters.Add(new SqlParameter("@TerminalCover", drCenter["TerminalCover"].ToString()));
                                            }
                                            catch { cmdInsert.Parameters.Add(new SqlParameter("@TerminalCover", DBNull.Value)); }

                                            oConDCI.ExecuteCommand(cmdInsert);
                                        }
                                        catch { }
                                    }

                                    //------ update old ------
                                    string strUpOldCenter = "UPDATE [dbDCI].[dbo].[FN_DataCenter] SET ";
                                    strUpOldCenter += "  [ReLabel_Status]=@ReLabel_Status, [ReLabel_Serial]=@ReLabel_Serial ";
                                    strUpOldCenter += " WHERE Serial=@Serial ";
                                    SqlCommand cmdUpOldCenter = new SqlCommand();
                                    cmdUpOldCenter.CommandText = strUpOldCenter;
                                    cmdUpOldCenter.Parameters.Add(new SqlParameter("@ReLabel_Status", "re_old"));
                                    cmdUpOldCenter.Parameters.Add(new SqlParameter("@ReLabel_Serial", _SerialNew));
                                    cmdUpOldCenter.Parameters.Add(new SqlParameter("@Serial", _SerialOld));
                                    oConDCI.ExecuteCommand(cmdUpOldCenter);
                                }
                            }
                            #endregion


                            #region Copy DataTo Backflush
                            //************* Copy DataTo Backflush ****************
                            DataTable dtBackflush = new DataTable();
                            string SQLBackflush = @"SELECT Nbr,dataSet,dataDate,dataShift,dataLine,
                                        dataModelCode,dataModel,SerialNo,ReportBy,ReportDate
                                    FROM FG_ReportBackFlush 
                                    WHERE SerialNo=@SerialNo ";
                            SqlCommand cmdBackflush = new SqlCommand();
                            cmdBackflush.CommandText = SQLBackflush;
                            cmdBackflush.CommandTimeout = 180;
                            cmdBackflush.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld));
                            dtBackflush = oConIoT.Query(cmdBackflush);

                            if (dtBackflush.Rows.Count > 0)
                            {
                                foreach (DataRow drBackflush in dtBackflush.Rows)
                                {
                                    try
                                    {
                                        string strInstBF = " INSERT INTO FG_ReportBackFlush ";
                                        strInstBF += " (dataSet,dataDate,dataShift,dataLine,dataModelCode ";
                                        strInstBF += "  ,dataModel,SerialNo,ReportBy,ReportDate) ";
                                        strInstBF += " SELECT dataSet,dataDate,dataShift,dataLine,dataModelCode ";
                                        strInstBF += "  ,dataModel,'" + _SerialNew.Trim() + "',ReportBy,ReportDate ";
                                        strInstBF += " FROM FG_ReportBackFlush WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdInstBF = new SqlCommand();
                                        cmdInstBF.CommandText = strInstBF;
                                        cmdInstBF.CommandTimeout = 180;
                                        cmdInstBF.Parameters.Add(new SqlParameter("SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdInstBF);
                                    }
                                    catch { }


                                    try
                                    {
                                        string UpdateBF = @"UPDATE FG_ReportBackFlush SET SerialNo=@SerialNew WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdUpdateBF = new SqlCommand();
                                        cmdUpdateBF.CommandText = UpdateBF;
                                        cmdUpdateBF.CommandTimeout = 180;
                                        cmdUpdateBF.Parameters.Add(new SqlParameter("@SerialNew", _SerialOld.Trim() + "_RELABEL"));
                                        cmdUpdateBF.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdUpdateBF);
                                    }
                                    catch { }
                                }
                            }
                            #endregion
                            
                            #region Copy DataTo UpPack
                            //************* Copy DataTo UpPack ****************
                            DataTable dtUpPack = new DataTable();
                            string SQLUpPack = @"SELECT Nbr, SerialNo, InsertDate, Line
                                    FROM FG_Unpack 
                                    WHERE SerialNo=@SerialNo ";
                            SqlCommand cmdUnPack = new SqlCommand();
                            cmdUnPack.CommandText = SQLUpPack;
                            cmdUnPack.CommandTimeout = 180;
                            cmdUnPack.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld));
                            dtUpPack = oConIoT.Query(cmdUnPack);

                            if (dtUpPack.Rows.Count > 0)
                            {
                                foreach (DataRow drUpPack in dtUpPack.Rows)
                                {
                                    try
                                    {
                                        string strInstUnPack = " INSERT INTO FG_Unpack ";
                                        strInstUnPack += " (SerialNo, InsertDate, Line) ";
                                        strInstUnPack += " SELECT '" + _SerialNew.Trim() + "', InsertDate, Line ";
                                        strInstUnPack += " FROM FG_Unpack WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdInstUnPack = new SqlCommand();
                                        cmdInstUnPack.CommandText = strInstUnPack;
                                        cmdInstUnPack.CommandTimeout = 180;
                                        cmdInstUnPack.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdInstUnPack);
                                    }
                                    catch { }

                                    try
                                    {
                                        string UpdateUnPack = @"UPDATE FG_Unpack SET SerialNo=@SerialNew WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdUpdateUnPack = new SqlCommand();
                                        cmdUpdateUnPack.CommandText = UpdateUnPack;
                                        cmdUpdateUnPack.CommandTimeout = 180;
                                        cmdUpdateUnPack.Parameters.Add(new SqlParameter("@SerialNew", _SerialOld.Trim() + "_RELABEL"));
                                        cmdUpdateUnPack.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdUpdateUnPack);
                                    }
                                    catch { }

                                }
                            }
                            #endregion
                            
                            #region Copy DataTo Rework
                            //************* Copy DataTo UpPack ****************
                            DataTable dtRework = new DataTable();
                            string SQLRework = @"SELECT Nbr,dataDate,dataShift,dataLine,
                                        dataModelCode,dataModel,SerialNo,ReportBy,ReportDate
                                    FROM  FG_ReportDefect 
                                    WHERE SerialNo=@SerialNo ";
                            SqlCommand cmdRework = new SqlCommand();
                            cmdRework.CommandText = SQLRework;
                            cmdRework.CommandTimeout = 180;
                            cmdRework.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld));
                            dtRework = oConIoT.Query(cmdRework);

                            if (dtRework.Rows.Count > 0)
                            {
                                foreach (DataRow drRework in dtRework.Rows)
                                {
                                    try
                                    {
                                        string strInstRework = " INSERT INTO FG_ReportDefect ";
                                        strInstRework += " (dataDate,dataShift,dataLine,dataModelCode,dataModel,SerialNo,ReportBy,ReportDate) ";
                                        strInstRework += " SELECT dataDate,dataShift,dataLine,dataModelCode,dataModel,'" + _SerialNew.Trim() + "',ReportBy,ReportDate ";
                                        strInstRework += " FROM FG_Unpack WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdInstRework = new SqlCommand();
                                        cmdInstRework.CommandText = strInstRework;
                                        cmdInstRework.CommandTimeout = 180;
                                        cmdInstRework.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdInstRework);
                                    }
                                    catch { }

                                    try
                                    {
                                        string UpdateRework = @"UPDATE FG_ReportDefect SET SerialNo=@SerialNew WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdUpdateRework = new SqlCommand();
                                        cmdUpdateRework.CommandText = UpdateRework;
                                        cmdUpdateRework.CommandTimeout = 180;
                                        cmdUpdateRework.Parameters.Add(new SqlParameter("@SerialNew", _SerialOld.Trim() + "_RELABEL"));
                                        cmdUpdateRework.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdUpdateRework);
                                    }
                                    catch { }

                                }
                            }
                            #endregion

                            #region Copy Location Zero
                            //************* Copy DataTo UpPack ****************
                            DataTable dtZero = new DataTable();
                            string SQLZero = @"SELECT SerialNo
                                    FROM [FG_LocationZeroHistory] 
                                    WHERE SerialNo=@SerialNo ";
                            SqlCommand cmdZero = new SqlCommand();
                            cmdZero.CommandText = SQLZero;
                            cmdZero.CommandTimeout = 180; 
                            cmdZero.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld));
                            dtZero = oConIoT.Query(cmdZero);

                            if (dtZero.Rows.Count > 0)
                            {
                                foreach (DataRow drZero in dtZero.Rows)
                                {
                                    try
                                    {
                                        string strInstZero = " INSERT INTO FG_LocationZeroHistory ";
                                        strInstZero += " (SerialNo,ModelCode,Model,InsertDate,StampDate,StampShift,Line,StampType) ";
                                        strInstZero += " SELECT '" + _SerialNew.Trim() + "',ModelCode,Model,InsertDate,StampDate,StampShift,Line,StampType ";
                                        strInstZero += " FROM FG_LocationZeroHistory WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdInstZero = new SqlCommand();
                                        cmdInstZero.CommandText = strInstZero;
                                        cmdInstZero.CommandTimeout = 180;
                                        cmdInstZero.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdInstZero);
                                    }
                                    catch { }

                                    try
                                    {
                                        string UpdateZero = @"UPDATE FG_LocationZeroHistory SET SerialNo=@SerialNew WHERE SerialNo=@SerialNo ";
                                        SqlCommand cmdUpdateZero = new SqlCommand();
                                        cmdUpdateZero.CommandText = UpdateZero;
                                        cmdUpdateZero.CommandTimeout = 180;
                                        cmdUpdateZero.Parameters.Add(new SqlParameter("@SerialNew", _SerialOld.Trim() + "_RELABEL"));
                                        cmdUpdateZero.Parameters.Add(new SqlParameter("@SerialNo", _SerialOld.Trim()));
                                        oConIoT.ExecuteCommand(cmdUpdateZero);
                                    }
                                    catch { }

                                }
                            }
                            #endregion


                            #region Update Old Series in Hold Table
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
                                foreach (DataRow drHead in dtHead.Rows)
                                {
                                    if (drHead["prd_status"].ToString() == "HOLD" || drHead["prd_status"].ToString() == "LINEOUT")
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

                                    }// end if check hold
                                } // end foreach head
                            }

                            #endregion

                            #region Copy Data To Appearance By Earth
                            try
                            {

                                DataTable dTable = new DataTable();
                                SqlCommand sqlApp = new SqlCommand();
                                string strSQLApp = @"SELECT  [Detail_ID],[RunningGroupID],[Serial_No],[Model_Name],[Model_Code],[Pipe_No],[LineNO],[Status],[Round]
                                                ,[IoT_Status],[Emp_ID],[Apperance_Judgement],[MasterID],[ApperanceDate],[InsertDate]
                                                FROM [dbIoT].[dbo].[Appearance_Detail]
                                                WHERE Serial_No=@Serial_No";
                                sql.CommandText = strSQLApp;
                                sql.Parameters.Add(new SqlParameter("@Serial_No", txtSerialOld.Text.Trim()));
                                dTable = oConIoT.Query(sql);

                                if (dTable.Rows.Count > 0)
                                {
                                    SqlCommand sqlInIF = new SqlCommand();
                                    sqlInIF.CommandText = @"INSERT INTO [dbIoT].[dbo].[Appearance_Detail]([RunningGroupID],[Serial_No],[Model_Name],[Model_Code],[Pipe_No]
                                                        ,[LineNO],[Status],[Round],[IoT_Status],[Emp_ID],[Apperance_Judgement],[MasterID],[ApperanceDate],[InsertDate])
                                                        (SELECT  [RunningGroupID],@SerialNew,[Model_Name],[Model_Code],[Pipe_No],[LineNO],[Status],[Round]
                                                        ,[IoT_Status],[Emp_ID],[Apperance_Judgement],[MasterID],[ApperanceDate],GETDATE()
                                                        FROM [dbIoT].[dbo].[Appearance_Detail]
                                                        WHERE Serial_No=@SerialOld)";
                                    sqlInIF.Parameters.Add(new SqlParameter("@SerialNew", txtSerialNew.Text.Trim()));
                                    sqlInIF.Parameters.Add(new SqlParameter("@SerialOld", txtSerialOld.Text.Trim()));
                                    oConIoT.Query(sqlInIF);
                                }

                            }///End if Insert Data to App
                            catch
                            {

                            }


                            #endregion

                            //******************************************
                            //            Reload Data
                            //******************************************
                            rptSerialNew.DataSource = null;
                            rptSerialNew.DataBind();

                            if (txtSerialNew.Text.Trim().Length >= 11)
                            {
                                DataTable dt = GetDataHistory(txtSerialNew.Text.Trim().ToUpper());

                                rptSerialNew.DataSource = dt;
                                rptSerialNew.DataBind();
                            }
                            //******************************************
                            //            Reload Data
                            //******************************************


                            //********* Check & Insert WareHouse Repack ************
                            DataTable dtDel = new DataTable();
                            string strDel = @"SELECT TOP 1 prd_serial,prd_line,prd_date,prd_pipeno,prd_cd,prd_name,pck_no,rework,repack,wh_recieve,deleteDate,reason
                            FROM [dbDCI].[dbo].[PD_PackPrd_Delete]
                            WHERE prd_serial=@prd_serial ";
                            SqlCommand cmdDel = new SqlCommand();
                            cmdDel.CommandText = strDel;
                            cmdDel.Parameters.Add(new SqlParameter("@prd_serial", _SerialOld));
                            dtDel = oConDCI.Query(cmdDel);
                            if (dtDel.Rows.Count > 0)
                            {
                                string strInstDel = "INSERT INTO [dbDCI].[dbo].[PD_PackPrd_Delete] ";
                                strInstDel += " (prd_serial,prd_line,prd_date,prd_pipeno,prd_cd,prd_name,";
                                strInstDel += " pck_no,rework,repack,wh_recieve,deleteDate,reason) ";
                                strInstDel += " SELECT '" + _SerialNew + "',prd_line,prd_date,prd_pipeno,prd_cd, ";
                                strInstDel += " prd_name,pck_no,rework,repack,wh_recieve,deleteDate,reason ";
                                strInstDel += "   FROM [dbDCI].[dbo].[PD_PackPrd_Delete] WHERE prd_serial=@prd_serial ";
                                SqlCommand cmdInstDel = new SqlCommand();
                                cmdInstDel.CommandText = strInstDel;
                                cmdInstDel.Parameters.Add(new SqlParameter("@prd_serial", _SerialOld));
                                oConDCI.ExecuteCommand(cmdInstDel);
                            }
                            //********* End Check & Insert WareHouse Repack ************

                        }
                        else
                        {
                            lblError.Text = "ข้อมูล Pipe Number ไม่ตรงกัน";
                        }//----- End Check Pipe No ------

                    }
                    else {
                        lblError.Text = "ข้อมูล Model ไม่ตรงกัน";
                    }//----- End Check Same Model ------

                } // end check is can
                else
                {
                    lblError.Text = "Serial นี้ถูก Packing ไปแล้วไม่สามารถทำการโอนถ่ายข้อมูลได้";
                }
            } // end have repeater
            else {
                lblError.Text = "ไม่พบข้อมูลที่จะทำการโอนถ่ายข้อมูล";
            }

            
            
        }// end if check
        else {
            lblError.Text = "กรุณาระบบหมายเลข Serial ที่ถูกต้อง";
        }


        btnTransfer.Enabled = false;
        btnReset.Enabled = true;

    }


    private DataTable GetDataHistory(string PrdSerial)
    {

        DataTable dtDataHistory = new DataTable();
        dtDataHistory.Columns.Add("PrdSerial", typeof(string));
        dtDataHistory.Columns.Add("PrdLabelNo", typeof(string));
        dtDataHistory.Columns.Add("OilChargeData", typeof(string));
        dtDataHistory.Columns.Add("RunningTestData", typeof(string));
        dtDataHistory.Columns.Add("LowVoltageData", typeof(string));
        dtDataHistory.Columns.Add("AppCheckData", typeof(string));
        dtDataHistory.Columns.Add("WeightCheckData", typeof(string));


        if (PrdSerial.Trim().Length == 15)
        {
            lblError.Text = "";

            //string _Year = PrdSerial.Substring(1, 1);
            //string _Month = PrdSerial.Substring(2, 1);
            //string _DataModel = PrdSerial.Substring(3, 4);
            //string _DataYear = DateTime.Now.Year.ToString().Substring(0, 3) + _Year;
            string _DataModelName = "";
            string _DataPipeNo = "";

            DataTable dtLabel = new DataTable();
            string strLabel = @"SELECT PrdDate, LocalDate, Model, ModelCode, Temp, PipeNo, SerialNumber 
                 FROM PD_LabelLine5 
                 WHERE SerialNumber=@SerialNumber ";
            SqlCommand cmdLabel = new SqlCommand();
            cmdLabel.CommandText = strLabel;
            cmdLabel.CommandTimeout = 180;
            cmdLabel.Parameters.Add(new SqlParameter("SerialNumber", PrdSerial.Trim()));
            dtLabel = oConDCI.Query(cmdLabel);

            try
            {
                _DataModelName = dtLabel.Rows[0]["Model"].ToString();
            }
            catch { }
            try
            {
                _DataPipeNo = dtLabel.Rows[0]["PipeNo"].ToString();
            }
            catch { }



            #region Oil Charge
            DataTable dtOil = new DataTable();
            string StrOil = @"SELECT SerialNo, Judgement, InsertDate, MFGDate
                FROM Line5_OilCharge 
                WHERE SerialNo = @SerialNo 
                ORDER BY MFGDate DESC";
            SqlCommand cmdOil = new SqlCommand();
            cmdOil.CommandText = StrOil;
            cmdOil.CommandTimeout = 180;
            cmdOil.Parameters.Add(new SqlParameter("@SerialNo", PrdSerial.Trim()));
            dtOil = oConIoT.Query(cmdOil);
            #endregion

            #region Running Test
            DataTable dtRunTest = new DataTable();
            string StrRunT = @"SELECT SerialNo, FrequencyJudgement, RunningJudgement, 
                    VacuumCapJudgement, VacuumLeakJudgement, TotalJudgement, InsertDate, MFGDate
                FROM Line5_RunningTest  
                WHERE SerialNo = @SerialNo 
                ORDER BY MFGDate DESC";
            SqlCommand cmdRunT = new SqlCommand();
            cmdRunT.CommandText = StrRunT;
            cmdRunT.CommandTimeout = 180;
            cmdRunT.Parameters.Add(new SqlParameter("@SerialNo", PrdSerial.Trim()));
            dtRunTest = oConIoT.Query(cmdRunT);
            #endregion

            #region High Voltage
            DataTable dtLowVolt = new DataTable();
            string StrLowV = @"SELECT SerialNo, MOhmTestJudgement, HVTestJudgement, 
                    MagTestJudgement, OhmTest2ndJudgement, TotalJudgement, 
                    InsertDate, MFGDate
            FROM Line5_HVTest 
            WHERE SerialNo = @SerialNo 
            ORDER BY MFGDate DESC";
            SqlCommand cmdLowV = new SqlCommand();
            cmdLowV.CommandText = StrLowV;
            cmdLowV.CommandTimeout = 180;
            cmdLowV.Parameters.Add(new SqlParameter("@SerialNo", PrdSerial.Trim()));
            dtLowVolt = oConIoT.Query(cmdLowV);
            #endregion

            #region Weight Check
            DataTable dtWeight = new DataTable();
            string StrWeight = @"SELECT SerialNo, WeightCheckJudgement, WeightMeasured, TerminalCover, InsertDate, MFGDate
                FROM Line5_WeightCheck 
                WHERE SerialNo = @SerialNo 
                ORDER BY MFGDate DESC";
            SqlCommand cmdWeight = new SqlCommand();
            cmdWeight.CommandText = StrWeight;
            cmdWeight.CommandTimeout = 180;
            cmdWeight.Parameters.Add(new SqlParameter("@SerialNo", PrdSerial.Trim()));
            dtWeight = oConIoT.Query(cmdWeight);
            #endregion

            #region Appearance Check
            DataTable dtApp = new DataTable();
            string StrApp = @"SELECT [Serial_No],[Apperance_Judgement],[ApperanceDate]
                          FROM [dbIoT].[dbo].[Appearance_Detail]
                WHERE Serial_No = @SerialNo 
                ORDER BY ApperanceDate DESC";
            SqlCommand cmdApp = new SqlCommand();
            cmdApp.CommandText = StrApp;
            cmdApp.CommandTimeout = 180;
            cmdApp.Parameters.Add(new SqlParameter("@SerialNo", PrdSerial.Trim()));
            dtApp = oConIoT.Query(cmdApp);
            #endregion

            #region Add DataRow Of DataHistory
            int dataRow = 0;
            int dataRowOil = 0;
            int dataRowRun = 0;
            int dataRowLow = 0;
            int dataRowWeight = 0;

            if (dtOil.Rows.Count > dataRow)
            {
                dataRow = dtOil.Rows.Count;
            }

            if (dtRunTest.Rows.Count > dataRow)
            {
                dataRow = dtRunTest.Rows.Count;
            }

            if (dtLowVolt.Rows.Count > dataRow)
            {
                dataRow = dtLowVolt.Rows.Count;
            }

            if (dtWeight.Rows.Count > dataRow)
            {
                dataRow = dtWeight.Rows.Count;
            }

            dataRowOil = dtOil.Rows.Count;
            dataRowRun = dtRunTest.Rows.Count;
            dataRowLow = dtLowVolt.Rows.Count;
            dataRowWeight = dtWeight.Rows.Count;

            if (dataRow > 0)
            {
                for (int idx = 0; idx < dataRow; idx++)
                {
                    DataRow drNew = dtDataHistory.NewRow();
                    drNew["PrdSerial"] = PrdSerial.Trim();
                    drNew["PrdLabelNo"] = PrdSerial.Trim();
                    try
                    {
                        drNew["OilChargeData"] = dtOil.Rows[idx]["Judgement"].ToString() + " : " + dtOil.Rows[idx]["MFGDate"].ToString();
                    }
                    catch { drNew["OilChargeData"] = ""; }

                    try
                    {
                        string _RunStatus = "";

                        if (dtRunTest.Rows[idx]["FrequencyJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["RunningJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["VacuumCapJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["VacuumLeakJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["TotalJudgement"].ToString() == "OK" )
                        {
                            _RunStatus = "OK";
                        }
                        else
                        {
                            _RunStatus = "NG";
                        }

                        drNew["RunningTestData"] = _RunStatus + " : " + dtRunTest.Rows[idx]["MFGDate"].ToString();
                    }
                    catch { drNew["RunningTestData"] = ""; }



                    try
                    {
                        string _HighStatus = "";
                        
                        if (dtLowVolt.Rows[idx]["MOhmTestJudgement"].ToString().ToUpper() == "OK" &&
                            dtLowVolt.Rows[idx]["HVTestJudgement"].ToString().ToUpper() == "OK" &&
                            dtLowVolt.Rows[idx]["MagTestJudgement"].ToString().ToUpper() == "OK" &&
                            dtLowVolt.Rows[idx]["OhmTest2ndJudgement"].ToString().ToUpper() == "OK" &&
                            dtLowVolt.Rows[idx]["TotalJudgement"].ToString().ToUpper() == "OK"  )
                        {
                            _HighStatus = "OK";
                        }
                        else {
                            _HighStatus = "NG";
                        }

                        drNew["LowVoltageData"] = _HighStatus + " : " + dtLowVolt.Rows[idx]["MFGDate"].ToString();
                    }
                    catch { drNew["LowVoltageData"] = ""; }

                    try
                    {
                        drNew["AppCheckData"] = dtApp.Rows[idx]["Apperance_Judgement"].ToString() + " : " + dtApp.Rows[idx]["ApperanceDate"].ToString();
                    }
                    catch { drNew["AppCheckData"] = ""; }


                    try
                    {
                        drNew["WeightCheckData"] = dtWeight.Rows[idx]["WeightCheckJudgement"].ToString() + " : " + dtWeight.Rows[idx]["MFGDate"].ToString();
                    }
                    catch { drNew["WeightCheckData"] = ""; }

                    dtDataHistory.Rows.Add(drNew);
                }
            }


            #endregion


        } // end if

        return dtDataHistory;
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

        rptSerialNew.DataSource = null;
        rptSerialNew.DataBind();
        

        rptSerialOld.DataSource = null;
        rptSerialOld.DataBind();

        txtSerialOld.Focus();
    }


    public string GetPipeNo(string SerialNo)
    {
        DataTable dtPipe = new DataTable();
        string PipeNo = "";

        try
        {
            string strPipe = @"SELECT PipeNo FROM PD_LabelLine5
                WHERE SerialNumber = @SerialNumber 
                ORDER BY LocalDate DESC";
            SqlCommand cmdPipe = new SqlCommand();
            cmdPipe.CommandText = strPipe;
            cmdPipe.CommandTimeout = 180;
            cmdPipe.Parameters.Add(new SqlParameter("@SerialNumber", SerialNo));
            dtPipe = oConIoT.Query(cmdPipe);

            PipeNo = dtPipe.Rows[0]["PipeNo"].ToString().Trim().ToUpper();
        }
        catch { }

        return PipeNo;
    }



}