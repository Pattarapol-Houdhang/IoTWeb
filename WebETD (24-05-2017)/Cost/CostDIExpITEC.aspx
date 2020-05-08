<%@ Page Title="" Language="C#" MasterPageFile="~/Template/MasterPageOther.master" AutoEventWireup="true" CodeFile="CostDIExpITEC.aspx.cs" Inherits="Cost_CostDIExpITEC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="<%= ResolveClientUrl("~/StyleMax/js/jquery-1.8.3.min.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/jquery-ui-1.10.4.min.js") %>"></script>
    <script src="<%= ResolveClientUrl("~/Highcharts/highcharts.js") %>"></script>
    <script src="<%= ResolveUrl("~/StyleMax/js/owl.carousel.js") %>"></script>
    <link rel="stylesheet" href="<%= ResolveUrl("~/StyleMax/css/owl.carousel.css") %>" type="text/css">
    <script type="text/javascript" src="<%= ResolveClientUrl("~/js/CostDIExpITEC.js") %>"></script>
    <link rel="stylesheet" href="<%= ResolveClientUrl("~/css/CostDIExpOverAll.css") %>">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" DynamicLayout="false" DisplayAfter="0">
        <ProgressTemplate>
            <div class="modal">
                <div class="center">
                    <img alt="" src="../StyleMax/icon/Gear-0.5s-200px.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>

            <script type="text/javascript" language="javascript">
                Sys.Application.add_load(LoadJavaScript);
            </script>

            <section class="wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h3 class="page-header" ><i class="fa fa-money"></i>Direct Expense Information Technology & Energy</h3>
                    </div>
                    <div style="clear:both;"></div>
                </div>

                <div id="container" style="width:100%; min-height:50%; margin: 0 auto">


                    <div class="divChart col-sm-12">
                        <div id="gpEC" ></div>
                        <div id="cmmEC"  style="height: 100%">
                            <div class="row">
                                <div class="btnShowHideComment col-sm-6" data-comment="#boxCommentEC">(+) Show Comment</div>
                                <div class="btnAddComment col-sm-6 alignRight" data-comment=".DIRECT_EXPENSE_EC" >+ Add Comment</div>
                            </div>
                            <div id="boxCommentEC" class="carousel slide boxComment" data-ride="carousel" style="height: 100%">
                                <!-- Indicators -->
                                <ol class="carousel-indicators">
                                    <li data-target="#boxCommentEC" data-slide-to="0" class="active"></li>
                                    <li data-target="#boxCommentEC" data-slide-to="1"></li>
                                    <li data-target="#boxCommentEC" data-slide-to="2"></li>
                                </ol>

                                <div class="carousel-inner" style="height: 100% !important">
                                    <div class="item active">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">APR</th>
                                                    <th width="25%">MAY</th>
                                                    <th width="25%">JUN</th>
                                                    <th width="25%">JUL</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtAPR" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="APR" ></textarea></td>
                                                    <td><textarea name="txtCmmtMAY" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="MAY" ></textarea></td>
                                                    <td><textarea name="txtCmmtJUN" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="JUN" ></textarea></td>
                                                    <td><textarea name="txtCmmtJUL" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="JUL" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="item">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">AUG</th>
                                                    <th width="25%">SEP</th>
                                                    <th width="25%">OCT</th>
                                                    <th width="25%">NOV</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtAUG" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="AUG" ></textarea></td>
                                                    <td><textarea name="txtCmmtSEP" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="SEP" ></textarea></td>
                                                    <td><textarea name="txtCmmtOCT" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="OCT" ></textarea></td>
                                                    <td><textarea name="txtCmmtNOV" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="NOV" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="item">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">DEC</th>
                                                    <th width="25%">JAN</th>
                                                    <th width="25%">FEB</th>
                                                    <th width="25%">MAR</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtDEC" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="DEC" ></textarea></td>
                                                    <td><textarea name="txtCmmtJAN" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="JAN" ></textarea></td>
                                                    <td><textarea name="txtCmmtFEB" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="FEB" ></textarea></td>
                                                    <td><textarea name="txtCmmtMAR" class="txtComment" data-costcenter=".DIRECT_EXPENSE_EC" data-month="MAR" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                                <!-- Left and right controls -->
                                <a class="left carousel-control" href="#boxCommentEC" data-slide="prev" style="width: 5% !important">
                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                </a>
                                <a class="right carousel-control" href="#boxCommentEC" data-slide="next" style="width: 5% !important">
                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                </a>
                            </div>
                        </div>
                        <div style="clear:both;"></div>
                    </div>


                    <div class="divChart col-sm-6">
                        <div id="gpECUT" ></div>
                        <div id="cmmECUT"  style="height: 100%">
                            <div class="row">
                                <div class="btnShowHideComment col-sm-6" data-comment="#boxCommentECUT">(+) Show Comment</div>
                                <div class="btnAddComment col-sm-6 alignRight" data-comment="..DIRECT_EXPENSE_UT" >+ Add Comment</div>
                            </div>
                            <div id="boxCommentECUT" class="carousel slide boxComment" data-ride="carousel" style="height: 100%">
                                <!-- Indicators -->
                                <ol class="carousel-indicators">
                                    <li data-target="#boxCommentECUT" data-slide-to="0" class="active"></li>
                                    <li data-target="#boxCommentECUT" data-slide-to="1"></li>
                                    <li data-target="#boxCommentECUT" data-slide-to="2"></li>
                                </ol>

                                <div class="carousel-inner" style="height: 100% !important">
                                    <div class="item active">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">APR</th>
                                                    <th width="25%">MAY</th>
                                                    <th width="25%">JUN</th>
                                                    <th width="25%">JUL</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtAPR" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="APR" ></textarea></td>
                                                    <td><textarea name="txtCmmtMAY" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="MAY" ></textarea></td>
                                                    <td><textarea name="txtCmmtJUN" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="JUN" ></textarea></td>
                                                    <td><textarea name="txtCmmtJUL" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="JUL" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="item">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">AUG</th>
                                                    <th width="25%">SEP</th>
                                                    <th width="25%">OCT</th>
                                                    <th width="25%">NOV</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtAUG" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="AUG" ></textarea></td>
                                                    <td><textarea name="txtCmmtSEP" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="SEP" ></textarea></td>
                                                    <td><textarea name="txtCmmtOCT" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="OCT" ></textarea></td>
                                                    <td><textarea name="txtCmmtNOV" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="NOV" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="item">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">DEC</th>
                                                    <th width="25%">JAN</th>
                                                    <th width="25%">FEB</th>
                                                    <th width="25%">MAR</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtDEC" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="DEC" ></textarea></td>
                                                    <td><textarea name="txtCmmtJAN" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="JAN" ></textarea></td>
                                                    <td><textarea name="txtCmmtFEB" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="FEB" ></textarea></td>
                                                    <td><textarea name="txtCmmtMAR" class="txtComment" data-costcenter="..DIRECT_EXPENSE_UT" data-month="MAR" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                                <!-- Left and right controls -->
                                <a class="left carousel-control" href="#boxCommentECUT" data-slide="prev" style="width: 5% !important">
                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                </a>
                                <a class="right carousel-control" href="#boxCommentECUT" data-slide="next" style="width: 5% !important">
                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                </a>
                            </div>
                        </div>
                        <div style="clear:both;"></div>
                    </div>


                    <div class="divChart col-sm-6">
                        <div id="gpECWC"></div>
                        <div id="cmmECWC"  style="height: 100%">
                            <div class="row">
                                <div class="btnShowHideComment col-sm-6" data-comment="#boxCommentECWC">(+) Show Comment</div>
                                <div class="btnAddComment col-sm-6 alignRight" data-comment="..DIRECT_EXPENSE_WC" >+ Add Comment</div>
                            </div>
                            <div id="boxCommentECWC" class="carousel slide boxComment" data-ride="carousel" style="height: 100%">
                                <!-- Indicators -->
                                <ol class="carousel-indicators">
                                    <li data-target="#boxCommentECWC" data-slide-to="0" class="active"></li>
                                    <li data-target="#boxCommentECWC" data-slide-to="1"></li>
                                    <li data-target="#boxCommentECWC" data-slide-to="2"></li>
                                </ol>

                                <div class="carousel-inner" style="height: 100% !important">
                                    <div class="item active">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">APR</th>
                                                    <th width="25%">MAY</th>
                                                    <th width="25%">JUN</th>
                                                    <th width="25%">JUL</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtAPR" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="APR" ></textarea></td>
                                                    <td><textarea name="txtCmmtMAY" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="MAY" ></textarea></td>
                                                    <td><textarea name="txtCmmtJUN" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="JUN" ></textarea></td>
                                                    <td><textarea name="txtCmmtJUL" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="JUL" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="item">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">AUG</th>
                                                    <th width="25%">SEP</th>
                                                    <th width="25%">OCT</th>
                                                    <th width="25%">NOV</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtAUG" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="AUG" ></textarea></td>
                                                    <td><textarea name="txtCmmtSEP" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="SEP" ></textarea></td>
                                                    <td><textarea name="txtCmmtOCT" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="OCT" ></textarea></td>
                                                    <td><textarea name="txtCmmtNOV" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="NOV" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="item">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                            <table width="100%" class="tblComment">
                                                <tr>
                                                    <th width="25%">DEC</th>
                                                    <th width="25%">JAN</th>
                                                    <th width="25%">FEB</th>
                                                    <th width="25%">MAR</th>
                                                </tr>
                                                <tr>
                                                    <td><textarea name="txtCmmtDEC" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="DEC" ></textarea></td>
                                                    <td><textarea name="txtCmmtJAN" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="JAN" ></textarea></td>
                                                    <td><textarea name="txtCmmtFEB" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="FEB" ></textarea></td>
                                                    <td><textarea name="txtCmmtMAR" class="txtComment" data-costcenter="..DIRECT_EXPENSE_WC" data-month="MAR" ></textarea></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                                <!-- Left and right controls -->
                                <a class="left carousel-control" href="#boxCommentECWC" data-slide="prev" style="width: 5% !important">
                                    <span class="glyphicon glyphicon-chevron-left"></span>
                                </a>
                                <a class="right carousel-control" href="#boxCommentECWC" data-slide="next" style="width: 5% !important">
                                    <span class="glyphicon glyphicon-chevron-right"></span>
                                </a>
                            </div>
                        </div>
                        <div style="clear:both;"></div>
                    </div>


                </div>
                <!-- Basic Forms & Horizontal Forms-->
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

