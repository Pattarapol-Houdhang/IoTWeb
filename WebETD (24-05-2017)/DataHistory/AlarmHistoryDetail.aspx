<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="AlarmHistoryDetail.aspx.cs" Inherits="DataHistory_AlarmHistoryDetail" %>


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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <h1>
                    <i class="icon-bars"></i>
                    Alarm History
            <small>Search Alarm History Data by Line
            </small>
                </h1>
            </div>

            <div class="board-widget">

                <div class="row">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="col-md-8 widget-module">
                            <div class="box-widget">
                                <div class="widget-head clearfix">
                                    <span class="h-icon"><i class="icon-binoculars-2"></i></span>
                                    <h4 class="pull-left">Search Area </h4>
                                    <div class="pull-right widget-action">
                                        <ul>
                                            <li><a href="#" class="widget-collapse"><i class="icon-arrow-down"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="widget-container" style="display: block;">
                                    <div class="widget-block">
                                        <div class="widget-content">
                                            <div class="form-horizontal form-box">

                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Line</label>
                                                    <div class="col-lg-4">
                                                        <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <label class="col-lg-2 control-label">Machine</label>
                                                    <div class="col-lg-4">
                                                        <asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Start Date</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtDateStart" runat="server" class="datetimepickerStart" Style="width: 100%;"></asp:TextBox>
                                                    </div>
                                                    <label class="col-lg-2 control-label">End Date</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtDateEnd" runat="server" class="datetimepickerEnd" Style="width: 100%;"></asp:TextBox>
                                                    </div>
                                                    
                                                </div>



                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">&nbsp;</label>
                                                    <div class="col-lg-4">
                                                        <div class="form-actions">
                                                            <asp:Button ID="btSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btSearch_Click" />
                                                            <asp:Button ID="btnExcel" runat="server" Text="EXPORT EXCEL" BackColor="Green" CssClass="btn btn-primary" OnClick="btnExcel_Click" />
                                                        </div>
                                                    </div>
                                                    
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        Summary Data:
                        <asp:Label ID="lbSummaryData" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal">
                            <div class="widget-container" style="display: block;">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    CssClass="table table-bordered table-hover responsive"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                    OnSorting="GridView1_Sorting" PageSize="10">
                                </asp:GridView>
                            </div>
                            <!-- table table-bordered table-hover responsive -->
                        </asp:Panel>
                    </div>
                </div>
            </div>

            <script type="text/javascript">
                $(document).ready(function () {
                    var today = new Date()
                    // create DatePicker from input HTML element
                    $(".datepicker").kendoDateTimePicker({

                        format: "yyyy-MM-dd HH:00:00"
                    });
                });
            </script>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btSearch" />
            <asp:PostBackTrigger ControlID="btnExcel" />
            <asp:PostBackTrigger ControlID="ddlLine" />
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
            
            var todayStart = new Date(new Date().getFullYear().toString() + '-' + new Date().getMonth().toString() + '-' + new Date().getDate().toString() + ' 08:00');
            var todayEnd = new Date(new Date().getFullYear().toString() + '-' + new Date().getMonth().toString() + '-' + new Date().getDate().toString() + ' 20:00');
            

            var start = $(".datetimepickerStart").kendoDateTimePicker({
                //value: todayStart,
                change: startChange,
                format: "yyyy/MM/dd HH:mm",
                americanMode: false,
                timeFormat: 'HH:mm',
                parseFormats: ["yyyy/MM/dd HH:mm"]
            }).data("kendoDateTimePicker");
                        

            var end = $(".datetimepickerEnd").kendoDateTimePicker({
                //value: todayEnd,
                change: endChange,
                format: "yyyy/MM/dd HH:mm",
                americanMode: false,
                timeFormat: 'HH:mm',
                parseFormats: ["yyyy/MM/dd HH:mm"]
            }).data("kendoDateTimePicker");


            //start.max(end.value());
            //end.min(start.value());
        });
    </script>
    
</asp:Content>

