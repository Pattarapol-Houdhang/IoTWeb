<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                        <h3>Current Password</h3>
                    </div>
                    <div class="login-form">
                        <ul>
                            <li>
                                <i class="icon-key"></i>
                                <asp:TextBox CssClass="login-pass-input" ID="txtCurrentPassword" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            </li>
                        </ul>
                    </div>
                    <div class="login-head">
                        <h3>New Password</h3>
                    </div>
                    <div class="login-form">
                        <ul>
                            <li>
                                <i class="icon-key"></i>
                                <asp:TextBox CssClass="login-pass-input" ID="txtNewPassword" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            </li>
                        </ul>
                        <ul>
                            <li>
                                <i class="icon-key"></i>
                                <asp:TextBox CssClass="login-pass-input" ID="txtConfirmPassword" runat="server" TextMode="Password" MaxLength="50"></asp:TextBox>
                            </li>
                        </ul>
                    </div>
                    <div class="login-action">
                        <asp:Button CssClass="backend-login-btn btn btn-block " ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                        <asp:Button CssClass="btn btn-block " ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                        <asp:Label ID="lblErrPassword" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

