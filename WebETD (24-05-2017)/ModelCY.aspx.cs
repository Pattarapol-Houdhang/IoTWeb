using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelCY : System.Web.UI.Page
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
    protected void btnCylinderSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID("011", "3");
        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = txtModelNo.Text;
            _ModelDetailInfo.Model_name = txtModelName.Text;
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