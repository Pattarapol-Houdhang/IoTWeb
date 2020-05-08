using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ConnectDBSCM
/// </summary>
public class ConnectDBCosty
{
    public ConnectDBCosty()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public SqlConnection SqlStrCon(string dbName)
    {
        switch (dbName.ToUpper())
        {
            case "DBSCM" : return new SqlConnection("Data Source=costy;Initial Catalog=dbSCM;Persist Security Info=True;User ID=sa;Password=decjapan;");                
            case "DBPDB": return new SqlConnection("Data Source=costy;Initial Catalog=dbPDB;Persist Security Info=True;User ID=sa;Password=decjapan;");
            case "DBDCI": return new SqlConnection("Data Source=costy;Initial Catalog=dbDCI;Persist Security Info=True;User ID=sa;Password=decjapan;");
            case "DBIOTFAC3": return new SqlConnection("Data Source=costy;Initial Catalog=dbIoTFac3;Persist Security Info=True;User ID=sa;Password=decjapan;");
            default: return new SqlConnection("Data Source=costy;Initial Catalog=dbSCM;Persist Security Info=True;User ID=sa;Password=decjapan;");
        }  
        
            
    }

    public DataTable SqlGet(string sql,string dbName)
    {
        SqlConnection conn = SqlStrCon(dbName);
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

    public DataTable SqlGet(SqlCommand sql, string dbName)
    {
        SqlConnection conn = SqlStrCon(dbName);
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

    public int SqlExecute(string sql, string dbName)
    {
        int i;
        SqlConnection conn = SqlStrCon(dbName);
        SqlCommand cmd = new SqlCommand(sql, conn);
        conn.Open();
        i = cmd.ExecuteNonQuery();
        conn.Close();
        return i;//------ Return number of rows affected---------    
    }

    public int SqlExecute(SqlCommand sql, string dbName)
    {
        int i;
        SqlConnection conn = SqlStrCon(dbName);
        sql.Connection = conn;
        conn.Open();
        i = sql.ExecuteNonQuery();
        conn.Close();
        return i;//------ Return number of rows affected---------
    }

    public DataSet SqlExcSto(string stpName, string tblName, SqlParameterCollection parameters, string dbName)
    {
        SqlConnection conn = SqlStrCon(dbName);
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