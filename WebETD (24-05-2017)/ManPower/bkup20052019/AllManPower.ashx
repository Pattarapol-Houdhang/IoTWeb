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

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        // string Month = context.Request.QueryString["month"] != null ? context.Request.QueryString["month"].ToString() : DateTime.Now.Month.ToString();
        string pCostCenter = context.Request.QueryString["cc"] != null ? context.Request.QueryString["cc"].ToString() : "";
        string pDate = context.Request.QueryString["Date"] != null ? context.Request.QueryString["Date"].ToString() : "";
        DateTime dataDate = DateTime.Now;
        int Month = DateTime.Now.Month;
        int Year = DateTime.Now.Year;
      //  int Prev = 0, Prev2 = 0, Prev3 = 0;


        DateTime lPrev =DateTime.Now.AddMonths(-1);
        DateTime lPrev2 = DateTime.Now.AddMonths(-2);
        DateTime lPrev3 = DateTime.Now.AddMonths(-3);

        int Prev = Convert.ToInt16(lPrev.Month);
        int Prev2 = Convert.ToInt16(lPrev2.Month);
        int Prev3 = Convert.ToInt16(lPrev3.Month);

        int _LastYearPrev = Convert.ToInt16(lPrev.Year);
        int _LastYearPrev2 = Convert.ToInt16(lPrev2.Year);
        int _LastYearPrev3 = Convert.ToInt16(lPrev3.Year);
        
        // int i = 0;
        try
        {
            dataDate = Convert.ToDateTime(pDate);
        }
        catch { } string getYear = context.Request.QueryString["getYear"] != null ? context.Request.QueryString["getYear"].ToString() : "NO";

        List<MMPInfo.MPAllChartInfo> oListMP = new List<MMPInfo.MPAllChartInfo>();
        List<MMPInfo.MPAllChartInfo> oListMP1 = new List<MMPInfo.MPAllChartInfo>();
        List<MMPInfo.MPAllChartInfo> oListMP2 = new List<MMPInfo.MPAllChartInfo>();


        //----------------------------InDirect ------------------
        //------------------ Production & Maintenance ------------------
        if (pCostCenter == "INFAC1" || pCostCenter == "OTINFAC1" ||
            pCostCenter == "INFAC2" || pCostCenter == "OTINFAC2" ||
            pCostCenter == "INFAC3" || pCostCenter == "OTINFAC3" ||
            pCostCenter == "INODM" || pCostCenter == "OTINODM"   ||
            pCostCenter == "INQA" || pCostCenter == "OTINQA" ||
            pCostCenter == "INIE" || pCostCenter == "OTINIE" ||
            pCostCenter == "INPS" || pCostCenter == "OTINPS" ||
            pCostCenter == "INMAN" || pCostCenter == "OTINMAN" ||
             pCostCenter == "INIE" || pCostCenter == "OTINIE" 
            
          )
        {
            oListMP = oMP.GetChartMPDailybyInDirect(Year,Month, dataDate, pCostCenter);

        }

        if
            //-----------------Procurement PU SPU PC ----------------
          (pCostCenter == "INPU" || pCostCenter == "OTINPU" ||
           pCostCenter == "INSPU" || pCostCenter == "OTINSPU" ||
           pCostCenter == "INPC" || pCostCenter == "OTINPC" ||
              pCostCenter == "INSP" || pCostCenter == "OTINSP" ||
              
                 //----------------------QCQAQS -- ----------------
           pCostCenter == "INQC" || pCostCenter == "OTINQC" ||
           pCostCenter == "INQS" || pCostCenter == "OTINQS" ||
            
            
           //------------Production Control and SCM IM PN PS DS SP
           pCostCenter == "INIM" || pCostCenter == "OTINIM" ||
         
           pCostCenter == "INDC" || pCostCenter == "OTINDC" ||
           pCostCenter == "INPN" || pCostCenter == "OTINPN" ||
            pCostCenter == "INWH" || pCostCenter == "OTINWH" ||

             //------------------ ENGINEER-------------
           pCostCenter == "INENA" || pCostCenter == "OTINENA" ||
           pCostCenter == "INENM" || pCostCenter == "OTINENM" ||
           pCostCenter == "INENMOT" || pCostCenter == "OTINENMOT" ||

              //--------------- Design and Development-----------------
           pCostCenter == "INDD" || pCostCenter == "OTINDD" ||
           pCostCenter == "INCD" || pCostCenter == "OTINCD" ||

            //----------------------------------------------------//
            //                     S.G.A GROUP                    //
            //---------------------------------------------------//
            //----------------------- IT-----------------
           pCostCenter == "INIT" || pCostCenter == "OTINIT" ||
            //--------------------- IT&EC-----------------
           pCostCenter == "INUT" || pCostCenter == "OTINUT" ||
            pCostCenter == "INEC" || pCostCenter == "OTINEC" ||


             //-------------------ADMINISTRATION---------------

           pCostCenter == "INSGA" || pCostCenter == "OTINSGA" ||
           pCostCenter == "INHR" || pCostCenter == "OTINHR" ||
           pCostCenter == "INAC" || pCostCenter == "OTINAC" ||
           pCostCenter == "INCC" || pCostCenter == "OTINCC" ||
           pCostCenter == "INCB" || pCostCenter == "OTINCB" ||
           pCostCenter == "INGA" || pCostCenter == "OTINGA" ||
           pCostCenter == "INTS" || pCostCenter == "OTINTS" ||
           pCostCenter == "INAUDIT" || pCostCenter == "OTINAUDIT" ||
           pCostCenter == "INHRD" || pCostCenter == "OTINHRD" ||
           pCostCenter == "INSF" || pCostCenter == "OTINSF" ||
           pCostCenter == "INLG" || pCostCenter == "OTINLG" ||
           pCostCenter == "INDCC" || pCostCenter == "OTINDCC" ||
           pCostCenter == "INTD" || pCostCenter == "OTINTD" ||
    

           pCostCenter == "INMTALL" || pCostCenter == "OTMTALL" ||
            pCostCenter == "INMTM" || pCostCenter == "OTINMTM" ||
            pCostCenter == "INMTA" || pCostCenter == "OTINMTA" ||
            pCostCenter == "INMTPM" || pCostCenter == "OTINMTPM" ||
            pCostCenter == "INMTTPM" || pCostCenter == "OTINMTTPM"

            )
        {
            oListMP = oMP.GetChartMPDailybyInDirectSupport(Year,Month, dataDate, pCostCenter);

        }

        //------------ DIRECT FACTORY1,2,3 MAINTENANCE,QCQAQS
        //----- Attandace Man Power by MA and Support Present Month   ------
        if (pCostCenter == "MPPS" || pCostCenter == "OTMPPS" ||
            pCostCenter == "MPQA" || pCostCenter == "OTMPQA")
        {

            oListMP = oMP.GetChartMPDailybyDirect(Year,Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "MPPSPrev" || pCostCenter == "OTMPPSPrev" ||
            pCostCenter == "MPQAPrev" || pCostCenter == "OTMPQAPrev")
        {
            oListMP = oMP.GetChartMPDailybyDirect(_LastYearPrev, Prev, dataDate, pCostCenter);

        }
        else if (pCostCenter == "MPPSPrev2" || pCostCenter == "OTMPPSPrev2" ||
             pCostCenter == "MPQAPrev2" || pCostCenter == "OTMPQAPrev2")
        {
            oListMP = oMP.GetChartMPDailybyDirect(_LastYearPrev2, Prev2, dataDate, pCostCenter);

        }
        else if (pCostCenter == "MPPSPrev3" || pCostCenter == "OTMPPSPrev3" ||
             pCostCenter == "MPQAPrev3" || pCostCenter == "OTMPQAPrev3")
        {
            oListMP = oMP.GetChartMPDailybyDirect(_LastYearPrev3, Prev3, dataDate, pCostCenter);

        }

            //------------ DIRECT FACTORY1,2,3 MAINTENANCE,QCQAQS
        //----- Attandace Man Power by Factory  Present Month   ------

        else if (pCostCenter == "MPFAC1" || pCostCenter == "MPMTALL" || pCostCenter == "MPFAC1M" || pCostCenter == "MPFAC1A" ||
             pCostCenter == "MPFAC2" || pCostCenter == "MPFAC3" || pCostCenter == "MPODM" || pCostCenter == "MPFAC2M" || pCostCenter == "MPFAC2A" ||
                  pCostCenter == "MPFAC2MOM" || pCostCenter == "MPFAC2MOA" ||
                  pCostCenter == "MPSCRM" || pCostCenter == "MPSCRA" || pCostCenter == "MPFAC3M" || pCostCenter == "MPFAC3A")
        {
            oListMP = oMP.GetChartMPDaily(Year,Month, dataDate, pCostCenter);

        }
        //----- OverTime by Factory   Present Month-----

        else if (pCostCenter == "OTFAC1" || pCostCenter == "OTMTALL" || pCostCenter == "OTFAC1M" || pCostCenter == "OTFAC1A" ||
           pCostCenter == "OTFAC2" || pCostCenter == "OTFAC3" || pCostCenter == "OTODM" || pCostCenter == "OTFAC2M" || pCostCenter == "OTFAC2A" ||
                pCostCenter == "OTFAC2MOM" || pCostCenter == "OTFAC2MOA" ||
                pCostCenter == "OTSCRM" || pCostCenter == "OTSCRA" || pCostCenter == "OTFAC3M" || pCostCenter == "OTFAC3A")
        {
            oListMP = oMP.GetChartMPDaily(Year,Month, dataDate, pCostCenter);

        }
        //----- Attandace Man Power by Factory Prev Month   -------
        else if (pCostCenter == "MPFAC1Prev" || pCostCenter == "MPFAC1MPrev" || pCostCenter == "MPFAC1APrev" ||
             pCostCenter == "MPFAC2Prev" || pCostCenter == "MPFAC3Prev" || pCostCenter == "MPODMPrev" || pCostCenter == "MPFAC2MPrev" || pCostCenter == "MPFAC2APrev" ||
                  pCostCenter == "MPFAC2MOMPrev" || pCostCenter == "MPFAC2MOAPrev" ||
                  pCostCenter == "MPSCRMPrev" || pCostCenter == "MPSCRAPrev" || pCostCenter == "MPFAC3MPrev" || pCostCenter == "MPFAC3APrev")
        {
            oListMP = oMP.GetChartMPDaily(_LastYearPrev, Prev, dataDate, pCostCenter);

        }
        //------ OverTime by Factory   Prev Month ---------

        else if (pCostCenter == "OTFAC1Prev" || pCostCenter == "OTMTALLPrev" || pCostCenter == "OTFAC1MPrev" || pCostCenter == "OTFAC1APrev" ||
           pCostCenter == "OTFAC2Prev" || pCostCenter == "OTFAC3Prev" || pCostCenter == "OTODMPrev" || pCostCenter == "OTFAC2MPrev" || pCostCenter == "OTFAC2APrev" ||
                pCostCenter == "OTFAC2MOMPrev" || pCostCenter == "OTFAC2MOAPrev" ||
                pCostCenter == "OTSCRMPrev" || pCostCenter == "OTSCRAPrev" || pCostCenter == "OTFAC3MPrev" || pCostCenter == "OTFAC3APrev")
        {
            oListMP = oMP.GetChartMPDaily(_LastYearPrev, Prev, dataDate, pCostCenter);

        }
        //----- Attandace Man Power by Factory Prev 2 Month   -------
        else if (pCostCenter == "MPFAC1Prev2" || pCostCenter == "MPFAC1MPrev2" || pCostCenter == "MPFAC1APrev2" ||
             pCostCenter == "MPFAC2Prev2" || pCostCenter == "MPFAC3Prev2" || pCostCenter == "MPODMPrev2" || pCostCenter == "MPFAC2MPrev2" || pCostCenter == "MPFAC2APrev2" ||
                  pCostCenter == "MPFAC2MOMPrev2" || pCostCenter == "MPFAC2MOAPrev2" ||
                  pCostCenter == "MPSCRMPrev2" || pCostCenter == "MPSCRAPrev2" || pCostCenter == "MPFAC3MPrev2" || pCostCenter == "MPFAC3APrev2")
        {
            oListMP = oMP.GetChartMPDaily(_LastYearPrev2, Prev2, dataDate, pCostCenter);

        }
        //------ OverTime by Factory   Prev  2 Month ---------

        else if (pCostCenter == "OTFAC1Prev2" || pCostCenter == "OTMTALLPrev2" || pCostCenter == "OTFAC1MPrev2" || pCostCenter == "OTFAC1APrev2" ||
           pCostCenter == "OTFAC2Prev2" || pCostCenter == "OTFAC3Prev2" || pCostCenter == "OTODMPrev2" || pCostCenter == "OTFAC2MPrev2" || pCostCenter == "OTFAC2APrev2" ||
                pCostCenter == "OTFAC2MOMPrev2" || pCostCenter == "OTFAC2MOAPrev2" ||
                pCostCenter == "OTSCRMPrev2" || pCostCenter == "OTSCRAPrev2" || pCostCenter == "OTFAC3MPrev2" || pCostCenter == "OTFAC3APrev2")
        {
            oListMP = oMP.GetChartMPDaily(_LastYearPrev2, Prev2, dataDate, pCostCenter);

        }
        //----- Attandace Man Power by Factory Prev 3 Month   -------
        else if (pCostCenter == "MPFAC1Prev3" || pCostCenter == "MPFAC1MPrev3" || pCostCenter == "MPFAC1APrev3" ||
             pCostCenter == "MPFAC2Prev3" || pCostCenter == "MPFAC3Prev3" || pCostCenter == "MPODMPrev3" || pCostCenter == "MPFAC2MPrev3" || pCostCenter == "MPFAC2APrev3" ||
                  pCostCenter == "MPFAC2MOMPrev3" || pCostCenter == "MPFAC2MOAPrev3" ||
                  pCostCenter == "MPSCRMPrev3" || pCostCenter == "MPSCRAPrev3" || pCostCenter == "MPFAC3MPrev3" || pCostCenter == "MPFAC3APrev3")
        {
            oListMP = oMP.GetChartMPDaily(_LastYearPrev3, Prev3, dataDate, pCostCenter);

        }
        //------ OverTime by Factory   Prev  3 Month ---------

        else if (pCostCenter == "OTFAC1Prev3" || pCostCenter == "OTMTALLPrev3" || pCostCenter == "OTFAC1MPrev3" || pCostCenter == "OTFAC1APrev3" ||
           pCostCenter == "OTFAC2Prev3" || pCostCenter == "OTFAC3Prev3" || pCostCenter == "OTODMPrev3" || pCostCenter == "OTFAC2MPrev3" || pCostCenter == "OTFAC2APrev3" ||
                pCostCenter == "OTFAC2MOMPrev3" || pCostCenter == "OTFAC2MOAPrev3" ||
                pCostCenter == "OTSCRMPrev3" || pCostCenter == "OTSCRAPrev3" || pCostCenter == "OTFAC3MPrev3" || pCostCenter == "OTFAC3APrev3")
        {
            oListMP = oMP.GetChartMPDaily(_LastYearPrev3, Prev3, dataDate, pCostCenter);

        }
        else if (pCostCenter == "FAC1" || pCostCenter == "FAC1M" || pCostCenter == "FAC1A" ||
               pCostCenter == "FAC2" || pCostCenter == "FAC3" || pCostCenter == "ODM" || pCostCenter == "FAC2M" || pCostCenter == "FAC2A" ||
                    pCostCenter == "FAC2MOM" || pCostCenter == "FAC2MOA" ||
                    pCostCenter == "SCRM" || pCostCenter == "SCRA" || pCostCenter == "FAC3M" || pCostCenter == "FAC3A")
        {
            oListMP = oMP.GetChartMP(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "MTALL" || pCostCenter == "MTM" || pCostCenter == "MTA" || pCostCenter == "PU" || pCostCenter == "SPU"
            || pCostCenter == "SP"
               || pCostCenter == "IM" || pCostCenter == "PS" || pCostCenter == "DC" || pCostCenter == "PN" || pCostCenter == "DC"
               || pCostCenter == "WH"
               || pCostCenter == "ENA" || pCostCenter == "ENM" || pCostCenter == "ENMOT"
               || pCostCenter == "IT" || pCostCenter == "UT" || pCostCenter == "WC"
               || pCostCenter == "QC" || pCostCenter == "QA" || pCostCenter == "QS"
               || pCostCenter == "DD" || pCostCenter == "CD")
        {
            //oListMP = oMP.GetChartMPMAandSupport(Month, dataDate, pCostCenter);
            oListMP = oMP.GetChartMPMAandSupport(Month, dataDate, pCostCenter);
        }
        else if (pCostCenter == "ALL")
        {
            oListMP = oMP.GetChartMPALL(Month, dataDate, pCostCenter);
        }
        else if (pCostCenter == "MPALL")
        {
            oListMP = oMP.GetChartMPDailyALL(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "OTALL")
        {
            oListMP = oMP.GetChartMPDailyALL(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "DIRECTALL")
        {
            oListMP = oMP.GetChartMPDailyDIRECTALL(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "OTDIRECTALL")
        {
            oListMP = oMP.GetChartMPDailyDIRECTALL(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "INDIRECTALL")
        {
            oListMP = oMP.GetChartMPDailyINDIRECTALL(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "OTINDIRECTALL")
        {
            oListMP = oMP.GetChartMPDailyINDIRECTALL(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "MPSGA")
        {
            oListMP = oMP.GetChartMPDailyMPSGA(Month, dataDate, pCostCenter);

        }
        else if (pCostCenter == "OTMPSGA")
        {
            oListMP = oMP.GetChartMPDailyMPSGA(Month, dataDate, pCostCenter);

        }
       
       



        if (oListMP.Count > 0)
        {
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(oListMP);
            // ---- Return ----
            context.Response.Write(json);
        }
        else
        {
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


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}









