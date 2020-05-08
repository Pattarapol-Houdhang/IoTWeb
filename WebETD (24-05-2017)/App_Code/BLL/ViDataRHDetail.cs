using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViDataRHDetail
/// </summary>
public class ViDataRHDetail
{
    vi_rhTableAdapter rhTba;
    vi_hit_rh_flTableAdapter flTba;
    vi_hit_rh_idTableAdapter idTba;

	public ViDataRHDetail()
	{
        rhTba = new vi_rhTableAdapter();
        idTba = new vi_hit_rh_idTableAdapter();
        flTba = new vi_hit_rh_flTableAdapter();
	}

    public DataTable getAllDataRH(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            rhTba.Connection.ConnectionString = conStr;
            DataTable tb = rhTba.GetAllDataByDateTimes(_startdate, _enddate);
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

    public DataTable getDataFL(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            flTba.Connection.ConnectionString = conStr;
            DataTable tb = flTba.GetDataFLByDateTimes(_startdate, _enddate);
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