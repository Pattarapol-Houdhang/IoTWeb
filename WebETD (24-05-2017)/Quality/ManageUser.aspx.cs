using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;
using System.Drawing;
using ExtensionModule;
using UserManagementService;
using AuthenService;

public partial class ManageUser : System.Web.UI.Page
{
    GVSorting gSorting1 = new GVSorting();
    UserManagementService.UserManagementService oUser = new UserManagementService.UserManagementService();
    AuthenService.Authen oAuthen = new AuthenService.Authen();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialVariable();
            InitialControl();
            LoadGrid();
        }

    }

    private void InitialControl()
    {
        Panel1.TodisPlayNone();
        Session["gSorting1"] = gSorting1;
        //oGenControl.GetAreaCode(ddlAreaCodeModal, General.CGeneral.SelectionType.Please);
    }

    private void InitialVariable()
    {

    }

    private void LoadGrid()
    {
        MDUserLoginData oUserLoginData = new MDUserLoginData();
        DataTable dTable = new DataTable();
        dTable.TableName = "Part Package";
        dTable.Columns.Add("CanEdit", typeof(bool));
        dTable.Columns.Add("CanDel", typeof(bool));
        dTable.Columns.Add("IsActive", typeof(bool));
        dTable.Columns.Add("EmpCode", typeof(string));
        dTable.Columns.Add("Password", typeof(string));
        dTable.Columns.Add("PwdExpired", typeof(string));
        dTable.Columns.Add("PwdLastUpdate", typeof(string));
        dTable.Columns.Add("SupplierName", typeof(string));
        dTable.Columns.Add("UpdateBy", typeof(string));
        dTable.Columns.Add("UpdateDate", typeof(string));
        dTable.Columns.Add("UserID", typeof(string));
        dTable.Columns.Add("Username", typeof(string));
        dTable.Columns.Add("PwdRemaining", typeof(string));

        int Active = 2; // all
        if (rblActive.SelectedValue == "0")
        {
            Active = 0; // InActive
        }
        else if (rblActive.SelectedValue == "1")
        {
            Active = 1; // Active
        }
        else
        {
            Active = 2; // all
        }
        oUserLoginData = oUser.GetUserListAll(txtSearch.Text.Trim(), Active);

        if (oUserLoginData.ListOfUserLoginData.Length > 0)
        {
            for (int i = 0; i <= oUserLoginData.ListOfUserLoginData.Length - 1; i++)
            {
                DataRow dRow;
                dRow = dTable.NewRow();
                dRow["CanEdit"] = true;
                dRow["CanDel"] = true;
                dRow["IsActive"] = oUserLoginData.ListOfUserLoginData[i].Active;
                dRow["EmpCode"] = oUserLoginData.ListOfUserLoginData[i].EmpCode;
                //oUserLoginData.ListOfUserLoginData[i].ListOfSystem;
                //oUserLoginData.ListOfUserLoginData[i].ListOfUserInGroup;
                dRow["Password"] = oUserLoginData.ListOfUserLoginData[i].Password;
                dRow["PwdExpired"] = oUserLoginData.ListOfUserLoginData[i].PwdExpired;
                //dRow[""] = oUserLoginData.ListOfUserLoginData[i].PwdLastUpdate;
                //DateTime date = DateTime.ParseExact(oUserLoginData.ListOfUserLoginData[i].PwdLastUpdate, "dd/MM/yyyy", null);
                //TimeSpan diff = DateTime.Now - date;
                //int days = (int)Math.Abs(Math.Round(diff.TotalDays));
                //dRow["PwdRemaining"] = days.ToString();
                dRow["SupplierName"] = oUserLoginData.ListOfUserLoginData[i].SupplierName;
                //dRow["SupplierNo"] = oUserLoginData.ListOfUserLoginData[i].SupplierNo;
                dRow["UpdateBy"] = oUserLoginData.ListOfUserLoginData[i].UpdateBy;
                dRow["UpdateDate"] = oUserLoginData.ListOfUserLoginData[i].UpdateDate;
                dRow["UserID"] = oUserLoginData.ListOfUserLoginData[i].UserID;
                dRow["Username"] = oUserLoginData.ListOfUserLoginData[i].UserName;
                dTable.Rows.Add(dRow);
            }
        }
        else
        {
            DataRow dRow;
            dRow = dTable.NewRow();
            dRow["CanEdit"] = false;
            dRow["CanDel"] = false;
            dTable.Rows.Add(dRow);
        }

        DataView dView = new DataView();
        dView.Table = dTable;
        gSorting1 = (GVSorting)Session["gSorting1"];

        if (gSorting1.GetSorting() != "")
        {
            try
            {
                dView.Sort = gSorting1.GetSorting();
            }
            catch (Exception ex)
            {

            }
        }

        GridView1.DataSource = dView;
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            lbHeader.Text = "Edit Data";
            ViewState["UserID"] = Convert.ToInt32(e.CommandArgument);
            SetDataEdit(Convert.ToInt32(e.CommandArgument));
        }
        else if (e.CommandName == "Deleting")
        {
            oUser.DeleteUserList(Convert.ToInt32(e.CommandArgument));
            LoadGrid();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadGrid();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView dView = new DataView();
        gSorting1 = (GVSorting)Session["gSorting1"];
        gSorting1.SetSorting(e.SortExpression);
        Session["gSorting1"] = gSorting1;
        LoadGrid();
    }

    private void SetDataEdit(int ID)
    {
        MDUserLoginData oUserLoginData = new MDUserLoginData();
        oUserLoginData = oUser.GetUserListByID(ID);

        if (oUserLoginData.ListOfUserLoginData.Length > 0)
        {
            trPassword.Visible = false;
            trConfirmPassword.Visible = false;
            txtUsername.Text = oUserLoginData.ListOfUserLoginData[0].UserName;
            txtEmpCode.Text = oUserLoginData.ListOfUserLoginData[0].EmpCode;
            txtPwdExpried.Text = oUserLoginData.ListOfUserLoginData[0].PwdExpired.ToString();
            txtSupplierNo.Text = oUserLoginData.ListOfUserLoginData[0].SupplierName;
            if (oUserLoginData.ListOfUserLoginData[0].Active == 0)
            {
                chkActive.Checked = false;
            }
            else
            {
                chkActive.Checked = true;
            }

            ModalPopup1.Show();
        }
    }

    private void ClearData()
    {
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtEmpCode.Text = "";
        txtSupplierNo.Text = "";
        txtPwdExpried.Text = "";
        rblActive.SelectedIndex = 0;

        lbErrorModal.Text = "";
    }

    private void ClearColor()
    {
        txtUsername.BackColor = Color.White;
        txtPassword.BackColor = Color.White;
        txtConfirmPassword.BackColor = Color.White;
        txtEmpCode.BackColor = Color.White;
        txtSupplierNo.BackColor = Color.White;
        txtPwdExpried.BackColor = Color.White;
    }

    private bool CheckData()
    {
        if (txtUsername.Text.Trim() == "")
        {
            txtUsername.Focus();
            lbErrorModal.Text = "Please input username.";
            txtUsername.BackColor = Color.Pink;
            return false;
        }
        if (txtPassword.Text.Trim() == "" && ViewState["UserID"] == null)
        {
            txtPassword.Focus();
            txtPassword.Text = "";
            lbErrorModal.Text = "Please input password.";
            txtPassword.BackColor = Color.Pink;
            return false;
        }
        if (txtConfirmPassword.Text.Trim() == "" && ViewState["UserID"] == null)
        {
            txtConfirmPassword.Focus();
            txtConfirmPassword.Text = "";
            lbErrorModal.Text = "Please input confirm password.";
            txtConfirmPassword.BackColor = Color.Pink;
            return false;
        }
        if (txtPwdExpried.Text.Trim() == "")
        {
            txtPwdExpried.Text = "0";
        }

        if (ViewState["UserID"] != null)
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                txtPassword.Focus();
                lbErrorModal.Text = "Password not match!";
                txtPwdExpried.BackColor = Color.Pink;
                txtConfirmPassword.BackColor = Color.Pink;
                return false;
            }
        }

        return true;
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }
    protected void btAddNew_Click(object sender, EventArgs e)
    {
        ClearData();
        ClearColor();
        lbHeader.Text = "Add New User";
        ViewState["UserID"] = null;
        trPassword.Visible = true;
        trConfirmPassword.Visible = true;
        ModalPopup1.Show();

    }
    protected void btSaveModal_Click(object sender, EventArgs e)
    {
        if (CheckData())
        {
            int ActiveCheck = 0;
            if (chkActive.Checked)
            {
                ActiveCheck = 1;
            }
            MDUserLoginData oUserLoginData = new MDUserLoginData();
            if (Session["Login"] != null)
            {
                oUserLoginData = (MDUserLoginData)Session["Login"];
            }

            if (ViewState["UserID"] == null) // Add
            {
                string Password = "";
                Password = oAuthen.EncryptPasswordNoKey(txtPassword.Text.Trim());
                oUser.InsertUserList(txtUsername.Text.Trim(), Password, txtSupplierNo.Text.Trim()
                    , txtEmpCode.Text.Trim(), Convert.ToInt32(txtPwdExpried.Text.Trim()), ActiveCheck
                    , oUserLoginData.ListOfUserLoginData[0].UserID.ToString());

            }
            else
            {
                oUser.UpdateUserList(Convert.ToInt32(ViewState["UserID"]),txtUsername.Text.Trim(), txtSupplierNo.Text.Trim()
                    , txtEmpCode.Text.Trim(), Convert.ToInt32(txtPwdExpried.Text.Trim()), ActiveCheck
                    , oUserLoginData.ListOfUserLoginData[0].UserID.ToString());
            }
        }
        else
        {
            ModalPopup1.Show();
        }
    }
    protected void btCloseModal_Click(object sender, EventArgs e)
    {
        ModalPopup1.Hide();
    }
}