using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_fgdatalist : System.Web.UI.Page
{
    ConnectDB oConDIT = new ConnectDB();
    CFGDataList cData = new CFGDataList();

    private void InitialControl()
    {
        txtPrdDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        DateTime Date = Convert.ToDateTime(txtPrdDate.Text);
        int i = 0;
        string Shift = "";
        if (ddlShift.SelectedValue == "D")
        {
            Shift = "08:00,20:00,D";
            i = 0;
        }
        else if (ddlShift.SelectedValue == "N")
        {
            Shift = "20:00,08:00,N";
            i = 1;
        }
        else
        {
            Shift = "08:00,08:00,A";
            i = 1;
        }
        ltrFilter.InnerText = " *** ข้อมูล  Line " + ddlLine.SelectedValue + "  ตั้งแต่ " + Date.ToString("yyyy/MM/dd") + " " + Shift.Split(',')[0] + " ถึง " + Date.AddDays(1).ToString("yyyy/MM/dd") + " " + Shift.Split(',')[1] + " *** ";
        lbPlan.InnerText = " *** แผนการผลิต  Line " + ddlLine.SelectedValue + "  วันที่ " + Date.ToString("yyyy/MM/dd") + " *** ";
        LoadData(txtPrdDate.Text, ddlLine.SelectedValue, ddlShift.SelectedValue);
        headLink("1");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialControl();

        }

    }
    public void ClearDataGrid()
    {
        GridView1.DataSource = new DataTable();
        GridView1.DataBind();

        gvAlpha.DataSource = new DataTable();
        gvAlpha.DataBind();

        gvPlan.DataSource = new DataTable();
        gvPlan.DataBind();

        gvActual.DataSource = new DataTable();
        gvActual.DataBind();

    }
    private void LoadPlan(string Date, string Line)
    {
        gvPlan.DataSource = cData.getPlan(Line, Date);
        gvPlan.DataBind();
    }
    private void LoadData(string SDate, string Line, string Shift)
    {
        ClearDataGrid();
        DateTime Date = Convert.ToDateTime(SDate);
        int i = 0;
        if (Shift == "D")
        {
            Shift = "08:00,20:00,D";
            i = 0;
        }
        else if (Shift == "N")
        {
            Shift = "20:00,08:00,N";
            i = 1;
        }
        else
        {
            Shift = "08:00,08:00,A";
            i = 1;
        }
        DataTable dTable = new DataTable();
        dTable = cData.GetDataFG(Date.ToString("yyyy-MM-dd"), Line, Shift);
        GridView1.DataSource = dTable;
        GridView1.DataBind();

        if (dTable.Rows.Count <= 0)
        {

            dTable = new DataTable();
            dTable.TableName = "dTable";
            dTable.Columns.Add("ModelCode", typeof(String));
            dTable.Columns.Add("Model", typeof(String));
            dTable.Columns.Add("Production_Qty", typeof(String));
            dTable.Columns.Add("Relabel", typeof(String));

            dTable.Columns.Add("Rework", typeof(String));
            dTable.Columns.Add("RWE", typeof(String));
            dTable.Columns.Add("RWD", typeof(String));
            dTable.Columns.Add("RWQ", typeof(String));
            dTable.Columns.Add("PDT", typeof(String));

            dTable.Columns.Add("UWH", typeof(String));

            DataRow workRow = dTable.NewRow();
            workRow["ModelCode"] = "";
            workRow["Model"] = "";
            workRow["Production_Qty"] = "";
            workRow["Relabel"] = "";

            workRow["Rework"] = "";
            workRow["RWE"] = "";
            workRow["RWD"] = "";
            workRow["RWQ"] = "";
            workRow["PDT"] = "";
            workRow["UWH"] = "";
            dTable.Rows.Add(workRow);

            GridView1.DataSource = dTable;
            GridView1.DataBind();
        }


        LoadPlan(Date.ToString("yyyyMMdd"), Line);
        ltrFilter.InnerText = " *** ข้อมูล  Line " + Line + "  ตั้งแต่ " + Date.ToString("yyyy/MM/dd") + " " + Shift.Split(',')[0] + " ถึง " + Date.AddDays(i).ToString("yyyy/MM/dd") + " " + Shift.Split(',')[1] + " *** ";
        lbPlan.InnerText = " *** แผนการผลิต  Line " + Line + "  วันที่ " + Date.ToString("yyyy/MM/dd") + " *** ";
        gvActual.DataSource = cData.getActualLine7("'" + Date.ToString("yyyy-MM-dd") + " " + Shift.Split(',')[0] + "' and '" + Date.AddDays(i).ToString("yyyy-MM-dd") + " " + Shift.Split(',')[1] + "'");
        gvActual.DataBind();
        lbAlpha.InnerText = " *** ข้อมูล  Line " + Line + " *** ";
        gvAlpha.DataSource = cData.loadSerialCountByWCLineModel("PDT", Line);
        gvAlpha.DataBind();

        lbPipe.InnerText = "Actual Main Line7";
    }

    private void LoadDataCustom(string Sdate, string Edate, string Line)
    {
        ClearDataGrid();
        int i = 0;

        DataTable dTable = new DataTable();
        dTable = cData.loadDataCustom(Sdate, Edate, Line);
        GridView1.DataSource = dTable;
        GridView1.DataBind();

        if (dTable.Rows.Count <= 0)
        {

            dTable = new DataTable();
            dTable.TableName = "dTable";
            dTable.Columns.Add("ModelCode", typeof(String));
            dTable.Columns.Add("Model", typeof(String));
            dTable.Columns.Add("Production_Qty", typeof(String));
            dTable.Columns.Add("Relabel", typeof(String));

            dTable.Columns.Add("Rework", typeof(String));
            dTable.Columns.Add("RWE", typeof(String));
            dTable.Columns.Add("RWD", typeof(String));
            dTable.Columns.Add("RWQ", typeof(String));
            dTable.Columns.Add("PDT", typeof(String));

            dTable.Columns.Add("UWH", typeof(String));

            DataRow workRow = dTable.NewRow();
            workRow["ModelCode"] = "";
            workRow["Model"] = "";
            workRow["Production_Qty"] = "";
            workRow["Relabel"] = "";

            workRow["Rework"] = "";
            workRow["RWE"] = "";
            workRow["RWD"] = "";
            workRow["RWQ"] = "";
            workRow["PDT"] = "";
            workRow["UWH"] = "";
            dTable.Rows.Add(workRow);

            GridView1.DataSource = dTable;
            GridView1.DataBind();
        }

        lbAlpha.InnerText = " *** ข้อมูล  Line " + Line + " *** ";
        ltrFilter.InnerText = " *** ข้อมูล  Line " + Line + "  ตั้งแต่ " + Sdate + " ถึง " + Edate + " *** ";

        gvAlpha.DataSource = cData.loadSerialCountByWCLineModel("PDT", "1");
        gvAlpha.DataBind();

        lbPipe.InnerText = "Actual Main Line7";
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=A");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData(txtPrdDate.Text.Replace('/', '-'), ddlLine.SelectedValue, ddlShift.SelectedValue);
        headLink("1");
    }
    protected void btnExportRelabel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=B");
    }
    protected void headLink(string tab)
    {
        HyperLink Link_Production_Qty = null;
        HyperLink Link_Relabel = null;
        HyperLink Link_Rework = null;

        GridViewRow header = GridView1.HeaderRow;

        Link_Production_Qty = header.FindControl("HLProduction_Qty") as HyperLink;
        Link_Relabel = header.FindControl("HLRelabel") as HyperLink;
        Link_Rework = header.FindControl("HLRework") as HyperLink;

        if (tab == "1")
        {
            if (Link_Production_Qty != null)
            {
                Link_Production_Qty.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=A";

            }
            if (Link_Relabel != null)
            {
                Link_Relabel.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=B";

            }
            if (Link_Rework != null)
            {
                Link_Rework.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=C";

            }
        }
        else if (tab == "2")
        {
            if (Link_Production_Qty != null)
            {
                Link_Production_Qty.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtDateC.Text.Replace('/', '_').Trim() + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=I";

            }
            if (Link_Relabel != null)
            {
                Link_Relabel.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtDateC.Text.Replace('/', '_').Trim() + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=J";

            }
            if (Link_Rework != null)
            {
                Link_Rework.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtDateC.Text.Replace('/', '_').Trim() + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=K";

            }
        }

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HyperLink Link_PDT = (HyperLink)e.Row.FindControl("LHPDT");
        HyperLink Link_UWH = (HyperLink)e.Row.FindControl("LHUWH");
        HyperLink Link_RWD = (HyperLink)e.Row.FindControl("LHRWD");
        HyperLink Link_RWE = (HyperLink)e.Row.FindControl("LHRWE");
        HyperLink Link_RWQ = (HyperLink)e.Row.FindControl("LHRWQ");
        if (Link_PDT != null)
        {
            Link_PDT.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=D";

        }
        if (Link_UWH != null)
        {
            Link_UWH.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=E";

        }
        if (Link_RWD != null)
        {
            Link_RWD.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=F";

        }
        if (Link_RWE != null)
        {
            Link_RWE.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=G";

        }
        if (Link_RWQ != null)
        {
            Link_RWQ.NavigateUrl = "ExportExcelFGDatalist.ashx?Date=" + txtPrdDate.Text.Replace('/', '-') + "&Line=" + ddlLine.SelectedValue + "&Shift=" + ddlShift.SelectedValue + "&Btn=H";

        }
    }
    protected void SearchC_Click(object sender, EventArgs e)
    {
        string Sdate = txtDateC.Text.Split('-')[0].Replace("/", "-");
        string Edate = txtDateC.Text.Split('-')[1].Replace("/", "-");
        LoadDataCustom(Sdate, Edate, ddlLine.SelectedValue);
        headLink("2");
    }
}
