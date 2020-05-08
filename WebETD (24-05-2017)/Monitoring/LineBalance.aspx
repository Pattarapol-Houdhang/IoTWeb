<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LineBalance.aspx.cs" Inherits="Monitoring_LineBalance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Highcharts/highcharts.js"></script>
    <script src="../Highcharts/modules/exporting.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <h4>Last Update: <asp:Label ID="lbLastUpdate" runat="server" Text=""></asp:Label></h4>
            <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
              <%=GenGraph() %>
            

            
        </div>
    </form>
</body>
</html>
