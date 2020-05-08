<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="UserLogout.aspx.cs" Inherits="UserLogout" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <style type="text/css">
                .main-container {
                    background-color: #dedede;
                }
            </style>
            <div class="main-wrapper">
                <div class="login-wrap">
                    <div class="login-action">
                        <asp:Button CssClass="btn-danger btn btn-block " ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click"  />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

