using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_QCSamplingMaster_Detail : System.Web.UI.Page
{
    ConnectDB oConn = new ConnectDB();
    ConnectDBSCM oConnSCM = new ConnectDBSCM();
    CGenControl oGenCon = new CGenControl();
    MDUserLoginData UserData = new MDUserLoginData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialControl();
        }
        if (Request.QueryString["ID"] != null && ViewState["IsAlreadyLoad"] == null)
        {
            ViewState["ID"] = Request.QueryString["ID"];
            LoadEditData();
            ViewState["IsAlreadyLoad"] = true;
        }
        else
        {
            if (!GetPermission())
            {
                Response.Redirect("http://websrv01.dci.daikin.co.jp/iotweb/");
            }
        }

    }
    private bool GetPermission()
    {
        MDUserLoginData UserData = new MDUserLoginData();
        UserData = (MDUserLoginData)Session["UserLoginData"];
        if (UserData == null)
        {
            return false;
        }
        foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
        {
            if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11 || UsrGroup.GroupID == 1 || UsrGroup.GroupID == 2)
            {
                return true;
            }
        }
        return false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlSubPoint.SelectedValue == "")
        {
            string display = "กรุณาเลือก Sub-Point.";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
            return;
        }
        SqlCommand sql = new SqlCommand();
        SqlCommand sqlLog = new SqlCommand();
        if (ViewState["ID"] == null)
        {
            //add
            sql.CommandText = @"insert into [QC_StandardMaster]([PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy]
                            ,[UpdateDate]) values(@Part,@ModelCode,@MainPoint,@SubPoint,@MQMin,@MQMax,@UCL,@CL,@LCL,@User,@InsertDate)";


            ////LOG
            sqlLog.CommandText = @"insert into [QC_StandardMaster_Log]([QCMasterID],[Operation],[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy]
                                ,[UpdateDate]) values((select top (1) [ID] from QC_StandardMaster order by UpdateDate desc )
                                ,@Operation,@Part,@ModelCode,@MainPoint,@SubPoint,@MQMin,@MQMax,@UCL,@CL,@LCL,@User,@InsertDate)";


            sqlLog.Parameters.Add(new SqlParameter("@Operation", "Insert"));
        }
        else
        {//update
            ////LOG
            sqlLog.CommandText = @"insert into [QC_StandardMaster_Log]([QCMasterID],[Operation],[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy]
                                ,[UpdateDate]) values(@ID,@Operation,@Part,@ModelCode,@MainPoint,@SubPoint,@MQMin,@MQMax,@UCL,@CL,@LCL,@User,@InsertDate)";

            sqlLog.Parameters.Add(new SqlParameter("@ID", ViewState["ID"].ToString()));
            sqlLog.Parameters.Add(new SqlParameter("@Operation", "Update"));

            ////UPDATE
            sql.CommandText = @"UPDATE QC_StandardMaster SET  MQMin = @MQMin, MQMax = @MQMax, UCL = @UCL, CL = @CL, LCL = @LCL,[UpdateBy] = @User,[UpdateDate] = @InsertDate
                                where ID = @ID";
            sql.Parameters.Add(new SqlParameter("@ID", ViewState["ID"].ToString()));
        }

        sql.Parameters.Add(new SqlParameter("@Part", ddlPart.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@MainPoint", ddlMainPoint.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@SubPoint", ddlSubPoint.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@MQMin", txtMQMin.Text));
        sql.Parameters.Add(new SqlParameter("@MQMax", txtMQMax.Text));
        sql.Parameters.Add(new SqlParameter("@UCL", txtUCL.Text));
        sql.Parameters.Add(new SqlParameter("@CL", txtCL.Text));
        sql.Parameters.Add(new SqlParameter("@LCL", txtLCL.Text));
        sql.Parameters.Add(new SqlParameter("@User", Session["UserName"]));
        sql.Parameters.Add(new SqlParameter("@InsertDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        oConn.Query(sql);

        ////LOG
        sqlLog.Parameters.Add(new SqlParameter("@Part", ddlPart.SelectedValue));
        sqlLog.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
        sqlLog.Parameters.Add(new SqlParameter("@MainPoint", ddlMainPoint.SelectedValue));
        sqlLog.Parameters.Add(new SqlParameter("@SubPoint", ddlSubPoint.SelectedValue));
        sqlLog.Parameters.Add(new SqlParameter("@MQMin", txtMQMin.Text));
        sqlLog.Parameters.Add(new SqlParameter("@MQMax", txtMQMax.Text));
        sqlLog.Parameters.Add(new SqlParameter("@UCL", txtUCL.Text));
        sqlLog.Parameters.Add(new SqlParameter("@CL", txtCL.Text));
        sqlLog.Parameters.Add(new SqlParameter("@LCL", txtLCL.Text));
        sqlLog.Parameters.Add(new SqlParameter("@User", Session["UserName"]));
        sqlLog.Parameters.Add(new SqlParameter("@InsertDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        oConn.Query(sqlLog);


        Response.Redirect("QCSamplingMaster.aspx?PartType=" + ddlPart.SelectedValue + "&Success=true");
    }
    protected void DropDownListMain_Point_SelectedIndexChanged(object sender, EventArgs e)
    {
        oGenCon.GenDDLMainPointByPartType(CGeneral.TypeSelect.Selected, ddlMainPoint, ddlPart.SelectedValue);
        oGenCon.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.Selected, ddlSubPoint, ddlPart.SelectedValue, ddlMainPoint.SelectedValue);
    }
    protected void DropDownListSub_Point_SelectedIndexChanged(object sender, EventArgs e)
    {
        oGenCon.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.Selected, ddlSubPoint, ddlPart.SelectedValue, ddlMainPoint.SelectedValue);
    }
    private void InitialControl()
    {
        oGenCon.GenDDLMainPointByPartType(CGeneral.TypeSelect.Selected, ddlMainPoint, ddlPart.SelectedValue);
        oGenCon.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.Selected, ddlSubPoint, ddlPart.SelectedValue, ddlMainPoint.SelectedValue);
        ddlModel_SelectedIndexChanged();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {

        Response.Redirect("QCSamplingMaster.aspx?PartType=" + ddlPart.SelectedValue);
    }
    protected void ddlModel_SelectedIndexChanged()
    {
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT [ModelCode],[Model] FROM [dbSCM].[dbo].[PN_Compressor] where Line = 6";
        dTable = oConnSCM.Query(sql);

        ddlModel.Items.Clear();
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                ddlModel.Items.Add(new ListItem(row["Model"].ToString(), row["ModelCode"].ToString()));
            }
        }
    }
    private void LoadEditData()
    {

        SqlCommand sql = new SqlCommand();
        sql.CommandText = @"SELECT [ID],[PartType],[Model],[MainPoint],[SubPoint],[MQMin],[MQMax],[UCL],[CL],[LCL],[UpdateBy],[UpdateDate]
                            FROM [dbIoT].[dbo].[QC_StandardMaster] 
                               where ID = @ID order by UpdateDate desc";

        sql.Parameters.Add(new SqlParameter("@ID", ViewState["ID"].ToString()));
        DataTable dDataTable = new DataTable();
        dDataTable = oConn.Query(sql);
        foreach (DataRow row in dDataTable.Rows)
        {
            oGenCon.GenDDLMainPointByPartType(CGeneral.TypeSelect.Selected, ddlMainPoint, row["PartType"].ToString());
            oGenCon.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.Selected, ddlSubPoint, row["PartType"].ToString(), row["MainPoint"].ToString());


            ddlPart.SelectedValue = row["PartType"].ToString();
            ddlModel.SelectedValue = row["Model"].ToString();
            ddlMainPoint.Items.FindByValue(row["MainPoint"].ToString()).Selected = true;
            ddlSubPoint.Items.FindByValue(row["SubPoint"].ToString()).Selected = true;
            txtMQMin.Text = row["MQMin"].ToString();
            txtMQMax.Text = row["MQMax"].ToString();
            txtUCL.Text = row["UCL"].ToString();
            txtCL.Text = row["CL"].ToString();
            txtLCL.Text = row["LCL"].ToString();

            ddlPart.Enabled = false;
        }
    }
}