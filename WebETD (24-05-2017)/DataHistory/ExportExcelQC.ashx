<%@ WebHandler Language="C#" Class="ExportExcelLeakcheck" %>

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using OfficeExcel = Microsoft.Office.Interop.Excel;


public class ExportExcelLeakcheck : IHttpHandler
{

    F3MechaService meTba = new F3MechaService();
    ConnectDBETD con = new ConnectDBETD();

    string Part;
    string Start;
    string End;
    string Con;
    string Name;
    string Base;
    string Line;

    public void ProcessRequest(HttpContext context)
    {

        Part = context.Request.QueryString["Part"].ToString();
        Start = context.Request.QueryString["Start"].ToString();
        End = context.Request.QueryString["End"].ToString();
        Con = context.Request.QueryString["Con"].ToString();
        Base = context.Request.QueryString["Base"].ToString();
        Line = context.Request.QueryString["Line"].ToString();

        DataTable dTable = new DataTable();
        dTable = GetData();

        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=QCDataTemp.csv;");

        StringBuilder sb = new StringBuilder();

        string[] columnNames = dTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
        sb.AppendLine(string.Join(",", columnNames));

        foreach (DataRow row in dTable.Rows)
        {
            string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
            sb.AppendLine(string.Join(",", fields));
        }

        //context.Response.Write(sb.ToString());

        //the most easy way as you have type it
        context.Response.Write(sb.ToString());
        context.Response.Flush();
        context.Response.End();

    }

    private DataTable GetData()
    {
        DataTable getdt = new DataTable();
        DataTable dt1 = new DataTable();
        string Str1 = "SELECT [StampTime],[ID],[Temp],[Hum] FROM [dbIoTFac2].[dbo].[etd_TEMP_HUM_QC] WHERE StampTime between '" + Start + "' and '" + End + "' ORDER BY  StampTime asc ";
        //SELECT [StampTime],[ID],[Temp],[Hum] FROM [dbIoTFac2].[dbo].[etd_TEMP_HUM_QC] WHERE StampTime between '" + Start + "' and '" + End + "' ORDER BY  StampTime asc 

        SqlCommand qr1 = new SqlCommand();
        qr1.CommandText = Str1;
        dt1 = con.Query(qr1, Con);

        getdt = dt1;
       

        return getdt;
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}