<%@ WebHandler Language="C#" Class="ExecuteNewRankColor" %>

using System;
using System.Web;

public class ExecuteNewRankColor : IHttpHandler {

    private RankItemsService riSer = new RankItemsService();
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        string _pID = context.Request.QueryString["id"];
        string _pText = context.Request.QueryString["txt"];
        string _pColor = context.Request.QueryString["colors"];
        
        RankItemsInfo rank = new RankItemsInfo();
        rank.R_id = Convert.ToInt16(_pID);
        rank.R_name = _pText.ToUpper();
        rank.R_color = "#"+_pColor;


        bool successDB = false;
        
        if (rank.R_id == 0)
        {
            successDB = riSer.InsertRankItem(rank); 
        }
        else
        {
            successDB = riSer.UpdateRankByID(rank);
        }


        context.Response.Write(successDB.ToString());
    }
 
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}