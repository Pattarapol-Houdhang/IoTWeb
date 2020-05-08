<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDSettingMenu.aspx.cs" Inherits="Production_Setting_PDSettingMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">

                <h1>
                    <i class="icon-tools"></i>
                    Setting Master Data
            <small>Select menu you want to manage.</small>
                </h1>

            </div>

            <div class="board-widget">
                <div class="row">
                    <h3>Master Management</h3>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-factory"></i>
                                <span class="board-widget-label">1.Factory</span>
                                <span class="board-widget-intro">Manage Factory Data </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-tree"></i>
                                <span class="board-widget-label">2.Production Line </span>
                                <span class="board-widget-intro">Manage Production Line </span>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-cogs-2"></i>
                                <span class="board-widget-label">3.Machine</span>
                                <span class="board-widget-intro">Manage Machine Data </span>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-sign-blank"></i>
                                <span class="board-widget-label">4.Model</span>
                                <span class="board-widget-intro">Manage Model Data </span>
                            </a>
                        </div>
                    </div>

                </div>
                <div class="row">
                    <h3>Collect Data Management</h3>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-list-ol"></i>
                                <span class="board-widget-label">Row Collect Data</span>
                                <span class="board-widget-intro">Manage Row for collect data  </span>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-columns"></i>
                                <span class="board-widget-label">Header Column</span>
                                <span class="board-widget-intro">Manage Header Column Data </span>
                            </a>
                        </div>
                    </div>


                </div>
                <div class="row">
                    <h3>Graph & Data Management</h3>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="PDColumnIndex.aspx"><i class="icon-list-4"></i>
                                <span class="board-widget-label">Column Index</span>
                                <span class="board-widget-intro">Column Index Managment </span>
                            </a>
                        </div>
                    </div>                   

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

