using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDCostBudgetInfo
/// </summary>
public class MDCostBudgetInfo
{
    public MDCostBudgetInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public class ExpenseChartInfo
    {
        public ExpenseChartInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public decimal? dataExpense { get; set; }
        public decimal? dataResult { get; set; }
        public int? dataPrdActual { get; set; }
        public decimal? dataPrdPerUnit { get; set; }
        public decimal? dataPrdPerUnitTarget { get; set; }
        public decimal? dataSaleAmount { get; set; }
        public decimal? dataSaleExpRatio { get; set; }
        public string dataCostCenter { get; set; }
        public string dataYearMonth { get; set; }

    }


}