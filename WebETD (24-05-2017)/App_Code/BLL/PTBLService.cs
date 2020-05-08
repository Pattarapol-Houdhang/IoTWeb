using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PTBLService
/// </summary>
public class PTBLService
{
    vi_web_ptblTableAdapter ptblTba;
	public PTBLService()
	{
        ptblTba = new vi_web_ptblTableAdapter();
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
        if (t == typeof(PTBLInfo))
        {
            PTBLInfo item = new PTBLInfo();
            DataSet.vi_web_ptblRow dr = (DataSet.vi_web_ptblRow)r;

            item.Pt_id = dr.pt_id;
            item.Pro_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Pt_bl1 = dr.pt_bl1;
            item.Pt_bl2 = dr.pt_bl2;
            item.Pt_bl3 = dr.pt_bl3;
            item.Pt_bl4 = dr.pt_bl4;
            item.Pt_bl5 = dr.pt_bl5;
            item.Pt_bl6 = dr.pt_bl6;
            item.Judge_bl_val = dr.pt_bl_rank;
            item.Judge_bl_rank = dr.pt_bl_rank_c;
            item.Judge_parallism = dr.pt_bl_parallism;
            item.Judge_perpen = dr.pt_bl_perpendicularity;
            item.Pt_judgement = dr.pt_bl_judgement;
            item.Pt_date = dr.pt_bl_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetPTBLData(DateTime startDate, DateTime endDate, string conStr)
    {
        ptblTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = ptblTba.GetPTBLDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(PTBLInfo));
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

    public ArrayList GetPTBLData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        ptblTba.Connection.ConnectionString = conStr;
        DataTable dt = ptblTba.GetPTBLDataByModelDateTime(modelID, startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(PTBLInfo));
        }
        else
        {
            return null;
        }
    }
}