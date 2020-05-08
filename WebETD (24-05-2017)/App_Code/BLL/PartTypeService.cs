using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PartTypeService
/// </summary>
public class PartTypeService
{
    private etd_mst_part_typeTableAdapter ptTba;

	public PartTypeService()
	{
        ptTba = new etd_mst_part_typeTableAdapter();
	}

    public string GetPartTypeIDByNameType(string _nameType)
    {
        try
        {
            DataTable tb = ptTba.GetPartTypeDataByNameType(_nameType);

            if (tb.Rows.Count > 0)
            {
                return tb.Rows[0][0].ToString();
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
}