<%@ WebHandler Language="C#" Class="LineOutChart" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class LineOutChart : IHttpHandler {
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    CLineOut oLine = new CLineOut();
    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "text/plain";

        string pModel = context.Request.QueryString["pModel"] != null ? context.Request.QueryString["pModel"].ToString() : "";
        string pDate = context.Request.QueryString["pDate"] != null ? context.Request.QueryString["pDate"].ToString() : "";
        string pMode = context.Request.QueryString["pMode"] != null ? context.Request.QueryString["pMode"].ToString() : "";
        DateTime dataDate = DateTime.Now;

        var jsonSerialiser = new JavaScriptSerializer();
        var json = "";

        if (pMode == "model") {
            List<CLineOut.LineOutChartInfo> oAryResult = new List<CLineOut.LineOutChartInfo>();
            oAryResult = oLine.GetModelHoldLineOutMonthReport(pModel, pDate);
            json = jsonSerialiser.Serialize(oAryResult);

        } else if (pMode == "process") {
            List<CLineOut.ProcessHoldLineOutInfo> oAryResult = new List<CLineOut.ProcessHoldLineOutInfo>();
            oAryResult = oLine.GetProcessHoldLineOutMonthReport(pModel, pDate);
            json = jsonSerialiser.Serialize(oAryResult);

        } else if (pMode == "year") {
            List<CLineOut.HoldLineOutInfo> oAryResult = new List<CLineOut.HoldLineOutInfo>();
            oAryResult = oLine.GetLineOutData(pModel, pDate);
            json = jsonSerialiser.Serialize(oAryResult);

        } else if (pMode == "overall") {
            List<CLineOut.HoldLineOutAllInfo> oAryResult = new List<CLineOut.HoldLineOutAllInfo>();
            oAryResult = oLine.GetHoldLineOutAll(pDate);
            json = jsonSerialiser.Serialize(oAryResult);
                
        }

        // ---- Return ----
        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}