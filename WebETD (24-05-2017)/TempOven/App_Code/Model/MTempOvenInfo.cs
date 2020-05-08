using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MEnergyInfo
/// </summary>
public class MTempOvenInfo
{
    public MTempOvenInfo()
    {
        //
        // TODO: Add constructor logic here
        //
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        CostKwh = 0;
        CostWater = 0;
        CostGas = 0;
        TempValue = 0;
        IDCH = 0;
        Temp1 = 0;
        Temp2 = 0;
        Temp3 = 0;
        Temp4 = 0;
        Temp5 = 0;
        Temp6 = 0;
        Temp7 = 0;
        Temp8 = 0;
        Temp9 = 0;
        Temp10 = 0;
        Temp11 = 0;
        Temp12 = 0;
        DTemp1 = 0;

    }

    public string Date { get; set; }
    public decimal? CostKwh { get; set; }
    public decimal? CostKwhTarget { get; set; }
    public double? CostWater { get; set; }
    public double? CostGas { get; set; }
    public double? TempValue { get; set; }
    public double? Temp1{ get; set; }
    public double? DTemp1 { get; set; }
    public double? Temp2 { get; set; }
    public double? Temp3 { get; set; }
    public double? Temp4 { get; set; }
    public double? Temp5 { get; set; }
    public double? Temp6 { get; set; }
    public double? Temp7 { get; set; }
    public double? Temp8 { get; set; }
    public double? Temp9 { get; set; }
    public double? Temp10 { get; set; }
    public double? Temp11{ get; set; }
    public double? Temp12{ get; set; }
    public int? IDCH { get; set; }

}