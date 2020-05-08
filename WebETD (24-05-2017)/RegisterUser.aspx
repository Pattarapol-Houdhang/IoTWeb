<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterUser.aspx.cs" Inherits="RegisterUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 135px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <h1>
                    <i class="icon-list"></i>
                    REGISTER USER
                </h1>
            </div>
            <div class="row">
                <table>
                    <tr>
                        <td width="20%">
                            <label class="control-label pull-right">Search : </label>
                        </td>
                        <td width="60%">
                            <asp:TextBox CssClass="form-control" ID="txtSearch" runat="server" MaxLength="5" AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td width="20%">
                            <asp:LinkButton CssClass="btn btn-default" ID="btnSearch" runat="server" OnClick="btnSearch_Click">
                        <i class="icon-search "></i>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="row">
                <%-- <table width="98%" border="1">
            <tr>
                <td width="50%">--%>
                <table width="30%" style="float: left;">
                    <tr>
                        <td colspan="4">
                            <h3>PERMISSION</h3>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%">
                            <h5 align="right">User Code :</h5>
                        </td>
                        <td width="25%">
                            <asp:Label CssClass="control-label" ID="lblEmpCode" runat="server" Font-Size="Medium"></asp:Label>
                        </td>
                        <td width="25%">
                            <h5 align="right">Sect. :</h5>
                        </td>
                        <td width="25%">
                            <asp:Label CssClass="control-label" ID="lblEmpSect" runat="server" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h5 align="right">Name :</h5>
                        </td>
                        <td colspan="3">
                            <asp:Label CssClass="control-label" ID="lblEmpName" runat="server" Font-Size="Medium"></asp:Label>
                        </td>
                        <%--                            <td width="25%">
                                <h5 align="right">Surname :</h5>
                            </td>
                            <td width="25%">
                                <asp:Label CssClass="control-label" ID="lblEmpSurname" runat="server" Text="00000" Font-Size="Medium"></asp:Label>
                            </td>--%>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:CheckBox CssClass="checkbox" ID="CheckBoxQCAdmin" runat="server" Text="QCAdmin" Font-Size="Medium" />
                        </td>
                        <td colspan="2">
                            <asp:CheckBox CssClass="checkbox" ID="CheckBoxAdmin" runat="server" Text="Admin" Font-Size="Medium" Enabled="False" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:CheckBox CssClass="checkbox" ID="CheckBoxQCUser" runat="server" Text="QCUser" Font-Size="Medium" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label CssClass="control-label" ID="lblEmpStatus" runat="server" Font-Size="Smaller"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="pull-right">
                                <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                                <asp:LinkButton CssClass="btn btn-default" ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
                <%--</td>
                <td width="50%">--%>
                <table width="70%">
                    <tr>
                        <td colspan="2">
                            <h3>USER AVAILABLE ON SYSTEM</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="widget-container">
                                <asp:GridView CssClass="table table-bordered table-hover stats-tbl-theme" ID="gridViewUserOnSystem" runat="server" AutoGenerateColumns="False" DataKeyNames="user_code" DataSourceID="SqlDataSource1" OnRowCommand="gridViewUserOnSystem_RowCommand">
                                    <Columns>
                                        <asp:BoundField HeaderText="User Code" ReadOnly="True" DataField="user_code" SortExpression="user_code" />
                                        <asp:BoundField DataField="user_name" HeaderText="Name" SortExpression="user_name" />
                                        <asp:BoundField DataField="user_surname" HeaderText="Surname" SortExpression="user_surname" />
                                        <asp:BoundField DataField="user_sect" HeaderText="Sect." SortExpression="user_sect" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button CssClass="btn btn-danger form-control" CommandName="Editing" CommandArgument='<%# Eval("user_code") %>' ID="btnEdit" runat="server" Text="Edit" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [user_code], [user_name], [user_surname], [user_sect] FROM [vi_user_detail]"></asp:SqlDataSource>
                            </div>
                        </td>
                    </tr>
                </table>
                <%--</td>
            </tr>
        </table>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

