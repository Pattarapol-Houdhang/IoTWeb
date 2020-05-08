<%@ WebHandler Language="C#" Class="SourcJson" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;

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
        string target = context.Request.QueryString["target"] != null ? context.Request.QueryString["target"].ToString() : "0";
        string create = context.Request.QueryString["create"] != null ? context.Request.QueryString["create"].ToString() : "";

        CGetDataGraph oTarget = new CGetDataGraph();
        CGetDataGraphLastDay oTargetLast = new CGetDataGraphLastDay();
        List<MDataGraph> oList = new List<MDataGraph>();

        if (create == "YES")
        {
            if (target == "last")
            {
                oList = oTargetLast.GetPlan(ct, fac, line, target, modelcode, strDate, endDate);
            }
            else
            {
                oList = oTarget.GetPlan(ct, fac, line, mc, modelcode, strDate, endDate);
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(oList);
                if (line == "")
                {
                    line = "main";
                }
                //----------- Create File Source Json --------------
                File.WriteAllText(HttpContext.Current.Server.MapPath("~/Production/EffSource/" + line + ".json"), json);

                context.Response.Write(json);
            }
        }
        else
        {
            if (line == "")
            {
                line = "main";
            }
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(oList);
                
            try
            {
                //----------- Read File Source Json --------------
                json = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Production/EffSource/"+ line + ".json"));
            }
            catch
            {
                //----------- Create File Source Json --------------
                oList = oTarget.GetPlan(ct, fac, line, mc, modelcode, strDate, endDate);
                json = jsonSerialiser.Serialize(oList);
                File.WriteAllText(HttpContext.Current.Server.MapPath("~/Production/EffSource/" + line + ".json"), json);
            }

            context.Response.Write(json);
        }

        //oList = oTarget.GetPlan(ct, fac, line, target, modelcode, strDate, endDate);        
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}