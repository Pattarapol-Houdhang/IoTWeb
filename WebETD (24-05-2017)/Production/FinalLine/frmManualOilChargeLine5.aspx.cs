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

public partial class Production_FinalLine_frmManualOilChargeLine5 : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    ConnectDBFac3 oConFac3IoT = new ConnectDBFac3();
    ConnectDBSCM oConnSCM = new ConnectDBSCM();
    ConnectDB oConIoT = new ConnectDB();

    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    string _EmpCode = "";

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            btnRecord.Enabled = false;
            btnReset.Enabled = true;
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
            Response.Redirect(@"http://websrv01.dci.daikin.co.jp/iotweb/");
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


    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        lblTime.Text = DateTime.Now.ToString();
    }


    private void GetOilChargeDataHistory(string PrdSerial)
    {
        if (PrdSerial.Trim().Length == 15)
        {
            lblError.Text = "";

            string _Year = PrdSerial.Substring(1, 1);
            string _Month = PrdSerial.Substring(2, 1);
            string _DataModel = PrdSerial.Substring(3, 4);
            string _LabelNo = PrdSerial.Substring(7, 8);
            string _DataYear = DateTime.Now.Year.ToString().Substring(0, 3) + _Year;
            
            DataTable dtOil = new DataTable();
            string strOil = @"SELECT SerialNo,ModelNo,ModelName,BeforeWeight,AfterWeight,
                                    OilChargeValue,Judgement,InsertDate,MFGDate
                 FROM Line5_OilCharge 
                 WHERE SerialNo=@SerialNo ";
            SqlCommand cmdOil = new SqlCommand();
            cmdOil.CommandText = strOil;
            cmdOil.CommandTimeout = 180;
            cmdOil.Parameters.Add(new SqlParameter("SerialNo", PrdSerial.Trim()));
            dtOil = oConIoT.Query(cmdOil);
            
            rptOilCharge.DataSource = dtOil;
            rptOilCharge.DataBind();
        } // end if


        

    }




    protected void rptOilCharge_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
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
            cmdCompressor.Parameters.Add(new SqlParameter("ModelCode", ltrModel.Text.Trim().Substring(1,3)));
            dtCompressor = oConnSCM.Query(cmdCompressor);
            if (dtCompressor.Rows.Count > 0)
            {
                try
                {
                    ltrModel.Text = ltrModel.Text+":" +dtCompressor.Rows[0]["Model"].ToString();
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



        }
    }





    protected void txtSerial_TextChanged(object sender, EventArgs e)
    {
        if (txtSerial.Text.Trim().Length == 15)
        {
            GetOilChargeDataHistory(txtSerial.Text.Trim().ToUpper());

            btnRecord.Enabled = true;
            btnReset.Enabled = true;
        }
        else {
            btnRecord.Enabled = false;
            btnReset.Enabled = true;
        }
    }




    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblError.Text = "";
        txtSerial.Text = "";
        txtWeight.Text = "";

        btnRecord.Enabled = false;
        btnReset.Enabled = true;

        txtSerial.Focus();
        rptOilCharge.DataSource = null;
        rptOilCharge.DataBind();
    }

    protected void btnRecord_Click(object sender, EventArgs e)
    {
        txtSerial.Enabled = false;
        txtWeight.Enabled = false;
        btnRecord.Enabled = false;
        btnReset.Enabled = false;


        decimal _WeightData = 0;
        try
        {
            _WeightData = Convert.ToDecimal(txtWeight.Text.ToString().Trim());
        }
        catch { }


        string _KeyCode = "";
        decimal _ModelWeightCheck = 1;
        //decimal _ModelWeightCheck = 99999;
        //try
        //{
        //    _KeyCode = "FinalLineOil" + txtSerial.Text.Trim().Substring(4, 3);
        //    string ModelWeightCheck = ConfigurationSettings.AppSettings[_KeyCode].ToString();
        //    _ModelWeightCheck = Convert.ToDecimal(ModelWeightCheck);
        //}
        //catch {
        //    _ModelWeightCheck = 99999;
        //}


        if (txtSerial.Text.Trim().ToUpper().Length == 15 &&
            (_WeightData > _ModelWeightCheck ))
        {            

            string PrdSerial = txtSerial.Text.Trim().ToUpper();

            string _Year = PrdSerial.Substring(1, 1);
            string _Month = PrdSerial.Substring(2, 1);
            string _DataModel = PrdSerial.Substring(3, 4);
            string _LabelNo = PrdSerial.Substring(7, 8);
            string _DataYear = DateTime.Now.Year.ToString().Substring(0, 3) + _Year;

            DataTable dtLabel = new DataTable();
            string strLabel = @"SELECT Id,PrdDate,LocalDate,Model,ModelCode,Temp,
                                    Serial,PipeNo,Data1,Data2,Data3,SerialNumber,Mode 
                FROM PD_LabelLine5 
                WHERE Model = @Model AND LabelNo=@LabelNo AND YEAR(MFGDate) = @DataYear ";
            SqlCommand cmdLabel = new SqlCommand();
            cmdLabel.CommandText = strLabel;
            cmdLabel.CommandTimeout = 180;
            cmdLabel.Parameters.Add(new SqlParameter("SerialNumber", PrdSerial));
            dtLabel = oConDCI.Query(cmdLabel);

            if (dtLabel.Rows.Count > 0)
            {
                bool _CanRecord = false;
                //************* Oil Charge Data History List ****************
                DataTable dtOil = new DataTable();
                string SQLOil = @"SELECT SELECT SerialNo,ModelNo,ModelName,BeforeWeight,AfterWeight,
                                    OilChargeValue,Judgement,InsertDate,MFGDate
                 FROM Line5_OilCharge
                 WHERE SerialNo = @SerialNo 
                 ORDER BY InsertDate DESC ";
                SqlCommand cmdOil = new SqlCommand();
                cmdOil.CommandText = SQLOil;
                cmdOil.CommandTimeout = 180;
                cmdOil.Parameters.Add(new SqlParameter("SerialNo", PrdSerial));
                dtOil = oConIoT.Query(cmdOil);


                if (dtOil.Rows.Count > 0)
                {
                    if (dtOil.Rows[0]["Judgement"].ToString() == "NG")
                    {
                        _CanRecord = true;
                    }
                    else
                    {

                        //********* UPDATE TO DATA CENTER ***********
                        DataTable dtFNCheck = new DataTable();
                        int FNCheck = 0;
                        string strFNCheck = @"SELECT ISNULL(COUNT(Serial),0) AS counts 
                            FROM FN_DataCenter WHERE Serial=@Serial AND Line = '5'  ";
                        SqlCommand cmdFNCheck = new SqlCommand();
                        cmdFNCheck.CommandText = strFNCheck;
                        cmdFNCheck.Parameters.Add(new SqlParameter("@Serial", PrdSerial));
                        dtFNCheck = oConDCI.Query(cmdFNCheck);
                        try
                        {
                            FNCheck = Convert.ToInt16(dtFNCheck.Rows[0]["counts"].ToString());
                        }
                        catch { }

                        if (FNCheck == 0)
                        {
                            string strFNCenter = @"INSERT INTO FN_DataCenter (Serial,ModelCode,Line,LB_InsertDate,
                                            LB_MFGDate,OC_Judgement,OC_InsertDate,RT_Station,
                                            RT_Judgement,RT_InsertDate,HV_Judgement,HV_InsertDate,
                                            LW_Judgement,LW_InsertDate,N2_Judgement,N2_InsertDate,
                                            WC_Judgement,WC_InsertDate) VALUES (@Serial,NULL,
                                            @Line,NULL,NULL,@OC_Judgement,@OC_InsertDate,NULL,
                                            NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL) ";
                            SqlCommand cmdFNCenter = new SqlCommand();
                            cmdFNCenter.CommandText = strFNCenter;
                            cmdFNCenter.Parameters.Add(new SqlParameter("@Serial", PrdSerial));
                            cmdFNCenter.Parameters.Add(new SqlParameter("@Line", "5"));
                            cmdFNCenter.Parameters.Add(new SqlParameter("@OC_Judgement", "OK"));
                            cmdFNCenter.Parameters.Add(new SqlParameter("@OC_InsertDate", DateTime.Now));
                            oConDCI.ExecuteCommand(cmdFNCenter);


                            lblError.Text = "*** ไม่สามารถบันทึกข้อมูลได้ เนื่องจากมีผล OK อยู่แล้ว *** [Insert in DataCenter]";
                        }
                        else
                        {
                            string strFNCenter = @"UPDATE FN_DataCenter SET OC_Judgement='OK' 
                                            WHERE Serial=@Serial AND Line = '5' ";
                            SqlCommand cmdFNCenter = new SqlCommand();
                            cmdFNCenter.CommandText = strFNCenter;
                            cmdFNCenter.Parameters.Add(new SqlParameter("@Serial", PrdSerial));
                            oConDCI.ExecuteCommand(cmdFNCenter);


                            lblError.Text = "*** ไม่สามารถบันทึกข้อมูลได้ เนื่องจากมีผล OK อยู่แล้ว *** [Update OK in DataCenter]";

                        }
                        //********* END UPDATE TO DATA CENTER ***********


                        
                    }
                }
                else
                {
                    _CanRecord = true;
                }// end check if



                //******* RECORD *********
                if (_CanRecord)
                {

                    string _DateShift = "";
                    string _dsYear = "";
                    string _dsMonth = "";
                    string _dsDay = "";

                    _dsDay = DateTime.Now.ToString("dd");
                    switch (_Month) {
                        case "1": _dsMonth = "01"; break;
                        case "2": _dsMonth = "02"; break;
                        case "3": _dsMonth = "03"; break;
                        case "4": _dsMonth = "04"; break;
                        case "5": _dsMonth = "05"; break;
                        case "6": _dsMonth = "06"; break;
                        case "7": _dsMonth = "07"; break;
                        case "8": _dsMonth = "08"; break;
                        case "9": _dsMonth = "09"; break;
                        case "A": _dsMonth = "10"; break;
                        case "B": _dsMonth = "11"; break;
                        case "C": _dsMonth = "12"; break;
                    }
                    
                    _dsYear = DateTime.Now.ToString("yyyy").Substring(0,3) + _Year;
                    _DateShift = _dsDay + _dsMonth + _dsYear;

                    string SQLInsert = @"INSERT INTO Line5_OilCharge (SerialNo,ModelNo,ModelName,
                                BeforeWeight,AfterWeight,OilChargeValue,Judgement,InsertDate,MFGDate) 
                            VALUES (@SerialNo,@ModelNo,@ModelName,@BeforeWeight,@AfterWeight,
                                @OilChargeValue,@Judgement,@InsertDate,@MFGDate) ";
                    SqlCommand cmdInsert = new SqlCommand();
                    cmdInsert.CommandText = SQLInsert;
                    cmdInsert.CommandTimeout = 180;
                    cmdInsert.Parameters.Add(new SqlParameter("@SerialNo", PrdSerial));
                    cmdInsert.Parameters.Add(new SqlParameter("@ModelNo", _DataModel));
                    cmdInsert.Parameters.Add(new SqlParameter("@ModelName", ""));
                    cmdInsert.Parameters.Add(new SqlParameter("@BeforeWeight", _WeightData.ToString()));
                    cmdInsert.Parameters.Add(new SqlParameter("@AfterWeight", _WeightData.ToString()));
                    cmdInsert.Parameters.Add(new SqlParameter("@OilChargeValue", _WeightData.ToString()));
                    cmdInsert.Parameters.Add(new SqlParameter("@Judgement", "OK"));
                    cmdInsert.Parameters.Add(new SqlParameter("@InsertDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    cmdInsert.Parameters.Add(new SqlParameter("@MFGDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    oConIoT.ExecuteCommand(cmdInsert);



                    //********************** INSERT LOG **********************
                    string SQLLog = "INSERT INTO FN_ManualDataLog (DateShift, ModelNo, MachineNo, "+
                        " PartSerialNo, DataProcess, DataValue1, DataValue2, DataValue3, DataValue4, "+
                        " DataValue5, DataValue6, DataValue7, DataValue8, DataValue9, DataValue10, "+
                        " DataValue11, DataValue12, DataValue13, DataValue14, DataValue15, "+
                        " IntegratedJudgementResult, InsertBy, InsertDate) VALUES (@DateShift, "+
                        " @ModelNo, @MachineNo, @PartSerialNo, @DataProcess, @DataValue1, @DataValue2, "+
                        " @DataValue3, @DataValue4, @DataValue5, @DataValue6, @DataValue7, @DataValue8, "+
                        " @DataValue9, @DataValue10, @DataValue11, @DataValue12, @DataValue13, @DataValue14, "+
                        " @DataValue15, @IntegratedJudgementResult, @InsertBy, @InsertDate) ";
                    SqlCommand cmdLog = new SqlCommand();
                    cmdLog.CommandText = SQLLog;
                    cmdLog.CommandTimeout = 180;
                    cmdLog.Parameters.Add(new SqlParameter("DateShift", DateTime.Now.ToString("ddMMyyyy")));
                    cmdLog.Parameters.Add(new SqlParameter("ModelNo", _DataModel));
                    cmdLog.Parameters.Add(new SqlParameter("MachineNo", "LINE 5"));
                    cmdLog.Parameters.Add(new SqlParameter("PartSerialNo", PrdSerial));
                    cmdLog.Parameters.Add(new SqlParameter("DataProcess", "OIL_CHARGE_5"));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue1", _WeightData.ToString()));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue2", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue3", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue4", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue5", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue6", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue7", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue8", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue9", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue10", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue11", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue12", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue13", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue14", ""));
                    cmdLog.Parameters.Add(new SqlParameter("DataValue15", ""));
                    cmdLog.Parameters.Add(new SqlParameter("IntegratedJudgementResult", "OK"));
                    cmdLog.Parameters.Add(new SqlParameter("InsertBy", _EmpCode));
                    cmdLog.Parameters.Add(new SqlParameter("InsertDate", DateTime.Now));
                    oConFac3IoT.ExecuteCommand(cmdLog);



                    //********* UPDATE TO DATA CENTER ***********
                    DataTable dtFNCheck = new DataTable();
                    int FNCheck = 0;
                    string strFNCheck = @"SELECT ISNULL(COUNT(Serial),0) AS counts 
                            FROM FN_DataCenter WHERE Serial=@Serial AND Line = '5'  ";
                    SqlCommand cmdFNCheck = new SqlCommand();
                    cmdFNCheck.CommandText = strFNCheck;
                    cmdFNCheck.Parameters.Add(new SqlParameter("@Serial", PrdSerial));
                    dtFNCheck = oConDCI.Query(cmdFNCheck);
                    try {
                        FNCheck = Convert.ToInt16(dtFNCheck.Rows[0]["counts"].ToString());
                    }catch { }

                    if (FNCheck == 0)
                    {
                        string strFNCenter = @"INSERT INTO FN_DataCenter (Serial,ModelCode,Line,LB_InsertDate,
                                            LB_MFGDate,OC_Judgement,OC_InsertDate,RT_Station,
                                            RT_Judgement,RT_InsertDate,HV_Judgement,HV_InsertDate,
                                            LW_Judgement,LW_InsertDate,N2_Judgement,N2_InsertDate,
                                            WC_Judgement,WC_InsertDate) VALUES (@Serial,NULL,
                                            @Line,NULL,NULL,@OC_Judgement,@OC_InsertDate,NULL,
                                            NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL) ";
                        SqlCommand cmdFNCenter = new SqlCommand();
                        cmdFNCenter.CommandText = strFNCenter;
                        cmdFNCenter.Parameters.Add(new SqlParameter("@Serial", PrdSerial));
                        cmdFNCenter.Parameters.Add(new SqlParameter("@Line", "5"));
                        cmdFNCenter.Parameters.Add(new SqlParameter("@OC_Judgement", "OK"));
                        cmdFNCenter.Parameters.Add(new SqlParameter("@OC_InsertDate", DateTime.Now));
                        oConDCI.ExecuteCommand(cmdFNCenter);

                    }
                    else {
                        string strFNCenter = @"UPDATE FN_DataCenter SET OC_Judgement='OK' 
                                            WHERE Serial=@Serial AND Line = '5' ";
                        SqlCommand cmdFNCenter = new SqlCommand();
                        cmdFNCenter.CommandText = strFNCenter;
                        cmdFNCenter.Parameters.Add(new SqlParameter("@Serial", PrdSerial));
                        oConDCI.ExecuteCommand(cmdFNCenter);

                    }
                    //********* END UPDATE TO DATA CENTER ***********

                    //------ Reload Form --------
                    GetOilChargeDataHistory(txtSerial.Text.Trim().ToUpper());
                }//***********************
            }
            else
            {
                lblError.Text = "*** ไม่พบข้อมูลจาก Label Printing ***";
            }


        }// end 15 and weight
        else {
            lblError.Text = "*** กรุณาตรวจสอบข้อมูล Serial และข้อมูลน้ำหนักให้ถูกต้อง. ***";
        }


        txtSerial.Enabled = true;
        txtWeight.Enabled = true;
        btnRecord.Enabled = true;
        btnReset.Enabled = true;

    }




}