<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="MonitoringLine.aspx.cs" Inherits="Monitoring_MonitoringLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header">

        <h1>
            <i class="icon-bars"></i>
            Select Monitoring Line
            <small>Select Line you want to see.</small>
        </h1>

    </div>

    <div class="board-widget">
       
        <div class="row">


            <%=GenBlock() %>
        </div>

    </div>
</asp:Content>

