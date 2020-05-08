using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MstMaster : System.Web.UI.Page
{
    MasterListService mstSer = new MasterListService();
    vi_masterTableAdapter oTable = new vi_masterTableAdapter();


    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userName"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}

        if (!IsPostBack) {
            string strModel = DropDownListModelName.SelectedValue.ToString();
            DataTable mstTable = mstSer.GetMasterListByKeyWord(txtSearch.Text, strModel);
            gridViewMasterList.DataSource = mstTable;
            gridViewMasterList.DataBind();
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strModel = DropDownListModelName.SelectedValue.ToString();
        DataTable mstTable = mstSer.GetMasterListByKeyWord(txtSearch.Text, strModel);

        if (mstTable != null)
        {
            gridViewMasterList.DataSource = mstTable;
            gridViewMasterList.DataBind();
        }
    }
    protected void btnNewMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterDetail.aspx");
    }

    protected void gridViewMasterList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            string ID = e.CommandArgument.ToString();

            Response.Redirect("MasterDetail.aspx?id=" + ID);
        }
    }
}