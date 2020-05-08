using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;

/// <summary>
/// Summary description for CLineData
/// </summary>
public class CLineData
{
    ConnectDB oConn = new ConnectDB();
    public MDLineData GetLineData(string inSearch)
    {
        inSearch = "%" + inSearch + "%";
        MDLineData oMDLine = new MDLineData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText += "SELECT ld_id,ld_linename,ld.FactoryID,fac.FactoryName,ld_order,ld_createby";
        sql.CommandText += " ,ld_createdate,ld_updateby,ld_updatedate";
        sql.CommandText += " FROM LineData ld";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID = fac.FactoryID";
        sql.CommandText += " WHERE ISNULL(ld_linename,'')+ISNULL(FactoryName,'') like @inSearch";
        sql.Parameters.Add(new SqlParameter("@inSearch", inSearch));
        dTable = oConn.Query(sql);
        if(dTable.Rows.Count > 0)
        {
            foreach(DataRow row in dTable.Rows)
            {
                MDLineData.CMDLineData oMD = new MDLineData.CMDLineData();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryID = row["FactoryID"] != DBNull.Value ? Convert.ToInt32(row["FactoryID"]) : 0;
                oMD.FactoryName = row["FactoryName"].ToString();
                oMD.ld_order = row["ld_order"] != DBNull.Value ? Convert.ToInt32(row["ld_order"]) : 0;
                oMD.ld_createby = row["ld_createby"].ToString();
                oMD.ld_createdate = row["ld_createdate"].ToString();
                oMD.ld_updateby = row["ld_updateby"].ToString();
                oMD.ld_updatedate = row["ld_updatedate"].ToString();
                oMDLine.ListOfLine.Add(oMD);
            }
        }
        return oMDLine;
    }

    public MDLineData GetLineDataByLineID(int ld_id)
    {
        MDLineData oMDLine = new MDLineData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText += "SELECT ld_id,ld_linename,ld.FactoryID,fac.FactoryName,ld_order,ld_createby";
        sql.CommandText += " ,ld_createdate,ld_updateby,ld_updatedate";
        sql.CommandText += " FROM LineData ld";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID = fac.FactoryID";
        sql.CommandText += " WHERE ld_id=@ld_id";
        sql.Parameters.Add(new SqlParameter("@ld_id", ld_id));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDLineData.CMDLineData oMD = new MDLineData.CMDLineData();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryID = row["FactoryID"] != DBNull.Value ? Convert.ToInt32(row["FactoryID"]) : 0;
                oMD.FactoryName = row["FactoryName"].ToString();
                oMD.ld_order = row["ld_order"] != DBNull.Value ? Convert.ToInt32(row["ld_order"]) : 0;
                oMD.ld_createby = row["ld_createby"].ToString();
                oMD.ld_createdate = row["ld_createdate"].ToString();
                oMD.ld_updateby = row["ld_updateby"].ToString();
                oMD.ld_updatedate = row["ld_updatedate"].ToString();
                oMDLine.ListOfLine.Add(oMD);
            }
        }
        return oMDLine;
    }

    public MDLineData GetLineDataByFactoryID(int FactoryID)
    {
        MDLineData oMDLine = new MDLineData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText += "SELECT ld.ld_id,ld_linename,ld.FactoryID,fac.FactoryName";
        sql.CommandText += " ,Count(mc.mc_code) as MachineTotal";
        sql.CommandText += " FROM LineData ld";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID = fac.FactoryID";
        sql.CommandText += " LEFT JOIN Machine mc ON ld.ld_id = mc.ld_id";
        sql.CommandText += " WHERE ld.FactoryID = @FactoryID";
        sql.CommandText += " GROUP BY ld_order,ld.ld_id,ld_linename,ld.FactoryID,fac.FactoryName";
        sql.Parameters.Add(new SqlParameter("@FactoryID", FactoryID));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDLineData.CMDLineData oMD = new MDLineData.CMDLineData();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryID = row["FactoryID"] != DBNull.Value ? Convert.ToInt32(row["FactoryID"]) : 0;
                oMD.FactoryName = row["FactoryName"].ToString();                
                oMD.MachineTotal = row["MachineTotal"] != DBNull.Value ? Convert.ToInt32(row["MachineTotal"]) : 0;
                oMDLine.ListOfLine.Add(oMD);
            }
        }
        return oMDLine;
    }

    public MDLineData GetLineMonitoringByFactoryID(int FactoryID)
    {
        MDLineData oMDLine = new MDLineData();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText += "SELECT ld.ld_id,ld_linename,ld.FactoryID,fac.FactoryName";
        sql.CommandText += " ,Count(mc.mc_code) as MachineTotal";
        sql.CommandText += " FROM LineMonitoring ld";
        sql.CommandText += " LEFT JOIN FactoryData fac ON ld.FactoryID = fac.FactoryID";
        sql.CommandText += " LEFT JOIN Machine mc ON ld.ld_id = mc.ld_id";
        sql.CommandText += " WHERE ld.FactoryID = @FactoryID";
        sql.CommandText += " GROUP BY ld_order,ld.ld_id,ld_linename,ld.FactoryID,fac.FactoryName";
        sql.Parameters.Add(new SqlParameter("@FactoryID", FactoryID));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDLineData.CMDLineData oMD = new MDLineData.CMDLineData();
                oMD.ld_id = row["ld_id"] != DBNull.Value ? Convert.ToInt32(row["ld_id"]) : 0;
                oMD.ld_linename = row["ld_linename"].ToString();
                oMD.FactoryID = row["FactoryID"] != DBNull.Value ? Convert.ToInt32(row["FactoryID"]) : 0;
                oMD.FactoryName = row["FactoryName"].ToString();
                //oMD.MachineTotal = row["MachineTotal"] != DBNull.Value ? Convert.ToInt32(row["MachineTotal"]) : 0;
                oMDLine.ListOfLine.Add(oMD);
            }
        }
        return oMDLine;
    }

}