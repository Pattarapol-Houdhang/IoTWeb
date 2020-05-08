<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageEditPart.master" AutoEventWireup="true" CodeFile="ModelEditRH.aspx.cs" Inherits="ModelEditRH" %>

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
                <b>
                    <i class=" icon-clipboard-4"></i>
                    REAR HEAD
                </b>
            </h2>
        </div>
        <div class="row">
            <div class="widget-container col col-md-11">
                <!-- REAR HEAD ID -->
                <div class="row col col-md-10">
                    <td>
                        <h3><b>Rear Head ID</b></h3>
                    </td>
                    <div class="form-group" align="center">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtRHCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                    </td>
                                    <td>
                                        Seconds
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>ID</h4>
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
                                                <td rowspan="2" width="20%">ID</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtRHIDMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownRHIDRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDSRank" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [g_id], [r_name] FROM [etd_group_rank]"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtRHIDRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownRHIDRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtRHIDCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownRHIDCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtRHIDPerpenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDPerpenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownRHIDPerpenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHIDPerpenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>                   
                </div>
                <!-- END REAR HEAD -->

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- REAR HEAD FLATNESS -->
                <div class="row col col-md-10">
                    <td>
                        <h3><b>Rear Head Flatness</b></h3>
                    </td>
                    <div class="form-group" align="center">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtRHIDFlatnessCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                    </td>
                                    <td>
                                        Seconds
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>FLATNESS</h4>
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
                                                <td rowspan="2" width="20%">FLATNESS 1</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtRHFlatness1Mid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtRHFlatness1Max" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownRHFlatness1Rank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHFlatness1Min" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td rowspan="2">FLATNESS 2</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtRHFlatness2Mid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHFlatness2Max" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownRHFlatness2Rank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtRHFlatness2Min" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>    
                </div>        
                <!-- END REAR HEAD FLATNESS -->

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <div class="row">
                    <table class="form-group">
                        <tr>
                            <td>
                                <asp:Button CssClass="btn btn-primary" ID="btnRHSave" runat="server" Text="SAVE REAR HEAD DATA" OnClick="btnRHSave_Click" />
                            </td>
                            <td>
                                <asp:Button CssClass="btn btn-danger" ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- END REAR HEAD -->
            </div>
        </div>
    </div>
</asp:Content>

