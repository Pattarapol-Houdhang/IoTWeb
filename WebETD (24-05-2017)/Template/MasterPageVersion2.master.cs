using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template_MasterPageVersion2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }


    public string GetUserProfile(){
        string result = "";
        try
        {
            if (Session["UserName"].ToString() != "")
            {
                result += "<span >" + Session["UserFullName"].ToString() +"</span>" + Environment.NewLine;
                result += "<a href='" + ResolveClientUrl("~/Login.aspx") + "'> Log Out </a>" + Environment.NewLine;

            }
            else
            {
                result += "<span ></span>" + Environment.NewLine;
                result += "<a style='font-size: 30px; text-transform: uppercase; font-weight: bold; color: #fff;' href='" + ResolveClientUrl("~/Login.aspx") + "'>[ Log In ]</a>" + Environment.NewLine;
            }
        }
        catch (Exception ex)
        {
            result += "<span ></span>" + Environment.NewLine;
            result += "<a style='font-size: 30px; text-transform: uppercase; font-weight: bold; color: #fff;' href='" + ResolveClientUrl("~/Login.aspx") + "'>[ Log In ]</a>" + Environment.NewLine;
        }
        return result;
    }

    



}
