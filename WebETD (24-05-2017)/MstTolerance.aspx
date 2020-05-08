<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="MstTolerance.aspx.cs" Inherits="NewModelTolerance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(".widget-container").hide();

            $(".widget-head").click(function () {

                var _div_name = $(this).data("display");
                $("#widget-" + _div_name).toggle(0);
            });
        });

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
    </asp:ScriptManager>
    <div class="page-header">
        <h1>
            <i class="icon-tools"></i>
            TOLERANCE MASTER
        </h1>
    </div>
    <div class="row">
        <table width="100%">
            <tr>
                <td width="13%" class="form-inline">
                    <label class="control-label">Model Name : </label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" ID="txtModelName" runat="server" MaxLength="20" AutoPostBack="True" required></asp:TextBox>
                </td>
                <td width="13%" class="form-inline">
                    <label class="control-label">Model Code : </label>
                </td>
                <td>
                    <asp:TextBox CssClass="form-control" ID="txtModelCode" runat="server" MaxLength="5" onkeypress="return isDigitInt(event, this.value);" required></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <!-- CRANK SHAFT -->
    <div class="row">
        <div class="col col-md-12 widget-module">
            <div class="box-widget">
                <div class="widget-head" data-display="crank-shaft">
                    <h4>CRANK SHAFT</h4>
                </div>
                <div class="col col-md-12 widget-container" id="widget-crank-shaft">
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>FRONT/REAR OD Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCSODCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                </td>
                                <td>
                                    <h4>Seconds</h4>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <!-- FRONT OD -->
                    <div class="row">
                        <table class="form-group">
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
                        <table class="form-group">
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
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>PIN FRONT/REAR OD Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCSPINCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                </td>
                                <td>
                                    <h4>Seconds</h4>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <!-- PIN FRONT OD -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td>
                                    <h4>Pin Front OD</h4>
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
                        <table class="form-group">
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
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>ECCENTRICITY Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCSECCCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                </td>
                                <td>
                                    <h4>Seconds</h4>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <!-- ECCENTRICITY FRONT -->
                    <div class="row">
                        <table class="form-group">
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
                        <table class="form-group">
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
                    <div class="row">
                        <table class="form-group">
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
    </div>
    <!-- END CRANK SHAFT -->
    <!-- PISTON -->
    <div class="row">
        <div class="col col-md-12 widget-module">
            <div class="box-widget">
                <div class="widget-head" data-display="piston">
                    <h4>PISTON</h4>
                </div>
                <div class="col col-md-12 widget-container" id="widget-piston">
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>ID Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtPSIDCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                </td>
                                <td>
                                    <h4>Seconds</h4>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <!-- PISTON ID -->
                    <div class="row">
                        <table class="form-group">
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
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtPisIDPerpendMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtPisIDPerpendMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownPisIDPerpendRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtPisIDPerpendMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">CONCENTRICITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtPisIDConcentricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtPisIDConcentricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownPisIDConcentricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id" required></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtPisIDConcentricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END PISTON ID -->
                    <!-- PISTON OD -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>OD Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtPSODCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
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
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtPisODPerpendMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtPisODPerpendMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownPisODPerpendRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtPisODPerpendMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END PISTON OD -->
                    <!-- PISTON HEIGHT -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>HEIGHT Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtPSHEICycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtPisHiHeightMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox CssClass="form-control" ID="txtPisHiHeightMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownPisHiHeightRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtPisHiHeightMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                    <!-- END PISTON HEIGHT -->
                    <!-- PISTON BLADE -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>BLADE Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtPSBLCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                    <!-- END PISTON BLADE -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td>
                                    <asp:Button CssClass="btn btn-primary" ID="btnPistonSave" runat="server" Text="SAVE PISTON DATA" OnClick="btnPistonSave_Click"/>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END PISTON -->
    <!-- CYLINDER + SWING BUSH -->
    <div class="row">
        <div class="col col-md-12 widget-module">
            <div class="box-widget">
                <div class="widget-head" data-display="cylinder">
                    <h4>CYLINDER + SWING BUSH</h4>
                </div>
                <div class="col col-md-12 widget-container" id="widget-cylinder">
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>ID BORE Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCYIDBoreCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <h4>Seconds</h4>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <!-- ID BORE -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td>
                                    <h4>ID BORE</h4>
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
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBOMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBOMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBORank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBOMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">ROUNDNESS</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBORoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBORoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBORoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBORoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">CYLINDRICITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBOCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBOCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBOCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBOCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">PERPENDICULARITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBOPerpendMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBOPerpendMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBOPerpendRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBOPerpendMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END ID BORE-->
                    <!-- HEIGHT -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>HEIGHT Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCYHEICycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYHeightMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox CssClass="form-control" ID="txtCYHeightMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYHeightRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYHeightMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">PARALLISM</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYParallismMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYParallismMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYParallismRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYParallismMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END HEIGHT -->
                    <!-- ID BUSH -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>ID BUSH Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtCYIDBushCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                    <h4>ID BUSH</h4>
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
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBUMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td width="15%">
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBIMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBURank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBUMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">ROUNDNESS</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBURoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBURoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBURoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBURoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">PERPENDICULARITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBUPerpendMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBUPerpendMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBUPerpendRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtCYIDBUPerpendMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END ID BUSH-->
                    <!-- SWING BUSH THICKNESS -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="30%">
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
                                <td width="25%">
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
                                    <asp:Button CssClass="btn btn-primary" ID="btnCylinderSave" runat="server" Text="SAVE CYLINDER AND SWING BUSH DATA" OnClick="btnCylinderSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END CYLINDER + SWING BUSH -->
    <!-- FRONT HEAD + REAR HEAD -->
    <div class="row">
        <div class="col col-md-12 widget-module">
            <div class="box-widget">
                <div class="widget-head" data-display="front-head">
                    <h4>FRONT HEAD + REAR HEAD</h4>
                </div>
                <div class="col col-md-12 widget-container" id="widget-front-head">
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="25%">
                                    <h4>FRONT/REAR HEAD Cycle Time :</h4>
                                </td>
                                <td width="20%">
                                    <asp:TextBox CssClass=" form-control" ID="txtFHRHCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <h4>Seconds</h4>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                    <!-- FRONT HEAD -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td>
                                    <h4>FRONT HEAD</h4>
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
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownFHIDRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">ROUNDNESS</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownFHIDRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">CYLINDRICITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownFHIDCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">CONCENTRICITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDConcentricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDConcentricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownFHIDConcentricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDConcentricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">PERPENDICULARITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtFHIDPerpendMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDPerpendMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownFHIDPerpendRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtFHIDPerpendMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END FRONT HEAD -->
                    <!-- REAR HEAD -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td>
                                    <h4>REAR HEAD</h4>
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
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownRHIDRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">ROUNDNESS</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtRHIDRoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDRoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownRHIDRoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDRoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">CYLINDRICITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtRHIDCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownRHIDCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="2">PERPENDICULARITY</td>
                                            <td rowspan="2">
                                                <asp:TextBox CssClass="form-control input-lg" ID="txtRHIDPerpendMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDPerpendMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td rowspan="2">
                                                <asp:DropDownList CssClass="form-control" ID="dropDownRHIDPerpendRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox CssClass="form-control" ID="txtRHIDPerpendMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END REAR HEAD -->
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td>
                                    <asp:Button CssClass="btn btn-primary" ID="btnFRHeadSave" runat="server" Text="SAVE FRONT/REAR HEAD DATA" OnClick="btnFRHeadSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END FRONT HEAD + REAR HEAD -->
    <!-- CLEARANCE -->
    <div class="row">
        <div class="col col-md-12 widget-module">
            <div class="box-widget">
                <div class="widget-head" data-display="clearance">
                    <h4>CLEARANCE</h4>
                </div>
                <div class="col col-md-12 widget-container" id="widget-clearance">
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td width="30%">
                                    <h5>PORTION</h5>
                                </td>
                                <td>
                                    <h5>MAX</h5>
                                </td>
                                <td>
                                    <h5>MIN</h5>
                                </td>
                            </tr>
                            <tr>
                                <td>CYLINDER HEIGHT & PISTON HEIGHT
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="CLCyPisHeightMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="CLCyPisHeightMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>CYLINDER HEIGHT & SWING BUSH HEIGHT
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>FRONT HEAD ID & FRONT SHAFT OD
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>REAR HEAD ID & REAR SHAFT OD
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>PISTON ID & CRANK SHAFT PIN OD
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>CRANK SHAFT ECCENTRIC. & PISTON OD & CYLINDER BORE ID
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>CYLINDER BUSH ID & SWING BUSH THICKNESS & PISTON BLADE THICKNESS
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox12" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox13" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="row">
                        <table class="form-group">
                            <tr>
                                <td>
                                    <asp:Button CssClass="btn btn-primary" ID="btnClearance" runat="server" Text="SAVE CLEARANCE DATA" OnClick="btnClearance_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END CLEARANCE -->
    <!--div class="col col-lg-10 row">
        <div class="pull-right form-group">
            <asp:Button CssClass="btn btn-primary" ID="btnSave" runat="server" Text="SAVE" />
            <asp:LinkButton CssClass="btn btn-default" ID="btnCancel" runat="server" Text="CANCEL" />
        </div>
    </div-->
    </ContentTemplate>
</asp:Content>

