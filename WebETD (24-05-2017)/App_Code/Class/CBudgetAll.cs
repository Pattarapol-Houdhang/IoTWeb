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
public class CBudgetAll
{
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();

    public CBudgetAll()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    string[] ArryPrd = { "1YC", "2YC", "SCR", "1YC/3", "ODM" };
    string[] ArryPrdALL = { "1101", "1102", "1201", "1202", "1301", "1302", "1401", "1402", "1501", "1701", "1702", "4310", "4320", "4510", "4520", "4720", "8120" };
    string[] ArryPrdProduction = { "1101", "1102", "1201", "1202", "1301", "1302", "1401", "1402", "1501", "1701", "1702", "4310", "4320" };
    string[] ArryPrdFac1 = { "1101", "1102" };
    string[] ArryPrdFac1M = { "1101" };
    string[] ArryPrdFac1A = { "1102" };
    string[] ArryPrdFac2 = { "1201", "1202" };
    string[] ArryPrdFac2M = { "1201" };
    string[] ArryPrdFac2A = { "1202" };
    string[] ArryPrdSRC = { "1301", "1302" };
    string[] ArryPrdSRCA = { "1301" };
    string[] ArryPrdSRCM = { "1302" };
    string[] ArryPrdFac3 = { "1701", "1702" };
    string[] ArryPrdFac3M = { "1701" };
    string[] ArryPrdFac3A = { "1702" };
    string[] ArryPrdMOT = { "1401" };
    string[] ArryPrdAL5 = { "1402" };
    string[] ArryPrdODM = { "1501" };
    string[] ArryPrdMTM = { "4310" };
    string[] ArryPrdMTA = { "4320" };
    string[] ArryPrdTD = { "7720" };

    string[] ArryProcurement = { "4110", "4130", "4910" };
    string[] ArryPU = { "4110" };
    string[] ArrySPU = { "4130" };
    string[] ArrySP = { "4910" };

    string[] ArryPrdControl = { "4210", "4610", "4620", "4140" };
    string[] ArryPrdIM = { "4610" };
    string[] ArryPrdPS = { "4620" };
    string[] ArryPrdDC = { "4140" };

    string[] ArryEngineer = { "4410", "4420", "4430" };
    string[] ArryENA = { "4610" };
    string[] ArryENM = { "4620" };
    string[] ArryENMOT = { "4140" };

    string[] ArryPrdEC = { "4510", "4520" };
    string[] ArryPrdUT = { "4510" };
    string[] ArryPrdWC = { "4520" };

    string[] ArryPrdQuality = { "4710", "4720", "4830" };
    string[] ArryPrdQA = { "4710" };
    string[] ArryPrdQC = { "4720" };
    string[] ArryPrdQS = { "4830" };

    string[] ArryDesignDevelop = { "4810", "4820" };
    string[] ArryDD = { "4810" };
    string[] ArryCD = { "4820" };

