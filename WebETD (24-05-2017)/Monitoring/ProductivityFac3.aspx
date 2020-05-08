<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ProductivityFac3.aspx.cs" Inherits="Monitoring_ProductivityFac3" %>

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


    <div class="page-header">
        <h1>
            <i class="icon-bars"></i>
            PRODUCTIVITY FACTORY 3
                <small>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></small>
        </h1>
        <input type="hidden" id="hidType" name="hidType" value="" />
        <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
    </div>
    <div class="row">
        <div class="col-md-12 widget-module">
            <div class="box-widget">
                <div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-5 control-label" ID="Label2" runat="server" Text="DATE : "></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox CssClass="form-control datepicker" ID="txtDate" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-5 control-label" ID="lblShift" runat="server" Text="SHIFT : "></asp:Label>
                    <div class="col-lg-10">
                        <asp:DropDownList CssClass="form-control" ID="dropDownShift" runat="server">
                            <asp:ListItem Text="DAY" Value="DAY" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="NIGHT" Value="NIGHT"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-5 control-label" ID="Label3" runat="server" Text="SEARCH : " Visible="True" ForeColor="White"></asp:Label>
                    <div class="col-lg-10">
                        <asp:Button CssClass="btn btn-info" ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    <%=GenGraph() %>

    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
        <%--<%=GenTable() %>--%>
        <%--<table class='table' style='width: 5000px;' border="1">
            <tr>
                <td rowspan="3">Line
                </td>
                <td rowspan="3">Process
                </td>
                <td colspan="60">November
                </td>

            </tr>
            <tr>
                <td colspan="2" style="background-color: yellow;">1
                </td>
            </tr>
            <tr>
                <td style="background-color: white;">D
                </td>
                <td style="background-color: yellow;">N
                </td>

            </tr>


            <tr>
                <td rowspan="3">
                    Piston
                </td>
                <td>
                    Plan
                </td>
                <td  style="background-color: yellow;">
                    1300
                </td>
                <td style="background-color: yellow;">
                    0
                </td>
            </tr>
            <tr>
                 <td>
                    Start
                </td>
                <td style="background-color: yellow;">
                    1200
                </td>
                <td style="background-color: yellow;">
                    0
                </td>
            </tr>
            <tr>
                 <td>
                    Last
                </td>
                <td style="background-color: yellow;">
                    800
                </td>
                <td style="background-color: yellow;">
                    0
                </td>
            </tr>

        </table>--%>
    </asp:Panel>

    <script type="text/javascript">
        $(document).ready(function () {
            var today = new Date()
            // create DatePicker from input HTML element
            $(".datepicker").kendoDatePicker({
                value: today,
                format: "yyyy-MM-dd"
            });
        });
    </script>
</asp:Content>

