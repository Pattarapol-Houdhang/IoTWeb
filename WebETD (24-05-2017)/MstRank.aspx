<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="MstRank.aspx.cs" Inherits="MstRank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>
            <i class="icon-list"></i>
            RANK
        </h1>
    </div>
    <div class="square-widget">
        <div class="widget-head">
            <h4 class="pull-left">Rank List</h4>
            <asp:Button CssClass="pull-right btn btn-success" ID="btnNewGroupRank" runat="server" Text="NEW" OnClick="btnNewGroupRank_Click" />
        </div>
        <div class="widget-container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView CssClass="table table-bordered stats-tbl-theme" ID="gridViewRankGroup" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="g_id" OnRowCommand="gridViewRankGroup_RowCommand" >
                        <Columns>
                            <asp:BoundField HeaderText="No." ReadOnly="True" DataField="g_id" />
                            <asp:BoundField HeaderText="Rank" ReadOnly="True" DataField="r_name" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="btn btn-danger form-control" CommandName="Editing" CommandArgument='<%# Eval("g_id") %>' ID="btnEdit" runat="server" Text="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT * FROM [etd_group_rank]"></asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

