using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Monitoring_MonitoringLine : System.Web.UI.Page
{
    CLineData oLine = new CLineData();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["FactoryID"] != "")
        {
            ViewState["FactoryID"] = Request.QueryString["FactoryID"];
        }
        else
        {

        }
    }

    public string GenBlock()
    {
        string result = "";

        MDLineData oMDLine = new MDLineData();
        oMDLine = oLine.GetLineMonitoringByFactoryID(Convert.ToInt32(ViewState["FactoryID"]));
        if (oMDLine.ListOfLine.Count > 0)
        {
            foreach (MDLineData.CMDLineData oMD in oMDLine.ListOfLine)
            {
                if (oMD.ld_id == 5)
                {
                    result += "	<div class='col-sm-6 col-md-2'>" + Environment.NewLine;
                    result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                    result += "            <a href='" + ResolveClientUrl("~/Monitoring/MainAssyMonitor.aspx") + "'><i class='icon-tree'></i>" + Environment.NewLine;
                    result += "                <span class='board-widget-label'>Main Assembly: Productivity </span>" + Environment.NewLine;
                    //result += "                <span class='board-widget-intro'>M/C Qty: " + oMD.MachineTotal + "</span>" + Environment.NewLine;
                    result += "            </a>" + Environment.NewLine;
                    result += "        </div>" + Environment.NewLine;
                    result += "    </div>" + Environment.NewLine;

                    result += "	<div class='col-sm-6 col-md-2'>" + Environment.NewLine;
                    result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                    result += "            <a href='" + ResolveClientUrl("~/Monitoring/ProductivityFac3.aspx") + "'><i class='icon-tree'></i>" + Environment.NewLine;
                    result += "                <span class='board-widget-label'>Productivity Graph </span>" + Environment.NewLine;
                    result += "            </a>" + Environment.NewLine;
                    result += "        </div>" + Environment.NewLine;
                    result += "    </div>" + Environment.NewLine;

                    result += "	<div class='col-sm-6 col-md-2'>" + Environment.NewLine;
                    result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                    result += "            <a href='" + ResolveClientUrl("~/DataHistory/ProductivityFac3History.aspx") + "'><i class='icon-tree'></i>" + Environment.NewLine;
                    result += "                <span class='board-widget-label'>Productivity History </span>" + Environment.NewLine;
                    result += "            </a>" + Environment.NewLine;
                    result += "        </div>" + Environment.NewLine;
                    result += "    </div>" + Environment.NewLine;

                }
                else
                {
                    result += "	<div class='col-sm-6 col-md-2'>" + Environment.NewLine;
                    result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                    if (oMD.ld_id >= 1 && oMD.ld_id <= 4)
                    {
                        result += "            <a href='" + ResolveClientUrl("~/Monitoring/ETDMeasurementTool.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
                        result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine; 
                    }
                    else if (oMD.ld_id >= 7 && oMD.ld_id <= 10)
                    {
                        result += "            <a href='" + ResolveClientUrl("~/Trends Data/DailyReport.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
                        result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
                    }                    
                    result += "            </a>" + Environment.NewLine;
                    result += "        </div>" + Environment.NewLine;
                    result += "    </div>" + Environment.NewLine;
                }               
            }
        }


        return result;
    }

}