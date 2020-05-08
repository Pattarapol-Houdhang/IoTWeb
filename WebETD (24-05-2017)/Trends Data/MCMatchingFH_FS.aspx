<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MCMatchingFH_FS.aspx.cs" Inherits="Monitoring_MCMatchingFH_FS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MC Matching</title>
    <meta http-equiv="Refresh" content="60; URL=" />
    <style type="text/css">
        body {
            background-color: #FFF!important;
        }
        .carousel-inner {
            width: 95%!important;
            margin: 0 auto!important;
        }
        .csTopButton {
            padding:10px;
            border: 2px solid #1e8cbd;
            border-radius: 5px;
            font-weight: bold;
            color: #1e8cbd;
            text-decoration:none;
            font-size: 24px;
        }
        .csTopButton:hover {
            color: #fff;
            border: 2px solid #1e8cbd;
            background-color: #1e8cbd;
        }
        .selected {
            color: #fff;
            border: 2px solid #1e8cbd;
            background-color: #1e8cbd;
        }
    </style>
    <link href="~/css/bootstrap.css" rel="stylesheet" />
    <link href="~/css/font-alpona.css" rel="stylesheet" />
    <link href="~/css/prettify.css" rel="stylesheet" />
    <link href="~/css/responsive-tables.css" rel="stylesheet" />
    <link href="~/css/styles.css" rel="stylesheet" />
    <link href="~/css/bootstrap-reset.css" rel="stylesheet" />
    <link href="~/css/highcharts.css" rel="stylesheet" />


    <link href="~/css/kendo.common-material.min.css" rel="stylesheet" />
    <link href="~/css/kendo.material.min.css" rel="stylesheet" />
    <link href="~/css/kendo.material.mobile.min.css" rel="stylesheet" />

    <link href="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.buttons.css") %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.css") %>" rel="stylesheet" />
    <link href="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.nonblock.css") %>" rel="stylesheet" />

    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/MasterOffsetDetail.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/kendo.all.min.js") %>"></script>


    <%--<script type="text/javascript" src="<%= ResolveUrl("~/js/highcharts.js") %>"></script>--%>
    <script src="<%= ResolveUrl("~/Highcharts/highstock.js") %>"></script>
    <%--<script src="Highcharts/highcharts.js"></script>--%>
    <script src="<%= ResolveUrl("~/Highcharts/modules/exporting.js") %>"></script>
   <%-- <script src="<%= ResolveUrl("~/vendors/jquery-sparkline/dist/jquery.sparkline.min.js") %>"></script>--%>


    <script type="text/javascript" src="<%= ResolveUrl("~/js/datatables/jquery.dataTables.min.js") %>"></script>

    <script src="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.buttons.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/vendors/pnotify/dist/pnotify.nonblock.js") %>"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main-container">
        <center>
            <h1>MATCHING PART F/G ON MACHINE LINE</h1>
        <table>
            <tr>
                <td><a href="MCMatchingCR.aspx" class="csTopButton">CR</a></td>
                <td><a href="MCMatchingPS_PN.aspx" class="csTopButton">PS/ID - Pin/OD</a></td>
                <td><a href="MCMatchingFH_FS.aspx" class="csTopButton selected">FH/ID - FS/OD</a></td>
                <td><a href="MCMatchingRH_RS.aspx" class="csTopButton">RH/ID - RS/OD</a></td>
            </tr>
            <tr>
                <td colspan="4" style="font-size: 24px;" >
                    <center>Model:
                    <asp:RadioButton ID="rdModel15" runat="server"  Text="1YC15BXD" GroupName="Model" OnCheckedChanged="rdModel_CheckedChanged" AutoPostBack="true" />
                    <asp:RadioButton ID="rdModel20" runat="server" Text="1YC20HXD" GroupName="Model" OnCheckedChanged="rdModel_CheckedChanged" AutoPostBack="true" />
                    <asp:RadioButton ID="rdModel22" runat="server" Text="1YC22DXD" GroupName="Model" OnCheckedChanged="rdModel_CheckedChanged" AutoPostBack="true" />
                    </center>
                </td>
            </tr>
        </table>
        </center>
        <div id="myCarouselHEI" class="carousel slide main-wrapper content_hei" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <center><h1>Front Head ID</h1></center>
                    <%=resultFHID() %>
                </div>
               
            </div>
        </div>

        <div id="myCarouselHEI" class="carousel slide main-wrapper content_hei" data-ride="carousel" data-interval="10000">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <center><h1>Front Shaft OD</h1></center>
                    <%=resultODF() %>
                </div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
