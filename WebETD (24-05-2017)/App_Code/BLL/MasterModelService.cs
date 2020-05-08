using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterModelService
/// </summary>
public class MasterModelService
{
    vi_model_statusTableAdapter mTba;
    private etd_mst_modelTableAdapter mmTba;
	public MasterModelService()
	{
        mTba = new vi_model_statusTableAdapter();
        mmTba = new etd_mst_modelTableAdapter();
	}

    public DataTable GetMstModelDataByKeyword(string keyword)
    {
        try
        {
            return mTba.GetMstModelDataByKeyword("%" + keyword + "%");
        }
        catch
        {
            return null;
        }
    }

    public bool InsertModelDetail(ModelDetailInfo mdInfo)
    {
        try
        {
            mmTba.InsertMstDetail(
                                  mdInfo.Model_id, 
                                  mdInfo.Model_name, 
                                  mdInfo.User_edit
                                  );
            return true;
        }
        catch
        {
            return false;
        }
    }
}