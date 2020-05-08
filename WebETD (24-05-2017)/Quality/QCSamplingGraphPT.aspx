<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="QCSamplingGraphPT.aspx.cs" Inherits="Quality_QCSamplingGraphPT" %>

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
                                    <asp:Label ID="lbPartType" runat="server" ForeColor="red" Font-Bold="true" Text="Piston"></asp:Label>
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

                            <div id="PTIDRoundness" style="height: 400px"></div>
                            <div id="PTIDPerpan" style="height: 400px"></div>
                            <div id="PTODRoundness" style="height: 400px"></div>
                            <div id="PTODPerpan" style="height: 400px"></div>
                            <div id="PTBladePerpan" style="height: 400px"></div>
                            <div id="PTHeightParallel" style="height: 400px"></div>
                            <div id="PTBladeParallel" style="height: 400px"></div>


                            <script>
                                $(document).ready(function () {
                                    LoadGraphPT();
                                    LoadDataPT();
                                });

                                function CheckMainGraph() {
                                    var e = document.getElementById('<%=ddlMainPoint.ClientID %>');
                                    var Main = e.options[e.selectedIndex].value;
                                    //if (Main = "ID") {
                                    //    LoadDataCS();
                                    //}
                                    LoadDataPT();

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

                                var PT_ID_ID_DateLabel = [], PT_ID_RN_DateLabel = [], PT_ID_CY_DateLabel = [], PT_ID_PP_DateLabel = [], PT_ID_CO_DateLabel = [];
                                var PT_OD_ID_DateLabel = [], PT_OD_RN_DateLabel = [], PT_OD_CY_DateLabel = [], PT_OD_PP_DateLabel = [], PT_OD_CO_DateLabel = [];
                                var PT_BL_TN_DateLabel = [], PT_BL_PL_DateLabel = [], PT_BL_PP_DateLabel = [];
                                var PT_HE_HE_DateLabel = [], PT_HE_PL_DateLabel = [];

                                var PT_ID_ID_MQMax = [], PT_ID_ID_MQMin = [], PT_ID_ID_UCL = [], PT_ID_ID_CL = [], PT_ID_ID_LCL = [];
                                var PT_ID_RN_MQMax = [], PT_ID_RN_MQMin = [], PT_ID_RN_UCL = [], PT_ID_RN_CL = [], PT_ID_RN_LCL = [];
                                var PT_ID_CY_MQMax = [], PT_ID_CY_MQMin = [], PT_ID_CY_UCL = [], PT_ID_CY_CL = [], PT_ID_CY_LCL = [];
                                var PT_ID_PP_MQMax = [], PT_ID_PP_MQMin = [], PT_ID_PP_UCL = [], PT_ID_PP_CL = [], PT_ID_PP_LCL = [];
                                var PT_ID_CO_MQMax = [], PT_ID_CO_MQMin = [], PT_ID_CO_UCL = [], PT_ID_CO_CL = [], PT_ID_CO_LCL = [];

                                var PT_OD_ID_MQMax = [], PT_OD_ID_MQMin = [], PT_OD_ID_UCL = [], PT_OD_ID_CL = [], PT_OD_ID_LCL = [];
                                var PT_OD_RN_MQMax = [], PT_OD_RN_MQMin = [], PT_OD_RN_UCL = [], PT_OD_RN_CL = [], PT_OD_RN_LCL = [];
                                var PT_OD_CY_MQMax = [], PT_OD_CY_MQMin = [], PT_OD_CY_UCL = [], PT_OD_CY_CL = [], PT_OD_CY_LCL = [];
                                var PT_OD_PP_MQMax = [], PT_OD_PP_MQMin = [], PT_OD_PP_UCL = [], PT_OD_PP_CL = [], PT_OD_PP_LCL = [];
                                var PT_OD_CO_MQMax = [], PT_OD_CO_MQMin = [], PT_OD_CO_UCL = [], PT_OD_CO_CL = [], PT_OD_CO_LCL = [];

                                var PT_BL_TN_MQMax = [], PT_BL_TN_MQMin = [], PT_BL_TN_UCL = [], PT_BL_TN_CL = [], PT_BL_TN_LCL = [];
                                var PT_BL_PL_MQMax = [], PT_BL_PL_MQMin = [], PT_BL_PL_UCL = [], PT_BL_PL_CL = [], PT_BL_PL_LCL = [];
                                var PT_BL_PP_MQMax = [], PT_BL_PP_MQMin = [], PT_BL_PP_UCL = [], PT_BL_PP_CL = [], PT_BL_PP_LCL = [];

                                var PT_HE_HE_MQMax = [], PT_HE_HE_MQMin = [], PT_HE_HE_UCL = [], PT_HE_HE_CL = [], PT_HE_HE_LCL = [];
                                var PT_HE_PL_MQMax = [], PT_HE_PL_MQMin = [], PT_HE_PL_UCL = [], PT_HE_PL_CL = [], PT_HE_PL_LCL = [];

                                var pt_id_rank = [];
                                var pt_id_roundness = [];
                                var pt_id_cylindricity = [];
                                var pt_id_perpendicularity = [];
                                var pt_id_concentricity = [];
                                var pt_od_rank = [];
                                var pt_od_judge_roundness = [];
                                var pt_od_cylindricity = [];
                                var pt_od_perpendicularity = [];
                                var pt_bl_rank = [];
                                var pt_bl_parallism = [];
                                var pt_bl_perpendicularity = [];
                                var pt_he_rank = [];
                                var pt_he_parallism = [];

                                function LoadDataPT() {
                                    $.ajax({
                                        url: "GetGraphDataPT.ashx?DateStart=" + _DateStart + "&DateEnd=" + _DateEnd + "&RowsQty=0",
                                        dataType: "json",
                                        async: true,
                                        success: function (data) {
                                            
                                            PT_ID_ID_DateLabel = [], PT_ID_RN_DateLabel = [], PT_ID_CY_DateLabel = [], PT_ID_PP_DateLabel = [], PT_ID_CO_DateLabel = [];
                                            PT_OD_ID_DateLabel = [], PT_OD_RN_DateLabel = [], PT_OD_CY_DateLabel = [], PT_OD_PP_DateLabel = [], PT_OD_CO_DateLabel = [];
                                            PT_BL_TN_DateLabel = [], PT_BL_PL_DateLabel = [], PT_BL_PP_DateLabel = [];
                                            PT_HE_HE_DateLabel = [], PT_HE_PL_DateLabel = [];

                                            PT_ID_ID_MQMax = [], PT_ID_ID_MQMin = [], PT_ID_ID_UCL = [], PT_ID_ID_CL = [], PT_ID_ID_LCL = [];
                                            PT_ID_RN_MQMax = [], PT_ID_RN_MQMin = [], PT_ID_RN_UCL = [], PT_ID_RN_CL = [], PT_ID_RN_LCL = [];
                                            PT_ID_CY_MQMax = [], PT_ID_CY_MQMin = [], PT_ID_CY_UCL = [], PT_ID_CY_CL = [], PT_ID_CY_LCL = [];
                                            PT_ID_PP_MQMax = [], PT_ID_PP_MQMin = [], PT_ID_PP_UCL = [], PT_ID_PP_CL = [], PT_ID_PP_LCL = [];
                                            PT_ID_CO_MQMax = [], PT_ID_CO_MQMin = [], PT_ID_CO_UCL = [], PT_ID_CO_CL = [], PT_ID_CO_LCL = [];

                                            PT_OD_ID_MQMax = [], PT_OD_ID_MQMin = [], PT_OD_ID_UCL = [], PT_OD_ID_CL = [], PT_OD_ID_LCL = [];
                                            PT_OD_RN_MQMax = [], PT_OD_RN_MQMin = [], PT_OD_RN_UCL = [], PT_OD_RN_CL = [], PT_OD_RN_LCL = [];
                                            PT_OD_CY_MQMax = [], PT_OD_CY_MQMin = [], PT_OD_CY_UCL = [], PT_OD_CY_CL = [], PT_OD_CY_LCL = [];
                                            PT_OD_PP_MQMax = [], PT_OD_PP_MQMin = [], PT_OD_PP_UCL = [], PT_OD_PP_CL = [], PT_OD_PP_LCL = [];
                                            PT_OD_CO_MQMax = [], PT_OD_CO_MQMin = [], PT_OD_CO_UCL = [], PT_OD_CO_CL = [], PT_OD_CO_LCL = [];

                                            PT_BL_TN_MQMax = [], PT_BL_TN_MQMin = [], PT_BL_TN_UCL = [], PT_BL_TN_CL = [], PT_BL_TN_LCL = [];
                                            PT_BL_PL_MQMax = [], PT_BL_PL_MQMin = [], PT_BL_PL_UCL = [], PT_BL_PL_CL = [], PT_BL_PL_LCL = [];
                                            PT_BL_PP_MQMax = [], PT_BL_PP_MQMin = [], PT_BL_PP_UCL = [], PT_BL_PP_CL = [], PT_BL_PP_LCL = [];

                                            PT_HE_HE_MQMax = [], PT_HE_HE_MQMin = [], PT_HE_HE_UCL = [], PT_HE_HE_CL = [], PT_HE_HE_LCL = [];
                                            PT_HE_PL_MQMax = [], PT_HE_PL_MQMin = [], PT_HE_PL_UCL = [], PT_HE_PL_CL = [], PT_HE_PL_LCL = [];

                                            pt_id_rank = [];
                                            pt_id_roundness = [];
                                            pt_id_cylindricity = [];
                                            pt_id_perpendicularity = [];
                                            pt_id_concentricity = [];
                                            pt_od_rank = [];
                                            pt_od_judge_roundness = [];
                                            pt_od_cylindricity = [];
                                            pt_od_perpendicularity = [];
                                            pt_bl_rank = [];
                                            pt_bl_parallism = [];
                                            pt_bl_perpendicularity = [];
                                            pt_he_rank = [];
                                            pt_he_parallism = [];


                                            for (i = 0; i < data.ListOfPT.length; i++) {
                                                //PT_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                if (data.ListOfPT[i].MainPoint == "ID") {
                                                    if (data.ListOfPT[i].SubPoint == "ID") {
                                                        PT_ID_ID_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_ID_ID_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_ID_ID_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_ID_ID_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_ID_ID_CL.push(data.ListOfPT[i].CL);
                                                        PT_ID_ID_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_id_rank.push(data.ListOfPT[i].pt_id_rank);
                                                    } else if (data.ListOfPT[i].SubPoint == "Roundness") {
                                                        PT_ID_RN_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_ID_RN_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_ID_RN_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_ID_RN_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_ID_RN_CL.push(data.ListOfPT[i].CL);
                                                        PT_ID_RN_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_id_roundness.push(data.ListOfPT[i].pt_id_roundness);
                                                    } else if (data.ListOfPT[i].SubPoint == "Cylindricity") {
                                                        PT_ID_CY_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_ID_CY_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_ID_CY_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_ID_CY_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_ID_CY_CL.push(data.ListOfPT[i].CL);
                                                        PT_ID_CY_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_id_cylindricity.push(data.ListOfPT[i].pt_id_cylindricity);
                                                    } else if (data.ListOfPT[i].SubPoint == "Perpan") {
                                                        PT_ID_PP_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_ID_PP_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_ID_PP_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_ID_PP_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_ID_PP_CL.push(data.ListOfPT[i].CL);
                                                        PT_ID_PP_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_id_perpendicularity.push(data.ListOfPT[i].pt_id_perpendicularity);
                                                    } else if (data.ListOfPT[i].SubPoint == "Concentric") {
                                                        PT_ID_CO_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_ID_CO_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_ID_CO_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_ID_CO_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_ID_CO_CL.push(data.ListOfPT[i].CL);
                                                        PT_ID_CO_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_id_concentricity.push(data.ListOfPT[i].pt_id_concentricity);
                                                    }
                                                } else if (data.ListOfPT[i].MainPoint == "OD") {
                                                    if (data.ListOfPT[i].SubPoint == "ID") {
                                                        PT_OD_ID_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_OD_ID_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_OD_ID_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_OD_ID_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_OD_ID_CL.push(data.ListOfPT[i].CL);
                                                        PT_OD_ID_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_od_rank.push(data.ListOfPT[i].pt_od_rank);
                                                    } else if (data.ListOfPT[i].SubPoint == "Roundness") {
                                                        PT_OD_RN_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_OD_RN_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_OD_RN_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_OD_RN_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_OD_RN_CL.push(data.ListOfPT[i].CL);
                                                        PT_OD_RN_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_od_judge_roundness.push(data.ListOfPT[i].pt_od_judge_roundness);
                                                    } else if (data.ListOfPT[i].SubPoint == "Cylindricity") {
                                                        PT_OD_CY_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_OD_CY_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_OD_CY_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_OD_CY_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_OD_CY_CL.push(data.ListOfPT[i].CL);
                                                        PT_OD_CY_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_od_cylindricity.push(data.ListOfPT[i].pt_od_cylindricity);
                                                    } else if (data.ListOfPT[i].SubPoint == "Perpan") {
                                                        PT_OD_PP_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_OD_PP_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_OD_PP_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_OD_PP_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_OD_PP_CL.push(data.ListOfPT[i].CL);
                                                        PT_OD_PP_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_od_perpendicularity.push(data.ListOfPT[i].pt_od_perpendicularity);
                                                    }
                                                } else if (data.ListOfPT[i].MainPoint == "HEIGHT") {
                                                    if (data.ListOfPT[i].SubPoint == "Height") {
                                                        PT_HE_HE_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_HE_HE_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_HE_HE_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_HE_HE_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_HE_HE_CL.push(data.ListOfPT[i].CL);
                                                        PT_HE_HE_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_he_rank.push(data.ListOfPT[i].pt_he_rank);
                                                    } else if (data.ListOfPT[i].SubPoint == "Parallel") {
                                                        PT_HE_PL_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_HE_PL_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_HE_PL_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_HE_PL_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_HE_PL_CL.push(data.ListOfPT[i].CL);
                                                        PT_HE_PL_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_he_parallism.push(data.ListOfPT[i].pt_he_parallism);
                                                    }
                                                } else if (data.ListOfPT[i].MainPoint == "BLADE") {
                                                    if (data.ListOfPT[i].SubPoint == "Thickness") {
                                                        PT_BL_TN_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_BL_TN_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_BL_TN_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_BL_TN_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_BL_TN_CL.push(data.ListOfPT[i].CL);
                                                        PT_BL_TN_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_bl_rank.push(data.ListOfPT[i].pt_bl_rank);
                                                    } else if (data.ListOfPT[i].SubPoint == "Parallel") {
                                                        PT_BL_PL_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_BL_PL_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_BL_PL_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_BL_PL_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_BL_PL_CL.push(data.ListOfPT[i].CL);
                                                        PT_BL_PL_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_bl_parallism.push(data.ListOfPT[i].pt_bl_parallism);
                                                    } else if (data.ListOfPT[i].SubPoint == "Perpan") {
                                                        PT_BL_PP_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                                        PT_BL_PP_MQMax.push(data.ListOfPT[i].MQMax);
                                                        PT_BL_PP_MQMin.push(data.ListOfPT[i].MQMin);
                                                        PT_BL_PP_UCL.push(data.ListOfPT[i].UCL);
                                                        PT_BL_PP_CL.push(data.ListOfPT[i].CL);
                                                        PT_BL_PP_LCL.push(data.ListOfPT[i].LCL);
                                                        pt_bl_perpendicularity.push(data.ListOfPT[i].pt_bl_perpendicularity);
                                                    }
                                                }


                                            }

                                            LoadGraphPT();

                                        },
                                        error: function (e) {
                                            alert(DatePDStart + ' ' + DatePDEnd);
                                        }
                                    });

                                }

                                function LoadGraphPT() {
                                    // ************** ID ******************
                                    Highcharts.chart('PTIDRoundness', {

                                        title: {
                                            text: 'Piston ID Roundness'
                                        }
                                        ,
                                        xAxis: {
                                            categories: PT_ID_RN_DateLabel
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
                                            max: PT_ID_RN_UCL[0] + 0.0030
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
                                            data: pt_id_roundness,
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
                                            data: PT_ID_RN_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: PT_ID_RN_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: PT_ID_RN_MQMax,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });

                                    Highcharts.chart('PTIDPerpan', {

                                        title: {
                                            text: 'Piston ID Perpan'
                                        }
                                        ,
                                        xAxis: {
                                            categories: PT_ID_PP_DateLabel
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
                                            tickInterval: 0.0005,
                                            gridLineWidth: 0,
                                            max: PT_ID_PP_UCL[0] + 0.0030
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
                                            data: pt_id_perpendicularity,
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
                                            data: PT_ID_PP_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: PT_ID_PP_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: PT_ID_PP_MQMax,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });


                                    // ************** OD ******************
                                    Highcharts.chart('PTODRoundness', {

                                        title: {
                                            text: 'Piston OD Roundness'
                                        }
                                        ,
                                        xAxis: {
                                            categories: PT_OD_RN_DateLabel
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
                                            max: PT_OD_RN_UCL[0] + 0.0030
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
                                            data: pt_od_judge_roundness,
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
                                            data: PT_OD_RN_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: PT_OD_RN_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: PT_OD_RN_MQMax,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });

                                    Highcharts.chart('PTODPerpan', {

                                        title: {
                                            text: 'Piston OD Perpan'
                                        }
                                        ,
                                        xAxis: {
                                            categories: PT_OD_PP_DateLabel
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
                                            max: PT_OD_PP_UCL[0] + 0.0030,
                                            min: PT_OD_PP_CL[0] - 0.0030
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
                                            data: pt_od_perpendicularity,
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
                                            data: PT_OD_PP_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: PT_OD_PP_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: PT_OD_PP_MQMax,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });


                                    // ************** BLADE ******************
                                    Highcharts.chart('PTBladePerpan', {

                                        title: {
                                            text: 'Piston Blade Perpan'
                                        }
                                        ,
                                        xAxis: {
                                            categories: PT_BL_PP_DateLabel
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
                                            tickInterval: 0.0005,
                                            gridLineWidth: 0,
                                            max: PT_BL_PP_UCL[0] + 0.0030,
                                            min: PT_BL_PP_CL[0] - 0.0030
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
                                            data: pt_bl_perpendicularity,
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
                                            data: PT_BL_PP_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: PT_BL_PP_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: PT_BL_PP_MQMax,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });

                                    Highcharts.chart('PTBladeParallel', {

                                        title: {
                                            text: 'Piston Blade Parallel'
                                        }
                                        ,
                                        xAxis: {
                                            categories: PT_BL_PL_DateLabel
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
                                            max: PT_BL_PL_UCL[0] + 0.0030
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
                                            data: pt_bl_parallism,
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
                                            data: PT_BL_PL_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: PT_BL_PL_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: PT_BL_PL_MQMax,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }]
                                    });


                                    // ************** Height ******************
                                    Highcharts.chart('PTHeightParallel', {

                                        title: {
                                            text: 'Piston Height Parallel'
                                        }
                                        ,
                                        xAxis: {
                                            categories: PT_HE_PL_DateLabel
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
                                            max: PT_HE_PL_UCL[0] + 0.0030
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
                                            data: pt_he_parallism,
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
                                            data: PT_HE_PL_UCL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'CL',
                                            color: '#C608CC',
                                            data: PT_HE_PL_CL,
                                            type: 'line',
                                            lineWidth: 2,
                                            marker: {
                                                enabled: false
                                            }
                                            //marker: false
                                        }, {
                                            name: 'MQMax',
                                            color: '#FF0000',
                                            data: PT_HE_PL_MQMax,
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

