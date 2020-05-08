<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="PDMeetingEditPlan.aspx.cs" Inherits="PDMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Productivity</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="refresh" content="300" />

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
            var dataTarget = new Array();
            var dataAchD = new Array();
            var dataAchN = new Array();
            var dataDay = new Array();
            var Target = 0;

            var monthNames = ["January", "February", "March", "April", "May", "June","July", "August", "September", "October", "November", "December"];
            var d = new Date();
            var line = $("#<%= ddlLine.ClientID %>").val();

            var url = 'Production/SourcJsonPDGraph.ashx?Fac=&Line=' + line + '&Mac=&ModelCode=&strDate=&endDate=&target=';

            $.getJSON(url,
            function (data) {
                for (i = 0; i < data.length; i++) {
                    dataPlanD[i] = data[i].PlanD;
                    dataPlanN[i] = data[i].PlanN;

                    dataActualD[i] = data[i].ActualD;
                    dataActualN[i] = data[i].ActualN;

                    dataAch[i] = data[i].Achieve;
                    dataTarget[i] = 100;// data[i].Target;
                    dataDay[i] = data[i].Day;

                    Target = data[i].Target;
                }

                Highcharts.setOptions({
                    lang: {
                        thousandsSep: ','
                    },
                    colors: ['#23b5ff', '#0a8200', '#066f96', '#df0000', '#0a0aff', '#0c0c0c', '#000000']
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
                                color: Highcharts.getOptions().colors[6],
                                fontSize: '15px'
                            }
                        },
                        min: 0,
                        max: Target,
                        //alignTicks: false,
                        tickInterval: Target / 5,
                        labels: {
                            format: '{value:,.0f} Unit',
                            style: {
                                color: Highcharts.getOptions().colors[6],
                                fontSize: '15px'
                            }
                        },
                        opposite: true
                    }, { // Secondary yAxis
                        //className: 'highcharts-color-1',
                        title: {
                            text: 'Acheive',
                            style: {
                                color: Highcharts.getOptions().colors[6],
                                fontSize: '15px'
                            }
                        },
                        labels: {
                            format: '{value} %',
                            style: {
                                color: Highcharts.getOptions().colors[6],
                                fontSize: '15px'
                            }
                        },
                        min: 0,
                        max: 100
                    }],
                    tooltip: {
                        headerFormat: '<span style="font-size:15px">{point.key}</span><table>',
                        pointFormat: '<tr><td style="color:{series.color};padding:0;font-weight:bold">{series.name}: </td>' +
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
                        name: 'Plan (Units)',
                        data: dataPlanD 
                    }, {
                        yAxis: 0,
                        type: 'column',
                        name: 'Actual (Units)',
                        data: dataActualD 
                    },
                    {
                        yAxis: 1,
                        colors:"#0a0aff",
                        type: 'line',
                        name: 'Acheive (%)',
                        data: dataAch 
                    },
                    {
                        yAxis: 1,
                        colors: Highcharts.getOptions().colors[3],
                        type: 'line',
                        name: 'Target (%)',
                        data: dataTarget
                    }]
                });
            });


            var oTable = $('#tbTest').dataTable({
                //"lengthMenu": [[-1, 1], ["All", "1"]],
                "scrollX": true,
                //"scrollY": '250px',
                "fixedColumns": {
                    leftColumns: 1
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
                //"scrollY": '250px',
                "fixedColumns": {
                    leftColumns: 1
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
        #tbTest{
            font-size:20px;
        }

        table{
            border-spacing: 0px;
            border-collapse:collapse;
            border-top: 1px solid #111 ;
            border-right: 1px solid #111;
        }

        table tr td{
            border-left: 1px solid #111 ;
            border-bottom: 1px solid #111 ;
        }
        table.dataTable.no-footer{
            border:none;
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
                        <div class="col-md-12 col-xs-12" style="margin-top:10px">
                            <div class="col-md-6 col-xs-6" style="text-align:left">
                                <asp:DropDownList ID="ddlLine" runat="server" Font-Bold="true" Font-Size="Large" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:Button ID="btnSavePlan" runat="server" Text="Save" Class="btn btn-info" OnClick="btnSavePlan_Click" />
                            </div>
                            <div class="col-md-6 col-xs-6" style="text-align:right">
                                <asp:Label ID="lbLastUpdate" runat="server" Text="" style="font-size: large; font-weight: 700; color: #FF5050"></asp:Label>
                            </div>                          
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 col-xs-12" style="text-align: center;">
                            <h1>
                                <asp:Label ID="lbtitle" runat="server" Text="Production Acheivement Main Assembly Factory 3"></asp:Label>
                            </h1>
                        </div>
                        <div class="col-md-12 col-xs-12" style="text-align: right;display:none">
                            <nobr>
                                <asp:Button ID="btnMonth" runat="server" CssClass="btn" Text="MONTH" Font-Bold="true" />
                                <asp:Button ID="btnWeek" runat="server" CssClass="btn" Text="WEEK" Font-Bold="true" />
                                <asp:Button ID="btnDay" runat="server" CssClass="btn" Text="DAY" Font-Bold="true" />
                            </nobr>
                        </div>
                        <div class="col-md-12 col-xs-12" style="padding-top:15px;">
                            <div id="container" style="height: 400px !important"></div>
                        </div>
                    </div>
                </div>

                <div class="row" style="margin: 0; padding: 0;">
                    <table id="tbTest" style="width: 100%" class="display">
                        <thead>
                            <tr id="rowHeaderDay" runat="server" style="font-size:20px">
                                <th style="text-align: center; background-color:white;border-left: 1px solid #111;border-bottom: 1px solid #111;border-right: 1px solid #111;border-top: 1px solid #111;">Day</th>
                                <th colspan="2" style="text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;">
                                    <asp:Label ID="lbDay1" runat="server" Text="1"></asp:Label></th>
                                <th colspan="2" style="text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;">
                                    <asp:Label ID="lbDay2" runat="server" Text="2"></asp:Label></th>
                                <th colspan="2" style="text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;">
                                    <asp:Label ID="lbDay3" runat="server" Text="3"></asp:Label></th>
                                <th colspan="2" style="text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;">
                                    <asp:Label ID="lbDay4" runat="server" Text="4"></asp:Label></th>
                                <th colspan="2" style="text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;">
                                    <asp:Label ID="lbDay5" runat="server" Text="5"></asp:Label></th>
                                <th colspan="2" style="text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;">
                                    <asp:Label ID="lbDay6" runat="server" Text="6"></asp:Label></th>
                                <th colspan="2" style="text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;">
                                    <asp:Label ID="lbDay7" runat="server" Text="7"></asp:Label></th>
                            </tr>
                            <tr id="rowHeaderDN" runat="server"  style="font-size:20px">
                                <th style="text-align: center; background-color: white;border-left: 1px solid #111;border-right: 1px solid #111;">Shift</th>

                                <th style="text-align: center; border-left: 1px solid #111;">D</th>
                                <th style="text-align: center; border-left: 1px solid #111;">N</th>
                                <th style="text-align: center; border-left: 1px solid #111;">D</th>
                                <th style="text-align: center; border-left: 1px solid #111;">N</th>
                                <th style="text-align: center; border-left: 1px solid #111;">D</th>
                                <th style="text-align: center; border-left: 1px solid #111;">N</th>
                                <th style="text-align: center; border-left: 1px solid #111;">D</th>
                                <th style="text-align: center; border-left: 1px solid #111;">N</th>
                                <th style="text-align: center; border-left: 1px solid #111;">D</th>
                                <th style="text-align: center; border-left: 1px solid #111;">N</th>
                                <th style="text-align: center; border-left: 1px solid #111;">D</th>
                                <th style="text-align: center; border-left: 1px solid #111;">N</th>
                                <th style="text-align: center; border-left: 1px solid #111;">D</th>
                                <th style="text-align: center; border-left: 1px solid #111;">N</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptPDMeeting" OnItemDataBound="rptPDMeeting_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <tr  style="font-size:20px">
                                        <td style="text-align: center;font-weight:bold;border-left: 1px solid #111;border-right: 1px solid #111;">
                                            <asp:Label ID="lbHeadRow" runat="server" Text='<%# Eval("HeadRow") %>'></asp:Label>
                                        </td>
                                        <td runat="server" id="tdD1">
                                            <asp:TextBox ID="txtDay_D1" runat="server" Text='<%# Eval("D1_D") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_D1" runat="server" Text='<%# Eval("D1_D") %>'></asp:Label></td>
                                        <td runat="server" id="tdN1">
                                            <asp:TextBox ID="txtDay_N1" runat="server" Text='<%# Eval("D1_N") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_N1" runat="server" Text='<%# Eval("D1_N") %>'></asp:Label></td>
                                        <td runat="server" id="tdD2">
                                            <asp:TextBox ID="txtDay_D2" runat="server" Text='<%# Eval("D2_D") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_D2" runat="server" Text='<%# Eval("D2_D") %>'></asp:Label></td>
                                        <td runat="server" id="tdN2">
                                            <asp:TextBox ID="txtDay_N2" runat="server" Text='<%# Eval("D2_N") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_N2" runat="server" Text='<%# Eval("D2_N") %>'></asp:Label></td>
                                        <td runat="server" id="tdD3">
                                            <asp:TextBox ID="txtDay_D3" runat="server" Text='<%# Eval("D3_D") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_D3" runat="server" Text='<%# Eval("D3_D") %>'></asp:Label></td>
                                        <td runat="server" id="tdN3">
                                            <asp:TextBox ID="txtDay_N3" runat="server" Text='<%# Eval("D3_N") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_N3" runat="server" Text='<%# Eval("D3_N") %>'></asp:Label></td>
                                        <td runat="server" id="tdD4">
                                            <asp:TextBox ID="txtDay_D4" runat="server" Text='<%# Eval("D4_D") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_D4" runat="server" Text='<%# Eval("D4_D") %>'></asp:Label></td>
                                        <td runat="server" id="tdN4">
                                            <asp:TextBox ID="txtDay_N4" runat="server" Text='<%# Eval("D4_N") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_N4" runat="server" Text='<%# Eval("D4_N") %>'></asp:Label></td>
                                        <td runat="server" id="tdD5">
                                            <asp:TextBox ID="txtDay_D5" runat="server" Text='<%# Eval("D5_D") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_D5" runat="server" Text='<%# Eval("D5_D") %>'></asp:Label></td>
                                        <td runat="server" id="tdN5">
                                            <asp:TextBox ID="txtDay_N5" runat="server" Text='<%# Eval("D5_N") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_N5" runat="server" Text='<%# Eval("D5_N") %>'></asp:Label></td>

                                        <td runat="server" id="tdD6">
                                            <asp:TextBox ID="txtDay_D6" runat="server" Text='<%# Eval("D6_D") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_D6" runat="server" Text='<%# Eval("D6_D") %>'></asp:Label></td>
                                        <td runat="server" id="tdN6">
                                            <asp:TextBox ID="txtDay_N6" runat="server" Text='<%# Eval("D6_N") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_N6" runat="server" Text='<%# Eval("D6_N") %>'></asp:Label></td>
                                        <td runat="server" id="tdD7">
                                            <asp:TextBox ID="txtDay_D7" runat="server" Text='<%# Eval("D7_D") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_D7" runat="server" Text='<%# Eval("D7_D") %>'></asp:Label></td>
                                        <td runat="server" id="tdN7">
                                            <asp:TextBox ID="txtDay_N7" runat="server" Text='<%# Eval("D7_N") %>' Visible="false" Width="60px"></asp:TextBox>
                                            <asp:Label ID="lbDay_N7" runat="server" Text='<%# Eval("D7_N") %>'></asp:Label></td>                                        
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

