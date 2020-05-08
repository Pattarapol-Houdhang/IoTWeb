using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Setting_PDColumnIndex : System.Web.UI.Page
{
    CGenControl oGenControl = new CGenControl();
    CFactory oFactory = new CFactory();
    CLineData oLineData = new CLineData();
    GVSorting gSorting1 = new GVSorting();
    ConnectDB oConn = new ConnectDB();
    CMachineHeader oMachineHeader = new CMachineHeader();
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
        oGenControl.GenDDLFactory(CGeneral.TypeSelect.All, ddlFactory);

        //oGenControl.GenDDLLineData(CGeneral.TypeSelect.All, ddlLine);
        oGenControl.GenDDLLineDataByFactoryID(CGeneral.TypeSelect.All, ddlLine, Convert.ToInt32(ddlFactory.SelectedValue));

    }

    public void LoadGrid()
    {
        DataTable dTable = new DataTable();
        dTable.TableName = "IndexColumn";
        dTable.Columns.Add("mhi_id");
        dTable.Columns.Add("mc_code");
        dTable.Columns.Add("index_datetime");
        dTable.Columns.Add("index_partnumber");
        dTable.Columns.Add("index_modelcode");
        dTable.Columns.Add("index_value");
        dTable.Columns.Add("index_result");


        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT DISTINCT mc.mc_code,index_datetime,index_partnumber,index_modelcode,index_value,index_result");
        sbd.AppendLine(",mhi.mhi_id");
        sbd.AppendLine("FROM Machine mc");
        sbd.AppendLine("LEFT JOIN MachineHeaderIndex mhi ON mc.mc_code=mhi.mc_code");
        sbd.AppendLine("LEFT JOIN IndexColumn ic ON mhi.index_id=ic.index_id");
        sbd.AppendLine("LEFT JOIN LineData ld ON mc.ld_id=ld.ld_id");
        sbd.AppendLine("LEFT JOIN FactoryData fd ON ld.FactoryID=fd.FactoryID");
        if (ddlFactory.SelectedValue != "0")
        {
            sbd.AppendLine("WHERE fd.FactoryID = '" + ddlFactory.SelectedValue + "'");
        }

        
        if (ddlLine.SelectedValue != "0" && ddlFactory.SelectedValue != "0")
        {
            sbd.AppendLine("AND ld.ld_id='" + ddlLine.SelectedValue + "'");
        }
        
        dTable = oConn.Query(sbd.ToString());

        dTable.Columns.Add("CanEdit", typeof(bool));
        dTable.Columns.Add("CanDel", typeof(bool));


        if (dTable.Rows.Count > 0)
        {
            for (int i = 0; i < dTable.Rows.Count; i++)
            {

                dTable.Rows[i]["CanEdit"] = true;
                dTable.Rows[i]["CanDel"] = true;
            }
        }
        else
        {
            DataRow row;
            row = dTable.NewRow();
            row["CanEdit"] = false;
            row["CanDel"] = false;
            dTable.Rows.Add(row);

        }


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

        GridView1.DataSource = dView;
        GridView1.DataBind();

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
            Response.Redirect("~/Production/Setting/PDColumnIndex_Detail.aspx?mc_code=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "Deleting")
        {
            oMachineHeader.DeleteMachineHeader(Convert.ToInt32(e.CommandArgument.ToString()));
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

    protected void btBackPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Production/Setting/PDSettingMenu.aspx");
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }

    protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
    {
        oGenControl.GenDDLLineDataByFactoryID(CGeneral.TypeSelect.All, ddlLine, Convert.ToInt32(ddlFactory.SelectedValue));
    }


}