using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MManpowerInfo
/// </summary>
public class MManpowerInfo
{
    public MManpowerInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string DateDay { get; set; }
    public decimal? CostDay { get; set; }
    public decimal? CostUnitDay { get; set; }
    public decimal? AccuDay { get; set; }
    public decimal? AvgDay { get; set; }

    public string DateMonth { get; set; }
    public decimal? CostMonth { get; set; }
    public decimal? CostUnitMonth { get; set; }
    public decimal? AccuMonth { get; set; }
    public decimal? AvgMonth { get; set; }
}