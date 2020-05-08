<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="DataHistoryMain.aspx.cs" Inherits="DataHistory_DataHistoryMain" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.dataTables.js")%>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/dataTables.bootstrap.js")%>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/datatables/jquery.dataTables.min.js")%>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/TableTools.js")%>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/datatables/dataTables.fixedColumns.min.js")%>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/bootstrap.min.js")%>"></script>


    <link href="<%= ResolveClientUrl("~/css/datatables/fixedColumns.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/css/datatables/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/css/styles.css") %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/css/font-alpona.css") %>" rel="stylesheet" />


    <style type="text/css">
        .item-block {
            cursor: pointer;
        }

        table td {
            padding: 1px 2px !important;
        }

        table td, table th {
            text-align: center;
            /*border-right: 1px #5b5847 solid;*/
        }
        /*table {
            border-left: 1px #5b5847 solid;
        }*/

        .dataTables_length {
            float: right !important;
            text-align: right !important;
        }

        .dataTables_filter {
            float: left !important;
            text-align: left !important;
        }

            .dataTables_filter input {
                display: inline-block;
                height: 26px;
                padding: 3px;
                font-size: 14px;
                line-height: 1.428571429;
                color: #555555;
                vertical-align: middle;
                background-color: #ffffff;
                border: 1px solid #cccccc;
                border-radius: 4px;
                -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
                box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
                -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
                transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            }


        .modal2 {
            position: fixed;
            z-index: 9999999;
            height: 100%;
            width: 100%;
            top: 0;
            /*background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;*/
        }

        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 180px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }

        .center img {
            height: 128px;
            width: 128px;
        }
        .data-tbl-boxy{
            margin-left: 0px !important;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>

            <div class="page-header">
                <h1>
                    <i class="icon-list"></i>
                    DATA HISTORY FACTORY 3
                <small>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></small>
                </h1>
                <input type="hidden" id="hidType" name="hidType" value="" />
                <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="row">
                <%-- <div class="row" style="margin-left: 5px;">
            <asp:LinkButton ID="btBackPreviousPage" runat="server"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</asp:LinkButton>
        </div>--%>
                <br />
                <div class="row">
                    <div class="col-sm-2 col-md-2">
                        <h4>Line</h4>
                        <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control" Style="width: 100%;" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Text="Main Assembly Line" Value="4" />
                            <asp:ListItem Text="Piston Finish Line" Value="5" />
                            <asp:ListItem Text="Front Head Finish Line" Value="16" />
                            <asp:ListItem Text="Crank Shaft Finish Line" Value="7" />
                            <asp:ListItem Text="Cylinder Finish Line" Value="6" />
                            <asp:ListItem Text="Rear Head Line" Value="1" />
                            <asp:ListItem Text="Casing Pipe Line" Value="2" />
                            <asp:ListItem Text="Stator Line" Value="8" />
                            <asp:ListItem Text="Rotor Line" Value="9" />
                            <asp:ListItem Text="Final Line" Value="10" />
                            <asp:ListItem Text="Mecha" Value="11" />
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <h4>Machine</h4>
                        <asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" Style="width: 100%;" OnSelectedIndexChanged="ddlMachine_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-2 col-md-1">
                        <h4>Search</h4>
                        <asp:LinkButton CssClass="btn btn-info" ID="btnSearch" runat="server" Width="100%" Height="30px" BorderStyle="Double" OnClick="btnSearch_Click">
                                <i class="icon-search"></i>
                        </asp:LinkButton>
                    </div>
                    <div class="col-sm-2 col-md-2">
                        <h4>Export to excel</h4>
                        <asp:LinkButton CssClass="btn btn-success" ID="btnExcel" runat="server" Width="50%" Height="30px" BorderStyle="Double" Enabled="false" Visible="true" OnClick="btnExcel_Click">
                                <i class="icon-file-excel"></i>
                        </asp:LinkButton>
                    </div>

                </div>
                <div class="row">
                    <div class="col-sm-1 col-md-1">
                        <h4>Select</h4>
                        <asp:RadioButtonList ID="rbSearchSelect" runat="server" OnSelectedIndexChanged="rbSearchSelect_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Datetime" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Serial No." Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <asp:Panel ID="panelDatetime" runat="server" Visible="true">
                        <div class="col-sm-2 col-md-2">
                            <h4>Start Date</h4>
                            <asp:TextBox ID="txtDateStart" runat="server" class="datetimepickerStart" Style="width: 100%;"></asp:TextBox>
                        </div>
                        <div class="col-sm-2 col-md-2">
                            <h4>End Date</h4>
                            <asp:TextBox ID="txtDateEnd" runat="server" class="datetimepickerEnd" Style="width: 100%;"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panelSerial" runat="server" Visible="false">
                         <div class="col-sm-1 col-md-1">
                            <h5>Production Year</h5>
                            <asp:DropDownList ID="ddlPDYear" runat="server" CssClass="form-control">                                
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-1 col-md-1">
                            <h4>Model</h4>
                            <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control">
                                <asp:ListItem Text="ALL" Value=""></asp:ListItem>
                                <asp:ListItem Text="1YC15BXD" Value="0442"></asp:ListItem>
                                <asp:ListItem Text="1YC20HXD" Value="0444"></asp:ListItem>
                                <asp:ListItem Text="1YC22DXD" Value="0121"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2 col-md-2">
                            <h4>
                                <asp:Label ID="lbSerialType" runat="server" Text="Serial No."></asp:Label></h4>
                            <asp:TextBox ID="txtSerialList" runat="server" Style="width: 100%; height: 100px; " TextMode="MultiLine"></asp:TextBox>
                        </div>
                        
                        <div class="col-sm-2 col-md-2" style="color: red;">
                            ค้นหาโดย Serial Number มากกว่า 1 ตัว ให้ใส่ตัวละบรรทัด เช่น.(Example)<br />
                            Can search Serial Number more than 1 like example below.<br />
                            90001234<br />
                            90001235<br />
                            90001236<br />
                            90001237<br />

                        </div>
                        <div id="noteLabel" runat="server" class="col-sm-3 col-md-3" style="color: red;" visible="false">
                            DateMC = Production Date. (Thai time +12 Hours.)<br />
                            MFGDate = Label Print Date. (Thai time)

                        </div>
                    </asp:Panel>
                </div>

            </div>
            <br />

            <div class="row">
                <div class="col-md-12">
                    <div class="box-widget">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnExcel" />
            <asp:PostBackTrigger ControlID="ddlLine" />
            <asp:PostBackTrigger ControlID="rbSearchSelect" />
            <asp:PostBackTrigger ControlID="ddlMachine" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">

        $(document).ready(function () {
            $('.data-tbl-boxy').dataTable({
                "sScrollX": true,
                //"sScrollY": "600px",
                "oLanguage": {
                    //"sLengthMenu": "<span class='lengthLabel pull-left'>Entries per page:</span><span class='lenghtMenu pull-left'> _MENU_</span>",
                },
                "sDom": '<"widget-head clearfix"fl>,<"widget-container"t>,<"table-bottom clearfix"<"tbl-pagination pull-left"p><"tbl-data-info pull-right"i>>'
            });

            $('#example2').DataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": true,
                "paging": true,
                "lengthMenu": [[30, 25, 50, -1], [30, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ],

            });

            function startChange() {
                var startDate = start.value(),
                endDate = end.value();

                if (startDate) {
                    startDate = new Date(startDate);
                    startDate.setDate(startDate.getDate());
                    end.min(startDate);
                } else if (endDate) {
                    start.max(new Date(endDate));
                } else {
                    endDate = new Date();
                    start.max(endDate);
                    end.min(endDate);
                }
            }

            function endChange() {
                var endDate = end.value(),
                startDate = start.value();

                if (endDate) {
                    endDate = new Date(endDate);
                    endDate.setDate(endDate.getDate());
                    start.max(endDate);
                } else if (startDate) {
                    end.min(new Date(startDate));
                } else {
                    endDate = new Date();
                    start.max(endDate);
                    end.min(endDate);
                }
            }

            var today = kendo.date.today();



            var start = $(".datetimepickerStart").kendoDateTimePicker({
                //value: today,
                change: startChange,
                format: "yyyy/MM/dd HH:mm",
                americanMode: false,
                timeFormat: 'HH:mm',
                parseFormats: ["yyyy/MM/dd"]
            }).data("kendoDateTimePicker");

            var end = $(".datetimepickerEnd").kendoDateTimePicker({
                //value: today,
                change: startChange,
                format: "yyyy/MM/dd HH:mm",
                americanMode: false,
                timeFormat: 'HH:mm',
                parseFormats: ["yyyy/MM/dd"]
            }).data("kendoDateTimePicker");


            //start.max(end.value());
            //end.min(start.value());
        });
    </script>
    <script type="text/javascript">

        var parameter = Sys.WebForms.PageRequestManager.getInstance();
        parameter.add_endRequest(function () {

            $('.data-tbl-boxy').dataTable({
                "sScrollX": true,
                //"sScrollY": "600px",
                "oLanguage": {
                    //"sLengthMenu": "<span class='lengthLabel pull-left'>Entries per page:</span><span class='lenghtMenu pull-left'> _MENU_</span>",
                },
                "sDom": '<"widget-head clearfix"fl>,<"widget-container"t>,<"table-bottom clearfix"<"tbl-pagination pull-left"p><"tbl-data-info pull-right"i>>'
            });

            $('#example').DataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": true,
                "paging": true,
                "lengthMenu": [[30, 25, 50, -1], [30, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ],

            });

            function startChange() {
                var startDate = start.value(),
                endDate = end.value();

                if (startDate) {
                    startDate = new Date(startDate);
                    startDate.setDate(startDate.getDate());
                    end.min(startDate);
                } else if (endDate) {
                    start.max(new Date(endDate));
                } else {
                    endDate = new Date();
                    start.max(endDate);
                    end.min(endDate);
                }
            }

            function endChange() {
                var endDate = end.value(),
                startDate = start.value();

                if (endDate) {
                    endDate = new Date(endDate);
                    endDate.setDate(endDate.getDate());
                    start.max(endDate);
                } else if (startDate) {
                    end.min(new Date(startDate));
                } else {
                    endDate = new Date();
                    start.max(endDate);
                    end.min(endDate);
                }
            }

            var today = kendo.date.today();


            var start = $(".datetimepickerStart").kendoDateTimePicker({
                //value: today,
                change: startChange,
                format: "dd/MM/yyyy HH:mm",
                parseFormats: ["dd/MM/yyyy"]
            }).data("kendoDateTimePicker");

            var end = $(".datetimepickerEnd").kendoDateTimePicker({
                //value: today,
                change: endChange,
                format: "dd/MM/yyyy HH:mm",
                parseFormats: ["dd/MM/yyyy"]
            }).data("kendoDateTimePicker");


            //start.max(end.value());
            //end.min(start.value());

        });



    </script>
</asp:Content>

