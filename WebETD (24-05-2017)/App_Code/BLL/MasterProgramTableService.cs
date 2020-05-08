using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterProgramTableService
/// </summary>
public class MasterProgramTableService
{
    etd_mst_programTableAdapter pTba;
	public MasterProgramTableService()
	{
        pTba = new etd_mst_programTableAdapter();
	}

    public bool InsertNewMstProgram(string pro_name)
    {
        try
        {
            pTba.InsertNewMstProgram(pro_name);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool GetCheckProName(string pro_name)
    {
        try
        {
            DataTable tb = pTba.GetCheckProName(pro_name);
            if (tb.Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }
        catch
        {
            return false;
        }
    }

    public object GetProID(string pro_name)
    {
        try
        {
            DataTable tb = pTba.GetCheckProName(pro_name);
            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0];
            }
            else return null;
        }
        catch
        {
            return null;
        }
    }

    public bool UpdateNameMstProgram(string pro_name, int p_id)
    {
        try
        {
            pTba.UpdateNameMstProgram(pro_name, p_id);

            return true;
        }
        catch
        {
            return false;
        }
    }

}