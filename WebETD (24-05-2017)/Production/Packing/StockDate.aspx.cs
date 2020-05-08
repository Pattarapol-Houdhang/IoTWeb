using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Packing_StockDate : System.Web.UI.Page
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
            //txtPrdDate.Attributes.Add("readonly", "readonly");
            txtInDate.Attributes.Add("readonly", "readonly");
            //txtOutDate.Attributes.Add("readonly", "readonly");
        }
    }
    

    protected void rptPacking_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           
            
        }
        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
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
        
        SqlCommand sql = new SqlCommand();
        string PackLike = txtPack.Text != "" ? "%" + txtPack.Text.Trim() + "%" : "%";
        string ModelLike = txtModel.Text != "" ? txtModel.Text.Trim() : "%";

        if (txtInDate.Text != "")
        {
            sql = new SqlCommand("sp_CompressorStock");
            sql.CommandType = CommandType.StoredProcedure;            
            sql.Parameters.AddWithValue("@PackNo", SqlDbType.VarChar).Value = PackLike;
            sql.Parameters.AddWithValue("@ModelNo", SqlDbType.VarChar).Value = ModelLike;
            sql.Parameters.AddWithValue("@DateST", SqlDbType.DateTime).Value = strInDate;
            sql.Parameters.AddWithValue("@DateED", SqlDbType.DateTime).Value = endInDate;
            sql.CommandTimeout = 1800000;
            DataTable dt = oConnDCI.SqlGet(sql);
            rptPacking.DataSource = dt;
            rptPacking.DataBind();
        }
       
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtInDate.Text = ""; 
    }
}