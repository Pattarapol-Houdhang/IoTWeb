using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CGetMachineStatus
/// </summary>
public class CGetMachineStatus
{
    ConnectDBIoTServerTon oConTon = new ConnectDBIoTServerTon();
    ConnectDBIoTServerTonMecha oConnTonMecha = new ConnectDBIoTServerTonMecha();
    ConnectDB oConnIoTCosty = new ConnectDB();
    ConnectDBPDB oConPDB = new ConnectDBPDB();

	public CGetMachineStatus()
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

    public List<MDMachineStatus> GetMachineStatus(DateTime Start, DateTime Stop,string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Rotor Yakibame")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 [RY_ID],[DateShift],[ModelNo],[MachineNo],replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime],[No1_RotorStationNo],[No1_MechaAssyNumber]";
            sql.CommandText += " ,[No1_RotorNumber],[No1_Result],[No2_RotorStationNo],[No2_MechaAssyNumber],[No2_RotorNumber],[No2_Result],[InsertDate]";
            sql.CommandText += " FROM [Rotor_Yakibame] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd ";
            sql.CommandText += " AND InsertDate >= @strDate AND InsertDate <= @endDate AND (No1_RotorNumber != '' OR No2_RotorNumber != '') AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY InsertDate DESC";
            MachineId = "MC-17060056";
        }
        else if (MCName == "Pipe Yakibame")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 [PY_ID],[DateShift],[ModelNo],[MachineNo],replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime],[PYStationNo],[PipeNumber]";
            sql.CommandText += " ,[StatorNumber],[Result],[InsertDate]";
            sql.CommandText += " FROM [Pipe_Yakibame] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " InsertDate >= @strDate AND InsertDate <= @endDate AND PipeNumber != '' AND replace([CycleEndTime],' ','0') != '000000' ";
            sql.CommandText += " ORDER BY InsertDate DESC";
            MachineId = "MC-17060053";
        }
        else if (MCName == "Magnetize")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 [MG_ID],[DateShift],[ModelNo],[MachineNo]";
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
            sql.CommandText = "SELECT TOP 1 [MGC_ID],[DateShift],[ModelNo],[MachineNo],[PipeNumber],replace([CycleStartTime],' ','0') as [CycleStartTime],replace([CycleEndTime],' ','0') as [CycleEndTime],[CentralHeightOfMagnet]";
            sql.CommandText += " ,[IntegratedJudgement],[RotorNumber],[InsertDate]";
            sql.CommandText += " FROM [MagnetCenter] WHERE replace([CycleEndTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND PipeNumber != '' AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-17060059";
        }
        else if (MCName == "Air Gap")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 [AG_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as CycleStartTime,replace([CycleEndTime],' ','0') as CycleEndTime,[AGCheck],[InsertDate]";
            sql.CommandText += " FROM [AirGap] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND PartSerialNo != '' AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "Electrical Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 [EC_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as CycleStartTime,replace([CycleEndTime],' ','0') as CycleEndTime,[IntegratedJudgementResult]";
            sql.CommandText += " ,[EC_UV],[EC_VW],[EC_WU],[InsertDate]";
            sql.CommandText += " FROM [ElectricalConduction] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND PartSerialNo != '' AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "TackWelding")
        {
            sql.CommandText = "";
            sql.CommandText += "SELECT TOP 1 [TW_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
            sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[TimeWeldingStep1_3Point],[TimeWeldingStep2_3Point],[TimeWeldingStep1_6Point]";
            sql.CommandText += " ,[TimeWeldingStep2_6Point],[WeldingTipToolLife],[TimeChargeWireWeldingTorchNo1],[TimeChargeWireWeldingTorchNo2]";
            sql.CommandText += " ,[TimeChargeWireWeldingTorchNo3],[InsertDate]";
            sql.CommandText += " FROM [Tack_Welding] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND ";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else if (MCName == "Top Bottom Welding")
        {
            sql.CommandText = "SELECT TOP 1 [TBW_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
            sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[TimeWelding_Bottom],[WeldingA_Bottom],[WeldingV_Bottom],[TimeWelding_TOP]";
            sql.CommandText += " ,[WeldingA_TOP],[WeldingV_TOP],[WeldingTipToolLift],[TimeChargeWireWelding],[InsertDate]";
            sql.CommandText += " FROM [TopBottomWelding] WHERE replace([CycleStartTime],' ','0') >= @ctStart AND replace([CycleEndTime],' ','0') < @ctEnd AND";
            sql.CommandText += " [InsertDate] >= @strDate AND [InsertDate] <= @endDate AND replace([CycleEndTime],' ','0') != '000000'";
            sql.CommandText += " AND PartSerialNo != ''";
            sql.CommandText += " ORDER BY [InsertDate] DESC";
            MachineId = "MC-999999999";
        }
        else
        {
            sql.CommandText = "";
            MachineId = "MC-999999999";
        }

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConTon.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1707", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["MachineNo"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineMechaStatus(DateTime Start, DateTime Stop, string MCName, bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Crank Shaft")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [crank_shaft_result]";
            sql.CommandText += " WHERE ((replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd) AND replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != ''";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050042";
        }
        else if (MCName == "Cylinder")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [cylinder_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != ''";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050029";
        }
        else if (MCName == "Piston")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [piston_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate ";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050028";
        }
        else if (MCName == "Front Head")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [front_head_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != ''";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050044";
        }
        else if (MCName == "Rear Head")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [rear_head_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != ''";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050043";
        }
        else if (MCName == "Cylinder Centering")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [cylinder_centering]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != ''";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050045";
        }
        else if (MCName == "Rear Centering")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [rear_centering]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != ''";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050046";
        }
        else if (MCName == "Tourque Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [torque_check]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != ''";
            sql.CommandText += " ORDER BY stamp_time DESC";
            MachineId = "MC-17050030";
        }

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(180);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnTonMecha.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1701", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["machine_no"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineCasingStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Pipe Marking")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipeMarking'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17050004";
        }
        else if (MCName == "Pipe Plasma Welding")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipePlasmaWelding'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17050007";
        }
        else if (MCName == "Pipe Punch Machine")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipePunchMachine'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-99999999999";
        }
        else if (MCName == "Pipe ID Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'PipeIDCheck'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-99999999999";
        }

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        //sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        //sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", Start.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", Stop.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1709", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["mc_code"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineMotorStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Stator Transport Unit Input Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_TransportUnit_InputSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Transport Unit Discharge Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_TransportUnit_DischargeSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Common Transport Input Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_CommonTransportInputSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Common Transport Discharg Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_CommonTransportDischargSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Insulator Laser Marking")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_InsulatorLaserMarking'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060036";
        }
        else if (MCName == "Stator Transport Winding Input Side")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_TransportWindingInputSide'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Stator Winding No1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_WindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060037";
        }
        else if (MCName == "Stator Charecteristic Measurement")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'STR_CharecteristicMeasurement'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060040";
        }

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        //sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        //sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", Start.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", Stop.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1708", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["mc_code"].ToString();
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

    public List<MDMachineStatus> GetMachinePistonStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Piston Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'PISTON_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999999";
        }
        else if (MCName == "Piston Surface Grinding")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_SurfaceGrinding'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060022";
        }
        else if (MCName == "Piston Blade Grinding 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_BladeGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060023";
        }
        else if (MCName == "Piston Blade Grinding 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_BladeGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060024";
        }
        else if (MCName == "Piston Brushing")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Piston_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060029";
        }        

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnTonMecha.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1705", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["machine_no"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineFrontheadStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Front Head Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'FRONTHEAD_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Front Head Internal Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_InternalGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060014";
        }
        else if (MCName == "Front Head Internal Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_InternalGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060015";
        }
        else if (MCName == "Front Head Surface Grinding")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_SurfaceGrinding'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060013";
        }
        else if (MCName == "Front Head Brushing")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND data_partnumber != '' AND mc_code = 'Fronthead_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060016";
        }        

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        //sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        //sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", Start.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", Stop.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1713", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["mc_code"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineCrankshaftStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Crankshaft Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'CRANKSHAFT_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Crankshaft Thrust Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_ThrustGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060006";
        }
        else if (MCName == "Crankshaft Thrust Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_ThrustGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-9999999";
        }
        else if (MCName == "Crankshaft Centerless Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_CenterlessGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060003";
        }
        else if (MCName == "Crankshaft Centerless Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_CenterlessGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060004";
        }
        else if (MCName == "Crankshaft Brushing")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Crankshaft_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-9999999";
        }

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        //sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        //sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", Start.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", Stop.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1702", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["mc_code"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineCylinderStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Cylinder Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'CYLINDER_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "999999";
        }
        else if (MCName == "Cylinder Surface Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_SurfaceGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060007";
        }
        else if (MCName == "Cylinder Surface Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_SurfaceGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-999999";
        }
        else if (MCName == "Cylinder BoreID Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BoreIDGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060008";
        }
        else if (MCName == "Cylinder BoreID Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BoreIDGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060009";
        }
        else if (MCName == "Cylinder Bush Hole Grinding No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BushHoleGrindingNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060010";
        }
        else if (MCName == "Cylinder Bush Hole Grinding No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BushHoleGrindingNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060011";
        }
        else if (MCName == "Cylinder Bush Hole Grinding No 3")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_BushHoleGrindingNo3'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-999999";
        }
        else if (MCName == "Cylinder_Brushing")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'Cylinder_Brushing'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060012";
        }

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        //sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        //sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", Start.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", Stop.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1703", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["mc_code"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineRearheadStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Rear Head Laser")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'RH_LASER'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "99999";
        }
        else if (MCName == "Rear Head Surface")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'RH_SURFACE'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060030";
        }
        else if (MCName == "Rear Head Brush")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'RH_BRUSH'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineId = "MC-17060033";
        }

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        //sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        //sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", Start.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", Stop.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1706", MachineId, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["mc_code"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    public List<MDMachineStatus> GetMachineFinalStatus(DateTime Start, DateTime Stop, string MCName)
    {
        string MachineID = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        if (MCName == "Running Test No 1")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'FN_RunningTestNo1'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineID = "MC-17060052";
        }
        else if (MCName == "Running Test No 2")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'FN_RunningTestNo2'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineID = "MC-17060044";
        }
        else if (MCName == "Running Test No 3")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'FN_RunningTestNo3'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineID = "MC-17060049";
        }
        else if (MCName == "Running Test No 4")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'FN_RunningTestNo4'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineID = "MC-17060051";
        }
        else if (MCName == "Oil Filling")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'FN_OilFilling'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineID = "MC-17060048";
        }
        else if (MCName == "Weight Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT TOP 1 data_partnumber,mc_code,data_mfgdate";
            sql.CommandText += " FROM [Data]";
            sql.CommandText += " WHERE data_mfgdate >= @strDate AND data_mfgdate <= @endDate ";
            sql.CommandText += " AND (data_partnumber != '' OR data_partnumber != 'ERROR') AND mc_code = 'FN_FinalWeightCheck'";
            sql.CommandText += " ORDER BY data_mfgdate DESC";
            MachineID = "MC-9999999";
        }

        DateTime dateNow = DateTime.Now;
        bool ShiptDay = true;
        if (Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00"))
        {
            ShiptDay = false;
        }
        Stop = Start.AddSeconds(90);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        string[] spTimeStr = timeStr.Split('.');
        string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }
        //sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        //sql.Parameters.Add(new SqlParameter("@ctEnd", timeEnd));
        sql.Parameters.Add(new SqlParameter("@strDate", Start.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", Stop.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnIoTCosty.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1710", MachineID, strDate, endDate);

        MDMachineStatus oMDMC = new MDMachineStatus();
        if (dTable.Rows.Count > 0)
        {
            oMDMC.McCode = dTable.Rows[0]["mc_code"].ToString();
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES"? "BREAK" : "TRUE";
        }
        else
        {
            oMDMC.McCode = "";
            oMDMC.McName = "";
            oMDMC.Status = StatusBreak == "YES" ? "BREAK" : "FALSE";
        }
        oList.Add(oMDMC);
        return oList;
    }

    private string GetMachineBreakDown(string LineId, string MachineId, DateTime StartTime, DateTime EndTime)
    {
        string StatusBreak = "NO";

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT [BreakdownId],[RequestId],[MachineId],[StartTime],[EndTime]"+
            " FROM [PD_LineBreakDownDetail] WHERE MachineId = '" + MachineId + "' AND StartTime >= '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' AND EndTime <= '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        DataTable dtBreak = oConPDB.Query(sql);
        if (dtBreak.Rows.Count > 0)
        {
            StatusBreak = "YES";
        }

        return StatusBreak;
    }


}