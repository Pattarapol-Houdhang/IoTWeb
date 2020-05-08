<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDColumnIndex.aspx.cs" Inherits="Production_Setting_PDColumnIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="page-header">

                <h1>
                    <i class="icon-bars"></i>
                    Setting Index of Columns
            <small></small>
                </h1>

            </div>

            <div class="board-widget">
                <div class="row" style="margin-left: 5px;">
                    <asp:LinkButton ID="btBackPreviousPage" runat="server" OnClick="btBackPreviousPage_Click"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</asp:LinkButton>
                </div>
                <br />
                <div class="row">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="col-md-5 widget-module">
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
                                                    <div class="col-lg-10">
                                                        <asp:DropDownList ID="ddlFactory" runat="server" CssClass="form-control" AutoPostBack="true"
                                                             OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">PD Line</label>
                                                    <div class="col-lg-10">
                                                        <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control"></asp:DropDownList>
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
                    <div class="col-md-12 col-sm-12">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal">
                            <div class="widget-container" style="display: block;">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    CssClass="table table-bordered table-hover responsive" AutoGenerateColumns="False" 
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                    OnSorting="GridView1_Sorting" PageSize="10" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <nobr>
                                                <asp:ImageButton ID="ImageButton2" runat="server"
                                                    ImageUrl="~/images/Gridview/Files-Edit-File-icon.png" Width="14px"
                                                    CommandArgument='<%# Eval("mc_code") %>' CommandName="Editing"
                                                    Visible='<%# Eval("CanEdit") %>' />
                                               <%-- <asp:ImageButton ID="ImageButton1" runat="server"
                                                    ImageUrl="~/images/Gridview/Editing-Delete-icon 24.png" Width="14px"
                                                    CommandArgument='<%# Eval("mhi_id") %>' CommandName="Deleting"
                                                    Visible='<%# Eval("CanDel") %>' OnClientClick="return confirm('Are you sure?');" />--%>
                                                 </nobr>                                        
                                                
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Machine code" SortExpression="mc_code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbmccode" runat="server" Text='<%# Eval("mc_code") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Index Datetime" SortExpression="index_datetime">
                                            <ItemTemplate>
                                                <asp:Label ID="lbdate" runat="server" Text='<%# Eval("index_datetime") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Index Part Number" SortExpression="index_partnumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lbpart" runat="server" Text='<%# Eval("index_partnumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Index Model" SortExpression="index_modelcode">
                                            <ItemTemplate>
                                                <asp:Label ID="lbmodel" runat="server" Text='<%# Eval("index_modelcode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Index Value" SortExpression="index_value">
                                            <ItemTemplate>
                                                <asp:Label ID="lbValue" runat="server" Text='<%# Eval("index_value") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Index Result" SortExpression="index_result">
                                            <ItemTemplate>
                                                <asp:Label ID="lbResult" runat="server" Text='<%# Eval("index_result") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

