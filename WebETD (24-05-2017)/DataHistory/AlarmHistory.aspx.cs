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

public partial class DataHistory_AlarmHistory : System.Web.UI.Page
{
    CGenGraph oGenGraph = new CGenGraph();
    CGenControl oGenControl = new CGenControl();
    CFactory oFactory = new CFactory();
    CLineData oLineData = new CLineData();
    CMachine oMachine = new CMachine();
    GVSorting gSorting1 = new GVSorting();
    ConnectDBIoTServerTonMecha oConnFac3 = new ConnectDBIoTServerTonMecha();
    ConnectDB oConn = new ConnectDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialVariable();
            InitialControl();
            ddlShift.SelectedValue = "D";
        }
    }

    private void InitialVariable()
    {
        Session["gSorting1"] = gSorting1;
        txtDateStart.Text = DateTime.Now.ToString("yyyy/MM/dd");
        txtDateEnd.Text = DateTime.Now.ToString("yyyy/MM/dd");
    }

    private void InitialControl()
    {
        //oGenControl.GenDDLModel(CGeneral.TypeSelect.All, ddlModel);
        //oGenControl.GenDDLModel(CGeneral.TypeSelect.Selected, ddlModel);
        oGenControl.GenDDLAlarmLine(CGeneral.TypeSelect.Selected,ddlLine);
        oGenControl.GenDDLAlarmMachineByLine(CGeneral.TypeSelect.All, ddlMachine, ddlLine.SelectedValue);
    }

    public void LoadGrid()
    {
        DataTable dTable = new DataTable();
        dTable.TableName = "CR";
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT MCName,StampDate,Shift,LastAlarmDate,CountAlarm FROM LogAlarmMC lam";
        sql.CommandText += " INNER JOIN AlarmLineSetting als ON lam.MCName=als.MachineName";
        sql.CommandText += " where als.LineName = @LineName";
        sql.CommandText += " and lam.StampDate >= @DateStart";
        sql.CommandText += " and lam.StampDate <= @DateEnd";
        if (ddlShift.SelectedValue != "")
        {
            sql.CommandText += " and lam.Shift = @Shift";
        }
        if (ddlMachine.SelectedValue != "")
        {
            sql.CommandText += " and lam.MCName=@MCName";
        }
        sql.Parameters.Add(new SqlParameter("@DateStart", txtDateStart.Text.Trim()));
        sql.Parameters.Add(new SqlParameter("@DateEnd", txtDateEnd.Text.Trim()));
        sql.Parameters.Add(new SqlParameter("@Shift", ddlShift.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@LineName", ddlLine.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@MCName", ddlMachine.SelectedValue));
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

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ExportExcelAlarmHistory.ashx?LineName=" + ddlLine.SelectedValue + "&Machine=" + ddlMachine.SelectedValue
                + "&DateStart=" + txtDateStart.Text.Trim() + "&DateEnd=" + txtDateEnd.Text.Trim() + "&Shift=" + ddlShift.SelectedValue
                + "&Line=" + ddlLine.SelectedValue);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }

}