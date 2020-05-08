using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Packing_PackingTracking : System.Web.UI.Page
{
    ConnectDBDCIMax oConnDCI = new ConnectDBDCIMax();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");

    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    DateTime strInDate = new DateTime();
    DateTime endInDate = new DateTime();
    DateTime strOutDate = new DateTime();
    DateTime endOutDate = new DateTime();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtPrdDate.Attributes.Add("readonly", "readonly");
            txtInDate.Attributes.Add("readonly", "readonly");
            txtOutDate.Attributes.Add("readonly", "readonly");
        }
    }
    

    protected void rptPacking_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbETDData = (Label)e.Item.FindControl("lbETDData");
            Label lbETAData = (Label)e.Item.FindControl("lbETAData");

            //Label lbPlDate = (Label)e.Item.FindControl("lbPlDate");
            Label lbinDate = (Label)e.Item.FindControl("inDate");
            Label lboutDate = (Label)e.Item.FindControl("outDate");
            Label lbcrDate = (Label)e.Item.FindControl("crDate");
            Label lbprdDate = (Label)e.Item.FindControl("prdDate");

            if (lbETDData.Text != "")
            {
                DateTime etdDate = Convert.ToDateTime(lbETDData.Text);
                lbETDData.Text = etdDate.ToString("dd/MM/yyyy");
                lbETDData.Text = lbETDData.Text == "01/01/1900" ? "" : lbETDData.Text;
            }
            
            if (lbETAData.Text != "")
            {
                DateTime etaDate = Convert.ToDateTime(lbETAData.Text);
                lbETAData.Text = etaDate.ToString("dd/MM/yyyy");
                lbETAData.Text = lbETAData.Text == "01/01/1900" ? "" : lbETAData.Text;
            }
            
            if (lbinDate.Text != "")
            {
                DateTime inDate = Convert.ToDateTime(lbinDate.Text);
                lbinDate.Text = inDate.ToString("dd/MM/yyyy HH:mm:ss");
                lbinDate.Text = lbinDate.Text == "01/01/1900 00:00:00" ? "" : lbinDate.Text;
            }
            
            if (lboutDate.Text != "")
            {
                DateTime outDate = Convert.ToDateTime(lboutDate.Text);
                lboutDate.Text = outDate.ToString("dd/MM/yyyy HH:mm:ss");
                lboutDate.Text = lboutDate.Text == "01/01/1900 00:00:00" ? "" : lboutDate.Text;
            }

            //if (lbPlDate.Text != "")
            //{
            //    DateTime plDate = Convert.ToDateTime(lbPlDate.Text);
            //    lbPlDate.Text = plDate.ToString("yyyy-MM-dd HH:mm:ss");
            //    lbPlDate.Text = lbPlDate.Text == "1900-01-01" ? "" : lbPlDate.Text;
            //}

            if (lbcrDate.Text != "")
            {
                DateTime crDate = Convert.ToDateTime(lbcrDate.Text);
                lbcrDate.Text = crDate.ToString("dd/MM/yyyy HH:mm:ss");
                lbcrDate.Text = lbcrDate.Text == "01/01/1900" ? "" : lbcrDate.Text;
            }

            if (lbprdDate.Text != "")
            {
                DateTime prdDate = Convert.ToDateTime(lbprdDate.Text);
                lbprdDate.Text = prdDate.ToString("dd/MM/yyyy HH:mm:ss");
                lbprdDate.Text = lbprdDate.Text == "01/01/1900" ? "" : lbprdDate.Text;
            }
            
        }
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        rptPacking.DataSource = null;
        rptPacking.DataBind();
        //------------------ prd date -------------------------
        if (txtPrdDate.Text != "")
        {
            string[] spDate = txtPrdDate.Text.Split('-');
            if (spDate.Length > 0)
            {
                strDate = DateTime.ParseExact(spDate[0].Replace(" ", ""), "dd/MM/yyyy", culture);
                strDate = strDate.Date + new TimeSpan(0, 0, 0);
                endDate = DateTime.ParseExact(spDate[1].Replace(" ", ""), "dd/MM/yyyy", culture);
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
            }
        }
        
        //------------------ in date -------------------------
        if (txtInDate.Text != "")
        {
            string[] spInDate = txtInDate.Text.Split('-');
            if (spInDate.Length > 0)
            {
                strInDate = DateTime.ParseExact(spInDate[0].Replace(" ", ""), "dd/MM/yyyy", culture);
                strInDate = strInDate.Date + new TimeSpan(0, 0, 0);
                endInDate = DateTime.ParseExact(spInDate[1].Replace(" ", ""), "dd/MM/yyyy", culture);
                endInDate = endInDate.Date + new TimeSpan(23, 59, 59);
            }
        }        

        //------------------ out date -------------------------
        if (txtOutDate.Text != "")
        {
            string[] spOutDate = txtOutDate.Text.Split('-');
            if (spOutDate.Length > 0)
            {
                strOutDate = DateTime.ParseExact(spOutDate[0].Replace(" ", ""), "dd/MM/yyyy", culture);
                strOutDate = strOutDate.Date + new TimeSpan(0, 0, 0);
                endOutDate = DateTime.ParseExact(spOutDate[1].Replace(" ", ""), "dd/MM/yyyy", culture);
                endOutDate = endOutDate.Date + new TimeSpan(23, 59, 59);
            }
        }        
        
        SqlCommand sql = new SqlCommand();
        string serialLike = "%", PackLike = "%", ModelLike = "%";
        serialLike = txtSerial.Text != "" ? "%" + txtSerial.Text.Trim() + "%" : "%";
        PackLike = txtPack.Text != "" ? "%" + txtPack.Text.Trim() + "%" : "%";
        ModelLike = txtModel.Text != "" ? "%" + txtModel.Text.Trim() + "%" : "%";        

        if (txtPrdDate.Text == "" && txtInDate.Text == "" && txtOutDate.Text == "")
        {
            sql.CommandText = "SELECT [prd_serial],[prd_name],[prd_cd],[pck_no],[pl_no],[pl_style],[pl_date],[cr_dt],[in_dt],dbo.Fnc_getShiftDate([in_dt]) AS inShdt,dbo.Fnc_getShiftDate([out_dt]) AS outShdt,[out_dt],[line_cd],[reason_title]" +
            " ,[inv_no],[ctn_no],[customer_id],[customer_name],[etd_dt],[eta_dt],[location],[booking_id],[ship_to],[pl_code],[prd_date] FROM [vi_Product_Tracking]" +
            " WHERE prd_serial LIKE '" + serialLike + "' AND pck_no LIKE '" + PackLike + "' AND prd_name LIKE '" + ModelLike + "'";
        }
        else
        {
            if (txtPrdDate.Text != "" && txtInDate.Text == "" && txtOutDate.Text == "")
            {
                sql.CommandText = "SELECT [prd_serial],[prd_name],[prd_cd],[pck_no],[pl_no],[pl_style],[pl_date],[cr_dt],[in_dt],dbo.Fnc_getShiftDate([in_dt]) AS inShdt,dbo.Fnc_getShiftDate([out_dt]) AS outShdt,[out_dt],[line_cd],[reason_title]" +
                " ,[inv_no],[ctn_no],[customer_id],[customer_name],[etd_dt],[eta_dt],[location],[booking_id],[ship_to],[pl_code],[prd_date] FROM [vi_Product_Tracking]" +
                " WHERE (prd_date >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND prd_date <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
            else if (txtPrdDate.Text != "" && txtInDate.Text != "" && txtOutDate.Text == "")
            {
                sql.CommandText = "SELECT [prd_serial],[prd_name],[prd_cd],[pck_no],[pl_no],[pl_style],[pl_date],[cr_dt],[in_dt],dbo.Fnc_getShiftDate([in_dt]) AS inShdt,dbo.Fnc_getShiftDate([out_dt]) AS outShdt,[out_dt],[line_cd],[reason_title]" +
                " ,[inv_no],[ctn_no],[customer_id],[customer_name],[etd_dt],[eta_dt],[location],[booking_id],[ship_to],[pl_code],[prd_date] FROM [vi_Product_Tracking]" +
                " WHERE (prd_date >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND prd_date <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
                " AND (dbo.Fnc_getShiftDate([in_dt]) >= '" + strInDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND dbo.Fnc_getShiftDate([in_dt]) <= '" + endInDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
            else if (txtPrdDate.Text != "" && txtInDate.Text != "" && txtOutDate.Text != "")
            {
                sql.CommandText = "SELECT [prd_serial],[prd_name],[prd_cd],[pck_no],[pl_no],[pl_style],[pl_date],[cr_dt],[in_dt],dbo.Fnc_getShiftDate([in_dt]) AS inShdt,dbo.Fnc_getShiftDate([out_dt]) AS outShdt,[out_dt],[line_cd],[reason_title]" +
                " ,[inv_no],[ctn_no],[customer_id],[customer_name],[etd_dt],[eta_dt],[location],[booking_id],[ship_to],[pl_code],[prd_date] FROM [vi_Product_Tracking]" +
                " WHERE (prd_date >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND prd_date <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
                " AND (dbo.Fnc_getShiftDate([in_dt]) >= '" + strInDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND dbo.Fnc_getShiftDate([in_dt]) <= '" + endInDate.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
                " AND (dbo.Fnc_getShiftDate([out_dt]) >= '" + strOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND dbo.Fnc_getShiftDate([out_dt]) <= '" + endOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
            else if (txtPrdDate.Text == "" && txtInDate.Text == "" && txtOutDate.Text != "")
            {
                sql.CommandText = "SELECT [prd_serial],[prd_name],[prd_cd],[pck_no],[pl_no],[pl_style],[pl_date],[cr_dt],[in_dt],dbo.Fnc_getShiftDate([in_dt]) AS inShdt,dbo.Fnc_getShiftDate([out_dt]) AS outShdt,[out_dt],[line_cd],[reason_title]" +
                " ,[inv_no],[ctn_no],[customer_id],[customer_name],[etd_dt],[eta_dt],[location],[booking_id],[ship_to],[pl_code],[prd_date] FROM [vi_Product_Tracking]" +
                " WHERE (dbo.Fnc_getShiftDate([out_dt]) >= '" + strOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND dbo.Fnc_getShiftDate([out_dt]) <= '" + endOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
            else if (txtPrdDate.Text == "" && txtInDate.Text != "" && txtOutDate.Text == "")
            {
                sql.CommandText = "SELECT [prd_serial],[prd_name],[prd_cd],[pck_no],[pl_no],[pl_style],[pl_date],[cr_dt],[in_dt],dbo.Fnc_getShiftDate([in_dt]) AS inShdt,dbo.Fnc_getShiftDate([out_dt]) AS outShdt,[out_dt],[line_cd],[reason_title]" +
                " ,[inv_no],[ctn_no],[customer_id],[customer_name],[etd_dt],[eta_dt],[location],[booking_id],[ship_to],[pl_code],[prd_date] FROM [vi_Product_Tracking]" +
                " WHERE (dbo.Fnc_getShiftDate([in_dt]) >= '" + strInDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND dbo.Fnc_getShiftDate([in_dt]) <= '" + endInDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
            else if (txtPrdDate.Text == "" && txtInDate.Text != "" && txtOutDate.Text != "")
            {
                sql.CommandText = "SELECT [prd_serial],[prd_name],[prd_cd],[pck_no],[pl_no],[pl_style],[pl_date],[cr_dt],[in_dt],dbo.Fnc_getShiftDate([in_dt]) AS inShdt,dbo.Fnc_getShiftDate([out_dt]) AS outShdt,[out_dt],[line_cd],[reason_title]" +
                " ,[inv_no],[ctn_no],[customer_id],[customer_name],[etd_dt],[eta_dt],[location],[booking_id],[ship_to],[pl_code],[prd_date] FROM [vi_Product_Tracking]" +
                " WHERE (dbo.Fnc_getShiftDate([out_dt]) >= '" + strOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND dbo.Fnc_getShiftDate([out_dt]) <= '" + endOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
                " AND (dbo.Fnc_getShiftDate([in_dt]) >= '" + strInDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND dbo.Fnc_getShiftDate([in_dt]) <= '" + endInDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
            sql.CommandText += " AND prd_serial LIKE '" + serialLike + "'";
            sql.CommandText += " AND pck_no LIKE '" + PackLike + "'";
            sql.CommandText += " AND prd_name LIKE '" + ModelLike + "'";
        }

        sql.CommandTimeout = 0;
        DataTable dt = oConnDCI.SqlGet(sql);
        rptPacking.DataSource = dt;
        rptPacking.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtPrdDate.Text = ""; txtInDate.Text = ""; txtOutDate.Text = "";
    }
}