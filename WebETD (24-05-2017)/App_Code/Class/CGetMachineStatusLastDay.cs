using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for CGetMachineStatus
/// </summary>
public class CGetMachineStatusLastDay
{
    ConnectDBIoTServerTon oConTon = new ConnectDBIoTServerTon();
    ConnectDBIoTServerTonMecha oConnTonMecha = new ConnectDBIoTServerTonMecha();
    ConnectDB oConnIoTCosty = new ConnectDB();
    ConnectDBPDB oConPDB = new ConnectDBPDB();
    ConnectDBFac3 oConFac = new ConnectDBFac3();

    public CGetMachineStatusLastDay()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<MDMachineStatus> GetStatusRotorYakibame(DateTime Start, DateTime Stop)
    {
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        
        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (dateNow.TimeOfDay > TimeSpan.Parse("20:00:00") || dateNow.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT TOP 1 [RY_ID],[DateShift],[ModelNo],[MachineNo],[CycleStartTime],[CycleEndTime],[No1_RotorStationNo],[No1_MechaAssyNumber]";
        sql.CommandText += " ,[No1_RotorNumber],[No1_Result],[No2_RotorStationNo],[No2_MechaAssyNumber],[No2_RotorNumber],[No2_Result],[InsertDate]";
        sql.CommandText += " FROM [Rotor_Yakibame] WHERE CycleStartTime >= @ctStart AND CycleEndTime < @ctEnd ";
        sql.CommandText += " AND InsertDate >= @strDate AND InsertDate <= @endDate AND (No1_Result = 'OK' OR No2_Result = 'OK')";
        sql.CommandText += " ORDER BY InsertDate DESC";

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = dateNow.Date + new TimeSpan(8,0,0);
            endDate = dateNow.Date + new TimeSpan(20, 0, 0);            
        }
        else
        {
            strDate = dateNow.Date + new TimeSpan(20, 0, 0);
            endDate = dateNow.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        sql.Parameters.Add(new SqlParameter("@ctStart", Convert.ToInt32(timeStr)));
        sql.Parameters.Add(new SqlParameter("@ctEnd", Convert.ToInt32(timeEnd)));
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConTon.Query(sql);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["MachineNo"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = "TRUE";
        }
        else
        {            
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = "FALSE";
        }
        oList.Add(oMDMC);

        return oList;
    }

    public List<MDMachineStatus> GetStatusPipeYakibame(DateTime Start, DateTime Stop)
    {
        List<MDMachineStatus> oList = new List<MDMachineStatus>();

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (dateNow.TimeOfDay > TimeSpan.Parse("20:00:00") || dateNow.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT TOP 1 [PY_ID],[DateShift],[ModelNo],[MachineNo],[CycleStartTime],[CycleEndTime],[PYStationNo],[PipeNumber]";
        sql.CommandText += " ,[StatorNumber],[Result],[InsertDate]";
        sql.CommandText += " FROM [Pipe_Yakibame] WHERE CycleStartTime >= @ctStart AND CycleEndTime < @ctEnd AND ";
        sql.CommandText += " InsertDate >= @strDate AND InsertDate <= @endDate AND Result = 'OK'";
        sql.CommandText += " ORDER BY InsertDate DESC";

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = dateNow.Date + new TimeSpan(8, 0, 0);
            endDate = dateNow.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = dateNow.Date + new TimeSpan(20, 0, 0);
            endDate = dateNow.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        sql.Parameters.Add(new SqlParameter("@ctStart", Convert.ToInt32(timeStr)));
        sql.Parameters.Add(new SqlParameter("@ctEnd", Convert.ToInt32(timeEnd)));
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConTon.Query(sql);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["MachineNo"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = "FALSE";
        }
        oList.Add(oMDMC);

        return oList;
    }

    public List<MDMachineStatus> GetStatusMagnetCenter(DateTime Start, DateTime Stop)
    {
        List<MDMachineStatus> oList = new List<MDMachineStatus>();

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (dateNow.TimeOfDay > TimeSpan.Parse("20:00:00") || dateNow.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT TOP 1 [MGC_ID],[DateShift],[ModelNo],[MachineNo],[PipeNumber],[CycleStartTime],[CycleEndTime],[CentralHeightOfMagnet]";
        sql.CommandText += " ,[IntegratedJudgement],[RotorNumber],[InsertDate]";
        sql.CommandText += " FROM [MagnetCenter] WHERE [CycleStartTime] >= @ctStart AND [CycleEndTime] < @ctEnd AND ";
        sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate";
        sql.CommandText += " ORDER BY [InsertDate] DESC";

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = dateNow.Date + new TimeSpan(8, 0, 0);
            endDate = dateNow.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = dateNow.Date + new TimeSpan(20, 0, 0);
            endDate = dateNow.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        sql.Parameters.Add(new SqlParameter("@ctStart", Convert.ToInt32(timeStr)));
        sql.Parameters.Add(new SqlParameter("@ctEnd", Convert.ToInt32(timeEnd)));
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConTon.Query(sql);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["MachineNo"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = "FALSE";
        }
        oList.Add(oMDMC);

        return oList;
    }

    public DataTable GetMachineStatus(DateTime Start, DateTime Stop,string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region set query
        if (MCName == "Rotor Yakibame")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT [RY_ID],[DateShift],[ModelNo],[MachineNo],replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime],[No1_RotorStationNo],[No1_MechaAssyNumber]";
            sql.CommandText += " ,[No1_RotorNumber],[No1_Result],[No2_RotorStationNo],[No2_MechaAssyNumber],[No2_RotorNumber],[No2_Result],[InsertDate]";
            sql.CommandText += " FROM [Rotor_Yakibame] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd ";
            sql.CommandText += " AND InsertDate >= @strDate AND InsertDate <= @endDate AND (No1_RotorNumber != '' OR No2_RotorNumber != '') AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY InsertDate DESC";
            MachineId = "MC-17060056";
        }
        else if (MCName == "Pipe Yakibame")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT [PY_ID],[DateShift],[ModelNo],[MachineNo],replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime],[PYStationNo],[PipeNumber]";
            sql.CommandText += " ,[StatorNumber],[Result],[InsertDate]";
            sql.CommandText += " FROM [Pipe_Yakibame] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " InsertDate >= @strDate AND InsertDate <= @endDate AND PipeNumber != '' AND replace([CycleEndTime],' ','0') != '000000' ";
            sql.CommandText += " ORDER BY InsertDate DESC";
            MachineId = "MC-17060053";
        }
        else if (MCName == "Magnetize")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT [MG_ID],[DateShift],[ModelNo],[MachineNo]";
            sql.CommandText += " ,replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime]";
            sql.CommandText += " ,[MechaAssyNumber],[MagnetizeYorcNo],[HeightOfRotor],[No7_JudgementResult],[MagnetizationVoltage]";
            sql.CommandText += " ,[VoltageJudgement],[MagnetizationCurrent],[No12_JudgementResult],[FluxMeasurements],[RotorTemperature]";
            sql.CommandText += " ,[No16_JudgementResult],[IntegratedJudgementResult],[InsertDate]";
            sql.CommandText += " FROM [Magnetize]";
            sql.CommandText += " WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND";
            sql.CommandText += " InsertDate >= @strDate AND InsertDate <= @endDate AND (replace([CycleStartTime],' ','0') != '000000' AND replace([CycleEndTime],' ','0') != '000000')";
            sql.CommandText += " AND MechaAssyNumber != '' AND IntegratedJudgementResult != '' AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY InsertDate DESC";
            MachineId = "MC-17060058";
        }
        else if (MCName == "Magnet Center")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT [MGC_ID],[DateShift],[ModelNo],[MachineNo],[PipeNumber],replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime],[CentralHeightOfMagnet]";
            sql.CommandText += " ,[IntegratedJudgement],[RotorNumber],[InsertDate]";
            sql.CommandText += " FROM [MagnetCenter] WHERE replace([CycleEndTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND PipeNumber != '' AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-17060059";
        }
        else if (MCName == "Air Gap")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT [AG_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as CycleStartTime,replace([CycleEndTime],' ','0') as CycleEndTime,[AGCheck],[InsertDate]";
            sql.CommandText += " FROM [AirGap] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND PartSerialNo != '' AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "Electrical Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT [EC_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as CycleStartTime,replace([CycleEndTime],' ','0') as CycleEndTime,[IntegratedJudgementResult]";
            sql.CommandText += " ,[EC_UV],[EC_VW],[EC_WU],[InsertDate]";
            sql.CommandText += " FROM [ElectricalConduction] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND PartSerialNo != '' AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "TackWelding")
        {
            sql.CommandText = "";
            sql.CommandText += "SELECT [TW_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
            sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[TimeWeldingStep1_3Point],[TimeWeldingStep2_3Point],[TimeWeldingStep1_6Point]";
            sql.CommandText += " ,[TimeWeldingStep2_6Point],[WeldingTipToolLife],[TimeChargeWireWeldingTorchNo1],[TimeChargeWireWeldingTorchNo2]";
            sql.CommandText += " ,[TimeChargeWireWeldingTorchNo3],[InsertDate]";
            sql.CommandText += " FROM [Tack_Welding] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";

            //sql.CommandText = "SELECT [MG_ID],[DateShift],[ModelNo],[MachineNo]";
            //sql.CommandText += " ,replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime]";
            //sql.CommandText += " ,[MechaAssyNumber],[MagnetizeYorcNo],[HeightOfRotor],[No7_JudgementResult],[MagnetizationVoltage]";
            //sql.CommandText += " ,[VoltageJudgement],[MagnetizationCurrent],[No12_JudgementResult],[FluxMeasurements],[RotorTemperature]";
            //sql.CommandText += " ,[No16_JudgementResult],[IntegratedJudgementResult],[InsertDate]";
            //sql.CommandText += " FROM [Magnetize]";
            //sql.CommandText += " WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND";
            //sql.CommandText += " InsertDate >= @strDate AND InsertDate <= @endDate AND (replace([CycleStartTime],' ','0') != '000000' AND replace([CycleEndTime],' ','0') != '000000')";
            //sql.CommandText += " AND MechaAssyNumber != '' AND IntegratedJudgementResult != '' AND replace([CycleEndTime],' ','0') != '000000'";
            //sql.CommandText += " ORDER BY InsertDate DESC";

            MachineId = "MC-999999999";
        }
        else if (MCName == "Top Bottom Welding 1")
        {
            sql.CommandText = "SELECT [TBW_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
            sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[TimeWelding_Bottom],[WeldingA_Bottom],[WeldingV_Bottom],[TimeWelding_TOP]";
            sql.CommandText += " ,[WeldingA_TOP],[WeldingV_TOP],[WeldingTipToolLift],[TimeChargeWireWelding],[InsertDate]";
            sql.CommandText += " FROM [TopBottomWelding] WHERE [MachineNo] = '01' AND replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND replace([CycleEndTime],' ','0') != '000000'";
            //sql.CommandText += " AND PartSerialNo != ''";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "Top Bottom Welding 2")
        {
            sql.CommandText = "SELECT [TBW_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
            sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[TimeWelding_Bottom],[WeldingA_Bottom],[WeldingV_Bottom],[TimeWelding_TOP]";
            sql.CommandText += " ,[WeldingA_TOP],[WeldingV_TOP],[WeldingTipToolLift],[TimeChargeWireWelding],[InsertDate]";
            sql.CommandText += " FROM [TopBottomWelding] WHERE [MachineNo] = '02' AND replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND replace([CycleEndTime],' ','0') != '000000'";
            //sql.CommandText += " AND PartSerialNo != ''";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "Top Bottom Welding 3")
        {
            sql.CommandText = "SELECT [TBW_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
            sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[TimeWelding_Bottom],[WeldingA_Bottom],[WeldingV_Bottom],[TimeWelding_TOP]";
            sql.CommandText += " ,[WeldingA_TOP],[WeldingV_TOP],[WeldingTipToolLift],[TimeChargeWireWelding],[InsertDate]";
            sql.CommandText += " FROM [TopBottomWelding] WHERE [MachineNo] = '03' AND replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND replace([CycleEndTime],' ','0') != '000000'";
            //sql.CommandText += " AND PartSerialNo != ''";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]" +
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '301'" +
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineId = "";
        }
        else
        {
            sql.CommandText = "";
            MachineId = "MC-999999999";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string MonthNow = DateTime.Now.Month.ToString();
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConTon.Query(sql);
        }

        string StatusBreak = GetMachineBreakDown("LN-1701", MachineId, strDate, endDate);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachineMechaStatus(DateTime Start, DateTime Stop, string MCName, bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region Set Query
        if (MCName == "Crank Shaft")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [crank_shaft_result]";
            sql.CommandText += " WHERE ((replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd) AND replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050042";
        }
        else if (MCName == "Cylinder")
        {
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [cylinder_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050029";
        }
        else if (MCName == "Piston")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [piston_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0')) ";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050028";
        }
        else if (MCName == "Front Head")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [front_head_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050044";
        }
        else if (MCName == "Rear Head")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [rear_head_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050043";
        }
        else if (MCName == "Cylinder Centering")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [cylinder_centering]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050045";
        }
        else if (MCName == "Rear Centering")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [rear_centering]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050046";
        }
        else if (MCName == "Tourque Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [torque_check]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050030";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]"+
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '302'"+
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineId = "";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        //Stop = Start.AddSeconds(180);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        //string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        //string[] spTimeStr = timeStr.Split('.');
        //string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }


        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {            
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }        
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConnTonMecha.Query(sql);
        }
            
        string StatusBreak = GetMachineBreakDown("LN-1701", MachineId, strDate, Stop);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {            
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachineCasingStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region Set query
        if (MCName == "Pipe Marking")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipeMarking'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17050004";
        }
        else if (MCName == "Pipe Plasma Welding")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipePlasmaWelding'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17050007";
        }
        else if (MCName == "Pipe Punch Machine")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipePunchMachine'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-99999999999";
        }
        else if (MCName == "Pipe ID Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipeIDCheck'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-99999999999";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        //string StatusBreak = GetMachineBreakDown("LN-1709", MachineId, strDate, endDate);
        //dTable.Columns.Add("Break", typeof(string));
        //if (dTable.Rows.Count > 0)
        //{
        //    dTable.Rows[0]["Break"] = StatusBreak;
        //}
        return dTable;
    }//------------- ok

    public DataTable GetMachineMotorStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region Set query
        if (MCName == "Stator Transport Unit Input Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_TransportUnit_InputSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Transport Unit Discharge Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_TransportUnit_DischargeSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Common Transport Input Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_CommonTransportInputSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Common Transport Discharg Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_CommonTransportDischargSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Insulator Laser Marking")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_InsulatorLaserMarking'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060036";
        }
        else if (MCName == "Stator Transport Winding Input Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_TransportWindingInputSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Winding No1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_WindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060037";
        }
        else if (MCName == "Stator Charecteristic Measurement")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_CharecteristicMeasurement'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060040";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1708", MachineId, strDate, endDate);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachinePistonStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        //"Laser Marking", "Surface","Blade grinding No 1", "Blade grinding No 2"
        //, "Blade grinding No 3", "Blade grinding No 4","External 1","External 2","External 3","External 4"
        //, "Internal 1", "Internal 2","Horning", "Brush"
        #region Set query
        if (MCName == "Laser Marking")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'PISTON_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17090007";
        }
        else if (MCName == "Surface")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_SurfaceGrinding'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060022";
        }
        else if (MCName == "Blade grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_BladeGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060023";
        }
        else if (MCName == "Blade grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_BladeGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060024";
        }
        else if (MCName == "Blade grinding No 3")
        {
            //MCno MPI-0077
        }
        else if (MCName == "Blade grinding No 4")
        {
            //MCno MPI-0078
        }
        else if (MCName == "External 1")
        {
            MachineId = "MC-17060025";
        }
        else if (MCName == "External 2")
        {
            MachineId = "MC-17060026";
        }
        else if (MCName == "External 3")
        {
            //McNo = MPI-0079
        }
        else if (MCName == "External 4")
        {
            //McNo = MPI-0080
        }
        else if (MCName == "Internal 1")
        {
            MachineId = "MC-17060027";
        }
        else if (MCName == "Internal 2")
        {
            MachineId = "MC-17060028";
        }
        else if (MCName == "Horning")
        {
            //McNo = MPI-0081
        }
        else if (MCName == "Brush")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060029";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]" +
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '308'" +
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineId = "";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConnIoTCosty.Query(sql);
        }
           
        string StatusBreak = GetMachineBreakDown("LN-1705", MachineId, strDate, endDate);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachineFrontheadStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region
        if (MCName == "Front Head Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'FRONTHEAD_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Front Head Internal Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_InternalGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060014";
        }
        else if (MCName == "Front Head Internal Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_InternalGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060015";
        }
        else if (MCName == "Front Head Surface Grinding")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_SurfaceGrinding'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060013";
        }
        else if (MCName == "Front Head Brushing")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060016";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]" +
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '307'" +
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineId = "";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConnIoTCosty.Query(sql);
        }       

        string StatusBreak = GetMachineBreakDown("LN-1713", MachineId, strDate, endDate);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachineCrankshaftStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        //"Crankshaft Laser","Hardening", "Crankshaft Centerless Grinding No 1"
        //, "Crankshaft Centerless Grinding No 2", "Crankshaft Centerless Grinding No 3", "Pin grinding No 1"
        //, "Pin grinding No 2", "Crankshaft Thrust Grinding No 1", "Crankshaft Thrust Grinding No 2", "Crankshaft Brushing"
        #region Set Query
        if (MCName == "Crankshaft Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'CRANKSHAFT_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17090010";
        }
        else if (MCName == "Hardening")
        {
            //McNo : MCH-0006

        }
        else if (MCName == "Crankshaft Thrust Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_ThrustGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060006";
        }
        else if (MCName == "Crankshaft Thrust Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_ThrustGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-9999999";
        }
        else if (MCName == "Crankshaft Centerless Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_CenterlessGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060003";
        }
        else if (MCName == "Crankshaft Centerless Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_CenterlessGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060004";
        }
        else if (MCName == "Crankshaft Centerless Grinding No 3")
        {
            //McNo : MCS-0051
        }
        else if (MCName == "Pin grinding No 1")
        {
            //sql.CommandText = "";
            //sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            //sql.CommandText += " FROM [Data]";
            //sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            //sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_CenterlessGrindingNo2'";
            //sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060005";
        }
        else if (MCName == "Pin grinding No 2")
        {
            //McNo : MCS-0049
        }
        else if (MCName == "Crankshaft Brushing")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-9999999";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]" +
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '306'" +
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineId = "";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConnIoTCosty.Query(sql);
        }
        

        string StatusBreak = GetMachineBreakDown("LN-1702", MachineId, strDate, endDate);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachineCylinderStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region Set query
        if (MCName == "Cylinder Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'CYLINDER_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Cylinder Surface Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_SurfaceGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060007";
        }
        else if (MCName == "Cylinder Surface Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_SurfaceGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-999999";
        }
        else if (MCName == "Cylinder BoreID Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BoreIDGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060008";
        }
        else if (MCName == "Cylinder BoreID Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BoreIDGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060009";
        }
        else if (MCName == "Cylinder Bush Hole Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BushHoleGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060010";
        }
        else if (MCName == "Cylinder Bush Hole Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BushHoleGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060011";
        }
        else if (MCName == "Cylinder Bush Hole Grinding No 3")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BushHoleGrindingNo3'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-999999";
        }
        else if (MCName == "Cylinder_Brushing")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060012";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]" +
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '305'" +
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineId = "";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConnIoTCosty.Query(sql);
        }        

        string StatusBreak = GetMachineBreakDown("LN-1703", MachineId, strDate, endDate);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachineRearheadStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region set query
        if (MCName == "Rear Head Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'RH_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "99999";
        }
        else if (MCName == "Rear Head Surface")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'RH_SURFACE'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060030";
        }
        else if (MCName == "Rear Head Brush")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'RH_BRUSH'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060033";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]" +
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '304'" +
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineId = "";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConnIoTCosty.Query(sql);
        }        

        string StatusBreak = GetMachineBreakDown("LN-1706", MachineId, strDate, endDate);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public DataTable GetMachineFinalStatus(DateTime Start, DateTime Stop, string MCName,bool Lastday)
    {
        string MachineID = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //"Label Printing", "Temp Oven", "Oil Filling", "Running Test No 1", "Running Test No 2", "Weight Check" 
        //--------- Set Command Query for each Machine -------------
        #region set query
        if (MCName == "Label Printing")
        {
            MachineID = "MC-17060052";
            sql.CommandText = "SELECT[LBP_ID],[DateMC],[Model],[LabelNo],replace(replace(CONVERT(time, dateadd(HOUR, -12, [CycleTimeStart]),108),':',''),'.0000000','') as [CycleStartTime]" +
                " ,replace(replace(CONVERT(time, dateadd(HOUR, -12, [CycleTimeEnd]),108),':',''),'.0000000','') as [CycleEndTime],[ModelName],[PipeNumber],[MFGDate],[InsertDate]" +
                " FROM [LabelPrinting]" +
                " WHERE replace(replace(CONVERT(time, dateadd(HOUR, -12, [CycleTimeStart]),108),':',''),'.0000000','') >= @ctStart AND replace(replace(CONVERT(time, dateadd(HOUR, -12, [CycleTimeEnd]),108),':',''),'.0000000','') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate)" +
                " ORDER BY InsertDate DESC";
            MachineID = "MC-17060047";
        }
        else if (MCName == "Oil Filling")
        {
            sql.CommandText = "SELECT [FNOF_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo] ,replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[AmountSettingValue],[AmountCountValue]" +
                " ,[IntegratedJudgement],[WeightCompressorBefore],[WeightCompressorAfter],[AmountOilFilling],[SpecificGravityConversion]" +
                " ,[AmountOilFilling2],[IntegratedJudgementResult],[InsertDate]" +
                " FROM [FN_OilFilling] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate)" +
                " ORDER BY InsertDate DESC";

            MachineID = "MC-17060048";
        }
        else if (MCName == "Running Test No 1")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '1' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 2")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '2' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 3")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '3' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 4")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '4' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 5")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '5' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 6")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '6' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 7")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '7' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 8")
        {
            sql.CommandText = "SELECT [FNRT_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[ConstantPressedTime],[ConstantJudgement],[RotationFrequencyArrivalTime]" +
                " ,[RotationJudgement],[ExhalationTime] ,[ExhalationJudgement],[DrivingCurrent],[DrivingJudgement],[VacuumArrivalTime],[VacuumJudgement]" +
                " ,[VacuumHoldtimeJudgement],[IntegratedJudgementResult],[InsulationInspectionResult],[ResistingPressureInspection],[WindingResistanceUV]" +
                " ,[WindingJudgement],[IntegratedJudgementResult2],[FluxMeasuredValue],[FluxJudgementResult],[TempertureSurface],[JudgementSeletedNo]" +
                " ,[MachineNumber],[InsertDate],[PeekHold1],[Average1],[PeekHold2],[Average2]" +
                " FROM [FN_RunningTest] WHERE MachineNumber = '8' AND replace([CycleStartTime],' ','0') >=  @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Weight Check")
        {
            sql.CommandText = "SELECT [FNW_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime]" +
                " ,replace([CycleEndTime],' ','0') as [CycleEndTime],[ManufacturingTime],[FinalWeight],[IntegratedJudgement],[InsertDate]" +
                " FROM [FN_WeightCheck] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd" +
                " AND (InsertDate >= @strDate AND InsertDate <= @endDate) ORDER BY InsertDate DESC";
            MachineID = "MC-9999999";
        }
        else if (MCName == "Model Change")
        {
            //--------------- Get Model Change Log form Andon Board -------------
            sql.CommandText = "SELECT [BoardID],[ChangeTime]" +
                " ,[StartTime],replace(convert(varchar, [StartTime], 8),':','') AS cycle_start_time,replace(convert(varchar, [ChangeTime], 8),':','') AS cycle_end_time" +
                " ,convert(time, [StartTime], 8) AS start_time,convert(time, [ChangeTime], 8) AS end_time" +
                " FROM [dbPDB].[dbo].[AndonChangeModel_Log] WHERE BoardID = '303'" +
                " AND (ChangeTime >= @strDate AND ChangeTime <= @endDate)" +
                " ORDER BY StartTime ASC";
            MachineID = "";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        //Stop = Start.AddSeconds(180);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        //string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        //string[] spTimeStr = timeStr.Split('.');
        //string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                strDate = Start.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                endDate = Start.Date + new TimeSpan(8, 0, 0);
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                strDate = Start.Date + new TimeSpan(20, 0, 0);
                endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
            }
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = new DataTable();
        if (MCName == "Model Change")
        {
            dTable = oConPDB.Query(sql);
        }
        else
        {
            dTable = oConTon.Query(sql);
        }

        string StatusBreak = GetMachineBreakDown("LN-1710", MachineID, strDate, Stop);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public string GetMachineBreakDown(string LineId, string MachineId, DateTime StartTime, DateTime EndTime)
    {
        string StatusBreak = "NO";

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT [BreakdownId],[RequestId],[MachineId],[StartTime],[EndTime]"+
            " FROM [PD_LineBreakDownDetail] WHERE MachineId = '" + MachineId + "'  "+
            " AND (StartTime >= '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' AND StartTime <= '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
            " AND EndTime > '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'  ";
        DataTable dtBreak = oConPDB.Query(sql);
        if (dtBreak.Rows.Count > 0)
        {
            StatusBreak = "YES";
        }

        return StatusBreak;
    }


    //-------------------- Get Machine BreakDown from Mantenace Board --------------------
    public DataTable GetDTMachineBreakDown(String Shift, DateTime DateTime,string Line)
    {
        DataTable dtBreak = new DataTable();
        DateTime StartTime = new DateTime(), EndTime = new DateTime();
        // ---- Day Shift ----
        if (DateTime.Hour >= 8 && DateTime.Hour < 20)
        {
            StartTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 8, 0, 0);
            EndTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 20, 0, 0);
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Hour >= 0 && DateTime.Hour <= 7)
            {
                StartTime = new DateTime(DateTime.AddDays(-1).Year, DateTime.AddDays(-1).Month, DateTime.AddDays(-1).Day, 20, 0, 0);
                EndTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 8, 0, 0);
            }
            else if (DateTime.Hour >= 20 && DateTime.Hour <= 23)
            {
                StartTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 20, 0, 0);
                EndTime = new DateTime(DateTime.AddDays(1).Year, DateTime.AddDays(1).Month, DateTime.AddDays(1).Day, 8, 0, 0);
            }
        }

        SqlCommand sql = new SqlCommand();

        if (Line == "" || Line == "mecha" || Line == "main")
        {
            sql.CommandText = "SELECT [AlarmID],[MCName],[StartAlarm],[EndAlarm],[AlarmStatus] " +
               "FROM [MECHA_FAC3].[dbo].[LogAlarmMCDetail] WHERE " +
               " (StartAlarm >= '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [EndAlarm] <= '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            dtBreak = oConnTonMecha.Query(sql);
        }
        else if (Line == "rh" || Line == "fh" || Line == "piston" || Line == "cd" || Line == "cs")
        {
            sql.CommandText = "SELECT [Lamp_Status],[UpdateLog],al.[Mc_No],mstr.Mc_Name,[Mode_]" +
                " FROM [Scada_AlarmMC] al" +
                " LEFT JOIN [Scada_AlarmMC_mst] mstr ON al.Mc_No = mstr.Mc_No" +
                " WHERE UpdateLog >= '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' AND UpdateLog <= '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                " ORDER BY mstr.Mc_No, UpdateLog";

            SqlConnection conn = new SqlConnection("Data Source=costy;Initial Catalog=dbIoTFac3;Persist Security Info=True;User ID=sa;Password=decjapan;");
            sql.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "table0");
                dtBreak = ds.Tables["table0"];
                
            }
            catch { }
        }


        //string json = ConvertDataTabletoString(dtBreak);
        
        //File.WriteAllText(HttpContext.Current.Server.MapPath("~/Production/EffSource/MCLameStatus"+ Line + ".json"), json);

        return dtBreak;
    }
    //-------------------- Get Machine BreakDown from Mantenace Board --------------------

    public string ConvertDataTabletoString(DataTable dt)
    {
        JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "AlarmStatus")
                {
                    row.Add(col.ColumnName, dr[col].ToString().Trim());
                }
                else if (col.ColumnName == "StartAlarm" || col.ColumnName == "EndAlarm")
                {
                    DateTime start = Convert.ToDateTime(dr[col].ToString());
                    row.Add(col.ColumnName, start.ToString("yyyy-MM-dd HH:mm:ss").Trim());
                }
                else
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }                
            }
            rows.Add(row);
        }
        serializer.MaxJsonLength = 500000000;
        return serializer.Serialize(rows);
    }

    //-------------------- Get Machine Breakdown from Machine Alram Light -------------------------
    public DataTable GetDTMachineBreakDown(String Shift, DateTime DateTime,string MCName,string Line)
    {
        DataTable dtBreak = new DataTable();
        DateTime StartTime, EndTime = new DateTime();
        if (Shift == "D")
        {
            StartTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 8, 0, 0);
            EndTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 20, 0, 0);
        }
        else
        {
            StartTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 20, 0, 0);
            if (DateTime.Hour <= 8)
            {
                EndTime = new DateTime(DateTime.AddDays(1).Year, DateTime.AddDays(1).Month, DateTime.AddDays(1).Day, 7, 50, 0);
            }
            else
            {
                EndTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, 7, 50, 0);
            }
        }

        string MCNameWhere = "";
        switch (MCName)
        {
            case "Crank Shaft": MCNameWhere = "CS_MEASURING";break;
            case "Cylinder": MCNameWhere = "CY_MEASURING"; break;
            case "Piston": MCNameWhere = "PT_MEASURING"; break;
            case "Front Head": MCNameWhere = "FH_MEASURING"; break;
            case "Rear Head": MCNameWhere = "RH_MEASURING"; break;
            case "Cylinder Centering": MCNameWhere = "CYLINDER_CENTERING"; break;
            case "Rear Centering": MCNameWhere = "REAR_CENTERING"; break;
            case "Tourque Check": MCNameWhere = ""; break;

        }

        SqlCommand sql = new SqlCommand();
        //sql.CommandText = "SELECT BreakdownId,RequestId,MachineId,StartTime,EndTime " +
        //    " FROM [PD_LineBreakDownDetail] WHERE   " +
        //    " AND (StartTime >= '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' AND StartTime <= '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
        //    " AND EndTime > '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'  ";
        //dtBreak = oConPDB.Query(sql);


        //---------------- Get Machine Alarm Light from IoT -------------------
        sql.CommandText = "SELECT [AlarmID],[MCName],[StartAlarm],[EndAlarm],[AlarmStatus] "+
            "FROM [MECHA_FAC3].[dbo].[LogAlarmMCDetail] WHERE MCName = '"+ MCNameWhere + "' "+
            "AND (StartAlarm >= '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' AND [EndAlarm] <= '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
        dtBreak = oConnTonMecha.Query(sql);
        return dtBreak;
    }
    //-------------------- Get Machine Breakdown from Machine Alram Light -------------------------

}