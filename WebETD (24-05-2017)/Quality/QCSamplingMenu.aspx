<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="QCSamplingMenu.aspx.cs" Inherits="Quality_QCSamplingMenu" %>

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
       
    </script>

    <style>
        .height_box {
            height: 140px;
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
                    <h2><b>Setting Master</b></h2>
                </div>
                <div class="row ">
                    <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Rear Head</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Setting Master of Rear Head</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-primary" target="_blank">SETTING</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Cylinder</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Setting Master of Cylinder</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-primary" target="_blank">SETTING</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Crank Shaft</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Setting Master of Crank Shaft</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-primary" target="_blank">SETTING</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Front Head</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Setting Master of Front Head</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-primary" target="_blank">SETTING</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Piston</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Setting Master of Piston</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-primary" target="_blank">SETTING</a>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <h2><b>Show Graph</b></h2>
                </div>
                <div class="row ">
                    <div class="card-deck mb-3 text-center" style="padding-right: 10px;">
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Rear Head</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Show Graph of Rear Head</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-success" target="_blank">SHOW GRAPH</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Cylinder</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Show Graph of Cylinder</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-success" target="_blank">SHOW GRAPH</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Crank Shaft</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Show Graph of Crank Shaft</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-success" target="_blank">SHOW GRAPH</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Front Head</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Show Graph of Front Head</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-success" target="_blank">SHOW GRAPH</a>
                            </div>
                        </div>
                        <div class="card mb-4 box-shadow col-md-2 height_box">
                            <div class="card-header">
                                <h2 class="my-0 font-weight-normal">Piston</h2>
                            </div>
                            <div class="card-body">
                                <ul class="list-unstyled mt-3 mb-4">
                                    <li>Show Graph of Piston</li>
                                </ul>
                                <a href="#" class="btn btn-lg btn-block btn-success" target="_blank">SHOW GRAPH</a>
                            </div>
                        </div>
                    </div>
                </div>

            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

