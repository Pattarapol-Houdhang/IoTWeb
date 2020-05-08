using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterListService
/// </summary>
public class MasterListService
{
    vi_masterTableAdapter mst;
	
    public MasterListService()
	{
        mst = new vi_masterTableAdapter();
	}

    public DataTable GetMasterListByKeyWord(string _key ,string _model)
    {
        try
        {
            return mst.GetDataByKeyWord("%" + _key + "%", "%" + _model + "%");
        }
        catch
        {
            return null;
        }
    }
}