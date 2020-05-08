<%@ WebHandler Language="C#" Class="GetMechaNGGraph" %>

using System;
using System.Web;

public class GetMechaNGGraph : IHttpHandler {
    string dtStart = "";
    string dtEnd = "";
    string Part_Name = "";
    CMechaNGGraph oGetGraph = new CMechaNGGraph();
    
    public void ProcessRequest (HttpContext context) {
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        Part_Name = context.Request.QueryString["ddlPart_Name"].ToString();
        MDMechaNG oMD = new MDMechaNG();
        oMD = oGetGraph.GetMechaNGGraph(dtStart, dtEnd,Part_Name);

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