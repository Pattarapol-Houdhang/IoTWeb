using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CYBOInfo
/// </summary>
public class CYBOInfo
{
    string cy_id;
    string program_id;
    string model_id;
    double cy_bo1;
    double cy_bo2;
    double cy_bo3;
    double cy_bo_rank;
    string cy_bo_rank_char;
    double cy_bo_roundness1;
    double cy_bo_roundness2;
    double cy_bo_roundness3;
    double cy_bo_judge_roundness;
    double cy_bo_cylindricity;
    double cy_bo_perpen;
    double cy_bo_concentric;
    string cy_bo_judgement;
    DateTime cy_bo_date;

    public DateTime Cy_bo_date
    {
        get { return cy_bo_date; }
        set { cy_bo_date = value; }
    }

    public string Cy_bo_judgement
    {
        get { return cy_bo_judgement; }
        set { cy_bo_judgement = value; }
    }

    public double Cy_bo_concentric
    {
        get { return cy_bo_concentric; }
        set { cy_bo_concentric = value; }
    }

    public double Cy_bo_perpen
    {
        get { return cy_bo_perpen; }
        set { cy_bo_perpen = value; }
    }

    public double Cy_bo_cylindricity
    {
        get { return cy_bo_cylindricity; }
        set { cy_bo_cylindricity = value; }
    }

    public double Cy_bo_judge_roundness
    {
        get { return cy_bo_judge_roundness; }
        set { cy_bo_judge_roundness = value; }
    }

    public double Cy_bo_roundness3
    {
        get { return cy_bo_roundness3; }
        set { cy_bo_roundness3 = value; }
    }

    public double Cy_bo_roundness2
    {
        get { return cy_bo_roundness2; }
        set { cy_bo_roundness2 = value; }
    }

    public double Cy_bo_roundness1
    {
        get { return cy_bo_roundness1; }
        set { cy_bo_roundness1 = value; }
    }

    public string Cy_bo_rank_char
    {
        get { return cy_bo_rank_char; }
        set { cy_bo_rank_char = value; }
    }

    public double Cy_bo_rank
    {
        get { return cy_bo_rank; }
        set { cy_bo_rank = value; }
    }

    public double Cy_bo3
    {
        get { return cy_bo3; }
        set { cy_bo3 = value; }
    }

    public double Cy_bo2
    {
        get { return cy_bo2; }
        set { cy_bo2 = value; }
    }

    public double Cy_bo1
    {
        get { return cy_bo1; }
        set { cy_bo1 = value; }
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