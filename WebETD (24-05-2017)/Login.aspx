<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>DCI - IoT</title>

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">
</head>

<body class="login">
    <div>
        <a class="hiddenanchor" id="signup"></a>
        <a class="hiddenanchor" id="signin"></a>

        <div class="login_wrapper">
            <div class="animate form login_form">
                <section class="login_content">
                    <form runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btLogin">
                            <h1>Login Form</h1>
                            <div>
                                <asp:TextBox ID="txtUsername" CssClass="form-control" placeholder="Username" runat="server"></asp:TextBox>

                            </div>
                            <div>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </div>
                            <div>
                                <asp:LinkButton ID="btLogin" CssClas="btn btn-default submit" runat="server" OnClick="btLogin_Click">Log in</asp:LinkButton>
                                <%--<a class="btn btn-default submit" href="test.aspx">Log in</a>--%>
                               
                            </div>
                        </asp:Panel>

                        <div class="clearfix"></div>

                        <div class="separator">
                            <p class="change_link">
                                Back to Home page
                  <a href="Default.aspx" class="">Click it. </a>
                            </p>

                            <div class="clearfix"></div>
                            <br />

                            <div>

                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/DCI_Logo.png" Width="200px" />
                                <p>©2017 All Rights Reserved. Daikin Compressor Industries Ltd.</p>
                            </div>
                        </div>
                    </form>
                </section>
            </div>

            <div id="register" class="animate form registration_form">
                <section class="login_content">
                    <form>
                        <h1>Create Account</h1>
                        <div>
                            <input type="text" class="form-control" placeholder="Username" required="" />
                        </div>
                        <div>
                            <input type="email" class="form-control" placeholder="Email" required="" />
                        </div>
                        <div>
                            <input type="password" class="form-control" placeholder="Password" required="" />
                        </div>
                        <div>
                            <a class="btn btn-default submit" href="index.html">Submit</a>
                        </div>

                        <div class="clearfix"></div>

                        <div class="separator">
                            <p class="change_link">
                                Already a member ?
                  <a href="#signin" class="to_register">Log in </a>
                            </p>

                            <div class="clearfix"></div>
                            <br />

                            <div>
                                <h1><i class="fa fa-paw"></i>Gentelella Alela!</h1>
                                <p>©2016 All Rights Reserved. Gentelella Alela! is a Bootstrap 3 template. Privacy and Terms</p>
                            </div>
                        </div>
                    </form>
                </section>
            </div>
        </div>
    </div>
</body>
</html>
