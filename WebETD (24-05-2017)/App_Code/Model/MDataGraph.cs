using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDataGraph
/// </summary>
public class MDataGraph
{
	public MDataGraph()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int target = 0;
    public int Target
    {
        get { return target; }
        set { target = value; }
    }

    private double totalmilli = 0;
    public double Totalmilli
    {
        get { return totalmilli; }
        set { totalmilli = value; }
    }

    private string datePlan = DateTime.Now.ToString();
    public string DatePlan
    {
        get { return datePlan; }
        set { datePlan = value; }
    }

    private int? planAccu = 0;
    public int? PlanAccu
    {
        get { return planAccu; }
        set { planAccu = value; }
    }

    private int? actualAccu = 0;
    public int? ActualAccu
    {
        get { return actualAccu; }
        set { actualAccu = value; }
    }

    private decimal? effiAccu = 0;
    public decimal? EffiAccu
    {
        get { return effiAccu; }
        set { effiAccu = value; }
    }
}