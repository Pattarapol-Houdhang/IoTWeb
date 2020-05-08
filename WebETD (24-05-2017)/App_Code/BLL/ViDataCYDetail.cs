using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViCYDataDetail
/// </summary>
public class ViDataCYDetail
{
    vi_cyTableAdapter cyTba;
    vi_hit_cy_boTableAdapter boTba;
    vi_hit_cy_buTableAdapter buTba;
    vi_hit_cy_heiTableAdapter heiTba;

	public ViDataCYDetail()
	{
        cyTba = new vi_cyTableAdapter();
        boTba = new vi_hit_cy_boTableAdapter();
        buTba = new vi_hit_cy_buTableAdapter();
        heiTba = new vi_hit_cy_heiTableAdapter();
	}

    public DataTable getAllDataCY(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            cyTba.Connection.ConnectionString = conStr;
            DataTable tb = cyTba.GetAllDataByDateTimes(_startdate, _enddate);
            if (tb.Rows.Count > 0)
            {
                return tb;
            }
            else return null;
        }
        catch
        {
            return null;
        }
    }

    public DataTable getDataIDBore(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            boTba.Connection.ConnectionString = conStr;
            DataTable tb = boTba.GetDataIDBoreByDateTimes(_startdate, _enddate);
            if (tb.Rows.Count > 0)
            {
                return tb;
            }
            else return null;
        }
        catch
        {
            return null;
        }
    }

    public DataTable getDataIDBush(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            buTba.Connection.ConnectionString = conStr;
            DataTable tb = buTba.GetDataIDBushByDateTimes(_startdate, _enddate);
            if (tb.Rows.Count > 0)
            {
                return tb;
            }
            else return null;
        }
        catch
        {
            return null;
        }
    }

    public DataTable getDataHeight(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            heiTba.Connection.ConnectionString = conStr;
            DataTable tb = heiTba.GetDataHeightByDateTimes(_startdate, _enddate);
            if (tb.Rows.Count > 0)
            {
                return tb;
            }
            else return null;
        }
        catch
        {
            return null;
        }
    }

}