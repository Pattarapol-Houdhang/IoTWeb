<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PDAllowPacking.aspx.cs" Inherits="Quality_PDAllowPacking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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

            <%--//------------------ Prd Date ----------------------
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

            //------------------ Prd Date ------------------------%>
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


     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>

            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight:bold"><i class="fa fa-exclamation-circle"></i>Allow Packing</h3>
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
                                        <div class="col-lg-1">
                                            <span style="font-size: 20px;">Serial No.:</span>
                                        </div>
                                        <div class="col-lg-5">
                                            <asp:TextBox ID="txtSerialNo" Font-Size="50px" CssClass="form-control" runat="server" Height="60px"></asp:TextBox>
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
                                Detail
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <table class="table table-striped table-advance table-hover" id="example" width="100%">
                                        <thead>
                                            <tr>
                                                <th align="center">
                                                    <asp:CheckBox ID="ckPrdSerialAll" runat="server" Text="ALL" />
                                                </th>
                                                <th align="center">Production Line</th>
                                                <th align="center">Pallet No</th>
                                                <th align="center">Serial No</th>
                                                <th align="center">ModelCode</th>
                                                <th align="center">Model</th>
                                                <th align="left">Hold By</th>
                                                <th align="center">Hold Date</th>
                                                <th align="left">Request By</th>
                                                <th align="center">Request Date</th>
                                                <th align="left">UnHold By</th>
                                                <th align="center">UnHold Date</th>
                                                <th align="center">Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptPacking" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td align="center">
                                                            <span class="checkPrdSerial">
                                                                <asp:CheckBox ID="ckPrdSerial" runat="server" />
                                                            </span>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblPrdLine" runat="server" Text='<%# Eval("prd_line") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblPalletNo" runat="server" Text='<%# Eval("pl_no") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblPrdSerial" runat="server" Text='<%# Eval("prd_serial") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblModelCode" runat="server" Text='<%# Eval("prd_model_code") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblModel" runat="server" Text='<%# Eval("prd_model") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblHoldBy" runat="server" Text='<%# Eval("HoldBy") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblHoldDate" runat="server" Text='<%# Eval("HoldDate") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblRequestBy" runat="server" Text='<%# Eval("RequestBy") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblRequestDate" runat="server" Text='<%# Eval("RequestDate") %>'></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblAllowBy" runat="server" Text='<%# Eval("AllowBy") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblAllowDate" runat="server" Text='<%# Eval("AllowDate") %>'></asp:Label>
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
                <!-- Basic Forms & Horizontal Forms-->
            </section>


            
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>


</asp:Content>

