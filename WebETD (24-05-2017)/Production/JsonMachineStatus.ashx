<%@ WebHandler Language="C#" Class="JsonMachineStatus" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class JsonMachineStatus : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string MC = context.Request.QueryString["MC"].ToString() != null ? context.Request.QueryString["MC"].ToString() : "";
        string Start = context.Request.QueryString["Start"].ToString() != null ? context.Request.QueryString["Start"].ToString() : "0";
        string Stop = context.Request.QueryString["Stop"].ToString() != null ? context.Request.QueryString["Stop"].ToString() : "0";

        DateTime ctStart = new DateTime();
        DateTime ctStop = new DateTime();

        try
        {
            ctStart = Convert.ToDateTime(Start);
            ctStop = Convert.ToDateTime(ctStop);
        }
        catch { }
        
        CGetMachineStatus oMCStat = new CGetMachineStatus();
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        if (MC == "Rotor")
        {
            oList = oMCStat.GetStatusRotorYakibame(ctStart, ctStop);
        }
        else
        {
            MDMachineStatus oMD = new MDMachineStatus();
            oMD.Status = "TRUE";
            oList.Add(oMD);
        }

        var jsonSerialiser = new JavaScriptSerializer();
        var json = jsonSerialiser.Serialize(oList);
        context.Response.Write(json);
        //context.Response.Close();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}