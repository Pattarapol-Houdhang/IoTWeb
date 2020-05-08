<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="ProgramDetail.aspx.cs" Inherits="ProgramDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">

        function isBlank(evt, txt) {
            //var charCode = (window.Event) ? event.which : event.keyCode;

            if (txt == "") {
                return false;
            }
            else {
                return true;
            }
            
        }
    </script>
    <div class="page-header">
        <h1>
            <i class="icon-screen-3"></i>
            PROGRAM
        </h1>
    </div>
    <div class="row">
        <div class="col-lg-10 form-group">
            <label class="control-label">
                Program Name : 
            </label>
            <asp:TextBox CssClass="col-lg-10 form-control" ID="txtProgramName" runat="server" MaxLength="50" onkeypress="return isBlank(event, this.value);" required></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <table class="col-lg-10 form-box" align="center" width="90%">
            <tr>
                <td width="40%">
                    <div class="form-group">
                        <label class="col-lg-10 control-label">Model List :</label>
                        <asp:ListBox CssClass="col-lg-10 form-control" Height="300" ID="listBoxModel" runat="server" DataField="m_name">
                        </asp:ListBox>
                    </div>
                </td>
                <td width="10%" style="text-align: center;" align="center" valign="middle">
                    <div class="form-group">
                        <asp:LinkButton CssClass="btn btn-primary" ID="btnAddToModelInProgram" runat="server" OnClick="btnAddToModelInProgram_Click">
                                <i class="icon-double-angle-right"></i>
                        </asp:LinkButton>
                    </div>
                    <div class="form-group">
                        <asp:LinkButton CssClass="btn btn-primary" ID="btnAddToModelList" runat="server" OnClick="btnAddToModelList_Click">
                                    <i class="icon-double-angle-left"></i>
                        </asp:LinkButton>
                    </div>
                </td>
                <td width="40%">
                    <div class="form-group">
                        <label class="col-lg-10 control-label">Model in this program :</label>
                        <asp:ListBox CssClass="col-lg-10 form-control" Height="300" ID="listBoxModelInProgram" runat="server"></asp:ListBox>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="col col-lg-10 row">
        <div class="form-group">
            <label class="control-label">
                <i class="icon-laptop-2"></i>
                Main Program : 
            </label>
            <asp:Label CssClass="board-widget-intro" ID="lblMainProgram" runat="server" Text="xxxxxxxx"></asp:Label>
        </div>
    </div>

    <div class="col col-lg-10 row">
        <div class="pull-right form-group">
            <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" />
            <asp:LinkButton CssClass="btn btn-default" ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>

