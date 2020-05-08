function LoadJavaScript(startDate, endDate,CH) {
    var CurDate = new Date();

    var StartDateSP = startDate.split('/');
    var EndDateSP = endDate.split('/');

    var Sdate = new Date(StartDateSP[2], StartDateSP[1]-1, StartDateSP[0], 8, 0, 0);
    var Edate = new Date(EndDateSP[2], EndDateSP[1]-1, EndDateSP[0], 8, 0, 0);

    //------------------------- Load Chart Over All -----------------------------
    //$("#gpAll").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllData('gpAll', 'ALL', formatDate(date), formatDate(month));

    if (CH == "" || CH == null) {
        CH = "CH1";
    }
    //------------------------- Factory 1 1YC M-A-----------------------------

    //$("#gpReal").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllRealTime('gpReal', CH, formatDate(Sdate), formatDate(Edate));
    if (CH == "ALL")
    {
        $("#gpCH1").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH1', 'CH1', formatDate(Sdate), formatDate(Edate));

        $("#gpCH2").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH2', 'CH2', formatDate(Sdate), formatDate(Edate));

        $("#gpCH3").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH3', 'CH3', formatDate(Sdate), formatDate(Edate));

        $("#gpCH4").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH4', 'CH4', formatDate(Sdate), formatDate(Edate));

        $("#gpCH5").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH5', 'CH5', formatDate(Sdate), formatDate(Edate));


        $("#gpCH6").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH6', 'CH6', formatDate(Sdate), formatDate(Edate));

        $("#gpCH7").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH7', 'CH7', formatDate(Sdate), formatDate(Edate));

        $("#gpCH8").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH8', 'CH8', formatDate(Sdate), formatDate(Edate));

        $("#gpCH9").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH9', 'CH9', formatDate(Sdate), formatDate(Edate));

        $("#gpCH10").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH10', 'CH10', formatDate(Sdate), formatDate(Edate));

        $("#gpCH11").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH11', 'CH11', formatDate(Sdate), formatDate(Edate));

        $("#gpCH12").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH12', 'CH12', formatDate(Sdate), formatDate(Edate));

    } else
    {
        $("#gpCH").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartOvelAllCH('gpCH', CH, formatDate(Sdate), formatDate(Edate));
    }
   

    //$("#gpCH2").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH2', 'CH2', formatDate(date), formatDate(month));

    //$("#gpCH3").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH3', 'CH3', formatDate(date), formatDate(month));

    //$("#gpCH4").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH4', 'CH4', formatDate(date), formatDate(month));

    //$("#gpCH5").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH5', 'CH5', formatDate(date), formatDate(month));


    //$("#gpCH6").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH6', 'CH6', formatDate(date), formatDate(month));

    //$("#gpCH7").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH7', 'CH7', formatDate(date), formatDate(month));

    //$("#gpCH8").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH8', 'CH8', formatDate(date), formatDate(month));

    //$("#gpCH9").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH9', 'CH9', formatDate(date), formatDate(month));

    //$("#gpCH10").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH10', 'CH10', formatDate(date), formatDate(month));

    //$("#gpCH11").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH11', 'CH11', formatDate(date), formatDate(month));

    //$("#gpCH12").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllCH('gpCH12', 'CH12', formatDate(date), formatDate(month));

    //$("#gpManFAC1M").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartData('gpManFAC1M', 'FAC1M', formatDate(date), formatDate(month));

    //$("#gpManFAC1A").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartData('gpManFAC1A', 'FAC1A', formatDate(date), formatDate(month));


    //$("#gpHoldODM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartOvelAllFac('gpHoldODM', 'ODM', formatDate(date), formatDate(month));





    $(".btnShowHideAll").click(function () {
        if ($($(this).data("graphall")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphall")).slideDown();
        } else {
            $(this).text("(+) Show Graph All");
            $($(this).data("graphall")).slideUp();
        }
    });
    $(".btnShowHideChannel").click(function () {
        if ($($(this).data("graphch")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphch")).slideDown();
        } else {
            $(this).text("(+) Show Graph Model");
            $($(this).data("graphch")).slideUp();
        }

    });

    $(".btnShowHideReal").click(function () {
        if ($($(this).data("graphreal")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphreal")).slideDown();
        } else {
            $(this).text("(+) Show Graph Model");
            $($(this).data("graphreal")).slideUp();
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
        dataTitle = "Factory 1 of" + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1M") {
        dataTitle = "PDM1YC of" + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1A") {
        dataTitle = "PDA1YC of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 of" + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2M") {
        dataTitle = "PDM2YC of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2A") {
        dataTitle = "PDA2YC of" + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2MOM") {
        dataTitle = "PDMOT of" + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2MOA") {
        dataTitle = "PDAL5 of" + DataDate.getFullYear();
    }
    else if (_CostCenter == "SCRM") {
        dataTitle = "PDMSCR of " + DataDate.getFullYear();
    } else if (_CostCenter == "SCRA") {
        dataTitle = "PDASCR of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 of" + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3M") {
        dataTitle = "PDMF3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3A") {
        dataTitle = "PDAF3  Assy. of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "ODM of " + DataDate.getFullYear();

    } else if (_CostCenter == "MTALL") {
        dataTitle = "Maintenance of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "MTM") {
        dataTitle = "MAINTENANCE MACHINE of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "MTA") {
        dataTitle = "MAINTENANCE ASSY. of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "PU") {
        dataTitle = "PURCHASING (PU) of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "SPU") {
        dataTitle = "PURCHASING STRATERGY&DEV of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "SP") {
        dataTitle = "PURCHASING of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "IM") {
        dataTitle = "IMPROVEMENT of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "PS") {
        dataTitle = "PART SUPPLY CONTROL of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "DC") {
        dataTitle = "DELIVERY CONTROL of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "PN") {
        dataTitle = "PRODUCTION PLANNING of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "WH") {
        dataTitle = "WAREHOUSE of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "ENA") {
        dataTitle = "ENGINEERING ASSEMBLY of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "ENM") {
        dataTitle = "ENGINEERING MACHINE of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "ENMOT") {
        dataTitle = "ENGINEERING MOTOR of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "IT") {
        dataTitle = "INFORMATION TECHNOLOGY of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "UT") {
        dataTitle = "MAINTENANCE(UT) of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "WC") {
        dataTitle = "OPERATION (WC) of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "QC") {
        dataTitle = "QUALITY CONTROL of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "QA") {
        dataTitle = "QUALITY ASSURANCE of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "QS") {
        dataTitle = "QUALITY SYSTEM AUIT of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "DD") {
        dataTitle = "DESIGN&DEVELOPMENTof " + DataDate.getFullYear();
    }
    else if (_CostCenter == "CD") {
        dataTitle = "CALORIE&DURABILITY of " + DataDate.getFullYear();
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
        dataTitle = "Over All Man Power of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1") {
        dataTitle = "Factory 1 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1M") {
        dataTitle = "PDM1YC of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC1A") {
        dataTitle = "PDA1YC of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2") {
        dataTitle = "Factory 2 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2M") {
        dataTitle = "PDM2YC of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC2A") {
        dataTitle = "PDA2YC of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3") {
        dataTitle = "Factory 3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3M") {
        dataTitle = "PDMF3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "FAC3A") {
        dataTitle = "PDAF3 of " + DataDate.getFullYear();
    } else if (_CostCenter == "ODM") {
        dataTitle = "ODM of " + DataDate.getFullYear();

    } else if (_CostCenter == "MTALL") {
        dataTitle = "Maintenance of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "MTM") {
        dataTitle = "MAINTENANCE MACHINE of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "MTA") {
        dataTitle = "MAINTENANCE ASSY. of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "PU") {
        dataTitle = "PURCHASING (PU) of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "SPU") {
        dataTitle = "PURCHASING STRATERGY&DEV of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "PS") {
        dataTitle = "PURCHASING of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "IM") {
        dataTitle = "IMPROVEMENT of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "DC") {
        dataTitle = "DELIVERY CONTROL of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "PN") {
        dataTitle = "PRODUCTION PLANNING of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "WH") {
        dataTitle = "WAREHOUSE of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "ENA") {
        dataTitle = "PURCHASING STRATERGY&DEV of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "ENM") {
        dataTitle = "PURCHASING of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "ENMOT") {
        dataTitle = "IMPROVEMENT of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "IT") {
        dataTitle = "INFORMATION TECHNOLOGY of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "UT") {
        dataTitle = "MAINTENANCE(UT) of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "WC") {
        dataTitle = "OPERATION (WC) of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "QC") {
        dataTitle = "QUALITY CONTROL of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "QA") {
        dataTitle = "QUALITY ASSURANCE of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "QS") {
        dataTitle = "QUALITY SYSTEM AUIT of " + DataDate.getFullYear();
    }
    else if (_CostCenter == "DD") {
        dataTitle = "DESIGN&DEVELOPMENTof " + DataDate.getFullYear();
    }
    else if (_CostCenter == "CD") {
        dataTitle = "CALORIE&DURABILITY of " + DataDate.getFullYear();
    }


    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
    //$.ajax({
    //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
    //    dataType: 'json',
    //    async: false,
        //success: function (ResponseData) {
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

                AccumCostUnit.push()

                //SumProd.push([ResponseData[i].SumPrd]);
                Prod.push([ResponseData[i].Prd]);
                //Cost.push([ResponseData[i].BudgetCost]);
                //OverlAllSum.push([ResponseData[i].OverAllSum]);

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
                             [0, '#098996'],
                                  [1, '#054C54']
                           //[0, '#FBFBD4'],
                           //       [1, '#C7C6A1']
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
                        stackLabels: {
                            enabled: true,
                            style: {
                                fontWeight: 'bold',
                                color: (Highcharts.theme && Highcharts.theme.textColor) || 'ฺสฟแา'
                            }
                        }


                    }, {
                        className: 'Accum Cost/Unit',
                        title: {
                            text: 'THB/Unit',
                            style: {
                                color: '#F3FF00',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.2f} THB/Unit',
                            style: {
                                color: '#F3FF00',
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
                            text: 'Prod. Unit',
                            style: {
                                color: '#FF0000',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.2f} Unit.',
                            style: {
                                color: '#FF0000',
                                fontSize: '10px'
                            }
                        },
                        stackLabels: {
                            enabled: true,
                            style: {

                                color: '#FF0000'
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
                    //shared: true,
                    //headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    //pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                    //            '<td style="padding:0;"><b>{point.y}</b></td></tr>',
                    //footerFormat: '</table>',
                    //shared: true,
                    //useHTML: true

                    //headerFormat: '<b>{point.x}</b>',
                    pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'

                    //headerFormat: '<b>{point.x}</b>',
                    //pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
                    //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
                    //shared: true
                },
                plotOptions: {
                    column: {
                        stacking: 'normal',
                        dataLabels: {
                            enabled: false,
                            color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Black',
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    }
                },
                series: [{
                    //    name: 'Accum.Cost',
                    //    color: '#FD0000',
                    //    borderColor: '#FD0000',
                    //    type: 'line',
                    //    width: 5,
                    //    data: OverlAllSum,

                    //    tooltip: {
                    //        valuePrefix: '฿',
                    //        valueSuffix: ' BHT'
                    //    },
                    //    pointPadding: 0.3,
                    //    pointPlacement: 0.2,
                    //    yAxis: 1

                    //},{

                    //    name: 'COST',
                    //    color: '#FDF600',
                    //    borderColor: '#FDF600',
                    //    type: 'line',
                    //    width: 2,
                    //    data: Cost,

                    //    tooltip: {
                    //        valuePrefix: '฿',
                    //        valueSuffix: ' BHT'
                    //    },
                    //    pointPadding: 0.3,
                    //    pointPlacement: 0.2,
                    //    yAxis: 1

                    //}, {

                    //     name: 'Accum.Prod',
                    //     color: '#03A03C',
                    //     borderColor: '#03A03C',
                    //     type: 'line',
                    //     width: 10,
                    //     data: SumProd,

                    //     tooltip: {
                    //         // valuePrefix: '฿',
                    //         valueSuffix: ' Unit'
                    //     },
                    //     pointPadding: 0.3,
                    //     pointPlacement: 0.2,
                    //     yAxis: 2



                    name: 'Prod.Unit',
                    color: '#FF0000',
                    borderColor: '#FF0000',
                    type: 'line',
                    width: 10,
                    data: Prod,

                    tooltip: {
                        // valuePrefix: '฿',
                        valueSuffix: ' Unit'
                    },
                    pointPadding: 0.3,
                    pointPlacement: 0.2,
                    yAxis: 2

                }, {

                    name: 'Accum.CostUnit',
                    color: '#F3FF00',
                    borderColor: '#F3FF00',
                    type: 'line',
                    width: 10,
                    data: AccumCostUnit,

                    tooltip: {
                        valuePrefix: '฿',
                        pointformat: '{point.y:,0.2f}',
                        valueSuffix: 'BHT/Unit'
                    },
                    pointPadding: 0.3,
                    pointPlacement: 0.2,
                    yAxis: 1

                    //},  {

                    //name: 'CostUnit',
                    //color: '#F3FF00',
                    //borderColor: '#F3FF00',
                    //type: 'line',
                    //width: 10,
                    //data: CostUnit,

                    //tooltip: {
                    //    valuePrefix: '฿',
                    //    pointformat: '{point.y:,0.2f}',
                    //    valueSuffix: 'BHT/Unit'
                    //},
                    //pointPadding: 0.3,
                    //pointPlacement: 0.2,
                    //yAxis: 2

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
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });
    // }
    //});



}

function loadChartOvelAllCH(_objChart, _CostCenter, _DataSDate, _DataEDate) {

    // var DataMonth = new Month(_DataMonth);
    var DataDate = new Date(_DataSDate);

 
    var dataTitle = "";

  //  var OVDate = new Date(_DataDate);
    var json_FGHold = new Array();
    var json_LineOut = new Array();
    var json_ReqUnhold = new Array();
    var json_Unhold = new Array();
    var DataaTitle = "";




    if (_CostCenter == "ALL") {
        dataTitle = "Over All Man Power of " + DataDate.getFullYear();
    } 


    $.getJSON("AllTempOven.ashx?cc=" + _CostCenter + "&SDate=" + _DataSDate + "&EDate=" + _DataEDate, function (ResponseData) {
  
            var DateStr = new Array();
     
            var Temp = new Array();
            var CH = new Array();
            var IDCH = new Array();
        
            var Max = new Array();
            var STPoint = new Array();
            var Min = new Array();

         

            for (var i = 0; i < ResponseData.length; i++) {

                DateStr[i] = ResponseData[i].Date;
                CH.push([ResponseData[i].CH]);
                Max.push([ResponseData[i].Max]);
                Min.push([ResponseData[i].Min]);
                STPoint.push([ResponseData[i].STPoint]);
                IDCH = _CostCenter
             
              


            }

        //------------------------- Chart summary direct -----------------------------       
            Highcharts.setOptions({
                global: {
                    useUTC: false
                }
            });
            Highcharts.chart(_objChart, {

                chart: {
                    zoomType: 'xy',
                     type: 'spline',
                    backgroundColor: {
                        linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        stops: [
                            // [0, '#098996'],
                              //    [1, '#054C54']
                                [0, '#FBFBD4'],
                             [1, '#C7C6A1']
                                //   [0, '#02FC61'],
                             //  [1, '#1AD005']
                               
                        ]
                    },
                    style: {
                        fontFamily: '\'Unica One\', sans-serif'
                    },
                    plotBorderColor: '#0A0A0A'
                } ,
                title: {
                    text: 'TEMPERATURE OF OVEN:' + _CostCenter 
                },
                xAxis: {
                    //type: 'datetime',
                    categories: DateStr,
                    labels: {
                        overflow: 'justify'
                    },
                  
                },
                yAxis: {
                    title: {
                        text: 'Temperature(C)'
                    },
                    min: 120,
                    max: 160,
                    tickInterval: 10,
                    minorGridLineWidth: 0,
                    gridLineWidth: 0,
                    alternateGridColor: null,
                    plotBands: [{ //Low Temp
                        from: 129,
                        to: 130,
                        color: '#A5A305',
                        label: {
                            text: ' Low Temp.[<130 C]',
                            style: {
                                color: '#606060'
                            }
                        },
                    },
                    { // High Temp
                        from: 150,
                        to: 151,
                        color: '#FFFB04',
                        label: {
                            text: 'High Temp.[>150 C]',
                            style: {
                                color: '#606060'
                            }
                        },
                    },
                     { // ST Point
                         from: 130,
                         to: 150,
                         color: 'rgba(68, 170, 213, 0.1)',
                         label: {
                             text: 'Set Point Temp.[140 C]',
                             style: {
                                 color: '#606060'
                             }
                         }
                    } ]
                },
        
                legend: {
                    enabled: false
                },
                plotOptions: {
                    area: {
                        fillColor: {
                            linearGradient: {
                                x1: 0,
                                y1: 0,
                                x2: 0,
                                y2: 1
                            },
                            stops: [
                              [0, Highcharts.getOptions().colors[0]],
                              [1, Highcharts.Color(Highcharts.getOptions().colors[0]).setOpacity(0).get('rgba')]
                            ]
                        },
                      
                        threshold: null
                    },
                    marker: {
                        radius: 2,
                        enabled: false
                    },
                    lineWidth: 0.5,
                    states: {
                        hover: {
                            lineWidth: 1
                        }
                    },
                        
                },


                // plotOptions: {
                //     series: {
                //             label: {
                //                 connectorAllowed: false
                //             }
                //     }
                // },
                tooltip: {
                    shared: true,
                    useHTML: true,
                    headerFormat: '<p style="font-weight:bold">{point.key}</p><table>',
                    pointFormat: '<tr><td style="color: {series.color}; font-weight:bold">{series.name}: </td><td style="text-align: right"><b> {point.y}C</b></td></tr>',
                    footerFormat: '</table>',
                    valueDecimals: 2
                },
              

                series: [{
                    name: IDCH,
                    color: '#E40202',
                    data: CH,
                    type: 'spline',
                    lineWidth: 5,
                    dataLabels: {
                        enabled: false,
                        color: '#ffffff'

                    },
                }]
            
            });
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });
    // }
    //});

}

function loadChartOvelAllRealTime(_objChart, _CostCenter, _DataSDate, _DataEDate) {

    // var DataMonth = new Month(_DataMonth);
    var DataDate = new Date(_DataSDate);

    var CH1 = new Array();
    var CH2 = new Array();
    var CH3 = new Array();


    if (_CostCenter == "ALL") {
        dataTitle = "Over All Man Power of " + DataDate.getFullYear();
    } 


    $.getJSON("AllTempOven.ashx?cc=" + _CostCenter + "&SDate=" + _DataSDate + "&EDate=" + _DataEDate, function (ResponseData) {
        
        var DateStr = new Array();
       
        var CH2 = new Array();
      
        var Temp = new Array();
        var CH = new Array();
        var IDCH = new Array();
     
        for (var i = 0; i < ResponseData.length; i++) {

            DateStr[i] = ResponseData[i].Date;
       

            CH.push([ResponseData[i].CH]);
            IDCH = _CostCenter
            CH2.push([ResponseData[i].CH2]);
         
        }

        //------------------------- Chart summary direct -----------------------------       
        Highcharts.setOptions({
            global: {
                useUTC: false
            }
        });

        Highcharts.chart(_objChart, {
            chart: {
                type: 'spline',
                animation: Highcharts.svg, // don't animate in old IE
                marginRight: 10,
                events: {
                    load: function () {

                        // set up the updating of the chart each second
                        var series = this.series[0];
                        setInterval(function () {
                            var x = (new Date()).getTime(), // current time
                              y = Math.random();
                            series.addPoint([x, y], true, true);
                        }, 1000);
                    }
                }
            },
            title: {
                text: 'Live random data'
            },
            xAxis: {
                type: 'datetime',
                tickPixelInterval: 150
            },
            yAxis: {
                title: {
                    text: 'Value'
                },
                plotLines: [{
                    value: 0,
                    width: 1,
                    color: '#808080'
                }]
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.series.name + '</b><br/>' +
                      Highcharts.dateFormat('%Y-%m-%d %H:%M:%S', this.x) + '<br/>' +
                      Highcharts.numberFormat(this.y, 2);
                }
            },
            legend: {
                enabled: false
            },
            exporting: {
                enabled: false
            },
            series: [{
                name: 'Random data',
                data: (function () {
                    // generate an array of random data
                    var data = [],
                      time = (new Date()).getTime(),
                      i;

                    for (i = -19; i <= 0; i += 1) {
                        data.push({
                            x: time + i * 1000,
                            y: CH
                        });
                    }
                    return data;
                }())
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




