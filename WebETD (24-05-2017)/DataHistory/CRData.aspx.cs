using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

public partial class DataHistory_CRData : System.Web.UI.Page
{
    CGenGraph oGenGraph = new CGenGraph();
    CGenControl oGenControl = new CGenControl();
    CFactory oFactory = new CFactory();
    CLineData oLineData = new CLineData();
    CMachine oMachine = new CMachine();
    GVSorting gSorting1 = new GVSorting();
    ConnectDBFac3 oConnFac3 = new ConnectDBFac3();
    ConnectDB oConn = new ConnectDB();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            InitialVariable();
            InitialControl();

        }
    }

    private void InitialVariable()
    {
        Session["gSorting1"] = gSorting1;
    }

    private void InitialControl()
    {
        //oGenControl.GenDDLModel(CGeneral.TypeSelect.All, ddlModel);
        //oGenControl.GenDDLModel(CGeneral.TypeSelect.Selected, ddlModel);

    }

    public void LoadGrid()
    {
        if (txtSerialNumber.Text.Trim() != "")
        {
            DataTable dTable = new DataTable();
            dTable.TableName = "CR";
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "exec GetDataCRByLabelNo @LabelNo,@Model";
            sql.Parameters.Add(new SqlParameter("@LabelNo", txtSerialNumber.Text.Trim()));
            sql.Parameters.Add(new SqlParameter("@Model", ddlModel.SelectedValue));
            dTable = oConnFac3.Query(sql);

            DataView dView = new DataView();
            dView.Table = dTable;
            gSorting1 = (GVSorting)Session["gSorting1"];

            if (gSorting1 != null)
            {
                if (gSorting1.GetSorting() != "")
                {
                    try
                    {
                        dView.Sort = gSorting1.GetSorting();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            lbSummaryData.Text = dView.Count.ToString();

            GridView1.DataSource = dView;
            GridView1.DataBind();
        }
        else
        {
            txtSerialNumber.Focus();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            //Response.Redirect("~/MachineManagement_Detail.aspx?mc_id=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "Deleting")
        {
            oMachine.DeleteMachine(Convert.ToInt32(e.CommandArgument));
            LoadGrid();
        }
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView dView = new DataView();
        gSorting1 = (GVSorting)Session["gSorting1"];
        gSorting1.SetSorting(e.SortExpression);
        Session["gSorting1"] = gSorting1;
        LoadGrid();
    }


    protected void btSearch_Click(object sender, EventArgs e)
    {

        LoadGrid();
    }
}