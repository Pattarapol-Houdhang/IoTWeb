<%@ WebHandler Language="C#" Class="dataALPHA" %>

using System;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using System.Data;

public class dataALPHA : IHttpHandler {

    OraConnectDB oOraAL1 = new OraConnectDB("ALPHA01");

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        string WC = context.Request.QueryString["T"].ToString() != null ? context.Request.QueryString["T"].ToString() : "";
        string LINE = context.Request.QueryString["L"].ToString() != null ? context.Request.QueryString["L"].ToString() : "";
        string MODEL = context.Request.QueryString["M"].ToString() != null ? context.Request.QueryString["M"].ToString() : "";
        MODEL = MODEL.Replace('_', '#');
        string result = loadSerialCountByWCLineModel(WC, LINE, MODEL);

        context.Response.Write(result);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }


    public string loadSerialCountByWCLineModel(string _wc, string _line, string _model )
    {
        string _result = "0";
                DataTable dtComp = new DataTable();
                string strSQL = @"SELECT COUNT(serial) counts
                    FROM SE.FH001@ALPHAPD 
                    WHERE TRIM(NWC) = '"+ _wc + "' AND TRIM(LINE) = '"+ _line + "' AND TRIM(MODEL) = '"+ _model + "'";
                OracleCommand cmdComp = new OracleCommand();
                cmdComp.CommandText = strSQL;
                cmdComp.CommandTimeout = 120;
                dtComp = oOraAL1.Query(cmdComp);
                try
                {
                    _result = dtComp.Rows[0]["counts"].ToString();
                }
                catch { }

        return _result;
    }

}

