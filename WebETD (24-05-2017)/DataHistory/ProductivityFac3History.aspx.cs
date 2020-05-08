using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataHistory_ProductivityFac3History : System.Web.UI.Page
{
    CProductivity oPro = new CProductivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime dt = new DateTime();
        if (txtDate.Text != "")
        {
            dt = Convert.ToDateTime(txtDate.Text.Trim());
        }
        else
        {
            dt = DateTime.Now;
        }

        hidMonth.Value = dt.Month.ToString();
        hidYear.Value = dt.Year.ToString();
    }

    private string GetMonth()
    {
        DateTime dt = new DateTime();
        if (txtDate.Text != "")
        {
            dt = Convert.ToDateTime(txtDate.Text.Trim());
        }
        else
        {
            dt = DateTime.Now;
        }
        
        switch (dt.Month)
        {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
            default:
                return "";
        }
    }

    public string GenTable()
    {
        string result = "";
        MDProcductivity oMDPro = new MDProcductivity();
        DateTime dt = new DateTime();
        if (txtDate.Text != "")
        {
            dt = Convert.ToDateTime(txtDate.Text.Trim());
        }
        else
        {
            dt = DateTime.Now;
        }
        oMDPro = oPro.GetProductivityByMonth(dt.Month, dt.Year);

        hidMonth.Value = dt.Month.ToString();
        hidYear.Value = dt.Year.ToString();

        int days = DateTime.DaysInMonth(dt.Year, dt.Month);
        result += "" + Environment.NewLine;
        result += "<table class='table' style='width: 3800px;' border=\"1\">" + Environment.NewLine;
        result += "    <tr>" + Environment.NewLine;
        result += "        <td rowspan=\"3\">Line" + Environment.NewLine;
        result += "        </td>" + Environment.NewLine;
        result += "        <td rowspan=\"3\" width='100px'>Process" + Environment.NewLine;
        result += "        </td>" + Environment.NewLine;
        result += "        <td colspan=\"" + days * 2 + "\">" + GetMonth() + "" + Environment.NewLine;
        result += "        </td>" + Environment.NewLine;
        result += "    </tr>" + Environment.NewLine;
        result += "    <tr>" + Environment.NewLine;
        
        for (int day = 1; day <= days; day++)
        {
            if (day == DateTime.Now.Day && dt.Month == DateTime.Now.Month)
            {
                result += "        <td colspan=\"2\" style='background-color: yellow;'>" + Environment.NewLine;
            }
            else
            {
                result += "        <td colspan=\"2\" style='background-color: white;'>" + Environment.NewLine;
            }

            result += "        " + day + "" + Environment.NewLine;
            result += "        </td>" + Environment.NewLine;
        }

        result += "    </tr>" + Environment.NewLine;
        result += "    <tr>" + Environment.NewLine;

        for (int day = 1; day <= days; day++)
        {
            if (day == DateTime.Now.Day && dt.Month == DateTime.Now.Month)
            {
                result += "        <td style='background-color: yellow; border-top: 1px solid #000000;'>" + Environment.NewLine;
                result += "        D" + Environment.NewLine;
                result += "        </td>" + Environment.NewLine;
                result += "        <td style='background-color: yellow; border-top: 1px solid #000000;'>" + Environment.NewLine;
                result += "        N" + Environment.NewLine;
                result += "        </td>" + Environment.NewLine;
            }
            else
            {
                result += "        <td style='background-color: white; border-top: 1px solid #000000;'>" + Environment.NewLine;
                result += "        D" + Environment.NewLine;
                result += "        </td>" + Environment.NewLine;
                result += "        <td style='background-color: white; border-top: 1px solid #000000;'>" + Environment.NewLine;
                result += "        N" + Environment.NewLine;
                result += "        </td>" + Environment.NewLine;
            }

        }


        result += "    </tr>" + Environment.NewLine;


        // Loop by Day
        foreach (MDProcductivity.CMDProductivity oMD in oMDPro.ListOfProductivity)
        {
            result += "    <tr>" + Environment.NewLine;
            result += "        <td rowspan=\"3\">" + Environment.NewLine;
            result += "            " + oMD.LineName + "" + Environment.NewLine;
            result += "        </td>" + Environment.NewLine;
            result += "        <td style='border-top: 1px solid #000000;'>" + Environment.NewLine;
            result += "            Plan" + Environment.NewLine;
            result += "        </td>" + Environment.NewLine;

            // Loop
            for (int day = 1; day <= days; day++)
            {
                if (day == DateTime.Now.Day && dt.Month == DateTime.Now.Month)
                {
                    result += "        <td width='60px' style='background-color: yellow; border-top: 1px solid #000000;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].PlanD + "" + Environment.NewLine; // Plan Day
                    result += "        </td>" + Environment.NewLine;
                    result += "        <td width='60px' style='background-color: yellow; border-top: 1px solid #000000;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].PlanN + "" + Environment.NewLine; // Plan Night
                    result += "        </td>" + Environment.NewLine;
                }
                else
                {
                    result += "        <td width='60px' style='background-color: white; border-top: 1px solid #000000;'>" + Environment.NewLine;
                    result += "             " + oMD.ListOfQty[day - 1].PlanD + "" + Environment.NewLine; // Plan Day
                    result += "        </td>" + Environment.NewLine;
                    result += "        <td width='60px' style='background-color: white; border-top: 1px solid #000000;'>" + Environment.NewLine;
                    result += "           " + oMD.ListOfQty[day - 1].PlanN + "" + Environment.NewLine; // Plan Night
                    result += "        </td>" + Environment.NewLine;
                }
            }

            result += "    </tr>" + Environment.NewLine;
            result += "    <tr>" + Environment.NewLine;
            result += "         <td>" + Environment.NewLine;
            result += "            Start" + Environment.NewLine;
            result += "        </td>" + Environment.NewLine;

            // Loop
            for (int day = 1; day <= days; day++)
            {
                if (day == DateTime.Now.Day && dt.Month == DateTime.Now.Month)
                {
                    result += "        <td width='60px' style='background-color: yellow;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].StartD + "" + Environment.NewLine; // Start Day
                    result += "        </td>" + Environment.NewLine;
                    result += "        <td width='60px' style='background-color: yellow;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].StartN + "" + Environment.NewLine; // Start Night
                    result += "        </td>" + Environment.NewLine;
                }
                else
                {
                    result += "        <td width='60px' style='background-color: white;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].StartD + "" + Environment.NewLine; // Start Day
                    result += "        </td>" + Environment.NewLine;
                    result += "        <td width='60px' style='background-color: white;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].StartN + "" + Environment.NewLine; // Start Night
                    result += "        </td>" + Environment.NewLine;
                }
            }

            result += "    </tr>" + Environment.NewLine;
            result += "    <tr>" + Environment.NewLine;
            result += "         <td>" + Environment.NewLine;
            result += "            Last" + Environment.NewLine;
            result += "        </td>" + Environment.NewLine;

            // Loop
            for (int day = 1; day <= days; day++)
            {
                if (day == DateTime.Now.Day && dt.Month == DateTime.Now.Month)
                {
                    result += "        <td width='60px' style='background-color: yellow;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].LastD + "" + Environment.NewLine; // End Day
                    result += "        </td>" + Environment.NewLine;
                    result += "        <td width='60px' style='background-color: yellow;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].LastN + "" + Environment.NewLine; // End Night
                    result += "        </td>" + Environment.NewLine;
                }
                else
                {
                    result += "        <td width='60px' style='background-color: white;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].LastD + "" + Environment.NewLine; // End Day
                    result += "        </td>" + Environment.NewLine;
                    result += "        <td width='60px' style='background-color: white;'>" + Environment.NewLine;
                    result += "            " + oMD.ListOfQty[day - 1].LastN + "" + Environment.NewLine; // End Night
                    result += "        </td>" + Environment.NewLine;
                }
            }

            result += "    </tr>" + Environment.NewLine;

        }
        result += "</table>" + Environment.NewLine;

        return result;
    }
    protected void btExport_Click(object sender, EventArgs e)
    {
        try
        {
            string _Month = hidMonth.Value;
            string _Year = hidYear.Value;
            Response.Redirect("ExportExcelProductivity.ashx?Month=" + _Month + "&Year=" + _Year);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }
}