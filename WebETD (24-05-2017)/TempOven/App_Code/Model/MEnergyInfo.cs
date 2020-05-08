using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MEnergyInfo
/// </summary>
public class MEnergyInfo
{
    public MEnergyInfo()
    {
        //
        // TODO: Add constructor logic here
        //
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        CostKwh = 0;
        CostWater = 0;
        CostGas = 0;
    }

    public string Date { get; set; }
    public decimal? CostKwh { get; set; }
    public decimal? CostKwhTarget { get; set; }
    public double? CostWater { get; set; }
    public double? CostGas { get; set; }
}