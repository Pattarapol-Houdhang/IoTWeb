using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataHistory_DataHistoryLine : System.Web.UI.Page
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
                if (oMD.ld_id == 25 || oMD.ld_id == 26) // Alarm History and Alarm History Detail
                {
                    continue;
                }

                result += "	<div class='col-sm-6 col-md-2'>" + Environment.NewLine;
                result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                if (oMD.ld_id >= 12 && oMD.ld_id <= 15) //etd
                {
                    result += "            <a href='" + ResolveClientUrl("~/DataHistory/MstDataHistory.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
					result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
					result += "                <span class='board-widget-intro'>ElectronicData Measurement Tool</span>" + Environment.NewLine;
				}
                else if (oMD.ld_id == 11) //mecha fac 3
                {
                    result += "            <a href='" + ResolveClientUrl("~/DataHistory/MstDataHistory2.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
					result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
					result += "                <span class='board-widget-intro'>M/C Qty: 10</span>" + Environment.NewLine;
				}
				else if (oMD.ld_id >= 17 && oMD.ld_id <= 20) //leak
                {
                    result += "            <a href='" + ResolveClientUrl("~/DataHistory/DataLeakcheck.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
                    result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
                    result += "                <span class='board-widget-intro'>Leak Check</span>" + Environment.NewLine;
                }
                else if (oMD.ld_id == 8 || oMD.ld_id == 9)
                {
                    result += "            <a href='" + ResolveClientUrl("~/DataHistory/DataMachine.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
					result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
					result += "                <span class='board-widget-intro'>M/C Qty: " + oMD.MachineTotal + "</span>" + Environment.NewLine;
				}
                else if (oMD.ld_id == 21)
                {
                    result += "            <a href='" + ResolveClientUrl("~/DataHistory/DataQC.aspx?ld_id=" + oMD.ld_id + "&FactoryID=" + ViewState["FactoryID"].ToString()) + "'><i class='icon-tree'></i>" + Environment.NewLine;
                    result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
                    result += "                <span class='board-widget-intro'>QC Temp Data</span>" + Environment.NewLine;
                }
                else
                {
                    result += "            <a href='" + ResolveClientUrl("~/DataHistory/DataHistoryMain.aspx?ld_id=" + oMD.ld_id) + "'><i class='icon-tree'></i>" + Environment.NewLine;
					result += "                <span class='board-widget-label'>" + oMD.ld_linename + " </span>" + Environment.NewLine;
					result += "                <span class='board-widget-intro'>M/C Qty: " + oMD.MachineTotal + "</span>" + Environment.NewLine;
                }
                
                result += "            </a>" + Environment.NewLine;
                result += "        </div>" + Environment.NewLine;
                result += "    </div>" + Environment.NewLine;
            }

            try
            {
                if (Convert.ToInt32(ViewState["FactoryID"]) == 3)
                {
                    divCR.Visible = true;
                    divCRPallet.Visible = true;
                    divAlarm.Visible = true;
                    divAlarmDetail.Visible = true;
                }
                else
                {
                    divCR.Visible = false;
                    divCRPallet.Visible = false;
                    divAlarm.Visible = false;
                    divAlarmDetail.Visible = false;
                }
            }
            catch (Exception)
            {

            }

        }


        return result;
    }
}