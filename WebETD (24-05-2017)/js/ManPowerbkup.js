function LoadJavaScript() {
    var CurDate = new Date();

    var date = new Date(CurDate.getFullYear(), CurDate.getMonth() - 1, CurDate.getDay(), 8, 0, 0);
    var month = new Date(CurDate.getFullYear(), CurDate.getMonth() - 1, CurDate.getDay(), 8, 0, 0);

    //------------------------- Load Chart Over All -----------------------------
    $("#gpHoldOverAll").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartOvelAllData('gpHoldOverAll', 'ALL', formatDate(date), formatDate(month));


    //------------------------- Factory 1 1YC M-A-----------------------------

    $("#gpHoldFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartOvelAllData('gpHoldFAC1', 'FAC1', formatDate(date), formatDate(month));

    $("#gpManFAC1M").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC1M', 'FAC1M', formatDate(date), formatDate(month));

    $("#gpManFAC1A").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC1A', 'FAC1A', formatDate(date), formatDate(month));


    $("#gpHoldODM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartOvelAllData('gpHoldODM', 'ODM', formatDate(date), formatDate(month));



   
    //------------------------- Factory 2 2YC M-A-----------------------------

    $("#gpHoldFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartOvelAllData('gpHoldFAC2', 'FAC2', formatDate(date), formatDate(month));

    $("#gpManFAC2M").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC2M', 'FAC2M', formatDate(date), formatDate(month));

    $("#gpManFAC2A").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC2A', 'FAC2A', formatDate(date), formatDate(month));

    $("#gpManFACSCRM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFACSCRM', 'SCRM', formatDate(date), formatDate(month));

    $("#gpManFACSCRA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFACSCRA', 'SCRA', formatDate(date), formatDate(month));

    $("#gpManFAC2MOM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC2MOM', 'FAC2MOM', formatDate(date), formatDate(month));

    $("#gpManFAC2MOA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC2MOA', 'FAC2MOA', formatDate(date), formatDate(month));

    //------------------------- Factory 3 1YC/3 M-A-----------------------------
    $("#gpHoldFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartOvelAllData('gpHoldFAC3', 'FAC3', formatDate(date), formatDate(month));

    $("#gpManFAC3M").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC3M', 'FAC3M', formatDate(date), formatDate(month));

    $("#gpManFAC3A").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartData('gpManFAC3A', 'FAC3A', formatDate(date), formatDate(month));


  


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
            $(this).text("(+) Show by Factory");
            $($(this).data("graphfac")).slideUp();
        }
    });
    $(".btnShowHideFac1").click(function () {

        if ($($(this).data("graphfac1")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphfac1")).slideDown();
        } else {
            $(this).text("(+) Factory 1");
            $($(this).data("graphfac1")).slideUp();
        }
    });

    $(".btnShowHideFac2").click(function () {

        if ($($(this).data("graphfac2")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphfac2")).slideDown();
        } else {
            $(this).text("(+) Factory 2");
            $($(this).data("graphfac2")).slideUp();
        }
    });

    $(".btnShowHideFac3").click(function () {

        if ($($(this).data("graphfac3")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphfac3")).slideDown();
        } else {
            $(this).text("(+) Factory 3");
            $($(this).data("graphfac3")).slideUp();
        }
    });

    $(".btnShowHideODM").click(function () {

        if ($($(this).data("graphodm")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphodm")).slideDown();
        } else {
            $(this).text("(+) Show Graph ODM");
            $($(this).data("graphodm")).slideUp();
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

    $(".btnShowHideWork").click(function () {
        if ($($(this).data("grabhtbwork")).is(":hidden")) {
            $(this).text("(-) Hide Table");
            $($(this).data("grabhtbwork")).slideDown();
        } else {
            $(this).text("(+) Show Table");
            $($(this).data("grabhtbwork")).slideUp();
        }

    });

    
}






function loadChartData(_objChart, _CostCenter, _DataDate, _DataMonth) {
    // var DataMonth = new Month(_DataMonth);
    var DataDate = new Date(_DataDate);
    var Prod = new Array();
    var Cost = new Array();
    var OverlAllSum = new Array();
    var OPPosition = new Array();
    var OPOT1 = new Array();
    var OPOT15 = new Array();
    var OPOT2 = new Array();
    var OPOT3 = new Array();
    var OPSumOT = new Array();

    var LEPosition = new Array();
    var LEOT1 = new Array();
    var LEOT15 = new Array();
    var LEOT2 = new Array();
    var LEOT3 = new Array();
    var LESumOT = new Array();

    var FOPosition = new Array();
    var FOOT1 = new Array();
    var FOOT15 = new Array();
    var FOOT2 = new Array();
    var FOOT3 = new Array();
    var FOSumOT = new Array();

    var SUPosition = new Array();
    var SUOT1 = new Array();
    var SUOT15 = new Array();
    var SUOT2 = new Array();
    var SUOT3 = new Array();
    var SUSumOT = new Array();




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
        dataTitle = "Ovel All Man Power of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1M") {
        dataTitle = "1YC Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1A") {
        dataTitle = "1YC Assy. of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2M") {
        dataTitle = "2YC Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2A") {
        dataTitle = "2YC Assy.  of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2MOM") {
        dataTitle = "MOTOR " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2MOA") {
        dataTitle = "ASSY.  of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "SCRM") {
        dataTitle = "SCR Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "SCRA") {
        dataTitle = "SCR Assy.  of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3M") {
        dataTitle = "1YC/3 Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3A") {
        dataTitle = "1YC/3  Assy. of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Factory ODM of " + DataDate.getFullYear();
    }

    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

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

            Cost.push([ResponseData[i].BudgetCost]);
            OverlAllSum.push([ResponseData[i].OverAllSum]);

            OPPosition.push([ResponseData[i].OPPosition]);
            OPOT1.push([ResponseData[i].OPOT1]);
            OPOT15.push([ResponseData[i].OPOT15]);
            OPOT2.push([ResponseData[i].OPOT2]);
            OPOT3.push([ResponseData[i].OPOT3]);
            //OPSumOT.push([ResponseData[i].OPSumOT]);

            LEOT1.push([ResponseData[i].LEOT1]);
            LEOT15.push([ResponseData[i].LEOT15]);
            LEOT2.push([ResponseData[i].LEOT2]);
            LEOT3.push([ResponseData[i].LEOT3]);

            FOOT1.push([ResponseData[i].FOOT1]);
            FOOT15.push([ResponseData[i].FOOT15]);
            FOOT2.push([ResponseData[i].FOOT2]);
            FOOT3.push([ResponseData[i].FOOT3]);

            SUOT1.push([ResponseData[i].SUOT1]);
            SUOT15.push([ResponseData[i].SUOT15]);
            SUOT2.push([ResponseData[i].SUOT2]);
            SUOT3.push([ResponseData[i].SUOT3]);


        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column',
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                    stops: [
                         //[0, '#098996'],
                         //     [1, '#054C54']
                       [0, '#FBFBD4'],
                              [1, '#C7C6A1']
                    ]
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#10100F',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: json_CostCenter,
                labels: {
                    style: {
                        color: '#10100F',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'Man/Hr',
                        style: {
                            color: '#10100F',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f}Hr.',
                        style: {
                            color: '#10100F',
                            fontSize: '10px'
                        }
                    },


                },
                {
                    className: 'highcharts-color-1',
                    title: {
                        text: 'Cost',
                        style: {
                            color: '#10100F',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} BHT.',
                        style: {
                            color: '#10100F',
                            fontSize: '10px'
                        }
                    },
                    stackLabels: {
                        enabled: true,
                        style: {

                            color: '#10100F'
                        }
                    },
                    opposite: true,
                    showFirstLabel: false

                }
            ],

            //legend: {
            //    align: 'center',
            //    x: -30,
            //    verticalAlign: 'top',
            //    y: 25,
            //    floating: true,
            //    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'Gray',
            //    borderColor: '#CCC',
            //    borderWidth: 1,
            //    shadow: false
            //},
            tooltip: {

                //headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                //pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                //            '<td style="padding:0"><b>{point.y} Min.</b></td></tr>',
                //footerFormat: '</table>',
                //shared: true,
                //useHTML: true

                headerFormat: '<b>{point.x}</b>',
                pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
                //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
                //shared: true
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    dataLabels: {
                        enabled: true,
                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Black',
                        grouping: false,
                        shadow: false,
                        borderWidth: 0
                    }
                }
            },
            series: [{
                name: 'Sum',
                color: '#FD0000',
                borderColor: '#FD0000',
                type: 'line',
                width: 5,
                data: OverlAllSum,

                tooltip: {
                    valuePrefix: '$',
                    valueSuffix: ' BHT'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }, {

                name: 'COST',
                color: '#FDF600',
                borderColor: '#FDF600',
                type: 'line',
                width: 2,
                data: Cost,

                tooltip: {
                    valuePrefix: '$',
                    valueSuffix: ' BHT'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }, {

                name: 'OP[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: OPOT1,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'OP[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: OPOT15,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'OP[OT2]',
                color: '#00FE1F',
                borderColor: '#FF0000',
                data: OPOT2,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'OP[OT3]',
                color: '#FE0000',
                borderColor: '#FE0000',
                data: OPOT3,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: LEOT1,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'LE[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: LEOT15,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: LEOT2,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: LEOT3,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: FOOT1,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'FO[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: FOOT15,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: FOOT2,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: FOOT3,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: SUOT1,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'SU[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: SUOT15,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: SUOT2,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: SUOT3,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },


            }]
        });
    });
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });

}


function loadChartOvelAllData(_objChart, _CostCenter, _DataDate, _DataMonth) {

    // var DataMonth = new Month(_DataMonth);
    var DataDate = new Date(_DataDate);


   
    var CostUnit = new Array();
    var AccumCostUnit = new Array();
    var SumProd = new Array();
    var Prod = new Array();
    var Cost = new Array();
    var OverlAllSum = new Array();
    var OPPosition = new Array();
    var OPOT1 = new Array();
    var OPOT15 = new Array();
    var OPOT2 = new Array();
    var OPOT3 = new Array();
    var OPSumOT = new Array();

    var LEPosition = new Array();
    var LEOT1 = new Array();
    var LEOT15 = new Array();
    var LEOT2 = new Array();
    var LEOT3 = new Array();
    var LESumOT = new Array();

    var FOPosition = new Array();
    var FOOT1 = new Array();
    var FOOT15 = new Array();
    var FOOT2 = new Array();
    var FOOT3 = new Array();
    var FOSumOT = new Array();

    var SUPosition = new Array();
    var SUOT1 = new Array();
    var SUOT15 = new Array();
    var SUOT2 = new Array();
    var SUOT3 = new Array();
    var SUSumOT = new Array();




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
        dataTitle = "Ovel All Man Power of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1M") {
        dataTitle = "1YC Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1A") {
        dataTitle = "1YC Assy. of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2M") {
        dataTitle = "2YC Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2A") {
        dataTitle = "2YC Assy.  of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3M") {
        dataTitle = "1YC/3 Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3A") {
        dataTitle = "1YC/3  Assy. of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Factory ODM of " + DataDate.getFullYear();
    }

    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

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

           
            CostUnit.push([ResponseData[i].CostUnit]);
            AccumCostUnit.push([ResponseData[i].AccumCostUnit]);

            SumProd.push([ResponseData[i].SumPrd]);
            Prod.push([ResponseData[i].Prd]);
            Cost.push([ResponseData[i].BudgetCost]);
            OverlAllSum.push([ResponseData[i].OverAllSum]);

            OPPosition.push([ResponseData[i].OPPosition]);
            OPOT1.push([ResponseData[i].OPOT1]);
            OPOT15.push([ResponseData[i].OPOT15]);
            OPOT2.push([ResponseData[i].OPOT2]);
            OPOT3.push([ResponseData[i].OPOT3]);
            //OPSumOT.push([ResponseData[i].OPSumOT]);

            LEOT1.push([ResponseData[i].LEOT1]);
            LEOT15.push([ResponseData[i].LEOT15]);
            LEOT2.push([ResponseData[i].LEOT2]);
            LEOT3.push([ResponseData[i].LEOT3]);

            FOOT1.push([ResponseData[i].FOOT1]);
            FOOT15.push([ResponseData[i].FOOT15]);
            FOOT2.push([ResponseData[i].FOOT2]);
            FOOT3.push([ResponseData[i].FOOT3]);

            SUOT1.push([ResponseData[i].SUOT1]);
            SUOT15.push([ResponseData[i].SUOT15]);
            SUOT2.push([ResponseData[i].SUOT2]);
            SUOT3.push([ResponseData[i].SUOT3]);


        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column',
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                    stops: [
                         //[0, '#098996'],
                         //     [1, '#054C54']
                       [0, '#FBFBD4'],
                              [1, '#C7C6A1']
                    ]
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#10100F',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: json_CostCenter,
                labels: {
                    style: {
                        color: '#10100F',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'Man/Hr',
                        style: {
                            color: '#10100F',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f}Hr.',
                        style: {
                            color: '#10100F',
                            fontSize: '10px'
                        }
                    },
                   

                }, {
                    className: 'highcharts-color-1',
                    title: {
                        text: 'THB/Unit',
                        style: {
                            color: '#FB0101',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} BHT.',
                        style: {
                            color: '#FB0101',
                            fontSize: '10px'
                        }
                    },
                    stackLabels: {
                        enabled: true,
                        style: {

                            color: '#FB0101'
                        }
                    },
                    opposite: true,
                    showFirstLabel: false

                }, {
                    className: 'highcharts-color-1',
                    title: {
                        text: 'Prod',
                        style: {
                            color: '#03A03C',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} Unit.',
                        style: {
                            color: '#03A03C',
                            fontSize: '10px'
                        }
                    },
                    stackLabels: {
                        enabled: true,
                        style: {

                            color: '#03A03C'
                        }
                    },
                    opposite: true,
                    showFirstLabel: false

                }
            ],

            //legend: {
            //    align: 'center',
            //    x: -30,
            //    verticalAlign: 'top',
            //    y: 25,
            //    floating: true,
            //    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'Gray',
            //    borderColor: '#CCC',
            //    borderWidth: 1,
            //    shadow: false
            //},
            tooltip: {
               
                    crosshairs: true,
                    shared: true,
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                            '<td style="padding:0;"><b>{point.y}</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true


                //headerFormat: '<b>{point.x}</b>',
                //pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
                //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
                //shared: true
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    dataLabels: {
                        enabled: true,
                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Black',
                        grouping: false,
                        shadow: false,
                        borderWidth: 0
                    }
                }
            },
            series: [{
                name: 'Accum.Cost',
                color: '#FD0000',
                borderColor: '#FD0000',
                type: 'line',
                width: 5,
                data: OverlAllSum,
            
                tooltip: {
                    valuePrefix: '$',
                    valueSuffix: ' BHT'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            },{
          
                name: 'COST',
                color: '#FDF600',
                borderColor: '#FDF600',
                type: 'line',
                width: 2,
                data: Cost,
            
                tooltip: {
                    valuePrefix: '$',
                    valueSuffix: ' BHT'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }, {

                 name: 'Accum.Prod',
                 color: '#03A03C',
                 borderColor: '#03A03C',
                 type: 'line',
                 width: 10,
                 data: SumProd,

                 tooltip: {
                     // valuePrefix: '$',
                     valueSuffix: ' Unit'
                 },
                 pointPadding: 0.3,
                 pointPlacement: 0.2,
                 yAxis: 2

             }, {

                name: 'Prod',
                color: '#09FB01',
                borderColor: '#09FB01',
                type: 'line',
                width: 10,
                data: Prod,

                tooltip: {
                   // valuePrefix: '$',
                    valueSuffix: ' Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 2

             }, {

                 name: 'Accum.CostUnit',
                 color: '#09090A',
                 borderColor: '#09090A',
                 type: 'line',
                 width: 10,
                 data: AccumCostUnit,

                 tooltip: {
                     valuePrefix: '$',
                     pointformat:'{point.y:,0.2f}',
                     valueSuffix: ' BHT/Unit'
                 },
                 pointPadding: 0.3,
                 pointPlacement: 0.2,
                 yAxis: 1

             },  {

                 name: 'CostUnit',
                 color: '#09090A',
                 borderColor: '#09090A',
                 type: 'line',
                 width: 10,
                 data: CostUnit,

                 tooltip: {
                     valuePrefix: '$',
                     pointformat: '{point.y:,0.2f}',
                     valueSuffix: ' BHT/Unit'
                 },
                 pointPadding: 0.3,
                 pointPlacement: 0.2,
                 yAxis: 1

             }, {

                name: 'OP[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: OPOT1,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'OP[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: OPOT15,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'OP[OT2]',
                color: '#00FE1F',
                borderColor: '#FF0000',
                data: OPOT2,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'OP[OT3]',
                color: '#FE0000',
                borderColor: '#FE0000',
                data: OPOT3,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: LEOT1,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'LE[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: LEOT15,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: LEOT2,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: LEOT3,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: FOOT1,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'FO[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: FOOT15,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: FOOT2,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: FOOT3,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: SUOT1,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'SU[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: SUOT15,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: SUOT2,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: SUOT3,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },
          

            }]
        });
    });
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });

}
function loadChartTest(_objChart, _CostCenter, _DataDate, _DataMonth) {

    // var DataMonth = new Month(_DataMonth);
    var DataDate = new Date(_DataDate);



    var CostUnit = new Array();
    var AccumCostUnit = new Array();
    var SumProd = new Array();
    var Prod = new Array();
    var Cost = new Array();
    var OverlAllSum = new Array();
    var OPPosition = new Array();
    var OPOT1 = new Array();
    var OPOT15 = new Array();
    var OPOT2 = new Array();
    var OPOT3 = new Array();
    var OPSumOT = new Array();

    var LEPosition = new Array();
    var LEOT1 = new Array();
    var LEOT15 = new Array();
    var LEOT2 = new Array();
    var LEOT3 = new Array();
    var LESumOT = new Array();

    var FOPosition = new Array();
    var FOOT1 = new Array();
    var FOOT15 = new Array();
    var FOOT2 = new Array();
    var FOOT3 = new Array();
    var FOSumOT = new Array();

    var SUPosition = new Array();
    var SUOT1 = new Array();
    var SUOT15 = new Array();
    var SUOT2 = new Array();
    var SUOT3 = new Array();
    var SUSumOT = new Array();




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
        dataTitle = "Ovel All Man Power of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1M") {
        dataTitle = "1YC Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1A") {
        dataTitle = "1YC Assy. of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2M") {
        dataTitle = "2YC Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2A") {
        dataTitle = "2YC Assy.  of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3M") {
        dataTitle = "1YC/3 Machine of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3A") {
        dataTitle = "1YC/3  Assy. of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "Factory ODM of " + DataDate.getFullYear();
    }

    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

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


            CostUnit.push([ResponseData[i].CostUnit]);
            AccumCostUnit.push([ResponseData[i].AccumCostUnit]);

            SumProd.push([ResponseData[i].SumPrd]);
            Prod.push([ResponseData[i].Prd]);
            Cost.push([ResponseData[i].BudgetCost]);
            OverlAllSum.push([ResponseData[i].OverAllSum]);

            OPPosition.push([ResponseData[i].OPPosition]);
            OPOT1.push([ResponseData[i].OPOT1]);
            OPOT15.push([ResponseData[i].OPOT15]);
            OPOT2.push([ResponseData[i].OPOT2]);
            OPOT3.push([ResponseData[i].OPOT3]);
            //OPSumOT.push([ResponseData[i].OPSumOT]);

            LEOT1.push([ResponseData[i].LEOT1]);
            LEOT15.push([ResponseData[i].LEOT15]);
            LEOT2.push([ResponseData[i].LEOT2]);
            LEOT3.push([ResponseData[i].LEOT3]);

            FOOT1.push([ResponseData[i].FOOT1]);
            FOOT15.push([ResponseData[i].FOOT15]);
            FOOT2.push([ResponseData[i].FOOT2]);
            FOOT3.push([ResponseData[i].FOOT3]);

            SUOT1.push([ResponseData[i].SUOT1]);
            SUOT15.push([ResponseData[i].SUOT15]);
            SUOT2.push([ResponseData[i].SUOT2]);
            SUOT3.push([ResponseData[i].SUOT3]);


        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column',
                backgroundColor: {
                    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                    stops: [
                         //[0, '#098996'],
                         //     [1, '#054C54']
                       [0, '#FBFBD4'],
                              [1, '#C7C6A1']
                    ]
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#10100F',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: json_CostCenter,
                labels: {
                    style: {
                        color: '#10100F',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'Man/Hr',
                        style: {
                            color: '#10100F',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f}Hr.',
                        style: {
                            color: '#10100F',
                            fontSize: '10px'
                        }
                    },


                }, {
                    className: 'highcharts-color-1',
                    title: {
                        text: 'THB/Unit',
                        style: {
                            color: '#FB0101',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} BHT.',
                        style: {
                            color: '#FB0101',
                            fontSize: '10px'
                        }
                    },
                    stackLabels: {
                        enabled: true,
                        style: {

                            color: '#FB0101'
                        }
                    },
                    opposite: true,
                    showFirstLabel: false

                }, {
                    className: 'highcharts-color-1',
                    title: {
                        text: 'Prod',
                        style: {
                            color: '#03A03C',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f} Unit.',
                        style: {
                            color: '#03A03C',
                            fontSize: '10px'
                        }
                    },
                    stackLabels: {
                        enabled: true,
                        style: {

                            color: '#03A03C'
                        }
                    },
                    opposite: true,
                    showFirstLabel: false

                }
            ],

            //legend: {
            //    align: 'center',
            //    x: -30,
            //    verticalAlign: 'top',
            //    y: 25,
            //    floating: true,
            //    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'Gray',
            //    borderColor: '#CCC',
            //    borderWidth: 1,
            //    shadow: false
            //},
            tooltip: {

                crosshairs: true,
                shared: true,
                headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                            '<td style="padding:0;"><b>{point.y}</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true


                //headerFormat: '<b>{point.x}</b>',
                //pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
                //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
                //shared: true
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    dataLabels: {
                        enabled: true,
                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Black',
                        grouping: false,
                        shadow: false,
                        borderWidth: 0
                    }
                }
            },
            series: [{
                name: 'Accum.Cost',
                color: '#FD0000',
                borderColor: '#FD0000',
                type: 'line',
                width: 5,
                data: OverlAllSum,

                tooltip: {
                    valuePrefix: '$',
                    valueSuffix: ' BHT'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }, {

                name: 'COST',
                color: '#FDF600',
                borderColor: '#FDF600',
                type: 'line',
                width: 2,
                data: Cost,

                tooltip: {
                    valuePrefix: '$',
                    valueSuffix: ' BHT'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }, {

                name: 'Accum.Prod',
                color: '#03A03C',
                borderColor: '#03A03C',
                type: 'line',
                width: 10,
                data: SumProd,

                tooltip: {
                    // valuePrefix: '$',
                    valueSuffix: ' Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 2

            }, {

                name: 'Prod',
                color: '#09FB01',
                borderColor: '#09FB01',
                type: 'line',
                width: 10,
                data: Prod,

                tooltip: {
                    // valuePrefix: '$',
                    valueSuffix: ' Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 2

            }, {

                name: 'Accum.CostUnit',
                color: '#09090A',
                borderColor: '#09090A',
                type: 'line',
                width: 10,
                data: AccumCostUnit,

                tooltip: {
                    valuePrefix: '$',
                    pointformat: '{point.y:,0.2f}',
                    valueSuffix: ' BHT/Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }, {

                name: 'CostUnit',
                color: '#09090A',
                borderColor: '#09090A',
                type: 'line',
                width: 10,
                data: CostUnit,

                tooltip: {
                    valuePrefix: '$',
                    pointformat: '{point.y:,0.2f}',
                    valueSuffix: ' BHT/Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }, {

                name: 'OP[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: OPOT1,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'OP[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: OPOT15,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'OP[OT2]',
                color: '#00FE1F',
                borderColor: '#FF0000',
                data: OPOT2,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'OP[OT3]',
                color: '#FE0000',
                borderColor: '#FE0000',
                data: OPOT3,
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: LEOT1,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'LE[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: LEOT15,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: LEOT2,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'LE[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: LEOT3,
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: FOOT1,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'FO[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: FOOT15,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: FOOT2,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'FO[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: FOOT3,
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: SUOT1,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },

            }, {
                name: 'SU[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: SUOT15,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: SUOT2,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },
            }, {
                name: 'SU[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: SUOT3,
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.'
                },


            }]
        });
    });
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });
}

function loadChartPareto(_objChart, _CostCenter, _DataDate, _DataMonth) {
    var DataMonth = new Month(_DataMonth);
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
        dataTitle = "Ovel All Hold Statistic of " + DataDate.getFullYear();
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




