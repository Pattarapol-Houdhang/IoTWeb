﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MCTSPInfo
/// </summary>
public class MCTSPInfo
{
    public MCTSPInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Date { get; set; }
    public string LDate1 { get; set; }
    public string LDate2 { get; set; }

    public decimal? CostDay { get; set; }

    public decimal? Cost { get; set; }
    public decimal? LCost1 { get; set; }
    public decimal? LCost2 { get; set; }
    public decimal? CostUnit { get; set; }
}