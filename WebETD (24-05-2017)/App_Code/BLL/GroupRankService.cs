using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GroupRankService
/// </summary>
public class GroupRankService
{

    private etd_group_rankTableAdapter grTba;

	public GroupRankService()
	{
        grTba = new etd_group_rankTableAdapter();
	}

    public bool InsertNewGroup(string g_id, string g_dataID, string g_data) {
        try
        {

            grTba.InsertNewGroupRank(g_id, g_dataID, g_data);
            return true;
        }
        catch { return false; }
    }

    public DataTable SelectAllGroupData() {
        try
        {
            DataTable tb = grTba.GetData();
            if (tb.Rows.Count > 0) {
                return tb;
            }
            else { return null; }
        }
        catch { return null; }
    }

    public bool DeleteGroup(string id) {
        try
        {
            grTba.DeleteGroupByID(id);
            return true;
        }
        catch { return false; }
    }

    public bool UpdateGroupData(string g_id, string g_dataID, string g_data)
    {
        try
        {
            grTba.UpdateGroupRank(g_dataID, g_data, g_id);
            return true;
        }
        catch { return false; }
    }

    public DataTable SelectGroupDataByID(string g_id) {

        try
        {
            DataTable tb = grTba.GetDataByGroupID(g_id);
            if (tb.Rows.Count > 0)
            {
                return tb;
            }
            else { return null; }

        }
        catch { return null; }
    }

}