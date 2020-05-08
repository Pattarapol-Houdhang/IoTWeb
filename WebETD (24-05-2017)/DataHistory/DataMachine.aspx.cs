using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataHistory_DataMachine : System.Web.UI.Page
{
    CMachine oMachine = new CMachine();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["FactoryID"] != "")
        {
            ViewState["FactoryID"] = Request.QueryString["FactoryID"];
        }
        else
        {
            
        }
        if (Request.QueryString["ld_id"] != "")
        {
            ViewState["ld_id"] = Request.QueryString["ld_id"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/DataHistory/DataLine.aspx?FactoryID" + ViewState["FactoryID"].ToString()));
        }

        if (!IsPostBack)
        {

        }
    }

    public string GenBlock()
    {
        string result = "";

        MDMachine oMDMachine = new MDMachine();
        oMDMachine = oMachine.GetMachineByLineID(Convert.ToInt32(ViewState["ld_id"]));
        if (oMDMachine.ListOfmachine.Count > 0)
        {
            foreach (MDMachine.CMDMachine oMD in oMDMachine.ListOfmachine)
            {
                result += "	<div class='col-sm-6 col-md-3'>" + Environment.NewLine;
                result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                result += "            <a href='" + ResolveClientUrl("~/DataHistory/QuantityData.aspx?ld_id=" + ViewState["ld_id"].ToString()) + "&FactoryID=" + ViewState["FactoryID"].ToString() + "&mc_code=" + oMD.mc_code + "'><i class='icon-tree'></i>" + Environment.NewLine;
                result += "                <span class='board-widget-label'>" + oMD.mc_code + " " + oMD.mc_name + " </span>" + Environment.NewLine;
                result += "                <span class='board-widget-intro'>" + DateTime.Now.ToString() + ", Qty OK: " + oMD.QtyOK + ",</span>" + Environment.NewLine;
                result += "                <span class='board-widget-intro'>Qty NG: " + oMD.QtyNG + "</span>" + Environment.NewLine;
                result += "            </a>" + Environment.NewLine;
                result += "        </div>" + Environment.NewLine;
                result += "    </div>" + Environment.NewLine;
            }
        }

        return result;
    }

    protected void btBackPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveClientUrl("~/DataHistory/DataHistoryLine.aspx?FactoryID=" + ViewState["FactoryID"].ToString()));
    }
}