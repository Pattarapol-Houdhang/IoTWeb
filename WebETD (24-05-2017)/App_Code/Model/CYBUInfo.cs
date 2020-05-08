using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CYBUInfo
/// </summary>
public class CYBUInfo
{
    string cy_id;
    string program_id;
    string model_id;
    double cy_bu1;
    double cy_bu2;
    double cy_bu3;
    double cy_bu_rank;
    string cy_bu_rank_char;
    double cy_bu_roundness1;
    double cy_bu_roundness2;
    double cy_bu_roundness3;
    double cy_bu_judge_roundness;
    double cy_bu_perpen;
    string cy_bu_judgement;
    DateTime cy_bu_date;

    public DateTime Cy_bu_date
    {
        get { return cy_bu_date; }
        set { cy_bu_date = value; }
    }

    public string Cy_bu_judgement
    {
        get { return cy_bu_judgement; }
        set { cy_bu_judgement = value; }
    }

    public double Cy_bu_perpen
    {
        get { return cy_bu_perpen; }
        set { cy_bu_perpen = value; }
    }

    public double Cy_bu_judge_roundness
    {
        get { return cy_bu_judge_roundness; }
        set { cy_bu_judge_roundness = value; }
    }

    public double Cy_bu_roundness3
    {
        get { return cy_bu_roundness3; }
        set { cy_bu_roundness3 = value; }
    }

    public double Cy_bu_roundness2
    {
        get { return cy_bu_roundness2; }
        set { cy_bu_roundness2 = value; }
    }

    public double Cy_bu_roundness1
    {
        get { return cy_bu_roundness1; }
        set { cy_bu_roundness1 = value; }
    }

    public string Cy_bu_rank_char
    {
        get { return cy_bu_rank_char; }
        set { cy_bu_rank_char = value; }
    }

    public double Cy_bu_rank
    {
        get { return cy_bu_rank; }
        set { cy_bu_rank = value; }
    }

    public double Cy_bu3
    {
        get { return cy_bu3; }
        set { cy_bu3 = value; }
    }

    public double Cy_bu2
    {
        get { return cy_bu2; }
        set { cy_bu2 = value; }
    }

    public double Cy_bu1
    {
        get { return cy_bu1; }
        set { cy_bu1 = value; }
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

    public string Cy_id
    {
        get { return cy_id; }
        set { cy_id = value; }
    }
}