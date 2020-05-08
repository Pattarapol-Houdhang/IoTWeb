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
using CRService;

public partial class DataHistory_CRDataPallet : System.Web.UI.Page
{
    CGenGraph oGenGraph = new CGenGraph();
    CGenControl oGenControl = new CGenControl();
    CFactory oFactory = new CFactory();
    CLineData oLineData = new CLineData();
    CMachine oMachine = new CMachine();
    GVSorting gSorting1 = new GVSorting();
    ConnectDBFac3 oConnFac3 = new ConnectDBFac3();
    ConnectDB oConn = new ConnectDB();
    CRService.Service oCR = new Service();
    ConnectDBDCI oConnDCI = new ConnectDBDCI();

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
            SqlCommand sql = new SqlCommand();
            DataTable dTablePallet = new DataTable();
            dTablePallet.TableName = "Pallet";
            sql.CommandText = "SELECT pl_no,pl_date,pck_no,prd_serial,prd_cd,prd_date,wh_recieve FROM vi_Pack_Pallet";
            sql.CommandText += " WHERE pl_no = @Pallet AND line_cd=6";
            sql.Parameters.Add(new SqlParameter("@Pallet", txtSerialNumber.Text.Trim()));
            dTablePallet = oConnDCI.Query(sql);

            DataTable dTable = new DataTable();
            dTable.TableName = "CR";
            if (dTablePallet.Rows.Count > 0)
            {
                foreach(DataRow _row in dTablePallet.Rows)
                {
                    DataTable _dTable = new DataTable();
                    sql = new SqlCommand();
                    sql.CommandText = "exec GetDataCRByLabelNo @LabelNo,@Model";
                    sql.Parameters.Add(new SqlParameter("@LabelNo", _row["prd_serial"].ToString().Substring(7,8)));
                    sql.Parameters.Add(new SqlParameter("@Model", _row["prd_serial"].ToString().Substring(3, 4)));
                    _dTable = oConnFac3.Query(sql);
                                        
                    if(dTable.Columns.Count != _dTable.Columns.Count)
                    {
                        dTable = _dTable.Clone();
                    }

                    if (_dTable.Rows.Count > 0)
                    {
                        foreach(DataRow row in _dTable.Rows)
                        {
                            
                            dTable.Rows.Add(row.ItemArray);
                        }
                    }
                }
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
            //oMachine.DeleteMachine(Convert.ToInt32(e.CommandArgument));
            //LoadGrid();
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

    protected void btExport_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ExportExcelCRByPallet.ashx?Pallet=" + txtSerialNumber.Text.Trim());
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }

}