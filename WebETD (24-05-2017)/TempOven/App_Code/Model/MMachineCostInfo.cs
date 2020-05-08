using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MMachineCostInfo
/// </summary>
public class MMachineCostInfo
{
    public MMachineCostInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Catagory { get; set; }
    public double? CostUnit { get; set; }
    public double? Target { get; set; }
    public double? Average { get; set; }

}