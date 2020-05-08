<%@ WebHandler Language="C#" Class="GetJsonAlarmDetail" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class GetJsonAlarmDetail : IHttpHandler {


    public void ProcessRequest(HttpContext context) {
        context.Response.ContentType = "text/plain";
        string mcName = context.Request.QueryString["name"] != null ? context.Request.QueryString["name"].ToString() : "Laser_Marking";
        string mcCode = context.Request.QueryString["McCode"] != null ? context.Request.QueryString["McCode"].ToString() : "";
        string date = context.Request.QueryString["date"] != null ? context.Request.QueryString["date"].ToString() : DateTime.Now.ToString();
        string line = context.Request.QueryString["line"] != null ? context.Request.QueryString["line"].ToString() : "main";

        string McSreach = "";
        //if (line == "piston" || line == "fh" || line == "cs" || line == "cd" || line == "rh")
        //{
        //    mcName = mcName.Replace(" ", "_");
        //}
        //if (line == "rh")
        //{
        //    switch (mcName)
        //    {
        //        case "Rear Head LaserMarking" : McSreach = "RH_LaserMarking"; break;
        //        case "Rear Head Surface" : McSreach = "RH_Surface"; break;
        //        case "Rear Head Internal Grinding No 1" : McSreach = "RH_Internal1"; break;
        //        case "Rear Head Internal Grinding No 2" : McSreach = "RH_Internal2"; break;
        //        case "Rear Head Brushing" : McSreach = "RH_Brushing"; break;
        //    }
        //}
        //else if (line == "fh")
        //{
        //    switch (mcName)
        //    {
        //        case "Laser Marking": McSreach = "FH_Laser"; break;
        //        case "Surface": McSreach = "FH_Surface"; break;
        //        case "Brush": McSreach = "FH_Brushing"; break;
        //        case "Internal 1": McSreach = "FH_Internal_No1"; break;
        //        case "Internal 2": McSreach = "FH_Internal_No2"; break;
        //    }
        //}
        //else if (line == "piston")
        //{
        //    switch (mcName)
        //    {
        //        case "Laser Marking": McSreach = "PI_Laser"; break;
        //        case "Surface": McSreach = "PI_Surface"; break;
        //        case "Brush": McSreach = "PI_Brushing"; break;
        //        case "Internal 1": McSreach = "PI_Internal_No1"; break;
        //        case "Internal 2": McSreach = "PI_Internal_No2"; break;
        //    }
        //}


        CGetAlarmDetail oGet = new CGetAlarmDetail();

        DateTime dateSearch = Convert.ToDateTime(date).Date + new TimeSpan(8, 0, 0);
        List<MAlarmInfo> oList = new List<MAlarmInfo>();
        oList = oGet.GetDataAlarmHead(McSreach, dateSearch,mcCode);

        var jsonSerialiser = new JavaScriptSerializer();
        var json = jsonSerialiser.Serialize(oList);

        context.Response.Write(json);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}