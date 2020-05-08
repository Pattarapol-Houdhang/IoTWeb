using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CSPINInfo
{
    private string cs_id;
    private string pro_id;
    private string model_id;
    private double pin_od1;
    private double pin_od2;
    private double pin_od3;
    private double pin_rank;
    private string pin_rank_c;
    private double pin_Roundness1;
    private double pin_Roundness2;
    private double pin_Roundness3;
    private double pin_Roundness;
    private double pin_Cylindricity;
    private string pin_Judgement;
    private DateTime pin_datetime;

    public string Cs_id
    {
        get { return cs_id; }
        set { cs_id = value; }
    }

    public string Pro_id
    {
        get { return pro_id; }
        set { pro_id = value; }
    }

    public string Model_id
    {
        get { return model_id; }
        set { model_id = value; }
    }

    public double Pin_od1
    {
        get { return pin_od1; }
        set { pin_od1 = value; }
    }

    public double Pin_od2
    {
        get { return pin_od2; }
        set { pin_od2 = value; }
    }

    public double Pin_od3
    {
        get { return pin_od3; }
        set { pin_od3 = value; }
    }

    public double Pin_rank
    {
        get { return pin_rank; }
        set { pin_rank = value; }
    }

    public string Pin_rank_c
    {
        get { return pin_rank_c; }
        set { pin_rank_c = value; }
    }

    public double Pin_Roundness1
    {
        get { return pin_Roundness1; }
        set { pin_Roundness1 = value; }
    }

    public double Pin_Roundness2
    {
        get { return pin_Roundness2; }
        set { pin_Roundness2 = value; }
    }

    public double Pin_Roundness3
    {
        get { return pin_Roundness3; }
        set { pin_Roundness3 = value; }
    }

    public double Pin_Roundness
    {
        get { return pin_Roundness; }
        set { pin_Roundness = value; }
    }

    public double Pin_Cylindricity
    {
        get { return pin_Cylindricity; }
        set { pin_Cylindricity = value; }
    }

    public string Pin_Judgement
    {
        get { return pin_Judgement; }
        set { pin_Judgement = value; }
    }

    public DateTime Pin_datetime
    {
        get { return pin_datetime; }
        set { pin_datetime = value; }
    }

}
