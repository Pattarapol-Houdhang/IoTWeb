<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDColumnIndex_Detail.aspx.cs" Inherits="Production_Setting_PDColumnIndex_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="page-header">

                <h1>
                    <i class="icon-bars"></i>
                    Setting Index of Columns
            <small></small>
                </h1>

            </div>

            <div class="board-widget">
                <div class="row" style="margin-left: 5px;">
                    <asp:LinkButton ID="btBackPreviousPage" runat="server" OnClick="btBackPreviousPage_Click"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</asp:LinkButton>
                </div>
                <br />
                <div class="row">
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="col-md-8 widget-module">
                            <div class="box-widget">
                                <div class="widget-head clearfix">
                                    <span class="h-icon"><i class="icon-tree "></i></span>
                                    <h4 class="pull-left">Detail</h4>
                                    <div class="pull-right widget-action">
                                        <ul>
                                            <li><a href="#" class="widget-collapse"><i class="icon-arrow-down"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="widget-container" style="display: block;">
                                    <div class="widget-block">
                                        <div class="widget-content">
                                            <div class="form-horizontal form-box">
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Machine</label>
                                                    <div class="col-lg-4">
                                                        <asp:Label ID="lbMachine" runat="server" Text="" CssClass=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>
                </div>

                <div class="row">
                    <div class="col-md-12 col-sm-12">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal">
                            <div class="widget-container" style="display: block;">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                    CssClass="table table-bordered table-hover responsive"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                    OnSorting="GridView1_Sorting" PageSize="10">
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <div class="row">
                    <asp:Panel ID="Panel3" runat="server">
                        <div class="col-md-8 widget-module">
                            <div class="box-widget">
                                <div class="widget-head clearfix">
                                    <span class="h-icon"><i class="icon-cog-5 "></i></span>
                                    <h4 class="pull-left">Detail</h4>
                                    <div class="pull-right widget-action">
                                        <ul>
                                            <li><a href="#" class="widget-collapse"><i class="icon-arrow-down"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="widget-container" style="display: block;">
                                    <div class="widget-block">
                                        <div class="widget-content">
                                            <div class="form-horizontal form-box">
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Index Datetime</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtDatetime" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Index Part Number</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtPartNumber" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Index Model</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtModel" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Index Value</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtValue" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">Index Result</label>
                                                    <div class="col-lg-4">
                                                        <asp:TextBox ID="txtResult" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="form-group">    
                                                    <div class="col-lg-2"></div>                                                
                                                    <div class="col-lg-4">
                                                        <asp:Button ID="btSave" runat="server" CssClass="btn btn-success" Text="Save" />
                                                        <asp:Button ID="btCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" />
                                                    </div>
                                                   
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>
                </div>


            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

