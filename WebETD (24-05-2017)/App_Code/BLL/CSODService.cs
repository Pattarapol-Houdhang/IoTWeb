using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CSODService
/// </summary>
public class CSODService
{
    vi_web_csodTableAdapter viCSOD;
	public CSODService()
	{
        viCSOD = new vi_web_csodTableAdapter();
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
        if (t == typeof(CSODInfo))
        {
            CSODInfo item = new CSODInfo();
            DataSet.vi_web_csodRow dr = (DataSet.vi_web_csodRow)r;

            item.Cs_id = dr.cs_id;
            item.Pro_id = dr.pro_id;
            item.Model_id = dr.m_id;
            item.Fr_judgeRank1 = dr.cs_fr_od1;
            item.Fr_judgeRank2 = dr.cs_fr_od2;
            item.Fr_judgeRank3 = dr.cs_fr_od3;
            item.Fr_judgeRank4 = dr.cs_fr_od4;
            item.Fr_judgeRank5 = dr.cs_fr_od5;
            item.Fr_judgeRank_f = dr.cs_fr_f_rank;
            item.Fr_judgeRank_fc = dr.cs_fr_f_rank_c;
            item.Fr_judgeRank_r = dr.cs_fr_r_rank;
            item.Fr_judgeRank_rc = dr.cs_fr_r_rank_c;
            item.Fr_judgeRoundness1 = dr.cs_fr_roundness1;
            item.Fr_judgeRoundness2 = dr.cs_fr_roundness2;
            item.Fr_judgeRoundness3 = dr.cs_fr_roundness3;
            item.Fr_judgeRoundness4 = dr.cs_fr_roundness4;
            item.Fr_judgeRoundness5 = dr.cs_fr_roundness5;
            item.Fr_judgeRoundness_f = dr.cs_fr_f_judge_roundness;
            item.Fr_judgeRoundness_r = dr.cs_fr_r_judge_roundness;
            item.Fr_judgeCylindricity_f = dr.cs_fr_f_cylindricity;
            item.Fr_judgeCylindricity_r = dr.cs_fr_r_cylindricity;
            item.Fr_judgement = dr.cs_fr_judgement;
            item.Fr_datetime = dr.cs_fr_date;

            return item;
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetCSODData(DateTime startDate, DateTime endDate, string conStr)
    {
        viCSOD.Connection.ConnectionString = conStr;
        DataTable dt = viCSOD.GetCSODDataByDateTime(startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(CSODInfo));
        }
        else
        {
            return null;
        }
    }

    public ArrayList GetCSODData(string modelID, DateTime startDate, DateTime endDate, string conStr)
    {
        viCSOD.Connection.ConnectionString = conStr;
        DataTable dt = viCSOD.GetCSODDataByModelDateTime(modelID, startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return DataTableToObjects(dt, typeof(CSODInfo));
        }
        else
        {
            return null;
        }
    }
}