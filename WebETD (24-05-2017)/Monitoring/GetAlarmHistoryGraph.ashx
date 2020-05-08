<%@ WebHandler Language="C#" Class="GetAlarmHistoryGraph" %>

using System;
using System.Web;

public class GetAlarmHistoryGraph : IHttpHandler
{
    string dtStart = "";
    string dtEnd = "";
    string Part_Name = "";
    string Shift = "";
    string Range = "";
    string Volume = "";
    string listMC = "";
    string Line = "";
    string fac = "";
    string LineODM = "";
    CAlarmHistory oGetGraph = new CAlarmHistory();
    
    public void ProcessRequest (HttpContext context) {
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        Shift = context.Request.QueryString["Shift"].ToString();
        Range = context.Request.QueryString["Range"].ToString();
        Volume = context.Request.QueryString["Volume"].ToString();
        listMC = context.Request.QueryString["listMC"].ToString();
        Line = context.Request.QueryString["Line"].ToString();
        fac = context.Request.QueryString["fac"].ToString();
        LineODM = context.Request.QueryString["LineODM"].ToString();
        MDAlarmHistory oMD = new MDAlarmHistory();
        oMD = oGetGraph.GetAlarmHistoryGraph(dtStart, dtEnd, Range, Shift, Volume, listMC, Line, fac, LineODM);

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