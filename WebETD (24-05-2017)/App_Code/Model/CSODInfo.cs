using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSODInfo
{
    private string cs_id;
    private string pro_id;
    private string model_id;
    private double fr_judgeRank1;
    private double fr_judgeRank2;
    private double fr_judgeRank3;
    private double fr_judgeRank4;
    private double fr_judgeRank5;
    private double fr_judgeRank_f;
    private string fr_judgeRank_fc;
    private double fr_judgeRank_r;
    private string fr_judgeRank_rc;
    private double fr_judgeRoundness1;
    private double fr_judgeRoundness2;
    private double fr_judgeRoundness3;
    private double fr_judgeRoundness4;
    private double fr_judgeRoundness5;
    private double fr_judgeRoundness_f;
    //private string fr_judgeRoundness_fc;
    private double fr_judgeRoundness_r;
    //private string fr_judgeRoundness_rc;
    private double fr_judgeCylindricity_f;
    private double fr_judgeCylindricity_r;
    private string fr_judgement;
    private DateTime fr_datetime;

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

    public DateTime Fr_datetime
    {
        get { return fr_datetime; }
        set { fr_datetime = value; }
    }

    public string Cs_id
    {
        get { return cs_id; }
        set { cs_id = value; }
    }

    public double Fr_judgeRank1
    {
        get { return fr_judgeRank1; }
        set { fr_judgeRank1 = value; }
    }

    public double Fr_judgeRank2
    {
        get { return fr_judgeRank2; }
        set { fr_judgeRank2 = value; }
    }

    public double Fr_judgeRank3
    {
        get { return fr_judgeRank3; }
        set { fr_judgeRank3 = value; }
    }

    public double Fr_judgeRank4
    {
        get { return fr_judgeRank4; }
        set { fr_judgeRank4 = value; }
    }

    public double Fr_judgeRank5
    {
        get { return fr_judgeRank5; }
        set { fr_judgeRank5 = value; }
    }

    public double Fr_judgeRank_f
    {
        get { return fr_judgeRank_f; }
        set { fr_judgeRank_f = value; }
    }

    public string Fr_judgeRank_fc
    {
        get { return fr_judgeRank_fc; }
        set { fr_judgeRank_fc = value; }
    }

    public double Fr_judgeRank_r
    {
        get { return fr_judgeRank_r; }
        set { fr_judgeRank_r = value; }
    }

    public string Fr_judgeRank_rc
    {
        get { return fr_judgeRank_rc; }
        set { fr_judgeRank_rc = value; }
    }

    public double Fr_judgeRoundness1
    {
        get { return fr_judgeRoundness1; }
        set { fr_judgeRoundness1 = value; }
    }

    public double Fr_judgeRoundness2
    {
        get { return fr_judgeRoundness2; }
        set { fr_judgeRoundness2 = value; }
    }

    public double Fr_judgeRoundness3
    {
        get { return fr_judgeRoundness3; }
        set { fr_judgeRoundness3 = value; }
    }

    public double Fr_judgeRoundness4
    {
        get { return fr_judgeRoundness4; }
        set { fr_judgeRoundness4 = value; }
    }

    public double Fr_judgeRoundness5
    {
        get { return fr_judgeRoundness5; }
        set { fr_judgeRoundness5 = value; }
    }

    public double Fr_judgeRoundness_f
    {
        get { return fr_judgeRoundness_f; }
        set { fr_judgeRoundness_f = value; }
    }

    //public string Fr_judgeRoundness_fc
    //{
    //    get { return fr_judgeRoundness_fc; }
    //    set { fr_judgeRoundness_fc = value; }
    //}

    public double Fr_judgeRoundness_r
    {
        get { return fr_judgeRoundness_r; }
        set { fr_judgeRoundness_r = value; }
    }

    //public string Fr_judgeRoundness_rc
    //{
    //    get { return fr_judgeRoundness_rc; }
    //    set { fr_judgeRoundness_rc = value; }
    //}

    public double Fr_judgeCylindricity_f
    {
        get { return fr_judgeCylindricity_f; }
        set { fr_judgeCylindricity_f = value; }
    }

    public double Fr_judgeCylindricity_r
    {
        get { return fr_judgeCylindricity_r; }
        set { fr_judgeCylindricity_r = value; }
    }

    public string Fr_judgement
    {
        get { return fr_judgement; }
        set { fr_judgement = value; }
    }
}
