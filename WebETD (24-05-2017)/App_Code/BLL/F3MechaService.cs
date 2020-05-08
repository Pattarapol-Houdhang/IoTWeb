using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for F3MechaService
/// </summary>
public class F3MechaService
{
    vi_crank_shaft_resultTableAdapter csTba;
    vi_cylinder_resultTableAdapter cyTba;
    vi_front_head_resultTableAdapter fhTba;
    vi_piston_resultTableAdapter ptTba;
    vi_rear_head_resultTableAdapter rhTba;
    mecha_matching_resultTableAdapter matTba;
    cylinder_centeringTableAdapter ccTba;
    rear_centeringTableAdapter rcTba;
    front_head_rivetingTableAdapter friTba;
    torque_checkTableAdapter torTba;

	public F3MechaService()
	{
        csTba = new vi_crank_shaft_resultTableAdapter();
        cyTba = new vi_cylinder_resultTableAdapter();
        fhTba = new vi_front_head_resultTableAdapter();
        ptTba = new vi_piston_resultTableAdapter();
        rhTba = new vi_rear_head_resultTableAdapter();
        matTba = new mecha_matching_resultTableAdapter();
        ccTba = new cylinder_centeringTableAdapter();
        rcTba = new rear_centeringTableAdapter();
        friTba = new front_head_rivetingTableAdapter();
        torTba = new torque_checkTableAdapter();

	}

    public DataTable getCSResultF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = csTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getCYResultF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = cyTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getFHResultF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = fhTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getMatchingData(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = matTba.GetMatchingDataByDateTimes(_startdate, _enddate);
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

    public DataTable getPTResultF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = ptTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getRHResultF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = rhTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getFHRivetingF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = friTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getRCenteringF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = rcTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getCYCenteringF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = ccTba.GetDataByDateTimes(_startdate, _enddate);
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

    public DataTable getTorqueF3(DateTime _startdate, DateTime _enddate)
    {
        try
        {
            DataTable tb = torTba.GetDataByDateTimes(_startdate, _enddate);
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