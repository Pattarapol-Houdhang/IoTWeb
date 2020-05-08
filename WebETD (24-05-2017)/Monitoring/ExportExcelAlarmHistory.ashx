<%@ WebHandler Language="C#" Class="ExportExcelAlarmHistory" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelAlarmHistory : IHttpHandler
{
    //CHistoryData oHis = new CHistoryData();
    ConnectDBIoTServerTonMecha oCon = new ConnectDBIoTServerTonMecha();
    ConnectDBODM oConODM = new ConnectDBODM();
    string DateStart = "";
    string DateEnd = "";
    string Name = "";
    string Shift = "";
    string Range = "";
    string Volume = "";
    string listMC = "";
    string fac = "";
    string LineODM = "";
    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        DateStart = context.Request.QueryString["DateStart"].ToString();
        DateEnd = context.Request.QueryString["DateEnd"].ToString();
        Shift = context.Request.QueryString["Shift"].ToString();
        Range = context.Request.QueryString["Range"].ToString();
        Volume = context.Request.QueryString["Volume"].ToString();
        listMC = context.Request.QueryString["listMC"].ToString().Replace('(', ' ');
        fac = context.Request.QueryString["Fac"].ToString();
        LineODM = context.Request.QueryString["LineODM"].ToString();
        //DataTable dTable = new DataTable();


        string _listMC = "";

        DataTable dTable = new DataTable();
        DataTable dTable1;
        DataTable dTable2;
        ////// Get Data
        SqlCommand sql = new SqlCommand();
        try
        {
            if (listMC == "''")
            {
                listMC = "";
            }
            if (listMC != "" && !listMC.Contains("All"))
            {
                _listMC = "in (" + listMC.Replace('%', '&') + ")";
            }
            else
            {
                _listMC = "not in ('')";
            }
            if (fac == "Fac3")
            {


                int _Volume = int.Parse(Volume);
                if (Range == "D")
                {
                    if (Shift == "All")
                    {
                        sql.CommandText = @"SELECT  [MCName],[StampDate],Sum([CountAlarm]) as Qty
                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                  where [StampDate] between @DateStart and @DateEnd  and [MCName] " + _listMC + @"
                                  group by MCName,StampDate
                                  order by StampDate ";
                        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
                        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                    }
                    else
                    {
                        sql.CommandText = @"SELECT  [MCName],[StampDate],[Shift],Sum([CountAlarm]) as Qty
                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                  where [StampDate] between @DateStart and @DateEnd and Shift = @Shift and [MCName] " + _listMC + @"
                                  group by MCName,StampDate,[Shift]
                                  order by StampDate ";
                        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
                        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                        sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                    }
                    dTable = oCon.Query(sql);
                }
                else if (Range == "W")
                {
                    if (Shift == "All")
                    {
                        for (int i = 0; i <= _Volume - 1; i++)
                        {
                            if (i == 0)
                            {
                                dTable1 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD(week, 0, GETDATE()) as StampDate
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between DATEADD(week, -1, FORMAT(GETDATE(), 'yyyy-MM-dd')) and DATEADD(week, 0,@DateEnd)
                                                  and [MCName] " + _listMC + @"
                                                  group by MCName";
                                sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
                                sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                                sql.Parameters.Add(new SqlParameter("@i", i));
                                dTable1 = oCon.Query(sql);
                                dTable.Merge(dTable1);
                            }
                            else
                            {
                                dTable2 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD( week, @i, GETDATE()) as StampDate
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between DATEADD(week, @j, FORMAT(getdate(), 'yyyy-MM-dd')) and DATEADD(week, @i, GETDATE()) 
                                                  and [MCName] " + _listMC + @"
                                                  group by MCName";
                                sql.Parameters.Add(new SqlParameter("@i", 0 - i));
                                sql.Parameters.Add(new SqlParameter("@j", 0 - i - 1));
                                dTable2 = oCon.Query(sql);
                                dTable.Merge(dTable2);
                            }

                        }

                    }
                    else
                    {
                        for (int i = 0; i <= _Volume - 1; i++)
                        {
                            if (i == 0)
                            {
                                dTable1 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD(week, 0, GETDATE()) as StampDate,[Shift]
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between DATEADD(week, -1, FORMAT(GETDATE(), 'yyyy-MM-dd')) and DATEADD(week, 0,@DateEnd) 
                                                        and Shift = @Shift and [MCName] " + _listMC + @"
                                                  group by MCName,[Shift]";
                                sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable1 = oCon.Query(sql);
                                dTable.Merge(dTable1);
                            }
                            else
                            {
                                dTable2 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,DATEADD( week, @i, GETDATE()) as StampDate,[Shift]
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between DATEADD(week, @j, FORMAT(getdate(), 'yyyy-MM-dd')) and DATEADD(week, @i, GETDATE()) 
                                                        and Shift = @Shift and [MCName] " + _listMC + @"
                                                  group by MCName,[Shift]";
                                sql.Parameters.Add(new SqlParameter("@i", 0 - i));
                                sql.Parameters.Add(new SqlParameter("@j", 0 - i - 1));
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable2 = oCon.Query(sql);
                                dTable.Merge(dTable2);
                            }

                        }
                    }
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
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(GETDATE(), 'yyyy-MM') as StampDate
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between FORMAT(GETDATE(), 'yyyy-MM-01') and GETDATE()
                                                  and [MCName] " + _listMC + @"
                                                  group by MCName";
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable1 = oCon.Query(sql);
                                dTable.Merge(dTable1);
                            }
                            else
                            {
                                dTable2 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(DATEADD(month, @i,GETDATE()), 'yyyy-MM') as StampDate
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between DATEADD(month, @i, FORMAT(GETDATE(), 'yyyy-MM-01')) and EOMONTH(DATEADD(month, @i,FORMAT(GETDATE(), 'yyyy-MMM')))
                                                  and [MCName] " + _listMC + @"
                                                  group by MCName";
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
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(GETDATE(), 'yyyy-MM') as StampDate
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between FORMAT(GETDATE(), 'yyyy-MM-01') and @DateEnd
                                                        and Shift = @Shift and [MCName] " + _listMC + @"
                                                  group by MCName";
                                sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
                                sql.Parameters.Add(new SqlParameter("@Shift", Shift));
                                dTable1 = oCon.Query(sql);
                                dTable.Merge(dTable1);
                            }
                            else
                            {
                                dTable2 = new DataTable();
                                sql = new SqlCommand();
                                sql.CommandText = @"SELECT  [MCName],Sum([CountAlarm]) as Qty,FORMAT(DATEADD(month, @i,GETDATE()), 'yyyy-MM') as StampDate
                                                  FROM [MECHA_FAC3].[dbo].[LogAlarmMC] 
                                                  where [StampDate] between DATEADD(month, @i, FORMAT(GETDATE(), 'yyyy-MM-01')) and EOMONTH(DATEADD(month, @i,FORMAT(GETDATE(), 'yyyy-MMM'))) 
                                                        and Shift = @Shift and [MCName] " + _listMC + @"
                                                  group by MCName";
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


            }
            else if (fac == "ODM")
            {
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
                    sqlStr = @"SELECT AM.[MC_Name] AS MCName,am.Network_No+AM.Station_No+AM.Location_No as Stations,SUM(convert(int,Times)) as Qty,FORMAT (InsertDate, 'yyyy-MM-dd') as StampDate FROM [dbIoTFacODM].[dbo].[odm_od_AlarmPerDay] AD
                                    left join odm_od_Alarm_mst AM on am.Network_No=ad.Network_No 
                                    and AM.Station_No = AD.Station_No and AM.Location_No = AD.Location_No and AM.Line_No = AD.Line_No
                                    where [InsertDate] between '" + SDate.ToString("yyyy-MM-dd") + "' and '" + EDate.AddDays(-1).ToString("yyyy-MM-dd") + "'  and AD." + LineODM + @" and am.Network_No+AM.Station_No+AM.Location_No " + _listMC +
                            @"group by AM.[MC_Name],[InsertDate],am.Network_No,AM.Station_No,AM.Location_No,AM.Line_No order by InsertDate";
                    dTableFor = oConODM.Query(sqlStr);
                    dTable.Merge(dTableFor);

                    //***********************************************************************************
                    //*                             selete Edate                                                
                    //***********************************************************************************
                    sqlStr = @"SELECT am.MC_Name AS MCName,am.[Network_No]+AM.[Station_No]+AM.[Location_No] as Stations,count([AlarmNo]) as Qty,'" + EDate.ToString("yyyy-MM-dd") + @"' as StampDate
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
                    //***********************************************************************************
                    //*                          selete  Date Sdate to Edate-1                                
                    //***********************************************************************************
                    sqlStr = @"SELECT AM.[MC_Name] AS MCName,am.Network_No+AM.Station_No+AM.Location_No as Stations,CONVERT(int,Times) as Qty,FORMAT (InsertDate, 'yyyy-MM-dd') as StampDate FROM [dbIoTFacODM].[dbo].[odm_od_AlarmPerDay] AD
                                    left join odm_od_Alarm_mst AM on am.Network_No=ad.Network_No 
                                    and AM.Station_No = AD.Station_No and AM.Location_No = AD.Location_No and AM.Line_No = AD.Line_No
                                    where [InsertDate] between '" + SDate.ToString("yyyy-MM-dd") + "' and '" + EDate.AddDays(-1).ToString("yyyy-MM-dd") + "'  and AD." + LineODM + @" and am.Network_No+AM.Station_No+AM.Location_No " + _listMC +
                            @" and AD.Shift = '" + Shift + "' order by InsertDate";
                    dTableFor = oConODM.Query(sqlStr);
                    dTable.Merge(dTableFor);

                    //***********************************************************************************
                    //*                             selete Edate                                                
                    //***********************************************************************************
                    if (Shift == "D")
                    {
                        sqlStr = @"SELECT am.MC_Name AS MCName,am.[Network_No]+AM.[Station_No]+AM.[Location_No] as Stations,count([AlarmNo]) as Qty,'" + EDate.ToString("yyyy-MM-dd") + @"' as StampDate
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

                }




            }
            if (dTable.Rows.Count <= 0)
            {
                
                return;
            }
            DataRow[] rows;
            rows = dTable.Select("MCName='SUM'");
            foreach (DataRow row in rows)
                dTable.Rows.Remove(row);
        }
        catch (Exception)
        {

        }

        /////

        Name = "IoTData_" + "AlarmHistory_"  + DateTime.Now.Year.ToString()
                + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00")
                + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00")
                ;


        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");

        StringBuilder sb = new StringBuilder();
        // Set Header
        string Header = "";
        if (dTable.Rows.Count > 0)
        {
            foreach (DataColumn column in dTable.Columns)
            {
                Header += column.ColumnName + ",";
            }
        }
        sb.AppendLine(Header);


        if (dTable.Rows.Count > 0)
        {
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                string Detail = "";

                foreach (object data in dTable.Rows[i].ItemArray)
                {

                    Detail += data + ",";

                }
                sb.AppendLine(Detail);
            }
        }

        //context.Response.Write(sb.ToString());

        //the most easy way as you have type it
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