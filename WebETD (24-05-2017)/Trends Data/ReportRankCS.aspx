<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ReportRankCS.aspx.cs" Inherits="ReportRankCS" UICulture="en" Culture="en-US" %>

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
        <h4 class="content_od">FRONT/REAR OD</h4>
        <div id="myCarousel" class="carousel slide main-wrapper content_od" data-ride="carousel" data-interval="10000" >
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultODR() %>
                </div>
                <div class="item">
                    <%=resultODF() %>
                </div>
                <div class="item">
                    <%=resultODRRoundness() %>
                </div>
                <div class="item">
                    <%=resultODFRoundness() %>
                </div>
                <div class="item">
                    <%=resultODRCylindricity() %>
                </div>
                <div class="item">
                    <%=resultODFCylindricity() %>
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
        <h4 class="content_pin">PIN OD</h4>
        <asp:TextBox ID="txtData" runat="server" Visible="false" ></asp:TextBox>
        <div id="myCarouselPin" class="carousel slide main-wrapper content_pin" data-ride="carousel" data-interval="10000" >
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultPINOD() %>
                </div>
                <div class="item">
                    <%=resultPINRoundness() %>
                </div>
                <div class="item">
                    <%=resultPINCylindricity() %>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarouselPin" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left icon-prev" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarouselPin" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right icon-next" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <%=CheckPIN() %>
        </div>
        <h4 class="content_eccen">ECCENTRICITY</h4>
        <div id="myCarouselEcc" class="carousel slide main-wrapper content_eccen" data-ride="carousel" data-interval="10000" >
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <%=resultECC() %>
                </div>
            </div>
            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarouselEcc" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left icon-prev" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarouselEcc" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right icon-next" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
            <%=CheckECCEN() %>
        </div>
    </div>

</asp:Content>

