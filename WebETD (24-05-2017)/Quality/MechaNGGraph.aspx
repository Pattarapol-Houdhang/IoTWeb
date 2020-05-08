<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="MechaNGGraph.aspx.cs" Inherits="Quality_QCSamplingGraphCS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        function myFunction() {
            //document.getElementById("UpdatePanel1").style.display = "block";
            document.getElementById("updateProg").style.display = "block";
            LoadData();
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

        .HideDiv {
            display: none;
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


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>

            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>Mecha_Fac3</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div id="updateProg" style="display: none;">
                            <progresstemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </progresstemplate>
                        </div>
                        <section class="panel">
                            <header class="panel-heading">
                                Searching
                            </header>
                            <div class="panel-body">
                                <div class="form-group">

                                    <div id="search_datetime" runat="server" class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Part Name</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlMainPoint" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="btnSearch_Click">
                                                <asp:ListItem Text="ALL" Value="ALL" />
                                                <asp:ListItem Text="Piston" Value="PT" />
                                                <asp:ListItem Text="Cylinder" Value="CY" />
                                                <asp:ListItem Text="Crank" Value="CS" />
                                                <asp:ListItem Text="Rear Head" Value="RH" />
                                                <asp:ListItem Text="Front Head" Value="FH" />
                                            </asp:DropDownList>
                                        </div>
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Date</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtPrdDate" runat="server" class="form-control" Text=""></asp:TextBox>
                                        </div>
                                    </div>


                                    <div class="row" style="margin-top: 10px">

                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-success btn-lg" Text="Show" OnClick="btnSearch_Click" AutoPostBack="true" OnClientClick="myFunction()" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 10px">
                                        <div class="col-sm-10">
                                            <asp:Button ID="btnExport" runat="server" class="btn btn-success btn" Text="Export to Excel" OnClick="btnExport_Click" OnClientClick="myFunction()" />
                                            <span style="color: red;">** Export data to excel file.
                                                ** ดาวโหลดไฟล์ข้อมูล Excel </span>
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
                                Graph : 
                        <asp:Label ID="DateShow" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:Label ID="FullDate" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="col-lg-12 ">
                                        <%--Piston--%>
                                        <div id="PT" class="col-lg-12">
                                            <h1>Piston </h1>
                                            <h4 id="PT_total"></h4>
                                            <h4 id="PT_totalM"></h4>
                                            <div id="OD" class="col-lg-3" style="height: 400px"></div>
                                            <div id="ID" class="col-lg-3" style="height: 400px"></div>
                                            <div id="HEIGHT" class="col-lg-3" style="height: 400px"></div>
                                            <div id="BLADE" class="col-lg-3" style="height: 400px"></div>

                                        </div>
                                        <%--Cylinder--%>
                                        <div id="CY" class="col-lg-12">
                                            <h1>Cylinder </h1>
                                            <h4 id="CY_total"></h4>
                                            <h4 id="CY_totalM"></h4>
                                            <div id="CY_HEIGHT" class="col-lg-4" style="height: 400px"></div>
                                            <div id="IDBORE" class="col-lg-4" style="height: 400px"></div>
                                            <div id="IDBUSH" class="col-lg-4" style="height: 400px"></div>
                                        </div>
                                        <%--Crank--%>
                                        <div id="CS" class="col-lg-12">
                                            <h1>Crank </h1>
                                            <h4 id="CS_total"></h4>
                                            <h4 id="CS_totalM"></h4>
                                            <div id="FRONT_OD" class="col-lg-4" style="height: 400px"></div>
                                            <div id="Rear_OD" class="col-lg-4" style="height: 400px"></div>
                                            <div id="PIN" class="col-lg-4" style="height: 400px"></div>
                                        </div>
                                        <%--Rear head--%>
                                        <div id="RH" class="col-lg-12">
                                            <h1>Rear head </h1>
                                            <h4 id="RH_total"></h4>
                                            <h4 id="RH_totalM"></h4>
                                            <div id="RH_ID" class="col-lg-6" style="height: 400px"></div>
                                        </div>
                                        <%--Front head--%>
                                        <div id="FH" class="col-lg-12">
                                            <h1>Front head</h1>
                                            <h4 id="FH_total"></h4>
                                            <h4 id="FH_totalM"></h4>
                                            <div id="FH_ID" class="col-lg-6" style="height: 400px"></div>
                                        </div>


                                        <script>

                                            $(document).ready(function () {
                                                LoadGraph();
                                                LoadDataG();
                                                HideGraph();
                                            });
                                            $(document).ready(function () {
                                                setInterval(function () {
                                                    LoadGraph();
                                                    LoadDataG();
                                                    HideGraph();
                                                }, 300000);
                                            });


                                            //var ShiftPD = "D";
                                            //var DatePD = moment().format("YYYY-MM-DD HH:mm:ss");
                                            var DatePDStart = moment().format("YYYY-MM-DD HH:mm:ss");
                                            var DatePDEnd = moment().format("YYYY-MM-DD HH:mm:ss");
                                            ///DatePD = new Date(DatePD);
                                            //DatePD = "2018-12-10";
                                            //if (DatePD > new Date(moment().format("YYYY-MM-DD") + " 08:00")
                                            //    && DatePD < new Date(moment().format("YYYY-MM-DD") + " 20:00")) {
                                            //    DatePDStart = moment().format("YYYY-MM-DD") + " 08:00";
                                            //    DatePDEnd = moment().format("YYYY-MM-DD") + " 20:00";
                                            //    //DatePD = moment().add(1, 'days').format("YYYY-MM-DD");
                                            //    ShiftPD = "D";
                                            //} else if (DatePD > new Date(moment().format("YYYY-MM-DD") + " 20:00")) {
                                            //    DatePDStart = moment().format("YYYY-MM-DD") + " 20:00";
                                            //    DatePDEnd = moment().add(1, 'days').format("YYYY-MM-DD") + " 08:00";
                                            //    ShiftPD = "N";
                                            //} else if (DatePD < new Date(moment().format("YYYY-MM-DD") + " 08:00")) {
                                            //    DatePDStart = moment().add(-1, 'days').format("YYYY-MM-DD") + " 20:00";
                                            //    DatePDEnd = moment().format("YYYY-MM-DD") + " 08:00";
                                            //    ShiftPD = "N";
                                            //} else {
                                            //    var DatePDStart = moment().format("YYYY-MM-DD") + " 08:00";
                                            //    var DatePDEnd = moment().format("YYYY-MM-DD") + " 20:00";
                                            //}
                                            var DatePDStart = moment().format("YYYY-MM-DD") + " 08:00";
                                            var DatePDEnd = moment().format("YYYY-MM-DD") + " 20:00";

                                            var _DateStart = "";
                                            var _DateEnd = "";
                                            var txtDate = document.getElementById('<%= txtPrdDate.ClientID %>').value;
                                            var ddlPart_Name = document.getElementById('<%= ddlMainPoint.ClientID %>').value;

                                            if (txtDate != "") {
                                                var spl = txtDate.split(" - ");
                                                _DateStart = spl[0].toString().replace('/', '-');
                                                _DateEnd = spl[1].toString().replace('/', '-');
                                            } else {
                                                _DateStart = DatePDStart;
                                                _DateEnd = DatePDEnd;
                                            }


                                            ///Piston
                                            var PT_OD = [];
                                            ///
                                            var PT_ID = [];
                                            ///
                                            var PT_BLADE = [];
                                            ///
                                            var PT_HEIGHT = [];
                                            ///
                                            ///End Piston
                                            ///Cylinder
                                            /////
                                            var CY_HEI = [];
                                            ///
                                            var CY_IDBO = [];
                                            //////
                                            var CY_IDBU = [];
                                            ////CS
                                            var CS_FOD = [];
                                            ////
                                            var CS_ROD = [];
                                            ///
                                            var CS_PIN = [];
                                            ////end cs
                                            ////RH
                                            var RH_ID = [];
                                            /////END RH
                                            ////FH
                                            var FH_ID = [];
                                            /////
                                            /////////AVG
                                            var AVG_PT_OD = [];

                                            var AVG_PT_ID = [];
                                            ///
                                            var AVG_PT_BLADE = [];
                                            ///
                                            var AVG_PT_HEIGHT = [];
                                            ////
                                            ///End Piston
                                            ///Cylinder
                                            var AVG_CY_HEI = [];
                                            ///ID BORE
                                            var AVG_CY_IDBO = [];

                                            ///ID BUSH
                                            var AVG_CY_IDBU = [];
                                            ////CS
                                            var AVG_CS_FOD = [];
                                            /////
                                            var AVG_CS_ROD = [];
                                            /////
                                            var AVG_CS_PIN = [];
                                            ////REAR HEAD
                                            var AVG_RH_ID = [];
                                            /////FRONT HEAD
                                            var AVG_FH_ID = [];

                                            //////////Total
                                            /////PT
                                            var PT_OD_Total = 0; var PT_ID_Total = 0; var PT_HI_Total = 0; var PT_BLADE_Total = 0;////BLADE+THICKNESS
                                            //////CYLINDER
                                            var CY_HI_Total = 0; var CY_IDBU_Total = 0; var CY_IDBO_Total = 0;
                                            /////Crank
                                            var CS_FO_Total = 0; var CS_RO_Total = 0; var CS_PO_Total = 0;
                                            ////Front Head
                                            var FH_ID_Total = 0;
                                            /////Rear Head
                                            var RH_ID_Total = 0;
                                            //////
                                            ////Total part_name
                                            var PT_Total = 0; var CS_Total = 0; var CY_Total = 0; var FH_Total = 0; var RH_Total = 0;

                                            var dataObj;

                                            var G_PT_OD = '';
                                            var G_PT_ID = '';
                                            var G_PT_BLADE = '';
                                            var G_PT_HEIGHT = '';
                                            var G_CY_HEI = '';
                                            var G_CY_IDBO = '';
                                            var G_CY_IDBU = '';
                                            var G_CS_FOD = '';
                                            var G_CS_ROD = '';
                                            var G_CS_PIN = '';
                                            var G_RH_ID = '';
                                            var G_FH_ID = '';

                                            var OG_PT_OD;
                                            var OG_PT_ID;
                                            var OG_PT_BLADE;
                                            var OG_PT_HEIGHT;
                                            var OG_CY_HEI;
                                            var OG_CY_IDBO;
                                            var OG_CY_IDBU;
                                            var OG_CS_FOD;
                                            var OG_CS_ROD;
                                            var OG_CS_PIN;
                                            var OG_RH_ID;
                                            var OG_FH_ID;

                                            function LoadDataG() {
                                                $.ajax({
                                                    url: "GetMechaNGGraph.ashx?DateStart=" + _DateStart + "&DateEnd=" + _DateEnd + "&ddlPart_Name=" + ddlPart_Name,
                                                    dataType: "json",
                                                    async: true,
                                                    success: function (data) {
                                                        ////Model///
                                                        var Model = [];
                                                        for (i = 0; i < data.ListOfModel.length; i++) {
                                                            Model.push(data.ListOfModel[i].model_name);
                                                        }
                                                        var listmodel = [];
                                                        for (i = 0; i < Model.length; i++) {
                                                            PT_OD.push([0, 0, 0, 0, 0, 0]);
                                                            PT_ID.push([0, 0, 0, 0, 0, 0]);
                                                            PT_BLADE.push([0, 0, 0, 0, 0, 0, 0, 0, 0]);
                                                            PT_HEIGHT.push([0, 0, 0, 0, 0, 0]);
                                                            CY_HEI.push([0, 0, 0, 0, 0, 0, 0]);
                                                            CY_IDBO.push([0, 0, 0, 0, 0, 0, 0]);
                                                            CY_IDBU.push([0, 0, 0, 0, 0]);
                                                            CS_FOD.push([0, 0, 0, 0, 0]);
                                                            CS_ROD.push([0, 0, 0, 0]);
                                                            CS_PIN.push([0, 0, 0, 0, 0]);
                                                            RH_ID.push([0, 0, 0, 0, 0]);
                                                            FH_ID.push([0, 0, 0, 0, 0, 0]);
                                                            listmodel.push(0);

                                                        }
                                                        AVG_PT_OD = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_PT_ID = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_PT_BLADE = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_PT_HEIGHT = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_CY_HEI = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_CY_IDBO = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_CY_IDBU = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_CS_FOD = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_CS_ROD = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_CS_PIN = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_RH_ID = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];

                                                        AVG_FH_ID = [[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
                                                        [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0], [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]];;
                                                        /////
                                                        for (i = 0; i < data.ListOfMechaNG.length; i++) {
                                                            ///////////////////////////<<-----Piston--->>/////////////////////////////////
                                                            if (data.ListOfMechaNG[i].part_name == "PT") {
                                                                if (data.ListOfMechaNG[i].part_type == "OD") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "OD_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_OD[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_OD[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }


                                                                                }
                                                                            }
                                                                            break;
                                                                        case "OD_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_OD[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_OD[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "OD_3":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_OD[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_OD[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "OD_ROUNDNESS":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_OD[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_OD[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "OD_CYLINDRI":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {

                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_OD[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_OD[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "OD_PERPEN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_OD[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][5] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_OD[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_OD[j][5] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;

                                                                        default:
                                                                    }

                                                                } else if (data.ListOfMechaNG[i].part_type == "ID") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "ID_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_ID[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_ID[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_ID[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_ID[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_3":

                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_ID[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_ID[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_ROUNDNESS":

                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_ID[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_ID[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_CYLINDRI":

                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_ID[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_ID[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_PERPEN":

                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_ID[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][5] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_ID[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_ID[j][5] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;

                                                                        default:
                                                                            break;
                                                                    }////////THICKNESS+BLADE
                                                                } else if (data.ListOfMechaNG[i].part_type == "BLADE" || data.ListOfMechaNG[i].part_type == "THICKNESS") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "BL_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BL_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BL_3":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BL_4":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BL_5":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BL_6":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][5] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][5] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BL_PARALLEL":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[6][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][6] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[6][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][6] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BL_PERPEN_L":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[7][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][7] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[7][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][7] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "THICKNESS":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_BLADE[8][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][8] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_BLADE[8][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_BLADE[j][8] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        default:
                                                                            break;
                                                                    }
                                                                } else if (data.ListOfMechaNG[i].part_type == "HEIGHT") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "HEI_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_HEIGHT[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_HEIGHT[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_HEIGHT[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_HEIGHT[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_3":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_HEIGHT[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_HEIGHT[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_4":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_HEIGHT[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_HEIGHT[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_5":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_HEIGHT[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_HEIGHT[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_PARALLEL":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_PT_HEIGHT[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][5] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_PT_HEIGHT[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        PT_HEIGHT[j][5] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;

                                                                        default:
                                                                            break;
                                                                    }
                                                                }
                                                                ////////////////////////////<<------Cylinder----->>///////////////////////////////////////////////////////////////////
                                                            } else if (data.ListOfMechaNG[i].part_name == "CY") {
                                                                if (data.ListOfMechaNG[i].part_type == "HEIGHT") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "HEI_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_HEI[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_HEI[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_HEI[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_HEI[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_3":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_HEI[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_HEI[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_4":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_HEI[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_HEI[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_5":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_HEI[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_HEI[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_6":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_HEI[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][5] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_HEI[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][5] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "HEI_PARALLEL":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_HEI[6][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][6] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_HEI[6][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_HEI[j][6] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;

                                                                        default:

                                                                    }
                                                                } else if (data.ListOfMechaNG[i].part_type == "IDBORE") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "BO_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBO[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBO[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BO_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBO[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBO[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BO_3":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBO[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBO[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BO_CONCEN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBO[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBO[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BO_CYLIN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBO[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBO[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BO_PERPEN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBO[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][5] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBO[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][5] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BO_ROUND":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBO[6][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][6] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBO[6][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBO[j][6] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;

                                                                        default:

                                                                    }
                                                                } else if (data.ListOfMechaNG[i].part_type == "IDBUSH") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "BU_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBU[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBU[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BU_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBU[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBU[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BU_CYLIN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBU[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBU[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BU_PERPEN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBU[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBU[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "BU_ROUND":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CY_IDBU[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CY_IDBU[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CY_IDBU[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        default:

                                                                    }
                                                                }
                                                                /////////////////////////////////////////////<---CS-->//////////////////////////////////////////////
                                                            } else if (data.ListOfMechaNG[i].part_name == "CS") {
                                                                if (data.ListOfMechaNG[i].part_type == "PIN_OD") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "PINOD_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_PIN[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_PIN[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "PINOD_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_PIN[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_PIN[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "PINOD_3":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_PIN[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_PIN[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "PINOD_CYLIN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_PIN[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_PIN[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "PINOD_ROUND":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_PIN[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_PIN[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_PIN[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        default:

                                                                    }
                                                                } else if (data.ListOfMechaNG[i].part_type == "REAR_OD") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "ROD_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_ROD[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_ROD[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ROD_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_ROD[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_ROD[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ROD_CYLIN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_ROD[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_ROD[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ROD_ROUND":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_ROD[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_ROD[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_ROD[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;

                                                                        default:

                                                                    }
                                                                } else if (data.ListOfMechaNG[i].part_type == "FRONT_OD") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "FOD_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_FOD[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_FOD[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }

                                                                                }
                                                                            }
                                                                            break;
                                                                        case "FOD_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_FOD[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_FOD[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "FOD_3":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_FOD[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_FOD[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "FOD_CYLIN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_FOD[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_FOD[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "FOD_ROUND":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_CS_FOD[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_CS_FOD[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        CS_FOD[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;

                                                                        default:

                                                                    }
                                                                }

                                                            } else if (data.ListOfMechaNG[i].part_name == "RH") {
                                                                if (data.ListOfMechaNG[i].part_type == "ID") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "ID_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_RH_ID[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_RH_ID[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_RH_ID[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_RH_ID[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_CYLIN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_RH_ID[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_RH_ID[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_PERPEN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_RH_ID[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_RH_ID[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_ROUND":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_RH_ID[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_RH_ID[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        RH_ID[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        default:

                                                                    }
                                                                }

                                                            } else if (data.ListOfMechaNG[i].part_name == "FH") {
                                                                if (data.ListOfMechaNG[i].part_type == "ID") {
                                                                    switch (data.ListOfMechaNG[i].detail) {
                                                                        case "ID_1":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_FH_ID[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][0] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_FH_ID[0][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][0] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_2":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_FH_ID[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][1] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_FH_ID[1][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][1] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_CONCEN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_FH_ID[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][2] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_FH_ID[2][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][2] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_CYLIN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_FH_ID[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][3] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_FH_ID[3][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][3] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_PREPEN":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_FH_ID[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][4] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_FH_ID[4][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][4] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        case "ID_ROUND":
                                                                            for (j = 0; j < Model.length; j++) {
                                                                                if (data.ListOfMechaNG[i].Model == Model[j]) {
                                                                                    if (Model[j] == "Other") {
                                                                                        AVG_FH_ID[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][5] += data.ListOfMechaNG[i].Qty;///////Unknow Model
                                                                                    } else {
                                                                                        AVG_FH_ID[5][j] = data.ListOfMechaNG[i].AVG;
                                                                                        FH_ID[j][5] = data.ListOfMechaNG[i].Qty;
                                                                                    }
                                                                                }
                                                                            }
                                                                            break;
                                                                        default:

                                                                    }
                                                                }

                                                            }

                                                        }
                                                        //////


                                                        ////part_Type_Total
                                                        for (i = 0; i < data.ListOfMechaNG_partType_Total.length; i++) {
                                                            if (data.ListOfMechaNG_partType_Total[i].part_name == "PT") {
                                                                if (data.ListOfMechaNG_partType_Total[i].part_type == "OD") {
                                                                    PT_OD_Total = data.ListOfMechaNG_partType_Total[i].Total;

                                                                }
                                                                else if (data.ListOfMechaNG_partType_Total[i].part_type == "ID") {
                                                                    PT_ID_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                                else if (data.ListOfMechaNG_partType_Total[i].part_type == "HEIGHT") {
                                                                    PT_HI_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                                else if (data.ListOfMechaNG_partType_Total[i].part_type == "BLADE" || data.ListOfMechaNG_partType_Total[i].part_type == "THICKNESS") {
                                                                    PT_BLADE_Total += data.ListOfMechaNG_partType_Total[i].Total;

                                                                }

                                                            }
                                                            else if (data.ListOfMechaNG_partType_Total[i].part_name == "CY") {
                                                                if (data.ListOfMechaNG_partType_Total[i].part_type == "HEIGHT") {
                                                                    CY_HI_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                                else if (data.ListOfMechaNG_partType_Total[i].part_type == "IDBUSH") {
                                                                    CY_IDBU_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                                else if (data.ListOfMechaNG_partType_Total[i].part_type == "IDBORE") {
                                                                    CY_IDBO_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }

                                                            }
                                                            else if (data.ListOfMechaNG_partType_Total[i].part_name == "CS") {
                                                                if (data.ListOfMechaNG_partType_Total[i].part_type == "FRONT_OD") {
                                                                    CS_FO_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                                else if (data.ListOfMechaNG_partType_Total[i].part_type == "REAR_OD") {
                                                                    CS_RO_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                                else if (data.ListOfMechaNG_partType_Total[i].part_type == "PIN_OD") {
                                                                    CS_PO_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                            }
                                                            else if (data.ListOfMechaNG_partType_Total[i].part_name == "FH") {
                                                                if (data.ListOfMechaNG_partType_Total[i].part_type == "ID") {
                                                                    FH_ID_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                            }
                                                            else if (data.ListOfMechaNG_partType_Total[i].part_name == "RH") {
                                                                if (data.ListOfMechaNG_partType_Total[i].part_type == "ID") {
                                                                    RH_ID_Total = data.ListOfMechaNG_partType_Total[i].Total;
                                                                }
                                                            }
                                                        }

                                                        ///////part_Name_Total
                                                        ////
                                                        for (i = 0; i < data.ListOfMechaNGTotal.length; i++) {
                                                            if (data.ListOfMechaNGTotal[i].part_name == "PT") {
                                                                PT_total = data.ListOfMechaNGTotal[i].Total;
                                                            }
                                                            else if (data.ListOfMechaNGTotal[i].part_name == "CS") {
                                                                CS_Total = data.ListOfMechaNGTotal[i].Total;
                                                            }
                                                            else if (data.ListOfMechaNGTotal[i].part_name == "CY") {
                                                                CY_Total = data.ListOfMechaNGTotal[i].Total;
                                                            }
                                                            else if (data.ListOfMechaNGTotal[i].part_name == "FH") {
                                                                FH_Total = data.ListOfMechaNGTotal[i].Total;
                                                            }
                                                            else if (data.ListOfMechaNGTotal[i].part_name == "RH") {
                                                                RH_Total = data.ListOfMechaNGTotal[i].Total;
                                                            }
                                                        }
                                                        document.getElementById("PT_total").innerHTML = "(NG Total " + PT_total.toString() + " )";
                                                        document.getElementById("CS_total").innerHTML = "(NG Total " + CS_Total.toString() + " )";
                                                        document.getElementById("CY_total").innerHTML = "(NG Total " + CY_Total.toString() + " )";
                                                        document.getElementById("FH_total").innerHTML = "(NG Total " + FH_Total.toString() + " )";
                                                        document.getElementById("RH_total").innerHTML = "(NG Total " + RH_Total.toString() + " )";

                                                        var PT_totalM = "";
                                                        var CS_totalM = "";
                                                        var CY_totalM = "";
                                                        var FH_totalM = "";
                                                        var RH_totalM = "";
                                                        i = 0; j = 0;
                                                        for (i = 0; i < data.ListOfMechaNGTotalM.length ; i++) {
                                                            for (j = 0; j < Model.length; j++) {
                                                                if (data.ListOfMechaNGTotalM[i].part_name == "PT") {
                                                                    if (Model[j] == data.ListOfMechaNGTotalM[i].model) {
                                                                        PT_totalM += data.ListOfMechaNGTotalM[i].model + " = " + data.ListOfMechaNGTotalM[i].Total.toString() + ",";
                                                                    }
                                                                } else if (data.ListOfMechaNGTotalM[i].part_name == "CS") {
                                                                    if (Model[j] == data.ListOfMechaNGTotalM[i].model) {
                                                                        CS_totalM += data.ListOfMechaNGTotalM[i].model + " = " + data.ListOfMechaNGTotalM[i].Total.toString() + ",";
                                                                    }
                                                                } else if (data.ListOfMechaNGTotalM[i].part_name == "CY") {
                                                                    if (Model[j] == data.ListOfMechaNGTotalM[i].model) {
                                                                        CY_totalM += data.ListOfMechaNGTotalM[i].model + " = " + data.ListOfMechaNGTotalM[i].Total.toString() + ",";
                                                                    }
                                                                } else if (data.ListOfMechaNGTotalM[i].part_name == "FH") {
                                                                    if (Model[j] == data.ListOfMechaNGTotalM[i].model) {
                                                                        FH_totalM += data.ListOfMechaNGTotalM[i].model + " = " + data.ListOfMechaNGTotalM[i].Total.toString() + ",";
                                                                    }
                                                                } else if (data.ListOfMechaNGTotalM[i].part_name == "RH") {
                                                                    if (Model[j] == data.ListOfMechaNGTotalM[i].model) {
                                                                        RH_totalM += data.ListOfMechaNGTotalM[i].model + " = " + data.ListOfMechaNGTotalM[i].Total.toString() + ",";
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        document.getElementById("PT_totalM").innerHTML = "(" + PT_totalM.toString() + " )";
                                                        document.getElementById("CS_totalM").innerHTML = "(" + CS_totalM.toString() + " )";
                                                        document.getElementById("CY_totalM").innerHTML = "(" + CY_totalM.toString() + " )";
                                                        document.getElementById("FH_totalM").innerHTML = "(" + FH_totalM.toString() + " )";
                                                        document.getElementById("RH_totalM").innerHTML = "(" + RH_totalM.toString() + " )";








                                                        ///////////////////////////////สร้างObj Json สำหรับแต่ละกราฟ
                                                        /////// G_PT_OD
                                                        i = 0;
                                                        G_PT_OD = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_PT_OD += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + PT_OD[i] + ' ] },';

                                                        }
                                                        G_PT_OD = G_PT_OD.substring(0, G_PT_OD.length - 1);
                                                        G_PT_OD += ']';
                                                        OG_PT_OD = JSON.parse(G_PT_OD);
                                                        //////////////
                                                        /////////////G_PT_ID
                                                        i = 0;
                                                        G_PT_ID = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_PT_ID += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + PT_ID[i] + ' ] },';

                                                        }
                                                        G_PT_ID = G_PT_ID.substring(0, G_PT_ID.length - 1);
                                                        G_PT_ID += ']';
                                                        OG_PT_ID = JSON.parse(G_PT_ID);
                                                        //////////////
                                                        i = 0;
                                                        G_PT_BLADE = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_PT_BLADE += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + PT_BLADE[i] + ' ] },';

                                                        }
                                                        G_PT_BLADE = G_PT_BLADE.substring(0, G_PT_BLADE.length - 1);
                                                        G_PT_BLADE += ']';
                                                        OG_PT_BLADE = JSON.parse(G_PT_BLADE);
                                                        //////////////
                                                        i = 0;
                                                        G_PT_HEIGHT = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_PT_HEIGHT += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + PT_HEIGHT[i] + ' ] },';

                                                        }
                                                        G_PT_HEIGHT = G_PT_HEIGHT.substring(0, G_PT_HEIGHT.length - 1);
                                                        G_PT_HEIGHT += ']';
                                                        OG_PT_HEIGHT = JSON.parse(G_PT_HEIGHT);
                                                        //////////////
                                                        i = 0;
                                                        G_CY_HEI = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_CY_HEI += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + CY_HEI[i] + ' ] },';

                                                        }
                                                        G_CY_HEI = G_CY_HEI.substring(0, G_CY_HEI.length - 1);
                                                        G_CY_HEI += ']';
                                                        OG_CY_HEI = JSON.parse(G_CY_HEI);
                                                        //////////////
                                                        i = 0;
                                                        G_CY_IDBO = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_CY_IDBO += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + CY_IDBO[i] + ' ] },';

                                                        }
                                                        G_CY_IDBO = G_CY_IDBO.substring(0, G_CY_IDBO.length - 1);
                                                        G_CY_IDBO += ']';
                                                        OG_CY_IDBO = JSON.parse(G_CY_IDBO);
                                                        //////////////
                                                        i = 0;
                                                        G_CY_IDBU = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_CY_IDBU += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + CY_IDBU[i] + ' ] },';

                                                        }
                                                        G_CY_IDBU = G_CY_IDBU.substring(0, G_CY_IDBU.length - 1);
                                                        G_CY_IDBU += ']';
                                                        OG_CY_IDBU = JSON.parse(G_CY_IDBU);
                                                        //////////////
                                                        i = 0;
                                                        G_CS_FOD = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_CS_FOD += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + CS_FOD[i] + ' ] },';

                                                        }
                                                        G_CS_FOD = G_CS_FOD.substring(0, G_CS_FOD.length - 1);
                                                        G_CS_FOD += ']';
                                                        OG_CS_FOD = JSON.parse(G_CS_FOD);
                                                        //////////////
                                                        i = 0;
                                                        G_CS_ROD = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_CS_ROD += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + CS_ROD[i] + ' ] },';

                                                        }
                                                        G_CS_ROD = G_CS_ROD.substring(0, G_CS_ROD.length - 1);
                                                        G_CS_ROD += ']';
                                                        OG_CS_ROD = JSON.parse(G_CS_ROD);
                                                        ///////////////
                                                        i = 0;
                                                        G_CS_PIN = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_CS_PIN += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + CS_PIN[i] + ' ] },';

                                                        }
                                                        G_CS_PIN = G_CS_PIN.substring(0, G_CS_PIN.length - 1);
                                                        G_CS_PIN += ']';
                                                        OG_CS_PIN = JSON.parse(G_CS_PIN);
                                                        /////////////////////
                                                        i = 0;
                                                        G_RH_ID = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_RH_ID += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + RH_ID[i] + ' ] },';

                                                        }
                                                        G_RH_ID = G_RH_ID.substring(0, G_RH_ID.length - 1);
                                                        G_RH_ID += ']';
                                                        OG_RH_ID = JSON.parse(G_RH_ID);
                                                        /////////////////////
                                                        i = 0;
                                                        G_FH_ID = '[';
                                                        for (i = 0; i < Model.length; i++) {
                                                            G_FH_ID += '{ "name" : "' + Model[i] + '",' + ' "data" : [ ' + FH_ID[i] + ' ] },';

                                                        }
                                                        G_FH_ID = G_FH_ID.substring(0, G_FH_ID.length - 1);
                                                        G_FH_ID += ']';
                                                        OG_FH_ID = JSON.parse(G_FH_ID);
                                                        ///////

                                                        LoadGraph();

                                                    },
                                                    error: function (e) {
                                                        alert(DatePDStart + ' ' + DatePDEnd);
                                                    }
                                                });

                                            }

                                            function LoadGraph() {
                                                ///Init
                                                var color = 'gray'
                                                var _stackLabels = true
                                                var _dataLabels = false
                                                ///

                                                ///Piston
                                                Highcharts.chart('OD', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'OD'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + PT_OD_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'OD 1', 'OD 2', 'OD 3', 'Round', 'Cylin', 'Perpen'

                                                        ],
                                                        crosshair: true
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_PT_OD[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_PT_OD
                                                });
                                                Highcharts.chart('ID', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'ID'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + PT_ID_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'ID 1', 'ID 2', 'ID 3', 'Round', 'Cylin', 'Perpen'

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_PT_ID[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_PT_ID
                                                }); Highcharts.chart('BLADE', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'BLADE'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + PT_BLADE_Total.toString()
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'BLADE 1', 'BLADE 2', 'BLADE 3', 'BLADE 4', 'BLADE 5', 'BLADE 6', 'BLADE PARALLEL', 'BLADE PERPEN L', 'THICKNESS'

                                                        ],
                                                        crosshair: true

                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_PT_BLADE[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_PT_BLADE
                                                }); Highcharts.chart('HEIGHT', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'HEIGHT'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + PT_HI_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'HEIGHT 1', 'HEIGHT 2', 'HEIGHT 3', 'HEIGHT 4', 'HEIGHT 5', 'HEIGHT PARALLEL'
                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_PT_HEIGHT[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_PT_HEIGHT
                                                });
                                                ///Cylinder
                                                Highcharts.chart('CY_HEIGHT', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'HEIGHT'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + CY_HI_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'HEIGHT 1', 'HEIGHT 2', 'HEIGHT 3', 'HEIGHT 4', 'HEIGHT 5', 'HEIGHT 6', 'HEIGHT PARALLEL'

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_CY_HEI[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_CY_HEI
                                                });
                                                Highcharts.chart('IDBORE', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'IDBORE'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + CY_IDBO_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'ID_BORE_1', 'ID_BORE_2', 'ID_BORE_3', 'CONCEN', 'CYLIN', 'PERPEN', 'ROUND'

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_CY_IDBO[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_CY_IDBO
                                                }); Highcharts.chart('IDBUSH', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'BUSH ID'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + CY_IDBU_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'ID_BUSH_1', 'ID_BUSH_2', 'CYLIN', 'PERPEN', 'ROUND'

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_CY_IDBU[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_CY_IDBU
                                                }); Highcharts.chart('FRONT_OD', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'FRONT_OD'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + CS_FO_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'FOD_1', 'FOD_2', 'FOD_3', 'FOD_CYLIN', 'FOD_ROUND',

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_CS_FOD[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_CS_FOD
                                                });
                                                Highcharts.chart('Rear_OD', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'Rear_OD'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + CS_RO_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'Rear_OD_1', 'Rear_OD_2', 'Rear_OD_CYLIN', 'Rear_OD_ROUND'

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_CS_ROD[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_CS_ROD
                                                }); Highcharts.chart('PIN', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'PIN'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + CS_PO_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'PINOD_1', 'PINOD_2', 'PINOD_3', 'PINOD_CYLIN', 'PINOD_ROUND'

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_CS_PIN[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_CS_PIN
                                                }); Highcharts.chart('RH_ID', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'ID'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + RH_ID_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'ID_1', 'ID_2', 'CYLIN', 'PERPEN', 'ROUND'
                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_RH_ID[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_RH_ID
                                                });
                                                ///Front
                                                Highcharts.chart('FH_ID', {
                                                    chart: {
                                                        type: 'column'
                                                    },
                                                    title: {
                                                        text: 'FH_ID'
                                                    },
                                                    subtitle: {
                                                        text: 'NG Total ' + FH_ID_Total
                                                    },
                                                    xAxis: {
                                                        categories: [
                                                            'ID_1', 'ID_2', 'ID_CONCEN', 'ID_CYLIN', 'ID_PREPEN', 'ID_ROUND'

                                                        ],
                                                        crosshair: true,
                                                        labels: {
                                                            autoRotationLimit: 20
                                                        }
                                                    },
                                                    yAxis: {
                                                        min: 0,
                                                        title: {
                                                            text: 'NG Number'
                                                        }, stackLabels: {
                                                            enabled: _stackLabels,
                                                            style: {
                                                                fontWeight: 'bold',
                                                                color: color
                                                            }
                                                        }
                                                    },
                                                    tooltip: {
                                                        formatter: function () {
                                                            var s = '<b>' + this.x + '</b>';

                                                            $.each(this.points, function (i, point) {
                                                                s += '<br/><span style="color:' + point.color + '">\u25CF</span> ' + point.series.name + ': ' + this.y + ' : ' + AVG_FH_ID[this.series.data.indexOf(this.point)][i];
                                                            });

                                                            return s;
                                                        },
                                                        shared: true
                                                    },
                                                    plotOptions: {
                                                        column: {
                                                            stacking: 'stream',
                                                            pointPadding: 0.1,
                                                            borderWidth: 0,
                                                            dataLabels: {
                                                                formatter: function () {
                                                                    if (this.y != 0) {
                                                                        return Highcharts.numberFormat(this.y, -1);
                                                                    }
                                                                },
                                                                enabled: _dataLabels
                                                            }
                                                        }
                                                    },
                                                    series: OG_FH_ID
                                                });

                                            }
                                            function HideGraph() {
                                                if (ddlPart_Name == "ALL") {
                                                    if (document.getElementById('PT').classList.contains('HideDiv')) {
                                                        document.getElementById('PT').classList.remove('HideDiv');
                                                    }
                                                    else if (document.getElementById('CY').classList.contains('HideDiv')) {
                                                        document.getElementById('CY').classList.remove('HideDiv');
                                                    }
                                                    else if (document.getElementById('CS').classList.contains('HideDiv')) {
                                                        document.getElementById('CS').classList.remove('HideDiv');
                                                    }
                                                    else if (document.getElementById('RH').classList.contains('HideDiv')) {
                                                        document.getElementById('RH').classList.remove('HideDiv');
                                                    }
                                                    else if (document.getElementById('FH').classList.contains('HideDiv')) {
                                                        document.getElementById('FH').classList.remove('HideDiv');
                                                    }
                                                } else if (ddlPart_Name == "PT") {
                                                    if (document.getElementById('PT').classList.contains('HideDiv')) {
                                                        document.getElementById('PT').classList.remove('HideDiv');
                                                    }

                                                    document.getElementById('CY').classList.toggle('HideDiv');
                                                    document.getElementById('CS').classList.toggle('HideDiv');
                                                    document.getElementById('RH').classList.toggle('HideDiv');
                                                    document.getElementById('FH').classList.toggle('HideDiv');

                                                } else if (ddlPart_Name == "CY") {
                                                    if (document.getElementById('CY').classList.contains('HideDiv')) {
                                                        document.getElementById('CY').classList.remove('HideDiv');
                                                    }

                                                    document.getElementById('PT').classList.toggle('HideDiv');
                                                    document.getElementById('CS').classList.toggle('HideDiv');
                                                    document.getElementById('RH').classList.toggle('HideDiv');
                                                    document.getElementById('FH').classList.toggle('HideDiv');

                                                } else if (ddlPart_Name == "CS") {
                                                    if (document.getElementById('CS').classList.contains('HideDiv')) {
                                                        document.getElementById('CS').classList.remove('HideDiv');
                                                    }

                                                    document.getElementById('PT').classList.toggle('HideDiv');
                                                    document.getElementById('CY').classList.toggle('HideDiv');
                                                    document.getElementById('RH').classList.toggle('HideDiv');
                                                    document.getElementById('FH').classList.toggle('HideDiv');

                                                } else if (ddlPart_Name == "RH") {
                                                    if (document.getElementById('RH').classList.contains('HideDiv')) {
                                                        document.getElementById('RH').classList.remove('HideDiv');
                                                    }

                                                    document.getElementById('PT').classList.toggle('HideDiv');
                                                    document.getElementById('CY').classList.toggle('HideDiv');
                                                    document.getElementById('CS').classList.toggle('HideDiv');
                                                    document.getElementById('FH').classList.toggle('HideDiv');

                                                } else if (ddlPart_Name == "FH") {
                                                    if (document.getElementById('FH').classList.contains('HideDiv')) {
                                                        document.getElementById('FH').classList.remove('HideDiv');
                                                    }

                                                    document.getElementById('PT').classList.toggle('HideDiv');
                                                    document.getElementById('CY').classList.toggle('HideDiv');
                                                    document.getElementById('CS').classList.toggle('HideDiv');
                                                    document.getElementById('RH').classList.toggle('HideDiv');

                                                }


                                            }

                                        </script>

                                    </div>

                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
</asp:Content>

