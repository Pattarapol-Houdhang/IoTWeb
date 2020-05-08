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
       // int i = 0;
        try
        {
            dataDate = Convert.ToDateTime(pDate);
        }
        catch { }        string getYear = context.Request.QueryString["getYear"] != null ? context.Request.QueryString["getYear"].ToString() : "NO";

        List<MMPInfo.MPAllChartInfo> oListMP = new List<MMPInfo.MPAllChartInfo>();
        List<MMPInfo.MPAllChartInfo> oListMP1 = new List<MMPInfo.MPAllChartInfo>();
        List<MMPInfo.MPAllChartInfo> oListMP2 = new List<MMPInfo.MPAllChartInfo>();

        if (pCostCenter == "MPMTALL" || pCostCenter == "MPFAC1" || pCostCenter == "MPFAC1M" || pCostCenter == "MPFAC1A" ||
             pCostCenter == "MPFAC2" || pCostCenter == "MPFAC3" || pCostCenter == "MPODM" || pCostCenter == "MPFAC2M" || pCostCenter == "MPFAC2A" ||
                  pCostCenter == "MPFAC2MOM" || pCostCenter == "MPFAC2MOA" ||
                  pCostCenter == "MPSCRM" || pCostCenter == "MPSCRA" || pCostCenter == "MPFAC3M" || pCostCenter == "MPFAC3A")
        {
            oListMP = oMP.GetChartMANPOWERDayNight(Month, dataDate, pCostCenter);

        }
     if (pCostCenter == "FAC1" || pCostCenter == "FAC1M" || pCostCenter == "FAC1A" ||
            pCostCenter == "FAC2" || pCostCenter == "FAC3" || pCostCenter == "ODM" || pCostCenter == "FAC2M" || pCostCenter == "FAC2A" ||
                 pCostCenter == "FAC2MOM" || pCostCenter == "FAC2MOA" ||
                 pCostCenter == "SCRM" || pCostCenter == "SCRA" || pCostCenter == "FAC3M" || pCostCenter == "FAC3A")
        {
            oListMP = oMP.GetChartMP(Month,dataDate, pCostCenter);
             
     }
     else if (pCostCenter == "MTALL" || pCostCenter == "MTM" || pCostCenter == "MTA" || pCostCenter == "PU" || pCostCenter == "SPU"
         || pCostCenter == "SP"
            || pCostCenter == "IM" || pCostCenter == "PS" || pCostCenter == "DC" || pCostCenter == "PN" || pCostCenter == "DC"
            || pCostCenter == "WH"
            || pCostCenter == "ENA" || pCostCenter == "ENM" || pCostCenter == "ENMOT"
            || pCostCenter == "IT" || pCostCenter == "UT" || pCostCenter == "WC"
            || pCostCenter == "QC" || pCostCenter == "QA" || pCostCenter == "QS"
            || pCostCenter == "DD" || pCostCenter == "CD" )
           
     {
         oListMP = oMP.GetChartMPMAandSupport(Month, dataDate, pCostCenter);
     }
     else if (pCostCenter == "ALL")
     {
         oListMP = oMP.GetChartMPALL(Month, dataDate, pCostCenter);
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









