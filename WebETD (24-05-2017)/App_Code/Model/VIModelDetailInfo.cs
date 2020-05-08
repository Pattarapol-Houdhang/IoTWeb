using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VIModelDetailInfo
/// </summary>
public class VIModelDetailInfo
{
	public VIModelDetailInfo()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string model_id;
    private string model_name;
    private string part_id;
    private string part_name;
    private string partType_id;
    private string partType_name;
    private double part_mid;
    private double part_max;
    private double part_min;
    private double part_cycletime;
    private string group_id;
    private string rank_id;
    private string rank_name;
    private string user_edit;
    private bool part_status;

    public string Rank_name
    {
        get { return rank_name; }
        set { rank_name = value; }
    }

    public string Group_id
    {
        get { return group_id; }
        set { group_id = value; }
    }

    public string PartType_name
    {
        get { return partType_name; }
        set { partType_name = value; }
    }

    public string Part_name
    {
        get { return part_name; }
        set { part_name = value; }
    }

    public string Model_name
    {
        get { return model_name; }
        set { model_name = value; }
    }

    public bool Part_status
    {
        get { return part_status; }
        set { part_status = value; }
    }

    public string User_edit
    {
        get { return user_edit; }
        set { user_edit = value; }
    }

    public double Part_cycletime
    {
        get { return part_cycletime; }
        set { part_cycletime = value; }
    }

    public double Part_min
    {
        get { return part_min; }
        set { part_min = value; }
    }

    public double Part_max
    {
        get { return part_max; }
        set { part_max = value; }
    }

    public double Part_mid
    {
        get { return part_mid; }
        set { part_mid = value; }
    }

    public string Rank_id
    {
        get { return rank_id; }
        set { rank_id = value; }
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