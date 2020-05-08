using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

/// <summary>
/// Summary description for CGenGraph
/// </summary>
public class CGenGraph
{
    ConnectDB oConn = new ConnectDB();

    public MDGenGraph GenGraph(string mc_code,string model,string DateStart,string DateEnd)
    {
        MDGenGraph oMDGen = new MDGenGraph();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "[dbo].[GenData] @mc_code,@model,@DateStart,@DateEnd";
        sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
        sql.Parameters.Add(new SqlParameter("@model", model));
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oConn.Query(sql);
        if(dTable.Rows.Count > 0)
        {
            foreach(DataRow row in dTable.Rows)
            {
                MDGenGraph.CMDGenGraph oMD = new MDGenGraph.CMDGenGraph();
                oMD.Date = row["DataDate"].ToString();
                oMD.QtyOK = row["QtyOK"] != DBNull.Value ? Convert.ToInt32(row["QtyOK"]) : 0;
                oMD.QtyNG = row["QtyNG"] != DBNull.Value ? Convert.ToInt32(row["QtyNG"]) : 0;
                oMD.DataDateStart = row["DataDatetimeStart"].ToString();
                oMD.DataDateEnd = row["DataDatetimeEnd"].ToString();
                oMD.MachineCode = row["MachineCode"].ToString();
                oMD.MachineName = row["MachineName"].ToString();
                oMD.ModelCode = row["ModelCode"].ToString();
                oMD.ModelName = row["ModelName"].ToString();
                oMDGen.ListOfData.Add(oMD);
            }
        }
        return oMDGen;
    }
}