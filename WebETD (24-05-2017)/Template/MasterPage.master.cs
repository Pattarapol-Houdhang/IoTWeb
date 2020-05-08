using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //MDUserLoginData oMDUser = new MDUserLoginData();
        //if (Session["UserLoginData"] != null)
        //{
        //    oMDUser = (MDUserLoginData)Session["UserLoginData"];
        //    if (oMDUser.ListOfUser.Count > 0)
        //    {
        //        // menuHome.Visible = false;
        //        foreach (MDUserLoginData.CMDUserLoginData.CGroup oMDGroup in oMDUser.ListOfUser[0].ListOfGroup)
        //        {
        //            if (oMDGroup.GroupID == 1)
        //            {

        //            }
        //            if (oMDGroup.GroupID == 2)
        //            {

        //            }
        //            if (oMDGroup.GroupID == 3)
        //            {

        //            }
        //        }

        //        //if (oMDUser.ListOfUser[0].ListOfGroup[0].GroupID == 2 || oMDUser.ListOfUser[0].ListOfGroup[0].GroupID == 1)
        //        //{
        //        //    //QcAdmin
        //        //    SetPermissionQCAdmin();
        //        //}
        //        //else
        //        //{
        //        //    //QcUser
        //        //    SetPermissionQCUser();
        //        //}
        //    }


        //btLogin.Text = "Logout";
        //}
        //else
        //{
        //    //SetPermissionDefault();
        //    //lblLogedin.Text = "Not Login";
        //    //btLogin.Text = "Login";
        //}


        if (!IsPostBack)
        {

        }

    }

    //private void SetPermissionDefault()
    //{
    //    menuSetting.Visible = false;
    //    menuRegister.Visible = false;
    //    menuChangePassword.Visible = false;
    //}

    //private void SetPermissionQCAdmin()
    //{
    //    menuSetting.Visible = true;
    //    menuRegister.Visible = true;
    //    menuChangePassword.Visible = true;
    //    menuProduction.Visible = true;
    //}

    //private void SetPermissionQCUser()
    //{
    //    menuSetting.Visible = true;
    //    menuRegister.Visible = false;
    //    menuChangePassword.Visible = true;
    //}

    protected void btLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

    public string GenLoginButton()
    {
        string result = "";

        string EmpCode = "";
        string Name = "";
        string Position = "";
        MDUserLoginData oMDUser = new MDUserLoginData();
        if (Session["UserLoginData"] != null)
        {
            oMDUser = (MDUserLoginData)Session["UserLoginData"];
            if (oMDUser.ListOfUser.Count > 0)
            {
                bool CheckAdminUser = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup oMDGroup in oMDUser.ListOfUser[0].ListOfGroup)
                {
                    if (oMDGroup.GroupName == "Administrator")
                    {
                        CheckAdminUser = true;
                    }
                }

                if (oMDUser.ListOfUser[0].empCode != "")
                {
                    EmpCode = oMDUser.ListOfUser[0].empCode + ".JPG";
                }

                Name = oMDUser.ListOfUser[0].firstname;

                Position = oMDUser.ListOfUser[0].ListOfGroup[0].GroupName;

                if (CheckAdminUser)
                {
                    Position = "Administrator";
                }
            }

            result += "" + Environment.NewLine;
            result += "<a class='dropdown-toggle clearfix' data-toggle='dropdown'>" + Environment.NewLine;
            result += "    <span class='pull-left loged-user-name'>" + Environment.NewLine;
            if (Name != "")
            {
                result += "      " + Name + " : " + Position + "</span>" + Environment.NewLine;
            }
            else
            {
                result += "   Geust</span>" + Environment.NewLine;
            }

            result += "    <span class='logged-user-thumb pull-right'>" + Environment.NewLine;
            if (EmpCode != "")
            {
                result += "        <img class='img-circle' src='http://dcidmc.dci.daikin.co.jp/PICTURE/" + EmpCode + "'>" + Environment.NewLine;
            }
            else
            {
                //result += "        <img class='img-circle' src=''>" + Environment.NewLine;
            }

            result += "    </span>" + Environment.NewLine;
            result += "</a>" + Environment.NewLine;
            result += "<div class='dropdown-menu'>" + Environment.NewLine;
            result += "    <ul class='pull-right'>" + Environment.NewLine;
            result += "        <li><a href='" + ResolveClientUrl("~/UserData/ChangePassword.aspx") + "'>Change Password</a></li>" + Environment.NewLine;
            result += "        <li class='divider'></li>" + Environment.NewLine;
            result += "        <li><a href='" + ResolveClientUrl("~/Login.aspx") + "' class='logout-link'><i class='icon-lock-3'></i>Logout</a></li>" + Environment.NewLine;
            result += "    </ul>" + Environment.NewLine;
            result += "</div>" + Environment.NewLine;

        }
        else
        {

            result += "<a class='clearfix' href='" + ResolveClientUrl("~/Login.aspx") + "'>" + Environment.NewLine;
            result += "    <span class='pull-left loged-user-name'>" + Environment.NewLine;

            result += "   <h4>Login</h4></span>" + Environment.NewLine;


            result += "    <span class='logged-user-thumb pull-right'>" + Environment.NewLine;

            result += "    </span>" + Environment.NewLine;
            result += "</a>" + Environment.NewLine;

        }



        return result;
    }

    public string GenMenu()
    {
        string result = "";
        MDUserLoginData oMDUser = new MDUserLoginData();
        ArrayList arrGroup = new ArrayList();
        if (Session["UserLoginData"] != null)
        {
            oMDUser = (MDUserLoginData)Session["UserLoginData"];
            if (oMDUser.ListOfUser.Count > 0)
            {
                if (oMDUser.ListOfUser[0].ListOfGroup.Count > 0)
                {
                    foreach (MDUserLoginData.CMDUserLoginData.CGroup oMD in oMDUser.ListOfUser[0].ListOfGroup)
                    {
                        arrGroup.Add(oMD.GroupName);
                    }
                }
            }
        }

        result += "" + Environment.NewLine;
        result += "<ul class='side-navigation accordion' id='nav-accordion'>" + Environment.NewLine;
        result += "    <li><a href='" + ResolveClientUrl("~/Default.aspx") + "'><i class='icon-home'></i>Home</a></li>" + Environment.NewLine;
        result += "    <li id='menuMonitoring' runat='server'><a href='#'><i class='icon-clipboard-2'></i>Monitoring</a>" + Environment.NewLine;
        result += "        <ul>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/Monitoring/MonitoringLine.aspx?FactoryID=1") + "'>Factory 1</a></li>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/Monitoring/MonitoringLine.aspx?FactoryID=2") + "'>Factory 2</a></li>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/Monitoring/MonitoringLine.aspx?FactoryID=3") + "'>Factory 3</a></li>" + Environment.NewLine;
        //result += "            <li><a href='" + ResolveClientUrl("~/Efficiency_Report.aspx") + "'>Line Efficiency</a></li>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/Production/Graph/PDGraphMenu.aspx") + "'>Line Efficiency</a></li>" + Environment.NewLine;
        result += "        </ul>" + Environment.NewLine;
        result += "    </li>" + Environment.NewLine;
        result += "    <li id='menuSetting' runat='server'><a><i class='icon-tools'></i>Setting</a>" + Environment.NewLine;
        result += "        <ul>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/MstModel.aspx") + "'>Model</a></li>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/MstProgram.aspx") + "'>Program</a></li>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/MstRank.aspx") + "'>Rank</a></li>" + Environment.NewLine;
        result += "        </ul>" + Environment.NewLine;
        result += "    </li>" + Environment.NewLine;
        result += "    <li id='menuDataHistory' runat='server'><a href='#'><i class='icon-list-alt'></i>Data History</a>" + Environment.NewLine;
        result += "        <ul>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=1") + "'>Factory 1</a></li>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=2") + "'>Factory 2</a></li>" + Environment.NewLine;
        result += "            <li><a href='" + ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=3") + "'>Factory 3</a></li>" + Environment.NewLine;
        result += "        </ul>" + Environment.NewLine;
        result += "    </li>" + Environment.NewLine;


        //result += "    <li><a><i class='icon-stats-up'></i>Productions</a>" + Environment.NewLine;
        //result += "        <ul>" + Environment.NewLine;
        //if (arrGroup.Contains("Administrator") || arrGroup.Contains("PDAdmin")) // Admin system
        //{
        //    result += "            <li><a href='" + ResolveClientUrl("~/Production/Setting/PDSettingMenu.aspx") + "'>Setting</a></li>" + Environment.NewLine;
        //}
        //result += "            <li><a href='" + ResolveClientUrl("~/Production/DataHistory/PDDataHistoryMenu.aspx") + "'>History</a></li>" + Environment.NewLine;
        //result += "            <li><a href='" + ResolveClientUrl("~/Production/Graph/PDGraphMenu.aspx") + "'>Monitoring</a></li>" + Environment.NewLine;
        //result += "        </ul>" + Environment.NewLine;
        //result += "    </li>" + Environment.NewLine;


        // --- Admin Panel ---
        if (arrGroup.Contains("Administrator")) // Admin system
        {
            result += "    <li id='menuManageUser' runat='server'><a><i class='icon-user'></i>Admin Panel</a>" + Environment.NewLine;
            result += "        <ul>" + Environment.NewLine;
            result += "            <li><a href='" + ResolveClientUrl("~/UserData/UserMenu.aspx") + "'>Manage User</a></li>" + Environment.NewLine;
            result += "            <li><a href='" + ResolveClientUrl("~/UserData/ResetPassword.aspx") + "'>Reset Password</a></li>" + Environment.NewLine;

            result += "        </ul>" + Environment.NewLine;
            result += "    </li>" + Environment.NewLine;
        }
        // ----------------------------------------------------

        result += "</ul>" + Environment.NewLine;

        return result;
    }
}
