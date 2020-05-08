<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PDFinalUnHold.aspx.cs" Inherits="Quality_PDFinalUnHold" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<META HTTP-EQUIV="Refresh" CONTENT="300;" >--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    <script src="<%= ResolveClientUrl("~/Highcharts/highcharts.js") %>"></script>

    <script type="text/javascript" src="<%= ResolveClientUrl("../js/HoldUnhold.js") %>"></script>
    <%-- <script type="text/javascript" src="<%= ResolveClientUrl("../js/pareto.js") %>"></script>--%>


    <link href="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />

    <!---------------------- Script for set Tab Click --------------------->
    <script type="text/javascript">
        $(document).ready(function () <%--{
          $('#<%= txtCutting.ClientID %>').daterangepicker({
              autoUpdateInput: true,
              locale: {
                  cancelLabel: 'Close',
                  format: 'YYYY/MM/DD'
              }
          });--%>

            $('#taboverall').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetoverall');
            });

            $('#tabfactory').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetfactory');
            });

            $('#tabmodel').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetmodel');
            });

            $('#<%= hdClassActive.ClientID %>').val('activeenergy');
        });

        function SetTabClick() {
            //-------------- Set class active on div tab for working after updatepanel -----------------
            var checkActive = $('#<%= hdClassActive.ClientID %>').val();
            if (checkActive == "activetoverall") {
                $('#toverlall').addClass("active");
                $('#tfactory').removeClass("active");
                $('#tmodel').removeClass("active");
               
                $('#taboverall').click();
            } else if (checkActive == "activetfactory") {
                $('#tfactory').addClass("active");
                $('#toverlall').removeClass("active");
                $('#tmodel').removeClass("active");

                $('#tabfactory').click();
            } 
            else {
                $('#tfactory').addClass("active");
                $('#toverlall').removeClass("active");
                $('#tmodel').removeClass("active");

                             
                $('#taboverall').click();
            } 

          
            //-------------- Set class active on div tab for working after updatepanel -----------------

            //---------------- Set Hidden value on tab click ------------------
            $('#taboverall').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetoverall');
            });

            $('#tabfactory').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetfactory');
            });

            $('#tabmodel').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetmodel');
            });
       
            }
    </script>

    <!---------------------- Script for set Tab Click --------------------->





    <script type="text/javascript">
        function LoadData() {
            $('#example').DataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": true,
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
                var diffDays = diff / 1000 / 60 / 60 / 24;
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
        

        $(document).ready(function () {
            
            if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
            } else {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
            }

            $("#ContentPlaceHolder1_ckPrdSerialAll").click(function () {
                if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
                } else {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
                }
            });

        });

        var parameter = Sys.WebForms.PageRequestManager.getInstance();
        parameter.add_endRequest(function () {
            if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
            } else {
                $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
            }

            $("#ContentPlaceHolder1_ckPrdSerialAll").click(function () {
                if ($("#ContentPlaceHolder1_ckPrdSerialAll").is(':checked')) {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', true);
                } else {
                    $(".checkPrdSerial").parent().find('input[type="checkbox"]').prop('checked', false);
                }
            });

        });

        function GoToTarget(url, target) {
            window.open(url, target);
        }

    </script>
    <style type="text/css">
         table.dataTable thead th, table.dataTable thead td {
            padding: 3px 3px;
            border: 1px solid #d0d0d0!important;
            font-size: 11px;
        }
        table.dataTable tbody th, table.dataTable tbody td {
            padding: 3px 3px;
            border: 1px solid #d0d0d0!important;
            font-size: 11px;
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

    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DynamicLayout="false" DisplayAfter="0">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
                Sys.Application.add_load(LoadJavaScript);
                Sys.Application.add_load(SetTabClick);
            </script>



            <asp:HiddenField ID="hdClassActive" runat="server" />
            <!------------ Tab Program ------------------->
            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-exclamation-circle"></i>FACTORY 3 GRAPH HOLD</h3>
                    </div>
                </div>
            </section>

            <div class="row">
                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#toverall" data-toggle="tab" id="taboverall">OverAll</a></li>
                            <li><a href="#tfactory" data-toggle="tab" id="tabfactory">By Factory</a></li>
                            <li><a href="#tmodel" data-toggle="tab" id="tabmodel">By Model</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="active tab-pane " id="toverall">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="btnShowHideAll" data-graphall="#boxHoldGraphAll">(-)Show Graph Over All</div>
                                        <div id="boxHoldGraphAll" class="carousel slide" data-ride="carousel" style="height: 100%">
                                            <div id="gpHoldOvelAll" style="margin: 0 auto;"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane " id="tfactory">
                                <div class="row">
                                    <div class="btnShowHideFac" data-graphfac="#boxHoldGraphFac">(-)Show Graph by Factory </div>
                                    <div id="boxHoldGraphFac" class="carousel slide" data-ride="carousel" style="height: 100%">
                                        <div class="col-sm-4">
                                            <div id="gpHoldFAC1" style="margin: 0 auto;"></div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div id="gpHoldFAC2" style="margin: 0 auto;"></div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div id="gpHoldFAC3" style="margin: 0 auto;"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane " id="tmodel">
                                <div class="row">
                                    <div class="btnShowHideModel" data-graphmodell="#boxHoldGraphModel">(-)Show Graph by Model</div>
                                    <div id="boxHoldGraphModel" class="carousel slide" data-ride="carousel" style="height: 100%">
                                        <div class="col-sm-4">
                                            <div id="gpFGHold1"></div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div id="gpFGHold2"></div>
                                        </div>
                                        <div class="col-sm-4">
                                            <div id="gpFGHold3"></div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>





            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-exclamation-circle"></i>FACTORY 3 HOLD/UNHOLD</h3>
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
                                    <div class="row">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Status</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="ALL"> -- ALL --</asp:ListItem>
                                                <asp:ListItem Value="HOLD">FG HOLD</asp:ListItem>
                                                <asp:ListItem Value="LINEOUT">Line Out</asp:ListItem>
                                                <asp:ListItem Value="REQUEST" Selected="True">REQUEST UNHOLD</asp:ListItem>
                                                <asp:ListItem Value="ALLOW">UNHOLD</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>


                                        <label class="col-sm-1 control-label" style="text-align: right!important">Model</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtModel" runat="server" class="form-control"></asp:TextBox>
                                        </div>


                                        <label class="col-sm-1 control-label" style="text-align: right!important">Date</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtDate" runat="server" class="form-control" Text=""></asp:TextBox>
                                        </div>


                                        <div class="col-sm-3">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default btn" Style="margin-left: 15px" Text="Clear" />
                                            <asp:Button ID="btnUnHold" runat="server" class="btn btn-warning btn" Style="margin-left: 15px" Text="UnHold" OnClientClick="return confirm('ยืนยันการ UnHold ข้อมูล?');" OnClick="btnUnHold_Click" />
                                            <asp:Button ID="Button1" runat="server" class="btn btn-refresh" Text="Refresh" OnClick="btnSearch_Click" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
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
                                List Data Hold
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <table class="table table-striped table-advance table-hover" id="example" width="100%">
                                        <thead>
                                            <tr>
                                                <th align="center">
                                                    <asp:CheckBox ID="ckPrdSerialAll" runat="server" Text="ALL" />
                                                </th>
                                                <th align="center">Serial No</th>
                                                <th align="center">Model</th>
                                                <th align="center">ModelCode</th>
                                                <th align="center">Pallet No</th>
                                                <th align="center">Pipe No</th>
                                                <th align="center">Oil Charge</th>
                                                <th align="center">Running Test</th>
                                                <th align="center">Weight Check</th>
                                                <th align="center">Hold By</th>
                                                <th align="center">Hold Date</th>
                                                <th align="center">Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptPacking" runat="server" OnItemDataBound="rptPacking_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td align="center">
                                                            <span class="checkPrdSerial">
                                                                <asp:CheckBox ID="ckPrdSerial" runat="server" />
                                                            </span>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:Label ID="lblPrdSerial" runat="server" Text='<%# Eval("prd_serial") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblModelCode" runat="server" Text='<%# Eval("prd_model_code") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblModel" runat="server" Text='<%# Eval("prd_model") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblPalletNo" runat="server" Text=''></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblPipeNo" runat="server" Text='<%# Eval("prd_pipe_no") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblOilStatus" runat="server" Text='<%# Eval("OilingStatus") %>'></asp:Literal>
                                                        </td>
                                                        <td style="cursor: pointer; text-align: center;" onclick="GoToTarget('PDFinal_RunningTest.aspx?serial='+'0'+<%# Eval("prd_serial") %>, '_blank')">
                                                            <asp:Literal ID="lblRunStatus" runat="server" Text='<%# Eval("RunningTestStatus") %>'></asp:Literal>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblWeightStatus" runat="server" Text='<%# Eval("WeightCheckStatus") %>'></asp:Literal>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblHoldBy" runat="server" Text='<%# Eval("HoldBy") %>'></asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblHoldDate" runat="server" Text='<%# Eval("HoldDate") %>'></asp:Literal>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Literal ID="lblStatus" runat="server" Text='<%# Eval("prd_status") %>'></asp:Literal>
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
    </asp:UpdatePanel>


</asp:Content>

