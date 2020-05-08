﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CGetDataGraph
/// </summary>
public class CGetDataGraph
{
    public CGetDataGraph()
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
        if (Fac == "old")
        {
            DateNow = Convert.ToDateTime(Mac) + new TimeSpan(8, 20, 0);
        }
        TimeSpan strTime = new TimeSpan(0, 0, 0);//---- Data Test ---------
        TimeSpan endTime = new TimeSpan(12, 0, 0);
        DateTime stDate = DateTime.Now.Date + strTime;
        DateTime edDate = DateTime.Now.Date + endTime;

        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour <= 19)
        {
            stDate = DateNow.Date + new TimeSpan(8, 5, 0);//---- Data Test ---------
            edDate = DateNow.Date + new TimeSpan(19, 59, 59);
            shipDay = true;
        }
        else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
        {
            stDate = DateNow.Date + new TimeSpan(20, 0, 0);//---- Data Test ---------
            edDate = DateNow.Date.AddDays(1) + new TimeSpan(7, 59, 59);
            shipDay = false;
        }
        else if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
        {
            stDate = DateNow.Date.AddDays(-1) + new TimeSpan(20, 0, 0);//---- Data Test ---------
            edDate = DateNow.Date + new TimeSpan(7, 59, 59);
            shipDay = false;
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
        #region Set Board id
        SqlCommand sql = new SqlCommand();
        string Board = "";
        if (Line == "mecha")
        {
            Board = "302";
        }
        else if (Line == "casing")
        {
            Board = "312";
        }
        else if (Line == "motor")
        {
            Board = "310";
        }
        else if (Line == "piston")
        {
            Board = "308";
        }
        else if (Line == "fh")
        {
            Board = "307";
        }
        else if (Line == "cs" || Line == "ct")
        {
            Board = "306";
        }
        else if (Line == "cd")
        {
            Board = "305";
        }
        else if (Line == "rh")
        {
            Board = "304";
        }
        else if (Line == "fn")
        {
            Board = "303";
        }
        else
        {            
            Board = "301";
        }
        #endregion
        sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
            " FROM [DataLog] WHERE BoardId = @Board AND LogTime >= @strDate" +
            " AND LogTime <= @endDate" +
            " ORDER BY LogTime ASC";
        sql.Parameters.Add(new SqlParameter("@Board", Board));
        sql.Parameters.Add(new SqlParameter("@strDate", strDate));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate));
        DataTable dtPlan = new DataTable();
        dtPlan = oConnPDB.Query(sql);
        int DailyPlan = 500;
        double PlanHour = 0;
        double PlanMin = 0;
        if (dtPlan.Rows.Count > 0)
        {
            DailyPlan = Convert.ToInt32(dtPlan.Rows[dtPlan.Rows.Count - 1]["DailyPlan"].ToString());
        }
        PlanHour = (DailyPlan / 12);
        PlanMin = 60 / PlanHour;

        double TotalMinWork = 589;
        double ComPerMin = 0;
        ComPerMin = Convert.ToDouble(DailyPlan) / TotalMinWork;
        double PlanPerMin = ComPerMin;
        int CurrPlan = 0;
        int SumPlanBreak = 0;

        DateTime ChDate = stDate;
        for (int i = 1; i <= 700; i++)//---------- Loop for 1 Min - 701 Min Is 8:20 - 20:00 ------------
        {
            MDataGraph oMDPlan = new MDataGraph();
            int plan = 0;

            oMDPlan.Target = DailyPlan;
            if (CurrDate > DateNow)
            {
                oMDPlan.PlanAccu = null;// Convert.ToInt32(ComPerMin);
                oMDPlan.ActualAccu = null;
                oMDPlan.EffiAccu = null;
                oMDPlan.DatePlan = CurrDate.ToString("HH:mm:ss");
                oMDPlan.Totalmilli = ConvertDateTimeToMilliSeconde(Convert.ToDateTime(CurrDate.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {                                               
                //-------- Get Data Plan Form Andon Board Table DataLog -----------     
                if (dtPlan.Rows.Count > 0)
                {
                    DataRow[] _rowPlan = dtPlan.Select("LogTime >= '" + stDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND LogTime <= '" + CurrDate.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    if (_rowPlan.Length > 0)
                    {
                        try
                        {
                            plan = Convert.ToInt32(_rowPlan[_rowPlan.Length - 1]["Plan_"].ToString());
                        }
                        catch
                        {
                            plan = 0;
                        }
                    }
                }
                //-------- Get Data Plan Form Andon Board Table DataLog -----------     

                oMDPlan.PlanAccu = plan;// Convert.ToInt32(Math.Floor(ComPerMin));               
                string CurrTimeOfCycle = stDate.TimeOfDay.ToString().Replace(":", "");
                string NextTimeOfCycle = CurrDate.TimeOfDay.ToString().Replace(":", "");

                //----------- Get Actual By Count Rows ------------
                int Actual = 0;
                DataView dViewActual = dtActual.DefaultView;
                dViewActual.RowFilter = "LogTime >= '" + stDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND LogTime <= '" + CurrDate.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                dViewActual.Sort = "LogTime DESC";
                DataTable dtViewActual = dViewActual.ToTable();

                if (dtViewActual.Rows.Count > 0)
                {
                    Actual = Convert.ToInt32(dtViewActual.Rows[0]["Actual"].ToString());
                }
                oMDPlan.ActualAccu = Actual;

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
                oMDPlan.DatePlan = CurrDate.ToString("HH:mm:ss");
                oMDPlan.Totalmilli = ConvertDateTimeToMilliSeconde(Convert.ToDateTime(CurrDate.ToString("yyyy-MM-dd HH:mm:ss")));                
            }

            //--------- Check Not Cal Plan Per Min -----------
            if (((CurrDate.TimeOfDay >= new TimeSpan(10, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(10, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(12, 0, 0) && CurrDate.TimeOfDay <= new TimeSpan(13, 0, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(15, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(15, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(17, 45, 0) && CurrDate.TimeOfDay <= new TimeSpan(18, 15, 0))) && shipDay)
            {
                //------ Plan Per Min ---------
                ComPerMin += 0;
            }
            else if (((CurrDate.TimeOfDay >= new TimeSpan(22, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(22, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(0, 0, 0) && CurrDate.TimeOfDay <= new TimeSpan(0, 0, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(3, 00, 0) && CurrDate.TimeOfDay <= new TimeSpan(3, 10, 0))
                || (CurrDate.TimeOfDay >= new TimeSpan(5, 45, 0) && CurrDate.TimeOfDay <= new TimeSpan(6, 15, 0))) && !shipDay)
            {
                //------ Plan Per Min ---------
                ComPerMin += 0;
            }
            else
            {
                //------ Plan Per Min ---------
                ComPerMin += PlanPerMin;
            }

            oListPlan.Add(oMDPlan);
            CurrDate = CurrDate.AddMinutes(1);
        }

        return oListPlan;
    }

    public List<MDataGrapPDMeeting> GetDataPDMeeting(string line,int Month, int Year)
    {
        int Target = 0;
        SqlCommand sqlDataLog = new SqlCommand();

        DateTime startDate = new DateTime(Year, Month, 1);
        DateTime endDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));

        string LineCode = "";
        if (line.ToUpper() == "MAIN")
        {
            LineCode = "3AMA5";
            sqlDataLog.CommandText = "SELECT MAX(DailyPlan) AS TargetPlan FROM [DataLog] WHERE BoardId = '301' AND" +
                " LogTime >= '" + startDate.ToString("yyyy-MM-dd") + "'" +
                " AND LogTime <= '" + endDate.ToString("yyyy-MM-dd") + "'";
        }
        else if (line.ToUpper() == "MECHA")
        {
            LineCode = "3AME5";
            sqlDataLog.CommandText = "SELECT MAX(DailyPlan) AS TargetPlan FROM [DataLog] WHERE BoardId = '302' AND" +
                " LogTime >= '" + startDate.ToString("yyyy-MM-dd") + "'" +
                " AND LogTime <= '" + endDate.ToString("yyyy-MM-dd") + "'";
        }
        else if (line.ToUpper() == "3101") {
            LineCode = "3101";
            sqlDataLog.CommandText = "SELECT MAX(DailyPlan) AS TargetPlan FROM [DataLog] WHERE BoardId = '304' AND" +
                " LogTime >= '" + startDate.ToString("yyyy-MM-dd") + "'" +
                " AND LogTime <= '" + endDate.ToString("yyyy-MM-dd") + "'";
        }
        else if (line.ToUpper() == "3102")
        {
            LineCode = "3102";
            sqlDataLog.CommandText = "SELECT MAX(DailyPlan) AS TargetPlan FROM [DataLog] WHERE BoardId = '305' AND" +
                " LogTime >= '" + startDate.ToString("yyyy-MM-dd") + "'" +
                " AND LogTime <= '" + endDate.ToString("yyyy-MM-dd") + "'";
        }
        else if (line.ToUpper() == "3103")
        {
            LineCode = "3103";
            sqlDataLog.CommandText = "SELECT MAX(DailyPlan) AS TargetPlan FROM [DataLog] WHERE BoardId = '306' AND" +
                " LogTime >= '" + startDate.ToString("yyyy-MM-dd") + "'" +
                " AND LogTime <= '" + endDate.ToString("yyyy-MM-dd") + "'";
        }
        else if (line.ToUpper() == "3104")
        {
            LineCode = "3104";
            sqlDataLog.CommandText = "SELECT MAX(DailyPlan) AS TargetPlan FROM [DataLog] WHERE BoardId = '307' AND" +
                " LogTime >= '" + startDate.ToString("yyyy-MM-dd") + "'" +
                " AND LogTime <= '" + endDate.ToString("yyyy-MM-dd") + "'";
        }
        else if (line.ToUpper() == "3105")
        {
            LineCode = "3105";
            sqlDataLog.CommandText = "SELECT MAX(DailyPlan) AS TargetPlan FROM [DataLog] WHERE BoardId = '308' AND" +
                " LogTime >= '" + startDate.ToString("yyyy-MM-dd") + "'" +
                " AND LogTime <= '" + endDate.ToString("yyyy-MM-dd") + "'";
        }
        DataTable dtTarget = oConnPDB.Query(sqlDataLog);
        if (dtTarget.Rows.Count > 0)
        {
            Target = 1300;// Convert.ToInt32(dtTarget.Rows[0]["TargetPlan"].ToString());
        }

        List<MDataGrapPDMeeting> oListPDAch = new List<MDataGrapPDMeeting>();

        //------------- Get Data PD Achieve Line Main Fac 3 ----------------
        SqlCommand sqlPDAch = new SqlCommand();
        SqlCommand sqlPDAchLastMonth = new SqlCommand();
        SqlCommand sqlPDAchNextMonth = new SqlCommand();

        sqlPDAch.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth='{1}' AND DataYear={2} ", LineCode, startDate.Month, startDate.Year);
        sqlPDAchLastMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth='{1}' AND DataYear={2} ", LineCode, startDate.AddMonths(-1).Month, startDate.AddMonths(-1).Year);
        sqlPDAchNextMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth='{1}' AND DataYear={2} ", LineCode, startDate.AddMonths(1).Month, startDate.AddMonths(1).Year);

        DataTable dtAch = oConn.Query(sqlPDAch);
        //DataTable dtAchLastMonth = oConn.Query(sqlPDAchLastMonth);
        //DataTable dtAchNextMonth = oConn.Query(sqlPDAchNextMonth);

        for (int i = 0; i < DateTime.DaysInMonth(Year, Month); i++)
        {
            DateTime dateShow = startDate.AddDays(i);
            string DayName = "", NightName = "";
            bool shiftDay = true;
            int day = 0,night = 0;
            int CheckMonth = 0;
            int CheckYear = 0;

            day = dateShow.Day;
            DayName = dateShow.Day.ToString() + " (D)";
            night = dateShow.Day;
            NightName = dateShow.Day.ToString() + " (N)";
            CheckMonth = dateShow.Month;
            CheckYear = dateShow.Year;


            //------------- Shift Day ---------------   
            MDataGrapPDMeeting oMPdAchDay = new MDataGrapPDMeeting();
            oMPdAchDay.Day = DayName;
            oMPdAchDay.Target = Target;
            if (dtAch.Rows.Count > 0)
            {                             
                oMPdAchDay.PlanD = dtAch.Rows[0]["Day" + day + "D_Plan"] ==
                            DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "D_Plan"].ToString());
                oMPdAchDay.ActualD = dtAch.Rows[0]["Day" + day + "D_Actual"] ==
                    DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "D_Actual"].ToString());                                          
            }
            oListPDAch.Add(oMPdAchDay);

            //------------- Shift Night ---------------
            MDataGrapPDMeeting oMPdAchNight = new MDataGrapPDMeeting();
            oMPdAchNight.Day = NightName;
            oMPdAchNight.Target = Target;
            if (dtAch.Rows.Count > 0)
            {               
                oMPdAchNight.PlanD = dtAch.Rows[0]["Day" + day + "N_Plan"] ==
                    DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "N_Plan"].ToString());
                oMPdAchNight.ActualD = dtAch.Rows[0]["Day" + day + "N_Actual"] ==
                    DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "N_Actual"].ToString());
            }
            oListPDAch.Add(oMPdAchNight);

            #region Old
            //if (dtAch.Rows.Count > 0)
            //{
            //    if (CheckYear == DateTime.Now.Year)
            //    {
            //        if (CheckMonth < DateTime.Now.Month)
            //        {
            //            oMPdAch.PlanD = dtAchLastMonth.Rows[0]["Day" + day + "D_Plan"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "D_Plan"].ToString());
            //            oMPdAch.PlanN = dtAchLastMonth.Rows[0]["Day" + day + "N_Plan"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "N_Plan"].ToString());

            //            oMPdAch.ActualD = dtAchLastMonth.Rows[0]["Day" + day + "D_Actual"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "D_Actual"].ToString());
            //            oMPdAch.ActualN = dtAchLastMonth.Rows[0]["Day" + day + "N_Actual"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "N_Actual"].ToString());
            //        }
            //        else if (CheckMonth > DateTime.Now.Month)
            //        {
            //            oMPdAch.PlanD = dtAchNextMonth.Rows[0]["Day" + day + "D_Plan"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "D_Plan"].ToString());
            //            oMPdAch.PlanN = dtAchNextMonth.Rows[0]["Day" + day + "N_Plan"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "N_Plan"].ToString());

            //            oMPdAch.ActualD = dtAchNextMonth.Rows[0]["Day" + day + "D_Actual"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "D_Actual"].ToString());
            //            oMPdAch.ActualN = dtAchNextMonth.Rows[0]["Day" + day + "N_Actual"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "N_Actual"].ToString());
            //        }
            //        else
            //        {
            //            oMPdAch.PlanD = dtAch.Rows[0]["Day" + day + "D_Plan"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "D_Plan"].ToString());
            //            oMPdAch.PlanN = dtAch.Rows[0]["Day" + day + "N_Plan"] ==
            //                DBNull.Value ? 0 :  Convert.ToInt32(dtAch.Rows[0]["Day" + day + "N_Plan"].ToString());

            //            oMPdAch.ActualD = dtAch.Rows[0]["Day" + day + "D_Actual"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "D_Actual"].ToString());
            //            oMPdAch.ActualN = dtAch.Rows[0]["Day" + day + "N_Actual"] ==
            //                DBNull.Value ? 0 : Convert.ToInt32(dtAch.Rows[0]["Day" + day + "N_Actual"].ToString());
            //        }
            //    }
            //    else if (CheckYear > DateTime.Now.Year)
            //    {
            //        oMPdAch.PlanD = dtAchNextMonth.Rows[0]["Day" + day + "D_Plan"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "D_Plan"].ToString());
            //        oMPdAch.PlanN = dtAchNextMonth.Rows[0]["Day" + day + "N_Plan"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "N_Plan"].ToString());

            //        oMPdAch.ActualD = dtAchNextMonth.Rows[0]["Day" + day + "D_Actual"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "D_Actual"].ToString());
            //        oMPdAch.ActualN = dtAchNextMonth.Rows[0]["Day" + day + "N_Actual"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + day + "N_Actual"].ToString());
            //    }
            //    else
            //    {
            //        oMPdAch.PlanD = dtAchLastMonth.Rows[0]["Day" + day + "D_Plan"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "D_Plan"].ToString());
            //        oMPdAch.PlanN = dtAchLastMonth.Rows[0]["Day" + day + "N_Plan"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "N_Plan"].ToString());

            //        oMPdAch.ActualD = dtAchLastMonth.Rows[0]["Day" + day + "D_Actual"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "D_Actual"].ToString());
            //        oMPdAch.ActualN = dtAchLastMonth.Rows[0]["Day" + day + "N_Actual"] ==
            //            DBNull.Value ? 0 : Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + day + "N_Actual"].ToString());
            //    }


            //    oMPdAch.PlanD = oMPdAch.PlanD;
            //    oMPdAch.ActualD = oMPdAch.ActualD;

            //    if (!shiftDay)
            //    {
            //        oMPdAch.PlanD = oMPdAch.PlanN;
            //        oMPdAch.ActualD = oMPdAch.ActualN;
            //    }

            //    if ((oMPdAch.PlanD + oMPdAch.PlanN) > 0)
            //    {
            //        oMPdAch.Achieve = ((oMPdAch.ActualD + oMPdAch.ActualN) * 100) / (oMPdAch.PlanD + oMPdAch.PlanN);
            //    }
            //    else if ((oMPdAch.PlanD + oMPdAch.PlanN) <= 0 && (oMPdAch.ActualD + oMPdAch.ActualN) <= 0)
            //    {
            //        oMPdAch.Achieve = 0;
            //    }
            //    else
            //    {
            //        oMPdAch.Achieve = 0;
            //    }
            //}
            #endregion

            //oListPDAch.Add(oMPdAch);
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
        string FirstNum = "";
        string ModelCodeLike1 = "";
        string ModelCodeLike2 = "";
        double unit = 0;
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
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "motor")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '310' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "piston")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '308' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "fh")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '307' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "cs")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '306' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "cd")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '305' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "fn")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '303' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else if (Line == "rh")
        {
            sql.CommandText = "SELECT [LogTime],[BoardId],[DailyPlan],[Plan_],[Actual],[Diff],[Shift],[Status],[BreakDown]" +
              " FROM [DataLog] WHERE BoardId = '304' AND LogTime >= '" + strDate + "'" +
              " AND LogTime <= '" + endDate + "' ORDER BY LogTime DESC";
            dTable = oConnPDB.Query(sql);
        }
        else
        {
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