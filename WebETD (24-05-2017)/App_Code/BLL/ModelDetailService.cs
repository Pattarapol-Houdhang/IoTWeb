using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ModelDetailService
/// </summary>
public class ModelDetailService
{
    private etd_model_detailTableAdapter mdTba;

	public ModelDetailService()
	{
        mdTba = new etd_model_detailTableAdapter();
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
        if (t == typeof(ModelDetailInfo))
        {
            ModelDetailInfo item = new ModelDetailInfo();
            DataSet.etd_model_detailRow dr = (DataSet.etd_model_detailRow)r;


            item.Model_id = dr.m_id;
            item.Part_id = dr.p_id;
            item.PartType_id = dr.pt_id;
            item.Rank_id = dr.r_id;
            item.Part_mid = dr.p_mid_dimension;
            item.Part_max = dr.p_max_dimension;
            item.Part_min = dr.p_min_dimension;
            item.Part_cycletime = dr.p_cycletime;
            item.User_edit = dr.p_user;
            item.Part_status = dr.p_status;

            return item;
        }
        return null;
    }

    public bool InsertModelDetail(ModelDetailInfo mdInfo)
    {
        try
        {
            mdTba.InsertModelDetail(
                                    mdInfo.Model_id, mdInfo.Part_id, mdInfo.PartType_id,
                                    mdInfo.Rank_id, mdInfo.Part_mid, mdInfo.Part_max,
                                    mdInfo.Part_min, mdInfo.Part_cycletime, mdInfo.User_edit,
                                    mdInfo.Part_status
                                    );

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateModelDetail(ModelDetailInfo mdInfo)
    {
        try
        {
            mdTba.UpdateModelDetail(
                                    mdInfo.Rank_id, mdInfo.Part_mid, mdInfo.Part_max,
                                    mdInfo.Part_min, mdInfo.Part_cycletime, mdInfo.User_edit,
                                    mdInfo.Part_status, mdInfo.Model_id,
                                    mdInfo.Part_id, mdInfo.PartType_id
                                    );

            return true;
        }
        catch
        {
            return false;
        }
    }

    public ArrayList GetModelDetail(string model_no, string part_id)
    {
        try
        {
            DataTable tb = mdTba.GetDataByModelPartID(model_no, part_id);

            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return DataTableToObjects(tb, typeof(OffsetMasterInfo));
            }
            else
            {
                return null;
            }
        }
        catch
        {
            return null;
        }
    }

    public bool UpdateModelStatus(bool p_status, string m_id)
    {
        try
        {
            mdTba.UpdateStatus(
                                p_status,
                                m_id
                               );

            return true;
        }
        catch
        {
            return false;
        }
    }
}