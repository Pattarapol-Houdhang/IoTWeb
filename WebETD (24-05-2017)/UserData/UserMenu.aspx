<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="UserMenu.aspx.cs" Inherits="UserData_UserMenu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">

                <h1>
                    <i class="icon-users"></i>
                    User Management
            <small>Manage User Data</small>
                </h1>
            </div>

            <div class="board-widget">
                <div class="row">
                    <h3>User Management</h3>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="<%=ResolveClientUrl("~/UserData/UserManagement.aspx") %>"><i class="icon-user-plus-2"></i>
                                <span class="board-widget-label">User Management</span>
                                <span class="board-widget-intro">Add,Edit or Delete Data </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-download"></i>
                                <span class="board-widget-label">Import User AD </span>
                                <span class="board-widget-intro">Import User from AD Server</span>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-key"></i>
                                <span class="board-widget-label">Change Password</span>
                                <span class="board-widget-intro">Change Password User</span>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <h3>Group Management</h3>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-users"></i>
                                <span class="board-widget-label">Group Master</span>
                                <span class="board-widget-intro">Manage Group Data  </span>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-user-plus-2"></i>
                                <span class="board-widget-label">User in Group</span>
                                <span class="board-widget-intro">Manage Group of User</span>
                            </a>
                        </div>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

