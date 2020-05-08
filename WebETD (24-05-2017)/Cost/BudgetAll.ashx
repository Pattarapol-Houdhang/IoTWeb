<%@ WebHandler Language="C#" Class="BudgetAll" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class BudgetAll : IHttpHandler {
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    CBudgetAll oCost = new CBudgetAll();

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
        if (pCostCenter == "ALL")
        {
            oAryResult = oCost.GetChartExpenseReport(dataDate, pCostCenter);

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






