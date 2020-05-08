using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProgramDetail
/// </summary>
public class ProgramDetailService
{
    vi_program_detailTableAdapter pTba;
    public ProgramDetailService()
	{
        pTba = new vi_program_detailTableAdapter();
	}
    public DataTable GetModelDetailByProID(int _pid)
    {
        try
        {
            return pTba.GetModelDetailByProID(_pid);
        }
        catch
        {
            return null;
        }
    }
    public DataTable GetModelDetailByStatus()
    {
        try
        {
            return pTba.GetModelDetailByStatus();
        }
        catch
        {
            return null;
        }
    }
}