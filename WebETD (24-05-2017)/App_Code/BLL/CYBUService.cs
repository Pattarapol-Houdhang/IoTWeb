using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CYBUService
/// </summary>
public class CYBUService
{
	vi_web_cybuTableAdapter cybuTba;
	public CYBUService()
	{
        cybuTba = new vi_web_cybuTableAdapter();
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
        if (t == typeof(CYBUInfo))
        {
            CYBUInfo item = new CYBUInfo();
            DataSet.vi_web_cybuRow dr = (DataSet.vi_web_cybuRow)r;

            item.Cy_id = dr.cy_id;
            item.Program_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Cy_bu1 = dr.cy_bu1;
            item.Cy_bu2 = dr.cy_bu2;
            item.Cy_bu3 = dr.cy_bu3;
            item.Cy_bu_rank = dr.cy_bu_rank;
            item.Cy_bu_rank_char = dr.cy_bu_rank_c;
            item.Cy_bu_roundness1 = dr.cy_bu_roundness1;
            item.Cy_bu_roundness2 = dr.cy_bu_roundness2;
            item.Cy_bu_roundness3 = dr.cy_bu_roundness3;
            item.Cy_bu_judge_roundness = dr.cy_bu_judge_roundness;
            item.Cy_bu_perpen = dr.cy_bu_perpendicularity;
            item.Cy_bu_judgement = dr.cy_bu_judgement;
            item.Cy_bu_date = dr.cy_bu_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetCYBUData(DateTime startDate, DateTime endDate, string conStr)
    {
        cybuTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = cybuTba.GetCYBUDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CYBUInfo));
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

    public ArrayList GetCYBUData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        cybuTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = cybuTba.GetCYBUDataByModelDateTime(modelID, startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CYBUInfo));
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