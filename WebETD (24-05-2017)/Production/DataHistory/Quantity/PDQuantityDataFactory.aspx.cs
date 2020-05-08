using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Graph_Quantity_PDQuantityDataFactory : System.Web.UI.Page
{
    CFactory oFactory = new CFactory();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GenBlock()
    {
        string result = "";

        MDFactory oMDFactory = new MDFactory();
        oMDFactory = oFactory.GetFactory();
        if (oMDFactory.ListOfFactory.Count > 0)
        {
            foreach (MDFactory.CMDFactory oMD in oMDFactory.ListOfFactory)
            {
                result += "	<div class='col-sm-6 col-md-2'>" + Environment.NewLine;
                result += "        <div class='board-widget-wrap'>" + Environment.NewLine;
                result += "            <a href='" + ResolveClientUrl("~/Production/DataHistory/Quantity/PDQuantityDataLine.aspx?FactoryID=" + oMD.FactoryID) + "'><i class='icon-factory'></i>" + Environment.NewLine;
                result += "                <span class='board-widget-label'>" + oMD.FactoryName + " </span>" + Environment.NewLine;
                result += "                <span class='board-widget-intro'>Line Qty: " + oMD.TotalLine + " , M/C Qty: " + oMD.TotalMachine + "</span>" + Environment.NewLine;
                result += "            </a>" + Environment.NewLine;
                result += "        </div>" + Environment.NewLine;
                result += "    </div>" + Environment.NewLine;
            }
        }


        return result;
    }
}