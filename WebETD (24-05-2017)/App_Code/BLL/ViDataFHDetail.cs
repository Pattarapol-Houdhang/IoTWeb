using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViDataFHDetail
/// </summary>
public class ViDataFHDetail
{
    vi_fhTableAdapter fhTba;
    vi_hit_fh_flTableAdapter flTba;
    vi_hit_fh_idTableAdapter idTba;

    vi_fh_line3TableAdapter fh3Tba;

	public ViDataFHDetail()
	{
        fhTba = new vi_fhTableAdapter();
        flTba = new vi_hit_fh_flTableAdapter();
        idTba = new vi_hit_fh_idTableAdapter();

        fh3Tba = new vi_fh_line3TableAdapter();
	}

    public DataTable getAllDataFH(DateTime _startdate, DateTime _enddate, string conStr, string line)
    {
        try
        {
            fhTba.Connection.ConnectionString = conStr;
            DataTable tb = new DataTable();
            if (line == "line3")
            {
                tb = fh3Tba.GetAllDataByDateTimes(_startdate, _enddate);
            }
            else
            {
                tb = fhTba.GetAllDataByDateTimes(_startdate, _enddate);
            }
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

    public DataTable getDataID(DateTime _startdate, DateTime _enddate, string conStr, string line)
    {
        try
        {
            idTba.Connection.ConnectionString = conStr;
            DataTable tb = new DataTable();
            if (line == "line3")
            {
                tb = fh3Tba.GetAllDataByDateTimes(_startdate, _enddate);
            }
            else
            {
                tb = idTba.GetDataIDByDateTimes(_startdate, _enddate);
            }
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