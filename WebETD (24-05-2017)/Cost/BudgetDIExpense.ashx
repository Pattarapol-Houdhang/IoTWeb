<%@ WebHandler Language="C#" Class="BudgetDIExpense" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class BudgetDIExpense : IHttpHandler {
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    CBudgetDIExpense oCost = new CBudgetDIExpense();

    public void ProcessRequest(HttpContext context) {
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
        if (pCostCenter == "ALL" || pCostCenter == "FAC1" ||
            pCostCenter == "FAC2" || pCostCenter == "FAC3" ||
            pCostCenter == "ODM"
            )
        {
            oAryResult = oCost.GetChartExpenseReport(dataDate, pCostCenter);

        }
        else if (pCostCenter == "PDM1YC" || pCostCenter == "PDA1YC" || pCostCenter == "PDM2YC" 
                || pCostCenter == "PDA2YC" || pCostCenter == "PDMSCR" || pCostCenter == "PDASCR" 
                || pCostCenter == "PDODM" || pCostCenter == "PDMF3" || pCostCenter == "PDAF3" )
        {
            oAryResult = oCost.GetChartExpenseCostCenterReport(dataDate, pCostCenter);

        } else if (pCostCenter == "Production" || pCostCenter == "UT" || pCostCenter == "WC" 
                || pCostCenter == "EC" || pCostCenter == "QC" || pCostCenter == "DCICENTER" 
                || pCostCenter == "PDMOT" || pCostCenter == "PDAL5" || pCostCenter == "MTM" 
                || pCostCenter == "MTA")
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






