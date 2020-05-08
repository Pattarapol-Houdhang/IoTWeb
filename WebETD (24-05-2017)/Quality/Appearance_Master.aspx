<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageVersion2.master" AutoEventWireup="true" CodeFile="Appearance_Master.aspx.cs" Inherits="Quality_Appearance_Master" %>

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
            .ChkBoxClass input {width:25px; height:25px;}
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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadData);
            </script>
            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <section class="panel">
                            <header class="panel-heading">
                                <div class="row" style="text-align: left">
                                    <i class="fa fa-plus"></i>Master Appearance
                                </div>
                            </header>
                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="row">
                                        <label class="col-sm-1 control-label" style="text-align: right!important">Line</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlLine" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                        <label ID="lbM" class="col-sm-1 control-label" style="text-align: right!important" runat="server">Model</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged" Visible="true"></asp:DropDownList>
                                            <asp:TextBox ID="txtModelCode" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        </div>
                                        <label ID="lbA" class="col-sm-1 control-label" style="text-align: right!important" runat="server">Area</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlHeader" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPoint_SelectedIndexChanged1"></asp:DropDownList>
                                            <asp:TextBox ID="txtModel" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        </div>
                                        <label ID="lbP" class="col-sm-1 control-label" style="text-align: right!important" runat="server">Point</label>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlPoint" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPoint_SelectedIndexChanged2"></asp:DropDownList>
                                        </div>

                                    </div>


                                    <div class="row" style="margin-top: 10px">
                                        <div class="col-sm-2">

                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary btn" Text="Search" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnAdd" runat="server" class="btn btn-success btn" Text="Add New Detail" OnClick="btnAddDetail_Click" AutoPostBack="true" />

                                            <asp:Button ID="btnSave" runat="server" class="btn btn-success" Text="Save" Visible ="false"  OnClick="btnSave_Click"/>
                                            <asp:Button ID="btnCan" runat="server" class="btn btn-danger btn" Text="Cancel" Visible ="false" OnClick="btnCan_Click"/>
                                        </div>

                                        <asp:Label ID="lbPoint" class='col-sm-1 control-label' Style='text-align: right!important' runat="server" Visible="false">Point</asp:Label>
                                        <asp:Label ID="lbDetail" class='col-sm-1 control-label' Style='text-align: right!important' runat="server" Visible="false">Detail</asp:Label>
                                        <div class='col-sm-3 '>
                                            <asp:TextBox ID='txtNewPoint' runat='server' CssClass='form-control' Visible="false"></asp:TextBox>
                                            <asp:TextBox ID='txtNewDetail' runat='server' CssClass='form-control' Visible="false"></asp:TextBox>
                                        </div>
                                        <div class="col=sm-1">
                                            <asp:Button ID="btnOK" runat="server" class="btn btn-primary btn" Text="Save" Visible="false" AutoPostBack="true" OnClick="btnOK_Click" />
                                            <asp:Button ID="btnCancel" runat="server" class="btn btn-danger btn" Text="Cancel" Visible="false" AutoPostBack="true" OnClick="btnCancel_Click1" />
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
                                <asp:Label ID="data" Text="Data" runat="server" CssClass="col-lg-11" Font-Size="Large"></asp:Label>
                                <asp:Label ID="lbStatus" runat="server" Text="" ForeColor="Lime" CssClass="col-lg-3" Visible="true" Font-Size="Large"></asp:Label>
                                <asp:Button ID="btnNewModel" runat="server" class="btn btn-success btn col-lg-1" Text="+NewModel" OnClick="btnNewModel_Click" Style='text-align: left!important' />
                            </header>

                            <div class="panel-body">
                                <div class="form-group">
                                    <%--<asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-advance table-hover"
                                        OnRowDataBound="GridView1_RowDataBound" OnPreRender="GridView1_PreRender" AllowPaging="false">
                                    </asp:GridView>--%>
                                     <asp:Button ID="btnSelectAll" runat="server" class="btn btn-success btn" Text="SelectAll"  Style='text-align: left!important' OnClick="btnSelectAll_Click" Visible="false"/>
                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-advance table-hover"
                                        AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" AllowPaging="True"
                                        PageSize="120" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" Visible="false">
                                                <ItemTemplate>

                                                    <asp:CheckBox ID="CheckBox1" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                        CommandName="Select" CssClass="ChkBoxClass"  />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex%>'
                                                        CommandName="Editing" ImageUrl="~/images/Gridview/Files-Edit-File-icon.png" Width="14"
                                                        Visible='<%# Eval("CanEdit") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>

                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
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
                                            <asp:TemplateField HeaderText="ID" SortExpression="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Area" SortExpression="Area">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbHeader" runat="server" Text='<%# Eval("Area") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Point" SortExpression="Point">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbPoint" runat="server" Text='<%# Eval("Point") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Detail" SortExpression="Detail">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbDetail" runat="server" Text='<%# Eval("Detail") %>'></asp:Label>
                                                    <asp:TextBox ID="txtDetailEdit" runat="server" Visible="false"></asp:TextBox>
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
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Save" SortExpression="Save" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary btn " Visible="false"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex%>' CommandName="_Save" />
                                                    <asp:Button ID="btnCancelEdit" runat="server" Text="Cancel" class="btn btn-danger btn " Visible="false"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex%>' CommandName="_Cancel" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="15" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="15" />
                                            </asp:TemplateField>


                                        </Columns>
                                    </asp:GridView>



                                </div>
                            </div>
                            <asp:Button ID="btnUpTop" Text="<-Go to top of page->" OnClientClick="javascript:scroll(0,0);" runat="server"/>
                        </section>
                    </div>
                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="ddlPart" />--%>
            <asp:PostBackTrigger ControlID="ddlHeader" />
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="btnOK" />
            <asp:PostBackTrigger ControlID="btnCancel" />
            <asp:PostBackTrigger ControlID="ddlModel" />
            <asp:PostBackTrigger ControlID="btnUpTop" />
            <asp:PostBackTrigger ControlID="btnSelectAll" />
        </Triggers>
    </asp:UpdatePanel>


    <script src="<%= ResolveUrl("~/StyleMax/js/bootstrap-colorpicker.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/daterangepicker.js") %>"></script>


</asp:Content>

