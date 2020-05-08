using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelFH : System.Web.UI.Page
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
    protected void btnFHSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID("011", "4");

        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = txtModelNo.Text;
            _ModelDetailInfo.Model_name = txtModelName.Text;
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