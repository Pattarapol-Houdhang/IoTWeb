using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using AuthenService;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    UserService userSer = new UserService();
    CUserLoginData oUser = new CUserLoginData();
    Authen oAuthen = new Authen();
    private ADHelper adHl = new ADHelper();


    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserLoginData"] = null;
        Session["UserName"] = null;
        Session["UserFullName"] = null;

        if (Request.QueryString["PathURL"] != null)
        {
            ViewState["PathURL"] = Request.QueryString["PathURL"];
        }
        else
        {
            ViewState["PathURL"] = "";
        }

        if (!IsPostBack)
        {
            txtUsername.Focus();
        }
    }

    private bool CheckLogin()
    {
        if (txtUsername.Text.Trim() == "")
        {
            txtUsername.BackColor = Color.Pink;
            lbError.Text = "Please input username.";
            txtUsername.Focus();
            return false;
        }
        if (txtPassword.Text.Trim() == "")
        {
            txtUsername.BackColor = Color.Pink;
            txtPassword.BackColor = Color.Pink;
            lbError.Text = "Username or Password incorrect!";
            txtPassword.Focus();
            return false;
        }

        return true;
    }


    protected void btLogin_Click(object sender, EventArgs e)
    {
        MDUserLoginData oMDUser = new MDUserLoginData();
        try
        {
            if (CheckLogin())
            {

                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                ADHelper.LoginResult lgresr = new ADHelper.LoginResult();
                lgresr = adHl.Login(username, password);
                if (lgresr == ADHelper.LoginResult.LOGIN_OK)
                {
                    DataSet usr = adHl.GetUserDataSet(username);
                    DataTable dtUser = new DataTable();
                    dtUser = usr.Tables["User"];
                    string EmpCode = dtUser.Rows[0]["Zip"].ToString();
                    string email = dtUser.Rows[0]["EmailAddress"].ToString();


                    // Login Success                       
                    oMDUser = oUser.LoginSystem(EmpCode);
                    Session["UserLoginData"] = oMDUser;
                    Session["EmpCode"] = EmpCode;
                    Session["UserName"] = username;
                    Session["UserFullName"] = dtUser.Rows[0]["LoginName"].ToString();
                    if (ViewState["PathURL"] != "")
                    {
                        Response.Redirect(ResolveClientUrl("~/" + ViewState["PathURL"].ToString()));
                    }
                    else
                    {
                        Response.Redirect(ResolveClientUrl("~/Default.aspx"));
                    }
                }
                else
                {
                    string CheckUserInSystem = "false";
                    CheckUserInSystem = oUser.CheckUserInSystem(txtUsername.Text.Trim());

                    if (Convert.ToBoolean(CheckUserInSystem))
                    {
                        bool CheckUserHavePassword = false;
                        CheckUserHavePassword = oUser.CheckUserHavePassword(txtUsername.Text.Trim());
                        if (CheckUserHavePassword)
                        {
                            oMDUser = oUser.LoginSystem(txtUsername.Text.Trim(), EncryptPassword(txtPassword.Text.Trim()));
                            Session["UserLoginData"] = oMDUser;
                            Session["UserName"] = oMDUser.ListOfUser[0].empCode;
                            Session["UserFullName"] = oMDUser.ListOfUser[0].firstname + " " + oMDUser.ListOfUser[0].lastname;
                            if (ViewState["PathURL"] != "")
                            {
                                string PathURL = "~/" + ViewState["PathURL"].ToString();
                                Response.Redirect(ResolveClientUrl(PathURL));
                            }
                            else
                            {
                                Response.Redirect(ResolveClientUrl("~/Default.aspx"));
                            }
                        }
                        else
                        {
                            bool LoginSuccess = false;
                            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
                            {
                                if (pc.ValidateCredentials(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
                                {
                                    // Login With AD Server
                                    LoginSuccess = true;
                                }
                            }

                            if (LoginSuccess)
                            {
                                // Login Success                       
                                oMDUser = oUser.LoginSystem(txtUsername.Text.Trim());
                                Session["UserLoginData"] = oMDUser;
                                Session["UserName"] = oMDUser.ListOfUser[0].empCode;
                                Session["UserFullName"] = oMDUser.ListOfUser[0].fullname;
                                if (ViewState["PathURL"] != "")
                                {
                                    Response.Redirect(ResolveClientUrl("~/" + ViewState["PathURL"].ToString()));
                                }
                                else
                                {
                                    Response.Redirect(ResolveClientUrl("~/Default.aspx"));
                                }

                            }
                            else
                            {
                                txtUsername.BackColor = Color.Pink;
                                txtPassword.BackColor = Color.Pink;
                                lbError.Text = "Username or Password incorrect!";
                                txtPassword.Focus();
                            }
                        }

                    }
                    else
                    {
                        txtUsername.BackColor = Color.Pink;
                        txtPassword.BackColor = Color.Pink;
                        lbError.Text = "Username or Password incorrect!";
                        txtPassword.Focus();
                    }
                }






            }
        }
        catch (Exception)
        {
            
        }
        


    }

    protected void btBackHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    private string EncryptPassword(string password)
    {
        string result = "";
        return result = oAuthen.EncryptPasswordNoKey(txtPassword.Text.Trim());

    }
}