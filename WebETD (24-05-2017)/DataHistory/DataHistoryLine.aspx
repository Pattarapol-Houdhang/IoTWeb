<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="DataHistoryLine.aspx.cs" Inherits="DataHistory_DataHistoryLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header">

        <h1>
            <i class="icon-bars"></i>
            Select Data History Line
            <small>Select Line you want to see.</small>
        </h1>

    </div>

    <div class="board-widget">
        <%-- <div class="row" style="margin-left: 5px;">
            <a href="PDQuantityGraphFactory.aspx"><span class="icon-arrow-left-7"></span>&nbsp;Back to Previous Page</a>

        </div>
        <br />--%>
        <div class="row">


            <%=GenBlock() %>

            <!-- CR Data -->
            <div id="divCR" runat="server" visible="false" class="col-sm-6 col-md-2">
                <div class="board-widget-wrap">
                    <a href="CRData.aspx"><i class="icon-tree"></i>
                        <span class="board-widget-label">Get CR Data </span>
                        <span class="board-widget-intro">For get CR data by Label No</span>
                    </a>
                </div>
            </div>
            <div id="divCRPallet" runat="server" visible="false" class="col-sm-6 col-md-2">
                <div class="board-widget-wrap">
                    <a href="CRDataPallet.aspx"><i class="icon-tree"></i>
                        <span class="board-widget-label">Get CR Data (Pallet) </span>
                        <span class="board-widget-intro">For get CR data by Pallet No</span>
                    </a>
                </div>
            </div>
            <div id="divAlarm" runat="server" visible="false" class="col-sm-6 col-md-2">
                <div class="board-widget-wrap">
                    <a href="AlarmHistory.aspx"><i class="icon-tree"></i>
                        <span class="board-widget-label">Alarm History </span>
                        <span class="board-widget-intro">Data Alarm History</span>
                    </a>
                </div>
            </div>
            <div id="divAlarmDetail" runat="server" visible="false" class="col-sm-6 col-md-2">
                <div class="board-widget-wrap">
                    <a href="AlarmHistoryDetail.aspx"><i class="icon-tree"></i>
                        <span class="board-widget-label">Alarm History Detail</span>
                        <span class="board-widget-intro">Data Alarm History Detail with Start & End Time</span>
                    </a>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

