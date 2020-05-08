<%@ WebHandler Language="C#" Class="ExportExcelAlarmHistoryDetailG" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelAlarmHistoryDetailG : IHttpHandler
{
    //CHistoryData oHis = new CHistoryData();
    ConnectDBIoTServerTonMecha oCon = new ConnectDBIoTServerTonMecha();
    ConnectDBODM oConODM = new ConnectDBODM();
    string DateStart = "";
    string DateEnd = "";
    string Name = "";
    string listMC = "";
    string Fac = "";
    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        DateStart = context.Request.QueryString["DateStart"].ToString();
        DateEnd = context.Request.QueryString["DateEnd"].ToString();
        listMC = context.Request.QueryString["listMC"].ToString().ToString().Replace('(', ' ');
        Fac = context.Request.QueryString["Fac"].ToString();
        //DataTable dTable = new DataTable();
        if (listMC == "''")
        {
            listMC = "";
        }
        if (listMC != "" && !listMC.Contains("All"))
        {
            listMC = " in ('" + listMC.Replace('%', '&') + "') ";
        }
        else
        {
            listMC = " not in ('') ";
        }

        DataTable dTable = new DataTable();
        if (Fac == "Fac3")
        {
            ////// Get Data
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"SELECT MC_No
		                    ,[MachineName]
		                    ,[AlarmNo]
		                    ,AlarmDetail
                          ,COUNT([AlarmDetail]) as Qty
	                      ,'" +DateStart+@"' as startDate
	                      ,'"+DateEnd+@"' as endDate
                      FROM [MECHA_FAC3].[dbo].[vi_Alarm_MC_Detail]
                      where DateStart between '" + DateStart + @"' and '" + DateEnd + @"' and [MachineName] " + listMC + @"
                      group by [MachineName],MC_No,[AlarmNo],AlarmDetail";
            dTable = oCon.Query(sql);
        }
        else if (Fac== "ODM")
        {
            string sqlODM = "";
            sqlODM = @"SELECT [MC_Name] as MachineName
                                ,[AlarmNo]
                                ,[AlarmDetail]
	                            ,COUNT(AlarmNo) as Qty
                            FROM [dbIoTFacODM].[dbo].[vi_ODM_OD_Alarm]
                            where DateInsert between '" + DateStart + @"' and '" + DateEnd + @"' and MC_Name " + listMC + @" 
                            group by [Station_No],[AlarmNo],[AlarmDetail],[MC_Name],AlarmNo";
            dTable = oConODM.Query(sqlODM);
        }
        
        if (dTable.Rows.Count <= 0)
        {
            return;
        }


        /////

        Name = "IoTData_" + "AlarmDetail"  + DateTime.Now.Year.ToString()
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

                    Detail += data.ToString().Replace(',','/') + ",";

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