<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PDLineOutChartAll.aspx.cs" Inherits="Quality_PDLineOutChartAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<META HTTP-EQUIV="Refresh" CONTENT="300;" >--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <script src="<%= ResolveClientUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-ui-1.10.4.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/Highcharts/highcharts.js") %>"></script>
    <script  src="<%= ResolveClientUrl("~/js/PDLineOutChartAll.js") %>" type="text/javascript"></script>
    <style type="text/css">
        .header {
            display:none;
        }
        .wrapper {
            margin-top: 0px;
        }
        .panel .panel-heading {
            text-align: center;
            text-transform: uppercase;
            font-weight: bold;
            color: #000;
        }
        .page-header {
            margin: 0px 0 5px;
        }
        .panel {
            margin-bottom: 5px;
        }
        .center {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 150px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 0.8;
        }
        .center img {
            height: 128px;
            width: 128px;
        }
        .lnkHeadMenu {
            display: inline-block;
            width: 80px;
            background-color: #ececec;
            text-align: center;
            border-radius: 10px;
            cursor: pointer;
            font-weight: bold;
            padding: 5px;
            margin: 5px;
            opacity: 0.2;
            border: 2px solid #dedede;
        }
        .active, .lnkHeadMenu:hover {
            opacity: 1;
            box-shadow: #808080 0px 0px 10px;
            border: 2px solid #9ba9ec;
        }
        .title {
            margin-top: 30px;
            text-align: left;
            font-weight: bold;
            border-bottom: none;
            font-size: 34px;
        }
    </style>

    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DynamicLayout="false" DisplayAfter="0">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadJavaScript);
            </script>
            <div class="row">
                <div class="col-lg-6">
                    <div class="lnkHeadMenu active" data-product="OVERALL">
                        <img src="../images/analytics.png" width="48"  /><br />
                        <span>OVERALL</span>
                    </div>
                    <div class="lnkHeadMenu" data-product="1YC">
                        <img src="../images/analytics.png" width="48"  /><br />
                        <span>1YC</span>
                    </div>
                    <div class="lnkHeadMenu" data-product="1YC/3">
                        <img src="../images/analytics.png" width="48"  /><br />
                        <span>1YC/FAC3</span>
                    </div>
                    <div class="lnkHeadMenu" data-product="2YC">
                        <img src="../images/analytics.png" width="48"  /><br />
                        <span>2YC</span>
                    </div>
                    <div class="lnkHeadMenu" data-product="SCROLL">
                        <img src="../images/analytics.png" width="48"  /><br />
                        <span>SCROLL</span>
                    </div>
                    <div class="lnkHeadMenu" data-product="ODM">
                        <img src="../images/analytics.png" width="48"  /><br />
                        <span>ODM</span>
                    </div>

                </div>
                <div class="col-lg-6">
                    <h3 class="page-header title" >PRODUCTION : <span id="lblTitle" style="color:#042fff;"></span></h3>
                </div>
            </div>


            <section class="wrapper">
                <div class="row" >
                    <div class="col-lg-12" id="boxOverAllChart" style="display:none;">
                        <section class="panel">
                            <header class="panel-heading">OVERALL</header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="HoldLineOutOverAll" style="height: 200px;"></div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>

                <div class="row" >
                    <div class="col-lg-12" id="boxSummaryChart" style="display:none;">
                        <section class="panel">
                            <header class="panel-heading">Summary Chart</header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="LineOutYear" style="height: 200px;"></div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>


                <div class="row">
                    <div class="col-lg-6">
                        <section class="panel">
                            <header class="panel-heading">LINEOUT & HOLD : Seperate by model <span class="lblMonth"></span></header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="LineOutAccu" style="height: 200px;"></div>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-lg-6">
                        <section class="panel">
                            <header class="panel-heading">LINEOUT & HOLD : Ratio by model <span class="lblMonth"></span></header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="LineOutRatio" style="height: 200px;"></div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                


                <div class="row">
                    <div class="col-lg-6">
                        <section class="panel">
                            <header class="panel-heading">LINEOUT : Seperate by process <span class="lblMonth"></span></header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="LineOutAccuProc" style="height: 200px;"></div>
                                </div>
                            </div>
                        </section>
                    </div>
                    <div class="col-lg-6">
                        <section class="panel">
                            <header class="panel-heading">LINEOUT : Ratio by process <span class="lblMonth"></span></header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="LineOutRatioProc" style="height: 200px;"></div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>




            </section>


            
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
</asp:Content>

