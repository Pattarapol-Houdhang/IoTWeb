<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PDLineOutData.aspx.cs" Inherits="Quality_PDLineOutData" %>

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
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight:bold"><i class="fa fa-exclamation-circle"></i>FACTORY 1, 2 - LINE OUT</h3>
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
                                    <table width="100%">
                                        <tr>
                                            <td width="10%" align="right">Date : </td>
                                            <td width="15%"><asp:TextBox ID="txtDate" runat="server" class="form-control" Text="" ></asp:TextBox></td>
                                            <td width="2%" width="3%"></td>
                                            <td width="10%" align="right">Production : </td>
                                            <td width="15%">
                                                <asp:DropDownList ID="ddlProdLine" runat="server" CssClass="form-control" >
                                                    <asp:ListItem Value="1YC" >1YC (Factory 1)</asp:ListItem>
                                                    <asp:ListItem Value="2YC" >2YC</asp:ListItem>
                                                    <asp:ListItem Value="SCR" Selected="True">SCROLL</asp:ListItem>
                                                    <asp:ListItem Value="ODM" >ODM</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td width="2%"></td>
                                            <td width="10%" align="right">Status : </td>
                                            <td width="15%">
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" >
                                                    <asp:ListItem Value="ALL"> -- ALL --</asp:ListItem>
                                                    <asp:ListItem Value="HOLD">FG HOLD</asp:ListItem>
                                                    <asp:ListItem Value="LINEOUT" Selected="True">Line Out</asp:ListItem>
                                                    <asp:ListItem Value="REQUEST" >REQUEST UNHOLD</asp:ListItem>
                                                    <asp:ListItem Value="ALLOW">UNHOLD</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td width="2%"></td>
                                            <td rowspan="4"  width="20%">
                                                <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn" Text="Search" OnClick="btnSearch_Click"  />
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
                                            <td align="right">Pallet No : </td>
                                            <td><asp:TextBox ID="txtPalletNo" runat="server" class="form-control"></asp:TextBox></td>
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
                            <header class="panel-heading">Line Out Data List</header>
                            <div class="panel-body">
                                <div class="form-group">

                                    <%= GetData() %>

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

