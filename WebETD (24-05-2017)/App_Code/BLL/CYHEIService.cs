using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CYHEIService
/// </summary>
public class CYHEIService
{
    vi_web_cyheiTableAdapter cyheiTba;
	public CYHEIService()
	{
        cyheiTba = new vi_web_cyheiTableAdapter();
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
        if (t == typeof(CYHEIInfo))
        {
            CYHEIInfo item = new CYHEIInfo();
            DataSet.vi_web_cyheiRow dr = (DataSet.vi_web_cyheiRow)r;

            item.Cy_id = dr.cy_id;
            item.Program_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Cy_height1 = dr.cy_he1;
            item.Cy_height2 = dr.cy_he2;
            item.Cy_height3 = dr.cy_he3;
            item.Cy_height4 = dr.cy_he4;
            item.Judge_hei_val = dr.cy_he_rank;
            item.Cy_height_rank_char = dr.cy_he_rank_c;
            item.Judge_parallism = dr.cy_he_parallism;
            item.Cy_height_judgement = dr.cy_he_judgement;
            item.Cy_height_date = dr.cy_he_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetCYHEIData(DateTime startDate, DateTime endDate, string conStr)
    {
        cyheiTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = cyheiTba.GetCYHEIDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CYHEIInfo));
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

    public ArrayList GetCYHEIData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        cyheiTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = cyheiTba.GetCYHEIDataByModelDateTime(modelID, startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CYHEIInfo));
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