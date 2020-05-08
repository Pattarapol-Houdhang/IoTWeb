using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using OfficeExcel = Microsoft.Office.Interop.Excel;

public partial class MstDataHistory : System.Web.UI.Page
{
    ViDataCSDetail csTba = new ViDataCSDetail();
    ViDataCYDetail cyTba = new ViDataCYDetail();
    ViDataPTDetail ptTba = new ViDataPTDetail();
    ViDataFHDetail fhTba = new ViDataFHDetail();
    ViDataRHDetail rhTba = new ViDataRHDetail();

    DataTable dtData = new DataTable();
    DataTable dt = new DataTable();
	
    
    bool check;
    string facId;
    string lineId;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnExcel.Enabled = true;

        //if (Session["userName"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        if (!IsPostBack)
        {
            if (((facId = Request.QueryString["FactoryID"]) != null) && ((lineId = Request.QueryString["ld_id"]) != null))
            {
                ViewState["FactoryID"] = Request.QueryString["FactoryID"];

                if (facId == "1")
                {
                    if (lineId == "12")
                    {
                        Label1.Text = "Mecha Factory 1 (Line1)";
                        ViewState["baseName"] = "ETD_YC";
                        ViewState["baseIP"] = "192.168.226.234";
                        ViewState["Line"] = "line1";
                    }
                    else if (lineId == "13")
                    {
                        Label1.Text = "Mecha Factory 1 (Line2)";
                        Label2.ForeColor = System.Drawing.Color.Red;
                        Label2.Text = "***COMMING SOON***";
                        ViewState["baseName"] = "ETD_YC4";
                        ViewState["baseIP"] = "192.168.226.2";
                        ViewState["Line"] = "line2";
                    }
                }
                else if (facId == "2")
                {
                    if (lineId == "14")
                    {
                        Label1.Text = "Mecha Factory 2 (Line3)";
                        ViewState["baseName"] = "ETD_2YC";
                        ViewState["baseIP"] = "192.168.229.59";
                        ViewState["Line"] = "line3";
                    }
                }
                else if (facId == "3")
                {
                    if (lineId == "15")
                    {
                        Label1.Text = "Machine Factory 3";
                        ViewState["baseName"] = "ETD_FAC3";
                        ViewState["baseIP"] = "10.194.40.103";
                        ViewState["Line"] = "fac3";
                    }
                }

                ViewState["conStr"] = "Data Source=" + ViewState["baseIP"].ToString() + ";Initial Catalog=" + ViewState["baseName"].ToString() + ";Persist Security Info=True;User ID=sa;Password=decjapan";
            }

            start.Text = (DateTime.Now.Date + new TimeSpan(8, 0, 0)).ToString("yyyy/MM/dd HH:mm");
            end.Text = (DateTime.Now.Date + new TimeSpan(20, 0, 0)).ToString("yyyy/MM/dd HH:mm");
        }
      
    }

    private DataTable GetData()
    {
        DataTable getdt = new DataTable();
        if (DropDownListPart.SelectedValue == "1") //CS
        {
            //dt = csTba.getAllDataCS();
            switch (DropDownListType.SelectedValue.ToString())
            {
                case "2"://front od
                    ViewState["PartType"] = "CS-FOD";
                    getdt = csTba.getDataFOD(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "3"://rear od
                    ViewState["PartType"] = "CS-ROD";
                    getdt = csTba.getDataROD(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;//pin od
                case "4":
                    ViewState["PartType"] = "CS-PIN";
                    getdt = csTba.getDataPinOD(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString(), ViewState["Line"].ToString());
                    break;
                case "12"://ecc
                    ViewState["PartType"] = "CS-ECC";
                    getdt = csTba.getDataECC(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString(), ViewState["Line"].ToString());
                    break;
                case "35"://all
                    ViewState["PartType"] = "CS-ALL";
                    getdt = csTba.getAllDataCS(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString(), ViewState["Line"].ToString());
                    break;

            }

        }


        else if (DropDownListPart.SelectedValue == "2") //PT
        {
            switch (DropDownListType.SelectedValue.ToString())
            {
                case "1": //od
                    ViewState["PartType"] = "PT-OD";
                    getdt = ptTba.getDataOD(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "5": //id
                    ViewState["PartType"] = "PT-ID";
                    getdt = ptTba.getDataID(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "10": //height
                    ViewState["PartType"] = "PT-HEIGHT";
                    getdt = ptTba.getDataHeight(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "15": //blade
                    ViewState["PartType"] = "PT-BLADE";
                    getdt = ptTba.getDataBlade(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "35": //all
                    ViewState["PartType"] = "PT-ALL";
                    getdt = ptTba.getAllDataPT(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;

            }
        }
        else if (DropDownListPart.SelectedValue == "3")//CY
        {
            switch (DropDownListType.SelectedValue.ToString())
            {
                case "8": //idbore
                    ViewState["PartType"] = "CY-IDBORE";
                    getdt = cyTba.getDataIDBore(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "9": //idbush
                    ViewState["PartType"] = "CY-IDBUSH";
                    getdt = cyTba.getDataIDBush(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "10": //height
                    ViewState["PartType"] = "CY-HEIGHT";
                    getdt = cyTba.getDataHeight(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "35": //all
                    ViewState["PartType"] = "CY-ALL";
                    getdt = cyTba.getAllDataCY(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
            }
        }
        else if (DropDownListPart.SelectedValue == "4")//FH
        {
            switch (DropDownListType.SelectedValue.ToString())
            {
                case "5": //id
                    ViewState["PartType"] = "FH-ID";
                    getdt = fhTba.getDataID(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString(), ViewState["Line"].ToString());
                    break;
                case "51": //id rough

                    break;
                case "35": //all
                    ViewState["PartType"] = "FH-ALL";
                    getdt = fhTba.getAllDataFH(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString(), ViewState["Line"].ToString());
                    break;
                case "55": //fl
                    ViewState["PartType"] = "FH-FLATNESS";
                    getdt = fhTba.getDataFL(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
            }
        }
        else if (DropDownListPart.SelectedValue == "5")//RH
        {
            switch (DropDownListType.SelectedValue.ToString())
            {
                case "5": //id
                    ViewState["PartType"] = "RH-ID";
                    getdt = rhTba.getDataID(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "35": //all
                    ViewState["PartType"] = "RH-ALL";
                    getdt = rhTba.getAllDataRH(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
                case "55": //fl
                    ViewState["PartType"] = "RH-FLATNESS";
                    getdt = rhTba.getDataFL(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]), ViewState["conStr"].ToString());
                    break;
            }
        }
        return getdt;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["DateStart"] = start.Text;
            ViewState["DateEnd"] = end.Text;

            check = true;
            showData();
            //System.Threading.Thread.Sleep(1000);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't search data, please chack datetimes select again.')", true);
        }
    }

    private void showData()
    {

        try
        {

            //Populating a DataTable from database.
            //btnExcel.Enabled = true;
            dt = GetData();

            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //html.Append("<table class='dataTables table table-bordered stats-tbl-theme' >");

            html.Append("<table class='table data-tbl-boxy'>");

            //Building the Header row.
            html.Append("<thead>");
            ArrayList arrHideColumn = new ArrayList();

            foreach (DataRow row in dt.Rows)
            {
                if (check)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        //if (row[column.ColumnName].ToString() != "")
                        //{
                            html.Append("<th>");
                            html.Append(column.ColumnName);
                            html.Append("</th>");
                        //}
                        //else
                        //{
                        //    arrHideColumn.Add(column.ColumnName);
                        //}
                    }

                    html.Append("</tr>");
                    html.Append("</thead>");
                    html.Append("<tbody>");
                    check = false;
                }

                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    //if (!(arrHideColumn.Contains(column.ColumnName)))
                    //{
                        html.Append("<td>");
                        if (row[column.ColumnName].ToString() != "-999" && row[column.ColumnName].ToString() != "")
                        {
                            html.Append(row[column.ColumnName].ToString());
                        }
                        else
                        {
                            html.Append("-");
                        }
                        html.Append("</td>");
                    //}

                }
                html.Append("</tr>");
            }

            html.Append("</tbody>");
            //Table end.
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }
        catch
        {

        }
    }
    
    private string changeStrTime(string strSplit)
    {
        string[] splitTime = strSplit.Split(':');
        strSplit = "";
        string lastWord = splitTime[splitTime.Count() - 1];
        foreach (string word in splitTime)
        {
            if (word != lastWord)
            {
                strSplit = strSplit + word + ".";
            }
            else
            {
                strSplit += word;
            }
        }

        string[] splitTime2 = strSplit.Split('/');
        strSplit = "";
        string lastWord2 = splitTime2[splitTime2.Count() - 1];
        foreach (string word in splitTime2)
        {
            if (word != lastWord2)
            {
                strSplit = strSplit + word + "-";
            }
            else
            {
                strSplit += word;
            }
        }

        return strSplit;
    }        

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            ViewState["DateStart"] = start.Text;
            ViewState["DateEnd"] = end.Text;
            getExcel();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }

    private void getExcel()
    {
        string Part = DropDownListPart.SelectedValue.ToString();
        string Type = DropDownListType.SelectedValue.ToString();
        string Start = ViewState["DateStart"].ToString();
        string End = ViewState["DateEnd"].ToString();
        string Con = ViewState["conStr"].ToString();
        string Line = ViewState["Line"].ToString();
        Response.Redirect("ExportExcel.ashx?Part=" + Part + "&Type=" + Type + "&Start=" + Start + "&End=" + End + "&Con=" + Con + "&Line=" + Line);
    }


    protected void btBackPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=" + ViewState["FactoryID"].ToString()));
    }
}