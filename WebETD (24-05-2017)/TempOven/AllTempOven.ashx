<%@ WebHandler Language="C#" Class="AllTempOven" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class AllTempOven : IHttpHandler
{
   // ConnectDBBCS oConnBCS = new ConnectDBBCS();
   //ConnectDBDCI oConDCI = new ConnectDBDCI();
    CTmpOvenInfo oMP = new CTmpOvenInfo();

    public void ProcessRequest (HttpContext context)
    {
        context.Response.ContentType = "text/plain";
       // string Month = context.Request.QueryString["month"] != null ? context.Request.QueryString["month"].ToString() : DateTime.Now.Month.ToString();
        string pCostCenter = context.Request.QueryString["cc"] != null ? context.Request.QueryString["cc"].ToString() : "";
        string pDate = context.Request.QueryString["SDate"] != null ? context.Request.QueryString["SDate"].ToString() : "";
        string EnDate = context.Request.QueryString["EDate"] != null ? context.Request.QueryString["EDate"].ToString() : "";
        DateTime SDate = DateTime.Now;
        DateTime EndDate = DateTime.Now;
        int Month = SDate.Month;
     //   int i = 0;
        try
        {
            SDate = Convert.ToDateTime(pDate);
            EndDate = Convert.ToDateTime(EnDate);
        }
        catch { }        string getYear = context.Request.QueryString["getYear"] != null ? context.Request.QueryString["getYear"].ToString() : "NO";

        List<MTmpOvenInfo.MTmpAllChartInfo> oListMP = new List<MTmpOvenInfo.MTmpAllChartInfo>();
       
      
     if (pCostCenter == "ALL" || pCostCenter == "CH1" || pCostCenter == "CH2" || pCostCenter == "CH3" ||
            pCostCenter == "CH4" || pCostCenter == "CH5" || pCostCenter == "CH6" || pCostCenter == "CH7" || pCostCenter == "CH8" ||
                 pCostCenter == "CH9" || pCostCenter == "CH10" ||
                 pCostCenter == "CH11" || pCostCenter == "CH12")
        {
            oListMP = oMP.GetChartTempOven(Month, SDate, EndDate,pCostCenter);
   
     }
     else if (pCostCenter == "CH12")
           
         
     {
         oListMP = oMP.GetChartTempOven(Month, SDate, EndDate, pCostCenter);
     }
     else
     {
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
       
   
   

    public bool IsReusable {
        get {
            return false;
        }
    }

}









