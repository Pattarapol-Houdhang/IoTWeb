using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelEditPT : System.Web.UI.Page
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
                var bufSplit = bufModelID.Split(',');
                if (bufSplit != null)
                {
                    ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "2");

                    foreach (VIModelDetailInfo dataInfo in _data)
                    {
                        //OD
                        if (dataInfo.PartType_name == "OD")
                        {
                            txtPisODCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtPisODMax.Text = dataInfo.Part_max.ToString();
                            txtPisODMid.Text = dataInfo.Part_mid.ToString();
                            txtPisODMin.Text = dataInfo.Part_min.ToString();
                            dropDownPisODRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "OD ROUNDNESS")
                        {
                            txtPisODRoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisODRoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "OD CYLINDRICITY")
                        {
                            txtPisODCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisODCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "OD PERPENDICULARITY")
                        {
                            txtPisODPerpenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisODPerpenRank.SelectedValue = dataInfo.Group_id;
                        }
                        //ID
                        else if (dataInfo.PartType_name == "ID")
                        {
                            txtPisIDCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtPisIDMax.Text = dataInfo.Part_max.ToString();
                            txtPisIDMid.Text = dataInfo.Part_mid.ToString();
                            txtPisIDMin.Text = dataInfo.Part_min.ToString();
                            dropDownPisIDRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID ROUNDNESS")
                        {
                            txtPisIDRoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisIDRoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID CYLINDRICITY")
                        {
                            txtPisIDCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisIDCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID PERPENDICULARITY")
                        {
                            txtPisIDPerpenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisIDPerpenRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID CONCENTRICITY")
                        {
                            txtPisIDConcenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisIDConcenRank.SelectedValue = dataInfo.Group_id;
                        }
                        //HEIGHT
                        else if (dataInfo.PartType_name == "HEIGHT")
                        {
                            txtPisHeightCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtPisHeightMax.Text = dataInfo.Part_max.ToString();
                            txtPisHeightMid.Text = dataInfo.Part_mid.ToString();
                            txtPisHeightMin.Text = dataInfo.Part_min.ToString();
                            dropDownPisHeightRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "HEIGHT PARALLISM")
                        {
                            txtPisHiParallismMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisHiParallismRank.SelectedValue = dataInfo.Group_id;
                        }
                        //BLADE
                        else if (dataInfo.PartType_name == "BLADE THICKNESS")
                        {
                            txtPisBLCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtBLThicknessMax.Text = dataInfo.Part_max.ToString();
                            txtBLThicknessMid.Text = dataInfo.Part_mid.ToString();
                            txtBLThicknessMin.Text = dataInfo.Part_min.ToString();
                            dropDownBLThicknessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BLADE PARALLISM")
                        {
                            txtBLParallismMid.Text = dataInfo.Part_mid.ToString();
                            dropDownBLParallismRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "BLADE PERPENDICULARITY")
                        {
                            txtBLPerpenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownBLPerpenRank.SelectedValue = dataInfo.Group_id;
                        }
                        //FLATNESS
                        else if (dataInfo.PartType_name == "FLATNESS 1")
                        {
                            txtPisFLCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtPisFlatnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownPisFlatnessRank.SelectedValue = dataInfo.Group_id;
                        }
                    }
                }
            }
        }
    }
    protected void btnPistonSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        bufModelID = Request.QueryString["id"];
        var bufSplit = bufModelID.Split(',');
        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "2");

        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = bufSplit[0].ToString();
            _ModelDetailInfo.Part_id = dataInfo.Part_id;
            _ModelDetailInfo.PartType_id = dataInfo.PartType_id;
            _ModelDetailInfo.Part_status = true;
            _ModelDetailInfo.User_edit = Session["userName"].ToString();
            //OD
            if (dataInfo.PartType_name == "OD")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtPisODCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtPisODMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisODMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtPisODMin.Text);
                _ModelDetailInfo.Rank_id = dropDownPisODRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "OD CYLINDRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisODCylindricMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisODCylindricRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "OD ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisODRoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisODRoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "OD PERPENDICULARITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisODPerpenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisODPerpenRank.SelectedValue;
            }
            //ID
            else if (dataInfo.PartType_name == "ID")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtPisIDCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtPisIDMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisIDMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtPisIDMin.Text);
                _ModelDetailInfo.Rank_id = dropDownPisIDRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "ID CYLINDRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisIDCylindricMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisIDCylindricRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "ID ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisIDRoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisIDRoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "ID PERPENDICULARITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisIDPerpenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisIDPerpenRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "ID CONCENTRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisIDConcenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisIDConcenRank.SelectedValue;
            }
            //HEIGHT
            else if (dataInfo.PartType_name == "HEIGHT")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtPisHeightCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtPisHeightMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisHeightMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtPisHeightMin.Text);
                _ModelDetailInfo.Rank_id = dropDownPisHeightRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "HEIGHT PARALLISM")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisHiParallismMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisHiParallismRank.SelectedValue;
            }
            //BLADE
            else if (dataInfo.PartType_name == "BLADE THICKNESS")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtPisBLCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtBLThicknessMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtBLThicknessMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtBLThicknessMin.Text);
                _ModelDetailInfo.Rank_id = dropDownBLThicknessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BLADE PARALLISM")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtBLParallismMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownBLParallismRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "BLADE PERPENDICULARITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtBLPerpenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownBLPerpenRank.SelectedValue;
            }
            //FLATNESS
            else if (dataInfo.PartType_name == "FLATNESS 1")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtPisFLCycleTime.Text);
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtPisFlatnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownPisFlatnessRank.SelectedValue;
            }

            moDetailSer.UpdateModelDetail(_ModelDetailInfo);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MstModel.aspx");
    }
}