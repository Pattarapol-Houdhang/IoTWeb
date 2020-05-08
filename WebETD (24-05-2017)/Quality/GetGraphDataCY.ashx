<%@ WebHandler Language="C#" Class="GetGraphDataCY" %>

using System;
using System.Web;

public class GetGraphDataCY : IHttpHandler
{

    string dtStart = "";
    string dtEnd = "";
    string RowsQty = "";

    CQCSamplingGraph oGetGraph = new CQCSamplingGraph();

    public void ProcessRequest(HttpContext context)
    {
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        RowsQty = context.Request.QueryString["RowsQty"].ToString();

        MDQCCY oMD = new MDQCCY();
        oMD = oGetGraph.GetCY(dtStart, dtEnd, RowsQty);

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

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}