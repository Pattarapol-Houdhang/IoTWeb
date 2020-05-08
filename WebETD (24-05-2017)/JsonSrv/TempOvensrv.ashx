<%@ WebHandler Language="C#" Class="TempOvenSrv" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class TempOvenSrv : IHttpHandler {

    CTempOvenInfo oTempOven = new CTempOvenInfo();

    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string Month = context.Request.QueryString["month"] != null ? context.Request.QueryString["month"].ToString() : DateTime.Now.Month.ToString();
        string Board = context.Request.QueryString["board"] != null ? context.Request.QueryString["board"].ToString() : "301";
        string getYear = context.Request.QueryString["getYear"] != null ? context.Request.QueryString["getYear"].ToString() : "NO";


        if (getYear == "NO")
        {
            List<MTempOvenInfo> oList = new List<MTempOvenInfo>();
            oList = oTempOven.GetChartTempOven(Convert.ToInt32(Month), Board);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(oList);
            context.Response.Write(json);
        }
        else
        {
            if (getYear == "")
            {
                getYear = DateTime.Now.Year.ToString();
            }
            List<MTempOvenMonth> olist = new List<MTempOvenMonth>();
            olist = oTempOven.GetChartTempOvenMonth(Convert.ToInt32(Month), Convert.ToInt32(getYear), Board);
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(olist);
            context.Response.Write(json);
        }




    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}