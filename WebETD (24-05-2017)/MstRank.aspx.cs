using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MstRank : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack) { 
            
        }
    }

    protected void btnNewGroupRank_Click(object sender, EventArgs e)
    {
        Response.Redirect("RankSetting.aspx");
    }


    protected void gridViewRankGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            string ID = e.CommandArgument.ToString();

            Response.Redirect("RankSetting.aspx?id=" + ID);
        }
    }
}