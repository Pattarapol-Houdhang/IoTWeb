using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViCSDetail
/// </summary>
public class ViDataCSDetail
{
    vi_csTableAdapter csTba;
    vi_hit_cs_eccTableAdapter eccTba;
    vi_hit_cs_frontTableAdapter froTba;
    vi_hit_cs_pinTableAdapter pinTba;
    vi_hit_cs_rearTableAdapter reaTba;
    
    vi_cs_line3TableAdapter cs3Tba;
    vi_hit_cs_ecc_line3TableAdapter ecc3Tba;
    vi_hit_cs_pin_line3TableAdapter pin3Tba;

	public ViDataCSDetail()
	{
        csTba = new vi_csTableAdapter();
        eccTba = new vi_hit_cs_eccTableAdapter();
        froTba = new vi_hit_cs_frontTableAdapter();
        pinTba = new vi_hit_cs_pinTableAdapter();
        reaTba = new vi_hit_cs_rearTableAdapter();

        cs3Tba = new vi_cs_line3TableAdapter();
        ecc3Tba = new vi_hit_cs_ecc_line3TableAdapter();
        pin3Tba = new vi_hit_cs_pin_line3TableAdapter();
	}

    public DataTable getAllDataCS(DateTime _startdate, DateTime _enddate, string conStr, string line)
    {
        try
        {
            csTba.Connection.ConnectionString = conStr;
            DataTable tb = new DataTable();
            if (line == "line3")
            {
                tb = cs3Tba.GetAllDataByDateTimes(_startdate, _enddate);
            }
            else
            {
                tb = csTba.GetAllDataByDateTimes(_startdate, _enddate);
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

    public DataTable getDataFOD(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            froTba.Connection.ConnectionString = conStr;
            DataTable tb = froTba.GetDataFODByDateTimes(_startdate, _enddate);
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

    public DataTable getDataROD(DateTime _startdate, DateTime _enddate, string conStr)
    {
        try
        {
            reaTba.Connection.ConnectionString = conStr;
            DataTable tb = reaTba.GetDataRODByDateTimes(_startdate, _enddate);
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

    public DataTable getDataPinOD(DateTime _startdate, DateTime _enddate, string conStr, string line)
    {
        try
        {
            pinTba.Connection.ConnectionString = conStr;
            DataTable tb = new DataTable();
            if (line == "line3")
            {
                tb = pin3Tba.GetDataPinByDateTimes(_startdate, _enddate);
            }
            else
            {
                tb = pinTba.GetDataPinByDateTimes(_startdate, _enddate);
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

    public DataTable getDataECC(DateTime _startdate, DateTime _enddate, string conStr, string line)
    {
        try
        {
            eccTba.Connection.ConnectionString = conStr;
            DataTable tb = new DataTable();
            if (line == "line3")
            {
                tb = ecc3Tba.GetDataECCByDateTimes(_startdate, _enddate);
            }
            else
            {
                tb = eccTba.GetDataECCByDateTimes(_startdate, _enddate);
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
}