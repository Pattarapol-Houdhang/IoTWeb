<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="CRDataPallet.aspx.cs" Inherits="DataHistory_CRDataPallet" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="page-header">

                <h1>
                    <i class="icon-bars"></i>
                    CR Data (Pallet Number)
            <small>Search CR Data by <b>Pallet</b> Number.
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
                                                    <label class="col-lg-2 control-label">Serial Number:</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtSerialNumber" runat="server" placeholder="ex: 90001234" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                    </div>
                                                    <%--<label class="col-lg-2 control-label">Model</label>
                                                    <div class="col-lg-4">
                                                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="1YC22DXD" Value="0121"></asp:ListItem>
                                                            <asp:ListItem Text="1YC15BXD" Value="0442"></asp:ListItem>
                                                            <asp:ListItem Text="1YC20HXD" Value="0444"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>--%>
                                                </div>


                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">&nbsp;</label>
                                                    <div class="col-lg-10">
                                                        <div class="form-actions">
                                                            <asp:Button ID="btSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btSearch_Click" />
                                                            <asp:Button CssClass="btn btn-success" ID="btExport" runat="server" Text="EXPORT EXCEL" OnClick="btExport_Click" />
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
                                    CssClass="table data-tbl-boxy"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                    OnSorting="GridView1_Sorting" PageSize="200">
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
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

