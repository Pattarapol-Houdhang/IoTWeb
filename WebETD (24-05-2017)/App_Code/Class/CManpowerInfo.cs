using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CManpowerInfo
/// </summary>
public class CManpowerInfo
{
    ConnectDBCosty oConn = new ConnectDBCosty();
    public CManpowerInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetEmployeeWorkTimeOfMonth(string EmpCode,string WType, int Month)
    {

        DataTable dtWorkTime = new DataTable();
        dtWorkTime.Columns.Add("Code", typeof(string));
        dtWorkTime.Columns.Add("WorkDate", typeof(string));
        dtWorkTime.Columns.Add("OT1", typeof(int));
        dtWorkTime.Columns.Add("OT15", typeof(int));
        dtWorkTime.Columns.Add("OT2", typeof(int));
        dtWorkTime.Columns.Add("OT3", typeof(int));

        string endDatePresentMonth = DateTime.Now.ToString("yyyy-MM-dd");
        string MonthPresent = Convert.ToString(DateTime.Now.Month.ToString());
        DateTime startDate = new DateTime(DateTime.Now.Year, Month, 1);
        DateTime endDate = startDate.AddMonths(1);

        string txtEndDate;
     
        if (Convert.ToString(Month) == MonthPresent)
        {
            txtEndDate = endDatePresentMonth;
        }
        else
        {
            txtEndDate = Convert.ToString(endDate.ToString());
        }
      //endDate.ToString("yyyy-MM-dd") 

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT * FROM [EmployeeWorkingTime] where Code = '" + EmpCode + "' and DatetimeIN >= '" + startDate.ToString("yyyy-MM-dd") + "' " +
            " AND DatetimeIN <= '" + txtEndDate + "'";


        //sql.CommandText = "SELECT [WCode],[WDate],[WTime],[WDoor],es.[WType],LTRIM(DATEDIFF(MINUTE, 0, otr.OT1)) as OT1,LTRIM(DATEDIFF(MINUTE, 0, otr.OT15)) as OT15 " +
        //        ",LTRIM(DATEDIFF(MINUTE, 0, otr.OT2)) as OT2,LTRIM(DATEDIFF(MINUTE, 0, otr.OT3)) as OT3 " +
        //        "  FROM [dbDCI].[dbo].[EmployeeTimeStamp] es " +
        //        " LEFT JOIN [dbDCI].[dbo].[Employee] e ON es.WCode = e.CODE " +
        //        " LEFT JOIN [dbDCI].[dbo].[EMP_OTRQ] otr ON es.WCode = otr.CODE AND es.WDate = otr.ODATE " +
        //        " WHERE WDate >= '" + startDate.ToString("yyyy-MM-dd") + "' AND WDate <= '" + txtEndDate + "' AND es.WType = 'O' AND WCODE = '" + EmpCode + "'" +
        //        " order by WDate  desc";


        DataTable dt = oConn.SqlGet(sql, "DBDCI");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow item in dt.Rows)
            {
                DataRow _row = dtWorkTime.NewRow();
                _row["Code"] = item["Code"].ToString();
                _row["WorkDate"] = Convert.ToDateTime(item["DatetimeIN"].ToString()).ToString("yyyy-MM-dd");


                //-------------- Calculate OT --------------------
                DateTime NormalStart = new DateTime(Convert.ToDateTime(item["SystemIN"].ToString()).Year, Convert.ToDateTime(item["SystemIN"].ToString()).Month, Convert.ToDateTime(item["SystemIN"].ToString()).Day, 18, 15, 0);
                DateTime NormalEnd = new DateTime(Convert.ToDateTime(item["SystemIN"].ToString()).Year, Convert.ToDateTime(item["SystemIN"].ToString()).Month, Convert.ToDateTime(item["SystemIN"].ToString()).Day, 20, 00, 0);
                if (item["WorkType"].ToString() == "D" && NormalStart < DateTime.Now)
                {                                    
                    if (item["WorkShift"].ToString() == "D")
                    {
                        NormalEnd = new DateTime(Convert.ToDateTime(item["SystemIN"].ToString()).Year, Convert.ToDateTime(item["SystemIN"].ToString()).Month, Convert.ToDateTime(item["SystemIN"].ToString()).Day, 20, 00, 0);

                        TimeSpan WorkNormalOT = NormalEnd.Subtract(NormalStart);
                        _row["OT1"] = 0;
                        _row["OT15"] = WorkNormalOT.TotalMinutes;
                        _row["OT2"] = 0;
                        _row["OT3"] = 0;
                    }
                    else
                    {
                        _row["OT1"] = 0;
                        _row["OT15"] = 0;
                        _row["OT2"] = 0;
                        _row["OT3"] = 0;
                    }                                        
                }
                else if (item["WorkType"].ToString() == "H" && NormalStart < DateTime.Now)
                {
                    DateTime WorkStart = new DateTime(Convert.ToDateTime(item["SystemIN"].ToString()).Year, Convert.ToDateTime(item["SystemIN"].ToString()).Month
                        , Convert.ToDateTime(item["SystemIN"].ToString()).Day, 8, 0, 0);
                    DateTime WorkEnd = new DateTime(WorkStart.Year, WorkStart.Month, WorkStart.Day, 17, 45, 0);
                    if (item["WorkShift"].ToString() == "D")
                    {
                        NormalEnd = new DateTime(Convert.ToDateTime(item["SystemIN"].ToString()).Year, Convert.ToDateTime(item["SystemIN"].ToString()).Month
                            , Convert.ToDateTime(item["SystemIN"].ToString()).Day, 20, 00, 0);

                        TimeSpan WorkNormal = WorkEnd.Subtract(WorkStart);
                        TimeSpan WorkOT = NormalEnd.Subtract(NormalStart);
                        if (WType == "S")
                        {
                            _row["OT1"] = WorkNormal.TotalMinutes - 60;
                            _row["OT2"] = 0;
                        }
                        else
                        {
                            _row["OT1"] = 0;
                            _row["OT2"] = WorkNormal.TotalMinutes - 60; 
                        }
                        
                        _row["OT15"] = 0;
                        
                        _row["OT3"] = WorkOT.TotalMinutes;
                    }
                    else
                    {
                        _row["OT1"] = 0;
                        _row["OT15"] = 0;
                        _row["OT2"] = 0;
                        _row["OT3"] = 0;
                    }
                }
                else
                {
                    _row["OT1"] = 0;
                    _row["OT15"] = 0;
                    _row["OT2"] = 0;
                    _row["OT3"] = 0;
                }
                
                dtWorkTime.Rows.Add(_row);
            }
        }

        return dtWorkTime;
    }

    public DataTable GetEmployeeWorkTimeOfMonthNew(string EmpCode, string WType, int Month)
    {

        DataTable dtWorkTime = new DataTable();
        dtWorkTime.Columns.Add("Code", typeof(string));
        dtWorkTime.Columns.Add("WorkDate", typeof(string));
        dtWorkTime.Columns.Add("OT1", typeof(int));
        dtWorkTime.Columns.Add("OT15", typeof(int));
        dtWorkTime.Columns.Add("OT2", typeof(int));
        dtWorkTime.Columns.Add("OT3", typeof(int));
        dtWorkTime.Columns.Add("SUMOT", typeof(int));
        dtWorkTime.Columns.Add("DOT1", typeof(int));
        dtWorkTime.Columns.Add("DOT15", typeof(int));
        dtWorkTime.Columns.Add("DOT2", typeof(int));
        dtWorkTime.Columns.Add("DOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMDOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPD", typeof(int));
        dtWorkTime.Columns.Add("NOT1", typeof(int));
        dtWorkTime.Columns.Add("NOT15", typeof(int));
        dtWorkTime.Columns.Add("NOT2", typeof(int));
        dtWorkTime.Columns.Add("NOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMNOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPN", typeof(int));
        dtWorkTime.Columns.Add("HOT1", typeof(int));
        dtWorkTime.Columns.Add("HOT15", typeof(int));
        dtWorkTime.Columns.Add("HOT2", typeof(int));
        dtWorkTime.Columns.Add("HOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMHOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPH", typeof(int));

        string endDatePresentMonth = DateTime.Now.ToString("yyyy-MM-dd");
        string MonthPresent = Convert.ToString(DateTime.Now.Month.ToString());
        DateTime startDate = new DateTime(DateTime.Now.Year, Month, 1);
        DateTime endDate = startDate.AddMonths(1);

        string txtEndDate;

        int SumOT1 = 0, OT1 = 0, OT15 = 0, OT2 = 0, OT3 = 0;
        int SUMMPD = 0, DOT1 = 0, DOT15 = 0, DOT2 = 0, DOT3 = 0, SDOT1 = 0, SDOT15 = 0, SDOT2 = 0, SDOT3 = 0;
        int SUMMPN = 0, HOT1 = 0, HOT15 = 0, HOT2 = 0, HOT3 = 0, SHOT1 = 0, SHOT15 = 0, SHOT2 = 0, SHOT3 = 0;
        int SUMMPH=0, NOT1 = 0, NOT15 = 0, NOT2 = 0, NOT3 = 0, SNOT1 = 0, SNOT15 = 0, SNOT2 = 0, SNOT3 = 0;

        if (Convert.ToString(Month) == MonthPresent)
        {
            txtEndDate = endDatePresentMonth;
        }
        else
        {
            txtEndDate = Convert.ToString(endDate.ToString());
        }
        //endDate.ToString("yyyy-MM-dd") 

        SqlCommand sql = new SqlCommand();
        //sql.CommandText = "SELECT * FROM [EmployeeWorkingTime] where Code = '"+ EmpCode + "' and DatetimeIN >= '"+ startDate.ToString("yyyy-MM-dd") + "' "+
        //    " AND DatetimeIN <= '" + txtEndDate + "'";


        sql.CommandText = "SELECT WorkShift,WorkType, [WCode],[WDate],[WTime],[WDoor],es.[WType],LTRIM(DATEDIFF(MINUTE, 0, otr.OT1)) as OT1,LTRIM(DATEDIFF(MINUTE, 0, otr.OT15)) as OT15 " +
                ",LTRIM(DATEDIFF(MINUTE, 0, otr.OT2)) as OT2,LTRIM(DATEDIFF(MINUTE, 0, otr.OT3)) as OT3 " +
                " FROM [dbDCI].[dbo].[EmployeeTimeStamp] es " +
                " LEFT JOIN [dbDCI].[dbo].[Employee] e ON es.WCode = e.CODE " +
                " LEFT JOIN [dbDCI].[dbo].[EmployeeWorkingTime] wt ON es.WCode = wt.Code " +
                " LEFT JOIN [dbDCI].[dbo].[EMP_OTRQ] otr ON es.WCode = otr.CODE AND es.WDate = otr.ODATE " +
                " WHERE WDate >= '" + startDate.ToString("yyyy-MM-dd") + "' AND WDate <= '" + txtEndDate + "' AND es.WType = 'O' AND WCODE = '" + EmpCode + "'" +
                "	AND CONVERT(DATE, wt.SystemOUT) = WDate " +
                " order by WDate  desc";


        DataTable dt = oConn.SqlGet(sql, "DBDCI");
        if (dt.Rows.Count > 0)
        {
         
            DataRow _row = dtWorkTime.NewRow();
            foreach (DataRow item in dt.Rows)
            {
          
                _row["Code"] = item["WCode"].ToString();
                _row["WorkDate"] = Convert.ToDateTime(item["WDate"].ToString()).ToString("yyyy-MM-dd");


                if (item["WorkType"].ToString() == "D")
                {

                    if (item["OT1"].ToString() != "" )
                    {
                        if ( Convert.ToInt16(item["OT1"].ToString()) != 0)
                        {
                        DOT1 += Convert.ToInt16(item["OT1"]);
                        SDOT1 += 1;
                          }
                    }
                    if (item["OT15"].ToString() != "" )
                    {
                        if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                        {
                            DOT15 += Convert.ToInt16(item["OT15"]);
                            SDOT15 += 1;
                        }
                    }
                    if (item["OT2"].ToString() != "" )
                    {
                        if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                        {
                            DOT2 += Convert.ToInt16(item["OT2"]);
                            SDOT2 += 1;
                        }
                    }
                    if (item["OT3"].ToString() != "" )
                    {
                        if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                        {
                            DOT3 += Convert.ToInt16(item["OT3"]);
                            SDOT3 += 1;
                        }
                    }

                    if (SDOT1 != 0 || SDOT15 != 0 || SDOT2 != 0 || SDOT3 != 0)
                    {
                        SUMMPD += 1;
                        SDOT1 = 0;
                        SDOT15 = 0;
                        SDOT2 = 0;
                        SDOT3 = 0;
                    }

                }
                else if (item["WorkType"].ToString() == "N")
                {
                    if (item["OT1"].ToString() != "" )
                    {
                        if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                        {
                            NOT1 += Convert.ToInt16(item["OT1"]);
                            SNOT1 += 1;
                        }
                    }
                    if (item["OT15"].ToString() != "" )
                    {
                        if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                        {
                            NOT15 += Convert.ToInt16(item["OT15"]);
                            SNOT15 += 1;
                        }
                    }
                    if (item["OT2"].ToString() != "" )
                    {
                        if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                        {
                            NOT2 += Convert.ToInt16(item["OT2"]);
                            SNOT2 += 1;
                        }
                    }
                    if (item["OT3"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                        {
                            NOT3 += Convert.ToInt16(item["OT3"]);
                            SNOT3 += 1;
                        }
                    }
                    if (SNOT1 != 0 || SNOT15 != 0 || SNOT2 != 0 || SNOT3 != 0)
                    {
                        SUMMPN += 1;
                        SNOT1 = 0;
                        SNOT15 = 0;
                        SNOT2 = 0;
                        SNOT3 = 0;
                    }
                }
                else if (item["WorkType"].ToString() == "H")
                {
                    if (item["OT1"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                        {
                            HOT1 += Convert.ToInt16(item["OT1"]);
                            SHOT1 += 1;
                        }
                    }
                    if (item["OT15"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                        {
                            HOT15 += Convert.ToInt16(item["OT15"]);
                            SHOT15 += 1;
                        }
                    }
                    if (item["OT2"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                        {
                            HOT2 += Convert.ToInt16(item["OT2"]);
                            SHOT2 += 1;
                        }
                    }
                    if (item["OT3"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                        {
                            HOT3 += Convert.ToInt16(item["OT3"]);
                            SHOT3 += 1;
                        }
                    }
                    if (SHOT1 != 0 || SHOT15 != 0 || SHOT2 != 0 || SHOT3 != 0)
                    {
                        SUMMPH += 1;
                        SHOT1 = 0;
                        SHOT15 = 0;
                        SHOT2 = 0;
                        SHOT3 = 0;
                    }
                }

            
                   
        //** OT DAY SHIFT
                    _row["DOT1"] = DOT1;
                    _row["DOT15"] = DOT15;
                    _row["DOT2"] = DOT2;
                    _row["DOT3"] = DOT3;
                    _row["SUMDOT"] = DOT1 + DOT15 + DOT2 + DOT3;
                    _row["SUMMPD"] = SUMMPD;


       //** OT NIGHT SHIFT
                    _row["NOT1"] = NOT1;
                    _row["NOT15"] = NOT15;
                    _row["NOT2"] = NOT2;
                    _row["NOT3"] = NOT3;
                    _row["SUMNOT"] = NOT1 + NOT15 + NOT2 + NOT3;
                    _row["SUMMPN"] = SUMMPN;

      //** OT HOLIDAY SHIFT
                    _row["HOT1"] = HOT1;
                    _row["HOT15"] = HOT15;
                    _row["HOT2"] = HOT2;
                    _row["HOT3"] = HOT3;
                    _row["SUMHOT"] = HOT1 + HOT15 + HOT2 + HOT3;
                    _row["SUMMPH"] = SUMMPH;

    //** SUMMARY OVER-TIME
                    _row["OT1"] = DOT1 + NOT1 + HOT1;
                    _row["OT15"] = DOT15 + NOT15 + HOT15;
                    _row["OT2"] = DOT2 + NOT2 + HOT2;
                    _row["OT3"] = DOT3 + NOT3 + HOT3;
                    _row["SUMOT"] = DOT1 + DOT15 + DOT2 + DOT3 + NOT1 + NOT15 + NOT2 + NOT3 + HOT1 + HOT15 + HOT2 + HOT3;      
                
              

                
            }
            dtWorkTime.Rows.Add(_row);
        }

        return dtWorkTime;
    }

    public DataTable GetEmployeeWorkTimeOfMonthDayNight(string EmpCode, string WType, int Month)
    {

        DataTable dtWorkTime = new DataTable();
        dtWorkTime.Columns.Add("Code", typeof(string));
        dtWorkTime.Columns.Add("WorkDate", typeof(string));

        dtWorkTime.Columns.Add("OT1", typeof(int));
        dtWorkTime.Columns.Add("OT15", typeof(int));
        dtWorkTime.Columns.Add("OT2", typeof(int));
        dtWorkTime.Columns.Add("OT3", typeof(int));
        dtWorkTime.Columns.Add("SUMOT", typeof(int));
        dtWorkTime.Columns.Add("REQDOT1", typeof(int));
        dtWorkTime.Columns.Add("REQDOT15", typeof(int));
        dtWorkTime.Columns.Add("REQDOT2", typeof(int));
        dtWorkTime.Columns.Add("REQDOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMDOTREQ", typeof(int));
        dtWorkTime.Columns.Add("SUMMPReqD", typeof(int));
        dtWorkTime.Columns.Add("DOT1", typeof(int));
        dtWorkTime.Columns.Add("DOT15", typeof(int));
        dtWorkTime.Columns.Add("DOT2", typeof(int));
        dtWorkTime.Columns.Add("DOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMDOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPD", typeof(int));

        dtWorkTime.Columns.Add("REQNOT1", typeof(int));
        dtWorkTime.Columns.Add("REQNOT15", typeof(int));
        dtWorkTime.Columns.Add("REQNOT2", typeof(int));
        dtWorkTime.Columns.Add("REQNOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMNOTREQ", typeof(int));
        dtWorkTime.Columns.Add("SUMMPReqN", typeof(int));
        dtWorkTime.Columns.Add("NOT1", typeof(int));
        dtWorkTime.Columns.Add("NOT15", typeof(int));
        dtWorkTime.Columns.Add("NOT2", typeof(int));
        dtWorkTime.Columns.Add("NOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMNOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPN", typeof(int));

        dtWorkTime.Columns.Add("REQHOT1", typeof(int));
        dtWorkTime.Columns.Add("REQHOT15", typeof(int));
        dtWorkTime.Columns.Add("REQHOT2", typeof(int));
        dtWorkTime.Columns.Add("REQHOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMHOTREQ", typeof(int));
        dtWorkTime.Columns.Add("SUMMPReqH", typeof(int));
        dtWorkTime.Columns.Add("HOT1", typeof(int));
        dtWorkTime.Columns.Add("HOT15", typeof(int));
        dtWorkTime.Columns.Add("HOT2", typeof(int));
        dtWorkTime.Columns.Add("HOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMHOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPH", typeof(int));

        string endDatePresentMonth = DateTime.Now.ToString("yyyy-MM-dd");
        string MonthPresent = Convert.ToString(DateTime.Now.Month.ToString());
        DateTime startDate = new DateTime(DateTime.Now.Year, Month, 1);
        DateTime endDate = startDate.AddMonths(1);

        string txtEndDate;

        int SumOT1 = 0, OT1 = 0, OT15 = 0, OT2 = 0, OT3 = 0;
        int SUMMPD = 0, DOT1 = 0, DOT15 = 0, DOT2 = 0, DOT3 = 0, SDOT1 = 0, SDOT15 = 0, SDOT2 = 0, SDOT3 = 0;
        int SUMMPN = 0, HOT1 = 0, HOT15 = 0, HOT2 = 0, HOT3 = 0, SHOT1 = 0, SHOT15 = 0, SHOT2 = 0, SHOT3 = 0;
        int SUMMPH = 0, NOT1 = 0, NOT15 = 0, NOT2 = 0, NOT3 = 0, SNOT1 = 0, SNOT15 = 0, SNOT2 = 0, SNOT3 = 0;

        // OT Request
        int SUMOT_REQD=0,SUMOT_ACTD = 0, REQDOT1 = 0, REQDOT15 = 0, REQDOT2 = 0, REQDOT3 = 0, SREQDOT1 = 0, SREQDOT15 = 0, SREQDOT2 = 0, SREQDOT3 = 0;
        int SUMOT_REQN=0,SUMOT_ACTN = 0, REQHOT1 = 0, REQHOT15 = 0, REQHOT2 = 0, REQHOT3 = 0, SREQHOT1 = 0, SREQHOT15 = 0, SREQHOT2 = 0, SREQHOT3 = 0;
        int SUMOT_REQH=0,SUMOT_ACTH = 0, REQNOT1 = 0, REQNOT15 = 0, REQNOT2 = 0, REQNOT3 = 0, SREQNOT1 = 0, SREQNOT15 = 0, SREQNOT2 = 0, SREQNOT3 = 0;



        if (Convert.ToString(Month) == MonthPresent)
        {
            txtEndDate = endDatePresentMonth;
        }
        else
        {
            txtEndDate = Convert.ToString(endDate.ToString());
        }
        //endDate.ToString("yyyy-MM-dd") 

        SqlCommand sql = new SqlCommand();
        //sql.CommandText = "SELECT * FROM [EmployeeWorkingTime] where Code = '"+ EmpCode + "' and DatetimeIN >= '"+ startDate.ToString("yyyy-MM-dd") + "' "+
        //    " AND DatetimeIN <= '" + txtEndDate + "'";


        sql.CommandText = "SELECT WorkShift,WorkType,otr.OTFROM ,[WCode],[WDate],[WTime],[WDoor],es.[WType],LTRIM(DATEDIFF(MINUTE, 0, otr.OT1)) as OT1,LTRIM(DATEDIFF(MINUTE, 0, otr.OT15)) as OT15 " +
                ",LTRIM(DATEDIFF(MINUTE, 0, otr.OT2)) as OT2,LTRIM(DATEDIFF(MINUTE, 0, otr.OT3)) as OT3 " +
                " FROM [dbDCI].[dbo].[EmployeeTimeStamp] es " +
                " LEFT JOIN [dbDCI].[dbo].[Employee] e ON es.WCode = e.CODE " +
                " LEFT JOIN [dbDCI].[dbo].[EmployeeWorkingTime] wt ON es.WCode = wt.Code " +
                " LEFT JOIN [dbDCI].[dbo].[EMP_OTRQ] otr ON es.WCode = otr.CODE AND es.WDate = otr.ODATE " +
                " WHERE WDate >= '" + startDate.ToString("yyyy-MM-dd") + "' AND WDate <= '" + txtEndDate + "' AND es.WType = 'O' AND WCODE = '" + EmpCode + "'" +
                " And OTFROM != ''" +
                "	AND CONVERT(DATE, wt.SystemOUT) = WDate " +
                " order by WDate  desc";


        DataTable dt = oConn.SqlGet(sql, "DBDCI");
        if (dt.Rows.Count > 0)
        {

            DataRow _row = dtWorkTime.NewRow();
            foreach (DataRow item in dt.Rows)
            {

                _row["Code"] = item["WCode"].ToString();
                _row["WorkDate"] = Convert.ToDateTime(item["WDate"].ToString()).ToString("yyyy-MM-dd");


                if (item["WorkShift"].ToString() == "D") 
                {

                    if ((item["OTFROM"].ToString() != "06:05") && (item["OTFROM"].ToString() != "20:00"))
                    {

                        SUMOT_REQD += 1;

                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                REQDOT1 += Convert.ToInt16(item["OT1"]);
                                SREQDOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                REQDOT15 += Convert.ToInt16(item["OT15"]);
                                SREQDOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                REQDOT2 += Convert.ToInt16(item["OT2"]);
                                SREQDOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                REQDOT3 += Convert.ToInt16(item["OT3"]);
                                SREQDOT3 += 1;
                            }
                        }

                        if (SREQDOT1 != 0 || SREQDOT15 != 0 || SREQDOT2 != 0 || SREQDOT3 != 0)
                        {
                            SUMOT_ACTD += 1;
                            SREQDOT1 = 0;
                            SREQDOT15 = 0;
                            SREQDOT2 = 0;
                            SREQDOT3 = 0;
                        }
                    }
                    else
                    {
                        SUMOT_REQD += 1;

                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                DOT1 += Convert.ToInt16(item["OT1"]);
                                SDOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                DOT15 += Convert.ToInt16(item["OT15"]);
                                SDOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                DOT2 += Convert.ToInt16(item["OT2"]);
                                SDOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                DOT3 += Convert.ToInt16(item["OT3"]);
                                SDOT3 += 1;
                            }
                        }

                        if (SDOT1 != 0 || SDOT15 != 0 || SDOT2 != 0 || SDOT3 != 0)
                        {
                            SUMMPD += 1;
                            SDOT1 = 0;
                            SDOT15 = 0;
                            SDOT2 = 0;
                            SDOT3 = 0;
                        }
                    
                    }

                }
                else if (item["WorkShift"].ToString() == "N")
                {
                    if ((item["OTFROM"].ToString() == "06:05") || (item["OTFROM"].ToString() == "20:00"))
                    {
                        SUMOT_REQN += 1;
                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                REQNOT1 += Convert.ToInt16(item["OT1"]);
                                SREQNOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                REQNOT15 += Convert.ToInt16(item["OT15"]);
                                SREQNOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                REQNOT2 += Convert.ToInt16(item["OT2"]);
                                SREQNOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                REQNOT3 += Convert.ToInt16(item["OT3"]);
                                SREQNOT3 += 1;
                            }
                        }
                        if (SREQNOT1 != 0 || SREQNOT15 != 0 || SREQNOT2 != 0 || SREQNOT3 != 0)
                        {
                              SUMOT_ACTN += 1;
                            SREQNOT1 = 0;
                            SREQNOT15 = 0;
                            SREQNOT2 = 0;
                            SREQNOT3 = 0;
                        }
                    }
                    else
                    {

                        SUMOT_REQN += 1;
                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                NOT1 += Convert.ToInt16(item["OT1"]);
                                SNOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                NOT15 += Convert.ToInt16(item["OT15"]);
                                SNOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                NOT2 += Convert.ToInt16(item["OT2"]);
                                SNOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                NOT3 += Convert.ToInt16(item["OT3"]);
                                SNOT3 += 1;
                            }
                        }
                        if (SNOT1 != 0 || SNOT15 != 0 || SNOT2 != 0 || SNOT3 != 0)
                        {
                            SUMMPN += 1;
                            SNOT1 = 0;
                            SNOT15 = 0;
                            SNOT2 = 0;
                            SNOT3 = 0;
                        }
                    }
                }
                else if (item["WorkType"].ToString() == "H")
                {
                    if (item["OT1"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                        {
                            HOT1 += Convert.ToInt16(item["OT1"]);
                            SHOT1 += 1;
                        }
                    }
                    if (item["OT15"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                        {
                            HOT15 += Convert.ToInt16(item["OT15"]);
                            SHOT15 += 1;
                        }
                    }
                    if (item["OT2"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                        {
                            HOT2 += Convert.ToInt16(item["OT2"]);
                            SHOT2 += 1;
                        }
                    }
                    if (item["OT3"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                        {
                            HOT3 += Convert.ToInt16(item["OT3"]);
                            SHOT3 += 1;
                        }
                    }
                    if (SHOT1 != 0 || SHOT15 != 0 || SHOT2 != 0 || SHOT3 != 0)
                    {
                        SUMMPH += 1;
                        SHOT1 = 0;
                        SHOT15 = 0;
                        SHOT2 = 0;
                        SHOT3 = 0;
                    }
                }

                //** OT DAY Req SHIFT
                _row["REQDOT1"] = REQDOT1;
                _row["REQDOT15"] = REQDOT15;
                _row["REQDOT2"] = REQDOT2;
                _row["REQDOT3"] = REQDOT3;
                _row["SUMDOTREQ"] = REQDOT1 + REQDOT15 + REQDOT2 + REQDOT3;
                _row["SUMMPReqD"] = SUMOT_REQD;

                //** OT DAY  SHIFT
                _row["DOT1"] = DOT1;
                _row["DOT15"] = DOT15;
                _row["DOT2"] = DOT2;
                _row["DOT3"] = DOT3;
                _row["SUMDOT"] = DOT1 + DOT15 + DOT2 + DOT3;
                _row["SUMMPD"] = SUMOT_ACTD;


                //** OT NIGHT Req SHIFT
                _row["REQNOT1"] = REQNOT1;
                _row["REQNOT15"] = REQNOT15;
                _row["REQNOT2"] = REQNOT2;
                _row["REQNOT3"] = REQNOT3;
                _row["SUMNOTREQ"] = REQNOT1 + REQNOT15 + REQNOT2 + REQNOT3;
                _row["SUMMPReqN"] = SUMOT_REQN;


                //** OT NIGHT SHIFT
                _row["NOT1"] = NOT1;
                _row["NOT15"] = NOT15;
                _row["NOT2"] = NOT2;
                _row["NOT3"] = NOT3;
                _row["SUMNOT"] = NOT1 + NOT15 + NOT2 + NOT3;
                _row["SUMMPN"] = SUMOT_ACTN;

                //** OT HOLIDAY SHIFT
                _row["HOT1"] = HOT1;
                _row["HOT15"] = HOT15;
                _row["HOT2"] = HOT2;
                _row["HOT3"] = HOT3;
                _row["SUMHOT"] = HOT1 + HOT15 + HOT2 + HOT3;
                _row["SUMMPH"] = SUMMPH;

                //** SUMMARY OVER-TIME
                _row["OT1"] = REQDOT1 + REQNOT1;
                _row["OT15"] = REQDOT15 + REQNOT15;
                _row["OT2"] = REQDOT2 + REQNOT2;
                _row["OT3"] = REQDOT3 + REQNOT3;
                _row["SUMOT"] = REQDOT1 + REQNOT1 + REQDOT15 + REQNOT15 + REQDOT2 + REQNOT2 + REQDOT3 + REQNOT3;




            }
            dtWorkTime.Rows.Add(_row);
        }

        return dtWorkTime;
    }
    public DataTable GetEmployeeWorkTimeOfDay(string EmpCode, string WType, int Month)
    {

        DataTable dtWorkTime = new DataTable();
        dtWorkTime.Columns.Add("Code", typeof(string));
        dtWorkTime.Columns.Add("WorkDate", typeof(string));
        dtWorkTime.Columns.Add("POSIT", typeof(string));
        dtWorkTime.Columns.Add("OT1", typeof(int));
        dtWorkTime.Columns.Add("OT15", typeof(int));
        dtWorkTime.Columns.Add("OT2", typeof(int));
        dtWorkTime.Columns.Add("OT3", typeof(int));
        dtWorkTime.Columns.Add("SUMOT", typeof(int));
        dtWorkTime.Columns.Add("REQDOT1", typeof(int));
        dtWorkTime.Columns.Add("REQDOT15", typeof(int));
        dtWorkTime.Columns.Add("REQDOT2", typeof(int));
        dtWorkTime.Columns.Add("REQDOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMDOTREQ", typeof(int));
        dtWorkTime.Columns.Add("SUMMPReqD", typeof(int));
        dtWorkTime.Columns.Add("DOT1", typeof(int));
        dtWorkTime.Columns.Add("DOT15", typeof(int));
        dtWorkTime.Columns.Add("DOT2", typeof(int));
        dtWorkTime.Columns.Add("DOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMDOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPD", typeof(int));

        dtWorkTime.Columns.Add("REQNOT1", typeof(int));
        dtWorkTime.Columns.Add("REQNOT15", typeof(int));
        dtWorkTime.Columns.Add("REQNOT2", typeof(int));
        dtWorkTime.Columns.Add("REQNOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMNOTREQ", typeof(int));
        dtWorkTime.Columns.Add("SUMMPReqN", typeof(int));
        dtWorkTime.Columns.Add("NOT1", typeof(int));
        dtWorkTime.Columns.Add("NOT15", typeof(int));
        dtWorkTime.Columns.Add("NOT2", typeof(int));
        dtWorkTime.Columns.Add("NOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMNOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPN", typeof(int));

        dtWorkTime.Columns.Add("REQHOT1", typeof(int));
        dtWorkTime.Columns.Add("REQHOT15", typeof(int));
        dtWorkTime.Columns.Add("REQHOT2", typeof(int));
        dtWorkTime.Columns.Add("REQHOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMHOTREQ", typeof(int));
        dtWorkTime.Columns.Add("SUMMPReqH", typeof(int));
        dtWorkTime.Columns.Add("HOT1", typeof(int));
        dtWorkTime.Columns.Add("HOT15", typeof(int));
        dtWorkTime.Columns.Add("HOT2", typeof(int));
        dtWorkTime.Columns.Add("HOT3", typeof(int));
        dtWorkTime.Columns.Add("SUMHOT", typeof(int));
        dtWorkTime.Columns.Add("SUMMPH", typeof(int));

        string endDatePresentMonth = DateTime.Now.ToString("yyyy-MM-dd");
        string MonthPresent = Convert.ToString(DateTime.Now.Month.ToString());
        DateTime startDate = new DateTime(DateTime.Now.Year, Month, 1);
        DateTime endDate = startDate.AddMonths(1);

        string txtEndDate;

        int SumOT1 = 0, OT1 = 0, OT15 = 0, OT2 = 0, OT3 = 0;
        int SUMMPD = 0, DOT1 = 0, DOT15 = 0, DOT2 = 0, DOT3 = 0, SDOT1 = 0, SDOT15 = 0, SDOT2 = 0, SDOT3 = 0;
        int SUMMPN = 0, HOT1 = 0, HOT15 = 0, HOT2 = 0, HOT3 = 0, SHOT1 = 0, SHOT15 = 0, SHOT2 = 0, SHOT3 = 0;
        int SUMMPH = 0, NOT1 = 0, NOT15 = 0, NOT2 = 0, NOT3 = 0, SNOT1 = 0, SNOT15 = 0, SNOT2 = 0, SNOT3 = 0;

        // OT Request
        int SUMOT_REQD = 0, SUMOT_ACTD = 0, REQDOT1 = 0, REQDOT15 = 0, REQDOT2 = 0, REQDOT3 = 0, SREQDOT1 = 0, SREQDOT15 = 0, SREQDOT2 = 0, SREQDOT3 = 0;
        int SUMOT_REQN = 0, SUMOT_ACTN = 0, REQHOT1 = 0, REQHOT15 = 0, REQHOT2 = 0, REQHOT3 = 0, SREQHOT1 = 0, SREQHOT15 = 0, SREQHOT2 = 0, SREQHOT3 = 0;
        int SUMOT_REQH = 0, SUMOT_ACTH = 0, REQNOT1 = 0, REQNOT15 = 0, REQNOT2 = 0, REQNOT3 = 0, SREQNOT1 = 0, SREQNOT15 = 0, SREQNOT2 = 0, SREQNOT3 = 0;

        //---------------- Get Employeee of Andon --------------
        string txtAndon = "";

        DataTable dtAndon = new DataTable();
        dtAndon.Columns.Add("LineCode", typeof(string));
        dtAndon.Columns.Add("LineName", typeof(string));
        dtAndon.Columns.Add("BoardId", typeof(string));
        dtAndon.Columns.Add("LineGroup", typeof(string));
      //  DateTime setDate = new DateTime(DateTime.Now.Year, MonthSelect, 1);


        SqlCommand sql = new SqlCommand();

    

        sql.CommandText = " Select LineCode,LineName,BoardId,LineGroup, " +
                 " PdModel,Factory " +
                 "  FROM PD_LineMstr where factory = '" + EmpCode + "' " +
                 " order by boardid  ";


        int ii = 0;
        DataTable dtt = oConn.SqlGet(sql, "DBPDB");
        foreach (DataRow item in dtt.Rows)
        {
            DataRow _rowAndon = dtAndon.NewRow();
            if ((item["LineCode"].ToString() != "") && (item["BoardId"].ToString() != "" && item["BoardId"].ToString() != "-"))
            {
                _rowAndon["LineCode"] = item["LineCode"].ToString();
                _rowAndon["LineName"] = item["LineName"].ToString();
                _rowAndon["BoardId"] = item["BoardId"].ToString();
                _rowAndon["LineGroup"] = item["LineGroup"].ToString();
                dtAndon.Rows.Add(_rowAndon);
            }
        }

        string sqlandon = " andon like ";
        int Loopj=0;
        if (dtAndon.Rows.Count > 0)
        {
          
            foreach (DataRow _rowMP in dtAndon.Rows)
              {
                
                  if (Loopj == dtAndon.Rows.Count-1)
                  {
                      txtAndon += sqlandon + "'" + _rowMP["BoardId"].ToString();
                  }
                  else
                  {
                      txtAndon += sqlandon + "'" + _rowMP["BoardId"].ToString() + "' or ";
                    
                  }
                  Loopj +=1;
              }
        }





        if (Convert.ToString(Month) == MonthPresent)
        {
            txtEndDate = endDatePresentMonth;
        }
        else
        {
            txtEndDate = Convert.ToString(endDate.ToString());
        }
        //endDate.ToString("yyyy-MM-dd") 

        //SqlCommand sql = new SqlCommand();
        //sql.CommandText = "SELECT * FROM [EmployeeWorkingTime] where Code = '"+ EmpCode + "' and DatetimeIN >= '"+ startDate.ToString("yyyy-MM-dd") + "' "+
        //    " AND DatetimeIN <= '" + txtEndDate + "'";


        sql.CommandText = "SELECT e.Posit,WorkShift,WorkType,otr.OTFROM ,[WCode],[WDate],[WTime],[WDoor],es.[WType],LTRIM(DATEDIFF(MINUTE, 0, otr.OT1)) as OT1,LTRIM(DATEDIFF(MINUTE, 0, otr.OT15)) as OT15 " +
                ",LTRIM(DATEDIFF(MINUTE, 0, otr.OT2)) as OT2,LTRIM(DATEDIFF(MINUTE, 0, otr.OT3)) as OT3 " +
                " FROM [dbDCI].[dbo].[EmployeeTimeStamp] es " +
                " LEFT JOIN [dbDCI].[dbo].[Employee] e ON es.WCode = e.CODE " +
                " LEFT JOIN [dbDCI].[dbo].[EmployeeWorkingTime] wt ON es.WCode = wt.Code " +
                " LEFT JOIN [dbDCI].[dbo].[EMP_OTRQ] otr ON es.WCode = otr.CODE AND es.WDate = otr.ODATE " +
                " WHERE WDate >= '" + startDate.ToString("yyyy-MM-dd") + "' AND WDate <= '" + txtEndDate + "' AND es.WType = 'O' " +
                " And OTFROM != ''" +
                "	AND CONVERT(DATE, wt.SystemOUT) = WDate " +
                " And  ( " + txtAndon + "')" +
                " order by WDate  desc";


        DataTable dt = oConn.SqlGet(sql, "DBDCI");
        if (dt.Rows.Count > 0)
        {

            DataRow _row = dtWorkTime.NewRow();
            foreach (DataRow item in dt.Rows)
            {

                _row["Code"] = item["WCode"].ToString();
                _row["WorkDate"] = Convert.ToDateTime(item["WDate"].ToString()).ToString("yyyy-MM-dd");
                _row["POSIT"] = item["Posit"].ToString();

                if (item["WorkShift"].ToString() == "D")
                {

                    if ((item["OTFROM"].ToString() != "06:05") && (item["OTFROM"].ToString() != "20:00"))
                    {

                        SUMOT_REQD += 1;

                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                REQDOT1 += Convert.ToInt16(item["OT1"]);
                                SREQDOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                REQDOT15 += Convert.ToInt16(item["OT15"]);
                                SREQDOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                REQDOT2 += Convert.ToInt16(item["OT2"]);
                                SREQDOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                REQDOT3 += Convert.ToInt16(item["OT3"]);
                                SREQDOT3 += 1;
                            }
                        }

                        if (SREQDOT1 != 0 || SREQDOT15 != 0 || SREQDOT2 != 0 || SREQDOT3 != 0)
                        {
                            SUMOT_ACTD += 1;
                            SREQDOT1 = 0;
                            SREQDOT15 = 0;
                            SREQDOT2 = 0;
                            SREQDOT3 = 0;
                        }
                    }
                    else
                    {
                        SUMOT_REQD += 1;

                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                DOT1 += Convert.ToInt16(item["OT1"]);
                                SDOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                DOT15 += Convert.ToInt16(item["OT15"]);
                                SDOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                DOT2 += Convert.ToInt16(item["OT2"]);
                                SDOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                DOT3 += Convert.ToInt16(item["OT3"]);
                                SDOT3 += 1;
                            }
                        }

                        if (SDOT1 != 0 || SDOT15 != 0 || SDOT2 != 0 || SDOT3 != 0)
                        {
                            SUMMPD += 1;
                            SDOT1 = 0;
                            SDOT15 = 0;
                            SDOT2 = 0;
                            SDOT3 = 0;
                        }

                    }

                }
                else if (item["WorkShift"].ToString() == "N")
                {
                    if ((item["OTFROM"].ToString() == "06:05") || (item["OTFROM"].ToString() == "20:00"))
                    {
                        SUMOT_REQN += 1;
                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                REQNOT1 += Convert.ToInt16(item["OT1"]);
                                SREQNOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                REQNOT15 += Convert.ToInt16(item["OT15"]);
                                SREQNOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                REQNOT2 += Convert.ToInt16(item["OT2"]);
                                SREQNOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                REQNOT3 += Convert.ToInt16(item["OT3"]);
                                SREQNOT3 += 1;
                            }
                        }
                        if (SREQNOT1 != 0 || SREQNOT15 != 0 || SREQNOT2 != 0 || SREQNOT3 != 0)
                        {
                            SUMOT_ACTN += 1;
                            SREQNOT1 = 0;
                            SREQNOT15 = 0;
                            SREQNOT2 = 0;
                            SREQNOT3 = 0;
                        }
                    }
                    else
                    {

                        SUMOT_REQN += 1;
                        if (item["OT1"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                            {
                                NOT1 += Convert.ToInt16(item["OT1"]);
                                SNOT1 += 1;
                            }
                        }
                        if (item["OT15"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                            {
                                NOT15 += Convert.ToInt16(item["OT15"]);
                                SNOT15 += 1;
                            }
                        }
                        if (item["OT2"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                            {
                                NOT2 += Convert.ToInt16(item["OT2"]);
                                SNOT2 += 1;
                            }
                        }
                        if (item["OT3"].ToString() != "")
                        {
                            if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                            {
                                NOT3 += Convert.ToInt16(item["OT3"]);
                                SNOT3 += 1;
                            }
                        }
                        if (SNOT1 != 0 || SNOT15 != 0 || SNOT2 != 0 || SNOT3 != 0)
                        {
                            SUMMPN += 1;
                            SNOT1 = 0;
                            SNOT15 = 0;
                            SNOT2 = 0;
                            SNOT3 = 0;
                        }
                    }
                }
                else if (item["WorkType"].ToString() == "H")
                {
                    if (item["OT1"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT1"].ToString()) != 0)
                        {
                            HOT1 += Convert.ToInt16(item["OT1"]);
                            SHOT1 += 1;
                        }
                    }
                    if (item["OT15"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT15"].ToString()) != 0)
                        {
                            HOT15 += Convert.ToInt16(item["OT15"]);
                            SHOT15 += 1;
                        }
                    }
                    if (item["OT2"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT2"].ToString()) != 0)
                        {
                            HOT2 += Convert.ToInt16(item["OT2"]);
                            SHOT2 += 1;
                        }
                    }
                    if (item["OT3"].ToString() != "")
                    {
                        if (Convert.ToInt16(item["OT3"].ToString()) != 0)
                        {
                            HOT3 += Convert.ToInt16(item["OT3"]);
                            SHOT3 += 1;
                        }
                    }
                    if (SHOT1 != 0 || SHOT15 != 0 || SHOT2 != 0 || SHOT3 != 0)
                    {
                        SUMMPH += 1;
                        SHOT1 = 0;
                        SHOT15 = 0;
                        SHOT2 = 0;
                        SHOT3 = 0;
                    }
                }

                //** OT DAY Req SHIFT
                _row["REQDOT1"] = REQDOT1;
                _row["REQDOT15"] = REQDOT15;
                _row["REQDOT2"] = REQDOT2;
                _row["REQDOT3"] = REQDOT3;
                _row["SUMDOTREQ"] = REQDOT1 + REQDOT15 + REQDOT2 + REQDOT3;
                _row["SUMMPReqD"] = SUMOT_REQD;

                //** OT DAY  SHIFT
                _row["DOT1"] = DOT1;
                _row["DOT15"] = DOT15;
                _row["DOT2"] = DOT2;
                _row["DOT3"] = DOT3;
                _row["SUMDOT"] = DOT1 + DOT15 + DOT2 + DOT3;
                _row["SUMMPD"] = SUMOT_ACTD;


                //** OT NIGHT Req SHIFT
                _row["REQNOT1"] = REQNOT1;
                _row["REQNOT15"] = REQNOT15;
                _row["REQNOT2"] = REQNOT2;
                _row["REQNOT3"] = REQNOT3;
                _row["SUMNOTREQ"] = REQNOT1 + REQNOT15 + REQNOT2 + REQNOT3;
                _row["SUMMPReqN"] = SUMOT_REQN;


                //** OT NIGHT SHIFT
                _row["NOT1"] = NOT1;
                _row["NOT15"] = NOT15;
                _row["NOT2"] = NOT2;
                _row["NOT3"] = NOT3;
                _row["SUMNOT"] = NOT1 + NOT15 + NOT2 + NOT3;
                _row["SUMMPN"] = SUMOT_ACTN;

                //** OT HOLIDAY SHIFT
                _row["HOT1"] = HOT1;
                _row["HOT15"] = HOT15;
                _row["HOT2"] = HOT2;
                _row["HOT3"] = HOT3;
                _row["SUMHOT"] = HOT1 + HOT15 + HOT2 + HOT3;
                _row["SUMMPH"] = SUMMPH;

                //** SUMMARY OVER-TIME
                _row["OT1"] = REQDOT1 + REQNOT1;
                _row["OT15"] = REQDOT15 + REQNOT15;
                _row["OT2"] = REQDOT2 + REQNOT2;
                _row["OT3"] = REQDOT3 + REQNOT3;
                _row["SUMOT"] = REQDOT1 + REQNOT1 + REQDOT15 + REQNOT15 + REQDOT2 + REQNOT2 + REQDOT3 + REQNOT3;




            }
            dtWorkTime.Rows.Add(_row);
        }

        return dtWorkTime;
    }

    public bool CheckEmployeeOnBase(string Code)
    {
        bool Emp = false;

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT * FROM [Employee] WHERE CODE = '"+Code+"'";
        DataTable dt = oConn.SqlGet(sql, "DBDCI");
        if (dt.Rows.Count > 0)
        {
            Emp = true;
        }


        return Emp;
    }
}