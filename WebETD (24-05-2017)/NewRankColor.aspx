<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="NewRankColor.aspx.cs" Inherits="NewRankColor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <script type="text/javascript" src="<%# ResolveUrl("~/js/jquery.js") %>" ></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=btnSaveRank.ClientID %>").click(function () {

                var dText = $("#<%=txtRank.ClientID %>").val();
                var dColor = $("#<%=txtColor.ClientID %>").val();
                var dRankID = $("#<%=hidRankID.ClientID %>").val();

                var parameter = "id=" + dRankID + "&txt=" + dText + "&colors=" + dColor;
                //alert(dRankID + dText + dColor);


                $.ajax({
                    type: "get",
                    url: "ExecuteNewRankColor.ashx",
                    data: parameter
                }).done(function (res) {
                    if (res.toUpperCase() == "TRUE") {
                        window.location.href = "RankSetting.aspx";
                    } else {
                        alert("FALSE");
                    }
                });


            });
        });


        function colorChanged(sender) {
            sender.get_element().blur();
            sender.get_element().value = sender.get_selectedColor();
            sender.get_element().style.color = '#' + sender.get_selectedColor();
            sender.get_element().style.backgroundColor = '#' + sender.get_selectedColor();
        }



    </script>

    <div class="page-header">
        <h1>
            <i class="icon-palette"></i>
            RANK COLOR
        </h1>
    </div>
    <div class="row">
        <table>
            <tr>
                <td>
                    <label class="control-label">
                        Rank : 
                    </label>
                </td>
                <td>
                    <label class="control-label">
                        Color : 
                    </label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="form-control" ID="txtRank" runat="server" MaxLength="5"></asp:TextBox>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox CssClass="form-control" ID="txtColor" runat="server" MaxLength="10" AutoPostBack="True" ReadOnly="True" CausesValidation="False"></asp:TextBox>
                            <%--<asp:ColorPickerExtender ID="txtColor_ColorPickerExtender" runat="server" TargetControlID="txtColor" PopupButtonID="txtColor" OnClientColorSelectionChanged="colorChanged" />--%>
                            <asp:ColorPickerExtender ID="txtColor_ColorPickerExtender" runat="server" TargetControlID="txtColor" PopupButtonID="txtColor" OnClientColorSelectionChanged="colorChanged"></asp:ColorPickerExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:HiddenField ID="hidRankID" runat="server" Value="0" />
                    <input type="button" class="btn btn-primary" name="btnSave" id="btnSaveRank" value="SAVE" runat="server" />
                    <asp:Button CssClass="btn btn-default" ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
                </td>
                <td></td>
                <td>
                    <asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" Visible="False"  />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

