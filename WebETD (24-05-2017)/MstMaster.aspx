<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="MstMaster.aspx.cs" Inherits="MstMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="page-header">
        <h1>
            <i class="icon-list"></i>
            MASTER
        </h1>
    </div>
    <div class="row">
        <table>
            <tr>
                <td width="20%">
                    <label class="control-label pull-right">Search : </label>
                </td>
                <td width="30%">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" MaxLength="10" AutoPostBack="True"></asp:TextBox>
                </td>
                <td width="30%">
                    <asp:DropDownList CssClass="form-control" ID="DropDownListModelName" runat="server" DataSourceID="SqlDataSourceModel" DataTextField="m_name" DataValueField="m_id"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceModel" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [m_id], [m_name] FROM [etd_mst_model] ORDER BY [m_name]"></asp:SqlDataSource>
                </td>
                <td width="20%">
                    <asp:LinkButton CssClass="btn btn-default" ID="btnSearch" runat="server" OnClick="btnSearch_Click">
                        <i class="icon-search "></i>
                    </asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <div class="square-widget">
        <div class="widget-head">
            <h4 class="pull-left">MASTER LIST</h4>
            <asp:Button CssClass="pull-right btn btn-success" ID="btnNewMaster" runat="server" Text="NEW" OnClick="btnNewMaster_Click" />
        </div>
        <div class="widget-container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView CssClass="table table-bordered stats-tbl-theme" ID="gridViewMasterList" runat="server" AutoGenerateColumns="False" OnRowCommand="gridViewMasterList_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Master No." DataField="of_id" SortExpression="of_id" ReadOnly="True" />
                            <asp:BoundField HeaderText="Model No." DataField="m_id" SortExpression="m_id" ReadOnly="True" />
                            <asp:BoundField HeaderText="Part name" DataField="p_name" SortExpression="p_name" ReadOnly="True" />
                            <asp:BoundField HeaderText="Part type name" DataField="pt_name" SortExpression="pt_name" ReadOnly="True" />
                            <asp:BoundField HeaderText="Part No." DataField="p_id" SortExpression="p_id" ReadOnly="True" Visible="False" />
                            <asp:BoundField HeaderText="Part Type No." DataField="pt_id" SortExpression="pt_id" ReadOnly="True" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="btn btn-danger form-control" CommandName="Editing" CommandArgument='<%# Eval("of_id") + "," + Eval("m_id") + "," + Eval("p_id") + "," + Eval("pt_id") %>' ID="btnEdit" runat="server" Text="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSearch" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

