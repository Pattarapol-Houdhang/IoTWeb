using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MstModel : System.Web.UI.Page
{
    MasterModelService mSer = new MasterModelService();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userName"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}

        if (!IsPostBack)
        {
            DataTable mstTable = mSer.GetMstModelDataByKeyword(txtSearch.Text);
            gridViewModelList.DataSource = mstTable;
            gridViewModelList.DataBind();
        }

    }


    protected void gridViewRankGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            string ID = e.CommandArgument.ToString();

            Response.Redirect("ModelEdit.aspx?id=" + ID);
        }
    }


    protected void btnNewModel_Click(object sender, EventArgs e)
    {
        //Response.Redirect("MstTolerance.aspx");
        Response.Redirect("ModelDetail.aspx");
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
        DataTable mstTable = mSer.GetMstModelDataByKeyword(txtSearch.Text);

        if (mstTable != null)
        {
            gridViewModelList.DataSource = mstTable;
            gridViewModelList.DataBind();
        }
    }
}