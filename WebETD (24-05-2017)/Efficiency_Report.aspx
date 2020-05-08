<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Efficiency_Report.aspx.cs" Inherits="Efficiency_Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Productivity</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- styles -->
    <link href="~/css/bootstrap.css" rel="stylesheet" />
    <link href="~/css/font-alpona.css" rel="stylesheet" />
    <link href="~/css/prettify.css" rel="stylesheet" />
    <link href="~/css/responsive-tables.css" rel="stylesheet" />
    <link href="~/css/styles.css" rel="stylesheet" />
    <link href="~/css/bootstrap-reset.css" rel="stylesheet" />
    <link href="~/css/highcharts.css" rel="stylesheet" />
    <link href="css/loading.css" rel="stylesheet" />

    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/loading.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.min.js"></script>
    <link href="css/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="js/datatables/datatables.css" rel="stylesheet" />
    <script type="text/javascript" src="js/datatables.js"></script>

    <script type="text/javascript" src="Highcharts/highcharts.js"></script>
    <script type="text/javascript" src="js/Highchartthemdark.js"></script>

    <%--<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/MasterOffsetDetail.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-ui-1.10.3.custom.min.js") %>"></script>--%>
</head>
<body>
    <script type='text/javascript'>
        $(document).ready(function () {
            $('body').loading({});

            //Loaddata();
        });

        $(window).load(function () {
            //window.location.replace('<%= ResolveUrl("~home.aspx") %>');
            $('body').loading('stop');
            //$('#overlay').fadeOut();
        });

        function commaSeparateNumber(val) {
            while (/(\d+)(\d{3})/.test(val.toString())) {
                val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
            }
            return val;
        }

        function chartdetails() {

            var LineName = $("#<%= linechoose.ClientID %>").text();
            var chartTitle = '';
            var processed_jsonPlan = new Array();
            var processed_jsonActual = new Array();
            var processed_jsonEff = new Array();
            var processed_jsonDate = new Array();
            var strJson = '';
            var dataT = new Array();
            var dataPlan = new Array();
            var dataTotalMille = new Array();
            var dataActual = new Array();
            var dataEff = new Array();
            var MaxData = 0;

            //-------- Get Current Date -----------
            var d = new Date();
            var month = d.getMonth() + 1;
            var day = d.getDate();
            var output = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();
            var Line = $("#<%= ddlLine.ClientID %>").val();

            var jsonData = [];
            var url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=&Mac=&ModelCode=&strDate=&endDate=&target=';
            $('#<%= lbtitle.ClientID %>').text('Line Efficiency Main Assemby Factory 3');
            if (LineName == "mecha") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=mecha&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Mecha Factory 3');
            } else if (LineName == "casing") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=casing&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Casing Line Factory 3');
            } else if (LineName == "motor") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=motor&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Motor Line Factory 3');
            } else if (LineName == "piston") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=piston&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Piston Line Factory 3');
            } else if (LineName == "fh") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=fh&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Front head Line Factory 3');
            } else if (LineName == "cs") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=cs&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Crankshaft Factory 3');
            } else if (LineName == "cd") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=cd&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Cylinder Factory 3');
            } else if (LineName == "rh") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=rh&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Rear Head Factory 3');
            } else if (LineName == "fn") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=fn&Mac=&ModelCode=&strDate=&endDate=&target=';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Final Line Factory 3');
            }

            

            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                },
                colors: ['#062ece', '#1b930b', '#960c07', '#DDDF00', '#00870b', '#870000', '#000000']
            });

            $.ajax({
                type: "POST",
                url: url,
                data: "",
                dataType: "json",
                async: true,
                success: function (data) {
                    var _EffVal = 0;
                    var _Plan = 0;
                    var _Actual = 0;
                    for (i = 0; i < data.length; i++) {
                        dataPlan[i] = data[i].PlanAccu;
                        dataActual[i] = data[i].ActualAccu;
                        dataEff[i] = data[i].EffiAccu;
                        processed_jsonDate.push([
                            data[i].DatePlan
                        ]);

                        if (data[i].EffiAccu != null) {
                            _EffVal = data[i].EffiAccu;
                        }
                        if (parseInt(data[i].ActualAccu) > 0) {
                            _Actual = data[i].ActualAccu;
                        }
                        if (parseInt(data[i].PlanAccu) > 0) {
                            _Plan = data[i].PlanAccu;
                        }

                        MaxData = data[i].Target;
                    }

                    $('#<%= lbEff.ClientID %>').text(_EffVal.toFixed(0));
                    $('#<%= lbPlan.ClientID %>').text(commaSeparateNumber(_Plan));
                    $('#<%= lbActual.ClientID %>').text(commaSeparateNumber(_Actual));

                    Highcharts.chart('container', {
                        chart: {
                            events: {
                                load: function () {
                                    var LineName2 = $("#<%= linechoose.ClientID %>").text();
                                    var dataPlan = this.series[0];
                                    var dataActual = this.series[1];
                                    var dataEff = this.series[2];
                                    var min = this.yAxis[0].min;
                                    var max = this.yAxis[0].max;
                                    var Target = 0;
                                    setInterval(function () {
                                        var x = (new Date()).getTime(), // current time
                                        url = '';
                                        var dataPlanArr = new Array();
                                        var dataActualArr = new Array();
                                        var dataEffArr = new Array();
                                        var CycleTime = $("#<%= txtCt.ClientID %>").val();
                                        var Line = $("#<%= ddlLine.ClientID %>").val();

                                        if (LineName2 == "mecha") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=mecha&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "casing") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=casing&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "motor") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=motor&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "piston") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=piston&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "fh") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=fh&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "cs") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=cs&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "cd") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=cd&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "rh") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=rh&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else if (LineName2 == "fn") {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=fn&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        } else {
                                            url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=&Mac=&ModelCode=&strDate=&endDate=&target=';
                                        }

                                        $.ajax({
                                            type: "POST",
                                            url: url,
                                            data: "",
                                            dataType: "json",
                                            async: true,
                                            success: function (data2) {
                                                var _EffVal = 0;
                                                var _Plan = 0;
                                                var _Actual = 0;
                                                for (i = 0; i < data2.length; i++) {
                                                    dataPlanArr[i] = data2[i].PlanAccu;
                                                    dataActualArr[i] = data2[i].ActualAccu;
                                                    dataEffArr[i] = data2[i].EffiAccu;

                                                    if (data2[i].EffiAccu != null) {
                                                        _EffVal = data2[i].EffiAccu;
                                                        //_Plan = data2[i].PlanAccu;
                                                        //_Actual = data2[i].ActualAccu;
                                                    }
                                                    if (parseInt(data2[i].ActualAccu) > 0) {
                                                        _Actual = data[i].ActualAccu;
                                                    }
                                                    if (parseInt(data2[i].PlanAccu) > 0) {
                                                        _Plan = data[i].PlanAccu;
                                                    }

                                                    Target = data2[i].Target;
                                                    MaxData = data2[i].Target;
                                                }
                                                dataPlan.setData(dataPlanArr);
                                                dataActual.setData(dataActualArr);
                                                dataEff.setData(dataEffArr);

                                                $('#<%= lbEff.ClientID %>').text(_EffVal.toFixed(0));
                                                $('#<%= lbPlan.ClientID %>').text(commaSeparateNumber(_Plan));
                                                $('#<%= lbActual.ClientID %>').text(commaSeparateNumber(_Actual));

                                                var DateNow = new Date();
                                                var HH = parseInt(DateNow.getHours()) >= 10 ? DateNow.getHours() : "0" + DateNow.getHours();
                                                var mm = DateNow.getMinutes() >= 10 ? DateNow.getMinutes() : "0" + DateNow.getMinutes();
                                                var ss = DateNow.getSeconds() >= 10 ? DateNow.getSeconds() : "0" + DateNow.getSeconds();
                                                var Timenow = DateNow.getDate() + "/" + (DateNow.getMonth() + 1) + "/" + DateNow.getFullYear() + " " + HH + ":" + mm + ":" + ss;
                                                $('#<%= lbLastUpdate.ClientID %>').text('Last Update ' + Timenow);
                                            }
                                        });
                                        min.setData(0);
                                        max.setData(Target);
                                    }, 180000);
                                }
                            }
                        },
                        title: {
                            //text: $("#<%= hdLine.ClientID %>").text()
                        },
                        subtitle: {
                            text: ''
                        },
                        legend: {
                            enabled: false,
                            layout: 'vertical',
                            align: 'left',
                            verticalAlign: 'top',
                            x: 130,
                            y: 50,
                            floating: true,
                            borderWidth: 1,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF',
                            itemStyle: {
                                font: 'bold 15pt Trebuchet MS, Verdana, sans-serif',
                                color: '#000000'
                            }
                        },
                        xAxis: [{
                            //type: 'datetime',
                            categories: processed_jsonDate,
                            tickInterval: 30,
                            dateTimeLabelFormats: {
                                millisecond: '%H:%M:%S.%L',
                                second: '%H:%M:%S',
                                minute: '%H:%M',
                                hour: '%H:%M',
                                day: '%e %b',
                                week: '%e. %b',
                                month: '%b \'%y',
                                year: '%Y'
                            },
                            style: {
                                fontSize: '18px'
                            }
                        }],
                        yAxis: [{ // Primary yAxis.
                            className: 'highcharts-color-0',
                            title: {
                                text: 'Units',
                                style: {
                                    color: Highcharts.getOptions().colors[6],
                                    fontSize: '18px'
                                }
                            },
                            labels: {
                                format: '{value} Units',
                                style: {
                                    color: Highcharts.getOptions().colors[6],
                                    fontSize: '18px'
                                }
                            },
                            opposite: true,
                            min: 0,
                            max: MaxData,
                            tickInterval: MaxData / 5
                        }, { // Secondary yAxis
                            className: 'highcharts-color-1',
                            title: {
                                text: 'Efficeincy',
                                style: {
                                    color: Highcharts.getOptions().colors[6],
                                    fontSize: '18px'
                                }
                            },
                            labels: {
                                format: '{value} %',
                                style: {
                                    color: Highcharts.getOptions().colors[6],
                                    fontSize: '18px'
                                }
                            },
                            min: 0,
                            max: 100,
                            tickInterval: 20
                        }],
                        tooltip: {
                            valueDecimals: 2,
                            split: false,
                            shared: true,
                        },
                        credits: {
                            enabled: false
                        },
                        plotOptions: {
                            line: {
                                animation: false
                            },
                            series: {
                                marker: {
                                    enabled: false
                                }
                            }
                        },
                        series: [{
                            yAxis: 0,
                            name: 'Plan',
                            data: dataPlan,
                            color: Highcharts.getOptions().colors[0],
                            lineWidth: 5
                        },
                        {
                            yAxis: 0,
                            name: 'Actual',
                            data: dataActual,
                            color: Highcharts.getOptions().colors[1],
                            lineWidth: 5
                        },
                        {
                            yAxis: 1,
                            name: 'Efficiency',
                            data: dataEff,
                            color: Highcharts.getOptions().colors[2],
                            lineWidth: 5
                        }]
                    });
                }
            });

            var $el = $(".item-block"),
                x = 500,
                originalColor = $el.css("background"),
                i = 3; //counter

            $("#BoxTime").click(function () {
                $("#BoxDate").slideToggle('fast');
            });
            var CurDate = new Date;
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            var MonthArr = new Array();
            MonthArr = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
            setInterval(function () {
                var DateNow = new Date();
                var HH = parseInt(DateNow.getHours()) >= 10 ? DateNow.getHours() : "0" + DateNow.getHours();
                var mm = DateNow.getMinutes() >= 10 ? DateNow.getMinutes() : "0" + DateNow.getMinutes();
                var ss = DateNow.getSeconds() >= 10 ? DateNow.getSeconds() : "0" + DateNow.getSeconds();
                var Timenow = Number2digit(DateNow.getDate()) + "/" + Number2digit(DateNow.getMonth() + 1) + "/" + DateNow.getFullYear() + " " + HH + ":" + mm + ":" + ss;
                //var strTimr = formatAMPM(DateNow);
                $("#<%= lbTime.ClientID %>").text(Timenow);
            }, 1000);

            var oTable = $('#tbTest').dataTable({
                "lengthMenu": [[-1], ["All"]],
                "scrollX": true,
                "scrollY": '45vh',
                "scrollCollapse": true
            });

            var idx = 1;
            //$(".colcontent").each(function (e) {
            //    idx++;
            //});
            //alert(idx);
        });

        function Number2digit(Number) {
            var Num2digit = Number;
            if (Number < 10) {
                Num2digit = "0" + Number;
            }
            return Num2digit;
        }

        //var parameter = Sys.WebForms.PageRequestManager.getInstance();
        //parameter.add_endRequest(function () {
        //    var oTable = $('#tbTest').dataTable({
        //        "lengthMenu": [[-1], ["All"]],
        //        "scrollX": true,
        //        "scrollY": '45vh',
        //        "scrollCollapse": true
        //    });            
        //});
    </script>

    <!-------------------- Script for show Alarm Detail ------------------->
    <script type="text/javascript">

        function Alarmdetail() {

            $("#closeAlm").click(function (e) {
                e.preventDefault();
                $('#here_table').hide();
            });

            $(".headmc").click(function (e) {
                e.preventDefault();
                var div = $('#here_table');
                var left = ($(window).width() - $('.centerload').width()) / 8;
                var top = ($(window).height() - $('.centerload').height()) / 4;
                div.css('margin-left', left, 'important');
                div.css('margin-top', top, 'important');

                var McName = $(this).data("mcname");
                var McCode = $(this).data("mccode");

                var alarmname = "Alarm Log " + McName
                $("#mcname").text(alarmname);

                if ($('#here_table').is(':hidden')) {
                    $('#here_table').show();
                } else {
                    $('#here_table').hide();
                }


                var AlarmName = new Array();
                var AlarmNumber = new Array();
                var Line = "";
                var LineHeader = $('#<%= hdLine.ClientID %>').text();
                if (LineHeader == "Line Efficiency Mecha Factory 3") {
                    Line = "mecha";
                }
                else if (LineHeader == "Line Efficiency Casing Line Factory 3") {
                    Line = "casing";
                }
                else if (LineHeader == "Line Efficiency Motor Line Factory 3") {
                    Line = "motor";
                }
                else if (LineHeader == "Line Efficiency Piston Line Factory 3") {
                    Line = "piston";
                }
                else if (LineHeader == "Line Efficiency Front head Line Factory 3") {
                    Line = "fh";
                }
                else if (LineHeader == "Line Efficiency Crankshaft Factory 3") {
                    Line = "cs";
                }
                else if (LineHeader == "Line Efficiency Cylinder Factory 3") {
                    Line = "cd";
                }
                else if (LineHeader == "Line Efficiency Rear Head Factory 3") {
                    Line = "rh";
                }
                else if (LineHeader == "Line Efficiency Final Line Factory 3") {
                    Line = "fn";
                }
                else {
                    Line = "";
                }

                var pjson = $.getJSON('Production/GetJsonAlarmDetail.ashx?name=' + McName + '&line=' + Line + '&McCode=' + McCode,
                    function (data) {
                        var content = "<table id='tbAlarm' border=1>"

                        if (data.length > 0) {
                            content += "<thead><tr><th>Alarm Name</th><th style='text-align:center'>Alarm Count</th></tr></thead>";
                            content += "<tbody>";
                            for (var i = 0; i < data.length; i++) {
                                AlarmName.push(data[i].AlarmName);
                                AlarmNumber.push(data[i].AlarmCount);

                                content += "<tr><td class='mcalarmhead' style='cursor:pointer' data-alarmhead='" + data[i].AlarmName + "' data-process='" + McName + "'>" + data[i].AlarmName + "</td><td style='text-align:center'>" + data[i].AlarmCount + "</td></tr>";
                            }
                            content += "</tbody>";
                        } else {
                            content += "<thead><tr><th style='text-align:center'>ไม่พบข้อมูล Alarm (No data Alarm)</th></tr></thead>";
                        }

                        content += "</table>"

                        $('#contentAlarm').html(content);
                    }
                );

                //$('#here_table').slideToggle("normal", "linear");

                var table = "";
            });
        }
    </script>
    <!-------------------- Script for show Alarm Detail ------------------->

    <style type="text/css">
        body, .main-warpper {
            padding: 0px;
            margin: 0px;
            background-color: #fff;
        }

        #container {
            margin-top: 0%;
        }

        #BoxEfficiency {
            display: none;
            position: absolute;
            z-index: 1000;
            top: 0px;
            right: 0px;
        }

        #BoxEfficiencyShow {
            /*opacity:0.5;
            filter: alpha(opacity=50);*/
            position: absolute;
            z-index: 1000;
            top: 125px;
            left: 200px;
            width: auto;
            height: auto;
            color: rgb(0, 0, 0);
            background-color: rgba(168, 223, 255, 0.7);
            vertical-align: middle;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
        }

        #eff {
            /*opacity:0.5;
            filter: alpha(opacity=50); /* For IE8 and earlier */
        }

        #BoxTime {
            position: absolute;
            z-index: 10000;
            top: 0px;
            left: 10px;
            color: #00a508;
        }

        #BoxTimeLastUpdate {
            position: absolute;
            z-index: 10000;
            top: 0px;
            right: 10px;
            color: #00a508;
        }

        #tbTime {
            border: 0;
            position: absolute;
            z-index: 10000;
        }

        #BoxDate {
            width: 600px;
            position: absolute;
            z-index: 1000;
            top: 0px;
            left: 30%;
        }

        #BoxSetting {
            display: none;
            position: absolute;
            z-index: 10000;
            top: 0px;
            left: 0px;
        }

        #tbstatus {
            width: 98%;
            border-top: solid;
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
        }

        .tbContent {
            /*width: 96%;*/
            border-top: 0;
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
        }

        #tbstatus td {
            padding: 1px !important;
            word-wrap: break-word;
            border-left: 1px;
            border-right: 1px;
            border-bottom: solid;
            border-top: solid;
        }

        .colcontent {
        }

        .headmc {
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
            border-top: solid;
            font-size: 10px;
        }

        .headone {
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
            border-top: solid;
            text-align: center;
            font-size: 18px;
            font-weight: bold;
        }

        .padding {
            padding-left: 0cm;
        }

        .status {
            margin-left: 0cm;
        }

        .highchart {
            margin-left: 0cm;
            margin-right: 1.5cm;
        }

        #lbtitle {
            font-family: "Times New Roman", Times, serif;
            fill: #000000;
            font-weight: bold;
            font-size: 65px !important;
            text-align: center;
            letter-spacing: 0.2em;
        }

        .highcharts-title {
            display: none;
        }

        .highcharts-container {
            padding-left: 0px;
            padding-right: 400px;
            margin-left: 3%;
        }

        .highcharts-root {
            width: 90%;
        }

        .highcharts-yaxis .highcharts-axis-line {
            stroke-width: 5px;
        }

        .highcharts-color-0 {
            fill: #062ece;
            stroke: #062ece;
        }

        .highcharts-axis.highcharts-color-0 .highcharts-axis-line {
            stroke: #062ece;
        }

        .highcharts-axis.highcharts-color-0 text {
            fill: #062ece;
        }

        .highcharts-color-1 {
            fill: #960c07;
            stroke: #960c07;
        }

        .highcharts-axis.highcharts-color-1 .highcharts-axis-line {
            stroke: #960c07;
        }

        .highcharts-axis.highcharts-color-1 text {
            fill: #960c07;
        }

        #tbEffShow th, #tbEffShow td {
            padding: 3px 5px !important;
        }

        .AlarmDetail {
            position: fixed;
            z-index: 1800;
            width: 70%;
            min-height: 300px;
            background-color: White;
            border: 2px solid Black;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 0.8;
            /*margin-left: 200px;*/
            box-shadow: 5px 5px 5px 2px;
        }

        .lbAlm {
            margin: 10px 10px;
            font-size: 18px;
        }

        #closeAlm {
            cursor: pointer;
            color: red;
        }

        #tbAlarm {
            width: 100%;
        }

            #tbAlarm th {
                font-size: 16px;
            }
    </style>


    <div class="main-warpper">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(Alarmdetail);
                Sys.Application.add_load(chartdetails);
            </script>
            <script type="text/javascript">
                //Re-Create for on page postbacks
                //var prm = Sys.WebForms.PageRequestManager.getInstance();
                //prm.add_endRequest(function () {
                //    chartdetails();
                //});
            </script>

            <div id="page">

                <asp:Timer ID="Timer1" Interval="180000" OnTick="Timer1_Tick" runat="server"></asp:Timer>
                <asp:Timer ID="Timer2" Interval="300000" OnTick="Timer2_Tick" runat="server"></asp:Timer>

                <asp:Label ID="hdLine" runat="server" Text="" ForeColor="White" BackColor="White"></asp:Label>
                <asp:Label ID="linechoose" runat="server" Text="" ForeColor="White" BackColor="White"></asp:Label>

                <!------------------------ BOX Machine Status --------------------->
                <div id="here_table" class="AlarmDetail" style="display: none !important">
                    <div class="col-md-12 col-xs-12">
                        <div class="col-md-11 col-xs-11">
                            <label id="mcname" class="lbAlm"></label>
                        </div>
                        <div class="col-md-1 col-xs-1" style="text-align: right !important">
                            <label id="closeAlm" class="lbAlm">ปิด</label>
                        </div>
                    </div>

                    <div id="contentAlarm" style="padding: 10px"></div>
                </div>

                <div class="col-md-12 col-xs-12">

                    <div class="row" style="display: none">
                        <div class="form-group">
                            <div class="col-md-1 col-xs-1">
                                <asp:Button ID="btnPopup" class="btn btn-primary" runat="server" Text="Setting" />
                            </div>
                            <div class="col-md-11 col-xs-11">
                            </div>
                        </div>
                    </div>

                    <div id="BoxTime">
                        <asp:Label Font-Bold="true" Font-Size="24px" ID="lbTime" runat="server" Text="" Visible="true"></asp:Label>
                    </div>


                    <div class="row highchart" style="margin: 0; padding: 0;">
                        <div class="form-group">
                            <div class="col-md-12 col-xs-12" style="text-align: center">
                                <h1>
                                    <asp:Label ID="lbtitle" runat="server" Text=""></asp:Label>
                                </h1>
                            </div>
                            <div class="col-md-12 col-xs-12">
                                <div id="container" style="height: 365px !important"></div>
                            </div>
                        </div>
                    </div>



                    <asp:UpdatePanel ID="TimedPanel" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                            <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                        </Triggers>
                        <ContentTemplate>

                            <div id="BoxTimeLastUpdate">
                                <asp:Label ID="lbLastUpdate" runat="server" ForeColor="Black" Font-Size="20px" Text=""></asp:Label>
                            </div>

                            <div class="row status" style="margin: 0; padding: 0; height: 400px !important">
                                <div class="form-group" style="width: 95%; margin: 0 auto; padding-right: 0px;">
                                    <asp:HiddenField ID="hdTotalCol" runat="server" />


                                    <table id="tbstatus" border="1" width="100%">
                                        <thead>
                                            <tr>
                                                <th background="Production/HeaderTableSplit.png" class="headone crossOut" width="(100/13)%" style="border: 1px solid black; background-size: 100% 100%; background-repeat: no-repeat;">
                                                    <span>Time</span><br />
                                                    <br />
                                                    <span id="A" style="text-align: left">Process</span>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime1" runat="server" Text="08.00 - 08.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime2" runat="server" Text="09.00 - 09.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime3" runat="server" Text="10.00 - 10.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime4" runat="server" Text="11.00 - 11.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime5" runat="server" Text="12.00 - 12.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime6" runat="server" Text="13.00 - 13.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime7" runat="server" Text="14.00 - 14.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime8" runat="server" Text="15.00 - 15.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime9" runat="server" Text="16.00 - 16.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime10" runat="server" Text="17.00 - 17.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime11" runat="server" Text="18.00 - 18.59"></asp:Label>
                                                </th>
                                                <th class="headone" colspan="20" width="(100/13)%">
                                                    <asp:Label ID="lbTime12" runat="server" Text="19.00 - 19.59"></asp:Label>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptMachine" runat="server" OnItemDataBound="rptMachine_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr id='<%# Eval("mc_name") %>,<%# Eval("mc_code") %>'>
                                                        <asp:HiddenField ID="hdmcName" Value='<%# Eval("mc_name") %>' runat="server" />
                                                        <asp:HiddenField ID="hdMcCode" Value='<%# Eval("mc_code") %>' runat="server" />
                                                        <th class="headmc" title="Click for show alarm detail" data-mcname='<%# Eval("mc_name") %>' data-mccode='<%# Eval("mc_code") %>' >
                                                            <table>
                                                                <tr>
                                                                    <th title="Click for show alarm detail" data-mcname='<%# Eval("mc_name") %>' data-mccode='<%# Eval("mc_code") %>' 
                                                                        style="font-size: 20px; font-weight: bold"><%# Eval("mc_name") %></th>                                                                    
                                                                </tr>
                                                                <tr>
                                                                    <th id="HeadModel" style="font-size: 16px;color: black;border-top: 1px dotted" runat="server">Model : <asp:Label ID="ModelRun" runat="server" Text="" style="color:blue"></asp:Label></th>
                                                                </tr>
                                                            </table>
                                                        </th>
                                                        
                                                        <asp:Repeater Visible="true" ID="rptTableMachine" OnItemDataBound="rptTableMachine_ItemDataBound" runat="server">
                                                            <ItemTemplate>                                                                
                                                                <td id="col" class="colcontent" runat='server'>
                                                                    <asp:HiddenField ID="hdmcName" Value='<%# Eval("MC") %>' runat="server" />
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                </td>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    <div class="col-md-12 col-xs-12" style="text-align: center; font-size: 20px; font-weight: bold">
                                        Machine Status
                                    <input type="button" class="btn btn-success" style="width: 20px; height: 30px; background-color: #45f960; border-color: black;" />
                                        RUN &nbsp;
                                    <input type="button" class="btn btn-danger" style="width: 20px; height: 30px; border-color: black;" />
                                        BREAK DOWN &nbsp;
                                    <input type="button" class="btn btn-warning" style="width: 20px; height: 30px; border-color: black;" />
                                        IDLE &nbsp;
                                    <input type="button" class="btn" style="width: 20px; height: 30px;background-color: #2d38d1; border-color: black;" />
                                        MODEL CHANGE 
                                    </div>
                                </div>
                            </div>

                            <div class="board-widget" style="margin: 0; padding: 0; display: none">
                                <div class="row">
                                    <div class="col-sm-12 col-md-12" style="align-content: center; text-align: center">
                                        <asp:Repeater ID="rptEmp" runat="server">
                                            <ItemTemplate>
                                                <div class="col-sm-1 col-md-1">
                                                    <div class="board-widget-wrap" style="text-align: center; background-color: black;">
                                                        <div style="background-color: white; padding: 1px 1px 1px 1px">
                                                            <p>
                                                                <asp:Image ID="Image" Width="90px" Height="100px" runat="server" ImageUrl='<%# Eval("LinkPic") %>' />
                                                            </p>
                                                            <p>
                                                                <asp:Label ID="lbName" Font-Bold="true" runat="server" Text='<%# Eval("FirstName") %>'></asp:Label>
                                                            </p>
                                                            <%--<p>
                                                            <asp:Label ID="lbPosition" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                                        </p>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div id="BoxEfficiency" class="item-block">
                    <div class="icon-block brown-block">
                        <span class="item-icon">
                            <span class="contact_sl"><a href="#"><i class="icon-warning"></i></a></span>
                        </span>
                    </div>
                    <h2>Efficiency Down!</h2>
                </div>

                <div id="BoxEfficiencyShow">
                    <div id="eff">
                        <%--<span class="item-icon">
                        <span class="contact_sl"><a href="#"><i class="icon-warning"></i></a></span>
                        
                    </span>--%>
                        <table id="tbEffShow" style="border: none; vertical-align: middle">
                            <tr style="text-align: left; color: blue; font-weight: bold; font-size: 35px">
                                <th>Plan
                                </th>
                                <th>
                                    <asp:Label ID="lbPlan" runat="server" Text="0" ForeColor="Blue" Font-Bold="true"></asp:Label></th>
                                <th>Units</th>
                            </tr>
                            <tr style="text-align: left; color: green; font-weight: bold; font-size: 35px">
                                <th style="text-align: left">Actual
                                </th>
                                <th>
                                    <asp:Label ID="lbActual" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></th>
                                <th>Units</th>
                            </tr>
                            <tr style="text-align: left; color: red; font-weight: bold; font-size: 35px">
                                <th>Efficiency
                                </th>
                                <th>
                                    <asp:Label ID="lbEff" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></th>
                                <th>%</th>
                            </tr>
                        </table>
                    </div>
                </div>

                <div id="dialog" class="col-md-12" style="display: none">
                    <div class="form-group">
                        <asp:Label ID="lbCt" class="col-lg-6 control-label" runat="server" Text="Cycle Time (s)"></asp:Label>
                        <div class="col-lg-6">
                            <asp:TextBox ID="txtCt" class="form-control" Style="width: 80px" runat="server" Text="30"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" class="col-lg-6 control-label" runat="server" Text="Line"></asp:Label>
                        <div class="col-lg-6">
                            <asp:DropDownList ID="ddlLine" class="form-control" runat="server">
                                <asp:ListItem Text="Pipe 1YC Line 2" Value="2" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

            </div>
        </form>
    </div>
</body>
</html>

