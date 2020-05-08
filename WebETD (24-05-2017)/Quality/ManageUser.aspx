<%@ Page Title="" Language="C#" MasterPageFile="~/UserManage.master" AutoEventWireup="true" CodeFile="ManageUser.aspx.cs" Inherits="ManageUser" %>

<%@ Register Src="~/UserControl/UCUpdateProgressStyle.ascx" TagPrefix="uc1" TagName="UCUpdateProgressStyle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                function ShowOptions(control, args) {
                    control._completionListElement.style.zIndex = 10000001;
                }
            </script>

            <div class="container">
                <div style="margin-top: 20px;">
                    <h1>User <small>Management</small></h1>
                    <hr class="thin" style="width: 100%; height: 4px;" />
                </div>
                <uc1:UCUpdateProgressStyle runat="server" ID="UCUpdateProgressStyle" />
                <div style="margin-top: 20px;">
                    <asp:Panel ID="Panel2" runat="server">
                        <div class="panel black" style="width: 720px;">
                            <div class="heading">
                                <span class="icon mif-search bg-black"></span>
                                <span class="title">Searching Detail</span>
                            </div>
                            <div class="content">
                                <table>
                                    <tr>
                                        <td style="height: 19px">Search :
                                        </td>
                                        <td style="height: 19px">
                                            <div class="input-control text">
                                                <asp:TextBox ID="txtSearch" runat="server" MaxLength="20"></asp:TextBox>
                                                <%--<asp:AutoCompleteExtender ServiceMethod="SearchPartNo"
                                                    MinimumPrefixLength="1"
                                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                                    FirstRowSelected="false"
                                                    ID="AutoCompleteExtender1" TargetControlID="txtPartNo" runat="server">
                                                </asp:AutoCompleteExtender>--%>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Active :</td>
                                        <td>

                                            <asp:RadioButtonList ID="rblActive" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="All" Value="2" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="InActive" Value="0"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td colspan="4">
                                            <asp:Label ID="lbError" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btSearch" CssClass="button" runat="server" Text="Search" OnClick="btSearch_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btAddNew" CssClass="button warning" runat="server" Text="ADD NEW" OnClick="btAddNew_Click" />
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <table>
                    <tr>
                        <td>

                            <div class="gvmetro" style="font-size: x-small !important; width: 100%;">
                                
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" CssClass="table striped bordered hovered" PageSize="20"
                                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                        OnSorting="GridView1_Sorting">
                                        <HeaderStyle CssClass="thead" ForeColor="Black" />
                                        <RowStyle CssClass="tbody" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                                        CommandName="Editing" ImageUrl="~/images/Gridview/Files-Edit-File-icon.png" Width="14"
                                                        Visible='<%# Eval("CanEdit") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Del.">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("UserID") %>'
                                                        CommandName="Deleting" ImageUrl="~/images/Gridview/Editing-Delete-icon 24.png"
                                                        Width="14" OnClientClick="return confirm('ต้องการลบข้อมูลผู้ใช้งานระบบรายนี้ใช่หรือไม่?');"
                                                        Visible='<%# Eval("CanDel") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Username" SortExpression="Username">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbUserName" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Supplier No" SortExpression="SupplierName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbSupplierNo" runat="server" Text='<%# Eval("SupplierName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="230" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="230" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Emp Code" SortExpression="EmpCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbEmpCode" runat="server" Text='<%# Eval("EmpCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Password Expired" SortExpression="PwdExpired">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbPwdExpired" runat="server" Text='<%# Eval("PwdExpired") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="80" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Active" SortExpression="IsActive">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbIsActive" runat="server" Text='<%# Eval("IsActive") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day remaining" SortExpression="PwdRemaining">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbPwdRemaining" runat="server" Text='<%# Eval("PwdRemaining") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="50" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Update By" SortExpression="UpdateBy">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("UpdateBy") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Update Date" SortExpression="UpdateDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("UpdateDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                
                            </div>

                        </td>
                    </tr>
                </table>

                <div>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:ModalPopupExtender ID="ModalPopup1" runat="server" PopupControlID="Panel1"
                        BackgroundCssClass="modalBackground" TargetControlID="HiddenField1" DropShadow="true">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="Panel1" Width="700px" runat="server" BackColor="White">
                        <div style="padding: 10px;">
                            <h3>
                                <asp:Label ID="lbHeader" runat="server" Text="Add New Data"></asp:Label>
                            </h3>
                            <br />
                            <table>
                                <tr>
                                    <td>Username :
                                    </td>
                                    <td>
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trPassword" runat="server">
                                    <td>Password :
                                    </td>
                                    <td>
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr id="trConfirmPassword" runat="server">
                                    <td>Confirm Password :
                                    </td>
                                    <td>
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Supplier No. :
                                    </td>
                                    <td>
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtSupplierNo" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Employee Code :
                                    </td>
                                    <td>
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtEmpCode" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Password Expired :
                                    </td>
                                    <td>
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtPwdExpried" runat="server"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Active :
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkActive" Checked="true" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbErrorModal" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btSaveModal" CssClass="button warning" runat="server" Text="Save" OnClick="btSaveModal_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btCloseModal" CssClass="button" runat="server" Text="Cancel" OnClick="btCloseModal_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

