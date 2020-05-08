<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Efficiency_Report2.aspx.cs" Inherits="Efficiency_Report2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Productivity</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <!-- styles -->
    <link href="~/css/bootstrap.css" rel="stylesheet" />
    <link href="~/css/font-alpona.css" rel="stylesheet" />
    <link href="~/css/prettify.css" rel="stylesheet" />
    <link href="~/css/responsive-tables.css" rel="stylesheet" />
    <link href="~/css/styles.css" rel="stylesheet" />
    <link href="~/css/bootstrap-reset.css" rel="stylesheet" />
    <link href="~/css/highcharts.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.min.js"></script>
    <link href="css/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="js/datatables/datatables.css" rel="stylesheet" />
    <script type="text/javascript" src="js/datatables.js"></script>

    

    <script type="text/javascript" src="Highcharts/highcharts.js"></script>

    <%--<script type="text/javascript" src="<%= ResolveUrl("~/js/jquery.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/bootstrap.min.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/MasterOffsetDetail.js") %>"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~/js/jquery-ui-1.10.3.custom.min.js") %>"></script>--%>
</head>
<body>
    <script type='text/javascript'>
        function Number2digit(Number) {
            var Num2digit = Number;
            if (Number < 10) {
                Num2digit = "0" + Number;
            }
            return Num2digit;
        }

        $(document).ready(function () {
            var url = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=main&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url2 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=mecha&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url3 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=casing&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url4 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=motor&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url5 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=piston&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url6 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=fh&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url7 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=cs&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url8 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=cd&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url9 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=rh&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';
            var url10 = 'Production/SourcJson.ashx?CycleTime=300&Fac=&Line=fn&Mac=&ModelCode=&strDate=&endDate=&target=&create=YES';

            $.ajax({ url: url, dataType: 'json', async: true, success: function (data) { console.log("Main OK"); } });
            $.ajax({ url: url2, dataType: 'json', async: true, success: function (data) { console.log("Mecha OK"); } });
            $.ajax({ url: url3, dataType: 'json', async: true, success: function (data) { console.log("Pipe OK"); } });
            $.ajax({ url: url4, dataType: 'json', async: true, success: function (data) { console.log("Motor OK"); } });
            $.ajax({ url: url5, dataType: 'json', async: true, success: function (data) { console.log("Piston OK"); } });
            $.ajax({ url: url6, dataType: 'json', async: true, success: function (data) { console.log("Front head OK"); } });
            $.ajax({ url: url7, dataType: 'json', async: true, success: function (data) { console.log("Crank shaft OK"); } });
            $.ajax({ url: url8, dataType: 'json', async: true, success: function (data) { console.log("Cylinder OK"); } });
            $.ajax({ url: url9, dataType: 'json', async: true, success: function (data) { console.log("Rear head OK"); } });
            $.ajax({ url: url10, dataType: 'json', async: true, success: function (data) { console.log("Final OK"); } });


            var DateNow = new Date();
            var HH = parseInt(DateNow.getHours()) >= 10 ? DateNow.getHours() : "0" + DateNow.getHours();
            var mm = DateNow.getMinutes() >= 10 ? DateNow.getMinutes() : "0" + DateNow.getMinutes();
            var ss = DateNow.getSeconds() >= 10 ? DateNow.getSeconds() : "0" + DateNow.getSeconds();
            var Timenow = Number2digit(DateNow.getDate()) + "/" + Number2digit(DateNow.getMonth() + 1) + "/" + DateNow.getFullYear() + " " + HH + ":" + mm + ":" + ss;            
            $("#update").text(Timenow);

            setInterval(function () {
                $.ajax({ url: url, dataType: 'json', async: true, success: function (data) { console.log("Main OK"); } });
                $.ajax({ url: url2, dataType: 'json', async: true, success: function (data) { console.log("Mecha OK"); } });
                $.ajax({ url: url3, dataType: 'json', async: true, success: function (data) { console.log("Pipe OK"); } });
                $.ajax({ url: url4, dataType: 'json', async: true, success: function (data) { console.log("Motor OK"); } });
                $.ajax({ url: url5, dataType: 'json', async: true, success: function (data) { console.log("Piston OK"); } });
                $.ajax({ url: url6, dataType: 'json', async: true, success: function (data) { console.log("Front head OK"); } });
                $.ajax({ url: url7, dataType: 'json', async: true, success: function (data) { console.log("Crank shaft OK"); } });
                $.ajax({ url: url8, dataType: 'json', async: true, success: function (data) { console.log("Cylinder OK"); } });
                $.ajax({ url: url9, dataType: 'json', async: true, success: function (data) { console.log("Rear head OK"); } });
                $.ajax({ url: url10, dataType: 'json', async: true, success: function (data) { console.log("Final OK"); } });

                var DateNow = new Date();
                var HH = parseInt(DateNow.getHours()) >= 10 ? DateNow.getHours() : "0" + DateNow.getHours();
                var mm = DateNow.getMinutes() >= 10 ? DateNow.getMinutes() : "0" + DateNow.getMinutes();
                var ss = DateNow.getSeconds() >= 10 ? DateNow.getSeconds() : "0" + DateNow.getSeconds();
                var Timenow = Number2digit(DateNow.getDate()) + "/" + Number2digit(DateNow.getMonth() + 1) + "/" + DateNow.getFullYear() + " " + HH + ":" + mm + ":" + ss;
                $("#update").text(Timenow);
            }, 900000);
        });
    </script>

    <style type="text/css">
        body, .main-warpper {
            padding: 0px;
            margin: 0px;
            background-color: #fff;
        }

        #container {
            margin-top: 0%;
        }

        #BoxEfficiency {
            display: none;
            position: absolute;
            z-index: 1000;
            top: 0px;
            right: 0px;
        }

        #BoxEfficiencyShow {            
            /*opacity:0.5;
            filter: alpha(opacity=50);*/
            position: absolute;
            z-index: 1000;
            top: 125px;
            left: 200px;
            width:auto;
            height:auto;
            color: rgb(0, 0, 0);
	        background-color: rgba(168, 223, 255, 0.7);
            vertical-align:middle;
            -webkit-border-radius:10px;
            -moz-border-radius:10px;
            border-radius:10px;
        }

        #eff{
            
            /*opacity:0.5;
            filter: alpha(opacity=50); /* For IE8 and earlier */
        }

        #BoxTime {
            position: absolute;
            z-index: 10000;
            top: 0px;
            left: 20px;
            color: #00a508;
        }

        #tbTime {
            border: 0;
            position: absolute;
            z-index: 10000;
        }

        #BoxDate {
            width: 600px;
            position: absolute;
            z-index: 1000;
            top: 0px;
            left: 30%;
        }

        #BoxSetting {
            display: none;
            position: absolute;
            z-index: 10000;
            top: 0px;
            left: 0px;
        }

        #tbstatus {
            width: 98%;
            border-top: solid;
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
        }

        .tbContent {
            /*width: 96%;*/
            border-top: 0;
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
        }

        #tbstatus td {
            padding: 1px !important;
            word-wrap: break-word;
            border-left: 1px;
            border-right: 1px;
            border-bottom: solid;
            border-top: solid;
        }

        .colcontent {
        }

        .headmc {
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
            border-top: solid;
            font-size: 10px;
        }

        .headone {
            border-left: solid;
            border-right: solid;
            border-bottom: solid;
            border-top: solid;
            text-align: center;
            font-size: 18px;
            font-weight: bold;
        }

        .padding {
            padding-left: 0cm;
        }

        .status {
            margin-left: 0cm;
        }

        .highchart {
            margin-left: 0cm;
            margin-right: 1.5cm;
        }

        #lbtitle {
            font-family: "Times New Roman", Times, serif;
            fill: #000000;
            font-weight: bold;
            font-size: 65px !important;
            text-align:center;
            letter-spacing: 0.2em;
        }

        .highcharts-title {
            display:none;
        }

        .highcharts-container {
            padding-left: 0px;
            padding-right: 400px;
            margin-left: 3%;
        }

        .highcharts-root {
            width: 90%;
        }

        .highcharts-yaxis .highcharts-axis-line {
            stroke-width: 5px;
        }

        .highcharts-color-0 {
            fill: #062ece;
            stroke: #062ece;
        }

        .highcharts-axis.highcharts-color-0 .highcharts-axis-line {
            stroke: #062ece;
        }

        .highcharts-axis.highcharts-color-0 text {
            fill: #062ece;
        }

        .highcharts-color-1 {
            fill: #960c07;
            stroke: #960c07;
        }

        .highcharts-axis.highcharts-color-1 .highcharts-axis-line {
            stroke: #960c07;
        }

        .highcharts-axis.highcharts-color-1 text {
            fill: #960c07;
        }

        hr {
            -moz-transform: rotate(30deg);  
            -o-transform: rotate(30deg);  
            -webkit-transform: rotate(30deg);  
            -ms-transform: rotate(30deg);  
            transform: rotate(30deg);  
            width:150%;
            margin-left:-15px;
            border:1px solid black;
        }
        #tbEffShow th, #tbEffShow td{
            padding:3px 5px !important;
        }
    </style>


    <div class="main-warpper">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <h1>Create Log Line Efficeincy Running</h1>
            <br />
            <h2><span id="update"></span></h2>
        </form>
    </div>
</body>
</html>

