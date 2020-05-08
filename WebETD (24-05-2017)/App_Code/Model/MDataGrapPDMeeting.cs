using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDataGrapPDMeeting
/// </summary>
public class MDataGrapPDMeeting
{
	public MDataGrapPDMeeting()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int? PlanD { get; set; }
    public int? ActualD { get; set; }
    public int? PlanN { get; set; }
    public int? ActualN { get; set; }
    public int? Target { get; set; }

    public decimal? Achieve { get; set; }
    public decimal? AchieveD { get; set; }
    public decimal? AchieveN { get; set; }
    public string Day { get; set; }
    public string Month { get; set; }
    public string Rmk1 { get; set; }
    public string Rmk2 { get; set; }
    public string Rmk3 { get; set; }
}