<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDQuantityGraph.aspx.cs" Inherits="Production_Graph_Quantity_PDQuantityGraph" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    <div class="page-header">

        <h1>
            <i class="icon-bars"></i>
            Select Production Line
            <small>Select Production Line you want to see.</small>
        </h1>

    </div>

    <div class="board-widget">
        <div class="row" style="margin-left: 5px;">
            <asp:LinkButton ID="btBackPreviousPage" runat="server" OnClick="btBackPreviousPage_Click"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</asp:LinkButton>
        </div>
        <br />
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
                                            <label class="col-lg-2 control-label">Factory</label>
                                            <div class="col-lg-4">
                                                <asp:Label ID="lbFactory" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                            <label class="col-lg-2 control-label">PD Line</label>
                                            <div class="col-lg-4">
                                                <asp:Label ID="lbPDLine" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Machine</label>
                                            <div class="col-lg-4">
                                                <asp:Label ID="lbMachine" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                            <label class="col-lg-2 control-label">Model</label>
                                            <div class="col-lg-4">
                                                <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">DateStart</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtDateStart" runat="server" aria-describedby="inputSuccess2Status2" required="required" class="datepicker form-control col-md-7 col-xs-12"></asp:TextBox>
                                            </div>
                                            <label class="col-lg-2 control-label">DateEnd</label>
                                            <div class="col-lg-4">
                                                <asp:TextBox ID="txtDateEnd" runat="server" aria-describedby="inputSuccess2Status2" required="required" class="datepicker form-control col-md-7 col-xs-12"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">&nbsp;</label>
                                            <div class="col-lg-10">
                                                <div class="form-actions">
                                                    <asp:Button ID="btSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btSearch_Click" />

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
            <div id="container" style="/*min-width: 310px; height: 400px; */ margin: 0 auto"></div>
                                        <%=LoadGraph() %>
        </div>

    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var today = new Date()
            // create DatePicker from input HTML element
            $(".datepicker").kendoDateTimePicker({
                value: today,
                format: "yyyy-MM-dd HH:00:00"
            });
        });
    </script>

    
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

