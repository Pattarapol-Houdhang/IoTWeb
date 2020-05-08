using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FHIDService
/// </summary>
public class FHIDService
{
    vi_web_fhidTableAdapter fhidTba;
	public FHIDService()
	{
        fhidTba = new vi_web_fhidTableAdapter();
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
        if (t == typeof(FHIDInfo))
        {
            FHIDInfo item = new FHIDInfo();
            DataSet.vi_web_fhidRow dr = (DataSet.vi_web_fhidRow)r;

            item.Fh_id = dr.fh_id;
            item.Program_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Fh_id1 = dr.fh_id1;
            item.Fh_id2 = dr.fh_id2;
            item.Fh_id3 = dr.fh_id3;
            item.Judge_id_val = dr.fh_rank;
            item.Fh_rank_char = dr.fh_rank_c;
            item.Fh_roundness1 = dr.fh_roundness1;
            item.Fh_roundness2 = dr.fh_roundness2;
            item.Fh_roundness3 = dr.fh_ronudness3;
            item.Judge_roundness = dr.fh_judge_roundness;
            item.Judge_cylindric = dr.fh_cylindricity;
            item.Judge_perpen = dr.fh_perpendicularity;
            item.Fh_judgement = dr.fh_judgement;
            item.Fh_date = dr.fh_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetFHIDData(DateTime startDate, DateTime endDate, string conStr)
    {
        fhidTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = fhidTba.GetFHIDDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(FHIDInfo));
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

    public ArrayList GetFHIDData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        fhidTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = fhidTba.GetFHIDDataByModelDateTime(modelID, startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(FHIDInfo));
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