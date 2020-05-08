using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PTBLInfo
/// </summary>
public class PTBLInfo
{
    private string pt_id;
    private string pro_id;
    private string model_id;
    private double pt_bl1;
    private double pt_bl2;
    private double pt_bl3;
    private double pt_bl4;
    private double pt_bl5;
    private double pt_bl6;
    private double judge_bl_val;
    private string judge_bl_rank;
    private double judge_parallism;
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

    public double Judge_parallism
    {
        get { return judge_parallism; }
        set { judge_parallism = value; }
    }

    public string Judge_bl_rank
    {
        get { return judge_bl_rank; }
        set { judge_bl_rank = value; }
    }

    public double Judge_bl_val
    {
        get { return judge_bl_val; }
        set { judge_bl_val = value; }
    }

    public double Pt_bl6
    {
        get { return pt_bl6; }
        set { pt_bl6 = value; }
    }

    public double Pt_bl5
    {
        get { return pt_bl5; }
        set { pt_bl5 = value; }
    }

    public double Pt_bl4
    {
        get { return pt_bl4; }
        set { pt_bl4 = value; }
    }

    public double Pt_bl3
    {
        get { return pt_bl3; }
        set { pt_bl3 = value; }
    }

    public double Pt_bl2
    {
        get { return pt_bl2; }
        set { pt_bl2 = value; }
    }

    public double Pt_bl1
    {
        get { return pt_bl1; }
        set { pt_bl1 = value; }
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