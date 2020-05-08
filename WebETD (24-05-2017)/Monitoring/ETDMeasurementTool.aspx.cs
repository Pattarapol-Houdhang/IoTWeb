using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Monitoring_ETDMeasurementTool_html : System.Web.UI.Page
{
    ConnectDBETD con = new ConnectDBETD();

    string facId;
    string lineId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (((facId = Request.QueryString["FactoryID"]) != null) && ((lineId = Request.QueryString["ld_id"]) != null))
            {
                ViewState["FactoryID"] = Request.QueryString["FactoryID"];

                if (facId == "1")
                {
                    if (lineId == "1")
                    {
                        lblLine.Text = "MECHA LINE 1";
                        ViewState["baseName"] = "ETD_YC";
                        ViewState["baseIP"] = "192.168.226.234";
                    }
                    else if (lineId == "2")
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
                    if (lineId == "3")
                    {
                        lblLine.Text = "MECHA LINE 3";
                        ViewState["baseName"] = "ETD_2YC";
                        ViewState["baseIP"] = "192.168.229.59";
                    }
                }
                else if (facId == "3")
                {
                    if (lineId == "4")
                    {
                        lblLine.Text = "MACHINE FACTORY 3";
                        ViewState["baseName"] = "ETD_FAC3";
                        ViewState["baseIP"] = "10.194.40.103";
                    }
                }

                ViewState["conStr"] = "Data Source=" + ViewState["baseIP"].ToString() + ";Initial Catalog=" + ViewState["baseName"].ToString() + ";Persist Security Info=True;User ID=sa;Password=decjapan";
            }
            //txtDate.Text = (DateTime.Now.Date.ToString("yyyy/MM/dd"));
            start.Text = (DateTime.Now.Date + new TimeSpan(8, 0, 0)).ToString("yyyy/MM/dd HH:mm");
            end.Text = (DateTime.Now.Date + new TimeSpan(20, 0, 0)).ToString("yyyy/MM/dd HH:mm");
			
			ActCS(start.Text, end.Text);
            ActCY(start.Text, end.Text);
            ActPT(start.Text, end.Text);
            ActFH(start.Text, end.Text);
            ActRH(start.Text, end.Text);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string startDate = start.Text;
        string endDate = end.Text;
        //serach and set data to gridView
        //if (dropDownShift.SelectedValue.ToString() == "DAY")
        //{
        //    startDate = txtDate.Text + " 08:00:00";
        //    endDate = txtDate.Text + " 20:00:00";
        //}
        //else
        //{
        //    DateTime bufDate = Convert.ToDateTime(txtDate.Text).AddDays(1);
        //    startDate = txtDate.Text + " 20:00:00";
        //    endDate = bufDate.ToString("yyyy-MM-dd") + " 08:00:00";
        //}

        ActCS(startDate, endDate);
        ActCY(startDate, endDate);
        ActPT(startDate, endDate);
        ActFH(startDate, endDate);
        ActRH(startDate, endDate);
    }

    private void ActCS(string start, string end)
    {

        DataTable dtCS = new DataTable();
        int totel = 0;
        string StrCS = "SELECT [cs_judgement] ,count([cs_judgement]) "
            + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_act_cs] "
            + " WHERE cs_date between '" + start + "' and '" + end + "' "
            + " and (((cs_line = 'CS_PE_FAC3' or cs_line = 'CS_DONT_MM') and cs_judgement = 'OK') or cs_judgement = 'NG') "
            + " group by [cs_judgement] ";

        SqlCommand qrCS = new SqlCommand();
        qrCS.CommandText = StrCS;
        //qrCS.CommandTimeout = 0;
        dtCS = con.Query(qrCS, ViewState["conStr"].ToString());
        
        if (dtCS.Rows.Count > 0)
        {
            if (dtCS.Rows[0][0].ToString() == "NG")
            {
                lbCSNG.Text = dtCS.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtCS.Rows[0][1]);
            }
            else
            {
                lbCSNG.Text = "0";
            }
            if (dtCS.Rows[0][0].ToString() == "OK")
            {
                lbCSOK.Text = dtCS.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtCS.Rows[0][1]);
            }
            else if (dtCS.Rows[1][0].ToString() == "OK" && dtCS.Rows.Count > 1)
            {
                lbCSOK.Text = dtCS.Rows[1][1].ToString();
                totel = totel + Convert.ToInt16(dtCS.Rows[1][1]);
            }
            else
            {
                lbCSOK.Text = "0";
            }

            lbCSQty.Text = totel.ToString();
        }
    }

    private void ActCY(string start, string end)
    {
        DataTable dtCY = new DataTable();
        int totel = 0;
        string StrCY = "SELECT [cy_judgement] ,count([cy_judgement]) "
            + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_act_cy] "
            + " WHERE cy_date between '" + start + "' and '" + end + "' "
            + " and ((cy_line = 'CY_HEI_FAC3' and cy_judgement = 'OK') or cy_judgement = 'NG') "
            + " group by [cy_judgement] ";

        SqlCommand qrCY = new SqlCommand();
        qrCY.CommandText = StrCY;
        //qrCS.CommandTimeout = 0;
        dtCY = con.Query(qrCY, ViewState["conStr"].ToString());

        if (dtCY.Rows.Count > 0)
        {
            if (dtCY.Rows[0][0].ToString() == "NG")
            {
                lbCYNG.Text = dtCY.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtCY.Rows[0][1]);
            }
            else
            {
                lbCYNG.Text = "0";
            }
            if (dtCY.Rows[0][0].ToString() == "OK")
            {
                lbCYOK.Text = dtCY.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtCY.Rows[0][1]);
            }
            else if (dtCY.Rows[1][0].ToString() == "OK" && dtCY.Rows.Count > 1)
            {
                lbCYOK.Text = dtCY.Rows[1][1].ToString();
                totel = totel + Convert.ToInt16(dtCY.Rows[1][1]);
            }
            else
            {
                lbCYOK.Text = "0";
            }

            lbCYQty.Text = totel.ToString();
        }
    }

    private void ActPT(string start, string end)
    {
        DataTable dtPT = new DataTable();
        int totel = 0;
        string StrPT = "SELECT [pt_judgement] ,count([pt_judgement]) "
            + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_act_pt] "
            + " WHERE pt_date between '" + start + "' and '" + end + "' "
            + " and ((pt_line = 'PT_HEI_FAC3' and pt_judgement = 'OK') or pt_judgement = 'NG') "
            + " group by [pt_judgement] ";

        SqlCommand qrPT = new SqlCommand();
        qrPT.CommandText = StrPT;
        //qrCS.CommandTimeout = 0;
        dtPT = con.Query(qrPT, ViewState["conStr"].ToString());

        if (dtPT.Rows.Count > 0)
        {
            if (dtPT.Rows[0][0].ToString() == "NG")
            {
                lbPTNG.Text = dtPT.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtPT.Rows[0][1]);
            }
            else
            {
                lbPTNG.Text = "0";
            }
            if (dtPT.Rows[0][0].ToString() == "OK")
            {
                lbPTOK.Text = dtPT.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtPT.Rows[0][1]);
            }
            else if (dtPT.Rows[1][0].ToString() == "OK" && dtPT.Rows.Count > 1)
            {
                lbPTOK.Text = dtPT.Rows[1][1].ToString();
                totel = totel + Convert.ToInt16(dtPT.Rows[1][1]);
            }
            else
            {
                lbPTOK.Text = "0";
            }

            lbPTQty.Text = totel.ToString();
        }
    }

    private void ActFH(string start, string end)
    {
        DataTable dtFH = new DataTable();
        int totel = 0;
        string StrFH = "SELECT [fh_judgement] ,count([fh_judgement]) "
            + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_act_fh] "
            + " WHERE fh_date between '" + start + "' and '" + end + "' "
            + " and ((fh_line = 'FH_FINISH_FAC3' and fh_judgement = 'OK') or fh_judgement = 'NG') "
            + " group by [fh_judgement] ";

        SqlCommand qrFH = new SqlCommand();
        qrFH.CommandText = StrFH;
        //qrCS.CommandTimeout = 0;
        dtFH = con.Query(qrFH, ViewState["conStr"].ToString());

        if (dtFH.Rows.Count > 0)
        {
            if (dtFH.Rows[0][0].ToString() == "NG")
            {
                lbFHNG.Text = dtFH.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtFH.Rows[0][1]);
            }
            else
            {
                lbFHNG.Text = "0";
            }
            if (dtFH.Rows[0][0].ToString() == "OK")
            {
                lbFHOK.Text = dtFH.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtFH.Rows[0][1]);
            }
            else if (dtFH.Rows[1][0].ToString() == "OK" && dtFH.Rows.Count > 1)
            {
                lbFHOK.Text = dtFH.Rows[1][1].ToString();
                totel = totel + Convert.ToInt16(dtFH.Rows[1][1]);
            }
            else
            {
                lbFHOK.Text = "0";
            }

            lbFHQty.Text = totel.ToString();
        }
    }

    private void ActRH(string start, string end)
    {
        DataTable dtRH = new DataTable();
        int totel = 0;
        string StrRH = "SELECT [rh_judgement] ,count([rh_judgement]) "
            + " FROM [" + ViewState["baseName"] + "].[dbo].[vi_act_rh] "
            + " WHERE rh_date between '" + start + "' and '" + end + "' "
            + " and ((rh_line = 'RH_ID_FL_FAC3' and rh_judgement = 'OK') or rh_judgement = 'NG') "
            + " group by [rh_judgement] ";

        SqlCommand qrRH = new SqlCommand();
        qrRH.CommandText = StrRH;
        //qrCS.CommandTimeout = 0;
        dtRH = con.Query(qrRH, ViewState["conStr"].ToString());

        if (dtRH.Rows.Count > 0)
        {
            if (dtRH.Rows[0][0].ToString() == "NG")
            {
                lbRHNG.Text = dtRH.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtRH.Rows[0][1]);
            }
            else
            {
                lbRHNG.Text = "0";
            }
            if (dtRH.Rows[0][0].ToString() == "OK")
            {
                lbRHOK.Text = dtRH.Rows[0][1].ToString();
                totel = Convert.ToInt16(dtRH.Rows[0][1]);
            }
            else if (dtRH.Rows[1][0].ToString() == "OK" && dtRH.Rows.Count > 1)
            {
                lbRHOK.Text = dtRH.Rows[1][1].ToString();
                totel = totel + Convert.ToInt16(dtRH.Rows[1][1]);
            }
            else
            {
                lbRHOK.Text = "0";
            }

            lbRHQty.Text = totel.ToString();
        }
    }
}