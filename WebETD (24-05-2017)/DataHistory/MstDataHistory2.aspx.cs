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
using System.Globalization;

public partial class MstDataHistory2 : System.Web.UI.Page
{
    DataTable dtData = new DataTable();
    DataTable dt = new DataTable();
    F3MechaService meTba = new F3MechaService();
	ConnectDBETD con = new ConnectDBETD();
	 

    bool check;
    private string bufId; 
    //DateTime startDate;
    //DateTime endDate;
	

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userName"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
        if (!IsPostBack)
        {
            if ((bufId = Request.QueryString["FactoryID"]) != null)
            {
                ViewState["FactoryID"] = Request.QueryString["FactoryID"];
                if (bufId == "3")
                {
                    Label1.Text = "Mecha Factory 3";
                    ViewState["baseName"] = "MECHA_FAC3";
                    ViewState["baseIP"] = "10.194.40.103";
                }

                ViewState["conStr"] = "Data Source=" + ViewState["baseIP"].ToString() + ";Initial Catalog=" + ViewState["baseName"].ToString() + ";Persist Security Info=True;User ID=sa;Password=decjapan";
            }

            start.Text = (DateTime.Now.Date + new TimeSpan(8, 0, 0)).ToString("yyyy/MM/dd HH:mm");
            end.Text = (DateTime.Now.Date + new TimeSpan(20, 0, 0)).ToString("yyyy/MM/dd HH:mm");
        }
    }

    private DataTable GetData()
    {
        try
        {
            DataTable getdt = new DataTable();
            if (DropDownListPart.SelectedValue == "1") //CS
            {
                //getdt = meTba.getCSResultF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));

                DataTable dtCS = new DataTable();
                string StrCS = "SELECT [part_serial_no], [date_shift], [model_no], [model_name], [fs_od_rank_val], [fs_od_rank_char], "
                    + " [fs_roundness], [fs_cylindric], [fs_od1], [fs_od2], [fs_od3], [fs_od1_remain], [fs_od2_remain], [fs_od3_remain], "
                    + " [rs_od_rank_val], [rs_od_rank_char], [rs_roundness], [rs_cylindric], [rs_od1], [rs_od2], [rs_od1_remain], [rs_od2_remain], "
                    + " [pin_od_rank_val], [pin_od_rank_char], [pin_roundness], [pin_cylindric], [pin_od1], [pin_od2], [pin_od3], [pin_od1_remain], "
                    + " [pin_od2_remain], [pin_od3_remain], [a_max], [eccentric], [total_judgement], [stamp_time], [cycle_start_time], [cycle_end_time], "
                    + " [production_count], [daily_counter] "
                    + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_crank_shaft_result] "
                    + " WHERE stamp_time between '" + ViewState["DateStart"] + "' and '" + ViewState["DateEnd"] + " '"
                    + " ORDER BY  stamp_time asc ";

                SqlCommand qrCS = new SqlCommand();
                qrCS.CommandText = StrCS;
                dtCS = con.Query(qrCS, ViewState["conStr"].ToString());

                getdt = dtCS;
            }

            else if (DropDownListPart.SelectedValue == "2")//PT
            {
                //getdt = meTba.getPTResultF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));

                DataTable dtPT = new DataTable();
                string StrPT = "SELECT part_serial_no, date_shift, model_no, model_name, id_rank_val, id_rank_char, id_roundness, id_cylindric, id_perpen, id_rank1, id_rank2, od_rank_val, "
                    + " od_rank_char, od_roundness, od_cylindric, od_perpen, od_rank1, od_rank2, bt_rank_val, bt_rank_char, bt_parallism, bs_perpen, bd_perpen, bt_rank1, bt_rank2, "
                    + " bt_rank3, bt_rank4, hi_rank_val, hi_rank_char, parallism_sur, hi_rank1, hi_rank2, hi_rank3, hi_rank4, hi_rank5, b1, b2, b3, b4, b_max_min, total_judgement, "
                    + " stamp_time, cycle_start_time, cycle_end_time, production_count, daily_counter "
                    + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_piston_result] "
                    + " WHERE stamp_time between '" + ViewState["DateStart"] + "' and '" + ViewState["DateEnd"] + " '"
                    + " ORDER BY  stamp_time asc ";

                SqlCommand qrPT = new SqlCommand();
                qrPT.CommandText = StrPT;
                dtPT = con.Query(qrPT, ViewState["conStr"].ToString());

                getdt = dtPT;
            }

            else if (DropDownListPart.SelectedValue == "3")//CY
            {
                //getdt = meTba.getCYResultF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));

                DataTable dtCY = new DataTable();
                string StrCY = "SELECT part_serial_no, date_shift, model_no, model_name, id_bo_rank_val, id_bo_rank_char, id_bo_roundness, id_bo_cylindric, id_bo_concen, id_bo_perpen, "
                    + " id_bo_rank1, id_bo_rank2, id_bu_rank_val, id_bu_rank_char, id_bu_roundness, id_bu_cylindric, id_bu_perpen, id_bu_rank1, id_bu_rank2, hi_rank_val, "
                    + " hi_rank_char, hi_parallism, hi_rank1, hi_rank2, hi_rank3, hi_rank4, hi_rank5, hi_rank6, total_judgement, stamp_time, cycle_start_time, cycle_end_time, "
                    + " production_count, daily_counter "
                    + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_cylinder_result] "
                    + " WHERE stamp_time between '" + ViewState["DateStart"] + "' and '" + ViewState["DateEnd"] + " '"
                    + " ORDER BY  stamp_time asc ";

                SqlCommand qrCY = new SqlCommand();
                qrCY.CommandText = StrCY;
                dtCY = con.Query(qrCY, ViewState["conStr"].ToString());

                getdt = dtCY;
            }

            else if (DropDownListPart.SelectedValue == "4")//FH
            {
                //getdt = meTba.getFHResultF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));

                DataTable dtFH = new DataTable();
                string StrFH = "SELECT [part_serial_no], [date_shift], [model_no], [model_name], [id_rank_val], [id_rank_char], "
                    + " [id_roundness], [id_cylindric], [id_concentric], [id_perpen], [id_rank_val1], [id_rank_val2], [total_judgement], "
                    + " [stamp_time], [cycle_start_time], [cycle_end_time], [production_count], [daily_counter] "
                    + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_front_head_result] "
                    + " WHERE stamp_time between '" + ViewState["DateStart"] + "' and '" + ViewState["DateEnd"] + " '"
                    + " ORDER BY  stamp_time asc ";

                SqlCommand qrFH = new SqlCommand();
                qrFH.CommandText = StrFH;
                dtFH = con.Query(qrFH, ViewState["conStr"].ToString());

                getdt = dtFH;
            }

            else if (DropDownListPart.SelectedValue == "5")//RH
            {
               //getdt = meTba.getRHResultF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));

                DataTable dtRH = new DataTable();
                string StrRH = "SELECT part_serial_no, date_shift, model_no, model_name, id_rank_val, id_rank_char, id_roundness, id_cylindric, id_perpen, total_judgement, stamp_time, "
                    + " cycle_start_time, cycle_end_time, production_count, daily_counter "
                    + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_rear_head_result] "
                    + " WHERE stamp_time between '" + ViewState["DateStart"] + "' and '" + ViewState["DateEnd"] + " '"
                    + " ORDER BY stamp_time asc ";

                SqlCommand qrRH = new SqlCommand();
                qrRH.CommandText = StrRH;
                dtRH = con.Query(qrRH, ViewState["conStr"].ToString());

                getdt = dtRH;
            }

            else if (DropDownListPart.SelectedValue == "6")//MATCHING
            {
                getdt = meTba.getMatchingData(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));
            }

            else if (DropDownListPart.SelectedValue == "7")//Front Head Riveting
            {
                getdt = meTba.getFHRivetingF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));
            }

            else if (DropDownListPart.SelectedValue == "8")//Rear Centering
            {
                getdt = meTba.getRCenteringF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));
            }

            else if (DropDownListPart.SelectedValue == "9")//Cylinder Centering
            {
                getdt = meTba.getCYCenteringF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));
            }

            else if (DropDownListPart.SelectedValue == "10")//Torque Check
            {
                getdt = meTba.getTorqueF3(Convert.ToDateTime(ViewState["DateStart"]), Convert.ToDateTime(ViewState["DateEnd"]));
            }


            //for (int i = 0; i < getdt.Rows.Count; i++)
            //{
            //    getdt.Rows[i]["stamp_time"] = (Convert.ToDateTime(getdt.Rows[i]["stamp_time"])).ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            //}



                return getdt;
        }
        catch
        {
            return null;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //startDate = DateTime.ParseExact(start.Text, "yyyy/MM/dd HH:mm", CultureInfo.CurrentCulture);
            //endDate = DateTime.ParseExact(end.Text, "yyyy/MM/dd HH:mm", CultureInfo.CurrentCulture);

            ViewState["DateStart"] = start.Text;
            ViewState["DateEnd"] = end.Text;
			
			
			lblError.Text =  ViewState["DateStart"].ToString() +", "+ViewState["DateEnd"].ToString();
			
            check = true;
            showData();
			//lblError.Text = getdt.Rows.Count.ToString() +" | "+ ViewState["DateStart"].ToString() +", "+ViewState["DateEnd"].ToString();
			
			
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
            btnExcel.Enabled = true;
            dt = GetData();
			lblError.Text += "\r\n"+dt.Rows.Count.ToString(); 
            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //html.Append("<table class='dataTables table table-bordered stats-tbl-theme' >");

            html.Append("<table class='table data-tbl-boxy'>");

            //Building the Header row.
            html.Append("<thead>");
            ArrayList arrHideColumn = new ArrayList();
			
			if(dt.Rows.Count > 0){
			
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
							html.Append(row[column.ColumnName].ToString());
							html.Append("</td>");
						//}
					}
					html.Append("</tr>");
				}
			
			}

            html.Append("</tbody>");
            //Table end.
            html.Append("</table>");

            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }
        catch
        {
			lblError.Text += "\r\n Error."; 
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
		string Start = ViewState["DateStart"].ToString();
		string End = ViewState["DateEnd"].ToString();
		string Con = ViewState["conStr"].ToString();
        string Base = ViewState["baseName"].ToString();
        Response.Redirect("ExportExcel2.ashx?Part=" + Part + "&Start=" + Start + "&End=" + End + "&Con=" + Con + "&Base=" + Base);
	}


    protected void btBackPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=" + ViewState["FactoryID"].ToString()));
    }
}