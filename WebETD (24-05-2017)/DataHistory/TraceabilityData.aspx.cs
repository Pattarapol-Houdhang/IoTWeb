using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataHistory_TraceabilityData : System.Web.UI.Page
{
    ConnectDBDCIMax oConnDCI = new ConnectDBDCIMax();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");

    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    DateTime strInDate = new DateTime();
    DateTime endInDate = new DateTime();
    DateTime strOutDate = new DateTime();
    DateTime endOutDate = new DateTime();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtPrdDate.Attributes.Add("readonly", "readonly");
            //txtInDate.Attributes.Add("readonly", "readonly");
            //txtOutDate.Attributes.Add("readonly", "readonly");
        }
    }


    protected void rptTraceability_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbETDData = (Label)e.Item.FindControl("lbETDData");
            Label lbETAData = (Label)e.Item.FindControl("lbETAData");

            //Label lbPlDate = (Label)e.Item.FindControl("lbPlDate");
            Label lbinDate = (Label)e.Item.FindControl("inDate");
            Label lboutDate = (Label)e.Item.FindControl("outDate");
            Label lbcrDate = (Label)e.Item.FindControl("crDate");
            Label lbprdDate = (Label)e.Item.FindControl("prdDate");

            
            
        }
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        rptTraceability.DataSource = null;
        rptTraceability.DataBind();
        
        
        SqlCommand sql = new SqlCommand();
        

        

        sql.CommandTimeout = 1800;
        DataTable dt = oConnDCI.SqlGet(sql);
        rptTraceability.DataSource = dt;
        rptTraceability.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        
    }
}