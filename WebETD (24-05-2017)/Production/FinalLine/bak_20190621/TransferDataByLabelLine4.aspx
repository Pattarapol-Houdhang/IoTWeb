<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransferDataByLabelLine4.aspx.cs" Inherits="Production_FinalLine_TransferDataByLabelLine4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <%--<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Admin Panel Template" />

    <title>DCI IoT System</title>
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
            
        }
    </script>
    <style>
        body {
            background-color: #000;
            color: #fff;
        }
        .wrapper {
            display: inline-block;
            margin-top: 0px;
            padding: 5px;
            width: 100%;
            background-color: #000;
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
        .lblHead {
            font-size: 40px;
            text-align: center;
        }
        .lblHead2 {
            font-size: 40px;
            text-decoration:underline;
        }

        .btnTrans {
            background-color: #000000;
            width:100px;
            border-radius: 8px;
            cursor: pointer;
        }
        .btnTrans:hover {
            box-shadow: #fff 0px 0px 30px;
        }

        .btnReset {
            background-color: #000000;
            width:75px;
            border-radius: 8px;
        }
        .btnReset:hover {
            box-shadow: #fff 0px 0px 30px;
        }
        .tbl {
            font-size: 18px;
            border-collapse: collapse;
            text-space-collapse: collapse;
            border-top: 2px solid #fff;
            border-right: 2px solid #fff;
        }
        .tbl td {
            border-bottom: 2px solid #fff;
            border-left: 2px solid #fff;
        }
        .tbl th {
            border-bottom: 2px solid #fff;
            border-left: 2px solid #fff;
            color: #fff209;
            font-weight: bold;
            text-align:center!important;
            background-color: #7b7b7b;
        }
        .form-control {
            height: 40px!important;
        }
        .txtInput {
            font-size: 38px;
            background-color: #ffc543;
            width: 350px;
        }
        .lblError {
            font-size: 28px;
            color: #ff0000;
        }
        .boxContent {
            border: 2px solid #fff;
            padding: 10px;
            border-radius: 10px;
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
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>


    

    <section class="wrapper">

    <asp:Timer runat="server" id="UpdateTimer" interval="400" ontick="UpdateTimer_Tick" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger controlid="UpdateTimer" eventname="Tick" />
        </Triggers>
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td colspan="2" style="font-size: 22px; font-weight: bold;">
                        <asp:Label ID="lblEmployee" runat="server" ></asp:Label>
                    </td>
                    <td align="right" style="font-size: 18px; font-weight: bold; color: #40e208;">
                        <asp:Label ID="lblTime" runat="server" ></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

                

    <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblError" CssClass="lblError" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="boxContent" width="45%" align="center" valign="top">
                        <div class="lblHead">SERIAL ข้อมูลเก่า :</div>
                        <div style="padding-bottom: 15px;">
                            <asp:TextBox ID="txtSerialOld" MaxLength="11" runat="server" class="form-control txtInput" Text="" OnTextChanged="txtSerialOld_TextChanged"  AutoPostBack="true" ></asp:TextBox>
                        </div>
                        <div>
                            <table width="100%" class="tbl">
                                <tr>
                                    <th width="20%" align="center">OIL CHARGE</th>
                                    <th width="20%" align="center">RUNNING TEST</th>
                                    <th width="20%" align="center">LOW VOLTAGE</th>
                                    <th width="20%" align="center">N2 LEAK CHECK</th>
                                    <th width="20%" align="center">WEIGHT CHECK</th>
                                </tr>
                                <asp:Repeater ID="rptSerialOld" runat="server" OnItemDataBound="rptSerialOld_ItemDataBound"  >
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                <asp:Literal ID="ltrOil" runat="server" Text='<%# Eval("OilChargeData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrRun" runat="server" Text='<%# Eval("RunningTestData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrLow" runat="server" Text='<%# Eval("LowVoltageData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrN2" runat="server" Text='<%# Eval("N2LeackData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrWeight" runat="server" Text='<%# Eval("WeightCheckData") %>'></asp:Literal>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </td>
                    <td width="10%" align="center" valign="middle">
                        <asp:ImageButton ID="btnTransfer" CssClass="btnTrans" ToolTip="โอนถ่ายข้อมูล" runat="server" BorderWidth="0" ImageUrl="~/images/transfer-icon.png" OnClick="btnTransfer_Click" OnClientClick="return confirm('กดยืนยันเเพื่อโอนถ่ายข้อมูล')" />
                        <br /><br /><br />
                        <asp:ImageButton ID="btnReset" CssClass="btnReset" ToolTip="ล้างข้อมูล" runat="server" BorderWidth="0" ImageUrl="~/images/reset-icon.png" OnClick="btnReset_Click" />
                    </td>
                    <td class="boxContent" width="45%" align="center" valign="top">
                        <div class="lblHead">SERIAL ข้อมูลใหม่ :</div>
                        <div style="padding-bottom: 15px;">
                            <asp:TextBox ID="txtSerialNew" MaxLength="11" runat="server" class="form-control txtInput" Text="" OnTextChanged="txtSerialNew_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                        <div>
                            <table width="100%" class="tbl">
                                <tr>
                                    <th width="20%" align="center">OIL CHARGE</th>
                                    <th width="20%" align="center">RUNNING TEST</th>
                                    <th width="20%" align="center">LOW VOLTAGE</th>
                                    <th width="20%" align="center">N2 LEAK CHECK</th>
                                    <th width="20%" align="center">WEIGHT CHECK</th>
                                </tr>
                                <asp:Repeater ID="rptSerialNew" runat="server" OnItemDataBound="rptSerialNew_ItemDataBound"  >
                                    <ItemTemplate>
                                        <tr>
                                            <td align="center">
                                                <asp:Literal ID="ltrOil" runat="server" Text='<%# Eval("OilChargeData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrRun" runat="server" Text='<%# Eval("RunningTestData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrLow" runat="server" Text='<%# Eval("LowVoltageData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrN2" runat="server" Text='<%# Eval("N2LeackData") %>'></asp:Literal>
                                            </td>
                                            <td align="center">
                                                <asp:Literal ID="ltrWeight" runat="server" Text='<%# Eval("WeightCheckData") %>'></asp:Literal>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </section>


            


    <!-- container section start -->
        
    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>
    </div>
    </form>
    <script src="<%= ResolveUrl("~/StyleMax/js/moment.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-datepicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>

</body>
</html>
