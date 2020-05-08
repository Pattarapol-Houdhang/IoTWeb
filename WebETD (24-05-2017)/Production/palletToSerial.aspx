<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="palletToSerial.aspx.cs" Inherits="Production_palletToSerial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>

    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.datepick.css") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/dataTables.buttons.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.flash.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jszip.min.js") %>"></script>
    <%--<script src="<%= ResolveUrl("~/StyleMax/js/pdfmake.min.js") %>"></script>--%>
    <script src="<%= ResolveUrl("~/StyleMax/js/vfs_fonts.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.html5.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.print.min.js") %>"></script>

    <link href="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />

    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.themes.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/autocomplete/easy-autocomplete.themes.min.css") %>" rel="stylesheet" />
    <script src="<%= ResolveUrl("~/StyleMax/autocomplete/jquery.easy-autocomplete.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/autocomplete/jquery.easy-autocomplete.min.js") %>"></script>
    <script type="text/javascript">
        function FormatNumberLength(num, length) {
            var r = "" + num;
            while (r.length < length) {
                r = "0" + r;
            }
            return r;
        }

        function Loading() {
            //document.getElementById("UpdatePanel1").style.display = "block";
            document.getElementById("updateProg").style.display = "block";
        }




        //---------- Calculate StartDay - EndDay for alert in case more than 31 days -----------------------
        function CaldiffDay(picker, txtID) {
            var spStrDate = picker.startDate.format('YYYY/MM/DD').split("/");
            var strDate = new Date(spStrDate[2], spStrDate[1] - 1, spStrDate[0]);

            var spEndDate = picker.endDate.format('YYYY/MM/DD').split("/");
            var endDate = new Date(spEndDate[2], spEndDate[1] - 1, spEndDate[0]);

            var diffDay = new Date(endDate - strDate);
            var days = diffDay / 1000 / 60 / 60 / 24;

            if (days > 31) {
                $("#" + txtID).val('');
                alert('ไม่สามารถเลือกช่วงเวลาเกิน 31 วันได้ครับ');
            }
        }
        //---------- Calculate StartDay - EndDay for alert in case more than 31 days -----------------------




      



    </script>

    <style>
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

        .HideDiv {
            display: none;
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

        .tbl {
            border-spacing: 0;
            border-collapse: collapse;
            background-color: #fff;
            margin: 0 auto;
            border-top: 1px solid #111;
            border-left: 1px solid #111;
        }

            .tbl th, .tbl td {
                border-right: 1px solid #111;
                border-bottom: 1px solid #111;
            }

        .rowHeader {
            /*background-color: #656565;*/
            font-size: 24px;
            font-weight: bold;
            padding: 5px 10px !important;
            /*cursor: pointer;*/
            color: #f9ff00;
            background: rgba(76,76,76,1);
            background: -moz-linear-gradient(top, rgba(76,76,76,1) 0%, rgba(89,89,89,1) 12%, rgba(102,102,102,1) 25%, rgba(71,71,71,1) 39%, rgba(44,44,44,1) 50%, rgba(0,0,0,1) 51%, rgba(17,17,17,1) 60%, rgba(43,43,43,1) 76%, rgba(28,28,28,1) 91%, rgba(19,19,19,1) 100%);
            background: -webkit-gradient(left top, left bottom, color-stop(0%, rgba(76,76,76,1)), color-stop(12%, rgba(89,89,89,1)), color-stop(25%, rgba(102,102,102,1)), color-stop(39%, rgba(71,71,71,1)), color-stop(50%, rgba(44,44,44,1)), color-stop(51%, rgba(0,0,0,1)), color-stop(60%, rgba(17,17,17,1)), color-stop(76%, rgba(43,43,43,1)), color-stop(91%, rgba(28,28,28,1)), color-stop(100%, rgba(19,19,19,1)));
            background: -webkit-linear-gradient(top, rgba(76,76,76,1) 0%, rgba(89,89,89,1) 12%, rgba(102,102,102,1) 25%, rgba(71,71,71,1) 39%, rgba(44,44,44,1) 50%, rgba(0,0,0,1) 51%, rgba(17,17,17,1) 60%, rgba(43,43,43,1) 76%, rgba(28,28,28,1) 91%, rgba(19,19,19,1) 100%);
            background: -o-linear-gradient(top, rgba(76,76,76,1) 0%, rgba(89,89,89,1) 12%, rgba(102,102,102,1) 25%, rgba(71,71,71,1) 39%, rgba(44,44,44,1) 50%, rgba(0,0,0,1) 51%, rgba(17,17,17,1) 60%, rgba(43,43,43,1) 76%, rgba(28,28,28,1) 91%, rgba(19,19,19,1) 100%);
            background: -ms-linear-gradient(top, rgba(76,76,76,1) 0%, rgba(89,89,89,1) 12%, rgba(102,102,102,1) 25%, rgba(71,71,71,1) 39%, rgba(44,44,44,1) 50%, rgba(0,0,0,1) 51%, rgba(17,17,17,1) 60%, rgba(43,43,43,1) 76%, rgba(28,28,28,1) 91%, rgba(19,19,19,1) 100%);
            background: linear-gradient(to bottom, rgba(76,76,76,1) 0%, rgba(89,89,89,1) 12%, rgba(102,102,102,1) 25%, rgba(71,71,71,1) 39%, rgba(44,44,44,1) 50%, rgba(0,0,0,1) 51%, rgba(17,17,17,1) 60%, rgba(43,43,43,1) 76%, rgba(28,28,28,1) 91%, rgba(19,19,19,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#4c4c4c', endColorstr='#131313', GradientType=0 );
        }

        .imgSize {
            height: 25px;
            width: 25px;
        }

        .rowDetail {
            font-size: 18px;
        }

        .tblForm {
            padding: 10px 50px 10px 50px;
            border: 1px solid #888888;
            /*background-color: #f5f5f5;*/
            box-shadow: #666 0px 0px 5px 0px;
            margin: 0 auto;
            font-weight: bold;
            background: rgba(209,209,209,1);
            background: -moz-linear-gradient(top, rgba(209,209,209,1) 0%, rgba(209,209,209,1) 31%, rgba(246,246,246,1) 67%, rgba(250,247,250,1) 100%);
            background: -webkit-gradient(left top, left bottom, color-stop(0%, rgba(209,209,209,1)), color-stop(31%, rgba(209,209,209,1)), color-stop(67%, rgba(246,246,246,1)), color-stop(100%, rgba(250,247,250,1)));
            background: -webkit-linear-gradient(top, rgba(209,209,209,1) 0%, rgba(209,209,209,1) 31%, rgba(246,246,246,1) 67%, rgba(250,247,250,1) 100%);
            background: -o-linear-gradient(top, rgba(209,209,209,1) 0%, rgba(209,209,209,1) 31%, rgba(246,246,246,1) 67%, rgba(250,247,250,1) 100%);
            background: -ms-linear-gradient(top, rgba(209,209,209,1) 0%, rgba(209,209,209,1) 31%, rgba(246,246,246,1) 67%, rgba(250,247,250,1) 100%);
            background: linear-gradient(to bottom, rgba(209,209,209,1) 0%, rgba(209,209,209,1) 31%, rgba(246,246,246,1) 67%, rgba(250,247,250,1) 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#d1d1d1', endColorstr='#faf7fa', GradientType=0 );
        }

        .btnImg {
            height: 64px;
            width: 64px;
        }

        .btnImg2 {
            height: 24px;
            width: 24px;
        }

        .btnImg:hover {
            box-shadow: #1914f1 0px 0px 10px 0px;
            border-radius: 32px;
        }

        h1 {
            margin: 0px;
            padding: 10px 0px 10px 0px;
            color: #000;
            font-family: monospace;
        }

        .tabHeader {
            background-color: #000;
            color: #fff;
            cursor: pointer;
            padding: 10px 20px;
            border-radius: 5px 5px 0px 0px;
            float: left;
            width: 10%;
            border-top: 1px solid #dedede;
            border-left: 1px solid #dedede;
            border-right: 1px solid #dedede;
            font-weight: bold;
            font-size: 12px;
        }

        .tabactive {
            background-color: #6260ef;
        }

        #dvDisplay {
            width: 90%;
            text-align: center;
            margin: 0 auto;
        }
    </style>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>

            <section class="wrapper">

                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>DCI - Serial</h3>
                    </div>
                </div>
                <div id="updateProg" style="display: none;">
                    <progresstemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </progresstemplate>
                </div>
                 <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                Searching
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="search_datetime" runat="server" class="row" style="margin-top: 20px">
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnLoad" runat="server" class="btn btn-success btn-lg" Text="1.Load" AutoPostBack="true" OnClick="btnLoad_Click" OnClientClick="Loading()"/>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnShow" runat="server" class="btn btn-success btn-lg" Text="2.Show" AutoPostBack="true" OnClick="btnShow_Click"  OnClientClick="Loading()"/>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:Button ID="btnExport" runat="server" class="btn btn-success btn-lg" Text="3.Export to Excel" AutoPostBack="true" OnClick="btnExport_Click"  />
                                        </div>
                                    </div>

                                </div>


                            </div>

                        </section>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <div id="updatePanel2">
                                <div class="tblForm" style="width: 45%; margin-bottom: 10px;">
                                    <center><span id="ltrFilter" style="color:Red;" runat="server"></span></center>
                                </div>
                                    <div>
                                        <div id="dvFGlist" style="">
                                            <asp:Repeater ID="rptData" runat="server" OnItemDataBound="rptData_ItemDataBound">
                                        <HeaderTemplate>
                                            <table class="table table-striped table-advance table-hover" id="example" width="100%">
                                                <thead>
                                                    <tr class="">
                                                        <asp:Repeater ID="Header1" runat="server">
                                                            <ItemTemplate>
                                                                <th align="left"><%# Container.DataItem %>
                                                                </th>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr class="">
                                                <asp:Repeater ID="Item1" runat="server">
                                                    <ItemTemplate>
                                                        <td><%# Container.DataItem %>
                                                        </td>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                        </table>
                                        </FooterTemplate>
                                    </asp:Repeater>

                                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="******** กดที่ Columns เพื่อ Export Excel ************"></asp:Label>
                                        </div>
                                    </div>
                            </div>
                        </section>
                    </div>
                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnLoad" />
            <asp:PostBackTrigger ControlID="btnShow" />
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>

</asp:Content>

