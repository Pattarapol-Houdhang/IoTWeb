using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for DrawCharts
/// </summary>
public class DrawCharts
{
    public DrawCharts()
    {
    }

    string PartID = "";

    public string SetLineChartHeader(string tagID, string partType, string subTitle, double rankMax, double rankMin)
    {
        string strChart = "<div class='row'>";
        strChart += "<div id='" + tagID + "'></div>";
        strChart += "<script type='text/javascript'>";
        strChart += "Highcharts.chart('" + tagID + "', {";
        strChart += "chart: { type: 'line', width: $('#myCarousel').width(), height: $('#myCarousel').height()},";
        strChart += "title: { text: '" + partType + "'},";
        strChart += "subtitle: { text: '" + subTitle + "'},";
        strChart += "xAxis: { type: 'datetime',";
        strChart += "dateTimeLabelFormats: {minute: '%d/%m/%Y %H:%M:%S'},";
        strChart += "title: { text: 'Date'}},";
        strChart += "yAxis: {title: {text: 'RANK ( mm )'},min: " + (rankMin - 0.003) + ", max:" + (rankMax + 0.003) + ", tickInterval: 0.001, minorTickInterval: 0.0005 },";
        strChart += "tooltip: { headerFormat: '<b>{series.name}</b><br>', pointFormat: '{point.x:%d/%m/%Y %H:%M:%S} value:{point.y:.4f} mm.'},";
        strChart += "plotOptions: {spline: {marker: {enabled: true}}},";
        strChart += "series: [ ";

        PartID = tagID;

        return strChart;
    }

    public string SetLineChartHeaderMax(string tagID, string partType, string subTitle, double rankMax, double rankMin)
    {

        string strChart = "<div class='row'>";
        strChart += "<div id='" + tagID + "'></div>";
        strChart += "<script type='text/javascript'>";
        strChart += "Highcharts.chart('" + tagID + "', {";
        strChart += "chart: { type: 'line', width: $('#myCarousel').width(), height: $('#myCarousel').height() },";
        strChart += "title: { text: '" + partType + "'},";
        strChart += "subtitle: { text: '" + subTitle + "'},";
        strChart += "xAxis: { type: 'datetime',";
        strChart += "dateTimeLabelFormats: {minute: '%d/%m/%Y %H:%M:%S'},";
        strChart += "title: { text: 'Date'}},";
        strChart += "yAxis: {title: {text: 'RANK ( mm )'},min: " + (rankMin) + ", max:" + (rankMax + 0.003) + ", tickInterval: 0.001, minorTickInterval: 0.0005 },";
        strChart += "tooltip: { headerFormat: '<b>{series.name}</b><br>', pointFormat: '{point.x:%d/%m/%Y %H:%M:%S} value:{point.y:.4f} mm.'},";
        strChart += "plotOptions: {spline: {marker: {enabled: true}}},";
        strChart += "series: [ ";

        return strChart;
    }

    public string SetFooterChart()
    {
        return " ] });</script></div>";
    }


