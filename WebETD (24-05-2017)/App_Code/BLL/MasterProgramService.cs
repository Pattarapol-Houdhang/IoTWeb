using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterProgramService
/// </summary>
public class MasterProgramService
{
    vi_program_modelTableAdapter proTba;
    public MasterProgramService()
	{
		proTba = new vi_program_modelTableAdapter();
	}

    public DataTable GetMstProgramDataByKeyword(string keyword)
    {
        try
        {
            return proTba.GetMstProgramDataByKeyword("%" + keyword + "%");
        }
        catch
        {
            return null;
        }
    }
}