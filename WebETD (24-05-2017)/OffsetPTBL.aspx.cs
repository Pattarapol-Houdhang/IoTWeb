using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OffsetPTBL : System.Web.UI.Page
{
    private string bufId;
    OffsetMasterService offSer;
    private string _partID = "2";
    private string _partTypeID = "15";
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
                        txtOD1.Text = offsetInfo.Offset_value.ToString();

                    }
                    else if (counter == 1)
                    {

                        txtOD2.Text = offsetInfo.Offset_value.ToString();

                    }
                    else if (counter == 2)
                    {

                        txtOD3.Text = offsetInfo.Offset_value.ToString();

                    }
                    else if (counter == 3)
                    {

                        txtOD4.Text = offsetInfo.Offset_value.ToString();

                    }
                    else if (counter == 4)
                    {

                        txtPerpen.Text = offsetInfo.Offset_value.ToString();

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
        if (txtMasterNo.Text != "" && txtOD1.Text != "" && txtOD2.Text != "" && txtOD3.Text != "" && txtOD4.Text != "" && txtPerpen.Text != "")
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
                for (int i = 0; i < 5; i++)
                {
                    offInfo.Offset_point = i;

                    if (i == 0)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD1.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            offSer.InsertOffsetDataLow(offInfo);
                            txtOD1.Text = "";
                        }

                    }
                    else if (i == 1)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD2.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            offSer.InsertOffsetDataLow(offInfo);
                            txtOD2.Text = "";
                        }

                    }
                    else if (i == 2)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD3.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            offSer.InsertOffsetDataLow(offInfo);
                            txtOD3.Text = "";
                        }

                    }
                    else if (i == 3)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD4.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            offSer.InsertOffsetDataLow(offInfo);
                            txtOD4.Text = "";
                        }

                    }
                    else if (i == 4)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtPerpen.Text);
                        if (offSer.InsertOffsetData(offInfo))
                        {
                            offSer.InsertOffsetDataLow(offInfo);
                            txtPerpen.Text = "";
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

                for (int i = 0; i < 5; i++)
                {
                    offInfo.Offset_point = i;

                    if (i == 0)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD1.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            offSer.UpdateOffsetDataLow(offInfo, i);
                            txtOD1.Text = "";
                        }

                    }
                    else if (i == 1)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD2.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            offSer.UpdateOffsetDataLow(offInfo, i);
                            txtOD2.Text = "";
                        }

                    }
                    else if (i == 2)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD3.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            offSer.UpdateOffsetDataLow(offInfo, i);
                            txtOD3.Text = "";
                        }

                    }
                    else if (i == 3)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtOD4.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            offSer.UpdateOffsetDataLow(offInfo, i);
                            txtOD4.Text = "";
                        }

                    }
                    else if (i == 4)
                    {
                        offInfo.Offset_value = Convert.ToDouble(txtPerpen.Text);
                        if (offSer.UpdateOffsetData(offInfo, i))
                        {
                            offSer.UpdateOffsetDataLow(offInfo, i);
                            txtPerpen.Text = "";
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
                offSer.DeleteOffsetDataLow(txtMasterNo.Text, DropDownListModelName.SelectedValue.ToString(), _partID, _partTypeID);

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