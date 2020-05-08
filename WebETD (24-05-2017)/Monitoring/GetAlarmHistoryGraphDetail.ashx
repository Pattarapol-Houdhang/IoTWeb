<%@ WebHandler Language="C#" Class="GetAlarmHistoryGraphDetail" %>

using System;
using System.Web;

public class GetAlarmHistoryGraphDetail : IHttpHandler
{
    string dtStart = "";
    string dtEnd = "";
    string Part_Name = "";
    string Shift = "";
    string Range = "";
    string Volume = "";
    string MC = "";
    string Line = "";
    string Fac = "";
    CAlarmHistoryDetail oGetGraph = new CAlarmHistoryDetail();
    
    public void ProcessRequest (HttpContext context) {
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        MC = context.Request.QueryString["MC"].ToString();
        Line = context.Request.QueryString["Line"].ToString();
        Shift = context.Request.QueryString["Shift"].ToString();
        Fac = context.Request.QueryString["Fac"].ToString(); 
        MDAlarmHistoryDetail oMD = new MDAlarmHistoryDetail();
        oMD = oGetGraph.GetAlarmHistoryGraphDetail(dtStart, dtEnd, MC,Fac, Shift);

        try
        {
            var jsonSerialiser = new System.Web.Script.Serialization.JavaScriptSerializer();
            jsonSerialiser.MaxJsonLength = 500000000;
            var json = jsonSerialiser.Serialize(oMD);
            context.Response.Write(json);
        }
        catch (Exception ex)
        {

        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}