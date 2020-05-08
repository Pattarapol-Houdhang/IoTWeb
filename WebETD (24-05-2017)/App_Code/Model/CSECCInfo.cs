using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSECCInfo
{
    private string cs_id;
    private string pro_id;
    private string model_id;
    private double ecc_rank;
    private string ecc_rank_c;
    private string eccJudgeRank;
    private DateTime ecc_datetime;

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

    public DateTime Ecc_datetime
    {
        get { return ecc_datetime; }
        set { ecc_datetime = value; }
    }

    public string EccJudgeRank
    {
        get { return eccJudgeRank; }
        set { eccJudgeRank = value; }
    }

    public string Cs_id
    {
        get { return cs_id; }
        set { cs_id = value; }
    }

    public double Ecc_rank
    {
        get { return ecc_rank; }
        set { ecc_rank = value; }
    }

    public string Ecc_rank_c
    {
        get { return ecc_rank_c; }
        set { ecc_rank_c = value; }
    }
}
