using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Graph_Quantity_PDQuantityGraphLine : System.Web.UI.Page
{
    CLineData oLine = new CLineData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["FactoryID"] != "")
        {
            ViewState["FactoryID"] = Request.QueryString["FactoryID"];
        }
        else
        {
            
        }

        if (!IsPostBack)
        {

        }
    }

    public string GenBlock()
    {
        string result = "";

        MDLineData oMDLine = new MDLineData();
        oMDLine = oLine.GetLineDataByFactoryID(Convert.ToInt32(ViewState["FactoryID"]));
        if (oMDLine.ListOfLine.Count > 0)
        {
            foreach (MDLineData.CMDLineData oMD in oMDLine.ListOfLine)
            {
                result += "	<div class='col-sm-6 col-md-2'>" + Environment.NewLine;
                result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                result += "            <a href='" + ResolveClientUrl("~/DataHistory/Graph/Quantity/PDQuantityGraphMachine.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
                result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
                result += "                <span class='board-widget-intro'>M/C Qty: " + oMD.MachineTotal + "</span>" + Environment.NewLine;
                result += "            </a>" + Environment.NewLine;
                result += "        </div>" + Environment.NewLine;
                result += "    </div>" + Environment.NewLine;
            }
        }


        return result;
    }
}