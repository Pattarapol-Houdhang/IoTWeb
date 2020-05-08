<%@ WebHandler Language="C#" Class="GetGraphDataRH" %>

using System;
using System.Web;
using System.Collections;

public class GetGraphDataRH : IHttpHandler
{

    string dtStart = "";
    string dtEnd = "";

    CQCSamplingGraph oGetGraph = new CQCSamplingGraph();

    public void ProcessRequest(HttpContext context)
    {
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();

        MDQCRHID oMD = new MDQCRHID();
        oMD = oGetGraph.GetRHID(dtStart, dtEnd);

        ArrayList arr = new ArrayList();

        string JsonText = "";
        if (oMD.ListOfRH.Count > 0)
        {

            for (int i = 0; i < oMD.ListOfRH.Count; i++)
            {

                if (i == 0)
                {
                    //JsonText = "[";
                }
                if (i < oMD.ListOfRH.Count - 1)
                {
                    JsonText += "[" + oMD.ListOfRH[i].rh_judge_roundness + "],";
                }
                else
                {
                    JsonText += "[" + oMD.ListOfRH[i].rh_judge_roundness + "]";
                }


            }
            //JsonText += "]";
            arr.Add(JsonText);
        }


        try
        {
            var jsonSerialiser = new System.Web.Script.Serialization.JavaScriptSerializer();
            jsonSerialiser.MaxJsonLength = 500000000;
            var json = jsonSerialiser.Serialize(arr);
            context.Response.Write(JsonText);
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