using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template_MasterPageOther : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }

    public string GetPermissionTopSecret() {
        string result = "";
        try
        {
            MDUserLoginData UserData = new MDUserLoginData();
            UserData = (MDUserLoginData)Session["UserLoginData"];
            foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
            {
                if (UsrGroup.GroupID == 12)
                {
                    result = "<li><a href='" + ResolveUrl("~/Cost/CostSummary.aspx") + "'>Summary</a></li>";
                }
            }
        }
        catch { }

        return result; 
    }


    public string GetUserProfile()
    {
        string result = "";
        try
        {
            if (Session["UserName"].ToString() != "")
            {
                result += "<span >" + Session["UserFullName"].ToString() + "</span>" + Environment.NewLine;
                result += "<a href='" + ResolveClientUrl("~/Login.aspx") + "' > Log Out </a>" + Environment.NewLine;

                MDUserLoginData UserData = new MDUserLoginData();
                UserData = (MDUserLoginData)Session["UserLoginData"];
                bool _Permission = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
                {
                    if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11)
                    {
                        _Permission = true;
                    }
                }

                if (!_Permission)
                {
                    Response.Redirect("~/Login.aspx");
                }


            }
            else
            {
                result += "<span ></span>" + Environment.NewLine;
                result += "<a href='" + ResolveClientUrl("~/Login.aspx") + "' style='font-size: 30px; text-transform: uppercase; font-weight: bold; color: #fff;'>[ Log In ]</a>" + Environment.NewLine;

                Response.Redirect("~/Login.aspx");
            }

        }
        catch (Exception ex)
        {
            result += "<span ></span>" + Environment.NewLine;
            //result += "<a href='" + ResolveClientUrl("~/Login.aspx") + "'> Log In "+ex.ToString()+" </a>" + Environment.NewLine;
            result += "<a href='" + ResolveClientUrl("~/Login.aspx") + "' style='font-size: 30px; text-transform: uppercase; font-weight: bold; color: #fff;'>[ Log In ]</a>" + Environment.NewLine;

            Response.Redirect("~/Login.aspx");
        }
        return result;
    }







    





}
