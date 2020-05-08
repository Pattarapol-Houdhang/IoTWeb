<%@ WebHandler Language="C#" Class="JsonMachaActual" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class JsonMachaActual : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "text/plain";
        string modelcode = context.Request.QueryString["ModelCode"] != null ? context.Request.QueryString["ModelCode"].ToString() : "";

        //CGetDataGraph oTarget = new CGetDataGraph();
        //List<MDataGraph> oList = new List<MDataGraph>();
        //oList = oTarget.GetPlan(ct, fac, line, mc, modelcode, strDate, endDate);
        //var jsonSerialiser = new JavaScriptSerializer();
        //var json = jsonSerialiser.Serialize(oList);
        //context.Response.Write(json);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}