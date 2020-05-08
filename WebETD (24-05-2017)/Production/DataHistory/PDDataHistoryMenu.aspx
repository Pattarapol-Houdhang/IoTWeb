<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDDataHistoryMenu.aspx.cs" Inherits="Production_Setting_PDDataHistoryMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">

                <h1>
                    <i class="icon-tools"></i>
                    Graph Report
            <small>Select graph you want to see.</small>
                </h1>

            </div>

            <div class="board-widget">
                
                <div class="row">
                    <div class="col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Production/DataHistory/Quantity/PDQuantityDataFactory.aspx") %>"><i class="icon-table"></i>
                                <span class="board-widget-label">Production Quantity</span>
                                <span class="board-widget-intro">Production Quantity Data </span>
                            </a>
                        </div>
                    </div>
                           

                </div>
               
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

