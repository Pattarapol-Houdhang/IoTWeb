using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CSECCService
/// </summary>
public class CSECCService
{
    vi_web_cseccTableAdapter viCSECC;
	public CSECCService()
	{
        viCSECC = new vi_web_cseccTableAdapter();
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
        if (t == typeof(CSECCInfo))
        {
            CSECCInfo item = new CSECCInfo();
            DataSet.vi_web_cseccRow dr = (DataSet.vi_web_cseccRow)r;

            item.Cs_id = dr.cs_id;
            item.Pro_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Ecc_rank = dr.cs_ecc_rank;
            item.Ecc_rank_c = dr.cs_ecc_rank_c;
            item.EccJudgeRank = dr.cs_ecc_judgement;
            item.Ecc_datetime = dr.cs_ecc_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetCSECCData(DateTime startDate, DateTime endDate, string conStr)
    {
        viCSECC.Connection.ConnectionString = conStr;
        try
        {
            DataTable dt = viCSECC.GetCSECCDataByDateTime(startDate, endDate);
            if (dt.Rows.Count > 0)
            {
                return DataTableToObjects(dt, typeof(CSECCInfo));
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

    public ArrayList GetCSECCData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        viCSECC.Connection.ConnectionString = conStr;
        DataTable dt = viCSECC.GetCSECCDataByModelDateTime(modelID, startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(CSECCInfo));
        }
        else
        {
            return null;
        }
    }
}