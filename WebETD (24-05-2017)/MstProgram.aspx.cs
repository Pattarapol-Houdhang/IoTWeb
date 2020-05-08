using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetProgram : System.Web.UI.Page
{
    MasterProgramService proSer = new MasterProgramService();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            DataTable mstTable = proSer.GetMstProgramDataByKeyword(txtSearch.Text);
            gridViewProgramList.DataSource = mstTable;
            gridViewProgramList.DataBind();
        }
    }
    protected void gridViewRankGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            string ID = e.CommandArgument.ToString();

            Response.Redirect("ProgramDetail.aspx?id=" + ID);
        }
    }


    protected void btnNewProgram_Click(object sender, EventArgs e)
    {
        //Response.Redirect("MstTolerance.aspx");
        Response.Redirect("ProgramDetail.aspx");
    }

    protected void gridViewRankGroup_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string _status = e.Row.Cells[2].Text;
        if (_status == "True" || _status == "False")
        {
            if (_status == "False")
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataTable mstTable = proSer.GetMstProgramDataByKeyword(txtSearch.Text);

        if (mstTable != null)
        {
            gridViewProgramList.DataSource = mstTable;
            gridViewProgramList.DataBind();
        }
    }
}