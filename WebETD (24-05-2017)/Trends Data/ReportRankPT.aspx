<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ReportRankPT.aspx.cs" Inherits="ReportRankPT" %>

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
        <h4 class="content_od">OD</h4>
        <div id="myCarousel" class="carousel slide main-wrapper content_od" data-ride="carousel" data-interval="10000">
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultPTOD() %>
                </div>
                <div class="item">
                    <%=resultPTODRoundness() %>
                </div>
                <div class="item">
                    <%=resultPTODCylindricity() %>
                </div>
                <div class="item">
                    <%=resultPTODPerpen() %>
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left icon-prev" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right icon-next" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <%=CheckOD() %>
        </div>
        <h4 class="content_id">ID</h4>
        <div id="myCarouselID" class="carousel slide main-wrapper content_id" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultPTID() %>
                </div>
                <div class="item">
                    <%=resultPTIDRoundness() %>
                </div>
                <div class="item">
                    <%=resultPTIDCylindricity() %>
                </div>
                <div class="item">
                    <%=resultPTIDPerpen() %>
                </div>
                <div class="item">
                    <%=resultPTIDConcentric() %>
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
            <%=CheckID() %>
        </div>
        <h4 class="content_hei">HEIGHT</h4>
        <div id="myCarouselHEI" class="carousel slide main-wrapper content_hei" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultPTHeight() %>
                </div>
                <div class="item">
                    <%=resultPTHEIPallism() %>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarouselHEI" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left icon-prev" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarouselHEI" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right icon-next" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <%=CheckHeight() %>
        </div>
        <h4 class="content_blade">BLADE</h4>
        <div id="myCarouselBL" class="carousel slide main-wrapper content_blade" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultPTBlade() %>
                </div>
                <div class="item">
                    <%=resultPTBLPallism() %>
                </div>
                <div class="item">
                    <%=resultPTBLPerpen() %>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarouselBL" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left icon-prev" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarouselBL" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right icon-next" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <%=CheckBlade() %>
        </div>
    </div>
</asp:Content>

