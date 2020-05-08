<%@ WebHandler Language="C#" Class="ExportExcelDataHistoryMain" %>

using System;
using System.Web;
using System.Text;
using System.Data;


public class ExportExcelDataHistoryMain : IHttpHandler
{
    CHistoryData oHis = new CHistoryData();
    string TableName = "";
    string dtStart = "";
    string dtEnd = "";
    string Model = "";
    string Name = "";

    public void ProcessRequest(HttpContext context)
    {
        TableName = context.Request.QueryString["TableName"].ToString();
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        DataTable dTable = new DataTable();

        dTable = oHis.GetDataMESIoTServer(TableName, dtStart, dtEnd, Model);
        Name = "DataHistory_" + DateTime.Now.Year.ToString()
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
                    Detail += "'" + data + ",";
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