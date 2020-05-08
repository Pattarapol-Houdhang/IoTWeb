using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Setting_PDColumnIndex_Detail : System.Web.UI.Page
{
    CGenControl oGenControl = new CGenControl();
    CFactory oFactory = new CFactory();
    CLineData oLineData = new CLineData();
    GVSorting gSorting1 = new GVSorting();
    ConnectDB oConn = new ConnectDB();
    CMachineHeader oMachineHeader = new CMachineHeader();
    CMachine oMachine = new CMachine();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mc_code"] != "")
        {
            ViewState["mc_code"] = Request.QueryString["mc_code"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/Production/Setting/PDColumnIndex.aspx"));
        }

        if (!IsPostBack)
        {
            InitialVariable();
            InitialControl();
            GetMachineName();
            //LoadGrid();
            LoadData();
            
        }
    }

    private void InitialVariable()
    {
        Session["gSorting1"] = gSorting1;
    }

    private void InitialControl()
    {
        
    }

    private void GetMachineName()
    {
        MDMachine oMDMachine = new MDMachine();
        oMDMachine = oMachine.GetMachineBymc_code(ViewState["mc_code"].ToString());
        if (oMDMachine.ListOfmachine.Count > 0)
        {
            lbMachine.Text = oMDMachine.ListOfmachine[0].mc_code;
        }
    }

    private void LoadData()
    {
        MDMachineHeader oMDMCHeader = new MDMachineHeader();
        oMDMCHeader = oMachineHeader.GetMachineHeaderBymc_code(ViewState["mc_code"].ToString());
        if (oMDMCHeader.ListOfMachineHeader.Count > 0)
        {
            txtDatetime.Text = oMDMCHeader.ListOfMachineHeader[0].index_datetime;
            txtModel.Text = oMDMCHeader.ListOfMachineHeader[0].index_modelcode;
            txtPartNumber.Text = oMDMCHeader.ListOfMachineHeader[0].index_partnumber;
            txtResult.Text = oMDMCHeader.ListOfMachineHeader[0].index_result;
            txtValue.Text = oMDMCHeader.ListOfMachineHeader[0].index_value;
        }
    }

    public void LoadGrid()
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        DataTable dTableData = new DataTable();
        sbd.AppendLine("SELECT TOP 3 data_detail,hm.header_detail");
        sbd.AppendLine("FROM Data dt");
        sbd.AppendLine("LEFT JOIN MachineHeaderIndex mhi ON dt.mc_code=mhi.mc_code");
        sbd.AppendLine("LEFT JOIN HeaderMaster hm ON mhi.header_id=hm.header_id");
        sbd.AppendLine("where dt.mc_code = '" + ViewState["mc_code"].ToString() + "'");
        
        dTableData = oConn.Query(sbd.ToString());

        DataTable dTableDetail = new DataTable();
        dTableDetail.TableName = "Detail";
        if (dTableData.Rows.Count > 0)
        {
            string[] header = dTableData.Rows[0]["header_detail"].ToString().Split(',');
            if (header.Length > 0)
            {
                int countRow = 0;
                ArrayList arrHeader = new ArrayList();
                foreach (string head in header)
                {
                    if (!arrHeader.Contains(head))
                    {
                        dTableDetail.Columns.Add(countRow.ToString() + ". " + head.Trim());
                    }
                    else
                    {
                        dTableDetail.Columns.Add(countRow.ToString() + ". " + head.Trim() + "2");
                    }
                    arrHeader.Add(head.Trim());
                    countRow++;
                }
            }


            foreach (DataRow row in dTableData.Rows)
            {
                string[] spl = row[0].ToString().Split(',');
                if (spl.Length > 0)
                {
                    DataRow dRow;
                    dRow = dTableDetail.NewRow();
                    for (int i = 0; i < spl.Length; i++)
                    {
                        dRow[i] = spl[i].ToString();
                    }
                    dTableDetail.Rows.Add(dRow);
                }
            }
        }

        dTable = dTableDetail.Copy();

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
            Response.Redirect("~/Production/Setting/PDColumnIndex.aspx");
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
        Response.Redirect("~/Production/Setting/PDColumnIndex.aspx");
    }
}