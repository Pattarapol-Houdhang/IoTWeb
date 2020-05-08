<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageEditPart.master" AutoEventWireup="true" CodeFile="ModelEditPT.aspx.cs" Inherits="ModelEditPT" %>

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
                    PISTON
                </b>
            </h2>
        </div>
        <div class="row">
            <div class="widget-container col col-md-11">
                <!-- PISTON -->
                <div class="row col col-md-10">
                    <td>
                        <h3><b>Piston ID</b></h3>
                    </td>
                    <div class="form-group" align="center">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtPisIDCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                    </td>
                                    <td>
                                        Seconds
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                        <!-- PISTON ID -->
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisIDMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisIDRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDSRank" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [g_id], [r_name] FROM [etd_group_rank]"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisIDRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisIDRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisIDCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisIDCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisIDPerpenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDPerpenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisIDPerpenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDPerpenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CONCENTRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisIDConcenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDConcenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisIDConcenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisIDConcenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END PISTON ID -->

                 <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- PISTON OD -->
                <div class="row col col-md-10">
                    <td>
                        <h3><b>Piston OD</b></h3>
                    </td>
                    <div class="form-group" align="center">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtPisODCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
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
                                        <h4>OD</h4>
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
                                                <td rowspan="2" width="20%">OD</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisODMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisODRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisODRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisODRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisODCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisODCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisODPerpenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODPerpenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisODPerpenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisODPerpenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END PISTON OD -->

                 <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- PISTON HEIGHT -->
                <div class="row col col-md-10">
                    <td>
                        <h3><b>Piston Height</b></h3>
                    </td>
                    <div class="form-group" align="center">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtPisHeightCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                        <h4>HEIGHT</h4>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisHeightMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtPisHeightMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisHeightRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisHeightMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PARALLISM</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisHiParallismMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisHiParallismMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisHiParallismRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisHiParallismMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END PISTON HEIGHT -->

                 <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- PISTON BLADE -->
                <div class="row col col-md-10">
                    <td>
                        <h3><b>Piston Blade</b></h3>
                    </td>
                    <div class="form-group" align="center">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtPisBLCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                        <h4>BLADE</h4>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtBLThicknessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtBLThicknessMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownBLThicknessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtBLThicknessMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PARALLISM</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtBLParallismMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtBLParallismMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownBLParallismRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtBLParallismMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtBLPerpenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtBLPerpenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownBLPerpenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtBLPerpenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END PISTON BLADE -->

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- PISTON FLATNESS -->
                <div class="row col col-md-10">
                    <td>
                        <h3><b>Piston Flatnees</b></h3>
                    </td>
                    <div class="form-group" align="center">
                        <div class="row">
                            <table class="form-group">
                                <tr>
                                    <td rowspan="2" width="20%">
                                        Cycle Time :
                                    </td>
                                    <td rowspan="2" width="30%">
                                        <asp:TextBox CssClass=" form-control" ID="txtPisFLCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                <td rowspan="2" width="20%">FLATNESS</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtPisFlatnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtPisFlatnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownPisFlatnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtPisFlatnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END PISTON FLATNESS -->

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <div class="row">
                    <table class="form-group">
                        <tr>
                            <td>
                                <asp:Button CssClass="btn btn-primary" ID="btnPistonSave" runat="server" Text="SAVE PISTON DATA" OnClick="btnPistonSave_Click" />
                            </td>
                            <td>
                                <asp:Button CssClass="btn btn-danger" ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- END PISTON -->
            </div>
        </div>
    </div>
</asp:Content>

