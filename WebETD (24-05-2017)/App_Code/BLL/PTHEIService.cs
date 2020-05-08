using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PTHEIService
/// </summary>
public class PTHEIService
{
    vi_web_ptheiTableAdapter ptheiTba;
	public PTHEIService()
	{
        ptheiTba = new vi_web_ptheiTableAdapter();
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
        if (t == typeof(PTHEIInfo))
        {
            PTHEIInfo item = new PTHEIInfo();
            DataSet.vi_web_ptheiRow dr = (DataSet.vi_web_ptheiRow)r;

            item.Pt_id = dr.pt_id;
            item.Pro_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Pt_hei1 = dr.pt_he1;
            item.Pt_hei2 = dr.pt_he2;
            item.Pt_hei3 = dr.pt_he3;
            item.Pt_hei4 = dr.pt_he4;
            item.Judge_hei_val = dr.pt_he_rank;
            item.Judge_hei_rank = dr.pt_he_rank_c;
            item.Judge_parallism = dr.pt_he_parallism;
            item.Pt_judgement = dr.pt_he_judgement;
            item.Pt_date = dr.pt_he_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetPTHEIData(DateTime startDate, DateTime endDate, string conStr)
    {
        ptheiTba.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = ptheiTba.GetPTHEIDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(PTHEIInfo));
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

    public ArrayList GetPTHEIData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        ptheiTba.Connection.ConnectionString = conStr;
        DataTable dt = ptheiTba.GetPTHEIDataByModelDateTime(modelID, startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(PTHEIInfo));
        }
        else
        {
            return null;
        }
    }
}