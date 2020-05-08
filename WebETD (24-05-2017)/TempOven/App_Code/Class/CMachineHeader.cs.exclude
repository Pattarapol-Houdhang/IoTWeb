using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CMachineHeader
/// </summary>
public class CMachineHeader
{
    ConnectDB oConn = new ConnectDB();

    public MDMachineHeader GetMachineHeader(string inSearch)
    {
        inSearch = "%" + inSearch + "%";
        MDMachineHeader oMDMCHeader = new MDMachineHeader();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT mhi_id,mhi.mc_code,mc_name,mhi.index_id,mhi.header_id,mhi_createby,mhi_createdate";
        sql.CommandText += ",mhi_updateby,mhi_updatedate,header_detail,index_datetime,index_partnumber,index_modelcode,index_result";
        sql.CommandText += ",index_value";
        sql.CommandText += " FROM MachineHeaderIndex mhi";
        sql.CommandText += " LEFT JOIN headerMaster hm ON mhi.header_id = hm.header_id";
        sql.CommandText += " LEFT JOIN IndexColumn ic ON mhi.index_id = ic.index_id";
        sql.CommandText += " LEFT JOIN machine mc ON mhi.mc_code=mc.mc_code";
        sql.CommandText += " WHERE ISNULL(mhi.mc_code,'') like @inSearch";
        sql.Parameters.Add(new SqlParameter("@inSearch", inSearch));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMachineHeader.CMDMachineHeader oMD = new MDMachineHeader.CMDMachineHeader();
                oMD.mhi_id = row["mhi_id"].ToString();
                oMD.mc_code = row["mc_code"].ToString();
                oMD.index_id = row["index_id"].ToString();
                oMD.header_id = row["header_id"].ToString();
                oMD.mhi_createby = row["mhi_createby"].ToString();
                oMD.mhi_createdate = row["mhi_createdate"].ToString();
                oMD.mhi_updateby = row["mhi_updateby"].ToString();
                oMD.mhi_updatedate = row["mhi_updatedate"].ToString();
                oMD.header_detail = row["header_detail"].ToString();
                oMD.index_datetime = row["index_datetime"].ToString();
                oMD.index_partnumber = row["index_partnumber"].ToString();
                oMD.index_modelcode = row["index_modelcode"].ToString();
                oMD.index_value = row["index_value"].ToString();
                oMD.index_result = row["index_result"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMDMCHeader.ListOfMachineHeader.Add(oMD);
            }
        }

