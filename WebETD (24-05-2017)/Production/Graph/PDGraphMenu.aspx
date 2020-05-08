<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDGraphMenu.aspx.cs" Inherits="Production_Setting_PDGraphMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        .example-modal .modal {
            position: relative;
            top: auto;
            bottom: auto;
            right: auto;
            left: auto;
            display: block;
            z-index: 1;

        }

        .modal-content{
            opacity: 1 !important ;
        }

        .example-modal .modal {
            background: transparent !important;
        }
    </style>

    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <div class="page-header">
                <h1>
                    <i class="icon-tools"></i>
                    Graph Report
                    <small>Select graph you want to see.</small>
                </h1>
            </div>

            <div class="board-widget">

                <div class="row">
                    <div class="col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Production/Graph/Quantity/PDQuantityGraphFactory.aspx") %>"><i class="icon-bars"></i>
                                <span class="board-widget-label">Production Quantity</span>
                                <span class="board-widget-intro">Production Quantity Graph </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Main Assembly Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>

                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=mecha") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Mecha Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                            <asp:Panel ID="Panel1" runat="server" style="display:none" BackColor="White" >
                                Start Date : <asp:TextBox ID="txtStrDate" class="form-control datepicker" runat="server"></asp:TextBox><br />
                                End Date : <asp:TextBox ID="txtEndDate" class="form-control datepicker" runat="server"></asp:TextBox><br />
                                <label>Machine:</label>
                                    <asp:DropDownList ID="ddlMahine" class="form-control" runat="server"></asp:DropDownList>
                                <label>Shipt:</label>
                                    <asp:DropDownList ID="ddlShipt" class="form-control" runat="server">
                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                        <asp:ListItem Value="D" Text="Day"></asp:ListItem>
                                        <asp:ListItem Value="N" Text="Night"></asp:ListItem>
                                    </asp:DropDownList>
                                <asp:Button ID="btnExport" class="btn btn-primary" runat="server" Text="Export" OnClick="btnExport_Click" />
                            </asp:Panel>
                            <button type="button" onclick="myFunction('mecha')" class="btn btn-block btn-default" >
                                Export Data (CSV File)                           
                            </button>
                            
                        </div>
                    </div>

                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=casing") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Casing Line Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=motor") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Motor Line Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=piston") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Machine Piston Line Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=fh") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Machine Front head Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=cs") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Machine Crankshaft Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=cd") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Machine Cylinder Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=rh") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Machine Rear Head Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                    <div class=" col-sm-6 col-md-3">
                        <div class="board-widget-wrap">
                            <a href="<%= ResolveClientUrl("~/Efficiency_Report.aspx?line=fn") %>" target="_blank"><i class="icon-stairs-down"></i>
                                <span class="board-widget-label">Efficiency Final Line Fac 3</span>
                                <span class="board-widget-intro">Line Efficiency Graph </span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>           

            <!------------------ Modal popup for export efficeincy ---------------->
            <asp:Label ID="lbLine" runat="server" Text="sasa" style="display:none"></asp:Label>
            <asp:HiddenField ID="hdModalChoose" runat="server" />
            
            <!------------------ Modal popup for export efficeincy ---------------->

            <script type="text/javascript">
                $(document).ready(function () {
                    var today = new Date()
                    // create DatePicker from input HTML element
                    $(".datepicker").kendoDatePicker({
                        value: today,
                        format: "yyyy-MM-dd"
                    });
                });

                function myFunction(line) {
                    $('#<%= hdModalChoose.ClientID %>').val(line);
                    $('#<%= Panel1.ClientID %>').toggle()
                }

                function AddDDLMecha() {
                    

                }

            </script>
        <%--</ContentTemplate>
   </asp:UpdatePanel>--%>

</asp:Content>

