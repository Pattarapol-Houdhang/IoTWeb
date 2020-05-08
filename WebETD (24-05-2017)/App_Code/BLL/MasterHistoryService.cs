using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterHistoryService
/// </summary>
public class MasterHistoryService
{
    etd_mst_historyTableAdapter hisTba;
	public MasterHistoryService()
	{
        hisTba = new etd_mst_historyTableAdapter();
	}

    public bool InsertMasterHistory(string master_id, string _user)
    {
        try
        {
            hisTba.InsertMasterHistory(master_id, _user);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateMasterHistory(string master_id, string _user, string _reason)
    {
        try
        {
            hisTba.UpdateMasterHistoryAfterDel(_user, _reason, master_id);

            return true;
        }
        catch
        {
            return false;
        }
    }
}