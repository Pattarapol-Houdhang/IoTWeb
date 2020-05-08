using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CYHEIInfo
/// </summary>
public class CYHEIInfo
{
    string cy_id;
    string program_id;
    string model_id;
    double cy_height1;
    double cy_height2;
    double cy_height3;
    double cy_height4;
    double judge_hei_val;
    string cy_height_rank_char;
    double judge_parallism;
    string cy_height_judgement;
    DateTime cy_height_date;

    public DateTime Cy_height_date
    {
        get { return cy_height_date; }
        set { cy_height_date = value; }
    }

    public string Cy_height_judgement
    {
        get { return cy_height_judgement; }
        set { cy_height_judgement = value; }
    }

    public double Judge_parallism
    {
        get { return judge_parallism; }
        set { judge_parallism = value; }
    }

    public string Cy_height_rank_char
    {
        get { return cy_height_rank_char; }
        set { cy_height_rank_char = value; }
    }

    public double Judge_hei_val
    {
        get { return judge_hei_val; }
        set { judge_hei_val = value; }
    }

    public double Cy_height4
    {
        get { return cy_height4; }
        set { cy_height4 = value; }
    }

    public double Cy_height3
    {
        get { return cy_height3; }
        set { cy_height3 = value; }
    }

    public double Cy_height2
    {
        get { return cy_height2; }
        set { cy_height2 = value; }
    }

    public double Cy_height1
    {
        get { return cy_height1; }
        set { cy_height1 = value; }
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