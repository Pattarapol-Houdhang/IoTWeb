function LoadJavaScript() {
    var date = moment().format("YYYY-MM-DD");
    var dateMonth = moment().format("MMM-YYYY");
    $("#LineOutRatio").html("<center><img src='../images/loading/gears.gif' border='0' /></center>");
    $("#LineOutAccu").html("<center><img src='../images/loading/gears.gif' border='0' /></center>");
    $("#LineOutYear").html("<center><img src='../images/loading/gears.gif' border='0' /></center>");
    $("#LineOutAccuProc").html("<center><img src='../images/loading/gears.gif' border='0' /></center>");
    $("#LineOutRatioProc").html("<center><img src='../images/loading/gears.gif' border='0' /></center>");
    $("#HoldLineOutOverAll").html("<center><img src='../images/loading/gears.gif' border='0' /></center>");

    $(".lblMonth").text(" on " + dateMonth);


    $(".lnkHeadMenu").click(function () {
        $(".lnkHeadMenu").removeClass("active");
        $(this).addClass("active");

        var product = $(this).data("product");
        var isOverAll = (product == "OVERALL") ? true : false;
        if (product == "1YC/3") { $("#lblTitle").text("1YC FACTORY 3"); } else { $("#lblTitle").text(product); }
            
        loadChartData(isOverAll, product, date);
    });


    var product = $(".lnkHeadMenu.active").data("product");
    if (product == "1YC/3") { $("#lblTitle").text("1YC FACTORY 3"); } else { $("#lblTitle").text(product); }
    var isOverAll = (product == "OVERALL") ? true : false;
    loadChartData(isOverAll, product, date);



    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });
}


