using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    private UserService userSer = new UserService();
    string username;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (CheckCurrentPassword())
        {
            //update
            userSer.ChangePassword(username, txtNewPassword.Text);
            userSer.ChangeStatusFirst(username);

            Response.Redirect("Default.aspx");
        }
    }

    public bool CheckCurrentPassword(){

        username = Session["userName"].ToString();

        if (txtNewPassword.Text == txtConfirmPassword.Text)
        {
            if (userSer.CheckLogin(username, txtCurrentPassword.Text) != null)
            {
                return true;
            }
            else
            {
                lblErrPassword.Text = "Current password fail.";
                return false;
            }
        }
        else
        {
            lblErrPassword.Text = "New password and Confirm password not match.";
            return false;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}