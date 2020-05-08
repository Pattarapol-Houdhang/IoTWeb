using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DailyReport : System.Web.UI.Page
{
    string facId;
    string lineId;
    MainDailyReportService mdrSer = new MainDailyReportService();
    string ipAddress;
    string dbName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (((facId = Request.QueryString["FactoryID"]) != null) && ((lineId = Request.QueryString["ld_id"]) != null))
            {
                ViewState["FactoryID"] = Request.QueryString["FactoryID"];

                if (facId == "1")
                {
                    if (lineId == "7")
                    {
                        lblLine.Text = "MECHA LINE 1";
                        ViewState["baseName"] = "ETD_YC";
                        ViewState["baseIP"] = "192.168.226.234";
                    }
                    else if (lineId == "8")
                    {
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = "***COMMING SOON***";
                        lblLine.Text = "MECHA LINE 2";
                        ViewState["baseName"] = "ETD_YC4";
                        ViewState["baseIP"] = "192.168.226.2";
                    }
                }
                else if (facId == "2")
                {
                    if (lineId == "9")
                    {
                        lblLine.Text = "MECHA LINE 3";
                        ViewState["baseName"] = "ETD_2YC";
                        ViewState["baseIP"] = "192.168.229.59";
                    }
                }
                else if (facId == "3")
                {
                    if (lineId == "10")
                    {
                        lblLine.Text = "MACHINE FACTORY 3";
                        ViewState["baseName"] = "ETD_FAC3";
                        ViewState["baseIP"] = "10.194.40.103";
                    }
                }

                ViewState["conStr"] = "Data Source=" + ViewState["baseIP"].ToString() + ";Initial Catalog=" + ViewState["baseName"].ToString() + ";Persist Security Info=True;User ID=sa;Password=decjapan";
            }
			txtDate.Text = (DateTime.Now.Date.ToString("yyyy/MM/dd"));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string startDate = "";
        string endDate = "";
        //serach and set data to gridView
        if (dropDownShift.SelectedValue.ToString() == "DAY")
        {
            startDate = txtDate.Text + " 08:00:00";
            endDate = txtDate.Text + " 20:00:00";
        }
        else
        {
            DateTime bufDate = Convert.ToDateTime(txtDate.Text).AddDays(1);
            startDate = txtDate.Text + " 20:00:00";
            endDate = bufDate.ToString("yyyy/MM/dd") + " 08:00:00";
        }

        lblSearchDateTime.Text = startDate + " To " + endDate;

        gridViewDailyProduce.DataSource = mdrSer.GetDailyProduceModel(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), ViewState["conStr"].ToString());
        gridViewDailyProduce.DataBind();
    }
    protected void gridViewDailyProduce_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "viewReport")
        {
            string reportData = e.CommandArgument.ToString();

            var dataSplit = reportData.Split(',');

            if (dataSplit[2] == "CRANK_SHAFT")
            {
                Response.Redirect("ReportRankCS.aspx?report=" + reportData);
            }
            else if (dataSplit[2] == "PISTON")
            {
                Response.Redirect("ReportRankPT.aspx?report=" + reportData);
            }
            else if (dataSplit[2] == "CYLINDER")
            {
                Response.Redirect("ReportRankCY.aspx?report=" + reportData);
            }
            else if (dataSplit[2] == "FRONT_HEAD")
            {
                Response.Redirect("ReportRankFH.aspx?report=" + reportData);
            }
            else if (dataSplit[2] == "REAR_HEAD")
            {
                Response.Redirect("ReportRankRH.aspx?report=" + reportData);
            }
            
        }
    }
}