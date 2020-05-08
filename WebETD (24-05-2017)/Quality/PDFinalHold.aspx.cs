using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_PDFinalHold : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Attributes.Add("readonly", "readonly");
            GetData();
        }
    }

    private void GetData()
    {
        string SerialLike = "%", ModelLike = "%", ConditionStatus = "";
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
        else {
            ConditionStatus = "";
        }

        SqlCommand sql = new SqlCommand();
        string strSQL = "SELECT prd_serial, prd_model, prd_model_code, prd_pipe_no, HoldBy, HoldDate, prd_status, "+
            " OilingStatus, RunningTestStatus, WeightCheckStatus, OilingDate, RunningTestDate, WeightCheckDate " +
            " FROM [PD_FinalHold] " +
            " WHERE prd_model LIKE '" + ModelLike + "'  " + ConditionStatus;

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
        else {
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
            Literal lblPrdSerial = (Literal)e.Item.FindControl("lblPrdSerial") as Literal;
            Literal lblModelCode = (Literal)e.Item.FindControl("lblModelCode") as Literal;
            Literal lblModel = (Literal)e.Item.FindControl("lblModel") as Literal;
            Label lblPalletNo = (Label)e.Item.FindControl("lblPalletNo") as Label;
            Literal lblPipeNo = (Literal)e.Item.FindControl("lblPipeNo") as Literal;
            Literal lblHoldBy = (Literal)e.Item.FindControl("lblHoldBy") as Literal;
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

            //*************************************
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
            else
            {
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


            lblPrdSerial.Text = "<span style='" + FontColor + "'>" + lblPrdSerial.Text.ToString() + "</span>";
            lblModelCode.Text = "<span style='" + FontColor + "'>" + lblModelCode.Text.ToString() + "</span>";
            lblModel.Text = "<span style='" + FontColor + "'>" + lblModel.Text.ToString() + "</span>";
            lblPipeNo.Text = "<span style='" + FontColor + "'>" + lblPipeNo.Text.ToString() + "</span>";
            lblOilStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + lblOilStatus.Text.ToString() + "</span>";
            lblRunStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + lblRunStatus.Text.ToString() + "</span>";
            lblWeightStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + lblWeightStatus.Text.ToString() + "</span>";
            lblHoldBy.Text = "<span style='" + FontColor + "'>" + lblHoldBy.Text.ToString() + "</span>";
            try
            {
                lblHoldDate.Text = "<span style='" + FontColor + "'>" + Convert.ToDateTime(lblHoldDate.Text).ToString("dd/MM/yyyy HH:mm:ss") + "</span>";
            }
            catch
            {
                lblHoldDate.Text = "<span style='" + FontColor + "'>" + lblHoldDate.Text.ToString() + "</span>";
            }
            lblStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + DataStatus + "</span>";



        }
    }



}