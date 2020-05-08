using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelPT : System.Web.UI.Page
{
    ModelDetailService moDetailSer = new ModelDetailService();
    VIModelDetailService viModelSer = new VIModelDetailService();
    MasterModelService mmDetailSer = new MasterModelService();
    ProgramDetailTableService proEtdSer = new ProgramDetailTableService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void btnPistonSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID("011", "2");

        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = txtModelNo.Text;
            _ModelDetailInfo.Model_name = txtModelName.Text;
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

            if (!moDetailSer.InsertModelDetail(_ModelDetailInfo))
            {
                lblErrModelNo.Text = "A Duplicate Model No.";
            }
            else
            {
                lblErrModelNo.Text = "";
            }
        }
        if (lblErrModelNo.Text == "")
        {
            mmDetailSer.InsertModelDetail(_ModelDetailInfo);
            proEtdSer.InsertNewProgramDetail(_ModelDetailInfo.Model_id);
            Response.Write("<script>alert('SUCCEED!!');</script>");
            //Response.Redirect("ModelCS.aspx");
        }
    }
}