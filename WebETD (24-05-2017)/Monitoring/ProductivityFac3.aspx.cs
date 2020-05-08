using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

public partial class Monitoring_ProductivityFac3 : System.Web.UI.Page
{
    CProductivity oPro = new CProductivity();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GenGraph()
    {
        string result = "";
        MDProcductivity oMDProc = new MDProcductivity();
        DateTime _Date = new DateTime();
        if (txtDate.Text != "")
        {
            _Date = Convert.ToDateTime(txtDate.Text.Trim());
        }
        else
        {
            _Date = DateTime.Now;
        }

        oMDProc = oPro.GetProductivityNow(_Date, dropDownShift.SelectedValue);
        if (oMDProc.ListOfProductivity.Count > 0)
        {
            string Shift = "";
            if (dropDownShift.SelectedValue != "")
            {
                Shift = dropDownShift.SelectedValue;
            }
            //if (DateTime.Now.TimeOfDay.Hours >= 20 || DateTime.Now.TimeOfDay.Hours < 8)
            //{
            //    Shift = "Night";
            //}
            //else
            //{
            //    Shift = "Day";
            //}

            //if (dropDownShift.SelectedValue == "NIGHT")
            //{
            //    Shift = "Night";
            //}
            //else
            //{
            //    Shift = "Day";
            //}

            result += "<script type='text/javascript'>" + Environment.NewLine;
            result += "Highcharts.chart('container', {" + Environment.NewLine;
            result += "    chart: {" + Environment.NewLine;
            result += "        type: 'column'" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    title: {" + Environment.NewLine;
            result += "        text: 'Productivity Factory 3'" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    subtitle: {" + Environment.NewLine;
            result += "        text: '" + _Date.ToString("dd MMMM yyyy") + " " + Shift + "'" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    xAxis: {" + Environment.NewLine;
            result += "        categories: [" + Environment.NewLine;

            for (int i = 0; i < oMDProc.ListOfProductivity.Count; i++)
            {
                if (i == oMDProc.ListOfProductivity.Count - 1)
                {
                    result += "            '" + oMDProc.ListOfProductivity[i].LineName + "'" + Environment.NewLine;
                }
                else
                {
                    result += "            '" + oMDProc.ListOfProductivity[i].LineName + "'," + Environment.NewLine;
                }
            }

            //result += "            'Rear Head'," + Environment.NewLine;
            //result += "            'Cylinder'," + Environment.NewLine;
            //result += "            'Crank Shaft'," + Environment.NewLine;
            //result += "            'Front Head'," + Environment.NewLine;
            //result += "            'Piston'," + Environment.NewLine;
            //result += "            'Pipe'," + Environment.NewLine;
            //result += "            'Mecha'," + Environment.NewLine;
            //result += "            'Main Assy'," + Environment.NewLine;
            //result += "            'Final'" + Environment.NewLine;
            result += "        ]," + Environment.NewLine;
            result += "        crosshair: true" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    yAxis: {" + Environment.NewLine;
            result += "        min: 0," + Environment.NewLine;
            result += "        title: {" + Environment.NewLine;
            result += "            text: 'Quantity (pcs)'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    tooltip: {" + Environment.NewLine;
            result += "        headerFormat: '<span style=\"font-size:10px\">{point.key}</span><table>'," + Environment.NewLine;
            result += "        pointFormat: '<tr><td style=\"color:{series.color};padding:0\">{series.name}: </td>' +" + Environment.NewLine;
            result += "            '<td style=\"padding:0\"><b>{point.y:.1f} mm</b></td></tr>'," + Environment.NewLine;
            result += "        footerFormat: '</table>'," + Environment.NewLine;
            result += "        shared: true," + Environment.NewLine;
            result += "        useHTML: true" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    plotOptions: {" + Environment.NewLine;
            result += "        column: {" + Environment.NewLine;
            result += "            pointPadding: 0.2," + Environment.NewLine;
            result += "            borderWidth: 0," + Environment.NewLine;
            result += "            dataLabels: {" + Environment.NewLine;
            result += "                enabled: true," + Environment.NewLine;
            //result += "                format: '{point.y:.1f}'," + Environment.NewLine;
            result += "                y: 0," + Environment.NewLine;
            result += "                color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'black'" + Environment.NewLine;
            result += "            }" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    tooltip: {" + Environment.NewLine;
            result += "        shared: true" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    series: [{" + Environment.NewLine;
            result += "        name: 'Plan'," + Environment.NewLine;

            result += "        data: [" + Environment.NewLine;
            for (int i = 0; i < oMDProc.ListOfProductivity.Count; i++)
            {
                if (i == oMDProc.ListOfProductivity.Count - 1)
                {
                    result += "            " + oMDProc.ListOfProductivity[i].ListOfQty[0].PlanD != DBNull.Value.ToString()
                        ? oMDProc.ListOfProductivity[i].ListOfQty[0].PlanD : "0" + "" + Environment.NewLine;
                }
                else
                {
                    result += "            " + oMDProc.ListOfProductivity[i].ListOfQty[0].PlanD != DBNull.Value.ToString()
                        ? oMDProc.ListOfProductivity[i].ListOfQty[0].PlanD + "," : "0" + "," + Environment.NewLine;
                }
            }
            result += "        ]," + Environment.NewLine;

            //result += "        data: [49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4]," + Environment.NewLine;
            result += "        tooltip: {" + Environment.NewLine;
            result += "            valueSuffix: ' pcs'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }, {" + Environment.NewLine;
            result += "        name: 'Start'," + Environment.NewLine;

            result += "        data: [" + Environment.NewLine;
            for (int i = 0; i < oMDProc.ListOfProductivity.Count; i++)
            {
                if (i == oMDProc.ListOfProductivity.Count - 1)
                {
                    result += "            " + oMDProc.ListOfProductivity[i].ListOfQty[0].StartD != DBNull.Value.ToString()
                        ? oMDProc.ListOfProductivity[i].ListOfQty[0].StartD : "0" + "" + Environment.NewLine;
                }
                else
                {
                    result += "            " + oMDProc.ListOfProductivity[i].ListOfQty[0].StartD != DBNull.Value.ToString()
                        ? oMDProc.ListOfProductivity[i].ListOfQty[0].StartD + "," : "0" + "," + Environment.NewLine;
                }
            }
            result += "        ]," + Environment.NewLine;

            //result += "        data: [83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0, 104.3, 91.2]," + Environment.NewLine;
            result += "        tooltip: {" + Environment.NewLine;
            result += "            valueSuffix: ' pcs'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }, {" + Environment.NewLine;
            result += "        name: 'Last'," + Environment.NewLine;

            result += "        data: [" + Environment.NewLine;
            for (int i = 0; i < oMDProc.ListOfProductivity.Count; i++)
            {
                if (i == oMDProc.ListOfProductivity.Count - 1)
                {
                    result += "            " + oMDProc.ListOfProductivity[i].ListOfQty[0].LastD != DBNull.Value.ToString()
                        ? oMDProc.ListOfProductivity[i].ListOfQty[0].LastD : "0" + "" + Environment.NewLine;
                }
                else
                {
                    result += "            " + oMDProc.ListOfProductivity[i].ListOfQty[0].LastD != DBNull.Value.ToString()
                        ? oMDProc.ListOfProductivity[i].ListOfQty[0].LastD + "," : "0" + "," + Environment.NewLine;
                }
            }
            result += "        ]," + Environment.NewLine;

            //result += "        data: [83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0, 104.3, 91.2]," + Environment.NewLine;
            result += "        tooltip: {" + Environment.NewLine;
            result += "            valueSuffix: ' pcs'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }]" + Environment.NewLine;
            result += "});" + Environment.NewLine;
            result += "</script>" + Environment.NewLine;

        }
        return result;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GenGraph();
    }
}