<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PDFinalUnHoldData.aspx.cs" Inherits="Quality_PDFinalUnHoldData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<META HTTP-EQUIV="Refresh" CONTENT="300;" >--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>

    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/dataTables.buttons.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.flash.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jszip.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/pdfmake.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/vfs_fonts.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.html5.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.print.min.js") %>"></script>

    <link href="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />


    <script type="text/javascript">
        function LoadData() {
            $('#example').DataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": true,
                "paging": true,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'print'
                ]
            });

            //------------------ Prd Date ----------------------
            $('#<%= txtDate.ClientID %>').daterangepicker({
                autoUpdateInput: true,
                //startDate: moment().startOf('month'),
                //endDate: moment().endOf('month'),
                locale: {
                    cancelLabel: 'Clear',
                    format: 'DD/MM/YYYY'
                }
            });

            $('#<%= txtDate.ClientID %>').on('apply.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                //$(this).val(picker3.startDate.format('DD/MM/YYYY') + ' - ' + picker3.endDate.format('DD/MM/YYYY'));
                var diff = new Date(picker3.endDate - picker3.startDate);
                var diffDays = diff / 1000 / 60 / 60 / 24;
                if (parseInt(diffDays) <= 31) {
                    $(this).val(picker3.startDate.format('DD/MM/YYYY') + ' - ' + picker3.endDate.format('DD/MM/YYYY'));
                } else {
                    alert('ห้ามเลือกเกิน 31 วัน!');
                    $(this).val('');
                }
            });

            $('#<%= txtDate.ClientID %>').on('cancel.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val('');
            });

            //------------------ Prd Date ----------------------


            var page = $(".lnkHeadPage.PageSelected").data("page");
            loadDisplay(page);

            $(".lnkHeadPage").click(function () {
                $(".lnkHeadPage").removeClass("PageSelected");
                $(this).addClass("PageSelected");

                var page = $(this).data("page");
                loadDisplay(page);
            });



        }// end function

        function loadDisplay(page) {
            $(".divDisplay").fadeOut(0, function () {
                $(".div" + page).fadeIn(0);
            });

            if (page == "CHART") {
                $(".page-header").text("CHART");
                $("#iFrameChart").attr("src", "PDLineOutChartAll.aspx");
            } else if (page == "FACTORY1") {
                $(".page-header").text("DATA FACTORY 1, 2, ODM");
                window.location.href = "http://192.168.226.19/iotweb/Quality/PDLineOutData.aspx";
            } else if (page == "FACTORY3") {
                $(".page-header").text("DATA FACTORY 3");
            }
        }
        

        $(document).ready(function () {
            
            if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
            } else {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
            }

            $("#ContentPlaceHolder1_ckPrdSerialAll").click(function () {
                if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
                } else {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
                }
            });

            var page = $(".lnkHeadPage").data("page");
            loadDisplay(page);
        });

        var parameter = Sys.WebForms.PageRequestManager.getInstance();
        parameter.add_endRequest(function () {
            if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
            } else {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
            }

            $("#ContentPlaceHolder1_ckPrdSerialAll").click(function () {
                if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
                } else {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
                }
            });

            
        });


    </script>
    <style type="text/css">
        .dataTables_wrapper.no-footer div.dataTables_scrollHead table.dataTable, .dataTables_wrapper.no-footer div.dataTables_scrollBody > table {
            min-width: 1315px!important;
        }
        table.dataTable thead th, table.dataTable thead td {
            padding: 3px 3px;
            border: 1px solid #d0d0d0!important;
            font-size: 11px;
        }
        table.dataTable tbody th, table.dataTable tbody td {
            padding: 3px 3px;
            border: 1px solid #d0d0d0!important;
            font-size: 11px;
        }
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
        .btn-refresh {
            color: #fff;
            background-color: #38984d;
            border-color: #22692e;
        }
        .btn-refresh:hover {
            color: #fff;
             background-color: #41e665;
        }
        .lnkHeadPage {
            display: inline-block;
            width: 160px;
            background-color: #ececec;
            text-align: center;
            border-radius: 10px;
            cursor: pointer;
            font-weight: bold;
            padding: 5px;
            margin: 5px;
            opacity: 0.2;
            border: 2px solid #dedede;
        }
        .PageSelected, .lnkHeadPage:hover {
            opacity: 1;
            box-shadow: #808080 0px 0px 10px;
            border: 2px solid #9ba9ec;
        }
        .divDisplay {
            display:none;
        }
        .title {
            margin-top: 30px;
            text-align: left;
            font-weight: bold;
            border-bottom: none;
            font-size: 34px;
        }
    </style>

    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DynamicLayout="false" DisplayAfter="0">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>

            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-8">
                        <div class="lnkHeadPage PageSelected" data-page="CHART">
                            <img src="../images/analytics.png" width="48"  height="48" /><br />
                            <span>CHART</span>
                        </div>
                        <div class="lnkHeadPage" data-page="FACTORY1">
                            <img src="../images/factory.png" width="48" height="48"  /><br />
                            <span>FACTORY 1, 2, ODM</span>
                        </div>
                        <div class="lnkHeadPage" data-page="FACTORY3">
                            <img src="../images/factory.png" width="48"  height="48" /><br />
                            <span>FACTORY 3</span>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <h3 class="page-header title" >Compressor HOLD</h3>
                    </div>
                </div>
                <hr />
                <div class="row divDisplay divCHART" >
                    <iframe id="iFrameChart" width="100%" height="1200px" style="border:none;" ></iframe>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row divDisplay divFACTORY3" >
                            <div class="row">
                                <div class="col-lg-12">
                                    <section class="panel">
                                        <header class="panel-heading">
                                            Searching
                                        </header>
                                        <div class="panel-body">
                                            <div class="form-group">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="10%" align="right">Date : </td>
                                                        <td width="15%"><asp:TextBox ID="txtDate" runat="server" class="form-control" Text="" ></asp:TextBox></td>
                                                        <td width="2%" width="3%"></td>
                                                        <td width="10%" align="right">Status : </td>
                                                        <td width="15%">
                                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" >
                                                                <asp:ListItem Value="ALL"> -- ALL --</asp:ListItem>
                                                                <asp:ListItem Value="HOLD">FG HOLD</asp:ListItem>
                                                                <asp:ListItem Value="LINEOUT">Line Out</asp:ListItem>
                                                                <asp:ListItem Value="REQUEST" Selected="True">REQUEST UNHOLD</asp:ListItem>
                                                                <asp:ListItem Value="ALLOW">UNHOLD</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="2%"></td>
                                                        <td rowspan="4"  width="20%">
                                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn" Text="Search" OnClick="btnSearch_Click"  />
                                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default btn" Style="margin-left: 15px" Text="Clear"  />
                                                            <asp:Button ID="btnUnHold" runat="server" class="btn btn-warning btn" Style="margin-left: 15px" Text="UnHold" OnClientClick="return confirm('ยืนยันการ UnHold ข้อมูล?');" OnClick="btnUnHold_Click" />
                                                            <asp:Button ID="Button1" runat="server" class="btn btn-refresh" Text="Refresh" OnClick="btnSearch_Click"  />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="9" align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">Model : </td>
                                                        <td><asp:TextBox ID="txtModel" runat="server" class="form-control"></asp:TextBox></td>
                                                        <td></td>
                                                        <td align="right"></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="9" align="left">
                                                            <asp:Label ID="lblError" runat="server" Text="" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </div>

                                        </div>
                                    </section>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <section class="panel">
                                        <header class="panel-heading">
                                            List Data Hold
                                        </header>
                                        <div class="panel-body">
                                            <div class="form-group">
                                                <table class="table table-striped table-advance table-hover" id="example" width="100%">
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                <asp:CheckBox ID="ckPrdSerialAll" runat="server" Text="ALL" />
                                                            </th>
                                                            <th>Factory</th>
                                                            <th>Serial No</th>
                                                            <th>Model Code</th>
                                                            <th>Model</th>
                                                            <th>Pallet No</th>
                                                            <th>Oil Charge</th>
                                                            <th>Running Test</th>
                                                            <th>Weight Check</th>
                                                            <th>Hold By</th>
                                                            <th>Hold Date</th>
                                                            <th>Status</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rptPacking" runat="server" OnItemDataBound="rptPacking_ItemDataBound">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <span class="checkPrdSerial">
                                                                            <asp:CheckBox ID="ckPrdSerial" runat="server" />
                                                                        </span>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblFactory" runat="server" Text='<%# Eval("factory") %>'></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblPrdSerial" runat="server" Text='<%# Eval("prd_serial") %>'></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblModelCode" runat="server" Text='<%# Eval("prd_model_code") %>'></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblModel" runat="server" Text='<%# Eval("prd_model") %>'></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblPalletNo" runat="server" Text='<%# Eval("pl_no") %>'></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Literal ID="lblOilStatus" runat="server" Text='<%# Eval("OilingStatus") %>'></asp:Literal>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Literal ID="lblRunStatus" runat="server" Text='<%# Eval("RunningTestStatus") %>'></asp:Literal>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Literal ID="lblWeightStatus" runat="server" Text='<%# Eval("WeightCheckStatus") %>'></asp:Literal>
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblHoldBy" runat="server" Text='<%# Eval("HoldBy") %>'></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblHoldDate" runat="server" Text='<%# Eval("HoldDate") %>'></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Literal ID="lblStatus" runat="server" Text='<%# Eval("prd_status") %>'></asp:Literal>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </section>


            
        

    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
</asp:Content>

