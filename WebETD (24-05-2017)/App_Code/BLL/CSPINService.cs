using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CSPINService
/// </summary>
public class CSPINService
{
    vi_web_cspinTableAdapter viCSPIN;
	public CSPINService()
	{
        viCSPIN = new vi_web_cspinTableAdapter();
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
        if (t == typeof(CSPINInfo))
        {
            CSPINInfo item = new CSPINInfo();
            DataSet.vi_web_cspinRow dr = (DataSet.vi_web_cspinRow)r;

            item.Cs_id = dr.cs_id;
            item.Pro_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Pin_od1 = dr.cs_pin_od1;
            item.Pin_od2 = dr.cs_pin_od2;
            item.Pin_od3 = dr.cs_pin_od3;
            item.Pin_rank = dr.cs_pin_rank;
            item.Pin_rank_c = dr.cs_pin_rank_c;
            item.Pin_Roundness1 = dr.cs_pin_roundness1;
            item.Pin_Roundness2 = dr.cs_pin_roundness2;
            item.Pin_Roundness3 = dr.cs_pin_roundness3;
            item.Pin_Roundness = dr.cs_pin_judge_roundness;
            item.Pin_Cylindricity = dr.cs_pin_cylindricity;
            item.Pin_Judgement = dr.cs_pin_judgement;
            item.Pin_datetime = dr.cs_pin_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetCSPINData(DateTime startDate, DateTime endDate, string conStr)
    {
        viCSPIN.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = viCSPIN.GetCSPINDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CSPINInfo));
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

    public ArrayList GetCSPINData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        viCSPIN.Connection.ConnectionString = conStr;
        DataTable dt = viCSPIN.GetCSPINDataByModelDateTime(modelID, startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(CSPINInfo));
        }
        else
        {
            return null;
        }
    }
}