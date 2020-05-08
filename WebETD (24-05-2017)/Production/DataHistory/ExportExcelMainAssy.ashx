<%@ WebHandler Language="C#" Class="ExportExcelMainAssy" %>

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

public class ExportExcelMainAssy : IHttpHandler {
    
    
    
    public void ProcessRequest (HttpContext context) {

        string NG_ID = context.Request.QueryString["NG_ID"].ToString();
        
        DataTable dTable = new DataTable();
        dTable = GetData();
        
        string Name = "Data_" + DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") 
            + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");

        //string Part = context.Request.QueryString["Part"].ToString();
        //string ListType = context.Request.QueryString["ListType"].ToString();
        //string StartDate = context.Request.QueryString["StartDate"].ToString();
        //string EndDate = context.Request.QueryString["EndDate"].ToString();

        //String FilePath = @"C:\testfile.txt";
        //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        //response.ClearContent();
        //response.Clear();
        

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
        DataTable dTable = new DataTable();


        return dTable;
    }

    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}