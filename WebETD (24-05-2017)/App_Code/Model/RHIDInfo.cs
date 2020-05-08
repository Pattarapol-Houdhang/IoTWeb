using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RHIDInfo
/// </summary>
public class RHIDInfo
{
    string rh_id;
    string program_id;
    string model_id;
    double rh_id1;
    double rh_id2;
    double rh_id3;
    double judge_id_val;
    string rh_rank_char;
    double rh_roundness1;
    double rh_roundness2;
    double rh_roundness3;
    double judge_roundness;
    double judge_cylindric;
    double judge_perpen;
    string rh_judgement;
    DateTime rh_date;

    public DateTime Rh_date
    {
        get { return rh_date; }
        set { rh_date = value; }
    }

    public string Rh_judgement
    {
        get { return rh_judgement; }
        set { rh_judgement = value; }
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

    public double Rh_roundness3
    {
        get { return rh_roundness3; }
        set { rh_roundness3 = value; }
    }

    public double Rh_roundness2
    {
        get { return rh_roundness2; }
        set { rh_roundness2 = value; }
    }

    public double Rh_roundness1
    {
        get { return rh_roundness1; }
        set { rh_roundness1 = value; }
    }

    public string Rh_rank_char
    {
        get { return rh_rank_char; }
        set { rh_rank_char = value; }
    }

    public double Judge_id_val
    {
        get { return judge_id_val; }
        set { judge_id_val = value; }
    }

    public double Rh_id3
    {
        get { return rh_id3; }
        set { rh_id3 = value; }
    }

    public double Rh_id2
    {
        get { return rh_id2; }
        set { rh_id2 = value; }
    }

    public double Rh_id1
    {
        get { return rh_id1; }
        set { rh_id1 = value; }
    }

    public string Model_id
    {
        get { return model_id; }
        set { model_id = value; }
    }

    public string Program_id
    {
        get { return program_id; }
        set { program_id = value; }
    }

    public string Rh_id
    {
        get { return rh_id; }
        set { rh_id = value; }
    }
}