<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPagePart.master" AutoEventWireup="true" CodeFile="ModelCS.aspx.cs" Inherits="ModelCS" %>

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
                    <i class=" icon-clipboard-4"></i>
                    CRANK SHAFT
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
                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>Front/Rear OD</b></h3>
                            </td>
                        </table>
                    </div>
                    <div class="form-group">
                         <div class="row">
                            <table class="form-group">
                                <td rowspan="2" width="20%">
                                    Cycle Time :
                                </td>
                                <td rowspan="2" width="30%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCSODCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                </td>
                                <td>
                                    Seconds
                                </td>
                            </table>
                        </div>
                        <!-- FRONT OD -->
                        <div class="row" >
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>Front OD</h4>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSFODMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFODMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSFODRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDSRank" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [g_id], [r_name] FROM [etd_group_rank]"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFODMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSFODRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFODRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSFODRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFODRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSFODCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFODCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSFODCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFODCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- END FRONT OD -->
                        <!-- REAR OD -->
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>Rear OD</h4>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSRODMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRODMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSRODRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRODMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSRODRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRODRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSRODRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRODRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSRODCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRODCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSRODCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRODCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- END REAR OD -->
                    </div>                   
                </div>

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>PIN OD</b></h3>
                            </td>
                        </table>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <table class="form-group">
                                <td rowspan="2" width="20%">
                                    Cycle Time :
                                </td>
                                <td rowspan="2" width="30%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCSPINCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                </td>
                                <td>
                                    Seconds
                                </td>
                            </table>
                        </div>
                        <!-- PIN FRONT OD -->
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <td>
                                    <h4>Pin Front OD</h4>
                                </td>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSPinFODMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinFODMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSPinFODRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinFODMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSPinFODRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinFODRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSPinFODRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinFODRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSPinFODCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinFODCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSPinFODCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinFODCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- END PIN FRONT OD -->
                        <!-- PIN REAR OD -->
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>Pin Rear OD</h4>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSPinRODMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinRODMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSPinRODRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinRODMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSPinRODRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinRODRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSPinRODRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinRODRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSPinRODCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinRODCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSPinRODCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSPinRODCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- END PIN REAR OD -->
                    </div>
                </div>
            

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>ECCENTRICITY</b></h3>
                            </td>
                        </table>
                    </div>
                    <div class="form-group" >
                        <div class="row">
                            <table class="form-group">
                                <td rowspan="2" width="20%">
                                    Cycle Time :
                                </td>
                                <td rowspan="2" width="30%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCSECCCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                </td>
                                <td>
                                    Seconds
                                </td>
                            </table>
                        </div>
                        <!-- ECCENTRICITY FRONT -->
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>ECCENTRICITY FRONT</h4>
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
                                                <td rowspan="2" width="20%">ECCENT.</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSEccFMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCSEccFMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSEccFRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSEccFMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- END ECCENTRICITY FRONT -->
                        <!-- ECCENTRICITY REAR -->
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>ECCENTRICITY REAR</h4>
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
                                                <td rowspan="2" width="20%">ECCENT.</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSEccRMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCSEccRMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSEccRRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSEccRMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- END ECCENTRICITY REAR -->
                    </div>
                </div>

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- RUN-OUT -->
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>FRONT REAR RUN-OUT</b></h3>
                            </td>
                        </table>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <table class="form-group" style="background-color:#e8e8e8">
                                <tr>
                                    <td>
                                        <h4>FRONT REAR RUN-OUT</h4>
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
                                                <td rowspan="2" width="20%">FRONT RUN-OUT</td>
                                                <td rowspan="2" width="30%">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSFRunMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFRunMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSFRunRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSFRunMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">REAR RUN-OUT</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCSRRunMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRRunMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCSRRunRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCSRRunMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END RUN-OUT -->

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <div class="row">
                    <table class="form-group pull-left">
                        <tr>
                            <td>
                                <asp:Button CssClass="btn btn-primary" ID="btnCSSave" runat="server" Text="SAVE CRANK SHAFT DATA" OnClick="btnCSSave_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <!-- END CRANK SHAFT -->
</asp:Content>

