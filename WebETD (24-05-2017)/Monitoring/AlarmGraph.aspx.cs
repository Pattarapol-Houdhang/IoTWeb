using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AlarmGraph : System.Web.UI.Page
{
    CGenControl oGenControl = new CGenControl();
    ConnectDBFac3 oCon = new ConnectDBFac3();
    ConnectDBODM oConOdm = new ConnectDBODM();
    string DefaultFac = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialControl();

        }
        DateShow.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
    }

    private void InitialControl()
    {
        DefaultFac = Request.QueryString["DefaultFac"].ToString();
        ddlFac_SelectedIndexChanged(ddlFac,null);
        DateShow.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
        FullDate.Text = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd") + " - " + DateTime.Now.ToString("yyyy/MM/dd");
    }



    private void LoadGraph()
    {
        DateShow.Text = txtPrdDate.Text.Trim().Replace('/', '-');
        FullDate.Text = txtPrdDate.Text.Trim();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DateShow.Text = txtPrdDate.Text.Trim().Replace('/', '-');// +"---" + ddlShift.SelectedValue.ToString() + "---" + ddlLine.SelectedValue.ToString() + "---" + cblMC.SelectedValue.ToString();
        FullDate.Text = txtPrdDate.Text.Trim();
        //MCName.visible = false;

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            string DateStart = "";
            string DateEnd = "";
            string Shift = "";
            string fac = "";


            DateStart = FullDate.Text.Trim().Split('-')[0].Trim();
            DateEnd = FullDate.Text.Trim().Split('-')[1].Trim();
            fac = ddlFac.SelectedValue;
            Shift = ddlShift.SelectedValue;
            string listMC = "'";

            List<ListItem> selected = new List<ListItem>();
            foreach (ListItem item in cblMC.Items){
                    if (item.Selected)
                    {
                        listMC += item.Value.ToString().Replace('&', '%') + "','";
                    }
            }
            listMC += "'";

            if (cblMC.Items.Count <= 0)
            {
                listMC = "All";
            }
            string _Volume = "";
            if (ddlVolume.Visible)
            {
               _Volume = ddlVolume.SelectedItem.ToString();
            }
            else
            {
                _Volume = "1";
            }
            Response.Redirect("ExportExcelAlarmHistory.ashx?DateStart=" + DateStart.Replace('/', '-') + "&DateEnd=" + DateEnd.Replace('/', '-') + "&Shift=" + Shift + "&Range=" + ddlDate.SelectedValue + "&Volume=" + _Volume + "&listMC=" + listMC.Replace('&', '%').Replace(' ', '(') + "&Fac=" + fac + "&LineODM=" + ddlLineODM.SelectedValue);
            //Response.Write("<script>window.open('ExportExcelAlarmHistory.ashx?DateStart=" + DateStart.Replace('/', '-') + "&DateEnd=" + DateEnd.Replace('/', '-') + "&Shift=" + Shift + "&Range=" + ddlDate.SelectedValue + "&Volume=" + _Volume + "&listMC=" + listMC.Replace('&', '_').Replace(' ', '%') + "&Fac=" + fac+"','_blank');</script>");
            //Response.Write("<script>");
            //Response.Write("window.open('ExportExcelAlarmHistory.ashx?DateStart=" + DateStart.Replace('/', '-') + "&DateEnd=" + DateEnd.Replace('/', '-') + "&Shift=" + Shift + "&Range=" + ddlDate.SelectedValue + "&Volume=" + _Volume + "&listMC=" + listMC.Replace('&', '_').Replace(' ', '%') + "&Fac=" + fac + "','_blank')");
            //Response.Write("</script>");
            //Response.AddHeader("Refresh", "3; url=ExportExcelAlarmHistory.ashx?DateStart=" + DateStart.Replace('/', '-') + "&DateEnd=" + DateEnd.Replace('/', '-') + "&Shift=" + Shift + "&Range=" + ddlDate.SelectedValue + "&Volume=" + _Volume + "&listMC=" + listMC.Replace('&', '_').Replace(' ', '%') + "&Fac=" + fac);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlDate.SelectedValue == "D")
        {

            DateShow.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
            FullDate.Text = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd") + " - " + DateTime.Now.ToString("yyyy/MM/dd");
        }
        else if (ddlDate.SelectedValue == "W")
        {

            DateShow.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
            FullDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy/MM/dd") + " - " + DateTime.Now.ToString("yyyy/MM/dd");
        }
        else if (ddlDate.SelectedValue == "M")
        {

            DateShow.Text = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
            FullDate.Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd") + " - " + DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
    protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlDate.SelectedValue == "D")
        {
            ddlVolume.Items.Clear();
            divVolume.Visible = false;
            ddlVolume.Visible = false;
            lbVol.Visible = false;
            //divDate.Visible = true;
            ddlDate.Enabled = true;
            divDate.Visible = true;
            DateShow.Text = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
            FullDate.Text = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd") + " - " + DateTime.Now.ToString("yyyy/MM/dd");
        }
        else if (ddlDate.SelectedValue == "W")
        {
            ddlVolume.Visible = true;
            ddlVolume.Items.Clear();
            divVolume.Visible = true;
            lbVol.Visible = true;
            for (int i = 4; i <= 100; i++)
            {
                ddlVolume.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            //divDate.Visible = false;
            divDate.Visible = false;
            DateShow.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
            FullDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy/MM/dd") + " - " + DateTime.Now.ToString("yyyy/MM/dd");
        }
        else if (ddlDate.SelectedValue == "M")
        {
            ddlVolume.Visible = true;
            ddlVolume.Items.Clear();
            divVolume.Visible = true;
            lbVol.Visible = true;
            for (int i = 12; i <= 120; i++)
            {
                ddlVolume.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            //divDate.Visible = false;
            divDate.Visible = false;
            DateShow.Text = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd") + " - " + DateTime.Now.ToString("yyyy-MM-dd");
            FullDate.Text = DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd") + " - " + DateTime.Now.ToString("yyyy/MM/dd");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        cblMC.Items.Clear();
        if (ddlLine.SelectedValue == "All")
        {
            divMCName.Visible = false;
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
        cblMC.Items.Add(new ListItem("All", "All"));
        cblMC.SelectedIndex = 0;
        foreach (DataRow row in dtable.Rows)
        {
            cblMC.Items.Add(new ListItem(row["MachineName"].ToString(), row["MachineName"].ToString()));
        }
        divMCName.Visible = true;
        cblMC.Visible = true;
        lbMC.Visible = true;


    }
    protected void ddlVolume_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void btnShowDetail_Click(object sender, EventArgs e)
    {
        Response.Redirect("AlarmGraphDetail.aspx?DateStart=" + DateTime.Now.ToString("yyyy-MM-dd 08:00") + "&DateEnd=" + DateTime.Now.ToString("yyyy-MM-dd 20:00") + "&MC=" + "Magnetzing : AMA-0122" + "&Fac=Fac3&shift=All&Line=All&LineODM=IN");
    }
    protected void ddlFac_SelectedIndexChanged(object sender, EventArgs e)
    {
        cblMC.Items.Clear();

        if (DefaultFac == "Fac3")
        {
            ddlFac.SelectedIndex = 0;
        }
        else if (DefaultFac == "ODM" )
        {
            ddlFac.SelectedIndex = 1;
        }
        if (ddlFac.SelectedValue == "All")
        {
            divMCName.Visible = false;
            divLine.Visible = false;
            return;
        }
        else if (ddlFac.SelectedValue == "ODM")
        {
            ddlLineODM.SelectedIndex = 0;
            divlLineODM.Visible = true;
            ddlDate.Enabled = true;
            //divMCName.Visible = true;
            divLine.Visible = false;
            cblMC.Visible = false;
            lbMC.Visible = false;
            divDate.Visible = true;
            /////
            //ddlShift.Enabled = false;
            lbVol.Visible = false; 
            //ddlDate.Enabled = false;
            divDR.Visible = false;
            lbF.Visible = false;
            ddlVolume.Visible = false;
            ddlLineODM_SelectedIndexChanged(ddlLineODM,null);
             
            
        }
        else if (ddlFac.SelectedValue == "Fac3")
        {
            ddlLine.SelectedIndex = 0;
            divlLineODM.Visible = false;
            divDate.Visible = true;
            ddlDate.Enabled = true;
            ddlDate.SelectedIndex = 0;
            divMCName.Visible = true;
            divLine.Visible = true;
            cblMC.Visible = false;
            lbMC.Visible = false;
            ///
            ddlShift.Enabled = true;
            divDR.Visible = true;
            lbF.Visible = true;
        }
       
        
    }
    protected void ddlLineODM_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlDate.Enabled = true;
        divMCName.Visible = true;
        divLine.Visible = false;
        cblMC.Visible = true;
        lbMC.Visible = true;
        divDate.Visible = true;
        /////
        //ddlShift.Enabled = false;
        lbVol.Visible = false;
        //ddlDate.Enabled = false;
        divDR.Visible = false;
        lbF.Visible = false;
        ddlVolume.Visible = false;
        string lineODM = "";
        if (ddlLineODM.SelectedValue == "IN")
        {
            lineODM = "Line_No = '1'";
        }
        else if (ddlLineODM.SelectedValue == "OUT")
        {
            lineODM = "Line_No = '2'";
        }
        else
        {
            lineODM = "Line_No != ''";
        }
        cblMC.Items.Clear();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT [MC_Name],Network_No+Station_No+Location_No as Station FROM [dbIoTFacODM].[dbo].[odm_od_Alarm_mst] where " + lineODM + " order by Station";
        DataTable dtable = new DataTable();
        dtable = oConOdm.Query(sql);
        if (dtable.Rows.Count < 0)
        {
            return;
        }
        cblMC.Items.Add(new ListItem("All", "All"));
        cblMC.SelectedIndex = 0;
        foreach (DataRow row in dtable.Rows)
        {
            cblMC.Items.Add(new ListItem(row["MC_Name"].ToString(), row["Station"].ToString()));
        }
    }
}