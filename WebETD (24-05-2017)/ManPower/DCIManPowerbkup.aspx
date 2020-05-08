<%@ Page Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="DCIManPower.aspx.cs" Inherits="DCIManPower" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<META HTTP-EQUIV="Refresh" CONTENT="300;" >--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%= ResolveUrl("~/Styl/js/bootstrap-colorpicker.js") %>"></script>

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


    <link href="<%= ResolveUrl("~/StyleMax/js/jquery.dataTables.min.css") %>" rel="stylesheet" />
    <link href="<%= ResolveUrl("~/StyleMax/js/buttons.dataTables.min.css") %>" rel="stylesheet" />


    <script type="text/javascript" src="<%= ResolveClientUrl("../js/ManPower.js") %>"></script>

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

            $('#<%= hdClassActive.ClientID %>').val('activetfactory');
        });
        $('#tabtbwork').click(function (e) {
            $('#<%= hdClassActive.ClientID %>').val('activettablework');
        });


        function SetTabClick() {
            //-------------- Set class active on div tab for working after updatepanel -----------------
            var checkActive = $('#<%= hdClassActive.ClientID %>').val();
            if (checkActive == "activetfac1") {
                $('#tfac1').addClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').removeClass("active");
               
                $('#tfac1').click();
            } else if (checkActive == "activetfac2") {
                $('#tfac1').removeClass("active");
                $('#tfac2').addClass("active");
                $('#tfac3').removeClass("active");
               
                $('#tfac2').click();
            } 
            else if (checkActive == "activetfac3") {
                $('#tfac1').removeClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').addClass("active");
               
                $('#tfac3').click();
            } 
            else if (checkActive == "activettablework") {
                $('#tfac1').removeClass("active");
                $('#tfac2').removeClass("active");
                $('#tfac3').removeClass("active");
                $('#ttablework').addClass("active");
               
                $('#ttablework').click();
          
                //-------------- Set class active on div tab for working after updatepanel -----------------

                //---------------- Set Hidden value on tab click ------------------
          <%--  $('#taboverall').click(function (e) {
                $('#<%= hdClassActive.ClientID %>').val('activetoverall');
            });--%>

                $('#tabfac1').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activettfac1');
                });

                $('#tabfac2').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activetfac2');
                });
                $('#tabfac3').click(function (e) {
                    $('#<%= hdClassActive.ClientID %>').val('activetfac3');
                });
                }
         
    </script>

    <!---------------------- Script for set Tab Click --------------------->
    <style type="text/css">
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
                    <img alt="" src="~/StyleMax/icon/Gear-0.5s-200px.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript" language="javascript">
                //Sys.Application.add_load(LoadData);
                Sys.Application.add_load(LoadJavaScript);
                Sys.Application.add_load(SetTabClick);
             
            </script>



            <asp:HiddenField ID="hdClassActive" runat="server" />
            <!------------ Tab Program ------------------->
            <section class="wrapper">
                <div class="row">

                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-exclamation-circle"></i>MAN POWER</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li><a href="#toverall" data-toggle="tab" id="taboverall">OverAll</a></li>
                                <li><a href="#ttablework" data-toggle="tab" id="tabtbwork">Work-Hour data</a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="active tab-pane " id="toverall">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHideAll" data-graphall="#boxHoldGraphAll">(-)Graph All</div>
                                            <div id="boxHoldGraphAll" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                <div id="gpHoldOverAll" style="min-width: 1349px; height: 400px; margin: 0 auto"></div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane" id="ttablework">
                                    <div class="col-sm-12">
                                        <div class="btnShowHideWork" data-grabhtbwork="#boxTableWork">(-) Table Work</div>
                                        <div id="boxTableWork" class="carousel slide" data-ridge="carousel" style="height: 100%">
                                            <div class="row">
                                                <div class="col-sm-2" style="padding-top: 2px">

                                                    <div class="form-group">

                                                        <label>Select Year: </label>
                                                        <asp:DropDownList ID="ddlTabMPYear" class="form-control" runat="server" OnSelectedIndexChanged="ddlTabMPYear_SelectedIndexChanged" AutoPostBack="true" Width="132px">
                                                        </asp:DropDownList>

                                                        <label>Select Month: </label>

                                                        <asp:DropDownList ID="ddlTabMPMonth" class="form-control" runat="server" OnSelectedIndexChanged="ddlTabMPMonth_SelectedIndexChanged" AutoPostBack="true" Width="135px">
                                                        </asp:DropDownList>

                                                        <label>Select Line: </label>
                                                        <asp:DropDownList ID="ddtabCostCenter" class="form-control" runat="server" OnSelectedIndexChanged="ddtabCostCenter_SelectedIndexChanged" AutoPostBack="true" Width="400px">
                                                        </asp:DropDownList>

                                                    </div>

                                                </div>
                                            </div>
                                            <div class="box-body">
                                                <div class="row">
                                                    <div class="col-md-6" align="center">
                                                        <table id="tbManpowerWork1" class="display " width="100%" border="1">
                                                            <thead>
                                                                <tr>
                                                                    <th rowspan="2" style="text-align: center">Position
                                                                    </th>
                                                                    <th style="text-align: center" colspan="7">
                                                                        <asp:Label ID="lbTabMPHeaderWorkingHour" runat="server" Text="Working of Febuary (Hrs)"></asp:Label>
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <th style="text-align: center">f</th>
                                                                    <th style="text-align: center">1</th>
                                                                    <th style="text-align: center">1.5</th>
                                                                    <th style="text-align: center">2</th>
                                                                    <th style="text-align: center">3</th>
                                                                    <th style="text-align: center">Sum OT</th>
                                                                    <th style="text-align: center">Cost</th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="rptTabMpWorkingHour" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbPositionWKHr" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lpMPCount" runat="server" Text='<%# Eval("OT1") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT1" runat="server" Text='<%# Eval("OT1") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT15" runat="server" Text='<%# Eval("OT15") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT2" runat="server" Text='<%# Eval("OT2") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbOT3" runat="server" Text='<%# Eval("OT3") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbSumTime" runat="server" Text='<%# Eval("OT3") %>'></asp:Label>
                                                                            </th>
                                                                            <th style="text-align: center">
                                                                                <asp:Label ID="lbBudget" runat="server" Text='<%# Eval("OT3") %>'></asp:Label>
                                                                            </th>
                                                                        </tr>

                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                            <thead>

                                                                <tr>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="totalOP" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                    <th style="text-align: center">
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("") %>'></asp:Label>
                                                                    </th>
                                                                </tr>
                                                            </thead>


                                                        </table>



                                                        <asp:HiddenField ID="hdMPOPOT1" runat="server" />
                                                        <asp:HiddenField ID="hdMPOPOT2" runat="server" />
                                                        <asp:HiddenField ID="hdMPOPOT3" runat="server" />
                                                        <asp:HiddenField ID="hdMPLEOT1" runat="server" />
                                                        <asp:HiddenField ID="hdMPLEOT2" runat="server" />
                                                        <asp:HiddenField ID="hdMPLEOT3" runat="server" />
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </section>
            <section>
                <div class="row">
                    <div class="col-md-12">
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <%--     <li><a href="#toverall" data-toggle="tab" id="taboverall">OverAll</a></li>--%>
                                <li class="active"><a href="#tfac1" data-toggle="tab" id="tabfac1">Factory 1</a></li>
                                <li><a href="#tfac2" data-toggle="tab" id="tabfac2">Factory 2</a></li>
                                <li><a href="#tfac3" data-toggle="tab" id="tabfac3">Factory 3</a></li>
                                <li><a href="#todm" data-toggle="tab" id="tabODM">ODM</a></li>
                                <%--       <li class="active"><a href="#tfactory" data-toggle="tab" id="tabfactory">By Factory</a></li>--%>
                                <li><%--<a href="#tmodel" data-toggle="tab" id="tabmodel">By Model</a>--%></li>
                                <%--   <li><a href="#tmanpower" data-toggle="tab" id="tabmanpower">ManPower</a></li>--%>
                            </ul>

                            <div class="tab-content">
                                <div class="active tab-pane " id="tfac1">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHideFac1" data-graphfac1="#boxHoldGraphFac1">(-)Factory 1</div>
                                            <div id="boxHoldGraphFac1" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                <div id="gpHoldFAC1" style="min-width: 1349px; height: 400px; margin: 0 auto"></div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC1M"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC1A"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane " id="tfac2">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHideFac2" data-graphfac2="#boxHoldGraphFac2">(-)Factory 2</div>
                                            <div id="boxHoldGraphFac2" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                <div id="gpHoldFAC2" style="min-width: 1349px; height: 400px; margin: 0 auto"></div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC2M"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC2A"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFACSCRM"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFACSCRA"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC2MOM"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC2MOA"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="tab-pane " id="tfac3">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHideFac3" data-graphfac3="#boxHoldGraphFac3">(-)Factory 3</div>
                                            <div id="boxHoldGraphFac3" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                <div id="gpHoldFAC3" style="min-width: 1349px; height: 400px; margin: 0 auto"></div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC3M"></div>
                                                </div>
                                                <div class="col-sm-6">
                                                    <div id="gpManFAC3A"></div>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane " id="todm">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHideODM" data-graphodm="#boxHoldGraphODM">(-)ODM</div>
                                            <div id="boxHoldGraphODM" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                <div id="gpHoldODM" style="min-width: 1349px; height: 400px; margin: 0 auto"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--    <div class="active tab-pane " id="tfactory">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="btnShowHideFac" data-graphfac="#boxHoldGraphFac">(-)Show Graph by Factory</div>
                                            <div id="boxHoldGraphFac" class="carousel slide" data-ride="carousel" style="height: 100%">--%>
                            <%-- <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="btnShowHideFac1" data-graphfac1="#boxHoldGraphFac1">(-)Factory 1</div>
                                                        <div id="boxHoldGraphFac1" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div id="gpHoldFAC1" style="margin: 0 auto;"></div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                            <%--      <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="btnShowHideFac2" data-graphfac2="#boxHoldGraphFac2">(-)Factory 2</div>
                                                        <div id="boxHoldGraphFac2" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div id="gpHoldFAC2" style="margin: 0 auto;"></div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                            <%--      <div class="row">
                                                    <div class="col-sm-12">
                                                        <div class="btnShowHideFac3" data-graphfac3="#boxHoldGraphFac3">(-)Factory 3</div>
                                                        <div id="boxHoldGraphFac3" class="carousel slide" data-ride="carousel" style="height: 100%">
                                                            <div id="gpHoldFAC3" style="margin: 0 auto;"></div>
                                                        </div>
                                                    </div>
                                                </div>--%>

                            <%--        <div class="row">
                                    <div class="col-sm-12">
                                        <div class="btnShowHideODM" data-graphodm="#boxHoldGraphODM">(-)ODM</div>
                                        <div id="boxHoldGraphODM" class="carousel slide" data-ride="carousel" style="height: 100%">
                                            <div id="gpHoldODM" style="margin: 0 auto;"></div>
                                        </div>
                                    </div>
                                </div>--%>
                        </div>
                    </div>
                </div>
                </div>

                    <%-- <div class="tab-pane " id="tmodel">
                                    <div class="row">
                                        <div class="btnShowHideModel" data-graphmodell="#boxHoldGraphModel">(-)Show Graph by Model</div>
                                        <div id="boxHoldGraphModel" class="carousel slide" data-ride="carousel" style="height: 100%">
                                            <div class="row">
                                                <div class="col-sm-4">
                                                    <div id="gpFGHold1"></div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-4">
                                                    <div id="gpFGHold2"></div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-4">
                                                    <div id="gpFGHold3"></div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>--%>
                <%--        </div>
                        </div>
                    </div>
                </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
