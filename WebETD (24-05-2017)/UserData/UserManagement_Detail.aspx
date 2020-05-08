<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="UserManagement_Detail.aspx.cs" Inherits="UserData_UserManagement_Detail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-header">

                <h1>
                    <i class="icon-users"></i>
                    User Management
            <small>Add, Edit or Delete User in System.</small>
                </h1>

            </div>

            <div class="row">
                <asp:Panel ID="Panel1" runat="server">
                    <div class="row">
                        <div class="col-md-5 widget-module">
                            <div class="square-widget widget-collapsible">

                                <div class="widget-container" style="display: block;">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Image By Emp.Code</label>
                                            <div class="col-lg-10">
                                                <asp:Image ID="imgUser" runat="server" Width="150px" ImageUrl="http://dcidmc.dci.daikin.co.jp/PICTURE/40876.JPG" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-5 widget-module">
                            <div class="square-widget widget-collapsible">

                                <div class="widget-container" style="display: block;">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Username</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div id="divPass" runat="server" class="form-group">
                                            <label class="col-lg-2 control-label">Password</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" TabIndex="3"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="divConPass" runat="server" class="form-group">
                                            <label class="col-lg-2 control-label">Confirm Password</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" TabIndex="4"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Department</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">First Name</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" TabIndex="7"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Email</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TabIndex="9"></asp:TextBox>
                                            </div>
                                        </div>




                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-5 widget-module">
                            <div class="square-widget widget-collapsible">

                                <div class="widget-container" style="display: block;">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Emp. Code</label>
                                            <div class="col-lg-10">
                                               <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control" TabIndex="2"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="divPass2" runat="server" class="form-group" style="height: 34px">
                                            <label class="col-lg-2 control-label"></label>
                                            <div class="col-lg-10">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div id="divConPass2" runat="server" class="form-group" style="height: 34px">
                                            <label class="col-lg-2 control-label"></label>
                                            <div class="col-lg-10">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Position</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control" TabIndex="6"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Last Name</label>
                                            <div class="col-lg-10">
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" TabIndex="8"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">Active</label>
                                            <div class="col-lg-10">
                                                
                                                <div class="radio">
                                                    <asp:RadioButtonList ID="rblActive" runat="server"  TabIndex="9">
                                                        <asp:ListItem Text="Active" Value="1" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-md-5 widget-module">
                            <div class="square-widget widget-collapsible">

                                <div class="widget-container" style="display: block;">
                                    <div class="form-horizontal">
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">&nbsp;</label>
                                            <div class="col-lg-10">
                                                <div class="form-actions">
                                                    <asp:Label ID="lbError" ForeColor="Red" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-2 control-label">&nbsp;</label>
                                            <div class="col-lg-10">
                                                <div class="form-actions">
                                                    <asp:Button ID="btSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btSave_Click" />
                                                    <asp:Button ID="btCancel" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btCancel_Click" />

                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

