<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="DailyReport.aspx.cs" Inherits="DailyReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-header">
        <h1>
            <i class="icon-clipboard-2"></i>
            DAILY REPORT : <asp:Label ID="lblLine" runat="server" Text=""></asp:Label>
            <small><asp:Label ID="Label2" runat="server" Text=""></asp:Label></small>
        </h1>
    </div>
    <div class="row">
        <div class="col-md-12 widget-module">
            <div class="box-widget">
                <%--<div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-6 control-label" ID="lblLineName" runat="server" Text="LINE NAME : "></asp:Label>
                    <div class="col-lg-10">
                        <asp:DropDownList CssClass="form-control" ID="dropDownListLineName" runat="server">
                            <asp:ListItem>MECHA LINE 1</asp:ListItem>
                            <asp:ListItem>MECHA LINE 3</asp:ListItem>
                            <asp:ListItem>MACHINE LINE FAC3</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>--%>
                <div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-6 control-label" ID="Label1" runat="server" Text="DATE : "></asp:Label>
                    <div class="col-lg-10">
                        <asp:TextBox CssClass="form-control datepicker" ID="txtDate" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-6 control-label" ID="lblShift" runat="server" Text="SHIFT : "></asp:Label>
                    <div class="col-lg-10">
                        <asp:DropDownList CssClass="form-control" ID="dropDownShift" runat="server">
                            <asp:ListItem Selected="True">DAY</asp:ListItem>
                            <asp:ListItem>NIGHT</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-3 form-group">
                    <asp:Label CssClass="col-lg-6 control-label" ID="Label3" runat="server" Text="SEARCH : " Visible="True" ForeColor="White"></asp:Label>
                    <div class="col-lg-10">
                        <asp:Button CssClass="btn btn-info" ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="square-widget">
        <div class="widget-head">
            <h4 class="pull-left">ACTUAL PRODUCT : (<asp:Label ID="lblSearchDateTime" runat="server" Text=""></asp:Label>)</h4> 
        </div>
        <div class="widget-container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView CssClass="table table-bordered stats-tbl-theme" ID="gridViewDailyProduce" runat="server" AutoGenerateColumns="False" OnRowCommand="gridViewDailyProduce_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="MODEL NO." ReadOnly="True" DataField="Model" />
                            <asp:BoundField HeaderText="MODEL NAME" ReadOnly="True" DataField="ModelName" />
                            <asp:BoundField HeaderText="PART" ReadOnly="True" DataField="PartName" />
                            <asp:BoundField HeaderText="ACTUAL" ReadOnly="True" DataField="Actual" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="btn btn-danger form-control" CommandName="viewReport" CommandArgument='<%# Eval("Model") + "," + Eval("ModelName") + "," + Eval("PartName") + "," + lblSearchDateTime.Text + "," + lblLine.Text %>' ID="btnViewReport" runat="server" Text="VIEW REPORT" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var today = new Date()
            // create DatePicker from input HTML element
            $(".datepicker").kendoDatePicker({
                format: "yyyy/MM/dd"
            });
        });
    </script>
</asp:Content>

