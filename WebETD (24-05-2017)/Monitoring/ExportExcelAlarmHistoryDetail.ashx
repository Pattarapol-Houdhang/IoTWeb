<%@ WebHandler Language="C#" Class="ExportExcelAlarmHistoryDetail" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelAlarmHistoryDetail : IHttpHandler
{
    //CHistoryData oHis = new CHistoryData();
    ConnectDBIoTServerTonMecha oCon = new ConnectDBIoTServerTonMecha();
    ConnectDBODM oConODM = new ConnectDBODM();
    string DateStart = "";
    string DateEnd = "";
    string Name = "";
    string listMC = "";
    string Fac = "";
    string Shift = "";
    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        DateStart = context.Request.QueryString["DateStart"].ToString();
        DateEnd = context.Request.QueryString["DateEnd"].ToString();
        listMC = context.Request.QueryString["listMC"].Replace('(', ' ').Replace('%', '&');
        Fac = context.Request.QueryString["Fac"].ToString();
        //DataTable dTable = new DataTable();

        DataTable dTable = new DataTable();
        ////// Get Data
        string sql = "";
        string sqlODM = "";
        
        if (Fac == "Fac3")
        {
            sql = @"SELECT ALS.MachineName,AlarmDetail,DateStart
                              FROM [MECHA_FAC3].[dbo].[vi_Alarm_MC_Detail] MCD
                              left join [MECHA_FAC3].[dbo].[AlarmLineSetting] ALS on MCD.MC_No = ALS.ID
                              WHERE DateStart between '" + DateStart + @"' and '" + DateEnd + @"' and ALS.MachineName = '" + listMC + @"'
                              ORDER BY DateStart desc";
            dTable = oCon.Query(sql);
        }
        else if (Fac == "ODM")
        {
            sqlODM = @"SELECT [MC_Name] as MachineName
                                ,[AlarmDetail]
                                ,[DateInsert]
                            FROM [dbIoTFacODM].[dbo].[vi_ODM_OD_Alarm]
                            where DateInsert between '" + DateStart + @"' and '" + DateEnd + @"' and MC_Name = '" + listMC + @"' order by DateInsert desc";
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

                    Detail += data.ToString().Replace(',', '/') + ",";

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