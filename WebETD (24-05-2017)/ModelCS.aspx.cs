using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelCS : System.Web.UI.Page
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

    protected void btnCSSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID("011", "1");

        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = txtModelNo.Text;
            _ModelDetailInfo.Model_name = txtModelName.Text;
            _ModelDetailInfo.Part_id = dataInfo.Part_id;
            _ModelDetailInfo.PartType_id = dataInfo.PartType_id;
            _ModelDetailInfo.Part_status = true;
            _ModelDetailInfo.User_edit = Session["userName"].ToString();

            //FRONT OD.
            if (dataInfo.PartType_name == "FRONT OD")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtCSODCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtCSFODMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSFODMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtCSFODMin.Text);
                _ModelDetailInfo.Rank_id = dropDownCSFODRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "FRONT ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSFODRoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSFODRoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "FRONT CYLINDRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSFODCylindricMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSFODCylindricRank.SelectedValue;
            }
            //REAR OD
            else if (dataInfo.PartType_name == "REAR OD")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtCSODCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtCSRODMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSRODMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtCSRODMin.Text);
                _ModelDetailInfo.Rank_id = dropDownCSRODRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "REAR ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSRODRoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSRODRoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "REAR CYLINDRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSRODCylindricMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSRODCylindricRank.SelectedValue;
            }
            //PIN
            else if (dataInfo.PartType_name == "PIN OD")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtCSPINCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtCSPinFODMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSPinFODMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtCSPinFODMin.Text);
                _ModelDetailInfo.Rank_id = dropDownCSPinFODRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "PIN ROUNDNESS")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSPinFODRoundnessMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSPinFODRoundnessRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "PIN CYLINDRICITY")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSPinFODCylindricMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSPinFODCylindricRank.SelectedValue;
            }
            //ECC
            else if (dataInfo.PartType_name == "ECCENTRICITY")
            {
                _ModelDetailInfo.Part_cycletime = Convert.ToDouble(txtCSECCCycleTime.Text);
                _ModelDetailInfo.Part_max = Convert.ToDouble(txtCSEccFMax.Text);
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSEccFMid.Text);
                _ModelDetailInfo.Part_min = Convert.ToDouble(txtCSEccFMin.Text);
                _ModelDetailInfo.Rank_id = dropDownCSEccFRank.SelectedValue;
            }
            //RUN OUT
            else if (dataInfo.PartType_name == "FRONT RUN-OUT")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSFRunMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSFRunRank.SelectedValue;
            }
            else if (dataInfo.PartType_name == "REAR RUN-OUT")
            {
                _ModelDetailInfo.Part_cycletime = 0;
                _ModelDetailInfo.Part_max = 0;
                _ModelDetailInfo.Part_mid = Convert.ToDouble(txtCSRRunMid.Text);
                _ModelDetailInfo.Part_min = 0;
                _ModelDetailInfo.Rank_id = dropDownCSRRunRank.SelectedValue;
            }

            if(!moDetailSer.InsertModelDetail(_ModelDetailInfo))
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