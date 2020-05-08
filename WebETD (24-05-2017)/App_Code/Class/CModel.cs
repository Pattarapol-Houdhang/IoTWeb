using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CModel
/// </summary>
public class CModel
{
    ConnectDB oConn = new ConnectDB();
    public MDModel GetModel(string inSearch)
    {
        inSearch = "%" + inSearch + "%";
        MDModel oMDModel = new MDModel();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT model_id,model_code,model_name,model_type,model_updateby,model_updatedate FROM model";
        sql.CommandText += " WHERE ISNULL(model_code,'')+ISNULL(model_name,'')+ISNULL(model_type,'') like @inSearch";
        sql.Parameters.Add(new SqlParameter("@inSearch", inSearch));
        dTable = oConn.Query(sql);
        if(dTable.Rows.Count > 0)
        {
            foreach(DataRow row in dTable.Rows)
            {
                MDModel.CMDModel oMD = new MDModel.CMDModel();
                oMD.model_id = row["model_id"].ToString();
                oMD.model_code = row["model_code"].ToString();
                oMD.model_name = row["model_name"].ToString();
                oMD.model_type = row["model_type"].ToString();
                oMD.model_updateby = row["model_updateby"].ToString();
                oMD.model_updatedate = row["model_updatedate"].ToString();
                oMDModel.ListOfModel.Add(oMD);
            }
        }
        return oMDModel;
    }

    public MDModel GetModelBymodel_id(string model_id)
    {
        MDModel oMDModel = new MDModel();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT model_id,model_code,model_name,model_type,model_updateby,model_updatedate FROM model";
        sql.CommandText += " WHERE model_id=@model_id";
        sql.Parameters.Add(new SqlParameter("@model_id", model_id));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDModel.CMDModel oMD = new MDModel.CMDModel();
                oMD.model_id = row["model_id"].ToString();
                oMD.model_code = row["model_code"].ToString();
                oMD.model_name = row["model_name"].ToString();
                oMD.model_type = row["model_type"].ToString();
                oMD.model_updateby = row["model_updateby"].ToString();
                oMD.model_updatedate = row["model_updatedate"].ToString();
                oMDModel.ListOfModel.Add(oMD);
            }
        }
        return oMDModel;
    }

    public MDModel GetModelBymodel_code(string model_code)
    {
        MDModel oMDModel = new MDModel();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT model_id,model_code,model_name,model_type,model_updateby,model_updatedate FROM model";
        sql.CommandText += " WHERE model_code=@model_code";
        sql.Parameters.Add(new SqlParameter("@model_code", model_code));
        dTable = oConn.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDModel.CMDModel oMD = new MDModel.CMDModel();
                oMD.model_id = row["model_id"].ToString();
                oMD.model_code = row["model_code"].ToString();
                oMD.model_name = row["model_name"].ToString();
                oMD.model_type = row["model_type"].ToString();
                oMD.model_updateby = row["model_updateby"].ToString();
                oMD.model_updatedate = row["model_updatedate"].ToString();
                oMDModel.ListOfModel.Add(oMD);
            }
        }
        return oMDModel;
    }

    public void InsertModel(string model_code,string model_name,string model_type,string model_updateby)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "INSERT INTO model(model_code,model_name,model_type,model_updateby,model_updatedate) VALUES(";
            sql.CommandText += "@model_code,@model_name,@model_type,@model_updateby,@model_updatedate)";
            sql.Parameters.Add(new SqlParameter("@model_code", model_code));
            sql.Parameters.Add(new SqlParameter("@model_name", model_name));
            sql.Parameters.Add(new SqlParameter("@model_type", model_type));
            sql.Parameters.Add(new SqlParameter("@model_updateby", model_updateby));
            sql.Parameters.Add(new SqlParameter("@model_updatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch
        {
        }
    }

    public void UpdateModel(string model_id,string model_code, string model_name, string model_type, string model_updateby)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "UPDATE model SET model_code=@model_code,model_name=@model_name,model_type=@model_type,model_updateby=@model_updateby,model_updatedate=@model_updatedate";
            sql.CommandText += " WHERE model_id=@model_id";
            sql.Parameters.Add(new SqlParameter("@model_id", model_id));
            sql.Parameters.Add(new SqlParameter("@model_code", model_code));
            sql.Parameters.Add(new SqlParameter("@model_name", model_name));
            sql.Parameters.Add(new SqlParameter("@model_type", model_type));
            sql.Parameters.Add(new SqlParameter("@model_updateby", model_updateby));
            sql.Parameters.Add(new SqlParameter("@model_updatedate", DateTime.Now));
            oConn.ExecuteCommand(sql);
        }
        catch
        {
        }
    }

    public void DeleteModel(string model_id)
    {
        try
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "DELETE FROM model WHERE model_id=@model_id";
            sql.Parameters.Add(new SqlParameter("@model_id", model_id));
            oConn.ExecuteCommand(sql);
        }
        catch
        {
        }
    }


}