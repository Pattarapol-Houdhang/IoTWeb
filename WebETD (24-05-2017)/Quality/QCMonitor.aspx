<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QCMonitor.aspx.cs" Inherits="Quality_QCMonitor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%= ResolveUrl("~/StyleMax/css/bootstrap.min.css") %>" rel="stylesheet">
    <!-- bootstrap theme -->
    <link href="<%= ResolveUrl("~/StyleMax/css/bootstrap-theme.css") %>" rel="stylesheet">
    <!--external css-->
    <!-- font icon -->
    <link href="<%= ResolveUrl("~/StyleMax/css/elegant-icons-style.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/css/font-awesome.min.css") %>" rel="stylesheet" />
    <!-- full calendar css-->
    <link href="<%= ResolveUrl("~/StyleMax/assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/assets/fullcalendar/fullcalendar/fullcalendar.css") %>" rel="stylesheet" />
    <!-- easy pie chart-->
    <link href="<%= ResolveUrl("~/StyleMax/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css") %>" rel="stylesheet" type="text/css" media="screen" />
    <!-- owl carousel -->
    <link rel="stylesheet" href="<%= ResolveUrl("~/StyleMax/css/owl.carousel.css") %>" type="text/css">
    <link href="<%= ResolveUrl("~/StyleMax/css/jquery-jvectormap-1.2.2.css") %>" rel="stylesheet">
    <!-- Custom styles -->
    <link rel="stylesheet" href="<%= ResolveUrl("~/StyleMax/css/fullcalendar.css") %>">
    <link href="<%= ResolveUrl("~/StyleMax/css/widgets.css") %>" rel="stylesheet">
    <link href="<%= ResolveUrl("~/StyleMax/css/style.css") %>" rel="stylesheet">
    <link href="<%= ResolveUrl("~/StyleMax/css/style-responsive.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/css/xcharts.min.css") %>" rel=" stylesheet">
    <link href="<%= ResolveUrl("~/StyleMax/css/jquery-ui-1.10.4.min.css") %>" rel="stylesheet">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="../StyleMax/css/slide/bootstrapslide.css" rel="stylesheet" />


    <!-- javascripts -->
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-ui-1.10.4.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/StyleMax/js/jquery-ui-1.9.2.custom.min.js") %>"></script>
    <!-- bootstrap -->
    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap.min.js") %>"></script>
    <!-- nice scroll -->
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.scrollTo.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.nicescroll.js") %>" type="text/javascript"></script>
    <!-- charts scripts -->
    <script src="<%= ResolveUrl("~/StyleMax/assets/jquery-knob/js/jquery.knob.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.sparkline.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/StyleMax/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/owl.carousel.js") %>"></script>
    <!-- jQuery full calendar -->

    <script src="<%= ResolveUrl("~/StyleMax/js/fullcalendar.min.js") %>"></script>
    <!-- Full Google Calendar - Calendar -->
    <script src="<%= ResolveUrl("~/StyleMax/assets/fullcalendar/fullcalendar/fullcalendar.js") %>"></script>
    <!--script for this page only-->
    <script src="<%= ResolveUrl("~/StyleMax/js/calendar-custom.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.rateit.min.js") %>"></script>
    <!-- custom select -->
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.customSelect.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/assets/chart-master/Chart.js") %>"></script>

    <!--custome script for all page-->
    <script src="<%= ResolveUrl("~/StyleMax/js/scripts.js") %>"></script>
    <!-- custom script for this page-->
    <script src="<%= ResolveUrl("~/StyleMax/js/sparkline-chart.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/easy-pie-chart.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-jvectormap-1.2.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-jvectormap-world-mill-en.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/xcharts.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.autosize.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.placeholder.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/gdp-data.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/morris.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/sparklines.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/charts.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.slimscroll.min.js") %>"></script>

    <link href="<%= ResolveUrl("~/StyleMax/js/daterangepicker.css") %>" rel="stylesheet" />


    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/highcharts.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/modules/data.js") %>"></script>
    <script src="<%= ResolveUrl("~/js/moment.js") %>"></script>

