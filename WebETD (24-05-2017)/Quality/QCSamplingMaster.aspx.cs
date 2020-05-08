using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QCSamplingMaster : System.Web.UI.Page
{
    GVSorting gSorting1 = new GVSorting();
    CGenControl oGenCon = new CGenControl();
    ConnectDB oConn = new ConnectDB();
    MDUserLoginData UserData = new MDUserLoginData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["PartType"] != null && GetPermission())
        {
            ViewState["PartType"] = Request.QueryString["PartType"];
            lbPartType.Text = ViewState["PartType"].ToString().Replace("_", " ");
            ViewState["Success"] = Request.QueryString["Success"];

        }
        else
        {
            Response.Redirect("http://localhost:56209/Default.aspx");
        }
        if (!IsPostBack )
        {
            InitialControl();
            LoadData();
            ShowSaveSuccess();
        }
    }
    private bool GetPermission()
    {
        MDUserLoginData UserData = new MDUserLoginData();
        UserData = (MDUserLoginData)Session["UserLoginData"];
        if (UserData==null)
        {
            return false;
        }
        foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
        {
            if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11)
            {
                return true;
                
            }
        }
        return false;
    }

    private void InitialControl()
    {
        Session["gSorting1"] = gSorting1;
        oGenCon.GenDDLMainPointByPartType(CGeneral.TypeSelect.All, ddlMainPoint, ViewState["PartType"].ToString());
        oGenCon.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.All, ddlSubPoint, ViewState["PartType"].ToString(), ddlMainPoint.SelectedValue);
        //LoadData();
    }

    //protected void DropDownListMain_Point_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    oGenCon.GenDDLMainPointByPartType(CGeneral.TypeSelect.Selected, ddlMainPoint, ViewState["PartType"].ToString());
    //}
    protected void DropDownListSub_Point_SelectedIndexChanged(object sender, EventArgs e)
    {

        oGenCon.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.All, ddlSubPoint, ViewState["PartType"].ToString(), ddlMainPoint.SelectedValue);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
            Response.Redirect("QCSamplingMaster_Detail.aspx");
        

    }
    private void LoadData()
    {

        DataTable dTable = new DataTable();
        dTable.TableName = "QC Sampling";
        dTable.Columns.Add("CanEdit", typeof(bool));
        dTable.Columns.Add("CanDel", typeof(bool));
        dTable.Columns.Add("ID", typeof(string));
        dTable.Columns.Add("ModelCode", typeof(string));
        dTable.Columns.Add("MainPoint", typeof(string));
        dTable.Columns.Add("SubPoint", typeof(string));
        dTable.Columns.Add("MQMin", typeof(string));
        dTable.Columns.Add("MQMax", typeof(string));
        dTable.Columns.Add("UCL", typeof(string));
        dTable.Columns.Add("CL", typeof(string));
        dTable.Columns.Add("LCL", typeof(string));
        dTable.Columns.Add("UpdateBy", typeof(string));
        dTable.Columns.Add("UpdateDate", typeof(DateTime));
        DataTable dDataTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        if (ddlMainPoint.Text != "" && ddlSubPoint.Text != "")
        {
            sql.CommandText = @"SELECT [ID],[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy],[UpdateDate]
                            FROM [dbIoT].[dbo].[QC_StandardMaster] 
                               where PartType = @part and MainPoint = @MainPoint and SubPoint = @SubPoint order by UpdateDate desc";

            sql.Parameters.Add(new SqlParameter("@Part", ViewState["PartType"].ToString()));
            sql.Parameters.Add(new SqlParameter("@MainPoint", ddlMainPoint.SelectedValue));
            sql.Parameters.Add(new SqlParameter("@SubPoint", ddlSubPoint.SelectedValue));

        }
        else if (ddlMainPoint.Text != "" && ddlSubPoint.Text == "")
        {
            sql.CommandText = @"SELECT [ID],[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy],[UpdateDate]
                            FROM [dbIoT].[dbo].[QC_StandardMaster] 
                               where PartType = @part and MainPoint = @MainPoint order by UpdateDate desc";

            sql.Parameters.Add(new SqlParameter("@Part", ViewState["PartType"].ToString()));
            sql.Parameters.Add(new SqlParameter("@MainPoint", ddlMainPoint.SelectedValue));
        }
        else
        {
            sql.CommandText = @"SELECT [ID],[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy],[UpdateDate]
                            FROM [dbIoT].[dbo].[QC_StandardMaster] 
                               where PartType = @part order by UpdateDate desc";

            sql.Parameters.Add(new SqlParameter("@Part", ViewState["PartType"].ToString()));
        }
        dDataTable = oConn.Query(sql);



        if (dDataTable.Rows.Count > 0)
        {

            foreach (DataRow row in dDataTable.Rows)
            {
                DataRow dRow;
                dRow = dTable.NewRow();
                dRow["CanEdit"] = true;
                dRow["CanDel"] = true;
                dRow["ID"] = row["ID"].ToString();
                dRow["ModelCode"] = row["Model"].ToString();
                dRow["MainPoint"] = row["MainPoint"].ToString();
                dRow["SubPoint"] = row["SubPoint"].ToString();
                dRow["MQMin"] = row["MQMin"].ToString();
                dRow["MQMax"] = row["MQMax"].ToString();
                dRow["UCL"] = row["UCL"].ToString();
                dRow["CL"] = row["CL"].ToString();
                dRow["LCL"] = row["LCL"].ToString();
                dRow["UpdateBy"] = row["UpdateBy"].ToString();
                dRow["UpdateDate"] = row["UpdateDate"].ToString();
                dTable.Rows.Add(dRow);
            }
        }
        else
        {
            DataRow dRow;
            dRow = dTable.NewRow();
            dRow["CanEdit"] = false;
            dRow["candel"] = false;
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



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Editing" )
        {
            Response.Redirect("QCSamplingMaster_Detail.aspx?ID=" + e.CommandArgument);
        }
        else if (e.CommandName == "Deleting" )
        {
            //// LOG
            SqlCommand sqlLog = new SqlCommand();
            sqlLog.CommandText = @"insert into [QC_StandardMaster_Log]([QCMasterID],[Operation],[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy]
                                ,[UpdateDate]) (select top (1) ID,'Delete',[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL] ,@User,@UpdateDate
                                 from QC_StandardMaster where ID = @ID ) ";
            sqlLog.Parameters.Add(new SqlParameter("@ID", e.CommandArgument));
            sqlLog.Parameters.Add(new SqlParameter("@User", Session["UserName"].ToString()));
            sqlLog.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            oConn.Query(sqlLog);
            //DELETE
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"delete from [QC_StandardMaster] where ID = @ID";
            sql.Parameters.Add(new SqlParameter("@ID", e.CommandArgument));
            oConn.Query(sql);
            LoadData();
        }
    }
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataView dView = new DataView();
        gSorting1 = (GVSorting)Session["gSorting1"];
        gSorting1.SetSorting(e.SortExpression);
        Session["gSorting1"] = gSorting1;

    }
    private void ShowSaveSuccess()
    {
        if (ViewState["Success"] != null)
        {
            string display = "บันทึกข้อมูลสำเร็จ";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadData();
    }
}