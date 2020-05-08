using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_TempRunningTestJudgement : System.Web.UI.Page
{
    ConnectDB oConn = new ConnectDB();
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
        string ConditionStatus = "";
        if (ddlStatus.SelectedValue.ToString() == "ALL")
        {
            ConditionStatus = " JudgementResult IN ('OK','NG') ";
        }
        else
        {
            ConditionStatus = " JudgementResult = '" + ddlStatus.SelectedValue.ToString().ToUpper() + "' ";
        }
        
        
        
        string strSQL = "SELECT SerialNO, SUBSTRING(SerialNO, 4, 4) AS ModelCode, JudgementValue, JudgementResult, " +
            " CreateBy, CreateDate, Remark1, Remark2, Remark3, Remark4, Remark5 " +
            " FROM TempRunningTestJudgementRecord " +
            " WHERE " + ConditionStatus;
        
        if (txtDate.Text != "")
        {
            string[] spOutDate = txtDate.Text.Split('-');
            if (spOutDate.Length > 0)
            {
                strDate = DateTime.ParseExact(spOutDate[0].Replace(" ", ""), "dd/MM/yyyy", culture);
                strDate = strDate.Date + new TimeSpan(0, 0, 0);
                endDate = DateTime.ParseExact(spOutDate[1].Replace(" ", ""), "dd/MM/yyyy", culture);
                endDate = endDate.Date + new TimeSpan(23, 59, 59);

                strSQL += " AND (CreateDate >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND CreateDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
        }
        else
        {
            strSQL += " AND (CreateDate >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00' AND CreateDate <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 20:00:00')";
        }

        strSQL += " ORDER BY CreateDate DESC ";
        SqlCommand cmdSelect = new SqlCommand();
        cmdSelect.CommandText = strSQL;
        cmdSelect.CommandTimeout = 180;

        DataTable dt = new DataTable();
        dt = oConn.Query(cmdSelect);
        rptRunningTest.DataSource = dt;
        rptRunningTest.DataBind();

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetData();
    }

    protected void rptRunningTest_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lblPrdSerial = (Literal)e.Item.FindControl("lblPrdSerial") as Literal;
            Literal lblModel = (Literal)e.Item.FindControl("lblModel") as Literal;
            Literal lblRunValue = (Literal)e.Item.FindControl("lblRunValue") as Literal;
            Literal lblRunStatus = (Literal)e.Item.FindControl("lblRunStatus") as Literal;
            Literal lblCreateBy = (Literal)e.Item.FindControl("lblCreateBy") as Literal;
            Literal lblCreateDate = (Literal)e.Item.FindControl("lblCreateDate") as Literal;

            string FontColor = "";
            string ResultValue = "";
            if (lblRunStatus.Text == "NG")
            {
                FontColor = " color:#ff9900; ";
                ResultValue = lblRunValue.Text;
            }
            else
            {
                FontColor = " color:#29a329; ";
                ResultValue = "";
            }


            //*************************************
            DataTable dtEmp = new DataTable();
            string StrEmp = "SELECT [NAME],[SURN] FROM Employee WHERE CODE=@CODE ";
            SqlCommand cmdEmp = new SqlCommand();
            cmdEmp.CommandText = StrEmp;
            cmdEmp.CommandTimeout = 180;
            cmdEmp.Parameters.Add(new SqlParameter("CODE", lblCreateBy.Text.Trim()));
            dtEmp = oConDCI.Query(cmdEmp);
            if (dtEmp.Rows.Count > 0)
            {
                try
                {
                    lblCreateBy.Text = dtEmp.Rows[0]["NAME"].ToString() + "." + dtEmp.Rows[0]["SURN"].ToString().Substring(0, 1);
                }
                catch { }
            }

            lblPrdSerial.Text = "<span style='" + FontColor + "'>" + lblPrdSerial.Text.ToString() + "</span>";
            lblModel.Text = "<span style='" + FontColor + "'>" + lblModel.Text.ToString() + "</span>";
            lblRunValue.Text = "<span style='font-weight:bold; " + FontColor + "'>" + ResultValue + "</span>";
            lblRunStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + lblRunStatus.Text.ToString() + "</span>";
            lblCreateBy.Text = "<span style='" + FontColor + "'>" + lblCreateBy.Text.ToString() + "</span>";
            try
            {
                lblCreateDate.Text = "<span style='" + FontColor + "'>" + Convert.ToDateTime(lblCreateDate.Text).ToString("dd/MM/yyyy HH:mm:ss") + "</span>";
            }
            catch
            {
                lblCreateDate.Text = "<span style='" + FontColor + "'>" + lblCreateDate.Text.ToString() + "</span>";
            }



        }
    }



}