﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ReportRankFH.aspx.cs" Inherits="ReportRankFH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header">
        <h1>
            <i class="icon-stats"></i>
            <asp:Label ID="lblLine" runat="server" Text=""></asp:Label>
        </h1>
        <div class="form-group">
            <asp:Label ID="lblPartName" runat="server" Text="" Font-Bold="False" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="lblModelName" runat="server" Text="" Font-Bold="False" Font-Size="Larger"></asp:Label>
        </div>
    </div>
    <div class="main-container">
        <h4>ID</h4>
        <div id="myCarouselID" class="carousel slide main-wrapper" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultFHID() %>
                </div>
                <div class="item">
                    <%=resultFHIDRoundness() %>
                </div>
                <div class="item">
                    <%=resultFHIDCylindricity() %>
                </div>
                <div class="item">
                    <%=resultFHIDPerpen() %>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarouselID" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left icon-prev" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarouselID" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right icon-next" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
</asp:Content>

