using DataSetTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OffsetMasterService
/// </summary>
public class OffsetMasterService
{
    etd_offset_detailTableAdapter offTba;
	public OffsetMasterService()
	{
		offTba = new etd_offset_detailTableAdapter();
	}

    private ArrayList DataTableToObjects(DataTable tb, Type t)
    {
        ArrayList ls = new ArrayList();
        if (tb.Rows != null)
        {
            foreach (DataRow item in tb.Rows)
            {
                object ob = DataRowToObject(item, t);
                ls.Add(ob);
            }
        }
        return ls;
    }

    private object DataRowToObject(DataRow r, Type t)
    {
        if (t == typeof(OffsetMasterInfo))
        {
            OffsetMasterInfo item = new OffsetMasterInfo();
            DataSet.etd_offset_detailRow dr = (DataSet.etd_offset_detailRow)r;


            item.Model_id = dr.m_id;
            item.Part_id = dr.p_id;
            item.PartType_id = dr.pt_id;
            item.Offset_id = dr.of_id;
            item.Offset_point = dr.of_point;
            item.Offset_value = (dr.of_val * 1000);
            item.Offset_user = dr.of_user;

            return item;
        }
        return null;
    }

    public bool CheckMasterIDNotInDB(string mst_id)
    {
        try
        {
            DataTable tb = offTba.GetDataByOffsetID(mst_id);
            if (tb.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    public bool InsertOffsetData(OffsetMasterInfo mstInfo)
    {
        try
        {
            offTba.InsertOffsetData(mstInfo.Model_id, mstInfo.Part_id, mstInfo.PartType_id,
                                    mstInfo.Offset_id, mstInfo.Offset_point,
                                    (mstInfo.Offset_value/1000), DateTime.Now, mstInfo.Offset_user);
            
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool InsertOffsetDataLow(OffsetMasterInfo mstInfo)
    {
        try
        {
            int partID = Convert.ToInt16(mstInfo.Part_id);

            if (partID != 6)
            {
                offTba.InsertOffsetData(mstInfo.Model_id, (partID + 5).ToString(), mstInfo.PartType_id,
                                        mstInfo.Offset_id, mstInfo.Offset_point,
                                        (mstInfo.Offset_value / 1000), DateTime.Now, mstInfo.Offset_user);
            }
            else
            {
                offTba.InsertOffsetData(mstInfo.Model_id, (partID + 3).ToString(), mstInfo.PartType_id,
                                        mstInfo.Offset_id, mstInfo.Offset_point,
                                        (mstInfo.Offset_value / 1000), DateTime.Now, mstInfo.Offset_user);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateOffsetData(OffsetMasterInfo mstInfo, int _point)
    {
        try
        {
            offTba.UpdateOffsetData(
                                    (mstInfo.Offset_value / 1000), DateTime.Now, mstInfo.Offset_user,
                                    mstInfo.Model_id, mstInfo.Part_id, mstInfo.PartType_id,
                                    mstInfo.Offset_id, _point);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool UpdateOffsetDataLow(OffsetMasterInfo mstInfo, int _point)
    {
        try
        {
            int partID = Convert.ToInt16(mstInfo.Part_id);

            if (partID != 6)
            {
                offTba.UpdateOffsetData(
                                        (mstInfo.Offset_value / 1000), DateTime.Now, mstInfo.Offset_user,
                                        mstInfo.Model_id, (partID + 5).ToString(), mstInfo.PartType_id,
                                        mstInfo.Offset_id, _point);
            }
            else
            {
                offTba.UpdateOffsetData(
                                        (mstInfo.Offset_value / 1000), DateTime.Now, mstInfo.Offset_user,
                                        mstInfo.Model_id, (partID + 3).ToString(), mstInfo.PartType_id,
                                        mstInfo.Offset_id, _point);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    public ArrayList SelectOffsetData(string offset_id, string model_no, string part_id, string partType_id)
    {
        try
        {
            DataTable tb = offTba.GetOffsetMasterDataDataByAllID(model_no, part_id, partType_id, offset_id);

            if (tb.Rows.Count > 0)
            {
                DataRow dr = tb.Rows[0];
                return DataTableToObjects(tb, typeof(OffsetMasterInfo));
            }
            else
            {
                return null;
            }
        }
        catch
        {
            return null;
        }
    }

    public bool DeleteOffsetData(string offset_id, string model_no, string part_id, string partType_id)
    {
        try
        {
            offTba.DeleteOffsetData(model_no, part_id, partType_id, offset_id);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteOffsetDataLow(string offset_id, string model_no, string part_id, string partType_id)
    {
        try
        {
            int partID = Convert.ToInt16(part_id);

            if (partID != 6)
            {
                offTba.DeleteOffsetData(model_no, (partID + 5).ToString(), partType_id, offset_id);
            }
            else
            {
                offTba.DeleteOffsetData(model_no, (partID + 3).ToString(), partType_id, offset_id);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}