function loadChartData(isOverAll, PrdModel, dataDate) {
    if (isOverAll) {
        $("#boxOverAllChart").fadeIn(0);
        $("#boxSummaryChart").fadeOut(0);
    } else {
        $("#boxSummaryChart").fadeIn(0);
        $("#boxOverAllChart").fadeOut(0);
    }

    $.ajax({
        type: "GET",
        url: "LineOutChart.ashx",
        data: "pMode=year&pModel=" + PrdModel + "&pDate=" + dataDate,
        contentType: "application/json; charset=utf-8",
        async: false,
        cache: false,
        success: function (ResponseData) {
            var ResponseData = JSON.parse(ResponseData);

            var json_Hold = new Array();
            var json_LineOut = new Array();
            var json_Period = new Array();

            for (i = 0; i < ResponseData.length; i++) {
                json_Hold.push([ResponseData[i].dataCountHold]);
                json_LineOut.push([ResponseData[i].dataCountLineOut]);
                json_Period.push([ResponseData[i].dataPeriod]);
            }


            //------------------------- Chart summary direct -----------------------------  
            var detail = Highcharts.chart("LineOutYear", {
                chart: {
                    type: 'column',
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
                title: { text: '' },
                xAxis: {
                    categories: json_Period,
                    labels: {
                        style: {
                            color: '#FFF',
                            fontSize: '12px'
                        }
                    }
                },
                yAxis: [
                    {
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
                    }
                ],
                legend: {
                    verticalAlign: 'top'
                },
                credits: {
                    enabled: false
                },
                tooltip: {
                    shared: true,
                    useHTML: true,
                    headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                    pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    valueDecimals: 0
                },
                plotOptions: {
                    column: {
                        stacking: 'normal',
                        dataLabels: {
                            enabled: false,
                            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                        }
                    }
                },
                series: [
                    {
                        name: 'LineOut',
                        zIndex: 2,
                        color: '#ffd11a',
                        data: json_LineOut
                    },
                    {
                        name: 'Hold',
                        zIndex: 2,
                        color: '#ff1a1a',
                        data: json_Hold
                    }
                ],
            });
        }
    }); // end ajax


    $.ajax({
        type: "GET",
        url: "LineOutChart.ashx",
        data: "pMode=model&pModel=" + PrdModel + "&pDate=" + dataDate,
        contentType: "application/json; charset=utf-8",
        async: false,
        cache: false,
        success: function (ResponseData) {
            var ResponseData = JSON.parse(ResponseData);

            var json_Hold = new Array();
            var json_LineOut = new Array();
            var json_ModelCode = new Array();
            var json_Model = new Array();
            var json_Pie = new Array();

            for (i = 0; i < ResponseData.length; i++) {
                json_Hold.push([ResponseData[i].dataCountHold]);
                json_LineOut.push([ResponseData[i].dataCountLineOut]);
                json_ModelCode.push([ResponseData[i].dataModelCode]);
                json_Model.push([ResponseData[i].dataModel]);
                json_Pie.push({ name: ResponseData[i].dataModel, y: ResponseData[i].dataRatio });
            }

            //------------------------- Chart summary direct -----------------------------  
            var detail = Highcharts.chart("LineOutAccu", {
                chart: {
                    type: 'column',
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
                title: { text: '' },
                xAxis: {
                    categories: json_Model,
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
                            text: 'Accumulate',
                            style: {
                                color: '#fff',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f} Unit',
                            style: {
                                color: '#fff',
                                fontSize: '10px'
                            }
                        },
                        stackLabels: {
                            enabled: true,
                            style: {
                                color: '#FFF'
                            }
                        }
                    }
                ],
                legend: { enabled: false },
                credits: {
                    enabled: false
                },
                tooltip: {
                    shared: true,
                    useHTML: true,
                    headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                    pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    valueDecimals: 0
                },
                plotOptions: {
                    column: {
                        stacking: 'normal',
                        dataLabels: {
                            enabled: false,
                            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white'
                        }
                    }
                },
                series: [
                    {
                        name: 'LineOut',
                        zIndex: 2,
                        color: '#ffd11a',
                        data: json_LineOut
                    },
                    {
                        name: 'Hold',
                        zIndex: 2,
                        color: '#ff1a1a',
                        data: json_Hold
                    }
                ],
            });



            var pieChart = Highcharts.chart('LineOutRatio', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: { text: '' },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                credits: {
                    enabled: false
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: json_Pie
                }]
            });

        } // end response
    }); // end ajax


    $.ajax({
        type: "GET",
        url: "LineOutChart.ashx",
        data: "pMode=process&pModel=" + PrdModel + "&pDate=" + dataDate,
        contentType: "application/json; charset=utf-8",
        async: false,
        cache: false,
        success: function (ResponseData) {
            var ResponseData = JSON.parse(ResponseData);

            var json_LineOut = new Array();
            var json_ProcCode = new Array();
            var json_ProcName = new Array();
            var json_Pie = new Array();

            for (i = 0; i < ResponseData.length; i++) {
                json_LineOut.push([ResponseData[i].dataCountLineOut]);
                json_ProcCode.push([ResponseData[i].dataProcessCode]);
                json_ProcName.push([ResponseData[i].dataProcessName]);
                json_Pie.push({ name: ResponseData[i].dataProcessName, y: ResponseData[i].dataRatio });
            }

            //------------------------- Chart summary direct -----------------------------  
            var detail = Highcharts.chart("LineOutAccuProc", {
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
                title: { text: '' },
                xAxis: {
                    categories: json_ProcName,
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
                            text: 'Process NG',
                            style: {
                                color: '#fff',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f} Unit',
                            style: {
                                color: '#fff',
                                fontSize: '10px'
                            }
                        },
                        opposite: false,
                        showFirstLabel: false

                    }
                ],
                legend: { enabled: false },
                credits: {
                    enabled: false
                },
                tooltip: {
                    shared: true,
                    useHTML: true,
                    headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                    pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y}</b></td></tr>',
                    footerFormat: '</table>',
                    valueDecimals: 0
                },
                plotOptions: {
                    series: {
                        borderWidth: 0,
                        dataLabels: {
                            enabled: true,
                            format: '{point.y:.0f}',
                            style: { color: "#fff" }
                        }
                    }
                },
                series: [
                    {
                        name: 'Accumulate LineOut',
                        type: 'column',
                        yAxis: 0,
                        zIndex: 2,
                        color: '#ffd11a',
                        data: json_LineOut
                    }
                ],
            });



            var pieChart = Highcharts.chart('LineOutRatioProc', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: { text: '' },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                credits: {
                    enabled: false
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                            }
                        }
                    }
                },
                series: [{
                    name: 'Brands',
                    colorByPoint: true,
                    data: json_Pie
                }]
            });

        } // end response
    }); // end ajax


    if (isOverAll) {
        $.ajax({
            type: "GET",
            url: "LineOutChart.ashx",
            data: "pMode=overall&pDate=" + dataDate,
            contentType: "application/json; charset=utf-8",
            async: false,
            cache: false,
            success: function (ResponseData) {
                var ResponseData = JSON.parse(ResponseData);

                var json_Fac1LineOut = new Array();
                var json_Fac1Hold = new Array();
                var json_Fac2LineOut = new Array();
                var json_Fac2Hold = new Array();
                var json_Fac3LineOut = new Array();
                var json_Fac3Hold = new Array();
                var json_ODMLineOut = new Array();
                var json_ODMHold = new Array();
                var json_Period = new Array();

                for (i = 0; i < ResponseData.length; i++) {
                    json_Fac1LineOut.push([ResponseData[i].dataFac1LineOut]);
                    json_Fac1Hold.push([ResponseData[i].dataFac1Hold]);
                    json_Fac2LineOut.push([ResponseData[i].dataFac2LineOut]);
                    json_Fac2Hold.push([ResponseData[i].dataFac2Hold]);
                    json_Fac3LineOut.push([ResponseData[i].dataFac3LineOut]);
                    json_Fac3Hold.push([ResponseData[i].dataFac3Hold]);
                    json_ODMLineOut.push([ResponseData[i].dataODMLineOut]);
                    json_ODMHold.push([ResponseData[i].dataODMHold]);
                    json_Period.push([ResponseData[i].dataPeriod]);
                }

                //------------------------- Chart summary direct -----------------------------  
                var detail = Highcharts.chart("HoldLineOutOverAll", {
                    chart: {
                        type: 'column',
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
                    title: { text: '' },
                    xAxis: {
                        categories: json_Period,
                        labels: {
                            style: {
                                color: '#FFF',
                                fontSize: '12px'
                            }
                        }
                    },
                    yAxis: [
                        {
                            allowDecimals: false,
                            min: 0,
                            className: 'highcharts-color-0',
                            title: {
                                text: 'LineOut & Hold',
                                style: {
                                    color: '#fff',
                                    fontWeight: 'bold'
                                }
                            },
                            labels: {
                                format: '{value:,.0f} Unit',
                                style: {
                                    color: '#fff',
                                    fontSize: '10px'
                                }
                            },
                            opposite: false,
                            showFirstLabel: false
                        }
                    ],
                    legend: {

                    },
                    credits: {
                        enabled: false
                    },
                    tooltip: {
                        shared: true,
                        useHTML: true,
                        headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                        pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y}</b></td></tr>',
                        footerFormat: '</table>',
                        valueDecimals: 0
                    },
                    plotOptions: {
                        column: {
                            stacking: 'normal'
                        }
                    },
                    series: [
                        {
                            name: 'Fac1-LineOut',
                            color: '#ffd11a',
                            data: json_Fac1LineOut,
                            stack: 'Factory 1'
                        },
                        {
                            name: 'Fac1-Hold',
                            color: '#ff1a1a',
                            data: json_Fac1Hold,
                            stack: 'Factory 1'
                        },
                        {
                            name: 'Fac2-LineOut',
                            color: '#ffd11a',
                            data: json_Fac2LineOut,
                            stack: 'Factory 2'
                        },
                        {
                            name: 'Fac2-Hold',
                            color: '#ff1a1a',
                            data: json_Fac2Hold,
                            stack: 'Factory 2'
                        },
                        {
                            name: 'Fac3-LineOut',
                            color: '#ffd11a',
                            data: json_Fac3LineOut,
                            stack: 'Factory 3'
                        },
                        {
                            name: 'Fac3-Hold',
                            color: '#ff1a1a',
                            data: json_Fac3Hold,
                            stack: 'Factory 3'
                        }, {
                            name: 'ODM-LineOut',
                            color: '#ffd11a',
                            data: json_ODMLineOut,
                            stack: 'Factory ODM'
                        },
                        {
                            name: 'ODM-Hold',
                            color: '#ff1a1a',
                            data: json_ODMHold,
                            stack: 'Factory ODM'
                        }
                    ],
                });


            } // end response
        }); // end ajax
    } 
    

}


$(document).ready(function () {

});

var parameter = Sys.WebForms.PageRequestManager.getInstance();
parameter.add_endRequest(function () {

});




