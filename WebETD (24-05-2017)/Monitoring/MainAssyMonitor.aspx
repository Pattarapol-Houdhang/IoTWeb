<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="MainAssyMonitor.aspx.cs" Inherits="Monitoring_MainAssyMonitor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">

                <h1>
                    <i class="icon-clipboard-2"></i>
                    DAILY REPORT : Main Assembly Line 6 Factory 3
            <small></small>
                </h1>

            </div>
            <div class="row">
                <div class="col-md-12 widget-module">
                    <div class="box-widget">
                        <%--<div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-6 control-label" ID="lblLineName" runat="server" Text="LINE NAME : "></asp:Label>
                    <div class="col-lg-10">
                        <asp:DropDownList CssClass="form-control" ID="dropDownListLineName" runat="server">
                            <asp:ListItem>MECHA LINE 1</asp:ListItem>
                            <asp:ListItem>MECHA LINE 3</asp:ListItem>
                            <asp:ListItem>MACHINE LINE FAC3</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>--%>
                        <div class="col-md-3 form-group">
                            <asp:Label CssClass="col-lg-6 control-label" ID="Label1" runat="server" Text="DATE : "></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control datepicker" ID="txtDate" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 form-group">
                            <asp:Label CssClass="col-lg-6 control-label" ID="lblShift" runat="server" Text="SHIFT : "></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList CssClass="form-control" ID="ddlShift" runat="server">
                                    <asp:ListItem Selected="True">DAY</asp:ListItem>
                                    <asp:ListItem>NIGHT</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3 form-group">
                            <asp:Label CssClass="col-lg-6 control-label" ID="Label3" runat="server" Text="SEARCH : " Visible="True" ForeColor="White"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Button CssClass="btn btn-info" ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6 col-md-3">
                    <h4>
                    Date: <asp:Label ID="lbDate" runat="server" Text="-"></asp:Label></h4>
                    <h4>
                    Plan: <asp:Label ID="lbPlan" runat="server" Text="0"></asp:Label></h4>
                    <h4>
                    Model: <asp:Label ID="lbModel" runat="server" Text="-"></asp:Label></h4>
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Rotor Yakibame</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbRYQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbRYOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>

                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbRYModel" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbRYNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>

                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                                <div class="col-sm-6">
                                    <a class="btn btn-danger stat-btn col-sm-12" href="#">View NG</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Magnetize</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbMGQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbMGOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>

                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbMGModel" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbMGNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                                <div class="col-sm-6">
                                    <a class="btn btn-danger stat-btn col-sm-12" href="#">View NG</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Pipe Yakibame</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbPYQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbPYOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                
                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbPYModel" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbPYNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                                <div class="col-sm-6">
                                    <a class="btn btn-danger stat-btn col-sm-12" href="#">View NG</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Tack Welding</b></h3>
                            <ul class="clearfix">

                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbTWQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbTWOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                
                                <li class=""><span style="font-size: 20px;">NG: -</span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Magnet Center</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbMCQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbMCOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                
                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbMCModel" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbMCNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                                <div class="col-sm-6">
                                    <a class="btn btn-danger stat-btn col-sm-12" href="#">View NG</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Air Gap</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbAGQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbAGOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                
                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbAGModel" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbAGNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                                <div class="col-sm-6">
                                    <a class="btn btn-danger stat-btn col-sm-12" href="#">View NG</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Connecting Check</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbCCQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbCCOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                
                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbCCModel" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbCCNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                                <div class="col-sm-6">
                                    <a class="btn btn-danger stat-btn col-sm-12" href="#">View NG</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Top Bottom Welding No1</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbTBWQty1" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbTBWOK1" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                
                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbTBWModel1" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: -</span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Top Bottom Welding No2</b></h3>
                            <ul class="clearfix">
                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbTBWQty2" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>
                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbTBWOK2" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                
                                <li class="pull-right"><span style="font-size: 20px;">Model: 
                                    <asp:Label ID="lbTBWModel2" runat="server" Text="-" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">NG: -</span></li>
                            </ul>
                            <div class="row">
                                <div class="col-sm-6">
                                    <a class="btn btn-primary stat-btn col-sm-12" href="#">View All</a>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>



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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>    
</asp:Content>

