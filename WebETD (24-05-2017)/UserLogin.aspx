<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    <div class="login-head">
                        <h3>Login</h3>
                    </div>
                    <div class="login-form">
                        <ul>
                            <li>
                                <i class="icon-user"></i>
                                <asp:TextBox CssClass="login-user-input" ID="txtLoginUsername" runat="server" MaxLength="5">Employee Code</asp:TextBox>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <i class="icon-key"></i>
                                <asp:TextBox CssClass="login-pass-input" ID="txtLoginPassword" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            </li>
                        </ul>
                    </div>
                    <div class="login-action">
                        <asp:Button CssClass="backend-login-btn btn btn-block " ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        <asp:Label ID="lblErrLogin" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

