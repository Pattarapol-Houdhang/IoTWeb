﻿<%@ WebHandler Language="C#" Class="ExportExcelAlarmHistoryDetail" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelAlarmHistoryDetail : IHttpHandler
{
    //CHistoryData oHis = new CHistoryData();
    ConnectDBDCI oConnDCI = new ConnectDBDCI();
    ConnectDBFac3 oConnFac3 = new ConnectDBFac3();
    ConnectDBIoTServerTonMecha oConnMecha = new ConnectDBIoTServerTonMecha();

    string dtStart = "";
    string dtEnd = "";
    string LineName = "";
    string Machine = "";

    string Name = "";

    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        LineName = context.Request.QueryString["Line"].ToString();
        Machine = context.Request.QueryString["Machine"].ToString();

        //DataTable dTable = new DataTable();

        //dTable = oHis.GetDataMESIoTServer(TableName, dtStart, dtEnd, Model);
        if (LineName != "")
        {
            SqlCommand sql = new SqlCommand();
            DataTable dTable = new DataTable();
            dTable.TableName = "Alarm";
            sql.CommandText = "SELECT MCName,Convert(nvarchar,StartAlarm,120) as StartAlarm,Convert(nvarchar,EndAlarm,120) as EndAlarm,DATEDIFF(second,StartAlarm,EndAlarm) as TotalSecond FROM LogAlarmMCDetail lam";
            sql.CommandText += " INNER JOIN AlarmLineSetting als ON lam.MCName=als.MachineName";
            sql.CommandText += " where als.LineName = @LineName";
            sql.CommandText += " and lam.StartAlarm >= @DateStart";
            sql.CommandText += " and lam.EndAlarm <= @DateEnd";
            
            if (Machine != "")
            {
                sql.CommandText += " and lam.MCName=@MCName";
            }
            sql.Parameters.Add(new SqlParameter("@DateStart", dtStart));
            sql.Parameters.Add(new SqlParameter("@DateEnd", dtEnd));
            sql.Parameters.Add(new SqlParameter("@LineName", LineName));
            sql.Parameters.Add(new SqlParameter("@MCName", Machine));
            dTable = oConnMecha.Query(sql);

            Name = "DataAlarmHistoryDetail_" + DateTime.Now.Year.ToString()
                + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;

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
                for (int i = 0; i < dTable.Rows.Count - 1; i++)
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

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }




}