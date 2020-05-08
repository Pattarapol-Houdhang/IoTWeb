<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="MenuHistoryData.aspx.cs" Inherits="DataHistory_MenuHistoryData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../StyleMax/js/jquery-1.8.3.min.js"></script>

    <script src="../../StyleMax/js/jquery.dataTables.min.js"></script>
    <script src="../../StyleMax/js/dataTables.buttons.min.js"></script>
    <script src="../../StyleMax/js/buttons.flash.min.js"></script>
    <script src="../../StyleMax/js/jszip.min.js"></script>
    <%--<script src="../../StyleMax/js/pdfmake.min.js"></script>--%>
    <script src="../../StyleMax/js/vfs_fonts.js"></script>
    <script src="../../StyleMax/js/buttons.html5.min.js"></script>
    <script src="../../StyleMax/js/buttons.print.min.js"></script>

    <link href="../../StyleMax/js/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../../StyleMax/js/buttons.dataTables.min.css" rel="stylesheet" />

    <script>
        function clickFactory(name) {

            var elements = document.getElementById(name);
            var elements1 = document.getElementById('fac1');
            var elements2 = document.getElementById('fac2');
            var elements3 = document.getElementById('fac3');
            var elements4 = document.getElementById('odm');
            elements1.className = "row collapse";
            elements2.className = "row collapse";
            elements3.className = "row collapse";
            elements4.className = "row collapse";
            elements.className = "row in";

        }
    </script>

    <style>
        .height_box {
            height: 185px;
        }

            .height_box a {
                position: absolute;
                bottom: 0;
                width: 80%;
                left: 50%;
                transform: translateX(-50%);
            }


        @media only screen and (max-width: 1343px) {
            .height_box .card-header h2 {
                font-size: 20px;
            }
            .height_box .btn-lg {
                font-size: 12px;
            }
        }
    </style>

    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DynamicLayout="false" DisplayAfter="0">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="../../StyleMax/icon/Gear-0.5s-200px.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <section class="wrapper">

                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>Select Factory & Line</h3>
                    </div>
                </div>

                <div class="row" style="margin-left: 10px;">

                    <div class="row">
                        <h3 class=""><b>Factory</b></h3>
                    </div>
                    <div class="row">

                        <div class="btn-group btn-group-lg">
                            <a href="#fac1" class="btn btn-primary" onclick="clickFactory('fac1');">Factory 1</a>
                            <a href="#fac2" class="btn btn-primary" onclick="clickFactory('fac2');">Factory 2</a>
                            <a href="#fac3" class="btn btn-primary" onclick="clickFactory('fac3');">Factory 3</a>
                            <a href="#odm" class="btn btn-primary" onclick="clickFactory('odm');">ODM</a>
                        </div>

                    </div>

                    <div class="row">
                        <h3 class=""><b>Production Line</b></h3>
                    </div>
                    <div id="fac1" class="row collapse ">
                       <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                           <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Mecha Line 1</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Mecha Line 1</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=1&ld_id=12" class="btn btn-lg btn-block btn-danger" target="_blank">Mecha Line 1</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Leak Check Common Line 1</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Leak Check Common Line 1</li>
                                    </ul>
                                    <a href="DataLeakcheck.aspx?ld_id=17&FactoryID=1" class="btn btn-lg btn-block btn-danger" target="_blank">Leak Check Common Line 1</a>
                                </div>
                            </div> 
                           <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Final Line 1</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Final Line 1</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=1&ld_id=30" class="btn btn-lg btn-block btn-danger" target="_blank">Final Line 1</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Final Line 2</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Final Line 2</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=1&ld_id=31" class="btn btn-lg btn-block btn-danger" target="_blank">Final Line 2</a>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div id="fac2" class="row collapse">
                        <%--<div class="btn-group">
                            <a href="HistoryData.aspx?FactoryID=2&ld_id=24" class="btn btn-lg btn-danger" target="_blank">Casing Pipe Line </a>
                            <a href="DataLeakcheck.aspx?ld_id=18&FactoryID=2" class="btn btn-lg btn-danger" target="_blank">Leak Check Common Line 3 </a>
                            <a href="DataLeakcheck.aspx?ld_id=19&FactoryID=2" class="btn btn-lg btn-danger" target="_blank">Leak Check Common Line 5 </a>
                            <a href="HistoryData.aspx?FactoryID=2&ld_id=23" class="btn btn-lg btn-danger" target="_blank">Main Assembly</a>
                            <a href="HistoryData.aspx?FactoryID=2&ld_id=27" class="btn btn-lg btn-danger" target="_blank">Final Line 3</a>
                            <a href="HistoryData.aspx?FactoryID=2&ld_id=22" class="btn btn-lg btn-danger" target="_blank">Final Scroll</a>
                            <a href="HistoryData.aspx?FactoryID=2&ld_id=28" class="btn btn-lg btn-danger" target="_blank">Final Line 5</a>
                        </div>--%>

                        <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Casing Pipe Line 3</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Casing Pipe Line 3</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=24" class="btn btn-lg btn-block btn-danger" target="_blank">Casing Pipe Line 3</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Casing Pipe Line 4</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Casing Pipe Line 4</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=36" class="btn btn-lg btn-block btn-danger" target="_blank">Casing Pipe Line 4</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Leak Check Common Line 3</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Leak Check Common Line 3</li>
                                    </ul>
                                    <a href="HistoryData.aspx?ld_id=18&FactoryID=2" class="btn btn-lg btn-block btn-danger" target="_blank">Leak Check Common Line 3</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Leak Check Common Line 5</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Leak Check Common Line 5</li>
                                    </ul>
                                    <a href="HistoryData.aspx?ld_id=19&FactoryID=2" class="btn btn-lg btn-block btn-danger" target="_blank">Leak Check Common Line 5</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Main Assembly Line 3</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Main Assembly Line 3</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=23" class="btn btn-lg btn-block btn-danger" target="_blank">Main Assembly Line 3</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Main Scroll Line 4</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Main Scroll Line 4</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=29" class="btn btn-lg btn-block btn-danger" target="_blank">Main Scroll Line 4</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Final Line 3</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Final Line 3</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=27" class="btn btn-lg btn-block btn-danger" target="_blank">Final Line 3</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Final Scroll</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Final Scroll Line 4</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=22" class="btn btn-lg btn-block btn-danger" target="_blank">Final Scroll</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Final Line 5</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Final Line 5</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=28" class="btn btn-lg btn-block btn-danger" target="_blank">Final Line 5</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Mecha Line 3</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Mecha Line 3</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=14" class="btn btn-lg btn-block btn-danger" target="_blank">Mecha Line 3</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Mecha Line 7</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Mecha Line 7</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=35" class="btn btn-lg btn-block btn-danger" target="_blank">Mecha Line 7</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Machine 2YC</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Machine 2YC</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=2&ld_id=34" class="btn btn-lg btn-block btn-danger" target="_blank">Machine 2YC</a>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div id="fac3" class="row collapse">
                        <%--<div class="btn-group">
                            <a href="http://192.168.226.19/iotweb/DataHistory/MstDataHistory.aspx?ld_id=15&FactoryID=3" class="btn btn-lg btn-danger" target="_blank">Machine Sampling</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=1" class="btn btn-lg btn-danger" target="_blank">Rear Head Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=6" class="btn btn-lg btn-danger" target="_blank">Cylinder Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=7" class="btn btn-lg btn-danger" target="_blank">Crank Shaft Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=16" class="btn btn-lg btn-danger" target="_blank">Front Head Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=5" class="btn btn-lg btn-danger" target="_blank">Piston Finish</a>
                            <a href="http://192.168.226.19/iotweb/DataHistory/MstDataHistory2.aspx?ld_id=11&FactoryID=3" class="btn btn-lg btn-danger" target="_blank">Mecha</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=2" class="btn btn-lg btn-danger" target="_blank">Casing Pipe</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=8" class="btn btn-lg btn-danger" target="_blank">Motor</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=4" class="btn btn-lg btn-danger" target="_blank">Main Assembly</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=10" class="btn btn-lg btn-danger" target="_blank">Final</a>
                            <a href="AlarmHistory2.aspx" class="btn btn-lg btn-danger" target="_blank">Alarm History</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=26" class="btn btn-lg btn-danger" target="_blank">Alarm History Detail</a>
                        </div>--%>

                        <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Machine Sampling</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Machine Sampling</li>
                                    </ul>
                                    <a href="http://192.168.226.19/iotweb/DataHistory/MstDataHistory.aspx?ld_id=15&FactoryID=3" class="btn btn-lg btn-block btn-danger" target="_blank">Machine Sampling</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Rear Head Finish</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Rear Head Finish</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=1" class="btn btn-lg btn-block btn-danger" target="_blank">Rear Head Finish</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Cylinder Finish</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Cylinder Finish</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=6" class="btn btn-lg btn-block btn-danger" target="_blank">Cylinder Finish</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Crank Shaft Finish</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Crank Shaft Finish</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=7" class="btn btn-lg btn-block btn-danger" target="_blank">Crank Shaft Finish</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Front Head Finish</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Front Head Finish</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=16" class="btn btn-lg btn-block btn-danger" target="_blank">Front Head Finish</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Piston Finish</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Piston Finish</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=5" class="btn btn-lg btn-block btn-danger" target="_blank">Piston Finish</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Mecha</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Mecha</li>
                                    </ul>
                                    <a href="MstDataHistory2.aspx?ld_id=11&FactoryID=3" class="btn btn-lg btn-block btn-danger" target="_blank">Mecha</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Casing Pipe</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Casing Pipe</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=2" class="btn btn-lg btn-block btn-danger" target="_blank">Casing Pipe</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Motor</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Motor</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=8" class="btn btn-lg btn-block btn-danger" target="_blank">Motor</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Main Assembly</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Main Assembly Line 6</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=4" class="btn btn-lg btn-block btn-danger" target="_blank">Main Assembly</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Leak Check Common Line 6</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Leak Check Common Line 6</li>
                                    </ul>
                                    <a href="HistoryData.aspx?ld_id=20&FactoryID=3" class="btn btn-lg btn-block btn-danger" target="_blank">Leak Check Common Line 6</a>
                                </div>
                            </div> 
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Final</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>Final Line</li>
                                    </ul>
                                    <a href="HistoryData.aspx?FactoryID=3&ld_id=10" class="btn btn-lg btn-block btn-danger" target="_blank">Final</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Alarm History Count</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Get Count of Alarm </li>
                                        <li>from Line and Machine</li>
                                    </ul>
                                    <a href="AlarmHistory2.aspx" class="btn btn-lg btn-block btn-danger" target="_blank">Alarm History Count</a>
                                </div>
                            </div>
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">Alarm History M/C Stop Time</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Get time of Machine Stop time</li>
                                        <li>from Line and Machine</li>
                                    </ul>
                                    <a href="AlarmHistoryDetail2.aspx" class="btn btn-lg btn-block btn-danger" target="_blank">Alarm History M/C Stop Time</a>
                                </div>
                            </div>

                        </div>

                    </div>

                    <div id="odm" class="row collapse">
                        <%--<div class="btn-group">
                            <a href="http://192.168.226.19/iotweb/DataHistory/MstDataHistory.aspx?ld_id=15&FactoryID=3" class="btn btn-lg btn-danger" target="_blank">Machine Sampling</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=1" class="btn btn-lg btn-danger" target="_blank">Rear Head Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=6" class="btn btn-lg btn-danger" target="_blank">Cylinder Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=7" class="btn btn-lg btn-danger" target="_blank">Crank Shaft Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=16" class="btn btn-lg btn-danger" target="_blank">Front Head Finish</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=5" class="btn btn-lg btn-danger" target="_blank">Piston Finish</a>
                            <a href="http://192.168.226.19/iotweb/DataHistory/MstDataHistory2.aspx?ld_id=11&FactoryID=3" class="btn btn-lg btn-danger" target="_blank">Mecha</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=2" class="btn btn-lg btn-danger" target="_blank">Casing Pipe</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=8" class="btn btn-lg btn-danger" target="_blank">Motor</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=4" class="btn btn-lg btn-danger" target="_blank">Main Assembly</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=10" class="btn btn-lg btn-danger" target="_blank">Final</a>
                            <a href="AlarmHistory2.aspx" class="btn btn-lg btn-danger" target="_blank">Alarm History</a>
                            <a href="HistoryData.aspx?FactoryID=3&ld_id=26" class="btn btn-lg btn-danger" target="_blank">Alarm History Detail</a>
                        </div>--%>

                        <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">ODM</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>IoT ODM</li>
                                    </ul>
                                    <a href="http://192.168.226.19/iotweb/DataHistory/HistoryData.aspx?ld_id=33&FactoryID=4" class="btn btn-lg btn-block btn-danger" target="_blank">ODM</a>
                                </div>
                            </div>
                            

                        </div>
                        <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">ODM Outdoor Ft1</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>ODM Outdoor Ft1</li>
                                    </ul>
                                    <a href="http://192.168.226.19/iotweb/DataHistory/HistoryData.aspx?ld_id=37&FactoryID=4" class="btn btn-lg btn-block btn-danger" target="_blank">ODM Outdoor Ft1</a>
                                </div>
                            </div>
                            

                        </div>
                        <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                            <div class="card mb-4 box-shadow col-md-2 height_box">
                                <div class="card-header">
                                    <h2 class="my-0 font-weight-normal">ODM Outdoor Ft2</h2>
                                </div>
                                <div class="card-body">
                                    <ul class="list-unstyled mt-3 mb-4">
                                        <li>Data History of</li>
                                        <li>ODM Outdoor Ft2</li>
                                    </ul>
                                    <a href="http://192.168.226.19/iotweb/DataHistory/HistoryData.aspx?ld_id=38&FactoryID=4" class="btn btn-lg btn-block btn-danger" target="_blank">ODM Outdoor Ft2</a>
                                </div>
                            </div>
                            

                        </div>

                    </div>
                </div>
            </section>



        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

