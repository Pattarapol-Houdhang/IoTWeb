using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RankSetting : System.Web.UI.Page
{
    private RunNumberService runNbr = new RunNumberService();
    private GroupRankService grSer = new GroupRankService();
    private string bufId;
    private DataTable gTable = new DataTable();
    private string[] grData;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack) {

            if ((bufId = Request.QueryString["id"]) != null)
            {
                try
                {
                    btnDelete.Visible = true;
                    Session["editState"] = true;
                    
                    hidRankID.Value = bufId;

                    gTable = grSer.SelectGroupDataByID(hidRankID.Value);

                    var bufData = gTable.Rows[0]["r_name"].ToString().Trim().Split(',');

                    grData = new string[bufData.Length];

                    grData = bufData;

                }
                catch
                {
                    Session["editState"] = false;
                    hidRankID.Value = "0";
                }

            }
            else
            {
                btnDelete.Visible = false;
                Session["editState"] = false;
                hidRankID.Value = "0";
            }
        
        }
    }
    
    protected void GridViewRank_Load(object sender, EventArgs e)
    {
        try
        {

            foreach (GridViewRow row in GridViewRank.Rows)
            {
                string _strColor = row.Cells[2].Text.ToString().Trim();

                row.Cells[2].BackColor = ColorTranslator.FromHtml(_strColor);
                row.Cells[2].ForeColor = ColorTranslator.FromHtml(_strColor);

                if (Convert.ToBoolean(Session["editState"]))
                {
                    //string str = row.Cells[1].Text;
                    for (int i = 0; i < grData.Length - 1; i++)
                    {
                        if (grData[i] == row.Cells[1].Text)
                        {
                            (row.FindControl("CheckBoxRank") as CheckBox).Checked = true;
                            break;
                        }
                    }
                }

            }

        }
        catch { }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //new group key
        //loop save to db
        string _rankID = "";
        string _rankName = "";
        foreach (GridViewRow row in GridViewRank.Rows)
        {
            // is rows checked
            if ((row.FindControl("CheckBoxRank") as CheckBox).Checked)
            {
                try
                {
                    if (_rankID == "")
                    {
                        _rankID += GridViewRank.DataKeys[row.DataItemIndex].Values[0].ToString();
                        _rankName += row.Cells[1].Text;
                    }
                    else
                    {
                        _rankID += "," + GridViewRank.DataKeys[row.DataItemIndex].Values[0].ToString();
                        _rankName += "," + row.Cells[1].Text;
                    }
                }
                catch { }
            }
        }

        //lblData.Text = _rankID + " : " + _rankName;

        if (!Convert.ToBoolean(Session["editState"]))
        {
            string idRank = runNbr.NextId("GR");
            grSer.InsertNewGroup(idRank, _rankID, _rankName);

        }
        else {

            grSer.UpdateGroupData(hidRankID.Value, _rankID, _rankName);

        }

        Response.Redirect("MstRank.aspx");
        
    }

    protected void btnAddNewRank_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewRankColor.aspx?id=");
    }

    protected void GridViewRank_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            string ID = e.CommandArgument.ToString();

            Response.Redirect("NewRankColor.aspx?id=" + ID);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (grSer.DeleteGroup(hidRankID.Value))
        {
            Response.Redirect("MstRank.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MstRank.aspx");
    }
}