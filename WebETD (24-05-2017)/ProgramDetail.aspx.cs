using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramDetail : System.Web.UI.Page
{
    ProgramDetailService proSer = new ProgramDetailService();
    ProgramDetailTableService proEtdSer = new ProgramDetailTableService();
    MasterProgramTableService mstproEtdSer = new MasterProgramTableService();
    ModelDetailService moDetailSer = new ModelDetailService();

    string bufModelID = "";
    int proID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            int j = 0;
            DataTable mduTable = proSer.GetModelDetailByStatus();
            foreach (DataRow row in mduTable.Rows)
            {
                listBoxModel.Items.Add(new ListItem(mduTable.Rows[j]["fieldname"].ToString(), mduTable.Rows[j]["m_id"].ToString()));
                j++;
            }

            //edit
            if ((bufModelID = Request.QueryString["id"]) != null)
            {
                Session["editState"] = true;
                var bufSplit = bufModelID.Split(',');

                if (bufSplit != null)
                {
                    proID = Convert.ToInt32(bufSplit[0]);
                    txtProgramName.Text = bufSplit[1];
                }
                DataTable mdTable = proSer.GetModelDetailByProID(proID);
                int i = 0;
                foreach (DataRow row in mdTable.Rows)
                {
                    listBoxModelInProgram.Items.Add(new ListItem(mdTable.Rows[i]["fieldname"].ToString(), mdTable.Rows[i]["m_id"].ToString()));
                    i++;
                }
                
            }
            else
            {
                Session["editState"] = false;
            }
        }
        
    }

    protected void btnAddToModelInProgram_Click(object sender, EventArgs e)
    {
        if (listBoxModel.SelectedIndex != -1)
        {
            listBoxModelInProgram.ClearSelection();
            listBoxModelInProgram.Items.Add(listBoxModel.SelectedItem);
            listBoxModel.Items.Remove(listBoxModel.SelectedItem);
        }
      
    }
    protected void btnAddToModelList_Click(object sender, EventArgs e)
    {
        if (listBoxModelInProgram.SelectedIndex != -1)
        {
            listBoxModel.ClearSelection();
            listBoxModel.Items.Add(listBoxModelInProgram.SelectedItem);
            listBoxModelInProgram.Items.Remove(listBoxModelInProgram.SelectedItem);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MstProgram.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //edit
        if (Request.QueryString["id"] != null)
        {
            bufModelID = Request.QueryString["id"];
            var bufSplit = bufModelID.Split(',');
            proID = Convert.ToInt32(bufSplit[0]);

            if (txtProgramName.Text != "")
            {
                if (!mstproEtdSer.GetCheckProName(txtProgramName.Text))
                {
                    //insert&deleteProgramDetail
                    insdelProgramDetail();
                    //change program name
                    mstproEtdSer.UpdateNameMstProgram(txtProgramName.Text, proID);
                    Response.Redirect("MstProgram.aspx");
                }
                else if (txtProgramName.Text == bufSplit[1])
                {
                    //insert&deleteProgramDetail
                    insdelProgramDetail();
                    Response.Redirect("MstProgram.aspx");
                }
                else
                {

                }
            }
            else
            {

            }
        }
        else //new
        {
            if (!mstproEtdSer.GetCheckProName(txtProgramName.Text) && (txtProgramName.Text != ""))
            {
                mstproEtdSer.InsertNewMstProgram(txtProgramName.Text);
                //insert
                foreach (ListItem item in listBoxModelInProgram.Items)
                {
                    if (!proEtdSer.CheckModelIDByModelID(item.Value))
                    {
                        proID = Convert.ToInt32(mstproEtdSer.GetProID(txtProgramName.Text));
                         proEtdSer.UpdateProIDByEditPro(item.Value, proID.ToString());
                    }
                }
                Response.Redirect("MstProgram.aspx");
            }
            else
            {
                txtProgramName.Text = "";
            }

        }
    }

    private void insdelProgramDetail()
    {
        bufModelID = Request.QueryString["id"];
        var bufSplit = bufModelID.Split(',');
        proID = Convert.ToInt32(bufSplit[0]);

        //in
        foreach (ListItem item in listBoxModelInProgram.Items)
        {
            if (!proEtdSer.CheckModelIDByModelID(item.Value))
            {
                proEtdSer.UpdateProIDByEditPro(item.Value, proID.ToString());
                moDetailSer.UpdateModelStatus(true, item.Value);
            }
        }

        //out
        foreach (ListItem item in listBoxModel.Items)
        {
            if (proEtdSer.CheckModelIDByModelID(item.Value))
            {
                proEtdSer.UpdateProIDToNull(item.Value);
                moDetailSer.UpdateModelStatus(false, item.Value);
            }
        }
    }
}