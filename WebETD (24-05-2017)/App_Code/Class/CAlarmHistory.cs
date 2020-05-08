using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CMechaNGGraph
/// </summary>
public class CAlarmHistory
{
    ConnectDBIoTServerTonMecha oCon = new ConnectDBIoTServerTonMecha();
    ConnectDBODM oConODM = new ConnectDBODM();
    public MDAlarmHistory GetAlarmHistoryGraph(string DateStart, string DateEnd, string Range, string Shift, string Volume, string listMC, string line, string fac, string LineODM)
    {
        MDAlarmHistory oMDAlarmHistory = new MDAlarmHistory();
        DataTable dTable = new DataTable();
        DataTable dTable1;
        DataTable dTable2;
        SqlCommand sql = new SqlCommand();
        sql.CommandTimeout = 180;
        string _listMC = "";
        try
        {
            if (listMC == "''")
            {
                listMC = "";
            }
            if (listMC != "")
            {
                _listMC = "in (" + listMC.Replace('%', '&') + ")";
            }
            else
            {
                _listMC = "not in ('')";
            }
            if (fac == "Fac3")
            {
                #region Fac3

                int _Volume = int.Parse(Volume);
                if (Range == "D")
                {
                    if (Shift == "All")
                    {

                        sql.CommandText = @"select t1.[MCName],t1.Qty,case when t2.Timediff is null then 0 else t2.Timediff end as Timediff,t1.StampDate from (SELECT  [MCName],[StampDate],Sum([CountAlarm]) as Qty
                                            FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                            where [StampDate] between @DateStart and @DateEnd and  [MCName] " + _listMC + @" 
                                            group by MCName,StampDate) t1 
                                            left join (
                                            SELECT  ADMC.[MC_No],AMC.ProcressName
                                            ,SUM(DATEDIFF(SECOND,[DateStart],[DateEnd])) as Timediff,FORMAT(DateStart, 'yyyy-MM-dd') as insertDate
                                            FROM [MECHA_FAC3].[dbo].[Scada_Alarm_Detail_MC] ADMC
                                            left join AlarmMC AMC on ADMC.MC_No = AMC.MC_No
                                            where DateStart between @DateStart and @DateEnd
                                            group by ADMC.MC_No,AMC.ProcressName,FORMAT(DateStart, 'yyyy-MM-dd') 
                                            ) t2 on t1.MCName = t2.ProcressName and t1.StampDate = t2.insertDate";
                        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
                        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));

                    }
                    else
                    {
                        sql.CommandText = @"select t1.[MCName],t1.Qty,case when t2.Timediff is null then 0 else t2.Timediff end as Timediff,t1.StampDate from (SELECT  [MCName],[StampDate],Sum([CountAlarm]) as Qty
                                            FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                            where [StampDate] between @DateStart and @DateEnd and Shift = @Shift and [MCName] " + _listMC + @"
                                            group by MCName,StampDate) t1 
                                            left join (
                                            SELECT  ADMC.[MC_No],AMC.ProcressName
                                            ,SUM(DATEDIFF(SECOND,[DateStart],[DateEnd])) as Timediff,FORMAT(DateStart, 'yyyy-MM-dd') as insertDate
                                            FROM [MECHA_FAC3].[dbo].[Scada_Alarm_Detail_MC] ADMC
                                            left join AlarmMC AMC on ADMC.MC_No = AMC.MC_No
                                            where DateStart between @DateStart and @DateEnd
                                            group by ADMC.MC_No,AMC.ProcressName,FORMAT(DateStart, 'yyyy-MM-dd') 
                                            ) t2 on t1.MCName = t2.ProcressName and t1.StampDate = t2.insertDate";
                        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
                        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                        sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                    }
                    dTable = oCon.Query(sql);
                }
                else if (Range == "W")
                {
                    #region Week
                    //                    if (Shift == "All")
                    //                    {
                    //                        for (int i = 0; i <= _Volume - 1; i++)
                    //                        {
                    //                            if (i == 0)
                    //                            {
                    //                                dTable1 = new DataTable();
                    //                                sql = new SqlCommand();
                    //                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD(week, 0, GETDATE()) as StampDate
                    //                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                    //                                                  where [StampDate] between DATEADD(week, -1, FORMAT(GETDATE(), 'yyyy-MM-dd')) and DATEADD(week, 0,@DateEnd)
                    //                                                  and [MCName] " + _listMC + @"
                    //                                                  group by MCName";
                    //                                sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
                    //                                sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                    //                                sql.Parameters.Add(new SqlParameter("@i", i));
                    //                                dTable1 = oCon.Query(sql);
                    //                                dTable.Merge(dTable1);
                    //                            }
                    //                            else
                    //                            {
                    //                                dTable2 = new DataTable();
                    //                                sql = new SqlCommand();
                    //                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD( week, @i, GETDATE()) as StampDate
                    //                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                    //                                                  where [StampDate] between DATEADD(week, @j, FORMAT(getdate(), 'yyyy-MM-dd')) and DATEADD(week, @i, GETDATE()) 
                    //                                                  and [MCName] " + _listMC + @"
                    //                                                  group by MCName";
                    //                                sql.Parameters.Add(new SqlParameter("@i", 0 - i));
                    //                                sql.Parameters.Add(new SqlParameter("@j", 0 - i - 1));
                    //                                dTable2 = oCon.Query(sql);
                    //                                dTable.Merge(dTable2);
                    //                            }

                    //                        }

                    //                    }
                    //                    else
                    //                    {
                    //                        for (int i = 0; i <= _Volume - 1; i++)
                    //                        {
                    //                            if (i == 0)
                    //                            {
                    //                                dTable1 = new DataTable();
                    //                                sql = new SqlCommand();
                    //                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD(week, 0, GETDATE()) as StampDate
                    //                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                    //                                                  where [StampDate] between DATEADD(week, -1, FORMAT(GETDATE(), 'yyyy-MM-dd')) and DATEADD(week, 0,@DateEnd) 
                    //                                                        and Shift = @Shift and [MCName] " + _listMC + @"
                    //                                                  group by MCName";
                    //                                sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                    //                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                    //                                dTable1 = oCon.Query(sql);
                    //                                dTable.Merge(dTable1);
                    //                            }
                    //                            else
                    //                            {
                    //                                dTable2 = new DataTable();
                    //                                sql = new SqlCommand();
                    //                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD( week, @i, GETDATE()) as StampDate
                    //                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                    //                                                  where [StampDate] between DATEADD(week, @j, FORMAT(getdate(), 'yyyy-MM-dd')) and DATEADD(week, @i, GETDATE()) 
                    //                                                        and Shift = @Shift and [MCName] " + _listMC + @"
                    //                                                  group by MCName";
                    //                                sql.Parameters.Add(new SqlParameter("@i", 0 - i));
                    //                                sql.Parameters.Add(new SqlParameter("@j", 0 - i - 1));
                    //                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                    //                                dTable2 = oCon.Query(sql);
                    //                                dTable.Merge(dTable2);
                    //                            }

                    //                        }
                    //                    }
                    #endregion
                }
                else if (Range == "M")
                {
                    if (Shift == "All")
                    {
                        for (int i = 0; i < _Volume; i++)
                        {
                            if (i == 0)
                            {
                                dTable1 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"select t1.[MCName],t1.Qty,case when t2.Timediff is null then 0 else t2.Timediff end as Timediff,t1.StampDate from (SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(GETDATE(), 'yyyy-MM') as StampDate
                                                    FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                    where [StampDate] between FORMAT(GETDATE(), 'yyyy-MM-01') and GETDATE()  and [MCName] " + _listMC + @"
                                                    group by MCName) t1 
                                                    left join (
                                                        SELECT  ADMC.[MC_No],AMC.ProcressName
	                                                        ,SUM(DATEDIFF(SECOND,[DateStart],[DateEnd])) as Timediff
                                                        FROM [MECHA_FAC3].[dbo].[Scada_Alarm_Detail_MC] ADMC
                                                        left join AlarmMC AMC on ADMC.MC_No = AMC.MC_No
                                                        where DateStart between FORMAT(GETDATE(), 'yyyy-MM-01') and GETDATE()
                                                        group by ADMC.MC_No,AMC.ProcressName
                                                    ) t2 on t1.MCName = t2.ProcressName";
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable1 = oCon.Query(sql);
                                dTable.Merge(dTable1);
                            }
                            else
                            {
                                dTable2 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"select t1.[MCName],t1.Qty,case when t2.Timediff is null then 0 else t2.Timediff end as Timediff,t1.StampDate from (SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(DATEADD(month, @i,GETDATE()), 'yyyy-MM') as StampDate
                                                    FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                    where [StampDate] between DATEADD(month, @i, FORMAT(GETDATE(), 'yyyy-MM-01')) and EOMONTH(DATEADD(month, @i,FORMAT(GETDATE(), 'yyyy-MMM')))
                                                    and [MCName] " + _listMC + @"
                                                    group by MCName) t1 
                                                    left join (
                                                     SELECT  ADMC.[MC_No],AMC.ProcressName
	                                                      ,SUM(DATEDIFF(SECOND,[DateStart],[DateEnd])) as Timediff
                                                      FROM [MECHA_FAC3].[dbo].[Scada_Alarm_Detail_MC] ADMC
                                                      left join AlarmMC AMC on ADMC.MC_No = AMC.MC_No
                                                      where DateStart  between DATEADD(month, @i, FORMAT(GETDATE(), 'yyyy-MM-01')) and EOMONTH(DATEADD(month, @i,FORMAT(GETDATE(), 'yyyy-MMM')))
                                                      group by ADMC.MC_No,AMC.ProcressName
                                                    ) t2 on t1.MCName = t2.ProcressName";
                                sql.Parameters.Add(new SqlParameter("@i", 0 - i));
                                sql.Parameters.Add(new SqlParameter("@j", 0 - i - 1));
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable2 = oCon.Query(sql);
                                dTable.Merge(dTable2);
                            }

                        }
                        dTable.DefaultView.Sort = "StampDate asc";
                        dTable = dTable.DefaultView.ToTable();
                    }
                    else
                    {
                        for (int i = 0; i < _Volume; i++)
                        {
                            if (i == 0)
                            {
                                dTable1 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"select t1.[MCName],t1.Qty,case when t2.Timediff is null then 0 else t2.Timediff end as Timediff,t1.StampDate from (SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(GETDATE(), 'yyyy-MM') as StampDate
                                                    FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                    where [StampDate] between FORMAT(GETDATE(), 'yyyy-MM-01 08:00') and DATEADD(day,1,@DateEnd)
                                                        and Shift = @Shift and [MCName] " + _listMC + @"
                                                    group by MCName) t1 
                                                    left join (
                                                        SELECT  ADMC.[MC_No],AMC.ProcressName
	                                                        ,SUM(DATEDIFF(SECOND,[DateStart],[DateEnd])) as Timediff
                                                        FROM [MECHA_FAC3].[dbo].[Scada_Alarm_Detail_MC] ADMC
                                                        left join AlarmMC AMC on ADMC.MC_No = AMC.MC_No
                                                        where DateStart between FORMAT(GETDATE(), 'yyyy-MM-01 08:00') and DATEADD(day,1,@DateEnd)
                                                        group by ADMC.MC_No,AMC.ProcressName
                                                    ) t2 on t1.MCName = t2.ProcressName";
                                sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd + " 08:00"));
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable1 = oCon.Query(sql);
                                dTable.Merge(dTable1);
                            }
                            else
                            {
                                dTable2 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"select t1.[MCName],t1.Qty,case when t2.Timediff is null then 0 else t2.Timediff end as Timediff,t1.StampDate from (SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(DATEADD(month, @i,GETDATE()), 'yyyy-MM') as StampDate
                                                    FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                    where [StampDate] between DATEADD(month, @i, FORMAT(GETDATE(), 'yyyy-MM-01')) and EOMONTH(DATEADD(month, @i,FORMAT(GETDATE(), 'yyyy-MMM')))
                                                     and Shift = @Shift and [MCName] " + _listMC + @"
                                                    group by MCName) t1 
                                                    left join (
                                                     SELECT  ADMC.[MC_No],AMC.ProcressName
	                                                      ,SUM(DATEDIFF(SECOND,[DateStart],[DateEnd])) as Timediff
                                                      FROM [MECHA_FAC3].[dbo].[Scada_Alarm_Detail_MC] ADMC
                                                      left join AlarmMC AMC on ADMC.MC_No = AMC.MC_No
                                                      where DateStart  between DATEADD(month, @i, FORMAT(GETDATE(), 'yyyy-MM-01')) and EOMONTH(DATEADD(month, @i,FORMAT(GETDATE(), 'yyyy-MMM')))
                                                      group by ADMC.MC_No,AMC.ProcressName
                                                    ) t2 on t1.MCName = t2.ProcressName";
                                sql.Parameters.Add(new SqlParameter("@i", 0 - i));
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable2 = oCon.Query(sql);
                                dTable.Merge(dTable2);
                            }
                            //SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD(week, 0, GETDATE()) as StampDate
                            //FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                            //where [StampDate] between DATEADD(day, -7, FORMAT(GETDATE(), 'yyyy-MM-dd')) and DATEADD(day, 0,getdate())
                            //group by MCName
                        }
                        dTable.DefaultView.Sort = "StampDate asc";
                        dTable = dTable.DefaultView.ToTable();
                    }
                }

                #endregion
            }
            else if (fac == "ODM")/////////////////////////////////////////////////////////////////////////////////////////////////////////////////// ODM /////////////////////////////////////////////////////////////////////////////////////
            {
                #region ODM
                dTable = new DataTable();
                string sqlStr = "";
                DateTime SDate = DateTime.Parse(DateStart);
                DateTime EDate = DateTime.Parse(DateEnd);
                DataTable dTableFor = new DataTable();
                if (LineODM == "IN")
                {
                    LineODM = "Line_No = 1";
                }
                else if (LineODM == "OUT")
                {
                    LineODM = "Line_No = 2";
                }

                if (Shift == "All")
                {


                    //***********************************************************************************
                    //*                          selete  Date Sdate to Edate-1                                
                    //***********************************************************************************
                    sqlStr = @"SELECT AM.[MC_Name] AS MCName,am.Network_No+AM.Station_No+AM.Location_No as Stations,SUM(convert(int,Times)) as Qty,FORMAT (InsertDate, 'yyyy-MM-dd') as StampDate,'0' as Timediff FROM [dbIoTFacODM].[dbo].[odm_od_AlarmPerDay] AD
                                    left join odm_od_Alarm_mst AM on am.Network_No=ad.Network_No 
                                    and AM.Station_No = AD.Station_No and AM.Location_No = AD.Location_No and AM.Line_No = AD.Line_No
                                    where [InsertDate] between '" + SDate.ToString("yyyy-MM-dd") + "' and '" + EDate.AddDays(-1).ToString("yyyy-MM-dd") + "'  and AD." + LineODM + @" and am.Network_No+AM.Station_No+AM.Location_No " + _listMC +
                            @"group by AM.[MC_Name],[InsertDate],am.Network_No,AM.Station_No,AM.Location_No,AM.Line_No";
                    dTableFor = oConODM.Query(sqlStr);
                    dTable.Merge(dTableFor);

                    //***********************************************************************************
                    //*                             selete Edate                                                
                    //***********************************************************************************
                    sqlStr = @"SELECT am.MC_Name AS MCName,am.[Network_No]+AM.[Station_No]+AM.[Location_No] as Stations,count([AlarmNo]) as Qty,'" + EDate.ToString("yyyy-MM-dd") + @"' as StampDate,'0' as Timediff
	                            FROM [dbIoTFacODM].[dbo].[vi_ODM_OD_Alarm] AD
                            left join odm_od_Alarm_mst AM on am.Network_No=ad.Network_No 
                            and AM.Station_No = AD.Station_No and AM.Location_No = AD.Location_No and AM.Line_No = AD.Line_No
                            where DateInsert between '" + EDate.ToString("yyyy-MM-dd") + @" 08:00' and '" + EDate.ToString("yyyy-MM-dd") + @" 20:00' 
                            and am." + LineODM + @" and am.Network_No+AM.Station_No+AM.Location_No " + _listMC +
                            @" group by am.MC_Name,AM.[Network_No],AM.[Station_No],AM.[Location_No]
                            order by am.MC_Name";
                          
                    dTableFor = oConODM.Query(sqlStr);

                    dTable.Merge(dTableFor);



                }else
                {
                    //***********************************************************************************
                    //*                          selete  Date Sdate to Edate-1                                
                    //***********************************************************************************
                    sqlStr = @"SELECT AM.[MC_Name] AS MCName,am.Network_No+AM.Station_No+AM.Location_No as Stations,CONVERT(int,Times) as Qty,FORMAT (InsertDate, 'yyyy-MM-dd') as StampDate,'0' as Timediff FROM [dbIoTFacODM].[dbo].[odm_od_AlarmPerDay] AD
                                    left join odm_od_Alarm_mst AM on am.Network_No=ad.Network_No 
                                    and AM.Station_No = AD.Station_No and AM.Location_No = AD.Location_No and AM.Line_No = AD.Line_No
                                    where [InsertDate] between '" + SDate.ToString("yyyy-MM-dd") + "' and '" + EDate.AddDays(-1).ToString("yyyy-MM-dd") + "'  and AD." + LineODM + @" and am.Network_No+AM.Station_No+AM.Location_No " + _listMC +
                            @" and AD.Shift = '"+Shift+"'";
                    dTableFor = oConODM.Query(sqlStr);
                    dTable.Merge(dTableFor);

                    //***********************************************************************************
                    //*                             selete Edate                                                
                    //***********************************************************************************
                    if (Shift == "D")
                    {
                        sqlStr = @"SELECT am.MC_Name AS MCName,am.[Network_No]+AM.[Station_No]+AM.[Location_No] as Stations,count([AlarmNo]) as Qty,'" + EDate.ToString("yyyy-MM-dd") + @"' as StampDate,'0' as Timediff
	                            FROM [dbIoTFacODM].[dbo].[vi_ODM_OD_Alarm] AD
                            left join odm_od_Alarm_mst AM on am.Network_No=ad.Network_No 
                            and AM.Station_No = AD.Station_No and AM.Location_No = AD.Location_No and AM.Line_No = AD.Line_No
                            where DateInsert between '" + EDate.ToString("yyyy-MM-dd") + @" 08:00' and '" + EDate.ToString("yyyy-MM-dd") + @" 20:00' 
                            and am." + LineODM + @" and am.Network_No+AM.Station_No+AM.Location_No " + _listMC +
                            @" group by am.MC_Name,AM.[Network_No],AM.[Station_No],AM.[Location_No]
                            order by am.MC_Name";

                        dTableFor = oConODM.Query(sqlStr);

                        dTable.Merge(dTableFor);
                    }
                    else
                    {
                        sqlStr = @"SELECT am.MC_Name AS MCName,am.[Network_No]+AM.[Station_No]+AM.[Location_No] as Stations,count([AlarmNo]) as Qty,'" + EDate.ToString("yyyy-MM-dd") + @"' as StampDate,'0' as Timediff
	                            FROM [dbIoTFacODM].[dbo].[vi_ODM_OD_Alarm] AD
                            left join odm_od_Alarm_mst AM on am.Network_No=ad.Network_No 
                            and AM.Station_No = AD.Station_No and AM.Location_No = AD.Location_No and AM.Line_No = AD.Line_No
                            where DateInsert between '" + EDate.ToString("yyyy-MM-dd") + @" 20:00' and DATEADD(DAY,1,'" + EDate.ToString("yyyy-MM-dd") + @"')+ ' 08:00' 
                            and am." + LineODM + @" and am.Network_No+AM.Station_No+AM.Location_No " + _listMC +
                            @" group by am.MC_Name,AM.[Network_No],AM.[Station_No],AM.[Location_No]
                            order by am.MC_Name";

                        dTableFor = oConODM.Query(sqlStr);

                        dTable.Merge(dTableFor);
                    }
                    
                }



                #endregion
            }
        }
        catch (Exception)
        {

        }
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDAlarmHistory.CMAlarmHistory oCMD = new MDAlarmHistory.CMAlarmHistory();
                oCMD.MCName = row["MCName"].ToString();
                oCMD.StampDate = Convert.ToDateTime(row["StampDate"]).ToString("yyyy-MM-dd");
                oCMD.Qty = int.Parse(row["Qty"].ToString());
                oCMD.Timediff = int.Parse(row["Timediff"].ToString());
                oMDAlarmHistory.ListOfAlarm.Add(oCMD);
            }

        }

        sql = new SqlCommand();
        if (line == "All")
        {
            line = "!= '" + line + "'";
        }
        else
        {
            line = " = '" + line + "'";
        }
        DataTable dTableMC = new DataTable();
        //////////////////////////////////////  Categories
        if (fac == "Fac3")
        {
            sql.CommandText = @"SELECT MachineName FROM  [MECHA_FAC3].[dbo].[AlarmLineSetting] WHERE MachineName " + _listMC + " and [LineName] " + line + " Order by [MachineName]";
            dTableMC = oCon.Query(sql);
        }
        else if (fac == "ODM")
        {
            sql.CommandText = @"SELECT  [ID],Network_No+[Station_No]+Location_No as Stations,[MC_Name] as MachineName FROM [dbIoTFacODM].[dbo].[odm_od_Alarm_mst] where Network_No+[Station_No]+Location_No " + _listMC + " and " + LineODM + " Order by [MC_Name]";
            dTableMC = oConODM.Query(sql);
        }
        if (dTableMC.Rows.Count > 0)
        {
            foreach (DataRow row in dTableMC.Rows)
            {
                MDAlarmHistory.CMMCName oCMDMC = new MDAlarmHistory.CMMCName();
                oCMDMC.MCname = row["MachineName"].ToString();
                oMDAlarmHistory.ListOfMC.Add(oCMDMC);
            }
        }






        return oMDAlarmHistory;
    }

}