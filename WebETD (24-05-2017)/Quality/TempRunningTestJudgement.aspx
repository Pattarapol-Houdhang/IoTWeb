<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TempRunningTestJudgement.aspx.cs" Inherits="Quality_TempRunningTestJudgement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <%--<META HTTP-EQUIV="Refresh" CONTENT="300;" >--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Admin Panel Template" />

    <title>Temp RunningTest Judgement</title>
    <link rel="icon" href="<%= ResolveUrl("~/images/daikin.ico") %>">

   <%-- <script src="../StyleMax/js/jquery-1.8.3.min.js"></script>--%>

    <!-- Bootstrap CSS -->
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
    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>

    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/dataTables.buttons.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.flash.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jszip.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/pdfmake.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/vfs_fonts.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.html5.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/buttons.print.min.js") %>"></script>

    <link href="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />


    <script type="text/javascript">

        function LoadData() {
            $('#example').DataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": false,
                "paging": true,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'print'
                ]
            });

            //------------------ Prd Date ----------------------
            $('#<%= txtDate.ClientID %>').daterangepicker({
                autoUpdateInput: true,
                //startDate: moment().startOf('month'),
                //endDate: moment().endOf('month'),
                locale: {
                    cancelLabel: 'Clear',
                    format: 'DD/MM/YYYY'
                }
            });


            $('#<%= txtDate.ClientID %>').on('apply.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                //$(this).val(picker3.startDate.format('DD/MM/YYYY') + ' - ' + picker3.endDate.format('DD/MM/YYYY'));

                var diff = new Date(picker3.endDate - picker3.startDate);
                var diffDays = diff/1000/60/60/24;
                if (parseInt(diffDays) <= 31) {
                    $(this).val(picker3.startDate.format('DD/MM/YYYY') + ' - ' + picker3.endDate.format('DD/MM/YYYY'));
                } else {
                    alert('ห้ามเลือกเกิน 31 วัน!');
                    $(this).val('');
                }
           });
           
            $('#<%= txtDate.ClientID %>').on('cancel.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val('');
            });
            //------------------ Prd Date ----------------------
        }

        

    </script>
    <style>
        .wrapper {
            display: inline-block;
            margin-top: 0px;
            padding: 5px;
            width: 100%;
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
</head>
<body>
    <form id="form1" runat="server">
    <div class="main-container">
        <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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

            <section class="wrapper">
                <%--<div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight:bold"><i class="fa fa-exclamation-circle"></i>Compressor HOLD</h3>
                    </div>
                </div>--%>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                Searching
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Status</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" >
                                                <asp:ListItem Value="ALL"> -- ALL --</asp:ListItem>
                                                <asp:ListItem Value="OK">OK</asp:ListItem>
                                                <asp:ListItem Value="NG">NG</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        

                                        <label class="col-sm-1 control-label" style="text-align: right!important">Date</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtDate" runat="server" class="form-control" Text="" ></asp:TextBox>
                                        </div>


                                        <div class="col-sm-3">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Search" OnClick="btnSearch_Click"  />
                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default" Style="margin-left: 15px" Text="Clear"  />
                                            <asp:Button ID="Button1" runat="server" class="btn btn-refresh" Text="Refresh" OnClick="btnSearch_Click"  />
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
                            <header class="panel-heading">Temp Running Test Judgement List</header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <table class="table table-striped table-advance table-hover" id="example" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Serial No</th>
                                                <th>Model</th>
                                                <th>Running Test Value</th>
                                                <th>Running Test Result</th>
                                                <th>Record By</th>
                                                <th>Record Date</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptRunningTest" runat="server" OnItemDataBound="rptRunningTest_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Literal ID="lblPrdSerial" runat="server" Text='<%# Eval("SerialNO") %>'></asp:Literal>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblModel" runat="server" Text='<%# Eval("ModelCode") %>'></asp:Literal>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblRunValue" runat="server" Text='<%# Eval("JudgementValue") %>'></asp:Literal>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblRunStatus" runat="server" Text='<%# Eval("JudgementResult") %>'></asp:Literal>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Literal ID="lblCreateBy" runat="server" Text='<%# Eval("CreateBy") %>'></asp:Literal>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblCreateDate" runat="server" Text='<%# Eval("CreateDate") %>'></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>


            
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="btnSearch" />--%>
        </Triggers>
    </asp:UpdatePanel>

    <!-- container section start -->
        
        <script>
            //knob
            $(function () {
                $(".knob").knob({
                    'draw': function () {
                        $(this.i).val(this.cv + '%')
                    }
                })
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

            //custom select box

            $(function () {
                $('select.styled').customSelect();
            });

        </script>

    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
    </div>
    </form>
        <script src="<%= ResolveUrl("~/StyleMax/js/moment.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-datepicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>

</body>
</html>
