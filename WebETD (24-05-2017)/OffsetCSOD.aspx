<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageOffsetDetail.master" AutoEventWireup="true" CodeFile="OffsetCSOD.aspx.cs" Inherits="OffsetCS" %>

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
    <div class="widget-container">
        <div class="row">
            <h2 class="pull-left">
                <i class=" icon-clipboard-4"></i>
                CRANK SHAFT
            </h2>
        </div>
        <div class="row">
            <div class="form-horizontal">
                <fieldset title="Crank Shaft Info">
                    <legend>FRONT REAR OD<asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></legend>
                </fieldset>
            </div>
            <div class="row">
                <table>
                    <tr>
                        <td width="20%">
                            <label class="control-label pull-right">MASTER NO.</label>
                        </td>
                        <td width="35%">
                            <asp:TextBox CssClass="form-control" ID="txtMasterNo" runat="server" MaxLength="10"></asp:TextBox>
                        </td>
                        <td width="15%">
                            <label class="control-label pull-left">MODEL</label>
                        </td>
                        <td width="30%">
                            <asp:DropDownList CssClass="form-control" ID="DropDownListModelName" runat="server" DataSourceID="SqlDataSourceModel" DataTextField="m_name" DataValueField="m_id"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceModel" runat="server" ConnectionString="<%$ ConnectionStrings:ETDConnectionString %>" SelectCommand="SELECT [m_id], [m_name] FROM [etd_mst_model] ORDER BY [m_name]"></asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-lg-3">
                <div class="cbp-vm-image">
                    <img src="images/ImgPartMaster/2YCCSOD.png" width="250" />
                </div>
            </div>
            <div class="col-lg-6">
                <div class="row">
                    <div class="cbp-vm-details">
                        <div class="form-group">
                            <label class="col-lg-1">OD1</label>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass=" form-control" ID="txtOD1" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                            </div>
                            <label class="col-lg-1">µm</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cbp-vm-details">
                        <div class="form-group">
                            <label class="col-lg-1">OD2</label>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass=" form-control" ID="txtOD2" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                            </div>
                            <label class="col-lg-1">µm</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cbp-vm-details">
                        <div class="form-group">
                            <label class="col-lg-1">OD3</label>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass=" form-control" ID="txtOD3" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                            </div>
                            <label class="col-lg-1">µm</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cbp-vm-details">
                        <div class="form-group">
                            <label class="col-lg-1">OD4</label>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass=" form-control" ID="txtOD4" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                            </div>
                            <label class="col-lg-1">µm</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cbp-vm-details">
                        <div class="form-group">
                            <label class="col-lg-1">OD5</label>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass="form-control" ID="txtOD5" runat="server" MaxLength="6" onkeypress="return isDigitFloat(event, this.value);" required></asp:TextBox>
                            </div>
                            <label class="col-lg-1">µm</label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cbp-vm-details">
                        <div class="form-group">
                            <br />
                            <asp:LinkButton CssClass="btn btn-primary" ID="btnSave" runat="server" OnClick="btnSave_Click">
                                       <i class="icon-save"> SAVE</i>
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-default" ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="cbp-vm-details">
                        <asp:Label CssClass="control-label" ID="LabelErrorMasterNo" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="cbp-vm-details">
                        <div class="form-group">
                            <br />
                            <label>Remark :</label>
                            <asp:TextBox CssClass="form-control" ID="txtDelReason" runat="server" TextMode="MultiLine" Height="100" Width="220" MaxLength="500"></asp:TextBox>
                            <asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click"></asp:Button>
                            <asp:Label ID="lblRemarkError" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

