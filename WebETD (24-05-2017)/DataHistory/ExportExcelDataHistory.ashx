<%@ WebHandler Language="C#" Class="ExportExcelDataHistory" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelDataHistory : IHttpHandler
{
    //CHistoryData oHis = new CHistoryData();
    ConnectDBDCI oConnDCI = new ConnectDBDCI();
    ConnectDBFac3 oConnFac3 = new ConnectDBFac3();
    ConnectDBIoTServerTonMecha oConnMecha = new ConnectDBIoTServerTonMecha();

    string dtStart = "";
    string dtEnd = "";
    string LineNo = "";
    string LineName = "";
    string MachineName = "";
    string Machine = "";
    string ListSerial = "";
    string checkSelect = "";
    string _TableName = "";
    string DBName = "";
    string Manpower = null;
    string Line = "";

    string Name = "";
    CGeneral.SerialType oSerialType = CGeneral.SerialType.Label;
    CGeneral.DBName oDBName = CGeneral.DBName.dbIoTFac3;
    CHistoryData oHis = new CHistoryData();

    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        LineNo = context.Request.QueryString["LineNo"].ToString();
        Machine = context.Request.QueryString["Machine"].ToString();
        ListSerial = context.Request.QueryString["ListSerial"].ToString();
        checkSelect = context.Request.QueryString["checkSelect"].ToString();
        LineName = context.Request.QueryString["LineName"].ToString();
        MachineName = context.Request.QueryString["MachineName"].ToString();
        if (context.Request.QueryString["Manpower"] != null)
        {
            Manpower = context.Request.QueryString["Manpower"].ToString();
        }
        
        //DataTable dTable = new DataTable();

        string LeakLineNo = "";
        DataTable dt = new DataTable();
        CGeneral.TableName TableName = CGeneral.TableName.None;
        string MCName = "";
        string TypeData = "DL";
        string M_Line = "";
        string M_Machine = "";

        if (LineNo == "4") // Main Assy
        {
            if (Manpower != null && Manpower == "1")
            {
                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "ALL";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Air_Gap":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Air_Gap";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Rotor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Rotor";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Rotor_Yakibame":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Rotor_Yakibame";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Top":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Top";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Brazing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Brazing";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Pipe_Yakibame":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Pipe_Yakibame";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Top_Fitting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Top_Fitting";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Pipe":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Pipe";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "ALL";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Foreman";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;

                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Supervisor";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Main6";
                        M_Machine = "Part_Delivery";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else{
                switch (Machine)
                {
                    case "Main01":
                        TableName = CGeneral.TableName.Rotor_Yakibame_New;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.RearAndRotor;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main02":
                        TableName = CGeneral.TableName.Magnetize;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.RearHead;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main03":
                        TableName = CGeneral.TableName.Pipe_Yakibame;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main04":
                        TableName = CGeneral.TableName.Tack_Welding;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main05":
                        TableName = CGeneral.TableName.MagnetCenter;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main06":
                        TableName = CGeneral.TableName.AirGap;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main07":
                        TableName = CGeneral.TableName.ElectricalConduction;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "Main08":
                        TableName = CGeneral.TableName.TopBottomWelding;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.Pipe;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }
                
            


        }
        else if (LineNo == "1") // Rear Head Finish Line
        {
            if (Manpower != null && Manpower == "1")
            {
                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_RH6";
                        M_Machine = "ALL";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_RH6";
                        M_Machine = "Process_Inspaction";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_RH6";
                        M_Machine = "Oparetor";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_RH6";
                        M_Machine = "Part_Delivery";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_RH6";
                        M_Machine = "LEADER";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_RH6";
                        M_Machine = "Foreman";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_RH6";
                        M_Machine = "Supervisor";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (Machine)
                {
                    case "RH_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_RH;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.RearHead;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }
            
        }
        else if (LineNo == "6") // Cylinder Finish Line
        {
            if (Manpower != null && Manpower == "1")
            {
                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CY6";
                        M_Machine = "ALL";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CY6";
                        M_Machine = "Process_Inspaction";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CY6";
                        M_Machine = "Oparetor";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CY6";
                        M_Machine = "Part_Delivery";
                
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CY6";
                        M_Machine = "LEADER";
                 
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CY6";
                        M_Machine = "Foreman";
                      
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CY6";
                        M_Machine = "Supervisor";
                    
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (Machine)
                {
                    case "CYLINDER_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_CY;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.Cylinder;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }
            
        }
        else if (LineNo == "7") // Crank Shaft Finish Line
        {
            if (Manpower != null && Manpower == "1")
            {

                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "ALL";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "Process_Inspaction";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "Oparetor";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "Part_Delivery";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "LEADER";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "Foreman";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "Supervisor";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Lubrite_Machine":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_CS6";
                        M_Machine = "Lubrite_Machine";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (Machine)
                {
                    case "CRANKSHAFT_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_CS;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.CrankShaft;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }
            
        }
        else if (LineNo == "16") // Front Head Finish Line
        {
            if (Manpower != null && Manpower == "1")
            {

                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_FH6";
                        M_Machine = "ALL";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_FH6";
                        M_Machine = "Process_Inspaction";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_FH6";
                        M_Machine = "Oparetor";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_FH6";
                        M_Machine = "Part_Delivery";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_FH6";
                        M_Machine = "LEADER";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_FH6";
                        M_Machine = "Foreman";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_FH6";
                        M_Machine = "Supervisor";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (Machine)
                {
                    case "FRONTHEAD_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_FH;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.FrontHead;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }
            
        }
        else if (LineNo == "5") // Piston Finish Line
        {
            if (Manpower != null && Manpower == "1")
            {

                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_PT6";
                        M_Machine = "ALL";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Process_Inspaction":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_PT6";
                        M_Machine = "Process_Inspaction";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Oparetor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_PT6";
                        M_Machine = "Oparetor";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_PT6";
                        M_Machine = "Part_Delivery";
                        
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_PT6";
                        M_Machine = "LEADER";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_PT6";
                        M_Machine = "Foreman";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "MC_PT6";
                        M_Machine = "Supervisor";
                       
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (Machine)
                {
                    case "PISTON_LASER":
                        TableName = CGeneral.TableName.MC_LaserMark_Piston;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.Piston;
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }
            
        }
        else if (LineNo == "2") // Pipe Line
        {
            switch (Machine)
            {
                case "PipeMarking":
                    TableName = CGeneral.TableName.PipeMarking;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT_103;
                    break;
                case "PipeIDCheck":
                    TableName = CGeneral.TableName.PipeIDCheck2;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT_103;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "8") // Stator Line
        {
            if (Manpower != null && Manpower == "1")
            {
                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "ALL";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "PD_Set_Pallet":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "PD_Set_Pallet";
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "PD_Twist_Cut":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "PD_Twist_Cut";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Insert_Tube":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "Insert_Tube";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Teminal_Crime":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "Teminal_Crime";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Appearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "Appearance_Check";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "LEADER";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "Foreman";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Characteristics_Test":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "Characteristics_Test";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "Supervisor";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Motor6";
                        M_Machine = "Part_Delivery";
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
                switch (Machine)
                {
                    case "STR_InsulatorLaserMarking":
                        TableName = CGeneral.TableName.Stator_LaserMarking;
                        TypeData = "MES";
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "STR_CharecteristicMeasurement":
                        TableName = CGeneral.TableName.Stator_Characteristic;
                        TypeData = "MES";
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    default:
                        break;
                }
            }
            
        }
        else if (LineNo == "9") // Rotor Line
        {
            switch (Machine)
            {
                case "RotorAssyMarking":
                    TableName = CGeneral.TableName.RotorLaserMarking;
                    TypeData = "MES";
                    oDBName = CGeneral.DBName.dbIoT_103;
                    break;
                case "Rotor_Riveting":
                    TableName = CGeneral.TableName.Rotor_Riveting;
                    TypeData = "MES";
                    oDBName = CGeneral.DBName.dbIoT_103;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "10") // Final Line
        {
            if (Manpower != null && Manpower == "1")
            {
                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "ALL";
                        break;
                    case "Label_Printing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Label_Printing";
                        break;
                    case "Dehydration_Veccum_take_off":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Dehydration_Veccum_take_off";
                        break;
                    case "Running_Test":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Running_Test";
                        break;
                    case "N2_Leck_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "N2_Leck_Check";
                        break;
                    case "Appearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Appearance_Check";
                        break;
                    case "Weight_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Weight_Check";
                        break;
                    case "Loading":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Loading";
                        break;
                    case "Paint_band":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Paint_band";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Part_Delivery";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "LEADER";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Foreman";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Final6";
                        M_Machine = "Supervisor";
                        break;
                    default:
                        break;
                }
                oSerialType = CGeneral.SerialType.None;
                oDBName = CGeneral.DBName.dbIoTFac3; 
            }
            else
            {
                switch (Machine)
                {
                    case "FN_LabelPrinting":
                        TableName = CGeneral.TableName.vi_LabelPrinting;
                        TypeData = "MES";
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_OilFilling":
                        TableName = CGeneral.TableName.vi_FN_OilFilling;
                        TypeData = "MES";
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_RunningTest":
                        TableName = CGeneral.TableName.FN_RunningTest;
                        TypeData = "MES";
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_FinalWeightCheck":
                        TableName = CGeneral.TableName.vi_FN_WeightCheck;
                        TypeData = "MES";
                        oDBName = CGeneral.DBName.dbIoT_103;
                        break;
                    case "FN_APCheck":
                        TableName = CGeneral.TableName.vi_Appearance_Detail;
                        TypeData = "MES";
                        oDBName = CGeneral.DBName.dbIoT;
                        M_Line = "6";
                        break;
                    default:
                        break;
                }
                oSerialType = CGeneral.SerialType.Label;
            }
            
        }
        else if (LineNo == "22") // SCR Line 4
        {
            switch (Machine)
            {
                case "LabelPrintingLine4":
                    TableName = CGeneral.TableName.PD_LabelLine4;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "SCR_OilCharge":
                    TableName = CGeneral.TableName.SCR_OilCharge;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_RunningTest":
                    TableName = CGeneral.TableName.SCR_runningtest;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_LowVoltage":
                    TableName = CGeneral.TableName.SCR_LowVoltage;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_N2LeakCheck":
                    TableName = CGeneral.TableName.SCR_N2LeakCheck;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "SCR_AppCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    M_Line = "4";
                    break;
                case "SCR_WeightCheck":
                    TableName = CGeneral.TableName.SCR_WeightCheck;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "23") // Main Assy Line 3
        {
            switch (Machine)
            {
                case "MainAssemblyLine3":
                    TableName = CGeneral.TableName.MainAssemblyLine3;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "11") // Main Assy Line 3
        {
            if(Manpower != null && Manpower == "1")
            {
                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "ALL";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Supervisor";
                        break;
                    case "Front_Head_Reviting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Front_Head_Reviting";
                        break;
                    case "Front_Head_Assembly":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Front_Head_Assembly";
                        break;
                    case "Oiling":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Oiling";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "LEADER";
                        break;
                    case "Clearance_Check1":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Clearance_Check1";
                        break;
                    case "Clearance_Check2":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Clearance_Check2";
                        break;
                    case "Drivider_Press_Fitting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Drivider_Press_Fitting";
                        break;
                    case "Rear_Head_Assembly":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Rear_Head_Assembly";
                        break;
                    case "Part_Loader":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Part_Loader";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Foreman";
                        break;
                    case "Clearance_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "Mecha";
                        M_Machine = "Clearance_Check";
                        break;


                    default:
                        break;
                }
            }
            oSerialType = CGeneral.SerialType.None;
            oDBName = CGeneral.DBName.dbIoTFac3; 
        }
        else if (LineNo == "24") // Pipe Check Equipment Line 3
        {
            switch (Machine)
            {
                case "PipeCheckEquipmentLine3":
                    TableName = CGeneral.TableName.PipeCheckEquipmentLine3;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "36") // Pipe Check Equipment Line 4
        {
            switch (Machine)
            {
                case "PipeCheckEquipmentLine4":
                    TableName = CGeneral.TableName.PipeL4_PipeCheckEquipment;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "39") // Pipe Check Equipment Line 4
        {
            switch (Machine)
            {
                case "Top_Bottom_Welding":
                    TableName = CGeneral.TableName.Scada_Main_Assy_FG;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "30") // Final Line 1
        {
            switch (Machine)
            {
                case "LabelPrintingLine1":
                    TableName = CGeneral.TableName.PD_LabelLine1;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL1_HVTest":
                    TableName = CGeneral.TableName.Line1_HVTest;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_OilCharge":
                    TableName = CGeneral.TableName.Line1_OilCharge;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_RunningTest":
                    TableName = CGeneral.TableName.Line1_RunningTest;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_WeightCheck":
                    TableName = CGeneral.TableName.Line1_WeightCheck;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL1_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    M_Line = "1";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "31") // Final Line 2
        {
            switch (Machine)
            {
                case "LabelPrintingLine2":
                    TableName = CGeneral.TableName.PD_LabelLine2;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL2_HVTest":
                    TableName = CGeneral.TableName.Line2_HVTest;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL2_OilCharge":
                    TableName = CGeneral.TableName.Line2_OilCharge;
                    TypeData = "MES";
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
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL2_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    M_Line = "2";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "27") // Final Line 3
        {
            switch (Machine)
            {
                case "LabelPrintingLine3":
                    TableName = CGeneral.TableName.PD_LabelLine3;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL3_HVTest":
                    TableName = CGeneral.TableName.Line3_HVTest;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_OilCharge":
                    TableName = CGeneral.TableName.Line3_OilCharge;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_RunningTest":
                    TableName = CGeneral.TableName.Line3_RunningTest;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_WeightCheck":
                    TableName = CGeneral.TableName.Line3_WeightCheck;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL3_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    M_Line = "3";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "28") // Final Line 5
        {
            switch (Machine)
            {
                case "LabelPrintingLine5":
                    TableName = CGeneral.TableName.PD_LabelLine5;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbDCI;
                    break;
                case "FL5_OilCharge":
                    TableName = CGeneral.TableName.Line5_OilCharge;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_RunningTest":
                    TableName = CGeneral.TableName.Line5_RunningTest;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_WeightCheck":
                    TableName = CGeneral.TableName.Line5_WeightCheck;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                case "FL5_APCheck":
                    TableName = CGeneral.TableName.vi_Appearance_Detail;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Label;
                    oDBName = CGeneral.DBName.dbIoT;
                    M_Line = "5";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "29") // Main Scroll Line 4
        {
            switch (Machine)
            {
                case "HousingPress":
                    TableName = CGeneral.TableName.MainScroll_HousingPress;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoT;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "17") // Leak Check Common Line 1
        {
            switch (Machine)
            {
                case "LCM1_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "1";
                    break;
                case "LCM1_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "1";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "18") // Leak Check Common Line 3
        {
            switch (Machine)
            {
                case "LCM3_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "3";
                    break;
                case "LCM3_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "3";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "19") // Leak Check Common Line 5
        {
            switch (Machine)
            {
                case "LCM5_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "5";
                    break;
                case "LCM5_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "5";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "20") // Leak Check Common Line 6
        {
            switch (Machine)
            {
                case "LCM6_LeakCheckOK":
                    TableName = CGeneral.TableName.vi_Leak_Check;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "6";
                    break;
                case "LCM6_LeakCheckRework":
                    TableName = CGeneral.TableName.vi_leak_rework;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "6";
                    break;
                case "LCM6_LeakCheckDetail":
                    TableName = CGeneral.TableName.vi_leak_NG_monitor;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.Pipe;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = "6";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "33") // ODM
        {
            switch (Machine)
            {
                case "ODM_Demagnetize_No1":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No1;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No2":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No2;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No3":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No3;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Demagnetize_No4":
                    TableName = CGeneral.TableName.ODM_Demagnetize_No4;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_Magnetize":
                    TableName = CGeneral.TableName.ODM_Magnetize;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_FinalInspection_No1":
                    TableName = CGeneral.TableName.ODM_FinalInspection_No1;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                case "ODM_FinalInspection_No2":
                    TableName = CGeneral.TableName.ODM_FinalInspection_No2;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoT;
                    //LineNo = "6";
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "37") // ODM Outdoor Ft1
        {
            if (Manpower != null && Manpower == "1")
            {
                switch (Machine)
                {
                    case "-ALL-":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "ALL";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Inspection":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Inspection";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "SRC_Assy":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "SRC_Assy";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Laser_Mark":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Laser_Mark";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Sound_Check":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Sound_Check";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Grease_Painting":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Grease_Painting";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "LEADER":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "LEADER";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Foreman":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Foreman";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Packing":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Packing";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Supervisor":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Supervisor";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    case "Part_Delivery":
                        TableName = CGeneral.TableName.ManPowerLog;
                        TypeData = "MES";
                        M_Line = "ODM_OD1";
                        M_Machine = "Part_Delivery";
                        oSerialType = CGeneral.SerialType.None;
                        oDBName = CGeneral.DBName.dbIoTFac3;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
            }
            else{
                switch (Machine)
                {
                    case "Inspection_Stator_Assy":
                        TableName = CGeneral.TableName.odm_od_stator_assy;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "SRC":
                        TableName = CGeneral.TableName.odm_od_SRC;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "Laser_Marking":
                        TableName = CGeneral.TableName.odm_od_marker;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    case "Sound_Check":
                        TableName = CGeneral.TableName.odm_od_soundcheck;
                        TypeData = "MES";
                        oSerialType = CGeneral.SerialType.SerialNo;
                        oDBName = CGeneral.DBName.dbODM;
                        //LineNo = "6";
                        break;
                    default:
                        break;
                }
                
            }
        }
        else if (LineNo == "35") // Mecha Line 6
        {
            switch (Machine)
            {
                case "Crank_Shaft":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Cylinder":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Front_Head":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Piston":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Rear_Head":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Matching":
                    TableName = CGeneral.TableName.etd_match_result_2;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Torque_Check":
                    TableName = CGeneral.TableName.vi_torque_check;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    LeakLineNo = LineNo;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "14") // Mecha Line 3
        {
            switch (Machine)
            {
                case "Crank_Shaft":
                    TableName = CGeneral.TableName.vi_cs;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Cylinder":
                    TableName = CGeneral.TableName.vi_cy;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Front_Head":
                    TableName = CGeneral.TableName.vi_fh;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Piston":
                    TableName = CGeneral.TableName.vi_pt;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Rear_Head":
                    TableName = CGeneral.TableName.vi_rh;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "Torque_Check":
                    TableName = CGeneral.TableName.vi_torque_check;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }
        else if (LineNo == "34") // Machine 2YC
        {
            switch (Machine)
            {
                case "MC_Crank_Shaft":
                    TableName = CGeneral.TableName.vi_MC_cs;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Cylinder":
                    TableName = CGeneral.TableName.vi_MC_cy;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Front_Head":
                    TableName = CGeneral.TableName.vi_MC_fh;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Piston":
                    TableName = CGeneral.TableName.vi_MC_pt;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                case "MC_Rear_Head":
                    TableName = CGeneral.TableName.vi_MC_rh;
                    TypeData = "MES";
                    oSerialType = CGeneral.SerialType.SerialNo;
                    oDBName = CGeneral.DBName.dbIoTFac2;
                    break;
                default:
                    break;
            }
        }



        if (checkSelect == "None")
        {
            oSerialType = CGeneral.SerialType.None;
        }
        dt = oHis.GetDataMESIoTServer(TableName, dtStart, dtEnd, "", oSerialType, ListSerial, oDBName, LeakLineNo,M_Line,M_Machine);

        //dTable = oHis.GetDataMESIoTServer(TableName, dtStart, dtEnd, Model);

        Name = "IoTData_" + DateTime.Now.Year.ToString()
                + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00")
                + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00")
                + "_" + LineName + "_" + MachineName;

        if (checkSelect == "None")
        {
            Name += "_" + dtStart + " to " + dtEnd;
        }
        else
        {

        }

        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");

        StringBuilder sb = new StringBuilder();
        // Set Header
        string Header = "";
        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn column in dt.Columns)
            {
                Header += column.ColumnName + ",";
            }
        }
        sb.AppendLine(Header);


        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Detail = "";

                foreach (object data in dt.Rows[i].ItemArray)
                {
                    Detail +=  data + ",";
                }
                sb.AppendLine(Detail);
            }
        }

        //context.Response.Write(sb.ToString());

        //the most easy way as you have type it

        context.Response.Charset = "windows-874";
        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-874");
        context.Response.Write(sb.ToString());
        context.Response.Flush();
        context.Response.End();


    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }




}