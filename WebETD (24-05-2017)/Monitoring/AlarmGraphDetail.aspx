<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="AlarmGraphDetail.aspx.cs" Inherits="AlarmGraphDetail" %>

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

    <%--<script src="<%= ResolveUrl("~/Highcharts/highstock.js") %>"></script>--%>
    <%--<script src="<%= ResolveUrl("~/Highcharts/exporting.js") %>"></script>
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
        function myFunction() {
            //document.getElementById("UpdatePanel1").style.display = "block";
            document.getElementById("loader").style.display = "block";
        }
        //function showLoadingBar() {
        //    $("#loader").show();
        //}
        function Search_Gridview(strKey, strGV) {
            try {
                var strData = strKey.substring(0,5).toLowerCase();
            } catch (Exception) {
                var strData = strKey.value.toLowerCase().split(" ");
            }
            var tblData = document.getElementById('<%= GridView1.ClientID %>');
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }    


        function LoadData() {


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
            $('#<%= txtPrdDate.ClientID %>').daterangepicker({
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


            $('#<%= txtPrdDate.ClientID %>').on('apply.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val(picker3.startDate.format('YYYY/MM/DD HH:mm') + ' - ' + picker3.endDate.format('YYYY/MM/DD HH:mm'));
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

        }


        //---------- Calculate StartDay - EndDay for alert in case more than 31 days -----------------------
        function CaldiffDay(picker, txtID) {
            var spStrDate = picker.startDate.format('YYYY/MM/DD HH:mm').split("/");
            var strDate = new Date(spStrDate[2], spStrDate[1] - 1, spStrDate[0]);

            var spEndDate = picker.endDate.format('YYYY/MM/DD HH:mm').split("/");
            var endDate = new Date(spEndDate[2], spEndDate[1] - 1, spEndDate[0]);

            var diffDay = new Date(endDate - strDate);
            var days = diffDay / 1000 / 60 / 60 / 24;

            if (days > 31) {
                $("#" + txtID).val('');
                alert('ไม่สามารถเลือกช่วงเวลาเกิน 31 วันได้ครับ');
            }
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
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <script type="text/javascript" language="javascript">
        Sys.Application.add_load(LoadData);
    </script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section class="wrapper">

                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>AlarmGraphDetail</h3>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnMain" runat="server" class="btn btn-success btn-lg" Text="Home" AutoPostBack="true" OnClick="btnMain_Click" />
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

                                    <div id="search_datetime" runat="server" class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Factory</label>
                                        <div class="col-sm-2" id="Div1" runat="server" style="margin-top: 10px">
                                            <asp:DropDownList ID="ddlFac" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlFac_SelectedIndexChanged">
                                                <asp:ListItem Text="-" Value="-" />
                                                <asp:ListItem Text="Fac3" Value="Fac3" />
                                                <asp:ListItem Text="ODM" Value="ODM" />
                                            </asp:DropDownList>
                                        </div>
                                        <div id="divLineMC" runat="server" visible="false">
                                            <label id="lbLineMC" runat="server" class="col-sm-1 control-label" style="text-align: right!important">Line Machine</label>
                                            <div class="col-sm-2" id="LineMC" runat="server" style="margin-top: 10px">
                                                <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    <%--<asp:ListItem Text="-" Value="-" />--%>
                                                    <asp:ListItem Text="Main Assembly Line 6" Value="Main Assembly Line 6" />
                                                    <asp:ListItem Text="Mecha Line 6" Value="Mecha Line 6" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div id="divLineODM" runat="server" visible="false">
                                            <label id="lbLineODM" runat="server" class="col-sm-1 control-label" style="text-align: right!important">Line</label>
                                            <div class="col-sm-2" id="divLineODM2" runat="server" style="margin-top: 10px">
                                                <asp:DropDownList ID="ddlLineODM" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLineODM_SelectedIndexChanged">
                                                    <%--<asp:ListItem Text="-" Value="-" />--%>
                                                    <asp:ListItem Text="INDOOR" Value="IN" />
                                                    <asp:ListItem Text="OUTDOOR" Value="OUT" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <label id="lbMC" class="col-sm-1 control-label" runat="server" style="text-align: right!important" visible="false">Machine Name</label>
                                        <div class="col-sm-2" id="divMCName" runat="server" style="margin-top: 10px" visible="false">
                                            <div>
                                                <asp:DropDownList ID="ddlMC" runat="server" Visible="false" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="col-sm-3" id="divDate" runat="server" style="margin-top: 10px">
                                        <label id="lbDate" class="col-sm-2 control-label" style="text-align: right!important">Date</label>
                                        <div class="col-sm-9">
                                            <asp:TextBox ID="txtPrdDate" runat="server" class="form-control" Text=""></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row" style="margin-top: 10px" runat="server">
                                        <div class="row" style="margin-top: 10px">

                                            <div class="col-sm-2">
                                                <asp:Button ID="btnSearch" runat="server" class="btn btn-success btn-lg" Text="Show" AutoPostBack="true" OnClick="btnSearch_Click" OnClientClick="myFunction()" />
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
                                        <div class="col-sm-5">
                                            <asp:Button ID="btnExportG" runat="server" class="btn btn-success btn" Text="Export to Excel" OnClick="btnExportG_Click" />
                                            <span style="color: red;">** Export Graph to excel file.
                                                ** ดาวโหลดไฟล์ข้อมูล Excel </span>
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
                            <header class="panel-heading">
                                Graph : 
                        <asp:Label ID="DateShow" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:Label ID="FullDate" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>

                            </header>
                            <div class="panel-body">
                                <%--<h1>AlarmGraph </h1>--%>
                                <div id="AlarmGraphDetail">
                                </div>
                                <script>

                                    $(document).ready(function () {
                                        LoadGraph();

                                    });
                                        

                                    function LoadGraph() {
                                        var dataObj = <%=JsonString%>;
                                        var listPB_Behind = <%=getListPB%>;
                                        const chart = Highcharts.chart('AlarmGraphDetail', {
                                            chart: {
                                                type: 'column',
                                                events: {
                                                    click: function (e) {
                                                        Search_Gridview(listPB_Behind[Math.floor(e.xAxis[0].value)+1],'GridView1')
                                                    }
                                                }
                                            },
                                            title: {
                                                text: 'Alarm Detail Graph'
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
                                                categories : listPB_Behind,
                                                title: {
                                                    text: 'Problem'
                                                }, crosshair: true
                                                ,
                                                scrollbar: {
                                                    enabled: true
                                                },
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
                                                                Search_Gridview(this.category.toString(),'GridView1')
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
                                    }
                                    

                                </script>

                            </div>

                        </section>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                Last Alarm History
                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red" Font-Bold="true" Visible="false"></asp:Label>

                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row" style="margin-top: 10px;" runat="server">
                                        <div class="col-sm-5">
                                            <asp:Button ID="btnExport" runat="server" class="btn btn-success btn" Text="Export to Excel" OnClick="btnExport_Click" />
                                            <span style="color: red;">** Export data to excel file.
                                                ** ดาวโหลดไฟล์ข้อมูล Excel </span>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="row" style="margin-top: 10px" runat="server">
                                        <div class="row" style="text-align: right!important; margin-top: 10px; margin-bottom: 10px; margin-right: 50px" runat="server">
                                            Search :
                                    <asp:TextBox ID="txtSearch" runat="server" Font-Size="20px" onkeyup="Search_Gridview(this, 'GridView1')"></asp:TextBox><br />
                                        </div>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="false" CssClass="table table-striped table-advance table-hover"
                                            OnPageIndexChanging="GridView1_PageIndexChanging">
                                            <Columns>

                                                <asp:TemplateField HeaderText="Machine" SortExpression="ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbID" runat="server" Text='<%# Eval("MachineName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="AlarmDetail" SortExpression="Area">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbHeader" runat="server" Text='<%# Eval("AlarmDetail") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" SortExpression="Point">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbPoint" runat="server" Text='<%# Eval("DateStart") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                                </asp:TemplateField>



                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>
            <%--</ContentTemplate>--%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ddlFac" />
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
</asp:Content>

