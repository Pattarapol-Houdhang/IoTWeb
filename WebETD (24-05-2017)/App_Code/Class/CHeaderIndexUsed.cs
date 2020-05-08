using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

/// <summary>
/// Summary description for CHeaderIndexUsed
/// </summary>
public class CHeaderIndexUsed
{
    ConnectDB oConn = new ConnectDB();
    public MDHeaderIndexUsed GetHeaderIndexUsed(string inSearch)
    {
        inSearch = "%" + inSearch + "%";
        MDHeaderIndexUsed oMDHeaderIndex = new MDHeaderIndexUsed();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT hiu.hiu_id,hiu.mc_code,mc.mc_name,hiu.header_id,hm.header_detail";
        sql.CommandText += " ,field_index,ColumnName,result_index,datetime_index,partnumber_index,model_index";
        sql.CommandText += " FROM HeaderIndexUsed hiu";
        sql.CommandText += " LEFT JOIN HeaderMaster hm ON hiu.header_id = hm.header_id";
        sql.CommandText += " LEFT JOIN Machine mc ON hiu.mc_code = mc.mc_code";
        sql.CommandText += " WHERE ISNULL(mc_code,'') like @inSearch";
        sql.Parameters.Add(new SqlParameter("@inSearch", inSearch));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDHeaderIndexUsed.CMDHeaderIndexUsed oMD = new MDHeaderIndexUsed.CMDHeaderIndexUsed();
                oMD.hiu_id = row["hiu_id"] != DBNull.Value ? Convert.ToInt32(row["hiu_id"]) : 0;
                oMD.mc_code = row["mc_code"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMD.header_id = row["header_id"].ToString();
                oMD.header_detail = row["header_detail"].ToString();
                oMD.field_index = row["field_index"].ToString();
                oMD.ColumnName = row["ColumnName"].ToString();
                oMD.result_index = row["result_index"].ToString();
                oMD.datetime_index = row["datetime_index"].ToString();
                oMD.partnumber_index = row["partnumber_index"].ToString();
                oMD.model_index = row["model_index"].ToString();
                oMDHeaderIndex.ListOfHeaderIndexUsed.Add(oMD);
            }
        }
        return oMDHeaderIndex;
    }

    public MDHeaderIndexUsed GetHeaderIndexUsedByhiu_id(string hiu_id)
    {
        MDHeaderIndexUsed oMDHeaderIndex = new MDHeaderIndexUsed();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT hiu.hiu_id,hiu.mc_code,mc.mc_name,hiu.header_id,hm.header_detail";
        sql.CommandText += " ,field_index,ColumnName,result_index,datetime_index,partnumber_index,model_index";
        sql.CommandText += " FROM HeaderIndexUsed hiu";
        sql.CommandText += " LEFT JOIN HeaderMaster hm ON hiu.header_id = hm.header_id";
        sql.CommandText += " LEFT JOIN Machine mc ON hiu.mc_code = mc.mc_code";
        sql.CommandText += " WHERE hiu_id = @hiu_id";
        sql.Parameters.Add(new SqlParameter("@hiu_id", hiu_id));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDHeaderIndexUsed.CMDHeaderIndexUsed oMD = new MDHeaderIndexUsed.CMDHeaderIndexUsed();
                oMD.hiu_id = row["hiu_id"] != DBNull.Value ? Convert.ToInt32(row["hiu_id"]) : 0;
                oMD.mc_code = row["mc_code"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMD.header_id = row["header_id"].ToString();
                oMD.header_detail = row["header_detail"].ToString();
                oMD.field_index = row["field_index"].ToString();
                oMD.ColumnName = row["ColumnName"].ToString();
                oMD.result_index = row["result_index"].ToString();
                oMD.datetime_index = row["datetime_index"].ToString();
                oMD.partnumber_index = row["partnumber_index"].ToString();
                oMD.model_index = row["model_index"].ToString();
                oMDHeaderIndex.ListOfHeaderIndexUsed.Add(oMD);
            }
        }
        return oMDHeaderIndex;
    }

    public void InsertHeaderIndexUsed(string mc_code, string header_id, string field_index, string ColumnName, string result_index
        , string datetime_index, string partnumber_index, string model_index)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "INSERT INTO HeaderIndexUsed(mc_code,header_id,field_index,ColumnName,result_index,datetime_index,partnumber_index,model_index) ";
            sql.CommandText += " VALUES(@mc_code,@header_id,@field_index,@ColumnName,@result_index,@datetime_index,@partnumber_index,@model_index)";
            sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
            sql.Parameters.Add(new SqlParameter("@header_id", header_id));
            sql.Parameters.Add(new SqlParameter("@field_index", field_index));
            sql.Parameters.Add(new SqlParameter("@result_index", result_index));
            sql.Parameters.Add(new SqlParameter("@datetime_index", datetime_index));
            sql.Parameters.Add(new SqlParameter("@partnumber_index", partnumber_index));
            sql.Parameters.Add(new SqlParameter("@model_index", model_index));
            oConn.ExecuteCommand(sql);
        }
        catch
        {

        }
    }

    public void UpdateHeaderIndexUsed(int hiu_id, string mc_code, string header_id, string field_index, string ColumnName, string result_index
        , string datetime_index, string partnumber_index, string model_index)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "UPDATE HeaderIndexUsed SET mc_code=@mc_code,header_id=@header_id,field_index=@field_index,ColumnName=@ColumnName";
            sql.CommandText += ",result_index=@result_index,datetime_index=@datetime_index,partnumber_index=@partnumber_index,model_index=@model_index ";
            sql.CommandText += " WHERE hiu_id=@hiu_id";
            sql.Parameters.Add(new SqlParameter("@hiu_id", hiu_id));
            sql.Parameters.Add(new SqlParameter("@mc_code", mc_code));
            sql.Parameters.Add(new SqlParameter("@header_id", header_id));
            sql.Parameters.Add(new SqlParameter("@field_index", field_index));
            sql.Parameters.Add(new SqlParameter("@ColumnName", ColumnName));
            sql.Parameters.Add(new SqlParameter("@result_index", result_index));
            sql.Parameters.Add(new SqlParameter("@datetime_index", datetime_index));
            sql.Parameters.Add(new SqlParameter("@partnumber_index", partnumber_index));
            sql.Parameters.Add(new SqlParameter("@model_index", model_index));
            oConn.ExecuteCommand(sql);
        }
        catch
        {

        }
    }

    public void DeleteHeaderIndexUsed(int hiu_id)
    {
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("DELETE FROM HeaderIndexUsed WHERE hiu_id=" + hiu_id);
        oConn.ExecuteCommand(sbd.ToString());
    }

    public MDHeaderIndexUsed GetDataWithHeaderInx(string mc_code, string Model, DateTime DateStart, DateTime DateEnd)
    {
        MDHeaderIndexUsed oMDHeaderInx = new MDHeaderIndexUsed();
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT data_partnumber,header_detail,data_detail,field_index,ColumnName");
        sbd.AppendLine(", mc_name, datetime_index, model_index, result_index,d.mc_code,model_code,Result");
        sbd.AppendLine("FROM data d");
        sbd.AppendLine("LEFT JOIN MachineHeaderIndex mhi ON d.mc_code = mhi.mc_code");
        sbd.AppendLine("LEFT JOIN HeaderMaster hm ON mhi.header_id = hm.header_id");
        sbd.AppendLine("LEFT JOIN Machine mc ON d.mc_code = mc.mc_code");
        sbd.AppendLine("LEFT JOIN HeaderIndexUsed hiu ON d.mc_code = hiu.mc_code AND hm.header_id = hiu.header_id");
        sbd.AppendLine("LEFT JOIN Model md ON d.model_id=md.model_id");
        sbd.AppendLine("WHERE d.mc_code='" + mc_code + "'");
        sbd.AppendLine("AND md.model_code='" + Model + "'");
        sbd.AppendLine("AND data_mfgdate >= '" + DateStart + "'");
        sbd.AppendLine("AND data_mfgdate <= '" + DateEnd + "'");
        dTable = oConn.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDHeaderIndexUsed.CMDHeaderIndexUsed oMD = new MDHeaderIndexUsed.CMDHeaderIndexUsed();
                oMD.ColumnName = row["ColumnName"].ToString();
                oMD.header_detail = row["header_detail"].ToString();
                oMD.data_detail = row["data_detail"].ToString();
                oMD.field_index = row["field_index"].ToString();
                oMD.mc_name = row["mc_name"].ToString();
                oMD.mc_code = row["mc_code"].ToString();
                oMD.result_index = row["result_index"].ToString();
                oMD.model_index = row["model_index"].ToString();
                oMD.datetime_index = row["datetime_index"].ToString();
                oMD.Result = row["Result"].ToString();
                oMDHeaderInx.ListOfHeaderIndexUsed.Add(oMD);

            }
        }

        return oMDHeaderInx;
    }

}