using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MCompressorModelCost
/// </summary>
public class MCompressorModelCost
{
    public MCompressorModelCost()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Catagory { get; set; }
    public decimal ActualModel1 { get; set; }
    public decimal ActualModel2 { get; set; }
    public decimal ActualModel3 { get; set; }
    public string Model1 { get; set; }
    public string Model2 { get; set; }
    public string Model3 { get; set; }
    public decimal? CostUnit1 { get; set; }
    public decimal? CostUnit2 { get; set; }
    public decimal? CostUnit3 { get; set; }
    public decimal? Cost1 { get; set; }
    public decimal? Cost2 { get; set; }
    public decimal? Cost3 { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? Average { get; set; }
    public decimal? Target { get; set; }

}