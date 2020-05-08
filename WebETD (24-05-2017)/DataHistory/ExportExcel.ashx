<%@ WebHandler Language="C#" Class="ExportExcel" %>

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

public class ExportExcel : IHttpHandler {

    ViDataCSDetail csTba = new ViDataCSDetail();
    ViDataCYDetail cyTba = new ViDataCYDetail();
    ViDataPTDetail ptTba = new ViDataPTDetail();
    ViDataFHDetail fhTba = new ViDataFHDetail();
    ViDataRHDetail rhTba = new ViDataRHDetail();
    string Part;
    string Type;
    string Start;
    string End;
    string Con;
    string Line;
    string Name;
    
    public void ProcessRequest (HttpContext context) {
        
        Part = context.Request.QueryString["Part"].ToString();
        Type = context.Request.QueryString["Type"].ToString();
        Start = context.Request.QueryString["Start"].ToString();
        End = context.Request.QueryString["End"].ToString();
        Con = context.Request.QueryString["Con"].ToString();
        Line = context.Request.QueryString["Line"].ToString();
        
        DataTable dTable = new DataTable();
        dTable = GetData();
        
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
        DataTable getdt = new DataTable();

        if (Part == "1") //CS
        {
            switch (Type)
            {
                case "2"://front od
                    Name = "CS-FOD (" + Start + ") to (" + End + ")";
                    getdt = csTba.getDataFOD(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "3"://rear od
                    Name = "CS-ROD (" + Start + ") to (" + End + ")";
                    getdt = csTba.getDataROD(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;//pin od
                case "4":
                    Name = "CS-PIN (" + Start + ") to (" + End + ")";
                    getdt = csTba.getDataPinOD(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con, Line);
                    break;
                case "12"://ecc
                    Name = "CS-ECC (" + Start + ") to (" + End + ")";
                    getdt = csTba.getDataECC(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con, Line);
                    break;
                case "35"://all
                    Name = "CS-ALL (" + Start + ") to (" + End + ")";
                    getdt = csTba.getAllDataCS(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con, Line);
                    break;
            }
        }


        else if (Part == "2")//PT
        {
            switch (Type)
            {
                case "1"://od
                    Name = "PT-OD (" + Start + ") to (" + End +")";
                    getdt = ptTba.getDataOD(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "5"://id
                    Name = "PT-ID (" + Start + ") to (" + End + ")";
                    getdt = ptTba.getDataID(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;//height
                case "10":
                    Name = "PT-HEI (" + Start + ") to (" + End + ")";
                    getdt = ptTba.getDataHeight(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "15"://blade
                    Name = "PT-BL (" + Start + ") to (" + End + ")";
                    getdt = ptTba.getDataBlade(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "35"://all
                    Name = "PT-ALL (" + Start + ") to (" + End + ")";
                    getdt = ptTba.getAllDataPT(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;

            }
        }
        else if (Part == "3")//CY
        {
            switch (Type)
            {
                case "8"://idbore
                    Name = "CY-BORE (" + Start + ") to (" + End + ")";
                    getdt = cyTba.getDataIDBore(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "9"://idbush
                    Name = "CY-BUSH (" + Start + ") to (" + End + ")";
                    getdt = cyTba.getDataIDBush(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;//height
                case "10":
                    Name = "CY-HEI (" + Start + ") to (" + End + ")";
                    getdt = cyTba.getDataHeight(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "35"://all
                    Name = "CY-ALL (" + Start + ") to (" + End + ")";
                    getdt = cyTba.getAllDataCY(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
            }
        }
        else if (Part == "4")//FH
        {
            switch (Type)
            {
                case "5"://id
                    Name = "FH-ID (" + Start + ") to (" + End + ")";
                    getdt = fhTba.getDataID(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con, Line);
                    break;
                case "51"://id rough

                    break;//height
                case "35"://all
                    Name = "FH-ALL (" + Start + ") to (" + End + ")";
                    getdt = fhTba.getAllDataFH(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con, Line);
                    break;
                case "55": //fl
                    Name = "FH-FL (" + Start + ") to (" + End + ")";
                    getdt = fhTba.getDataFL(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
            }
        }
        else if (Part == "5")//RH
        {
            switch (Type)
            {
                case "5"://id
                    Name = "RH-ID (" + Start + ") to (" + End + ")";
                    getdt = rhTba.getDataID(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "35"://all
                    Name = "RH-ALL (" + Start + ") to (" + End + ")";
                    getdt = rhTba.getAllDataRH(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
                case "55": //fl
                    Name = "RH-FL (" + Start + ") to (" + End + ")";
                    getdt = rhTba.getDataFL(Convert.ToDateTime(Start), Convert.ToDateTime(End), Con);
                    break;
            }
        }
        
        
        
        return getdt;
    }

    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}