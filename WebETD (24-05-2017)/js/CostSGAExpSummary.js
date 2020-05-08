﻿function LoadJavaScript() {
    var CurDate = new Date();

    var date = new Date();
    if (CurDate.getMonth() == 0 || CurDate.getMonth() == 1 || CurDate.getMonth() == 2) {
        date = new Date(CurDate.getFullYear() - 1, CurDate.getMonth(), CurDate.getDay(), 8, 0, 0);
    } else {
        date = new Date(CurDate.getFullYear(), CurDate.getMonth(), CurDate.getDay(), 8, 0, 0);
    }

    //------------------------- Load Chart -----------------------------
    $("#gpSGAExpense").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartSaleData('gpSGAExpense', 'ALL', formatDate(date));

    $("#gpPartSupply").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpPartSupply', 'PartSupply', formatDate(date));

    $("#gpITEC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpITEC', 'ITEC', formatDate(date));

    $("#gpAdministration").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpAdministration', 'Administration', formatDate(date));

    $("#gpCSR").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpCSR', 'CSR', formatDate(date));

    $("#gpTD").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpTD', 'TD', formatDate(date));

    $("#gpSA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpSA', 'SA', formatDate(date));

    $("#gpDCICENTER").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpDCICENTER', 'DCICENTER', formatDate(date));


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
    var json_PrdActual = new Array();
    var json_SaleRatio = new Array();
    var json_SaleAmount = new Array();
    var json_CostCenter = new Array();
    var json_Expense = new Array();
    var json_Result = new Array();
    var json_YearMonth = new Array();
    var dataTitle = "";

    if (_CostCenter == "ALL") {
        dataTitle = "S.G.A Expense DCI of " + DataDate.getFullYear();
    } else if (_CostCenter == "PartSupply") {
        dataTitle = "S.G.A Expense Production Control & SCM of " + DataDate.getFullYear();
    } else if (_CostCenter == "ITEC") {
        dataTitle = "S.G.A Expense IT & EC of " + DataDate.getFullYear();
    } else if (_CostCenter == "TD") {
        dataTitle = "S.G.A Expense Trainning of " + DataDate.getFullYear();
    } else if (_CostCenter == "CSR") {
        dataTitle = "S.G.A Expense Corporate Compliannce of " + DataDate.getFullYear();
    } else {
        dataTitle = "S.G.A Expense " + _CostCenter + " of " + DataDate.getFullYear();
    }

    $.getJSON("BudgetSGAExpense.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

        for (i = 0; i < ResponseData.length; i++) {
            json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            json_PrdActual.push([ResponseData[i].dataPrdActual]);
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
                    className: 'highcharts-color-1',
                    title: {
                        text: 'Expense Budget',
                        style: {
                            color: '#FFF',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} THB',
                        formatter: function () {
                            return this.value / 1000000 + "M";
                        },
                        style: {
                            color: '#FFF',
                            fontSize: '10px'
                        }
                    },
                    opposite: false,
                    min:0
                    //showFirstLabel: false
                },
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'Accumulate Cost Per Unit',
                        style: {
                            color: '#2EE2CA',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} THB/Unit',
                        style: {
                            color: '#2EE2CA',
                            fontSize: '10px'
                        }
                    },
                    opposite: true,
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
                    yAxis: 1,
                    zIndex: 2,
                    color: '#2EE2CA',
                    data: json_PrdPerUnit
                }
                ,
                {
                    name: 'Target THB/Unit',
                    type: 'line',
                    yAxis: 1,
                    zIndex: 2,
                    color: '#0A21CA',
                    data: json_PrdTarget
                },
                {
                    name: 'Expense',
                    type: 'column',
                    yAxis: 0,
                    zIndex: 1,
                    color: '#F5AF18',
                    data: json_Expense
                },
                {
                    name: 'Actual',
                    type: 'column',
                    yAxis: 0,
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


function loadChartSaleData(_objChart, _CostCenter, _DataDate) {
    var DataDate = new Date(_DataDate);
    var json_PrdTarget = new Array();
    var json_PrdPerUnit = new Array();
    var json_PrdActual = new Array();
    var json_SaleRatio = new Array();
    var json_SaleAmount = new Array();
    var json_CostCenter = new Array();
    var json_Expense = new Array();
    var json_Result = new Array();
    var json_YearMonth = new Array();
    var dataTitle = "";

    if (_CostCenter == "ALL") {
        dataTitle = "S.G.A Expense DCI of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "S.G.A Expense Factory 1 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "S.G.A Expense Factory 2 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "S.G.A Expense Factory 3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "S.G.A Expense Factory ODM of " + DataDate.getFullYear();
    }

    $.getJSON("BudgetSGAExpense.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

        for (i = 0; i < ResponseData.length; i++) {
            json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            json_PrdActual.push([ResponseData[i].dataPrdActual]);
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
                    className: 'highcharts-color-1',
                    title: {
                        text: 'Expense Budget',
                        style: {
                            color: '#FFF',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} THB',
                        formatter: function () {
                            return this.value / 1000000 + "M";
                        },
                        style: {
                            color: '#FFF',
                            fontSize: '10px'
                        }
                    },
                    opposite: false,
                    min:0
                    //showFirstLabel: false
                },
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'Accumulate Cost Per Unit',
                        style: {
                            color: '#2EE2CA',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} THB/Unit',
                        style: {
                            color: '#2EE2CA',
                            fontSize: '10px'
                        }
                    },
                    opposite: true,
                    min:0
                    //showFirstLabel: false

                },
                {
                    className: 'highcharts-color-2',
                    title: {
                        text: 'Accumulate Sale Ratio',
                        style: {
                            color: '#FF00FF',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.1f}%',
                        style: {
                            color: '#FF00FF',
                            fontSize: '10px'
                        }
                    },
                    opposite: true,
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
                    yAxis: 1,
                    zIndex: 2,
                    color: '#2EE2CA',
                    data: json_PrdPerUnit
                }
                ,
                {
                    name: 'Target THB/Unit',
                    type: 'line',
                    yAxis: 1,
                    zIndex: 2,
                    color: '#0A21CA',
                    data: json_PrdTarget
                },
                {
                    name: 'Sale Ratio',
                    type: 'line',
                    yAxis: 2,
                    zIndex: 3,
                    color: '#EC34EC',
                    data: json_SaleRatio
                },
                {
                    name: 'Expense',
                    type: 'column',
                    yAxis: 0,
                    zIndex: 1,
                    color: '#F5AF18',
                    data: json_Expense
                },
                {
                    name: 'Actual',
                    type: 'column',
                    yAxis: 0,
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




