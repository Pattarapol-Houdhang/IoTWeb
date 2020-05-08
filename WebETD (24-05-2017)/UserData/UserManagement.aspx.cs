using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserData_UserManagement : System.Web.UI.Page
{
    GVSorting gSorting1 = new GVSorting();
    CUserLoginData oUser = new CUserLoginData();
    CNotify oNotify = new CNotify();
    CLogData oLog = new CLogData();
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check Login
        if (Session["UserLoginData"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            InitialValiable();
            LoadGrid();

            if (Session["UserAddStatus"] != null)
            {
                string result = (string)Session["UserAddStatus"];
                string[] status = result.Split(',');
                if (status[0] == "Success")
                {
                    string jquery = oNotify.GetNotifyAutoHide("Success", "Add new user " + status[1] + " finish.", CGeneral.NotifyType.Success);
                    ClientScript.RegisterStartupScript(typeof(Page), "a key",
                         "<script type=\"text/javascript\">" + jquery + "</script>"
                         );
                }
                else
                {
                    string jquery = oNotify.GetNotifyAutoHide("Failed!", "Add new user " + status[1]
                        + " Failed!! Please check at LogID=" + status[2] + "", CGeneral.NotifyType.Error);
                    ClientScript.RegisterStartupScript(typeof(Page), "a key",
                         "<script type=\"text/javascript\">" + jquery + "</script>"
                         );
                }
            }
            Session["UserAddStatus"] = null;
        }
    }

    private void InitialValiable()
    {
        Session["gSorting1"] = gSorting1;
    }

    private void LoadGrid()
    {
        DataTable dTable = new DataTable();
        dTable.TableName = "UserList";
        dTable.Columns.Add("username");
        dTable.Columns.Add("firstname");
        dTable.Columns.Add("lastname");
        dTable.Columns.Add("empCode");
        dTable.Columns.Add("department");
        dTable.Columns.Add("position");
        dTable.Columns.Add("email");
        dTable.Columns.Add("active");
        dTable.Columns.Add("createby");
        dTable.Columns.Add("createdate");
        dTable.Columns.Add("updateby");
        dTable.Columns.Add("updatedate");
        dTable.Columns.Add("CanEdit", typeof(bool));
        dTable.Columns.Add("CanDel", typeof(bool));

        MDUserLoginData oMDUser = new MDUserLoginData();
        oMDUser = oUser.GetUser(txtSearch.Text.Trim());

        if (oMDUser.ListOfUser.Count > 0)
        {
            for (int i = 0; i < oMDUser.ListOfUser.Count; i++)
            {
                DataRow dRow;
                dRow = dTable.NewRow();
                dRow["username"] = oMDUser.ListOfUser[i].Username;
                dRow["firstname"] = oMDUser.ListOfUser[i].firstname;
                dRow["lastname"] = oMDUser.ListOfUser[i].lastname;
                dRow["empCode"] = oMDUser.ListOfUser[i].empCode;
                dRow["department"] = oMDUser.ListOfUser[i].department;
                dRow["position"] = oMDUser.ListOfUser[i].position;
                dRow["email"] = oMDUser.ListOfUser[i].email;
                dRow["active"] = oMDUser.ListOfUser[i].active == "1" ? "Active" : "Inactive";
                dRow["createby"] = oMDUser.ListOfUser[i].createby;
                dRow["createdate"] = oMDUser.ListOfUser[i].createdate;
                dRow["updateby"] = oMDUser.ListOfUser[i].updateby;
                dRow["updatedate"] = oMDUser.ListOfUser[i].updatedate;
                dRow["CanEdit"] = true;
                dRow["CanDel"] = true;
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Editing")
        {
            Response.Redirect("~/UserData/UserManagement_Detail.aspx?username=" + e.CommandArgument.ToString());
        }
        else if(e.CommandName == "Deleting")
        {
            oUser.DeleteUser(e.CommandArgument.ToString());

            string QError = "";
            if (Session["QueryError"] != null)
            {
                QError = (string)Session["QueryError"];
                Session["QueryError"] = null;
            }

            string username = "";
            MDUserLoginData oMDUser = new MDUserLoginData();
            if (Session["UserLoginData"] != null)
            {
                oMDUser = (MDUserLoginData)Session["UserLoginData"];
                if (oMDUser.ListOfUser.Count > 0)
                {
                    username = oMDUser.ListOfUser[0].Username;
                }
            }

            if (QError == "")
            {
                string LogID = "";
                oLog.InsertLog("Delete UserList username=" + e.CommandArgument.ToString() + " by Username: " + username, "/UserData/UserManagement.aspx");
                string jquery = oNotify.GetNotifyAutoHide("Success", "Delete Data Success " + e.CommandArgument.ToString() + " Success", CGeneral.NotifyType.Success);
                ClientScript.RegisterStartupScript(typeof(Page), "a key",
                     "<script type=\"text/javascript\">" + jquery + "</script>"
                     );
                //Session["UserAddStatus"] = "Success," + txtUsername.Text.Trim() + "," + LogID + "";
            }
            else
            {

                string LogID = "";
                LogID = oLog.InsertLog("Failed!! Delete UserList username=" + e.CommandArgument.ToString() + " by Username: "+ username +" Error Detail=" + QError, "/UserData/UserManagement.aspx");
                string jquery = oNotify.GetNotifyAutoHide("Failed!", "Delete Data Failed " + e.CommandArgument.ToString()
                       + " Failed!! Please check at LogID=" + LogID + "", CGeneral.NotifyType.Error);
                ClientScript.RegisterStartupScript(typeof(Page), "a key",
                     "<script type=\"text/javascript\">" + jquery + "</script>"
                     );
                //Session["UserAddStatus"] = "Failed," + txtUsername.Text.Trim() + "," + LogID + "";
            }

            LoadGrid();
        }
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView dView = new DataView();
        gSorting1 = (GVSorting)Session["gSorting1"];
        gSorting1.SetSorting(e.SortExpression);
        Session["gSorting1"] = gSorting1;
        LoadGrid();
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }

    protected void btAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserData/UserManagement_Detail.aspx");
    }


    protected void btImport_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserData/ImportUser.aspx");
    }

}