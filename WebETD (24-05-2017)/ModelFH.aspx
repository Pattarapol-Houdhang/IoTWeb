<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPagePart.master" AutoEventWireup="true" CodeFile="ModelFH.aspx.cs" Inherits="ModelFH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <div class="widget-container col-md-10" align="center">
        <div class="row">
            <h2 class="pull-left">
                <b>
                    <i class="icon-clipboard-4"></i>
                    FRONT HEAD
                </b>
            </h2>
        </div>
        <div class="row pull-left">
            <table class="form-group">
                <tr>
                    <td width="15%">
                        <label class="control-label pull-right">MODEL NO.</label>
                    </td>
                    <td width="35%">
                        <asp:TextBox CssClass="form-control" ID="txtModelNo" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="lblErrModelNo" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td width="15%">
                        <label class="control-label pull-right">MODEL NAME.</label>
                    </td>
                    <td width="35%">
                        <asp:TextBox CssClass="form-control" ID="txtModelName" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="lblErrModelName" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="row">
            <div class="widget-container col col-md-8">
                <!-- FRONT HEAD -->
                 <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>FRONT HEAD ID</b></h3>
                            </td>
                        </table>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtFHCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDSRank" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [g_id], [r_name] FROM [etd_group_rank]"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CONCENTRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDConcenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDConcenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDConcenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDConcenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDPerpenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDPerpenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDPerpenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDPerpenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>                   
                </div>

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- FRONT HEAD ROUGH -->
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>FRONT HEAD ID ROUGH</b></h3>
                            </td>
                        </table>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtFHIDRoughCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                        <h4>ID ROUGH</h4>
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
                                                <td rowspan="2" width="20%">ID ROUGH</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDRoughMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDRoughMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDRoughRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [g_id], [r_name] FROM [etd_group_rank]"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDRoughMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS ROUGH</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDRoundnessRoughMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDRoundnessRoughMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDRoundnessRoughRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDRoundnessRoughMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td rowspan="2">CYLINDRICITY ROUGH</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDCylindricRoughMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDCylindricRoughMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDCylindricRoughRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDCylindricRoughMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td rowspan="2">CONCENTRICITY ROUGH</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDConcenRoughMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDConcenRoughMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDConcenRoughRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDConcenRoughMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY ROUGH</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDPerpenRoughMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDPerpenRoughMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHIDPerpenRoughRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHIDPerpenRoughMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>                   
                </div>

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- FRONT HEAD FLATNESS -->
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>FRONT HEAD FLATNESS</b></h3>
                            </td>
                        </table>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtFHIDFlatnessCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHFlatness1Mid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtFHFlatness1Max" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHFlatness1Rank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHFlatness1Min" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td rowspan="2">FLATNESS 2</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtFHFlatness2Mid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHFlatness2Max" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownFHFlatness2Rank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtFHFlatness2Min" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>                   
                </div>
                <!-- END FRONT HEAD -->
                <div class="row">
                    <table class="form-group pull-left">
                        <tr>
                            <td>
                                <asp:Button CssClass="btn btn-primary" ID="btnFHSave" runat="server" Text="SAVE FRONT HEAD DATA" OnClick="btnFHSave_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- END FRONT HEAD -->
            </div>
        </div>
    </div>
</asp:Content>

