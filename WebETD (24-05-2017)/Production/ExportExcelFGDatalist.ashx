<%@ WebHandler Language="C#" Class="ExportExcelFGDatalist" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelFGDatalist : IHttpHandler
{
    string Date = "";
    string Line = "";
    string Shift = "";
    string Name = "";
    string Btn = "";
    CFGDataList cFGlist = new CFGDataList();
    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        Date = context.Request.QueryString["Date"].ToString();
        Line = context.Request.QueryString["Line"].ToString();
        Shift = context.Request.QueryString["Shift"].ToString();
        Btn = context.Request.QueryString["Btn"].ToString();



        ////// Get Data
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        try
        {
            //////////
            if (Shift == "D")
            {
                Shift = "08:00,20:00,D";
            }
            else if (Shift == "N")
            {
                Shift = "20:00,08:00,N";
            }
            else
            {
                Shift = "08:00,08:00,A";
            }
            if (Btn == "A")
            {
                dTable = cFGlist.ExportDataFG(Date, Line, Shift);

            }
            else if(Btn == "B")
            {
                dTable = cFGlist.ExportDataRelabel(Date, Line, Shift);
            }
            else if (Btn == "C")
            {
                dTable = cFGlist.ExportDataRework(Date, Line, Shift);
            }
            else if (Btn == "D")
            {
                dTable = cFGlist.ExportDataAlpha("PDT", Line);
            }
            else if (Btn == "E")
            {
                dTable = cFGlist.ExportDataAlpha("UWH", Line);
            }
            else if (Btn == "F")
            {
                dTable = cFGlist.ExportDataAlpha("RWD", Line);
            }
            else if (Btn == "G")
            {
                dTable = cFGlist.ExportDataAlpha("RWE", Line);
            }
            else if (Btn == "H")
            {
                dTable = cFGlist.ExportDataAlpha("RWQ", Line);
            }
            else if (Btn == "I")
            {
                dTable = cFGlist.ExportDataFGC(Date, Line, Shift);
            }
            else if (Btn == "J")
            {
                dTable = cFGlist.ExportDataRelabelC(Date, Line, Shift);
            }
            else if (Btn == "K")
            {
                dTable = cFGlist.ExportDataReworkC(Date, Line, Shift);
            }
            ////////
        }
        catch (Exception)
        {

        }

        /////

        Name = "FGlist" + DateTime.Now.Year.ToString()
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