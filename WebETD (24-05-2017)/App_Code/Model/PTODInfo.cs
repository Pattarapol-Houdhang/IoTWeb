using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PTODInfo
/// </summary>
public class PTODInfo
{
    private string pt_id;
    private string pro_id;
    private string model_id;
    private double pt_od1;
    private double pt_od2;
    private double pt_od3;
    private double judge_od_val;
    private string judge_od_rank;
    private double pt_roundness1;
    private double pt_roundness2;
    private double pt_roundness3;
    private double judge_roundness;
    private double judge_cylindric;
    private double judge_perpen;
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

    public double Judge_perpen
    {
        get { return judge_perpen; }
        set { judge_perpen = value; }
    }

    public double Judge_cylindric
    {
        get { return judge_cylindric; }
        set { judge_cylindric = value; }
    }

    public double Judge_roundness
    {
        get { return judge_roundness; }
        set { judge_roundness = value; }
    }

    public double Pt_roundness3
    {
        get { return pt_roundness3; }
        set { pt_roundness3 = value; }
    }

    public double Pt_roundness2
    {
        get { return pt_roundness2; }
        set { pt_roundness2 = value; }
    }

    public double Pt_roundness1
    {
        get { return pt_roundness1; }
        set { pt_roundness1 = value; }
    }

    public double Judge_od_val
    {
        get { return judge_od_val; }
        set { judge_od_val = value; }
    }

    public string Judge_od_rank
    {
        get { return judge_od_rank; }
        set { judge_od_rank = value; }
    }

    public double Pt_od3
    {
        get { return pt_od3; }
        set { pt_od3 = value; }
    }

    public double Pt_od2
    {
        get { return pt_od2; }
        set { pt_od2 = value; }
    }

    public double Pt_od1
    {
        get { return pt_od1; }
        set { pt_od1 = value; }
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