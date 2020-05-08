using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CGeneralDDL
/// </summary>
public class CGeneralDDL
{
    ConnectDBCosty oConn = new ConnectDBCosty();
    string[] montharr = { "January", "Fabuary", "March", "April", "May", "June", "July", "Auguest", "September", "October", "November", "December" };
    string[] charr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

    public CGeneralDDL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void GetDDLModelType(DropDownList ddlModelType)
    {
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT DISTINCT ModelType FROM [PN_Compressor]";
        DataTable dtModelType = oConn.SqlGet(sql, "DBSCM");
        ddlModelType.DataSource = dtModelType;
        ddlModelType.DataValueField = "ModelType";
        ddlModelType.DataTextField = "ModelType";
        ddlModelType.DataBind();
    }

    public void GetDDLModel(DropDownList ddlModel, string ModelType)
    {
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT DISTINCT Model,ModelCode FROM [PN_Compressor] WHERE ModelType = '"+ModelType+"'";
        DataTable dtModel = oConn.SqlGet(sql, "DBSCM");
        ddlModel.DataSource = dtModel;
        ddlModel.DataValueField = "ModelCode";
        ddlModel.DataTextField = "Model";
        ddlModel.DataBind();
    }

    public void GetDDLChannel(DropDownList ddlCH)
    {
        for (int i = 1; i <= charr.Length; i++)
        {
            ddlCH.Items.Add(new ListItem(charr[i - 1].ToUpper(), i.ToString()));
        }
      //  ddlCH.SelectedValue = DateTime.Now.Month.ToString();
    }


    public void GetDDLMonth(DropDownList ddlMonth)
    {
        for (int i = 1; i <= montharr.Length; i++)
        {
            ddlMonth.Items.Add(new ListItem(montharr[i - 1].ToUpper(), i.ToString()));
        }
        ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
    }

    public void GetDDLYear (DropDownList ddlYear)
    {
        int strYear = DateTime.Now.Year - 2;
        for (int i = strYear; i < DateTime.Now.Year + 2; i++)
        {
            ddlYear.Items.Add(i.ToString());
        }
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }
}