<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageEditPart.master" AutoEventWireup="true" CodeFile="ModelEditSB.aspx.cs" Inherits="ModelEditSB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">

        function isDigitInt(evt, txt) {
            var charCode = (window.Event) ? event.which : event.keyCode;

            if (charCode >= 48 && charCode <= 57) {
                return true;
            }
            return false;
        }

        function isDigitFloat(evt, txt) {
            var charCode = (window.Event) ? event.which : event.keyCode;

            if (charCode == 46 || charCode == 45 || (charCode >= 48 && charCode <= 57)) {

                return true;
            }

            return false;
        }
    </script>
    <div class="widget-container">
        <div class="row">
            <h2 class="pull-left">
                <i class=" icon-clipboard-4"></i>
                SWING BUSH
            </h2>
        </div>
        <div class="row">
            <div class="widget-container col col-md-12">
                <!-- CYLINDER + SWING BUSH -->
                <!-- SWING BUSH THICKNESS -->
                <div class="row">
                    <table class="form-group">
                        <tr>
                            <td width="35%">
                                <h4>SWING BUSH THICKNESS Cycle Time :</h4>
                            </td>
                            <td width="20%">
                                <asp:TextBox CssClass=" form-control" ID="txtSWTHCycletime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                            </td>
                            <td>
                                <h4>Seconds</h4>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <table class="form-group">
                        <tr>
                            <td>
                                <h4>SWING BUSH THICKNESS</h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="form-group">
                                    <tr>
                                        <td></td>
                                        <td colspan="2">
                                            <h5>DIMENSION</h5>
                                        </td>
                                        <td>
                                            <h5>RANK</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" width="20%">THICKNESS</td>
                                        <td rowspan="2" width="30%">
                                            <asp:TextBox CssClass="form-control input-lg" ID="txtSWThicknessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                        </td>
                                        <td width="15%">
                                            <asp:TextBox CssClass="form-control" ID="txtSWThicknessMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                        </td>
                                        <td rowspan="2">
                                            <asp:DropDownList CssClass="form-control" ID="dropDownSWThicknessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDSRank" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [g_id], [r_name] FROM [etd_group_rank]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox CssClass="form-control" ID="txtSWThicknessMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- END SWING BUSH THICKNESS -->
                <!-- SWING BUSH HEIGHT -->
                <div class="row">
                    <table class="form-group">
                        <tr>
                            <td width="35%">
                                <h4>SWING BUSH HEIGHT Cycle Time :</h4>
                            </td>
                            <td width="20%">
                                <asp:TextBox CssClass=" form-control" ID="txtSWHEICycletime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                            </td>
                            <td>
                                <h4>Seconds</h4>
                            </td>
                            <td></td>
                        </tr>
                    </table>
                </div>
                <div class="row">
                    <table class="form-group">
                        <tr>
                            <td>
                                <h4>SWING BUSH HEIGHT</h4>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table class="form-group">
                                    <tr>
                                        <td></td>
                                        <td colspan="2">
                                            <h5>DIMENSION</h5>
                                        </td>
                                        <td>
                                            <h5>RANK</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" width="20%">HEIGHT</td>
                                        <td rowspan="2" width="30%">
                                            <asp:TextBox CssClass="form-control input-lg" ID="txtSWHeightMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                        </td>
                                        <td width="15%">
                                            <asp:TextBox CssClass="form-control" ID="txtSWHeightMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                        </td>
                                        <td rowspan="2">
                                            <asp:DropDownList CssClass="form-control" ID="dropDownSWHeightRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox CssClass="form-control" ID="txtSWHeightMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- END SWING BUSH HEIGHT -->
                <div class="row">
                    <table class="form-group">
                        <tr>
                            <td>
                                <asp:Button CssClass="btn btn-primary" ID="btnSBSave" runat="server" Text="SAVE SWING BUSH DATA" />
                            </td>
                            <td>
                                <asp:Button CssClass="btn btn-danger" ID="btnCancel" runat="server" Text="CANCEL" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- END CYLINDER + SWING BUSH -->
            </div>
        </div>
    </div>
</asp:Content>

