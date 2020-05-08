using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoldServices;

public partial class Quality_PDUnHoldData : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    ConnectDB oConCostyIoT = new ConnectDB();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    HoldService srvHold = new HoldService();
    

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
                string SQLPerm = "SELECT * FROM UserInGroup WHERE username = @username ";
                SqlCommand cmdPerm = new SqlCommand();
                cmdPerm.CommandText = SQLPerm;
                cmdPerm.CommandTimeout = 180;
                cmdPerm.Parameters.Add(new SqlParameter("username", Session["EmpCode"].ToString()));
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
                else
                {
                    btnUnHold.Visible = false;
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


        string SerialLike = "%", ModelLike = "%", ConditionStatus = "", PalletNo = "", ConditionLine = "";

        PalletNo = txtPalletNo.Text != "" ? "%" + txtPalletNo.Text.Trim() + "%" : "%";
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


        //*********************************
        //         Line Master
        //*********************************
        if (ddlProdLine.SelectedValue.ToString() == "1YC")
        {
            ConditionLine = " AND prd_model LIKE '1YC%' ";
        }
        else if (ddlProdLine.SelectedValue.ToString() == "2YC")
        {
            ConditionLine = " AND prd_model LIKE '2YC%' ";
        }
        else if (ddlProdLine.SelectedValue.ToString() == "SCR")
        {
            ConditionLine = " AND prd_model LIKE 'J%' ";
        }
        else if (ddlProdLine.SelectedValue.ToString() == "ODM")
        {
            ConditionLine = " AND (prd_model LIKE '1P%' OR prd_model LIKE '2P%') ";
        }
        //*********************************


        SqlCommand sql = new SqlCommand();
        string strSQL = @"SELECT HoldNbr, LotUnholdNbr, LotNbr, prd_serial, prd_line, prd_model_code, 
                    prd_model, pl_no, prd_pipe_no, HoldBy, HoldDate, prd_status, RequestBy, 
                    RequestDate, AllowBy, AllowDate, remark1, remark2, remark3 
            FROM PD_Hold ";
        strSQL += " WHERE prd_model LIKE '" + ModelLike + "' " + ConditionStatus + ConditionLine;
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
        DataTable dtHead = new DataTable();
        dtHead = oConDCI.Query(sql);

        rptPacking.DataSource = dtHead;
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
            Label lblPrdLine = (Label)e.Item.FindControl("lblPrdLine") as Label;
            Label lblPrdSerial = (Label)e.Item.FindControl("lblPrdSerial") as Label;
            Label lblModelCode = (Label)e.Item.FindControl("lblModelCode") as Label;
            Label lblModel = (Label)e.Item.FindControl("lblModel") as Label;
            Label lblPalletNo = (Label)e.Item.FindControl("lblPalletNo") as Label;
            Label lblHoldBy = (Label)e.Item.FindControl("lblHoldBy") as Label;
            Label lblHoldDate = (Label)e.Item.FindControl("lblHoldDate") as Label;
            Label lblRequestBy = (Label)e.Item.FindControl("lblRequestBy") as Label;
            Label lblRequestDate = (Label)e.Item.FindControl("lblRequestDate") as Label;
            Label lblAllowBy = (Label)e.Item.FindControl("lblAllowBy") as Label;
            Label lblAllowDate = (Label)e.Item.FindControl("lblAllowDate") as Label;


            switch (lblPrdLine.Text.Trim())
            {
                case "1": lblPrdLine.Text = "1YC : Line 1"; break;
                case "2": lblPrdLine.Text = "1YC : Line 2"; break;
                case "3": lblPrdLine.Text = "2YC : Line 3"; break;
                case "4": lblPrdLine.Text = "SCROLL : Line 4"; break;
                case "5": lblPrdLine.Text = "2YC : Line 5"; break;
                case "6": lblPrdLine.Text = "1YC/3 : Line 6"; break;
            }
            
            
            lblHoldBy.Text = (lblHoldBy.Text.Trim() == "") ? "" : GetEmpNameByCode(lblHoldBy.Text.Trim());
            try
            {
                lblHoldDate.Text = (Convert.ToDateTime(lblHoldDate.Text) > new DateTime(2018,1,1)) ? Convert.ToDateTime(lblHoldDate.Text).ToString("dd/MM/yyyy HH:mm:ss") : "";
            }
            catch (Exception ex)
            {
                lblHoldDate.Text = ex.ToString();
            }

            lblRequestBy.Text = (lblRequestBy.Text.Trim() == "") ? "" : GetEmpNameByCode(lblRequestBy.Text.Trim());
            try
            {
                lblRequestDate.Text = (Convert.ToDateTime(lblRequestDate.Text) > new DateTime(2018, 1, 1)) ? Convert.ToDateTime(lblRequestDate.Text).ToString("dd/MM/yyyy HH:mm:ss") : "";
            }
            catch (Exception ex)
            {
                //lblRequestDate.Text = ex.ToString();
            }

            lblAllowBy.Text = (lblAllowBy.Text.Trim() == "") ? "" : GetEmpNameByCode(lblAllowBy.Text.Trim());
            try
            {
                lblAllowDate.Text = (Convert.ToDateTime(lblAllowDate.Text) > new DateTime(2018, 1, 1)) ? Convert.ToDateTime(lblAllowDate.Text).ToString("dd/MM/yyyy HH:mm:ss") : "";
            }
            catch (Exception ex)
            {
                //lblAllowDate.Text = ex.ToString();
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

            lblStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>"+ DataStatus + "</span>";
            
        }
    }

    

    protected void btnUnHold_Click(object sender, EventArgs e)
    {
        string _DataBy = Session["EmpCode"].ToString();
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
                    string Response = srvHold.RecordFGHoldByPrdSerial(_DataBy, _DataSerial, _DataStatus);
                    
                    if (Response != "SUCCESS") {
                        _Error += _DataSerial + ":FAIL.  ";
                    }
                }// checked
            }
        }


        //---- Load Data ----
        GetData();

        lblError.Text = _Error;
    }


    public string GetEmpNameByCode(string EmpCode) {
        string EmpName = EmpCode;
        DataTable dtEmp = new DataTable();
        string StrEmp = "SELECT [NAME],[SURN] FROM Employee WHERE CODE=@CODE ";
        SqlCommand cmdEmp = new SqlCommand();
        cmdEmp.CommandText = StrEmp;
        cmdEmp.CommandTimeout = 180;
        cmdEmp.Parameters.Add(new SqlParameter("CODE", EmpCode.Trim()));
        dtEmp = oConDCI.Query(cmdEmp);
        if (dtEmp.Rows.Count > 0)
        {
            try
            {
                EmpName = dtEmp.Rows[0]["NAME"].ToString() + "." + dtEmp.Rows[0]["SURN"].ToString().Substring(0, 1);
            }
            catch { }
        }

        return EmpName;
    }

    

}