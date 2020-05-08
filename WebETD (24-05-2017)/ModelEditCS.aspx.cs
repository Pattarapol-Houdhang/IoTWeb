using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModelEditCS : System.Web.UI.Page
{
    //ModelDetailService mdSer = new ModelDetailService();
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
                    ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "1");

                    foreach (VIModelDetailInfo dataInfo in _data)
                    {
                        //FRONT OD
                        if (dataInfo.PartType_name == "FRONT OD")
                        {
                            txtCSODCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtCSFODMax.Text = dataInfo.Part_max.ToString();
                            txtCSFODMid.Text = dataInfo.Part_mid.ToString();
                            txtCSFODMin.Text = dataInfo.Part_min.ToString();
                            dropDownCSFODRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "FRONT ROUNDNESS")
                        {
                            txtCSFODRoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSFODRoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "FRONT CYLINDRICITY")
                        {
                            txtCSFODCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSFODCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        //REAR OD
                        else if (dataInfo.PartType_name == "REAR OD")
                        {
                            txtCSRODMax.Text = dataInfo.Part_max.ToString();
                            txtCSRODMid.Text = dataInfo.Part_mid.ToString();
                            txtCSRODMin.Text = dataInfo.Part_min.ToString();
                            dropDownCSRODRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "REAR ROUNDNESS")
                        {
                            txtCSRODRoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSRODRoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "REAR CYLINDRICITY")
                        {
                            txtCSRODCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSRODCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        //PIN
                        else if (dataInfo.PartType_name == "PIN OD")
                        {
                            txtCSPINCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtCSPinFODMax.Text = dataInfo.Part_max.ToString();
                            txtCSPinFODMid.Text = dataInfo.Part_mid.ToString();
                            txtCSPinFODMin.Text = dataInfo.Part_min.ToString();
                            dropDownCSPinFODRank.SelectedValue = dataInfo.Group_id;
                                                        
                            txtCSPinRODMax.Text = "-";
                            txtCSPinRODMid.Text = "-";
                            txtCSPinRODMin.Text = "-";
                            dropDownCSPinRODRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "PIN ROUNDNESS")
                        {
                            txtCSPinFODRoundnessMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSPinFODRoundnessRank.SelectedValue = dataInfo.Group_id;

                            txtCSPinRODRoundnessMid.Text = "-";
                            dropDownCSPinRODRoundnessRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "PIN CYLINDRICITY")
                        {
                            txtCSPinFODCylindricMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSPinFODCylindricRank.SelectedValue = dataInfo.Group_id;

                            txtCSPinRODCylindricMid.Text = "-";
                            dropDownCSPinRODCylindricRank.SelectedValue = dataInfo.Group_id;
                        }
                        //ECC
                        else if (dataInfo.PartType_name == "ECCENTRICITY")
                        {
                            txtCSECCCycleTime.Text = dataInfo.Part_cycletime.ToString();
                            txtCSEccFMax.Text = dataInfo.Part_max.ToString();
                            txtCSEccFMid.Text = dataInfo.Part_mid.ToString();
                            txtCSEccFMin.Text = dataInfo.Part_min.ToString();
                            dropDownCSEccFRank.SelectedValue = dataInfo.Group_id;

                            txtCSEccRMax.Text = "-";
                            txtCSEccRMid.Text = "-";
                            txtCSEccRMin.Text = "-";
                            dropDownCSEccRRank.SelectedValue = dataInfo.Group_id;
                        }
                        //RUN OUT
                        else if (dataInfo.PartType_name == "FRONT RUN-OUT")
                        {
                            txtCSFRunMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSFRunRank.SelectedValue = dataInfo.Group_id;
                        }
                        else if (dataInfo.PartType_name == "REAR RUN-OUT")
                        {
                            txtCSRRunMid.Text = dataInfo.Part_mid.ToString();
                            dropDownCSRRunRank.SelectedValue = dataInfo.Group_id;
                        }
                    }
                }
            }
            else
            {
                Session["editState"] = false;
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MstModel.aspx");
    }
    protected void btnCSSave_Click(object sender, EventArgs e)
    {
        ModelDetailInfo _ModelDetailInfo = new ModelDetailInfo();

        bufModelID = Request.QueryString["id"];
        var bufSplit = bufModelID.Split(',');
        ArrayList _data = viModelSer.GetModelDetailDataByModelIDANDPartID(bufSplit[0].ToString(), "1");

        foreach (VIModelDetailInfo dataInfo in _data)
        {
            _ModelDetailInfo.Model_id = bufSplit[0].ToString();
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

            moDetailSer.UpdateModelDetail(_ModelDetailInfo);
        }
    }
}