        return oMDMCHeader;
    }

    public MDMachineHeader GetMachineHeaderBymc_code(string mc_code)
    {
        MDMachineHeader oMDMCHeader = new MDMachineHeader();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT mhi_id,mhi.mc_code,mc_name,mhi.index_id,mhi.header_id,mhi_createby,mhi_createdate";
        sql.CommandText += ",mhi_updateby,mhi_updatedate,header_detail,index_datetime,index_partnumber,index_modelcode,index_result";
        sql.CommandText += ",index_value";
        sql.CommandText += " FROM MachineHeaderIndex mhi";
        sql.CommandText += " LEFT JOIN headerMaster hm ON mhi.header_id = hm.header_id";
        sql.CommandText += " LEFT JOIN IndexColumn ic ON mhi.index_id = ic.index_id";
        sql.CommandText += " LEFT JOIN machine mc ON mhi.mc_code=mc.mc_code";
        sql.CommandText += " WHERE mhi.mc_code = @mc_code";
        sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMachineHeader.CMDMachineHeader oMD = new MDMachineHeader.CMDMachineHeader();
                oMD.mhi_id = row["mhi_id"].ToString();
                oMD.mc_code = row["mc_code"].ToString();
                oMD.index_id = row["index_id"].ToString();
                oMD.header_id = row["header_id"].ToString();
                oMD.mhi_createby = row["mhi_createby"].ToString();
                oMD.mhi_createdate = row["mhi_createdate"].ToString();
                oMD.mhi_updateby = row["mhi_updateby"].ToString();
                oMD.mhi_updatedate = row["mhi_updatedate"].ToString();
                oMD.header_detail = row["header_detail"].ToString();
                oMD.index_datetime = row["index_datetime"].ToString();
                oMD.index_partnumber = row["index_partnumber"].ToString();
                oMD.index_modelcode = row["index_modelcode"].ToString();
                oMD.index_value = row["index_value"].ToString();
                oMD.index_result = row["index_result"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMDMCHeader.ListOfMachineHeader.Add(oMD);
            }
        }

        return oMDMCHeader;
    }

    public MDMachineHeader GetMachineHeaderByID(string mhi_id)
    {
        MDMachineHeader oMDMCHeader = new MDMachineHeader();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT mhi_id,mhi.mc_code,mc_name,mhi.index_id,mhi.header_id,mhi_createby,mhi_createdate";
        sql.CommandText += ",mhi_updateby,mhi_updatedate,header_detail,index_datetime,index_partnumber,index_modelcode,index_result";
        sql.CommandText += ",index_value";
        sql.CommandText += " FROM MachineHeaderIndex mhi";
        sql.CommandText += " LEFT JOIN headerMaster hm ON mhi.header_id = hm.header_id";
        sql.CommandText += " LEFT JOIN IndexColumn ic ON mhi.index_id = ic.index_id";
        sql.CommandText += " LEFT JOIN machine mc ON mhi.mc_code=mc.mc_code";
        sql.CommandText += " WHERE mhi_id = @mhi_id";
        sql.Parameters.Add(new SqlParameter("@mhi_id", mhi_id));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMachineHeader.CMDMachineHeader oMD = new MDMachineHeader.CMDMachineHeader();
                oMD.mhi_id = row["mhi_id"].ToString();
                oMD.mc_code = row["mc_code"].ToString();
                oMD.index_id = row["index_id"].ToString();
                oMD.header_id = row["header_id"].ToString();
                oMD.mhi_createby = row["mhi_createby"].ToString();
                oMD.mhi_createdate = row["mhi_createdate"].ToString();
                oMD.mhi_updateby = row["mhi_updateby"].ToString();
                oMD.mhi_updatedate = row["mhi_updatedate"].ToString();
                oMD.header_detail = row["header_detail"].ToString();
                oMD.index_datetime = row["index_datetime"].ToString();
                oMD.index_partnumber = row["index_partnumber"].ToString();
                oMD.index_modelcode = row["index_modelcode"].ToString();
                oMD.index_value = row["index_value"].ToString();
                oMD.index_result = row["index_result"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMDMCHeader.ListOfMachineHeader.Add(oMD);
            }
        }

        return oMDMCHeader;
    }

    public void InsertMachineHeader(string mc_code, int index_id, int header_id, string updateby)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "INSERT INTO MachineHeaderIndex VALUES(@mc_code,@index_id,@header_id,@mhi_createby,@mhi_createdate,@mhi_updateby,@mhi_updatedate)";
            sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
            sql.Parameters.Add(new SqlParameter("@index_id", index_id));
            sql.Parameters.Add(new SqlParameter("@header_id", header_id));
            sql.Parameters.Add(new SqlParameter("@mhi_createby", updateby));
            sql.Parameters.Add(new SqlParameter("@mhi_createdate", DateTime.Now));
            sql.Parameters.Add(new SqlParameter("@mhi_updateby", updateby));
            sql.Parameters.Add(new SqlParameter("@mhi_updatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch
        {

        }
    }


    public void UpdateMachineHeader(int mhi_id, string mc_code, int index_id, int header_id, string updateby)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "UPDATE MachineHeaderIndex SET mc_code=@mc_code,index_id=@index_id,header_id=@header_id,mhi_updateby=@mhi_updateby,mhi_updatedate=@mhi_updatedate";
            sql.CommandText += " WHERE mhi_id=@mhi_id";
            sql.Parameters.Add(new SqlParameter("@mhi_id", mhi_id));
            sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
            sql.Parameters.Add(new SqlParameter("@index_id", index_id));
            sql.Parameters.Add(new SqlParameter("@header_id", header_id));
            sql.Parameters.Add(new SqlParameter("@mhi_updateby", updateby));
            sql.Parameters.Add(new SqlParameter("@mhi_updatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch
        {

        }
    }


    public void DeleteMachineHeader(int mhi_id)
    {
        try
        {
            StringBuilder sbd = new StringBuilder();
            sbd.AppendLine("DELETE FROM MachineheaderIndex WHERE mhi_id='" + mhi_id + "'");
            oConn.ExecuteCommand(sbd.ToString());
        }
        catch
        {

        }
    }

}