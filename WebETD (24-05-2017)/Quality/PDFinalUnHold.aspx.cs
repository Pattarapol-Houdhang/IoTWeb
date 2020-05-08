﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductionServices;


public partial class Quality_PDFinalUnHold : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    ConnectDB oConCostyIoT = new ConnectDB();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    ProductionService srvProd = new ProductionService();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Attributes.Add("readonly", "readonly");
            GetData();
        }
    }


    private void CheckPermission()
    {
        try
        {
            if (Session["UserName"].ToString() != "")
            {
                DataTable dtPerm = new DataTable();
                string SQLPerm = "SELECT * FROM UserInGroup WHERE ug_id = '8' AND username = @username ";
                SqlCommand cmdPerm = new SqlCommand();
                cmdPerm.CommandText = SQLPerm;
                cmdPerm.CommandTimeout = 180;
                cmdPerm.Parameters.Add(new SqlParameter("username", Session["UserName"].ToString()));
                dtPerm = oConCostyIoT.Query(cmdPerm);

                if (dtPerm.Rows.Count > 0)
                {
                    if (ddlStatus.SelectedValue.ToString() == "REQUEST")
                    {
                        btnUnHold.Visible = true;
                    }
                    else {
                        btnUnHold.Visible = false;
                    }
                    
                }
            }
            else {
                btnUnHold.Visible = false;
            }
        }
        catch {
            btnUnHold.Visible = false;
        }
    }



    private void GetData()
    {
        //--- Get Permission ----
        CheckPermission();


        string SerialLike = "%", ModelLike = "%", ConditionStatus = ""; ;
        //SerialLike = txtSerial.Text != "" ? "%" + txtSerial.Text.Trim() + "%" : "%";

        ModelLike = txtModel.Text != "" ? "%" + txtModel.Text.Trim() + "%" : "%";

        if (ddlStatus.SelectedValue.ToString() == "ALL")
        {
            ConditionStatus = " AND prd_status IN ('HOLD','REQUEST','LINEOUT', 'ALLOW') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "HOLD")
        {
            ConditionStatus = " AND prd_status IN ('HOLD','REQUEST') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "LINEOUT")
        {
            ConditionStatus = " AND prd_status IN ('LINEOUT') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "REQUEST")
        {
            ConditionStatus = " AND prd_status IN ('REQUEST') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "ALLOW")
        {
            ConditionStatus = " AND prd_status IN ('ALLOW') ";
        }
        else
        {
            ConditionStatus = "";
        }

        SqlCommand sql = new SqlCommand();
        //sql.CommandText = "SELECT prd_serial,prd_model,prd_model_code,prd_pipe_no,HoldBy,HoldDate,prd_status FROM [PD_FinalHold]" +
        //    " WHERE prd_model LIKE '" + ModelLike + "' AND prd_serial LIKE '" + SerialLike + "' "+ ConditionStatus;

        string strSQL = "SELECT prd_serial,prd_model,prd_model_code,prd_pipe_no,HoldBy,HoldDate,prd_status, "+
            " OilingStatus, RunningTestStatus, WeightCheckStatus, OilingDate, RunningTestDate, WeightCheckDate " +
            " FROM [PD_FinalHold] " +
            " WHERE  prd_model LIKE '" + ModelLike + "'  " + ConditionStatus;
        sql.CommandText = strSQL;
        if (txtDate.Text != "")
        {
            string[] spOutDate = txtDate.Text.Split('-');
            if (spOutDate.Length > 0)
            {
                strDate = DateTime.ParseExact(spOutDate[0].Replace(" ", ""), "dd/MM/yyyy", culture);
                strDate = strDate.Date + new TimeSpan(0, 0, 0);
                endDate = DateTime.ParseExact(spOutDate[1].Replace(" ", ""), "dd/MM/yyyy", culture);
                endDate = endDate.Date + new TimeSpan(23, 59, 59);

                strSQL += " AND (HoldDate >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND HoldDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
        }
        else
        {
            strSQL += " AND (HoldDate >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00' AND HoldDate <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 20:00:00')";
        }

        strSQL += " ORDER BY HoldDate DESC ";
        sql.CommandText = strSQL;
        DataTable dt = new DataTable();
        dt = oConn.SqlGet(sql);
        rptPacking.DataSource = dt;
        rptPacking.DataBind();

    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetData();
    }


    protected void rptPacking_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lblStatus = (Literal)e.Item.FindControl("lblStatus") as Literal;
            Label lblPrdSerial = (Label)e.Item.FindControl("lblPrdSerial") as Label;
            Label lblModelCode = (Label)e.Item.FindControl("lblModelCode") as Label;
            Label lblModel = (Label)e.Item.FindControl("lblModel") as Label;
            Label lblPalletNo = (Label)e.Item.FindControl("lblPalletNo") as Label;
            Label lblPipeNo = (Label)e.Item.FindControl("lblPipeNo") as Label;
            Label lblHoldBy = (Label)e.Item.FindControl("lblHoldBy") as Label;
            Literal lblHoldDate = (Literal)e.Item.FindControl("lblHoldDate") as Literal;
            Literal lblOilStatus = (Literal)e.Item.FindControl("lblOilStatus") as Literal;
            Literal lblRunStatus = (Literal)e.Item.FindControl("lblRunStatus") as Literal;
            Literal lblWeightStatus = (Literal)e.Item.FindControl("lblWeightStatus") as Literal;
            
            //*************************************
            DataTable dtEmp = new DataTable();
            string StrEmp = "SELECT [NAME],[SURN] FROM Employee WHERE CODE=@CODE ";
            SqlCommand cmdEmp = new SqlCommand();
            cmdEmp.CommandText = StrEmp;
            cmdEmp.CommandTimeout = 180;
            cmdEmp.Parameters.Add(new SqlParameter("CODE", lblHoldBy.Text.Trim()));
            dtEmp = oConDCI.Query(cmdEmp);
            if (dtEmp.Rows.Count > 0)
            {
                try
                {
                    lblHoldBy.Text = dtEmp.Rows[0]["NAME"].ToString() + "." + dtEmp.Rows[0]["SURN"].ToString().Substring(0, 1);
                }
                catch { }
            }


            DataTable dtPallet = new DataTable();
            string StrPallet = "SELECT pl_no, pl_code FROM vi_Pack_Pallet WHERE prd_serial=@prd_serial ";
            SqlCommand cmdPallet = new SqlCommand();
            cmdPallet.CommandText = StrPallet;
            cmdPallet.CommandTimeout = 180;
            cmdPallet.Parameters.Add(new SqlParameter("prd_serial", lblPrdSerial.Text.Trim()));
            dtPallet = oConDCI.Query(cmdPallet);

            try
            {
                lblPalletNo.Text = dtPallet.Rows[0]["pl_no"].ToString();
            }
            catch { lblPalletNo.Text = ""; }
            


            //-------- Oil Filing ----------
            if (lblOilStatus.Text.Trim().ToUpper() == "OK" || lblOilStatus.Text.Trim().ToUpper() == "NG")
            {
                lblOilStatus.Text = lblOilStatus.Text.Trim().ToUpper();
            }
            else {
                lblOilStatus.Text = "-";
            }

            //-------- Running Test ----------
            if (lblRunStatus.Text.Trim().ToUpper() == "OK" || lblRunStatus.Text.Trim().ToUpper() == "NG")
            {
                lblRunStatus.Text = lblRunStatus.Text.Trim().ToUpper();
            }
            else
            {
                lblRunStatus.Text = "-";
            }

            //-------- Weight Check ----------
            if (lblWeightStatus.Text.Trim().ToUpper() == "OK" || lblWeightStatus.Text.Trim().ToUpper() == "NG")
            {
                lblWeightStatus.Text = lblWeightStatus.Text.Trim().ToUpper();
            }
            else
            {
                lblWeightStatus.Text = "-";
            }


            string FontColor = "";
            string DataStatus = "";
            if (lblStatus.Text == "HOLD" || lblStatus.Text == "REQUEST")
            {
                FontColor = " color:#ff0000; ";
                DataStatus = "FG HOLD";
            }
            else if (lblStatus.Text == "LINEOUT")
            {
                FontColor = " color:#ff9900; ";
                DataStatus = "LINE OUT";
            }
            else
            {
                FontColor = " color:#29a329; ";
                DataStatus = "UNHOLD";
            }
            

            
            lblOilStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + lblOilStatus.Text.ToString() + "</span>";
            lblRunStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + lblRunStatus.Text.ToString() + "</span>";
            lblWeightStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + lblWeightStatus.Text.ToString() + "</span>";
            
            try
            {
                lblHoldDate.Text = Convert.ToDateTime(lblHoldDate.Text).ToString("dd/MM/yyyy HH:mm:ss");   
            }
            catch (Exception ex)
            {
                lblHoldDate.Text = ex.ToString();
            }
            lblStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>"+ DataStatus + "</span>";



        }
    }

    

    protected void btnUnHold_Click(object sender, EventArgs e)
    {
        string _DataBy = "40865";
        string _DataPrdLot = "";
        string _DataSerial = "";
        string _DataStatus = "ALLOW";
        string _Error = "";
        foreach (RepeaterItem item in rptPacking.Items)
        {
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox ckPrdSerial = (CheckBox)item.FindControl("ckPrdSerial") as CheckBox;
                Label lblPrdSerial = (Label)item.FindControl("lblPrdSerial") as Label;
                if (ckPrdSerial.Checked) {
                    _DataSerial = lblPrdSerial.Text;
                    string Response = srvProd.UpdateUnHold(_DataBy, _DataPrdLot, _DataSerial, _DataStatus);
                    if (Response == "FAIL") {
                        _Error += _DataSerial + ":FAIL.  ";
                    }
                }// checked
                
            }
        }


        //---- Load Data ----
        GetData();

        lblError.Text = _Error;
    }




    
}