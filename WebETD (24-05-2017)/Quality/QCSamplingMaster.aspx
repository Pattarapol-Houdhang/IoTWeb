<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="QCSamplingMaster.aspx.cs" Inherits="QCSamplingMaster" %>

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
                        <h3 class="page-header" style="margin-top: 0px !important; font-weight: bold"><i class="fa fa-search"></i>History Data</h3>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                <div class="row">
                                    <label class="col-sm-1 control-label" style="text-align: right!important; font-size: xx-large;">Part : </label>
                                    <asp:Label ID="lbPartType" class="col-sm-2 control-label" Style="text-align: right!important; font-size: xx-large;" runat="server" Text="Front_Head">Front Head</asp:Label>

                                </div>
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row">
                                        <%--<label class="col-sm-1 control-label" style="text-align: right!important">Part</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlPart" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListMain_Point_SelectedIndexChanged">
                                                <asp:ListItem Text="Front_Head" Value="Front_Head" />
                                                <asp:ListItem Text="Rear_Head" Value="Rear_Head" />
                                                <asp:ListItem Text="Crank_Shaft" Value="Crank_Shaft" />
                                                <asp:ListItem Text="Piston" Value="Piston" />
                                                <asp:ListItem Text="Cylinder" Value="Cylinder" />
                                            </asp:DropDownList>
                                            
                                        </div>--%>

                                        <label class="col-sm-1 control-label" style="text-align: right!important">Main Point</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlMainPoint" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSub_Point_SelectedIndexChanged"></asp:DropDownList>

                                        </div>
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Sub-Point</label>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlSubPoint" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="row" style="margin-top: 10px">
                                        <div class="col-sm-3">
                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnAdd" runat="server" class="btn btn-success btn" Text="Add" OnClick="btnAdd_Click" />
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
                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-advance table-hover" OnRowDataBound="GridView1_RowDataBound"
                                        AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" AllowPaging="True" AllowSorting="True"
                                        PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                        CommandName="Editing" ImageUrl="~/images/Gridview/Files-Edit-File-icon.png" Width="14"
                                                        Visible='<%# Eval("CanEdit") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Del.">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("ID") %>'
                                                        CommandName="Deleting" ImageUrl="~/images/Gridview/Editing-Delete-icon 24.png"
                                                        Width="14" OnClientClick="return confirm('ต้องการลบข้อมูล ใช่หรือไม่?');"
                                                        Visible='<%# Eval("CanDel") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="ID" SortExpression="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="ModelCode" SortExpression="ModelCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbModelCode" runat="server" Text='<%# Eval("ModelCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MainPoint" SortExpression="MainPoint">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbMainPoint" runat="server" Text='<%# Eval("MainPoint") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubPoint" SortExpression="SubPoint">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbSubPoint" runat="server" Text='<%# Eval("SubPoint") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MQMin" SortExpression="MQMin">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbMQMin" runat="server" Text='<%# Eval("MQMin") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MQMax" SortExpression="MQMax">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbMQMax" runat="server" Text='<%# Eval("MQMax") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UCL" SortExpression="UCL">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbUCL" runat="server" Text='<%# Eval("UCL") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CL" SortExpression="CL">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbCL" runat="server" Text='<%# Eval("CL") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LCL" SortExpression="LCL">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbLCL" runat="server" Text='<%# Eval("LCL") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UpdateBy" SortExpression="UpdateBy">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbUpdateBy" runat="server" Text='<%# Eval("UpdateBy") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UpdateDate" SortExpression="UpdateDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbUpdateDate" runat="server" Text='<%# Eval("UpdateDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>



                                </div>
                            </div>
                        </section>
                    </div>
                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="ddlPart" />--%>
            <asp:PostBackTrigger ControlID="ddlMainPoint" />
            <asp:PostBackTrigger ControlID="ddlSubPoint" />
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>


</asp:Content>

