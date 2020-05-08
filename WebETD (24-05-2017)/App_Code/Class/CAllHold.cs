using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for CCostBudget
/// </summary>
public class CAllHold
{
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
  

    public CAllHold()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public List<MDHoldAllInfo.HoldAllChartInfo> GetChartExpenseReport(DateTime _DataDate, string _Type)
    {

        List<MDHoldAllInfo.HoldAllChartInfo> oAryResult = new List<MDHoldAllInfo.HoldAllChartInfo>();

        string[] ArryPrd = { "1YC", "2YC", "SCR", "1YC/3", "ODM" };
        string[] ArryPrdALL = { "1101", "1102", "1201", "1202", "1301", "1302", "1401", "1402", "1501", "1701", "1702", "4310", "4320", "4510", "4720", "8120" };
        string[] ArryPrdFac1 = { "1101", "1102" };
        string[] ArryPrdFac1M = { "1101" };
        string[] ArryPrdFac1A = { "1102" };
        string[] ArryPrdFac2 = { "1201", "1202" };
        string[] ArryPrdFac2M = { "1201", "1202" };
        string[] ArryPrdFac2A = { "1201", "1202" };
        string[] ArryPrdSRC = { "1301", "1302" };
        string[] ArryPrdSRCA = { "1301" };
        string[] ArryPrdSRCM = { "1302" };
        string[] ArryPrdFac3 = { "1701", "1702" };
        string[] ArryPrdFac3M = { "1701" };
        string[] ArryPrdFac3A = { "1702" };
        string[] ArryPrdODM = { "1501" };
        string[] ArryPeriod = { "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "JAN", "FEB", "MAR" };
        int[] ArryMonth = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };


        string pAccGroup = "EXP";
        string pBudgetType = "DI";
        string pYear = _DataDate.ToString("yyyy");
        string pMonth = _DataDate.ToString("MM");
        DateTime _LastYear = new DateTime();
        DateTime _Last2Year = new DateTime();
        DateTime _Last3Year = new DateTime();
        _LastYear = _DataDate.AddYears(-1);
        _Last2Year = _DataDate.AddYears(-2);
        _Last3Year = _DataDate.AddYears(-3);
        string pLastYear = _LastYear.ToString("yyyy");
        string pLast2Year = _Last2Year.ToString("yyyy");
        string pLast3Year = _Last3Year.ToString("yyyy");
        string TxtModel = " ";

        #region init
        int _PrdActualLastYear = 0;
        int _PrdActualLast2Year = 0;
        int _PrdActualLast3Year = 0;
        decimal SumMayFGHold = 0;
        decimal SumMayLineOut = 0;
        decimal SumJunFGHold = 0;  
        decimal SumJulLineOut = 0;
        decimal SumJulFGHold = 0;  
        decimal SumJunLineOut = 0;
        decimal SumAugFGHold = 0;  
        decimal SumAugLineOut = 0;
        decimal SumSepFGHold = 0;  
        decimal SumSepLineOut = 0;
        decimal SumOctFGHold = 0;  
        decimal SumOctLineOut = 0;
        decimal SumNovFGHold = 0;  
        decimal SumNovLineOut = 0;
        decimal SumDecFGHold = 0;  
        decimal SumDecLineOut = 0;
        decimal SumJanFGHold = 0;  
        decimal SumJanLineOut = 0;
        decimal SumFebFGHold = 0;  
        decimal SumFebLineOut = 0;  
        decimal SumMarFGHold = 0;  
        decimal SumMarLineOut = 0;  
        decimal SumAprFGHold = 0;  
        decimal SumAprLineOut = 0;
     
   

        decimal _PrdTargetLastYear = 0;
        decimal _PrdTargetLast2Year = 0;
        decimal _PrdTargetLast3Year = 0;

        decimal _SaleAmountLastYear = 0;
        decimal _SaleAmountLast2Year = 0;
        decimal _SaleAmountLast3Year = 0;

        decimal _SaleExpRatioLastYear = 0;
        decimal _SaleExpRatioLast2Year = 0;
        decimal _SaleExpRatioLast3Year = 0;


        int[] _PrdActual = new int[12];

        string[] ArrySeires5 = new string[5];
        Decimal[] ArrySeiresValue5 = new Decimal[5];          
// May
        decimal _Model121LOPYear = 0;
        decimal _Model442LOPYear = 0;
        decimal _Model444LOPYear = 0;
        decimal _Model121FGPYear = 0;
        decimal _Model442FGPYear = 0;
        decimal _Model444FGPYear = 0;

// June
        decimal _Model121LOPJun = 0;
        decimal _Model442LOPJun = 0;
        decimal _Model444LOPJun = 0;
        decimal _Model121FGPJun = 0;
        decimal _Model442FGPJun = 0;
        decimal _Model444FGPJun = 0;

// July
        decimal _Model121LOPJul = 0;
        decimal _Model442LOPJul = 0;
        decimal _Model444LOPJul = 0;
        decimal _Model121FGPJul = 0;
        decimal _Model442FGPJul = 0;
        decimal _Model444FGPJul = 0;

// Aug
        decimal _Model121LOPAug = 0;
        decimal _Model442LOPAug = 0;
        decimal _Model444LOPAug = 0;
        decimal _Model121FGPAug = 0;
        decimal _Model442FGPAug = 0;
        decimal _Model444FGPAug = 0;

// Sep
        decimal _Model121LOPSep = 0;
        decimal _Model442LOPSep = 0;
        decimal _Model444LOPSep = 0;
        decimal _Model121FGPSep = 0;
        decimal _Model442FGPSep = 0;
        decimal _Model444FGPSep = 0;

// Oct
        decimal _Model121LOPOct = 0;
        decimal _Model442LOPOct = 0;
        decimal _Model444LOPOct = 0;
        decimal _Model121FGPOct = 0;
        decimal _Model442FGPOct = 0;
        decimal _Model444FGPOct = 0;


// Nov
        decimal _Model121LOPNov = 0;
        decimal _Model442LOPNov = 0;
        decimal _Model444LOPNov = 0;
        decimal _Model121FGPNov = 0;
        decimal _Model442FGPNov = 0;
        decimal _Model444FGPNov = 0;




// Dec
        decimal _Model121LOPDec = 0;
        decimal _Model442LOPDec = 0;
        decimal _Model444LOPDec = 0;
        decimal _Model121FGPDec = 0;
        decimal _Model442FGPDec = 0;
        decimal _Model444FGPDec = 0;


// Jan
        decimal _Model121LOPJan = 0;
        decimal _Model442LOPJan = 0;
        decimal _Model444LOPJan = 0;
        decimal _Model121FGPJan = 0;
        decimal _Model442FGPJan = 0;
        decimal _Model444FGPJan = 0;


// Feb
        decimal _Model121LOPFeb = 0;
        decimal _Model442LOPFeb = 0;
        decimal _Model444LOPFeb = 0;
        decimal _Model121FGPFeb = 0;
        decimal _Model442FGPFeb = 0;
        decimal _Model444FGPFeb = 0;


// Mar
        decimal _Model121LOPMar = 0;
        decimal _Model442LOPMar = 0;
        decimal _Model444LOPMar = 0;
        decimal _Model121FGPMar = 0;
        decimal _Model442FGPMar = 0;
        decimal _Model444FGPMar = 0;



 // Apr
        decimal _Model121LOPApr = 0;
        decimal _Model442LOPApr = 0;
        decimal _Model444LOPApr = 0;
        decimal _Model121FGPApr = 0;
        decimal _Model442FGPApr = 0;
        decimal _Model444FGPApr = 0;

         decimal _Model1LastYear = 0;
         decimal _Model2LastYear = 0;
         decimal _Model3LastYear = 0;

         decimal _Model1Last2Year = 0;
         decimal _Model2Last2Year = 0;
         decimal _Model3Last2Year = 0;

         decimal _Model1Last3Year = 0;
         decimal _Model2Last3Year = 0;
         decimal _Model3Last3Year = 0;

        decimal _InLastYear = 0;
        decimal _InLast2Year = 0;
        decimal _InLast3Year = 0;
      
        decimal _InAPRModel = 0;
        decimal _InAPR = 0;
       

        decimal _InMAYFG = 0;
        decimal _InMAYLO = 0;
        decimal _InJUNFG = 0;
        decimal _InJUNLO = 0;
        decimal _InJUlFG = 0;
        decimal _InJUlLO = 0;  
        decimal _InAUGFG = 0;
        decimal _InAUGLO = 0;       
        decimal _InSEPFG = 0;
        decimal _InSEPLO = 0;       
        decimal _InOCTFG = 0;
        decimal _InOCTLO = 0;       
        decimal _InNOVFG = 0;
        decimal _InNOVLO = 0;      
        decimal _InDECFG = 0;
        decimal _InDECLO = 0;    
        decimal _InJANFG = 0;
        decimal _InJANLO = 0;    
        decimal _InFEBFG = 0;
        decimal _InFEBLO = 0;    
        decimal _InMARFG = 0;
        decimal _InMARLO = 0;    
        decimal _InAPRFG = 0;
        decimal _InAPRLO = 0;    
     
   
        decimal _ResLastYear = 0;
        decimal _ResLast2Year = 0;
        decimal _ResLast3Year = 0;
        decimal _ResAPR = 0;
        decimal _ResMAY = 0;
        decimal _ResJUN = 0;
        decimal _ResJUL = 0;
        decimal _ResAUG = 0;
        decimal _ResSEP = 0;
        decimal _ResOCT = 0;
        decimal _ResNOV = 0;
        decimal _ResDEC = 0;
        decimal _ResJAN = 0;
        decimal _ResFEB = 0;
        decimal _ResMAR = 0;

        decimal _TargetAPR = 0;
        decimal _TargetMAY = 0;
        decimal _TargetJUN = 0;
        decimal _TargetJUL = 0;
        decimal _TargetAUG = 0;
        decimal _TargetSEP = 0;
        decimal _TargetOCT = 0;
        decimal _TargetNOV = 0;
        decimal _TargetDEC = 0;
        decimal _TargetJAN = 0;
        decimal _TargetFEB = 0;
        decimal _TargetMAR = 0;

        int _PrdAPR = 0;
        int _PrdMAY = 0;
        int _PrdJUN = 0;
        int _PrdJUL = 0;
        int _PrdAUG = 0;
        int _PrdSEP = 0;
        int _PrdOCT = 0;
        int _PrdNOV = 0;
        int _PrdDEC = 0;
        int _PrdJAN = 0;
        int _PrdFEB = 0;
        int _PrdMAR = 0;


        decimal _SaleAmtAPR = 0;
        decimal _SaleAmtMAY = 0;
        decimal _SaleAmtJUN = 0;
        decimal _SaleAmtJUL = 0;
        decimal _SaleAmtAUG = 0;
        decimal _SaleAmtSEP = 0;
        decimal _SaleAmtOCT = 0;
        decimal _SaleAmtNOV = 0;
        decimal _SaleAmtDEC = 0;
        decimal _SaleAmtJAN = 0;
        decimal _SaleAmtFEB = 0;
        decimal _SaleAmtMAR = 0;

        int _SaleRatioAPR = 0;
        int _SaleRatioMAY = 0;
        int _SaleRatioJUN = 0;
        int _SaleRatioJUL = 0;
        int _SaleRatioAUG = 0;
        int _SaleRatioSEP = 0;
        int _SaleRatioOCT = 0;
        int _SaleRatioNOV = 0;
        int _SaleRatioDEC = 0;
        int _SaleRatioJAN = 0;
        int _SaleRatioFEB = 0;
        int _SaleRatioMAR = 0;
        #endregion  

        string[] ArryLoop = new string[0];
        string ProductType = "";
        string TargetType = "";
        if (_Type == "ALL")
        {
            ArryLoop = ArryPrdALL;
            TargetType = "DCI";
        }
        else if (_Type == "FAC1")
        {
            ArryLoop = ArryPrdFac1;
            ProductType = "1YC";
            TargetType = "1YC";
            TxtModel = "1YC%";
      
        }
        else if (_Type == "FAC1M")
        {
            ArryLoop = ArryPrdFac1M;
            ProductType = "1YC";
            TargetType = "1YC";
        }
        else if (_Type == "FAC1A")
        {
            ArryLoop = ArryPrdFac1A;
            ProductType = "1YC";
            TargetType = "1YC";
        }
        else if (_Type == "FAC2")
        {
            ArryLoop = ArryPrdFac2;
            ProductType = "2YC";
            TargetType = "2YC";
            TxtModel = "2YC%";
        }
        else if (_Type == "FAC2M")
        {
            ArryLoop = ArryPrdFac2M;
            ProductType = "2YC";
            TargetType = "2YC";
        }
        else if (_Type == "FAC2A")
        {
            ArryLoop = ArryPrdFac2A;
            ProductType = "2YC";
            TargetType = "2YC";
        }
        else if (_Type == "FAC3")
        {
            ArryLoop = ArryPrdFac3;
            ProductType = "1YC/3";
            TargetType = "1YC/3";
            TxtModel = "1YC%";
        }
        else if (_Type == "FAC3M")
        {
            ArryLoop = ArryPrdFac3M;
            ProductType = "1YC/3";
            TargetType = "1YC/3";
        }
        else if (_Type == "FAC3A")
        {
            ArryLoop = ArryPrdFac3A;
            ProductType = "1YC/3";
            TargetType = "1YC/3";
        }
        else if (_Type == "ODM")
        {
            ArryLoop = ArryPrdODM;
            ProductType = "ODM";
            TargetType = "ODM";
        }
        else if (_Type == "SCR")
        {
            ArryLoop = ArryPrdSRC;
            ProductType = "SCR";
            TargetType = "SCR";
        }
        else if (_Type == "SCRM")
        {
            ArryLoop = ArryPrdSRCM;
            ProductType = "SCR";
            TargetType = "SCR";
        }
        else if (_Type == "SCRA")
        {
            ArryLoop = ArryPrdSRCA;
            ProductType = "SCR";
            TargetType = "SCR";
        }

     

        #region Last Year


        #region Last Year 1
        //*********************************************
        //         Get Data Last Year
        //*********************************************
        if (_Type == "ALL" || _Type == "FAC1" ||
           _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
        {
            //DataTable dtDataLast = new DataTable();
            //string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, " +
            //    "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
            //    " FROM BC_REPORT " +
            //    " WHERE Focal_year=@Focal_year " +
            //    "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
            //    " GROUP BY Focal_year, AccGroup, BudgetType ";
            //SqlCommand cmdDataLast = new SqlCommand();
            //cmdDataLast.CommandText = StrDataLast;
            //cmdDataLast.CommandTimeout = 180;
            //cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
            //cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
            //cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
            //dtDataLast = oConnBCS.Query(cmdDataLast);

          

            DataTable dtDataLast = new DataTable();
             string StrDataLast = "";
             SqlCommand cmdDataLast = new SqlCommand();
            if (_Type == "ALL")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                        ",prd_model_code " +
                        "FROM PD_FinalHold " +
                        " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' " +
                        "group by prd_model_code " +
                        "order by prd_model_code ";
               
                cmdDataLast.CommandText = StrDataLast;
            }
            else if (_Type == "FAC3")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";
            
                cmdDataLast.CommandText = StrDataLast;
            }
            else if (_Type == "FAC2")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast.CommandText = StrDataLast;
            }
            else if (_Type == "FAC1")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast.CommandText = StrDataLast;
            }

                cmdDataLast.CommandTimeout = 180;
                cmdDataLast.Parameters.Add(new SqlParameter("@YearHold", pLastYear));
                dtDataLast = oConDCI.Query(cmdDataLast);
            

            if (dtDataLast.Rows.Count > 0)
            {

                for (int i = 0; i <= dtDataLast.Rows.Count; i++)
                    foreach (DataRow _rowMP in dtDataLast.Rows)
                    {
                        if (i == 0)
                        {
                            _Model1LastYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                        }
                        else if (i == 1)
                        {
                            _Model2LastYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                        }
                        else if (i == 2)
                        {
                            _Model3LastYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                        }

                          
                    }
            }
        }

