<%@ WebHandler Language="C#" Class="SourcJson" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class SourcJson : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "text/plain";
        decimal ct = Convert.ToDecimal(context.Request.QueryString["CycleTime"] != null ? context.Request.QueryString["CycleTime"].ToString() : "0");
        string fac = context.Request.QueryString["Fac"] != null ? context.Request.QueryString["Fac"].ToString() : "";
        string line = context.Request.QueryString["Line"] != null ? context.Request.QueryString["Line"].ToString() : "";
        string mc = context.Request.QueryString["Mac"] != null ? context.Request.QueryString["Mac"].ToString() : "";
        string modelcode = context.Request.QueryString["ModelCode"] != null ? context.Request.QueryString["ModelCode"].ToString() : "";
        string strDate = context.Request.QueryString["strDate"] != null ? context.Request.QueryString["strDate"].ToString() : "";
        string endDate = context.Request.QueryString["endDate"] != null ? context.Request.QueryString["endDate"].ToString() : "";
        string TypeData = context.Request.QueryString["Type"] != null ? context.Request.QueryString["Type"].ToString() : "";
        int month = context.Request.QueryString["month"] != null ? Convert.ToInt16(context.Request.QueryString["month"]) : 0;
        int year = context.Request.QueryString["year"] != null ? Convert.ToInt16(context.Request.QueryString["year"]) : 0;
        
        CGetDataGraph oGraph = new CGetDataGraph();
        

        if (TypeData == "allline")
        {
            List<MDataGrapPDMeeting> oList = new List<MDataGrapPDMeeting>();
            oList = oGraph.GetDataPDMeeting(line,DateTime.Now.Month,DateTime.Now.Year);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(oList);

            context.Response.Write(json);
        }
        else
        {
            List<MDataGrapPDMeeting> oList = new List<MDataGrapPDMeeting>();
            oList = oGraph.GetDataPDMeeting(line,month,year);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(oList);

            context.Response.Write(json);
        }                                
    }
         
    public bool IsReusable {
        get {
            return false;
        }
    }

}