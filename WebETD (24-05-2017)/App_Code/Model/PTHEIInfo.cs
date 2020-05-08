using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PTHEIInfo
/// </summary>
public class PTHEIInfo
{
    private string pt_id;
    private string pro_id;
    private string model_id;
    private double pt_hei1;
    private double pt_hei2;
    private double pt_hei3;
    private double pt_hei4;
    private double judge_hei_val;
    private string judge_hei_rank;
    private double judge_parallism;
    private string pt_judgement;
    private DateTime pt_date;

    public DateTime Pt_date
    {
        get { return pt_date; }
        set { pt_date = value; }
    }

    public string Pt_judgement
    {
        get { return pt_judgement; }
        set { pt_judgement = value; }
    }

    public double Judge_parallism
    {
        get { return judge_parallism; }
        set { judge_parallism = value; }
    }

    public string Judge_hei_rank
    {
        get { return judge_hei_rank; }
        set { judge_hei_rank = value; }
    }

    public double Judge_hei_val
    {
        get { return judge_hei_val; }
        set { judge_hei_val = value; }
    }

    public double Pt_hei4
    {
        get { return pt_hei4; }
        set { pt_hei4 = value; }
    }

    public double Pt_hei3
    {
        get { return pt_hei3; }
        set { pt_hei3 = value; }
    }

    public double Pt_hei2
    {
        get { return pt_hei2; }
        set { pt_hei2 = value; }
    }

    public double Pt_hei1
    {
        get { return pt_hei1; }
        set { pt_hei1 = value; }
    }

    public string Model_id
    {
        get { return model_id; }
        set { model_id = value; }
    }

    public string Pro_id
    {
        get { return pro_id; }
        set { pro_id = value; }
    }

    public string Pt_id
    {
        get { return pt_id; }
        set { pt_id = value; }
    }
}