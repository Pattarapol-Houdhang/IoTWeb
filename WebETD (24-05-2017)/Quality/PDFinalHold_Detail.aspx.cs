using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_PDFinalHold_Detail : System.Web.UI.Page
{
    private ConnectDBDCI oConDCI = new ConnectDBDCI();
    private string serial_no = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Open();
        }
    }

    private void Open()
    {
        try
        {
            serial_no = Request.QueryString["serial"].Trim().ToString();

            SqlCommand sqlSelect = new SqlCommand();
            sqlSelect.CommandText = "SELECT * FROM PD_FinalHold_Log WHERE prd_serial = @prd_serial ORDER BY HoldDate DESC";
            sqlSelect.Parameters.Add(new SqlParameter("@prd_serial", serial_no));
            sqlSelect.CommandTimeout = 180;
            DataTable dtSerial = oConDCI.Query(sqlSelect);
            if (dtSerial.Rows.Count > 0)
            {
                ltrModelName.Text = dtSerial.Rows[0]["prd_model"].ToString();
                ltrModelCode.Text = dtSerial.Rows[0]["prd_model_code"].ToString();
                ltrSerialNo.Text = dtSerial.Rows[0]["prd_serial"].ToString();
                ltrPipeNo.Text = dtSerial.Rows[0]["prd_pipe_no"].ToString();

                rptData.DataSource = dtSerial;
                rptData.DataBind();
            }
            else
            {
                rptData.DataSource = null;
                rptData.DataBind();
            }
        }
        catch { }
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drow = e.Item.DataItem as DataRowView;

            Literal lblPrdSerial = e.Item.FindControl("lblPrdSerial") as Literal;
            Literal lblModelCode = e.Item.FindControl("lblModelCode") as Literal;
            Literal lblModel = e.Item.FindControl("lblModel") as Literal;
            Literal lblPipeNo = e.Item.FindControl("lblPipeNo") as Literal;
            Literal lblOilStatus = e.Item.FindControl("lblOilStatus") as Literal;
            Literal lblRunStatus = e.Item.FindControl("lblRunStatus") as Literal;
            Literal lblWeightStatus = e.Item.FindControl("lblWeightStatus") as Literal;
            Literal lblHoldBy = e.Item.FindControl("lblHoldBy") as Literal;
            Literal lblHoldDate = e.Item.FindControl("lblHoldDate") as Literal;
            Literal lblStatus = e.Item.FindControl("lblStatus") as Literal;

            
            lblPrdSerial.Text = drow["prd_serial"].ToString();
            lblModelCode.Text = drow["prd_model_code"].ToString();
            lblModel.Text = drow["prd_model"].ToString();
            lblPipeNo.Text = drow["prd_pipe_no"].ToString();
            lblOilStatus.Text = (drow["OilingStatus"].ToString() != "") ? drow["OilingStatus"].ToString() : "-";
            lblRunStatus.Text = (drow["RunningTestStatus"].ToString() != "") ? drow["RunningTestStatus"].ToString() : "-"; 
            lblWeightStatus.Text = (drow["WeightCheckStatus"].ToString() != "") ? drow["WeightCheckStatus"].ToString() : "-";
            lblHoldBy.Text = drow["HoldBy"].ToString();
            lblHoldDate.Text = Convert.ToDateTime(drow["HoldDate"].ToString()).ToString("dd/MM/yyyy HH:mm");
            lblStatus.Text = drow["prd_status"].ToString();
        }
    }
}