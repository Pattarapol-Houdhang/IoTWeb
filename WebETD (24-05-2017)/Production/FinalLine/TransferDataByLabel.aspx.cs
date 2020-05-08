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

public partial class Production_FinalLine_TransferDataByLabel : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    ConnectDB oConIoT = new ConnectDB();
    ConnectDBFac3 oConFac3IoT = new ConnectDBFac3();
    ConnectDBSCM oConnSCM = new ConnectDBSCM();
    string _EmpCode = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }

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
        else
        {
            DataTable dtEmp = new DataTable();
            string StrEmp = @"SELECT CODE,NAME,SURN,POSIT FROM Employee WHERE CODE=@CODE ";
            SqlCommand cmdEmp = new SqlCommand();
            cmdEmp.CommandText = StrEmp;
            cmdEmp.CommandTimeout = 180;
            cmdEmp.Parameters.Add(new SqlParameter("@CODE", _EmpCode));
            dtEmp = oConDCI.Query(cmdEmp);
            try
            {
                lblEmployee.Text = (dtEmp.Rows.Count > 0) ? _EmpCode + " : " + dtEmp.Rows[0]["NAME"].ToString() + "." + dtEmp.Rows[0]["SURN"].ToString().Substring(0, 1) : _EmpCode;
            }
            catch { lblEmployee.Text = _EmpCode; }
        }
    }




    private DataTable GetDataHistory(string PrdSerial)
    {

        DataTable dtDataHistory = new DataTable();
        dtDataHistory.Columns.Add("PrdSerial", typeof(string));
        dtDataHistory.Columns.Add("PrdLabelNo", typeof(string));
        dtDataHistory.Columns.Add("OilChargeData", typeof(string));
        dtDataHistory.Columns.Add("RunningTestData", typeof(string));
        dtDataHistory.Columns.Add("WeightCheckData", typeof(string));
        dtDataHistory.Columns.Add("AppCheckData", typeof(string));

        if (PrdSerial.Trim().Length == 15)
        {
            lblError.Text = "";
            
            string _Year = PrdSerial.Substring(1, 1);
            string _Month = PrdSerial.Substring(2, 1);
            string _DataModel = PrdSerial.Substring(3, 4);
            string _LabelNo = PrdSerial.Substring(7, 8);
            string _DataYear = DateTime.Now.Year.ToString().Substring(0, 3) + _Year;
            string _DataModelName = "";
            string _DataPipeNo = "";

            DataTable dtLabel = new DataTable();
            string strLabel = "SELECT LBP_ID, DateMC, Model, LabelNo, " +
                "  CycleTimeStart, CycleTimeEnd, ModelName, PipeNumber, " +
                "  MFGDate, InsertDate " +
                " FROM vi_LabelPrinting " +
                //" WHERE Model = @Model AND LabelNo=@LabelNo AND YEAR(MFGDate) = @DataYear  ";
                " WHERE SerialNumber=@SerialNumber ";
            SqlCommand cmdLabel = new SqlCommand();
            cmdLabel.CommandText = strLabel;
            cmdLabel.CommandTimeout = 180;
            //cmdLabel.Parameters.Add(new SqlParameter("Model", _DataModel));
            //cmdLabel.Parameters.Add(new SqlParameter("LabelNo", _LabelNo));
            //cmdLabel.Parameters.Add(new SqlParameter("DataYear", _DataYear));
            cmdLabel.Parameters.Add(new SqlParameter("SerialNumber", PrdSerial.Trim()));
            dtLabel = oConFac3IoT.Query(cmdLabel);
            
            try
            {
                _DataModelName = dtLabel.Rows[0]["ModelName"].ToString();
            }
            catch { }
            try
            {
                _DataPipeNo = dtLabel.Rows[0]["PipeNumber"].ToString();
            }
            catch { }


            #region Oil Charge
            //************* Oil Charge Data History List ****************
            DataTable dtOil = new DataTable();
            string SQLOil = "SELECT DateShift, ModelNo, MachineNo, PartSerialNo, CycleStartTime, CycleEndTime, " +
            "     ManufacturingTime, IntegratedJudgement, WeightCompressorBefore, WeightCompressorAfter, " +
            "     IntegratedJudgementResult AS ResultData, InsertDate AS DataDate " +
            "  FROM vi_FN_OilFilling " +
            "  WHERE SerialNumber=@SerialNumber " +
            "  ORDER BY InsertDate DESC ";
            SqlCommand cmdOil = new SqlCommand();
            cmdOil.CommandText = SQLOil;
            cmdOil.CommandTimeout = 180;
            cmdOil.Parameters.Add(new SqlParameter("@SerialNumber", PrdSerial.Trim()));
            dtOil = oConFac3IoT.Query(cmdOil);
            #endregion


            #region Running Test
            //***************** Check Running Test Data **********************
            DataTable dtRunTest = new DataTable();
            string StrRunTest = "SELECT InsertDate AS DataDate, " +
            "   ConstantJudgement, RotationJudgement, ExhalationJudgement, DrivingJudgement,  " +
            "   VacuumJudgement, VacuumHoldtimeJudgement, InsulationInspectionResult, " +
            "   ResistingPressureInspection, WindingJudgement, FluxJudgementResult " +
            " FROM FN_RunningTest " +
            " WHERE (PartSerialNo = @PartSerialNo)  " +
            " ORDER BY InsertDate DESC ";
            SqlCommand cmdRunTest = new SqlCommand();
            cmdRunTest.CommandText = StrRunTest;
            cmdRunTest.CommandTimeout = 180;
            cmdRunTest.Parameters.Add(new SqlParameter("@PartSerialNo", PrdSerial.Trim()));
            dtRunTest = oConFac3IoT.Query(cmdRunTest);
            //***************** End Check Running Test Data **********************
            #endregion


            #region Weight Check
            //***************** Check Weight Check Data **********************
            DataTable dtWeight = new DataTable();
            string StrWeight = "SELECT IntegratedJudgement AS ResultData, InsertDate AS DataDate " +
            " FROM vi_FN_WeightCheck " +
            " WHERE PartSerialNo=@PartSerialNo  " +
            " ORDER BY InsertDate DESC ";
            SqlCommand cmdWeight = new SqlCommand();
            cmdWeight.CommandText = StrWeight;
            cmdWeight.CommandTimeout = 180;
            cmdWeight.Parameters.Add(new SqlParameter("@PartSerialNo", PrdSerial.Trim()));
            dtWeight = oConFac3IoT.Query(cmdWeight);
            //***************** End Check Running Test Data **********************
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

            #region Insert DataHistory
            int dataRow = 0;
            int dataRowOil = 0;
            int dataRowRun = 0;
            int dataRowWeight = 0;
            int dataRowWApp = 0;

            if (dtOil.Rows.Count > dataRow) {
                dataRow = dtOil.Rows.Count;
            }

            if (dtRunTest.Rows.Count > dataRow)
            {
                dataRow = dtRunTest.Rows.Count;
            }

            if (dtWeight.Rows.Count > dataRow)
            {
                dataRow = dtWeight.Rows.Count;
            }

            if (dtApp.Rows.Count > dataRow)
            {
                dataRow = dtApp.Rows.Count;
            }

            dataRowOil = dtOil.Rows.Count;
            dataRowRun = dtRunTest.Rows.Count;
            dataRowWeight = dtWeight.Rows.Count;
            dataRowWApp = dtApp.Rows.Count;

            if (dataRow > 0)
            {
                for (int idx = 0; idx < dataRow; idx++)
                {
                    DataRow drNew = dtDataHistory.NewRow();
                    drNew["PrdSerial"] = PrdSerial.Trim();
                    drNew["PrdLabelNo"] = _LabelNo;
                    try
                    {
                        drNew["OilChargeData"] = dtOil.Rows[idx]["ResultData"].ToString() + " : " + dtOil.Rows[idx]["DataDate"].ToString();
                    }
                    catch { drNew["OilChargeData"] = ""; }

                    try
                    {
                        string _RunStatus = "";
                        if (dtRunTest.Rows[idx]["ConstantJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["RotationJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["ExhalationJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["DrivingJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["VacuumJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["VacuumHoldtimeJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["InsulationInspectionResult"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["ResistingPressureInspection"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["WindingJudgement"].ToString() == "OK" &&
                        dtRunTest.Rows[idx]["FluxJudgementResult"].ToString() == "OK")
                        {
                            _RunStatus = "OK";
                        }
                        else
                        {
                            _RunStatus = "NG";
                        }

                        drNew["RunningTestData"] = _RunStatus + " : " + dtRunTest.Rows[idx]["DataDate"].ToString();
                    }
                    catch { drNew["RunningTestData"] = ""; }

                    try
                    {
                        drNew["WeightCheckData"] = dtWeight.Rows[idx]["ResultData"].ToString()+" : "+ dtWeight.Rows[idx]["DataDate"].ToString();
                    }
                    catch { drNew["WeightCheckData"] = ""; }

                    try
                    {
                        drNew["AppCheckData"] = dtApp.Rows[idx]["Apperance_Judgement"].ToString() + " : " + dtApp.Rows[idx]["ApperanceDate"].ToString();
                    }
                    catch { drNew["AppCheckData"] = ""; }
                    
                    dtDataHistory.Rows.Add(drNew);
                }
            }
            
            
            #endregion

        } // end if

        return dtDataHistory;
    }




    protected void rptOilCharge_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            /*
            Literal ltrSerial = (Literal)e.Item.FindControl("ltrSerial") as Literal;
            Literal ltrModel = (Literal)e.Item.FindControl("ltrModel") as Literal;
            Literal ltrBefore = (Literal)e.Item.FindControl("ltrBefore") as Literal;
            Literal ltrAfter = (Literal)e.Item.FindControl("ltrAfter") as Literal;
            Literal ltrResult = (Literal)e.Item.FindControl("ltrResult") as Literal;
            Literal ltrDate = (Literal)e.Item.FindControl("ltrDate") as Literal;

            //******** SET COLOR ********
            string FontColor = "";
            if (ltrResult.Text.ToString().ToUpper() == "OK")
            {
                FontColor = " color:#29a329; ";
            }
            else
            {
                FontColor = " color:#ff0000; ";
            }



            DataTable dtCompressor = new DataTable();
            string SQLCompressor = "SELECT ModelCode, Model FROM PN_Compressor WHERE ModelCode=@ModelCode ";
            SqlCommand cmdCompressor = new SqlCommand();
            cmdCompressor.CommandText = SQLCompressor;
            cmdCompressor.CommandTimeout = 180;
            cmdCompressor.Parameters.Add(new SqlParameter("ModelCode", ltrModel.Text.Trim().Substring(1, 3)));
            dtCompressor = oConnSCM.Query(cmdCompressor);
            if (dtCompressor.Rows.Count > 0)
            {
                try
                {
                    ltrModel.Text = ltrModel.Text + ":" + dtCompressor.Rows[0]["Model"].ToString();
                }
                catch (Exception ex)
                {
                    //ltrModel.Text = ex.ToString();
                }
            }



            ltrResult.Text = "<span style='font-weight:bold; " + FontColor + "'>" + ltrResult.Text.ToString() + "</span>";


            try
            {
                ltrDate.Text = Convert.ToDateTime(ltrDate.Text).ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch
            {
                ltrDate.Text = ltrDate.Text.ToString();
            }
            */


        }
    }

   


    protected void txtSerialOld_TextChanged(object sender, EventArgs e)
    {
        rptSerialOld.DataSource = null;
        rptSerialOld.DataBind();

        if (txtSerialOld.Text.Trim().Length == 15)
        {
            DataTable dt = GetDataHistory(txtSerialOld.Text.Trim().ToUpper());

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

        if (txtSerialNew.Text.Trim().Length == 15)
        {
            DataTable dt = GetDataHistory(txtSerialNew.Text.Trim().ToUpper());

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

        if (txtSerialNew.Text.Trim().Length == 15 && txtSerialOld.Text.Trim().Length == 15) {
            if (rptSerialOld.Items.Count > 0) {

                if (isCanTransferLabel(txtSerialOld.Text.Trim().Substring(0, 15)))
                {
                    string _SerialNew = "";
                    string _SerialOld = "";

                    _SerialNew = txtSerialNew.Text.Trim();
                    string _YearNew = _SerialNew.Substring(1, 1);
                    string _MonthNew = _SerialNew.Substring(2, 1);
                    string _DataModelNew = _SerialNew.Substring(3, 4);
                    string _LabelNoNew = _SerialNew.Substring(7, 8);
                    string _DataYearNew = DateTime.Now.Year.ToString().Substring(0, 3) + _YearNew;

                    _SerialOld = txtSerialOld.Text.Trim();
                    string _YearOld = _SerialOld.Substring(1, 1);
                    string _MonthOld = _SerialOld.Substring(2, 1);
                    string _DataModelOld = _SerialOld.Substring(3, 4);
                    string _LabelNoOld = _SerialOld.Substring(7, 8);
                    string _DataYearOld = DateTime.Now.Year.ToString().Substring(0, 3) + _YearOld;


                    //----- Check Same Model ------
                    if (_DataModelNew == _DataModelOld)
                    {
                        string PipeNew = GetPipeNo(_SerialNew);
                        string PipeOld = GetPipeNo(_SerialOld);


                        // ------ Check Same Pipe No --------
                        if (PipeNew == PipeOld)
                        {

                            #region Oil Charge
                            //************* Oil Charge Data History List ****************
                            DataTable dtOil = new DataTable();
                            string SQLOil = "SELECT FNOF_ID, DateShift, ModelNo, MachineNo, PartSerialNo, " +
                            "    CycleStartTime, CycleEndTime, ManufacturingTime, AmountSettingValue, AmountCountValue, " +
                            "    IntegratedJudgement, WeightCompressorBefore, WeightCompressorAfter, AmountOilFilling, " +
                            "    SpecificGravityConversion, AmountOilFilling2, IntegratedJudgementResult, InsertDate " +
                            "  FROM vi_FN_OilFilling " +
                            "  WHERE SerialNumber=@SerialNumber " +
                            "  ORDER BY InsertDate DESC ";
                            SqlCommand cmdOil = new SqlCommand();
                            cmdOil.CommandText = SQLOil;
                            cmdOil.CommandTimeout = 180;
                            cmdOil.Parameters.Add(new SqlParameter("SerialNumber", _SerialOld));
                            dtOil = oConFac3IoT.Query(cmdOil);

                            if (dtOil.Rows.Count > 0)
                            {
                                foreach (DataRow drOil in dtOil.Rows)
                                {
                                    try
                                    {
                                        string SQLInsert = "INSERT INTO FN_OilFilling (FNOF_ID, DateShift, ModelNo, MachineNo, " +
                                            " PartSerialNo, CycleStartTime, CycleEndTime, ManufacturingTime, AmountSettingValue, " +
                                            " AmountCountValue, IntegratedJudgement, WeightCompressorBefore, WeightCompressorAfter, " +
                                            " AmountOilFilling, SpecificGravityConversion, AmountOilFilling2, IntegratedJudgementResult, " +
                                            " InsertDate) VALUES (@FNOF_ID, @DateShift, @ModelNo, @MachineNo, @PartSerialNo, " +
                                            " @CycleStartTime, @CycleEndTime, @ManufacturingTime, @AmountSettingValue, " +
                                            " @AmountCountValue, @IntegratedJudgement, @WeightCompressorBefore, " +
                                            " @WeightCompressorAfter, @AmountOilFilling, @SpecificGravityConversion, " +
                                            " @AmountOilFilling2, @IntegratedJudgementResult, @InsertDate) ";
                                        SqlCommand cmdInsert = new SqlCommand();
                                        cmdInsert.CommandText = SQLInsert;
                                        cmdInsert.CommandTimeout = 180;
                                        cmdInsert.Parameters.Add(new SqlParameter("@FNOF_ID", drOil["FNOF_ID"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@DateShift", drOil["DateShift"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", _DataModelNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MachineNo", drOil["MachineNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CycleStartTime", drOil["CycleStartTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CycleEndTime", drOil["CycleEndTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ManufacturingTime", drOil["ManufacturingTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@AmountSettingValue", drOil["AmountSettingValue"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@AmountCountValue", drOil["AmountCountValue"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@IntegratedJudgement", drOil["IntegratedJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@WeightCompressorBefore", drOil["WeightCompressorBefore"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@WeightCompressorAfter", drOil["WeightCompressorAfter"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@AmountOilFilling", drOil["AmountOilFilling"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@SpecificGravityConversion", drOil["SpecificGravityConversion"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@AmountOilFilling2", drOil["AmountOilFilling2"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drOil["IntegratedJudgementResult"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", drOil["InsertDate"].ToString()));
                                        oConFac3IoT.ExecuteCommand(cmdInsert);
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
                                        cmdLog.Parameters.Add(new SqlParameter("@DateShift", drOil["DateShift"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@ModelNo", _DataModelNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@MachineNo", drOil["MachineNo"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataProcess", "TRANSFER_OIL_CHARGE"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue1", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue2", _SerialOld));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue3", drOil["WeightCompressorBefore"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue4", drOil["WeightCompressorAfter"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue5", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue6", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue7", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue8", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue9", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue10", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue11", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue12", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue13", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue14", "LINE 6"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue15", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drOil["IntegratedJudgementResult"].ToString()));
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
                            string StrRunTest = "SELECT DateShift, ModelNo, MachineNo, PartSerialNo, " +
                            "   CycleStartTime, CycleEndTime, ManufacturingTime, ConstantPressedTime, " +
                            "   ConstantJudgement, RotationFrequencyArrivalTime, RotationJudgement, " +
                            "   ExhalationTime, ExhalationJudgement, DrivingCurrent, DrivingJudgement, " +
                            "   VacuumArrivalTime, VacuumJudgement, VacuumHoldtimeJudgement, " +
                            "   IntegratedJudgementResult, InsulationInspectionResult, ResistingPressureInspection, " +
                            "   WindingResistanceUV, WindingJudgement, IntegratedJudgementResult2, " +
                            "   FluxMeasuredValue, FluxJudgementResult, TempertureSurface, JudgementSeletedNo, " +
                            "   MachineNumber, InsertDate " +
                            " FROM FN_RunningTest " +
                            " WHERE (PartSerialNo = @PartSerialNo)  " +
                            " ORDER BY InsertDate DESC ";
                            SqlCommand cmdRunTest = new SqlCommand();
                            cmdRunTest.CommandText = StrRunTest;
                            cmdRunTest.CommandTimeout = 180;
                            cmdRunTest.Parameters.Add(new SqlParameter("PartSerialNo", _SerialOld));
                            dtRunTest = oConFac3IoT.Query(cmdRunTest);
                            //***************** End Check Running Test Data **********************
                            if (dtRunTest.Rows.Count > 0)
                            {
                                foreach (DataRow drRunTest in dtRunTest.Rows)
                                {
                                    try
                                    {
                                        string SQLInsert = "INSERT INTO FN_RunningTest (DateShift, ModelNo, MachineNo, " +
                                            " PartSerialNo, CycleStartTime, CycleEndTime, ManufacturingTime, " +
                                            " ConstantPressedTime, ConstantJudgement, RotationFrequencyArrivalTime, " +
                                            " RotationJudgement, ExhalationTime, ExhalationJudgement, DrivingCurrent, " +
                                            " DrivingJudgement, VacuumArrivalTime, VacuumJudgement, VacuumHoldtimeJudgement, " +
                                            " IntegratedJudgementResult, InsulationInspectionResult, ResistingPressureInspection, " +
                                            " WindingResistanceUV, WindingJudgement, IntegratedJudgementResult2, " +
                                            " FluxMeasuredValue, FluxJudgementResult, TempertureSurface, JudgementSeletedNo, " +
                                            " MachineNumber, InsertDate) VALUES (@DateShift, @ModelNo, @MachineNo, " +
                                            " @PartSerialNo, @CycleStartTime, @CycleEndTime, @ManufacturingTime, " +
                                            " @ConstantPressedTime, @ConstantJudgement, @RotationFrequencyArrivalTime, " +
                                            " @RotationJudgement, @ExhalationTime, @ExhalationJudgement, @DrivingCurrent, " +
                                            " @DrivingJudgement, @VacuumArrivalTime, @VacuumJudgement, @VacuumHoldtimeJudgement, " +
                                            " @IntegratedJudgementResult, @InsulationInspectionResult, @ResistingPressureInspection, " +
                                            " @WindingResistanceUV, @WindingJudgement, @IntegratedJudgementResult2, " +
                                            " @FluxMeasuredValue, @FluxJudgementResult, @TempertureSurface, @JudgementSeletedNo, " +
                                            " @MachineNumber, @InsertDate) ";
                                        SqlCommand cmdInsert = new SqlCommand();
                                        cmdInsert.CommandText = SQLInsert;
                                        cmdInsert.CommandTimeout = 180;
                                        cmdInsert.Parameters.Add(new SqlParameter("@DateShift", drRunTest["DateShift"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", _DataModelNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MachineNo", drRunTest["MachineNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CycleStartTime", drRunTest["CycleStartTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CycleEndTime", drRunTest["CycleEndTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ManufacturingTime", drRunTest["ManufacturingTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ConstantPressedTime", drRunTest["ConstantPressedTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ConstantJudgement", drRunTest["ConstantJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@RotationFrequencyArrivalTime", drRunTest["RotationFrequencyArrivalTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@RotationJudgement", drRunTest["RotationJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ExhalationTime", drRunTest["ExhalationTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ExhalationJudgement", drRunTest["ExhalationJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@DrivingCurrent", drRunTest["DrivingCurrent"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@DrivingJudgement", drRunTest["DrivingJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@VacuumArrivalTime", drRunTest["VacuumArrivalTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@VacuumJudgement", drRunTest["VacuumJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@VacuumHoldtimeJudgement", drRunTest["VacuumHoldtimeJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drRunTest["IntegratedJudgementResult"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@InsulationInspectionResult", drRunTest["InsulationInspectionResult"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ResistingPressureInspection", drRunTest["ResistingPressureInspection"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@WindingResistanceUV", drRunTest["WindingResistanceUV"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@WindingJudgement", drRunTest["WindingJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@IntegratedJudgementResult2", drRunTest["IntegratedJudgementResult2"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@FluxMeasuredValue", drRunTest["FluxMeasuredValue"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@FluxJudgementResult", drRunTest["FluxJudgementResult"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@TempertureSurface", drRunTest["TempertureSurface"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@JudgementSeletedNo", drRunTest["JudgementSeletedNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MachineNumber", drRunTest["MachineNumber"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", drRunTest["InsertDate"].ToString()));
                                        oConFac3IoT.ExecuteCommand(cmdInsert);
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
                                        cmdLog.Parameters.Add(new SqlParameter("@DateShift", drRunTest["DateShift"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@ModelNo", _DataModelNew));
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
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue14", "LINE 6"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue15", drRunTest["JudgementSeletedNo"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drRunTest["IntegratedJudgementResult2"].ToString()));
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
                            string StrWeight = "SELECT DateShift, ModelNo, MachineNo, PartSerialNo, " +
                            "   CycleStartTime, CycleEndTime, ManufacturingTime, FinalWeight, " +
                            "   IntegratedJudgement, InsertDate " +
                            " FROM vi_FN_WeightCheck " +
                            " WHERE PartSerialNo=@PartSerialNo " +
                            " ORDER BY InsertDate DESC ";
                            SqlCommand cmdWeight = new SqlCommand();
                            cmdWeight.CommandText = StrWeight;
                            cmdWeight.CommandTimeout = 180;
                            cmdWeight.Parameters.Add(new SqlParameter("PartSerialNo", _SerialOld));
                            dtWeight = oConFac3IoT.Query(cmdWeight);
                            //***************** End Check Running Test Data **********************
                            if (dtWeight.Rows.Count > 0)
                            {
                                foreach (DataRow drWeight in dtWeight.Rows)
                                {
                                    try
                                    {
                                        string SQLInsert = "INSERT INTO FN_WeightCheck (DateShift, ModelNo, " +
                                            "    MachineNo, PartSerialNo, CycleStartTime, CycleEndTime, " +
                                            "    ManufacturingTime, FinalWeight, IntegratedJudgement, InsertDate) " +
                                            " VALUES (@DateShift, @ModelNo, @MachineNo, @PartSerialNo, " +
                                            " @CycleStartTime, @CycleEndTime, @ManufacturingTime, @FinalWeight, " +
                                            " @IntegratedJudgement, @InsertDate) ";
                                        SqlCommand cmdInsert = new SqlCommand();
                                        cmdInsert.CommandText = SQLInsert;
                                        cmdInsert.CommandTimeout = 180;
                                        cmdInsert.Parameters.Add(new SqlParameter("@DateShift", drWeight["DateShift"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", _DataModelNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@MachineNo", drWeight["MachineNo"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@PartSerialNo", _LabelNoNew));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CycleStartTime", drWeight["CycleStartTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@CycleEndTime", drWeight["CycleEndTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@ManufacturingTime", drWeight["ManufacturingTime"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@FinalWeight", drWeight["FinalWeight"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@IntegratedJudgement", drWeight["IntegratedJudgement"].ToString()));
                                        cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", drWeight["InsertDate"].ToString()));
                                        oConFac3IoT.ExecuteCommand(cmdInsert);
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
                                        cmdLog.Parameters.Add(new SqlParameter("@DateShift", drWeight["DateShift"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@ModelNo", _DataModelNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@MachineNo", drWeight["MachineNo"].ToString()));
                                        cmdLog.Parameters.Add(new SqlParameter("@PartSerialNo", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataProcess", "TRANSFER_WEIGHT_CHECK"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue1", _SerialNew));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue2", _SerialOld));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue3", drWeight["FinalWeight"].ToString()));
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
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue14", "LINE 6"));
                                        cmdLog.Parameters.Add(new SqlParameter("@DataValue15", ""));
                                        cmdLog.Parameters.Add(new SqlParameter("@IntegratedJudgementResult", drWeight["IntegratedJudgement"].ToString()));
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


                            #region Update Old Series in Hold Table
                            DataTable dtHold = new DataTable();
                            string strHold = "SELECT prd_serial,prd_status, remark2 FROM PD_FinalHold WHERE prd_serial=@prd_serial ";
                            SqlCommand cmdHold = new SqlCommand();
                            cmdHold.CommandText = strHold;
                            cmdHold.CommandTimeout = 180;
                            cmdHold.Parameters.Add(new SqlParameter("@prd_serial", _SerialOld));
                            dtHold = oConDCI.Query(cmdHold);
                            if (dtHold.Rows.Count > 0)
                            {
                                if (dtHold.Rows[0]["prd_status"].ToString() == "HOLD" || dtHold.Rows[0]["prd_status"].ToString() == "LINEOUT")
                                {
                                    //----- Create new --------
                                    string strInstrHold = "INSERT INTO [dbDCI].[dbo].[PD_FinalHold] (Nbr,LotUnholdNbr, ";
                                    strInstrHold += " LotNbr,prd_serial,prd_line,prd_model_code,prd_model,prd_pipe_no, ";
                                    strInstrHold += " HoldBy,HoldDate,prd_status,RequestBy,RequestDate,AllowBy,AllowDate, ";
                                    strInstrHold += " OilingStatus,OilingDate,RunningTestStatus,RunningTestDate, ";
                                    strInstrHold += " WeightCheckStatus,WeightCheckDate,remark1,remark2,remark3,remark4,remark5) ";
                                    strInstrHold += "  SELECT 'RE_'+Nbr,LotUnholdNbr, ";
                                    strInstrHold += "  LotNbr,'" + _SerialNew + "',prd_line,prd_model_code,prd_model,prd_pipe_no, ";
                                    strInstrHold += "  HoldBy,HoldDate,prd_status,RequestBy,RequestDate,AllowBy,AllowDate, ";
                                    strInstrHold += "  OilingStatus,OilingDate,RunningTestStatus,RunningTestDate, ";
                                    strInstrHold += "  WeightCheckStatus,WeightCheckDate,remark1,remark2,remark3,remark4,remark5 ";
                                    strInstrHold += " FROM [dbDCI].[dbo].[FN_DataCenter] ";
                                    strInstrHold += "   WHERE prd_serial=@prd_serial ";
                                    SqlCommand cmdInstrHold = new SqlCommand();
                                    cmdInstrHold.CommandText = strInstrHold;
                                    cmdInstrHold.Parameters.Add(new SqlParameter("@prd_serial", _SerialOld));
                                    oConDCI.ExecuteCommand(cmdInstrHold);


                                    string strUpdateHold = "UPDATE PD_FinalHold SET prd_status=@prd_status, remark2=@remark2 WHERE prd_serial=@prd_serial ";
                                    SqlCommand cmdUpdateHold = new SqlCommand();
                                    cmdUpdateHold.CommandText = strUpdateHold;
                                    cmdUpdateHold.CommandTimeout = 180;
                                    cmdUpdateHold.Parameters.Add(new SqlParameter("@prd_status", "RELABEL"));
                                    cmdUpdateHold.Parameters.Add(new SqlParameter("@remark2", _SerialNew));
                                    cmdUpdateHold.Parameters.Add(new SqlParameter("@prd_serial", _SerialOld));
                                    oConDCI.ExecuteCommand(cmdUpdateHold);
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

                            #region Copy  DataCenter
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
                                        LW_InsertDate, N2_Judgement, N2_InsertDate, WC_Judgement, WC_InsertDate,
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
                                            else
                                            {
                                                if (dtCenterNew.Rows[0]["OC_Judgement"].ToString() == "OK")
                                                {
                                                    Oil = "OK";
                                                }
                                                else
                                                {
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
                                            //------ Appearance ------
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
                                                [ReLabel_Serial]=@ReLabel_Serial,[TerminalCover]=@TerminalCover
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


                                } // end foreach
                            }
                            #endregion

                            #region old Code insert Fn_datacenter

//                            //********* Check & Insert FN Data Center ************
//                            DataTable dtFNCenter = new DataTable();
//                            string strFNCenter = @"SELECT TOP 1 Serial, ModelCode, Line ,[PipeNo]
//                            FROM [dbDCI].[dbo].[FN_DataCenter] 
//                            WHERE Serial=@Serial ";
//                            SqlCommand cmdFNCenter = new SqlCommand();
//                            cmdFNCenter.CommandText = strFNCenter;
//                            cmdFNCenter.Parameters.Add(new SqlParameter("@Serial", _SerialOld));
//                            dtFNCenter = oConDCI.Query(cmdFNCenter);
//                            if (dtFNCenter.Rows.Count == 0)
//                            {

//                                //----- Create new --------
//                                string strCenter = "INSERT INTO [dbDCI].[dbo].[FN_DataCenter] ([Serial],";
//                                strCenter += " [ModelCode],[PipeNo],[Line],[LB_InsertDate],[LB_MFGDate],[OC_Judgement], ";
//                                strCenter += " [OC_InsertDate],[RT_Station],[RT_Judgement],[RT_InsertDate], ";
//                                strCenter += " [HV_Judgement],[HV_InsertDate],[LW_Judgement],[LW_InsertDate], ";
//                                strCenter += " [N2_Judgement],[N2_InsertDate],[WC_Judgement],[WC_InsertDate], ";
//                                strCenter += " [ReLabel_Status],[ReLabel_Serial],[AP_Judgement],[AP_InsertDate],[TerminalCover]) ";
//                                strCenter += "  SELECT '" + _SerialNew + "', ModelCode,PipeNo, Line, LB_InsertDate, ";
//                                strCenter += "   LB_MFGDate, OC_Judgement, OC_InsertDate, RT_Station, RT_Judgement, ";
//                                strCenter += "   RT_InsertDate, HV_Judgement, HV_InsertDate, LW_Judgement, ";
//                                strCenter += "   LW_InsertDate, N2_Judgement, N2_InsertDate, WC_Judgement, ";
//                                strCenter += "   WC_InsertDate, 're_new', '" + _SerialOld + "',AP_Judgement,AP_InsertDate,TerminalCover FROM [dbDCI].[dbo].[FN_DataCenter] ";
//                                strCenter += "   WHERE Serial=@Serial ";
//                                SqlCommand cmdCenter = new SqlCommand();
//                                cmdCenter.CommandText = strCenter;
//                                cmdCenter.Parameters.Add(new SqlParameter("@Serial", _SerialOld));
//                                oConDCI.ExecuteCommand(cmdCenter);

//                                //------ update old ------
//                                string strUpOldCenter = "UPDATE [dbDCI].[dbo].[FN_DataCenter] SET ";
//                                strUpOldCenter += "  [ReLabel_Status]=@ReLabel_Status, [ReLabel_Serial]=@ReLabel_Serial ";
//                                strUpOldCenter += " WHERE Serial=@Serial ";
//                                SqlCommand cmdUpOldCenter = new SqlCommand();
//                                cmdUpOldCenter.CommandText = strUpOldCenter;
//                                cmdUpOldCenter.Parameters.Add(new SqlParameter("@ReLabel_Status", "re_old"));
//                                cmdUpOldCenter.Parameters.Add(new SqlParameter("@ReLabel_Serial", _SerialNew));
//                                cmdUpOldCenter.Parameters.Add(new SqlParameter("@Serial", _SerialOld));
//                                oConDCI.ExecuteCommand(cmdUpOldCenter);

//                            }
//                            //********* End Check & Insert FN Data Center ************
                            #endregion



                            //******************************************
                            //            Reload Data
                            //******************************************
                            rptSerialNew.DataSource = null;
                            rptSerialNew.DataBind();

                            if (txtSerialNew.Text.Trim().Length == 15)
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
                                strInstDel += " prd_name,pck_no,rework,'1',wh_recieve,deleteDate,reason ";
                                strInstDel += "   FROM [dbDCI].[dbo].[PD_PackPrd_Delete] WHERE prd_serial=@prd_serial ";
                                SqlCommand cmdInstDel = new SqlCommand();
                                cmdInstDel.CommandText = strInstDel;
                                cmdInstDel.Parameters.Add(new SqlParameter("@prd_serial", _SerialOld));
                                oConDCI.ExecuteCommand(cmdInstDel);
                            }
                            //********* End Check & Insert WareHouse Repack ************

                        }
                        else {
                            lblError.Text = "ข้อมูล Pipe Number ไม่ตรงกัน";
                        }// ------ End Check Same Pipe No --------
                    }
                    else {
                        lblError.Text = "ข้อมูล Model ไม่ตรงกัน";
                    }//----- End Check Same Model ------

                }
                else {
                    lblError.Text = "Serial นี้ถูก Packing ไปแล้วไม่สามารถทำการโอนถ่ายข้อมูลได้";
                }
            }
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


    public bool isCanTransferLabel(string PrdSerial) {
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


    protected void rptSerialNew_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem ) {
            Literal ltrOil = (Literal)e.Item.FindControl("ltrOil") as Literal;
            Literal ltrRun = (Literal)e.Item.FindControl("ltrRun") as Literal;
            Literal ltrWeight = (Literal)e.Item.FindControl("ltrWeight") as Literal;
            Literal ltrApp = (Literal)e.Item.FindControl("ltrApp") as Literal;


        }
    }

    protected void rptSerialOld_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltrOil = (Literal)e.Item.FindControl("ltrOil") as Literal;
            Literal ltrRun = (Literal)e.Item.FindControl("ltrRun") as Literal;
            Literal ltrWeight = (Literal)e.Item.FindControl("ltrWeight") as Literal;
            Literal ltrApp = (Literal)e.Item.FindControl("ltrApp") as Literal;


        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        txtSerialOld.Text = "";
        txtSerialNew.Text = "";

        btnTransfer.Enabled = false;
        btnReset.Enabled = true;

        txtSerialOld.Focus();
        rptSerialOld.DataSource = null;
        rptSerialOld.DataBind();

        rptSerialNew.DataSource = null;
        rptSerialNew.DataBind();
    }



    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString();
    }


    public string GetPipeNo(string SerialNo) {
        DataTable dtPipe = new DataTable();
        string PipeNo = "";

        try
        {
            string strPipe = @"SELECT PipeNumber FROM vi_LabelPrinting 
                WHERE SerialNumber = @SerialNumber 
                ORDER BY MFGDate DESC";
            SqlCommand cmdPipe = new SqlCommand();
            cmdPipe.CommandText = strPipe;
            cmdPipe.CommandTimeout = 180;
            cmdPipe.Parameters.Add(new SqlParameter("@SerialNumber", SerialNo));
            dtPipe = oConFac3IoT.Query(cmdPipe);

            PipeNo = dtPipe.Rows[0]["PipeNumber"].ToString().Trim().ToUpper();
        }
        catch { }

        return PipeNo;
    }

}