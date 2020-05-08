using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MMaterail
/// </summary>
public class MMaterail
{
    public MMaterail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public decimal? StandCostUnit { get; set; }
    public string Date { get; set; }
    public decimal? CostUnit { get; set; } //---------------- Actual Cost/Unit -------------------
    public decimal? Usage { get; set; }
    public string ModelName1 { get; set; }
    public string ModelName2 { get; set; }
    public string ModelName3 { get; set; }
    public string ModelName4 { get; set; }
    public decimal? Model1 { get; set; }
    public decimal? Model2 { get; set; }
    public decimal? Model3 { get; set; }
    public decimal? Model4 { get; set; }
    public decimal? ModelPD1 { get; set; }
    public decimal? ModelPD2 { get; set; }
    public decimal? ModelPD3 { get; set; }
    public decimal? ModelPD4 { get; set; }
    public int? actualOK { get; set; }
    public int? actualNG { get; set; }

}