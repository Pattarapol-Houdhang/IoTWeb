function LoadJavaScript() {
    var CurDate = new Date();

    var date = new Date(CurDate.getFullYear(), CurDate.getMonth() - 1, CurDate.getDay(), 8, 0, 0);

    //------------------------- Load Chart -----------------------------
    $("#gpHoldOvelAll").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartOvelAllData('gpHoldOvelAll', 'ALL', formatDate(date));

    //$("#gpHoldTest").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartTest('gpHoldTest', 'ALL', formatDate(date));

    $("#gpHoldFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpHoldFAC3', 'FAC3', formatDate(date));

    $("#gpHoldFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpHoldFAC2', 'FAC2', formatDate(date));

    $("#gpHoldFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpHoldFAC1', 'FAC1', formatDate(date));

    //Model Pareto Graph
    $("#gpFGHold3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartTest('gpFGHold3', 'FAC3', formatDate(date));

    $("#gpFGHold2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartTest('gpFGHold2', 'FAC2', formatDate(date));

    $("#gpFGHold1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartTest('gpFGHold1', 'FAC1', formatDate(date));

    //Model Pareto Graph
    //$("#gpHoldTest4").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartPareto('gpHoldTest4', 'FAC3', formatDate(date));

    

    //$("#gpODM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartData('gpODM', 'ODM', formatDate(date));


    $(".btnShowHideAll").click(function () {
        if ($($(this).data("graphall")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphall")).slideDown();
        } else {
            $(this).text("(+) Show Graph All");
            $($(this).data("graphall")).slideUp();
        }
    });

        $(".btnShowHideFac").click(function () {

            if ($($(this).data("graphfac")).is(":hidden")) {
           $(this).text("(-) Hide Graph");
           
            $($(this).data("graphfac")).slideDown();
        } else {
            $(this).text("(+) Show Graph Factory");
            $($(this).data("graphfac")).slideUp();
        }
        });

        $(".btnShowHideModel").click(function () {
        if ($($(this).data("graphmodell")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphmodell")).slideDown();
        } else {
            $(this).text("(+) Show Graph Model");
            $($(this).data("graphmodell")).slideUp();
        }

    });


}






function loadChartData(_objChart, _CostCenter, _DataDate) {
    var DataDate = new Date(_DataDate);
    var json_PrdTarget = new Array();
    var json_PrdPerUnit = new Array();
    var json_SaleRatio = new Array();
    var json_SaleAmount = new Array();
    var json_CostCenter = new Array();
    var json_Hold = new Array();
    var json_Result = new Array();
    var json_YearMonth = new Array();
    var dataTitle = "";
    var json_FGHold = new Array();
    var json_LineOut = new Array();


    if (_CostCenter == "ALL") {
        dataTitle = "Overall Hold Statistic of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Direct Expense Factory ODM of " + DataDate.getFullYear();
    }

    $.getJSON("AllHoldChart.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

        for (i = 0; i < ResponseData.length; i++) {
            json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            json_SaleAmount.push([ResponseData[i].dataSaleAmount]);
            json_SaleRatio.push([ResponseData[i].dataSaleExpRatio]);
            json_CostCenter.push([ResponseData[i].dataCostCenter]);
            json_Hold.push([ResponseData[i].dataHold]);
            json_Result.push([ResponseData[i].dataResult]);
            json_YearMonth.push([ResponseData[i].dataYearMonth]);


            json_FGHold.push([ResponseData[i].dataFGHold]);
            json_LineOut.push([ResponseData[i].dataLineOut]);
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column',
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                    stops: [
                       [0, '#098996'],
                              [1, '#054C54']
                    ]
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#606063'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#FFF',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: json_CostCenter,
                labels: {
                    style: {
                        color: '#FFF',
                        fontSize: '12px'
                    }
                }
            }, 

            yAxis: {
                min: 0,
                title: {
                    text: 'Unit',
                    style: {
                        color: '#FFF',
                        fontWeight: 'bold'
                    }

                }, labels: {
                    style: {
                        color: '#FFF',
                        fontSize: '12px'
                    }
                },
                stackLabels: {
                    enabled: true,
                    style: {

                        color: '#FFF'
                    }
                }
            },
            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 25,
                floating: true,
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },

            legend: {
                align: 'center',
                x: -30,
                verticalAlign: 'top',
                y: 25,
                floating: true,
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'Gray',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {
                headerFormat: '<b>{point.x}</b><br/>',

                pointFormat: '{series.name}: <b>{point.y} Unit</b>[{point.percentage:.0f}%]<br/>Total: {point.stackTotal}'
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    dataLabels: {
                        enabled: true,
                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Green'
                    }
                }
            },
            series: [{
                name: 'FG Hold',
                color: '#F8FC07',
                borderColor: '#F8FC07',
                data: json_FGHold
            }, {
                name: 'LineOut',
                color: '#FF0000',
                borderColor: '#FF0000',
                data: json_LineOut

            }]
        });
    });
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });

}


function loadChartOvelAllData(_objChart, _CostCenter, _DataDate) {
    var DataDate = new Date(_DataDate);
    var json_PrdTarget = new Array();
    var json_PrdPerUnit = new Array();
    var json_SaleRatio = new Array();
    var json_SaleAmount = new Array();
    var json_CostCenter = new Array();
    var json_Hold = new Array();
    var json_Result = new Array();
    var json_YearMonth = new Array();
    var dataTitle = "";

    var OVDate = new Date(_DataDate);
    var json_FGHold = new Array();
    var json_LineOut = new Array();
    var json_ReqUnhold = new Array();
    var json_Unhold = new Array();
    var DataaTitle = "";



    if (_CostCenter == "ALL") {
        dataTitle = "Overall Hold of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Direct Expense Factory 3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Factory ODM of " + DataDate.getFullYear();
    }

    $.getJSON("AllHoldChart.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

        for (i = 0; i < ResponseData.length; i++) {
            json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            json_SaleAmount.push([ResponseData[i].dataSaleAmount]);
            json_SaleRatio.push([ResponseData[i].dataSaleExpRatio]);
            json_CostCenter.push([ResponseData[i].dataCostCenter]);
            json_Hold.push([ResponseData[i].dataHold]);
            json_Result.push([ResponseData[i].dataResult]);
   
           json_YearMonth.push([ResponseData[i].dataYearMonth]);

           json_FGHold.push([ResponseData[i].dataFGHold]);
           json_LineOut.push([ResponseData[i].dataLineOut]);

         
        }
  
        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {
          
            chart: {
                type: 'column',
          backgroundColor: {
              linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
              stops: [
                 [0, '#098996'],
                        [1, '#054C54']
              ]
          },
          style: {
              fontFamily: '\'Unica One\', sans-serif'
          },
          plotBorderColor: '#606063'
      },
      title: {
          text: dataTitle,
          style: {
              color: '#FFF',
              fontWeight: 'bold'
          }
      },
      xAxis: {
          categories: json_CostCenter,
          labels: {
              style: {
                  color: '#FFF',
                  fontSize: '12px'
              }
          }
      },

      yAxis: {
          min: 0,
          title: {
              text: 'Unit',
              style: {
                  color: '#FFF',
                  fontWeight: 'bold'
              }
      
          },  labels: {
              style: {
                  color: '#FFF',
                  fontSize: '12px'
              }
          },
          stackLabels: {
              enabled: true,
              style: {
                 
                color:'#FFF'
              }
          }
      },
      legend: {
          align: 'right',
          x: -30,
          verticalAlign: 'top',
          y: 25,
          floating: true,
          backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
          borderColor: '#CCC',
          borderWidth: 1,
          shadow: false
      },
     
      legend: {
          align: 'center',
          x: -30,
          verticalAlign: 'top',
          y: 25,
          floating: true,
          backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'Gray',
          borderColor: '#CCC',
          borderWidth: 1,
          shadow: false
      },
      tooltip: {
          headerFormat: '<b>{point.x}</b><br/>',
          pointFormat: '{series.name}: <b>{point.y} Unit</b>[{point.percentage:.0f}%]<br/>Total: {point.stackTotal}'
          //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
        //shared: true
      },
      plotOptions: {
          column: {
              stacking: 'normal',
              dataLabels: {
                  enabled: true,
                  color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Green'
              }
          }
      },
      series: [{
          name: 'FG Hold',
          color: '#F8FC07',
          borderColor: '#F8FC07',
          data: json_FGHold
      }, {
          name: 'LineOut',
          color: '#FF0000',
          borderColor: '#FF0000',
          data: json_LineOut
            
      }]
  });
    });
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });

}
function loadChartTest(_objChart, _CostCenter, _DataDate) {
    var DataDate = new Date(_DataDate);
    var json_PrdTarget = new Array();
    var json_PrdPerUnit = new Array();
    var json_SaleRatio = new Array();
    var json_SaleAmount = new Array();
    var json_CostCenter = new Array();
    var json_Hold = new Array();
    var json_Result = new Array();
    var json_YearMonth = new Array();
    var dataTitle = "";

    var OVDate = new Date(_DataDate);
    var json_121 = new Array();
    var json_442 = new Array();
    var json_444 = new Array();
    var json_FGHold = new Array();
    var json_LineOut = new Array();
    var json_ReqUnhold = new Array();
    var json_Unhold = new Array();
   
  
    


    if (_CostCenter == "ALL") {
        dataTitle = "Overall Hold Statistic of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 by Model of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 by Model of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 by Model of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Factory ODM by Model of " + DataDate.getFullYear();
    }

    $.getJSON("AllHoldChart.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

        for (i = 0; i < ResponseData.length; i++) {
            json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            json_SaleAmount.push([ResponseData[i].dataSaleAmount]);
            json_SaleRatio.push([ResponseData[i].dataSaleExpRatio]);
            json_CostCenter.push([ResponseData[i].dataCostCenter]);
            json_Hold.push([ResponseData[i].dataHold]);
            json_Result.push([ResponseData[i].dataResult]);

            json_YearMonth.push([ResponseData[i].dataYearMonth]);

            json_FGHold.push([ResponseData[i].dataFGHold]);
            json_LineOut.push([ResponseData[i].dataLineOut]);

            json_121.push([ResponseData[i].dataM121]);
            json_442.push([ResponseData[i].dataM442]);
            json_444.push([ResponseData[i].dataM444]);
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column',
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                    stops: [
                       [0, '#098996'],
                              [1, '#054C54']
                    ]
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#606063'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#FFF',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: json_CostCenter,
                labels: {
                    style: {
                        color: '#FFF',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: {
                min: 0,
                title: {
                    text: 'Unit',
                    style: {
                        color: '#FFF',
                        fontWeight: 'bold'
                    }

                }, labels: {
                    style: {
                        color: '#FFF',
                        fontSize: '12px'
                    }
                },
                stackLabels: {
                    enabled: true,
                    style: {

                        color: '#FFF'
                    }
                }
            },
            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 25,
                floating: true,
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },

            legend: {
                align: 'center',
                x: -30,
                verticalAlign: 'top',
                y: 25,
                floating: true,
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'Gray',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {
              
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                            '<td style="padding:0"><b>{point.y} Unit</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            //plotOptions: {
            //    column: {
            //        stacking: 'normal',
            //        dataLabels: {
            //            enabled: true,
            //            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Green'
            //        }
            //    }
            //},
            series: [{
                name: '121',
                color: '#F8FC07',
                borderColor: '#F8FC07',
                data: json_121
            }, {
                name: '442',
                color: '#001FFF',
                borderColor: '#001FFF',
                data: json_442
            }, {
                name: '444',
                color: '#FF0000',
                borderColor: '#FF0000',
                data: json_444
            }]
        });
    });
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });
}

