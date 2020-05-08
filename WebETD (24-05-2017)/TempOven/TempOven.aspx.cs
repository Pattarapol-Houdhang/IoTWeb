using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_PDHold : System.Web.UI.Page
{
    ConnectDBIoT oConn = new ConnectDBIoT();
    ConnectDBCosty oConDCI = new ConnectDBCosty();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Attributes.Add("readonly", "readonly");
         //   GetData();
        }
    }

    private void GetData()
    {
        string  ConditionStatus = "",ConditionSearch="";
        //SerialLike = txtSerial.Text != "" ? "%" + txtSerial.Text.Trim() + "%" : "%";

   //  ModelLike = txtModel.Text != "" ? "%" + txtModel.Text.Trim() + "%" : "%";

        if (ddlStatus.SelectedValue.ToString() == "ALL")
       {
            ConditionStatus = "";
        }
        else if (ddlStatus.SelectedValue.ToString() == "1")
        {
           ConditionStatus = " IDCH = '1'";
       }
        else if (ddlStatus.SelectedValue.ToString() == "2")
       {
            ConditionStatus = " IDCH ='2' ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "3")
        { 
            ConditionStatus = " IDCH = '3' ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "4")
        {
            ConditionStatus = " IDCH = '4' ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "5")
        {
            ConditionStatus = " IDCH = '5' ";
        }
       
        else if (ddlStatus.SelectedValue.ToString() == "6")
        {
            ConditionStatus = " IDCH = '6' ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "7")
        {
            ConditionStatus = " IDCH ='7' ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "8")
        {
            ConditionStatus = " IDCH = '8' ";
        }
            
        else if (ddlStatus.SelectedValue.ToString() == "6")
        {
            ConditionStatus = " IDCH = '6' ";
        }
       
        else if (ddlStatus.SelectedValue.ToString() == "9")
        {
            ConditionStatus = " IDCH ='9' ";
        }
     
        else if (ddlStatus.SelectedValue.ToString() == "10")
        {
            ConditionStatus = " IDCH = '10' ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "11")
        {
            ConditionStatus = " IDCH = '11' ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "12")
        {
            ConditionStatus = " IDCH = '12' ";
        }
        else
     
       {
            ConditionStatus = "";
        }

        SqlCommand sql = new SqlCommand();

        if (ConditionStatus != "")
        {
            ConditionSearch = " Where" + ConditionStatus + " And ";
        }
        else
        {
            ConditionSearch = " Where ";
        }

        string strSQL = "select IDCH,Temp,TimeStamp from FN_TempOven" + ConditionSearch;
        
        if (txtDate.Text != "")
        {
            string[] spOutDate = txtDate.Text.Split('-');
            if (spOutDate.Length > 0)
            {
                strDate = DateTime.ParseExact(spOutDate[0].Replace(" ", ""), "dd/MM/yyyy", culture);
                strDate = strDate.Date + new TimeSpan(08, 0, 0);
                endDate = DateTime.ParseExact(spOutDate[1].Replace(" ", ""), "dd/MM/yyyy", culture);
                endDate = endDate.AddDays(1) + new TimeSpan(08, 0, 0);

                strSQL += "(TimeStamp >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND TimeStamp <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
        }
        else
        {
            strSQL += "(TimeStamp >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00' AND TimeStamp <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 20:00:00')";
        }

        strSQL += " ORDER BY IDCH ASC,TimeStamp desc ";
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
            Literal lblDateTime = (Literal)e.Item.FindControl("lblDateTime") as Literal;
            Literal lblIDCH = (Literal)e.Item.FindControl("lblIDCH") as Literal;
            Literal lblTemp = (Literal)e.Item.FindControl("lblTemp") as Literal;

            double tempp = 0.0;

            tempp = Convert.ToDouble(lblTemp.Text) / 10.0;


            lblDateTime.Text = "<span style='"  + "'>" + Convert.ToDateTime(lblDateTime.Text).ToString("dd/MM/yyyy HH:mm:ss") + "</span>";
            lblIDCH.Text = "<span style='"  + "'>" + lblIDCH.Text.ToString() + "</span>";
            lblTemp.Text = "<span style='" + "'>" + tempp.ToString() + "</span>";
           
         //   try
        //    {
         //       lblHoldDate.Text = "<span style='" + FontColor + "'>" + Convert.ToDateTime(lblHoldDate.Text).ToString("dd/MM/yyyy HH:mm:ss") + "</span>";
         //   }
         //   catch
         //   {
         //       lblHoldDate.Text = "<span style='" + FontColor + "'>" + lblHoldDate.Text.ToString() + "</span>";
         //   }
          //  lblStatus.Text = "<span style='font-weight:bold; " + FontColor + "'>" + DataStatus + "</span>";



        }
    }



}