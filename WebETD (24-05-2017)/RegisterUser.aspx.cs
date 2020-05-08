using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HrmsService;
using System.Drawing;

public partial class RegisterUser : System.Web.UI.Page
{
    HRMSWebService hrmsSer;
    UserService userSer = new UserService();
    EmployeeInfo empInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        hrmsSer = new HRMSWebService();
    }

    object objUserInfo
    {
        get
        {
            UserInfo userInfo = new UserInfo();
            empInfo = hrmsSer.GetEmployeeData(lblEmpCode.Text);

            userInfo.User_code = empInfo.Code;
            userInfo.User_name = empInfo.NameInEng.Name;
            userInfo.User_surname = empInfo.NameInEng.Surname;
            userInfo.User_sect = empInfo.Division.ShortName;
            userInfo.User_permission = CheckPermission();
            userInfo.User_password = empInfo.CitizenId;
            userInfo.User_passwordSt = empInfo.CitizenId; 
            userInfo.User_first_login = true;

            return userInfo;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //insert user 
        userSer.insertNewUser((UserInfo)objUserInfo);
        Response.Redirect("RegisterUser.aspx");
    }

    private void SetOwnPermission(string permission)
    {
        if (permission == "2")
        {
            CheckBoxQCAdmin.Checked = true;
            CheckBoxQCUser.Checked = false;
        }
        else if (permission == "3")
        {
            CheckBoxQCAdmin.Checked = false;
            CheckBoxQCUser.Checked = true;
        }
        else
        {
            CheckBoxQCAdmin.Checked = false;
            CheckBoxQCUser.Checked = false;
        }

        if (permission == "1")
        {
            btnSave.Enabled = false;
            CheckBoxQCAdmin.Enabled = false;
            CheckBoxQCUser.Enabled = false;

            CheckBoxAdmin.Visible = true;
            CheckBoxAdmin.Checked = true;

        }
        else
        {
            btnSave.Enabled = true;

            CheckBoxAdmin.Visible = false;
            CheckBoxAdmin.Checked = false;
            CheckBoxQCAdmin.Enabled = true;
            CheckBoxQCUser.Enabled = true;

        }
    }

    private string CheckPermission()
    {
        bool _qcAdmin = CheckBoxQCAdmin.Checked;
        bool _qcUser = CheckBoxQCUser.Checked;
        string permission = "";

        if (_qcAdmin && _qcUser || _qcAdmin && _qcUser == false)
        {
            permission = "2";
        }
        else if (_qcUser && _qcAdmin == false)
        {
            permission = "3";
        }
        else
        {
            permission = "";
        }

        return permission;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegisterUser.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        empInfo = hrmsSer.GetEmployeeData(txtSearch.Text);

        if (empInfo != null)
        {
            lblEmpCode.Text = empInfo.Code;
            lblEmpName.Text = empInfo.NameInEng.Name + "_" + empInfo.NameInEng.Surname;
            lblEmpSect.Text = empInfo.Division.ShortName;

            SetUserDataInfo(empInfo.Code);
        }
    }

    public void SetUserDataInfo(string id)
    {
        UserInfo usInfo = userSer.CheckUserAvailableOnSystem(id);

        if (usInfo != null)
        {
            lblEmpCode.Text = usInfo.User_code;
            lblEmpName.Text = usInfo.User_name + "_" + usInfo.User_surname;
            lblEmpSect.Text = usInfo.User_sect;

            SetOwnPermission(usInfo.User_permission);

            lblEmpStatus.Text = "USER AVAILABLE ON SYSTEM";
            lblEmpStatus.ForeColor = Color.Green;
        }
        else
        {
            SetOwnPermission("0");
            lblEmpStatus.Text = "USER NOT AVAILABLE ON SYSTEM";
            lblEmpStatus.ForeColor = Color.Red;
        }
    }

    protected void gridViewUserOnSystem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            string ID = e.CommandArgument.ToString();

            SetUserDataInfo(ID);
        }
    }
}