function loadChartPareto(_objChart, _CostCenter, _DataDate) {
    var DataDate = new Date(_DataDate);
    var json_PrdTarget = new Array();
    var json_PrdPerUnit = new Array();
    var json_SaleRatio = new Array();
    var json_SaleAmount = new Array();
    var json_CostCenter = new Array();
    var json_Hold = new Array();
    var json_Result = new Array();
    var json_YearMonth = new Array();
    var dataTitle = "";

    var OVDate = new Date(_DataDate);
    var json_121 = new Array();
    var json_442 = new Array();
    var json_444 = new Array();
    var json_FGHold = new Array();
    var json_LineOut = new Array();
    var json_ReqUnhold = new Array();
    var json_Unhold = new Array();





    if (_CostCenter == "ALL") {
        dataTitle = "Overall Hold Statistic of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 by Model of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 by Model of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 by Model of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Factory ODM by Model of " + DataDate.getFullYear();
    }

    $.getJSON("AllHoldChart.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

        for (i = 0; i < ResponseData.length; i++) {
            json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            json_SaleAmount.push([ResponseData[i].dataSaleAmount]);
            json_SaleRatio.push([ResponseData[i].dataSaleExpRatio]);
            json_CostCenter.push([ResponseData[i].dataCostCenter]);
            json_Hold.push([ResponseData[i].dataHold]);
            json_Result.push([ResponseData[i].dataResult]);

            json_YearMonth.push([ResponseData[i].dataYearMonth]);

            json_FGHold.push([ResponseData[i].dataFGHold]);
            json_LineOut.push([ResponseData[i].dataLineOut]);

            json_121.push([ResponseData[i].dataM121]);
            json_442.push([ResponseData[i].dataM442]);
            json_444.push([ResponseData[i].dataM444]);
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart('_objChart', {
            chart: {
                renderTo: '_objChart',
                type: 'column'
            },
            title: {
                text: 'Restaurants Complaints'
            },
            xAxis: {
                categories: ['Overpriced', 'Small portions', 'Wait time', 'Food is tasteless', 'No atmosphere', 'Not clean', 'Too noisy', 'Unfriendly staff']
            },
            yAxis: [{
                title: {
                    text: ''
                }
            }, {
                title: {
                    text: ''
                },
                minPadding: 0,
                maxPadding: 0,
                max: 100,
                min: 0,
                opposite: true,
                labels: {
                    format: "{value}%"
                }
            }],
            series: [{
                type: 'pareto',
                name: 'Pareto',
                yAxis: 1,
                zIndex: 10,
                baseSeries: 1
            }, {
                name: 'Complaints',
                type: 'column',
                zIndex: 2,
                data: [755, 222, 151, 86, 72, 51, 36, 10]
            }]
        });
    });
}


function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('-');
}




