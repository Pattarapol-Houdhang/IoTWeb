using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PTODService
/// </summary>
public class PTODService
{
    vi_web_ptodTableAdapter ptodTba;
	public PTODService()
	{
        ptodTba = new vi_web_ptodTableAdapter();
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
        if (t == typeof(PTODInfo))
        {
            PTODInfo item = new PTODInfo();
            DataSet.vi_web_ptodRow dr = (DataSet.vi_web_ptodRow)r;

            item.Pt_id = dr.pt_id;
            item.Pro_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Pt_od1 = dr.pt_od1;
            item.Pt_od2 = dr.pt_od2;
            item.Pt_od3 = dr.pt_od3;
            item.Judge_od_val = dr.pt_od_rank;
            item.Judge_od_rank = dr.pt_od_rank_c;
            item.Pt_roundness1 = dr.pt_od_roundness1;
            item.Pt_roundness2 = dr.pt_od_roundness2;
            item.Pt_roundness3 = dr.pt_od_roundness3;
            item.Judge_roundness = dr.pt_od_judge_roundness;
            item.Judge_cylindric = dr.pt_od_cylindricity;
            item.Judge_perpen = dr.pt_od_perpendicularity;
            item.Pt_judgement = dr.pt_od_judgement;
            item.Pt_date = dr.pt_od_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetPTODData(DateTime startDate, DateTime endDate, string conStr)
    {
        ptodTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = ptodTba.GetPTODDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(PTODInfo));
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

    public ArrayList GetPTODData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        ptodTba.Connection.ConnectionString = conStr;
        DataTable dt = ptodTba.GetPTODDataByModelDateTime(modelID, startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(PTODInfo));
        }
        else
        {
            return null;
        }
    }

}