    public string SetFooterChartRank(string PartType)
    {
        string strChart = "";
        if (PartType == "ECCENTRICITY" || PartType == "BORE ID" || PartID == "PTOD")
        {
            strChart = " ]}, function (chart) {  " +
            " var point = chart.series[5].data[1], text = chart.renderer.text('D',point.plotX-10 + chart.plotLeft, point.plotY + chart.plotTop - 10).attr({zIndex: 5}).add(), box = text.getBBox(); " +
            " var point2 = chart.series[4].data[1], text2 = chart.renderer.text('C',point2.plotX-10 + chart.plotLeft, point2.plotY + chart.plotTop - 10).attr({zIndex: 6}).add(), box2 = text2.getBBox(); " +
            " var point3 = chart.series[3].data[1], text3 = chart.renderer.text('B',point3.plotX-10 + chart.plotLeft, point3.plotY + chart.plotTop - 10).attr({zIndex: 6}).add(), box3 = text3.getBBox(); " +
            " var point4 = chart.series[2].data[1], text4 = chart.renderer.text('A',point4.plotX-10 + chart.plotLeft, point4.plotY + chart.plotTop - 10).attr({zIndex: 6}).add(), box4 = text4.getBBox(); " +
            " var point5 = chart.series[1].data[1], text5 = chart.renderer.text('SA',point5.plotX-10 + chart.plotLeft, point5.plotY + chart.plotTop - 10).attr({zIndex: 6}).add(), box5 = text5.getBBox(); " +

            " chart.renderer.rect(box.x - 5, box.y - 5, 30, 28, 0).attr({fill: '#E85911',stroke: 'gray','stroke-width': 0, zIndex: 4}).add(); " +
            " chart.renderer.rect(box2.x - 5, box2.y - 5, 30, 28, 0).attr({fill: '#F0C91B',stroke: 'gray','stroke-width': 0,zIndex: 4}).add(); " +
            " chart.renderer.rect(box3.x - 5, box3.y - 5, 30, 28, 0).attr({fill: '#3AD51C',stroke: 'gray','stroke-width': 0,zIndex: 4 }).add(); " +
            " chart.renderer.rect(box4.x - 5, box4.y - 5, 30, 28, 0).attr({fill: '#F519E6',stroke: 'gray','stroke-width': 0,zIndex: 4 }).add(); " +
            " chart.renderer.rect(box5.x - 5, box5.y - 5, 30, 28, 0).attr({fill: '#F22411',stroke: 'gray','stroke-width': 0,zIndex: 4 }).add(); " +
            "});</script></div>";
        }
        else if (PartType == "HEIGHT")
        {
            strChart = " ]}, function (chart) {  " +
            " var point = chart.series[4].data[1], text = chart.renderer.text('C',point.plotX-10 + chart.plotLeft, point.plotY + chart.plotTop - 10).attr({zIndex: 5}).add(), box = text.getBBox(); " +
            " var point2 = chart.series[3].data[1], text2 = chart.renderer.text('BC',point2.plotX-10 + chart.plotLeft, point2.plotY + chart.plotTop - 10).attr({zIndex: 6}).add(), box2 = text2.getBBox(); " +
            " var point3 = chart.series[2].data[1], text3 = chart.renderer.text('BA',point3.plotX-10 + chart.plotLeft, point3.plotY + chart.plotTop - 10).attr({zIndex: 6}).add(), box3 = text3.getBBox(); " +
            " var point4 = chart.series[1].data[1], text4 = chart.renderer.text('A',point4.plotX-10 + chart.plotLeft, point4.plotY + chart.plotTop - 10).attr({zIndex: 6}).add(), box4 = text4.getBBox(); " +

            " chart.renderer.rect(box.x - 5, box.y - 5, 30, 28, 0).attr({fill: '#F0C91B',stroke: 'gray','stroke-width': 0, zIndex: 4}).add(); " +
            " chart.renderer.rect(box2.x - 5, box2.y - 5, 30, 28, 0).attr({fill: '#3AD51C',stroke: 'gray','stroke-width': 0,zIndex: 4}).add(); " +
            " chart.renderer.rect(box3.x - 5, box3.y - 5, 30, 28, 0).attr({fill: '#3AD51C',stroke: 'gray','stroke-width': 0,zIndex: 4 }).add(); " +
            " chart.renderer.rect(box4.x - 5, box4.y - 5, 30, 28, 0).attr({fill: '#F519E6',stroke: 'gray','stroke-width': 0,zIndex: 4 }).add(); " +

            "});</script></div>";
        }
        else
        {
            strChart = " ]}, function (chart) {  " +
            " var point = chart.series[3].data[1], text = chart.renderer.text('C',point.plotX-10 + chart.plotLeft, point.plotY + chart.plotTop - 28).attr({zIndex: 5}).add(), box = text.getBBox(); " +
            " var point2 = chart.series[2].data[1], text2 = chart.renderer.text('B',point2.plotX-10 + chart.plotLeft, point2.plotY + chart.plotTop - 28).attr({zIndex: 6}).add(), box2 = text2.getBBox(); " +
            " var point3 = chart.series[1].data[1], text3 = chart.renderer.text('A',point3.plotX-10 + chart.plotLeft, point3.plotY + chart.plotTop - 28).attr({zIndex: 6}).add(), box3 = text3.getBBox(); " +

            " chart.renderer.rect(box.x - 5, box.y - 5, 30, 44, 0).attr({fill: '#F0C91B',stroke: 'gray','stroke-width': 0, zIndex: 4}).add(); " +
            " chart.renderer.rect(box2.x - 5, box2.y - 5, 30, 44, 0).attr({fill: '#3AD51C',stroke: 'gray','stroke-width': 0,zIndex: 4}).add(); " +
            " chart.renderer.rect(box3.x - 5, box3.y - 5, 30, 44, 0).attr({fill: '#F519E6',stroke: 'gray','stroke-width': 0,zIndex: 4 }).add(); " +
            "});</script></div>";
        }
        
        return strChart;
    }

