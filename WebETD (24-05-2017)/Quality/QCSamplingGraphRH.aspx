<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="QCSamplingGraphRH.aspx.cs" Inherits="Quality_QCSamplingGraphRH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>

    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/dataTables.buttons.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.flash.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jszip.min.js") %>"></script>
    <%--<script src="<%= ResolveUrl("~/StyleMax/js/pdfmake.min.js") %>"></script>--%>
    <script src="<%= ResolveUrl("~/StyleMax/js/vfs_fonts.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.html5.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.print.min.js") %>"></script>

    <link href="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />

    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.themes.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.themes.min.css") %>" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/StyleMax/autocomplete/jquery.easy-autocomplete.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/autocomplete/jquery.easy-autocomplete.min.js") %>"></script>

    <%--<script src="<%= ResolveUrl("~/Highcharts/highstock.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/exporting.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/modules/exporting.js") %>"></script>--%>

    <script src="<%= ResolveUrl("~/Highcharts/highcharts.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/modules/data.js") %>"></script>
    <script src="<%= ResolveUrl("~/js/moment.js") %>"></script>

    <script type="text/javascript">
        function FormatNumberLength(num, length) {
            var r = "" + num;
            while (r.length < length) {
                r = "0" + r;
            }
            return r;
        }



        function LoadData() {


            var start = moment().subtract(29, 'days');
            var end = moment();

            var d = new Date();
            var month = d.getMonth() + 1;
            var day = d.getDate();
            var year = d.getFullYear();
            var date = year + "/" + month + "/" + day + " 08:00 - " + year + "/" + month + "/" + day + " 20:00";
            var _StartDate = year + "/" + month + "/" + day + " 08:00";
            var _EndDate = year + "/" + month + "/" + day + " 20:00";

            //------------------ Prd Date ----------------------
            $('#<%= txtPrdDate.ClientID %>').daterangepicker({
                autoUpdateInput: true,
                locale: {
                    cancelLabel: 'Clear',
                    format: 'YYYY/MM/DD HH:mm'
                },
                timePicker: true,
                timePickerIncrement: 5,
                timePicker24Hour: true,
                startDate: _StartDate,
                endDate: _EndDate

            });


            $('#<%= txtPrdDate.ClientID %>').on('apply.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val(picker3.startDate.format('YYYY/MM/DD HH:mm') + ' - ' + picker3.endDate.format('YYYY/MM/DD HH:mm'));
                var id = "<%= txtPrdDate.ClientID %>";
                /*CaldiffDay(picker3, id);*/

            });
            $('#<%= txtPrdDate.ClientID %>').on('cancel.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val('');
            });
            //------------------ Prd Date ----------------------

            <%--$('#<%= btnManual.ClientID %>').on('click', function () {
                var url = $(this).data('link');
                if (url != "") {
                    window.open(url);
                }

            });--%>

        }


        //---------- Calculate StartDay - EndDay for alert in case more than 31 days -----------------------
        function CaldiffDay(picker, txtID) {
            var spStrDate = picker.startDate.format('YYYY/MM/DD HH:mm').split("/");
            var strDate = new Date(spStrDate[2], spStrDate[1] - 1, spStrDate[0]);

            var spEndDate = picker.endDate.format('YYYY/MM/DD HH:mm').split("/");
            var endDate = new Date(spEndDate[2], spEndDate[1] - 1, spEndDate[0]);

            var diffDay = new Date(endDate - strDate);
            var days = diffDay / 1000 / 60 / 60 / 24;

            if (days > 31) {
                $("#" + txtID).val('');
                alert('ไม่สามารถเลือกช่วงเวลาเกิน 31 วันได้ครับ');
            }
        }
        //---------- Calculate StartDay - EndDay for alert in case more than 31 days -----------------------



    </script>

    <style>
        .modal {
            position: fixed !important;
            z-index: 999 !important;
            height: 100% !important;
            width: 100% !important;
            top: 0 !important;
            background-color: Black !important;
            filter: alpha(opacity=60) !important;
            opacity: 0.8 !important;
            display: block !important;
            -moz-opacity: 0.8;
        }


        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 150px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 0.8;
        }

            .center img {
                height: 128px;
                width: 128px;
            }
    </style>

    <%-- <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DynamicLayout="false" DisplayAfter="0">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>

    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <script type="text/javascript" language="javascript">
        Sys.Application.add_load(LoadData);
    </script>

    <section class="wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>QC Sampling: <small>Quality Graph</small></h3>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <header class="panel-heading">
                        Searching
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <div class="row">
                                <label class="col-sm-1 control-label" style="text-align: right!important">Part Type:</label>
                                <div class="col-sm-2">
                                    <%--<asp:DropDownList ID="ddlPartType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPartType_SelectedIndexChanged"></asp:DropDownList>--%>
                                    <asp:Label ID="lbPartType" runat="server" ForeColor="red" Font-Bold="true" Text="Rear Head"></asp:Label>
                                </div>



                            </div>

                            <div runat="server" class="row" style="margin-top: 10px">
                                <label class="col-sm-1 control-label" style="text-align: right!important">Main Point</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlMainPoint" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMainPoint_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <label class="col-sm-1 control-label" style="text-align: right!important">Sub Point</label>
                                <div class="col-sm-2">
                                    <asp:DropDownList ID="ddlSubPoint" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>

                            </div>


                            <div id="search_datetime" runat="server" class="row" style="margin-top: 10px">
                                <label class="col-sm-1 control-label" style="text-align: right!important">Production Date</label>
                                <div class="col-sm-3">
                                    <asp:TextBox ID="txtPrdDate" runat="server" class="form-control" Text=""></asp:TextBox>
                                </div>
                            </div>


                            <div class="row" style="margin-top: 10px">
                                <div class="col-sm-2">
                                    <asp:Button ID="btnSearch" runat="server" class="btn btn-success btn-lg" Text="Show" OnClientClick="CheckMainGraph()" />
                                </div>
                            </div>
                        </div>

                    </div>
                </section>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <header class="panel-heading">
                        Data
                    </header>
                    <div class="panel-body">
                        <div class="form-group">

                            <div id="RHRoundness" style="height: 400px"></div>
                            <div id="RHPerpan" style="height: 400px"></div>
                            <%--<div id="FHIDConcentric" style="height: 400px"></div>--%>



                            <script>
                                $(document).ready(function () {
                                    LoadGraphRH();
                                    LoadDataRH();
                                });

                                function CheckMainGraph() {
                                    var e = document.getElementById('<%=ddlMainPoint.ClientID %>');
                                    var Main = e.options[e.selectedIndex].value;
                                    if (Main = "ID") {
                                        LoadDataRH();
                                    }

                                }

                                var ShiftPD = "D";
                                var DatePD = moment().format("YYYY-MM-DD HH:mm:ss");
                                var DatePDStart = moment().format("YYYY-MM-DD HH:mm:ss");
                                var DatePDEnd = moment().format("YYYY-MM-DD HH:mm:ss");
                                DatePD = new Date(DatePD);
                                //DatePD = "2018-12-10";
                                if (DatePD > new Date(moment().format("YYYY-MM-DD") + " 08:00")
                                    && DatePD < new Date(moment().format("YYYY-MM-DD") + " 20:00")) {
                                    DatePDStart = moment().format("YYYY-MM-DD") + " 08:00";
                                    DatePDEnd = moment().format("YYYY-MM-DD") + " 20:00";
                                    //DatePD = moment().add(1, 'days').format("YYYY-MM-DD");
                                    ShiftPD = "D";
                                } else if (DatePD > new Date(moment().format("YYYY-MM-DD") + " 20:00")) {
                                    DatePDStart = moment().format("YYYY-MM-DD") + " 20:00";
                                    DatePDEnd = moment().add(1, 'days').format("YYYY-MM-DD") + " 08:00";
                                    ShiftPD = "N";
                                } else if (DatePD < new Date(moment().format("YYYY-MM-DD") + " 08:00")) {
                                    DatePDStart = moment().add(-1, 'days').format("YYYY-MM-DD") + " 20:00";
                                    DatePDEnd = moment().format("YYYY-MM-DD") + " 08:00";
                                    ShiftPD = "N";
                                }

                                var _DateStart = "";
                                var _DateEnd = "";
                                var txtDate = document.getElementById('<%= txtPrdDate.ClientID %>').value;
                                if (txtDate != "") {
                                    var spl = txtDate.split(" - ");
                                    _DateStart = spl[0];
                                    _DateEnd = spl[1];
                                } else {
                                    _DateStart = DatePDStart;
                                    _DateEnd = DatePDEnd;
                                }

                                var RH_ID_DateLabel = [], RH_RN_DateLabel = [], RH_CY_DateLabel = [], RH_PP_DateLabel = [], RH_CO_DateLabel = [];
                                var RH_ID_MQMax = [], RH_ID_MQMin = [], RH_ID_UCL = [], RH_ID_CL = [], RH_ID_LCL = [];
                                var RH_RN_MQMax = [], RH_RN_MQMin = [], RH_RN_UCL = [], RH_RN_CL = [], RH_RN_LCL = [];
                                var RH_CY_MQMax = [], RH_CY_MQMin = [], RH_CY_UCL = [], RH_CY_CL = [], RH_CY_LCL = [];
                                var RH_PP_MQMax = [], RH_PP_MQMin = [], RH_PP_UCL = [], RH_PP_CL = [], RH_PP_LCL = [];
                                var RH_CO_MQMax = [], RH_CO_MQMin = [], RH_CO_UCL = [], RH_CO_CL = [], RH_CO_LCL = [];
                                var rh_id1 = [];
                                var rh_judge_roundness = [];
                                var rh_cylindricity = [];
                                var rh_perpendicularity = [];

                                function LoadDataRH() {
                                    $.ajax({
                                        url: "GetGraphDataRH.ashx?DateStart=" + _DateStart + "&DateEnd=" + _DateEnd + "&RowsQty=0",
                                        dataType: "json",
                                        async: true,
                                        success: function (data) {


                                            //data.ListOfID[0].fh_id1;
                                            RH_ID_DateLabel = [], RH_RN_DateLabel = [], RH_CY_DateLabel = [], RH_PP_DateLabel = [], RH_CO_DateLabel = [];
                                            RH_ID_MQMax = [], RH_ID_MQMin = [], RH_ID_UCL = [], RH_ID_CL = [], RH_ID_LCL = [];
                                            RH_RN_MQMax = [], RH_RN_MQMin = [], RH_RN_UCL = [], RH_RN_CL = [], RH_RN_LCL = [];
                                            RH_CY_MQMax = [], RH_CY_MQMin = [], RH_CY_UCL = [], RH_CY_CL = [], RH_CY_LCL = [];
                                            RH_PP_MQMax = [], RH_PP_MQMin = [], RH_PP_UCL = [], RH_PP_CL = [], RH_PP_LCL = [];
                                            RH_CO_MQMax = [], RH_CO_MQMin = [], RH_CO_UCL = [], RH_CO_CL = [], RH_CO_LCL = [];
                                            rh_id1 = [];
                                            rh_judge_roundness = [];
                                            rh_cylindricity = [];
                                            rh_perpendicularity = [];


                                            for (i = 0; i < data.ListOfRH.length; i++) {
                                                //RH_DateLabel.push(data.ListOfRH[i].first_stamptime);

                                                if (data.ListOfRH[i].SubPoint == "ID") {
                                                    RH_ID_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                                    RH_ID_MQMax.push(data.ListOfRH[i].MQMax);
                                                    RH_ID_MQMin.push(data.ListOfRH[i].MQMin);
                                                    RH_ID_UCL.push(data.ListOfRH[i].UCL);
                                                    RH_ID_CL.push(data.ListOfRH[i].CL);
                                                    RH_ID_LCL.push(data.ListOfRH[i].LCL);
                                                    rh_id1.push(data.ListOfRH[i].rh_id1);
                                                } else if (data.ListOfRH[i].SubPoint == "Roundness") {
                                                    RH_RN_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                                    RH_RN_MQMax.push(data.ListOfRH[i].MQMax);
                                                    RH_RN_MQMin.push(data.ListOfRH[i].MQMin);
                                                    RH_RN_UCL.push(data.ListOfRH[i].UCL);
                                                    RH_RN_CL.push(data.ListOfRH[i].CL);
                                                    RH_RN_LCL.push(data.ListOfRH[i].LCL);
                                                    rh_judge_roundness.push(data.ListOfRH[i].rh_judge_roundness);
                                                } else if (data.ListOfRH[i].SubPoint == "Cylindricity") {
                                                    RH_CY_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                                    RH_CY_MQMax.push(data.ListOfRH[i].MQMax);
                                                    RH_CY_MQMin.push(data.ListOfRH[i].MQMin);
                                                    RH_CY_UCL.push(data.ListOfRH[i].UCL);
                                                    RH_CY_CL.push(data.ListOfRH[i].CL);
                                                    RH_CY_LCL.push(data.ListOfRH[i].LCL);
                                                    rh_cylindricity.push(data.ListOfRH[i].rh_cylindricity);
                                                } else if (data.ListOfRH[i].SubPoint == "Perpan") {
                                                    RH_PP_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                                    RH_PP_MQMax.push(data.ListOfRH[i].MQMax);
                                                    RH_PP_MQMin.push(data.ListOfRH[i].MQMin);
                                                    RH_PP_UCL.push(data.ListOfRH[i].UCL);
                                                    RH_PP_CL.push(data.ListOfRH[i].CL);
                                                    RH_PP_LCL.push(data.ListOfRH[i].LCL);
                                                    rh_perpendicularity.push(data.ListOfRH[i].rh_perpendicularity);
                                                }

                                            }

                                            LoadGraphRH();

                                        },
                                        error: function (e) {
                                            alert(DatePDStart + ' ' + DatePDEnd);
                                        }
                                    });

                                }

                                function LoadGraphRH() {
                                    // ************** Roundness ******************
                                    Highcharts.chart('RHRoundness', {

                                        title: {
                                            text: 'Rear Head Roundness'
                                        }
                                        ,
                                        xAxis: {
                                            categories: RH_RN_DateLabel
                                        }
                                        ,
                                        yAxis: {
                                            title: {
                                                text: 'Actual',
                                                style: {
                                                    color: '#000000'
                                                }
                                            },
                                            labels: {
                                                format: '{value: point.y .4f}',
                                                style: {
                                                    color: '#000000'
                                                }
                                            },
                                            tickInterval: 0.0010,
                                            gridLineWidth: 0,
                                            max: RH_RN_UCL[0] + 0.0030
                                        },
                                        plotOptions: {
                                            series: {
                                                label: {
                                                    connectorAllowed: false
                                                }
                                            },
                                            turboThreshold: 0
                                        },
                                        tooltip: {
                                            shared: true,
                                            useHTML: true,
                                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                                            footerFormat: '</table>',
                                            valueDecimals: 4
                                        },
                                        legend: {
                                            align: 'right',
                                            x: -90,
                                            verticalAlign: 'top',
                                            y: 25,
                                            floating: true,
                                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                                            borderColor: '#ffffff',
                                            borderWidth: 1,
                                            shadow: false
                                        },
                                        series: [{
                                            name: 'Actual',
                                            color: '#1efff3',
                                            data: rh_judge_roundness,
                                            type: 'line',
                                            lineWidth: 2,
                                            dataLabels: {
                                                enabled: false,
                                                color: '#ffffff'
                                            },
                                            marker: {
                                                enabled: false
                                            }
                                        }, {
                                            name: 'UCL',
                                            color: '#FF5733',
                                            data: RH_RN_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: RH_RN_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: RH_RN_MQMax,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });


                                    // **************** Perpen *********************
                                    Highcharts.chart('RHPerpan', { // ***************** Edit name of div tag.

                                        title: {
                                            text: 'Rear Head Perpan' // ***************** edit name of graph
                                        }
                                        ,
                                        xAxis: {
                                            categories: RH_PP_DateLabel
                                        }
                                        ,
                                        yAxis: {
                                            title: {
                                                text: 'Actual',
                                                style: {
                                                    color: '#000000'
                                                }
                                            },
                                            labels: {
                                                format: '{value: point.y .4f}',
                                                style: {
                                                    color: '#000000'
                                                }
                                            },
                                            tickInterval: 0.0010,
                                            gridLineWidth: 0,
                                            max: RH_PP_UCL[0] + 0.0030 // ***************** edit max of yAxis
                                        },
                                        plotOptions: {
                                            series: {
                                                label: {
                                                    connectorAllowed: false
                                                }
                                            },
                                            turboThreshold: 0
                                        },
                                        tooltip: {
                                            shared: true,
                                            useHTML: true,
                                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                                            footerFormat: '</table>',
                                            valueDecimals: 4
                                        },
                                        legend: {
                                            align: 'right',
                                            x: -90,
                                            verticalAlign: 'top',
                                            y: 25,
                                            floating: true,
                                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                                            borderColor: '#ffffff',
                                            borderWidth: 1,
                                            shadow: false
                                        },
                                        series: [{
                                            name: 'Actual',
                                            color: '#1efff3',
                                            data: rh_perpendicularity, // ***************** edit to field of Point type
                                            type: 'line',
                                            lineWidth: 2,
                                            dataLabels: {
                                                enabled: false,
                                                color: '#ffffff'
                                            },
                                            marker: {
                                                enabled: false
                                            }
                                        }, {
                                            name: 'UCL',
                                            color: '#FF5733',
                                            data: RH_PP_UCL, // ***************** edit to field of Point type
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: RH_PP_CL, // ***************** edit to field of Point type
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: RH_PP_MQMax, // ***************** edit to field of Point type
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });


                                }


                            </script>

                        </div>
                    </div>
                </section>
            </div>
        </div>
        <!-- Basic Forms & Horizontal Forms-->
    </section>
    <%--</ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlMainPoint" />
        </Triggers>
    </asp:UpdatePanel>--%>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
</asp:Content>

