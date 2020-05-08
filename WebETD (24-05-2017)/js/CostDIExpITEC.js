function LoadJavaScript() {
    var CurDate = new Date();

    var date = new Date();
    if (CurDate.getMonth() == 0 || CurDate.getMonth() == 1 || CurDate.getMonth() == 2) {
        date = new Date(CurDate.getFullYear() - 1, CurDate.getMonth(), CurDate.getDay(), 8, 0, 0);
    } else {
        date = new Date(CurDate.getFullYear(), CurDate.getMonth(), CurDate.getDay(), 8, 0, 0);
    }

    //------------------------- Load Chart -----------------------------
    //$("#gpEC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartData('gpEC', 'EC', formatDate(date));
    //loadChartMergeData('gpEC', 'EC', 'gpECUT,gpECWC', 'UT,WC', formatDate(date));

    //$("#gpECUT").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartData('gpECUT', 'UT', formatDate(date));

    //$("#gpECWC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartData('gpECWC', 'WC', formatDate(date));


    $("#gpEC").html("<img src='../images/loading/gears.gif' border='0' />");
    $("#gpECUT").html("<img src='../images/loading/gears.gif' border='0' />");
    $("#gpECWC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMergeData('gpEC', 'EC', 'gpECUT,gpECWC', 'UT,WC', formatDate(date));
    

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




function loadChartMergeData(_HeadObjChart, _HeadCostCenter, _ObjChart, _CostCenter, _DataDate) {
    var DataDate = new Date(_DataDate);
    var json_PrdTarget_All = new Array();
    var json_PrdPerUnit_All = new Array();
    var json_SaleRatio_All = new Array();
    var json_SaleAmount_All = new Array();
    var json_CostCenter_All = new Array();
    var json_Expense_All = new Array();
    var json_Result_All = new Array();
    var json_YearMonth_All = new Array();

    var SpObjChart = _ObjChart.split(',');
    var SpCostCenter = _CostCenter.split(',');

    for (idx = 0; idx < SpObjChart.length; idx++) {
        var LoopObjChart = SpObjChart[idx];
        var LoopCostCenter = SpCostCenter[idx];

        var json_PrdTarget = new Array();
        var json_PrdPerUnit = new Array();
        var json_SaleRatio = new Array();
        var json_SaleAmount = new Array();
        var json_CostCenter = new Array();
        var json_Expense = new Array();
        var json_Result = new Array();
        var json_YearMonth = new Array();
        var dataTitle = "";
        dataTitle = "Direct Expense " + LoopCostCenter + " of " + DataDate.getFullYear();
        $.ajax({
            type: "GET",
            url: "BudgetDIExpense.ashx",
            data: "cc=" + LoopCostCenter + "&Date=" + _DataDate,
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false,
            success: function (ResponseData) {
                var ResponseData = JSON.parse(ResponseData);
                for (i = 0; i < ResponseData.length; i++) {
                    json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
                    json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
                    json_SaleAmount.push([ResponseData[i].dataSaleAmount]);
                    json_SaleRatio.push([ResponseData[i].dataSaleExpRatio]);
                    json_CostCenter.push([ResponseData[i].dataCostCenter]);
                    json_Expense.push([ResponseData[i].dataExpense]);
                    json_Result.push([ResponseData[i].dataResult]);
                    json_YearMonth.push([ResponseData[i].dataYearMonth]);

                    if (idx == 0) {
                        json_PrdTarget_All.push([ResponseData[i].dataPrdPerUnitTarget]);
                        json_PrdPerUnit_All.push([ResponseData[i].dataPrdPerUnit]);
                        json_SaleAmount_All.push([ResponseData[i].dataSaleAmount]);
                        json_SaleRatio_All.push([ResponseData[i].dataSaleExpRatio]);
                        json_CostCenter_All.push([ResponseData[i].dataCostCenter]);
                        json_Expense_All.push([ResponseData[i].dataExpense]);
                        json_Result_All.push([ResponseData[i].dataResult]);
                        json_YearMonth_All.push([ResponseData[i].dataYearMonth]);

                    } else {
                        json_PrdTarget_All[i] = [parseFloat(json_PrdTarget_All[i]) + parseFloat(ResponseData[i].dataPrdPerUnitTarget)];
                        json_PrdPerUnit_All[i] = [parseFloat(json_PrdPerUnit_All[i]) + parseFloat(ResponseData[i].dataPrdPerUnit)];
                        json_SaleAmount_All[i] = [parseFloat(json_SaleAmount_All[i]) + parseFloat(ResponseData[i].dataSaleAmount)];
                        json_SaleRatio_All[i] = [parseFloat(json_SaleRatio_All[i]) + parseFloat(ResponseData[i].dataSaleExpRatio)];
                        //json_CostCenter_All[i] = [parseFloat(json_CostCenter_All[i]) + parseFloat(ResponseData[i].dataCostCenter)];
                        json_Expense_All[i] = [parseFloat(json_Expense_All[i]) + parseFloat(ResponseData[i].dataExpense)];
                        json_Result_All[i] = [parseFloat(json_Result_All[i]) + parseFloat(ResponseData[i].dataResult)];
                        //json_YearMonth_All.push([ResponseData[i].dataYearMonth]);
                    }
                    
                }

                //------------------------- Chart summary direct -----------------------------  
                var detail = Highcharts.chart(LoopObjChart, {
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
            }
        });

    } // end for

    
    //------------------------- Chart summary direct -----------------------------
    var head = Highcharts.chart(_HeadObjChart, {
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
            text: "Direct Expense " + _HeadCostCenter + " of " + DataDate.getFullYear(),
            style: {
                color: '#FFF',
                fontWeight: 'bold'
            }
        },
        xAxis: {
            categories: json_CostCenter_All,
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
                data: json_PrdPerUnit_All
            }
            ,
            {
                name: 'Target THB/Unit',
                type: 'line',
                yAxis: 0,
                zIndex: 2,
                color: '#0A21CA',
                data: json_PrdTarget_All
            },
            {
                name: 'Expense',
                type: 'column',
                yAxis: 1,
                zIndex: 1,
                color: '#F5AF18',
                data: json_Expense_All
            },
            {
                name: 'Actual',
                type: 'column',
                yAxis: 1,
                zIndex: 1,
                color: '#2FF518',
                data: json_Result_All
            }
        ],
    });



    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
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

    dataTitle = "Direct Expense " + _CostCenter + " of " + DataDate.getFullYear();

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




