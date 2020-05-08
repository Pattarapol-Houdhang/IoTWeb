<%@ WebHandler Language="C#" Class="AllManPower" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class AllManPower : IHttpHandler
{
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
     CMPInfo oMP = new CMPInfo();

    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/plain";
       // string Month = context.Request.QueryString["month"] != null ? context.Request.QueryString["month"].ToString() : DateTime.Now.Month.ToString();
        string pCostCenter = context.Request.QueryString["cc"] != null ? context.Request.QueryString["cc"].ToString() : "";
        string pDate = context.Request.QueryString["Date"] != null ? context.Request.QueryString["Date"].ToString() : "";
        DateTime dataDate = DateTime.Now;
        int Month = dataDate.Month;
         
        try
        {
            dataDate = Convert.ToDateTime(pDate);
        }
        catch { }        string getYear = context.Request.QueryString["getYear"] != null ? context.Request.QueryString["getYear"].ToString() : "NO";

        List<MMPInfo.MPAllChartInfo> oListMP = new List<MMPInfo.MPAllChartInfo>();
        
      
     if (pCostCenter == "ALL" || pCostCenter == "FAC1" || 
            pCostCenter == "FAC2" || pCostCenter == "FAC3" || pCostCenter == "ODM")
        {
            oListMP = oMP.GetChartMP(Month,dataDate, pCostCenter);
        }
        else if (pCostCenter == "FAC1M" || pCostCenter == "FAC1A" || pCostCenter == "FAC2M" || pCostCenter == "FAC2A" ||
                   pCostCenter == "FAC2MOM" || pCostCenter == "FAC2MOA" ||
                 pCostCenter == "SCRM" || pCostCenter == "SCRA" || pCostCenter == "FAC3M" || pCostCenter == "FAC3A")
        {
            oListMP = oMP.GetChartMP(Month,dataDate, pCostCenter);
        }
        else {
            //oAryResult = oCost.GetChartExpenseMonth(pCostCenter, dataDate);
        }

        if (oListMP.Count > 0)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(oListMP);
            // ---- Return ----
            context.Response.Write(json);
        }
        else {
            context.Response.Write("");
        }
    }        
       
        
        //if (getYear == "NO")
        //{
        //    string txtCC = CostCenter.Substring(0, 4);
        //    List<MMPInfo> oList = new List<MMPInfo>();
        //    oList = oMP.GetChartMP(Convert.ToInt32(Month), txtCC);
        //    var jsonSerialiser = new JavaScriptSerializer();
        //    var json = jsonSerialiser.Serialize(oList);
        //    context.Response.Write(json);
        //}
        //else
        //{
            //if (getYear == "")
            //{
            //    getYear = DateTime.Now.Year.ToString();
            //}
            //List<MMPMonth> olist = new List<MMPMonth>();
            //olist = oMP.GetChartMPMonth(Convert.ToInt32(Month), Convert.ToInt32(getYear), CostCenter);
            //var jsonSerialiser = new JavaScriptSerializer();
            //var json = jsonSerialiser.Serialize(olist);
            //context.Response.Write(json);
        //}




        //List<MDHoldAllInfo.HoldAllChartInfo> oAryResult = new List<MDHoldAllInfo.HoldAllChartInfo>();
   

    public bool IsReusable {
        get {
            return false;
        }
    }

}









