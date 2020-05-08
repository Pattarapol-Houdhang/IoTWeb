<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="PDMeetingProductAllLine.aspx.cs" Inherits="PDMeetingProductAllLine" %>

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

    <link href="js/datatables/jquery.dataTables.min.css" rel="stylesheet" />
    <script type="text/javascript" src="js/datatables/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="js/datatables/dataTables.fixedColumns.min.js"></script>

    <%--<link href="https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>--%>



    <script type="text/javascript" src="Highcharts/highcharts.js"></script>

    <%--<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/MasterOffsetDetail.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-ui-1.10.3.custom.min.js") %>"></script>--%>
</head>
<body>
    <script type='text/javascript'>
        $(document).ready(function () {
            var dataPlanD = new Array();
            var dataPlanN = new Array();
            var dataActualD = new Array();
            var dataActualN = new Array();

            var dataAch = new Array();
            var dataAchD = new Array();
            var dataAchN = new Array();
            var dataDay = new Array();

            var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            var d = new Date();

            var url = 'Production/SourcJsonPDGraph.ashx?Fac=&Line=Main&Mac=&ModelCode=&strDate=&endDate=&Type=allline';
            $.getJSON(url,
            function (data) {
                for (i = 0; i < data.length; i++) {
                    dataPlanD[i] = data[i].PlanD;
                    dataPlanN[i] = data[i].PlanN;

                    dataActualD[i] = data[i].ActualD;
                    dataActualN[i] = data[i].ActualN;

                    dataAch[i] = data[i].Achieve;
                    dataDay[i] = data[i].Day;
                }

                Highcharts.setOptions({
                    lang: {
                        thousandsSep: ','
                    },
                    colors: ['#062ece', '#010c00', '#066f96', '#df0000', '#00870b', '#0c0c0c']
                });

                Highcharts.chart('container', {
                    chart: {
                        type: 'column'
                    },
                    legend: {
                        enabled: true,
                        layout: 'vertical',
                        align: 'left',
                        verticalAlign: 'top',
                        x: parseFloat($(window).width() - 400),
                        y: 50,
                        floating: true,
                        borderWidth: 1,
                        backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF',
                        itemStyle: {
                            font: 'bold 15pt Trebuchet MS, Verdana, sans-serif',
                            color: '#000000'
                        }
                    },
                    credits: {
                        enabled: false
                    },
                    xAxis: {
                        categories: dataDay,//[11, 12, 13, 14, 15, 16, 17],
                        crosshair: true,
                        title: {
                            text: 'Day of ' + monthNames[d.getMonth()],
                            style: {
                                color: Highcharts.getOptions().colors[5],
                                fontSize: '15px'
                            }
                        },
                        labels: {
                            style: {
                                color: Highcharts.getOptions().colors[5],
                                fontSize: '15px'
                            }
                        }
                    },
                    yAxis: [{ // Primary yAxis.
                        //className: 'highcharts-color-0',
                        title: {
                            text: 'Unit',
                            style: {
                                color: Highcharts.getOptions().colors[0],
                                fontSize: '15px'
                            }
                        },
                        labels: {
                            format: '{value} Unit',
                            style: {
                                color: Highcharts.getOptions().colors[0],
                                fontSize: '15px'
                            }
                        },
                        opposite: true
                    }, { // Secondary yAxis
                        //className: 'highcharts-color-1',
                        title: {
                            text: 'Acheive',
                            style: {
                                color: Highcharts.getOptions().colors[4],
                                fontSize: '15px'
                            }
                        },
                        labels: {
                            format: '{value} %',
                            style: {
                                color: Highcharts.getOptions().colors[4],
                                fontSize: '15px'
                            }
                        },
                        min: 0,
                        max: 100
                    }],
                    tooltip: {
                        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                            '<td style="padding:0"><b>{point.y:.1f}</b></td></tr>',
                        footerFormat: '</table>',
                        shared: true,
                        useHTML: true
                    },
                    plotOptions: {
                        column: {
                            pointPadding: 0.2,
                            borderWidth: 0
                        }
                    },
                    series: [{
                        yAxis: 0,
                        type: 'column',
                        name: 'Plan (D) (Units)',
                        data: dataPlanD //[100, 100, 0, 0, 200, 200, 0]

                    }, {
                        yAxis: 0,
                        type: 'column',
                        name: 'Actual (D) (Units)',
                        data: dataActualD //[90, 85, 0, 0, 190, 170, 0]

                    },
                    {
                        yAxis: 0,
                        type: 'column',
                        name: 'Plan (N) (Units)',
                        data: dataPlanN
                    }, {
                        yAxis: 0,
                        type: 'column',
                        name: 'Actual (N) (Units)',
                        data: dataActualN
                    },
                    {
                        yAxis: 1,
                        colors: Highcharts.getOptions().colors[4],
                        type: 'spline',
                        name: 'Acheive (%)',
                        data: dataAch //[90, 85, 100, 100, 95, 85, 100]

                    }]
                });
            });


            var oTable = $('#tbTest').dataTable({
                //"lengthMenu": [[-1, 1], ["All", "1"]],
                "scrollX": true,
                "scrollY": '300px',
                "fixedColumns": {
                    leftColumns: 0
                },
                "ordering": false,
                "paging": false,
                "scrollCollapse": true,
                "searching": false,
                "bInfo": false
            });
        });

        $('#<%= btnWeek.ClientID %>').click(function () {
            alert("swwewewe");
        });

        var parameter = Sys.WebForms.PageRequestManager.getInstance();
        parameter.add_endRequest(function () {
            var oTable = $('#tbTest').dataTable({
                //"lengthMenu": [[-1, 1], ["All", "1"]],
                "scrollX": true,
                "scrollY": '300px',
                "fixedColumns": {
                    leftColumns: 0
                },
                "ordering": false,
                "paging": false,
                "scrollCollapse": true,
                "searching": false,
                "bInfo": false
            });

            $('#<%= btnWeek.ClientID %>').click(function () {
                alert("swwewewe");
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
            top: 170px;
            right: 150px;
            width: auto;
            height: auto;
            color: rgb(0, 0, 0);
            background-color: rgba(168, 223, 255, 0.7);
            vertical-align: middle;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
        }

        .highchart {
            margin-left: 0cm;
            margin-right: 0cm;
        }

        #lbtitle {
            font-family: "Times New Roman", Times, serif;
            fill: #000000;
            font-weight: bold;
            font-size: 50px !important;
            text-align: center;
            letter-spacing: 0.2em;
        }

        /*thead th {
            border-right: 1px solid #111 !important;
        }*/
        #tbTest {
            font-size: 20px;
        }

        table {
            border-spacing: 0px;
            border-collapse: collapse;
            border-top: 1px solid #111 !important;
            border-right: 1px solid #111 !important;
        }
            table tr th {
                border-left: 1px solid #111;
                border-bottom: 0px solid #111 !important;
            }

            table tr td {
                border-left: 1px solid #111;
                border-bottom: 1px solid #111;
            }

            table.dataTable.no-footer {
                border: none;
                /*border-bottom: 1px solid #111;*/
            }

        headerFreez {
            background-color: #6b6b6b;
        }

        .highcharts-title {
            display: none;
        }

        .highcharts-container {
            padding-left: 0px;
            padding-right: 0px;
            margin-left: 0%;
        }

        .highcharts-root {
            width: 100%;
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

        table.display tbody tr:nth-child(even):hover td {
            background-color: #eeffbc !important;
        }

        table.display tbody tr:nth-child(odd):hover td {
            background-color: #eeffbc !important;
        }
    </style>


    <div class="main-warpper">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:Label ID="hdLine" runat="server" Text="" ForeColor="White" BackColor="White"></asp:Label>
            <asp:Label ID="linechoose" runat="server" Text="" ForeColor="White" BackColor="White"></asp:Label>

            <div class="col-md-12 col-xs-12">

                <div class="row" style="display: none">
                    <div class="form-group">
                        <div class="col-md-1 col-xs-1">
                            <asp:Button ID="btnPopup" class="btn btn-primary" runat="server" Text="Setting" />
                        </div>
                    </div>
                </div>

                <div class="row highchart" style="margin: 0; padding: 0;">
                    <div class="form-group">
                        <div class="col-md-12 col-xs-12" style="text-align: center; display: none">
                            <h1>
                                <asp:Label ID="lbtitle" runat="server" Text="Production Acheivement Main Assembly Factory 3"></asp:Label>
                            </h1>
                        </div>
                        <div class="col-md-12 col-xs-12" style="text-align: right">
                            <nobr>
                                <asp:Button ID="btnMonth" runat="server" CssClass="btn" Text="Assembly" Font-Bold="true" />
                                <asp:Button ID="btnWeek" runat="server" CssClass="btn" Text="Machine" Font-Bold="true" />
                            </nobr>
                        </div>
                        <div class="col-md-12 col-xs-12" style="padding-top: 15px;">
                            <div id="container" style="height: 400px !important"></div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin: 0; padding: 0;">

                    <table id="tbTest" style="width: 100%" class="display">
                        <thead>
                            <tr id="rowHeaderDay" runat="server" style="font-size: 20px">
                                <th style="text-align: center; background-color: white;">Assembly Line</th>
                                <th style="text-align: center; background-color: white;">3AMA5</th>
                                <th style="text-align: center; background-color: white;">3AFI9</th>
                                <th style="text-align: center; background-color: white;">3MRH5</th>
                                <th style="text-align: center; background-color: white;">3AST3</th>
                                <th style="text-align: center; background-color: white;">3ACT2</th>
                                <th style="text-align: center; background-color: white;">3ACP5</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptPDMeeting" OnItemDataBound="rptPDMeeting_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <tr style="font-size: 20px">
                                        <td style="text-align: center; font-weight: bold;">
                                            <asp:Label ID="lbHeadRow" runat="server" Text='<%# Eval("HeadRow") %>'></asp:Label>
                                        </td>
                                        <td runat="server" id="tdD1" style="font-weight: bold;">
                                            <asp:Label ID="lbLine3AMA5" runat="server" Text='<%# Eval("Data") %>'></asp:Label>
                                        </td>
                                        <td runat="server" id="td1" style="font-weight: bold;">
                                            <asp:Label ID="lbLine3AFI9" runat="server" Text='<%# Eval("Data") %>'></asp:Label>
                                        </td>
                                        <td runat="server" id="td2" style="font-weight: bold;">
                                            <asp:Label ID="lbLine3MRH5" runat="server" Text='<%# Eval("Data") %>'></asp:Label>
                                        </td>
                                        <td runat="server" id="td3" style="font-weight: bold;">
                                            <asp:Label ID="lbLine3AST3" runat="server" Text='<%# Eval("Data") %>'></asp:Label>
                                        </td>
                                        <td runat="server" id="td4" style="font-weight: bold;">
                                            <asp:Label ID="lbLine3ACT2" runat="server" Text='<%# Eval("Data") %>'></asp:Label>
                                        </td>
                                        <td runat="server" id="td5" style="font-weight: bold;">
                                            <asp:Label ID="lbLine3ACP5" runat="server" Text='<%# Eval("Data") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>


                        </tbody>
                    </table>
                </div>
            </div>


        </form>
    </div>
</body>
</html>

