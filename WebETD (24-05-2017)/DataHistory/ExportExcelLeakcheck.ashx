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
		
		context.Response.Charset = "windows-874";
        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding(874);
		//context.Response.Charset = "UTF-8";
        //context.Response.ContentEncoding = System.Text.Encoding.GetEncoding(874);
        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");

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
        if (Part == "1")
        {                        
            Name = "LEAKCHECK-OK (" + Start + ") to (" + End + ")";
            //getdt = meTba.getCSResultF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));
            
            DataTable dt1 = new DataTable();
            string Str1 = "SELECT  SerialNo, StampTime, ID, emp_ID, Name, Line "
                    + " FROM [" + Base + "].[dbo].[vi_Leak_Check] "
                    + " WHERE StampTime between '" + Start + "' and '" + End + "' and Line = '" + Line + "' "
                    + " ORDER BY  StampTime asc ";
            
            SqlCommand qr1 = new SqlCommand();
            qr1.CommandText = Str1;
            dt1 = con.Query(qr1, Con);

            getdt = dt1;
        }


        else if (Part == "2")
        {
            Name = "LEAKCHECK-REWORK (" + Start + ") to (" + End + ")";
            //getdt = meTba.getPTResultF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));

            DataTable dt2 = new DataTable();
            string Str2 = "SELECT  key_no, serial_no, line, point_leak, position_body, position_welds, ng_description, ng_category, insert_time, user_check "
                + " FROM [" + Base + "].[dbo].[vi_leak_rework] "
                + " WHERE insert_time between '" + Start + "' and '" + End + "' and line = '" + Line + "' "
                + " ORDER BY  insert_time asc ";

            SqlCommand qr2 = new SqlCommand();
            qr2.CommandText = Str2;
            dt2 = con.Query(qr2, Con);

            getdt = dt2;
        }                

        return getdt;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}