</head>
<body style="background-color: black; color: gold;">
    <form id="form1" runat="server">
        <div>

            <div class="row">
                <div class="col-lg-12" style="text-align: center;">
                    <h1><b>QC Sampling Real Time Monitor</b></h1>
                </div>
            </div>


            <div class="row">
                <div id="divFH" class="col-lg-2" style="background-color: gray">
                    <div class="col-lg-12" style="margin-bottom: 10px; text-align: center;">
                        <h2><b>Front Head</b></h2>
                    </div>

                    <!-- Front Head -->
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="FHIDID" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="FHIDRoundness" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="FHIDCylindricity" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="FHIDPerpan" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="FHIDConcentric" style="height: 270px"></div>
                    </div>


                </div>

                <div class="col-lg-2">
                    <div class="col-lg-12" style="margin-bottom: 10px; text-align: center;">
                        <h2><b>Rear Head</b></h2>
                    </div>

                    <!-- Front Head -->
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="RHRoundness" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="RHPerpan" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="testG" style="height: 270px"></div>
                    </div>


                </div>

                <div class="col-lg-2" style="background-color: gray">
                    <div class="col-lg-12" style="margin-bottom: 10px; text-align: center;">
                        <h2><b>Crank Shaft</b></h2>
                    </div>

                    <!-- Front Head -->
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CSFODRoundness" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CSRODRoundness" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CSPINRoundness" style="height: 270px"></div>
                    </div>


                </div>

                <div class="col-lg-4">
                    <div class="col-lg-12" style="margin-bottom: 10px; text-align: center;">
                        <h2><b>Piston</b></h2>
                    </div>
                    <div class="col-lg-6">
                        <div class="col-lg-12" style="margin-bottom: 10px;">
                            <div id="PTIDRoundness" style="height: 270px"></div>
                        </div>
                        <div class="col-lg-12" style="margin-bottom: 10px;">
                            <div id="PTIDPerpan" style="height: 270px"></div>
                        </div>
                        <div class="col-lg-12" style="margin-bottom: 10px;">
                            <div id="PTODRoundness" style="height: 270px"></div>
                        </div>
                        <div class="col-lg-12" style="margin-bottom: 10px;">
                            <div id="PTODPerpan" style="height: 270px"></div>
                        </div>
                        <div class="col-lg-12" style="margin-bottom: 10px;">
                            <div id="PTBladePerpan" style="height: 270px"></div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="col-lg-12" style="margin-bottom: 10px;">
                            <div id="PTHeightParallel" style="height: 270px"></div>
                        </div>
                        <div class="col-lg-12" style="margin-bottom: 10px;">
                            <div id="PTBladeParallel" style="height: 270px"></div>
                        </div>
                    </div>

                </div>
                <div class="col-lg-2" style="background-color: gray">
                    <div class="col-lg-12" style="margin-bottom: 10px; text-align: center;">
                        <h2><b>Cyliner</b></h2>
                    </div>

                    <!-- Front Head -->
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CYBORoundness" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CYBOPerpan" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CYHEPallaism" style="height: 270px"></div>
                    </div>
                    <%--<div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CYBURoundness" style="height: 270px"></div>
                    </div>
                    <div class="col-lg-12" style="margin-bottom: 10px;">
                        <div id="CYBUPerpan" style="height: 270px"></div>
                    </div>--%>

                </div>

            </div>

            <script>
                $(document).ready(function () {
                    LoadGraphFH();
                    LoadGraphRH();
                    LoadGraphCS();
                    LoadGraphPT();
                    LoadGraphCY();

                    LoadDataFH();
                    LoadDataRH();
                    LoadDataCS();
                    LoadDataPT();
                    LoadDataCY();

                    //$('#divFH').animate({ 'zoom': "-3%" }, 100);

                    document.body.style.zoom = "67%";

                });


                $(document).ready(function () {
                    setInterval(function () {
                        LoadDataFH();
                        LoadDataRH();
                        LoadDataCS();
                        LoadDataPT();
                        LoadDataCY();
                    }, 30000);
                });


                var ShiftPD = "D";
                var DatePD = moment().format("YYYY-MM-DD HH:mm:ss");
                var DatePDStart = moment().format("YYYY-MM-DD HH:mm:ss");
                var DatePDEnd = moment().format("YYYY-MM-DD HH:mm:ss");
                DatePD = new Date(DatePD);
                //DatePD = "2018-12-10";
                if (DatePD > new Date(moment().format("YYYY-MM-DD") + " 08:00")
                    && DatePD < new Date(moment().format("YYYY-MM-DD") + " 20:00")) {
                    DatePDStart = moment().format("YYYY-MM-DD") + " 08:00";
                    DatePDEnd = moment().format("YYYY-MM-DD") + " 20:00";
                    //DatePD = moment().add(1, 'days').format("YYYY-MM-DD");
                    ShiftPD = "D";
                } else if (DatePD > new Date(moment().format("YYYY-MM-DD") + " 20:00")) {
                    DatePDStart = moment().format("YYYY-MM-DD") + " 20:00";
                    DatePDEnd = moment().add(1, 'days').format("YYYY-MM-DD") + " 08:00";
                    ShiftPD = "N";
                } else if (DatePD < new Date(moment().format("YYYY-MM-DD") + " 08:00")) {
                    DatePDStart = moment().add(-1, 'days').format("YYYY-MM-DD") + " 20:00";
                    DatePDEnd = moment().format("YYYY-MM-DD") + " 08:00";
                    ShiftPD = "N";
                }

                var FH_ID_DateLabel = [], FH_RN_DateLabel = [], FH_CY_DateLabel = [], FH_PP_DateLabel = [], FH_CO_DateLabel = [];
                var FH_ID_MQMax = [], FH_ID_MQMin = [], FH_ID_UCL = [], FH_ID_CL = [], FH_ID_LCL = [];
                var FH_RN_MQMax = [], FH_RN_MQMin = [], FH_RN_UCL = [], FH_RN_CL = [], FH_RN_LCL = [];
                var FH_CY_MQMax = [], FH_CY_MQMin = [], FH_CY_UCL = [], FH_CY_CL = [], FH_CY_LCL = [];
                var FH_PP_MQMax = [], FH_PP_MQMin = [], FH_PP_UCL = [], FH_PP_CL = [], FH_PP_LCL = [];
                var FH_CO_MQMax = [], FH_CO_MQMin = [], FH_CO_UCL = [], FH_CO_CL = [], FH_CO_LCL = [];
                var fh_id1 = [];
                var fh_judge_roundness = [];
                var fh_cylindricity = [];
                var fh_perpendicularity = [];
                var fh_concentricity = [];

                function LoadDataFH() {

                    $.ajax({
                        url: "GetGraphDataFHID.ashx?DateStart=" + DatePDStart + "&DateEnd=" + DatePDEnd + "&RowsQty=1000" ,
                        dataType: "json",
                        async: true,
                        success: function (data) {


                            //data.ListOfID[0].fh_id1;
                            FH_ID_DateLabel = [], FH_RN_DateLabel = [], FH_CY_DateLabel = [], FH_PP_DateLabel = [], FH_CO_DateLabel = [];
                            FH_ID_MQMax = [], FH_ID_MQMin = [], FH_ID_UCL = [], FH_ID_CL = [], FH_ID_LCL = [];
                            FH_RN_MQMax = [], FH_RN_MQMin = [], FH_RN_UCL = [], FH_RN_CL = [], FH_RN_LCL = [];
                            FH_CY_MQMax = [], FH_CY_MQMin = [], FH_CY_UCL = [], FH_CY_CL = [], FH_CY_LCL = [];
                            FH_PP_MQMax = [], FH_PP_MQMin = [], FH_PP_UCL = [], FH_PP_CL = [], FH_PP_LCL = [];
                            FH_CO_MQMax = [], FH_CO_MQMin = [], FH_CO_UCL = [], FH_CO_CL = [], FH_CO_LCL = [];
                            fh_id1 = [];
                            fh_judge_roundness = [];
                            fh_cylindricity = [];
                            fh_perpendicularity = [];
                            fh_concentricity = [];

                            var testValue2 = data.ListOfID[0].SubPoint;

                            for (i = 0; i < data.ListOfID.length; i++) {
                                //FH_DateLabel.push(data.ListOfID[i].first_stamptime);

                                if (data.ListOfID[i].SubPoint == "ID") {
                                    FH_ID_DateLabel.push(data.ListOfID[i].first_stamptime);
                                    FH_ID_MQMax.push(data.ListOfID[i].MQMax);
                                    FH_ID_MQMin.push(data.ListOfID[i].MQMin);
                                    FH_ID_UCL.push(data.ListOfID[i].UCL);
                                    FH_ID_CL.push(data.ListOfID[i].CL);
                                    FH_ID_LCL.push(data.ListOfID[i].LCL);
                                    fh_id1.push(data.ListOfID[i].fh_id1);
                                } else if (data.ListOfID[i].SubPoint == "Roundness") {
                                    FH_RN_DateLabel.push(data.ListOfID[i].first_stamptime);
                                    FH_RN_MQMax.push(data.ListOfID[i].MQMax);
                                    FH_RN_MQMin.push(data.ListOfID[i].MQMin);
                                    FH_RN_UCL.push(data.ListOfID[i].UCL);
                                    FH_RN_CL.push(data.ListOfID[i].CL);
                                    FH_RN_LCL.push(data.ListOfID[i].LCL);
                                    fh_judge_roundness.push(data.ListOfID[i].fh_judge_roundness);
                                } else if (data.ListOfID[i].SubPoint == "Cylindricity") {
                                    FH_CY_DateLabel.push(data.ListOfID[i].first_stamptime);
                                    FH_CY_MQMax.push(data.ListOfID[i].MQMax);
                                    FH_CY_MQMin.push(data.ListOfID[i].MQMin);
                                    FH_CY_UCL.push(data.ListOfID[i].UCL);
                                    FH_CY_CL.push(data.ListOfID[i].CL);
                                    FH_CY_LCL.push(data.ListOfID[i].LCL);
                                    fh_cylindricity.push(data.ListOfID[i].fh_cylindricity);
                                } else if (data.ListOfID[i].SubPoint == "Perpan") {
                                    FH_PP_DateLabel.push(data.ListOfID[i].first_stamptime);
                                    FH_PP_MQMax.push(data.ListOfID[i].MQMax);
                                    FH_PP_MQMin.push(data.ListOfID[i].MQMin);
                                    FH_PP_UCL.push(data.ListOfID[i].UCL);
                                    FH_PP_CL.push(data.ListOfID[i].CL);
                                    FH_PP_LCL.push(data.ListOfID[i].LCL);
                                    fh_perpendicularity.push(data.ListOfID[i].fh_perpendicularity);
                                } else if (data.ListOfID[i].SubPoint == "Concentric") {
                                    FH_CO_DateLabel.push(data.ListOfID[i].first_stamptime);
                                    FH_CO_MQMax.push(data.ListOfID[i].MQMax);
                                    FH_CO_MQMin.push(data.ListOfID[i].MQMin);
                                    FH_CO_UCL.push(data.ListOfID[i].UCL);
                                    FH_CO_CL.push(data.ListOfID[i].CL);
                                    FH_CO_LCL.push(data.ListOfID[i].LCL);
                                    fh_concentricity.push(data.ListOfID[i].fh_concentricity);
                                }

                            }


                            LoadGraphFH();




                        },
                        error: function (e) {
                            alert(DatePDStart + ' ' + DatePDEnd);
                        }
                    });


                }



                var RH_ID_DateLabel = [], RH_RN_DateLabel = [], RH_CY_DateLabel = [], RH_PP_DateLabel = [], RH_CO_DateLabel = [];
                var RH_ID_MQMax = [], RH_ID_MQMin = [], RH_ID_UCL = [], RH_ID_CL = [], RH_ID_LCL = [];
                var RH_RN_MQMax = [], RH_RN_MQMin = [], RH_RN_UCL = [], RH_RN_CL = [], RH_RN_LCL = [];
                var RH_CY_MQMax = [], RH_CY_MQMin = [], RH_CY_UCL = [], RH_CY_CL = [], RH_CY_LCL = [];
                var RH_PP_MQMax = [], RH_PP_MQMin = [], RH_PP_UCL = [], RH_PP_CL = [], RH_PP_LCL = [];
                var RH_CO_MQMax = [], RH_CO_MQMin = [], RH_CO_UCL = [], RH_CO_CL = [], RH_CO_LCL = [];
                var rh_id1 = [];
                var rh_judge_roundness = [];
                var rh_cylindricity = [];
                var rh_perpendicularity = [];

                function LoadDataRH() {
                    $.ajax({
                        url: "GetGraphDataRH.ashx?DateStart=" + DatePDStart + "&DateEnd=" + DatePDEnd + "&RowsQty=1000",
                        dataType: "json",
                        async: true,
                        success: function (data) {


                            //data.ListOfID[0].fh_id1;
                            RH_ID_DateLabel = [], RH_RN_DateLabel = [], RH_CY_DateLabel = [], RH_PP_DateLabel = [], RH_CO_DateLabel = [];
                            RH_ID_MQMax = [], RH_ID_MQMin = [], RH_ID_UCL = [], RH_ID_CL = [], RH_ID_LCL = [];
                            RH_RN_MQMax = [], RH_RN_MQMin = [], RH_RN_UCL = [], RH_RN_CL = [], RH_RN_LCL = [];
                            RH_CY_MQMax = [], RH_CY_MQMin = [], RH_CY_UCL = [], RH_CY_CL = [], RH_CY_LCL = [];
                            RH_PP_MQMax = [], RH_PP_MQMin = [], RH_PP_UCL = [], RH_PP_CL = [], RH_PP_LCL = [];
                            RH_CO_MQMax = [], RH_CO_MQMin = [], RH_CO_UCL = [], RH_CO_CL = [], RH_CO_LCL = [];
                            rh_id1 = [];
                            rh_judge_roundness = [];
                            rh_cylindricity = [];
                            rh_perpendicularity = [];


                            for (i = 0; i < data.ListOfRH.length; i++) {
                                //RH_DateLabel.push(data.ListOfRH[i].first_stamptime);

                                if (data.ListOfRH[i].SubPoint == "ID") {
                                    RH_ID_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                    RH_ID_MQMax.push(data.ListOfRH[i].MQMax);
                                    RH_ID_MQMin.push(data.ListOfRH[i].MQMin);
                                    RH_ID_UCL.push(data.ListOfRH[i].UCL);
                                    RH_ID_CL.push(data.ListOfRH[i].CL);
                                    RH_ID_LCL.push(data.ListOfRH[i].LCL);
                                    rh_id1.push(data.ListOfRH[i].rh_id1);
                                } else if (data.ListOfRH[i].SubPoint == "Roundness") {
                                    RH_RN_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                    RH_RN_MQMax.push(data.ListOfRH[i].MQMax);
                                    RH_RN_MQMin.push(data.ListOfRH[i].MQMin);
                                    RH_RN_UCL.push(data.ListOfRH[i].UCL);
                                    RH_RN_CL.push(data.ListOfRH[i].CL);
                                    RH_RN_LCL.push(data.ListOfRH[i].LCL);
                                    rh_judge_roundness.push(data.ListOfRH[i].rh_judge_roundness);
                                } else if (data.ListOfRH[i].SubPoint == "Cylindricity") {
                                    RH_CY_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                    RH_CY_MQMax.push(data.ListOfRH[i].MQMax);
                                    RH_CY_MQMin.push(data.ListOfRH[i].MQMin);
                                    RH_CY_UCL.push(data.ListOfRH[i].UCL);
                                    RH_CY_CL.push(data.ListOfRH[i].CL);
                                    RH_CY_LCL.push(data.ListOfRH[i].LCL);
                                    rh_cylindricity.push(data.ListOfRH[i].rh_cylindricity);
                                } else if (data.ListOfRH[i].SubPoint == "Perpan") {
                                    RH_PP_DateLabel.push(data.ListOfRH[i].first_stamptime);
                                    RH_PP_MQMax.push(data.ListOfRH[i].MQMax);
                                    RH_PP_MQMin.push(data.ListOfRH[i].MQMin);
                                    RH_PP_UCL.push(data.ListOfRH[i].UCL);
                                    RH_PP_CL.push(data.ListOfRH[i].CL);
                                    RH_PP_LCL.push(data.ListOfRH[i].LCL);
                                    rh_perpendicularity.push(data.ListOfRH[i].rh_perpendicularity);
                                }

                            }

                            LoadGraphRH();

                        },
                        error: function (e) {
                            alert(DatePDStart + ' ' + DatePDEnd);
                        }
                    });

                }

                var CS_F_ID_DateLabel = [], CS_F_RN_DateLabel = [], CS_F_CY_DateLabel = [];
                var CS_R_ID_DateLabel = [], CS_R_RN_DateLabel = [], CS_R_CY_DateLabel = [];
                var CS_P_ID_DateLabel = [], CS_P_RN_DateLabel = [], CS_P_CY_DateLabel = [];

                var CS_F_ID_MQMax = [], CS_F_ID_MQMin = [], CS_F_ID_UCL = [], CS_F_ID_CL = [], CS_F_ID_LCL = [];
                var CS_R_ID_MQMax = [], CS_R_ID_MQMin = [], CS_R_ID_UCL = [], CS_R_ID_CL = [], CS_R_ID_LCL = [];
                var CS_P_ID_MQMax = [], CS_P_ID_MQMin = [], CS_P_ID_UCL = [], CS_P_ID_CL = [], CS_P_ID_LCL = [];

                var CS_F_RN_MQMax = [], CS_F_RN_MQMin = [], CS_F_RN_UCL = [], CS_F_RN_CL = [], CS_F_RN_LCL = [];
                var CS_R_RN_MQMax = [], CS_R_RN_MQMin = [], CS_R_RN_UCL = [], CS_R_RN_CL = [], CS_R_RN_LCL = [];
                var CS_P_RN_MQMax = [], CS_P_RN_MQMin = [], CS_P_RN_UCL = [], CS_P_RN_CL = [], CS_P_RN_LCL = [];

                var CS_F_CY_MQMax = [], CS_F_CY_MQMin = [], CS_F_CY_UCL = [], CS_F_CY_CL = [], CS_F_CY_LCL = [];
                var CS_R_CY_MQMax = [], CS_R_CY_MQMin = [], CS_R_CY_UCL = [], CS_R_CY_CL = [], CS_R_CY_LCL = [];
                var CS_P_CY_MQMax = [], CS_P_CY_MQMin = [], CS_P_CY_UCL = [], CS_P_CY_CL = [], CS_P_CY_LCL = [];

                var cs_fr_f_rank = [];
                var cs_fr_r_rank = [];
                var cs_fr_f_judge_roundness = [];
                var cs_fr_r_judge_roundness = [];
                var cs_fr_f_cylindricity = [];
                var cs_fr_r_cylindricity = [];
                var cs_pin_rank = [];
                var cs_pin_judge_roundness = [];
                var cs_pin_cylindricity = [];

                function LoadDataCS() {
                    $.ajax({
                        url: "GetGraphDataCS.ashx?DateStart=" + DatePDStart + "&DateEnd=" + DatePDEnd + "&RowsQty=1000",
                        dataType: "json",
                        async: true,
                        success: function (data) {


                            //data.ListOfID[0].fh_id1;
                            CS_F_ID_DateLabel = [], CS_F_RN_DateLabel = [], CS_F_CY_DateLabel = []
                            CS_R_ID_DateLabel = [], CS_R_RN_DateLabel = [], CS_R_CY_DateLabel = []
                            CS_P_ID_DateLabel = [], CS_P_RN_DateLabel = [], CS_P_CY_DateLabel = []


                            CS_F_ID_MQMax = [], CS_F_ID_MQMin = [], CS_F_ID_UCL = [], CS_F_ID_CL = [], CS_F_ID_LCL = [];
                            CS_R_ID_MQMax = [], CS_R_ID_MQMin = [], CS_R_ID_UCL = [], CS_R_ID_CL = [], CS_R_ID_LCL = [];
                            CS_P_ID_MQMax = [], CS_P_ID_MQMin = [], CS_P_ID_UCL = [], CS_P_ID_CL = [], CS_P_ID_LCL = [];

                            CS_F_RN_MQMax = [], CS_F_RN_MQMin = [], CS_F_RN_UCL = [], CS_F_RN_CL = [], CS_F_RN_LCL = [];
                            CS_R_RN_MQMax = [], CS_R_RN_MQMin = [], CS_R_RN_UCL = [], CS_R_RN_CL = [], CS_R_RN_LCL = [];
                            CS_P_RN_MQMax = [], CS_P_RN_MQMin = [], CS_P_RN_UCL = [], CS_P_RN_CL = [], CS_P_RN_LCL = [];

                            CS_F_CY_MQMax = [], CS_F_CY_MQMin = [], CS_F_CY_UCL = [], CS_F_CY_CL = [], CS_F_CY_LCL = [];
                            CS_R_CY_MQMax = [], CS_R_CY_MQMin = [], CS_R_CY_UCL = [], CS_R_CY_CL = [], CS_R_CY_LCL = [];
                            CS_P_CY_MQMax = [], CS_P_CY_MQMin = [], CS_P_CY_UCL = [], CS_P_CY_CL = [], CS_P_CY_LCL = [];
                            cs_fr_f_rank = [];
                            cs_fr_r_rank = [];
                            cs_fr_f_judge_roundness = [];
                            cs_fr_r_judge_roundness = [];
                            cs_fr_f_cylindricity = [];
                            cs_fr_r_cylindricity = [];
                            cs_pin_rank = [];
                            cs_pin_judge_roundness = [];
                            cs_pin_cylindricity = [];


                            for (i = 0; i < data.ListOfCS.length; i++) {
                                //CS_DateLabel.push(data.ListOfCS[i].first_stamptime);

                                if (data.ListOfCS[i].MainPoint == "FRONT_OD") {
                                    if (data.ListOfCS[i].SubPoint == "ID") {
                                        CS_F_ID_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_F_ID_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_F_ID_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_F_ID_UCL.push(data.ListOfCS[i].UCL);
                                        CS_F_ID_CL.push(data.ListOfCS[i].CL);
                                        CS_F_ID_LCL.push(data.ListOfCS[i].LCL);
                                        cs_fr_f_rank.push(data.ListOfCS[i].cs_fr_f_rank);
                                    } else if (data.ListOfCS[i].SubPoint == "Roundness") {
                                        CS_F_RN_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_F_RN_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_F_RN_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_F_RN_UCL.push(data.ListOfCS[i].UCL);
                                        CS_F_RN_CL.push(data.ListOfCS[i].CL);
                                        CS_F_RN_LCL.push(data.ListOfCS[i].LCL);
                                        cs_fr_f_judge_roundness.push(data.ListOfCS[i].cs_fr_f_judge_roundness);
                                    } else if (data.ListOfCS[i].SubPoint == "Cylindricity") {
                                        CS_F_CY_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_F_CY_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_F_CY_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_F_CY_UCL.push(data.ListOfCS[i].UCL);
                                        CS_F_CY_CL.push(data.ListOfCS[i].CL);
                                        CS_F_CY_LCL.push(data.ListOfCS[i].LCL);
                                        cs_fr_f_cylindricity.push(data.ListOfCS[i].cs_fr_f_cylindricity);
                                    }
                                } else if (data.ListOfCS[i].MainPoint == "REAR_OD") {
                                    if (data.ListOfCS[i].SubPoint == "ID") {
                                        CS_R_ID_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_R_ID_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_R_ID_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_R_ID_UCL.push(data.ListOfCS[i].UCL);
                                        CS_R_ID_CL.push(data.ListOfCS[i].CL);
                                        CS_R_ID_LCL.push(data.ListOfCS[i].LCL);
                                        cs_fr_r_rank.push(data.ListOfCS[i].cs_fr_r_rank);
                                    } else if (data.ListOfCS[i].SubPoint == "Roundness") {
                                        CS_R_RN_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_R_RN_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_R_RN_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_R_RN_UCL.push(data.ListOfCS[i].UCL);
                                        CS_R_RN_CL.push(data.ListOfCS[i].CL);
                                        CS_R_RN_LCL.push(data.ListOfCS[i].LCL);
                                        cs_fr_r_judge_roundness.push(data.ListOfCS[i].cs_fr_r_judge_roundness);
                                    } else if (data.ListOfCS[i].SubPoint == "Cylindricity") {
                                        CS_R_CY_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_R_CY_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_R_CY_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_R_CY_UCL.push(data.ListOfCS[i].UCL);
                                        CS_R_CY_CL.push(data.ListOfCS[i].CL);
                                        CS_R_CY_LCL.push(data.ListOfCS[i].LCL);
                                        cs_fr_r_cylindricity.push(data.ListOfCS[i].cs_fr_r_cylindricity);
                                    }
                                } else if (data.ListOfCS[i].MainPoint == "PIN") {
                                    if (data.ListOfCS[i].SubPoint == "ID") {
                                        CS_P_ID_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_P_ID_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_P_ID_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_P_ID_UCL.push(data.ListOfCS[i].UCL);
                                        CS_P_ID_CL.push(data.ListOfCS[i].CL);
                                        CS_P_ID_LCL.push(data.ListOfCS[i].LCL);
                                        cs_pin_rank.push(data.ListOfCS[i].cs_pin_rank);
                                    } else if (data.ListOfCS[i].SubPoint == "Roundness") {
                                        CS_P_RN_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_P_RN_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_P_RN_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_P_RN_UCL.push(data.ListOfCS[i].UCL);
                                        CS_P_RN_CL.push(data.ListOfCS[i].CL);
                                        CS_P_RN_LCL.push(data.ListOfCS[i].LCL);
                                        cs_pin_judge_roundness.push(data.ListOfCS[i].cs_pin_judge_roundness);
                                    } else if (data.ListOfCS[i].SubPoint == "Cylindricity") {
                                        CS_P_CY_DateLabel.push(data.ListOfCS[i].first_stamptime);
                                        CS_P_CY_MQMax.push(data.ListOfCS[i].MQMax);
                                        CS_P_CY_MQMin.push(data.ListOfCS[i].MQMin);
                                        CS_P_CY_UCL.push(data.ListOfCS[i].UCL);
                                        CS_P_CY_CL.push(data.ListOfCS[i].CL);
                                        CS_P_CY_LCL.push(data.ListOfCS[i].LCL);
                                        cs_pin_cylindricity.push(data.ListOfCS[i].cs_pin_cylindricity);
                                    }
                                }


                            }

                            LoadGraphCS();

                        },
                        error: function (e) {
                            alert(DatePDStart + ' ' + DatePDEnd);
                        }
                    });

                }


                var PT_ID_ID_DateLabel = [], PT_ID_RN_DateLabel = [], PT_ID_CY_DateLabel = [], PT_ID_PP_DateLabel = [], PT_ID_CO_DateLabel = [];
                var PT_OD_ID_DateLabel = [], PT_OD_RN_DateLabel = [], PT_OD_CY_DateLabel = [], PT_OD_PP_DateLabel = [], PT_OD_CO_DateLabel = [];
                var PT_BL_TN_DateLabel = [], PT_BL_PL_DateLabel = [], PT_BL_PP_DateLabel = [];
                var PT_HE_HE_DateLabel = [], PT_HE_PL_DateLabel = [];

                var PT_ID_ID_MQMax = [], PT_ID_ID_MQMin = [], PT_ID_ID_UCL = [], PT_ID_ID_CL = [], PT_ID_ID_LCL = [];
                var PT_ID_RN_MQMax = [], PT_ID_RN_MQMin = [], PT_ID_RN_UCL = [], PT_ID_RN_CL = [], PT_ID_RN_LCL = [];
                var PT_ID_CY_MQMax = [], PT_ID_CY_MQMin = [], PT_ID_CY_UCL = [], PT_ID_CY_CL = [], PT_ID_CY_LCL = [];
                var PT_ID_PP_MQMax = [], PT_ID_PP_MQMin = [], PT_ID_PP_UCL = [], PT_ID_PP_CL = [], PT_ID_PP_LCL = [];
                var PT_ID_CO_MQMax = [], PT_ID_CO_MQMin = [], PT_ID_CO_UCL = [], PT_ID_CO_CL = [], PT_ID_CO_LCL = [];

                var PT_OD_ID_MQMax = [], PT_OD_ID_MQMin = [], PT_OD_ID_UCL = [], PT_OD_ID_CL = [], PT_OD_ID_LCL = [];
                var PT_OD_RN_MQMax = [], PT_OD_RN_MQMin = [], PT_OD_RN_UCL = [], PT_OD_RN_CL = [], PT_OD_RN_LCL = [];
                var PT_OD_CY_MQMax = [], PT_OD_CY_MQMin = [], PT_OD_CY_UCL = [], PT_OD_CY_CL = [], PT_OD_CY_LCL = [];
                var PT_OD_PP_MQMax = [], PT_OD_PP_MQMin = [], PT_OD_PP_UCL = [], PT_OD_PP_CL = [], PT_OD_PP_LCL = [];
                var PT_OD_CO_MQMax = [], PT_OD_CO_MQMin = [], PT_OD_CO_UCL = [], PT_OD_CO_CL = [], PT_OD_CO_LCL = [];

                var PT_BL_TN_MQMax = [], PT_BL_TN_MQMin = [], PT_BL_TN_UCL = [], PT_BL_TN_CL = [], PT_BL_TN_LCL = [];
                var PT_BL_PL_MQMax = [], PT_BL_PL_MQMin = [], PT_BL_PL_UCL = [], PT_BL_PL_CL = [], PT_BL_PL_LCL = [];
                var PT_BL_PP_MQMax = [], PT_BL_PP_MQMin = [], PT_BL_PP_UCL = [], PT_BL_PP_CL = [], PT_BL_PP_LCL = [];

                var PT_HE_HE_MQMax = [], PT_HE_HE_MQMin = [], PT_HE_HE_UCL = [], PT_HE_HE_CL = [], PT_HE_HE_LCL = [];
                var PT_HE_PL_MQMax = [], PT_HE_PL_MQMin = [], PT_HE_PL_UCL = [], PT_HE_PL_CL = [], PT_HE_PL_LCL = [];

                var pt_id_rank = [];
                var pt_id_roundness = [];
                var pt_id_cylindricity = [];
                var pt_id_perpendicularity = [];
                var pt_id_concentricity = [];
                var pt_od_rank = [];
                var pt_od_judge_roundness = [];
                var pt_od_cylindricity = [];
                var pt_od_perpendicularity = [];
                var pt_bl_rank = [];
                var pt_bl_parallism = [];
                var pt_bl_perpendicularity = [];
                var pt_he_rank = [];
                var pt_he_parallism = [];

                function LoadDataPT() {
                    $.ajax({
                        url: "GetGraphDataPT.ashx?DateStart=" + DatePDStart + "&DateEnd=" + DatePDEnd + "&RowsQty=2000",
                        dataType: "json",
                        async: true,
                        success: function (data) {


                            PT_ID_ID_DateLabel = [], PT_ID_RN_DateLabel = [], PT_ID_CY_DateLabel = [], PT_ID_PP_DateLabel = [], PT_ID_CO_DateLabel = [];
                            PT_OD_ID_DateLabel = [], PT_OD_RN_DateLabel = [], PT_OD_CY_DateLabel = [], PT_OD_PP_DateLabel = [], PT_OD_CO_DateLabel = [];
                            PT_BL_TN_DateLabel = [], PT_BL_PL_DateLabel = [], PT_BL_PP_DateLabel = [];
                            PT_HE_HE_DateLabel = [], PT_HE_PL_DateLabel = [];

                            PT_ID_ID_MQMax = [], PT_ID_ID_MQMin = [], PT_ID_ID_UCL = [], PT_ID_ID_CL = [], PT_ID_ID_LCL = [];
                            PT_ID_RN_MQMax = [], PT_ID_RN_MQMin = [], PT_ID_RN_UCL = [], PT_ID_RN_CL = [], PT_ID_RN_LCL = [];
                            PT_ID_CY_MQMax = [], PT_ID_CY_MQMin = [], PT_ID_CY_UCL = [], PT_ID_CY_CL = [], PT_ID_CY_LCL = [];
                            PT_ID_PP_MQMax = [], PT_ID_PP_MQMin = [], PT_ID_PP_UCL = [], PT_ID_PP_CL = [], PT_ID_PP_LCL = [];
                            PT_ID_CO_MQMax = [], PT_ID_CO_MQMin = [], PT_ID_CO_UCL = [], PT_ID_CO_CL = [], PT_ID_CO_LCL = [];

                            PT_OD_ID_MQMax = [], PT_OD_ID_MQMin = [], PT_OD_ID_UCL = [], PT_OD_ID_CL = [], PT_OD_ID_LCL = [];
                            PT_OD_RN_MQMax = [], PT_OD_RN_MQMin = [], PT_OD_RN_UCL = [], PT_OD_RN_CL = [], PT_OD_RN_LCL = [];
                            PT_OD_CY_MQMax = [], PT_OD_CY_MQMin = [], PT_OD_CY_UCL = [], PT_OD_CY_CL = [], PT_OD_CY_LCL = [];
                            PT_OD_PP_MQMax = [], PT_OD_PP_MQMin = [], PT_OD_PP_UCL = [], PT_OD_PP_CL = [], PT_OD_PP_LCL = [];
                            PT_OD_CO_MQMax = [], PT_OD_CO_MQMin = [], PT_OD_CO_UCL = [], PT_OD_CO_CL = [], PT_OD_CO_LCL = [];

                            PT_BL_TN_MQMax = [], PT_BL_TN_MQMin = [], PT_BL_TN_UCL = [], PT_BL_TN_CL = [], PT_BL_TN_LCL = [];
                            PT_BL_PL_MQMax = [], PT_BL_PL_MQMin = [], PT_BL_PL_UCL = [], PT_BL_PL_CL = [], PT_BL_PL_LCL = [];
                            PT_BL_PP_MQMax = [], PT_BL_PP_MQMin = [], PT_BL_PP_UCL = [], PT_BL_PP_CL = [], PT_BL_PP_LCL = [];

                            PT_HE_HE_MQMax = [], PT_HE_HE_MQMin = [], PT_HE_HE_UCL = [], PT_HE_HE_CL = [], PT_HE_HE_LCL = [];
                            PT_HE_PL_MQMax = [], PT_HE_PL_MQMin = [], PT_HE_PL_UCL = [], PT_HE_PL_CL = [], PT_HE_PL_LCL = [];

                            pt_id_rank = [];
                            pt_id_roundness = [];
                            pt_id_cylindricity = [];
                            pt_id_perpendicularity = [];
                            pt_id_concentricity = [];
                            pt_od_rank = [];
                            pt_od_judge_roundness = [];
                            pt_od_cylindricity = [];
                            pt_od_perpendicularity = [];
                            pt_bl_rank = [];
                            pt_bl_parallism = [];
                            pt_bl_perpendicularity = [];
                            pt_he_rank = [];
                            pt_he_parallism = [];


                            for (i = 0; i < data.ListOfPT.length; i++) {
                                //PT_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                if (data.ListOfPT[i].MainPoint == "ID") {
                                    if (data.ListOfPT[i].SubPoint == "ID") {
                                        PT_ID_ID_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_ID_ID_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_ID_ID_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_ID_ID_UCL.push(data.ListOfPT[i].UCL);
                                        PT_ID_ID_CL.push(data.ListOfPT[i].CL);
                                        PT_ID_ID_LCL.push(data.ListOfPT[i].LCL);
                                        pt_id_rank.push(data.ListOfPT[i].pt_id_rank);
                                    } else if (data.ListOfPT[i].SubPoint == "Roundness") {
                                        PT_ID_RN_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_ID_RN_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_ID_RN_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_ID_RN_UCL.push(data.ListOfPT[i].UCL);
                                        PT_ID_RN_CL.push(data.ListOfPT[i].CL);
                                        PT_ID_RN_LCL.push(data.ListOfPT[i].LCL);
                                        pt_id_roundness.push(data.ListOfPT[i].pt_id_roundness);
                                    } else if (data.ListOfPT[i].SubPoint == "Cylindricity") {
                                        PT_ID_CY_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_ID_CY_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_ID_CY_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_ID_CY_UCL.push(data.ListOfPT[i].UCL);
                                        PT_ID_CY_CL.push(data.ListOfPT[i].CL);
                                        PT_ID_CY_LCL.push(data.ListOfPT[i].LCL);
                                        pt_id_cylindricity.push(data.ListOfPT[i].pt_id_cylindricity);
                                    } else if (data.ListOfPT[i].SubPoint == "Perpan") {
                                        PT_ID_PP_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_ID_PP_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_ID_PP_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_ID_PP_UCL.push(data.ListOfPT[i].UCL);
                                        PT_ID_PP_CL.push(data.ListOfPT[i].CL);
                                        PT_ID_PP_LCL.push(data.ListOfPT[i].LCL);
                                        pt_id_perpendicularity.push(data.ListOfPT[i].pt_id_perpendicularity);
                                    } else if (data.ListOfPT[i].SubPoint == "Concentric") {
                                        PT_ID_CO_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_ID_CO_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_ID_CO_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_ID_CO_UCL.push(data.ListOfPT[i].UCL);
                                        PT_ID_CO_CL.push(data.ListOfPT[i].CL);
                                        PT_ID_CO_LCL.push(data.ListOfPT[i].LCL);
                                        pt_id_concentricity.push(data.ListOfPT[i].pt_id_concentricity);
                                    }
                                } else if (data.ListOfPT[i].MainPoint == "OD") {
                                    if (data.ListOfPT[i].SubPoint == "ID") {
                                        PT_OD_ID_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_OD_ID_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_OD_ID_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_OD_ID_UCL.push(data.ListOfPT[i].UCL);
                                        PT_OD_ID_CL.push(data.ListOfPT[i].CL);
                                        PT_OD_ID_LCL.push(data.ListOfPT[i].LCL);
                                        pt_od_rank.push(data.ListOfPT[i].pt_od_rank);
                                    } else if (data.ListOfPT[i].SubPoint == "Roundness") {
                                        PT_OD_RN_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_OD_RN_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_OD_RN_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_OD_RN_UCL.push(data.ListOfPT[i].UCL);
                                        PT_OD_RN_CL.push(data.ListOfPT[i].CL);
                                        PT_OD_RN_LCL.push(data.ListOfPT[i].LCL);
                                        pt_od_judge_roundness.push(data.ListOfPT[i].pt_od_judge_roundness);
                                    } else if (data.ListOfPT[i].SubPoint == "Cylindricity") {
                                        PT_OD_CY_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_OD_CY_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_OD_CY_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_OD_CY_UCL.push(data.ListOfPT[i].UCL);
                                        PT_OD_CY_CL.push(data.ListOfPT[i].CL);
                                        PT_OD_CY_LCL.push(data.ListOfPT[i].LCL);
                                        pt_od_cylindricity.push(data.ListOfPT[i].pt_od_cylindricity);
                                    } else if (data.ListOfPT[i].SubPoint == "Perpan") {
                                        PT_OD_PP_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_OD_PP_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_OD_PP_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_OD_PP_UCL.push(data.ListOfPT[i].UCL);
                                        PT_OD_PP_CL.push(data.ListOfPT[i].CL);
                                        PT_OD_PP_LCL.push(data.ListOfPT[i].LCL);
                                        pt_od_perpendicularity.push(data.ListOfPT[i].pt_od_perpendicularity);
                                    }
                                } else if (data.ListOfPT[i].MainPoint == "HEIGHT") {
                                    if (data.ListOfPT[i].SubPoint == "Height") {
                                        PT_HE_HE_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_HE_HE_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_HE_HE_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_HE_HE_UCL.push(data.ListOfPT[i].UCL);
                                        PT_HE_HE_CL.push(data.ListOfPT[i].CL);
                                        PT_HE_HE_LCL.push(data.ListOfPT[i].LCL);
                                        pt_he_rank.push(data.ListOfPT[i].pt_he_rank);
                                    } else if (data.ListOfPT[i].SubPoint == "Parallel") {
                                        PT_HE_PL_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_HE_PL_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_HE_PL_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_HE_PL_UCL.push(data.ListOfPT[i].UCL);
                                        PT_HE_PL_CL.push(data.ListOfPT[i].CL);
                                        PT_HE_PL_LCL.push(data.ListOfPT[i].LCL);
                                        pt_he_parallism.push(data.ListOfPT[i].pt_he_parallism);
                                    }
                                } else if (data.ListOfPT[i].MainPoint == "BLADE") {
                                    if (data.ListOfPT[i].SubPoint == "Thickness") {
                                        PT_BL_TN_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_BL_TN_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_BL_TN_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_BL_TN_UCL.push(data.ListOfPT[i].UCL);
                                        PT_BL_TN_CL.push(data.ListOfPT[i].CL);
                                        PT_BL_TN_LCL.push(data.ListOfPT[i].LCL);
                                        pt_bl_rank.push(data.ListOfPT[i].pt_bl_rank);
                                    } else if (data.ListOfPT[i].SubPoint == "Parallel") {
                                        PT_BL_PL_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_BL_PL_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_BL_PL_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_BL_PL_UCL.push(data.ListOfPT[i].UCL);
                                        PT_BL_PL_CL.push(data.ListOfPT[i].CL);
                                        PT_BL_PL_LCL.push(data.ListOfPT[i].LCL);
                                        pt_bl_parallism.push(data.ListOfPT[i].pt_bl_parallism);
                                    } else if (data.ListOfPT[i].SubPoint == "Perpan") {
                                        PT_BL_PP_DateLabel.push(data.ListOfPT[i].first_stamptime);
                                        PT_BL_PP_MQMax.push(data.ListOfPT[i].MQMax);
                                        PT_BL_PP_MQMin.push(data.ListOfPT[i].MQMin);
                                        PT_BL_PP_UCL.push(data.ListOfPT[i].UCL);
                                        PT_BL_PP_CL.push(data.ListOfPT[i].CL);
                                        PT_BL_PP_LCL.push(data.ListOfPT[i].LCL);
                                        pt_bl_perpendicularity.push(data.ListOfPT[i].pt_bl_perpendicularity);
                                    }
                                }


                            }

                            LoadGraphPT();

                        },
                        error: function (e) {
                            alert(DatePDStart + ' ' + DatePDEnd);
                        }
                    });

                }


                var CY_BO_ID_DateLabel = [], CY_BO_RN_DateLabel = [], CY_BO_CY_DateLabel = [], CY_BO_PP_DateLabel = [], CY_BO_CO_DateLabel = [];
                var CY_HE_ID_DateLabel = [], CY_HE_RN_DateLabel = [], CY_HE_PL_DateLabel = [];

                var CY_BO_ID_MQMax = [], CY_BO_ID_MQMin = [], CY_BO_ID_UCL = [], CY_BO_ID_CL = [], CY_BO_ID_LCL = [];
                var CY_BO_RN_MQMax = [], CY_BO_RN_MQMin = [], CY_BO_RN_UCL = [], CY_BO_RN_CL = [], CY_BO_RN_LCL = [];
                var CY_BO_CY_MQMax = [], CY_BO_CY_MQMin = [], CY_BO_CY_UCL = [], CY_BO_CY_CL = [], CY_BO_CY_LCL = [];
                var CY_BO_PP_MQMax = [], CY_BO_PP_MQMin = [], CY_BO_PP_UCL = [], CY_BO_PP_CL = [], CY_BO_PP_LCL = [];
                var CY_BO_CO_MQMax = [], CY_BO_CO_MQMin = [], CY_BO_CO_UCL = [], CY_BO_CO_CL = [], CY_BO_CO_LCL = [];
                var CY_HE_HE_MQMax = [], CY_HE_HE_MQMin = [], CY_HE_HE_UCL = [], CY_HE_HE_CL = [], CY_HE_HE_LCL = [];
                var CY_HE_PL_MQMax = [], CY_HE_PL_MQMin = [], CY_HE_PL_UCL = [], CY_HE_PL_CL = [], CY_HE_PL_LCL = [];
                var cy_bo_rank = [];
                var cy_bo_judge_roundness = [];
                var cy_bo_cylindricity = [];
                var cy_bo_perpendicularity = [];
                var cy_bo_concentricity = [];
                var cy_he_rank = [];
                var cy_he_parallism = [];

                function LoadDataCY() {
                    $.ajax({
                        url: "GetGraphDataCY.ashx?DateStart=" + DatePDStart + "&DateEnd=" + DatePDEnd + "&RowsQty=2000",
                        dataType: "json",
                        async: true,
                        success: function (data) {


                            CY_BO_ID_DateLabel = [], CY_BO_RN_DateLabel = [], CY_BO_CY_DateLabel = [], CY_BO_PP_DateLabel = [], CY_BO_CO_DateLabel = [];
                            CY_HE_HE_DateLabel = [], CY_HE_RN_DateLabel = [], CY_HE_PL_DateLabel = [];

                            CY_BO_ID_MQMax = [], CY_BO_ID_MQMin = [], CY_BO_ID_UCL = [], CY_BO_ID_CL = [], CY_BO_ID_LCL = [];
                            CY_BO_RN_MQMax = [], CY_BO_RN_MQMin = [], CY_BO_RN_UCL = [], CY_BO_RN_CL = [], CY_BO_RN_LCL = [];
                            CY_BO_CY_MQMax = [], CY_BO_CY_MQMin = [], CY_BO_CY_UCL = [], CY_BO_CY_CL = [], CY_BO_CY_LCL = [];
                            CY_BO_PP_MQMax = [], CY_BO_PP_MQMin = [], CY_BO_PP_UCL = [], CY_BO_PP_CL = [], CY_BO_PP_LCL = [];
                            CY_BO_CO_MQMax = [], CY_BO_CO_MQMin = [], CY_BO_CO_UCL = [], CY_BO_CO_CL = [], CY_BO_CO_LCL = [];
                            CY_HE_HE_MQMax = [], CY_HE_HE_MQMin = [], CY_HE_HE_UCL = [], CY_HE_HE_CL = [], CY_HE_HE_LCL = [];
                            CY_HE_PL_MQMax = [], CY_HE_PL_MQMin = [], CY_HE_PL_UCL = [], CY_HE_PL_CL = [], CY_HE_PL_LCL = [];
                            cy_bo_rank = [];
                            cy_bo_judge_roundness = [];
                            cy_bo_cylindricity = [];
                            cy_bo_perpendicularity = [];
                            cy_bo_concentricity = [];
                            cy_he_rank = [];
                            cy_he_parallism = [];


                            for (i = 0; i < data.ListOfCY.length; i++) {
                                //RH_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                if (data.ListOfCY[i].MainPoint == "BORE") {
                                    if (data.ListOfCY[i].SubPoint == "ID") {
                                        CY_BO_ID_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                        CY_BO_ID_MQMax.push(data.ListOfCY[i].MQMax);
                                        CY_BO_ID_MQMin.push(data.ListOfCY[i].MQMin);
                                        CY_BO_ID_UCL.push(data.ListOfCY[i].UCL);
                                        CY_BO_ID_CL.push(data.ListOfCY[i].CL);
                                        CY_BO_ID_LCL.push(data.ListOfCY[i].LCL);
                                        cy_bo_rank.push(data.ListOfCY[i].cy_bo_rank);
                                    } else if (data.ListOfCY[i].SubPoint == "Roundness") {
                                        CY_BO_RN_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                        CY_BO_RN_MQMax.push(data.ListOfCY[i].MQMax);
                                        CY_BO_RN_MQMin.push(data.ListOfCY[i].MQMin);
                                        CY_BO_RN_UCL.push(data.ListOfCY[i].UCL);
                                        CY_BO_RN_CL.push(data.ListOfCY[i].CL);
                                        CY_BO_RN_LCL.push(data.ListOfCY[i].LCL);
                                        cy_bo_judge_roundness.push(data.ListOfCY[i].cy_bo_judge_roundness);
                                    } else if (data.ListOfCY[i].SubPoint == "Cylindricity") {
                                        CY_BO_CY_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                        CY_BO_CY_MQMax.push(data.ListOfCY[i].MQMax);
                                        CY_BO_CY_MQMin.push(data.ListOfCY[i].MQMin);
                                        CY_BO_CY_UCL.push(data.ListOfCY[i].UCL);
                                        CY_BO_CY_CL.push(data.ListOfCY[i].CL);
                                        CY_BO_CY_LCL.push(data.ListOfCY[i].LCL);
                                        cy_bo_cylindricity.push(data.ListOfCY[i].cy_bo_cylindricity);
                                    } else if (data.ListOfCY[i].SubPoint == "Perpan") {
                                        CY_BO_PP_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                        CY_BO_PP_MQMax.push(data.ListOfCY[i].MQMax);
                                        CY_BO_PP_MQMin.push(data.ListOfCY[i].MQMin);
                                        CY_BO_PP_UCL.push(data.ListOfCY[i].UCL);
                                        CY_BO_PP_CL.push(data.ListOfCY[i].CL);
                                        CY_BO_PP_LCL.push(data.ListOfCY[i].LCL);
                                        cy_bo_perpendicularity.push(data.ListOfCY[i].cy_bo_perpendicularity);
                                    } else if (data.ListOfCY[i].SubPoint == "Concentric") {
                                        CY_BO_CO_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                        CY_BO_CO_MQMax.push(data.ListOfCY[i].MQMax);
                                        CY_BO_CO_MQMin.push(data.ListOfCY[i].MQMin);
                                        CY_BO_CO_UCL.push(data.ListOfCY[i].UCL);
                                        CY_BO_CO_CL.push(data.ListOfCY[i].CL);
                                        CY_BO_CO_LCL.push(data.ListOfCY[i].LCL);
                                        cy_bo_concentricity.push(data.ListOfCY[i].cy_bo_concentricity);
                                    }
                                } else if (data.ListOfCY[i].MainPoint == "HEIGHT") {
                                    if (data.ListOfCY[i].SubPoint == "Height") {
                                        CY_HE_HE_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                        CY_HE_HE_MQMax.push(data.ListOfCY[i].MQMax);
                                        CY_HE_HE_MQMin.push(data.ListOfCY[i].MQMin);
                                        CY_HE_HE_UCL.push(data.ListOfCY[i].UCL);
                                        CY_HE_HE_CL.push(data.ListOfCY[i].CL);
                                        CY_HE_HE_LCL.push(data.ListOfCY[i].LCL);
                                        cy_he_rank.push(data.ListOfCY[i].cy_he_rank);
                                    } else if (data.ListOfCY[i].SubPoint == "Parallel") {
                                        CY_HE_PL_DateLabel.push(data.ListOfCY[i].first_stamptime);
                                        CY_HE_PL_MQMax.push(data.ListOfCY[i].MQMax);
                                        CY_HE_PL_MQMin.push(data.ListOfCY[i].MQMin);
                                        CY_HE_PL_UCL.push(data.ListOfCY[i].UCL);
                                        CY_HE_PL_CL.push(data.ListOfCY[i].CL);
                                        CY_HE_PL_LCL.push(data.ListOfCY[i].LCL);
                                        cy_he_parallism.push(data.ListOfCY[i].cy_he_parallism);
                                    }
                                }


                            }

                            LoadGraphCY();

                        },
                        error: function (e) {
                            alert(DatePDStart + ' ' + DatePDEnd);
                        }
                    });

                }


                // ****************** Graph Function *********************

                function LoadGraphFH() {
                    // ************ ID ***************
                    Highcharts.chart('FHIDID', {

                        title: {
                            text: 'Front Head ID ID'
                        }
            ,
                        xAxis: {
                            categories: FH_ID_DateLabel
                        }
            ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: FH_ID_UCL[0] + 0.0030 // ************
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }

                            }, line: {
                                turboThreshold: 0
                            }
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: fh_id1,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: FH_ID_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'LCL',
                            color: '#FF5733',
                            data: FH_ID_LCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: FH_ID_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: FH_ID_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMin',
                            color: '#FF0000',
                            data: FH_ID_MQMin,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });
                    // #ff0000


                    // ************** Roundness ******************
                    Highcharts.chart('FHIDRoundness', {

                        title: {
                            text: 'Front Head ID Roundness'
                        }
                        ,
                        xAxis: {
                            categories: FH_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: FH_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: fh_judge_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: FH_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: FH_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: FH_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMin',
                            color: '#FF0000',
                            data: FH_RN_MQMin,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    // **************** Cylindricity *********************
                    Highcharts.chart('FHIDCylindricity', { // ***************** Edit name of div tag.

                        title: {
                            text: 'Front Head ID Cylindricity' // ***************** edit name of graph
                        }
                        ,
                        xAxis: {
                            categories: FH_CY_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: FH_CY_UCL[0] + 0.0030 // ***************** edit max of yAxis
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: fh_cylindricity, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: FH_CY_UCL, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: FH_CY_CL, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: FH_CY_MQMax, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    // **************** Perpen *********************
                    Highcharts.chart('FHIDPerpan', { // ***************** Edit name of div tag.

                        title: {
                            text: 'Front Head ID Perpan' // ***************** edit name of graph
                        }
                        ,
                        xAxis: {
                            categories: FH_PP_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: FH_PP_UCL[0] + 0.0030 // ***************** edit max of yAxis
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: fh_perpendicularity, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: FH_PP_UCL, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: FH_PP_CL, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: FH_PP_MQMax, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    // **************** Concentric *********************
                    //Highcharts.chart('FHIDConcentric', { // ***************** Edit name of div tag.

                    //    title: {
                    //        text: 'Front Head ID Concentric' // ***************** edit name of graph
                    //    }
                    //    ,
                    //    xAxis: {
                    //        categories: FH_CO_DateLabel
                    //    }
                    //    ,
                    //    yAxis: {
                    //        title: {
                    //            text: 'Actual',
                    //            style: {
                    //                color: '#000000'
                    //            }
                    //        },
                    //        labels: {
                    //            format: '{value}',
                    //            style: {
                    //                color: '#000000'
                    //            }
                    //        },
                    //        tickInterval: 0.0010,
                    //        gridLineWidth: 0,
                    //        max: FH_CO_UCL[0] + 0.0030 // ***************** edit max of yAxis
                    //    },
                    //    plotOptions: {
                    //        series: {
                    //            label: {
                    //                connectorAllowed: false
                    //            }
                    //        },
                    //        turboThreshold: 0
                    //    },
                    //    tooltip: {
                    //        shared: true,
                    //        useHTML: true,
                    //        headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                    //        pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                    //        footerFormat: '</table>',
                    //        valueDecimals: 4
                    //    },
                    //    legend: {
                    //        align: 'right',
                    //        x: -90,
                    //        verticalAlign: 'top',
                    //        y: 25,
                    //        floating: true,
                    //        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                    //        borderColor: '#ffffff',
                    //        borderWidth: 1,
                    //        shadow: false
                    //    },
                    //    series: [{
                    //        name: 'Actual',
                    //        color: '#1efff3',
                    //        data: fh_concentricity, // ***************** edit to field of Point type
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        dataLabels: {
                    //            enabled: false,
                    //            color: '#ffffff'
                    //        },
                    //        marker: {
                    //            enabled: false
                    //        }
                    //    }, {
                    //        name: 'UCL',
                    //        color: '#FF5733',
                    //        data: FH_CO_UCL, // ***************** edit to field of Point type
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        marker: {
                    //            enabled: false
                    //        }
                    //        //marker: false
                    //    }, {
                    //        name: 'CL',
                    //        color: '#C608CC',
                    //        data: FH_CO_CL, // ***************** edit to field of Point type
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        marker: {
                    //            enabled: false
                    //        }
                    //        //marker: false
                    //    }, {
                    //        name: 'MQMax',
                    //        color: '#FF0000',
                    //        data: FH_CO_MQMax, // ***************** edit to field of Point type
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        marker: {
                    //            enabled: false
                    //        }
                    //        //marker: false
                    //    }]
                    //});




                }

                function LoadGraphRH() {
                    // ************** Roundness ******************
                    Highcharts.chart('RHRoundness', {

                        title: {
                            text: 'Rear Head Roundness'
                        }
                        ,
                        xAxis: {
                            categories: RH_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: RH_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: rh_judge_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: RH_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: RH_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: RH_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    // **************** Perpen *********************
                    Highcharts.chart('RHPerpan', { // ***************** Edit name of div tag.

                        title: {
                            text: 'Rear Head Perpan' // ***************** edit name of graph
                        }
                        ,
                        xAxis: {
                            categories: RH_PP_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: RH_PP_UCL[0] + 0.0030 // ***************** edit max of yAxis
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: rh_perpendicularity, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: RH_PP_UCL, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: RH_PP_CL, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: RH_PP_MQMax, // ***************** edit to field of Point type
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                }

                function LoadGraphCS() {
                    // ************** Roundness ******************
                    Highcharts.chart('CSFODRoundness', {

                        title: {
                            text: 'Crank Shaft FOD Roundness'
                        }
                        ,
                        xAxis: {
                            categories: CS_F_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: CS_F_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: cs_fr_f_judge_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: CS_F_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: CS_F_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: CS_F_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });

                    // ************** Roundness ******************
                    Highcharts.chart('CSRODRoundness', {

                        title: {
                            text: 'Crank Shaft ROD Roundness'
                        }
                        ,
                        xAxis: {
                            categories: CS_R_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: CS_R_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: cs_fr_r_judge_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: CS_R_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: CS_R_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: CS_R_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });

                    // ************** Roundness ******************
                    Highcharts.chart('CSPINRoundness', {

                        title: {
                            text: 'Crank Shaft PIN Roundness'
                        }
                        ,
                        xAxis: {
                            categories: CS_P_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: CS_P_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: cs_pin_judge_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: CS_P_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: CS_P_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: CS_P_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });



                }

                function LoadGraphPT() {
                    // ************** ID ******************
                    Highcharts.chart('PTIDRoundness', {

                        title: {
                            text: 'Piston ID Roundness'
                        }
                        ,
                        xAxis: {
                            categories: PT_ID_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: PT_ID_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: pt_id_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: PT_ID_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: PT_ID_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: PT_ID_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });

                    Highcharts.chart('PTIDPerpan', {

                        title: {
                            text: 'Piston ID Perpan'
                        }
                        ,
                        xAxis: {
                            categories: PT_ID_PP_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0005,
                            gridLineWidth: 0,
                            max: PT_ID_PP_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: pt_id_perpendicularity,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: PT_ID_PP_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: PT_ID_PP_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: PT_ID_PP_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    // ************** OD ******************
                    Highcharts.chart('PTODRoundness', {

                        title: {
                            text: 'Piston OD Roundness'
                        }
                        ,
                        xAxis: {
                            categories: PT_OD_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: PT_OD_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: pt_od_judge_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: PT_OD_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: PT_OD_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: PT_OD_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });

                    Highcharts.chart('PTODPerpan', {

                        title: {
                            text: 'Piston OD Perpan'
                        }
                        ,
                        xAxis: {
                            categories: PT_OD_PP_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: PT_OD_PP_UCL[0] + 0.0030,
                            min: PT_OD_PP_CL[0] - 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: pt_od_perpendicularity,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: PT_OD_PP_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: PT_OD_PP_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: PT_OD_PP_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    // ************** BLADE ******************
                    Highcharts.chart('PTBladePerpan', {

                        title: {
                            text: 'Piston Blade Perpan'
                        }
                        ,
                        xAxis: {
                            categories: PT_BL_PP_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0005,
                            gridLineWidth: 0,
                            max: PT_BL_PP_UCL[0] + 0.0030,
                            min: PT_BL_PP_CL[0] - 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: pt_bl_perpendicularity,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: PT_BL_PP_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: PT_BL_PP_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: PT_BL_PP_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });

                    Highcharts.chart('PTBladeParallel', {

                        title: {
                            text: 'Piston Blade Parallel'
                        }
                        ,
                        xAxis: {
                            categories: PT_BL_PL_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: PT_BL_PL_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: pt_bl_parallism,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: PT_BL_PL_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: PT_BL_PL_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: PT_BL_PL_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    // ************** Height ******************
                    Highcharts.chart('PTHeightParallel', {

                        title: {
                            text: 'Piston Height Parallel'
                        }
                        ,
                        xAxis: {
                            categories: PT_HE_PL_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: PT_HE_PL_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: pt_he_parallism,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: PT_HE_PL_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: PT_HE_PL_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: PT_HE_PL_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });

                }

                function LoadGraphCY() {
                    Highcharts.chart('CYBORoundness', {

                        title: {
                            text: 'Cylinder Bore Roundness'
                        }
                        ,
                        xAxis: {
                            categories: CY_BO_RN_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: CY_BO_RN_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: cy_bo_judge_roundness,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: CY_BO_RN_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: CY_BO_RN_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: CY_BO_RN_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });


                    Highcharts.chart('CYBOPerpan', {

                        title: {
                            text: 'Cylinder Bore Perpan'
                        }
                        ,
                        xAxis: {
                            categories: CY_BO_PP_DateLabel
                        }
                        ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: CY_BO_PP_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: cy_bo_perpendicularity,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: CY_BO_PP_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: CY_BO_PP_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: CY_BO_PP_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });



                    Highcharts.chart('CYHEPallaism', {

                        title: {
                            text: 'Cylinder Height Pallaism'
                        }
                       ,
                        xAxis: {
                            categories: CY_HE_PL_DateLabel
                        }
                       ,
                        yAxis: {
                            title: {
                                text: 'Actual',
                                style: {
                                    color: '#000000'
                                }
                            },
                            labels: {
                                format: '{value: point.y .4f}',
                                style: {
                                    color: '#000000'
                                }
                            },
                            tickInterval: 0.0010,
                            gridLineWidth: 0,
                            max: CY_HE_PL_UCL[0] + 0.0030
                        },
                        plotOptions: {
                            series: {
                                label: {
                                    connectorAllowed: false
                                }
                            },
                            turboThreshold: 0
                        },
                        tooltip: {
                            shared: true,
                            useHTML: true,
                            headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                            pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                            footerFormat: '</table>',
                            valueDecimals: 4
                        },
                        legend: {
                            align: 'right',
                            x: -90,
                            verticalAlign: 'top',
                            y: 25,
                            floating: true,
                            backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                            borderColor: '#ffffff',
                            borderWidth: 1,
                            shadow: false
                        },
                        series: [{
                            name: 'Actual',
                            color: '#1efff3',
                            data: cy_he_parallism,
                            type: 'line',
                            lineWidth: 2,
                            dataLabels: {
                                enabled: false,
                                color: '#ffffff'
                            },
                            marker: {
                                enabled: false
                            }
                        }, {
                            name: 'UCL',
                            color: '#FF5733',
                            data: CY_HE_PL_UCL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'CL',
                            color: '#C608CC',
                            data: CY_HE_PL_CL,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }, {
                            name: 'MQMax',
                            color: '#FF0000',
                            data: CY_HE_PL_MQMax,
                            type: 'line',
                            lineWidth: 2,
                            marker: {
                                enabled: false
                            }
                            //marker: false
                        }]
                    });

                    //Highcharts.chart('CYBURoundness', {

                    //    title: {
                    //        text: 'Cylinder Bush Roundness'
                    //    }
                    //    ,
                    //    xAxis: {
                    //        categories: CY_BU_RN_DateLabel
                    //    }
                    //    ,
                    //    yAxis: {
                    //        title: {
                    //            text: 'Actual',
                    //            style: {
                    //                color: '#000000'
                    //            }
                    //        },
                    //        labels: {
                    //            format: '{value}',
                    //            style: {
                    //                color: '#000000'
                    //            }
                    //        },
                    //        tickInterval: 0.0010,
                    //        gridLineWidth: 0,
                    //        max: CY_BU_RN_UCL[0] + 0.0030
                    //    },
                    //    plotOptions: {
                    //        series: {
                    //            label: {
                    //                connectorAllowed: false
                    //            }
                    //        },
                    //        turboThreshold: 0
                    //    },
                    //    tooltip: {
                    //        shared: true,
                    //        useHTML: true,
                    //        headerFormat: '<p style="font-weight:bold">{point.key} 1</p><table>',
                    //        pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right;color: {series.color};"><b> {point.y} micron</b></td></tr>',
                    //        footerFormat: '</table>',
                    //        valueDecimals: 4
                    //    },
                    //    legend: {
                    //        align: 'right',
                    //        x: -90,
                    //        verticalAlign: 'top',
                    //        y: 25,
                    //        floating: true,
                    //        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                    //        borderColor: '#ffffff',
                    //        borderWidth: 1,
                    //        shadow: false
                    //    },
                    //    series: [{
                    //        name: 'Actual',
                    //        color: '#1efff3',
                    //        data: cy_bu,
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        dataLabels: {
                    //            enabled: false,
                    //            color: '#ffffff'
                    //        },
                    //        marker: {
                    //            enabled: false
                    //        }
                    //    }, {
                    //        name: 'UCL',
                    //        color: '#FF5733',
                    //        data: CY_BO_RN_UCL,
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        marker: {
                    //            enabled: false
                    //        }
                    //        //marker: false
                    //    }, {
                    //        name: 'CL',
                    //        color: '#C608CC',
                    //        data: CY_BO_RN_CL,
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        marker: {
                    //            enabled: false
                    //        }
                    //        //marker: false
                    //    }, {
                    //        name: 'MQMax',
                    //        color: '#FF0000',
                    //        data: CY_BO_RN_MQMax,
                    //        type: 'line',
                    //        lineWidth: 2,
                    //        marker: {
                    //            enabled: false
                    //        }
                    //        //marker: false
                    //    }]
                    //});
                    

                }

            </script>



            <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
            <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
        </div>

        <script src="<%= ResolveUrl("~/StyleMax/js/moment.js") %>"></script>
        <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-datepicker.js") %>"></script>
    </form>
</body>
</html>