//            //********* Loop Production Last Year ***********
//            foreach (string prdType in ArryPrd)
//            {
//                DataTable dtPrdLast = new DataTable();
//                string StrPrdLast = @"SELECT Focal_year,AccGroup,BudgetType,ProductType, Total_PRD 
//                        FROM BC_REPORT
//                        WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup 
//                        AND BudgetType = @BudgetType AND ProductType = @ProductType ";
//                SqlCommand cmdPrdLast = new SqlCommand();
//                cmdPrdLast.CommandText = StrPrdLast;
//                cmdPrdLast.CommandTimeout = 180;
//                cmdPrdLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
//                cmdPrdLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
//                cmdPrdLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
//                cmdPrdLast.Parameters.Add(new SqlParameter("@ProductType", prdType));
//                dtPrdLast = oConnBCS.Query(cmdPrdLast);
//                if (dtPrdLast.Rows.Count > 0)
//                {
//                    if (prdType == "ODM")
//                    {
//                        try { _PrdActualLastYear = _PrdActualLastYear + (Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()) / 20); } catch { }
//                    }
//                    else {
//                        try { _PrdActualLastYear = _PrdActualLastYear + Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()); } catch { }
//                    }
                    
//                }
//            }
//            //********* Loop Production Last Year ***********


//            //********* Sale Amount / Sale Ratio *************
//            DataTable dtSaleLast = new DataTable();
//            string StrSaleLast = @"SELECT SUM(SA_Total) AS SA_Total, SUM(SA_QTY_Total) AS SA_QTY_Total  
//                FROM BC_SALE_AMOUNT 
//                WHERE Fiscal_year=@Fiscal_year  ";
//            SqlCommand cmdSaleLast = new SqlCommand();
//            cmdSaleLast.CommandText = StrSaleLast;
//            cmdSaleLast.CommandTimeout = 180;
//            cmdSaleLast.Parameters.Add(new SqlParameter("@Fiscal_year", pLastYear));
//            dtSaleLast = oConnBCS.Query(cmdSaleLast);

//            if (dtSaleLast.Rows.Count > 0)
//            {
//                try { _SaleAmountLastYear = Convert.ToDecimal(dtSaleLast.Rows[0]["SA_Total"].ToString()); } catch { }
//                try { _SaleExpRatioLastYear = Convert.ToInt32(dtSaleLast.Rows[0]["SA_QTY_Total"].ToString()); } catch { }
//            }

//        }
//        else
//        {
//            DataTable dtDataLast = new DataTable();
//            string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, ProductType, " +
//                "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
//                " FROM BC_REPORT " +
//                " WHERE Focal_year=@Focal_year AND ProductType = @ProductType " +
//                "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
//                " GROUP BY Focal_year, AccGroup, BudgetType, ProductType ";
//            SqlCommand cmdDataLast = new SqlCommand();
//            cmdDataLast.CommandText = StrDataLast;
//            cmdDataLast.CommandTimeout = 180;
//            cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
//            cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
//            cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
//            cmdDataLast.Parameters.Add(new SqlParameter("@ProductType", ProductType));
//            dtDataLast = oConnBCS.Query(cmdDataLast);

//            if (dtDataLast.Rows.Count > 0)
//            {
//                try { _InLastYear = Convert.ToDecimal(dtDataLast.Rows[0]["Total_IN"].ToString()); } catch { }
//                try { _ResLastYear = Convert.ToDecimal(dtDataLast.Rows[0]["Total_RES_IN"].ToString()); } catch { }
//            }


//            //********* Loop Production Last Year ***********
//            DataTable dtPrdLast = new DataTable();
//            string StrPrdLast = @"SELECT Focal_year,AccGroup,BudgetType,ProductType, Total_PRD 
//                    FROM BC_REPORT
//                    WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup 
//                    AND BudgetType = @BudgetType AND ProductType = @ProductType ";
//            SqlCommand cmdPrdLast = new SqlCommand();
//            cmdPrdLast.CommandText = StrPrdLast;
//            cmdPrdLast.CommandTimeout = 180;
//            cmdPrdLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
//            cmdPrdLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
//            cmdPrdLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
//            cmdPrdLast.Parameters.Add(new SqlParameter("@ProductType", ProductType));
//            dtPrdLast = oConnBCS.Query(cmdPrdLast);
//            if (dtPrdLast.Rows.Count > 0)
//            {
//                try { _PrdActualLastYear = Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()); } catch { }
//            }



//            //********* Sale Amount / Sale Ratio *************
//            DataTable dtSaleLast = new DataTable();
//            string StrSaleLast = @"SELECT SUM(SA_Total) AS SA_Total, SUM(SA_QTY_Total) AS SA_QTY_Total 
//                FROM BC_SALE_AMOUNT 
//                WHERE Fiscal_year=@Fiscal_year AND ProductType=@ProductType  ";
//            SqlCommand cmdSaleLast = new SqlCommand();
//            cmdSaleLast.CommandText = StrSaleLast;
//            cmdSaleLast.CommandTimeout = 180;
//            cmdSaleLast.Parameters.Add(new SqlParameter("@ProductType", pBudgetType));
//            cmdSaleLast.Parameters.Add(new SqlParameter("@Fiscal_year", pLastYear));
//            dtSaleLast = oConnBCS.Query(cmdSaleLast);

//            if (dtSaleLast.Rows.Count > 0)
//            {
//                try { _SaleAmountLastYear = Convert.ToDecimal(dtSaleLast.Rows[0]["SA_Total"].ToString()); } catch { }
//                try { _SaleExpRatioLastYear = Convert.ToInt32(dtSaleLast.Rows[0]["SA_QTY_Total"].ToString()); } catch { }
//            }


