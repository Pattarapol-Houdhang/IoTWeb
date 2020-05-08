﻿function LoadJavaScript() {
    var CurDate = new Date();

    var date = new Date(CurDate.getFullYear(), CurDate.getMonth() - 1, CurDate.getDay(), 8, 0, 0);

    //------------------------- Load Chart -----------------------------
    $("#gpFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpFAC1', 'FAC1', formatDate(date));

    $("#gpFAC1M").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpFAC1M', 'FAC1M', formatDate(date));

    $("#gpFAC1A").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpFAC1A', 'FAC1A', formatDate(date));


    $(".btnShowHideComment").click(function () {
        if ($($(this).data("comment")).is(":hidden")) {
            $(this).text("(-) Hide Comment");
            $($(this).data("comment")).slideDown();
        } else {
            $(this).text("(+) Show Comment");
            $($(this).data("comment")).slideUp();
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
    var json_Expense = new Array();
    var json_Result = new Array();
    var json_YearMonth = new Array();
    var dataTitle = "";

    if (_CostCenter == "FAC1") {
        dataTitle = "Direct Expense Factory 1 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Direct Expense Factory 2 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Direct Expense Factory 3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Direct Expense Factory ODM of " + DataDate.getFullYear();
    }

    $.getJSON("BudgetDIExpense.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

        for (i = 0; i < ResponseData.length; i++) {
            json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            json_SaleAmount.push([ResponseData[i].dataSaleAmount]);
            json_SaleRatio.push([ResponseData[i].dataSaleExpRatio]);
            json_CostCenter.push([ResponseData[i].dataCostCenter]);
            json_Expense.push([ResponseData[i].dataExpense]);
            json_Result.push([ResponseData[i].dataResult]);
            json_YearMonth.push([ResponseData[i].dataYearMonth]);
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {
            chart: {
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                    stops: [
                        [0, '#7B7878'],
                        [1, '#9A9A9A']
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
            yAxis: [
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'Cost/Unit',
                        style: {
                            color: '#FFF',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} THB/Unit',
                        style: {
                            color: '#FFF',
                            fontSize: '10px'
                        }
                    },
                    opposite: true,
                    min:0
                    //showFirstLabel: false

                },
                {
                    className: 'highcharts-color-1',
                    title: {
                        text: 'THB',
                        style: {
                            color: '#FFF',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} THB',
                        style: {
                            color: '#FFF',
                            fontSize: '10px'
                        }
                    },
                    min:0
                    //showFirstLabel: false
                }
            ],
            legend: {
                align: 'center',
                verticalAlign: 'top',
                x: 0,
                y: 30,
                floating: true,
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {
                shared: true,
                useHTML: true,
                headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y}</b></td></tr>',
                footerFormat: '</table>',
                valueDecimals: 2
            },
            series: [
                {
                    name: 'Expense THB/Unit',
                    type: 'line',
                    yAxis: 0,
                    zIndex: 2,
                    color: '#2EE2CA',
                    data: json_PrdPerUnit
                }
                ,
                {
                    name: 'Target THB/Unit',
                    type: 'line',
                    yAxis: 0,
                    zIndex: 2,
                    color: '#0A21CA',
                    data: json_PrdTarget
                },
                {
                    name: 'Expense',
                    type: 'column',
                    yAxis: 1,
                    zIndex: 1,
                    color: '#F5AF18',
                    data: json_Expense
                },
                {
                    name: 'Actual',
                    type: 'column',
                    yAxis: 1,
                    zIndex: 1,
                    color: '#2FF518',
                    data: json_Result
                }
            ],
        });

    });

    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
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




