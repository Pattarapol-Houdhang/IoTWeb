<%@ WebHandler Language="C#" Class="ModelJson" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;

public class ModelJson : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        CModelInfo oModel = new CModelInfo();


        List<MDModelCompressor> oList = new List<MDModelCompressor>();
        oList = oModel.GetModelCompressor();
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