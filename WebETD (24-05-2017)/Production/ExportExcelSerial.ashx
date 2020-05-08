<%@ WebHandler Language="C#" Class="ExportExcelSerial" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelSerial : IHttpHandler
{
    string Date = "";
    string Line = "";
    string Shift = "";
    string Name = "";
    string Btn = "";
    CpalletToSerial CpalletToSerial = new CpalletToSerial();
    ConnectDB oCon = new ConnectDB();
    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();



        ////// Get Data
        DataTable dTable = new DataTable();
        try
        {
            string sql = @"SELECT *
                        FROM [dbIoT].[dbo].[tmpCheckSerial_PLNO]";
            dTable = oCon.Query(sql);
            ////////
        }
        catch (Exception)
        {

        }

        /////

        Name = "SerialAlpha" + DateTime.Now.Year.ToString()
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

                    Detail +=  "'"+data + ",";

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