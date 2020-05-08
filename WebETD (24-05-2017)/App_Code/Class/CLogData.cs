using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CLogData
/// </summary>
public class CLogData
{
    ConnectDB oConn = new ConnectDB();
    CGenerateRunningNumber oGenRunning = new CGenerateRunningNumber();
    public string InsertLog(string Action, string PageUrl)
    {
        string username = "";
        if (HttpContext.Current.Session["UserLoginData"] != null)
        {
            MDUserLoginData oUser = new MDUserLoginData();
            oUser = (MDUserLoginData)HttpContext.Current.Session["UserLoginData"];
            if (oUser.ListOfUser.Count > 0)
            {
                username = oUser.ListOfUser[0].Username;
            }
        }
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "INSERT INTO LogData(LogID,username,Action,PageUrl,LogDate) OUTPUT Inserted.LogID VALUES(";
        sql.CommandText += "@LogID,@username,@Action,@PageUrl,@LogDate)";
        sql.Parameters.Add(new SqlParameter("@LogID", oGenRunning.GetRunningNumber_FormatWithDate(CGeneral.TypeConfig.Log)));
        sql.Parameters.Add(new SqlParameter("@username", username));
        sql.Parameters.Add(new SqlParameter("@Action", Action));
        sql.Parameters.Add(new SqlParameter("@PageUrl", PageUrl));
        sql.Parameters.Add(new SqlParameter("@LogDate", DateTime.Now));
        dTable = oConn.Query(sql);

        if (dTable.Rows.Count > 0)
        {
            return dTable.Rows[0][0].ToString();
        }

        return "";
    }

    public MDLogData GetLogData(string inSearch, string LogDate)
    {
        inSearch = "%" + inSearch + "%";
        MDLogData oMDLog = new MDLogData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT TOP 200 LogID,username,ComputerName,IPAddress,Action,PageUrl,LogDate FROM LogData";
        sql.CommandText += " WHERE ISNULL(LogID,'')+ISNULL(username,'')+ISNULL(ComputerName,'')+ISNULL(IPAddress,'')+ISNULL(PageUrl,'')+ISNULL(Action,'') like @inSearch";
        if (LogDate != "")
        {
            sql.CommandText += " AND Convert(date,LogDate)=@LogDate";
            sql.Parameters.Add(new SqlParameter("@LogDate", LogDate));
        }
        sql.CommandText += " ORDER BY LogDate DESC";
        sql.Parameters.Add(new SqlParameter("@inSearch", inSearch));
       
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDLogData.CMDLogData oMD = new MDLogData.CMDLogData();
                oMD.LogID = row["LogID"].ToString();
                oMD.username = row["username"].ToString();
                oMD.ComputerName = row["ComputerName"].ToString();
                oMD.IPAddress = row["IPAddress"].ToString();
                oMD.Action = row["Action"].ToString();
                oMD.PageUrl = row["PageUrl"].ToString();
                oMD.LogDate = row["LogDate"].ToString();
                oMDLog.ListOfLog.Add(oMD);
            }
        }

        return oMDLog;
    }

    public MDLogData GetLogDataByLogID(string LogID)
    {
        
        MDLogData oMDLog = new MDLogData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT LogID,username,ComputerName,IPAddress,Action,PageUrl,LogDate FROM LogData";
        sql.CommandText += " WHERE LogID=@LogID";
        sql.Parameters.Add(new SqlParameter("@LogID", LogID));

        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDLogData.CMDLogData oMD = new MDLogData.CMDLogData();
                oMD.LogID = row["LogID"].ToString();
                oMD.username = row["username"].ToString();
                oMD.ComputerName = row["ComputerName"].ToString();
                oMD.IPAddress = row["IPAddress"].ToString();
                oMD.Action = row["Action"].ToString();
                oMD.PageUrl = row["PageUrl"].ToString();
                oMD.LogDate = row["LogDate"].ToString();
                oMDLog.ListOfLog.Add(oMD);
            }
        }

        return oMDLog;
    }

}
