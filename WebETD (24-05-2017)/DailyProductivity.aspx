<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="DailyProductivity.aspx.cs" Inherits="DailyProductivity" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Production Data By Line</title>
	<meta http-equiv="refresh" content="300" />
    <!-- styles -->
    <link href="//cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="~/css/bootstrap.css" rel="stylesheet" />
    <link href="~/css/font-alpona.css" rel="stylesheet" />
    <link href="~/css/prettify.css" rel="stylesheet" />
    <link href="~/css/responsive-tables.css" rel="stylesheet" />
    <link href="~/css/styles.css" rel="stylesheet" />
    <link href="~/css/bootstrap-reset.css" rel="stylesheet" />
    <link href="~/css/highcharts.css" rel="stylesheet" />
    <link href="~/css/kendo.common-material.min.css" rel="stylesheet" />
    <link href="~/css/kendo.material.min.css" rel="stylesheet" />
    <link href="~/css/kendo.material.mobile.min.css" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.buttons.css") %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.css") %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.nonblock.css") %>" rel="stylesheet" />
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/MasterOffsetDetail.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/kendo.all.min.js") %>"></script>
    <%--<script type="text/javascript" src="<%= ResolveUrl("~/js/highcharts.js") %>"></script>--%>
    <script src="<%= ResolveUrl("~/Highcharts/highstock.js") %>"></script>
    <%--<script src="Highcharts/highcharts.js"></script>--%>
    <script src="<%= ResolveUrl("~/Highcharts/modules/exporting.js") %>"></script>
    <%-- <script src="<%= ResolveUrl("~/vendors/jquery-sparkline/dist/jquery.sparkline.min.js") %>"></script>--%>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/datatables/jquery.dataTables.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.buttons.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.nonblock.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-ui-1.10.3.custom.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/prettify.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.nicescroll.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.cookie.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.hoverIntent.minified.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.dcjqaccordion.2.7.js") %>"></script>
    <script type="text/javascript" src="//cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/common-script.js") %>"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var today = new Date()
            // create DatePicker from input HTML element
            $(".datepicker").kendoDatePicker({
                //value: today,
                format: "yyyy-MM-dd"
            });

            $('#tbResult').DataTable({
                searching: false,
                lengthChange: false,
                bInfo: false,
                pageLength: 50,
				paging: false

            });
        });
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 18px;
        }
		body{
			background: #fff;
			font-size: 38px;
		}
		#tbResult thead{
			background-color: #546990;
			color: #fff;
			
		}
		#tbResult{
			border-top: 1px solid #111!important;
			border-left: 1px solid #111!important;
		}
		#tbResult th, #tbResult td
		{
			border-right: 1px solid #111!important;
			border-bottom: 1px solid #111!important;
			padding: 1px 2px;
		}
		table.dataTable tr.odd { background-color: #fff; }
		table.dataTable tr.even { background-color: #e2e4ff; }
		
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="row">
            <div class="col-md-12 widget-module" style="text-align: center;">
                <div><h3><b>PRODUCTIVITY</b></h3></div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 widget-module">
                <div >
                    <div class="col-md-3 form-group">
                        <div class="col-lg-3">
                            <asp:TextBox CssClass="form-control datepicker" ID="txtDate" runat="server" Placeholder="Please select date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-2 form-group">
                        <div class="col-lg-2">
                            <asp:Button CssClass="btn btn-info" ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="square-widget">
            <div class="widget-container">
                <table id="tbResult" class="cell-border hover" cellspacing="0" style="width: 95%">
                    <thead>
                        <tr>
                            <th rowspan="2" style="display:none;">Board Id </th>
                            <th style="text-align: center" rowspan="2">Line Code</th>
                            <th style="text-align: center" rowspan="2">Line Name</th>
                            <th style="text-align: center" class="text-center" colspan="4">DAY SHIFT</th>
                            <th style="text-align: center" class="text-center" colspan="4">NIGHT SHIFT</th>
                        </tr>
                        <tr>
                            <th class="auto-style1" style="text-align: center">Plan</th>
                            <th class="auto-style1" style="text-align: center">Actual</th>
                            <th class="auto-style1" style="text-align: center">Diff</th>
                            <th class="auto-style1" style="text-align: center">NG</th>
                            <th class="auto-style1" style="text-align: center">Plan</th>
                            <th class="auto-style1" style="text-align: center">Actual</th>
                            <th class="auto-style1" style="text-align: center">Diff</th>
                            <th class="auto-style1" style="text-align: center">NG</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound">
                            <ItemTemplate>
                                <tr>
                                    <td style="display:none;">
                                        <asp:Literal ID="ltrBoardId" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrLineCode" runat="server"></asp:Literal></td>
                                    <td>
                                        <asp:Literal ID="ltrLineName" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrPlanDay" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrActualDay" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrDiffDay" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrTotalNgDay" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrPlanNight" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrActualNight" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrDiffNight" runat="server"></asp:Literal></td>
                                    <td style="text-align: right">
                                        <asp:Literal ID="ltrTotalNgNight" runat="server"></asp:Literal></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>

