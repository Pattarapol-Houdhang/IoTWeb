<%@ Page Language="C#" MasterPageFile="~/Template/TemplateNoMenu.master" AutoEventWireup="true" CodeFile="GraphTempOven.aspx.cs" Inherits="GraphTempOven" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="JS/highcharts.js"></script>
    <script type="text/javascript" src="JS/Highchartthemdark.js"></script>

    <!-- DataTables -->
    <script src="Template/Admin/plugins/datatables/jquery.dataTables.min.js"></script>

    <script src="Template/Admin/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <%--<script src="https://cdn.datatables.net/fixedcolumns/3.2.4/js/dataTables.fixedColumns.min.js"></script>--%>

    <script type="text/JavaScript">
        var idleInterval = setInterval("reloadPage()", 1000000);

        function reloadPage() {
            location.reload();
        }
     
    </script>

       <!---------------------- Script for Chart of TempOven -------------------->
   <script type="text/javascript">

       <%--function LoadDDLMonthTempOven() {
           $('#<%=  ddlTabTempOvenMonth.ClientID %>').change(
            function () {
                $("#loadTempOvenCost").show();
                LoadChartTempOven($('#<%= ddlTabTempOvenMonth.ClientID %>').val(), true, false);
            });

            $('#<%=  ddlTapTempOvenYear.ClientID %>').change(
           function () {
               $("#loadTempOvenCost").show();
               $("#loadTempOvenCost2").show();
               LoadChartTempOven($('#<%= ddlTabTempOvenMonth.ClientID %>').val(), true, true);
            });
        }--%>

       function LoadChartTempOven(monthselect, ddlchange, ddlYear) {
           var monthnamearr = ["January", "Fabuary", "March", "April", "May", "June", "July", "Auguest", "September", "October", "November", "December"];
           var boardid = "301";
           //var month = $('#<%= ddlTabTempOvenMonth.ClientID %>').val();
           if (ddlchange == true) {
               month = monthselect;
           }

           var url = 'JsonSrv/TempOvenSrv.ashx';
           var d = new Date();

           var pjson = $.getJSON(url,
           function (data) {
               var DateStr = new Array();
               var TempDay = new Array();
               var CH1 = new Array();
               var CH2 = new Array();
               var CH3 = new Array();
               var CH4 = new Array();
               var CH5 = new Array();
               var CH6 = new Array();
               var CH7 = new Array();
               var CH8 = new Array();
               var CH9 = new Array();
               var CH10 = new Array();
               var CH11 = new Array();
               var CH12 = new Array();

               var Temp = new Array();
               var CH = new Array();
               var CostKwh = new Array();
               var CostKwhTarget = new Array();
               var CostWater = new Array();
               var CostGas = new Array();
               var PDResutl = new Array();
               var CostAvg = new Array();

               for (var i = 0; i < data.length; i++) {

                   DateStr[i] = data[i].Date;
                   TempDay[i] = data[i].TempValue;
                   CH[i] = data[i].IDCH;
                   CH1[i] = data[i].Temp1;
                   CH2[i] = data[i].Temp2;
                   CH3[i] = data[i].Temp3;
                   CH4[i] = data[i].Temp4;
                   CH5[i] = data[i].Temp5;
                   CH6[i] = data[i].Temp6;
                   CH7[i] = data[i].Temp7;
                   CH8[i] = data[i].Temp8;
                   CH9[i] = data[i].Temp9;
                   CH10[i] = data[i].Temp10;
                   CH11[i] = data[i].Temp11;
                   CH12[i] = data[i].Temp12;


               }


               //---------------- Chart Cost/Unit each day ----------------
               $("#loadTempOvenCost").hide();
               Highcharts.setOptions(Highcharts.theme);
               Highcharts.chart('ChartTempOvenMonth', {


                   title: {
                       text: 'Temperature of Oven ' + d.format('ddd dd-MM-yy HH:mm:ss')
                   },
                   xAxis: {
                       categories: DateStr
                   },
                   yAxis: {
                       title: {
                           text: 'Temperature(C)'
                       },
                       min: 100,
                       max: 115,
                       tickInterval: 50

                   },

                   plotOptions: {
                       series: {
                           label: {
                               connectorAllowed: false
                           }
                       }
                   },
                   tooltip: {
                       shared: true,
                       useHTML: true,
                       headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                       pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y}C</b></td></tr>',
                       footerFormat: '</table>',
                       valueDecimals: 2
                   },

                   series: [{
                       name: 'CH1',
                       color: '#AC33FF',
                       data: CH1,
                       type: 'spline',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff',

                       }
                   }, {
                       name: 'CH2',
                       color: '#FFBB33',
                       data: CH2,
                       type: 'spline',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }

                   }, {
                       name: 'CH3',
                       color: '#0C8304',
                       data: CH3,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH4',
                       color: '#20B1F9',
                       data: CH4,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH5',
                       color: '#07EEE7',
                       data: CH5,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH6',
                       color: '#58C2E3',
                       data: CH6,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH7',
                       color: '#E7F90C',
                       data: CH7,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH8',
                       color: '#FF42FF',
                       data: CH8,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH9',
                       color: '#067BCC',
                       data: CH9,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH10',
                       color: '#FFE400',
                       data: CH10,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH11',
                       color: '#0A1A9C',
                       data: CH11,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }
                   }, {
                       name: 'CH12',
                       color: '#06F3EF',
                       data: CH12,
                       type: 'line',
                       lineWidth: 4,
                       dataLabels: {
                           enabled: false,
                           color: '#ffffff'
                       }


                   }]


               });
           });


           //------------------ Chart of Usage of year ---------------------
           <%--var CH = $('#<%= ddlTabTempOvenCH.ClientID %>').val();
            var url2 = 'JsonSrv/TempOvenSrv.ashx?month=' + month + '&CH='+ '&board=' + boardid ;
            var pjson2 = $.getJSON(url2,
            function (data2) {
                var Month = new Array();
                Var CH1 = new Array();
                var AvrTemp = new Array();
                var MaxTemp = new Array();
                var MinTemp = new Array();
                var CostKwhMonth = new Array();
                var CostKwhMonthUnit = new Array();
                var Target = new Array();

                for (var i = 0; i < data2.length; i++) {
                    Month[i] = data2[i].Month;
                    AvrTemp[i] = data2[i].TempValue;
                    CH1 [i] = data2[i].DTemp1;

                    CostKwhMonth[i] = data2[i].CostEnergy;
                    CostKwhMonthUnit[i] = data2[i].CostEnergyUnit;
                    Target[i] = data2[i].TargetElec;
                }
                $("#loadTempOvenCost2").hide();

                Highcharts.setOptions(Highcharts.theme);
                Highcharts.chart('ChartTempOvenCH', {

                    title: {
                        text: 'Temperature usage (C) each month of year ' + year
                    },
                    xAxis: {
                        categories: Month
                    },
                    yAxis: [{ // First yAxis
                        title: {
                            text: 'Kwh Usage',
                            style: {
                                color: '#ff921e'
                            }
                        },
                        labels: {
                            format: '{value}',
                            style: {
                                color: '#ff921e'
                            }
                        },
                        stackLabels: {
                            enabled: true,
                            style: {
                                fontWeight: 'bold',
                                color: '#ff921e'
                            }
                        }
                    }, { // Secondary yAxis
                        title: {
                            text: 'Kwh/Unit',
                            style: {
                                color: '#ff1e1e'
                            }
                        },
                        labels: {
                            format: '{value}',
                            style: {
                                color: '#ff1e1e'
                            }
                        },
                        stackLabels: {
                            enabled: true,
                            style: {
                                fontWeight: 'bold',
                                color: '#ff1e1e'
                            }
                        },
                        opposite: true,
                        min: 0,
                        tickInterval: 0.25
                    }],
                    plotOptions: {
                        series: {
                            label: {
                                connectorAllowed: false
                            }
                        }
                    },
                    legend: {
                        align: 'right',
                        x: -120,
                        verticalAlign: 'top',
                        y: 25,
                        floating: true,
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                        borderColor: '#ffffff',
                        borderWidth: 1,
                        shadow: false
                    },
                    tooltip: {
                        shared: true,
                        useHTML: true,
                        headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                        pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y} Kwh</b></td></tr>',
                        footerFormat: '</table>',
                        valueDecimals: 2
                    },
                    series: [{
                        name: 'Temperature(C)',
                        color: '#ff921e',
                        data: AvrTemp,
                        type: 'line',
                        dataLabels: {
                            enabled: true,
                            color: '#ffffff'
                        }
                    }, {
                        name: 'Target',
                        color: '#ffff00',
                        data: AvrTemp,
                        type: 'line',
                        lineWidth: 4,
                        //marker: false
                    }, {
                        name: 'Kwh/Unit',
                        color: '#ff1e1e',
                        data: AvrTemp,
                        type: 'line',
                        lineWidth: 4,
                        dataLabels: {
                            enabled: true,
                            color: '#ffffff'
                        },
                        yAxis: 1
                    }]
                });
                setTimeout(function () { pjson2.abort(); }, 60000);
            });--%>



           var url = 'JsonSrv/TempOvenSrv.ashx';
           var d = new Date();

           var pjson = $.getJSON(url,
           function (data) {
               var DateStr = new Array();
               var TempDay = new Array();
               var CH1 = new Array();
               var CH2 = new Array();
               var CH3 = new Array();
               var CH4 = new Array();
               var CH5 = new Array();
               var CH6 = new Array();
               var CH7 = new Array();
               var CH8 = new Array();
               var CH9 = new Array();
               var CH10 = new Array();
               var CH11 = new Array();
               var CH12 = new Array();

               var Temp = new Array();
               var CH = new Array();
               var CostKwh = new Array();
               var CostKwhTarget = new Array();
               var CostWater = new Array();
               var CostGas = new Array();
               var PDResutl = new Array();
               var CostAvg = new Array();
               var Dformat = d.format('yyyy,MM,d')+ ",08,0,0";
          

               for (var i = 0; i < data.length; i++) {

                   DateStr[i] = data[i].Date;
                   TempDay[i] = data[i].TempValue;
                   CH[i] = data[i].IDCH;
                   CH1[i] = data[i].Temp1;
                   CH2[i] = data[i].Temp2;
                   CH3[i] = data[i].Temp3;
                   CH4[i] = data[i].Temp4;
                   CH5[i] = data[i].Temp5;
                   CH6[i] = data[i].Temp6;
                   CH7[i] = data[i].Temp7;
                   CH8[i] = data[i].Temp8;
                   CH9[i] = data[i].Temp9;
                   CH10[i] = data[i].Temp10;
                   CH11[i] = data[i].Temp11;
                   CH12[i] = data[i].Temp12;


               }

             //  var totalsec = date.format('ss', (DateStr[data.length - 1] - DateStr[0]));
               var d1 = new Date(DateStr[data.length - 1]);//"now"
               var d2 = new Date(DateStr[0]);  // some date
               var diff = Math.abs(((d1 - d2)/10)/2);  // d
             //  var diff = Math.abs(DateStr[0]-DateStr[data.length - 1]  );

               $("#loadTempOvenCost").hide();
               Highcharts.setOptions(Highcharts.theme);
                  Highcharts.chart('ChartTempOven', {
               chart: {
                   type: 'spline',
                   scrollablePlotArea: {
                       minWidth: 600,
                       scrollPositionX: 1
                   }
               },
               title: {
                   text: 'Oven Temperature ' + d.format('ddd dd-MM-yy HH:mm:ss')
               },
               subtitle: {
                   text: ''
               },
               xAxis: {
                   categories: DateStr
               },
               yAxis: {
                   title: {
                       text: 'Temperature (*c)'
                   },
                   minorGridLineWidth: 0,
                   gridLineWidth: 0,
                   alternateGridColor: null,
                   //plotBands: [{ // Light air
                   //    from: 100,
                   //    to: 150,
                   //    color: 'rgba(68, 170, 213, 0.1)',
                   //    label: {
                   //        text: 'Light air',
                   //        style: {
                   //            color: '#606060'
                   //        }
                   //    }
                   //}, { // Light breeze
                   //    from: 100,
                   //    to: 150,
                   //    color: 'rgba(0, 0, 0, 0)',
                   //    label: {
                   //        text: 'Light breeze',
                   //        style: {
                   //            color: '#606060'
                   //        }
                   //    }
                   //}, { // Gentle breeze
                   //    from: 100,
                   //    to: 150,
                   //    color: 'rgba(68, 170, 213, 0.1)',
                   //    label: {
                   //        text: 'Gentle breeze',
                   //        style: {
                   //            color: '#606060'
                   //        }
                   //    }
                   //}, { // Moderate breeze
                   //    from: 100,
                   //    to: 150,
                   //    color: 'rgba(0, 0, 0, 0)',
                   //    label: {
                   //        text: 'Moderate breeze',
                   //        style: {
                   //            color: '#606060'
                   //        }
                   //    }
                   //}, { // Fresh breeze
                   //    from: 100,
                   //    to: 150,
                   //    color: 'rgba(68, 170, 213, 0.1)',
                   //    label: {
                   //        text: 'Fresh breeze',
                   //        style: {
                   //            color: '#606060'
                   //        }
                   //    }
                   //}, { // Strong breeze
                   //    from: 100,
                   //    to: 150,
                   //    color: 'rgba(0, 0, 0, 0)',
                   //    label: {
                   //        text: 'Strong breeze',
                   //        style: {
                   //            color: '#606060'
                   //        }
                   //    }
                   //}, { // High wind
                   //    from: 100,
                   //    to: 150,
                   //    color: 'rgba(68, 170, 213, 0.1)',
                   //    label: {
                   //        text: 'High wind',
                   //        style: {
                   //            color: '#606060'
                   //        }
                   //    }
                   //}]
               },
               tooltip: {
                   valueSuffix: ' *c'
               },
               plotOptions: {
                   spline: {
                       lineWidth: 5,
                       states: {
                           hover: {
                               lineWidth: 5
                           }
                       },
                       marker: {
                           enabled: false
                       },
                     //  pointInterval: 1600000,//diff, // one hour
                     //  pointStart: Date.UTC(d.getFullYear(), d.getMonth(), d.getDate(), 08, 0, 0)
                    //   pointEnd:Date.UTC(d.getFullYear(), d.getMonth(), d.getDate(), 20, 0, 0)
                   }
               },
               series: [{
                   name: 'CH1',
                   color :'#AC33FF',
                   data: CH1
                

               }, {
                   name: 'CH2',
                   data: CH2
               }, {
                   name: 'CH3',
                   data: CH3
               }, {
                   name: 'CH4',
                   data: CH4
               }, {
                   name: 'CH5',
                   data: CH5
               }, {
                   name: 'CH6',
                   data: CH6
               }, {
                   name: 'CH7',
                   data: CH7
               }, {
                   name: 'CH8',
                   data: CH8
               }, {
                   name: 'CH9',
                   data: CH9
               }, {
                   name: 'CH10',
                   data: CH10
               }, {
                   name: 'CH11',
                   data: CH11
               }, {
                   name: 'CH12',
                   data: CH12
             
               }],
               navigation: {
                   menuItemStyle: {
                       fontSize: '10px'
                   }
               }
           });
           });
       }

    </script>


       <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
     
        <ContentTemplate>
            <section class="content">

              <script type="text/javascript" language="javascript">

                Sys.Application.add_load(LoadChartTempOven);

             </script>

   
            <section class="content">
               

                  <!--------- Tab TermpOven ---------->
                                
                                  

                                    <div class="row">
                                       
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-2">
                                           
                                            <asp:DropDownList ID="ddlTabTempOvenMonth" class="form-control" runat="server" Visible="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div id="ChartTempOven" style="margin: 0 auto; padding-top: 10px; height: 60vh"></div>
                                        </div>
                                    </div>
                                   <%-- <div class="row">
                                        <div class="col-sm-12">
                                          
                                            <div id="ChartTempOvenMonth" style="margin: 0 auto; padding-top: 10px; height: 70vh"></div>
                                        </div>
                                    </div>--%>

                         
                                  

                            
                                <!--------- Tab Oven ---------->
      </section>
                             </div>
                <!------------ Tab Program ------------------->
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
 
    <!-- /.content -->
</asp:Content>


