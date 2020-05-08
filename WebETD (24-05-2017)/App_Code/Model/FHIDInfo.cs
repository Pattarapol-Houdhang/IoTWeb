using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FHIDInfo
/// </summary>
public class FHIDInfo
{
    string fh_id;
    string program_id;
    string model_id;
    double fh_id1;
    double fh_id2;
    double fh_id3;
    double judge_id_val;
    string fh_rank_char;
    double fh_roundness1;
    double fh_roundness2;
    double fh_roundness3;
    double judge_roundness;
    double judge_cylindric;
    double judge_perpen;
    string fh_judgement;
    DateTime fh_date;

    public DateTime Fh_date
    {
        get { return fh_date; }
        set { fh_date = value; }
    }

    public string Fh_judgement
    {
        get { return fh_judgement; }
        set { fh_judgement = value; }
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

    public double Fh_roundness3
    {
        get { return fh_roundness3; }
        set { fh_roundness3 = value; }
    }

    public double Fh_roundness2
    {
        get { return fh_roundness2; }
        set { fh_roundness2 = value; }
    }

    public double Fh_roundness1
    {
        get { return fh_roundness1; }
        set { fh_roundness1 = value; }
    }

    public string Fh_rank_char
    {
        get { return fh_rank_char; }
        set { fh_rank_char = value; }
    }

    public double Judge_id_val
    {
        get { return judge_id_val; }
        set { judge_id_val = value; }
    }

    public double Fh_id3
    {
        get { return fh_id3; }
        set { fh_id3 = value; }
    }

    public double Fh_id2
    {
        get { return fh_id2; }
        set { fh_id2 = value; }
    }

    public double Fh_id1
    {
        get { return fh_id1; }
        set { fh_id1 = value; }
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

    public string Fh_id
    {
        get { return fh_id; }
        set { fh_id = value; }
    }
}