    string[] ArryAdmin = { "7220" };
    string[] ArryPrdDCICenter = { "8120" };
    string[] ArryPeriod = { "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "JAN", "FEB", "MAR" };
    string[] ArryPhysicalPeriod = { "JAN", "FEB", "MAR","APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
    int[] ArryMonth = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };


    public List<MDCostBudgetInfo.ExpenseChartInfo> GetChartExpenseReport(DateTime _DataDate, string _Type)
    {
        
        List<MDCostBudgetInfo.ExpenseChartInfo> oAryResult = new List<MDCostBudgetInfo.ExpenseChartInfo>();

        
        string pAccGroup = "EXP";
        string pYear = _DataDate.ToString("yyyy");
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
        decimal _InLastYear = 0;
        decimal _InLast2Year = 0;
        decimal _InLast3Year = 0;
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

        decimal _AccuResAPR = 0;
        decimal _AccuResMAY = 0;
        decimal _AccuResJUN = 0;
        decimal _AccuResJUL = 0;
        decimal _AccuResAUG = 0;
        decimal _AccuResSEP = 0;
        decimal _AccuResOCT = 0;
        decimal _AccuResNOV = 0;
        decimal _AccuResDEC = 0;
        decimal _AccuResJAN = 0;
        decimal _AccuResFEB = 0;
        decimal _AccuResMAR = 0;

        decimal _AccuBudAPR = 0;
        decimal _AccuBudMAY = 0;
        decimal _AccuBudJUN = 0;
        decimal _AccuBudJUL = 0;
        decimal _AccuBudAUG = 0;
        decimal _AccuBudSEP = 0;
        decimal _AccuBudOCT = 0;
        decimal _AccuBudNOV = 0;
        decimal _AccuBudDEC = 0;
        decimal _AccuBudJAN = 0;
        decimal _AccuBudFEB = 0;
        decimal _AccuBudMAR = 0;

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
        

        string[] ArryLoop = new string[0];
        string ProductType = "";
        string TargetType = "";
        ArryLoop = GetArrayLoopData(_Type);
        ProductType = GetProductTypeData(_Type);
        TargetType = GetTargetTypeData(_Type);

        #endregion  




        #region Last Year


        #region Last Year 1
        //*********************************************
        //         Get Data Last Year
        //*********************************************

        DataTable dtDataLast = new DataTable();
        string StrDataLast = "SELECT Focal_year, AccGroup, " +
            "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
            " FROM BC_REPORT " +
            " WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup " +
            " GROUP BY Focal_year, AccGroup";
        SqlCommand cmdDataLast = new SqlCommand();
        cmdDataLast.CommandText = StrDataLast;
        cmdDataLast.CommandTimeout = 180;
        cmdDataLast.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdDataLast.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
        dtDataLast = oConnBCS.Query(cmdDataLast);

        if (dtDataLast.Rows.Count > 0)
        {
            try { _InLastYear = Convert.ToDecimal(dtDataLast.Rows[0]["Total_IN"].ToString()); } catch { }
            try { _ResLastYear = Convert.ToDecimal(dtDataLast.Rows[0]["Total_RES_IN"].ToString()); } catch { }
        }

        //********* Loop Production Last Year ***********
        foreach (string prdType in ArryPrd)
        {
            DataTable dtPrdLast = new DataTable();
            string StrPrdLast = @"SELECT Fiscal_year,ProductType, Total_PRD 
                    FROM BC_PRODUCTION
                    WHERE Fiscal_year=@Fiscal_year AND ProductType = @ProductType ";
            SqlCommand cmdPrdLast = new SqlCommand();
            cmdPrdLast.CommandText = StrPrdLast;
            cmdPrdLast.CommandTimeout = 180;
            cmdPrdLast.Parameters.Add(new SqlParameter("@Fiscal_year", pLastYear));
            cmdPrdLast.Parameters.Add(new SqlParameter("@ProductType", prdType));
            dtPrdLast = oConnBCS.Query(cmdPrdLast);
            if (dtPrdLast.Rows.Count > 0)
            {
                if (prdType == "ODM")
                {
                    try { _PrdActualLastYear += (Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()) / 20); } catch { }
                }
                else {
                    try { _PrdActualLastYear += Convert.ToInt32(dtPrdLast.Rows[0]["Total_PRD"].ToString()); } catch { }
                }

            }
        }
        //********* Loop Production Last Year ***********


        //********* Sale Amount / Sale Ratio *************
        DataTable dtSaleLast = new DataTable();
        string StrSaleLast = @"SELECT SUM(SA_Total) AS SA_Total, SUM(SA_QTY_Total) AS SA_QTY_Total  
            FROM BC_SALE_AMOUNT 
            WHERE Fiscal_year=@Fiscal_year  ";
        SqlCommand cmdSaleLast = new SqlCommand();
        cmdSaleLast.CommandText = StrSaleLast;
        cmdSaleLast.CommandTimeout = 180;
        cmdSaleLast.Parameters.Add(new SqlParameter("@Fiscal_year", pLastYear));
        dtSaleLast = oConnBCS.Query(cmdSaleLast);

        if (dtSaleLast.Rows.Count > 0)
        {
            try { _SaleAmountLastYear = Convert.ToDecimal(dtSaleLast.Rows[0]["SA_Total"].ToString()); } catch { }
            try { _SaleExpRatioLastYear = Convert.ToInt32(dtSaleLast.Rows[0]["SA_QTY_Total"].ToString()); } catch { }
        }


        //*********************************************
        //        End Get Data Last Year
        //*********************************************
        #endregion


        #region Last Year 2
        //*********************************************
        //         Get Data Last Year
        //*********************************************
        
        DataTable dtDataLast2 = new DataTable();
        string StrDataLast2 = "SELECT Focal_year, AccGroup,  " +
            "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
            " FROM BC_REPORT " +
            " WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup " +
            " GROUP BY Focal_year, AccGroup ";
        SqlCommand cmdDataLast2 = new SqlCommand();
        cmdDataLast2.CommandText = StrDataLast2;
        cmdDataLast2.CommandTimeout = 180;
        cmdDataLast2.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdDataLast2.Parameters.Add(new SqlParameter("@Focal_year", pLast2Year));
        dtDataLast2 = oConnBCS.Query(cmdDataLast2);

        if (dtDataLast2.Rows.Count > 0)
        {
            try { _InLast2Year = Convert.ToDecimal(dtDataLast2.Rows[0]["Total_IN"].ToString()); } catch { }
            try { _ResLast2Year = Convert.ToDecimal(dtDataLast2.Rows[0]["Total_RES_IN"].ToString()); } catch { }
        }

        //********* Loop Production Last Year ***********
        foreach (string prdType in ArryPrd)
        {
            DataTable dtPrdLast2 = new DataTable();
            string StrPrdLast2 = @"SELECT Fiscal_year,ProductType, Total_PRD 
                    FROM BC_PRODUCTION
                    WHERE Fiscal_year=@Fiscal_year AND ProductType = @ProductType ";
            SqlCommand cmdPrdLast2 = new SqlCommand();
            cmdPrdLast2.CommandText = StrPrdLast2;
            cmdPrdLast2.CommandTimeout = 180;
            cmdPrdLast2.Parameters.Add(new SqlParameter("@Fiscal_year", pLast2Year));
            cmdPrdLast2.Parameters.Add(new SqlParameter("@ProductType", prdType));
            dtPrdLast2 = oConnBCS.Query(cmdPrdLast2);
            if (dtPrdLast2.Rows.Count > 0)
            {
                if (prdType == "ODM")
                {
                    try { _PrdActualLast2Year += (Convert.ToInt32(dtPrdLast2.Rows[0]["Total_PRD"].ToString()) / 20); } catch { }
                }
                else
                {
                    try { _PrdActualLast2Year += Convert.ToInt32(dtPrdLast2.Rows[0]["Total_PRD"].ToString()); } catch { }
                }

            }
        }
        //********* Loop Production Last Year ***********


        //********* Sale Amount / Sale Ratio *************
        DataTable dtSaleLast2 = new DataTable();
        string StrSaleLast2 = @"SELECT SUM(SA_Total) AS SA_Total, SUM(SA_QTY_Total) AS SA_QTY_Total 
            FROM BC_SALE_AMOUNT 
            WHERE Fiscal_year=@Fiscal_year  ";
        SqlCommand cmdSaleLast2 = new SqlCommand();
        cmdSaleLast2.CommandText = StrSaleLast2;
        cmdSaleLast2.CommandTimeout = 180;
        cmdSaleLast2.Parameters.Add(new SqlParameter("@Fiscal_year", pLast2Year));
        dtSaleLast2 = oConnBCS.Query(cmdSaleLast2);

        if (dtSaleLast2.Rows.Count > 0)
        {
            try { _SaleAmountLast2Year = Convert.ToDecimal(dtSaleLast2.Rows[0]["SA_Total"].ToString()); } catch { }
            try { _SaleExpRatioLast2Year = Convert.ToInt32(dtSaleLast2.Rows[0]["SA_QTY_Total"].ToString()); } catch { }
        }



        
        //*********************************************
        //        End Get Data Last Year
        //*********************************************
        #endregion


        #region Last Year 3
        //*********************************************
        //         Get Data Last Year
        //*********************************************
        
        DataTable dtDataLast3 = new DataTable();
        string StrDataLast3 = "SELECT Focal_year, AccGroup,  " +
            "    SUM(Total_IN) AS Total_IN, SUM(Total_RES_IN) AS Total_RES_IN " +
            " FROM BC_REPORT " +
            " WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup " +
            " GROUP BY Focal_year, AccGroup ";
        SqlCommand cmdDataLast3 = new SqlCommand();
        cmdDataLast3.CommandText = StrDataLast3;
        cmdDataLast3.CommandTimeout = 180;
        cmdDataLast3.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdDataLast3.Parameters.Add(new SqlParameter("@Focal_year", pLast3Year));
        dtDataLast3 = oConnBCS.Query(cmdDataLast3);

        if (dtDataLast3.Rows.Count > 0)
        {
            try { _InLast3Year = Convert.ToDecimal(dtDataLast3.Rows[0]["Total_IN"].ToString()); } catch { }
            try { _ResLast3Year = Convert.ToDecimal(dtDataLast3.Rows[0]["Total_RES_IN"].ToString()); } catch { }
        }

        //********* Loop Production Last Year ***********
        foreach (string prdType in ArryPrd)
        {
            DataTable dtPrdLast3 = new DataTable();
            string StrPrdLast3 = @"SELECT Fiscal_year,ProductType, Total_PRD 
                    FROM BC_PRODUCTION
                    WHERE Fiscal_year=@Fiscal_year AND ProductType = @ProductType ";
            SqlCommand cmdPrdLast3 = new SqlCommand();
            cmdPrdLast3.CommandText = StrPrdLast3;
            cmdPrdLast3.CommandTimeout = 180;
            cmdPrdLast3.Parameters.Add(new SqlParameter("@Fiscal_year", pLast3Year));
            cmdPrdLast3.Parameters.Add(new SqlParameter("@ProductType", prdType));
            dtPrdLast3 = oConnBCS.Query(cmdPrdLast3);
            if (dtPrdLast3.Rows.Count > 0)
            {
                if (prdType == "ODM")
                {
                    try { _PrdActualLast3Year += (Convert.ToInt32(dtPrdLast3.Rows[0]["Total_PRD"].ToString()) / 20); } catch { }
                }
                else
                {
                    try { _PrdActualLast3Year += Convert.ToInt32(dtPrdLast3.Rows[0]["Total_PRD"].ToString()); } catch { }
                }

            }
        }
        //********* Loop Production Last Year ***********


        //********* Sale Amount / Sale Ratio *************
        DataTable dtSaleLast3 = new DataTable();
        string StrSaleLast3 = @"SELECT SUM(SA_Total) AS SA_Total, SUM(SA_QTY_Total) AS SA_QTY_Total 
            FROM BC_SALE_AMOUNT 
            WHERE Fiscal_year=@Fiscal_year  ";
        SqlCommand cmdSaleLast3 = new SqlCommand();
        cmdSaleLast3.CommandText = StrSaleLast3;
        cmdSaleLast3.CommandTimeout = 180;
        cmdSaleLast3.Parameters.Add(new SqlParameter("@Fiscal_year", pLast3Year));
        dtSaleLast3 = oConnBCS.Query(cmdSaleLast3);

        if (dtSaleLast3.Rows.Count > 0)
        {
            try { _SaleAmountLast3Year = Convert.ToDecimal(dtSaleLast3.Rows[0]["SA_Total"].ToString()); } catch { }
            try { _SaleExpRatioLast3Year = Convert.ToInt32(dtSaleLast3.Rows[0]["SA_QTY_Total"].ToString()); } catch { }
        }

        
        //*********************************************
        //        End Get Data Last Year
        //*********************************************
        #endregion


        #endregion




        //********* Target Last Year ***********
        #region Target
        DataTable dtPrdTarget = new DataTable();
        string StrPrdTarget = @"SELECT *  
                    FROM BC_TARGET
                    WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup 
                     AND Cost_Center = @Cost_Center ";
        SqlCommand cmdPrdTarget = new SqlCommand();
        cmdPrdTarget.CommandText = StrPrdTarget;
        cmdPrdTarget.CommandTimeout = 180;
        cmdPrdTarget.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdPrdTarget.Parameters.Add(new SqlParameter("@Focal_year", pLastYear));
        cmdPrdTarget.Parameters.Add(new SqlParameter("@Cost_Center", TargetType));
        dtPrdTarget = oConnBCS.Query(cmdPrdTarget);
        if (dtPrdTarget.Rows.Count > 0)
        {
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_APR"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_MAY"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_JUN"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_JUL"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_AUG"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_SEP"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_OCT"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_NOV"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_DEC"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_JAN"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_FEB"].ToString()); } catch { }
            try { _PrdTargetLastYear += Convert.ToDecimal(dtPrdTarget.Rows[0]["TG_MAR"].ToString()); } catch { }
        }


        //********* Target Last 2 Year ***********
        DataTable dtPrdTarget2 = new DataTable();
        string StrPrdTarget2 = @"SELECT *  
                    FROM BC_TARGET
                    WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup 
                       AND Cost_Center = @Cost_Center ";
        SqlCommand cmdPrdTarget2 = new SqlCommand();
        cmdPrdTarget2.CommandText = StrPrdTarget2;
        cmdPrdTarget2.CommandTimeout = 180;
        cmdPrdTarget2.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdPrdTarget2.Parameters.Add(new SqlParameter("@Focal_year", pLast2Year));
        cmdPrdTarget2.Parameters.Add(new SqlParameter("@Cost_Center", TargetType));
        dtPrdTarget2 = oConnBCS.Query(cmdPrdTarget2);
        if (dtPrdTarget2.Rows.Count > 0)
        {
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_APR"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_MAY"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_JUN"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_JUL"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_AUG"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_SEP"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_OCT"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_NOV"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_DEC"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_JAN"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_FEB"].ToString()); } catch { }
            try { _PrdTargetLast2Year += Convert.ToDecimal(dtPrdTarget2.Rows[0]["TG_MAR"].ToString()); } catch { }
        }


        //********* Target Last 3 Year ***********
        DataTable dtPrdTarget3 = new DataTable();
        string StrPrdTarget3 = @"SELECT *  
                    FROM BC_TARGET
                    WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup 
                        AND Cost_Center = @Cost_Center ";
        SqlCommand cmdPrdTarget3 = new SqlCommand();
        cmdPrdTarget3.CommandText = StrPrdTarget3;
        cmdPrdTarget3.CommandTimeout = 180;
        cmdPrdTarget3.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdPrdTarget3.Parameters.Add(new SqlParameter("@Focal_year", pLast3Year));
        cmdPrdTarget3.Parameters.Add(new SqlParameter("@Cost_Center", TargetType));
        dtPrdTarget3 = oConnBCS.Query(cmdPrdTarget3);
        if (dtPrdTarget3.Rows.Count > 0)
        {
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_APR"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_MAY"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_JUN"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_JUL"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_AUG"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_SEP"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_OCT"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_NOV"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_DEC"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_JAN"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_FEB"].ToString()); } catch { }
            try { _PrdTargetLast3Year += Convert.ToDecimal(dtPrdTarget3.Rows[0]["TG_MAR"].ToString()); } catch { }
        }

        #endregion





        //*********************************************
        //         Get Data 
        //*********************************************

        DataTable dtData = new DataTable();
        DataTable dtPrd = new DataTable();

        string StrData = "SELECT * FROM BC_REPORT " +
            " WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup ";
        SqlCommand cmdData = new SqlCommand();
        cmdData.CommandText = StrData;
        cmdData.CommandTimeout = 180;
        cmdData.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdData.Parameters.Add(new SqlParameter("@Focal_year", pYear));
        dtData = oConnBCS.Query(cmdData);

        //********* Loop Production Last Year ***********
        foreach (string prdType in ArryPrd)
        {
            string StrPrd = @"SELECT Fiscal_year,ProductType, PRD_APR,PRD_MAY,PRD_JUN,
                    PRD_JUL,PRD_AUG,PRD_SEP,PRD_OCT,PRD_NOV,PRD_DEC,PRD_JAN,PRD_FEB,PRD_MAR
                FROM BC_PRODUCTION
                WHERE Fiscal_year=@Fiscal_year AND ProductType = @ProductType ";
            SqlCommand cmdPrd = new SqlCommand();
            cmdPrd.CommandText = StrPrd;
            cmdPrd.CommandTimeout = 180;
            cmdPrd.Parameters.Add(new SqlParameter("@Fiscal_year", pYear));
            cmdPrd.Parameters.Add(new SqlParameter("@ProductType", prdType));
            dtPrd = oConnBCS.Query(cmdPrd);


            _PrdAPR += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "APR");
            _PrdMAY += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "MAY");
            _PrdJUN += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "JUN");
            _PrdJUL += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "JUL");
            _PrdAUG += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "AUG");
            _PrdSEP += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "SEP");
            _PrdOCT += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "OCT");
            _PrdNOV += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "NOV");
            _PrdDEC += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "DEC");
            _PrdJAN += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "JAN");
            _PrdFEB += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "FEB");
            _PrdMAR += AccumulateIntData(dtPrd.Rows[0], (prdType == "ODM") ? true : false, "PRD", "MAR");

        } // end foreach


        //*****************************************
        //             Sale Amount
        //*****************************************
        DataTable dtSale = new DataTable();
        string StrSale = @"SELECT Fiscal_year, SUM(SA_APR) AS SA_APR, SUM(SA_MAY) AS SA_MAY, 
                SUM(SA_JUN) AS SA_JUN, SUM(SA_JUL) AS SA_JUL, SUM(SA_AUG) AS SA_AUG, 
                SUM(SA_SEP) AS SA_SEP, SUM(SA_OCT) AS SA_OCT, SUM(SA_NOV) AS SA_NOV, 
                SUM(SA_DEC) AS SA_DEC, SUM(SA_JAN) AS SA_JAN, SUM(SA_FEB) AS SA_FEB, 
                SUM(SA_MAR) AS SA_MAR
            FROM  BC_SALE_AMOUNT 
            WHERE Fiscal_year=@Fiscal_year 
            GROUP BY Fiscal_year ";
        SqlCommand cmdSale = new SqlCommand();
        cmdSale.CommandText = StrSale;
        cmdSale.CommandTimeout = 180;
        cmdSale.Parameters.Add(new SqlParameter("@Fiscal_year", pYear));
        dtSale = oConnBCS.Query(cmdSale);


        _SaleAmtAPR = AccumulateFloatData(dtSale.Rows[0], "SA", "APR");
        _SaleAmtMAY = AccumulateFloatData(dtSale.Rows[0], "SA", "MAY");
        _SaleAmtJUN = AccumulateFloatData(dtSale.Rows[0], "SA", "JUN");
        _SaleAmtJUL = AccumulateFloatData(dtSale.Rows[0], "SA", "JUL");
        _SaleAmtAUG = AccumulateFloatData(dtSale.Rows[0], "SA", "AUG");
        _SaleAmtSEP = AccumulateFloatData(dtSale.Rows[0], "SA", "SEP");
        _SaleAmtOCT = AccumulateFloatData(dtSale.Rows[0], "SA", "OCT");
        _SaleAmtNOV = AccumulateFloatData(dtSale.Rows[0], "SA", "NOV");
        _SaleAmtDEC = AccumulateFloatData(dtSale.Rows[0], "SA", "DEC");
        _SaleAmtJAN = AccumulateFloatData(dtSale.Rows[0], "SA", "JAN");
        _SaleAmtFEB = AccumulateFloatData(dtSale.Rows[0], "SA", "FEB");
        _SaleAmtMAR = AccumulateFloatData(dtSale.Rows[0], "SA", "MAR");






        //********* Target Production ***********
        DataTable dtTarget = new DataTable();
        string StrTarget = @"SELECT *  
                    FROM BC_TARGET
                    WHERE Focal_year=@Focal_year AND AccGroup=@AccGroup AND Cost_Center = @Cost_Center ";
        SqlCommand cmdTarget = new SqlCommand();
        cmdTarget.CommandText = StrTarget;
        cmdTarget.CommandTimeout = 180;
        cmdTarget.Parameters.Add(new SqlParameter("@AccGroup", pAccGroup));
        cmdTarget.Parameters.Add(new SqlParameter("@Focal_year", pYear));
        cmdTarget.Parameters.Add(new SqlParameter("@Cost_Center", TargetType));
        dtTarget = oConnBCS.Query(cmdTarget);
        if (dtTarget.Rows.Count > 0)
        {
            try { _TargetAPR = Convert.ToDecimal(dtTarget.Rows[0]["TG_APR"].ToString()); } catch { }
            try { _TargetMAY = Convert.ToDecimal(dtTarget.Rows[0]["TG_MAY"].ToString()); } catch { }
            try { _TargetJUN = Convert.ToDecimal(dtTarget.Rows[0]["TG_JUN"].ToString()); } catch { }
            try { _TargetJUL = Convert.ToDecimal(dtTarget.Rows[0]["TG_JUL"].ToString()); } catch { }
            try { _TargetAUG = Convert.ToDecimal(dtTarget.Rows[0]["TG_AUG"].ToString()); } catch { }
            try { _TargetSEP = Convert.ToDecimal(dtTarget.Rows[0]["TG_SEP"].ToString()); } catch { }
            try { _TargetOCT = Convert.ToDecimal(dtTarget.Rows[0]["TG_OCT"].ToString()); } catch { }
            try { _TargetNOV = Convert.ToDecimal(dtTarget.Rows[0]["TG_NOV"].ToString()); } catch { }
            try { _TargetDEC = Convert.ToDecimal(dtTarget.Rows[0]["TG_DEC"].ToString()); } catch { }
            try { _TargetJAN = Convert.ToDecimal(dtTarget.Rows[0]["TG_JAN"].ToString()); } catch { }
            try { _TargetFEB = Convert.ToDecimal(dtTarget.Rows[0]["TG_FEB"].ToString()); } catch { }
            try { _TargetMAR = Convert.ToDecimal(dtTarget.Rows[0]["TG_MAR"].ToString()); } catch { }
        }



        if (dtData.Rows.Count > 0)
        {
            foreach (DataRow drData in dtData.Rows)
            {


                try { _InAPR += Convert.ToDecimal(drData["IN_APR"].ToString()); } catch { }
                try { _InMAY += Convert.ToDecimal(drData["IN_MAY"].ToString()); } catch { }
                try { _InJUN += Convert.ToDecimal(drData["IN_JUN"].ToString()); } catch { }
                try { _InJUL += Convert.ToDecimal(drData["IN_JUL"].ToString()); } catch { }
                try { _InAUG += Convert.ToDecimal(drData["IN_AUG"].ToString()); } catch { }
                try { _InSEP += Convert.ToDecimal(drData["IN_SEP"].ToString()); } catch { }
                try { _InOCT += Convert.ToDecimal(drData["IN_OCT"].ToString()); } catch { }
                try { _InNOV += Convert.ToDecimal(drData["IN_NOV"].ToString()); } catch { }
                try { _InDEC += Convert.ToDecimal(drData["IN_DEC"].ToString()); } catch { }
                try { _InJAN += Convert.ToDecimal(drData["IN_JAN"].ToString()); } catch { }
                try { _InFEB += Convert.ToDecimal(drData["IN_FEB"].ToString()); } catch { }
                try { _InMAR += Convert.ToDecimal(drData["IN_MAR"].ToString()); } catch { }

                try { _ResAPR += Convert.ToDecimal(drData["RES_IN_APR"].ToString()); } catch { }
                try { _ResMAY += Convert.ToDecimal(drData["RES_IN_MAY"].ToString()); } catch { }
                try { _ResJUN += Convert.ToDecimal(drData["RES_IN_JUN"].ToString()); } catch { }
                try { _ResJUL += Convert.ToDecimal(drData["RES_IN_JUL"].ToString()); } catch { }
                try { _ResAUG += Convert.ToDecimal(drData["RES_IN_AUG"].ToString()); } catch { }
                try { _ResSEP += Convert.ToDecimal(drData["RES_IN_SEP"].ToString()); } catch { }
                try { _ResOCT += Convert.ToDecimal(drData["RES_IN_OCT"].ToString()); } catch { }
                try { _ResNOV += Convert.ToDecimal(drData["RES_IN_NOV"].ToString()); } catch { }
                try { _ResDEC += Convert.ToDecimal(drData["RES_IN_DEC"].ToString()); } catch { }
                try { _ResJAN += Convert.ToDecimal(drData["RES_IN_JAN"].ToString()); } catch { }
                try { _ResFEB += Convert.ToDecimal(drData["RES_IN_FEB"].ToString()); } catch { }
                try { _ResMAR += Convert.ToDecimal(drData["RES_IN_MAR"].ToString()); } catch { }

                _AccuResAPR += AccumulateFloatData(drData, "RES_IN", "APR");
                _AccuResMAY += AccumulateFloatData(drData, "RES_IN", "MAY");
                _AccuResJUN += AccumulateFloatData(drData, "RES_IN", "JUN");
                _AccuResJUL += AccumulateFloatData(drData, "RES_IN", "JUL");
                _AccuResAUG += AccumulateFloatData(drData, "RES_IN", "AUG");
                _AccuResSEP += AccumulateFloatData(drData, "RES_IN", "SEP");
                _AccuResOCT += AccumulateFloatData(drData, "RES_IN", "OCT");
                _AccuResNOV += AccumulateFloatData(drData, "RES_IN", "NOV");
                _AccuResDEC += AccumulateFloatData(drData, "RES_IN", "DEC");
                _AccuResJAN += AccumulateFloatData(drData, "RES_IN", "JAN");
                _AccuResFEB += AccumulateFloatData(drData, "RES_IN", "FEB");
                _AccuResMAR += AccumulateFloatData(drData, "RES_IN", "MAR");


                _AccuBudAPR += AccumulateBudgetData(drData, _DataDate, "APR");
                _AccuBudMAY += AccumulateBudgetData(drData, _DataDate, "MAY");
                _AccuBudJUN += AccumulateBudgetData(drData, _DataDate, "JUN");
                _AccuBudJUL += AccumulateBudgetData(drData, _DataDate, "JUL");
                _AccuBudAUG += AccumulateBudgetData(drData, _DataDate, "AUG");
                _AccuBudSEP += AccumulateBudgetData(drData, _DataDate, "SEP");
                _AccuBudOCT += AccumulateBudgetData(drData, _DataDate, "OCT");
                _AccuBudNOV += AccumulateBudgetData(drData, _DataDate, "NOV");
                _AccuBudDEC += AccumulateBudgetData(drData, _DataDate, "DEC");
                _AccuBudJAN += AccumulateBudgetData(drData, _DataDate, "JAN");
                _AccuBudFEB += AccumulateBudgetData(drData, _DataDate, "FEB");
                _AccuBudMAR += AccumulateBudgetData(drData, _DataDate, "MAR");

            }
        }






        //******* add data  ********
        MDCostBudgetInfo.ExpenseChartInfo mLast3Year = new MDCostBudgetInfo.ExpenseChartInfo();
        mLast3Year.dataExpense = _InLast3Year / 12;
        mLast3Year.dataResult = _ResLast3Year / 12;
        mLast3Year.dataPrdActual = _PrdActualLast3Year;
        mLast3Year.dataSaleAmount = _SaleAmountLast3Year;
        try { mLast3Year.dataSaleExpRatio = CeilingData(((_ResLast3Year / _SaleAmountLast3Year) * 100), 2); } catch { mLast3Year.dataSaleExpRatio = 0; }
        try
        {
            mLast3Year.dataPrdPerUnit = CeilingData((_ResLast3Year / _PrdActualLast3Year), 2);
        }
        catch
        {
            mLast3Year.dataPrdPerUnit = 0;
        }
        try
        {
            mLast3Year.dataPrdPerUnitTarget = CeilingData((_PrdTargetLast3Year / 12), 2);
        }
        catch
        {
            mLast3Year.dataPrdPerUnitTarget = 0;
        }
        mLast3Year.dataCostCenter = pLast3Year;
        mLast3Year.dataYearMonth = pLast3Year;
        oAryResult.Add(mLast3Year);



        MDCostBudgetInfo.ExpenseChartInfo mLast2Year = new MDCostBudgetInfo.ExpenseChartInfo();
        mLast2Year.dataExpense = _InLast2Year / 12;
        mLast2Year.dataResult = _ResLast2Year / 12;
        mLast2Year.dataPrdActual = _PrdActualLast2Year;
        mLast2Year.dataSaleAmount = _SaleAmountLast2Year;
        try { mLast2Year.dataSaleExpRatio = CeilingData(((_ResLast2Year / _SaleAmountLast2Year)*100), 2); } catch { mLast2Year.dataSaleExpRatio = 0; }
        try
        {
            mLast2Year.dataPrdPerUnit = CeilingData((_ResLast2Year / _PrdActualLast2Year), 2);
        }
        catch
        {
            mLast2Year.dataPrdPerUnit = 0;
        }
        try
        {
            mLast2Year.dataPrdPerUnitTarget = CeilingData((_PrdTargetLast2Year / 12), 2);
        }
        catch
        {
            mLast2Year.dataPrdPerUnitTarget = 0;
        }
        mLast2Year.dataCostCenter = pLast2Year;
        mLast2Year.dataYearMonth = pLast2Year;
        oAryResult.Add(mLast2Year);



        MDCostBudgetInfo.ExpenseChartInfo mLastYear = new MDCostBudgetInfo.ExpenseChartInfo();
        mLastYear.dataExpense = _InLastYear / 12;
        mLastYear.dataResult = _ResLastYear / 12;
        mLastYear.dataPrdActual = _PrdActualLastYear;
        mLastYear.dataSaleAmount = _SaleAmountLastYear;
        try { mLastYear.dataSaleExpRatio = CeilingData(((_ResLastYear / _SaleAmountLastYear) * 100), 2); } catch { mLastYear.dataSaleExpRatio = 0; }
        try
        {
            mLastYear.dataPrdPerUnit = CeilingData((_ResLastYear / _PrdActualLastYear), 2);
        }
        catch
        {
            mLastYear.dataPrdPerUnit = 0;
        }
        try {
            mLastYear.dataPrdPerUnitTarget = CeilingData((_PrdTargetLastYear / 12), 2);
        } catch {
            mLastYear.dataPrdPerUnitTarget = 0;
        }
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
                mExpense.dataPrdActual = _PrdAPR;
                mExpense.dataPrdPerUnitTarget = _TargetAPR;
                mExpense.dataSaleAmount = _SaleAmtAPR;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResAPR / _SaleAmtAPR)*100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudAPR / _PrdAPR), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "MAY")
            {
                mExpense.dataExpense = _InMAY;
                mExpense.dataResult = _ResMAY;
                mExpense.dataPrdActual = _PrdMAY;
                mExpense.dataPrdPerUnitTarget = _TargetMAY;
                mExpense.dataSaleAmount = _SaleAmtMAY;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResMAY / _SaleAmtMAY) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudMAY / _PrdMAY), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "JUN")
            {
                mExpense.dataExpense = _InJUN;
                mExpense.dataResult = _ResJUN;
                mExpense.dataPrdActual = _PrdJUN;
                mExpense.dataPrdPerUnitTarget = _TargetJUN;
                mExpense.dataSaleAmount = _SaleAmtJUN;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResJUN / _SaleAmtJUN) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudJUN / _PrdJUN), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "JUL")
            {
                mExpense.dataExpense = _InJUL;
                mExpense.dataResult = _ResJUL;
                mExpense.dataPrdActual = _PrdJUL;
                mExpense.dataPrdPerUnitTarget = _TargetJUL;
                mExpense.dataSaleAmount = _SaleAmtJUL;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResJUL / _SaleAmtJUL) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudJUL / _PrdJUL), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "AUG")
            {
                mExpense.dataExpense = _InAUG;
                mExpense.dataResult = _ResAUG;
                mExpense.dataPrdActual = _PrdAUG;
                mExpense.dataPrdPerUnitTarget = _TargetAUG;
                mExpense.dataSaleAmount = _SaleAmtAUG;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResAUG / _SaleAmtAUG) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudAUG / _PrdAUG), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "SEP")
            {
                mExpense.dataExpense = _InSEP;
                mExpense.dataResult = _ResSEP;
                mExpense.dataPrdActual = _PrdSEP;
                mExpense.dataPrdPerUnitTarget = _TargetSEP;
                mExpense.dataSaleAmount = _SaleAmtSEP;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResSEP / _SaleAmtSEP) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudSEP / _PrdSEP), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "OCT")
            {
                mExpense.dataExpense = _InOCT;
                mExpense.dataResult = _ResOCT;
                mExpense.dataPrdActual = _PrdOCT;
                mExpense.dataPrdPerUnitTarget = _TargetOCT;
                mExpense.dataSaleAmount = _SaleAmtOCT;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResOCT / _SaleAmtOCT) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudOCT / _PrdOCT), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "NOV")
            {
                mExpense.dataExpense = _InNOV;
                mExpense.dataResult = _ResNOV;
                mExpense.dataPrdActual = _PrdNOV;
                mExpense.dataPrdPerUnitTarget = _TargetNOV;
                mExpense.dataSaleAmount = _SaleAmtNOV;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResNOV / _SaleAmtNOV) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudNOV / _PrdNOV), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "DEC")
            {
                mExpense.dataExpense = _InDEC;
                mExpense.dataResult = _ResDEC;
                mExpense.dataPrdActual = _PrdDEC;
                mExpense.dataPrdPerUnitTarget = _TargetDEC;
                mExpense.dataSaleAmount = _SaleAmtDEC;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResDEC / _SaleAmtDEC) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudDEC / _PrdDEC), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "JAN")
            {
                mExpense.dataExpense = _InJAN;
                mExpense.dataResult = _ResJAN;
                mExpense.dataPrdActual = _PrdJAN;
                mExpense.dataPrdPerUnitTarget = _TargetJAN;
                mExpense.dataSaleAmount = _SaleAmtJAN;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResJAN / _SaleAmtJAN) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudJAN / _PrdJAN), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "FEB")
            {
                mExpense.dataExpense = _InFEB;
                mExpense.dataResult = _ResFEB;
                mExpense.dataPrdActual = _PrdFEB;
                mExpense.dataPrdPerUnitTarget = _TargetFEB;
                mExpense.dataSaleAmount = _SaleAmtFEB;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResFEB / _SaleAmtFEB) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudFEB / _PrdFEB), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            else if (_Month == "MAR")
            {
                mExpense.dataExpense = _InMAR;
                mExpense.dataResult = _ResMAR;
                mExpense.dataPrdActual = _PrdMAR;
                mExpense.dataPrdPerUnitTarget = _TargetMAR;
                mExpense.dataSaleAmount = _SaleAmtMAR;
                try { mExpense.dataSaleExpRatio = CeilingData(((_AccuResMAR / _SaleAmtMAR) * 100), 2); } catch { mExpense.dataSaleExpRatio = 0; }
                try { mExpense.dataPrdPerUnit = CeilingData((_AccuBudMAR / _PrdMAR), 2); } catch { mExpense.dataPrdPerUnit = 0; }
            }
            mExpense.dataCostCenter = _Month;
            mExpense.dataYearMonth = _Month;
            oAryResult.Add(mExpense);

            ix++;
        } // end foreach


        return oAryResult;
    }

    



    public string[] GetArrayLoopData(string _Type)
    {
        string[] ArryLoop = new string[0];
        if (_Type == "ALL")
        {
            ArryLoop = ArryPrdALL;
        }
        else if (_Type == "Production")
        {
            ArryLoop = ArryPrdProduction;
        }
        else if (_Type == "FAC1")
        {
            ArryLoop = ArryPrdFac1;
        }
        else if (_Type == "FAC2")
        {
            ArryLoop = ArryPrdFac1;
        }
        else if (_Type == "FAC3")
        {
            ArryLoop = ArryPrdFac1;
        }
        else if (_Type == "ODM")
        {
            ArryLoop = ArryPrdFac1;
        }
        else if (_Type == "FAC1M")
        {
            ArryLoop = ArryPrdFac1M;
        }
        else if (_Type == "FAC1A")
        {
            ArryLoop = ArryPrdFac1A;
        }
        else if (_Type == "PDM1YC")
        {
            ArryLoop = ArryPrdFac1M;
        }
        else if (_Type == "PDA1YC")
        {
            ArryLoop = ArryPrdFac1A;
        }
        else if (_Type == "PDM2YC")
        {
            ArryLoop = ArryPrdFac2M;
        }
        else if (_Type == "PDA2YC")
        {
            ArryLoop = ArryPrdFac2A;
        }
        else if (_Type == "PDMSCR")
        {
            ArryLoop = ArryPrdSRCM;
        }
        else if (_Type == "PDASCR")
        {
            ArryLoop = ArryPrdSRCA;
        }
        else if (_Type == "PDMOT")
        {
            ArryLoop = ArryPrdMOT;
        }
        else if (_Type == "PDAL5")
        {
            ArryLoop = ArryPrdAL5;
        }
        else if (_Type == "PDMF3")
        {
            ArryLoop = ArryPrdFac3M;
        }
        else if (_Type == "PDAF3")
        {
            ArryLoop = ArryPrdFac3A;
        }
        else if (_Type == "PDODM")
        {
            ArryLoop = ArryPrdODM;
        }
        else if (_Type == "MTM")
        {
            ArryLoop = ArryPrdMTM;
        }
        else if (_Type == "MTA")
        {
            ArryLoop = ArryPrdMTA;
        }
        else if (_Type == "MTA")
        {
            ArryLoop = ArryPrdMTA;
        }
        else if (_Type == "PDTD")
        {
            ArryLoop = ArryPrdTD;
        }
        else if (_Type == "Procurement")
        {
            ArryLoop = ArryProcurement;
        }
        else if (_Type == "PU")
        {
            ArryLoop = ArryPU;
        }
        else if (_Type == "SPU")
        {
            ArryLoop = ArrySPU;
        }
        else if (_Type == "SP")
        {
            ArryLoop = ArrySP;
        }
        else if (_Type == "PartSupply")
        {
            ArryLoop = ArryPrdControl;
        }
        else if (_Type == "IM")
        {
            ArryLoop = ArryPrdIM;
        }
        else if (_Type == "PS")
        {
            ArryLoop = ArryPrdPS;
        }
        else if (_Type == "DC")
        {
            ArryLoop = ArryPrdDC;
        }
        else if (_Type == "Engineer")
        {
            ArryLoop = ArryEngineer;
        }
        else if (_Type == "ENA")
        {
            ArryLoop = ArryENA;
        }
        else if (_Type == "ENM")
        {
            ArryLoop = ArryENM;
        }
        else if (_Type == "EC") {
            ArryLoop = ArryPrdEC;
        }
        else if (_Type == "UT")
        {
            ArryLoop = ArryPrdUT;
        }
        else if (_Type == "WC")
        {
            ArryLoop = ArryPrdWC;
        }
        else if (_Type == "ENMOT")
        {
            ArryLoop = ArryENMOT;
        }
        else if (_Type == "Quality")
        {
            ArryLoop = ArryPrdQuality;
        }
        else if (_Type == "QA")
        {
            ArryLoop = ArryPrdQA;
        }
        else if (_Type == "QC")
        {
            ArryLoop = ArryPrdQC;
        }
        else if (_Type == "QS")
        {
            ArryLoop = ArryPrdQS;
        }
        else if (_Type == "Design")
        {
            ArryLoop = ArryDesignDevelop;
        }
        else if (_Type == "DD")
        {
            ArryLoop = ArryDD;
        }
        else if (_Type == "CD")
        {
            ArryLoop = ArryCD;
        }
        else if (_Type == "DCICENTER")
        {
            ArryLoop = ArryPrdDCICenter;
        }
        return ArryLoop;
    }

    public string GetProductTypeData(string _Type)
    {
        string ProductType = "";
        if (_Type == "ALL")
        {
            ProductType = "";
        }
        else if (_Type == "Production")
        {
            ProductType = "";
        }
        else if (_Type == "FAC1")
        {
            ProductType = "1YC";
        }
        else if (_Type == "FAC2")
        {
            ProductType = "2YC";
        }
        else if (_Type == "FAC3")
        {
            ProductType = "1YC/3";
        }
        else if (_Type == "ODM")
        {
            ProductType = "ODM";
        }
        else if (_Type == "FAC1M")
        {
            ProductType = "1YC";
        }
        else if (_Type == "FAC1A")
        {
            ProductType = "1YC";
        }
        else if (_Type == "PDM1YC")
        {
            ProductType = "1YC";

        }
        else if (_Type == "PDA1YC")
        {
            ProductType = "1YC";
        }
        else if (_Type == "PDM2YC")
        {
            ProductType = "2YC";
        }
        else if (_Type == "PDA2YC")
        {
            ProductType = "2YC";
        }
        else if (_Type == "PDMSCR")
        {
            ProductType = "SCR";
        }
        else if (_Type == "PDASCR")
        {
            ProductType = "SCR";
        }
        else if (_Type == "PDMOT")
        {
            ProductType = "";
        }
        else if (_Type == "PDAL5")
        {
            ProductType = "";
        }
        else if (_Type == "PDMF3")
        {
            ProductType = "1YC/3";
        }
        else if (_Type == "PDAF3")
        {
            ProductType = "1YC/3";
        }
        else if (_Type == "PDODM")
        {
            ProductType = "ODM";
        }
        else
        {
            ProductType = "";
        }

        return ProductType;
    }

    public string GetTargetTypeData(string _Type)
    {
        string TargetType = "";
        if (_Type == "ALL")
        {
            TargetType = "ALL_EXPENSE";
        }
        else
        {
            TargetType = "";
        }

        return TargetType;
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



    public int AccumulateIntData(DataRow _dataRow, bool isODM, string _PreFix, string _dataMonth) {
        int data = 0;
        switch (_dataMonth) {
            case "APR":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                break;
            case "MAY":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 2) : 0;
                //}
                //else {
                //    data = 0;
                //}
                break;
            case "JUN":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 3) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "JUL":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 4) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "AUG":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 5) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "SEP":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 6) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "OCT":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_OCT"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 7) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "NOV":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_NOV"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 8) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "DEC":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_DEC"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 9) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "JAN":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JAN"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_JAN"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 10) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "FEB":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JAN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_FEB"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_FEB"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 11) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "MAR":
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_JAN"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_FEB"].ToString()); } catch { }
                try { data += Convert.ToInt32(_dataRow[_PreFix + "_MAR"].ToString()); } catch { }
                //if (Convert.ToInt32(_dataRow[_PreFix + "_MAR"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 12) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
        }
        
        if (isODM) {
            data = (data > 0) ? (data / 20) : 0;
        }
        return data;
    }



    public decimal AccumulateFloatData(DataRow _dataRow, string _PreFix, string _dataMonth)
    {
        decimal data = 0;
        switch (_dataMonth)
        {
            case "APR":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                break;
            case "MAY":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 2) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "JUN":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 3) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "JUL":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 4) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "AUG":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 5) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "SEP":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 6) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "OCT":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_OCT"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 7) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "NOV":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_NOV"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 8) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "DEC":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_DEC"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 9) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "JAN":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JAN"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_JAN"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 10) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "FEB":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JAN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_FEB"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_FEB"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 11) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
            case "MAR":
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_APR"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAY"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JUL"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_AUG"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_SEP"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_OCT"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_NOV"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_DEC"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_JAN"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_FEB"].ToString()); } catch { }
                try { data += Convert.ToDecimal(_dataRow[_PreFix + "_MAR"].ToString()); } catch { }
                //if (Convert.ToDecimal(_dataRow[_PreFix + "_MAR"].ToString()) > 0)
                //{
                //    data = (data > 0) ? (data / 12) : 0;
                //}
                //else
                //{
                //    data = 0;
                //}
                break;
        }
        
        return data;
    }



    public decimal AccumulateBudgetData(DataRow _dataRow, DateTime _DataDate, string _dataMonth)
    {
        List<string> oAryMonthPassive = new List<string>();

        // in fiscal year
        if (_DataDate.Month >= 4)
        {
            for (int m = 4; m <= _DataDate.Month; m++) {
                oAryMonthPassive.Add(ArryPhysicalPeriod[m - 1]);
            }
        }
        // fiscal year -1
        else if(_DataDate.Month <= 3)
        {
            for (int m = 4; m <= 12; m++)
            {
                oAryMonthPassive.Add(ArryPhysicalPeriod[m-1]);
            }

            for (int m = 1; m <= _DataDate.Month; m++)
            {
                oAryMonthPassive.Add(ArryPhysicalPeriod[m-1]);
            }
        }
        
        decimal data = 0;
        switch (_dataMonth)
        {
            case "APR":
                if (oAryMonthPassive.Any("APR".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }else {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }
                break;
            case "MAY":
                if (oAryMonthPassive.Any("APR".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }
                
                break;
            case "JUN":
                if (oAryMonthPassive.Any("APR".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                break;
            case "JUL":
                if (oAryMonthPassive.Any("APR".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains)){
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }else{
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                break;
            case "AUG":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                
                break;
            case "SEP":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("SEP".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_SEP"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_SEP"].ToString()); } catch { }
                }
                
                break;
            case "OCT":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("SEP".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_SEP"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_SEP"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("OCT".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_OCT"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_OCT"].ToString()); } catch { }
                }
                
                break;
            case "NOV":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("SEP".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_SEP"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_SEP"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("OCT".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_OCT"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_OCT"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("NOV".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_NOV"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_NOV"].ToString()); } catch { }
                }
                break;
            case "DEC":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("SEP".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_SEP"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_SEP"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("OCT".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_OCT"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_OCT"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("NOV".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_NOV"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_NOV"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("DEC".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_DEC"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_DEC"].ToString()); } catch { }
                }
                
                break;
            case "JAN":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("SEP".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_SEP"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_SEP"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("OCT".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_OCT"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_OCT"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("NOV".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_NOV"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_NOV"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("DEC".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_DEC"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_DEC"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JAN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JAN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JAN"].ToString()); } catch { }
                }
                
                break;
            case "FEB":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("SEP".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_SEP"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_SEP"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("OCT".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_OCT"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_OCT"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("NOV".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_NOV"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_NOV"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("DEC".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_DEC"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_DEC"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JAN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JAN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JAN"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("FEB".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_FEB"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_FEB"].ToString()); } catch { }
                }
                
                break;
            case "MAR":
                if (oAryMonthPassive.Any("APR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_APR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_APR"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("MAY".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAY"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAY"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUN"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JUL".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JUL"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JUL"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("AUG".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_AUG"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_AUG"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("SEP".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_SEP"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_SEP"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("OCT".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_OCT"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_OCT"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("NOV".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_NOV"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_NOV"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("DEC".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_DEC"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_DEC"].ToString()); } catch { }
                }

                if (oAryMonthPassive.Any("JAN".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_JAN"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_JAN"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("FEB".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_FEB"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_FEB"].ToString()); } catch { }
                }
                if (oAryMonthPassive.Any("MAR".Contains))
                {
                    try { data += Convert.ToDecimal(_dataRow["RES_IN" + "_MAR"].ToString()); } catch { }
                }
                else
                {
                    try { data += Convert.ToDecimal(_dataRow["IN" + "_MAR"].ToString()); } catch { }
                }
                break;
        }

        return data;
    }




}