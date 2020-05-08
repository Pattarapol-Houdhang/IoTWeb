using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSInfo
{
    private string cs_id;
    private string pro_id;
    private string cs_line;
    private int cs_position;
    private string cs_judgement;
    private DateTime cs_date;

    public DateTime Cs_date
    {
        get { return cs_date; }
        set { cs_date = value; }
    }

    public string Cs_judgement
    {
        get { return cs_judgement; }
        set { cs_judgement = value; }
    }

    public int Cs_position
    {
        get { return cs_position; }
        set { cs_position = value; }
    }

    public string Cs_line
    {
        get { return cs_line; }
        set { cs_line = value; }
    }

    public string Pro_id
    {
        get { return pro_id; }
        set { pro_id = value; }
    }

    public string Cs_id
    {
        get { return cs_id; }
        set { cs_id = value; }
    }
}