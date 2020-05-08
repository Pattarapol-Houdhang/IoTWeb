<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPage.master" AutoEventWireup="true" CodeFile="PDQuantityGraphFactory.aspx.cs" Inherits="Production_Graph_Quantity_PDQuantityGraphFactory" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="page-header">

                <h1>
                    <i class="icon-bars"></i>
                    Select Factory
            <small>Select Factory you want to see.</small>
                </h1>

            </div>

            <div class="board-widget">
                
                <div class="row">
                    <%--<div class=" col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-factory"></i>
                                <span class="board-widget-label">Factory 1 </span>
                                <span class="board-widget-intro"> </span>
                            </a>
                        </div>
                    </div>   
                    <div class=" col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-factory"></i>
                                <span class="board-widget-label">Factory 2 </span>
                                <span class="board-widget-intro"></span>
                            </a>
                        </div>
                    </div>  
                    <div class=" col-sm-6 col-md-2">
                        <div class="board-widget-wrap">
                            <a href="#"><i class="icon-factory"></i>
                                <span class="board-widget-label">Factory 3 </span>
                                <span class="board-widget-intro"></span>
                            </a>
                        </div>
                    </div>  --%>

                    <%=GenBlock() %>
                </div>
               
            </div>
</asp:Content>

