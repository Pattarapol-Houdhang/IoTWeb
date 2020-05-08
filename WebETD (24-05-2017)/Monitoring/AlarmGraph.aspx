<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="AlarmGraph.aspx.cs" Inherits="AlarmGraph" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>

    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.js") %>"></script>
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

    <%--<script src="<%= ResolveUrl("~/Highcharts/highstock.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/exporting.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/modules/exporting.js") %>"></script>--%>

    <script src="<%= ResolveUrl("~/Highcharts/highcharts.js") %>"></script>
    <script src="<%= ResolveUrl("~/Highcharts/modules/data.js") %>"></script>
    <script src="<%= ResolveUrl("~/js/moment.js") %>"></script>

    <script type="text/javascript">
        function FormatNumberLength(num, length) {
            var r = "" + num;
            while (r.length < length) {
                r = "0" + r;
            }
            return r;
        }



        function LoadData() {


            var start = moment().subtract(29, 'days');
            var end = moment();

            var d = new Date();
            var month = d.getMonth() + 1;
            var day = d.getDate();
            var year = d.getFullYear();
            var date = year + "/" + month + "/" + day + " - " + year + "/" + month + "/" + day;
            var _StartDate = year + "/" + month + "/" + day;
            var _EndDate = year + "/" + month + "/" + day;

            //------------------ Prd Date ----------------------
            $('#<%= txtPrdDate.ClientID %>').daterangepicker({
                //autoUpdateInput: true,
                locale: {
                    //cancelLabel: 'Clear',
                    format: 'YYYY/MM/DD'
                },
                startDate: moment().startOf('hour').add(-144, 'hour'),
                endDate: moment().startOf('hour'),
                //timePicker: true,
                //timePickerIncrement: 5,
                //timePicker24Hour: true,

            });


            $('#<%= txtPrdDate.ClientID %>').on('apply.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val(picker3.startDate.format('YYYY/MM/DD') + ' - ' + picker3.endDate.format('YYYY/MM/DD'));
                var id = "<%= txtPrdDate.ClientID %>";
                /*CaldiffDay(picker3, id);*/

            });
            $('#<%= txtPrdDate.ClientID %>').on('cancel.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val('');
            });
            //------------------ Prd Date ----------------------

            <%--$('#<%= btnManual.ClientID %>').on('click', function () {
                var url = $(this).data('link');
                if (url != "") {
                    window.open(url);
                }

            });--%>

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
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>AlarmGraph</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                Searching
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div id="filter" runat="server" class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Factory</label>
                                        <div class="col-sm-2" id="Fac" runat="server" style="margin-top: 10px">
                                            <asp:DropDownList ID="ddlFac" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFac_SelectedIndexChanged">
                                                <%--<asp:ListItem Text="All" Value="All" />--%>
                                                <asp:ListItem Text="Fac3" Value="Fac3" />
                                                <asp:ListItem Text="ODM" Value="ODM" />
                                            </asp:DropDownList>
                                        </div>

                                        <div id="divlLineODM" runat="server" style="margin-top: 10px" visible="false">
                                            <label class="col-sm-1 control-label" style="text-align: right!important">Line</label>
                                            <div class="col-sm-2">
                                                <asp:DropDownList ID="ddlLineODM" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLineODM_SelectedIndexChanged">
                                                    <%--<asp:ListItem Text="All" Value="All" />--%>
                                                    <asp:ListItem Text="INDOOR" Value="IN" />
                                                    <asp:ListItem Text="OUTDOOR" Value="OUT" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-" id="divLine" runat="server" visible="true">
                                            <label class="col-sm-1 control-label" style="text-align: right!important">Line Machine</label>
                                            <div class="col-sm-3" id="LineMC" runat="server" style="margin-top: 10px">
                                                <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    <asp:ListItem Text="All" Value="All" />
                                                    <asp:ListItem Text="Main Assembly Line 6" Value="Main Assembly Line 6" />
                                                    <asp:ListItem Text="Mecha Line 6" Value="Mecha Line 6" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-sm-4" id="divMCName" runat="server" style="margin-top: 10px" visible="false">
                                            <label id="lbMC" class="col-sm-3 control-label" runat="server" style="text-align: right!important" visible="false">Machine Name</label>
                                            <div class="col-sm-8">
                                                <asp:CheckBoxList ID="cblMC" runat="server" Visible="false"></asp:CheckBoxList>
                                            </div>
                                        </div>


                                    </div>
                                    <div id="search_datetime" runat="server" class="row" style="margin-top: 20px">
                                        <div class="col-sm-4" id="divDate" runat="server">
                                            <label id="lbDate" class="col-sm-2 control-label" style="text-align: right!important">Date</label>
                                            <div class="col-sm-8">
                                                <asp:TextBox ID="txtPrdDate" runat="server" class="form-control" Text=""></asp:TextBox>
                                            </div>
                                        </div>

                                        <label id="lbF" runat="server" class="col-sm-1">Frequency</label>
                                        <div class="col-sm-2" id="divDR" runat="server">
                                            <asp:DropDownList ID="ddlDate" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
                                                <%--AutoPostBack="true" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">--%>
                                                <asp:ListItem Text="Daily" Value="D" />
                                                <%--<asp:ListItem Text="Weekly" Value="W" />--%>
                                                <asp:ListItem Text="Yearly" Value="M" />
                                            </asp:DropDownList>
                                        </div>
                                        <label id="lbVol" class="col-sm-1" runat="server" visible="false">volume</label>
                                        <div class="col-sm-2" id="divVolume" runat="server" visible="false">

                                            <asp:DropDownList ID="ddlVolume" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlVolume_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>


                                        <label class="col-sm-1" style="text-align: right!important">Shift</label>
                                        <div class="col-sm-2" id="divShift" runat="server">
                                            <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control">
                                                <%-- AutoPostBack="true" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">--%>
                                                <asp:ListItem Text="All" Value="All" />
                                                <asp:ListItem Text="D" Value="D" />
                                                <asp:ListItem Text="N" Value="N" />
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row" style="margin-top: 10px">

                                        <div class="col-sm-2">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-success btn-lg" Text="Show" AutoPostBack="true" OnClick="btnSearch_Click" />
                                        </div>
                                        <div id='loader' style='display: none;' >
                                            <progresstemplate>
                                                <div class="modal">
                                                    <div class="center">
                                            <img src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" width='32px' height='32px'>
                                                        </div>
                                                </div>
                                            </progresstemplate>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 10px" runat="server">
                                        <div class="col-sm-5">
                                            <asp:Button ID="btnExport" runat="server" class="btn btn-success btn" AutoPostBack="true" Text="Export to Excel" OnClick="btnExport_Click" />
                                            <span style="color: red;">** Export data to excel file.
                                                ** ดาวโหลดไฟล์ข้อมูล Excel </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 10px">

                                    <div class="col-sm-2">
                                        <asp:Button ID="btnShowDetail" runat="server" class="btn btn-success btn-lg" Text="Show Detail" AutoPostBack="true" OnClick="btnShowDetail_Click" />
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                Graph : 
                        <asp:Label ID="DateShow" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:Label ID="FullDate" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="col-lg-12 ">
                                        <%--<h1>AlarmGraph </h1>--%>
                                        <div id="AlarmGraph" class="col-lg-12"></div>
                                        <div id="AlarmGraphTime" class="col-lg-12"></div>


                                            <script>

                                                $(document).ready(function () {
                                                    LoadDataG();
                                                    LoadGraph();

                                                });
                                                var DatePDStart = moment().add(-144, 'hour').format("YYYY-MM-DD");
                                                var DatePDEnd = moment().format("YYYY-MM-DD");
                                                _Shift = "";
                                                Range = "";
                                                var _Volume;
                                                var MCName = [];
                                                var _DateStart = "";
                                                var _DateEnd = "";
                                                var txtDate = document.getElementById('<%= DateShow.ClientID %>').textContent;
                                                _Shift = document.getElementById('<%= ddlShift.ClientID %>').value;
                                                try {

                                                    Range = document.getElementById('<%= ddlDate.ClientID %>').value;
                                                } catch (Exception) {
                                                    Range = "";
                                                }
                                                try {

                                                    _Volume = document.getElementById('<%= ddlVolume.ClientID %>').value;
                                                } catch (Exception) {
                                                    _Volume = 0
                                                }
                                        <%--MCName.append(document.getElementByID('<%= cblMC.ClientID %>').value);--%>
                                                if (txtDate != "") {
                                                    var spl = txtDate.split(" - ");
                                                    _DateStart = spl[0].toString().trim();
                                                    _DateEnd = spl[1].toString().trim();
                                                } else {
                                                    _DateStart = DatePDStart;
                                                    _DateEnd = DatePDEnd;
                                                }
                                                var listMC = "'";
                                                var chkBoxList = document.getElementById('<%= cblMC.ClientID %>');
                                                try {
                                                    var chkBoxCount = chkBoxList.getElementsByTagName("input");
                                                    var clicked = this;

                                                    for (var i = 0; i < chkBoxCount.length; i++) {
                                                        if (chkBoxCount[0].checked) {
                                                            listMC = "";
                                                            break;
                                                        } else {
                                                            if (chkBoxCount[i].checked) {
                                                                listMC += chkBoxCount[i].value.replace('&', '%') + "','";
                                                            }
                                                            if (i == chkBoxCount.length - 1) {
                                                                listMC += "'";
                                                            }
                                                        }

                                                    }

                                                } catch (Exception) {
                                                    listMC = "";
                                                }
                                                var Line = "";
                                                try {
                                                    Line = document.getElementById('<%= ddlLine.ClientID %>').value;
                                                } catch (Exception) {

                                                }
                                                var fac = "";
                                                try {
                                                    fac = document.getElementById('<%= ddlFac.ClientID %>').value;
                                                } catch (Exception) {

                                                }
                                                try {
                                                    var LineODM = document.getElementById('<%= ddlLineODM.ClientID %>').value;
                                                } catch (Exception) {
                                                    LineODM = "IN";
                                                }



                                                var ListMcName = [];
                                                var ListOfQty = [];
                                                var ListOfTotal = [];
                                                var DateG = [];
                                                var myJsonString = "";
                                                var dataObj;
                                                var dataObj2;
                                                var test = '[{"name": "b","data": [[1493326164493, 100],[1493326194018, 120]]}]';
                                                var test2;

                                                function LoadDataG() {
                                                    $.ajax({
                                                        url: "GetAlarmHistoryGraph.ashx?DateStart=" + _DateStart + "&DateEnd=" + _DateEnd + "&Range=" + Range + "&Shift=" + _Shift + "&Volume=" + _Volume + "&listMC=" + listMC + "&Line=" + Line + "&Fac=" + fac + "&LineODM=" + LineODM,
                                                        dataType: "json",
                                                        cache: false,
                                                        beforeSend: function () {
                                                            $('#loader').show();
                                                        },
                                                        async: true,
                                                        complete: function () {
                                                            $('#loader').hide();
                                                        },
                                                        success: function (data) {
                                                            if (Range == "D") {////Graph Daily
                                                                for (i = 0; i < data.ListOfMC.length; i++) {
                                                                    ListMcName.push(data.ListOfMC[i].MCname);
                                                                }
                                                                myJsonString = '[';
                                                                for (j = 0; j < ListMcName.length; j++) {
                                                                    ListOfQty = [];
                                                                    for (i = 0; i < data.ListOfAlarm.length; i++) {
                                                                        if (ListMcName[j] == data.ListOfAlarm[i].MCName) {
                                                                            ListOfQty.push('[' + Date.parse(data.ListOfAlarm[i].StampDate) + ',' + data.ListOfAlarm[i].Qty + ']');
                                                                        }
                                                                    }
                                                                    if (j < ListMcName.length - 1) {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] },'
                                                                    } else {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] }'
                                                                    }

                                                                }
                                                                myJsonString += ']'
                                                                ////myJsonString = JSON.stringify(ListOfTotal);
                                                                //test2 = '[{"name": "b","data": [' + ListOfQty[5] + ']}]';
                                                                dataObj = JSON.parse(myJsonString);

                                                                myJsonString = '[';
                                                                for (j = 0; j < ListMcName.length; j++) {
                                                                    ListOfQty = [];
                                                                    for (i = 0; i < data.ListOfAlarm.length; i++) {
                                                                        if (ListMcName[j] == data.ListOfAlarm[i].MCName) {
                                                                            ListOfQty.push('[' + Date.parse(data.ListOfAlarm[i].StampDate) + ',' + data.ListOfAlarm[i].Timediff + ']');
                                                                        }
                                                                    }
                                                                    if (j < ListMcName.length - 1) {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] },'
                                                                    } else {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] }'
                                                                    }

                                                                }
                                                                myJsonString += ']'
                                                                ////myJsonString = JSON.stringify(ListOfTotal);
                                                                //test2 = '[{"name": "b","data": [' + ListOfQty[5] + ']}]';
                                                                dataObj2 = JSON.parse(myJsonString);

                                                            } else {//////Graph weekly && Monthly
                                                                for (i = 0; i < data.ListOfMC.length; i++) {
                                                                    ListMcName.push(data.ListOfMC[i].MCname);
                                                                }
                                                                var j = -1
                                                                for (i = 0; i < data.ListOfAlarm.length; i++) {
                                                                    if (data.ListOfAlarm.length > 0) {
                                                                        if (DateG[j] != data.ListOfAlarm[i].StampDate) {
                                                                            DateG.push(data.ListOfAlarm[i].StampDate);
                                                                            j++;
                                                                        }
                                                                    }

                                                                }
                                                                //******************************************************
                                                                //**               preparation Object Json 1
                                                                //******************************************************
                                                                myJsonString = '[';
                                                                for (j = 0; j < ListMcName.length; j++) {
                                                                    ListOfQty = [];
                                                                    for (i = 0; i < data.ListOfAlarm.length; i++) {
                                                                        if (ListMcName[j] == data.ListOfAlarm[i].MCName) {
                                                                            ListOfQty.push('[' + Date.parse(data.ListOfAlarm[i].StampDate) + ',' + data.ListOfAlarm[i].Qty + ']');
                                                                        }
                                                                    }
                                                                    if (j < ListMcName.length - 1) {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] },'
                                                                    } else {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] }'
                                                                    }

                                                                }
                                                                myJsonString += ']';
                                                                dataObj = JSON.parse(myJsonString);
                                                                //******************************************************
                                                                //**               End preparation Object Json 1
                                                                //******************************************************


                                                                //******************************************************
                                                                //**               preparation Object Json 2
                                                                //******************************************************
                                                                myJsonString = '[';
                                                                for (j = 0; j < ListMcName.length; j++) {
                                                                    ListOfQty = [];
                                                                    for (i = 0; i < data.ListOfAlarm.length; i++) {
                                                                        if (ListMcName[j] == data.ListOfAlarm[i].MCName) {
                                                                            ListOfQty.push('[' + Date.parse(data.ListOfAlarm[i].StampDate) + ',' + data.ListOfAlarm[i].Timediff + ']');
                                                                        }
                                                                    }
                                                                    if (j < ListMcName.length - 1) {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] },'
                                                                    } else {
                                                                        myJsonString += '{ "name" : "' + ListMcName[j] + '",' + ' "data" : [ ' + ListOfQty + ' ] }'
                                                                    }

                                                                }
                                                                myJsonString += ']';
                                                                dataObj2 = JSON.parse(myJsonString);
                                                                //******************************************************
                                                                //**               End preparation Object Json 2
                                                                //******************************************************
                                                            }


                                                            LoadGraph();
                                                        },
                                                        error: function (e) {
                                                            alert(DatePDStart + ' ' + DatePDEnd);
                                                        }
                                                    });

                                                }

                                                //******************************************************
                                                //**                Graph1
                                                //******************************************************
                                                function LoadGraph() {
                                                    Highcharts.setOptions({
                                                        colors: ['#2f7ed8', '#0d233a', '#8bbc21', '#910000', '#1aadce',
                                                                     '#492970', '#f28f43', '#77a1e5', '#c42525', '#a6c96a',
                                                                     '#008000', '#C0C0C0', '#FF0000', '#0000FF', '#FBB917',
                                                                     '#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5',
                                                                    '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
                                                    });
                                                    Highcharts.chart('AlarmGraph', {
                                                        chart: {
                                                            type: 'column'
                                                        },
                                                        title: {
                                                            text: 'Summary'
                                                        },


                                                        yAxis: {
                                                            title: {
                                                                text: 'Times'
                                                            },
                                                            //plotLines: [{
                                                            //    dashStyle: 'dash',
                                                            //    color: '#FF0000',
                                                            //    width: 2,
                                                            //    value: 100,
                                                            //    label: {
                                                            //        text: 'standard line',
                                                            //        align: 'right',
                                                            //        x: -10
                                                            //    }
                                                            //}]
                                                            stackLabels: {
                                                                enabled: true,
                                                            }
                                                        },
                                                        xAxis: {
                                                            type: "datetime",
                                                            format: "{value:%Y-%b-%d}",
                                                            title: {
                                                                text: 'Date'
                                                            }, crosshair: true,
                                                            labels: {
                                                                autoRotationLimit: 20
                                                            }
                                                        }, tooltip: {
                                                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                                                '<td style="padding:0"><b>{point.y:.0f} </b></td></tr>',
                                                            footerFormat: '</table>',
                                                            shared: true,
                                                            useHTML: true
                                                        }, plotOptions: {
                                                            series: {
                                                                cursor: 'pointer',
                                                                point: {
                                                                    events: {
                                                                        click: function (e) {
                                                                            //alert('Category: ' + this.series.name.toString().replace('&', ' ') + ', value: ' + this.y + ',Date:' + new Date(this.x).format('yyyy-MM-dd') + ',SDate:' + _DateStart + ",DateEnd:" + _DateEnd + ",Range:" + Range + ",Shift:" + _Shift + ",Volume:" + _Volume + ",listMC:" + listMC);
                                                                            return document.location.href = 'AlarmGraphDetail.aspx?DateStart=' + new Date(this.x).format('yyyy-MM-dd') + ' 08:00' + "&DateEnd=" + new Date(this.x).format('yyyy-MM-dd') + ' 20:00' + "&Fac=" + fac + "&MC=" + this.series.name.toString().replace('&', '@').replace(' ', '%') + "&Shift=" + _Shift + "&Line=" + Line.replace('&', '_').replace(' ', '%') + "&LineODM=" + LineODM
                                                                            //return document.location.href = 'http://localhost:56209/Monitoring/AlarmGraphDetail.aspx?DateStart=' + new Date(this.x).format('yyyy-MM-dd') + ' 08:00' + "&DateEnd=" + new Date(this.x).format('yyyy-MM-dd') + ' 20:00' + "&Fac=" + fac + "&MC=" + this.series.name.toString().replace('&', '@').replace(' ', '%') + "&Shift=" + _Shift + "&Line=" + Line.replace('&', '_').replace(' ', '%')

                                                                        }
                                                                    }
                                                                },
                                                                marker: {
                                                                    lineWidth: 1
                                                                }
                                                            },
                                                            column: {
                                                                stacking: 'stream',
                                                                pointPadding: 0.1,
                                                                borderWidth: 0,
                                                                dataLabels: {
                                                                    formatter: function () {
                                                                        if (this.y != 0) {
                                                                            return Highcharts.numberFormat(this.y, -1);
                                                                        }
                                                                    },
                                                                    enabled: false,
                                                                }
                                                            }, line: {
                                                                dataLabels: {
                                                                    enabled: true
                                                                },
                                                            }
                                                        },
                                                        series: dataObj,

                                                        responsive: {
                                                            rules: [{
                                                                condition: {
                                                                    maxWidth: 500
                                                                },
                                                                chartOptions: {
                                                                    legend: {
                                                                        layout: 'horizontal',
                                                                        align: 'center',
                                                                        verticalAlign: 'bottom'
                                                                    }
                                                                }
                                                            }]
                                                        }

                                                    });
                                                    //******************************************************
                                                    //**               Graph2
                                                    //******************************************************
                                                    Highcharts.chart('AlarmGraphTime', {
                                                        chart: {
                                                            type: 'column'
                                                        },
                                                        title: {
                                                            text: 'Summary'
                                                        },


                                                        yAxis: {
                                                            title: {
                                                                text: 'SECOND'
                                                            },
                                                            stackLabels: {
                                                                enabled: true,
                                                            }
                                                        },
                                                        xAxis: {
                                                            type: "datetime",
                                                            format: "{value:%Y-%b-%d}",
                                                            title: {
                                                                text: 'Date'
                                                            }, crosshair: true,
                                                            labels: {
                                                                autoRotationLimit: 20
                                                            }
                                                        }, tooltip: {
                                                            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                                                            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                                                                '<td style="padding:0"><b>{point.y:.0f} </b></td></tr>',
                                                            footerFormat: '</table>',
                                                            shared: true,
                                                            useHTML: true
                                                        }, plotOptions: {
                                                            series: {
                                                                cursor: 'pointer',
                                                                point: {
                                                                    events: {
                                                                        click: function (e) {
                                                                           
                                                                        }
                                                                    }
                                                                },
                                                                marker: {
                                                                    lineWidth: 1
                                                                }
                                                            },
                                                            column: {
                                                                stacking: 'stream',
                                                                pointPadding: 0.1,
                                                                borderWidth: 0,
                                                                dataLabels: {
                                                                    formatter: function () {
                                                                        if (this.y != 0) {
                                                                            return Highcharts.numberFormat(this.y, -1);
                                                                        }
                                                                    },
                                                                    enabled: false,
                                                                }
                                                            }, line: {
                                                                dataLabels: {
                                                                    enabled: true
                                                                },
                                                            }
                                                        },
                                                        series: dataObj2,

                                                        responsive: {
                                                            rules: [{
                                                                condition: {
                                                                    maxWidth: 500
                                                                },
                                                                chartOptions: {
                                                                    legend: {
                                                                        layout: 'horizontal',
                                                                        align: 'center',
                                                                        verticalAlign: 'bottom'
                                                                    }
                                                                }
                                                            }]
                                                        }

                                                    });


                                                    //******************************************************
                                                    //**               End Graph
                                                    //******************************************************


                                                }

                                            </script>

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
            <asp:PostBackTrigger ControlID="ddlFac" />
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnExport" />
            <%--<asp:PostBackTrigger ControlID="btnExport" />--%>
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
</asp:Content>

