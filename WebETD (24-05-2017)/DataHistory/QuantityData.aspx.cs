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

public partial class DataHistory_QuantityData : System.Web.UI.Page
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
        if (Request.QueryString["FactoryID"] != null)
        {
            ViewState["FactoryID"] = Request.QueryString["FactoryID"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=1"));
        }

        if (Request.QueryString["ld_id"] != null)
        {
            ViewState["ld_id"] = Request.QueryString["ld_id"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=" + ViewState["FactoryID"].ToString()));
        }

        if (Request.QueryString["mc_code"] != null)
        {
            ViewState["mc_code"] = Request.QueryString["mc_code"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=" + ViewState["FactoryID"].ToString()));
        }

        if (!IsPostBack)
        {
            InitialVariable();
            InitialControl();
            txtDateStart.Text = DateTime.Now.ToString();
            txtDateEnd.Text = DateTime.Now.ToString();
        }
    }

    private void InitialVariable()
    {
        Session["gSorting1"] = gSorting1;
    }

    private void InitialControl()
    {
        //oGenControl.GenDDLModel(CGeneral.TypeSelect.All, ddlModel);

        MDFactory oMDFactory = new MDFactory();
        MDLineData oMDLineData = new MDLineData();
        MDMachine oMDMachine = new MDMachine();

        oMDFactory = oFactory.GetFactoryByFactoryID(ViewState["FactoryID"].ToString());
        oMDLineData = oLineData.GetLineDataByLineID(Convert.ToInt32(ViewState["ld_id"]));
        //oMDMachine = oMachine.GetMachineBymc_code(ViewState["mc_code"].ToString());

        if (oMDFactory.ListOfFactory.Count > 0)
        {
            lbFactory.Text = oMDFactory.ListOfFactory[0].FactoryName;
        }
        if (oMDLineData.ListOfLine.Count > 0)
        {
            lbPDLine.Text = oMDLineData.ListOfLine[0].ld_linename;
        }

        oGenControl.GenDDLMachineByLine(CGeneral.TypeSelect.Please, ddlMachine, ViewState["ld_id"].ToString());

        ddlMachine.SelectedValue = ViewState["mc_code"].ToString();
    }

    public void LoadGrid()
    {
        DataTable dTable = new DataTable();
        dTable.TableName = "Quantity";
        StringBuilder sbd = new StringBuilder();
        if (ViewState["ld_id"].ToString() == "4")
        {
            // From MES
            // Main Assembly Line
            if (ViewState["mc_code"].ToString() == "Main01") // Rotor Yakibame
            {
                sbd.AppendLine("SELECT * FROM Rotor_Yakibame");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }
            else if (ViewState["mc_code"].ToString() == "Main02") // Magnetize
            {
                sbd.AppendLine("SELECT * FROM Magnetize");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }
            else if (ViewState["mc_code"].ToString() == "Main03") // Pipe Yakibame
            {
                sbd.AppendLine("SELECT * FROM Pipe_Yakibame");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }
            else if (ViewState["mc_code"].ToString() == "Main04") // Tack Welding
            {
                sbd.AppendLine("SELECT * FROM TackWelding");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }
            else if (ViewState["mc_code"].ToString() == "Main05") // Magnet Center
            {
                sbd.AppendLine("SELECT * FROM MagnetCenter");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }
            else if (ViewState["mc_code"].ToString() == "Main06") // Air Gap
            {
                sbd.AppendLine("SELECT * FROM AirGap");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }
            else if (ViewState["mc_code"].ToString() == "Main07") // Connecting Check
            {
                sbd.AppendLine("SELECT * FROM ElectricalConduction");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }
            else if (ViewState["mc_code"].ToString() == "Main08") // Connecting Check
            {
                sbd.AppendLine("SELECT * FROM TopBottomWelding");
                sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
                sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
                sbd.AppendLine("ORDER BY InsertDate desc");
            }

            dTable = oConnFac3.Query(sbd.ToString());
        }
        else if (ViewState["mc_code"].ToString() == "PISTON_LASER")
        {
            sbd.AppendLine("SELECT * FROM MC_LaserMark_Piston");
            sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
            sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
            sbd.AppendLine("ORDER BY InsertDate desc");
            dTable = oConnFac3.Query(sbd.ToString());
        }
        else if (ViewState["mc_code"].ToString() == "FRONTHEAD_LASER")
        {
            sbd.AppendLine("SELECT * FROM MC_LaserMark_FH");
            sbd.AppendLine("WHERE InsertDate >= '" + txtDateStart.Text.Trim() + "'");
            sbd.AppendLine("AND InsertDate <= '" + txtDateEnd.Text.Trim() + "'");
            sbd.AppendLine("ORDER BY InsertDate desc");
            dTable = oConnFac3.Query(sbd.ToString());
        }
        else
        {
            // From Data Logger            
            sbd = new StringBuilder();
            DataTable dTableData = new DataTable();
            sbd.AppendLine("SELECT data_detail,hm.header_detail");
            sbd.AppendLine("FROM Data dt");
            sbd.AppendLine("LEFT JOIN MachineHeaderIndex mhi ON dt.mc_code=mhi.mc_code");
            sbd.AppendLine("LEFT JOIN HeaderMaster hm ON mhi.header_id=hm.header_id");
            sbd.AppendLine("where dt.mc_code = '" + ddlMachine.SelectedValue + "'");
            if (ddlModel.SelectedValue != "0")
            {
                sbd.AppendLine("AND model_id='" + ddlModel.SelectedValue + "'");
            }
            sbd.AppendLine("AND data_mfgdate_search >= '" + txtDateStart.Text.Trim() + "'");
            sbd.AppendLine("AND data_mfgdate_search <= '" + txtDateEnd.Text.Trim() + "'");
            sbd.AppendLine("AND data_partnumber like '%" + txtSerialNumber.Text.Trim() + "%'");
            dTableData = oConn.Query(sbd.ToString());

            DataTable dTableDetail = new DataTable();
            dTableDetail.TableName = "Detail";
            if (dTableData.Rows.Count > 0)
            {
                string[] header = dTableData.Rows[0]["header_detail"].ToString().Split(',');
                if (header.Length > 0)
                {
                    ArrayList arrHeader = new ArrayList();
                    foreach (string head in header)
                    {
                        if (!arrHeader.Contains(head))
                        {
                            dTableDetail.Columns.Add(head.Trim());
                        }
                        else
                        {
                            dTableDetail.Columns.Add(head.Trim() + "2");
                        }
                        arrHeader.Add(head.Trim());
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            Response.Redirect("~/MachineManagement_Detail.aspx?mc_id=" + e.CommandArgument.ToString());
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

    protected void btBackPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveClientUrl("~/DataHistory/DataMachine.aspx?FactoryID=" + ViewState["FactoryID"].ToString() + "&ld_id=" + ViewState["ld_id"].ToString()));
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }
}