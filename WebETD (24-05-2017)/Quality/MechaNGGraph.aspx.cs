using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_QCSamplingGraphCS : System.Web.UI.Page
{
    CGenControl oGenControl = new CGenControl();
    CQCSamplingGraph oQCGraph = new CQCSamplingGraph();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialControl();
        }
        DateShow.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 08:00 - " + DateTime.Now.ToString("yyyy-MM-dd") + " 20:00";
    }

    private void InitialControl()
    {
        DateShow.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 08:00 - " + DateTime.Now.ToString("yyyy-MM-dd") + " 20:00";
        FullDate.Text = DateTime.Now.ToString("yyyy/MM/dd") + " 08:00 - " + DateTime.Now.ToString("yyyy/MM/dd") + " 20:00";
    }



    private void LoadGraph()
    {
        DateShow.Text = txtPrdDate.Text.Trim().Replace('/', '-');
        FullDate.Text = txtPrdDate.Text.Trim();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DateShow.Text = txtPrdDate.Text.Trim().Replace('/', '-');
        FullDate.Text = txtPrdDate.Text.Trim();

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            string DateStart = "";
            string DateEnd = "";
            string Part_Name = "";


            DateStart = FullDate.Text.Trim().Split('-')[0].Trim();
            DateEnd = FullDate.Text.Trim().Split('-')[1].Trim();

            Part_Name = ddlMainPoint.SelectedValue;

            Response.Redirect("ExportExcelMechaNG.ashx?DateStart=" + DateStart.Replace('/', '-') + "&DateEnd=" + DateEnd.Replace('/', '-') + "&Part_Name=" + Part_Name);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }
}