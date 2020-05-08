<%@ WebHandler Language="C#" Class="EncodeTextToHTML" %>

using System;
using System.Web;

public class EncodeTextToHTML : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        

        string Encoded = "";
        Encoded = context.Request.QueryString["Encode"].ToString();
        string EncodedString = System.Web.HttpUtility.UrlPathEncode(Encoded);
        //context.Response.ContentType = "text/plain";
        context.Response.Write(EncodedString);
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    public string encode
    {
        set {
            string TestString = "This is a <Test String>.";
            

            
        }
        
    }

}