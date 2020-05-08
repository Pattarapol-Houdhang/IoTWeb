<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="DataLeakcheck.aspx.cs" Inherits="DataHistory_DataLeakcheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!--Data Tables -->
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
    <script src="../js/datatables/buttons.html5.min.js"></script>
    <script src="../js/datatables/buttons.print.min.js"></script>
    <script src="../js/datatables/dataTables.buttons.min.js"></script>
    <script src="../js/datatables/jszip.min.js"></script>
    <script src="../js/datatables/pdfmake.min.js"></script>
    <script src="../js/datatables/vfs_fonts.js"></script>
    <link href="../css/datatables/jquery.dataTables.min.css" rel="stylesheet" />

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

        .data-tbl-boxy {
            margin-left: 0px !important;
        }
    </style>

    <div>

        <div class="page-header">
            <h1>
                <i class="icon-list"></i>
                DATA HISTORY
                <small>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></small>
                <small>
                    <asp:Label ID="Label2" runat="server" Text="" color="red"></asp:Label></small>
            </h1>
            <input type="hidden" id="hidType" name="hidType" value="" />
        </div>
        <div class="row">
            <div class="row" style="margin-left: 5px;">
                <asp:LinkButton ID="btBackPreviousPage" runat="server" OnClick="btBackPreviousPage_Click"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</asp:LinkButton>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <div class="col-sm-2 col-md-4">
                            <h4 align="left">Station</h4>
                            <asp:DropDownList ID="DropDownListPart" runat="server" AutoPostBack="True" CssClass="form-control" Style="width: 100%;">
                                <asp:ListItem Text="LEAK CHECK OK" Value="1" />
                                <asp:ListItem Text="LEAK CHECK REWORK" Value="2" />
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2 col-md-3">
                            <h4 align="left">Start Date</h4>
                            <asp:TextBox ID="start" runat="server" class="datetimepickerStart" Style="width: 100%;"></asp:TextBox>
                            <%--<input id="start" class="datetimepickerStart" runat="server" style="width: 100%;" />--%>
                        </div>
                        <div class="col-sm-2 col-md-3">
                            <h4 align="left">End Date</h4>
                            <asp:TextBox ID="end" runat="server" class="datetimepickerEnd" Style="width: 100%;"></asp:TextBox>
                            <%--<input id="end" class="datetimepickerEnd" runat="server" style="width: 100%;" />--%>
                        </div>
                        <div class="col-sm-2 col-md-2">
                            <h4 align="left">Search</h4>
                            <asp:LinkButton CssClass="btn btn-info" ID="btnSearch" runat="server" Width="100%" Height="30px" BorderStyle="Double" OnClick="btnSearch_Click">
                        <i class="icon-search"></i>
                            </asp:LinkButton>
                        </div>                        
                    </td>
                </tr>
            </table>
            <br />
        </div>

        <br />
        <div class="row">
            <div class="col-md-12">
                <div class="box-widget">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $('#dataItem').dataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": false,
                "paging": true,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]

                /*fixedColumns: {
                    leftColumns: 2
                },
                "sScrollX": true,
                //"sScrollY": "600px",
                "oLanguage": {
                    //"sLengthMenu": "<span class='lengthLabel pull-left'>Entries per page:</span><span class='lenghtMenu pull-left'> _MENU_</span>",
                },
				dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'copyHtml5',
                        title: 'Data_'
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Data_'
                    },
                    {
                        extend: 'csvHtml5',
                        title: 'Data_'
                    }
                ],
                "sDom": '<"widget-head clearfix"fl>,<"widget-container"t>,<"table-bottom clearfix"<"tbl-pagination pull-left"p><"tbl-data-info pull-right"i>>'
				*/
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
                change: endChange,
                format: "yyyy/MM/dd HH:mm",
                americanMode: false,
                timeFormat: 'HH:mm',
                parseFormats: ["yyyy/MM/dd"]
            }).data("kendoDateTimePicker");


            start.max(end.value());
            end.min(start.value());
        });
    </script>
    <script type="text/javascript">

        var parameter = Sys.WebForms.PageRequestManager.getInstance();
        parameter.add_endRequest(function () {
            $('#dataItem').dataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": false,
                "paging": true,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
                /*
				fixedColumns: {
                    leftColumns: 2
                },
                "sScrollX": true,
                //"sScrollY": "600px",
                "oLanguage": {
                    //"sLengthMenu": "<span class='lengthLabel pull-left'>Entries per page:</span><span class='lenghtMenu pull-left'> _MENU_</span>",
                },
				dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'copyHtml5',
                        title: 'Data_'
                    },
                    {
                        extend: 'excelHtml5',
                        title: 'Data_'
                    },
                    {
                        extend: 'csvHtml5',
                        title: 'Data_'
                    }
                ],
                "sDom": '<"widget-head clearfix"fl>,<"widget-container"t>,<"table-bottom clearfix"<"tbl-pagination pull-left"p><"tbl-data-info pull-right"i>>'
				*/
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


            start.max(end.value());
            end.min(start.value());



        });



    </script>
</asp:Content>

