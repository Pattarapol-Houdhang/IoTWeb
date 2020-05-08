<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="MstModel.aspx.cs" Inherits="MstModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">
        <h1>
            <i class="icon-list"></i>
            MODEL
        </h1>
    </div>
    <div class="row">
        <table>
            <tr>
                <td width="20%">
                    <label class="control-label pull-right">Search : </label>
                </td>
                <td width="60%">
                    <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" MaxLength="10" AutoPostBack="True"></asp:TextBox>
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
            <h4 class="pull-left">MODEL LIST</h4>
            <asp:Button CssClass="pull-right btn btn-success" ID="btnNewModel" runat="server" Text="NEW" OnClick="btnNewModel_Click" />
        </div>
        <div class="widget-container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView CssClass="table table-bordered stats-tbl-theme" ID="gridViewModelList" runat="server" AutoGenerateColumns="False" OnRowCommand="gridViewRankGroup_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Model No." ReadOnly="True" DataField="m_id"  />
                            <asp:BoundField HeaderText="Model Name" ReadOnly="True" DataField="m_name"  />
                            <asp:BoundField HeaderText="Status" ReadOnly="True" DataField="p_status"   />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button CssClass="btn btn-danger form-control" CommandName="Editing" CommandArgument='<%# Eval("m_id") + "," + Eval("m_name") %>' ID="btnEdit" runat="server" Text="Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

