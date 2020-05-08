<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PDFinalHold_Detail.aspx.cs" Inherits="Quality_PDFinalHold_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        $(document).ready(function () {
            $('#example').DataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": false,
                "paging": true,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'print'
                ]
            });
        });
    </script>
    <section class="wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-exclamation-circle"></i>Compressor Hold History</h3>
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
                            <div class="row">
                                <label class="col-sm-2 control-label" style="text-align: right!important">Model Name:</label>
                                <div class="col-sm-2">
                                    <asp:Label ID="ltrModelName" runat="server" Text="-"></asp:Label>
                                </div>
                                <label class="col-sm-2 control-label" style="text-align: right!important">Model Code:</label>
                                <div class="col-sm-2">
                                    <asp:Label ID="ltrModelCode" runat="server" Text="-"></asp:Label>
                                </div>
                                <label class="col-sm-1 control-label" style="text-align: right!important"></label>
                                <div class="col-sm-2">
                                </div>
                                <div class="col-sm-1">
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-sm-2 control-label" style="text-align: right!important">Serial:</label>
                                <div class="col-sm-2">
                                    <asp:Label ID="ltrSerialNo" runat="server" Text="-"></asp:Label>
                                </div>
                                <label class="col-sm-2 control-label" style="text-align: right!important">Pipe:</label>
                                <div class="col-sm-2">
                                    <asp:Label ID="ltrPipeNo" runat="server" Text="-"></asp:Label>
                                </div>
                                <label class="col-sm-1 control-label" style="text-align: right!important"></label>
                                <div class="col-sm-2">
                                </div>
                                <div class="col-sm-1">
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
                        Hold History
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <table class="table table-striped table-advance table-hover" id="example" width="100%">
                                <thead>
                                    <tr>
                                        <th>Serial No</th>
                                        <th>Model</th>
                                        <th>ModelCode</th>
                                        <th>Pipe No</th>
                                        <th>Oil Charge</th>
                                        <th>Running Test</th>
                                        <th>Weight Check</th>
                                        <th>Update By</th>
                                        <th>Update Date</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblPrdSerial" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblModelCode" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblModel" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblPipeNo" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblOilStatus" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblRunStatus" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblWeightStatus" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblHoldBy" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblHoldDate" runat="server"></asp:Literal>
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="lblStatus" runat="server"></asp:Literal>
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

</asp:Content>

