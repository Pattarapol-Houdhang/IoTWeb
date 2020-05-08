using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CGetDataGraph
/// </summary>
public class CGetDataGraphLastDay
{
    public CGetDataGraphLastDay()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    ConnectDBSCM oConn = new ConnectDBSCM();
    ConnectDBIoTServerTon oConnTon = new ConnectDBIoTServerTon();
    ConnectDBIoTServerTonMecha oConnMecha = new ConnectDBIoTServerTonMecha();
    ConnectDBPDB oConnPDB = new ConnectDBPDB();
    CultureInfo USCulture = new CultureInfo("en-US");
    ConnectDB oConnIoTCosty = new ConnectDB();

    public List<MDataGraph> GetPlan(decimal CycleTime, string Fac, string Line, string Mac, string ModelCode, string strDate, string endDate)
    {
        bool shipDay = true;
        DateTime DateNow = DateTime.Now;
        if (Mac == "last")
        {
            DateNow = DateNow.AddDays(-1) + new TimeSpan(8, 20, 0);
            DateTime DateNew = new DateTime(DateNow.Year, DateNow.Month, DateNow.Day - 1) + new TimeSpan(8, 20, 0);
            DateNow = DateTime.Now;
        }

        TimeSpan strTime = new TimeSpan(0, 0, 0);//---- Data Test ---------
        TimeSpan endTime = new TimeSpan(12, 0, 0);
        DateTime stDate = DateTime.Now.Date.AddDays(-1) + strTime;
        DateTime edDate = DateTime.Now.Date.AddDays(-1) + endTime;

        if ((DateNow.TimeOfDay >= new TimeSpan(20, 0, 0) || DateNow.TimeOfDay < new TimeSpan(8, 0, 0)))
        {
            stDate = stDate.Date + new TimeSpan(20, 0, 0);//---- Data Test ---------
            edDate = edDate.AddDays(1) + new TimeSpan(8, 20, 0);
            shipDay = false;
        }
        else
        {
            stDate = stDate.Date + new TimeSpan(8, 20, 0);//---- Data Test ---------
            edDate = edDate.Date + new TimeSpan(20, 0, 0);
        }
       
        TimeSpan difference = edDate - stDate;
        strDate = stDate.ToString("yyyy-MM-dd HH:mm:ss");
        endDate = edDate.ToString("yyyy-MM-dd HH:mm:ss");

        DateTime CurrDate = stDate;
        List<MDataGraph> oListPlan = new List<MDataGraph>();
        MDataGraph oPlan = new MDataGraph();

        //---------- Get Actual -----------
        DataTable dtActual = GetDataActual(Fac, Line, Mac, ModelCode, strDate, endDate);

        //--------- Get Plan from Andon board Line Main Fac 3 Board ID is 301 --------------
        #region
        SqlCommand sql = new SqlCommand();
        if (Line == "mecha")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '302' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate AND DailyPlan != '0' " +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "casing")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '312' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate" +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "motor")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '310' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate" +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "piston")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '308' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate" +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "fh")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '307' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate " +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "cs")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '306' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate" +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "cd")
        {
            //------------ Line Cylinder don,t have andon board ----------------
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '305' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate " +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "rh")
        {
            //------------ Line Rear head don,t have andon board ----------------
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '304' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate" +
              " ORDER BY LogTime DESC";
        }
        else if (Line == "fn")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '303' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate" +
              " ORDER BY LogTime DESC";
        }
        else
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '301' AND LogTime >= @strDate" +
              " AND LogTime <= @endDate AND DailyPlan != '0' " +
              " ORDER BY LogTime DESC";
        }
        #endregion

        sql.Parameters.Add(new SqlParameter("@strDate", strDate));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate));
        DataTable dtPlan = new DataTable();
        dtPlan = oConnPDB.Query(sql);
        double DailyPlan = 0;
        double PlanHour = 0;
        double PlanMin = 0;
        if (dtPlan.Rows.Count > 0)
        {
            DailyPlan = Convert.ToInt32(dtPlan.Rows[0]["DailyPlan"].ToString());
        }
        PlanHour = (DailyPlan / 12);
        PlanMin = (60 / PlanHour);

        double TotalMinWork = 589;
        double ComPerMin = 0;
        ComPerMin = Convert.ToDouble(DailyPlan) / TotalMinWork;
        double PlanPerMin = ComPerMin;

        int CurrPlan = 0;
        int SumPlanBreak = 0;

        DateTime ChDate = stDate;
        for (int i = 1; i <= 701; i++)
        {
            MDataGraph oMDPlan = new MDataGraph();

            //----------- Set Now -------------
            #region

            //oMDPlan.PlanAccu = CurrPlan;
            oMDPlan.PlanAccu = Convert.ToInt32(ComPerMin);
            oMDPlan.Target = Convert.ToInt32(DailyPlan);
            string CurrTimeOfCycle = stDate.TimeOfDay.ToString().Replace(":", "");
            string NextTimeOfCycle = CurrDate.TimeOfDay.ToString().Replace(":", "");

            int Actual = 0;
            DataView dViewActual = dtActual.DefaultView;
            dViewActual.RowFilter = "LogTime >= '" + stDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND LogTime <= '" + CurrDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            DataTable newDtPlan = dViewActual.ToTable();

            if (newDtPlan.Rows.Count > 0)
            {
                Actual = Convert.ToInt32(newDtPlan.Rows[0]["Actual"].ToString());
            }

            oMDPlan.ActualAccu = Convert.ToInt32(Actual);
            if (oMDPlan.PlanAccu == 0)
            {
                oMDPlan.EffiAccu = null;
            }
            else
            {
                decimal eff = (Convert.ToDecimal(oMDPlan.ActualAccu * 100) / Convert.ToDecimal(oMDPlan.PlanAccu));
                decimal? effSet = Math.Round(eff, 3);
                oMDPlan.EffiAccu = effSet > 100 ? 100 : effSet;
            }
            #endregion
            
            oMDPlan.DatePlan = CurrDate.ToString("HH:mm:ss");
            oMDPlan.Totalmilli = ConvertDateTimeToMilliSeconde(Convert.ToDateTime(CurrDate.ToString("yyyy-MM-dd HH:mm:ss")));

            //--------- Check Not Cal Plan Per Min -----------
            if (((CurrDate.TimeOfDay >= new TimeSpan(10, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(10, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(12, 0, 0) && CurrDate.TimeOfDay <= new TimeSpan(13, 0, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(15, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(15, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(17, 45, 0) && CurrDate.TimeOfDay <= new TimeSpan(18, 15, 0))) && shipDay)
            {
                CurrPlan += 0;
                SumPlanBreak++;

                //------ Plan Per Min ---------
                ComPerMin += 0;
            }
            else if (((CurrDate.TimeOfDay >= new TimeSpan(22, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(22, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(0, 0, 0) && CurrDate.TimeOfDay <= new TimeSpan(0, 0, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(3, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(3, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(5, 45, 0) && CurrDate.TimeOfDay <= new TimeSpan(6, 15, 0))) && !shipDay)
            {
                CurrPlan += 0;
                SumPlanBreak++;

                //------ Plan Per Min ---------
                ComPerMin += 0;
            }
            else
            {
                CurrPlan++;
                CurrPlan += SumPlanBreak;
                SumPlanBreak = 0;

                //------ Plan Per Min ---------
                ComPerMin += PlanPerMin;
            }
            //--------- Check Not Cal Plan Per Min -----------

            oListPlan.Add(oMDPlan);
            CurrDate = CurrDate.AddSeconds(60);                       
        }

        return oListPlan;
    }

    public List<MDataGrapPDMeeting> GetDataPDMeeting(string line)
    {
        string LineCode = "";
        if (line == "Main")
        {
            LineCode = "3AMA5";
        }
        List<MDataGrapPDMeeting> oListPDAch = new List<MDataGrapPDMeeting>();

        //------------- Get Data PD Achieve Line Main Fac 3 ----------------
        SqlCommand sqlPDAch = new SqlCommand();
        sqlPDAch.CommandText = "SELECT * FROM [PD_Achievement] WHERE ProductionLine = '" + LineCode + "' AND DataMonth = '" + DateTime.Now.Month + "' AND DataYear = '" + DateTime.Now.Year + "'";
        DataTable dtAch = oConn.Query(sqlPDAch);

        for (int i = 1; i <= 14; i++)
        {
            string DayName = "";
            bool shiftDay = true;
            int day = 0;
            switch (i)
            {
                case 1: day = DateTime.Now.AddDays(-3).Day;
                    DayName = DateTime.Now.AddDays(-3).Day.ToString() + " (D)";
                    break;
                case 2: day = DateTime.Now.AddDays(-3).Day;
                    DayName = DateTime.Now.AddDays(-3).Day.ToString() + " (N)";
                    shiftDay = false;
                    break;
                case 3: day = DateTime.Now.AddDays(-2).Day;
                    DayName = DateTime.Now.AddDays(-2).Day.ToString() + " (D)";
                    break;
                case 4: day = DateTime.Now.AddDays(-2).Day;
                    DayName = DateTime.Now.AddDays(-2).Day.ToString() + " (N)";
                    shiftDay = false;
                    break;
                case 5: day = DateTime.Now.AddDays(-1).Day;
                    DayName = DateTime.Now.AddDays(-1).Day.ToString() + " (D)";
                    break;
                case 6: day = DateTime.Now.AddDays(-1).Day;
                    DayName = DateTime.Now.AddDays(-1).Day.ToString() + " (N)";
                    shiftDay = false;
                    break;

                case 7: day = DateTime.Now.Day;
                    DayName = DateTime.Now.Day.ToString() + " (D)";
                    break;
                case 8: day = DateTime.Now.Day;
                    DayName = DateTime.Now.Day.ToString() + " (N)";
                    shiftDay = false;
                    break;
                case 9: day = DateTime.Now.AddDays(1).Day;
                    DayName = DateTime.Now.AddDays(1).Day.ToString() + " (D)";
                    break;
                case 10: day = DateTime.Now.AddDays(1).Day;
                    DayName = DateTime.Now.AddDays(1).Day.ToString() + " (N)";
                    shiftDay = false;
                    break;
                case 11: day = DateTime.Now.AddDays(2).Day;
                    DayName = DateTime.Now.AddDays(2).Day.ToString() + " (D)";
                    break;
                case 12: day = DateTime.Now.AddDays(2).Day;
                    DayName = DateTime.Now.AddDays(2).Day.ToString() + " (N)";
                    shiftDay = false;
                    break;
                case 13: day = DateTime.Now.AddDays(3).Day;
                    DayName = DateTime.Now.AddDays(3).Day.ToString() + " (D)";
                    break;
                case 14: day = DateTime.Now.AddDays(3).Day;
                    DayName = DateTime.Now.AddDays(3).Day.ToString() + " (N)";
                    shiftDay = false;
                    break;
            }

            MDataGrapPDMeeting oMPdAch = new MDataGrapPDMeeting();
            oMPdAch.Day = DayName;
            oMPdAch.Target = 92;
            //if (day > DateTime.Now.Day)
            //{
            //    //oMPdAch.PlanD = null;
            //    //oMPdAch.PlanN = null;
            //    //oMPdAch.ActualD = null;
            //    //oMPdAch.ActualN = null;
            //}
            //else
            //{
            if (dtAch.Rows.Count > 0)
            {
                oMPdAch.PlanD = dtAch.Rows[0]["Day" + day + "D_Plan"] == DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "D_Plan"].ToString());
                oMPdAch.PlanN = dtAch.Rows[0]["Day" + day + "N_Plan"] == DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "N_Plan"].ToString());

                oMPdAch.PlanD = oMPdAch.PlanD;

                oMPdAch.ActualD = dtAch.Rows[0]["Day" + day + "D_Actual"] == DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "D_Actual"].ToString());
                oMPdAch.ActualN = dtAch.Rows[0]["Day" + day + "N_Actual"] == DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "N_Actual"].ToString());

                oMPdAch.ActualD = oMPdAch.ActualD;

                if (!shiftDay)
                {
                    oMPdAch.PlanD = oMPdAch.PlanN;
                    oMPdAch.ActualD = oMPdAch.ActualN;
                }

                if ((oMPdAch.PlanD + oMPdAch.PlanN) > 0)
                {
                    oMPdAch.Achieve = ((oMPdAch.ActualD + oMPdAch.ActualN) * 100) / (oMPdAch.PlanD + oMPdAch.PlanN);
                    //oMPdAch.Achieve = 100;                        
                }
                else if ((oMPdAch.PlanD + oMPdAch.PlanN) <= 0 && (oMPdAch.ActualD + oMPdAch.ActualN) <= 0)
                {
                    oMPdAch.Achieve = 0;
                }
                else
                {
                    oMPdAch.Achieve = 0;
                }
            }
            //}

            oListPDAch.Add(oMPdAch);
        }

        return oListPDAch;
    }


    public double GetRandomNumber(double minimum, double maximum)
    {
        Random random = new Random();
        return random.NextDouble() * (maximum - minimum) + minimum;
    }

    public double ConvertDateTimeToMilliSeconde(DateTime date)
    {
        DateTime d1 = new DateTime(1970, 1, 1);
        DateTime d2 = date;
        TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
        return ts.TotalMilliseconds;
    }

    //private int GetPlanPD()
    //{
    //    int CurrPlan = 0;
    //    SqlCommand sql = new SqlCommand();
    //    sql.CommandText = "SELECT [BoardId],[PdName],[Actual],[CurPlan],[CurDlPlan],[CurStatus],[ActiveTime]" +
    //        " ,[LogTime],[LastActive],[LastLog],[ReadPlan],[CycleTime],[ServiceRequest],[RequestStart],[ServiceStart]" +
    //        " ,[ServiceEnd],[MachineNo],[RequestType],[Shift],[Enable],[LastCycleTime],[IpAddress],[Tempature]" +
    //        " ,[PdModel],[TotalNG]" +
    //        " FROM [BoardData] where PdName like 'AME1'";
    //    DataTable dTable = oConnPDB.Query(sql);

    //    if (dTable.Rows.Count > 0)
    //    {
    //        CurrPlan = Convert.ToInt32(dTable.Rows[0]["CurPlan"].ToString());
    //    }

    //    return CurrPlan;
    //}

    public DataTable GetDataActual(string Fac, string Line, string Mac, string ModelCode, string strDate, string endDate)
    {
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();

        if (Line == "mecha")
        {
            //sql.CommandText = "SELECT DISTINCT part_serial_no,model_no,stamp_time,replace(cycle_start_time,' ','0') as cycle_start_time,";
            //sql.CommandText += " replace(cycle_end_time,' ','0') as cycle_end_time,part_serial_no";
            //sql.CommandText += " FROM [torque_check]";
            //sql.CommandText += " WHERE stamp_time >= '" + strDate + "' AND stamp_time <= '" + endDate + "' AND part_serial_no != '' ";
            //dTable = oConnMecha.Query(sql);

            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '302' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "casing")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '312' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' AND Status = 'Run' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "motor")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '310' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' AND Status = 'Run' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "piston")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '308' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' AND Status = 'Run' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "fh")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '307' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' AND Status = 'Run' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "cs")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '306' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' AND Status = 'Run' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "cd")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '305' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' AND Status = 'Run' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "fn")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '303' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' AND Status = 'Run' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else
        {
            //sql.CommandText = "SELECT [EC_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
            //sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[IntegratedJudgementResult]";
            //sql.CommandText += " ,[EC_UV],[EC_VW],[EC_WU],[InsertDate]";
            //sql.CommandText += " FROM [ElectricalConduction]";
            //sql.CommandText += " WHERE InsertDate >= '" + strDate + "' AND InsertDate <= '" + endDate + "'";
            //sql.CommandText += " AND IntegratedJudgementResult = 'OK' AND PartSerialNo != '' ";
            //dTable = oConnTon.Query(sql);

            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '301' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        return dTable;
    }

    public DataTable GetActualMechaF3(string Fac, string Line, string Mac, string ModelCode, string strDate, string endDate)
    {
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();

        sql.CommandText = "SELECT [EC_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as [CycleStartTime],";
        sql.CommandText += " replace([CycleEndTime],' ','0') as [CycleEndTime],[IntegratedJudgementResult]";
        sql.CommandText += " ,[EC_UV],[EC_VW],[EC_WU],[InsertDate]";
        sql.CommandText += " FROM [ElectricalConduction]";
        sql.CommandText += " WHERE InsertDate >= '" + strDate + "' AND InsertDate <= '" + endDate + "'";
        sql.CommandText += " AND IntegratedJudgementResult = 'OK' AND PartSerialNo != '' ";
        dTable = oConnTon.Query(sql);

        return dTable;
    }

    private int CalculateTarget(string cycletime)
    {
        int Target = 0;

        return Target;
    }
}