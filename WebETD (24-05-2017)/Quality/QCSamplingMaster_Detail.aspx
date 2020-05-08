<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="QCSamplingMaster_Detail.aspx.cs" Inherits="Quality_QCSamplingMaster_Detail" %>


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
        function isDigitFloat(evt, txt) {
    var charCode = (window.Event) ? event.which : event.keyCode;

    if (charCode == 46 || charCode == 45 || (charCode >= 48 && charCode <= 57)) {

        return true;
    }

    return false;
}</script>

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
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-plus"></i>Add Data</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading ">
                                Searching
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Model Name</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control"></asp:DropDownList>

                                        </div>
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Part</label>
                                        <%--<asp:Label ID="lbPartType" class="col-sm-2 control-label" Style="text-align: right!important; font-size: xx-large;" runat="server" Text="Front_Head">Front Head</asp:Label>--%>

                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlPart" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListMain_Point_SelectedIndexChanged">
                                                <asp:ListItem Text="Front_Head" Value="Front_Head" />
                                                <asp:ListItem Text="Rear_Head" Value="Rear_Head" />
                                                <asp:ListItem Text="Crank_Shaft" Value="Crank_Shaft" />
                                                <asp:ListItem Text="Piston" Value="Piston" />
                                                <asp:ListItem Text="Cylinder" Value="Cylinder" />
                                            </asp:DropDownList>

                                        </div>


                                        <label class="col-sm-1 control-label" style="text-align: right!important">Main Point</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlMainPoint" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSub_Point_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Sub-Point</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlSubPoint" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">MQ Minimum</label>
                                        <div class="col-lg-1 col-sm-4 col-md-3">
                                            <asp:TextBox ID="txtMQMin" runat="server" CssClass="form-control" onkeypress="return isDigitFloat(event, this.value);" onFocus="this.select();" required>0.00000</asp:TextBox>

                                        </div>
                                        <label class="col-sm-1 control-label" style="text-align: right!important">MQ Maximun</label>
                                        <div class="col-lg-1 col-sm-4 col-md-3">
                                            <asp:TextBox ID="txtMQMax" runat="server" CssClass="form-control" onkeypress="return isDigitFloat(event, this.value);" onFocus="this.select();" required>0.00000</asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">UCL</label>
                                        <div class="col-lg-1 col-sm-4 col-md-3">
                                            <asp:TextBox ID="txtUCL" runat="server" CssClass="form-control" onkeypress="return isDigitFloat(event, this.value);" onFocus="this.select();" required>0.00000</asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">CL</label>
                                        <div class="col-lg-1 col-sm-4 col-md-3">
                                            <asp:TextBox ID="txtCL" runat="server" CssClass="form-control" onkeypress="return isDigitFloat(event, this.value);" onFocus="this.select();" required>0.00000</asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row" style="margin-top: 10px">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">LCL</label>
                                        <div class="col-lg-1 col-sm-4 col-md-3">
                                            <asp:TextBox ID="txtLCL" runat="server" CssClass="form-control" onkeypress="return isDigitFloat(event, this.value);" onFocus="this.select();" required>0.00000</asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="text-align: right!important">
                                        <div class="col-sm-2" style="margin-top: 10px">
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-primary btn" Text="Save" OnClick="btnSave_Click"  />
                                            <asp:Button ID="Button1" runat="server" class="btn btn-danger btn" Text="Cancel" OnClick="btnBack_Click" />
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
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="ddlMainPoint" />
        </Triggers>
    </asp:UpdatePanel>

    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>



</asp:Content>

