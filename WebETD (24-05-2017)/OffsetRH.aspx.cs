using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OffsetRH : System.Web.UI.Page
{
    private string bufId;
    OffsetMasterService offSer;
    private string _partID = "5";
    private string _partTypeID = "5";
    ArrayList _OffsetDataList;
    string[] bufSplit;
    MasterHistoryService hisSer;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        offSer = new OffsetMasterService();
        hisSer = new MasterHistoryService();

        lblRemarkError.Text = "";
        LabelErrorMasterNo.Text = "";

        if (!IsPostBack)
        {
            if ((bufId = Request.QueryString["id"]) != null)
            {
                lblStatus.Text = "(EDIT)";
                Session["editState"] = true;

                txtDelReason.Enabled = true;
                btnDelete.Enabled = true;

                txtMasterNo.Enabled = false;
                DropDownListModelName.Enabled = false;

                bufSplit = bufId.Split(',');

                txtMasterNo.Text = bufSplit[0];
                DropDownListModelName.SelectedValue = bufSplit[1];

                _partID = bufSplit[2];

                _OffsetDataList = offSer.SelectOffsetData(bufSplit[0], bufSplit[1], _partID, _partTypeID);


                int counter = 0;
                foreach (OffsetMasterInfo offsetInfo in _OffsetDataList)
                {
                    if (counter == 0)
                    {
                        txtID1.Text = offsetInfo.Offset_value.ToString();

                    }
                    else if (counter == 1)
                    {

                        txtID2.Text = offsetInfo.Offset_value.ToString();

                    }
                    else if (counter == 2)
                    {

                        txtP1.Text = offsetInfo.Offset_value.ToString();

                    }
                    else { }

                    counter++;
                }

            }
            else
            {
                lblStatus.Text = "(NEW)";
                Session["editState"] = false;

                txtMasterNo.Enabled = true;
                DropDownListModelName.Enabled = true;

                txtDelReason.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtMasterNo.Text != "" && txtID1.Text != "" && txtID2.Text != "" && txtP1.Text != "")
        {
            //insert data to database
            OffsetMasterInfo offInfo = new OffsetMasterInfo();
            offInfo.Model_id = DropDownListModelName.SelectedValue.ToString();
            offInfo.Offset_id = txtMasterNo.Text;
            offInfo.Part_id = _partID;
            offInfo.PartType_id = _partTypeID;
            offInfo.Offset_user = Session["userName"].ToString();

            if (Convert.ToBoolean(Session["editState"]) == false)
            {
                for (int i = 0; i < 3; i++)
                {
                    offInfo.Offset_point = i;

                    if (i == 0)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtID1.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            txtID1.Text = "";
                        }

                    }
                    else if (i == 1)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtID2.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            txtID2.Text = "";
                        }

                    }
                    else if (i == 2)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtP1.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            txtP1.Text = "";
                        }

                    }
                    else { }

                }
                txtMasterNo.Text = "";
                DropDownListModelName.SelectedIndex = 0;

                hisSer.InsertMasterHistory(offInfo.Offset_id, offInfo.Offset_user);
            }
            else
            {

                for (int i = 0; i < 3; i++)
                {
                    offInfo.Offset_point = i;

                    if (i == 0)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtID1.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            txtID1.Text = "";
                        }

                    }
                    else if (i == 1)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtID2.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            txtID2.Text = "";
                        }

                    }
                    else if (i == 2)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtP1.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            txtP1.Text = "";
                        }

                    }
                    else { }

                }

                Response.Redirect("MstMaster.aspx");
            }
        }
        else
        {
            LabelErrorMasterNo.Text = "Please complete all fields.";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MasterDetail.aspx");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (txtDelReason.Text != "")
        {
            //delete
            if (offSer.DeleteOffsetData(txtMasterNo.Text, DropDownListModelName.SelectedValue.ToString(), _partID, _partTypeID))
            {
                hisSer.UpdateMasterHistory(txtMasterNo.Text, Session["userName"].ToString(), txtDelReason.Text);
                lblRemarkError.Text = "";
                Response.Redirect("MstMaster.aspx");
            }
            else
            {
                lblRemarkError.Text = "Error!! : Can't delete data.";
            }
        }
        else
        {
            lblRemarkError.Text = "Please, Input reason to delete this master.";
        }
    }
}