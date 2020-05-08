using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PTIDService
/// </summary>
public class PTIDService
{
    vi_web_ptidTableAdapter ptidTba;
	public PTIDService()
	{
        ptidTba = new vi_web_ptidTableAdapter();
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
        if (t == typeof(PTIDInfo))
        {
            PTIDInfo item = new PTIDInfo();
            DataSet.vi_web_ptidRow dr = (DataSet.vi_web_ptidRow)r;

            item.Pt_id = dr.pt_id;
            item.Pro_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Pt_id1 = dr.pt_id1;
            item.Pt_id2 = dr.pt_id2;
            item.Pt_id3 = dr.pt_id3;
            item.Judge_id_val = dr.pt_id_rank;
            item.Judge_id_rank = dr.pt_id_rank_c;
            item.Pt_roundness1 = dr.pt_id_roundness1;
            item.Pt_roundness2 = dr.pt_id_roundness2;
            item.Pt_roundness3 = dr.pt_id_roundness3;
            item.Judge_roundness = dr.pt_id_roundness;
            item.Judge_cylindric = dr.pt_id_cylindricity;
            item.Judge_perpen = dr.pt_id_perpendicularity;
            item.Pt_judgement = dr.pt_id_judgement;
            item.Pt_date = dr.pt_id_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetPTIDData(DateTime startDate, DateTime endDate, string conStr)
    {
        ptidTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = ptidTba.GetPTIDDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(PTIDInfo));
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

    public ArrayList GetPTIDData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        ptidTba.Connection.ConnectionString = conStr;
        DataTable dt = ptidTba.GetPTIDDataByModelDateTime(modelID, startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(PTIDInfo));
        }
        else
        {
            return null;
        }
    }
}