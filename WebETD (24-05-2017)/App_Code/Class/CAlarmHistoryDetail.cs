using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CMechaNGGraph
/// </summary>
public class CAlarmHistoryDetail
{
    ConnectDBIoTServerTonMecha oCon = new ConnectDBIoTServerTonMecha();
    ConnectDBODM oConODM = new ConnectDBODM();

    public MDAlarmHistoryDetail GetAlarmHistoryGraphDetail(string DateStart, string DateEnd, string MC, string Fac, string Shift)
    {
        MDAlarmHistoryDetail oMDAlarmHistoryDetail = new MDAlarmHistoryDetail();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        string STime = "";
        string ETime = "";
        DateTime SDate = DateTime.Parse(DateStart);
        DateTime EDate = DateTime.Parse(DateEnd);
        try
        {
        if (Shift == "All")
        {
            STime = "08:00";
            ETime = "08:00";

            DateStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            DateEnd = EDate.AddDays(1).ToString("yyyy-MM-dd") + " " + ETime;

        }
        else if (Shift == "D")
        {
            STime = "08:00";
            ETime = "20:00";

            DateStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            DateEnd = EDate.ToString("yyyy-MM-dd") + " " + ETime;
        }
        else if (Shift == "N")
        {
            STime = "20:00";
            ETime = "08:00";

            DateStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            DateEnd = EDate.ToString("yyyy-MM-dd") + " " + ETime;
        }


        
            if (Fac == "Fac3")
            {
                sql.CommandText = @"SELECT MC_No
		                    ,[MachineName]
		                    ,[AlarmNo]
		                    ,AlarmDetail
                          ,COUNT([AlarmDetail]) as Qty
	                      ,FORMAT(DATEADD(day,0,GETDATE()),'yyyy-MM-dd 08:00') as startDate
	                      ,FORMAT(DATEADD(day,1,GETDATE()),'yyyy-MM-dd 08:00') as endDate
                      FROM [MECHA_FAC3].[dbo].[vi_Alarm_MC_Detail]
                      where DateStart between @SDate and @EDate and [MachineName] = @MC
                      group by [MachineName],MC_No,[AlarmNo],AlarmDetail";
                sql.Parameters.Add(new SqlParameter("@SDate", DateStart));
                sql.Parameters.Add(new SqlParameter("@EDate", DateEnd));
                sql.Parameters.Add(new SqlParameter("@MC", MC));
                dTable = oCon.Query(sql);
            }
            else if (Fac == "ODM")
            {
                string sqlODM = "";
                sqlODM = @"SELECT [MC_Name] as MachineName
                                ,[AlarmNo]
                                ,[AlarmDetail]
	                            ,COUNT(AlarmNo) as Qty
                            FROM [dbIoTFacODM].[dbo].[vi_ODM_OD_Alarm]
                            where DateInsert between '" + DateStart + @"' and '" + DateEnd + @"' and MC_Name = '" + MC + @"'  
                            group by [Station_No],[AlarmNo],[AlarmDetail],[MC_Name],AlarmNo";
                dTable = oConODM.Query(sqlODM);

            }




            if (dTable.Rows.Count > 0)
            {
                foreach (DataRow row in dTable.Rows)
                {
                    MDAlarmHistoryDetail.CMDAlarmHistoryDetail oCMD = new MDAlarmHistoryDetail.CMDAlarmHistoryDetail();
                    oCMD.MCName = row["MachineName"].ToString();
                    oCMD.AlarmDetail = row["AlarmDetail"].ToString();
                    oCMD.Qty = int.Parse(row["Qty"].ToString());

                    oMDAlarmHistoryDetail.ListOfAlarm.Add(oCMD);
                }
            }


        }
        catch (Exception)
        {

        }

        return oMDAlarmHistoryDetail;
    }

}