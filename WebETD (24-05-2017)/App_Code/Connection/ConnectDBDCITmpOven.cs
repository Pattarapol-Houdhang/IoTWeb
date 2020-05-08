using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConnectDBDCI
/// </summary>
public class ConnectDBDCITempOven
{
    public ConnectDBDCITempOven()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection SqlStrCon()
    {
        return new SqlConnection("Data Source=10.194.40.103;Initial Catalog=dbIoT;Persist Security Info=True;User ID=sa;Password=decjapan;");
    }

    public DataTable SqlGet(string sql)
    {
        SqlConnection conn = SqlStrCon();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "table0");
            return ds.Tables["table0"];
        }
        catch (Exception e)
        {
            DataTable dtErr = new DataTable();
            dtErr.Columns.Add("Err", typeof(string));
            DataRow _row = dtErr.NewRow();
            _row["Err"] = e.ToString();
            dtErr.Rows.Add(_row);
            return dtErr;
        }
    }

    public DataTable SqlGet(SqlCommand sql)
    {
        SqlConnection conn = SqlStrCon();
        sql.Connection = conn;
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        try
        {
            da.Fill(ds, "table0");
            return ds.Tables["table0"];
        }
        catch (Exception e)
        {
            //DataTable dtErr = new DataTable();
            //dtErr.Columns.Add("Err", typeof(string));
            //DataRow _row = dtErr.NewRow();
            //_row["Err"] = e.ToString();
            //dtErr.Rows.Add(_row);
            return new DataTable();
        }
    }

    public int SqlExecute(string sql)
    {
        int i;
        SqlConnection conn = SqlStrCon();
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;//------ Return number of rows affected---------    
    }

    public int SqlExecute(SqlCommand sql)
    {
        int i;
        SqlConnection conn = SqlStrCon();
        sql.Connection = conn;
        conn.Open();
        i = sql.ExecuteNonQuery();
        conn.Close();
        return i;//------ Return number of rows affected---------
    }

    public DataSet SqlExcSto(string stpName, string tblName, SqlParameterCollection parameters)
    {
        SqlConnection conn = SqlStrCon();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = stpName;
        foreach (SqlParameter param in parameters)
        {
            cmd.Parameters.AddWithValue(param.ParameterName, param.SqlDbType).Value = param.Value;
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, tblName);
        return ds;
    }
}