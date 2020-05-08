using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelEditCY : System.Web.UI.Page
{
    VIModelDetailService viModelSer = new VIModelDetailService();
    ModelDetailService moDetailSer = new ModelDetailService();
    string bufModelID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {
            if ((bufModelID = Request.QueryString["id"]) != null)
            {
                //Session["editState"] = true;
                var bufSplit = bufModelID.Split(',');

                if (bufSplit != null)
                {
                    ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "3");

                    foreach (VIModelDetailInfo dataInfo in _data)
                    {
                        if (dataInfo.PartType_name == "BORE ID")
                        {
                            txtCYIDBoreCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtCYIDBOMax.Text = dataInfo.Part_max.ToString();
                            txtCYIDBOMid.Text = dataInfo.Part_mid.ToString();
                            txtCYIDBOMin.Text = dataInfo.Part_min.ToString();
                            dropDownCYIDBORank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BORE ID ROUNDNESS")
                        {
                            txtCYIDBORoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCYIDBORoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BORE ID CYLINDRICITY")
                        {
                            txtCYIDBOCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCYIDBOCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BORE ID PERPENDICULARITY")
                        {
                            txtCYIDBOPerpenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCYIDBOPerpenRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BORE ID CONCENTRICITY")
                        {
                            txtCYIDBOConcenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCYIDBOConcenRank.SelectedValue = dataInfo.Group_id;
                        }

                        else if (dataInfo.PartType_name == "HEIGHT")
                        {
                            txtCYHeightCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtCYHeightMax.Text = dataInfo.Part_max.ToString();
                            txtCYHeightMid.Text = dataInfo.Part_mid.ToString();
                            txtCYHeightMin.Text = dataInfo.Part_min.ToString();
                            dropDownCYHeightRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "HEIGHT PARALLISM")
                        {
                            txtCYParallismMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCYParallismRank.SelectedValue = dataInfo.Group_id;
                        }

                        else  if (dataInfo.PartType_name == "BUSH ID")
                        {
                            txtCYIDBushCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtCYIDBUMax.Text = dataInfo.Part_max.ToString();
                            txtCYIDBUMid.Text = dataInfo.Part_mid.ToString();
                            txtCYIDBUMin.Text = dataInfo.Part_min.ToString();
                            dropDownCYIDBURank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BUSH ID ROUNDNESS")
                        {
                            txtCYIDBURoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCYIDBURoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BUSH ID PERPENDICULARITY")
                        {
                            txtCYIDBUPerpenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCYIDBUPerpenRank.SelectedValue = dataInfo.Group_id;
                        }
                    }
                }
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MstModel.aspx");
    }
    protected void btnCylinderSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        bufModelID = Request.QueryString["id"];
        var bufSplit = bufModelID.Split(',');
        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "3");

        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = bufSplit[0].ToString();
            _ModelDetailInfo.Part_id = dataInfo.Part_id;
            _ModelDetailInfo.PartType_id = dataInfo.PartType_id;
            _ModelDetailInfo.Part_status = true;
            _ModelDetailInfo.User_edit = Session["userName"].ToString();
            //ID BORE
            if (dataInfo.PartType_name == "BORE ID")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtCYIDBoreCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtCYIDBOMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBOMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtCYIDBOMin.Text);
                _ModelDetailInfo.Rank_id = dropDownCYIDBORank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BORE ID CYLINDRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBOCylindricMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCYIDBOCylindricRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BORE ID ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBORoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCYIDBORoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BORE ID PERPENDICULARITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBOPerpenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCYIDBOPerpenRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BORE ID CONCENTRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBOConcenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCYIDBOConcenRank.SelectedValue;
            }
            //ID BUSH
            if (dataInfo.PartType_name == "BUSH ID")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtCYIDBushCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtCYIDBUMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBUMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtCYIDBUMin.Text);
                _ModelDetailInfo.Rank_id = dropDownCYIDBURank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BUSH ID ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBURoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCYIDBURoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BUSH ID PERPENDICULARITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYIDBUPerpenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCYIDBUPerpenRank.SelectedValue;
            }
            //HEIGHT
            else if (dataInfo.PartType_name == "HEIGHT")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtCYHeightCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtCYHeightMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYHeightMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtCYHeightMin.Text);
                _ModelDetailInfo.Rank_id = dropDownCYHeightRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "HEIGHT PARALLISM")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCYParallismMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCYParallismRank.SelectedValue;
            }

            moDetailSer.UpdateModelDetail(_ModelDetailInfo);

        }


    }
}