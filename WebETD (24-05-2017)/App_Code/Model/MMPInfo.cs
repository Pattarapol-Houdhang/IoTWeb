using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class MMPInfo
{
       public MMPInfo ()
       {
        //
        // TODO: Add constructor logic here
        //
      }
 
      public class MPAllChartInfo
    {
        public MPAllChartInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }
   
      

   

    public int CountLoop { get; set; }
    public string MC_Name { get; set; }
    public double? MC_MPD { get; set; }
    public double? MC_MPN { get; set; }    
    public double? MCACTD { get; set; }
    public double? MCACTN { get; set; }      

    public string dataCostCenter { get; set; }
    public string DatetoDay { get; set; }
    public int Xdate { get; set; }
    public string dataYearMonth { get; set; }

    public double? CostUnit { get; set; }
    public double? AccumCostUnit { get; set; }

    public double? BudgetCost { get; set; }
    public double? OverAllSum { get; set; }
    public double? SumPrd { get; set; }
    public double? Prd { get; set; }
    public double? OT1 { get; set; }
    public double? OT15 { get; set; }
    public double? OT2 { get; set; }
    public double? OT3 { get; set; }
    public double? SumOT { get; set; }


    public string OPPosition { get; set; }
    public double? OPOT1 { get; set; }
    public double? OPOT15 { get; set; }
    public double? OPOT2 { get; set; }
    public double? OPOT3 { get; set; }
    public double? OPSumOT { get; set; }

    public string LEPosition { get; set; }
    public double? LEOT1 { get; set; }
    public double? LEOT15 { get; set; }
    public double? LEOT2 { get; set; }
    public double? LEOT3 { get; set; }
    public double? LESumOT { get; set; }
 
    public string FOPosition { get; set; }
    public double? FOOT1 { get; set; }
    public double? FOOT15 { get; set; }
    public double? FOOT2 { get; set; }
    public double? FOOT3 { get; set; }
    public double? FOSumOT { get; set; }

    public string SUPosition { get; set; }
    public double? SUOT1 { get; set; }
    public double? SUOT15 { get; set; }
    public double? SUOT2 { get; set; }
    public double? SUOT3 { get; set; }
    public double? SUSumOT { get; set; }

    public double? SumMP { get; set; }
    public double? SumMP_ACTD { get; set; }
    public double? SumMP_ACTN { get; set; }
    public double? SumLED { get; set; }
    public double? SumLEN { get; set; }

    public double? SumFOD { get; set; }
    public double? SumFON { get; set; }

    public double? SumMPD { get; set; }
    public double? SumMPN{ get; set; }
    public double? SumMP_DIFFD { get; set; }
    public double? SumMP_DIFFN { get; set; }
    public double? SumMPH{ get; set; }

    public double? SumOT_ReqD { get; set; }
    public double? SumOT_ReqN { get; set; }
    public double? SumOT_ActD { get; set; }
    public double? SumOT_ActN { get; set; }


    public double? MP_SHIFT { get; set; }
    public double? SumMP_ACT { get; set; }


      }

}