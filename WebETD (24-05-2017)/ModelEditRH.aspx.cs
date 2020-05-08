using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelEditRH : System.Web.UI.Page
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
                    ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "5");

                    foreach (VIModelDetailInfo dataInfo in _data)
                    {
                        if (dataInfo.PartType_name == "ID")
                        {
                            txtRHCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtRHIDMax.Text = dataInfo.Part_max.ToString();
                            txtRHIDMid.Text = dataInfo.Part_mid.ToString();
                            txtRHIDMin.Text = dataInfo.Part_min.ToString();
                            dropDownRHIDRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID ROUNDNESS")
                        {
                            txtRHIDRoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownRHIDRoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID CYLINDRICITY")
                        {
                            txtRHIDCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownRHIDCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "ID PERPENDICULARITY")
                        {
                            txtRHIDPerpenMid.Text = dataInfo.Part_mid.ToString();
                            dropDownRHIDPerpenRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "FLATNESS 1")
                        {
                            txtRHIDFlatnessCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtRHFlatness1Mid.Text = dataInfo.Part_mid.ToString();
                            dropDownRHFlatness1Rank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "FLATNESS 2")
                        {
                            txtRHIDFlatnessCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtRHFlatness2Mid.Text = dataInfo.Part_mid.ToString();
                            dropDownRHFlatness2Rank.SelectedValue = dataInfo.Group_id;
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
    protected void btnRHSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        bufModelID = Request.QueryString["id"];
        var bufSplit = bufModelID.Split(',');
        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "5");

        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = bufSplit[0].ToString();
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

            moDetailSer.UpdateModelDetail(_ModelDetailInfo);
        }
    }
}