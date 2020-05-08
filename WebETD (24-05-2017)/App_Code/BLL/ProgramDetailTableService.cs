using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProgramDetailTableService
/// </summary>
public class ProgramDetailTableService
{
    etd_program_detailTableAdapter pTba;
	public ProgramDetailTableService()
	{
        pTba = new etd_program_detailTableAdapter();
	}

    public bool InsertNewProgramDetail(string m_id)
    {
        try
        {
            pTba.InsertNewProgramDetail(m_id);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool CheckModelIDByModelID(string m_id)
    {
        try
        {
            DataTable tb = pTba.GetCheckModelIDByModelID(m_id);
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

    public bool UpdateProIDByEditPro(string m_id, string pro_id)
    {
        try
        {
            pTba.UpdateProgramDetail(Convert.ToInt32(pro_id), m_id);
            return true;
            
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateProIDToNull(string m_id)
    {
        try
        {
            pTba.UpdateProgramDetailToNull(m_id);
            return true;

        }
        catch
        {
            return false;
        }
    }



    public bool DeleteModelID(string m_id)
    {
        try
        {
            pTba.Delete(m_id);

            return true;
        }
        catch
        {
            return false;
        }
    }

}