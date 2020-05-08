using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserData_UserManagement_Detail : System.Web.UI.Page
{
    CUserLoginData oUser = new CUserLoginData();
    CNotify oNotify = new CNotify();
    CLogData oLog = new CLogData();
    AuthenService.Authen oAuthen = new AuthenService.Authen();
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check Login
        if (Session["UserLoginData"] == null)
        {
            Response.Redirect("~/Login.aspx?url=UserManagement.aspx");
        }

        // Check QueryString
        if (Request.QueryString["username"] != null)
        {
            ViewState["username"] = Request.QueryString["username"];
            ViewState["event"] = "Edit";
        }
        else
        {
            //Response.Redirect("~/UserData/UserManagement.aspx");
            ViewState["event"] = "Add";
        }

        if (!IsPostBack)
        {

            CheckEvent();
        }
    }

    private void CheckEvent()
    {
        if(ViewState["event"].ToString() == "Add")
        {
            divPass.Visible = true;
            divConPass.Visible = true;
            divPass2.Visible = true;
            divConPass2.Visible = true;
            imgUser.ImageUrl = ResolveClientUrl("~/images/user.png");
        }
        else if(ViewState["event"].ToString() == "Edit")
        {
            divPass.Visible = false;
            divConPass.Visible = false;
            divPass2.Visible = false;
            divConPass2.Visible = false;
            SetData();
        }
    }

    private void SetData()
    {
        string username = ViewState["username"].ToString();
        MDUserLoginData oMDUser = new MDUserLoginData();
        oMDUser = oUser.GetUserByUsername(username);
        if (oMDUser.ListOfUser.Count > 0)
        {
            txtUsername.Enabled = false;
            txtUsername.Text = oMDUser.ListOfUser[0].Username;
            txtFirstName.Text = oMDUser.ListOfUser[0].firstname;
            txtLastName.Text = oMDUser.ListOfUser[0].lastname;
            txtEmpCode.Text = oMDUser.ListOfUser[0].empCode;
            txtDepartment.Text = oMDUser.ListOfUser[0].department;
            txtEmail.Text = oMDUser.ListOfUser[0].email;
            txtPosition.Text = oMDUser.ListOfUser[0].position;
            rblActive.SelectedValue = oMDUser.ListOfUser[0].active;

            imgUser.ImageUrl = "http://dcidmc.dci.daikin.co.jp/PICTURE/" + oMDUser.ListOfUser[0].empCode + ".jpg";
        }
        else
        {
            // Go to 
            Response.Redirect(ResolveClientUrl("~/UserData/UserManagement.aspx"));
        }
    }

    private void ClearTextboxColor()
    {
        txtUsername.BackColor = Color.White;
        txtFirstName.BackColor = Color.White;
        txtLastName.BackColor = Color.White;
        txtEmpCode.BackColor = Color.White;
    }

    private bool CheckData()
    {
        if (txtUsername.Text.Trim() == "")
        {
            lbError.Text = "Please input Username";
            txtUsername.Focus();
            ClearTextboxColor();
            txtUsername.BackColor = Color.Pink;
            return false;
        }

        if(ViewState["event"].ToString() == "Add")
        {
            if (Convert.ToBoolean(oUser.CheckUserInSystem(txtUsername.Text.Trim())))
            {
                lbError.Text = "Username already exists";
                txtUsername.Focus();
                ClearTextboxColor();
                txtUsername.BackColor = Color.Pink;
                return false;
            }

            if(txtPassword.Text.Trim() == "")
            {
                lbError.Text = "Please input Password";
                txtPassword.Focus();
                ClearTextboxColor();
                txtPassword.BackColor = Color.Pink;
                return false;
            }

            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                lbError.Text = "Password not match!";
                txtPassword.Focus();
                ClearTextboxColor();
                txtPassword.BackColor = Color.Pink;
                return false;
            }
        }
        



        if (txtFirstName.Text.Trim() == "")
        {
            lbError.Text = "Please input First Name";
            txtFirstName.Focus();
            ClearTextboxColor();
            txtFirstName.BackColor = Color.Pink;
            return false;
        }
        if (txtLastName.Text.Trim() == "")
        {
            lbError.Text = "Please input Last Name";
            txtLastName.Focus();
            ClearTextboxColor();
            txtLastName.BackColor = Color.Pink;
            return false;
        }
        if (txtEmpCode.Text.Trim() == "")
        {
            lbError.Text = "Please input Employee Code";
            txtEmpCode.Focus();
            ClearTextboxColor();
            txtEmpCode.BackColor = Color.Pink;
            return false;
        }

        return true;
    }

    protected void btSave_Click(object sender, EventArgs e)
    {
        if (CheckData())
        {
            string username = "";
            MDUserLoginData oMDUser = new MDUserLoginData();
            if(Session["UserLoginData"] != null)
            {
                oMDUser = (MDUserLoginData)Session["UserLoginData"];
                if(oMDUser.ListOfUser.Count > 0)
                {
                    username = oMDUser.ListOfUser[0].Username;
                }
            }

            if(ViewState["event"].ToString() == "Add")
            {
                // Insert new
                oUser.InsertUser(txtUsername.Text.Trim(), EncryptPassword(txtPassword.Text.Trim()), txtFirstName.Text.Trim()
                    , txtLastName.Text.Trim(), txtEmpCode.Text.Trim(), txtDepartment.Text.Trim(), txtPosition.Text.Trim()
                    , txtEmail.Text.Trim(), Convert.ToInt32(rblActive.SelectedValue), username);

                string QError = "";
                if (Session["QueryError"] != null)
                {
                    QError = (string)Session["QueryError"];
                    Session["QueryError"] = null;
                }

                if (QError == "")
                {
                    string LogID = "";
                    LogID = oLog.InsertLog("INSERT UserList by username=" + txtUsername.Text.Trim() + "", "/UserData/UserManagement_Detail.aspx");
                    Session["UserAddStatus"] = "Success," + txtUsername.Text.Trim() + "," + LogID + "";
                }
                else
                {

                    string LogID = "";
                    LogID = oLog.InsertLog("Failed!! INSERT UserList by username=" + txtUsername.Text.Trim() + " Error Detail=" + QError, "/UserData/UserManagement_Detail.aspx");
                    Session["UserAddStatus"] = "Failed," + txtUsername.Text.Trim() + "," + LogID + "";
                }

                Response.Redirect(ResolveClientUrl("~/UserData/UserManagement.aspx"));
            }
            else if (ViewState["event"].ToString() == "Edit")
            {
                // Update
                oUser.UpdateUser(txtUsername.Text.Trim(), txtFirstName.Text.Trim()
                    , txtLastName.Text.Trim(), txtEmpCode.Text.Trim(), txtDepartment.Text.Trim(), txtPosition.Text.Trim()
                    , txtEmail.Text.Trim(), Convert.ToInt32(rblActive.SelectedValue), username);


                string QError = "";
                if (Session["QueryError"] != null)
                {
                    QError = (string)Session["QueryError"];
                    Session["QueryError"] = null;
                }

                if (QError == "")
                {
                    string LogID = "";
                    oLog.InsertLog("UPDATE UserList by username=" + txtUsername.Text.Trim() + "", "/UserData/UserManagement_Detail.aspx");
                    string jquery = oNotify.GetNotifyAutoHide("Success", "Edit Data Success " + txtUsername.Text.Trim() + " Success", CGeneral.NotifyType.Success);
                    ClientScript.RegisterStartupScript(typeof(Page), "a key",
                         "<script type=\"text/javascript\">" + jquery + "</script>"
                         );
                    //Session["UserAddStatus"] = "Success," + txtUsername.Text.Trim() + "," + LogID + "";
                }
                else
                {

                    string LogID = "";
                    LogID = oLog.InsertLog("Failed!! UPDATE UserList by username=" + txtUsername.Text.Trim() + " Error Detail=" + QError, "/UserData/UserManagement_Detail.aspx");
                    string jquery = oNotify.GetNotifyAutoHide("Failed!", "Edit Data Failed " + txtUsername.Text.Trim()
                           + " Failed!! Please check at LogID=" + LogID + "", CGeneral.NotifyType.Error);
                    ClientScript.RegisterStartupScript(typeof(Page), "a key",
                         "<script type=\"text/javascript\">" + jquery + "</script>"
                         );
                    //Session["UserAddStatus"] = "Failed," + txtUsername.Text.Trim() + "," + LogID + "";
                }
            }

            

            //Response.Redirect(ResolveClientUrl("~/UserData/UserManagement.aspx"));
        }
    }

    protected void btCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveClientUrl("~/UserData/UserManagement.aspx"));
    }

    private string EncryptPassword(string password)
    {
        return oAuthen.EncryptPasswordNoKey(password);
    }
}