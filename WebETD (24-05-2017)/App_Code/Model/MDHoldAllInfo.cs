using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDCostBudgetInfo
/// </summary>
public class MDHoldAllInfo
{
    public MDHoldAllInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public class HoldAllChartInfo
    {
        public HoldAllChartInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public decimal? dataFGHold { get; set; }
        public decimal? dataLineOut { get; set; }
        public decimal? dataM121 { get; set; }
        public decimal? dataM444 { get; set; }
        public decimal? dataM442 { get; set; }
        public decimal? dataResult { get; set; }
        public int? dataPrdActual { get; set; }
        public decimal? dataPrdPerUnit { get; set; }
        public decimal? dataPrdPerUnitTarget { get; set; }
        public decimal? dataSaleAmount { get; set; }
        public decimal? dataSaleExpRatio { get; set; }
        public string dataCostCenter { get; set; }
        public string dataYearMonth { get; set; }
        public string[] arrySeries { get; set; }
        public decimal[] SeriesValue { get; set; }
        public string Prd_Model6 { get; set; }
        public string Prd_Model7 { get; set; }
        public string Prd_Model8 { get; set; }

    }


}