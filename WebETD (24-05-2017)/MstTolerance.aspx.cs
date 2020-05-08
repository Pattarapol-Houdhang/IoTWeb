using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewModelTolerance : System.Web.UI.Page
{
    PartTypeService ptSer = new PartTypeService();
    ModelDetailService mdSer = new ModelDetailService();
    ModelDetailInfo mdInfo = new ModelDetailInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userName"] == null)
        //{
        //    Response.Redirect("~/Login.aspx");
        //}

        if (!IsPostBack) {

        }
    }

    protected void btnCSSave_Click(object sender, EventArgs e)
    {
        string[] strPartType = {
                                 "FRONT OD", "REAR OD",
                                 "PIN FRONT OD", "PIN REAR OD",
                                 "FORNT ECCENTRICITY", "REAR ECCENTRICITY"
                               };

        string modelName = txtModelName.Text;

        mdInfo.Model_id = txtModelCode.Text;
        mdInfo.Part_id = "1";
        mdInfo.User_edit = Session["userName"].ToString();
        mdInfo.Part_status = true;
         
        for (int i = 0; i < strPartType.Length; i++)
        {
            mdInfo.PartType_id = ptSer.GetPartTypeIDByNameType(strPartType[i]);

            if (strPartType[i] == "FRONT OD")
            {
                mdInfo.Rank_id = dropDownCSFODRank.SelectedValue.ToString();
                mdInfo.Part_mid = Convert.ToDouble(txtCSFODMid.Text);
                mdInfo.Part_min = Convert.ToDouble(txtCSFODMin.Text);
                mdInfo.Part_max = Convert.ToDouble(txtCSFODMax.Text);
                mdInfo.Part_cycletime = Convert.ToDouble(txtCSODCycleTime.Text);

            }
            else if (strPartType[i] == "REAR OD")
            {
                mdInfo.Rank_id = dropDownCSRODRank.SelectedValue.ToString();
                mdInfo.Part_mid = Convert.ToDouble(txtCSRODMid.Text);
                mdInfo.Part_min = Convert.ToDouble(txtCSRODMin.Text);
                mdInfo.Part_max = Convert.ToDouble(txtCSRODMax.Text);
                mdInfo.Part_cycletime = Convert.ToDouble(txtCSODCycleTime.Text);
            }
            else if (strPartType[i] == "PIN FORNT OD")
            {
                mdInfo.Rank_id = dropDownCSPinFODRank.SelectedValue.ToString();
                mdInfo.Part_mid = Convert.ToDouble(txtCSPinFODMid.Text);
                mdInfo.Part_min = Convert.ToDouble(txtCSPinFODMin.Text);
                mdInfo.Part_max = Convert.ToDouble(txtCSPinFODMax.Text);
                mdInfo.Part_cycletime = Convert.ToDouble(txtCSPINCycleTime.Text);
            }
            else if (strPartType[i] == "PIN REAR OD")
            {
                mdInfo.Rank_id = dropDownCSPinRODRank.SelectedValue.ToString();
                mdInfo.Part_mid = Convert.ToDouble(txtCSPinRODMid.Text);
                mdInfo.Part_min = Convert.ToDouble(txtCSPinRODMin.Text);
                mdInfo.Part_max = Convert.ToDouble(txtCSPinRODMax.Text);
                mdInfo.Part_cycletime = Convert.ToDouble(txtCSPINCycleTime.Text);
            }
            else if (strPartType[i] == "FORNT ECCENTRICITY")
            {
                mdInfo.Rank_id = dropDownCSEccFRank.SelectedValue.ToString();
                mdInfo.Part_mid = Convert.ToDouble(txtCSEccFMid.Text);
                mdInfo.Part_min = Convert.ToDouble(txtCSEccFMin.Text);
                mdInfo.Part_max = Convert.ToDouble(txtCSEccFMax.Text);
                mdInfo.Part_cycletime = Convert.ToDouble(txtCSECCCycleTime.Text);
            }
            else if (strPartType[i] == "REAR ECCENTRICITY")
            {
                mdInfo.Rank_id = dropDownCSEccRRank.SelectedValue.ToString();
                mdInfo.Part_mid = Convert.ToDouble(txtCSEccRMid.Text);
                mdInfo.Part_min = Convert.ToDouble(txtCSEccRMin.Text);
                mdInfo.Part_max = Convert.ToDouble(txtCSEccRMax.Text);
                mdInfo.Part_cycletime = Convert.ToDouble(txtCSECCCycleTime.Text);
            }
            else
            {
                //error
            }

            mdSer.InsertModelDetail(mdInfo);
        }
    }

    protected void btnPistonSave_Click(object sender, EventArgs e)
    {

    }

    protected void btnCylinderSave_Click(object sender, EventArgs e)
    {

    }

    protected void btnFRHeadSave_Click(object sender, EventArgs e)
    {

    }

    protected void btnClearance_Click(object sender, EventArgs e)
    {

    }
}