<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ProductivityFac3History.aspx.cs" Inherits="DataHistory_ProductivityFac3History" %>


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
                    <i class="icon-list-4"></i>
                    PRODUCTIVITY FACTORY 3
                <small>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></small>
                </h1>
                <asp:HiddenField ID="hidMonth" runat="server"  />
                <asp:HiddenField ID="hidYear" runat="server" />

                <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-12 widget-module">
                    <div class="box-widget">
                        <div class="col-md-2 form-group">
                            <asp:Label CssClass="col-lg-12 control-label" ID="Label2" runat="server" Text="DATE : "></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control datepicker" ID="txtDate" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-1 form-group">
                            <asp:Label CssClass="col-lg-12 control-label" ID="Label3" runat="server" Text="SEARCH : "></asp:Label>
                            <div class="col-lg-10">
                                <asp:Button CssClass="btn btn-info" ID="btnSearch" runat="server" Text="SEARCH" />
                            </div>
                        </div>
                        <div class="col-md-2 form-group">
                            <asp:Label CssClass="col-lg-12 control-label" ID="Label4" runat="server" Text="EXPORT TO EXCEL : "></asp:Label>
                            <div class="col-lg-10">
                                <asp:Button CssClass="btn btn-success" ID="btExport" runat="server" Text="EXPORT" OnClick="btExport_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
                <%=GenTable() %>
            </asp:Panel>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btExport" />
        </Triggers>
    </asp:UpdatePanel>

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

