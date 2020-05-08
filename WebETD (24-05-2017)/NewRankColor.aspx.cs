using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewRankColor : System.Web.UI.Page
{
    private string bufId;
    private RankItemsService riSer = new RankItemsService();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            if ((bufId = Request.QueryString["id"]) != null)
            {
                try {
                    btnDelete.Visible = true;
                    Session["editState"] = true;
                    this.RankInfo = riSer.SearchRankByID(Convert.ToInt16(bufId));

                    hidRankID.Value = bufId;
                }
                catch {
                    Session["rank_id"] = 0;
                    Session["editState"] = false;
                    hidRankID.Value = "0";
                }
                
            }
            else
            {
                Session["rank_id"] = 0;
                Session["editState"] = false;
                hidRankID.Value = "0";
            }
        }
        
    }

    private Object RankInfo {
        get {
            RankItemsInfo rank = new RankItemsInfo();

            rank.R_id = Convert.ToInt16(Session["rank_id"]);
            rank.R_name = txtRank.Text.ToUpper();
            rank.R_color = txtColor.Text;

            return rank;
        }

        set {
            RankItemsInfo rank = (RankItemsInfo)value;

            if (rank != null)
            {
                Session["rank_id"] = rank.R_id;
                txtRank.Text = rank.R_name.ToUpper();
                txtColor.Text = rank.R_color.Replace('#',' ').Trim();

                try {
                    txtColor.ForeColor = ColorTranslator.FromHtml("#" + txtColor.Text);
                    txtColor.BackColor = ColorTranslator.FromHtml("#" + txtColor.Text);
                }
                catch { }
                
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RankSetting.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (riSer.DeleteRankByID(Convert.ToInt16(Session["rank_id"])))
        {
            Response.Redirect("RankSetting.aspx");
        }
    }
}