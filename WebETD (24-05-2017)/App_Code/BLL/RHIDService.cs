using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RHIDService
/// </summary>
public class RHIDService
{
	vi_web_rhidTableAdapter rhidTba;
	public RHIDService()
	{
        rhidTba = new vi_web_rhidTableAdapter();
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
        if (t == typeof(RHIDInfo))
        {
            RHIDInfo item = new RHIDInfo();
            DataSet.vi_web_rhidRow dr = (DataSet.vi_web_rhidRow)r;

            item.Rh_id = dr.rh_id;
            item.Program_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Rh_id1 = dr.rh_id1;
            item.Rh_id2 = dr.rh_id2;
            item.Rh_id3 = dr.rh_id3;
            item.Judge_id_val = dr.rh_rank;
            item.Rh_rank_char = dr.rh_rank_c;
            item.Rh_roundness1 = dr.rh_roundness1;
            item.Rh_roundness2 = dr.rh_roundness2;
            item.Rh_roundness3 = dr.rh_roundness3;
            item.Judge_roundness = dr.rh_judge_roundness;
            item.Judge_cylindric = dr.rh_cylindricity;
            item.Judge_perpen = dr.rh_perpendicularity;
            item.Rh_judgement = dr.rh_judgement;
            item.Rh_date = dr.rh_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetRHIDData(DateTime startDate, DateTime endDate, string conStr)
    {
        rhidTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = rhidTba.GetRHIDDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(RHIDInfo));
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

    public ArrayList GetRHIDData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        rhidTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = rhidTba.GetRHIDDataByModelDateTime(modelID, startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(RHIDInfo));
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
}