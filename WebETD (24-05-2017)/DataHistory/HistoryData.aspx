<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="HistoryData.aspx.cs" Inherits="HistoryData_HistoryData" %>

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

    <script type="text/javascript">
        function FormatNumberLength(num, length) {
            var r = "" + num;
            while (r.length < length) {
                r = "0" + r;
            }
            return r;
        }

        function GetFileName() {
            var result = "";

            var txtDateSearch = $('#<%= HiddenField1.ClientID %>').val();
            var _ddlLine = $('#<%= ddlLine.ClientID %>');
            var _ddlMachine = $('#<%= ddlMachine.ClientID %>');
            var LineSelect = $('#<%=ddlLine.ClientID %>').find(":selected").text();
            var MachineSelect = $('#<%=ddlMachine.ClientID %>').find(":selected").text();
            var selected = $('#<%=rbSearchSelect.ClientID %> input:checked').val();

            var d = new Date();
            var month = d.getMonth() + 1;
            var day = d.getDate();
            var year = d.getFullYear();
            var hour = d.getHours();
            var minute = d.getMinutes();
            var second = d.getSeconds();

            result = "IoTData_" + year + FormatNumberLength(month, 2) + FormatNumberLength(day, 2) + "_"
                + FormatNumberLength(hour, 2) + FormatNumberLength(minute, 2) + FormatNumberLength(second, 2)
                + "_" + LineSelect.split(' ').join('_') + "_" + MachineSelect + "_";

            if (selected == "1") {
                if (txtDateSearch == "") {
                    txtDateSearch = $('#<%=txtPrdDate.ClientID %>').val();
                }
                txtDateSearch = txtDateSearch.split('-').join('to');
                txtDateSearch = txtDateSearch.split('/').join('-');
                result += txtDateSearch;


            }

            //alert(result);
            return result;
        }

        function LoadData() {
            $('#example').DataTable({
                "scrollX": true,
                "scrollCollapse": true,
                "ordering": true,
                "paging": true,
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                dom: 'Bfrtip',
                buttons: [
                    //'copy', 'csv', 'excel', 'pdf', 'print'
                    {
                        extend: 'copy',
                        title: GetFileName()
                    },
                    {
                        extend: 'csv',
                        title: GetFileName()
                    },
                    {
                        extend: 'excel',
                        title: GetFileName()
                    },
                    {
                        extend: 'pdf',
                        title: GetFileName()
                    },
                    {
                        extend: 'print',
                        title: GetFileName()
                    }
                ],
            });

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
                    <img alt="" src="<%= ResolveUrl("~/StyleMax/icon/Gear-0.5s-200px.gif") %>" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>

            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>
                            <asp:Label ID="lbContent" runat="server" Text="Label"></asp:Label></h3>
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
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Select Line No.</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                        <label class="col-sm-1 control-label" style="text-align: right!important"><asp:Label ID="lbMachine" runat="server" Text="Label1">Select Machine</asp:Label></label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlMachine" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMachine_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Select Type Search</label>
                                        <div class="col-sm-2">
                                            <asp:RadioButtonList ID="rbSearchSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblSearchType_SelectedIndexChanged">
                                                <asp:ListItem Text="Datetime" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Serial No." Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>

                                    </div>

                                    <div id="search_datetime" runat="server" class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Production Date</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtPrdDate" runat="server" class="form-control" Text=""></asp:TextBox>
                                        </div>
                                    </div>

                                    <div id="search_serial" runat="server" class="row" style="margin-top: 10px" visible="false">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Serial No.</label>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtSerialNo" runat="server" class="form-control" Text="" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <asp:Label ID="lbSerialType" runat="server" Text="" CssClas="col-sm-1 control-label" ForeColor="Red"></asp:Label>
                                    </div>

                                    <div class="row" style="margin-top: 10px">
                                        <div class="col-sm-1">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn" Text="Search" OnClick="btnSearch_Click" />
                                        </div>
                                        <div class="col-sm-10">
                                            <asp:Button ID="btExport" runat="server" class="btn btn-success btn" Text="Export to Excel" OnClick="btExport_Click"/>
                                            <span style="color: red;">** Export data to excel file without generate to table below.
                                                ** ดาวโหลดไฟล์ข้อมูล Excel ได้โดยตรง โดยไม่ต้องสร้างตารางด้านล่างก่อน สำหรับดึงข้อมูลไปทำไฟล์ Excel โดยไม่ต้องรอนาน</span>
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
                                    <%--<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-advance table-hover"
                                        OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender" AllowPaging="false">
                                    </asp:GridView>--%>


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

                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="rbSearchSelect" />
            <asp:PostBackTrigger ControlID="ddlLine" />
            <asp:PostBackTrigger ControlID="ddlMachine" />
            <asp:PostBackTrigger ControlID="btExport" />

            <%--<asp:PostBackTrigger ControlID="btnSearch" />--%>
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>


</asp:Content>

