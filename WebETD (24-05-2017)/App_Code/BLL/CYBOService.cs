using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CYBOService
/// </summary>
public class CYBOService
{
    vi_web_cyboTableAdapter cyboTba;
	public CYBOService()
	{
        cyboTba = new vi_web_cyboTableAdapter();
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
        if (t == typeof(CYBOInfo))
        {
            CYBOInfo item = new CYBOInfo();
            DataSet.vi_web_cyboRow dr = (DataSet.vi_web_cyboRow)r;

            item.Cy_id = dr.cy_id;
            item.Program_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Cy_bo1 = dr.cy_bo1;
            item.Cy_bo2 = dr.cy_bo2;
            item.Cy_bo3 = dr.cy_bo3;
            item.Cy_bo_rank = dr.cy_bo_rank;
            item.Cy_bo_rank_char = dr.cy_bo_rank_c;
            item.Cy_bo_roundness1 = dr.cy_bo_roundness1;
            item.Cy_bo_roundness2 = dr.cy_bo_roundness2;
            item.Cy_bo_roundness3 = dr.cy_bo_roundness3;
            item.Cy_bo_judge_roundness = dr.cy_bo_judge_roundness;
            item.Cy_bo_cylindricity = dr.cy_bo_cylindricity;
            item.Cy_bo_perpen = dr.cy_bo_perpendicularity;
            item.Cy_bo_concentric = dr.cy_bo_concentricity;
            item.Cy_bo_judgement = dr.cy_bo_judgement;
            item.Cy_bo_date = dr.cy_bo_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetCYBOData(DateTime startDate, DateTime endDate, string conStr)
    {
        cyboTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = cyboTba.GetCYBODataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CYBOInfo));
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

    public ArrayList GetCYBOData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        cyboTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = cyboTba.GetCYBODataByModelDateTime(modelID, startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CYBOInfo));
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