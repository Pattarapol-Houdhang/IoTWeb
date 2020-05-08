<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ReportRankCY.aspx.cs" Inherits="ReportRankCY" %>

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
        <h4>ID BORE</h4>
        <div id="myCarousel" class="carousel slide main-wrapper" data-ride="carousel" data-interval="10000">
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultCYBO() %>
                </div>
                <div class="item">
                    <%=resultCYBORoundness() %>
                </div>
                <div class="item">
                    <%=resultCYBOCylindricity() %>
                </div>
                <div class="item">
                    <%=resultCYBOPerpen() %>
                </div>
                <div class="item">
                    <%=resultCYBOConcentric() %>
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <h4>HEIGHT</h4>
        <div id="myCarouselHEI" class="carousel slide main-wrapper" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultCYHeight() %>
                </div>
                <div class="item">
                    <%=resultCYHEIPallism() %>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarouselHEI" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarouselHEI" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <h4>ID BUSH</h4>
        <div id="myCarouselID" class="carousel slide main-wrapper" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultCYBU() %>
                </div>
                <div class="item">
                    <%=resultCYBURoundness() %>
                </div>
                <div class="item">
                    <%=resultCYBUPerpen() %>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarouselID" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarouselID" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
</asp:Content>

