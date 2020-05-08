<%@ WebHandler Language="C#" Class="BudgetIndirectCost" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class BudgetIndirectCost : IHttpHandler {
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    CBudgetINExpense oCost = new CBudgetINExpense();


    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string pCostCenter = context.Request.QueryString["cc"] != null ? context.Request.QueryString["cc"].ToString() : "";
        string pDate = context.Request.QueryString["Date"] != null ? context.Request.QueryString["Date"].ToString() : "";
        DateTime dataDate = DateTime.Now;
        try
        {
            dataDate = Convert.ToDateTime(pDate);
        }
        catch { }


        List<MDCostBudgetInfo.ExpenseChartInfo> oAryResult = new List<MDCostBudgetInfo.ExpenseChartInfo>();
        // Production Factory 
        if (pCostCenter == "ALL" || pCostCenter == "FAC1" ||
            pCostCenter == "FAC2" || pCostCenter == "FAC3" ||
            pCostCenter == "ODM" 
            )
        {
            oAryResult = oCost.GetChartExpenseReport(dataDate, pCostCenter);

        }
        // Production line 
        else if (pCostCenter == "PDM1YC" || pCostCenter == "PDA1YC" || pCostCenter == "PDM2YC" || pCostCenter == "PDA2YC" ||
            pCostCenter == "PDMSCR" || pCostCenter == "PDASCR" || 
            pCostCenter == "PDODM" || pCostCenter == "PDMF3" || pCostCenter == "PDAF3"  )
        {
            oAryResult = oCost.GetChartExpenseCostCenterReport(dataDate, pCostCenter);

        }
        // Other Support line 
        else if (pCostCenter == "Production" || pCostCenter == "UT" || pCostCenter == "WC" || 
        pCostCenter == "EC" || pCostCenter == "Quality" || pCostCenter == "DCICENTER" || 
        pCostCenter == "Procurement" || pCostCenter == "PU" || pCostCenter == "SPU" || 
        pCostCenter == "SP" || pCostCenter == "PartSupply" || pCostCenter == "IM" || 
        pCostCenter == "PS" || pCostCenter == "DC" || pCostCenter == "Engineer" || 
        pCostCenter == "ENA" || pCostCenter == "ENM" || pCostCenter == "ENMOT" || pCostCenter == "QA" ||
        pCostCenter == "QC" || pCostCenter == "QS" || pCostCenter == "Design" || pCostCenter == "DD" || 
        pCostCenter == "CD" || pCostCenter == "GA" || pCostCenter == "MTM" || pCostCenter == "MTA" || 
        pCostCenter == "PDTD" || pCostCenter == "PDMOT" || pCostCenter == "PDAL5" )
        {
            oAryResult = oCost.GetChartOtherCostCenterReport(dataDate, pCostCenter);
        }
        else {
            //oAryResult = oCost.GetChartExpenseMonth(pCostCenter, dataDate);
        }

        if (oAryResult.Count > 0)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(oAryResult);
            // ---- Return ----
            context.Response.Write(json);
        }
        else {
            context.Response.Write("");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}