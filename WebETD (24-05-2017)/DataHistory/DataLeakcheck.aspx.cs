using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataHistory_DataLeakcheck : System.Web.UI.Page
{
    ViDataCSDetail csTba = new ViDataCSDetail();
    ViDataCYDetail cyTba = new ViDataCYDetail();
    ViDataPTDetail ptTba = new ViDataPTDetail();
    ViDataFHDetail fhTba = new ViDataFHDetail();
    ViDataRHDetail rhTba = new ViDataRHDetail();

    DataTable dtData = new DataTable();
    DataTable dt = new DataTable();

    ConnectDBETD con = new ConnectDBETD();


    bool check;
    string facId;
    string lineId;

    protected void Page_Load(object sender, EventArgs e)
    {
        //btnExcel.Enabled = true;

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
                    if (lineId == "17")
                    {
                        Label1.Text = "Common Line 1";
                        ViewState["baseName"] = "dbIoTFac2";
                        ViewState["baseIP"] = "costy";
                        ViewState["Line"] = "line1";
                        ViewState["LineNo"] = "1";
                    }
                }
                else if (facId == "2")
                {
                    if (lineId == "18")
                    {
                        Label1.Text = "Common Line 3";
                        ViewState["baseName"] = "dbIoTFac2";
                        ViewState["baseIP"] = "costy";
                        ViewState["Line"] = "line3";
                        ViewState["LineNo"] = "3";
                    }
                    else if (lineId == "19")
                    {
                        Label1.Text = "Common Line 5";
                        ViewState["baseName"] = "dbIoTFac2";
                        ViewState["baseIP"] = "costy";
                        ViewState["Line"] = "line5";
                        ViewState["LineNo"] = "5";
                    }
                }
                else if (facId == "3")
                {
                    if (lineId == "20")
                    {
                        Label1.Text = "Common Line 6";
                        ViewState["baseName"] = "dbIoTFac2";
                        ViewState["baseIP"] = "costy";
                        ViewState["Line"] = "line6";
                        ViewState["LineNo"] = "6";
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
        if (DropDownListPart.SelectedValue == "1")
        {            
                DataTable dt1 = new DataTable();
                string Str1 = "SELECT  SerialNo, StampTime, ID, emp_ID, Name, Line "
                    + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_Leak_Check] "
                    + " WHERE StampTime between '" + ViewState["DateStart"] + "' and '" + ViewState["DateEnd"] + "' and Line = '" + ViewState["LineNo"] + "' "
                    + " ORDER BY  StampTime asc ";

                SqlCommand qr1 = new SqlCommand();
                qr1.CommandText = Str1;
                dt1 = con.Query(qr1, ViewState["conStr"].ToString());
                getdt = dt1;
        }
        else if (DropDownListPart.SelectedValue == "2") 
        {
            DataTable dt2 = new DataTable();
            string Str2 = "SELECT  serial_no, rework_line, point_leak, top_view_position, side_view_position, ng_description, insert_time, rework_emp, bazzing_emp, line_out, status_record "
                + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_leak_rework] "
                + " WHERE insert_time between '" + ViewState["DateStart"] + "' and '" + ViewState["DateEnd"] + "' and rework_line = '" + ViewState["LineNo"] + "' "
                + " ORDER BY  insert_time asc ";

            SqlCommand qr2 = new SqlCommand();
            qr2.CommandText = Str2;
            dt2 = con.Query(qr2, ViewState["conStr"].ToString());

            getdt = dt2;
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
			
			if (dt.Rows.Count != 0)
			{

				//Building an HTML string.
				StringBuilder html = new StringBuilder();

				//Table start.
				//html.Append("<table class='dataTables table table-bordered stats-tbl-theme' >");

				html.Append("<table id='dataItem' class='table data-tbl-boxy display' style='width: 100%'>");

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

    //protected void btnExcel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //       ViewState["DateStart"] = start.Text;
    //        ViewState["DateEnd"] = end.Text;
    //        getExcel();
    //    }
    //    catch
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
    //    }
    //}

    //private void getExcel()
    //{
    //    string Part = DropDownListPart.SelectedValue.ToString();
    //    string Start = ViewState["DateStart"].ToString();
    //    string End = ViewState["DateEnd"].ToString();
    //    string Con = ViewState["conStr"].ToString();
    //    string Line = ViewState["LineNo"].ToString();
    //    string Base = ViewState["baseName"].ToString();
    //    Response.Redirect("ExportExcelLeakcheck.ashx?Part=" + Part + "&Start=" + Start + "&End=" + End + "&Con=" + Con + "&Base=" + Base + "&Line=" + Line);
    //}


    protected void btBackPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=" + ViewState["FactoryID"].ToString()));
    }
}