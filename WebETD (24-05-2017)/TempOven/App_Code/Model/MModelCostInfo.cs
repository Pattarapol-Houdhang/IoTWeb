﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MModelCostInfo
/// </summary>
public class MModelCostInfo
{
    public MModelCostInfo()
    {
        //
        // TODO: Add constructor logic here
        //
        CostTotal = 0;
    }

    public string Date { get; set; }
    public double? CostCTSP { get; set; }
    public double? CostMP { get; set; }
    public double? CostMaterail { get; set; }
    public double? CostEnergy { get; set; }
    public double? CostTotal { get; set; }
    public double? CostMachine { get; set; }
    public double Average { get; set; }
    public double Accumulate { get; set; }
    public double Target { get; set; }

}