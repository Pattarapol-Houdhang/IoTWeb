<%@ Page Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="DCIManPower.aspx.cs" Inherits="DCIManPower" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<META HTTP-EQUIV="Refresh" CONTENT="300;" >--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%= ResolveUrl("~/Styl/js/bootstrap-colorpicker.js") %>"></script>

    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/dataTables.buttons.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.flash.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jszip.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/pdfmake.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/vfs_fonts.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.html5.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.print.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/Highcharts/highcharts.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/Highcharts/highstock.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/Highcharts/highcharts-more.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/StyleMax/js/owl.carousel.js") %>"></script>


    <link href="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/css/owl.carousel.css") %>" rel="stylesheet" />


    <script type="text/javascript" src="<%= ResolveClientUrl("../js/ManPower.js") %>"></script>

    <script type="text/javascript">



        function SetTabClick() {
            //-------------- Set class active on div tab for working after updatepanel -----------------


            var checkActive = $('#<%= hdClassActive.ClientID %>').val();
            if (checkActive == "activetfac1") {
                $('#tfac1').addClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').removeClass("active");

                $('#tfac1').click();
            } else if (checkActive == "activetfac2") {
                $('#tfac1').removeClass("active");
                $('#tfac2').addClass("active");
                $('#tfac3').removeClass("active");

                $('#tfac2').click();
            }
            else if (checkActive == "activetfac3") {
                $('#tfac1').removeClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').addClass("active");

                $('#tfac3').click();
            }
            else if (checkActive == "activetfacodm") {
                $('#tfac1').removeClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').removeClass("active");
                $('#todm').addClass("active");

                $('#todm').click();
            }
            else if (checkActive == "activetfacqc") {
                $('#tfac1').removeClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').removeClass("active");
                $('#todm').removeClass("active");
                $('#tqc').addClass("active");

                $('#tqc').click();
            }
            else if (checkActive == "activeinmain") {
                $('#tfac1').removeClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').removeClass("active");
                $('#todm').removeClass("active");
                $('#tinmain').addClass("active");
                $('#tinmain').click();
            }
            else if (checkActive == "activettablework") {
                $('#tfac1').removeClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').removeClass("active");
                $('#ttablework').addClass("active");

                $('#ttablework').click();

                //-------------- Set class active on div tab for working after updatepanel -----------------

                //---------------- Set Hidden value on tab click ------------------
                <%--  $('#taboverall').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetoverall');
            });--%>

                $('#tabfac1').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activettfac1');
                });

                $('#tabfac2').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activetfac2');
                });
                $('#tabfac3').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activetfac3');
                });
                $('#tabodm').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activetodm');
                });
                $('#tabqc').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activetqc');
                });
                $('#tabecut').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activetecut');
                });
                $('#tabinmain').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activeinmain');
                });
                }

}
$('.carousel').carousel({
    interval: false
});
//carousel
$(document).ready(function () {
    $("#owl-slider").owlCarousel({
        navigation: true,
        slideSpeed: 800,
        paginationSpeed: 1000,
        singleItem: true

    });
});
    </script>

    <!---------------------- Script for set Tab Click --------------------->
    <style type="text/css">
        #carousel-inner {
            height: 100vh !important;
        }

        .imgicon {
            margin-top: 10px;
        }




        .modal {
            position: fixed !important;
            z-index: 999 !important;
            height: 100% !important;
            width: 100% !important;
            top: 0 !important;
            background-color: Black !important;
            filter: alpha(opacity=60) !important;
            opacity: 0.8 !important;
            display: block !important;
            -moz-opacity: 0.8;
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

        .btn-refresh {
            color: #fff;
            background-color: #38984d;
            border-color: #22692e;
        }

            .btn-refresh:hover {
                color: #fff;
                background-color: #41e665;
            }
    </style>

    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DynamicLayout="false" DisplayAfter="0">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="~/StyleMax/icon/Gear-0.5s-200px.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" language="javascript">
                //Sys.Application.add_load(LoadData);
                Sys.Application.add_load(LoadJavaScript);
                Sys.Application.add_load(SetTabClick);

            </script>



            <asp:HiddenField ID="hdClassActive" runat="server" />
            <!------------ Tab Program ------------------->
            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-exclamation-circle"></i>MAN POWER</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#toverall" data-toggle="tab" id="taboverall">AllDCI</a></li>
                                <li><a href="#tDirect" data-toggle="tab" id="tabdirect">DIRECT</a></li>
                                <li><a href="#tIndirect" data-toggle="tab" id="tabIndirect">INDIRECT</a></li>
                                <li><a href="#tsupport" data-toggle="tab" id="tabsupport">S.G.A.</a></li>
                                <li><a href="#ttablework" data-toggle="tab" id="tabtbwork">Work-Hour data</a></li>
                            </ul>
                            <div class="tab-content">

                                <div class="active tab-pane " id="toverall">

                                    <div class="btnShowHideAll" data-graphall="#boxHoldGraphAll">(-)Graph All</div>
                                    <div id="boxHoldGraphAll" class="carousel slide" data-ride="carousel" style="height: 100%">

                                        <div class="item active">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div id="gpMPALL" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpOTALL" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>

                                            </div>
                                        </div>

                                    </div>

                                    <%--                                            <!-- Left and right controls -->
                                            <a class="left carousel-control" href="#myCarouselMain" data-slide="prev" style="width: 5% !important">
                                                <span class="glyphicon glyphicon-chevron-left"></span>
                                                <span class="sr-only">Previous</span>
                                            </a>
                                            <a class="right carousel-control" href="#myCarouselMain" data-slide="next" style="width: 5% !important">
                                                <span class="glyphicon glyphicon-chevron-right"></span>
                                                <span class="sr-only">Next</span>
                                            </a>
                                        </div>--%>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div id="gpHoldFAC1"></div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div id="gpManFAC1M"></div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div id="gpManFAC1A"></div>
                                        </div>
                                    </div>
                                </div>

                                <%--      <div class="tab-pane" id="tmt">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHideAll" data-graphall="#boxMaintenance">(-)Maintenance</div>
                                            <div id="boxMaintenance" class="carousel slide" data-ride="carousel" style="height: 100%">

                                                <div id="gpMPMTALL" style="min-width: 1349px; height: 400px; margin: 0 auto"></div>
                                                <div class="col-sm-6">
                                                    <div id="gpMPMTM"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpMPMTA"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>

                                <div class="tab-pane " id="tDirect">
                                    <div class="btnShowHideDirectAll" data-graphdirectall="#boxHoldGraphDirectAll">(-)Graph Direct All</div>
                                    <div id="boxHoldGraphDirectAll" class="carousel slide" data-ride="carousel" style="height: 100%">

                                        <div class="item active">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div id="gpDIRECTALL" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpOTDIRECTALL" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="nav-tabs-custom">
                                                <ul class="nav nav-tabs">
                                                    <%--     <li><a href="#toverall" data-toggle="tab" id="taboverall">OverAll</a></li>--%>
                                                    <li class="active"><a href="#tfac1" data-toggle="tab" id="tabfac1">Factory 1</a></li>
                                                    <li><a href="#tfac2" data-toggle="tab" id="tabfac2">Factory 2</a></li>
                                                    <li><a href="#tfac3" data-toggle="tab" id="tabfac3">Factory 3</a></li>
                                                    <li><a href="#todm" data-toggle="tab" id="tabodm">ODM</a></li>
                                                    <li><a href="#tps" data-toggle="tab" id="tabps">Part Supply</a></li>
                                                    <li><a href="#tqa" data-toggle="tab" id="tabqc">QA</a></li>


                                                    <%--       <li class="active"><a href="#tfactory" data-toggle="tab" id="tabfactory">By Factory</a></li>--%>
                                                    <li><%--<a href="#tmodel" data-toggle="tab" id="tabmodel">By Model</a>--%></li>
                                                    <%--   <li><a href="#tmanpower" data-toggle="tab" id="tabmanpower">ManPower</a></li>--%>
                                                </ul>
                                                <div class="tab-content">
                                                    <div class="active tab-pane " id="tfac1">
                                                        <div id="myCarousel" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <!-- Indicators -->
                                                            <ol class="carousel-indicators">
                                                                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                                                                <li data-target="#myCarousel" data-slide-to="1"></li>
                                                                <li data-target="#myCarousel" data-slide-to="2"></li>
                                                                <li data-target="#myCarousel" data-slide-to="3"></li>
                                                            </ol>
                                                            <div class="btnShowHideFac1" data-graphfac1="#boxHoldGraphFac1">(-)Factory 1</div>
                                                            <div id="boxHoldGraphFac1" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                                <div class="carousel-inner" style="height: 100% !important">
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC1Prev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC1Prev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC1Prev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC1Prev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC1Prev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC1Prev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item active">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC1" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC1" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <!-- Left and right controls -->
                                                                <a class="left carousel-control" href="#myCarousel" data-slide="prev" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                                                    <span class="sr-only">Previous</span>
                                                                </a>
                                                                <a class="right carousel-control" href="#myCarousel" data-slide="next" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                                                    <span class="sr-only">Next</span>
                                                                </a>

                                                            </div>
                                                        </div>

                                                    </div>
                                                    <div class="tab-pane " id="tfac2">
                                                        <div id="myCarousel2" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <!-- Indicators -->
                                                            <ol class="carousel-indicators">
                                                                <li data-target="#myCarousel2" data-slide-to="0" class="active"></li>
                                                                <li data-target="#myCarousel2" data-slide-to="1"></li>
                                                                <li data-target="#myCarousel2" data-slide-to="2"></li>
                                                                <li data-target="#myCarousel2" data-slide-to="3"></li>
                                                            </ol>
                                                            <div class="btnShowHideFac2" data-graphfac2="#boxHoldGraphFac2">(-)Factory 2</div>
                                                            <div id="boxHoldGraphFac2" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                                <div class="carousel-inner" style="height: 100% !important">
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC2Prev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC2Prev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC2Prev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC2Prev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC2Prev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC2Prev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item active ">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <!-- Left and right controls -->
                                                                <a class="left carousel-control" href="#myCarousel2" data-slide="prev" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                                                    <span class="sr-only">Previous</span>
                                                                </a>
                                                                <a class="right carousel-control" href="#myCarousel2" data-slide="next" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                                                    <span class="sr-only">Next</span>
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <%-- <div class="row">
                                                            <div class="col-sm-12">
                                                                <div id="gpHoldFAC2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div id="gpManFAC2M"></div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div id="gpManFAC2A"></div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div id="gpManFACSCRM"></div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div id="gpManFACSCRA"></div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div id="gpManFAC2MOM"></div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div id="gpManFAC2MOA"></div>
                                                            </div>

                                                        </div>--%>
                                                    </div>
                                                    <div class="tab-pane " id="tfac3">
                                                        <div id="myCarousel3" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <!-- Indicators -->
                                                            <ol class="carousel-indicators">
                                                                <li data-target="#myCarousel3" data-slide-to="0" class="active"></li>
                                                                <li data-target="#myCarousel3" data-slide-to="1"></li>
                                                                <li data-target="#myCarousel3" data-slide-to="2"></li>
                                                                <li data-target="#myCarousel3" data-slide-to="3"></li>
                                                            </ol>
                                                            <div class="btnShowHideFac3" data-graphfac3="#boxHoldGraphFac3">(-)Factory 3</div>
                                                            <div id="boxHoldGraphFac3" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                                <div class="carousel-inner" style="height: 100% !important">

                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC3Prev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC3Prev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC3Prev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC3Prev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC3Prev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC3Prev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item active ">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPFAC3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTFAC3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <!-- Left and right controls -->
                                                                <a class="left carousel-control" href="#myCarousel3" data-slide="prev" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                                                    <span class="sr-only">Previous</span>
                                                                </a>
                                                                <a class="right carousel-control" href="#myCarousel3" data-slide="next" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                                                    <span class="sr-only">Next</span>
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <%--  <div class="row">
                                                            <div class="col-sm-12">
                                                                <div id="gpHoldFAC3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                            </div>

                                                            <div class="col-sm-6">
                                                                <div id="gpManFAC3M"></div>
                                                            </div>
                                                            <div class="col-sm-6">
                                                                <div id="gpManFAC3A"></div>
                                                            </div>
                                                        </div>--%>
                                                    </div>
                                                    <div class="tab-pane " id="todm">
                                                        <div id="myCarouselODM" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <!-- Indicators -->
                                                            <ol class="carousel-indicators">
                                                                <li data-target="#myCarouselODM" data-slide-to="0" class="active"></li>
                                                                <li data-target="#myCarouselODM" data-slide-to="1"></li>
                                                                <li data-target="#myCarouselODM" data-slide-to="2"></li>
                                                                <li data-target="#myCarouselODM" data-slide-to="3"></li>
                                                            </ol>
                                                            <div class="btnShowHideODM" data-graphodm="#boxHoldGraphODM">(-)Factory ODM</div>
                                                            <div id="boxHoldGraphODM" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                                <div class="carousel-inner" style="height: 100% !important">
                                                                    <div class="item active ">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPODM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTODM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPODMPrev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTODMPrev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPODMPrev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTODMPrev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPODMPrev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTODMPrev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <!-- Left and right controls -->
                                                                <a class="left carousel-control" href="#myCarouselODM" data-slide="prev" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                                                    <span class="sr-only">Previous</span>
                                                                </a>
                                                                <a class="right carousel-control" href="#myCarouselODM" data-slide="next" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                                                    <span class="sr-only">Next</span>
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <%--<div class="row">
                                                            <div class="col-sm-12">
                                                                <div id="gpHoldODM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                            </div>
                                                        </div>--%>
                                                    </div>
                                                    <div class="tab-pane " id="tps">
                                                        <div id="myCarouselps" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <!-- Indicators -->
                                                            <ol class="carousel-indicators">
                                                                <li data-target="#myCarouselps" data-slide-to="0" class="active"></li>
                                                                <li data-target="#myCarouselps" data-slide-to="1"></li>
                                                                <li data-target="#myCarouselps" data-slide-to="2"></li>
                                                                <li data-target="#myCarouselps" data-slide-to="3"></li>
                                                            </ol>
                                                            <div class="btnShowHidePS" data-graphps="#boxHoldGraphPS">(-)PART SUPPLY</div>
                                                            <div id="boxHoldGraphPS" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                                <div class="carousel-inner" style="height: 100% !important">
                                                                    <div class="item active ">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPPS" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPPS" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPPSPrev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPPSPrev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPPSPrev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPPSPrev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPPSPrev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPPSPrev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <!-- Left and right controls -->
                                                                <a class="left carousel-control" href="#myCarouselps" data-slide="prev" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                                                    <span class="sr-only">Previous</span>
                                                                </a>
                                                                <a class="right carousel-control" href="#myCarouselps" data-slide="next" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                                                    <span class="sr-only">Next</span>
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <%--   <div class="row">
                                        <div class="col-sm-12">
                                            <div id="gpHoldODM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                        </div>

                                    </div>--%>
                                                    </div>
                                                    <div class="tab-pane " id="tqa">
                                                        <div id="myCarouselqa" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <!-- Indicators -->
                                                            <ol class="carousel-indicators">
                                                                <li data-target="#myCarouselqa" data-slide-to="0" class="active"></li>
                                                                <li data-target="#myCarouselqa" data-slide-to="1"></li>
                                                                <li data-target="#myCarouselqa" data-slide-to="2"></li>
                                                                <li data-target="#myCarouselqa" data-slide-to="3"></li>
                                                            </ol>
                                                            <div class="btnShowHideQA" data-graphps="#boxHoldGraphQA">(-)QA</div>
                                                            <div id="boxHoldGraphQA" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                                <div class="carousel-inner" style="height: 100% !important">
                                                                    <div class="item active ">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPQA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPQA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPQAPrev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPQAPrev3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPQAPrev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPQAPrev2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                    <div class="item">
                                                                        <div class="row">
                                                                            <div class="col-sm-12">
                                                                                <div id="gpMPQAPrev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>
                                                                            <div class="col-sm-12">
                                                                                <div id="gpOTMPQAPrev" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                            </div>

                                                                        </div>
                                                                    </div>

                                                                </div>

                                                                <!-- Left and right controls -->
                                                                <a class="left carousel-control" href="#myCarouselqa" data-slide="prev" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                                                    <span class="sr-only">Previous</span>
                                                                </a>
                                                                <a class="right carousel-control" href="#myCarouselqa" data-slide="next" style="width: 5% !important">
                                                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                                                    <span class="sr-only">Next</span>
                                                                </a>
                                                            </div>
                                                        </div>
                                                        <%--   <div class="row">
                                        <div class="col-sm-12">
                                            <div id="gpHoldODM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                        </div>

                                    </div>--%>
                                                    </div>



                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane " id="tIndirect">
                                    <div class="btnShowHideInDirectAll" data-graphindirectall="#boxHoldGraphInDirectAll">(-)Graph Direct All</div>
                                    <div id="boxHoldGraphInDirectAll" class="carousel slide" data-ride="carousel" style="height: 100%">

                                        <div class="item active">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div id="gpINDIRECTALL" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpOTINDIRECTALL" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="nav-tabs-custom">
                                                <ul class="nav nav-tabs">
                                                    <%--     <li><a href="#toverall" data-toggle="tab" id="taboverall">OverAll</a></li>--%>
                                                    <li class="active"><a href="#tinfac1" data-toggle="tab" id="tabinfac1">Factory 1</a></li>
                                                    <li><a href="#tinfac2" data-toggle="tab" id="tabinfac2">Factory 2</a></li>
                                                    <li><a href="#tinfac3" data-toggle="tab" id="tabinfac3">Factory 3</a></li>
                                                    <li><a href="#tinodm" data-toggle="tab" id="tabinodm">ODM</a></li>
                                                    <li><a href="#tinprocurement" data-toggle="tab" id="tabinprocurement">Procurement</a></li>
                                                    <li><a href="#tinpdscm" data-toggle="tab" id="tabinpdscm">Production Control&SCM</a></li>
                                                    <li><a href="#tinengineer" data-toggle="tab" id="tabengineer">Engineer</a></li>
                                                    <li><a href="#tinmaintenance" data-toggle="tab" id="tabmaintenance">Maintenance</a></li>
                                                    <li><a href="#tinecut" data-toggle="tab" id="tabinecut">IT&EC</a></li>
                                                    <li><a href="#tinqc" data-toggle="tab" id="tabinqc">QC</a></li>
                                                    <li><a href="#tindesign" data-toggle="tab" id="tabindesign">Design&Development</a></li>



                                                    <%--       <li class="active"><a href="#tfactory" data-toggle="tab" id="tabfactory">By Factory</a></li>--%>
                                                    <li><%--<a href="#tmodel" data-toggle="tab" id="tabmodel">By Model</a>--%></li>
                                                    <%--   <li><a href="#tmanpower" data-toggle="tab" id="tabmanpower">ManPower</a></li>--%>
                                                </ul>
                                                <div class="tab-content">
                                                    <div class="active tab-pane " id="tinfac1">
                                                        <div class="btnShowHideInFac1" data-graphinfac1="#boxHoldGraphInFac1">(-)Factory 1</div>
                                                        <div id="boxHoldGraphInFac1" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINFAC1" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpOTINFAC1" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinfac2">
                                                        <div class="btnShowHideInFac2" data-graphinfac2="#boxHoldGraphInFac2">(-)Factory 2</div>
                                                        <div id="boxHoldGraphInFac2" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINFAC2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpOTINFAC2" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinfac3">
                                                        <div class="btnShowHideInFac3" data-graphinfac3="#boxHoldGraphInFac3">(-)Factory 3</div>
                                                        <div id="boxHoldGraphInFac3" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINFAC3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpOTINFAC3" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinodm">
                                                        <div class="btnShowHideInODM" data-graphinodm="#boxHoldGraphInODM">(-)Factory ODM</div>
                                                        <div id="boxHoldGraphInODM" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINODM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpOTINODM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinprocurement">
                                                        <div class="btnShowHideInProcurement" data-tinprocurement="#boxHoldGraphInProcurement">(-)Procurment</div>
                                                        <div id="boxHoldGraphInProcurement" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINMAN" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINPU" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINSPU" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinpdscm">
                                                        <div class="btnShowHideInPDSCM" data-tinpdscm="#boxHoldGraphInPDSCM">(-)Procurment</div>
                                                        <div id="boxHoldGraphInPDSCM" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINIM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINPS" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINDC" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINPN" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINIE" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinengineer">
                                                        <div class="btnShowHideInENGIEER" data-tinengineer="#boxHoldGraphInENGINEER">(-)ENGINEER</div>
                                                        <div id="boxHoldGraphInENGINEER" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINENA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINENM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINENMOT" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinmaintenance">
                                                        <div class="btnShowHideInMaintenance" data-tinmaintenance="#boxHoldGraphInMaintenance">(-)Maintenance</div>
                                                        <div id="boxHoldGraphInMaintenance" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINMTM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINMTA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINMTTPM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINMTPM" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>


                                                    <div class="tab-pane " id="tinecut">
                                                        <div class="btnShowHideInITEC" data-tinecut="#boxHoldGraphInITEC">(-)IT&EC</div>
                                                        <div id="boxHoldGraphInITEC" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINIT" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINUT" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINEC" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="tab-pane " id="tinqc">
                                                        <div class="btnShowHideInQC" data-tinqc="#boxHoldGraphInQC">(-)QC</div>
                                                        <div id="boxHoldGraphInQC" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="carousel-inner" style="height: 100% !important">
                                                                <div class="item active ">
                                                                    <div class="row">
                                                                        <div class="col-sm-12">
                                                                            <div id="gpINQC" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                        </div>

                                                                        <div class="col-sm-12">
                                                                            <div id="gpINQA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                        </div>

                                                                        <div class="col-sm-12">
                                                                            <div id="gpINQS" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                        </div>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="tab-pane " id="tindesign">
                                                        <div class="btnShowHideInDesign" data-tindesign="#boxHoldGraphInDESIGN">(-)QC</div>
                                                        <div id="boxHoldGraphInDESIGN" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div class="item active ">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINDD" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div id="gpINCD" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="tab-pane" id="tsupport">
                                    <div class="btnShowHideSGA" data-graphsga="#boxHoldGraphSGA">(-)Graph SGA All</div>
                                    <div id="boxHoldGraphSGA" class="carousel slide" data-ride="carousel" style="height: 100%">

                                        <div class="item active">
                                            <div class="row">
                                                <div class="col-sm-12">
                                                    <div id="gpMPSGA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpOTMPSGA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>


                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHide" data-graphall="#boxSupport">(-)S.G.A</div>
                                            <div id="boxSupport" class="carousel slide" data-ride="carousel" style="height: 100%">

                                                <div class="col-sm-12">
                                                    <div id="gpINWH" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINSGA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINHR" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINAC" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINCC" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINGA" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINTS" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINAUDIT" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINHRD" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINSF" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINLG" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                                <div class="col-sm-12">
                                                    <div id="gpINTD" style="min-width: 1300px; height: 400px; margin: 0 auto"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="ttablework">
                                    <div class="col-sm-12">
                                        <div class="btnShowHideAll" data-grabhtbwork="#boxTableWork">(-) Table Work</div>
                                        <div id="boxTableWork" class="carousel slide" data-ridge="carousel" style="height: 100%">
                                            <div class="row">
                                                <div class="col-sm-2" style="padding-top: 2px">
                                                    <div class="form-group">

                                                        <label>Select Year: </label>
                                                        <asp:DropDownList ID="ddlTabMPYear" class="form-control" runat="server" OnSelectedIndexChanged="ddlTabMPYear_SelectedIndexChanged" AutoPostBack="true" Width="132px">
                                                        </asp:DropDownList>

                                                        <label>Select Month: </label>

                                                        <asp:DropDownList ID="ddlTabMPMonth" class="form-control" runat="server" OnSelectedIndexChanged="ddlTabMPMonth_SelectedIndexChanged" AutoPostBack="true" Width="135px">
                                                        </asp:DropDownList>

                                                        <label>Select Line: </label>
                                                        <asp:DropDownList ID="ddtabCostCenter" class="form-control" runat="server" OnSelectedIndexChanged="ddtabCostCenter_SelectedIndexChanged" AutoPostBack="true" Width="400px">
                                                        </asp:DropDownList>

                                                    </div>

                                                </div>
                                            </div>
                                            <div class="box-body">
                                                <div class="row">
                                                    <div class="col-md-6" align="center">
                                                        <table id="tbManpowerWork1" class="display " width="100%" border="1">
                                                            <thead>
                                                                <tr>
                                                                    <th rowspan="2" style="text-align: center">Position
                                                                    </th>
                                                                    <th style="text-align: center" colspan="7">
                                                                        <asp:Label ID="lbTabMPHeaderWorkingHour" runat="server" Text="Working of Febuary (Hrs)"></asp:Label>
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <th style="text-align: center">f</th>
                                                                    <th style="text-align: center">1</th>
                                                                    <th style="text-align: center">1.5</th>
                                                                    <th style="text-align: center">2</th>
                                                                    <th style="text-align: center">3</th>
                                                                    <th style="text-align: center">Sum OT</th>
                                                                    <th style="text-align: center">Cost</th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="rptTabMpWorkingHour" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbPositionWKHr" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lpMPCount" runat="server" Text='<%# Eval("OT1") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT1" runat="server" Text='<%# Eval("OT1") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT15" runat="server" Text='<%# Eval("OT15") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT2" runat="server" Text='<%# Eval("OT2") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT3" runat="server" Text='<%# Eval("OT3") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbSumTime" runat="server" Text='<%# Eval("OT3") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbBudget" runat="server" Text='<%# Eval("OT3") %>'></asp:Label>
                                                                            </th>
                                                                        </tr>

                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                            <thead>

                                                                <tr>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="totalOP" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                        </table>



                                                        <asp:HiddenField ID="hdMPOPOT1" runat="server" />
                                                        <asp:HiddenField ID="hdMPOPOT2" runat="server" />
                                                        <asp:HiddenField ID="hdMPOPOT3" runat="server" />
                                                        <asp:HiddenField ID="hdMPLEOT1" runat="server" />
                                                        <asp:HiddenField ID="hdMPLEOT2" runat="server" />
                                                        <asp:HiddenField ID="hdMPLEOT3" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
