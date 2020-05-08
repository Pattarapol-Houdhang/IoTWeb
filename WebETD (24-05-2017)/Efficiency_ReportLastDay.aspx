<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Efficiency_ReportLastDay.aspx.cs" Inherits="Efficiency_ReportLastDay" %>

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
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.min.js"></script>
    <link href="css/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="js/datatables/datatables.css" rel="stylesheet" />
    <script type="text/javascript" src="js/datatables.js"></script>



    <script type="text/javascript" src="Highcharts/highcharts.js"></script>

    <%--<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/MasterOffsetDetail.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-ui-1.10.3.custom.min.js") %>"></script>--%>
</head>
<body>
    <script type='text/javascript'>
        $(document).ready(function () {
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
            var output = (('' + day).length < 2 ? '0' : '') + day + '/'
                + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();
            var Line = $("#<%= ddlLine.ClientID %>").val();

            var jsonData = [];
            var url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=&Mac=&ModelCode=&strDate=&endDate=&target=last';
            $('#<%= lbtitle.ClientID %>').text('Line Efficiency Main Assemby Factory 3');
            if (LineName == "mecha") {
                url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=mecha&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Mecha Factory 3');
            } else if (LineName == "casing") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=casing&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Casing Line Factory 3');
            } else if (LineName == "motor") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=motor&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Motor Line Factory 3');
            } else if (LineName == "piston") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=piston&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Piston Line Factory 3');
            } else if (LineName == "fh") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=fh&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Front head Line Factory 3');
            } else if (LineName == "cs") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=cs&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Crankshaft Factory 3');
            } else if (LineName == "cd") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=cd&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Cylinder Factory 3');
            } else if (LineName == "rh") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=rh&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Rear Head Factory 3');
            } else if (LineName == "fn") {
                url = 'Production/SourcJson.ashx?CycleTime=30&Fac=&Line=fn&Mac=&ModelCode=&strDate=&endDate=&target=last';
                $('#<%= lbtitle.ClientID %>').text('Line Efficiency Final Line Factory 3');
            }

            function commaSeparateNumber(val) {
                while (/(\d+)(\d{3})/.test(val.toString())) {
                    val = val.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
                }
                return val;
            }

            $.getJSON(url,
            function (data) {
                var _EffVal = 0;
                var _Plan = 0;
                var _Actual = 0;
                var _MaxActual = 0;
                for (i = 0; i < data.length; i++) {
                    dataPlan[i] = data[i].PlanAccu;
                    dataActual[i] = data[i].ActualAccu;
                    dataEff[i] = data[i].EffiAccu;
                    processed_jsonDate.push([
                        data[i].DatePlan
                    ]);

                    if (parseInt(data[i].EffiAccu) > 0) {
                        _EffVal = data[i].EffiAccu;
                    }
                    if (parseInt(data[i].ActualAccu) > 0) {
                        _Actual = data[i].ActualAccu;
                        if (_Actual > _MaxActual) {
                            _MaxActual = _Actual
                        }
                    }
                    if (parseInt(data[i].PlanAccu) > 0) {
                        _Plan = data[i].PlanAccu;
                    }

                    MaxData = data[i].Target;
                }
                //_EffVal.toFixed(0)
                $('#<%= lbEff.ClientID %>').text(((parseInt(_MaxActual) * 100) / parseInt(MaxData)).toFixed(0));
                $('#<%= lbPlan.ClientID %>').text(commaSeparateNumber(MaxData));
                $('#<%= lbActual.ClientID %>').text(commaSeparateNumber(_MaxActual));

                Highcharts.setOptions({
                    lang: {
                        thousandsSep: ','
                    },
                    colors: ['#062ece', '#1b930b', '#960c07', '#DDDF00', '#00870b', '#870000','#000000']
                });

                Highcharts.chart('container', {

                    title: {
                    },
                    subtitle: {
                        text: null
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
                        tickInterval: MaxData/5
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
                        split: false
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
                //---------- Line Efficeincy -------
            });

            //--------- Set Box Efficiency Warnning Blink ------------
            //var $el = $(".item-block"),
            //    x = 500,
            //    originalColor = $el.css("background"),
            //    i = 3; //counter

            //(function loop() { //recurisve IIFE
            //    $el.css("background", "#f97a7a");
            //    setTimeout(function () {
            //        $el.css("background", originalColor);
            //        if (--i) setTimeout(loop, x); //restart loop
            //    }, x);
            //}());

            //$("#BoxTime").click(function () {
            //    $("#BoxDate").slideToggle('fast');
            //});
            //$("#BoxDate").slideToggle('fast');

            //var CurDate = new Date;

            //$("#datepicker").datepicker({
            //    dateFormat: 'yy-mm-dd',
            //    maxDate: new Date(CurDate.getFullYear(), CurDate.getMonth(), CurDate.getDate() - 1),
            //    minDate: new Date(2000, 6, 12)
            //});
        });

    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            var oTable = $('#tbTest').dataTable({
                "lengthMenu": [[-1], ["All"]],
                "scrollX": true,
                "scrollY": '45vh',
                "scrollCollapse": true
            });
        });

        var parameter = Sys.WebForms.PageRequestManager.getInstance();
        parameter.add_endRequest(function () {
            var oTable = $('#tbTest').dataTable({
                "lengthMenu": [[-1], ["All"]],
                "scrollX": true,
                "scrollY": '45vh',
                "scrollCollapse": true
            });
        });
    </script>

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

        #BoxTime2 {
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

        #tbEffShow th, #tbEffShow td{
            padding:3px 5px !important;
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

            <asp:Label ID="hdLine" runat="server" Text="" ForeColor="White" BackColor="White"></asp:Label>
            <asp:Label ID="linechoose" runat="server" Text="" ForeColor="White" BackColor="White"></asp:Label>

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
                    <asp:Label Font-Bold="true" Font-Size="24px" ID="lbTime" runat="server" Text="Line : " Visible="true" ForeColor="Black"></asp:Label>
                    <asp:DropDownList ID="ddlLineName" Font-Size="24px" Font-Bold="true" runat="server" OnSelectedIndexChanged="ddlLineName_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div id="BoxTime2">
                    <asp:Label Font-Bold="true" Font-Size="24px" ID="lbLastDay" runat="server" Text="" Visible="true" ForeColor="Black"></asp:Label>
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
                    </Triggers>
                    <ContentTemplate>

                        <div id="BoxTimeLastUpdate">
                            <asp:Label ID="lbLastUpdate" runat="server" ForeColor="Black" Font-Size="20px" Text="" Visible="false"></asp:Label>
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
                                                    <asp:HiddenField ID="hdMcCode" Value='<%# Eval("mc_name") %>' runat="server" />
                                                    <th class="headmc" style="font-size: 20px; font-weight: bold"><%# Eval("mc_name") %></th>

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
                                    <input type="button" class="btn btn-success" style="width: 20px; height: 30px; background-color: #45f960; border-color: black;" />
                                    RUN &nbsp;
                                    <input type="button" class="btn btn-danger" style="width: 20px; height: 30px; border-color: black;" />
                                    BREAK DOWN &nbsp;
                                    <input type="button" class="btn btn-warning" style="width: 20px; height: 30px; border-color: black;" />
                                    IDLE 
                                </div>
                            </div>
                        </div>


                    </ContentTemplate>
                </asp:UpdatePanel>
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
        </form>
    </div>
</body>
</html>

