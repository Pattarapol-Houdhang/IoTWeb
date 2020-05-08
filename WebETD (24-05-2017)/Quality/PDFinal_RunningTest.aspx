<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PDFinal_RunningTest.aspx.cs" Inherits="Quality_PDFinal_RunningTest" %>

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
                <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-exclamation-circle"></i>Running Test History</h3>
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
                        Running Test History
                    </header>
                    <div class="panel-body">
                        <div class="form-group">
                            <table class="table table-striped table-advance table-hover" id="example" width="100%">
                                <thead>
                                    <tr>
                                        <th>DateShift</th>
                                        <th>ModelNo</th>
                                        <th>MachineNo</th>
                                        <th>PartSerialNo</th>
                                        <th>CycleStartTime</th>
                                        <th>CycleEndTime</th>
                                        <th>ManufacturingTime</th>
                                        <th>ConstantPressedTime</th>
                                        <th>ConstantJudgement</th>
                                        <th>RotationFrequencyArrivalTime</th>
                                        <th>RotationJudgement</th>
                                        <th>ExhalationTime</th>
                                        <th>ExhalationJudgement</th>
                                        <th>DrivingCurrent</th>
                                        <th>DrivingJudgement</th>
                                        <th>VacuumArrivalTime</th>
                                        <th>VacuumJudgement</th>
                                        <th>VacuumHoldtimeJudgement</th>
                                        <th>IntegratedJudgementResult</th>
                                        <th>InsulationInspectionResult</th>
                                        <th>ResistingPressureInspection</th>
                                        <th>WindingResistanceUV</th>
                                        <th>WindingJudgement</th>
                                        <th>IntegratedJudgementResult2</th>
                                        <th>FluxMeasuredValue</th>
                                        <th>FluxJudgementResult</th>
                                        <th>TempertureSurface</th>
                                        <th>JudgementSeletedNo</th>
                                        <th>MachineNumber</th>
                                        <th>q_axis_a</th>
                                        <th>InsertDate</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrDateShift" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrModelNo" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrMachineNo" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrPartSerialNo" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrCycleStartTime" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrCycleEndTime" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrManufacturingTime" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrConstantPressedTime" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrConstantJudgement" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrRotationFrequencyArrivalTime" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrRotationJudgement" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrExhalationTime" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrExhalationJudgement" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrDrivingCurrent" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrDrivingJudgement" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrVacuumArrivalTime" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrVacuumJudgement" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrVacuumHoldtimeJudgement" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrIntegratedJudgementResult" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrInsulationInspectionResult" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrResistingPressureInspection" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrWindingResistanceUV" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrWindingJudgement" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrIntegratedJudgementResult2" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrFluxMeasuredValue" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrFluxJudgementResult" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrTempertureSurface" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrJudgementSeletedNo" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrMachineNumber" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrq_axis_a" runat="server"></asp:Literal></td>
                                                <td style="text-align: center;">
                                                    <asp:Literal ID="ltrInsertDate" runat="server"></asp:Literal></td>
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

