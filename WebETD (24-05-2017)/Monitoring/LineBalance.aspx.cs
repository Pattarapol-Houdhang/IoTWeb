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

public partial class Monitoring_LineBalance : System.Web.UI.Page
{
    ConnectDBIoTServerTon oConn = new ConnectDBIoTServerTon();
    ConnectDBPDB oConnPDB = new ConnectDBPDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        lbLastUpdate.Text = DateTime.Now.ToString();
    }

    public string GenGraph()
    {
        string result = "";

        string DateStart = "";
        string DateEnd = "";
        if (DateTime.Now < Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.Day.ToString() + " 08:00:00") || DateTime.Now >= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.Day.ToString() + " 20:00:00"))
        {
            // Night Shift
            DateStart = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.Day.ToString() + " 20:00:00";

            DateEnd = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.AddDays(1).Day.ToString() + " 08:00:00";

        }
        else if (DateTime.Now <= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.Day.ToString() + " 20:00:00"))
        {
            // Day Shift
            DateStart = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.Day.ToString() + " 08:00:00";

            DateEnd = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.Day.ToString() + " 20:00:00";
        }
        else
        {
            DateStart = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
           + "-" + DateTime.Now.Day.ToString() + " 20:00:00";

            DateEnd = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
            + "-" + DateTime.Now.AddDays(1).Day.ToString() + " 08:00:00";
        }

        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("exec dbo.GetCycleTimeData '" + DateStart + "','" + DateEnd + "'");
        dTable = oConn.Query(sbd.ToString());


        if (dTable.Rows.Count > 0)
        {
            DataTable dTableTackTime = new DataTable();
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT CurDlPlan,CycleTime FROM BoardData WHERE BoardId = '301'");
            dTableTackTime = oConnPDB.Query(sbd.ToString());
            string TackTime = "0";
            if (dTableTackTime.Rows.Count > 0)
            {
                TackTime = ((575 * 60) / (dTableTackTime.Rows[0]["CurDlPlan"].ToString() != "0" ? Convert.ToInt32(dTableTackTime.Rows[0]["CurDlPlan"]) : 0)).ToString();
            }

            result += "<script type='text/javascript'>" + Environment.NewLine;
            result += "Highcharts.chart('container', {" + Environment.NewLine;
            result += "    chart: {" + Environment.NewLine;
            result += "        zoomType: 'xy'" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    title: {" + Environment.NewLine;
            result += "        text: 'Line Balance'" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    xAxis: [{" + Environment.NewLine;


            result += "        categories: [ " + Environment.NewLine;
            //result += "'Rotor Yaki', 'Magnetize', 'Pipe Yaki', 'Magnet Center','Air Gap', 'Connecting Check', 'TBWelding No1', 'TBWelding No2'" + Environment.NewLine;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if (i == dTable.Rows.Count - 1)
                {
                    result += "'" + dTable.Rows[i]["MachineName"].ToString() + "'" + Environment.NewLine;
                }
                else
                {
                    result += "'" + dTable.Rows[i]["MachineName"].ToString() + "'," + Environment.NewLine;
                }

            }
            result += "        ]," + Environment.NewLine;


            result += "        crosshair: true" + Environment.NewLine;
            result += "    }]," + Environment.NewLine;
            result += "    yAxis: [{ // Primary yAxis" + Environment.NewLine;
            result += "        labels: {" + Environment.NewLine;
            result += "            style: {" + Environment.NewLine;
            result += "                color: Highcharts.getOptions().colors[1]" + Environment.NewLine;
            result += "            }" + Environment.NewLine;
            result += "        }," + Environment.NewLine;
            result += "        title: {" + Environment.NewLine;
            result += "            text: 'Tack Time'," + Environment.NewLine;
            result += "            style: {" + Environment.NewLine;
            result += "                color: Highcharts.getOptions().colors[1]" + Environment.NewLine;
            result += "            }" + Environment.NewLine;
            result += "        },        " + Environment.NewLine;
            result += "        max: 80," + Environment.NewLine;  // Set Max 
            result += "        min: 0," + Environment.NewLine;
            result += "        startOnTick: false" + Environment.NewLine;
            result += "    }, { // Secondary yAxis" + Environment.NewLine;
            result += "        title: {" + Environment.NewLine;
            result += "            text: 'C/T'," + Environment.NewLine;
            result += "            style: {" + Environment.NewLine;
            result += "                color: Highcharts.getOptions().colors[0]" + Environment.NewLine;
            result += "            }" + Environment.NewLine;
            result += "        }," + Environment.NewLine;
            result += "        labels: {" + Environment.NewLine;
            result += "            style: {" + Environment.NewLine;
            result += "                color: Highcharts.getOptions().colors[0]" + Environment.NewLine;
            result += "            }" + Environment.NewLine;
            result += "        }," + Environment.NewLine;
            result += "        opposite: true," + Environment.NewLine;
            result += "        max: 80," + Environment.NewLine;  // Set Max 
            result += "        min: 0," + Environment.NewLine;
            result += "        startOnTick: false" + Environment.NewLine;
            result += "    }]," + Environment.NewLine;
            result += "    tooltip: {" + Environment.NewLine;
            result += "        shared: true" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    plotOptions: {" + Environment.NewLine;
            result += "        column: {" + Environment.NewLine;
            result += "            dataLabels: {" + Environment.NewLine;
            result += "                enabled: true," + Environment.NewLine;
            result += "                format: '{point.y:.1f} sec'," + Environment.NewLine;
            result += "                color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'black'" + Environment.NewLine;
            result += "            }" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }," + Environment.NewLine;
            result += "    series: [{" + Environment.NewLine;
            result += "        name: 'Cycle Time Min'," + Environment.NewLine;
            result += "        type: 'column'," + Environment.NewLine;
            result += "        yAxis: 1," + Environment.NewLine;
            result += "        color: '#bfbfbf'," + Environment.NewLine;
            result += "        data: [        " + Environment.NewLine;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if (i == dTable.Rows.Count - 1)
                {
                    result += "" + (dTable.Rows[i]["CycleMin"] != DBNull.Value ? dTable.Rows[i]["CycleMin"].ToString() : "0") + "" + Environment.NewLine;
                }
                else
                {
                    result += "" + (dTable.Rows[i]["CycleMin"] != DBNull.Value ? dTable.Rows[i]["CycleMin"].ToString() : "0") + "," + Environment.NewLine;
                }

            }
            result += "        ],        " + Environment.NewLine;
            result += "        tooltip: {" + Environment.NewLine;
            result += "            valueSuffix: ' sec'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    },{" + Environment.NewLine;
            result += "        name: 'Cycle Time Avg'," + Environment.NewLine;
            result += "        type: 'column'," + Environment.NewLine;
            result += "        yAxis: 1," + Environment.NewLine;
            result += "        color: '#009900'," + Environment.NewLine;
            result += "        data: [" + Environment.NewLine; //22, 13.5, 23, 25.2, 23.1, 25.1, {y:33,color:'#ff0000'},31],
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if (i == dTable.Rows.Count - 1)
                {
                    result += "" + (dTable.Rows[i]["CycleAvg"] != DBNull.Value ? dTable.Rows[i]["CycleAvg"].ToString() : "0") + "" + Environment.NewLine;
                }
                else
                {
                    result += "" + (dTable.Rows[i]["CycleAvg"] != DBNull.Value ? dTable.Rows[i]["CycleAvg"].ToString() : "0") + "," + Environment.NewLine;
                }

            }
            result += "]," + Environment.NewLine;
            result += "        tooltip: {" + Environment.NewLine;
            result += "            valueSuffix: ' sec'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    },{" + Environment.NewLine;
            result += "        name: 'Cycle Time Max'," + Environment.NewLine;
            result += "        type: 'column'," + Environment.NewLine;
            result += "        yAxis: 1," + Environment.NewLine;
            result += "        color: '#737373'," + Environment.NewLine;
            result += "        data: [" + Environment.NewLine; //33, 32, 43, 28, 27, 39, 112, 96
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if (i == dTable.Rows.Count - 1)
                {
                    result += "" + (dTable.Rows[i]["CycleMax"] != DBNull.Value ? dTable.Rows[i]["CycleMax"].ToString() : "0") + "" + Environment.NewLine;
                }
                else
                {
                    result += "" + (dTable.Rows[i]["CycleMax"] != DBNull.Value ? dTable.Rows[i]["CycleMax"].ToString() : "0") + "," + Environment.NewLine;
                }

            }
            result += "]," + Environment.NewLine;
            result += "        tooltip: {" + Environment.NewLine;
            result += "            valueSuffix: ' sec'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }, {" + Environment.NewLine;
            result += "        name: 'Tack Time'," + Environment.NewLine;
            result += "        type: 'spline'," + Environment.NewLine;
            result += "        color: '#ff9900'," + Environment.NewLine;
            result += "        data: [" + Environment.NewLine;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                if (i == dTable.Rows.Count - 1)
                {
                    result += "" + TackTime + "" + Environment.NewLine;
                }
                else
                {
                    result += "" + TackTime + "," + Environment.NewLine;
                }

            }
            result += "]," + Environment.NewLine;
            result += "        tooltip: {" + Environment.NewLine;
            result += "            valueSuffix: ' sec'" + Environment.NewLine;
            result += "        }" + Environment.NewLine;
            result += "    }]" + Environment.NewLine;
            result += "});" + Environment.NewLine;

            result += "</script>" + Environment.NewLine;
        }


        return result;
    }
}