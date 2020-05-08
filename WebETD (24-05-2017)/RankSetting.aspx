<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="RankSetting.aspx.cs" Inherits="RankSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>
            <i class="icon-list"></i>
            RANK MASTER
        </h1>
    </div>
    <div class="square-widget">
        <div class="widget-head">
            <!--h4 class="pull-left">Rank Setting</h4-->
            <asp:HiddenField ID="hidRankID" runat="server" Value="0" />
            <asp:Button CssClass="pull-right btn btn-success" ID="btnAddNewRank" runat="server" Text="NEW" OnClick="btnAddNewRank_Click" />
        </div>
        <div class="widget-container">
            <asp:GridView ID="GridViewRank" CssClass="table table-bordered stats-tbl-theme" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="r_id" ClientIDMode="Static" OnLoad="GridViewRank_Load" OnRowCommand="GridViewRank_RowCommand" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate >
                            <asp:CheckBox ID="CheckBoxRank" runat="server" CssClass="checkbox-inline"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="r_name" HeaderText="Rank Name" SortExpression="r_name" />
                    <asp:BoundField DataField="r_color" HeaderText="Rank Color" SortExpression="r_color" />
                    <asp:TemplateField>
                        <ItemTemplate >
                            <asp:Button CssClass="btn btn-danger form-control" CommandName="Editing" CommandArgument='<%# Eval("r_id") %>' ID="btnEdit" runat="server" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT * FROM [etd_mst_rank]"></asp:SqlDataSource>

            <asp:Label ID="lblData" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="col col-lg-10 row">
        <div class="pull-right form-group">
            <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
            <asp:LinkButton CssClass="btn btn-default" ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
            <asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" Visible="False"  />
        </div>
    </div>
</asp:Content>

