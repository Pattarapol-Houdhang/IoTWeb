<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="fgdatalist.aspx.cs" Inherits="Production_fgdatalist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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

        function myFunction() {
            //document.getElementById("UpdatePanel1").style.display = "block";
            document.getElementById("updateProg").style.display = "block";
        }

        function txtDatePicker() {

            var start = moment().subtract(29, 'days');
            var end = moment();

            var d = new Date();
            var month = d.getMonth() + 1;
            var day = d.getDate();
            var year = d.getFullYear();
            var date = year + "/" + month + "/" + day + " 08:00 - " + year + "/" + month + "/" + day + " 20:00";
            var _StartDate = year + "/" + month + "/" + day + " 08:00";
            var _EndDate = year + "/" + month + "/" + day + " 20:00";

            //------------------ Prd Date ----------------------
            $('#<%= txtDateC.ClientID %>').daterangepicker({
                autoUpdateInput: true,
                locale: {
                    cancelLabel: 'Clear',
                    format: 'YYYY/MM/DD HH:mm'
                },
                timePicker: true,
                timePickerIncrement: 5,
                timePicker24Hour: true,
                startDate: _StartDate,
                endDate: _EndDate

            });


            $('#<%= txtDateC.ClientID %>').on('apply.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val(picker3.startDate.format('YYYY/MM/DD HH:mm') + ' - ' + picker3.endDate.format('YYYY/MM/DD HH:mm'));
                var id = "<%= txtDateC.ClientID %>";
                /*CaldiffDay(picker3, id);*/

            });
            $('#<%= txtDateC.ClientID %>').on('cancel.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val('');
            });
        }
        function LoadData() {
            //------------------ Prd Date ----------------------
            $('#<%= txtPrdDate.ClientID %>').datepicker({
                format: 'yyyy/mm/dd',
                autoclose: true,
            });

            $(".dateClick").click(function () {

            });
            txtDatePicker();
            //////////////////////////////////////////////////////////////////////



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



        $(document).ready(function () {
            $(".cUWH").each(function () {
                var _model = $(this).data("model");
                var _type = $(this).data("type");
                var _line = document.getElementById('<%=ddlLine.ClientID%>').value;
                var _idUWH = "#idUwh_" + _model.replace('#', '_');
                _model = _model.replace('#', '_');

                $.getJSON("dataALPHA.ashx?T=" + _type + "&L=" + _line + "&M=" + _model, function (ResponseData) {
                    $(_idUWH).text(ResponseData);
                });
            });
        });


        $(document).ready(function () {
            $(".cRWD").each(function () {
                var _model = $(this).data("model");
                var _type = $(this).data("type");
                var _line = document.getElementById('<%=ddlLine.ClientID%>').value;
                var _idRWD = "#idRWD_" + _model.replace('#', '_');
                _model = _model.replace('#', '_');

                $.getJSON("dataALPHA.ashx?T=" + _type + "&L=" + _line + "&M=" + _model, function (ResponseData) {
                    $(_idRWD).text(ResponseData);
                });
            });
        });

        $(document).ready(function () {
            $(".cRWE").each(function () {
                var _model = $(this).data("model");
                var _type = $(this).data("type");
                var _line = document.getElementById('<%=ddlLine.ClientID%>').value;
                var _idRWE = "#idRWE_" + _model.replace('#', '_');
                _model = _model.replace('#', '_');

                $.getJSON("dataALPHA.ashx?T=" + _type + "&L=" + _line + "&M=" + _model, function (ResponseData) {
                    $(_idRWE).text(ResponseData);
                });
            });
        });
        $(document).ready(function () {
            $(".cRWQ").each(function () {
                var _model = $(this).data("model");
                var _type = $(this).data("type");
                var _line = document.getElementById('<%=ddlLine.ClientID%>').value;
                var _idRWQ = "#idRWQ_" + _model.replace('#', '_');
                _model = _model.replace('#', '_');

                $.getJSON("dataALPHA.ashx?T=" + _type + "&L=" + _line + "&M=" + _model, function (ResponseData) {
                    $(_idRWQ).text(ResponseData);
                });
            });
        });

        function SelectedTab(evt, tab) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(tab).style.display = "block";
            evt.currentTarget.className += " active";
        }

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

        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
        }

            /* Style the buttons inside the tab */
            .tab button {
                background-color: inherit;
                float: left;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 14px 16px;
                transition: 0.3s;
                font-size: 17px;
            }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab button.active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
            border: 1px solid #ccc;
            border-top: none;
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
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>DCI - PRODUCTION DAILY ACTUAL</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                Searching
                            </header>
                            <div class="panel-body" style="margin-top: 30px">
                                <div class="tab">
                                    <button class="tablinks" onclick="SelectedTab(event, 'DivSearchD')" >Daily</button>
                                    <button class="tablinks" onclick="SelectedTab(event, 'DivsearchC')" >Custom</button>
                                </div>

                                <div id="DivSearchD" class="form-group  tabcontent" style="display: block; margin-top: 10px">
                                    <div id="search_datetime" runat="server" class="row" style="margin-top: 20px">
                                        <div class="col-sm-4" id="divDate" runat="server">
                                            <label id="lbDate" class="col-sm-2 control-label" style="text-align: right!important">Date</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtPrdDate" runat="server" class="form-control" Text="1900/01/01"></asp:TextBox>
                                            </div>
                                        </div>

                                        <label class="col-sm-1" style="text-align: right!important">Line</label>
                                        <div class="col-sm-2" id="divLine" runat="server">
                                            <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="1" Value="1" />
                                                <asp:ListItem Text="2" Value="2" />
                                                <asp:ListItem Text="3" Value="3" />
                                                <asp:ListItem Text="4" Value="4" />
                                                <asp:ListItem Text="5" Value="5" />
                                                <asp:ListItem Text="6" Value="6" />
                                                <asp:ListItem Text="7" Value="7" />
                                            </asp:DropDownList>
                                        </div>

                                        <label class="col-sm-1" style="text-align: right!important">Shift</label>
                                        <div class="col-sm-2" id="divShift" runat="server">
                                            <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="All" Value="All" />
                                                <asp:ListItem Text="Day" Value="D" />
                                                <asp:ListItem Text="Night" Value="N" />
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-success btn-lg" Text="Search" AutoPostBack="true" OnClick="btnSearch_Click" OnClientClick="myFunction()" />
                                        </div>
                                    </div>

                                </div>

                                <div id="DivsearchC" class="form-group  tabcontent">
                                    <div id="Div1" runat="server" class="row" style="margin-top: 20px">
                                        <div class="col-sm-4" id="div2" runat="server">
                                            <label id="lbDataC" class="col-sm-2 control-label" style="text-align: right!important">Date</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtDateC" runat="server" Class="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <label class="col-sm-1" style="text-align: right!important">Line</label>
                                        <div class="col-sm-2" id="div3" runat="server">
                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="1" Value="1" />
                                                <asp:ListItem Text="2" Value="2" />
                                                <asp:ListItem Text="3" Value="3" />
                                                <asp:ListItem Text="4" Value="4" />
                                                <asp:ListItem Text="5" Value="5" />
                                                <asp:ListItem Text="6" Value="6" />
                                                <asp:ListItem Text="7" Value="7" />
                                            </asp:DropDownList>
                                        </div>

                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearchC" runat="server" class="btn btn-success btn-lg" Text="Search" AutoPostBack="true" OnClick="SearchC_Click" OnClientClick="myFunction()" />
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </section>
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
                            <div id="updatePanel2">
                                <div class="tblForm" style="width: 45%; margin-bottom: 10px;">
                                    <center><span id="ltrFilter" style="color:Red;" runat="server"></span></center>
                                </div>
                                <div id="dvDisplay">
                                    <div>
                                        <div id="dvFGlist" style="">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="false" CssClass="table table-striped table-advance table-hover"
                                                >
                                                <Columns>

                                                    <asp:TemplateField HeaderText="ModelCode" SortExpression="ModelCode">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbModelCode" runat="server" Text='<%# Eval("ModelCode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Model" SortExpression="Model">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbModel" runat="server" Text='<%# Eval("Model") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Production" SortExpression="Production_Qty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbProduction_Qty" runat="server" Text='<%# Eval("Production_Qty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="Production_Qty " runat="server" />
                                                            <asp:HyperLink ID="HLProduction_Qty" Text="Production_Qty" ToolTip="Export Production_Qty" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>" class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Relabel" SortExpression="Relabel">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbRelabel" runat="server" Text='<%# Eval("Relabel") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="Relabel " runat="server" />
                                                            <asp:HyperLink ID="HLRelabel" ToolTip="Export Relabel" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>" class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Rework" SortExpression="Rework">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbRework" runat="server" Text='<%# Eval("Rework") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="Rework " runat="server" />
                                                            <asp:HyperLink ID="HLRework" ToolTip="Export Rework" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>"class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>


                                                </Columns>
                                            </asp:GridView>

                                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="******** กดที่ Columns เพื่อ Export Excel ************"></asp:Label>
                                        </div>

                                        <div class="tblForm" style="width: 45%; margin-bottom: 10px; margin-top: 20px;">
                                            <center><span id="lbAlpha" style="color:Red;" runat="server" ></span></center>
                                        </div>

                                        <div id="dvFGlistAlpha" style="">
                                            <asp:GridView ID="gvAlpha" runat="server" AutoGenerateColumns="False" AllowPaging="false" CssClass="table table-striped table-advance table-hover"
                                                OnRowDataBound="GridView2_RowDataBound">
                                                <Columns>


                                                    <asp:TemplateField HeaderText="Model" SortExpression="Model">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbModel" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="PDT" SortExpression="PDT">
                                                        <ItemTemplate>
                                                            <asp:Label ID="idPdt" runat="server" Text='<%# Eval("COUNTS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="PDT " runat="server" />
                                                            <asp:HyperLink ID="LHPDT" ToolTip="Export PDT" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>" class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="UNW" SortExpression="UNW">
                                                        <ItemTemplate>
                                                            <span class="cUWH" id="idUwh_<%# Eval("MODEL").ToString().Replace('#','_') %>" data-type="UWH" data-model='<%# Eval("MODEL") %>'>
                                                                <%# Eval("UWH") %>
                                                            </span>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="UNW " runat="server" />
                                                            <asp:HyperLink ID="LHUWH" ToolTip="Export UNW" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>" class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="RWD" SortExpression="RWD">
                                                        <ItemTemplate>
                                                            <span class="cRWD" id="idRWD_<%# Eval("MODEL").ToString().Replace('#','_') %>" data-type="RWD" data-model='<%# Eval("MODEL") %>'>
                                                                <%# Eval("RWD") %>
                                                            </span>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="RWD " runat="server" />
                                                            <asp:HyperLink ID="LHRWD" ToolTip="Export RWD" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>" class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="RWE" SortExpression="RWE">
                                                        <ItemTemplate>
                                                            <span class="cRWE" id="idRWE_<%# Eval("MODEL").ToString().Replace('#','_') %>" data-type="RWE" data-model='<%# Eval("MODEL") %>'>
                                                                <%# Eval("RWE") %>
                                                            </span>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="RWE " runat="server" />
                                                            <asp:HyperLink ID="LHRWE" ToolTip="Export RWE" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>" class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="RWQ" SortExpression="RWQ">
                                                        <ItemTemplate>
                                                            <span class="cRWQ" id="idRWQ_<%# Eval("MODEL").ToString().Replace('#','_') %>" data-type="RWQ" data-model='<%# Eval("MODEL") %>'>
                                                                <%# Eval("RWQ") %>
                                                            </span>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                        <HeaderTemplate>
                                                            <asp:Label Text="RWQ " runat="server" />
                                                            <asp:HyperLink ID="LHRWQ" ToolTip="Export RWQ" runat="server" Target="_blank"><img alt="" src="<%= ResolveUrl("~/StyleMax/icon/print.png") %>" class="imgSize"/> </asp:HyperLink>

                                                        </HeaderTemplate>
                                                    </asp:TemplateField>



                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="tblForm" style="width: 45%; margin-bottom: 10px; margin-top: 20px;">
                                            <center><span id="lbPlan" style="color:Red;" runat="server" ></span></center>
                                        </div>
                                        <div id="dvPlan" style="">
                                            <asp:GridView ID="gvPlan" runat="server" AutoGenerateColumns="False" AllowPaging="false" CssClass="table table-striped table-advance table-hover">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="WCNO" SortExpression="WCNO">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbWCNO" runat="server" Text='<%# Eval("WCNO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="MODEL" SortExpression="MODEL">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbMODEL" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="DATA_TYPE" SortExpression="DATA_TYPE">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbDATA_TYPE" runat="server" Text='<%# Eval("DATA_TYPE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="QTY" SortExpression="QTY">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbQTY" runat="server" Text='<%# Eval("QTY") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="USERID" SortExpression="USERID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbUSERID" runat="server" Text='<%# Eval("USERID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Production_Date(yyyy-MM-dd)" SortExpression="Production_Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbPRDYMD" runat="server" Text='<%# Eval("Production_Date") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Create_Date" SortExpression="Create_Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbCDATE" runat="server" Text='<%# Eval("CDATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Update_Date" SortExpression="Update_Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbUDATE" runat="server" Text='<%# Eval("UDATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="tblForm" style="width: 45%; margin-bottom: 10px; margin-top: 20px;">
                                            <center><span id="lbPipe" style="color:Red;" runat="server" ></span></center>
                                        </div>
                                        <div id="dvPipe" style="">
                                            <asp:GridView ID="gvActual" runat="server" AutoGenerateColumns="False" AllowPaging="false" CssClass="table table-striped table-advance table-hover">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Actual" SortExpression="Actual">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbActual" runat="server" Text='<%# Eval("Actual") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Error" SortExpression="Error">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbError" runat="server" Text='<%# Eval("Error") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />

                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
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
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnSearchC" />
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>

</asp:Content>

