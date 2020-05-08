using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelEditFH : System.Web.UI.Page
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
                    ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "4");

                    foreach (VIModelDetailInfo dataInfo in _data)
                    {
                        if (dataInfo.PartType_name == "ID")
                        {
                            txtFHCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtFHIDMax.Text = dataInfo.Part_max.ToString();
                            txtFHIDMid.Text = dataInfo.Part_mid.ToString();
                            txtFHIDMin.Text = dataInfo.Part_min.ToString();
                            dropDownFHIDRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID ROUNDNESS")
                        {
                            txtFHIDRoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHIDRoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID CYLINDRICITY")
                        {
                            txtFHIDCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHIDCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID PERPENDICULARITY")
                        {
                            txtFHIDPerpenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHIDPerpenRank.SelectedValue = dataInfo.Group_id;
                        }
                        //ROUGH
                        else if (dataInfo.PartType_name == "FRONT ID ROUGH")
                        {
                            txtFHIDRoughCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtFHIDRoughMax.Text = dataInfo.Part_max.ToString();
                            txtFHIDRoughMid.Text = dataInfo.Part_mid.ToString();
                            txtFHIDRoughMin.Text = dataInfo.Part_min.ToString();
                            dropDownFHIDRoughRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID ROUGH ROUNDNESS")
                        {
                            txtFHIDRoundnessRoughMid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHIDRoundnessRoughRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID ROUGH CYLINDRICITY")
                        {
                            txtFHIDCylindricRoughMid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHIDCylindricRoughRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID ROUGH PERPENDICULARITY")
                        {
                            txtFHIDPerpenRoughMid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHIDPerpenRoughRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "FLATNESS 1")
                        {
                            txtFHIDFlatnessCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtFHFlatness1Mid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHFlatness1Rank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "FLATNESS 2")
                        {
                            txtFHIDFlatnessCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtFHFlatness2Mid.Text = dataInfo.Part_mid.ToString();
                            dropDownFHFlatness2Rank.SelectedValue = dataInfo.Group_id;
                        }

                        txtFHIDConcenMid.Text = "-";
                        dropDownFHIDConcenRank.SelectedValue = "GR-1510140006";
                        txtFHIDConcenRoughMid.Text = "-";
                        dropDownFHIDConcenRoughRank.SelectedValue = "GR-1510140006";
                        
                    }
                }
            }
        }

    }
    protected void btnFHSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        bufModelID = Request.QueryString["id"];
        var bufSplit = bufModelID.Split(',');
        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "4");

            foreach (VIModelDetailInfo dataInfo in _data)
            {
                _ModelDetailInfo.Model_id = bufSplit[0].ToString();
                _ModelDetailInfo.Part_id = dataInfo.Part_id;
                _ModelDetailInfo.PartType_id = dataInfo.PartType_id;
                _ModelDetailInfo.Part_status = true;
                _ModelDetailInfo.User_edit = Session["userName"].ToString();

                if (dataInfo.PartType_name == "ID")
                {
                    _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtFHCycleTime.Text);
                    _ModelDetailInfo.Part_max = Convert.ToDouble(txtFHIDMax.Text);
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDMid.Text);
                    _ModelDetailInfo.Part_min = Convert.ToDouble(txtFHIDMin.Text);
                    _ModelDetailInfo.Rank_id = dropDownFHIDRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID CYLINDRICITY")
                {                                        
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDCylindricMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDCylindricRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID ROUNDNESS")
                {
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDRoundnessMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDRoundnessRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID PERPENDICULARITY")
                {
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDPerpenMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDPerpenRank.SelectedValue;
                }
                //ROUGH
                else if (dataInfo.PartType_name == "FRONT ID ROUGH")
                {
                    _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtFHIDRoughCycleTime.Text);
                    _ModelDetailInfo.Part_max = Convert.ToDouble(txtFHIDRoughMax.Text);
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDRoughMid.Text);
                    _ModelDetailInfo.Part_min = Convert.ToDouble(txtFHIDRoughMin.Text);
                    _ModelDetailInfo.Rank_id = dropDownFHIDRoughRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID ROUGH CYLINDRICITY")
                {
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDCylindricRoughMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDCylindricRoughRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID ROUGH ROUNDNESS")
                {
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDRoundnessRoughMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDRoundnessRoughRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID ROUGH PERPENDICULARITY")
                {
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDPerpenRoughMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDPerpenRoughRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID ROUGH CYLINDRICITY")
                {
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDRoundnessRoughMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDRoundnessRoughRank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "ID ROUGH PERPENDICULARITY")
                {
                    _ModelDetailInfo.Part_cycletime = 0;
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHIDPerpenRoughMid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHIDPerpenRoughRank.SelectedValue;
                }
                //FLATNESS
                else if (dataInfo.PartType_name == "FLATNESS 1")
                {
                    _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtFHCycleTime.Text);
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHFlatness1Mid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHFlatness1Rank.SelectedValue;
                }
                else if (dataInfo.PartType_name == "FLATNESS 2")
                {
                    _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtFHCycleTime.Text);
                    _ModelDetailInfo.Part_max = 0;
                    _ModelDetailInfo.Part_mid = Convert.ToDouble(txtFHFlatness2Mid.Text);
                    _ModelDetailInfo.Part_min = 0;
                    _ModelDetailInfo.Rank_id = dropDownFHFlatness2Rank.SelectedValue;
                }

                moDetailSer.UpdateModelDetail(_ModelDetailInfo);
            }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MstModel.aspx");
    }
}