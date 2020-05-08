using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{
    private UserService userSer = new UserService();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            Response.Redirect("UserLogout.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtLoginUsername.Text.Trim();
        string password = txtLoginPassword.Text.Trim();

        UserInfo userInfo = userSer.CheckLogin(username, password);

        if (userInfo != null)
        {
            //keep session.(employee id)
            Session["userName"] = username;
            Session["userFLName"] = userInfo.User_name + " " + userInfo.User_surname;
            Session["userPermission"] = userInfo.User_permission;
            //(this.Master as MasterPage).SetLabelLogin();

            if (userInfo.User_first_login)
            {
                //redirect to change password page.
                Response.Redirect("ChangePassword.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            lblErrLogin.Text = "Can't login. Please check username or password.";
        }
        


    }
}