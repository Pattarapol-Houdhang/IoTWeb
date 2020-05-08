using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class RankItemsInfo
{
	public RankItemsInfo()
	{
	}

    private int r_id;
    private string r_name;
    private string r_color;

    public string R_color
    {
        get { return r_color; }
        set { r_color = value; }
    }

    public string R_name
    {
        get { return r_name; }
        set { r_name = value; }
    }

    public int R_id
    {
        get { return r_id; }
        set { r_id = value; }
    }
    
}