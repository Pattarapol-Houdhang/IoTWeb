<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Efficiency_ReportOld.aspx.cs" Inherits="Efficiency_ReportOld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Admin Panel Template" />

    <!-- styles -->
    <link href="~/css/bootstrap.css" rel="stylesheet" />
    <link href="~/css/font-alpona.css" rel="stylesheet" />
    <link href="~/css/prettify.css" rel="stylesheet" />
    <link href="~/css/responsive-tables.css" rel="stylesheet" />
    <link href="~/css/styles.css" rel="stylesheet" />
    <link href="~/css/bootstrap-reset.css" rel="stylesheet" />
    <link href="~/css/highcharts.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.min.js"></script>
    <link href="css/jquery-ui-1.10.3.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="Highcharts/highcharts.js"></script>
    <script type="text/javascript" src="Highcharts/heatmap.js"></script>

    <%--<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/MasterOffsetDetail.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-ui-1.10.3.custom.min.js") %>"></script>--%>
</head>
<body>
    <script type='text/javascript'>
        $(document).ready(function () {
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
            var output = (('' + day).length < 2 ? '0' : '') + day + '/'
                + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();
            var Line = $("#<%= ddlLine.ClientID %>").val();
            var txtDate2 = $("#<%= datepicker.ClientID %>").val();
            var jsonData = [];
            var url = 'Production/SourcJson.ashx?CycleTime=30&Fac=old&Line=&Mac=' + txtDate2 + '&ModelCode=&strDate=&endDate=&target=';

            $.getJSON(url,
            function (data) {
                for (i = 0; i < data.length; i++) {
                    dataPlan[i] = data[i].PlanAccu;
                    dataActual[i] = data[i].ActualAccu;
                    dataEff[i] = data[i].EffiAccu;
                    processed_jsonDate.push([
                        data[i].DatePlan
                    ]);

                    if (data[i].PlanAccu != null) {
                        MaxData = data[i].Target;
                    }
                }

                Highcharts.setOptions({
                    lang: {
                        thousandsSep: ','
                    },
                    colors: ['#062ece', '#1b930b', '#960c07', '#DDDF00', '#00870b', '#870000']
                });

                Highcharts.chart('container', {                    
                    title: {
                        text: 'Productivity Main Assembly Factory 3',
                        style: {
                            color: '#000000',
                            font: 'bold 24px "Trebuchet MS", Verdana, sans-serif'
                        }
                    },
                    subtitle: {
                        text: ''
                    },
                    legend: {
                        enabled: true,
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
                        tickInterval: 100,
                        dateTimeLabelFormats: {
                            millisecond: '%H:%M:%S.%L',
                            second: '%H:%M:%S',
                            minute: '%H:%M',
                            hour: '%H:%M',
                            day: '%e %b',
                            week: '%e. %b',
                            month: '%b \'%y',
                            year: '%Y'
                        }
                    }],
                    yAxis: [{ // Primary yAxis.
                        className: 'highcharts-color-0',
                        title: {
                            text: 'Unit',
                            style: {
                                color: Highcharts.getOptions().colors[0]
                            }
                        },
                        labels: {
                            format: '{value} Pcs',
                            style: {
                                color: Highcharts.getOptions().colors[0]
                            }
                        },
                        opposite: true,
                        min: 0,
                        max: MaxData
                    }, { // Secondary yAxis
                        className: 'highcharts-color-1',
                        title: {
                            text: 'Efficeincy',
                            style: {
                                color: Highcharts.getOptions().colors[2]
                            }
                        },
                        labels: {
                            format: '{value} %',
                            style: {
                                color: Highcharts.getOptions().colors[2]
                            }
                        },
                        min: 0,
                        max: 100
                    }],
                    tooltip: {
                        valueDecimals: 2,
                        split: false
                    },
                    credits: {
                        enabled: false
                    },
                    plotOptions: {
                        line: {
                            animation: false
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
                        color: Highcharts.getOptions().colors[0],
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
                //---------- Line Efficeincy -------
            });

            //--------- Set Box Efficiency Warnning Blink ------------
            var $el = $(".item-block"),
                x = 500,
                originalColor = $el.css("background"),
                i = 3; //counter

            (function loop() { //recurisve IIFE
                $el.css("background", "#f97a7a");
                setTimeout(function () {
                    $el.css("background", originalColor);
                    if (--i) setTimeout(loop, x); //restart loop
                }, x);
            }());

            $("#BoxTime").click(function () {
                $("#BoxDate").slideToggle('fast');
            });
            $("#BoxDate").slideToggle('fast');

            var CurDate = new Date;

            $("#datepicker").datepicker({
                dateFormat: 'yy-mm-dd',
                maxDate: new Date(CurDate.getFullYear(), CurDate.getMonth(), CurDate.getDate() - 1),
                minDate: new Date(2000, 6, 12)
            });
        });


        function chartdetails() {
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
            var dataMax = 0;

            //-------- Get Current Date -----------
            var d = new Date();
            var month = d.getMonth() + 1;
            var day = d.getDate();
            var output = (('' + day).length < 2 ? '0' : '') + day + '/'
                + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();
            var Line = $("#<%= ddlLine.ClientID %>").val();
            var txtDate2 = $("#<%= datepicker.ClientID %>").val();
            var jsonData = [];
            var url = 'Production/SourcJson.ashx?CycleTime=30&Fac=old&Line=&Mac=' + txtDate2 + '&ModelCode=&strDate=&endDate=&target=';

            $.getJSON(url,
            function (data) {
                for (i = 0; i < data.length; i++) {
                    dataPlan[i] = data[i].PlanAccu;
                    dataActual[i] = data[i].ActualAccu;
                    dataEff[i] = data[i].EffiAccu;
                    processed_jsonDate.push([
                        data[i].DatePlan
                    ]);
                    dataMax = data[i].Target;
                }

                Highcharts.setOptions({
                    lang: {
                        thousandsSep: ','
                    },
                    colors: ['#062ece', '#1b930b', '#960c07', '#DDDF00', '#00870b', '#870000']
                });

                Highcharts.chart('container', {
                    chart: {
                        events: {
                            load: function () {
                                var dataPlan = this.series[0];
                                var dataActual = this.series[1];
                                var dataEff = this.series[2];
                                var min = this.yAxis[0].min;
                                var max = this.yAxis[0].max;
                                var line1 = this.series[0].lineWidth;
                                var line2 = this.series[1].lineWidth;
                                var line3 = this.series[2].lineWidth;

                                var Target = 0;
                                setInterval(function () {
                                    var x = (new Date()).getTime(), // current time
                                    url = '';
                                    var dataPlanArr = new Array();
                                    var dataActualArr = new Array();
                                    var dataEffArr = new Array();
                                    var CycleTime = $("#<%= txtCt.ClientID %>").val();
                                    var Line = $("#<%= ddlLine.ClientID %>").val();
                                    var txtDate = $("#<%= datepicker.ClientID %>").val();
                                    url = 'Production/SourcJson.ashx?CycleTime=' + CycleTime + '&Fac=old&Line=' + Line + '&Mac=' + txtDate + '&ModelCode=&strDate=&endDate=&target=';
                                    $.getJSON(url,
                                    function (data2) {
                                        var _EffVal = 0;
                                        for (i = 0; i < data2.length; i++) {
                                            dataPlanArr[i] = data2[i].PlanAccu;
                                            dataActualArr[i] = data2[i].ActualAccu;
                                            dataEffArr[i] = data2[i].EffiAccu;

                                            if (data2[i].EffiAccu != null) {
                                                _EffVal = data2[i].EffiAccu;
                                            }

                                            Target = data2[i].Target;
                                        }
                                        dataPlan.setData(dataPlanArr);
                                        dataActual.setData(dataActualArr);
                                        dataEff.setData(dataEffArr);

                                        if (parseFloat(_EffVal) < 75 || _EffVal == "") {
                                            //$("#BoxEfficiency").fadeIn(1000);
                                        } else {
                                            $("#BoxEfficiency").fadeOut(1000);
                                        }
                                    });
                                    min.setData(0);
                                    max.setData(Target);
                                }, 30000);
                            }
                        }
                    },
                    title: {
                        text: 'Productivity Main Assembly Factory 3',
                        style: {
                            color: '#000000',
                            font: 'bold 24px "Trebuchet MS", Verdana, sans-serif'
                        }
                    },
                    subtitle: {
                        text: ''
                    },
                    legend: {
                        enabled: true,
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
                        tickInterval: 100,
                        dateTimeLabelFormats: {
                            millisecond: '%H:%M:%S.%L',
                            second: '%H:%M:%S',
                            minute: '%H:%M',
                            hour: '%H:%M',
                            day: '%e %b',
                            week: '%e. %b',
                            month: '%b \'%y',
                            year: '%Y'
                        }
                    }],
                    yAxis: [{ // Primary yAxis
                        className: 'highcharts-color-0',
                        labels: {
                            format: 'Unit',
                            style: {
                                color: Highcharts.getOptions().colors[0]
                            }
                        },
                        title: {
                            text: '{value} Pcs',
                            style: {
                                color: Highcharts.getOptions().colors[0]
                            }
                        },
                        opposite: true,
                        min: 0,
                        max: dataMax
                    }, { // Secondary yAxis
                        className: 'highcharts-color-1',
                        gridLineWidth: 0,
                        title: {
                            text: 'Efficeincy',
                            style: {
                                color: Highcharts.getOptions().colors[2]
                            }
                        },
                        labels: {
                            format: '{value} %',
                            style: {
                                color: Highcharts.getOptions().colors[2]
                            }
                        },
                        min: 0,
                        max: 100
                    }],
                    tooltip: {
                        valueDecimals: 2,
                        split: false
                    },
                    credits: {
                        enabled: false
                    },
                    plotOptions: {                        
                        line: {
                            animation: false
                        }
                    },
                    series: [{
                        yAxis: 0,
                        name: 'Plan',
                        data: dataPlan,
                        lineWidth: 5,
                        color: Highcharts.getOptions().colors[0]
                    },
                    {
                        yAxis: 0,
                        name: 'Actual',
                        data: dataActual,
                        lineWidth: 5,
                        color: Highcharts.getOptions().colors[0]
                    },
                    {
                        yAxis: 1,
                        name: 'Efficiency',
                        data: dataEff,
                        lineWidth: 5,
                        color: Highcharts.getOptions().colors[2]
                    }]
                });
                //---------- Line Efficeincy -------          
                //$(".highcharts-root").css('width', '1490px');
            });

            //--------- Set Box Efficiency Warnning Blink ------------
            var $el = $(".item-block"),
                x = 500,
                originalColor = $el.css("background"),
                i = 3; //counter

            (function loop() { //recurisve IIFE
                $el.css("background", "#f97a7a");
                setTimeout(function () {
                    $el.css("background", originalColor);
                    if (--i) setTimeout(loop, x); //restart loop
                }, x);
            }());

            $("#BoxTime").click(function () {
                $("#BoxDate").slideToggle('fast');
            });
            var CurDate = new Date;

            $("#datepicker").datepicker({
                dateFormat: 'yy-mm-dd',
                maxDate: new Date(CurDate.getFullYear(), CurDate.getMonth(), CurDate.getDate() - 1),
                minDate: new Date(2000, 6, 12)
            });
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#container").click(function () {
                if ($("#BoxEfficiency").is(':visible')) {
                    //$("#BoxEfficiency").fadeOut(1000);
                } else {
                    //$("#BoxEfficiency").fadeIn(1000);
                }
            });
            var MonthArr = new Array();
            MonthArr = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
            setInterval(function () {
                var DateNow = new Date();
                var HH = parseInt(DateNow.getHours()) >= 10 ? DateNow.getHours() : "0" + DateNow.getHours();
                var mm = DateNow.getMinutes() >= 10 ? DateNow.getMinutes() : "0" + DateNow.getMinutes();
                var ss = DateNow.getSeconds() >= 10 ? DateNow.getSeconds() : "0" + DateNow.getSeconds();
                var Timenow = DateNow.getDate() + " " + MonthArr[DateNow.getMonth()] + " " + DateNow.getFullYear() + " " + HH + ":" + mm + ":" + ss;
                $("#<%= lbTime.ClientID %>").text(Timenow);
            }, 1000);
        });
    </script>    

    <style type="text/css">
        body, .main-warpper {
            padding: 0px;
            margin: 0px;
            background-color: #fff;
        }

        #container {
            margin-top: 2%;
        }

        #BoxEfficiency {
            display: none;
            position: absolute;
            z-index: 1000;
            top: 0px;
            right: 0px;
        }

        #BoxTime {
            position: absolute;
            z-index: 10000;
            top: 0px;
            left: 20px;
            color: #00a508;
        }

        #tbTime{
            border:0;
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

        table {
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

        td {
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
            font-size: 12px;
        }

        .headone {
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
            border-top: solid;
            text-align: center;
            font-size: 12px;
        }

        .padding {
            padding-left: 0cm;
        }

        .status {
            margin-left: 0cm;
        }

        .highchart {
            margin-left: 0cm;
            margin-right: 1.2cm;
        }

        .highcharts-container {
            padding-left: 19px;
            padding-right: 400px;
            margin-left:4%;
        }

        .highcharts-root {
            width: 95%;
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
    </style>


    <div class="main-warpper">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <script type="text/javascript">
                //Re-Create for on page postbacks
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    chartdetails();
                });
            </script>
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

                <div class="row highchart">
                    <div class="form-group">
                        <div class="col-md-12 col-xs-12">
                            <div id="container"></div>
                        </div>
                    </div>
                </div>
                <div id="BoxDate">
                    <div class="form-group">
                        <table class="tbTime">
                            <tr>
                                <td>
                                    <asp:TextBox ID="datepicker" style="display:none" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label Font-Bold="true" style="display:none" Font-Size="16px" ID="Label2" runat="server" Text="Search Data Past"></asp:Label>
                                    <asp:Button ID="btnSetDate" OnClick="btnSetDate_Click" Text="Monitor Real Time" class="btn btn-primary" runat="server" />
                                </td>
                            </tr>
                        </table>                                                                        
                    </div>
                </div>

                <asp:UpdatePanel ID="TimedPanel" runat="server">
                    <Triggers>
                        
                    </Triggers>
                    <ContentTemplate>
                        <div class="row status" style="margin: 0; padding: 0;">
                            <div class="form-group" style="width: 95%; margin: 0 auto; padding-right: 10px;">                                
                                <asp:HiddenField ID="hdTotalCol" runat="server" />

                                <table border="1" width="100%">
                                    <thead>
                                        <tr>
                                            <th class="headone" width="(100/13)%">Machine/Times</th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime1" runat="server" Text="08.00 - 08.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime2" runat="server" Text="09.00 - 09.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime3" runat="server" Text="10.00 - 10.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime4" runat="server" Text="11.00 - 11.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime5" runat="server" Text="12.00 - 12.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime6" runat="server" Text="13.00 - 13.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime7" runat="server" Text="14.00 - 14.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime8" runat="server" Text="15.00 - 15.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime9" runat="server" Text="16.00 - 16.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime10" runat="server" Text="17.00 - 17.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime11" runat="server" Text="18.00 - 18.59"></asp:Label>
                                            </th>
                                            <th class="headone" colspan="40" width="(100/13)%">
                                                <asp:Label ID="lbTime12" runat="server" Text="19.00 - 19.59"></asp:Label>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rptMachine" runat="server" OnItemDataBound="rptMachine_ItemDataBound">
                                            <ItemTemplate>
                                                <tr id='<%# Eval("mc_name") %>,<%# Eval("mc_code") %>'>
                                                    <asp:HiddenField ID="hdmcName" Value='<%# Eval("mc_name") %>' runat="server" />
                                                    <asp:HiddenField ID="hdMcCode" Value='<%# Eval("mc_name") %>' runat="server" />
                                                    <th class="headmc"><%# Eval("mc_name") %></th>

                                                    <asp:Repeater Visible="true" ID="rptTableMachine" OnItemDataBound="rptTableMachine_ItemDataBound" runat="server">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdmcName" Value='<%# Eval("MC") %>' runat="server" />
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            <td id="col" class="colcontent" runat='server'></td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                                <div class="col-md-12 col-xs-12" style="text-align: center; font-size: 20px; font-weight: bold">
                                    Machine Status
                                    <input type="button" class="btn btn-success" style="width: 20px; height: 30px;background-color:#45f960;border-color:black;" />
                                    RUN &nbsp;
                                    <input type="button" class="btn btn-danger" style="width: 20px; height: 30px;border-color:black;" />
                                    BREAK DOWN &nbsp;
                                    <input type="button" class="btn btn-warning" style="width: 20px; height: 30px;border-color:black;" />
                                    IDLE 
                                </div>
                            </div>
                        </div>
                        <div id="BoxTime">
                            <h1>
                                <asp:Label Font-Bold="true" Font-Size="24px" ID="lbTime" runat="server" Text=""></asp:Label>
                            </h1>
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
        </form>
    </div>
</body>
</html>

