using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AlarmGraphDetail : System.Web.UI.Page
{
    ConnectDBFac3 oCon = new ConnectDBFac3();
    ConnectDBODM oConODM = new ConnectDBODM();
    public string DateStart = "";
    public string DateEnd = "";
    public string Shift = "";
    public static string MClist;
    string dtStart = "";
    string dtEnd = "";
    string Part_Name = "";
    string Range = "";
    string Volume = "";
    string MC = "";
    string Line = "";
    string Date = "";
    string Fac = "";
    public string JsonString;
    public string LineODM = "";
    CAlarmHistoryDetail oGetGraph = new CAlarmHistoryDetail();
    public static List<string> PBList = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialControl();
        }
        GridView1.DataSource = new DataTable();
        //DateShow.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
    }
    private void LoadData(string DateStart, string DateEnd,string MC,string Fac,string Shift="")
    {
        
        string sql = "";
        string STime = "";
        string ETime = "";
        DateTime SDate = DateTime.Parse(DateStart);
        DateTime EDate = DateTime.Parse(DateEnd);
        if (Shift == "All")
        {
            STime = "08:00";
            ETime = "08:00";

            DateStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            DateEnd = EDate.AddDays(1).ToString("yyyy-MM-dd") + " " + ETime;

        }
        else if (Shift == "D")
        {
            STime = "08:00";
            ETime = "20:00";

            DateStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            DateEnd = EDate.ToString("yyyy-MM-dd") + " " + ETime;
        }
        else if (Shift == "N")
        {
            STime = "20:00";
            ETime = "08:00";

            DateStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            DateEnd = EDate.ToString("yyyy-MM-dd") + " " + ETime;
        }


        if (Fac == "Fac3")
        {
            sql = @"SELECT ALS.MachineName,AlarmDetail,DateStart
                              FROM [MECHA_FAC3].[dbo].[vi_Alarm_MC_Detail] MCD
                              left join [MECHA_FAC3].[dbo].[AlarmLineSetting] ALS on MCD.MC_No = ALS.ID
                              WHERE DateStart between '" + DateStart + @"' and '" + DateEnd + @"' and ALS.MachineName = '" + MC + @"'
                              ORDER BY DateStart desc";
            DataTable dTable = new DataTable();
            dTable = oCon.Query(sql);
            if (dTable.Rows.Count > 0)
            {
                DataView dView = new DataView();
                dView.Table = dTable;
                GridView1.DataSource = dView;
                GridView1.DataBind();
            }
        }
        else if (Fac == "ODM")
        {
            sql = @"SELECT [MC_Name] as MachineName
                                ,[AlarmDetail]
                                ,DateInsert as DateStart
                            FROM [dbIoTFacODM].[dbo].[vi_ODM_OD_Alarm]
                            where DateInsert between '" + DateStart + @"' and '" + DateEnd + @"' and MC_Name = '" + MC + @"'
                            order by DateInsert desc";
            DataTable dTable = new DataTable();
            dTable = oConODM.Query(sql);
            if (dTable.Rows.Count > 0)
            {
                DataView dView = new DataView();
                dView.Table = dTable;
                GridView1.DataSource = dView;
                GridView1.DataBind();
            }
        }
        

    }
    private void InitialControl()
    {
        try
        {

        MClist = Request.QueryString["MC"].ToString().Replace('_', '&');
        MClist = MClist.Replace('%', ' ');
        if (MClist == "")
        {
            MClist = "";
        }

        string dtStart = "";
        string dtEnd = "";
        dtStart = Request.QueryString["DateStart"].ToString();
        dtEnd = Request.QueryString["DateEnd"].ToString();
        Fac = Request.QueryString["Fac"].ToString();
        Shift = Request.QueryString["Shift"].ToString();
        MC = Request.QueryString["MC"].ToString();
        MC = MC.Replace('%', ' ').Replace('@', '&');
        Line = Request.QueryString["Line"].ToString().Replace('_', '&').Replace('%', ' ');
        LineODM = Request.QueryString["LineODM"].ToString();
        if (LineODM == "IN")
        {
            LineODM = "1";
        }
        else if (LineODM == "OUT")
        {
           LineODM = "2";
        }
        else
        {
            LineODM = "0";
        }
        if (MC == "")
        {
            MC = "";
        }
        if (Fac == "Fac3")
        {
            divLineODM.Visible = false;
            ddlFac.SelectedIndex = 1;
            ddlFac_SelectedIndexChanged(ddlFac.SelectedValue, null);
            if (Line == "All")
            {
                try
                {
                    ddlLine.ClearSelection();
                    ddlLine.Items.FindByValue("Main Assembly Line 6").Selected = true;

                    DropDownList1_SelectedIndexChanged(ddlLine.SelectedValue, null);
                    ddlMC.ClearSelection();
                    ddlMC.Items.FindByValue(MC).Selected = true;
                    ddlMC.Visible = true;
                    divMCName.Visible = true;
                }
                catch (Exception ex)
                {

                    ddlLine.ClearSelection();
                    ddlLine.Items.FindByValue("Mecha Line 6").Selected = true;

                    DropDownList1_SelectedIndexChanged(ddlLine.SelectedValue, null);
                    ddlMC.ClearSelection();
                    ddlMC.Items.FindByValue(MC).Selected = true;
                    ddlMC.Visible = true;
                    divMCName.Visible = true;
                }
            }
            else
            {

                ddlLine.ClearSelection();
                ddlLine.Items.FindByValue(Line).Selected = true;

                DropDownList1_SelectedIndexChanged(ddlLine.SelectedValue, null);
                ddlMC.ClearSelection();
                ddlMC.Items.FindByValue(MC).Selected = true;
                ddlMC.Visible = true;
                divMCName.Visible = true;
            }

            
        }
        else if (Fac== "ODM")
        {
            divLineODM.Visible = true;
            ddlFac.SelectedIndex = 2;
            ddlFac_SelectedIndexChanged(ddlFac, null);
            if (LineODM == "1")
            {
                ddlLineODM.SelectedIndex = 0;
            }
            else if (LineODM == "2")
            {
                ddlLineODM.SelectedIndex = 1;
            }
            ddlLineODM_SelectedIndexChanged(ddlLineODM, null);
            ddlMC.ClearSelection();
            ddlMC.Items.FindByValue(MC).Selected = true;
            ddlMC.Visible = true;
            divMCName.Visible = true;
            
        }


        LoadDataG(dtStart, dtEnd, MC, Fac);
        LoadData(dtStart, dtEnd, MC, Fac, Shift);
        Console.Write(dtStart);

        string STime = "";
        string ETime = "";
        DateTime SDate = DateTime.Parse(dtStart);
        DateTime EDate = DateTime.Parse(dtEnd);
        if (Shift == "All")
        {
            STime = "08:00";
            ETime = "08:00";

            dtStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            dtEnd = EDate.AddDays(1).ToString("yyyy-MM-dd") + " " + ETime;

        }
        else if (Shift == "D")
        {
            STime = "08:00";
            ETime = "20:00";

            dtStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            dtEnd = EDate.ToString("yyyy-MM-dd") + " " + ETime;
        }
        else if (Shift == "N")
        {
            STime = "20:00";
            ETime = "08:00";

            dtStart = SDate.ToString("yyyy-MM-dd") + " " + STime;
            dtEnd = EDate.ToString("yyyy-MM-dd") + " " + ETime;
        }

        DateShow.Text = dtStart + " - " + dtEnd;
        FullDate.Text = dtStart.Replace('-', '/') + " - " + dtEnd.Replace('-', '/');

        }
        catch (Exception ex)
        {
        }
    }
    private void LoadDataG(string DateStart, string DateEnd,string MC,string Fac)
    {
        MDAlarmHistoryDetail oMD = new MDAlarmHistoryDetail();
        oMD = oGetGraph.GetAlarmHistoryGraphDetail(DateStart, DateEnd, MC, Fac, Shift);
        if (oMD.ListOfAlarm.Count > 0)
        {
            JsonString = GenSJson(oMD);
            LoadData(DateStart, DateEnd, MC,Fac,Shift);
        }
    }
    private string GenSJson(MDAlarmHistoryDetail oMD)
    {
        PBList.Clear();
        string myJsonString = "[{ name:'" + oMD.ListOfAlarm[0].MCName.ToString() + "',data:[";
        foreach (MDAlarmHistoryDetail.CMDAlarmHistoryDetail oCMD in oMD.ListOfAlarm)
        {
            PBList.Add("'" + oCMD.AlarmDetail + "'");
            myJsonString += oCMD.Qty + ",";


        }
        myJsonString += "]}]";

        return myJsonString;
    }
    protected string getListPB
    {
        get
        {
            return string.Format("[{0}]", string.Join(",", PBList));
        }
    }


    private void LoadGraph()
    {
        DateShow.Text = txtPrdDate.Text.Trim().Replace('/', '-');
        FullDate.Text = txtPrdDate.Text.Trim();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = new DataTable();
        GridView1.DataBind();
        //loader2.Visible = true;
        Shift = "";
        MC = Request.QueryString["MC"].ToString();
        LoadDataG(txtPrdDate.Text.Trim().Split('-')[0].Replace('/', '-'), txtPrdDate.Text.Trim().Split('-')[1].Replace('/', '-'), ddlMC.SelectedValue, ddlFac.SelectedValue);
        LoadData(txtPrdDate.Text.Trim().Split('-')[0].Replace('/', '-'), txtPrdDate.Text.Trim().Split('-')[1].Replace('/', '-'), ddlMC.SelectedValue, ddlFac.SelectedValue);
        DateShow.Text = txtPrdDate.Text.Trim().Replace('/', '-');// +"---" + ddlShift.SelectedValue.ToString() + "---" + ddlLine.SelectedValue.ToString() + "---" + cblMC.SelectedValue.ToString();
        FullDate.Text = txtPrdDate.Text.Trim();
        //MCName.visible = false;
        //loader2.Visible = false;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {



            DateStart = FullDate.Text.Trim().Split('-')[0].Trim();
            DateEnd = FullDate.Text.Trim().Split('-')[1].Trim();


            Response.Redirect("ExportExcelAlarmHistoryDetail.ashx?DateStart=" + DateStart.Replace('/', '-') + "&DateEnd=" + DateEnd.Replace('/', '-') + "&listMC=" + ddlMC.SelectedValue.ToString().Replace('&', '%').Replace(' ', '(') + "&Fac=" + ddlFac.SelectedValue);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = new DataTable();
        GridView1.DataBind();
        ddlMC.Items.Clear();
        if (ddlLine.SelectedValue == "-")
        {
            divMCName.Visible = false;
            ddlMC.Visible = false;
            lbMC.Visible = false;
            return;
        }
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT [LineName],[MachineName],[Remark] FROM [MECHA_FAC3].[dbo].[AlarmLineSetting] WHERE LineName = @line order by MachineName";
        sql.Parameters.Add(new SqlParameter("@line", ddlLine.SelectedValue));
        DataTable dtable = new DataTable();
        dtable = oCon.Query(sql);
        if (dtable.Rows.Count < 0)
        {
            return;
        }
        ddlMC.Items.Add(new ListItem("-", "-"));
        foreach (DataRow row in dtable.Rows)
        {
            ddlMC.Items.Add(new ListItem(row["MachineName"].ToString(), row["MachineName"].ToString()));
        }
        divMCName.Visible = true;
        ddlMC.Visible = true;
        lbMC.Visible = true;


    }
    protected void ddlVolume_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadDataG(FullDate.Text.Trim().Split('-')[0].Replace('/', '-'), FullDate.Text.Trim().Split('-')[1].Replace('/', '-'), ddlMC.SelectedValue,ddlFac.SelectedValue);
        LoadData(FullDate.Text.Trim().Split('-')[0].Replace('/', '-'), FullDate.Text.Trim().Split('-')[1].Replace('/', '-'), ddlMC.SelectedValue, ddlFac.SelectedValue, Shift);
        ///////
    }
    protected void btnExportG_Click(object sender, EventArgs e)
    {
        try
        {
            DateStart = FullDate.Text.Trim().Split('-')[0].Trim();
            DateEnd = FullDate.Text.Trim().Split('-')[1].Trim();


            Response.Redirect("ExportExcelAlarmHistoryDetailG.ashx?DateStart=" + DateStart.Replace('/', '-') + "&DateEnd=" + DateEnd.Replace('/', '-') + "&listMC=" + ddlMC.SelectedValue.Replace('&', '%').Replace(' ', '(') + "&Fac=" + ddlFac.SelectedValue);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }
    protected void ddlFac_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        if (ddlFac.SelectedValue =="Fac3")
        {
            divLineODM.Visible = false;
            ddlLine.SelectedIndex = 0;
            divLineMC.Visible = true;
            divMCName.Visible = false;
            ddlMC.Visible = false;
            lbMC.Visible = false;
            DropDownList1_SelectedIndexChanged(ddlFac.SelectedValue,null);
        }
        else if (ddlFac.SelectedValue =="ODM")
        {
            ddlMC.Items.Clear();
            lbMC.Visible = false;
            divMCName.Visible = false;
            divLineODM.Visible = true;
            divLineMC.Visible = false;
            ddlLineODM_SelectedIndexChanged(ddlLineODM,null);
        }
    }
    protected void btnMain_Click(object sender, EventArgs e)
    {
        Response.Redirect("AlarmGraph.aspx?DefaultFac=Fac3");
       
    }

    protected void ddlLineODM_SelectedIndexChanged(object sender, EventArgs e)
    {

        GridView1.DataSource = null;
        GridView1.DataBind();
        string strLine = "";
        if (ddlLineODM.SelectedValue == "IN")
        {
            strLine = "Line_No = '1'";
        }
        else if (ddlLineODM.SelectedValue == "OUT")
        {
            strLine = "Line_No = '2'";
        }
        else
        {
            strLine = "Line_No != ''";
        }
        divLineMC.Visible = false;
        ddlMC.Items.Clear();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT TOP (1000) [ID],[Station_No],[MC_Name] as MachineName FROM [dbIoTFacODM].[dbo].[odm_od_Alarm_mst] where " + strLine + " order by MC_Name";
        DataTable dtable = new DataTable();
        dtable = oConODM.Query(sql);
        if (dtable.Rows.Count < 0)
        {
            return;
        }
        ddlMC.Items.Add(new ListItem("-", "-"));
        foreach (DataRow row in dtable.Rows)
        {
            ddlMC.Items.Add(new ListItem(row["MachineName"].ToString(), row["MachineName"].ToString()));
        }
        divMCName.Visible = true;
        ddlMC.Visible = true;
        lbMC.Visible = true;
    }
}