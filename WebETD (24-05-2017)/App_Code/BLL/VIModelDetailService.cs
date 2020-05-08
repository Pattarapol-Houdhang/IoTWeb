using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for VIModelDetailService
/// </summary>
public class VIModelDetailService
{
    vi_model_detailTableAdapter viModelTba;
    public VIModelDetailService()
    {
        viModelTba = new vi_model_detailTableAdapter();
    }

    private ArrayList DataTableToObjects(DataTable tb, Type t)
    {
        ArrayList ls = new ArrayList();
        if (tb.Rows != null)
        {
            foreach (DataRow item in tb.Rows)
            {
                object ob = DataRowToObject(item, t);
                ls.Add(ob);
            }
        }
        return ls;
    }

    private object DataRowToObject(DataRow r, Type t)
    {
        if (t == typeof(VIModelDetailInfo))
        {
            VIModelDetailInfo item = new VIModelDetailInfo();
            DataSet.vi_model_detailRow dr = (DataSet.vi_model_detailRow)r;

            item.Model_id = dr.m_id;
            item.Model_name = dr.m_name;
            item.Part_id = dr.p_id;
            item.Part_name = dr.p_name;
            item.PartType_id = dr.pt_id;
            item.PartType_name = dr.pt_name;
            item.Part_mid = dr.p_mid_dimension;
            item.Part_max = dr.p_max_dimension;
            item.Part_min = dr.p_min_dimension;
            item.Part_cycletime = dr.p_cycletime;
            item.Group_id = dr.g_id;
            item.Rank_id = dr.gr_id;
            item.Rank_name = dr.r_name;
            item.Part_status = dr.p_status;

            return item;
        }
        return null;
    }

    public ArrayList GetModelDetailDataByModelIDANDPartID(string model_id, string part_id)
    {
        DataTable dt = viModelTba.GetDataByModelIDANDPartID(model_id, part_id);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(VIModelDetailInfo));
        }
        else
        {
            return null;
        }
    }

    public VIModelDetailInfo GetModelDetailDataByModelIDANDPartIDAndPartTypeName(string model_id, string part_id, string partType_name, string conStr)
    {
        viModelTba.Connection.ConnectionString = conStr;
        DataTable dt = viModelTba.GetDataByModelIDPartIDPartTypeName(model_id, part_id, partType_name);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            return (VIModelDetailInfo)DataRowToObject(dr, typeof(VIModelDetailInfo));
        }
        else
        {
            return null;
        }
    }
}