//        }
        //*********************************************
        //        End Get Data Last Year
        //*********************************************
        #endregion


        #region Last Year 2
        //*********************************************
        //         Get Data Last Year
        //*********************************************
        if (_Type == "ALL" || _Type == "FAC1" ||
            _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
        {
            //DataTable dtDataLast = new DataTable();
            //string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, " +
            //    "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
            //    " FROM BC_REPORT " +
            //    " WHERE Focal_year=@Focal_year " +
            //    "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
            //    " GROUP BY Focal_year, AccGroup, BudgetType ";
            //SqlCommand cmdDataLast = new SqlCommand();
            //cmdDataLast.CommandText = StrDataLast;
            //cmdDataLast.CommandTimeout = 180;
            //cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
            //cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
            //cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
            //dtDataLast = oConnBCS.Query(cmdDataLast);



            DataTable dtDataLast2 = new DataTable();
            string StrDataLast = "";
            SqlCommand cmdDataLast2 = new SqlCommand();
            if (_Type == "ALL")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                        ",prd_model_code " +
                        "FROM PD_FinalHold " +
                        " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' " +
                        "group by prd_model_code " +
                        "order by prd_model_code ";

                cmdDataLast2.CommandText = StrDataLast;
            }
            else if (_Type == "FAC3")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast2.CommandText = StrDataLast;
            }
            else if (_Type == "FAC2")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast2.CommandText = StrDataLast;
            }
            else if (_Type == "FAC1")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast2.CommandText = StrDataLast;
            }

            cmdDataLast2.CommandTimeout = 180;
            cmdDataLast2.Parameters.Add(new SqlParameter("@YearHold", pLastYear));
            dtDataLast2 = oConDCI.Query(cmdDataLast2);


            if (dtDataLast2.Rows.Count > 0)
            {

                for (int i = 0; i <= dtDataLast2.Rows.Count; i++)
                    foreach (DataTable _rowMP in dtDataLast2.Rows)
                    {
                        if (i == 0)
                        {
                            _Model1Last2Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                        }
                        else if (i == 1)
                        {
                            _Model2Last2Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                        }
                        else if (i == 2)
                        {
                            _Model3Last2Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                        }

                          
                    }
            }
       }
           //*********************************************
        //        End Get Data Last Year
        //*********************************************
        #endregion


        #region Last Year 3
        //*********************************************
        //         Get Data Last Year
        //*********************************************

        if (_Type == "ALL" || _Type == "FAC1" ||
       _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
        {
            //DataTable dtDataLast = new DataTable();
            //string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, " +
            //    "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
            //    " FROM BC_REPORT " +
            //    " WHERE Focal_year=@Focal_year " +
            //    "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
            //    " GROUP BY Focal_year, AccGroup, BudgetType ";
            //SqlCommand cmdDataLast = new SqlCommand();
            //cmdDataLast.CommandText = StrDataLast;
            //cmdDataLast.CommandTimeout = 180;
            //cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
            //cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
            //cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
            //dtDataLast = oConnBCS.Query(cmdDataLast);



            DataTable dtDataLast3 = new DataTable();
            string StrDataLast = "";
            SqlCommand cmdDataLast3 = new SqlCommand();
            if (_Type == "ALL")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                        ",prd_model_code " +
                        "FROM PD_FinalHold " +
                        " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' " +
                        "group by prd_model_code " +
                        "order by prd_model_code ";

                cmdDataLast3.CommandText = StrDataLast;
            }
            else if (_Type == "FAC3")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast3.CommandText = StrDataLast;
            }
            else if (_Type == "FAC2")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast3.CommandText = StrDataLast;
            }
            else if (_Type == "FAC1")
            {
                StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                       ",prd_model_code " +
                       "FROM PD_FinalHold " +
                       " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                       "group by prd_model_code " +
                       "order by prd_model_code ";

                cmdDataLast3.CommandText = StrDataLast;
            }

            cmdDataLast3.CommandTimeout = 180;
            cmdDataLast3.Parameters.Add(new SqlParameter("@YearHold", pLastYear));
            dtDataLast3 = oConDCI.Query(cmdDataLast3);


            if (dtDataLast3.Rows.Count > 0)
            {

                for (int i = 0; i <= dtDataLast3.Rows.Count; i++)
                    foreach (DataTable _rowMP in dtDataLast3.Rows)
                    {
                        if (i == 0)
                        {
                            _Model1Last3Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                        }
                        else if (i == 1)
                        {
                            _Model2Last3Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                        }
                        else if (i == 2)
                        {
                            _Model3Last3Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                        }

                          
                    }
            }
      }

        //*********************************************
        //        End Get Data Last Year
        //*********************************************
        #endregion


        #endregion








        //*********************************************
        //         Get Data Present
        //*********************************************

        DataTable dtDatap = new DataTable();
        DataTable dtPrd = new DataTable(); 
        SqlCommand cmdDatap = new SqlCommand();
       // string StrDatap = "";
        if (_Type == "ALL" || _Type == "FAC1" ||
           _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
        {


            //if (_Type == "ALL")
            //{
            //    StrDatap = "SELECT  Count(prd_model_code) as CCount " +
            //            ",prd_model_code " +
            //            "FROM PD_FinalHold " +
            //             " where Year(HoldDate) =@PresentYear  and prd_status='LINEOUT' " +
            //            "group by prd_model_code " +
            //            "order by prd_model_code ";

            //    cmdDatap.CommandText = StrDatap;
            //}
            //else if (_Type == "FAC3")
            //{
            //    StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
            //           ",prd_model_code " +
            //           "FROM PD_FinalHold " +
            //           " where Year(HoldDate) =@PresentYear  and prd_status='LINEOUT'  " +
            //           " and (prd_model_code like '%121%' or prd_model_code like '%442%' " +
            //           " or prd_model_code like '%444%') " +
                       
            //           "group by prd_model_code " +
            //           "order by prd_model_code ";

            //    cmdDatap.CommandText = StrDataLast;
            //}

            //cmdDatap.CommandText = StrDatap;
            //cmdDatap.Parameters.Add(new SqlParameter("@PresentYear", pYear));
            //dtDatap = oConDCI.Query(cmdDatap);



            //if (dtDatap.Rows.Count > 0)
            //{

            //    for (int i = 0; i <= dtDatap.Rows.Count; i++)
            //        foreach (DataRow _rowMP in dtDatap.Rows)
            //        {
            //            if (i == 0)
            //            {
            //                _Model1PYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

            //            }
            //            else if (i == 1)
            //            {
            //                _Model2PYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

            //            }
            //            else if (i == 2)
            //            {
            //                _Model3PYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

            //            }


            //        }
            //}

            #region Get Data FG Hold
            //Start  *** Get Data FG Hold
            DataTable dtHoldMonth = new DataTable();
            string StrDataHold = "";
            SqlCommand cmdDataHold = new SqlCommand();
            if (_Type == "ALL")
            {
                StrDataHold = " SELECT Count(prd_model_code) as CCount " +
                ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                " where Year(HoldDate) = @Presentyear and prd_status='HOLD' " +
                " group by prd_model_code,Month(HoldDate),prd_model " +
                " order by HDate,prd_model_code ";

                cmdDataHold.CommandText = StrDataHold;
            }
            else if (_Type == "FAC3")
            {
                StrDataHold = " SELECT Count(prd_model_code) as CCount " +
                  ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                  " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                  " where Year(HoldDate) = @Presentyear and prd_status='HOLD' " +
                 //" where Year(HoldDate) =@PresentYear  and prd_status='HOLD'  " +

                 " and (prd_model_code like '%121%' or prd_model_code like '%442%' " +
                 " or prd_model_code like '%444%') " +
                  " group by prd_model_code,Month(HoldDate),prd_model " +
                 " order by HDate,prd_model_code ";

                cmdDataHold.CommandText = StrDataHold;
            }
            else if (_Type == "FAC2")
            {
                StrDataHold = " SELECT Count(prd_model_code) as CCount " +
               ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
               " FROM [dbDCI].[dbo].[PD_FinalHold] " +
               " where Year(HoldDate) = @Presentyear and prd_status='HOLD' " +
                    //" where Year(HoldDate) =@PresentYear  and prd_status='HOLD'  " +

              " and (prd_model_code like '%222%' or prd_model_code like '%333%' " +
              " or prd_model_code like '%555%') " +
               " group by prd_model_code,Month(HoldDate),prd_model " +
              " order by HDate,prd_model_code ";

            

                cmdDataHold.CommandText = StrDataHold;
            }
            else if (_Type == "FAC1")
            {
                StrDataHold = " SELECT Count(prd_model_code) as CCount " +
                 ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                 " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                 " where Year(HoldDate) = @Presentyear and prd_status='HOLD' " +
                    //" where Year(HoldDate) =@PresentYear  and prd_status='HOLD'  " +

                " and (prd_model_code like '%111%' or prd_model_code like '%222%' " +
                " or prd_model_code like '%333%') " +
                 " group by prd_model_code,Month(HoldDate),prd_model " +
                " order by HDate,prd_model_code ";

            

                cmdDataHold.CommandText = StrDataHold;
            }



            cmdDataHold.CommandText = StrDataHold;
            cmdDataHold.CommandTimeout = 180;
            cmdDataHold.Parameters.Add(new SqlParameter("@Presentyear", pYear));
            // cmdDataHold.Parameters.Add(new SqlParameter("@Presentmonth", pMonth));
            dtHoldMonth = oConDCI.Query(cmdDataHold);

            if (dtHoldMonth.Rows.Count > 0)
            {
               // int i = 0;
                foreach (DataRow drData in dtHoldMonth.Rows)
                {

                    if (Convert.ToInt16(drData["HDate"]) == 5)
                    {
                        SumMayFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPYear += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPYear += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPYear += Convert.ToDecimal(drData["CCount"].ToString());
                        }

                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 6)
                    {
                        SumJunFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPJun += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPJun += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPJun += Convert.ToDecimal(drData["CCount"].ToString());
                        }

                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 7)
                    {
                        SumJulFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPJul += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPJul += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPJul += Convert.ToDecimal(drData["CCount"].ToString());
                        }

                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 8)
                    {
                        SumAugLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPAug += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPAug += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPAug += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 9)
                    {
                        SumSepLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPSep += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPSep += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPSep += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 10)
                    {
                        SumOctLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPOct += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPOct += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPOct += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 11)
                    {
                        SumNovLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPNov += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPNov += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPNov += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 12)
                    {
                        SumDecLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPDec += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPDec += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPDec += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 1)
                    {
                        SumJanLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPJan += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPJan += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPJan += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 2)
                    {
                        SumFebLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPFeb += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPFeb += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPFeb += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 3)
                    {
                        SumMarLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPMar += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPMar += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPMar += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                    }
                    else if (Convert.ToInt16(drData["HDate"]) == 4)
                    {
                        SumAprLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                        if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                        {

                            _Model121FGPApr += Convert.ToDecimal(drData["CCount"].ToString());

                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                        {
                            _Model442FGPApr += Convert.ToDecimal(drData["CCount"].ToString());
                        }
                        else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                        {
                            _Model444FGPApr += Convert.ToDecimal(drData["CCount"].ToString());
                        }

                    }

                }
                //End  *** Get Data FG Hold


                //Start  *** Get Data LineOut

                DataTable dtLineOutMonth = new DataTable();
                string StrDataLineOut = "";
                SqlCommand cmdDataLineOut = new SqlCommand();
                if (_Type == "ALL")
                {
                    StrDataLineOut = " SELECT Count(prd_model_code) as CCount " +
                    ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                    " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                    " where Year(HoldDate) = @Presentyear and prd_status='LINEOUT' " +
                    " group by prd_model_code,Month(HoldDate),prd_model " +
                    " order by HDate,prd_model_code ";

                    cmdDataLineOut.CommandText = StrDataLineOut;
                }
                else if (_Type == "FAC3")
                {
                    StrDataLineOut = " SELECT Count(prd_model_code) as CCount " +
                      ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                      " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                      " where Year(HoldDate) = @Presentyear and prd_status='LINEOUT' " +
                       " and (prd_model_code like '%121%' or prd_model_code like '%442%' " +
                     " or prd_model_code like '%444%') " +
                     " group by prd_model_code,Month(HoldDate),prd_model " +
                     " order by HDate,prd_model_code ";
                    

                    cmdDataLineOut.CommandText = StrDataLineOut;
                }
                else if (_Type == "FAC2")
                {
                    StrDataLineOut = " SELECT Count(prd_model_code) as CCount " +
                      ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                      " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                      " where Year(HoldDate) = @Presentyear and prd_status='LINEOUT' " +
                       " and (prd_model_code like '%222%' or prd_model_code like '%333%' " +
                     " or prd_model_code like '%555%') " +
                     " group by prd_model_code,Month(HoldDate),prd_model " +
                     " order by HDate,prd_model_code ";


                    cmdDataLineOut.CommandText = StrDataLineOut;
                }
                else if (_Type == "FAC1")
                {
                    StrDataLineOut = " SELECT Count(prd_model_code) as CCount " +
                     ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                     " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                     " where Year(HoldDate) = @Presentyear and prd_status='LINEOUT' " +
                      " and (prd_model_code like '%111%' or prd_model_code like '%222%' " +
                    " or prd_model_code like '%555%') " +
                    " group by prd_model_code,Month(HoldDate),prd_model " +
                    " order by HDate,prd_model_code ";


                    cmdDataLineOut.CommandText = StrDataLineOut;
                }



                cmdDataLineOut.CommandText = StrDataLineOut;
                cmdDataLineOut.CommandTimeout = 180;
                cmdDataLineOut.Parameters.Add(new SqlParameter("@Presentyear", pYear));
                // cmdDataHold.Parameters.Add(new SqlParameter("@Presentmonth", pMonth));
                dtLineOutMonth = oConDCI.Query(cmdDataLineOut);

                if (dtLineOutMonth.Rows.Count > 0)
                {
                   // int i = 0;
                    foreach (DataRow drData in dtLineOutMonth.Rows)
                    {

                        if (Convert.ToInt16(drData["HDate"]) == 5)
                        {
                            SumMayLineOut += Convert.ToDecimal(drData["CCount"].ToString());

                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPYear += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPYear += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPYear += Convert.ToDecimal(drData["CCount"].ToString());
                            }


                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 6)
                        {
                            SumJunLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPJun += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPJun += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPJun += Convert.ToDecimal(drData["CCount"].ToString());
                            }

                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 7)
                        {
                            SumJulLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPJul += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPJul += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPJul += Convert.ToDecimal(drData["CCount"].ToString());
                            }

                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 8)
                        {
                            SumAugLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPAug += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPAug += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPAug += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 9)
                        {
                            SumSepLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPSep += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPSep += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPSep += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 10)
                        {
                            SumOctLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPOct += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPOct += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPOct += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 11)
                        {
                            SumNovLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPNov += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPNov += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPNov += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 12)
                        {
                            SumDecLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPDec += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPDec += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPDec += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 1)
                        {
                            SumJanLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPJan += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPJan += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPJan += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 2)
                        {
                            SumFebLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPFeb += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPFeb += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPFeb += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 3)
                        {
                            SumMarLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPMar += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPMar += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPMar += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                        }
                        else if (Convert.ToInt16(drData["HDate"]) == 4)
                        {
                            SumAprLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                            if (Convert.ToString(drData["prd_model_code"].ToString()) == "0121")
                            {

                                _Model121LOPApr += Convert.ToDecimal(drData["CCount"].ToString());

                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0442")
                            {
                                _Model442LOPApr += Convert.ToDecimal(drData["CCount"].ToString());
                            }
                            else if (Convert.ToString(drData["prd_model_code"].ToString()) == "0444")
                            {
                                _Model444LOPApr += Convert.ToDecimal(drData["CCount"].ToString());
                            }

                        }

                    }


                    _InMAYFG = SumMayFGHold;
                    _InMAYLO = SumMayLineOut;
                    _InJUNFG = SumJunFGHold;
                    _InJUNLO = SumJunLineOut;
                    _InJUlFG = SumJulFGHold;
                    _InJUlLO = SumJulLineOut;
                    _InAUGFG = SumAugFGHold;
                    _InAUGLO = SumAugLineOut;
                    _InSEPFG = SumSepFGHold;
                    _InSEPLO = SumSepLineOut;
                    _InOCTFG = SumOctFGHold;
                    _InOCTLO = SumOctLineOut;
                    _InNOVFG = SumNovFGHold;
                    _InNOVLO = SumNovLineOut;
                    _InDECFG = SumDecFGHold;
                    _InDECLO = SumDecLineOut;
                    _InJANFG = SumJanFGHold;
                    _InJANLO = SumJanLineOut;
                    _InFEBFG = SumFebFGHold;
                    _InFEBLO = SumFebLineOut;
                    _InMARFG = SumMarFGHold;
                    _InMARLO = SumMarLineOut;
                    _InAPRFG = SumAprFGHold;
                    _InAPRLO = SumAprLineOut;

                }
                else
                {
                    _InMAYFG = 0;
                    _InMAYLO = 0;
                    //_InJUNFG = SumJunFGHold;
                    //_InJUNLO = SumJunLineOut;
                    //_InJUlFG = SumJulFGHold;
                    //_InJUlLO = SumJulLineOut;
                    //_InAUGFG = SumAugFGHold;
                    //_InAUGLO = SumAugLineOut;
                    //_InSEPFG = SumSepFGHold;
                    //_InSEPLO = SumSepLineOut;
                    //_InOCTFG = SumOctFGHold;
                    //_InOCTLO = SumOctLineOut;
                    //_InNOVFG = SumNovFGHold;
                    //_InNOVLO = SumNovLineOut;
                    //_InDECFG = SumDecFGHold;
                    //_InDECLO = SumDecLineOut;
                    //_InJANFG = SumJanFGHold;
                    //_InJANLO = SumJanLineOut;
                    //_InFEBFG = SumFebFGHold;
                    //_InFEBLO = SumFebLineOut;
                    //_InMARFG = SumMarFGHold;
                    //_InMARLO = SumMarLineOut;
                    //_InAPRFG = SumAprFGHold;
                    //_InAPRLO = SumAprLineOut;


                }
                // end check 

            }
            else{
                  _InMAYFG = 0;
                    _InMAYLO = 0;
            }






                //******* add data  ********
                MDHoldAllInfo.HoldAllChartInfo mLast3Year = new MDHoldAllInfo.HoldAllChartInfo();
                mLast3Year.dataFGHold = _Model1Last3Year;
                mLast3Year.dataResult = _Model2Last3Year;
                mLast3Year.dataPrdActual = Convert.ToInt16(_Model3Last3Year);
                //mLast3Year.dataSaleAmount = _SaleAmountLast3Year;
                //mLast3Year.dataSaleExpRatio = _SaleExpRatioLast3Year;
                //try
                //{
                //    mLast3Year.dataPrdPerUnit = Math.Ceiling(_ResLast3Year / _PrdActualLast3Year);
                //}
                //catch
                //{
                //    mLast3Year.dataPrdPerUnit = 0;
                //}
                //try
                //{
                //    mLast3Year.dataPrdPerUnitTarget = Math.Ceiling(_PrdTargetLast3Year / 12);
                //}
                //catch
                //{
                //    mLast3Year.dataPrdPerUnitTarget = 0;
                //}
                mLast3Year.dataCostCenter = pLast3Year;
                mLast3Year.dataYearMonth = pLast3Year;
                oAryResult.Add(mLast3Year);



                MDHoldAllInfo.HoldAllChartInfo mLast2Year = new MDHoldAllInfo.HoldAllChartInfo();
                mLast2Year.dataFGHold = _Model1Last2Year;
                mLast2Year.dataResult = _Model2Last2Year;
                mLast2Year.dataPrdActual = Convert.ToInt16(_Model3Last2Year);
                //mLast2Year.dataSaleAmount = _SaleAmountLast2Year;
                //mLast2Year.dataSaleExpRatio = _SaleExpRatioLast2Year;
                //try
                //{
                //    mLast2Year.dataPrdPerUnit = Math.Ceiling(_ResLast2Year / _PrdActualLast2Year);
                //}
                //catch
                //{
                //    mLast2Year.dataPrdPerUnit = 0;
                //}
                //try
                //{
                //    mLast2Year.dataPrdPerUnitTarget = Math.Ceiling(_PrdTargetLast2Year / 12);
                //}
                //catch
                //{
                //    mLast2Year.dataPrdPerUnitTarget = 0;
                //}
                mLast2Year.dataCostCenter = pLast2Year;
                mLast2Year.dataYearMonth = pLast2Year;
                oAryResult.Add(mLast2Year);



                MDHoldAllInfo.HoldAllChartInfo mLastYear = new MDHoldAllInfo.HoldAllChartInfo();
                mLastYear.dataFGHold = _Model1LastYear;
                mLastYear.dataResult = _Model2LastYear;
                mLastYear.dataPrdActual = Convert.ToInt16(_Model3LastYear);
                //mLastYear.dataSaleAmount = _SaleAmountLastYear;
                //mLastYear.dataSaleExpRatio = _SaleExpRatioLastYear;
                //try
                //{
                //    mLastYear.dataPrdPerUnit = Math.Ceiling(_ResLastYear / _PrdActualLastYear);
                //}
                //catch
                //{
                //    mLastYear.dataPrdPerUnit = 0;
                //}
                //try {
                //    mLastYear.dataPrdPerUnitTarget = Math.Ceiling(_PrdTargetLastYear / 12);
                //} catch {
                //    mLastYear.dataPrdPerUnitTarget = 0;
                //}
                mLastYear.dataCostCenter = pLastYear;
                mLastYear.dataYearMonth = pLastYear;
                oAryResult.Add(mLastYear);





                int ix = 0;
                foreach (string _Month in ArryPeriod)
                {
                    // add data 
                    MDHoldAllInfo.HoldAllChartInfo mExpense = new MDHoldAllInfo.HoldAllChartInfo();

                    if (_Month == "APR")
                    {
                        mExpense.dataFGHold = _InAPRFG;
                        mExpense.dataLineOut = _InAPRLO;
                        //mExpense.dataM121 = _Model121FGPYear + _Model121LOPYear;
                        //mExpense.dataM442 = _Model442FGPYear + _Model442LOPYear;
                        //mExpense.dataM444 = _Model444FGPYear + _Model444LOPYear;
                        //mExpense.arrySeries = ArrySeires5;
                        //   mExpense.dataResult = ArrySeiresValue5;
                        //mExpense.dataPrdActual = _PrdAPR;
                        //mExpense.dataPrdPerUnitTarget = _TargetAPR;
                        //mExpense.dataSaleAmount = _SaleAmtAPR;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResAPR / _SaleAmtAPR), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResAPR / _PrdAPR); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "MAY")
                    {
                        mExpense.dataFGHold = _InMAYFG;
                        mExpense.dataLineOut = _InMAYLO;
                        mExpense.dataM121 = _Model121FGPYear + _Model121LOPYear;
                        mExpense.dataM442 = _Model442FGPYear + _Model442LOPYear;
                        mExpense.dataM444 = _Model444FGPYear + _Model444LOPYear;
                        //mExpense.arrySeries = ArrySeires5;
                        //mExpense.SeriesValue = ArrySeiresValue5;
                        // mExpense.dataResult = ArrySeiresValue5;
                        //mExpense.dataPrdActual = _PrdMAY;
                        //mExpense.dataPrdPerUnitTarget = _TargetMAY;
                        //mExpense.dataSaleAmount = _SaleAmtMAY;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResMAY / _SaleAmtMAY), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResMAY / _PrdMAY); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "JUN")
                    {
                        mExpense.dataFGHold = _InJUNFG;
                        mExpense.dataLineOut = _InJUNLO;
                        mExpense.dataM121 = _Model121FGPJun + _Model121LOPJun;
                        mExpense.dataM442 = _Model442FGPJun + _Model442LOPJun;
                        mExpense.dataM444 = _Model444FGPJun + _Model444LOPJun;
                        //mExpense.dataM121 = _Model121FGPYear + _Model121LOPYear;
                        //mExpense.dataM442 = _Model442FGPYear + _Model442LOPYear;
                        //mExpense.dataM444 = _Model444FGPYear + _Model444LOPYear;
                        //mExpense.dataPrdActual = _PrdJUN;
                        //mExpense.dataPrdPerUnitTarget = _TargetJUN;
                        //mExpense.dataSaleAmount = _SaleAmtJUN;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResJUN / _SaleAmtJUN), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResJUN / _PrdJUN); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "JUL")
                    {
                        mExpense.dataFGHold = _InJUlFG;
                        mExpense.dataLineOut = _InJUlLO;
                        mExpense.dataM121 = _Model121FGPJul + _Model121LOPJul;
                        mExpense.dataM442 = _Model442FGPJul + _Model442LOPJul;
                        mExpense.dataM444 = _Model444FGPJul + _Model444LOPJul;
                        //mExpense.dataPrdActual = _PrdJUL;
                        //mExpense.dataPrdPerUnitTarget = _TargetJUL;
                        //mExpense.dataSaleAmount = _SaleAmtJUL;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResJUL / _SaleAmtJUL), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResJUL / _PrdJUL); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "AUG")
                    {
                        mExpense.dataFGHold = _InAUGFG;
                        mExpense.dataLineOut = _InAUGLO;
                        mExpense.dataM121 = _Model121FGPAug + _Model121LOPAug;
                        mExpense.dataM442 = _Model442FGPAug + _Model442LOPAug;
                        mExpense.dataM444 = _Model444FGPAug + _Model444LOPAug;
                        //mExpense.dataPrdActual = _PrdAUG;
                        //mExpense.dataPrdPerUnitTarget = _TargetAUG;
                        //mExpense.dataSaleAmount = _SaleAmtAUG;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResAUG / _SaleAmtAUG), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResAUG / _PrdAUG); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "SEP")
                    {
                        mExpense.dataFGHold = _InSEPFG;
                        mExpense.dataLineOut = _InSEPLO;
                        mExpense.dataM121 = _Model121FGPSep + _Model121LOPSep;
                        mExpense.dataM442 = _Model442FGPSep + _Model442LOPSep;
                        mExpense.dataM444 = _Model444FGPSep + _Model444LOPSep;
                        //mExpense.dataPrdActual = _PrdSEP;
                        //mExpense.dataPrdPerUnitTarget = _TargetSEP;
                        //mExpense.dataSaleAmount = _SaleAmtSEP;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResSEP / _SaleAmtSEP), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResSEP / _PrdSEP); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "OCT")
                    {
                        mExpense.dataFGHold = _InOCTFG;
                        mExpense.dataLineOut = _InOCTLO;
                        mExpense.dataM121 = _Model121FGPOct + _Model121LOPOct;
                        mExpense.dataM442 = _Model442FGPOct + _Model442LOPOct;
                        mExpense.dataM444 = _Model444FGPOct + _Model444LOPOct;
                        //mExpense.dataPrdActual = _PrdOCT;
                        //mExpense.dataPrdPerUnitTarget = _TargetOCT;
                        //mExpense.dataSaleAmount = _SaleAmtOCT;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResOCT / _SaleAmtOCT), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResOCT / _PrdOCT); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "NOV")
                    {
                        mExpense.dataFGHold = _InNOVFG;
                        mExpense.dataLineOut = _InNOVLO;
                        mExpense.dataM121 = _Model121FGPNov + _Model121LOPNov;
                        mExpense.dataM442 = _Model442FGPNov + _Model442LOPNov;
                        mExpense.dataM444 = _Model444FGPNov + _Model444LOPNov;
                        //mExpense.dataPrdActual = _PrdNOV;
                        //mExpense.dataPrdPerUnitTarget = _TargetNOV;
                        //mExpense.dataSaleAmount = _SaleAmtNOV;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResNOV / _SaleAmtNOV), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResNOV / _PrdNOV); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "DEC")
                    {
                        mExpense.dataFGHold = _InDECFG;
                        mExpense.dataLineOut = _InDECLO;
                        mExpense.dataM121 = _Model121FGPDec + _Model121LOPDec;
                        mExpense.dataM442 = _Model442FGPDec + _Model442LOPDec;
                        mExpense.dataM444 = _Model444FGPDec + _Model444LOPDec;
                        //mExpense.dataPrdActual = _PrdDEC;
                        //mExpense.dataPrdPerUnitTarget = _TargetDEC;
                        //mExpense.dataSaleAmount = _SaleAmtDEC;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResDEC / _SaleAmtDEC), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResDEC / _PrdDEC); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "JAN")
                    {
                        mExpense.dataFGHold = _InJANFG;
                        mExpense.dataLineOut = _InJANLO;
                        mExpense.dataM121 = _Model121FGPJan + _Model121LOPJan;
                        mExpense.dataM442 = _Model442FGPJan + _Model442LOPJan;
                        mExpense.dataM444 = _Model444FGPJan + _Model444LOPJan;
 
                        //mExpense.dataPrdActual = _PrdJAN;
                        //mExpense.dataPrdPerUnitTarget = _TargetJAN;
                        //mExpense.dataSaleAmount = _SaleAmtJAN;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResJAN / _SaleAmtJAN), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResJAN / _PrdJAN); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "FEB")
                    {
                        mExpense.dataFGHold = _InFEBFG;
                        mExpense.dataLineOut = _InFEBLO;
                        mExpense.dataM121 = _Model121FGPFeb + _Model121LOPFeb;
                        mExpense.dataM442 = _Model442FGPFeb + _Model442LOPFeb;
                        mExpense.dataM444 = _Model444FGPFeb + _Model444LOPFeb;
 
                        //mExpense.dataPrdActual = _PrdFEB;
                        //mExpense.dataPrdPerUnitTarget = _TargetFEB;
                        //mExpense.dataSaleAmount = _SaleAmtFEB;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResFEB / _SaleAmtFEB), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResFEB / _PrdFEB); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "MAR")
                    {
                        mExpense.dataFGHold = _InMARFG;
                        mExpense.dataLineOut = _InMARLO;
                        mExpense.dataM121 = _Model121FGPMar + _Model121LOPMar;
                        mExpense.dataM442 = _Model442FGPMar + _Model442LOPMar;
                        mExpense.dataM444 = _Model444FGPMar + _Model444LOPMar;
                        //mExpense.dataPrdActual = _PrdMAR;
                        //mExpense.dataPrdPerUnitTarget = _TargetMAR;
                        //mExpense.dataSaleAmount = _SaleAmtMAR;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResMAR / _SaleAmtMAR), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResMAR / _PrdMAR); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    else if (_Month == "APR")
                    {
                        mExpense.dataFGHold = _InMARFG;
                        mExpense.dataLineOut = _InMARLO;
                        mExpense.dataM121 = _Model121FGPApr + _Model121LOPApr;
                        mExpense.dataM442 = _Model442FGPApr + _Model442LOPApr;
                        mExpense.dataM444 = _Model444FGPApr + _Model444LOPApr;
                        //mExpense.dataPrdActual = _PrdMAR;
                        //mExpense.dataPrdPerUnitTarget = _TargetMAR;
                        //mExpense.dataSaleAmount = _SaleAmtMAR;
                        //try { mExpense.dataSaleExpRatio = CeilingData((_ResMAR / _SaleAmtMAR), 2); }
                        //catch { mExpense.dataSaleExpRatio = 0; }
                        //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResMAR / _PrdMAR); }
                        //catch { mExpense.dataPrdPerUnit = 0; }
                    }
                    mExpense.dataCostCenter = _Month;
                    mExpense.dataYearMonth = _Month;
                    oAryResult.Add(mExpense);

                    ix++;
                }
              

            #endregion
            //}
        }
        return oAryResult;
    }




     public List<MDHoldAllInfo.HoldAllChartInfo> GetChartExpenseCostCenterReport(DateTime _DataDate, string _Type)
     {

        List<MDHoldAllInfo.HoldAllChartInfo> oAryResult = new List<MDHoldAllInfo.HoldAllChartInfo>();

         string[] ArryPrd = { "1YC", "2YC", "SCR", "1YC/3", "ODM" };
         string[] ArryPrdALL = { "1101", "1102", "1201", "1202", "1301", "1302", "1401", "1402", "1501", "1701", "1702", "4310", "4320", "4510", "4720", "8120" };
         string[] ArryPrdFac1 = { "1101", "1102" };
         string[] ArryPrdFac1M = { "1101" };
         string[] ArryPrdFac1A = { "1102" };
         string[] ArryPrdFac2 = { "1201", "1202" };
         string[] ArryPrdFac2M = { "1201", "1202" };
         string[] ArryPrdFac2A = { "1201", "1202" };
         string[] ArryPrdSRC = { "1301", "1302" };
         string[] ArryPrdSRCA = { "1301" };
         string[] ArryPrdSRCM = { "1302" };
         string[] ArryPrdFac3 = { "1701", "1702" };
         string[] ArryPrdFac3M = { "1701" };
         string[] ArryPrdFac3A = { "1702" };
         string[] ArryPrdODM = { "1501" };
         string[] ArryPeriod = { "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "JAN", "FEB", "MAR" };
         int[] ArryMonth = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };


         string pAccGroup = "EXP";
         string pBudgetType = "DI";
         string pYear = _DataDate.ToString("yyyy");
         string pMonth = _DataDate.ToString("MM");
         DateTime _LastYear = new DateTime();
         DateTime _Last2Year = new DateTime();
         DateTime _Last3Year = new DateTime();
         _LastYear = _DataDate.AddYears(-1);
         _Last2Year = _DataDate.AddYears(-2);
         _Last3Year = _DataDate.AddYears(-3);
         string pLastYear = _LastYear.ToString("yyyy");
         string pLast2Year = _Last2Year.ToString("yyyy");
         string pLast3Year = _Last3Year.ToString("yyyy");

         #region init
         int _PrdActualLastYear = 0;
         int _PrdActualLast2Year = 0;
         int _PrdActualLast3Year = 0;
         decimal SumMayFGHold = 0;
         decimal SumMayLineOut = 0;
         decimal SumJunFGHold = 0;  
         decimal SumJulLineOut = 0;
         decimal SumJulFGHold = 0;  
         decimal SumJunLineOut = 0;
         decimal SumAugFGHold = 0;  
         decimal SumAugLineOut = 0;
         decimal SumSepFGHold = 0;  
         decimal SumSepLineOut = 0;
         decimal SumOctFGHold = 0;  
         decimal SumOctLineOut = 0;
         decimal SumNovFGHold = 0;  
         decimal SumNovLineOut = 0;
         decimal SumDecFGHold = 0;  
         decimal SumDecLineOut = 0;
         decimal SumJanFGHold = 0;  
         decimal SumJanLineOut = 0;
         decimal SumFebFGHold = 0;  
         decimal SumFebLineOut = 0;  
         decimal SumMarFGHold = 0;  
         decimal SumMarLineOut = 0;  
         decimal SumAprFGHold = 0;  
         decimal SumAprLineOut = 0;
     
   

         decimal _PrdTargetLastYear = 0;
         decimal _PrdTargetLast2Year = 0;
         decimal _PrdTargetLast3Year = 0;

         decimal _SaleAmountLastYear = 0;
         decimal _SaleAmountLast2Year = 0;
         decimal _SaleAmountLast3Year = 0;

         decimal _SaleExpRatioLastYear = 0;
         decimal _SaleExpRatioLast2Year = 0;
         decimal _SaleExpRatioLast3Year = 0;


         int[] _PrdActual = new int[12];

         string[] ArrySeires5 = new string[5];
         Decimal[] ArrySeiresValue5 = new Decimal[5];          

         decimal _Model1PYear = 0;
         decimal _Model2PYear = 0;
         decimal _Model3PYear = 0;

          decimal _Model1LastYear = 0;
          decimal _Model2LastYear = 0;
          decimal _Model3LastYear = 0;

          decimal _Model1Last2Year = 0;
          decimal _Model2Last2Year = 0;
          decimal _Model3Last2Year = 0;

          decimal _Model1Last3Year = 0;
          decimal _Model2Last3Year = 0;
          decimal _Model3Last3Year = 0;

         decimal _InLastYear = 0;
         decimal _InLast2Year = 0;
         decimal _InLast3Year = 0;
      
         decimal _InAPRModel = 0;
         decimal _InAPR = 0;
       

         decimal _InMAYFG = 0;
         decimal _InMAYLO = 0;
         decimal _InJUNFG = 0;
         decimal _InJUNLO = 0;
         decimal _InJUlFG = 0;
         decimal _InJUlLO = 0;  
         decimal _InAUGFG = 0;
         decimal _InAUGLO = 0;       
         decimal _InSEPFG = 0;
         decimal _InSEPLO = 0;       
         decimal _InOCTFG = 0;
         decimal _InOCTLO = 0;       
         decimal _InNOVFG = 0;
         decimal _InNOVLO = 0;      
         decimal _InDECFG = 0;
         decimal _InDECLO = 0;    
         decimal _InJANFG = 0;
         decimal _InJANLO = 0;    
         decimal _InFEBFG = 0;
         decimal _InFEBLO = 0;    
         decimal _InMARFG = 0;
         decimal _InMARLO = 0;    
         decimal _InAPRFG = 0;
         decimal _InAPRLO = 0;    
     
   
         decimal _ResLastYear = 0;
         decimal _ResLast2Year = 0;
         decimal _ResLast3Year = 0;
         decimal _ResAPR = 0;
         decimal _ResMAY = 0;
         decimal _ResJUN = 0;
         decimal _ResJUL = 0;
         decimal _ResAUG = 0;
         decimal _ResSEP = 0;
         decimal _ResOCT = 0;
         decimal _ResNOV = 0;
         decimal _ResDEC = 0;
         decimal _ResJAN = 0;
         decimal _ResFEB = 0;
         decimal _ResMAR = 0;

         decimal _TargetAPR = 0;
         decimal _TargetMAY = 0;
         decimal _TargetJUN = 0;
         decimal _TargetJUL = 0;
         decimal _TargetAUG = 0;
         decimal _TargetSEP = 0;
         decimal _TargetOCT = 0;
         decimal _TargetNOV = 0;
         decimal _TargetDEC = 0;
         decimal _TargetJAN = 0;
         decimal _TargetFEB = 0;
         decimal _TargetMAR = 0;

         int _PrdAPR = 0;
         int _PrdMAY = 0;
         int _PrdJUN = 0;
         int _PrdJUL = 0;
         int _PrdAUG = 0;
         int _PrdSEP = 0;
         int _PrdOCT = 0;
         int _PrdNOV = 0;
         int _PrdDEC = 0;
         int _PrdJAN = 0;
         int _PrdFEB = 0;
         int _PrdMAR = 0;


         decimal _SaleAmtAPR = 0;
         decimal _SaleAmtMAY = 0;
         decimal _SaleAmtJUN = 0;
         decimal _SaleAmtJUL = 0;
         decimal _SaleAmtAUG = 0;
         decimal _SaleAmtSEP = 0;
         decimal _SaleAmtOCT = 0;
         decimal _SaleAmtNOV = 0;
         decimal _SaleAmtDEC = 0;
         decimal _SaleAmtJAN = 0;
         decimal _SaleAmtFEB = 0;
         decimal _SaleAmtMAR = 0;

         int _SaleRatioAPR = 0;
         int _SaleRatioMAY = 0;
         int _SaleRatioJUN = 0;
         int _SaleRatioJUL = 0;
         int _SaleRatioAUG = 0;
         int _SaleRatioSEP = 0;
         int _SaleRatioOCT = 0;
         int _SaleRatioNOV = 0;
         int _SaleRatioDEC = 0;
         int _SaleRatioJAN = 0;
         int _SaleRatioFEB = 0;
         int _SaleRatioMAR = 0;
         #endregion  

         string[] ArryLoop = new string[0];
         string ProductType = "";
         string TargetType = "";
         if (_Type == "ALL")
         {
             ArryLoop = ArryPrdALL;
             TargetType = "DCI";
         }
         else if (_Type == "FAC1")
         {
             ArryLoop = ArryPrdFac1;
             ProductType = "1YC";
             TargetType = "1YC";
         }
         else if (_Type == "FAC1M")
         {
             ArryLoop = ArryPrdFac1M;
             ProductType = "1YC";
             TargetType = "1YC";
         }
         else if (_Type == "FAC1A")
         {
             ArryLoop = ArryPrdFac1A;
             ProductType = "1YC";
             TargetType = "1YC";
         }
         else if (_Type == "FAC2")
         {
             ArryLoop = ArryPrdFac2;
             ProductType = "2YC";
             TargetType = "2YC";
         }
         else if (_Type == "FAC2M")
         {
             ArryLoop = ArryPrdFac2M;
             ProductType = "2YC";
             TargetType = "2YC";
         }
         else if (_Type == "FAC2A")
         {
             ArryLoop = ArryPrdFac2A;
             ProductType = "2YC";
             TargetType = "2YC";
         }
         else if (_Type == "FAC3")
         {
             ArryLoop = ArryPrdFac3;
             ProductType = "1YC/3";
             TargetType = "1YC/3";
         }
         else if (_Type == "FAC3M")
         {
             ArryLoop = ArryPrdFac3M;
             ProductType = "1YC/3";
             TargetType = "1YC/3";
         }
         else if (_Type == "FAC3A")
         {
             ArryLoop = ArryPrdFac3A;
             ProductType = "1YC/3";
             TargetType = "1YC/3";
         }
         else if (_Type == "ODM")
         {
             ArryLoop = ArryPrdODM;
             ProductType = "ODM";
             TargetType = "ODM";
         }
         else if (_Type == "SCR")
         {
             ArryLoop = ArryPrdSRC;
             ProductType = "SCR";
             TargetType = "SCR";
         }
         else if (_Type == "SCRM")
         {
             ArryLoop = ArryPrdSRCM;
             ProductType = "SCR";
             TargetType = "SCR";
         }
         else if (_Type == "SCRA")
         {
             ArryLoop = ArryPrdSRCA;
             ProductType = "SCR";
             TargetType = "SCR";
         }

     

         #region Last Year


         #region Last Year 1
         //*********************************************
         //         Get Data Last Year
         //*********************************************
         if (_Type == "ALL" || _Type == "FAC1" ||
            _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
         {
             //DataTable dtDataLast = new DataTable();
             //string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, " +
             //    "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
             //    " FROM BC_REPORT " +
             //    " WHERE Focal_year=@Focal_year " +
             //    "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
             //    " GROUP BY Focal_year, AccGroup, BudgetType ";
             //SqlCommand cmdDataLast = new SqlCommand();
             //cmdDataLast.CommandText = StrDataLast;
             //cmdDataLast.CommandTimeout = 180;
             //cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
             //cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
             //cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
             //dtDataLast = oConnBCS.Query(cmdDataLast);

          

             DataTable dtDataLast = new DataTable();
              string StrDataLast = "";
              SqlCommand cmdDataLast = new SqlCommand();
             if (_Type == "ALL")
             {
                 StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                         ",prd_model_code " +
                         "FROM PD_FinalHold " +
                         " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' " +
                         "group by prd_model_code " +
                         "order by prd_model_code ";
               
                 cmdDataLast.CommandText = StrDataLast;
             }
             else if (_Type == "FAC3")
             {
                 StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                        ",prd_model_code " +
                        "FROM PD_FinalHold " +
                        " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                        "group by prd_model_code " +
                        "order by prd_model_code ";
            
                 cmdDataLast.CommandText = StrDataLast;
             }

                 cmdDataLast.CommandTimeout = 180;
                 cmdDataLast.Parameters.Add(new SqlParameter("@YearHold", pLastYear));
                 dtDataLast = oConDCI.Query(cmdDataLast);
            

             if (dtDataLast.Rows.Count > 0)
             {

                 for (int i = 0; i <= dtDataLast.Rows.Count; i++)
                     foreach (DataRow _rowMP in dtDataLast.Rows)
                     {
                         if (i == 0)
                         {
                             _Model1LastYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                         }
                         else if (i == 1)
                         {
                             _Model2LastYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                         }
                         else if (i == 2)
                         {
                             _Model3LastYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                         }

                          
                     }
             }
         }

 //            //********* Loop Production Last Year ***********
 //            foreach (string prdType in ArryPrd)
 //            {
 //                DataTable dtPrdLast = new DataTable();
 //                string StrPrdLast = @"SELECT Focal_year,AccGroup,BudgetType,ProductType, Total_PRD 
 //                        FROM BC_REPORT
 //                        WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup 
 //                        AND BudgetType = @BudgetType AND ProductType = @ProductType ";
 //                SqlCommand cmdPrdLast = new SqlCommand();
 //                cmdPrdLast.CommandText = StrPrdLast;
 //                cmdPrdLast.CommandTimeout = 180;
 //                cmdPrdLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
 //                cmdPrdLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
 //                cmdPrdLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
 //                cmdPrdLast.Parameters.Add(new SqlParameter("@ProductType", prdType));
 //                dtPrdLast = oConnBCS.Query(cmdPrdLast);
 //                if (dtPrdLast.Rows.Count > 0)
 //                {
 //                    if (prdType == "ODM")
 //                    {
 //                        try { _PrdActualLastYear = _PrdActualLastYear + (Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()) / 20); } catch { }
 //                    }
 //                    else {
 //                        try { _PrdActualLastYear = _PrdActualLastYear + Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()); } catch { }
 //                    }
                    
 //                }
 //            }
 //            //********* Loop Production Last Year ***********


 //            //********* Sale Amount / Sale Ratio *************
 //            DataTable dtSaleLast = new DataTable();
 //            string StrSaleLast = @"SELECT SUM(SA_Total) AS SA_Total, SUM(SA_QTY_Total) AS SA_QTY_Total  
 //                FROM BC_SALE_AMOUNT 
 //                WHERE Fiscal_year=@Fiscal_year  ";
 //            SqlCommand cmdSaleLast = new SqlCommand();
 //            cmdSaleLast.CommandText = StrSaleLast;
 //            cmdSaleLast.CommandTimeout = 180;
 //            cmdSaleLast.Parameters.Add(new SqlParameter("@Fiscal_year", pLastYear));
 //            dtSaleLast = oConnBCS.Query(cmdSaleLast);

 //            if (dtSaleLast.Rows.Count > 0)
 //            {
 //                try { _SaleAmountLastYear = Convert.ToDecimal(dtSaleLast.Rows[0]["SA_Total"].ToString()); } catch { }
 //                try { _SaleExpRatioLastYear = Convert.ToInt32(dtSaleLast.Rows[0]["SA_QTY_Total"].ToString()); } catch { }
 //            }

 //        }
 //        else
 //        {
 //            DataTable dtDataLast = new DataTable();
 //            string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, ProductType, " +
 //                "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
 //                " FROM BC_REPORT " +
 //                " WHERE Focal_year=@Focal_year AND ProductType = @ProductType " +
 //                "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
 //                " GROUP BY Focal_year, AccGroup, BudgetType, ProductType ";
 //            SqlCommand cmdDataLast = new SqlCommand();
 //            cmdDataLast.CommandText = StrDataLast;
 //            cmdDataLast.CommandTimeout = 180;
 //            cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
 //            cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
 //            cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
 //            cmdDataLast.Parameters.Add(new SqlParameter("@ProductType", ProductType));
 //            dtDataLast = oConnBCS.Query(cmdDataLast);

 //            if (dtDataLast.Rows.Count > 0)
 //            {
 //                try { _InLastYear = Convert.ToDecimal(dtDataLast.Rows[0]["Total_IN"].ToString()); } catch { }
 //                try { _ResLastYear = Convert.ToDecimal(dtDataLast.Rows[0]["Total_RES_IN"].ToString()); } catch { }
 //            }


 //            //********* Loop Production Last Year ***********
 //            DataTable dtPrdLast = new DataTable();
 //            string StrPrdLast = @"SELECT Focal_year,AccGroup,BudgetType,ProductType, Total_PRD 
 //                    FROM BC_REPORT
 //                    WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup 
 //                    AND BudgetType = @BudgetType AND ProductType = @ProductType ";
 //            SqlCommand cmdPrdLast = new SqlCommand();
 //            cmdPrdLast.CommandText = StrPrdLast;
 //            cmdPrdLast.CommandTimeout = 180;
 //            cmdPrdLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
 //            cmdPrdLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
 //            cmdPrdLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
 //            cmdPrdLast.Parameters.Add(new SqlParameter("@ProductType", ProductType));
 //            dtPrdLast = oConnBCS.Query(cmdPrdLast);
 //            if (dtPrdLast.Rows.Count > 0)
 //            {
 //                try { _PrdActualLastYear = Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()); } catch { }
 //            }



 //            //********* Sale Amount / Sale Ratio *************
 //            DataTable dtSaleLast = new DataTable();
 //            string StrSaleLast = @"SELECT SUM(SA_Total) AS SA_Total, SUM(SA_QTY_Total) AS SA_QTY_Total 
 //                FROM BC_SALE_AMOUNT 
 //                WHERE Fiscal_year=@Fiscal_year AND ProductType=@ProductType  ";
 //            SqlCommand cmdSaleLast = new SqlCommand();
 //            cmdSaleLast.CommandText = StrSaleLast;
 //            cmdSaleLast.CommandTimeout = 180;
 //            cmdSaleLast.Parameters.Add(new SqlParameter("@ProductType", pBudgetType));
 //            cmdSaleLast.Parameters.Add(new SqlParameter("@Fiscal_year", pLastYear));
 //            dtSaleLast = oConnBCS.Query(cmdSaleLast);

 //            if (dtSaleLast.Rows.Count > 0)
 //            {
 //                try { _SaleAmountLastYear = Convert.ToDecimal(dtSaleLast.Rows[0]["SA_Total"].ToString()); } catch { }
 //                try { _SaleExpRatioLastYear = Convert.ToInt32(dtSaleLast.Rows[0]["SA_QTY_Total"].ToString()); } catch { }
 //            }


 //        }
         //*********************************************
         //        End Get Data Last Year
         //*********************************************
         #endregion


         #region Last Year 2
         //*********************************************
         //         Get Data Last Year
         //*********************************************
         if (_Type == "ALL" || _Type == "FAC1" ||
             _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
         {
             //DataTable dtDataLast = new DataTable();
             //string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, " +
             //    "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
             //    " FROM BC_REPORT " +
             //    " WHERE Focal_year=@Focal_year " +
             //    "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
             //    " GROUP BY Focal_year, AccGroup, BudgetType ";
             //SqlCommand cmdDataLast = new SqlCommand();
             //cmdDataLast.CommandText = StrDataLast;
             //cmdDataLast.CommandTimeout = 180;
             //cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
             //cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
             //cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
             //dtDataLast = oConnBCS.Query(cmdDataLast);



             DataTable dtDataLast2 = new DataTable();
             string StrDataLast = "";
             SqlCommand cmdDataLast2 = new SqlCommand();
             if (_Type == "ALL")
             {
                 StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                         ",prd_model_code " +
                         "FROM PD_FinalHold " +
                         " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' " +
                         "group by prd_model_code " +
                         "order by prd_model_code ";

                 cmdDataLast2.CommandText = StrDataLast;
             }
             else if (_Type == "FAC3")
             {
                 StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                        ",prd_model_code " +
                        "FROM PD_FinalHold " +
                        " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                        "group by prd_model_code " +
                        "order by prd_model_code ";

                 cmdDataLast2.CommandText = StrDataLast;
             }

             cmdDataLast2.CommandTimeout = 180;
             cmdDataLast2.Parameters.Add(new SqlParameter("@YearHold", pLastYear));
             dtDataLast2 = oConDCI.Query(cmdDataLast2);


             if (dtDataLast2.Rows.Count > 0)
             {

                 for (int i = 0; i <= dtDataLast2.Rows.Count; i++)
                     foreach (DataTable _rowMP in dtDataLast2.Rows)
                     {
                         if (i == 0)
                         {
                             _Model1Last2Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                         }
                         else if (i == 1)
                         {
                             _Model2Last2Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                         }
                         else if (i == 2)
                         {
                             _Model3Last2Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                         }

                          
                     }
             }
        }
            //*********************************************
         //        End Get Data Last Year
         //*********************************************
         #endregion


         #region Last Year 3
         //*********************************************
         //         Get Data Last Year
         //*********************************************

         if (_Type == "ALL" || _Type == "FAC1" ||
        _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
         {
             //DataTable dtDataLast = new DataTable();
             //string StrDataLast = "SELECT Focal_year, AccGroup, BudgetType, " +
             //    "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
             //    " FROM BC_REPORT " +
             //    " WHERE Focal_year=@Focal_year " +
             //    "   AND AccGroup=@AccGroup AND BudgetType=@BudgetType " +
             //    " GROUP BY Focal_year, AccGroup, BudgetType ";
             //SqlCommand cmdDataLast = new SqlCommand();
             //cmdDataLast.CommandText = StrDataLast;
             //cmdDataLast.CommandTimeout = 180;
             //cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
             //cmdDataLast.Parameters.Add(new SqlParameter("@BudgetType", pBudgetType));
             //cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
             //dtDataLast = oConnBCS.Query(cmdDataLast);



             DataTable dtDataLast3 = new DataTable();
             string StrDataLast = "";
             SqlCommand cmdDataLast3 = new SqlCommand();
             if (_Type == "ALL")
             {
                 StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                         ",prd_model_code " +
                         "FROM PD_FinalHold " +
                         " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' " +
                         "group by prd_model_code " +
                         "order by prd_model_code ";

                 cmdDataLast3.CommandText = StrDataLast;
             }
             else if (_Type == "FAC3")
             {
                 StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                        ",prd_model_code " +
                        "FROM PD_FinalHold " +
                        " where Year(HoldDate) = @YearHold and prd_status='LINEOUT' and prd_serial like '%9%'" +
                        "group by prd_model_code " +
                        "order by prd_model_code ";

                 cmdDataLast3.CommandText = StrDataLast;
             }

             cmdDataLast3.CommandTimeout = 180;
             cmdDataLast3.Parameters.Add(new SqlParameter("@YearHold", pLastYear));
             dtDataLast3 = oConDCI.Query(cmdDataLast3);


             if (dtDataLast3.Rows.Count > 0)
             {

                 for (int i = 0; i <= dtDataLast3.Rows.Count; i++)
                     foreach (DataTable _rowMP in dtDataLast3.Rows)
                     {
                         if (i == 0)
                         {
                             _Model1Last3Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                         }
                         else if (i == 1)
                         {
                             _Model2Last3Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                         }
                         else if (i == 2)
                         {
                             _Model3Last3Year = Convert.ToDecimal(_rowMP.Rows[i]["CCount"].ToString());

                         }

                          
                     }
             }
       }

         //*********************************************
         //        End Get Data Last Year
         //*********************************************
         #endregion


         #endregion








         //*********************************************
         //         Get Data Present
         //*********************************************

         DataTable dtDatap = new DataTable();
         DataTable dtPrd = new DataTable(); 
         SqlCommand cmdDatap = new SqlCommand();
         string StrDatap = "";
         if (_Type == "ALL" || _Type == "FAC1" ||
            _Type == "FAC2" || _Type == "FAC3" || _Type == "ODM")
         {


             if (_Type == "ALL")
             {
                 StrDatap = "SELECT  Count(prd_model_code) as CCount " +
                         ",prd_model_code " +
                         "FROM PD_FinalHold " +
                          " where Year(HoldDate) =@PresentYear  and prd_status='LINEOUT' " +
                         "group by prd_model_code " +
                         "order by prd_model_code ";

                 cmdDatap.CommandText = StrDataLast;
             }
             else if (_Type == "FAC3")
             {
                 StrDataLast = "SELECT  Count(prd_model_code) as CCount " +
                        ",prd_model_code " +
                        "FROM PD_FinalHold " +
                        " where Year(HoldDate) = @PresentYear and prd_status='LINEOUT' and prd_serial like '%9%' " +
                        "group by prd_model_code " +
                        "order by prd_model_code ";

                 cmdDatap.CommandText = StrDataLast;
             }

             cmdDatap.CommandText = StrDatap;
             cmdDatap.Parameters.Add(new SqlParameter("@PresentYear", pYear));
             dtDatap = oConDCI.Query(cmdDatap);



             if (dtDatap.Rows.Count > 0)
             {

                 for (int i = 0; i <= dtDatap.Rows.Count; i++)
                     foreach (DataRow _rowMP in dtDatap.Rows)
                     {
                         if (i == 0)
                         {
                             _Model1PYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                         }
                         else if (i == 1)
                         {
                             _Model2PYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                         }
                         else if (i == 2)
                         {
                             _Model3PYear = Convert.ToDecimal(_rowMP["CCount"].ToString());

                         }


                     }
             }

             #region Get Data FG Hold
             //Start  *** Get Data FG Hold
             DataTable dtHoldMonth = new DataTable();
             string StrDataHold = "";
             SqlCommand cmdDataHold = new SqlCommand();
             if (_Type == "ALL")
             {
                 StrDataHold = " SELECT Count(prd_model_code) as CCount " +
                 ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                 " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                 " where Year(HoldDate) = @Presentyear and prd_status='HOLD' " +
                 " group by prd_model_code,Month(HoldDate),prd_model " +
                 " order by HDate,prd_model_code ";

                 cmdDataHold.CommandText = StrDataHold;
             }
             else if (_Type == "FAC3")
             {
                 StrDataHold = " SELECT Count(prd_model_code) as CCount " +
                   ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                   " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                   " where Year(HoldDate) = @Presentyear and prd_status='HOLD' and prd_serial like '%9%' " +
                   " group by prd_model_code,Month(HoldDate),prd_model " +
                  " order by HDate,prd_model_code ";

                 cmdDataHold.CommandText = StrDataHold;
             }



             cmdDataHold.CommandText = StrDataHold;
             cmdDataHold.CommandTimeout = 180;
             cmdDataHold.Parameters.Add(new SqlParameter("@Presentyear", pYear));
             // cmdDataHold.Parameters.Add(new SqlParameter("@Presentmonth", pMonth));
             dtHoldMonth = oConDCI.Query(cmdDataHold);

             if (dtHoldMonth.Rows.Count > 0)
             {
                 //int i = 0;
                 foreach (DataRow drData in dtHoldMonth.Rows)
                 {

                     if (Convert.ToInt16(drData["HDate"]) == 5)
                     {
                         SumMayFGHold += Convert.ToDecimal(drData["CCount"].ToString());

                         //ArrySeires5[i] = drData["prd_model_code"].ToString();
                         //ArrySeiresValue5[i] += Convert.ToDecimal(drData["CCount"].ToString());

                         //i = i + 1;
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 6)
                     {
                         SumJunFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 7)
                     {
                         SumJulFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 8)
                     {
                         SumAugFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 9)
                     {
                         SumSepLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 10)
                     {
                         SumOctFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 11)
                     {
                         SumNovLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 12)
                     {
                         SumDecFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (drData["HDate"] == "1")
                     {
                         SumJanFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 2)
                     {
                         SumFebLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 3)
                     {
                         SumMarFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }
                     else if (Convert.ToInt16(drData["HDate"]) == 4)
                     {
                         SumAprFGHold += Convert.ToDecimal(drData["CCount"].ToString());
                     }

                 }
                 //End  *** Get Data FG Hold


                 //Start  *** Get Data LineOut

                 DataTable dtLineOutMonth = new DataTable();
                 string StrDataLineOut = "";
                 SqlCommand cmdDataLineOut = new SqlCommand();
                 if (_Type == "ALL")
                 {
                     StrDataLineOut = " SELECT Count(prd_model_code) as CCount " +
                     ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                     " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                     " where Year(HoldDate) = @Presentyear and prd_status='LINEOUT' " +
                     " group by prd_model_code,Month(HoldDate),prd_model " +
                     " order by HDate,prd_model_code ";

                     cmdDataLineOut.CommandText = StrDataLineOut;
                 }
                 else if (_Type == "FAC3")
                 {
                     StrDataLineOut = " SELECT Count(prd_model_code) as CCount " +
                       ",prd_model_code,Month(HoldDate) as HDate,prd_model " +
                       " FROM [dbDCI].[dbo].[PD_FinalHold] " +
                       " where Year(HoldDate) = @Presentyear and prd_status='LINEOUT' and prd_serial like '%9%' " +
                       " group by prd_model_code,Month(HoldDate),prd_model " +
                      " order by HDate,prd_model_code ";

                     cmdDataLineOut.CommandText = StrDataLineOut;
                 }



                 cmdDataLineOut.CommandText = StrDataLineOut;
                 cmdDataLineOut.CommandTimeout = 180;
                 cmdDataLineOut.Parameters.Add(new SqlParameter("@Presentyear", pYear));
                 // cmdDataHold.Parameters.Add(new SqlParameter("@Presentmonth", pMonth));
                 dtLineOutMonth = oConDCI.Query(cmdDataLineOut);

                 if (dtLineOutMonth.Rows.Count > 0)
                 {
                     //int i = 0;
                     foreach (DataRow drData in dtLineOutMonth.Rows)
                     {

                         if (Convert.ToInt16(drData["HDate"]) == 5)
                         {
                             SumMayLineOut += Convert.ToDecimal(drData["CCount"].ToString());

                            // ArrySeires5[i] = drData["prd_model_code"].ToString();
                            // ArrySeiresValue5[i] += Convert.ToDecimal(drData["CCount"].ToString());

                            // i = i + 1;
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 6)
                         {
                             SumJunLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 7)
                         {
                             SumJulLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 8)
                         {
                             SumAugLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 9)
                         {
                             SumSepLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 10)
                         {
                             SumOctLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 11)
                         {
                             SumNovLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 12)
                         {
                             SumDecLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 1)
                         {
                             SumJanLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 2)
                         {
                             SumFebLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 3)
                         {
                             SumMarLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }
                         else if (Convert.ToInt16(drData["HDate"]) == 4)
                         {
                             SumAprLineOut += Convert.ToDecimal(drData["CCount"].ToString());
                         }

                     }


                     _InMAYFG = SumMayFGHold;
                     _InMAYLO = SumMayLineOut;
                     _InJUNFG = SumJunFGHold;
                     _InJUNLO = SumJunLineOut;
                     _InJUlFG = SumJulFGHold;
                     _InJUlLO = SumJulLineOut;
                     _InAUGFG = SumAugFGHold;
                     _InAUGLO = SumAugLineOut;
                     _InSEPFG = SumSepFGHold;
                     _InSEPLO = SumSepLineOut;
                     _InOCTFG = SumOctFGHold;
                     _InOCTLO = SumOctLineOut;
                     _InNOVFG = SumNovFGHold;
                     _InNOVLO = SumNovLineOut;
                     _InDECFG = SumDecFGHold;
                     _InDECLO = SumDecLineOut;
                     _InJANFG = SumJanFGHold;
                     _InJANLO = SumJanLineOut;
                     _InFEBFG = SumFebFGHold;
                     _InFEBLO = SumFebLineOut;
                     _InMARFG = SumMarFGHold;
                     _InMARLO = SumMarLineOut;
                     _InAPRFG = SumAprFGHold;
                     _InAPRLO = SumAprLineOut;

                 } // end check 









                 //******* add data  ********
                 MDHoldAllInfo.HoldAllChartInfo mLast3Year = new MDHoldAllInfo.HoldAllChartInfo();
                 mLast3Year.dataFGHold = _Model1Last3Year;
                 mLast3Year.dataResult = _Model2Last3Year;
                 mLast3Year.dataPrdActual = Convert.ToInt16(_Model3Last3Year);
                 //mLast3Year.dataSaleAmount = _SaleAmountLast3Year;
                 //mLast3Year.dataSaleExpRatio = _SaleExpRatioLast3Year;
                 //try
                 //{
                 //    mLast3Year.dataPrdPerUnit = Math.Ceiling(_ResLast3Year / _PrdActualLast3Year);
                 //}
                 //catch
                 //{
                 //    mLast3Year.dataPrdPerUnit = 0;
                 //}
                 //try
                 //{
                 //    mLast3Year.dataPrdPerUnitTarget = Math.Ceiling(_PrdTargetLast3Year / 12);
                 //}
                 //catch
                 //{
                 //    mLast3Year.dataPrdPerUnitTarget = 0;
                 //}
                 mLast3Year.dataCostCenter = pLast3Year;
                 mLast3Year.dataYearMonth = pLast3Year;
                 oAryResult.Add(mLast3Year);



                 MDHoldAllInfo.HoldAllChartInfo mLast2Year = new MDHoldAllInfo.HoldAllChartInfo();
                 mLast2Year.dataFGHold = _Model1Last2Year;
                 mLast2Year.dataResult = _Model2Last2Year;
                 mLast2Year.dataPrdActual = Convert.ToInt16(_Model3Last2Year);
                 //mLast2Year.dataSaleAmount = _SaleAmountLast2Year;
                 //mLast2Year.dataSaleExpRatio = _SaleExpRatioLast2Year;
                 //try
                 //{
                 //    mLast2Year.dataPrdPerUnit = Math.Ceiling(_ResLast2Year / _PrdActualLast2Year);
                 //}
                 //catch
                 //{
                 //    mLast2Year.dataPrdPerUnit = 0;
                 //}
                 //try
                 //{
                 //    mLast2Year.dataPrdPerUnitTarget = Math.Ceiling(_PrdTargetLast2Year / 12);
                 //}
                 //catch
                 //{
                 //    mLast2Year.dataPrdPerUnitTarget = 0;
                 //}
                 mLast2Year.dataCostCenter = pLast2Year;
                 mLast2Year.dataYearMonth = pLast2Year;
                 oAryResult.Add(mLast2Year);



                 MDHoldAllInfo.HoldAllChartInfo mLastYear = new MDHoldAllInfo.HoldAllChartInfo();
                 mLastYear.dataFGHold = _Model1LastYear;
                 mLastYear.dataResult = _Model2LastYear;
                 mLastYear.dataPrdActual = Convert.ToInt16(_Model3LastYear);
                 //mLastYear.dataSaleAmount = _SaleAmountLastYear;
                 //mLastYear.dataSaleExpRatio = _SaleExpRatioLastYear;
                 //try
                 //{
                 //    mLastYear.dataPrdPerUnit = Math.Ceiling(_ResLastYear / _PrdActualLastYear);
                 //}
                 //catch
                 //{
                 //    mLastYear.dataPrdPerUnit = 0;
                 //}
                 //try {
                 //    mLastYear.dataPrdPerUnitTarget = Math.Ceiling(_PrdTargetLastYear / 12);
                 //} catch {
                 //    mLastYear.dataPrdPerUnitTarget = 0;
                 //}
                 mLastYear.dataCostCenter = pLastYear;
                 mLastYear.dataYearMonth = pLastYear;
                 oAryResult.Add(mLastYear);





                 int ix = 0;
                 foreach (string _Month in ArryPeriod)
                 {
                     // add data 
                     MDHoldAllInfo.HoldAllChartInfo mExpense = new MDHoldAllInfo.HoldAllChartInfo();

                     if (_Month == "APR")
                     {
                         mExpense.dataFGHold = _InAPRFG;
                         mExpense.dataLineOut = _InAPRLO;
                         //mExpense.arrySeries = ArrySeires5;
                         //   mExpense.dataResult = ArrySeiresValue5;
                         //mExpense.dataPrdActual = _PrdAPR;
                         //mExpense.dataPrdPerUnitTarget = _TargetAPR;
                         //mExpense.dataSaleAmount = _SaleAmtAPR;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResAPR / _SaleAmtAPR), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResAPR / _PrdAPR); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "MAY")
                     {
                         mExpense.dataFGHold = _InMAYFG;
                         mExpense.dataLineOut = _InMAYLO;
                         //mExpense.arrySeries = ArrySeires5;
                         //mExpense.SeriesValue = ArrySeiresValue5;
                         // mExpense.dataResult = ArrySeiresValue5;
                         //mExpense.dataPrdActual = _PrdMAY;
                         //mExpense.dataPrdPerUnitTarget = _TargetMAY;
                         //mExpense.dataSaleAmount = _SaleAmtMAY;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResMAY / _SaleAmtMAY), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResMAY / _PrdMAY); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "JUN")
                     {
                         mExpense.dataFGHold = _InJUNFG;
                         mExpense.dataLineOut = _InJUNLO;
                         //mExpense.dataPrdActual = _PrdJUN;
                         //mExpense.dataPrdPerUnitTarget = _TargetJUN;
                         //mExpense.dataSaleAmount = _SaleAmtJUN;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResJUN / _SaleAmtJUN), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResJUN / _PrdJUN); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "JUL")
                     {
                         mExpense.dataFGHold = _InJUlFG;
                         mExpense.dataLineOut = _InJUlLO;
                         //mExpense.dataPrdActual = _PrdJUL;
                         //mExpense.dataPrdPerUnitTarget = _TargetJUL;
                         //mExpense.dataSaleAmount = _SaleAmtJUL;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResJUL / _SaleAmtJUL), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResJUL / _PrdJUL); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "AUG")
                     {
                         mExpense.dataFGHold = _InAUGFG;
                         mExpense.dataLineOut = _InAUGLO;
                         //mExpense.dataPrdActual = _PrdAUG;
                         //mExpense.dataPrdPerUnitTarget = _TargetAUG;
                         //mExpense.dataSaleAmount = _SaleAmtAUG;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResAUG / _SaleAmtAUG), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResAUG / _PrdAUG); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "SEP")
                     {
                         mExpense.dataFGHold = _InSEPFG;
                         mExpense.dataLineOut = _InSEPLO;
                         //mExpense.dataPrdActual = _PrdSEP;
                         //mExpense.dataPrdPerUnitTarget = _TargetSEP;
                         //mExpense.dataSaleAmount = _SaleAmtSEP;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResSEP / _SaleAmtSEP), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResSEP / _PrdSEP); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "OCT")
                     {
                         mExpense.dataFGHold = _InOCTFG;
                         mExpense.dataLineOut = _InOCTLO;
                         //mExpense.dataPrdActual = _PrdOCT;
                         //mExpense.dataPrdPerUnitTarget = _TargetOCT;
                         //mExpense.dataSaleAmount = _SaleAmtOCT;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResOCT / _SaleAmtOCT), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResOCT / _PrdOCT); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "NOV")
                     {
                         mExpense.dataFGHold = _InNOVFG;
                         mExpense.dataLineOut = _InNOVLO;
                         //mExpense.dataPrdActual = _PrdNOV;
                         //mExpense.dataPrdPerUnitTarget = _TargetNOV;
                         //mExpense.dataSaleAmount = _SaleAmtNOV;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResNOV / _SaleAmtNOV), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResNOV / _PrdNOV); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "DEC")
                     {
                         mExpense.dataFGHold = _InDECFG;
                         mExpense.dataLineOut = _InDECLO;
                         //mExpense.dataPrdActual = _PrdDEC;
                         //mExpense.dataPrdPerUnitTarget = _TargetDEC;
                         //mExpense.dataSaleAmount = _SaleAmtDEC;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResDEC / _SaleAmtDEC), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResDEC / _PrdDEC); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "JAN")
                     {
                         mExpense.dataFGHold = _InJANFG;
                         mExpense.dataLineOut = _InJANLO;
                         //mExpense.dataPrdActual = _PrdJAN;
                         //mExpense.dataPrdPerUnitTarget = _TargetJAN;
                         //mExpense.dataSaleAmount = _SaleAmtJAN;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResJAN / _SaleAmtJAN), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResJAN / _PrdJAN); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "FEB")
                     {
                         mExpense.dataFGHold = _InFEBFG;
                         mExpense.dataLineOut = _InFEBLO;
                         //mExpense.dataPrdActual = _PrdFEB;
                         //mExpense.dataPrdPerUnitTarget = _TargetFEB;
                         //mExpense.dataSaleAmount = _SaleAmtFEB;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResFEB / _SaleAmtFEB), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResFEB / _PrdFEB); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     else if (_Month == "MAR")
                     {
                         mExpense.dataFGHold = _InMARFG;
                         mExpense.dataLineOut = _InMARLO;
                         //mExpense.dataPrdActual = _PrdMAR;
                         //mExpense.dataPrdPerUnitTarget = _TargetMAR;
                         //mExpense.dataSaleAmount = _SaleAmtMAR;
                         //try { mExpense.dataSaleExpRatio = CeilingData((_ResMAR / _SaleAmtMAR), 2); }
                         //catch { mExpense.dataSaleExpRatio = 0; }
                         //try { mExpense.dataPrdPerUnit = Math.Ceiling(_ResMAR / _PrdMAR); }
                         //catch { mExpense.dataPrdPerUnit = 0; }
                     }
                     mExpense.dataCostCenter = _Month;
                     mExpense.dataYearMonth = _Month;
                     oAryResult.Add(mExpense);

                     ix++;
                 }

             #endregion
             }
         }
         return oAryResult;
     }

    public decimal CeilingData(decimal _dataNumber, int _digit) {
        string StrResult = "";
        decimal dataResult = 0;
        StrResult = _dataNumber.ToString("N"+_digit.ToString());

        try
        {
            dataResult = Convert.ToDecimal(StrResult);
        }
        catch { }

        return dataResult;
    }



    /*
    public List<MDCostBudgetInfo.ExpenseChartInfo> GetChartExpense(DateTime _DataDate, string _Type)
    {
        List<MDCostBudgetInfo.ExpenseChartInfo> oAryResult = new List<MDCostBudgetInfo.ExpenseChartInfo>();

        string[] ArryPrdALL = { "1101", "1102", "1201", "1202", "1301", "1302", "1401", "1402", "1501", "1701", "1702", "4310", "4320", "4510", "4720" };
        string[] ArryPrdFac1 = { "1101", "1102" };
        string[] ArryPrdFac2 = { "1201", "1202" };
        string[] ArryPrdFac3 = { "1701", "1702" };
        string[] ArryPrdODM = { "1501" };
        string[] ArryPeriod = { "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "JAN", "FEB", "MAR" };
        int[] ArryMonth = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };


        string pAccGroup = "EXP";
        string pBudgetType = "DI";
        string pYear = _DataDate.ToString("yyyy");
        DateTime _LastYear = new DateTime();
        _LastYear = _DataDate.AddYears(-1);
        string pLastYear = _LastYear.ToString("yyyy");

        int _PrdActualLastYear = 0;
        int[] _PrdActual = new int[12];
        decimal _InLastYear = 0;
        decimal _InAPR = 0;
        decimal _InMAY = 0;
        decimal _InJUN = 0;
        decimal _InJUL = 0;
        decimal _InAUG = 0;
        decimal _InSEP = 0;
        decimal _InOCT = 0;
        decimal _InNOV = 0;
        decimal _InDEC = 0;
        decimal _InJAN = 0;
        decimal _InFEB = 0;
        decimal _InMAR = 0;

        decimal _ResLastYear = 0;
        decimal _ResAPR = 0;
        decimal _ResMAY = 0;
        decimal _ResJUN = 0;
        decimal _ResJUL = 0;
        decimal _ResAUG = 0;
        decimal _ResSEP = 0;
        decimal _ResOCT = 0;
        decimal _ResNOV = 0;
        decimal _ResDEC = 0;
        decimal _ResJAN = 0;
        decimal _ResFEB = 0;
        decimal _ResMAR = 0;


        string[] ArryLoop = new string[0];
        string ConditionLine = "";
        if (_Type == "ALL")
        {
            ArryLoop = ArryPrdALL;
            ConditionLine = " ('1','2','3','4','5','6') ";
        }
        else if (_Type == "FAC1")
        {
            ArryLoop = ArryPrdFac1;
            ConditionLine = " ('1','2') ";
        }
        else if (_Type == "FAC2")
        {
            ArryLoop = ArryPrdFac2;
            ConditionLine = " ('3','5') ";
        }
        else if (_Type == "FAC3")
        {
            ArryLoop = ArryPrdFac3;
            ConditionLine = " ('6') ";
        }
        else if (_Type == "ODM")
        {
            ArryLoop = ArryPrdODM;
            ConditionLine = " ('0') ";
        }

        //**************************************
        //        Load Production Data
        //**************************************
        DateTime StartDateLast = new DateTime(_DataDate.Year, 4, 1, 8, 0, 0);
        DateTime EndDateLast = new DateTime(_DataDate.AddYears(1).Year, 4, 1, 7, 59, 59);
        DataTable dtPrdLast = new DataTable();
        string StrPrdLast = "SELECT COUNT(prd_serial) AS COUNTS " +
        " FROM PD_PackPrd " +
        " WHERE prd_date BETWEEN @StartDate AND @EndDate AND prd_line IN " + ConditionLine + " ";
        SqlCommand cmdPrdLast = new SqlCommand();
        cmdPrdLast.CommandText = StrPrdLast;
        cmdPrdLast.CommandTimeout = 180;
        cmdPrdLast.Parameters.Add(new SqlParameter("@StartDate", StartDateLast));
        cmdPrdLast.Parameters.Add(new SqlParameter("@EndDate", EndDateLast));
        dtPrdLast = oConDCI.Query(cmdPrdLast);
        try
        {
            if (dtPrdLast.Rows.Count == 1)
            {
                _PrdActualLastYear = Convert.ToInt32(dtPrdLast.Rows[0]["COUNTS"].ToString());
            }
            else
            {
                _PrdActualLastYear = 0;
            }
        }
        catch { _PrdActualLastYear = 0; }


        int idx = 0;
        foreach (string _Month in ArryPeriod)
        {
            DateTime StartDate = new DateTime();
            DateTime EndDate = new DateTime();

            // Check Data Year
            if (ArryMonth[idx] >= 4)
            {
                StartDate = new DateTime(_DataDate.Year, ArryMonth[idx], 1, 8, 0, 0);
                EndDate = new DateTime(_DataDate.Year, ArryMonth[idx], DateTime.DaysInMonth(_DataDate.Year, ArryMonth[idx]), 7, 59, 59);
            }
            else
            {
                StartDate = new DateTime(_DataDate.AddYears(1).Year, ArryMonth[idx], 1, 8, 0, 0);
                EndDate = new DateTime(_DataDate.AddYears(1).Year, ArryMonth[idx], DateTime.DaysInMonth(_DataDate.AddYears(1).Year, ArryMonth[idx]), 7, 59, 59);
            }

            //---- Check Have Production Data Actual ----
            if (DateTime.Now >= StartDate)
            {
                // -- Set to End of Night Shift --
                EndDate = EndDate.AddDays(1);

                DataTable dtPrd = new DataTable();
                string StrPrd = "SELECT COUNT(prd_serial) AS COUNTS " +
                " FROM PD_PackPrd " +
                " WHERE prd_date BETWEEN @StartDate AND @EndDate AND prd_line IN " + ConditionLine + " ";
                SqlCommand cmdPrd = new SqlCommand();
                cmdPrd.CommandText = StrPrd;
                cmdPrd.CommandTimeout = 180;
                cmdPrd.Parameters.Add(new SqlParameter("@StartDate", StartDate));
                cmdPrd.Parameters.Add(new SqlParameter("@EndDate", EndDate));
                dtPrd = oConDCI.Query(cmdPrd);
                try
                {
                    if (dtPrd.Rows.Count == 1)
                    {
                        _PrdActual[idx] = Convert.ToInt32(dtPrd.Rows[0]["COUNTS"].ToString());
                    }
                    else
                    {
                        _PrdActual[idx] = 0;
                    }
                }
                catch { _PrdActual[idx] = 0; }

            }
            else
            {
                _PrdActual[idx] = 0;
            }

            idx++;
        } // end foreach
        //**************************************
        //       End Load Production Data
        //**************************************






        // Loop CostCenter             
        foreach (string _CostCenter in ArryLoop)
        {
            string pCostcenter = _CostCenter;

            //*********************************************
            //              Data Last Year 
            //*********************************************
            DataTable dtLastYear = new DataTable();
            string StrLastYear = "sp_BudgetPrPerformance_Summary";
            SqlCommand cmdLastYear = new SqlCommand();
            cmdLastYear.CommandText = StrLastYear;
            cmdLastYear.CommandType = CommandType.StoredProcedure;
            cmdLastYear.Parameters.Add(new SqlParameter("@pCostcenter", pCostcenter));
            cmdLastYear.Parameters.Add(new SqlParameter("@pAccGroup", pAccGroup));
            cmdLastYear.Parameters.Add(new SqlParameter("@pBudgetType", pBudgetType));
            cmdLastYear.Parameters.Add(new SqlParameter("@pYear", pLastYear));
            dtLastYear = oConnBCS.Query(cmdLastYear);
            if (dtLastYear.Rows.Count > 0)
            {
                foreach (string _Month in ArryPeriod)
                {
                    decimal _Expense = 0;
                    decimal _Result = 0;
                    try
                    {
                        _Expense = Convert.ToDecimal(dtLastYear.Rows[0]["IN_" + _Month].ToString());
                    }
                    catch (Exception ex) { }

                    try
                    {
                        _Result = Convert.ToDecimal(dtLastYear.Rows[0]["RES_IN_" + _Month].ToString());
                    }
                    catch (Exception ex) { }

                    _InLastYear = _InLastYear + _Expense;
                    _ResLastYear = _ResLastYear + _Result;
                }
            }
            //*********************************************
            //            End Data Last Year 
            //*********************************************


            DataTable dtCost = new DataTable();
            string StrCost = "sp_BudgetPrPerformance_Summary";
            SqlCommand cmdCost = new SqlCommand();
            cmdCost.CommandText = StrCost;
            cmdCost.CommandType = CommandType.StoredProcedure;
            cmdCost.Parameters.Add(new SqlParameter("@pCostcenter", pCostcenter));
            cmdCost.Parameters.Add(new SqlParameter("@pAccGroup", pAccGroup));
            cmdCost.Parameters.Add(new SqlParameter("@pBudgetType", pBudgetType));
            cmdCost.Parameters.Add(new SqlParameter("@pYear", pYear));
            dtCost = oConnBCS.Query(cmdCost);

            if (dtCost.Rows.Count > 0)
            {

                try { _InAPR = _InAPR + Convert.ToDecimal(dtCost.Rows[0]["IN_APR"].ToString()); } catch { }
                try { _InMAY = _InMAY + Convert.ToDecimal(dtCost.Rows[0]["IN_MAY"].ToString()); } catch { }
                try { _InJUN = _InJUN + Convert.ToDecimal(dtCost.Rows[0]["IN_JUN"].ToString()); } catch { }
                try { _InJUL = _InJUL + Convert.ToDecimal(dtCost.Rows[0]["IN_JUL"].ToString()); } catch { }
                try { _InAUG = _InAUG + Convert.ToDecimal(dtCost.Rows[0]["IN_AUG"].ToString()); } catch { }
                try { _InSEP = _InSEP + Convert.ToDecimal(dtCost.Rows[0]["IN_SEP"].ToString()); } catch { }
                try { _InOCT = _InOCT + Convert.ToDecimal(dtCost.Rows[0]["IN_OCT"].ToString()); } catch { }
                try { _InNOV = _InNOV + Convert.ToDecimal(dtCost.Rows[0]["IN_NOV"].ToString()); } catch { }
                try { _InDEC = _InDEC + Convert.ToDecimal(dtCost.Rows[0]["IN_DEC"].ToString()); } catch { }
                try { _InJAN = _InJAN + Convert.ToDecimal(dtCost.Rows[0]["IN_JAN"].ToString()); } catch { }
                try { _InFEB = _InFEB + Convert.ToDecimal(dtCost.Rows[0]["IN_FEB"].ToString()); } catch { }
                try { _InMAR = _InMAR + Convert.ToDecimal(dtCost.Rows[0]["IN_MAR"].ToString()); } catch { }

                try { _ResAPR = _ResAPR + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_APR"].ToString()); } catch { }
                try { _ResMAY = _ResMAY + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_MAY"].ToString()); } catch { }
                try { _ResJUN = _ResJUN + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_JUN"].ToString()); } catch { }
                try { _ResJUL = _ResJUL + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_JUL"].ToString()); } catch { }
                try { _ResAUG = _ResAUG + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_AUG"].ToString()); } catch { }
                try { _ResSEP = _ResSEP + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_SEP"].ToString()); } catch { }
                try { _ResOCT = _ResOCT + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_OCT"].ToString()); } catch { }
                try { _ResNOV = _ResNOV + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_NOV"].ToString()); } catch { }
                try { _ResDEC = _ResDEC + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_DEC"].ToString()); } catch { }
                try { _ResJAN = _ResJAN + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_JAN"].ToString()); } catch { }
                try { _ResFEB = _ResFEB + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_FEB"].ToString()); } catch { }
                try { _ResMAR = _ResMAR + Convert.ToDecimal(dtCost.Rows[0]["RES_IN_MAR"].ToString()); } catch { }


            }// end if

        } // end foreach





        // add data 
        MDCostBudgetInfo.ExpenseChartInfo mLastYear = new MDCostBudgetInfo.ExpenseChartInfo();
        mLastYear.dataExpense = _InLastYear / 12;
        mLastYear.dataResult = _ResLastYear / 12;
        mLastYear.dataPrdActual = _PrdActualLastYear;
        mLastYear.dataPrdPerUnit = _PrdActualLastYear;
        mLastYear.dataCostCenter = pLastYear;
        mLastYear.dataYearMonth = pLastYear;
        oAryResult.Add(mLastYear);

        int ix = 0;
        foreach (string _Month in ArryPeriod)
        {
            // add data 
            MDCostBudgetInfo.ExpenseChartInfo mExpense = new MDCostBudgetInfo.ExpenseChartInfo();

            if (_Month == "APR")
            {
                mExpense.dataExpense = _InAPR;
                mExpense.dataResult = _ResAPR;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResAPR / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "MAY")
            {
                mExpense.dataExpense = _InMAY;
                mExpense.dataResult = _ResMAY;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResMAY / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "JUN")
            {
                mExpense.dataExpense = _InJUN;
                mExpense.dataResult = _ResJUN;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResJUN / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "JUL")
            {
                mExpense.dataExpense = _InJUL;
                mExpense.dataResult = _ResJUL;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResJUL / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "AUG")
            {
                mExpense.dataExpense = _InAUG;
                mExpense.dataResult = _ResAUG;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResAUG / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "SEP")
            {
                mExpense.dataExpense = _InSEP;
                mExpense.dataResult = _ResSEP;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResSEP / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "OCT")
            {
                mExpense.dataExpense = _InOCT;
                mExpense.dataResult = _ResOCT;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResOCT / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "NOV")
            {
                mExpense.dataExpense = _InNOV;
                mExpense.dataResult = _ResNOV;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResNOV / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "DEC")
            {
                mExpense.dataExpense = _InDEC;
                mExpense.dataResult = _ResDEC;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResDEC / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "JAN")
            {
                mExpense.dataExpense = _InJAN;
                mExpense.dataResult = _ResJAN;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResJAN / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "FEB")
            {
                mExpense.dataExpense = _InFEB;
                mExpense.dataResult = _ResFEB;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResFEB / Convert.ToDecimal(_PrdActual[ix]));
            }
            else if (_Month == "MAR")
            {
                mExpense.dataExpense = _InMAR;
                mExpense.dataResult = _ResMAR;
                mExpense.dataPrdPerUnit = Math.Ceiling(_ResMAR / Convert.ToDecimal(_PrdActual[ix]));

            }

            mExpense.dataPrdActual = _PrdActual[ix];
            mExpense.dataCostCenter = _Month;
            mExpense.dataYearMonth = _Month;
            oAryResult.Add(mExpense);

            ix++;
        } // end foreach


        return oAryResult;
    }



    public List<MDCostBudgetInfo.ExpenseChartInfo> GetChartExpenseMonth(string _CostCenter, DateTime _DataDate)
    {
        List<MDCostBudgetInfo.ExpenseChartInfo> oAryResult = new List<MDCostBudgetInfo.ExpenseChartInfo>();

        string[] ArryPeriod = { "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "JAN", "FEB", "MAR" };

        string pCostcenter = _CostCenter;
        string pAccGroup = "EXP";
        string pBudgetType = "DI";
        string pYear = _DataDate.ToString("yyyy");


        //*********************************************
        //              Data Last Year 
        //*********************************************
        DateTime _LastYear = new DateTime();
        _LastYear = _DataDate.AddYears(-1);
        string pLastYear = _LastYear.ToString("yyyy");


        DataTable dtLastYear = new DataTable();
        string StrLastYear = "sp_BudgetPrPerformance_Summary";
        SqlCommand cmdLastYear = new SqlCommand();
        cmdLastYear.CommandText = StrLastYear;
        cmdLastYear.CommandType = CommandType.StoredProcedure;
        cmdLastYear.Parameters.Add(new SqlParameter("@pCostcenter", pCostcenter));
        cmdLastYear.Parameters.Add(new SqlParameter("@pAccGroup", pAccGroup));
        cmdLastYear.Parameters.Add(new SqlParameter("@pBudgetType", pBudgetType));
        cmdLastYear.Parameters.Add(new SqlParameter("@pYear", pLastYear));
        dtLastYear = oConnBCS.Query(cmdLastYear);
        if (dtLastYear.Rows.Count > 0)
        {
            decimal _AccExpense = 0;
            decimal _AccResult = 0;
            foreach (string _Month in ArryPeriod)
            {
                decimal _Expense = 0;
                decimal _Result = 0;
                try
                {
                    _Expense = Convert.ToDecimal(dtLastYear.Rows[0]["IN_" + _Month].ToString());
                }
                catch (Exception ex) { }

                try
                {
                    _Result = Convert.ToDecimal(dtLastYear.Rows[0]["RES_IN_" + _Month].ToString());
                }
                catch (Exception ex) { }

                _AccExpense = _AccExpense + _Expense;
                _AccResult = _AccResult + _Result;
            }

            MDCostBudgetInfo.ExpenseChartInfo mExpense = new MDCostBudgetInfo.ExpenseChartInfo();
            // add data 
            mExpense.dataExpense = _AccExpense / 12;
            mExpense.dataResult = _AccResult / 12;
            mExpense.dataCostCenter = pLastYear;
            mExpense.dataYearMonth = pLastYear;
            oAryResult.Add(mExpense);
        }
        //*********************************************
        //            End Data Last Year 
        //*********************************************


        DataTable dtCost = new DataTable();
        string StrCost = "sp_BudgetPrPerformance_Summary";
        SqlCommand cmdCost = new SqlCommand();
        cmdCost.CommandText = StrCost;
        cmdCost.CommandType = CommandType.StoredProcedure;
        cmdCost.Parameters.Add(new SqlParameter("@pCostcenter", pCostcenter));
        cmdCost.Parameters.Add(new SqlParameter("@pAccGroup", pAccGroup));
        cmdCost.Parameters.Add(new SqlParameter("@pBudgetType", pBudgetType));
        cmdCost.Parameters.Add(new SqlParameter("@pYear", pYear));
        dtCost = oConnBCS.Query(cmdCost);

        if (dtCost.Rows.Count > 0)
        {
            foreach (string _Month in ArryPeriod)
            {
                MDCostBudgetInfo.ExpenseChartInfo mExpense = new MDCostBudgetInfo.ExpenseChartInfo();

                decimal _Expense = 0;
                decimal _Result = 0;
                string yearmonth = _Month;

                try
                {
                    _Expense = Convert.ToDecimal(dtCost.Rows[0]["IN_" + _Month].ToString());
                }
                catch (Exception ex)
                {
                    //yearmonth = ex.Message.ToString();
                }

                try
                {
                    _Result = Convert.ToDecimal(dtCost.Rows[0]["RES_IN_" + _Month].ToString());
                }
                catch (Exception ex)
                {
                    //yearmonth = ex.Message.ToString();
                }


                // add data 
                mExpense.dataExpense = _Expense;
                mExpense.dataResult = _Result;
                mExpense.dataCostCenter = _CostCenter;
                mExpense.dataYearMonth = yearmonth;
                oAryResult.Add(mExpense);

            } // end foreach
        }// end if



        return oAryResult;
    }
    */



    public string StrDataLast { get; set; }
}