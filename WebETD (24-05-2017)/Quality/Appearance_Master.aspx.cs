using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_Appearance_Master : System.Web.UI.Page
{
    ConnectDB oConn = new ConnectDB();
    ConnectDBSCM oConnSCM = new ConnectDBSCM();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        lbStatus.Text = "";
        lbStatus.Visible = false;
        if (!GetPermission())
        {
            //return menu
            Response.Redirect("http://localhost:56209/Default.aspx");

        }

        if (!IsPostBack)
        {
            InitialControl();
        }

    }
    public class Skills
    {

        public string Name;

    }

    public class SelectedSkills
    {

        public string Name;

    }
    private bool GetPermission()
    {
        MDUserLoginData UserData = new MDUserLoginData();
        UserData = (MDUserLoginData)Session["UserLoginData"];
        if (UserData == null)
        {
            return true;///ไม่ต้องlogin
            //return false;
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
        ddlHeader_SelectedIndexChanged();
        setDDLModel();
        ddlPoint_SelectedIndexChanged();
        if (ddlModel.SelectedValue != "All")
        {
            LoadData();
        }
        else
        {
            loadMaster();
        }
        


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }
    protected void btnAddDetail_Click(object sender, EventArgs e)
    {
        if (ddlHeader.SelectedValue != "" && ddlPoint.SelectedValue != "" && ddlPoint.SelectedValue != "+")
        {
            lbPoint.Visible = false;
            txtNewPoint.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;

            lbDetail.Visible = true;
            txtNewDetail.Visible = true;
            btnOK.Visible = true;
            btnCancel.Visible = true;

            ddlLine.Enabled = false;
            ddlModel.Enabled = false;
            ddlHeader.Enabled = false;
            ddlPoint.Enabled = false;
        }
        else
        {
            string display = "กรุณาเลือก Area หรือ Point ให้ครบ";
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlCommand sql = new SqlCommand();
        SqlCommand sqlAPM = new SqlCommand();
        SqlCommand sqlLog = new SqlCommand();
        GridView gdw = (GridView)sender;
        int rowIndex = Convert.ToInt32(e.CommandArgument);
        TextBox txtDetailEdit = (TextBox)GridView1.Rows[rowIndex].FindControl("txtDetailEdit");
        Label lbDetail = (Label)GridView1.Rows[rowIndex].FindControl("lbDetail");
        Label lbPoint = (Label)GridView1.Rows[rowIndex].FindControl("lbPoint");
        Label lbHeader = (Label)GridView1.Rows[rowIndex].FindControl("lbHeader");
        Label lbID = (Label)GridView1.Rows[rowIndex].FindControl("lbID");
        Button btnSave = (Button)GridView1.Rows[rowIndex].FindControl("btnSave");
        Button btnCancelEdit = (Button)GridView1.Rows[rowIndex].FindControl("btnCancelEdit");

        if (e.CommandName == "Editing")
        {
            gdw.Columns[8].Visible = true;
            txtDetailEdit.Visible = true;
            txtDetailEdit.Text = lbDetail.Text;
            lbDetail.Visible = false;
            btnSave.Visible = true;
            btnCancelEdit.Visible = true;

        }
        else if (e.CommandName == "Deleting")
        {
            ///Delete

            /////Master Appearance
            sql.CommandText = @"DELETE FROM Master_Appearance where ID = @ID";
            /////Master Appearance model APM
            sqlAPM.CommandText = @"DELETE FROM [Master_Appearance_Model] where [MasterID] = @ID";
            sqlAPM.Parameters.Add(new SqlParameter("@ID", lbID.Text));
            ////LOG
            sqlLog.CommandText = @"INSERT INTO [Master_Appearance_Log]([Operation],[ModelCode],[Line],[MasterID],[Header],[Point],[Detail],[UpdateBy],[UpdateDate])
                                   values(@Operater,@ModelCode,@Line,@MasterID,@Header,@Point,@NewDetail,@UpdateBy,@UpdateDate)";
            sqlLog.Parameters.Add(new SqlParameter("@Operater", "DELETE"));
            sqlLog.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
            sqlLog.Parameters.Add(new SqlParameter("@Line", ddlLine.Text));
            sqlLog.Parameters.Add(new SqlParameter("@MasterID", lbID.Text));
            sqlLog.Parameters.Add(new SqlParameter("@Header", lbHeader.Text));
            sqlLog.Parameters.Add(new SqlParameter("@Point", lbPoint.Text));
            sqlLog.Parameters.Add(new SqlParameter("@NewDetail", lbDetail.Text));
            sqlLog.Parameters.Add(new SqlParameter("@UpdateBy", Session["UserName"].ToString()));
            sqlLog.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            ///////
            sql.Parameters.Add(new SqlParameter("@ID", lbID.Text));
            sql.Parameters.Add(new SqlParameter("@UpdateBy", Session["UserName"].ToString()));
            sql.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            try
            {
                oConn.Query(sqlLog);
                oConn.Query(sql);
                oConn.Query(sqlAPM);
                ///load
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }

            lbStatus.Text = "*** ลบรายการสำเร็จแล้ว ***";
            lbStatus.Visible = true;
        }
        else if (e.CommandName == "_Save" && txtDetailEdit.Text != "")
        {
            gdw.Columns[8].Visible = false;
            txtDetailEdit.Visible = false;
            btnSave.Visible = false;
            btnCancelEdit.Visible = false;
            lbDetail.Visible = true;
            ///Update
            sql = new SqlCommand();
            sql.CommandText = @"UPDATE [dbIoT].[dbo].[Master_Appearance] SET Detail = @Detail,[UpdateBy] = @UpdateBy,[UpdateDate] = @UpdateDate where ID = @ID";
            sql.Parameters.Add(new SqlParameter("@Detail", txtDetailEdit.Text.Replace('/', '_')));
            sql.Parameters.Add(new SqlParameter("@ID", lbID.Text));
            sql.Parameters.Add(new SqlParameter("@UpdateBy", Session["UserName"].ToString()));
            sql.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            ///Log
            sqlLog.CommandText = @"INSERT INTO [Master_Appearance_Log]([Operation],[ModelCode],[Line],[MasterID],[Header],[Point],[Detail],[UpdateBy],[UpdateDate])
                                   values(@Operater,@ModelCode,@Line,@MasterID,@Header,@Point,@NewDetail,@UpdateBy,@UpdateDate)";
            sqlLog.Parameters.Add(new SqlParameter("@Operater", "UPDATE"));
            sqlLog.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
            sqlLog.Parameters.Add(new SqlParameter("@Line", ddlLine.Text));
            sqlLog.Parameters.Add(new SqlParameter("@MasterID", lbID.Text));
            sqlLog.Parameters.Add(new SqlParameter("@Header", lbHeader.Text));
            sqlLog.Parameters.Add(new SqlParameter("@Point", lbPoint.Text));
            sqlLog.Parameters.Add(new SqlParameter("@NewDetail", txtDetailEdit.Text));
            sqlLog.Parameters.Add(new SqlParameter("@UpdateBy", Session["UserName"].ToString()));
            sqlLog.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            try
            {
                oConn.Query(sqlLog);
                oConn.Query(sql);
                ///load
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
            string display = "*** แก้ไขรายการสำเร็จ ***";
            lbStatus.Text = display;
            lbStatus.Visible = true;
        }
        else if (e.CommandName == "_Cancel")
        {
            gdw.Columns[8].Visible = false;
            txtDetailEdit.Visible = false;
            btnSave.Visible = false;
            btnCancelEdit.Visible = false;
            lbDetail.Visible = true;
            ///Load
            LoadData();


        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (ddlModel.SelectedValue != "All")
        {
            LoadData();
        }
        else
        {
            loadMaster();
        }
        
    }
    protected void setDDLModel()
    {
        try
        {

            DataTable dTable = new DataTable();
            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"SELECT [ModelCode],[Model],[Line] FROM [dbSCM].[dbo].[PN_Compressor] where Line = @Line";
            sql.Parameters.Add(new SqlParameter("@Line", ddlLine.SelectedValue));
            dTable = oConnSCM.Query(sql);

            ddlModel.Items.Clear();
            if (dTable.Rows.Count > 0)
            {
                ddlModel.Items.Add(new ListItem("-All-", "All"));
                foreach (DataRow row in dTable.Rows)
                {
                    ddlModel.Items.Add(new ListItem(row["Model"].ToString(), row["ModelCode"].ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
        }
    }
    private void ddlHeader_SelectedIndexChanged()
    {
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        try
        {
            sql.CommandText = @"SELECT distinct [Header] FROM [dbIoT].[dbo].[Master_Appearance] order by Header desc ";
            dTable = oConn.Query(sql);

            ddlHeader.Items.Clear();
            if (dTable.Rows.Count > 0)
            {
                ddlHeader.Items.Add(new ListItem("-ALL-", ""));
                foreach (DataRow row in dTable.Rows)
                {
                    ddlHeader.Items.Add(new ListItem(row["Header"].ToString(), row["Header"].ToString()));
                }
            }

        }
        catch (Exception)
        {

            throw;
        }
    }
    private void ddlPoint_SelectedIndexChanged()
    {
        if (ddlHeader.SelectedValue == "")
        {
            ddlPoint.Items.Add(new ListItem("-ALL-", ""));
            return;
        }
        DataTable dTable = new DataTable();
        try
        {

            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"SELECT  distinct [Point] FROM [dbIoT].[dbo].[Master_Appearance_Model] mam
                                left join Master_Appearance ma on mam.MasterID = ma.ID
                                where Header=@Header and  ModelCode = @ModelCode";
            sql.Parameters.Add(new SqlParameter("@Header", ddlHeader.SelectedValue));
            sql.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
            dTable = oConn.Query(sql);
            ddlPoint.Items.Clear();
            if (dTable.Rows.Count > 0)
            {
                ddlPoint.Items.Add(new ListItem("-ALL-", ""));
                foreach (DataRow row in dTable.Rows)
                {
                    ddlPoint.Items.Add(new ListItem(row["Point"].ToString(), row["Point"].ToString()));
                }
                ddlPoint.Items.Add(new ListItem("+Add New Point.", "+"));
            }

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
        }
    }
    private void LoadData()
    {
        DataTable dTable = new DataTable();
        dTable.TableName = "Appearance";
        dTable.Columns.Add("CanEdit", typeof(bool));
        dTable.Columns.Add("CanDel", typeof(bool));
        dTable.Columns.Add("ID", typeof(string));
        dTable.Columns.Add("Area", typeof(string));
        dTable.Columns.Add("Point", typeof(string));
        dTable.Columns.Add("Detail", typeof(string));
        dTable.Columns.Add("UpdateBy", typeof(string));
        dTable.Columns.Add("UpdateDate", typeof(string));

        DataTable dDataTable = new DataTable();
        try
        {

            SqlCommand sql = new SqlCommand();
            if (ddlHeader.SelectedValue == "")
            {
                sql.CommandText = @"SELECT ma.* FROM [dbIoT].[dbo].[Master_Appearance_Model] mam left join Master_Appearance ma on mam.MasterID = ma.ID 
                            where ModelCode = @ModelCode and [LineNo] = @LineNo order by [UpdateDate] desc ,[Header] desc,[Point]";
            }
            else if (ddlHeader.SelectedValue != "" && ddlPoint.SelectedValue == "")
            {
                sql.CommandText = @"SELECT ma.* FROM [dbIoT].[dbo].[Master_Appearance_Model] mam left join Master_Appearance ma on mam.MasterID = ma.ID where ModelCode = @ModelCode and [LineNo] = @LineNo and Header = @Header order by [UpdateDate] desc ,[Header] desc,[Point]";
            }
            else
            {
                sql.CommandText = @"SELECT ma.* FROM [dbIoT].[dbo].[Master_Appearance_Model] mam left join Master_Appearance ma on mam.MasterID = ma.ID where ModelCode = @ModelCode and [LineNo] = @LineNo and Header = @Header  and Point = @Point order by [UpdateDate] desc ,[Header] desc,[Point]";
                sql.Parameters.Add(new SqlParameter("@Point", ddlPoint.SelectedValue));
            }
            sql.Parameters.Add(new SqlParameter("@LineNo", ddlLine.SelectedValue));
            sql.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
            sql.Parameters.Add(new SqlParameter("@Header", ddlHeader.SelectedValue));
            dDataTable = oConn.Query(sql);

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
        }

        if (dDataTable.Rows.Count > 0)
        {

            foreach (DataRow row in dDataTable.Rows)
            {
                DataRow dRow;
                dRow = dTable.NewRow();
                dRow["CanEdit"] = true;
                dRow["CanDel"] = true;

                dRow["ID"] = row["ID"];
                dRow["Area"] = row["Header"].ToString();
                dRow["Point"] = row["Point"].ToString();
                dRow["Detail"] = row["Detail"].ToString().Replace('_', '/');
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

        GridView1.DataSource = dView;
        GridView1.DataBind();
    }
    protected void ddlPoint_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlPoint_SelectedIndexChanged();
    }
    protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        setDDLModel();
    }
    protected void ddlPoint_SelectedIndexChanged2(object sender, EventArgs e)
    {
        if (ddlPoint.SelectedValue == "+")
        {
            setTxtNewPoint();
        }
        else
        {

            lbDetail.Visible = false;
            txtNewDetail.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;

            lbPoint.Visible = false;
            txtNewPoint.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;

        }
    }
    public void setTxtNewPoint()
    {
        if (ddlPoint.SelectedValue == "+")
        {
            lbDetail.Visible = false;
            txtNewDetail.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;

            lbPoint.Visible = true;
            txtNewPoint.Visible = true;
            btnOK.Visible = true;
            btnCancel.Visible = true;

            ddlLine.Enabled = false;
            ddlModel.Enabled = false;
            ddlHeader.Enabled = false;
            ddlPoint.Enabled = false;
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ////Point
        if (txtNewPoint.Visible == true && ddlHeader.SelectedValue != "" && ddlPoint.SelectedValue != "" && txtNewPoint.Text != "")
        {
            try
            {

                /////Check limit Point
                string display;
                SqlCommand sqlDetail = new SqlCommand();
                sqlDetail.CommandText = @"SELECT  distinct [Point] FROM [dbIoT].[dbo].[Master_Appearance_Model] mam
                                        left join Master_Appearance ma on mam.MasterID = ma.ID
                                        where Header=@Header and  ModelCode = @ModelCode and [LineNo] = @LineNo ";
                sqlDetail.Parameters.Add(new SqlParameter("@Header", ddlHeader.SelectedValue));
                sqlDetail.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
                sqlDetail.Parameters.Add(new SqlParameter("@LineNo", ddlLine.Text));
                DataTable dTableDetail = new DataTable();
                dTableDetail = oConn.Query(sqlDetail);
                if (dTableDetail.Rows.Count >= 14)
                {
                    display = "เกินจำนวนที่สามารถเพิ่มได้แล้ว กรุณาติดต่อแผนก IT.";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                    return;
                }
                //add new point
                ddlPoint.Items.RemoveAt(ddlPoint.Items.Count - 1);
                ddlPoint.Items.Add(new ListItem(txtNewPoint.Text, txtNewPoint.Text));
                ddlPoint.Items.Add(new ListItem("+Add New Point.", "+"));
                setTxtAndBtnAndLbNew();

                display = "เพิ่ม Point ใหม่สำเร็จ";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
            }

        }////Detail
        else if (txtNewDetail.Visible == true && txtNewDetail.Text != "")
        {

            //add new detail 
            #region
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = @"SELECT TOP (1000) [APID],[ModelCode],[ModelName],[LineNo],[MasterID],ma.Header,ma.Point,ma.Detail 
                                    FROM [dbIoT].[dbo].[Master_Appearance_Model] mam
                                    left join Master_Appearance ma on mam.MasterID = ma.ID
                                    where ModelCode = @ModelCode and [LineNo] = @LineNo and Header = @Header and Point = @Point and Detail = @Detail";
                sql.Parameters.Add(new SqlParameter("@Header", ddlHeader.SelectedValue));
                sql.Parameters.Add(new SqlParameter("@Point", ddlPoint.SelectedValue));
                sql.Parameters.Add(new SqlParameter("@Detail", txtNewDetail.Text));
                sql.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
                sql.Parameters.Add(new SqlParameter("@LineNo", ddlLine.Text));
                DataTable dTable = new DataTable();
                dTable = oConn.Query(sql);
                if (dTable.Rows.Count <= 0)
                {   ////Check limit
                    string display;
                    SqlCommand sqlDetail = new SqlCommand();
                    sqlDetail.CommandText = @"SELECT TOP (1000) [Point] FROM [dbIoT].[dbo].[Master_Appearance_Model] mam
                                        left join Master_Appearance ma on mam.MasterID = ma.ID
                                        where Header=@Header and Point = @Point and ModelCode = @ModelCode and [LineNo] = @Line";
                    sqlDetail.Parameters.Add(new SqlParameter("@Header", ddlHeader.SelectedValue));
                    sqlDetail.Parameters.Add(new SqlParameter("@Point", ddlPoint.SelectedValue));
                    sqlDetail.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
                    sqlDetail.Parameters.Add(new SqlParameter("@Line", ddlLine.Text));
                    DataTable dTableDetail = new DataTable();
                    dTableDetail = oConn.Query(sqlDetail);
                    if (dTableDetail.Rows.Count >= 14)
                    {
                        display = "เกินจำนวนที่สามารถเพิ่มได้แล้ว กรุณาติดต่อแผนก IT.";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
                        return;
                    }
                    /////INSERT INTO Master_Aperance
                    SqlCommand sqlIn = new SqlCommand();
                    sqlIn.CommandText = @"insert into [dbIoT].[dbo].[Master_Appearance](Header,Point,Detail,UpdateBy,UpdateDate) 
                                      values(@Header,@Point,@Detail,@UpDateBy,@UpDateDate)";

                    sqlIn.Parameters.Add(new SqlParameter("@Header", ddlHeader.SelectedValue));
                    sqlIn.Parameters.Add(new SqlParameter("@Point", ddlPoint.SelectedValue));
                    sqlIn.Parameters.Add(new SqlParameter("@Detail", txtNewDetail.Text.Replace('/', '_')));
                    sqlIn.Parameters.Add(new SqlParameter("@UpDateBy", Session["UserName"].ToString()));
                    sqlIn.Parameters.Add(new SqlParameter("@UpDateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    oConn.Query(sqlIn);
                    /////INSERT INTO Master_Appearance_Model
                    sqlIn = new SqlCommand();
                    sqlIn.CommandText = @"insert into [dbIoT].[dbo].[Master_Appearance_Model]([ModelCode],[ModelName],[LineNo],[MasterID],[UpdateBy],[UpdateDate]) 
                                      values(@ModelCode,@ModelName,@LineNo,(SELECT TOP (1) [ID] FROM [dbIoT].[dbo].[Master_Appearance] order by ID desc),@UpDateBy,@UpDateDate)";

                    sqlIn.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
                    sqlIn.Parameters.Add(new SqlParameter("@ModelName", ddlModel.SelectedItem.ToString()));
                    sqlIn.Parameters.Add(new SqlParameter("@LineNo", ddlLine.Text));
                    sqlIn.Parameters.Add(new SqlParameter("@UpDateBy", Session["UserName"].ToString()));
                    sqlIn.Parameters.Add(new SqlParameter("@UpDateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    oConn.Query(sqlIn);
                    /////Log
                    SqlCommand sqlLog = new SqlCommand();
                    sqlLog.CommandText = @"INSERT INTO [Master_Appearance_Log]([Operation],[ModelCode],[Line],[MasterID],[Header],[Point],[Detail],[UpdateBy],
                                        [UpdateDate]) (select top (1) @Operater,@ModelCode,@Line,ID,Header,Point,Detail,@UpdateBy,@UpdateDate from Master_Appearance where ID = 
                                    (SELECT TOP (1) [ID] FROM [dbIoT].[dbo].[Master_Appearance] order by ID desc))";
                    sqlLog.Parameters.Add(new SqlParameter("@Operater", "INSERT"));
                    sqlLog.Parameters.Add(new SqlParameter("@ModelCode", ddlModel.SelectedValue));
                    sqlLog.Parameters.Add(new SqlParameter("@Line", ddlLine.Text));
                    sqlLog.Parameters.Add(new SqlParameter("@UpdateBy", Session["UserName"].ToString()));
                    sqlLog.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                    oConn.Query(sqlLog);
                    display = "เพิ่ม Detail ใหม่สำเร็จ";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
            }
            LoadData();
            txtNewDetail.Text = "";
            //ddlLine.Enabled = true;
            //ddlModel.Enabled = true;
            //ddlHeader.Enabled = true;
            //ddlPoint.Enabled = true;
            #endregion
        }
    }
    private void setTxtAndBtnAndLbNew()
    {

        ddlPoint.SelectedValue = txtNewPoint.Text;
        lbPoint.Visible = false;
        lbDetail.Visible = false;
        txtNewPoint.Visible = false;
        txtNewDetail.Visible = false;
        btnOK.Visible = false;
        btnCancel.Visible = false;
        txtNewDetail.Text = "";
        txtNewPoint.Text = "";
        ddlLine.Enabled = true;
        ddlModel.Enabled = true;
        ddlHeader.Enabled = true;
        ddlPoint.Enabled = true;
    }
    protected void btnCancel_Click1(object sender, EventArgs e)
    {

        setTxtAndBtnAndLbNew();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            // Button btn = e.Row.FindControl("btnSave") as Button;
            // ////ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btn);
            //ScriptManager.GetCurrent(this).RegisterPostBackControl(btn);
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
        }

    }
    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlHeader.SelectedValue = "";
        ddlPoint.SelectedValue = "";
        LoadData();
    }
    private void NewModel()
    {
        ddlModel.Visible = false;
        txtModel.Visible = true;
        txtModelCode.Visible = true;
        btnSelectAll.Visible = true;

        lbA.InnerText = "Model Name";
        lbM.InnerText = "Model Code";

        lbA.Visible = true;
        lbM.Visible = true;

        btnSave.Visible = true;
        btnCan.Visible = true;

        lbP.Visible = false;

        btnSearch.Visible = false;
        btnAdd.Visible = false;
        lbPoint.Visible = false;
        lbDetail.Visible = false;
        btnOK.Visible = false;
        btnCancel.Visible = false;
        ddlHeader.Visible = false;
        ddlPoint.Visible = false;

        GridView1.Columns[0].Visible = true;
        GridView1.Columns[1].Visible = false;
        GridView1.Columns[2].Visible = false;

        btnSelectAll.Visible = true;
    }
    protected void btnNewModel_Click(object sender, EventArgs e)
    {
        GridView1.PageSize = 1000;
        NewModel();
        loadMaster();
        
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        ddlModel.Visible = true;
        txtModel.Visible = false;
        txtModelCode.Visible = false;
        btnSelectAll.Visible = false;

        lbA.InnerText = "Model";
        lbM.InnerText = "Area";


        btnSave.Visible = false;
        btnCan.Visible = false;

        lbA.Visible = true;
        lbP.Visible = true;
        btnAdd.Visible = true;
        btnSearch.Visible = true;
        ddlHeader.Visible = true;
        ddlPoint.Visible = true;
        GridView1.Columns[0].Visible = false;
        GridView1.Columns[1].Visible = true;
        GridView1.Columns[2].Visible = true;
    }
    private void loadMaster()
    {
        DataTable dTable = new DataTable();
        dTable.TableName = "Appearance";
        dTable.Columns.Add("CanEdit", typeof(bool));
        dTable.Columns.Add("CanDel", typeof(bool));
        dTable.Columns.Add("ID", typeof(string));
        dTable.Columns.Add("Area", typeof(string));
        dTable.Columns.Add("Point", typeof(string));
        dTable.Columns.Add("Detail", typeof(string));
        dTable.Columns.Add("UpdateBy", typeof(string));
        dTable.Columns.Add("UpdateDate", typeof(string));

        DataTable dDataTable = new DataTable();
        try
        {

            SqlCommand sql = new SqlCommand();
            sql.CommandText = @"SELECT * FROM [dbIoT].[dbo].[Master_Appearance]";

            dDataTable = oConn.Query(sql);

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.ToString() + "');", true);
        }

        if (dDataTable.Rows.Count > 0)
        {

            foreach (DataRow row in dDataTable.Rows)
            {
                DataRow dRow;
                dRow = dTable.NewRow();
                dRow["CanEdit"] = true;
                dRow["CanDel"] = true;

                dRow["ID"] = row["ID"];
                dRow["Area"] = row["Header"].ToString();
                dRow["Point"] = row["Point"].ToString();
                dRow["Detail"] = row["Detail"].ToString().Replace('_', '/');
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

        GridView1.DataSource = dView;
        GridView1.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<SqlCommand> oListSql = new List<SqlCommand>();

        SqlCommand sql;
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chk;
            chk = (CheckBox)row.FindControl("CheckBox1");
            Label lb1 = (Label)row.FindControl("lbID");
            if (chk.Checked)
            {
                
            sql = new SqlCommand();
            sql.CommandText = @"INSERT INTO [dbIoT].[dbo].[Master_Appearance_Model] VALUES(@ModelCode,@ModelName,@Line,@MasterID,@EmpCode,GETDATE())";
            sql.Parameters.Add(new SqlParameter("@ModelCode",txtModelCode.Text));
            sql.Parameters.Add(new SqlParameter("@ModelName", txtModel.Text));
            sql.Parameters.Add(new SqlParameter("@Line", ddlLine.SelectedValue));
            sql.Parameters.Add(new SqlParameter("@MasterID", lb1.Text));
            sql.Parameters.Add(new SqlParameter("@EmpCode", Session["UserName"].ToString()));
            oListSql.Add(sql);
            }


        }
        oConn.ExecuteCommand(oListSql);

        ddlModel.Visible = true;
        txtModel.Visible = false;
        txtModelCode.Visible = false;
        btnSelectAll.Visible = false;

        btnSave.Visible = false;
        btnCan.Visible = false;

        lbA.InnerText = "Model";
        lbM.InnerText = "Area";

        btnSearch.Visible = true;
        btnAdd.Visible = true;
        lbPoint.Visible = false;
        lbDetail.Visible = false;
        btnOK.Visible = false;
        btnCancel.Visible = false;
        ddlHeader.Visible = true;
        ddlPoint.Visible = true;

        GridView1.Columns[0].Visible = false;
        GridView1.Columns[1].Visible = true;
        GridView1.Columns[2].Visible = true;

        btnSelectAll.Visible = false;
    }
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            CheckBox chk;
            chk = (CheckBox)row.FindControl("CheckBox1");
            chk.Checked = true;


        }
    }
}