using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelRH : System.Web.UI.Page
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
    protected void btnRHSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID("011", "5");

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
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtRHCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtRHIDMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtRHIDMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtRHIDMin.Text);
                _ModelDetailInfo.Rank_id = dropDownRHIDRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "ID CYLINDRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtRHIDCylindricMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownRHIDCylindricRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "ID ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtRHIDRoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownRHIDRoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "ID PERPENDICULARITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtRHIDPerpenMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownRHIDPerpenRank.SelectedValue;
            }            
            //FLATNESS
            else if (dataInfo.PartType_name == "FLATNESS 1")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtRHIDFlatnessCycleTime.Text);
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtRHFlatness1Mid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownRHFlatness1Rank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "FLATNESS 2")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtRHIDFlatnessCycleTime.Text);
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtRHFlatness2Mid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownRHFlatness2Rank.SelectedValue;
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