<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DefaultVer2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        #homelabel {
            cursor: pointer;
        }

        #groupMonitor {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #002f75;
        }

        #groupSetting {
            height: 85vh;
            padding: 10px;
            border-radius: 25px;
            background-color: #4a3810;
        }

        #groupHistory {
            height: 85vh;
            padding: 10px;
            border-radius: 25px;
            background-color: #000000;
        }

        #groupPD {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #00b590;
        }

        .groupPD2 {
            height: 100%;
            padding: 5px;
            border-radius: 25px;
            background-color: #00b590;
        }

        #groupEG {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #823800;
        }

        #groupQC {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #adaa00;
        }

        .groupQC2 {
            height: 100%;
            padding: 10px;
            border-radius: 25px;
            background-color: #adaa00;
        }

        #groupMachine {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #00007f;
        }

        #groupCost {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #197f00;
        }

        #groupMP {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #cc8e00;
        }

        #groupSCM {
            height: 100%;
            min-height: 85vh;
            clear: both;
            padding: 10px;
            border-radius: 25px;
            background-color: #53b355;
        }

        .monitorFac1 {
            background-color: #002f75;
        }

        .Setting {
            background-color: #4a3810;
        }

        .History {
            background-color: #000000;
        }

        .PD {
            background-color: #00b590;
        }

        .EG {
            background-color: #823800;
        }

        .QC {
            background-color: #adaa00;
        }

        .MC {
            background-color: #00007f;
        }

        .CO {
            background-color: #197f00;
        }

        .MP {
            background-color: #cc8e00;
        }

        .SCM {
            background-color: #53b355;
        }

        .textMonitor {
            margin-top: 3px !important;
            margin-left: 3px;
            margin-right: 3px;
            margin-bottom: 3px;
            font-size: 25px !important;
        }

        .textMonitor2 {
            margin-top: 1px !important;
            margin-left: 1px;
            margin-right: 1px;
            margin-bottom: 1px;
            font-size: 20px !important;
        }

        .monitorFac1:hover {
            background-color: #5d5d5d;
        }

        .Hover {
            align-items: center;
            margin-top: 15px;
            margin-left: 20px;
            margin-right: 10px;
            text-align: center;
            border-radius: 20px;
            border: 3px solid;
            vertical-align: middle;
            cursor: pointer;
        }

            .Hover:hover {
                background-color: #5d5d5d;
            }


        #carousel-inner {
            height: 100vh !important;
        }

        .imgicon {
            margin-top: 10px;
        }

        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 10000; /* Sit on top */
            padding-top: 50px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
            visibility: hidden;
            -webkit-transition: opacity 600ms, visibility 600ms;
            transition: opacity 600ms, visibility 600ms;
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 90%;
        }

        .modalAndon {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 10000; /* Sit on top */
            padding-top: 50px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
            visibility: hidden;
            -webkit-transition: opacity 600ms, visibility 600ms;
            transition: opacity 600ms, visibility 600ms;
        }

        /* Modal Content */
        .modal-contentAndon {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 90%;
        }

        /* The Close Button */
        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }

        .disabledLink {
            border: 3px solid #f00;
            color: #f00;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            $(".lnkNavigator").on('click', function () {
                var _url = $(this).data("navi");
                if (_url != "") {
                    window.open(_url);
                }
            });

            //<----------------- Modal PD Andon -------------------
            //var modalAndon = document.getElementById('modalAndon');
            //var btnAndon = document.getElementById("PDAnDon");
            //var spanAndon = document.getElementsByClassName("close")[0];
            //btnAndon.onclick = function () {
            //    modalAndon.style.display = "block";
            //    modalAndon.style.visibility = "visible";
            //    modalAndon.style.opacity = "1";
            //}
            //spanAndon.onclick = function () {
            //    modalAndon.style.display = "none";
            //}
            //<----------------- Modal PD Andon -------------------

            //<----------------- Modal PD Efficiency -------------------
            var modal = document.getElementsByClassName('modal')[2];
            var btn = document.getElementById("PDEff");
            //var span = document.getElementsByClassName("close")[2];

            btn.onclick = function () {
                modal.style.display = "block";
                modal.style.visibility = "visible";
                modal.style.opacity = "1";
            }
            //span.onclick = function () {
            //    modal.style.display = "none";
            //}
            //<----------------- Modal PD Efficiency -------------------

            //------------------- Modal QC Data History ----------------------
            var modalQCDataHis = document.getElementById('modalDataHis');
            var btnQCDataHis = document.getElementById("QCDataHistory");
            //var spanQCDataHis = document.getElementsByClassName("close")[0];
            try {
                btnQCDataHis.onclick = function () {
                    modalQCDataHis.style.display = "block";
                    modalQCDataHis.style.visibility = "visible";
                    modalQCDataHis.style.opacity = "1";
                }
            } catch (ex) { }

            //spanQCDataHis.onclick = function () {
            //    modalQCDataHis.style.display = "none";
            //}            
            //------------------- Modal QC Data History ----------------------



            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
                if (event.target == modalAndon) {
                    modalAndon.style.display = "none";
                }
                if (event.target == modalQCDataHis) {
                    modalQCDataHis.style.display = "none";
                }
            }


            $(".close").click(function () {
                $(".modal").fadeOut(0);
            });
        });
    </script>

    <section class="wrapper">

        <!--overview start-->
        <%--<div class="row">
            <div class="col-lg-12">
                <h3 class="page-header" id="homelabel"><i class="glyphicon glyphicon-home"></i>Main Page</h3>

            </div>
        </div>--%>


        <!-------------- Modal QC Data History ---------------------->
        <div id="modalDataHis" class="modal">
            <div class="modal-content">
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <h2 style="font-weight: bold; margin-top: 0px !important">Data History</h2>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <span class="close">&times;</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="info-box brown-bg groupQC2" id="">
                            <div class="row" style="border-bottom: 5px solid;">
                                <div class="col-12" style="text-align: center">
                                    <div class="count">Data History</div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6 lnkNavigator QC Hover" id="QCData1" data-navi="http://http://websrv01.dci.daikin.co.jp/iotweb/DataHistory/DataHistoryLine.aspx?FactoryID=1">
                                    <img src="StyleMax/icon/factory.png" class="imgicon" /><div class="count textMonitor2">Factory 1</div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6 lnkNavigator QC Hover" id="QCData2" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/DataHistory/DataHistoryLine.aspx?FactoryID=2">
                                    <img src="StyleMax/icon/factory.png" class="imgicon" /><div class="count textMonitor2">Factory 2</div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6 lnkNavigator QC Hover" id="QCData3" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/DataHistory/DataHistoryLine.aspx?FactoryID=3">
                                    <img src="StyleMax/icon/factory.png" class="imgicon" /><div class="count textMonitor2">Factory 3</div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-------------- Modal QC Data History ---------------------->


        <!-------------- Modal PD Andon ---------------------->
        <div id="modalAndon" class="modal">
            <div class="modal-content">
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <h2 style="font-weight: bold; margin-top: 0px !important">Andon Board</h2>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <span class="close">&times;</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="info-box brown-bg groupPD2" id="">
                            <div class="row" style="border-bottom: 5px solid;">
                                <div class="col-12" style="text-align: center">
                                    <div class="count">Andon Board Monitor</div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" data-navi="http://www.dci.co.th/andon/pd/">
                                    <img src="StyleMax/icon/connect.png" class="imgicon" /><div class="count textMonitor2">Factory 1</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" data-navi="http://www.dci.co.th/andon/pd/">
                                    <img src="StyleMax/icon/connect.png" class="imgicon" /><div class="count textMonitor2">Factory 2</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" data-navi="http://www.dci.co.th/andon/pd/">
                                    <img src="StyleMax/icon/connect.png" class="imgicon" /><div class="count textMonitor2">Factory 3</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" data-navi="http://www.dci.co.th/andon/pd/">
                                    <img src="StyleMax/icon/connect.png" class="imgicon" /><div class="count textMonitor2">ODM</div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-------------- Modal PD Andon ---------------------->


        <!-------------- Modal PD Efficiency ---------------------->
        <div id="myModal" class="modal">
            <div class="modal-content">
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <h2 style="font-weight: bold; margin-top: 0px !important">Line Efficeincy</h2>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <span class="close">&times;</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="info-box brown-bg groupPD2" id="">
                            <div class="row" style="border-bottom: 5px solid;">
                                <div class="col-12" style="text-align: center">
                                    <div class="count">Line Efficeincy</div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffFinal" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=303">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Final Assembly</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffMain" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=301">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Main Assembly</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffMecha" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=302">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Mecha</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffCasing" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=312">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Casing</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffMotor" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=310">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Motor</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffFT" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=308">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Piston</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffFH" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=307">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Font Head</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffCS" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=306">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Crankshaft</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffCY" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=305">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Cylinder</div>
                                </div>

                                <div class="col-lg-2 col-md-2 col-sm-6 col-xs-6 lnkNavigator PD Hover" id="LineEffRH" data-navi="http://websrv01.dci.daikin.co.jp/lineeff/RealtimeEff.aspx?Board=304">
                                    <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor2">Rear Head</div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-------------- Modal PD Efficiency---------------------->

        <script type="text/javascript">
            $(document).ready(function () {
                $('.carousel').carousel({
                    interval: false
                });
            });
        </script>



        <div class="row">
            <div id="myCarousel" class="carousel slide" data-ride="carousel" style="height: 100%">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                </ol>

                <div class="carousel-inner" style="height: 100% !important">
                    <div class="item active">
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="info-box brown-bg" id="groupQC">
                                <div class="row" style="border-bottom: 5px solid;">
                                    <div class="col-12" style="text-align: center">
                                        <div class="count">QUALITY CONTROL</div>
                                    </div>
                                </div>

                                <div class="row">
                                    
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/DataHistory/MenuHistoryData.aspx">
                                        <img src="StyleMax/icon/folder.png" class="imgicon" /><div class="count textMonitor">Data History</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Monitoring/MonitoringLine.aspx?FactoryID=3">
                                        <img src="StyleMax/icon/trend.png" class="imgicon" /><div class="count textMonitor">Quality Trend</div>
                                    </div>
									<div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/DataHistory/HistoryData.aspx?FactoryID=3&ld_id=10">
                                        <img src="StyleMax/icon/research.png" class="imgicon" /><div class="count textMonitor">Traceability Data</div>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" id="QCSamTrend" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Trends%20Data/DailyReport.aspx?ld_id=10&FactoryID=3">
                                        <img src="StyleMax/icon/line-graph.png" class="imgicon" /><div class="count textMonitor">Sampling Trend</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" id="PDHold" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Quality/PDFinalUnHoldData.aspx">
                                        <img src="StyleMax/icon/hold.png" class="imgicon" /><div class="count textMonitor">Compressor Hold</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" id="PDHold" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Quality/PDUnHoldData.aspx">
                                        <img src="StyleMax/icon/hold.png" class="imgicon" /><div class="count textMonitor">Compressor UnHold</div>
                                    </div>

                                     <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Quality/MechaNGGraph.aspx">
                                        <img src="StyleMax/icon/trend.png" class="imgicon" /><div class="count textMonitor">Mecha Measuring NG</div>
                                    </div>

                                    <%--<%=GetLinkQCSampling() %>--%>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Quality/QCSamplingMenu.aspx">
                                        <img src="StyleMax/icon/trend.png" class="imgicon" /><div class="count textMonitor">QC Graph Monitor</div>
                                    </div>

                                    <%--<div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" id="QCRunningTest" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Quality/RunningTestJudgement.aspx">
                                        <img src="StyleMax/icon/Track.png" class="imgicon" /><div class="count textMonitor">Temp Running Test Judgement</div>
                                    </div>--%>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover" data-navi="http://websrv01.dci.daikin.co.jp/matchingpercent">
                                        <img src="StyleMax/icon/trend.png" class="imgicon" /><div class="count textMonitor">Matching Monitor</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="info-box brown-bg" id="groupPD">
                                <div class="row" style="border-bottom: 5px solid;">
                                    <div class="col-12" style="text-align: center">
                                        <div class="count">PRODUCTIVITY</div>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator PD Hover" id="PDAnDon" data-navi="http://www.dci.co.th/andon/pd/">
                                        <img src="StyleMax/icon/connect.png" class="imgicon" /><div class="count textMonitor">Andon Board</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 PD Hover" id="PDEff">
                                        <img src="StyleMax/icon/graph.png" class="imgicon" /><div class="count textMonitor">Line Efficeincy</div>
                                    </div>
									<div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator PD Hover" id="PDModelRunning" data-navi="http://websrv01.dci.daikin.co.jp/ModelRunning/">
                                        <img src="StyleMax/icon/Achieve.png" class="imgicon" /><div class="count textMonitor">Model Running</div>
                                    </div>
									<div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator PD Hover" id="PDAchPlan" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/pdmeeting.aspx">
                                        <img src="StyleMax/icon/Achieve.png" class="imgicon" /><div class="count textMonitor">Achieve Plan</div>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator PD Hover" id="PDEff2" data-navi="http://websrv01.dci.daikin.co.jp/lineeff">
                                        <img src="StyleMax/icon/graph.png" class="imgicon" /><div class="count textMonitor">Line Efficeincy (History)</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator PD Hover" id="PDPack" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Production/Packing/PackingTracking.aspx">
                                        <img src="StyleMax/icon/Track.png" class="imgicon" /><div class="count textMonitor">Compressor Tracking</div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>


                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="info-box brown-bg" id="groupCost">
                                <div class="row" style="border-bottom: 5px solid;">
                                    <div class="col-12" style="text-align: center">
                                        <div class="count">COSTING</div>
                                    </div>
                                </div>

                                <div class="row">

                                    <%= GetBudgetMenu() %>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="item">
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="info-box brown-bg" id="groupMachine">
                                <div class="row" style="border-bottom: 5px solid;">
                                    <div class="col-12" style="text-align: center">
                                        <div class="count">MACHINERY</div>
                                    </div>
                                </div>

                                <div class="row">
                                    

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MC Hover" data-navi="http://websrv01.dci.daikin.co.jp/andon/rp/">
                                        <img src="StyleMax/icon/stop.png" class="imgicon" /><div class="count textMonitor">M/C Breakdown</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MC Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/TempOven/TempOven.aspx">
                                        <img src="StyleMax/icon/thermometer.png" class="imgicon" /><div class="count textMonitor">OVEN Temperature</div>
                                    </div>
									<%--<div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MC Hover disabledLink" data-navi="">
                                        <img src="StyleMax/icon/alarm.png" class="imgicon" /><div class="count textMonitor">Alarm History</div>
                                    </div>--%>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MC Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Monitoring/AlarmGraph.aspx?DefaultFac=Fac3">
                                        <img src="StyleMax/icon/research.png" class="imgicon" /><div class="count textMonitor">Alarm History Graph</div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="info-box brown-bg" id="groupMP">
                                <div class="row" style="border-bottom: 5px solid;">
                                    <div class="col-12" style="text-align: center">
                                        <div class="count">MANPOWER</div>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MP Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/ManPower/DCIManPower.aspx">
                                        <img src="StyleMax/icon/bars.png" class="imgicon" /><div class="count textMonitor">Summarize</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MP Hover" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/MonitorLocation3DayAndonFac1.aspx">
                                        <img src="StyleMax/icon/MP.png" class="imgicon" /><div class="count textMonitor">Factory 1</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MP MPFac2 Hover" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/MonitorLocation3DayAndon.aspx">
                                        <img src="StyleMax/icon/MP.png" class="imgicon" /><div class="count textMonitor">Factory 2</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MP MPFac3 Hover" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/MonitorLocation3DayAndonFac3.aspx">
                                        <img src="StyleMax/icon/MP.png" class="imgicon" /><div class="count textMonitor">Factory 3</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MP MPODM Hover" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/MonitorLocation3DayAndonODM.aspx">
                                        <img src="StyleMax/icon/MP.png" class="imgicon" /><div class="count textMonitor">ODM</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MPMT Hover" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/MonitorLocation3DayAndonMT.aspx">
                                        <img src="StyleMax/icon/MPMT.png" class="imgicon" /><div class="count textMonitor">Maintenance</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MPUT Hover" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/MonitorEnergyControl.aspx">
                                        <img src="StyleMax/icon/MPUT.png" class="imgicon" /><div class="count textMonitor">Utility</div>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MPUT Hover" data-navi="DataHistory/MenuHistoryManPowerLog.aspx">
                                        <img src="StyleMax/icon/MP.png" class="imgicon" /><div class="count textMonitor">ManPower History Data</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="info-box brown-bg" id="groupEG">
                                <div class="row" style="border-bottom: 5px solid;">
                                    <div class="col-12" style="text-align: center">
                                        <div class="count">ENERGY</div>
                                    </div>
                                </div>

                                <!-- disabledLink -->
                                <div class="row">

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator EG Hover" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/EnergyLink.aspx?type=Electrical">
                                        <img src="StyleMax/icon/flash.png" class="imgicon" /><div class="count textMonitor">Electrical</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator EG Hover " data-navi="http://websrv01.dci.daikin.co.jp/iotweb/EnergyLink.aspx?type=Water">
                                        <img src="StyleMax/icon/drop.png" class="imgicon" /><div class="count textMonitor">Waste Water</div>
                                    </div>

                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator EG Hover " data-navi="http://websrv01.dci.daikin.co.jp/iotweb/EnergyLink.aspx?type=AirCompressor">
                                        <img src="StyleMax/icon/gas-pipe.png" class="imgicon" /><div class="count textMonitor">Air Compressor</div>
                                    </div>

                                   <%-- <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator EG Hover " data-navi="http://websrv01.dci.daikin.co.jp/iotweb/EnergyLink.aspx?type=SSUControl">
                                        <img src="StyleMax/icon/Gear-0.5s-200px.gif" class="imgicon" width="70" /><div class="count textMonitor" >SSU Control</div>
                                    </div>--%>

                                    <%=GetSSUControlMenu() %>


                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="item">
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="info-box brown-bg" id="groupSCM">
                                <div class="row" style="border-bottom: 5px solid;">
                                    <div class="col-12" style="text-align: center">
                                        <div class="count">SCM</div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" data-navi="http://websrv01.dci.daikin.co.jp/DeliverySchedule/DeliveryMonitor">
                                        <img src="StyleMax/icon/folder.png" class="imgicon" /><div class="count textMonitor">Receive</div>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" data-navi="http://websrv01.dci.daikin.co.jp/DCISCM_DEV/delivery_order/RMStockByModel.aspx">
                                        <img src="StyleMax/icon/folder.png" class="imgicon" /><div class="count textMonitor">Store</div>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" data-navi="http://websrv01.dci.daikin.co.jp/DeliverySchedule/PicklistData">
                                        <img src="StyleMax/icon/folder.png" class="imgicon" /><div class="count textMonitor">Issue</div>
                                    </div>
									<div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" id="PDResult" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/productioncenter/fgmonitor.aspx">
                                        <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor">Compressor FG Product</div>
                                    </div>
                                    
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" id="PDResult2" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/productioncenter/fgdatalist.aspx">
                                        <img src="StyleMax/icon/line-graph.png" class="imgicon" /><div class="count textMonitor">Product Daily Actual</div>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" id="PDResult3" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/productioncenter/FGDataListHistory.aspx">
                                        <img src="StyleMax/icon/line-graph.png" class="imgicon" /><div class="count textMonitor">Product Actual History</div>
                                    </div>
									<div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" id="PDResult" data-navi="http://websrv01.dci.daikin.co.jp/pdmonitoring/productioncenter/FGODMMonitor.aspx">
                                        <img src="StyleMax/icon/line-chart.png" class="imgicon" /><div class="count textMonitor">ODM FG Product</div>
                                    </div>
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator SCM Hover" id="PDResult2" data-navi="http://websrv01.dci.daikin.co.jp/iotweb/Production/PDBackflushMainAssyFac3.aspx">
                                        <img src="StyleMax/icon/line-graph.png" class="imgicon" /><div class="count textMonitor">Part Main Assy Daily Actual</div>
                                    </div>
									
                                </div>
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


    </section>
</asp:Content>