    //type=>Time or Other
    public string SetLineChartSeriesData(string partType, ArrayList _partData, Type _dataType, double rankMax, double rankMid, double rankMin)
    {
        string[] startDate = null, endDate = null;
        string strSeries = "{name: 'RANK Result', zIndex: 2,color: '#0BF803', lineWidth: 5, data: [";
        int n = 0;
        foreach (dynamic dataInfo in _partData)
        {
            string[] splitedData = null;

            if (_dataType == typeof(CSODInfo))
            {
                splitedData = dataInfo.Fr_datetime.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Fr_datetime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(CSPINInfo))
            {
                splitedData = dataInfo.Pin_datetime.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Pin_datetime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if(_dataType == typeof(CSECCInfo))
            {
                splitedData = dataInfo.Ecc_datetime.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Ecc_datetime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(PTODInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Fr_datetime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(PTIDInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Pt_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(PTHEIInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Pt_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(PTBLInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Pt_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(FHIDInfo))
            {
                splitedData = dataInfo.Fh_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Fh_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(RHIDInfo))
            {
                splitedData = dataInfo.Rh_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Rh_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(CYBOInfo))
            {
                splitedData = dataInfo.Cy_bo_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Cy_bo_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(CYBUInfo))
            {
                splitedData = dataInfo.Cy_bu_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Cy_bu_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (_dataType == typeof(CYHEIInfo))
            {
                splitedData = dataInfo.Cy_height_date.ToString().Split('-', ' ', ':', '/');
                //Console.WriteLine(dataInfo.Cy_height_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            if (n == 0)
            {
                startDate = splitedData;
            }

            if (splitedData.Length > 6)
            {
                if (splitedData[6] == "PM")
                {
                    if (splitedData[3] != "12")
                    {
                        splitedData[3] = (Convert.ToInt16(splitedData[3]) + 12).ToString();
                    }
                }
                else
                {
                    if (splitedData[3] == "12")
                    {
                        splitedData[3] = (Convert.ToInt16(splitedData[3]) - 12).ToString();
                    }
                }
            }
            //[Date.UTC(Year, Months, Day, h, m, s, ms), Value],
            if (partType == "FRONT OD")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Fr_judgeRank_f.ToString("00.0000") + "]";
            }
            else if (partType == "REAR OD")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Fr_judgeRank_r.ToString("00.0000") + "]";
            }
            else if (partType == "PIN OD")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Pin_rank.ToString("00.0000") + "]";
            }
            else if (partType == "ECCENTRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Ecc_rank.ToString("0.0000") + "]";
            }
            else if (partType == "OD")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_od_val.ToString("0.0000") + "]";
            }
            else if (partType == "ID")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_id_val.ToString("0.0000") + "]";
            }
            else if (partType == "HEIGHT")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_hei_val.ToString("0.0000") + "]";
            }
            else if (partType == "BLADE THICKNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_bl_val.ToString("0.0000") + "]";
            }
            else if (partType == "BORE ID")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Cy_bo_rank.ToString("0.0000") + "]";
            }
            else if (partType == "BUSH ID")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Cy_bu_rank.ToString("0.0000") + "]";
            }

            if (n + 1 < _partData.Count)
            {
                strSeries += ",";
                n++;
            }
            else
            {
                endDate = splitedData;
            }
        }
        strSeries += "]}";

        //strSeries += SetLineChartSeriesMaxMidMin(startDate, endDate, rankMax, rankMid, rankMin);

        strSeries += SetLineChartSeriesRank(partType, startDate, endDate, rankMax, rankMid, rankMin);
        

        return strSeries;
    }

    public string SetLineChartSeriesMaxMidMin(string[] startDate, string[] endDate, double rankMax, double rankMid, double rankMin)
    {
        string strMaxMidMin = "";
        double _dataMaxMidMin = 0;

        for (int x = 0; x < 3; x++)
        {
            if (x == 0)
            {
                strMaxMidMin += ",{name: 'MID',zIndex: 1, color: '#090909', data: [";
                _dataMaxMidMin = rankMid;
            }
            else if (x == 1)
            {
                strMaxMidMin += ",{name: 'MAX',zIndex: 1, color: '#080808', data: [";
                _dataMaxMidMin = rankMax;
            }
            else if (x == 2)
            {
                strMaxMidMin += ",{name: 'MIN',zIndex: 1, color: '#070707', data: [";
                _dataMaxMidMin = rankMin;
            }

            for (int i = 0; i < 2; i++)
            {
                string[] splitedData;
                if (i == 0)
                {
                    splitedData = startDate;
                }
                else
                {
                    splitedData = endDate;
                }


                //[Date.UTC(Year, Months, Day, h, m, s, ms), Value], (month start at index 0=>Jan.)
                strMaxMidMin += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + _dataMaxMidMin.ToString("0.0000") + "]";
                if (i + 1 < 2)
                {
                    strMaxMidMin += ",";
                }
            }

            strMaxMidMin += "]}";

        }

        return strMaxMidMin;
    }


    public string SetLineChartSeriesRank(string PartType, string[] startDate, string[] endDate, double rankMax, double rankMid, double rankMin)
    {
        string strRankData = "";
        double _dataRankData = 0;


        int Loop = 0;
        if (PartType == "ECCENTRICITY" || PartType == "BORE ID" || PartID == "PTOD")
        {
            Loop = 5;
        }
        else if (PartType == "HEIGHT")
        {
            Loop = 4;
        }
        else {
            Loop = 3;
        }



        if (Loop == 3) {
            #region Rank A,B,C
            double rankStaircase = 0;
            double rankLoop = 0;
            rankStaircase = (rankMax - rankMin) / Loop;
            rankLoop = rankMin;

            for (int x = 0; x <= Loop; x++)
            {
                if (x == 0)
                {
                    strRankData += ",{name: 'MIN', zIndex: 1, color: '#f00',  data: [";
                    _dataRankData = rankMin;
                }
                else if (x == 1)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'A-B', zIndex: 1, color: '#080808', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == 2)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'B-C', zIndex: 1, color: '#070707', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == Loop)
                {
                    strRankData += ",{name: 'MAX', zIndex: 1, color: '#f00',  data: [";
                    _dataRankData = rankMax;
                }

                //-----------------------------
                //     loop start, end
                //-----------------------------
                for (int i = 0; i < 2; i++)
                {
                    string[] splitedData;
                    if (i == 0)
                    {
                        splitedData = startDate;
                    }
                    else
                    {
                        splitedData = endDate;
                    }

                    strRankData += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + _dataRankData.ToString("0.0000") + "]";
                    if (i + 1 < 2)
                    {
                        strRankData += ",";
                    }
                }
                strRankData += "]}";
                //-----------------------------
                //    end loop start, end
                //-----------------------------
            }
            #endregion
        }
        else if (Loop == 4)
        {            
            #region Rank A,BA,BC,C
            double rankStaircase = 0;
            double rankLoop = 0;
            rankStaircase = (rankMax - rankMin) / Loop;
            rankLoop = rankMin;

            for (int x = 0; x <= Loop; x++)
            {                
                if (x == 0)
                {
                    strRankData += ",{name: 'MIN', zIndex: 1, color: '#f00', data: [";
                    _dataRankData = rankMin;
                }
                else if (x == 1)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'A-BA', zIndex: 1, color: '#080808', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == 2)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'BA-BC', zIndex: 1, color: '#070707', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == 3)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'BC-C', zIndex: 1, color: '#060606', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == Loop)
                {
                    strRankData += ",{name: 'MAX', zIndex: 1, color: '#f00', data: [";
                    _dataRankData = rankMax;
                }

                //-----------------------------
                //     loop start, end
                //-----------------------------
                for (int i = 0; i < 2; i++)
                {
                    string[] splitedData;
                    if (i == 0)
                    {
                        splitedData = startDate;
                    }
                    else
                    {
                        splitedData = endDate;
                    }

                    strRankData += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + _dataRankData.ToString("0.0000") + "]";
                    if (i + 1 < 2)
                    {
                        strRankData += ",";
                    }
                }
                strRankData += "]}";
                //-----------------------------
                //    end loop start, end
                //-----------------------------
            }
            #endregion
        }
        else if (Loop == 5)
        {
            #region Rank SA,A,B,C,D
            double rankStaircase = 0;
            double rankLoop = 0;
            rankStaircase = (rankMax - rankMin) / Loop;
            rankLoop = rankMin;

            for (int x = 0; x <= Loop; x++)
            {
                if (x == 0)
                {
                    strRankData += ",{name: 'MIN', zIndex: 1, color: '#f00', data: [";
                    _dataRankData = rankMin;
                }
                else if (x == 1)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'SA-A', zIndex: 1, color: '#080808', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == 2)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'A-B', zIndex: 1, color: '#070707', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == 3)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'B-C', zIndex: 1, color: '#060606', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == 4)
                {
                    rankLoop = rankLoop + rankStaircase;
                    strRankData += ",{name: 'C-D', zIndex: 1, color: '#050505', dashStyle:'Dot', data: [";
                    _dataRankData = rankLoop;
                }
                else if (x == Loop)
                {
                    strRankData += ",{name: 'MAX',zIndex: 1, color: '#f00', data: [";
                    _dataRankData = rankMax;
                }

                //-----------------------------
                //     loop start, end
                //-----------------------------
                for (int i = 0; i < 2; i++)
                {
                    string[] splitedData;
                    if (i == 0)
                    {
                        splitedData = startDate;
                    }
                    else
                    {
                        splitedData = endDate;
                    }

                    strRankData += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + _dataRankData.ToString("0.0000") + "]";
                    if (i + 1 < 2)
                    {
                        strRankData += ",";
                    }
                }
                strRankData += "]}";
                //-----------------------------
                //    end loop start, end
                //-----------------------------
            }
            #endregion
        }





        return strRankData;
    }





    public string SetLineChartSeriesDataMax(string partType, ArrayList _partData, Type _dataType, double rankMax)
    {
        string[] startDate = null, endDate = null;
        string strSeries = "{name: 'RANK Result',zIndex: 2, color: '#0BF803', lineWidth: 5, data: [";
        int n = 0;

        foreach (dynamic dataInfo in _partData)
        {
            string[] splitedData = null;

            if (_dataType == typeof(CSODInfo))
            {
                splitedData = dataInfo.Fr_datetime.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(CSPINInfo))
            {
                splitedData = dataInfo.Pin_datetime.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(PTODInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(PTIDInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(PTHEIInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(PTBLInfo))
            {
                splitedData = dataInfo.Pt_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(FHIDInfo))
            {
                splitedData = dataInfo.Fh_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(RHIDInfo))
            {
                splitedData = dataInfo.Rh_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(CYBOInfo))
            {
                splitedData = dataInfo.Cy_bo_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(CYBUInfo))
            {
                splitedData = dataInfo.Cy_bu_date.ToString().Split('-', ' ', ':', '/');
            }
            else if (_dataType == typeof(CYHEIInfo))
            {
                splitedData = dataInfo.Cy_height_date.ToString().Split('-', ' ', ':', '/');
            }
            else
            {

            }

            if (n == 0)
            {
                startDate = splitedData;
            }

            if (splitedData.Length > 6)
            {
                if (splitedData[6] == "PM")
                {
                    if (splitedData[3] != "12")
                    {
                        splitedData[3] = (Convert.ToInt16(splitedData[3]) + 12).ToString();
                    }
                }
                else
                {
                    if (splitedData[3] == "12")
                    {
                        splitedData[3] = (Convert.ToInt16(splitedData[3]) - 12).ToString();
                    }
                }
            }

            //[Date.UTC(Year, Months, Day, h, m, s, ms), Value],
            if (partType == "FRONT ROUNDNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Fr_judgeRoundness_f.ToString("0.0000") + "]";
            }
            else if (partType == "REAR ROUNDNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Fr_judgeRoundness_r.ToString("0.0000") + "]";
            }
            else if (partType == "FRONT CYLINDRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Fr_judgeCylindricity_f.ToString("0.0000") + "]";
            }
            else if (partType == "REAR CYLINDRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Fr_judgeCylindricity_r.ToString("0.0000") + "]";
            }
            else if (partType == "PIN ROUNDNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Pin_Roundness.ToString("0.0000") + "]";
            }
            else if (partType == "PIN CYLINDRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Pin_Cylindricity.ToString("0.0000") + "]";
            }
            else if (partType == "OD ROUNDNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_roundness.ToString("0.0000") + "]";
            }
            else if (partType == "OD CYLINDRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_cylindric.ToString("0.0000") + "]";
            }
            else if (partType == "OD PERPENDICULARITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_perpen.ToString("0.0000") + "]";
            }
            else if (partType == "ID ROUNDNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_roundness.ToString("0.0000") + "]";
            }
            else if (partType == "ID CYLINDRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_cylindric.ToString("0.0000") + "]";
            }
            else if (partType == "ID PERPENDICULARITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_perpen.ToString("0.0000") + "]";
            }
            else if (partType == "ID CONCENTRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_concentric.ToString("0.0000") + "]";
            }
            else if (partType == "HEIGHT PARALLISM")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_parallism.ToString("0.0000") + "]";
            }
            else if (partType == "BLADE PARALLISM")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + dataInfo.Judge_parallism.ToString("0.0000") + "]";
            }
            else if (partType == "BLADE PERPENDICULARITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + Math.Abs(dataInfo.Judge_perpen).ToString("0.0000") + "]";
            }
            else if (partType == "BORE ID ROUNDNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + Math.Abs(dataInfo.Cy_bo_judge_roundness).ToString("0.0000") + "]";
            }
            else if (partType == "BORE ID CYLINDRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + Math.Abs(dataInfo.Cy_bo_cylindricity).ToString("0.0000") + "]";
            }
            else if (partType == "BORE ID PERPENDICULARITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + Math.Abs(dataInfo.Cy_bo_perpen).ToString("0.0000") + "]";
            }
            else if (partType == "BORE ID CONCENTRICITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + Math.Abs(dataInfo.Cy_bo_concentric).ToString("0.0000") + "]";
            }
            else if (partType == "BUSH ID ROUNDNESS")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + Math.Abs(dataInfo.Cy_bu_judge_roundness).ToString("0.0000") + "]";
            }
            else if (partType == "BUSH ID PERPENDICULARITY")
            {
                strSeries += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + Math.Abs(dataInfo.Cy_bu_perpen).ToString("0.0000") + "]";
            }

            if (n + 1 < _partData.Count)
            {
                strSeries += ",";
                n++;
            }
            else
            {
                endDate = splitedData;
            }
        }

        strSeries += "]}";

        strSeries += SetLineChartSeriesMax(startDate, endDate, rankMax);

        return strSeries;
    }

    public string SetLineChartSeriesMax(string[] startDate, string[] endDate, double rankMax)
    {
        string strMaxMidMin = "";

        strMaxMidMin += ",{name: 'MAX', zIndex: 1, color: '#090909', data: [";

        for (int i = 0; i < 2; i++)
        {
            string[] splitedData;
            if (i == 0)
            {
                splitedData = startDate;
            }
            else
            {
                splitedData = endDate;
            }

            //[Date.UTC(Year, Months, Day, h, m, s, ms), Value], (month start at index 0=>Jan.)
            strMaxMidMin += "[Date.UTC(" + splitedData[2] + "," + (Convert.ToInt16(splitedData[0]) - 1) + "," + splitedData[1] + "," + splitedData[3] + "," + splitedData[4] + "," + splitedData[5] + ")," + rankMax.ToString("0.0000") + "]";
            if (i + 1 < 2)
            {
                strMaxMidMin += ",";
            }
        }

        strMaxMidMin += "]}";

        return strMaxMidMin;
    }


    public string[] SplitDateTime(DateTime _dateTime)
    {
        string[] _splitedDateTime = _dateTime.ToString().Split(' ', ',', ':');

        return _splitedDateTime;
    }
}