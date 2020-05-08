<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="PackingTracking.aspx.cs" Inherits="Production_Packing_PackingTracking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../StyleMax/js/jquery-1.8.3.min.js"></script>

    <script src="../../StyleMax/js/jquery.dataTables.min.js"></script>
    <script src="../../StyleMax/js/dataTables.buttons.min.js"></script>
    <script src="../../StyleMax/js/buttons.flash.min.js"></script>
    <script src="../../StyleMax/js/jszip.min.js"></script>
    <script src="../../StyleMax/js/pdfmake.min.js"></script>
    <script src="../../StyleMax/js/vfs_fonts.js"></script>
    <script src="../../StyleMax/js/buttons.html5.min.js"></script>
    <script src="../../StyleMax/js/buttons.print.min.js"></script>

    <link href="../../StyleMax/js/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../../StyleMax/js/buttons.dataTables.min.css" rel="stylesheet" />


    <link href="../../StyleMax/autocomplete/easy-autocomplete.css" rel="stylesheet" />
    <link href="../../StyleMax/autocomplete/easy-autocomplete.min.css" rel="stylesheet" />
    <link href="../../StyleMax/autocomplete/easy-autocomplete.themes.css" rel="stylesheet" />
    <link href="../../StyleMax/autocomplete/easy-autocomplete.themes.min.css" rel="stylesheet" />
    <script src="../../StyleMax/autocomplete/jquery.easy-autocomplete.js"></script>
    <script src="../../StyleMax/autocomplete/jquery.easy-autocomplete.min.js"></script>

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
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ],
            });

            var start = moment().subtract(29, 'days');
            var end = moment();
            //------------------ In Date -----------------
            $('#<%= txtInDate.ClientID %>').daterangepicker({
                maxSpan: {
                    "days": 7
                },
                autoUpdateInput: false,
                locale: {
                    cancelLabel: 'Clear',
                    format: 'DD/MM/YYYY'
                }                
            });

            $('#<%= txtInDate.ClientID %>').on('apply.daterangepicker', function (ev, picker) {//<----------- Event Date Apply
                $('#<%= txtInDate.ClientID %>').val(picker.startDate.format('DD/MM/YYYY') + ' - ' + picker.endDate.format('DD/MM/YYYY'));
                var id = "<%= txtInDate.ClientID %>";
                CaldiffDay(picker,id);

            });
            $('#<%= txtInDate.ClientID %>').on('cancel.daterangepicker', function (ev, picker) {//<----------- Event Daterange Clear
                $(this).val('');
            });
            //------------------ In Date -----------------

            //------------------ Out Date ------------------
            $('#<%= txtOutDate.ClientID %>').daterangepicker({
                autoUpdateInput: false,
                locale: {
                    cancelLabel: 'Clear',
                    format: 'DD/MM/YYYY'
                }
            });
            $('#<%= txtOutDate.ClientID %>').on('apply.daterangepicker', function (ev2, picker2) {//<----------- Event Date Apply
                $(this).val(picker2.startDate.format('DD/MM/YYYY') + ' - ' + picker2.endDate.format('DD/MM/YYYY'));
                var id = "<%= txtOutDate.ClientID %>";
                CaldiffDay(picker2, id);
            });
            $('#<%= txtOutDate.ClientID %>').on('cancel.daterangepicker', function (ev2, picker2) {//<----------- Event Date Apply
                $(this).val('');
            });
            //------------------ Out Date ------------------

            //------------------ Prd Date ----------------------
            $('#<%= txtPrdDate.ClientID %>').daterangepicker({
                autoUpdateInput: false,
                locale: {
                    cancelLabel: 'Clear',
                    format: 'DD/MM/YYYY'
                }
            });
            $('#<%= txtPrdDate.ClientID %>').on('apply.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val(picker3.startDate.format('DD/MM/YYYY') + ' - ' + picker3.endDate.format('DD/MM/YYYY'));
                var id = "<%= txtPrdDate.ClientID %>";
                CaldiffDay(picker3, id);
            });
            $('#<%= txtPrdDate.ClientID %>').on('cancel.daterangepicker', function (ev3, picker3) {//<----------- Event Date Apply
                $(this).val('');
            });
            //------------------ Prd Date ----------------------

            $('#<%= btnManual.ClientID %>').on('click', function () {
                var url = $(this).data('link');
                if (url != "") {
                    window.open(url);
                }
                
            }); 
        }

        //---------- Calculate StartDay - EndDay for alert in case more than 31 days -----------------------
        function CaldiffDay(picker,txtID) {
            var spStrDate = picker.startDate.format('DD/MM/YYYY').split("/");
            var strDate = new Date(spStrDate[2], spStrDate[1] - 1, spStrDate[0]);

            var spEndDate = picker.endDate.format('DD/MM/YYYY').split("/");
            var endDate = new Date(spEndDate[2], spEndDate[1] - 1, spEndDate[0]);

            var diffDay = new Date(endDate - strDate);
            var days = diffDay / 1000 / 60 / 60 / 24;

            if (days > 31) {
                $("#"+txtID).val('');
                alert('ไม่สามารถเลือกช่วงเวลาเกิน 31 วันได้ครับ');
            }
        }
        //---------- Calculate StartDay - EndDay for alert in case more than 31 days -----------------------


        //--------------- Auto Complete textbox by EasyAutocomplete JS -----------------------
        function Autocomplete() {
            var options = {
                url: "ModelJson.ashx",
                getValue: "Model",
                template: {
                    type: "description",
                    fields: {
                        description: "ModelCode"
                    }
                },
                list: {
                    match: {
                        enabled: true
                    }
                },
                theme: "Square"
            };

            $('#<%= txtModel.ClientID %>').easyAutocomplete(options);
        }
        //--------------- Auto Complete textbox by EasyAutocomplete JS -----------------------

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
        <Triggers>
        </Triggers>
        <ContentTemplate>

            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
                Sys.Application.add_load(Autocomplete);
            </script>

            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight:bold"><i class="fa fa-search"></i>Compressor Tracking</h3>
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
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Serial No.</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtSerial" runat="server" class="form-control"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-1 control-label" style="text-align: right!important">Pack No.</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtPack" runat="server" class="form-control"></asp:TextBox>
                                        </div>

                                        <label class="col-sm-1 control-label" style="text-align: right!important">Model</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtModel" runat="server" class="form-control"></asp:TextBox>
                                        </div>

                                        <%--<label class="col-sm-1 control-label" style="text-align: right!important">ModelCode</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtModelCode" runat="server" class="form-control"></asp:TextBox>
                                        </div>--%>
                                    </div>

                                    <div class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Production Date</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtPrdDate" runat="server" class="form-control" Text=""></asp:TextBox>
                                        </div>

                                        <label class="col-sm-1 control-label" style="text-align: right!important">In-Warehouse Date</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtInDate" runat="server" class="form-control" Text="" ToolTip="In Warehouse Date" ></asp:TextBox>
                                        </div>

                                        <label class="col-sm-1 control-label" style="text-align: right!important">Loading Date</label>
                                        <div class="col-sm-2">
                                            <asp:TextBox ID="txtOutDate" runat="server" class="form-control" Text="" ToolTip="Out Warehouse Date" ></asp:TextBox>
                                        </div>

                                        <div class="col-sm-3">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnClear" runat="server" class="btn btn-default btn" Style="margin-left: 15px" Text="Clear" OnClick="btnClear_Click" />
                                            <asp:Button ID="btnManual" runat="server" class="btn btn-warning btn" Style="margin-left: 15px" Text="Manual" data-link="http://websrv01.dci.daikin.co.jp/iotweb/Production/Packing/ManualPackingTracking.pdf"/>
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
                                Data
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <table class="table table-striped table-advance table-hover" id="example">
                                        <thead>
                                            <tr>
                                                <th>Serial</th>
                                                <th>Model</th>
                                                <th>ModelCode</th>
                                                <th>Packing</th>
                                                <th>PalletNo</th>
                                                <th>PalletId</th>
                                                <th>Type</th>
                                                <th>PDDate</th>
                                                <%--<th>Create Date</th>--%>
                                                <th>PackDate</th>
                                                <th>InDate</th>
                                                <th>LoadingDate</th>
                                                <th>Line NO</th>
                                                <th>Qut-Warehouse By</th>
                                                <th>Invoice</th>
                                                <th>Container</th>
                                                <th>Customer ID</th>
                                                <th>Customer Name</th>
                                                <th>ETD Date</th>
                                                <th>ETA Date</th>
                                                <th>Location Warehouse</th>
                                                <th>Booking No.</th>
                                                <th>Shiping To</th>
                                                
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptPacking" OnItemDataBound="rptPacking_ItemDataBound" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("prd_serial") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("prd_name") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("prd_cd") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("pck_no") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("pl_no") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("pl_code") %>'></asp:Label></td>
                                                        
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("pl_style") %>'></asp:Label></td>
                                                         <td>
                                                            <asp:Label ID="prdDate" runat="server" Text='<%# Eval("prd_date") %>'></asp:Label></td>
                                                        <%--<td>
                                                            <asp:Label ID="lbPlDate" runat="server" Text='<%# Eval("pl_date") %>'></asp:Label></td>--%>
                                                        <td>
                                                            <asp:Label ID="crDate" runat="server" Text='<%# Eval("cr_dt") %>'></asp:Label></td>
                                                       
                                                        <td>
                                                            <asp:Label ID="inDate" runat="server" Text='<%# Eval("in_dt") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="outDate" runat="server" Text='<%# Eval("out_dt") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("line_cd") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("reason_title") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label13" runat="server" Text='<%# Eval("inv_no") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label14" runat="server" Text='<%# Eval("ctn_no") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label15" runat="server" Text='<%# Eval("customer_id") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("customer_name") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbETDData" runat="server" Text='<%# Eval("etd_dt") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lbETAData" runat="server" Text='<%# Eval("eta_dt") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("location") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label19" runat="server" Text='<%# Eval("booking_id") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("ship_to") %>'></asp:Label></td>
                                                        
                                                        
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



    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>


</asp:Content>

