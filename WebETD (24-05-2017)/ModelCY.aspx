<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPagePart.master" AutoEventWireup="true" CodeFile="ModelCY.aspx.cs" Inherits="ModelCY" %>

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
    <div class="widget-container" col-md-10" align="center">
        <div class="row">
            <h2 class="pull-left">
                <b>
                    <i class=" icon-clipboard-4"></i>
                    CYLINDER
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
                <!-- CYLINDER -->
                <!-- ID BORE -->
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>ID BORE</b></h3>
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
                                        <asp:TextBox CssClass=" form-control" ID="txtCYIDBoreCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBORank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDSRank" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [g_id], [r_name] FROM [etd_group_rank]"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBORoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBORoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBORoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBORoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CYLINDRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBOCylindricMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOCylindricMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBOCylindricRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOCylindricMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBOPerpenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOPerpendMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBOPerpenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOPerpenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">CONCENTRICITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBOConcenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOConcenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBOConcenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBOConcenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END ID BORE-->

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- HEIGHT -->
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>HEIGHT</b></h3>
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
                                        <asp:TextBox CssClass=" form-control" ID="txtCYHeightCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYHeightMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td width="15%">
                                                    <asp:TextBox CssClass="form-control" ID="txtCYHeightMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYHeightRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYHeightMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PARALLISM</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYParallismMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYParallismMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYParallismRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYParallismMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END HEIGHT -->

                <%--////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                <!-- ID BUSH -->
                <div class="row col col-md-12">
                    <div class="row">
                        <table class="form-group pull-left">
                            <td>
                                <h3><b>ID BUSH</b></h3>
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
                                        <asp:TextBox CssClass=" form-control" ID="txtCYIDBushCycleTime" runat="server" MaxLength="4" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBUMax" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBURank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBUMin" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">ROUNDNESS</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBURoundnessMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBURoundnessMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBURoundnessRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBURoundnessMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2">PERPENDICULARITY</td>
                                                <td rowspan="2">
                                                    <asp:TextBox CssClass="form-control input-lg" ID="txtCYIDBUPerpenMid" Style="text-align: right;" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBUPerpenMax" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td rowspan="2">
                                                    <asp:DropDownList CssClass="form-control" ID="dropDownCYIDBUPerpenRank" runat="server" Height="85px" DataSourceID="SqlDSRank" DataTextField="r_name" DataValueField="g_id"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox CssClass="form-control" ID="txtCYIDBUPerpenMin" Style="text-align: right;" runat="server" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- END ID BUSH-->
                <div class="row">
                    <table class="form-group pull-left">
                        <tr>
                            <td>
                                <asp:Button CssClass="btn btn-primary" ID="btnCylinderSave" runat="server" Text="SAVE CYLINDER DATA" OnClick="btnCylinderSave_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <!-- END CYLINDER-->
            </div>
        </div>
    </div>
</asp:Content>

