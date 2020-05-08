<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDQuantityDataLine.aspx.cs" Inherits="Production_Graph_Quantity_PDQuantityDataLine" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">

        <h1>
            <i class="icon-bars"></i>
            Select Production Line
            <small>Select Production Line you want to see.</small>
        </h1>

    </div>

    <div class="board-widget">
        <div class="row" style="margin-left: 5px;">
            <a href="PDQuantityGraphFactory.aspx"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</a>

        </div>
        <br />
        <div class="row">


            <%=GenBlock() %>
        </div>

    </div>
</asp:Content>

