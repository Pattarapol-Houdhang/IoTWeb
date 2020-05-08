using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

/// <summary>
/// Summary description for CFactory
/// </summary>
public class CFactory
{
    ConnectDB oConn = new ConnectDB();
    public MDFactory GetFactory()
    {
        MDFactory oMDFactory = new MDFactory();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT fac.FactoryID,FactoryName";
        sql.CommandText += " ,Count(ld.ld_id) as TotalLine";
        sql.CommandText += " ,Count(mc.mc_code) as TotalMachine";
        sql.CommandText += " FROM FactoryData fac";
        sql.CommandText += " LEFT JOIN LineData ld ON fac.FactoryID = ld.FactoryID";
        sql.CommandText += " LEFT JOIN Machine mc ON ld.ld_id = mc.ld_id";
        sql.CommandText += " GROUP BY fac.FactoryID,FactoryName";
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDFactory.CMDFactory oMD = new MDFactory.CMDFactory();
                oMD.FactoryID = row["FactoryID"] != DBNull.Value ? Convert.ToInt32(row["FactoryID"]) : 0;
                oMD.FactoryName = row["FactoryName"].ToString();
                oMD.TotalLine = row["TotalLine"] != DBNull.Value ? Convert.ToInt32(row["TotalLine"]) : 0;
                oMD.TotalMachine = row["TotalMachine"] != DBNull.Value ? Convert.ToInt32(row["TotalMachine"]) : 0;
                oMDFactory.ListOfFactory.Add(oMD);
            }
        }

        return oMDFactory;
    }

    public MDFactory GetFactoryByFactoryID(string FactoryID)
    {
        MDFactory oMDFactory = new MDFactory();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT FactoryID,FactoryName";
        sql.CommandText += " FROM FactoryData";
        sql.CommandText += " WHERE FactoryID=@FactoryID";
        sql.Parameters.Add(new SqlParameter("@FactoryID", FactoryID));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDFactory.CMDFactory oMD = new MDFactory.CMDFactory();
                oMD.FactoryID = row["FactoryID"] != DBNull.Value ? Convert.ToInt32(row["FactoryID"]) : 0;
                oMD.FactoryName = row["FactoryName"].ToString();
                oMDFactory.ListOfFactory.Add(oMD);
            }
        }

        return oMDFactory;
    }
}