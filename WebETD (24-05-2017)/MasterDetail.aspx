<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageOffsetDetail.master" AutoEventWireup="true" CodeFile="MasterDetail.aspx.cs" Inherits="MasterDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="widget-container">--%>
        <h3 class="pull-left">
            <i class="icon-arrow-up"></i>
            PLEASE SELECT PART
        </h3>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        </asp:UpdatePanel>
    <%--</div>--%>
</asp:Content>
