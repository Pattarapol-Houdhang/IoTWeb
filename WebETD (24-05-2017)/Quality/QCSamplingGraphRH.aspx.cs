using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_QCSamplingGraphRH : System.Web.UI.Page
{
    CGenControl oGenControl = new CGenControl();
    CQCSamplingGraph oQCGraph = new CQCSamplingGraph();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialControl();
        }
    }

    private void InitialControl()
    {
        //oGenControl.GenDDLPartType(CGeneral.TypeSelect.Selected, ddlPartType);
        oGenControl.GenDDLMainPointByPartType(CGeneral.TypeSelect.Selected, ddlMainPoint, "Front_Head");
        oGenControl.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.All, ddlSubPoint, "Front_Head", ddlMainPoint.SelectedValue);

    }

    protected void ddlPartType_SelectedIndexChanged(object sender, EventArgs e)
    {
        oGenControl.GenDDLMainPointByPartType(CGeneral.TypeSelect.Selected, ddlMainPoint, "Front_Head");
        oGenControl.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.All, ddlSubPoint, "Front_Head", ddlMainPoint.SelectedValue);
    }


    protected void ddlMainPoint_SelectedIndexChanged(object sender, EventArgs e)
    {
        oGenControl.GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect.All, ddlSubPoint, "Front_Head", ddlMainPoint.SelectedValue);
    }

    private void LoadGraph()
    {

    }
}