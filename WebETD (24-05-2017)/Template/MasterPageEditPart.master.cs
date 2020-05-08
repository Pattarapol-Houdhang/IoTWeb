using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template_MasterPageEditPart : System.Web.UI.MasterPage
{
    string bufModelID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((bufModelID = Request.QueryString["id"]) != null)
            {
                Session["editState"] = true;
                var bufSplit = bufModelID.Split(',');

                if (bufSplit != null)
                {
                    lblModelNo.Text = bufSplit[0];
                    txtModelName.Text = bufSplit[1];
                }

            }
            else
            {
                Session["editState"] = false;
            }
        }
    }

    protected void BtnEditCS_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModelEditCS.aspx?id=" + lblModelNo.Text + "," + txtModelName.Text);
    }

    protected void BtnEditPT_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModelEditPT.aspx?id=" + lblModelNo.Text + "," + txtModelName.Text);
    }

    protected void BtnEditCY_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModelEditCY.aspx?id=" + lblModelNo.Text + "," + txtModelName.Text);
    }

    protected void BtnEditFH_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModelEditFH.aspx?id=" + lblModelNo.Text + "," + txtModelName.Text);
    }

    protected void BtnEditRH_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModelEditRH.aspx?id=" + lblModelNo.Text + "," + txtModelName.Text);
    }

    protected void BtnEditSB_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModelEditSB.aspx?id=" + lblModelNo.Text + "," + txtModelName.Text);
    }
}
