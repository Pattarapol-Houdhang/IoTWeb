<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDQuantityDataMachine.aspx.cs" Inherits="Production_Graph_Quantity_PDQuantityDataMachine" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">

        <h1>
            <i class="icon-bars"></i>
            Select Machine
            <small>Select Machine you want to see.</small>
        </h1>

    </div>

    <div class="board-widget">
        <div class="row" style="margin-left: 5px;">
            <asp:LinkButton ID="btBackPreviousPage" runat="server" OnClick="btBackPreviousPage_Click"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</asp:LinkButton>
        </div>
        <br />
        <div class="row">
            
            <%=GenBlock() %>
        </div>

    </div>
</asp:Content>

