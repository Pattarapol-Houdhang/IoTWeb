<%@ WebHandler Language="C#" Class="AllHoldChart" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class AllHoldChart : IHttpHandler {
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    CAllHold oHold = new CAllHold();

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


        List<MDHoldAllInfo.HoldAllChartInfo> oAryResult = new List<MDHoldAllInfo.HoldAllChartInfo>();
        if (pCostCenter == "ALL" || pCostCenter == "FAC1" || 
            pCostCenter == "FAC2" || pCostCenter == "FAC3" || pCostCenter == "ODM")
        {
            oAryResult = oHold.GetChartExpenseReport(dataDate, pCostCenter);
        }
        else if (pCostCenter == "FAC1M" || pCostCenter == "FAC1A" || pCostCenter == "FAC2M" || pCostCenter == "FAC2A" ||
                 pCostCenter == "SRCM" || pCostCenter == "SRCA" || pCostCenter == "FAC3M" || pCostCenter == "FAC3A")
        {
            oAryResult = oHold.GetChartExpenseCostCenterReport(dataDate, pCostCenter);
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






