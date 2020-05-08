using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HistoryData_HistoryData : System.Web.UI.Page
{
    ConnectDBDCIMax oConnDCI = new ConnectDBDCIMax();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    CGenControl oGenCon = new CGenControl();
    CGeneral oGen = new CGeneral();

    DataTable dt = new DataTable();
    CHistoryData oHis = new CHistoryData();
    bool check;

    CGeneral.SerialType oSerialType = CGeneral.SerialType.Label;
    CGeneral.DBName oDBName = CGeneral.DBName.dbIoTFac3;
    string Line = "";
    string Machine = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["FactoryID"] != null)
        {
            ViewState["FactoryID"] = Request.QueryString["FactoryID"];
        }
        else
        {
            ViewState["FactoryID"] = "0";
        }

        if (Request.QueryString["ld_id"] != null)
        {
            ViewState["ld_id"] = Request.QueryString["ld_id"];
        }
        else
        {
            ViewState["ld_id"] = "0";
        }

        if (Request.QueryString["Manpower"] != null)
        {
            lbContent.Text = "Manpower History Data";
            lbMachine.Text = "Select Process";
            ViewState["Manpower"] = Request.QueryString["Manpower"];
        }
        else
        {
            lbContent.Text = "History Data";
            ViewState["Manpower"] = "0";
        }

        if (!IsPostBack)
        {
            txtPrdDate.Attributes.Add("readonly", "readonly");
            InitialControl();
            InitialDDL();
            LoadGrid();
        }
    }

    private void InitialControl()
    {
        if (ViewState["Manpower"].ToString() == "1")
        {
            oGenCon.GenDDLLineDataByManPowerMachineID(CGeneral.TypeSelect.Selected, ddlLine, Convert.ToInt16(ViewState["ld_id"].ToString()));
            ddlLine.SelectedValue = ViewState["ld_id"].ToString();
            oGenCon.GenDDLMachineManpowerByLine(CGeneral.TypeSelect.All, ddlMachine, ViewState["ld_id"].ToString());

        }
        else
        {
            oGenCon.GenDDLLineDataByFactoryID(CGeneral.TypeSelect.Selected, ddlLine, Convert.ToInt16(ViewState["FactoryID"].ToString()));
            ddlLine.SelectedValue = ViewState["ld_id"].ToString();
            oGenCon.GenDDLMachineByLine(CGeneral.TypeSelect.Selected, ddlMachine, ViewState["ld_id"].ToString());
        }

    }

    private DataTable GetData()
    {
        dt = new DataTable();
        CGeneral.TableName TableName = CGeneral.TableName.None;
        string MCName = "";
        string TypeData = "DL";
        string LineNo = "";

        LineNo = ddlLine.SelectedValue;
        if (ddlLine.SelectedValue == "4") // Main Assy
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Air_Gap":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Air_Gap";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Rotor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Rotor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Rotor_Yakibame":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Rotor_Yakibame";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Top":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Top";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Brazing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Brazing";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Pipe_Yakibame":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Pipe_Yakibame";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Top_Fitting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Top_Fitting";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Pipe":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Pipe";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        // lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;

                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else
            {


                switch (ddlMachine.SelectedValue)
                {
                    case "Main01":
                        TableName = CGeneral.TableName.Rotor_Yakibame_New;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Mecha or Rotor No.";
                        oSerialType = CGeneral.SerialType.RearAndRotor;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main02":
                        TableName = CGeneral.TableName.Magnetize;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Mecha No.";
                        oSerialType = CGeneral.SerialType.RearHead;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main03":
                        TableName = CGeneral.TableName.Pipe_Yakibame;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main04":
                        TableName = CGeneral.TableName.Tack_Welding;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = false;
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main05":
                        TableName = CGeneral.TableName.MagnetCenter;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe & Rotor No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main06":
                        TableName = CGeneral.TableName.AirGap;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main07":
                        TableName = CGeneral.TableName.ElectricalConduction;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main08":
                        TableName = CGeneral.TableName.TopBottomWelding;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }

        }
        else if (ddlLine.SelectedValue == "1") // Rear Head Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }

            else
            {


                switch (ddlMachine.SelectedValue)
                {
                    case "RH_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_RH;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.RearHead;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
        }
        else if (ddlLine.SelectedValue == "6") // Cylinder Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "CYLINDER_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_CY;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Cylinder No.";
                        oSerialType = CGeneral.SerialType.Cylinder;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }

        }
        else if (ddlLine.SelectedValue == "7") // Crank Shaft Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {

                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Lubrite_Machine":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Lubrite_Machine";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;

                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "CRANKSHAFT_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_CS;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Crank Shaft No.";
                        oSerialType = CGeneral.SerialType.CrankShaft;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }

        }
        else if (ddlLine.SelectedValue == "16") // Front Head Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {

                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "FRONTHEAD_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_FH;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Front Head No.";
                        oSerialType = CGeneral.SerialType.FrontHead;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }

        }
        else if (ddlLine.SelectedValue == "5") // Piston Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {

                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "PISTON_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_Piston;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Piston No.";
                        oSerialType = CGeneral.SerialType.Piston;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }

            }

        }
        else if (ddlLine.SelectedValue == "2") // Pipe Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "PipeMarking":
                    TableName = CGeneral.TableName.PipeMarking;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac3;
                    break;
                case "PipeIDCheck":
                    TableName = CGeneral.TableName.PipeIDCheck2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac3;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "8") // Stator Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "PD_Set_Pallet":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "PD_Set_Pallet";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "PD_Twist_Cut":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "PD_Twist_Cut";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Insert_Tube":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Insert_Tube";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Teminal_Crime":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Teminal_Crime";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Appearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Appearance_Check";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        // lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Characteristics_Test":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Characteristics_Test";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "STR_InsulatorLaserMarking":
                        TableName = CGeneral.TableName.Stator_LaserMarking;
                        TypeData = "MES";
                        break;
                    case "STR_CharecteristicMeasurement":
                        TableName = CGeneral.TableName.Stator_Characteristic;
                        TypeData = "MES";
                        break;
                    default:
                        break;
                }

            }

        }
        else if (ddlLine.SelectedValue == "9") // Rotor Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "RotorAssyMarking":
                    TableName = CGeneral.TableName.RotorLaserMarking;
                    TypeData = "MES";
                    break;
                case "Rotor_Riveting":
                    TableName = CGeneral.TableName.Rotor_Riveting;
                    TypeData = "MES";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "10") // Final Line
        {

            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "ALL";
                        break;
                    case "Label_Printing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Label_Printing";
                        break;
                    case "Running_Test":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Running_Test";
                        break;
                    case "N2_Leck_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "N2_Leck_Check";
                        break;
                    case "Appearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Appearance_Check";
                        break;
                    case "Weight_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Weight_Check";
                        break;
                    case "Loading":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Loading";
                        break;
                    case "Paint_band":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Paint_band";
                        break;
                    case "Dehydration_Veccum_take_off":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Dehydration_Veccum_take_off";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Part_Delivery";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "LEADER";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Foreman";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Supervisor";
                        break;
                    default:
                        break;
                }
                rbSearchSelect.Items[1].Enabled = false;
                lbSerialType.Text = "Label No.";
                oSerialType = CGeneral.SerialType.None;
                oDBName = CGeneral.DBName.dbIoTFac3;
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "FN_LabelPrinting":
                        TableName = CGeneral.TableName.vi_LabelPrinting;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_OilFilling":
                        TableName = CGeneral.TableName.vi_FN_OilFilling;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_RunningTest":
                        TableName = CGeneral.TableName.FN_RunningTest;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_FinalWeightCheck":
                        TableName = CGeneral.TableName.vi_FN_WeightCheck;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_APCheck":
                        TableName = CGeneral.TableName.vi_Appearance_Detail;
                        Line = "6";
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoT;
                        break;
                    default:
                        break;
                }

            }

        }
        else if (ddlLine.SelectedValue == "22") // SCR Line 4
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine4":
                    TableName = CGeneral.TableName.PD_LabelLine4;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "SCR_OilCharge":
                    TableName = CGeneral.TableName.SCR_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_RunningTest":
                    TableName = CGeneral.TableName.SCR_runningtest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_LowVoltage":
                    TableName = CGeneral.TableName.SCR_LowVoltage;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_N2LeakCheck":
                    TableName = CGeneral.TableName.SCR_N2LeakCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_AppCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "4";
                    break;
                case "SCR_WeightCheck":
                    TableName = CGeneral.TableName.SCR_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "23") // Main Assy Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "MainAssemblyLine3":
                    TableName = CGeneral.TableName.MainAssemblyLine3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "24") // Pipe Check Equipment Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "PipeCheckEquipmentLine3":
                    TableName = CGeneral.TableName.PipeCheckEquipmentLine3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "36") // Pipe Check Equipment Line 4
        {
            switch (ddlMachine.SelectedValue)
            {
                case "PipeCheckEquipmentLine4":
                    TableName = CGeneral.TableName.PipeL4_PipeCheckEquipment;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "12") // Mecha fac1 line1
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Cylinder":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Cylinder;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Crank_Shaft":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.CrankShaft;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Front_Head":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.FrontHead;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Piston":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Rear_Head":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.RearHead;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "30") // Final Line 1
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine1":
                    TableName = CGeneral.TableName.PD_LabelLine1;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL1_HVTest":
                    TableName = CGeneral.TableName.Line1_HVTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_OilCharge":
                    TableName = CGeneral.TableName.Line1_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_RunningTest":
                    TableName = CGeneral.TableName.Line1_RunningTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_WeightCheck":
                    TableName = CGeneral.TableName.Line1_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "1";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "31") // Final Line 2
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine2":
                    TableName = CGeneral.TableName.PD_LabelLine2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL2_HVTest":
                    TableName = CGeneral.TableName.Line2_HVTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL2_OilCharge":
                    TableName = CGeneral.TableName.Line2_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                //case "FL2_RunningTest":
                //    TableName = CGeneral.TableName.Line2_RunningTest;
                //    TypeData = "MES";
                //    rbSearchSelect.Items[1].Enabled = true;
                //    lbSerialType.Text = "Label No.";
                //    oSerialType = CGeneral.SerialType.Label;
                //    oDBName = CGeneral.DBName.dbIoT;
                //    break;
                case "FL2_WeightCheck":
                    TableName = CGeneral.TableName.Line2_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL2_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "2";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "27") // Final Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine3":
                    TableName = CGeneral.TableName.PD_LabelLine3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL3_HVTest":
                    TableName = CGeneral.TableName.Line3_HVTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_OilCharge":
                    TableName = CGeneral.TableName.Line3_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_RunningTest":
                    TableName = CGeneral.TableName.Line3_RunningTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_WeightCheck":
                    TableName = CGeneral.TableName.Line3_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "3";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "28") // Final Line 5
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine5":
                    TableName = CGeneral.TableName.PD_LabelLine5;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL5_OilCharge":
                    TableName = CGeneral.TableName.Line5_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_RunningTest":
                    TableName = CGeneral.TableName.Line5_RunningTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_WeightCheck":
                    TableName = CGeneral.TableName.Line5_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "5";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "29") // Main Scroll Line 4
        {
            switch (ddlMachine.SelectedValue)
            {
                case "HousingPress":
                    TableName = CGeneral.TableName.MainScroll_HousingPress;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "17") // Leak Check Common Line 1
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM1_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "1";
                    break;
                case "LCM1_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "1";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "18") // Leak Check Common Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM3_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "3";
                    break;
                case "LCM3_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "3";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "11") // Leak Check Common Line 3
        {

            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "ALL";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Supervisor";
                        break;
                    case "Front_Head_Reviting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Front_Head_Reviting";
                        break;
                    case "Front_Head_Assembly":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Front_Head_Assembly";
                        break;
                    case "Oiling":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Oiling";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "LEADER";
                        break;
                    case "Clearance_Check1":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Clearance_Check1";
                        break;
                    case "Clearance_Check2":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Clearance_Check2";
                        break;
                    case "Drivider_Press_Fitting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Drivider_Press_Fitting";
                        break;
                    case "Rear_Head_Assembly":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Rear_Head_Assembly";
                        break;
                    case "Part_Loader":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Part_Loader";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Foreman";
                        break;
                    case "Clearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Clearance_Check";
                        break;


                    default:
                        break;
                }
                rbSearchSelect.Items[1].Enabled = false;
                lbSerialType.Text = "Label No.";
                oSerialType = CGeneral.SerialType.None;
                oDBName = CGeneral.DBName.dbIoTFac3;
            }
        }
        else if (ddlLine.SelectedValue == "19") // Leak Check Common Line 5
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM5_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "5";
                    break;
                case "LCM5_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "5";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "20") // Leak Check Common Line 6
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM6_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "6";
                    break;
                case "LCM6_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "6";
                    break;
                case "LCM6_LeakCheckDetail":
                    TableName = CGeneral.TableName.vi_leak_NG_monitor;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LineNo = "6";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "33") // ODM
        {
            switch (ddlMachine.SelectedValue)
            {
                case "ODM_Demagnetize_No1":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No1;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No2":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No3":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No4":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No4;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Magnetize":
                    TableName = CGeneral.TableName.ODM_Magnetize;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_FinalInspection_No1":
                    TableName = CGeneral.TableName.ODM_FinalInspection_No1;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_FinalInspection_No2":
                    TableName = CGeneral.TableName.ODM_FinalInspection_No2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "37") // ODM Outdoor Ft1
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Inspection":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Inspection";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "SRC_Assy":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "SRC_Assy";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Laser_Mark":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Laser_Mark";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Sound_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Sound_Check";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Grease_Painting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Grease_Painting";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        // lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Packing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Packing";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "Inspection_Stator_Assy":
                        TableName = CGeneral.TableName.odm_od_stator_assy;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "SRC":
                        TableName = CGeneral.TableName.odm_od_SRC;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "Laser_Marking":
                        TableName = CGeneral.TableName.odm_od_marker;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "Sound_Check":
                        TableName = CGeneral.TableName.odm_od_soundcheck;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
        }
        //else if (ddlLine.SelectedValue == "38") // ODM Outdoor Ft2
        //{
        //    switch (ddlMachine.SelectedValue)
        //    {

        //    }
        //}
        else if (ddlLine.SelectedValue == "35") // Mecha Line 7
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Crank_Shaft":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Cylinder":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Front_Head":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Piston":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Rear_Head":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Matching":
                    TableName = CGeneral.TableName.etd_match_result_2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Torque_Check":
                    TableName = CGeneral.TableName.vi_torque_check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "39") // Mecha Line 7
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Top_Bottom_Welding":
                    TableName = CGeneral.TableName.Scada_Main_Assy_FG;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    LineNo = "7";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;


                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "14") // Mecha Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Crank_Shaft":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Cylinder":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Front_Head":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Piston":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Rear_Head":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Torque_Check":
                    TableName = CGeneral.TableName.vi_torque_check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "34") // Machine 2YC
        {
            switch (ddlMachine.SelectedValue)
            {
                case "MC_Crank_Shaft":
                    TableName = CGeneral.TableName.vi_MC_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Cylinder":
                    TableName = CGeneral.TableName.vi_MC_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Front_Head":
                    TableName = CGeneral.TableName.vi_MC_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Piston":
                    TableName = CGeneral.TableName.vi_MC_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Rear_Head":
                    TableName = CGeneral.TableName.vi_MC_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }


        ViewState["TableName"] = TableName;

        ViewState["DateStart"] = txtPrdDate.Text.Trim().Split('-')[0].Trim();
        ViewState["DateEnd"] = txtPrdDate.Text.Trim().Split('-')[1].Trim();
        if (rbSearchSelect.SelectedValue == "1")
        {
            oSerialType = CGeneral.SerialType.None;
        }
        dt = oHis.GetDataMESIoTServer(TableName, txtPrdDate.Text.Trim().Split('-')[0].Trim(), txtPrdDate.Text.Trim().Split('-')[1].Trim()
            , "", oSerialType, txtSerialNo.Text.Trim(), oDBName, LineNo, Line, Machine);


        return dt;
    }

    private void InitialDDL()
    {
        CGeneral.TableName TableName = CGeneral.TableName.ElectricalConduction;
        string MCName = "";
        string TypeData = "DL";

        if (ddlLine.SelectedValue == "4") // Main Assy
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Air_Gap":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Air_Gap";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Rotor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Rotor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Rotor_Yakibame":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Rotor_Yakibame";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Top":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Top";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Brazing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Brazing";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Pipe_Yakibame":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Pipe_Yakibame";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Top_Fitting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Top_Fitting";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Pipe":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Pipe";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        // lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;

                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Main6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else
            {


                switch (ddlMachine.SelectedValue)
                {
                    case "Main01":
                        TableName = CGeneral.TableName.Rotor_Yakibame_New;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Mecha or Rotor No.";
                        oSerialType = CGeneral.SerialType.RearAndRotor;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Main02":
                        TableName = CGeneral.TableName.Magnetize;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Mecha No.";
                        oSerialType = CGeneral.SerialType.RearHead;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Main03":
                        TableName = CGeneral.TableName.Pipe_Yakibame;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Main04":
                        TableName = CGeneral.TableName.Tack_Welding;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = false;
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Main05":
                        TableName = CGeneral.TableName.MagnetCenter;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe & Rotor No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Main06":
                        TableName = CGeneral.TableName.AirGap;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Main07":
                        TableName = CGeneral.TableName.ElectricalConduction;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Main08":
                        TableName = CGeneral.TableName.TopBottomWelding;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Pipe No.";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }


        }
        else if (ddlLine.SelectedValue == "1") // Rear Head Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {

                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_RH6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "RH_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_RH;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.RearHead;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }

        }
        else if (ddlLine.SelectedValue == "6") // Cylinder Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CY6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "CYLINDER_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_CY;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Cylinder No.";
                        oSerialType = CGeneral.SerialType.Cylinder;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }

        }
        else if (ddlLine.SelectedValue == "7") // Crank Shaft Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {

                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Lubrite_Machine":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_CS6";
                        Machine = "Lubrite_Machine";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "CRANKSHAFT_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_CS;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Crank Shaft No.";
                        oSerialType = CGeneral.SerialType.CrankShaft;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }

            }

        }
        else if (ddlLine.SelectedValue == "16") // Front Head Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {

                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_FH6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "FRONTHEAD_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_FH;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Front Head No.";
                        oSerialType = CGeneral.SerialType.FrontHead;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }

            }

        }
        else if (ddlLine.SelectedValue == "5") // Piston Finish Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {

                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Process_Inspaction";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Oparetor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "MC_PT6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Rear No.";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "PISTON_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_Piston;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Piston No.";
                        oSerialType = CGeneral.SerialType.Piston;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }

            }

        }
        else if (ddlLine.SelectedValue == "2") // Pipe Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "PipeMarking":
                    TableName = CGeneral.TableName.PipeMarking;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac3;
                    break;
                case "PipeIDCheck":
                    TableName = CGeneral.TableName.PipeIDCheck2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac3;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "8") // Stator Line
        {

            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "PD_Set_Pallet":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "PD_Set_Pallet";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "PD_Twist_Cut":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "PD_Twist_Cut";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Insert_Tube":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Insert_Tube";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Teminal_Crime":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Teminal_Crime";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Appearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Appearance_Check";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        // lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Characteristics_Test":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Characteristics_Test";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Motor6";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else
            {


                switch (ddlMachine.SelectedValue)
                {
                    case "STR_InsulatorLaserMarking":
                        TableName = CGeneral.TableName.Stator_LaserMarking;
                        TypeData = "MES";
                        break;
                    case "STR_CharecteristicMeasurement":
                        TableName = CGeneral.TableName.Stator_Characteristic;
                        TypeData = "MES";
                        break;
                    default:
                        break;
                }
            }
        }
        else if (ddlLine.SelectedValue == "9") // Rotor Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "RotorAssyMarking":
                    TableName = CGeneral.TableName.RotorLaserMarking;
                    TypeData = "MES";
                    break;
                case "Rotor_Riveting":
                    TableName = CGeneral.TableName.Rotor_Riveting;
                    TypeData = "MES";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "10") // Final Line
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "ALL";
                        break;
                    case "Label_Printing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Label_Printing";
                        break;
                    case "Running_Test":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Running_Test";
                        break;
                    case "N2_Leck_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "N2_Leck_Check";
                        break;
                    case "Appearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Appearance_Check";
                        break;
                    case "Dehydration_Veccum_take_off":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Dehydration_Veccum_take_off";
                        break;
                    case "Weight_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Weight_Check";
                        break;
                    case "Loading":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Loading";
                        break;
                    case "Paint_band":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Paint_band";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Part_Delivery";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "LEADER";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Foreman";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Final6";
                        Machine = "Supervisor";
                        break;
                    default:
                        break;
                }
                rbSearchSelect.Items[1].Enabled = false;
                lbSerialType.Text = "Label No.";
                oSerialType = CGeneral.SerialType.None;
                oDBName = CGeneral.DBName.dbIoTFac3;
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "FN_LabelPrinting":
                        TableName = CGeneral.TableName.vi_LabelPrinting;
                        TypeData = "MES";

                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "FN_OilFilling":
                        TableName = CGeneral.TableName.vi_FN_OilFilling;
                        TypeData = "MES";

                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "FN_RunningTest":
                        TableName = CGeneral.TableName.FN_RunningTest;
                        TypeData = "MES";

                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "FN_FinalWeightCheck":
                        TableName = CGeneral.TableName.vi_FN_WeightCheck;
                        TypeData = "MES";

                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "FN_APCheck":
                        TableName = CGeneral.TableName.vi_Appearance_Detail;
                        Line = "6";
                        TypeData = "MES";

                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Label No.";
                        oSerialType = CGeneral.SerialType.Label;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }

            }

        }
        else if (ddlLine.SelectedValue == "11") // Leak Check Common Line 3
        {

            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "ALL";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Supervisor";
                        break;
                    case "Front_Head_Reviting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Front_Head_Reviting";
                        break;
                    case "Front_Head_Assembly":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Front_Head_Assembly";
                        break;
                    case "Oiling":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Oiling";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "LEADER";
                        break;
                    case "Clearance_Check1":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Clearance_Check1";
                        break;
                    case "Clearance_Check2":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Clearance_Check2";
                        break;
                    case "Drivider_Press_Fitting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Drivider_Press_Fitting";
                        break;
                    case "Rear_Head_Assembly":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Rear_Head_Assembly";
                        break;
                    case "Part_Loader":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Part_Loader";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Foreman";
                        break;
                    case "Clearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "Mecha";
                        Machine = "Clearance_Check";
                        break;


                    default:
                        break;
                }
                rbSearchSelect.Items[1].Enabled = false;
                lbSerialType.Text = "Label No.";
                oSerialType = CGeneral.SerialType.None;
                oDBName = CGeneral.DBName.dbIoTFac3;
            }
        }
        else if (ddlLine.SelectedValue == "22") // SCR Line 4
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine4":
                    TableName = CGeneral.TableName.PD_LabelLine4;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "SCR_OilCharge":
                    TableName = CGeneral.TableName.SCR_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_RunningTest":
                    TableName = CGeneral.TableName.SCR_runningtest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_LowVoltage":
                    TableName = CGeneral.TableName.SCR_LowVoltage;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_N2LeakCheck":
                    TableName = CGeneral.TableName.SCR_N2LeakCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_AppCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "4";
                    break;
                case "SCR_WeightCheck":
                    TableName = CGeneral.TableName.SCR_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;

                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "23") // Main Assy Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "MainAssemblyLine3":
                    TableName = CGeneral.TableName.MainAssemblyLine3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "24") // Pipe Check Equipment Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "PipeCheckEquipmentLine3":
                    TableName = CGeneral.TableName.PipeCheckEquipmentLine3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "36") // Pipe Check Equipment Line 4
        {
            switch (ddlMachine.SelectedValue)
            {
                case "PipeCheckEquipmentLine4":
                    TableName = CGeneral.TableName.PipeL4_PipeCheckEquipment;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "12") // Mecha fac1 line1
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Cylinder":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Cylinder;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Crank_Shaft":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.CrankShaft;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Front_Head":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.FrontHead;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Piston":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                case "Rear_Head":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No";
                    oSerialType = CGeneral.SerialType.RearHead;
                    oDBName = CGeneral.DBName.dbIoTFac1;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "30") // Final Line 1
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine1":
                    TableName = CGeneral.TableName.PD_LabelLine1;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL1_HVTest":
                    TableName = CGeneral.TableName.Line1_HVTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_OilCharge":
                    TableName = CGeneral.TableName.Line1_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_RunningTest":
                    TableName = CGeneral.TableName.Line1_RunningTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_WeightCheck":
                    TableName = CGeneral.TableName.Line1_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "1";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "31") // Final Line 2
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine2":
                    TableName = CGeneral.TableName.PD_LabelLine2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL2_HVTest":
                    TableName = CGeneral.TableName.Line2_HVTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL2_OilCharge":
                    TableName = CGeneral.TableName.Line2_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                //case "FL2_RunningTest":
                //    TableName = CGeneral.TableName.Line2_RunningTest;
                //    TypeData = "MES";
                //    rbSearchSelect.Items[1].Enabled = true;
                //    lbSerialType.Text = "Label No.";
                //    oSerialType = CGeneral.SerialType.Label;
                //    oDBName = CGeneral.DBName.dbIoT;
                //    break;
                case "FL2_WeightCheck":
                    TableName = CGeneral.TableName.Line2_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL2_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "2";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "27") // Final Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine3":
                    TableName = CGeneral.TableName.PD_LabelLine3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL3_HVTest":
                    TableName = CGeneral.TableName.Line3_HVTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_OilCharge":
                    TableName = CGeneral.TableName.Line3_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_RunningTest":
                    TableName = CGeneral.TableName.Line3_RunningTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_WeightCheck":
                    TableName = CGeneral.TableName.Line3_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No.";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "3";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "28") // Final Line 5
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LabelPrintingLine5":
                    TableName = CGeneral.TableName.PD_LabelLine5;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL5_OilCharge":
                    TableName = CGeneral.TableName.Line5_OilCharge;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_RunningTest":
                    TableName = CGeneral.TableName.Line5_RunningTest;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_WeightCheck":
                    TableName = CGeneral.TableName.Line5_WeightCheck;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Label No";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    Line = "5";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "29") // Main Scroll Line 4
        {
            switch (ddlMachine.SelectedValue)
            {
                case "HousingPress":
                    TableName = CGeneral.TableName.MainScroll_HousingPress;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "17") // Leak Check Common Line 1
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM1_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "LCM1_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "18") // Leak Check Common Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM3_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "LCM3_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "19") // Leak Check Common Line 5
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM5_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "LCM5_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "20") // Leak Check Common Line 6
        {
            switch (ddlMachine.SelectedValue)
            {
                case "LCM6_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "LCM6_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "LCM6_LeakCheckDetail":
                    TableName = CGeneral.TableName.vi_leak_NG_monitor;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;

                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "33") // ODM
        {
            switch (ddlMachine.SelectedValue)
            {
                case "ODM_Demagnetize_No1":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No1;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No2":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No3":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No3;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No4":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No4;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Magnetize":
                    TableName = CGeneral.TableName.ODM_Magnetize;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_FinalInspection_No1":
                    TableName = CGeneral.TableName.ODM_FinalInspection_No1;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_FinalInspection_No2":
                    TableName = CGeneral.TableName.ODM_FinalInspection_No2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "37") // ODM Outdoor Ft1
        {
            if (ViewState["Manpower"].ToString() == "1")
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "ALL";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Inspection":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Inspection";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "SRC_Assy":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "SRC_Assy";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Laser_Mark":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Laser_Mark";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Sound_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Sound_Check";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Grease_Painting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Grease_Painting";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "LEADER";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Foreman";
                        rbSearchSelect.Items[1].Enabled = false;
                        // lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Packing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Packing";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Supervisor";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        Line = "ODM_OD1";
                        Machine = "Part_Delivery";
                        rbSearchSelect.Items[1].Enabled = false;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (ddlMachine.SelectedValue)
                {
                    case "Inspection_Stator_Assy":
                        TableName = CGeneral.TableName.odm_od_stator_assy;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Group_Lot_Number";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "SRC":
                        TableName = CGeneral.TableName.odm_od_SRC;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Stator_Serial_QR_Code";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "Laser_Marking":
                        TableName = CGeneral.TableName.odm_od_marker;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Mark_Lot_Number";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "Sound_Check":
                        TableName = CGeneral.TableName.odm_od_soundcheck;
                        TypeData = "MES";
                        rbSearchSelect.Items[1].Enabled = true;
                        lbSerialType.Text = "Lot_No";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }

        }
        //else if (ddlLine.SelectedValue == "37") // ODM Outdoor Ft1
        //{
        //    switch (ddlMachine.SelectedValue)
        //    {

        //    }
        //}
        else if (ddlLine.SelectedValue == "35") // Mecha Line 7
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Crank_Shaft_Measuring":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Cylinder_Measuring":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Front_Head_Measuring":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Piston_Measuring":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Rear_Head_Measuring":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Matching":
                    TableName = CGeneral.TableName.etd_match_result_2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Torque_Check":
                    TableName = CGeneral.TableName.vi_torque_check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "39") // Mecha Line 7
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Top_Bottom_Welding":
                    TableName = CGeneral.TableName.Scada_Main_Assy_FG;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;


                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "14") // Mecha Line 3
        {
            switch (ddlMachine.SelectedValue)
            {
                case "Crank_Shaft":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Cylinder":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Front_Head":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Piston":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Rear_Head":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Torque_Check":
                    TableName = CGeneral.TableName.vi_torque_check;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "34") // Machine 2YC
        {
            switch (ddlMachine.SelectedValue)
            {
                case "MC_Crank_Shaft":
                    TableName = CGeneral.TableName.vi_MC_cs;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Cylinder":
                    TableName = CGeneral.TableName.vi_MC_cy;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Front_Head":
                    TableName = CGeneral.TableName.vi_MC_fh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Piston":
                    TableName = CGeneral.TableName.vi_MC_pt;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Rear_Head":
                    TableName = CGeneral.TableName.vi_MC_rh;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    lbSerialType.Text = "Serial No";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }

    }


    private void LoadGrid()
    {
        if (dt.Rows.Count > 0)
        {
            rptData.DataSource = dt;
            rptData.DataBind();

            //GridView1.DataSource = dt;

            //GridView1.DataBind();
        }
        else
        {
            dt = new DataTable();
            dt.TableName = "null";
            dt.Columns.Add(" ");
            dt.Rows.Add("");

            rptData.DataSource = dt;
            rptData.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        GetData();
        HiddenField1.Value = txtPrdDate.Text.Trim();
        LoadGrid();

    }

    public string GenHeader()
    {
        string result = "";
        result = "<tr>";

        //result += "                                        <th>Serial No</th>";
        //result += "                                        <th>Model</th>";
        //result += "                                        <th>ModelCode</th>";
        //result += "                                        <th>Pipe No</th>";
        //result += "                                        <th>Oil Charge</th>";
        //result += "                                        <th>Running Test</th>";
        //result += "                                        <th>Weight Check</th>";
        //result += "                                        <th>Hold By</th>";
        //result += "                                        <th>Hold Date</th>";
        //result += "                                        <th>Status</th>";

        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn col in dt.Columns)
            {
                result += "<th>" + col.Caption + "</th>" + Environment.NewLine;
            }
        }
        else
        {
            result += "<th></th>";
        }

        result += "</tr>";
        return result;
    }

    public string GenDataRow()
    {
        string result = "";

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                result += "<tr>";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    result += "<td>" + row[i].ToString() + "</td>" + Environment.NewLine;
                }
                result += "</tr>";
            }
        }
        else
        {
            result += "<td></td>";
        }




        return result;
    }


    protected void rblSearchType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbSearchSelect.SelectedValue == "1") // Datetime
        {
            search_datetime.Visible = true;
            search_serial.Visible = false;
        }
        else
        {
            search_datetime.Visible = false;
            search_serial.Visible = true;
        }
    }
    protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        oGenCon.GenDDLMachineByLine(CGeneral.TypeSelect.Selected, ddlMachine, ddlLine.SelectedValue);
        InitialDDL();
        dt = new DataTable();

    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Repeater headerRepeater = e.Item.FindControl("Header1") as Repeater;
            headerRepeater.DataSource = dt.Columns;
            headerRepeater.DataBind();
        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater columnRepeater = e.Item.FindControl("Item1") as Repeater;
            var row = e.Item.DataItem as System.Data.DataRowView;
            columnRepeater.DataSource = row.Row.ItemArray;
            columnRepeater.DataBind();
        }
    }
    protected void ddlMachine_SelectedIndexChanged(object sender, EventArgs e)
    {
        InitialDDL();
        dt = new DataTable();
        LoadGrid();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)

        //    e.Row.TableSection = TableRowSection.TableHeader;
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        //gv.UseAccessibleHeader = true;
        if ((gv.ShowHeader == true && gv.Rows.Count > 0)
            || (gv.ShowHeaderWhenEmpty == true))
        {
            //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (gv.ShowFooter == true && gv.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void btExport_Click(object sender, EventArgs e)
    {
        try
        {
            string DateStart = "";
            string DateEnd = "";


            DateStart = txtPrdDate.Text.Trim().Split('-')[0].Trim();
            DateEnd = txtPrdDate.Text.Trim().Split('-')[1].Trim();

            if (rbSearchSelect.SelectedValue == "1")
            {
                oSerialType = CGeneral.SerialType.None;
            }

            string LineName = "";
            string MachineName = "";
            LineName = ddlLine.SelectedItem.Text;
            MachineName = ddlMachine.SelectedItem.Text;
            if (ViewState["Manpower"].ToString() == "1")
            {
                Response.Redirect("ExportExcelDataHistory.ashx?DateStart=" + DateStart + "&DateEnd=" + DateEnd + "&LineNo=" + ddlLine.SelectedValue
                + "&Machine=" + ddlMachine.SelectedValue + "&checkSelect=" + oSerialType.ToString() + "&ListSerial=" + txtSerialNo.Text.Trim()
                + "&LineName=" + LineName + "&MachineName=" + MachineName + "&Manpower=1");
            }
            else
            {
                Response.Redirect("ExportExcelDataHistory.ashx?DateStart=" + DateStart + "&DateEnd=" + DateEnd + "&LineNo=" + ddlLine.SelectedValue
                + "&Machine=" + ddlMachine.SelectedValue + "&checkSelect=" + oSerialType.ToString() + "&ListSerial=" + txtSerialNo.Text.Trim()
                + "&LineName=" + LineName + "&MachineName=" + MachineName);
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }
}