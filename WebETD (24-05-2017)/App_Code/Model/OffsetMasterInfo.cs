using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OffsetMasterInfo
/// </summary>
public class OffsetMasterInfo
{
	public OffsetMasterInfo()
	{
	}

    private string model_id;
    private string part_id;
    private string partType_id;
    private string offset_id;
    private int offset_point;
    private double offset_value;
    private string offset_user;

    public string Offset_user
    {
        get { return offset_user; }
        set { offset_user = value; }
    }

    public double Offset_value
    {
        get { return offset_value; }
        set { offset_value = value; }
    }


    public int Offset_point
    {
        get { return offset_point; }
        set { offset_point = value; }
    }

    public string Offset_id
    {
        get { return offset_id; }
        set { offset_id = value; }
    }

    public string PartType_id
    {
        get { return partType_id; }
        set { partType_id = value; }
    }

    public string Part_id
    {
        get { return part_id; }
        set { part_id = value; }
    }

    public string Model_id
    {
        get { return model_id; }
        set { model_id = value; }
    }
}