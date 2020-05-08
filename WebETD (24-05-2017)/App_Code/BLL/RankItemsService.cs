using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

public class RankItemsService
{
    private etd_mst_rankTableAdapter rTba;

	public RankItemsService()
    {
        rTba = new etd_mst_rankTableAdapter();
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
        if (t == typeof(RankItemsInfo))
        {
            RankItemsInfo item = new RankItemsInfo();
            DataSet.etd_mst_rankRow dr = (DataSet.etd_mst_rankRow)r;


            item.R_id = dr.r_id;
            item.R_name = dr.r_name;
            item.R_color = dr.r_color;

            return item;
        }
        return null;
    }

    public ArrayList SearchAllRankItems(){

        DataTable tb = rTba.GetAllRankData();

        if (tb.Rows.Count > 0) {
            return DataTableToObjects(tb, typeof(RankItemsInfo));
        }
        else
        {
            return null;
        }
    }

    public RankItemsInfo SearchRankByID(int id)
    {
        try
        {
            DataTable tb = rTba.GetDataByRankID(id);
            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return (RankItemsInfo)DataRowToObject(dr, typeof(RankItemsInfo));
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

    public bool InsertRankItem(RankItemsInfo rank)
    {
        try
        {
            rTba.InsertNewRank(rank.R_name, rank.R_color);
            return true;
           
        }
        catch {
            return false;
        }
    }

    public bool DeleteRankByID(int id) {
        try
        {
            rTba.DeleteRankByID(id);
            return true;
        }
        catch { 
            return false; 
        }
    }

    public bool UpdateRankByID(RankItemsInfo rank) {
        try
        {
            rTba.UpdateRankColorByID(rank.R_name, rank.R_color, rank.R_id);
            return true;
        }
        catch {
            return false;
        }
    }
}