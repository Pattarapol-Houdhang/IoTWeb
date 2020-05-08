<%@ WebHandler Language="C#" Class="BudgetSGAExpense" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class BudgetSGAExpense : IHttpHandler {
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    CBudgetSGAExpense oCost = new CBudgetSGAExpense();


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
            pCostCenter == "ODM" || pCostCenter == "Production"
            )
        {
            oAryResult = oCost.GetChartExpenseReport(dataDate, pCostCenter);

        }
        // Other Support line 
        else if (pCostCenter == "ITEC" || pCostCenter == "IT" || pCostCenter == "UT" ||
        pCostCenter == "PN" || pCostCenter == "DCICENTER" || pCostCenter == "DL" ||
        pCostCenter == "WH" || pCostCenter == "HR" || pCostCenter == "GA" ||
        pCostCenter == "PartSupply" || pCostCenter == "AC" || pCostCenter == "CB" ||
        pCostCenter == "TS" || pCostCenter == "HRD" || pCostCenter == "CSR" ||
        pCostCenter == "TD" || pCostCenter == "SA" || pCostCenter == "SGA" || pCostCenter == "Administration"
        )
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