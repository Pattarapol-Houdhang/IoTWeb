using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CMachine
/// </summary>
public class CMachine
{
    ConnectDB oConn = new ConnectDB();
    public MDMachine GetMachine(string inSearch)
    {
        inSearch = "%" + inSearch + "%";
        MDMachine oMDMachine = new MDMachine();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT mc_id,mc_code,mc_name,mc_process,mc.ld_id,ld_linename,FactoryName,mc_updateby,mc_updatedate FROM machine mc";
        sql.CommandText += " LEFT JOIN LineData ld ON mc.ld_id=ld.ld_id";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID=fac.FactoryID";
        sql.CommandText += " WHERE ISNULL(mc_code,'')+ISNULL(mc_name,'') like @InSearch";
        sql.Parameters.Add(new SqlParameter("@InSearch", inSearch));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMachine.CMDMachine oMD = new MDMachine.CMDMachine();
                oMD.mc_id = row["mc_id"] != DBNull.Value ? Convert.ToInt32(row["mc_id"]) : 0;
                oMD.mc_code = row["mc_code"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMD.mc_process = row["mc_process"].ToString();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryName = row["FactoryName"].ToString();
                oMD.mc_updateby = row["mc_updateby"].ToString();
                oMD.mc_updatedate = row["mc_updatedate"].ToString();
                oMDMachine.ListOfmachine.Add(oMD);
            }
        }
        return oMDMachine;
    }

    public MDMachine GetMachineBymc_id(int mc_id)
    {
        MDMachine oMDMachine = new MDMachine();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT mc_id,mc_code,mc_name,mc_process,mc.ld_id,ld_linename,FactoryName,mc_updateby,mc_updatedate FROM machine mc";
        sql.CommandText += " LEFT JOIN LineData ld ON mc.ld_id=ld.ld_id";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID=fac.FactoryID";
        sql.CommandText += " WHERE mc_id=@mc_id";
        sql.Parameters.Add(new SqlParameter("@mc_id", mc_id));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMachine.CMDMachine oMD = new MDMachine.CMDMachine();
                oMD.mc_id = row["mc_id"] != DBNull.Value ? Convert.ToInt32(row["mc_id"]) : 0;
                oMD.mc_code = row["mc_code"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMD.mc_process = row["mc_process"].ToString();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryName = row["FactoryName"].ToString();
                oMD.mc_updateby = row["mc_updateby"].ToString();
                oMD.mc_updatedate = row["mc_updatedate"].ToString();
                oMDMachine.ListOfmachine.Add(oMD);
            }
        }
        return oMDMachine;
    }


    public MDMachine GetMachineBymc_code(string mc_code)
    {
        MDMachine oMDMachine = new MDMachine();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT mc_id,mc_code,mc_name,mc_process,mc.ld_id,ld_linename,FactoryName,mc_updateby,mc_updatedate FROM machine mc";
        sql.CommandText += " LEFT JOIN LineData ld ON mc.ld_id=ld.ld_id";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID=fac.FactoryID";
        sql.CommandText += " WHERE mc_code=@mc_code";
        sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMachine.CMDMachine oMD = new MDMachine.CMDMachine();
                oMD.mc_id = row["mc_id"] != DBNull.Value ? Convert.ToInt32(row["mc_id"]) : 0;
                oMD.mc_code = row["mc_code"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMD.mc_process = row["mc_process"].ToString();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryName = row["FactoryName"].ToString();
                oMD.mc_updateby = row["mc_updateby"].ToString();
                oMD.mc_updatedate = row["mc_updatedate"].ToString();
                oMDMachine.ListOfmachine.Add(oMD);
            }
        }
        return oMDMachine;
    }

    public void InsertMachine(string mc_code, string mc_name, string mc_process, int ld_id, string updateby)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "INSERT INTO machine(mc_code,mc_name,mc_process,ld_id,mc_createby,mc_createdate,mc_updateby,mc_updatedate) VALUES(";
            sql.CommandText += "@mc_code,@mc_name,@mc_process,@ld_id,@mc_createby,@mc_createdate,@mc_updateby,@mc_udpatedate)";
            sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
            sql.Parameters.Add(new SqlParameter("@mc_name", mc_name));
            sql.Parameters.Add(new SqlParameter("@mc_process", mc_process));
            sql.Parameters.Add(new SqlParameter("@ld_id", ld_id));
            sql.Parameters.Add(new SqlParameter("@mc_createby", updateby));
            sql.Parameters.Add(new SqlParameter("@mc_createdate", DateTime.Now));
            sql.Parameters.Add(new SqlParameter("@mc_updateby", updateby));
            sql.Parameters.Add(new SqlParameter("@mc_udpatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch
        {

        }
    }

    public void UpdateMachine(int mc_id, string mc_code, string mc_name, string mc_process, int ld_id, string updateby)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "UPDATE machine SET mc_code=@mc_code,mc_name=@mc_name,mc_process=@mc_process,ld_id=@ld_id";
            sql.CommandText += ",mc_updateby=@mc_updateby,mc_updatedate=@mc_updatedate WHERE mc_id=@mc_id";
            sql.Parameters.Add(new SqlParameter("@mc_id", mc_id));
            sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
            sql.Parameters.Add(new SqlParameter("@mc_name", mc_name));
            sql.Parameters.Add(new SqlParameter("@mc_process", mc_process));
            sql.Parameters.Add(new SqlParameter("@ld_id", ld_id));
            sql.Parameters.Add(new SqlParameter("@mc_updateby", updateby));
            sql.Parameters.Add(new SqlParameter("@mc_updatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch
        {

        }
    }

    public void DeleteMachine(int mc_id)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "DELETE FROM machine WHERE mc_id=@mc_id";
            sql.Parameters.Add(new SqlParameter("@mc_id", mc_id));
            oConn.ExecuteCommand(sql);
        }
        catch
        {

        }
    }


    public MDMachine GetMachineByLineID(int ld_id)
    {
        MDMachine oMDMachine = new MDMachine();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT DISTINCT mc_id,mc.mc_code,mc_name,mc_process,mc.ld_id,ld_linename,FactoryName,mc_updateby,mc_updatedate ";
        sql.CommandText += " ,(SELECT COUNT(d2.data_partnumber) FROM Data d2 WHERE d2.mc_code=mc.mc_code AND (d2.Result='OK' OR d2.Result='1')";
        sql.CommandText += " AND d2.data_mfgdate_search >= @DatetimeStart";
        sql.CommandText += " AND d2.data_mfgdate_search <= @DatetimeEnd) as QtyOK";
        sql.CommandText += " ,(SELECT COUNT(d2.data_partnumber) FROM Data d2 WHERE d2.mc_code = mc.mc_code AND(d2.Result = 'NG' OR d2.Result = '0')";
        sql.CommandText += " AND d2.data_mfgdate_search >= @DatetimeStart";
        sql.CommandText += " AND d2.data_mfgdate_search <= @DatetimeEnd) as QtyNG";
        sql.CommandText += " FROM machine mc";
        sql.CommandText += " LEFT JOIN LineData ld ON mc.ld_id = ld.ld_id";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID = fac.FactoryID";
        sql.CommandText += " LEFT JOIN Data d ON mc.mc_code = d.mc_code";
        sql.CommandText += " WHERE mc.ld_id = @ld_id";
        sql.CommandText += " GROUP BY mc_id,mc.mc_code,mc_name,mc_process,mc.ld_id,ld_linename,FactoryName,mc_updateby,mc_updatedate,d.Result";
        sql.Parameters.Add(new SqlParameter("@ld_id", ld_id));

        string shift = "D";
        if (DateTime.Now >= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-"
            + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 20:00:00"))
        {
            shift = "N";
        }

        if (shift == "D")
        {
            sql.Parameters.Add(new SqlParameter("@DatetimeStart", DateTime.Now.Year.ToString() + "-"
            + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 08:00:00"));
            sql.Parameters.Add(new SqlParameter("@DatetimeEnd", DateTime.Now.Year.ToString() + "-"
                + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 20:00:00"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@DatetimeStart", DateTime.Now.Year.ToString() + "-"
            + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + " 20:00:00"));
            sql.Parameters.Add(new SqlParameter("@DatetimeEnd", DateTime.Now.Year.ToString() + "-"
                + DateTime.Now.Month.ToString() + "-" + DateTime.Now.AddDays(1).Day.ToString() + " 08:00:00"));
        }


        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMachine.CMDMachine oMD = new MDMachine.CMDMachine();
                oMD.mc_id = row["mc_id"] != DBNull.Value ? Convert.ToInt32(row["mc_id"]) : 0;
                oMD.mc_code = row["mc_code"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMD.mc_process = row["mc_process"].ToString();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryName = row["FactoryName"].ToString();
                oMD.mc_updateby = row["mc_updateby"].ToString();
                oMD.mc_updatedate = row["mc_updatedate"].ToString();
                oMD.QtyOK = row["QtyOK"] != DBNull.Value ? Convert.ToInt32(row["QtyOK"]) : 0;
                oMD.QtyNG = row["QtyNG"] != DBNull.Value ? Convert.ToInt32(row["QtyNG"]) : 0;
                oMDMachine.ListOfmachine.Add(oMD);
            }
        }
        return oMDMachine;
    }

}