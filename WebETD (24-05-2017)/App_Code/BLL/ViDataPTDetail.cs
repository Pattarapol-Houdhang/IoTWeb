using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViDataPTDetail
/// </summary>
public class ViDataPTDetail
{
    vi_ptTableAdapter ptTba;
    vi_hit_pt_blTableAdapter blTba;
    vi_hit_pt_heiTableAdapter heiTba;
    vi_hit_pt_idTableAdapter idTba;
    vi_hit_pt_odTableAdapter odTba;

	public ViDataPTDetail()
	{
		ptTba = new vi_ptTableAdapter();
        blTba = new vi_hit_pt_blTableAdapter();
        heiTba = new vi_hit_pt_heiTableAdapter();
        idTba = new vi_hit_pt_idTableAdapter();
        odTba = new vi_hit_pt_odTableAdapter();
	}

    public DataTable getAllDataPT(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            ptTba.Connection.ConnectionString = conStr;
            DataTable tb = ptTba.GetAllDataByDateTimes(_startdate, _enddate);
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

    public DataTable getDataID(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            idTba.Connection.ConnectionString = conStr;
            DataTable tb = idTba.GetDataIDByDateTimes(_startdate, _enddate);
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

    public DataTable getDataOD(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            odTba.Connection.ConnectionString = conStr;
            DataTable tb = odTba.GetDataODByDateTimes(_startdate, _enddate);
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

    public DataTable getDataBlade(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            blTba.Connection.ConnectionString = conStr;
            DataTable tb = blTba.GetDataBladeByDateTimes(_startdate, _enddate);
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