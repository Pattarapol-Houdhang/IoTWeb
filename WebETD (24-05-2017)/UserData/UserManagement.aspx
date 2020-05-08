<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="UserManagement.aspx.cs" Inherits="UserData_UserManagement" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <div class="page-header">

                <h1>
                    <i class="icon-users"></i>
                    User Management
            <small>Add, Edit or Delete User in System.</small>
                </h1>

            </div>

            <div class="row">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btSearch">
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
                                                <label class="col-lg-2 control-label">Search</label>
                                                <div class="col-lg-10">
                                                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Enter text"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-lg-2 control-label">&nbsp;</label>
                                                <div class="col-lg-10">
                                                    <div class="form-actions">
                                                        <asp:Button ID="btSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btSearch_Click" />
                                                        <asp:Button ID="btImport" runat="server" Text="Import from AD Server" CssClass="btn btn-info" OnClick="btImport_Click" />
                                                        <asp:Button ID="btAddNew" runat="server" Text="Create New" CssClass="btn btn-success" OnClick="btAddNew_Click" />
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
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CssClass="table table-bordered table-hover responsive"
                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                    OnSorting="GridView1_Sorting" PageSize="20">
                    <HeaderStyle CssClass="thead" ForeColor="Black" />
                    <RowStyle CssClass="tbody" />
                    <Columns>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>

                                        <nobr>
                                        <asp:ImageButton ID="ImageButton2" runat="server"
                                            ImageUrl="~/images/Gridview/Files-Edit-File-icon.png" Width="14px"
                                            CommandArgument='<%# Eval("username") %>' CommandName="Editing"
                                            Visible='<%# Eval("CanEdit") %>' />
                                        <asp:ImageButton ID="ImageButton1" runat="server"
                                            ImageUrl="~/images/Gridview/Editing-Delete-icon 24.png" Width="14px"
                                            CommandArgument='<%# Eval("username") %>' CommandName="Deleting"
                                            Visible='<%# Eval("CanDel") %>' OnClientClick="return confirm('Are you sure?');" />
                                        </nobr>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="ImageButton1" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="username" SortExpression="username">
                            <ItemTemplate>
                                <asp:Label ID="lbusername" runat="server" Text='<%# Eval("username") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Emp. Code" SortExpression="empCode">
                            <ItemTemplate>
                                <asp:Label ID="lbempcode" runat="server" Text='<%# Eval("empCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="First Name" SortExpression="firstname">
                            <ItemTemplate>
                                <asp:Label ID="lbfirst" runat="server" Text='<%# Eval("firstname") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name" SortExpression="lastname">
                            <ItemTemplate>
                                <asp:Label ID="lblast" runat="server" Text='<%# Eval("lastname") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Department" SortExpression="Department">
                            <ItemTemplate>
                                <asp:Label ID="lbdepart" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active" SortExpression="active">
                            <ItemTemplate>
                                <asp:Label ID="lbActive" runat="server" Text='<%# Eval("active") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="60" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="create by" SortExpression="createby">
                            <ItemTemplate>
                                <asp:Label ID="lbCreateBy" runat="server" Text='<%# Eval("createby") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="create Date" SortExpression="createdate">
                            <ItemTemplate>
                                <asp:Label ID="lbCreatedate" runat="server" Text='<%# Eval("createdate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="update by" SortExpression="updateby">
                            <ItemTemplate>
                                <asp:Label ID="lbupdateby" runat="server" Text='<%# Eval("updateby") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="update Date" SortExpression="updatedate">
                            <ItemTemplate>
                                <asp:Label ID="lbupdatedate" runat="server" Text='<%# Eval("updatedate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                        </asp:TemplateField>

                    </Columns>

                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

