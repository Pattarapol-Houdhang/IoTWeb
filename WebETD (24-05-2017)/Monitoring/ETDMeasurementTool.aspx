<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ETDMeasurementTool.aspx.cs" Inherits="Monitoring_ETDMeasurementTool_html" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <h1>
                    <i class="icon-clipboard-2"></i>
                    DAILY REPORT : <asp:Label ID="lblLine" runat="server" Text=""></asp:Label>
                    <small><asp:Label ID="Label2" runat="server" Text=""></asp:Label></small>
                </h1>
            </div>
            <%--<div class="row">
                <div class="col-md-12 widget-module">
                    <div class="box-widget">
                        <div class="col-md-3 form-group">
                            <asp:Label CssClass="col-lg-6 control-label" ID="Label1" runat="server" Text="DATE : "></asp:Label>
                            <div class="col-lg-10">
                                <asp:TextBox CssClass="form-control datepicker" ID="txtDate" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3 form-group">
                            <asp:Label CssClass="col-lg-6 control-label" ID="lblShift" runat="server" Text="SHIFT : "></asp:Label>
                            <div class="col-lg-10">
                                <asp:DropDownList CssClass="form-control" ID="dropDownShift" runat="server">
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
            </div>--%>

            <div class="row">
                <div class="col-md-12 widget-module">
                    <div class="box-widget">
                        <div class="col-sm-2 col-md-2">
                            <%--<h4>Start Date</h4>--%>
                            <asp:Label CssClass="col-lg-6 control-label" ID="Label1" runat="server" Text="START DATE : "></asp:Label>
                            <asp:TextBox ID="start" runat="server" class="datetimepickerStart" style="width: 100%;"></asp:TextBox>
                            <%--<input id="start" class="datetimepickerStart" runat="server" style="width: 100%;" />--%>
                        </div>
                        <div class="col-sm-2 col-md-2">
                            <%--<h4>End Date</h4>--%>
                            <asp:Label CssClass="col-lg-6 control-label" ID="Label3" runat="server" Text="END DATE : "></asp:Label>
                            <asp:TextBox ID="end" runat="server" class="datetimepickerEnd" style="width: 100%;"></asp:TextBox>
                            <%--<input id="end" class="datetimepickerEnd" runat="server" style="width: 100%;" />--%>
                        </div>
                        <div class="col-sm-2 col-md-2">
                            <%--<h4>Search</h4>
                            <asp:LinkButton CssClass="btn btn-info" ID="btnSearch" runat="server" Width="100%" Height="30px" BorderStyle="Double" OnClick="btnSearch_Click">
                            <i class="icon-search"></i>
                            </asp:LinkButton>--%>
                            <asp:Label CssClass="col-lg-6 control-label" ID="Label4" runat="server" Text="SEARCH : " Visible="True" ForeColor="White"></asp:Label>
                            <div class="col-lg-10">
                                <asp:Button CssClass="btn btn-info" ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>   
            </div>
            <br />

            <div class="row">
                <div class="col-sm-6 col-md-3">
                    <div class="graph-widget-wrap">
                        <div class="graph-widget-container">
                            <h3><b>Crank Shaft</b></h3>
                            <ul class="clearfix">

                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbCSQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbCSOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                                                
                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbCSNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>
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
                            <h3><b>Piston</b></h3>
                            <ul class="clearfix">

                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbPTQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbPTOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                                                
                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbPTNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>
                                                              
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
                            <h3><b>Cylinder</b></h3>
                            <ul class="clearfix">

                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbCYQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbCYOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                                                
                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbCYNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>                               
                            
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
                            <h3><b>Front Head</b></h3>
                            <ul class="clearfix">

                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbFHQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbFHOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                                                
                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbFHNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>                               
                            
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
                            <h3><b>Rear Head</b></h3>
                            <ul class="clearfix">

                                <li class=""><span style="font-size: 20px;">QTY: 
                                    <asp:Label ID="lbRHQty" runat="server" Text="0" ForeColor="DarkGoldenrod" Font-Bold="true"></asp:Label></span></li>

                                <li class=""><span style="font-size: 20px;">OK: 
                                    <asp:Label ID="lbRHOK" runat="server" Text="0" ForeColor="Green" Font-Bold="true"></asp:Label></span></li>
                                                                
                                <li class=""><span style="font-size: 20px;">NG: 
                                    <asp:Label ID="lbRHNG" runat="server" Text="0" ForeColor="Red" Font-Bold="true"></asp:Label></span></li>   
                            
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

            <%--<script type="text/javascript">
                $(document).ready(function () {
                    var today = new Date()
                    // create DatePicker from input HTML element
                    $(".datepicker").kendoDatePicker({
                        value: today,
                        format: "yyyy-MM-dd"
                    });
                });
            </script>--%>

            <script type="text/javascript">

                $(document).ready(function () {
                    $('.data-tbl-boxy').dataTable({
                        fixedColumns: {
                            leftColumns: 2
                        },
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>    



</asp:Content>

