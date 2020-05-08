using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CGetAlarmDetail
/// </summary>
public class CGetAlarmDetail
{
    ConnectDBFac3 oConn = new ConnectDBFac3();
    CultureInfo cu = new CultureInfo("en-US");

    public CGetAlarmDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<MAlarmInfo> GetDataAlarmHead (string ProcessName, DateTime dateSeach,string McCode)
    {
        List<MAlarmInfo> oList = new List<MAlarmInfo>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT COUNT(Alarm_No) AS NumberAlarm, [Mc_Name] ,[Alarm_Detail] ,[Mc_No] ,[Alarm_No] FROM [vi_Scada_Alarm_Detail] WHERE Mc_No = '" + McCode + "'"+
            " AND Alarm_Date >= '"+dateSeach.ToString("yyyy-MM-dd HH:mm:ss",cu)+"'"+
            " GROUP BY[Mc_Name],[Alarm_Detail],[Mc_No],[Alarm_No]";
        DataTable dt = ConnectDBFac3Costy(sql);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow _row in dt.Rows)
            {
                MAlarmInfo _item = new MAlarmInfo();
                _item.AlarmCount = Convert.ToInt16(_row["NumberAlarm"].ToString());
                _item.AlarmId = _row["Alarm_No"].ToString();
                _item.AlarmName = _row["Alarm_Detail"].ToString();
                oList.Add(_item);
            }
        }
        return oList;
    }

    public DataTable ConnectDBFac3Costy(SqlCommand sql)
    {
        DataTable dt = new DataTable();
        SqlConnection conn = new SqlConnection("Data Source=costy;Initial Catalog=dbIoTFac3;Persist Security Info=True;User ID=sa;Password=decjapan;");
        sql.Connection = conn;
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "table0");
            dt = ds.Tables["table0"];
        }
        catch { }

        return dt;
    }
}