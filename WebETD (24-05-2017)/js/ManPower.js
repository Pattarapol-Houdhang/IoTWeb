function LoadJavaScript() {
    var CurDate = new Date();

    var date = new Date(CurDate.getFullYear(), CurDate.getMonth() + 1, CurDate.getDay());
    var month = new Date(CurDate.getFullYear(), CurDate.getMonth() + 1, CurDate.getDay());

    var date1 = new Date(CurDate.getFullYear(), CurDate.getMonth() - 1, CurDate.getDay(), 8, 0, 0);
    var month1 = new Date(CurDate.getFullYear(), CurDate.getMonth() - 1, CurDate.getDay(), 8, 0, 0);

    var date3 = new Date(CurDate.getFullYear(), CurDate.getMonth() - 3, CurDate.getDay(), 8, 0, 0);
    var month3 = new Date(CurDate.getFullYear(), CurDate.getMonth() - 3, CurDate.getDay(), 8, 0, 0);

    var date2 = new Date(CurDate.getFullYear(), CurDate.getMonth() - 2, CurDate.getDay(), 8, 0, 0);
    var month2 = new Date(CurDate.getFullYear(), CurDate.getMonth() - 2, CurDate.getDay(), 8, 0, 0);

    var _YearPresent = new Date(CurDate.getFullYear(), CurDate.getMonth(), CurDate.getDay());
    var _YearPrev = new Date(CurDate.getFullYear() - 1, CurDate.getMonth(), CurDate.getDay());
    var _YearPrev2 = new Date(CurDate.getFullYear() - 2, CurDate.getMonth(), CurDate.getDay());
    var _YearPrev3 = new Date(CurDate.getFullYear() - 3, CurDate.getMonth(), CurDate.getDay());




    $("#gpDIRECTALL").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacDayDIRECTALL('gpDIRECTALL', 'DIRECTALL', formatDate(date), formatDate(month));

    $("#gpDIRECTALL").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacDayDIRECTALL('gpDIRECTALL', 'DIRECTALL', formatDate(date), formatDate(month));

    $("#gpOTDIRECTALL").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTALL('gpOTDIRECTALL', 'OTDIRECTALL', formatDate(date), formatDate(month));

    $("#gpINDIRECTALL").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacDayINDirectALL('gpINDIRECTALL', 'INDIRECTALL', formatDate(date), formatDate(month));

    $("#gpOTINDIRECTALL").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTALL('gpOTINDIRECTALL', 'OTINDIRECTALL', formatDate(date), formatDate(month));

    $("#gpMPSGA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacDayMPSGA('gpMPSGA', 'MPSGA', formatDate(date), formatDate(month));

    $("#gpOTMPSGA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTALL('gpOTMPSGA', 'OTMPSGA', formatDate(date), formatDate(month));

    $("#gpMPALL").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacDayALL('gpMPALL', 'MPALL', formatDate(date), formatDate(month));

    $("#gpOTALL").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTALL('gpOTALL', 'OTALL', formatDate(date), formatDate(month));


    //////------------------------------------------------------
    //////                           DIRECT Factory1
    //////------------------------------------------------------
    $("#gpMPFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3DrillDown('gpMPFAC1', 'MPFAC1', formatDate(date), formatDate(month));

    $("#gpOTFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC1', 'OTFAC1', formatDate(date), formatDate(month));

    $("#gpMPFAC1Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac1Day('gpMPFAC1Prev', 'MPFAC1Prev', formatDate(_YearPrev), formatDate(month1));

    $("#gpOTFAC1Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC1Prev', 'OTFAC1Prev', formatDate(_YearPrev), formatDate(month1));


    $("#gpMPFAC1Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac1Day('gpMPFAC1Prev2', 'MPFAC1Prev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpOTFAC1Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC1Prev2', 'OTFAC1Prev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpMPFAC1Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac1Day('gpMPFAC1Prev3', 'MPFAC1Prev3', formatDate(_YearPrev3), formatDate(month3));

    $("#gpOTFAC1Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC1Prev3', 'OTFAC1Prev3', formatDate(_YearPrev3), formatDate(month3));


    //////////------------------------------------------------------
    //////////                           DIRECT Factory2
    //////////------------------------------------------------------


    $("#gpMPFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3DrillDown('gpMPFAC2', 'MPFAC2', formatDate(date), formatDate(month));

    $("#gpOTFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC2', 'OTFAC2', formatDate(date), formatDate(month));

    $("#gpMPFAC2Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac2Day('gpMPFAC2Prev', 'MPFAC2Prev', formatDate(_YearPrev), formatDate(month1));

    $("#gpOTFAC2Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC2Prev', 'OTFAC2Prev', formatDate(_YearPrev), formatDate(month1));

    $("#gpMPFAC2Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac2Day('gpMPFAC2Prev2', 'MPFAC2Prev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpOTFAC2Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC2Prev2', 'OTFAC2Prev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpMPFAC2Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac2Day('gpMPFAC2Prev3', 'MPFAC2Prev3', formatDate(_YearPrev3), formatDate(month3));

    $("#gpOTFAC2Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC2Prev3', 'OTFAC2Prev3', formatDate(_YearPrev3), formatDate(month3));



    ////////------------------------------------------------------
    ////////                           DIRECT Factory3
    ////////------------------------------------------------------

    $("#gpMPFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3DrillDown('gpMPFAC3', 'MPFAC3', formatDate(date), formatDate(month));

    $("#gpMPFAC3Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3DrillDown('gpMPFAC3Prev', 'MPFAC3Prev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3DrillDown('gpMPFAC3Prev2', 'MPFAC3Prev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3DrillDown('gpMPFAC3Prev3', 'MPFAC3Prev3', formatDate(date), formatDate(month3));


//// *** LE, FO
//    $("#gpMPFAC3LDFO").html("<img src='../images/loading/gears.gif' border='0' />");
//    loadChartMPFac3Direct('gpMPFAC3LDFO', 'MPFAC3', formatDate(date), formatDate(month));



    ////$("#gpOTFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    ////loadChartMPFacOT('gpOTFAC3', 'OTFAC3', formatDate(date), formatDate(month));

    $("#gpMPFAC3CY").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CY', 'MPFAC3CY', formatDate(date), formatDate(month));

    $("#gpMPFAC3CYPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CYPrev', 'MPFAC3CYPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3CYPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CYPrev2', 'MPFAC3CYPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3CYPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CYPrev3', 'MPFAC3CYPrev3', formatDate(date), formatDate(month3));
    

    $("#gpMPFAC3CS").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CS', 'MPFAC3CS', formatDate(date), formatDate(month));

    $("#gpMPFAC3CSPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CSPrev', 'MPFAC3CSPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3CSPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CSPrev2', 'MPFAC3CSPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3CSPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CSPrev3', 'MPFAC3CSPrev3', formatDate(date), formatDate(month3));


    $("#gpMPFAC3CP").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CP', 'MPFAC3CP', formatDate(date), formatDate(month));

    $("#gpMPFAC3CPPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CPPrev', 'MPFAC3CPPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3CPPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CPPrev2', 'MPFAC3CPPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3CPPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3CPPrev3', 'MPFAC3CPPrev3', formatDate(date), formatDate(month3));


    $("#gpMPFAC3FH").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3FH', 'MPFAC3FH', formatDate(date), formatDate(month));

    $("#gpMPFAC3FHPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3FHPrev', 'MPFAC3FHPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3FHPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3FHPrev2', 'MPFAC3FHPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3FHPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3FHPrev3', 'MPFAC3FHPrev3', formatDate(date), formatDate(month3));



    $("#gpMPFAC3RH").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3RH', 'MPFAC3RH', formatDate(date), formatDate(month));

    $("#gpMPFAC3RHPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3RHPrev', 'MPFAC3RHPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3RHPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3RHPrev2', 'MPFAC3RHPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3RHPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3RHPrev3', 'MPFAC3RHPrev3', formatDate(date), formatDate(month3));



    $("#gpMPFAC3PI").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3PI', 'MPFAC3PI', formatDate(date), formatDate(month));

    $("#gpMPFAC3PIPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3PIPrev', 'MPFAC3PIPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3PIPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3PIPrev2', 'MPFAC3PIPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3PIPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3PIPrev3', 'MPFAC3PIPrev3', formatDate(date), formatDate(month3));


    $("#gpMPFAC3MOT").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MOT', 'MPFAC3MOT', formatDate(date), formatDate(month));

    $("#gpMPFAC3MOTPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MOTPrev', 'MPFAC3MOTPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3MOTPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MOTPrev2', 'MPFAC3MOTPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3MOTPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MOTPrev3', 'MPFAC3MOTPrev3', formatDate(date), formatDate(month3));


    $("#gpMPFAC3MA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MA', 'MPFAC3MA', formatDate(date), formatDate(month));

    $("#gpMPFAC3MAPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MAPrev', 'MPFAC3MAPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3MAPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MAPrev2', 'MPFAC3MAPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3MAPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3MAPrev3', 'MPFAC3MAPrev3', formatDate(date), formatDate(month3));

    $("#gpMPFAC3AS").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3AS', 'MPFAC3AS', formatDate(date), formatDate(month));

    $("#gpMPFAC3ASPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3ASPrev', 'MPFAC3ASPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3ASPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3ASPrev2', 'MPFAC3ASPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3ASPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3ASPrev3', 'MPFAC3ASPrev3', formatDate(date), formatDate(month3));

    $("#gpMPFAC3FIN").html("<img src='../images/loading/gears.gif' border='0' />");
        loadChartMPFac3Andon('gpMPFAC3FIN', 'MPFAC3FIN', formatDate(date), formatDate(month));

    $("#gpMPFAC3FINPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3FINPrev', 'MPFAC3FINPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3FINPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3FINPrev2', 'MPFAC3FINPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3FINPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Andon('gpMPFAC3FINPrev3', 'MPFAC3FINPrev3', formatDate(date), formatDate(month3));


    $("#gpMPFAC3OTH").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Other('gpMPFAC3OTH', 'MPFAC3OTH', formatDate(date), formatDate(month));

    $("#gpMPFAC3OTHPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Other('gpMPFAC3OTHPrev', 'MPFAC3OTHPrev', formatDate(date), formatDate(month1));

    $("#gpMPFAC3OTHPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Other('gpMPFAC3OTHPrev2', 'MPFAC3OTHPrev2', formatDate(date), formatDate(month2));

    $("#gpMPFAC3OTHPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Other('gpMPFAC3OTHPrev3', 'MPFAC3OTHPrev3', formatDate(date), formatDate(month3));

    //$("#gpMPFAC3M").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFac3Day('gpMPFAC3M', 'MPFAC3M', formatDate(date), formatDate(month));

    //$("#gpOTFAC3M").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTFAC3M', 'OTFAC3M', formatDate(date), formatDate(month));

    //$("#gpMPFAC3A").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFac3Day('gpMPFAC3A', 'MPFAC3A', formatDate(date), formatDate(month));

    //$("#gpOTFAC3A").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTFAC3A', 'OTFAC3A', formatDate(date), formatDate(month));

    //$("#gpMPFAC3Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFac3Day('gpMPFAC3Prev', 'MPFAC3Prev', formatDate(_YearPrev), formatDate(month1));

    //$("#gpOTFAC3Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTFAC3Prev', 'OTFAC3Prev', formatDate(_YearPrev), formatDate(month1));

    //$("#gpMPFAC3Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFac3Day('gpMPFAC3Prev2', 'MPFAC3Prev2', formatDate(_YearPrev2), formatDate(month2));

    //$("#gpOTFAC3Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTFAC3Prev2', 'OTFAC3Prev2', formatDate(_YearPrev2), formatDate(month2));

    //$("#gpMPFAC3Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFac3Day('gpMPFAC3Prev3', 'MPFAC3Prev3', formatDate(_YearPrev3), formatDate(month3));

    //$("#gpOTFAC3Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTFAC3Prev3', 'OTFAC3Prev3', formatDate(_YearPrev3), formatDate(month3));


    ////////////------------------------------------------------------
    ////////////                           DIRECT ODM
    ////////////------------------------------------------------------
    //$("#gpMPODM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPODMDay('gpMPODM', 'MPODM', formatDate(date), formatDate(month));

    //$("#gpOTODM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTODM', 'OTODM', formatDate(date), formatDate(month));

    //$("#gpMPODMPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPODMDay('gpMPODMPrev', 'MPODMPrev', formatDate(_YearPrev), formatDate(month1));

    //$("#gpOTODMPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTODMPrev', 'OTODMPrev', formatDate(_YearPrev), formatDate(month1));

    //$("#gpMPODMPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPODMDay('gpMPODMPrev2', 'MPODMPrev2', formatDate(_YearPrev2), formatDate(month2));

    //$("#gpOTODMPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTODMPrev2', 'OTODMPrev2', formatDate(_YearPrev2), formatDate(month2));

    //$("#gpMPODMPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPODMDay('gpMPODMPrev3', 'MPODMPrev3', formatDate(_YearPrev3), formatDate(month3));

    //$("#gpOTODMPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOT('gpOTODMPrev3', 'OTODMPrev3', formatDate(_YearPrev3), formatDate(month3));


    //////////////------------------------------------------------------
    //////////////                           DIRECT MPPS
    //////////////------------------------------------------------------
    $("#gpMPPS").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPPS', 'MPPS', formatDate(date), formatDate(month));

    $("#gpOTMPPS").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPPS', 'OTMPPS', formatDate(date), formatDate(month));

    $("#gpMPPSPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPPSPrev', 'MPPSPrev', formatDate(_YearPrev), formatDate(month1));

    $("#gpOTMPPSPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPPSPrev', 'OTMPPSPrev', formatDate(_YearPrev), formatDate(month1));

    $("#gpMPPSPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPPSPrev2', 'MPPSPrev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpOTMPPSPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPPSPrev2', 'OTMPPSPrev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpMPPSPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPPSPrev3', 'MPPSPrev3', formatDate(_YearPrev3), formatDate(month3));

    $("#gpOTMPPSPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPPSPrev3', 'OTMPPSPrev3', formatDate(_YearPrev3), formatDate(month3));


    $("#gpMPQA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPQA', 'MPQA', formatDate(date), formatDate(month));

    $("#gpOTMPQA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPQA', 'OTMPQA', formatDate(date), formatDate(month));

    $("#gpMPQAPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPQAPrev', 'MPQAPrev', formatDate(_YearPrev), formatDate(month1));

    $("#gpOTMPQAPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPQAPrev', 'OTMPQAPrev', formatDate(_YearPrev), formatDate(month1));

    $("#gpMPQAPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPQAPrev2', 'MPQAPrev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpOTMPQAPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPQAPrev2', 'OTMPQAPrev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpMPQAPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPDirectSupport('gpMPQAPrev3', 'MPQAPrev3', formatDate(_YearPrev3), formatDate(month3));

    $("#gpOTMPQAPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTMPQAPrev3', 'OTMPQAPrev3', formatDate(_YearPrev3), formatDate(month3));






    ////////------------------------------------------------------
    ////////                           INDIRECT Management
    ////////------------------------------------------------------
    //$("#gpINMAN").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINMAN', 'INMAN', formatDate(date), formatDate(month));

    //$("#gpINIE").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINIE', 'INIE', formatDate(date), formatDate(month));

    //$("#gpOTINMAN").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOTINDIRECT('gpOTINMAN', 'OTINMAN', formatDate(date), formatDate(month));



    //////////////------------------------------------------------------
    //////////////                           INDIRECT Factory1
    //////////////------------------------------------------------------
    //$("#gpINFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINFAC1', 'INFAC1', formatDate(date), formatDate(month));

    //$("#gpOTINFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOTINDIRECT('gpOTINFAC1', 'OTINFAC1', formatDate(date), formatDate(month));





    ////////////------------------------------------------------------
    ////////////                           INDIRECT Factory2
    ////////////------------------------------------------------------
    //$("#gpINFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINFAC2', 'INFAC2', formatDate(date), formatDate(month));

    //$("#gpOTINFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOTINDIRECT('gpOTINFAC2', 'OTINFAC2', formatDate(date), formatDate(month));


    ////////////------------------------------------------------------
    ////////////                           INDIRECT Factory3
    ////////////------------------------------------------------------
    //$("#gpINFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINFAC3', 'INFAC3', formatDate(date), formatDate(month));

    //$("#gpOTINFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOTINDIRECT('gpOTINFAC3', 'OTINFAC3', formatDate(date), formatDate(month));



    //////////------------------------------------------------------
    //////////                           INDIRECT ODM
    //////////------------------------------------------------------
    //$("#gpINODM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINODM', 'INODM', formatDate(date), formatDate(month));

    //$("#gpOTINODM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOTINDIRECT('gpOTINODM', 'OTINODM', formatDate(date), formatDate(month));


    ////////////----------------------------------------------------------------------------
    ////////////                          INDIRECT PROCUREMENT 
    ////////////----------------------------------------------------------------------------

    //$("#gpINPU").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINPU', 'INPU', formatDate(date), formatDate(month));

    //$("#gpINSPU").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINSPU', 'INSPU', formatDate(date), formatDate(month));

    //$("#gpINPC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINPC', 'INPC', formatDate(date), formatDate(month));

    //$("#gpINSP").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINSP', 'INSP', formatDate(date), formatDate(month));




    //////////----------------------------------------------------------------------------
    //////////                      INDIRECT Production Control and SCM IM PN PS DS SP
    //////////----------------------------------------------------------------------------

    //$("#gpINIM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINIM', 'INIM', formatDate(date), formatDate(month));

    //$("#gpINPS").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINPS', 'INPS', formatDate(date), formatDate(month));


    //////////----------------------------------------------------------------------------
    //////////                     INDIRECT ENGINEER
    //////////----------------------------------------------------------------------------

    //$("#gpINENA").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINENA', 'INENA', formatDate(date1), formatDate(month));


    //$("#gpINENM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINENM', 'INENM', formatDate(date1), formatDate(month));


    //$("#gpINENMOT").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINENMOT', 'INENMOT', formatDate(date1), formatDate(month));


    ////////////----------------------------------------------------------------------------
    ////////////                    INDIRECT IT&EC
    ////////////----------------------------------------------------------------------------

    ////$("#gpINIT").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINIT', 'INIT', formatDate(date), formatDate(month));

    //$("#gpINUT").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINUT', 'INUT', formatDate(date), formatDate(month));

    //$("#gpINEC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINEC', 'INEC', formatDate(date), formatDate(month));

    ////////////----------------------------------------------------------------------------
    ////////////                 INDIRECT QUALITY CONTROL
    ////////////----------------------------------------------------------------------------

    //$("#gpINQC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINQC', 'INQC', formatDate(date), formatDate(month));

    //$("#gpINQA").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINQA', 'INQA', formatDate(date), formatDate(month));

    //$("#gpINQS").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINQS', 'INQS', formatDate(date), formatDate(month));


    ////////////----------------------------------------------------------------------------
    ////////////                   INDIRECT Design and Development
    ////////////----------------------------------------------------------------------------

    //$("#gpINDD").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINDD', 'INDD', formatDate(date), formatDate(month));

    //$("#gpINCD").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINCD', 'INCD', formatDate(date), formatDate(month));




    ////////////----------------------------------------------------------------------------
    ////////////                  INDIRECT MAINTENANCE
    ////////////----------------------------------------------------------------------------


    //$("#gpINMTM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINMTM', 'INMTM', formatDate(date), formatDate(month));

    //$("#gpINMTA").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINMTA', 'INMTA', formatDate(date), formatDate(month));

    //$("#gpINMTTPM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINMTTPM', 'INMTTPM', formatDate(date), formatDate(month));

    //$("#gpINMTPM").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINMTPM', 'INMTPM', formatDate(date), formatDate(month));



    ////////////-------------------------------END OF  INDIRECT ---------------------------------------



    ////////////---------------------------------------------------------------------------------
    ////////////                                  S.G.A SUPPORT 
    ////////////--------------------------------------------------------------------------------- 


    //$("#gpINDC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINDC', 'INDC', formatDate(date), formatDate(month));

    //$("#gpINPN").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINPN', 'INPN', formatDate(date), formatDate(month));

    //$("#gpINWH").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINWH', 'INWH', formatDate(date), formatDate(month));

    //$("#gpINHR").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINHR', 'INHR', formatDate(date), formatDate(month));

    //$("#gpINAC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINAC', 'INAC', formatDate(date), formatDate(month));

    //$("#gpINCC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINCC', 'INCC', formatDate(date), formatDate(month));

    //$("#gpINGA").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINGA', 'INGA', formatDate(date), formatDate(month));

    //$("#gpINCB").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINCB', 'INCB', formatDate(date), formatDate(month));

    //$("#gpINTS").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINTS', 'INTS', formatDate(date), formatDate(month));

    //$("#gpINAUDIT").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINAUDIT', 'INAUDIT', formatDate(date), formatDate(month));

    //$("#gpINHRD").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINHRD', 'INHRD', formatDate(date), formatDate(month));

    //$("#gpINSF").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINSF', 'INSF', formatDate(date), formatDate(month));

    //$("#gpINLG").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINLG', 'INLG', formatDate(date), formatDate(month));

    //$("#gpINDCC").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINDCC', 'INDCC', formatDate(date), formatDate(month));

    //$("#gpINTD").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPINDirectSupport('gpINTD', 'INTD', formatDate(date), formatDate(month));

    //$("#gpOTINTD").html("<img src='../images/loading/gears.gif' border='0' />");
    //loadChartMPFacOTINDIRECT('gpOTINTD', 'OTINTD', formatDate(date), formatDate(month));




    $(".btnShowHideAll").click(function () {
        if ($($(this).data("graphall")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphall")).slideDown();
        } else {
            $(this).text("(+) Show Graph All");
            $($(this).data("graphall")).slideUp();
        }
    });

    $(".btnShowHideDirectAll").click(function () {
        if ($($(this).data("graphdirectall")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphdirectall")).slideDown();
        } else {
            $(this).text("(+) Show Graph Direct All");
            $($(this).data("graphdirectall")).slideUp();
        }
    });

    $(".btnShowHideInDirectAll").click(function () {
        if ($($(this).data("graphindirectall")).is(":hidden")) {
            $(this).text("(-) Hide Graph");
            $($(this).data("graphindirectall")).slideDown();
        } else {
            $(this).text("(+) Show Graph Direct All");
            $($(this).data("graphindirectall")).slideUp();
        }
    });
    $(".btnShowHideSGA").click(function () {
        if ($($(this).data("graphsga")).is(":hidden")) {
            $(this).text("(-) Hide Graph SGA");
            $($(this).data("graphsga")).slideDown();
        } else {
            $(this).text("(+) Show Graph SGA");
            $($(this).data("graphsga")).slideUp();
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
    $(".btnShowHideFac3Machine").click(function () {

        if ($($(this).data("graphfac3machine")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphfac3machine")).slideDown();
        } else {
            $(this).text("(+) Machine ");
            $($(this).data("graphfac3machine")).slideUp();
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

    $(".btnShowHidePS").click(function () {

        if ($($(this).data("graphps")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphps")).slideDown();
        } else {
            $(this).text("(+) Show Graph PS");
            $($(this).data("graphps")).slideUp();
        }
    });

    $(".btnShowHideQA").click(function () {

        if ($($(this).data("graphqa")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphqa")).slideDown();
        } else {
            $(this).text("(+) Show Graph QA");
            $($(this).data("graphqa")).slideUp();
        }
    });
    $(".btnShowHideQC").click(function () {

        if ($($(this).data("graphqc")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphqc")).slideDown();
        } else {
            $(this).text("(+) Show Graph QC");
            $($(this).data("graphqc")).slideUp();
        }
    });

    $(".btnShowHideECUT").click(function () {

        if ($($(this).data("graphecut")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphecut")).slideDown();
        } else {
            $(this).text("(+) Show Graph EC");
            $($(this).data("graphecut")).slideUp();
        }
    });


    $(".btnShowHideInFac").click(function () {

        if ($($(this).data("graphinfac")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphinfac")).slideDown();
        } else {
            $(this).text("(+) Show by Factory");
            $($(this).data("graphinfac")).slideUp();
        }
    });
    $(".btnShowHideInFac1").click(function () {

        if ($($(this).data("graphinfac1")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphinfac1")).slideDown();
        } else {
            $(this).text("(+) Factory 1");
            $($(this).data("graphinfac1")).slideUp();
        }
    });

    $(".btnShowHideInFac2").click(function () {

        if ($($(this).data("graphinfac2")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphinfac2")).slideDown();
        } else {
            $(this).text("(+) Factory 2");
            $($(this).data("graphinfac2")).slideUp();
        }
    });

    $(".btnShowHideInFac3").click(function () {

        if ($($(this).data("graphinfac3")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphinfac3")).slideDown();
        } else {
            $(this).text("(+) Factory 3");
            $($(this).data("graphinfac3")).slideUp();
        }
    });

    $(".btnShowHideInODM").click(function () {

        if ($($(this).data("graphinodm")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphinodm")).slideDown();
        } else {
            $(this).text("(+) Show Graph ODM");
            $($(this).data("graphinodm")).slideUp();
        }
    });

    $(".btnShowHideInQC").click(function () {

        if ($($(this).data("graphinqc")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphinqc")).slideDown();
        } else {
            $(this).text("(+) Show Graph QC");
            $($(this).data("graphinqc")).slideUp();
        }
    });

    $(".btnShowHideInECUT").click(function () {

        if ($($(this).data("graphinecut")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("graphinecut")).slideDown();
        } else {
            $(this).text("(+) Show Graph EC");
            $($(this).data("graphinecut")).slideUp();
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

    $(".btnShowHidetinprocurement").click(function () {

        if ($($(this).data("tinprocurement")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinprocurement")).slideDown();
        } else {
            $(this).text("(+) Show Graph Procurement");
            $($(this).data("tinprocurement")).slideUp();
        }
    });
    $(".btnShowHidetinpdscm").click(function () {

        if ($($(this).data("tinpdscm")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinpdscm")).slideDown();
        } else {
            $(this).text("(+) Show Graph Prod&SCM");
            $($(this).data("tinpdscm")).slideUp();
        }
    });

    $(".btnShowHidetinengineer").click(function () {

        if ($($(this).data("tinengineer")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinengineer")).slideDown();
        } else {
            $(this).text("(+) Show Graph Engineer");
            $($(this).data("tinengineer")).slideUp();
        }
    });
    $(".btnShowHidetinmaintenance").click(function () {

        if ($($(this).data("tinmaintenance")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinmaintenance")).slideDown();
        } else {
            $(this).text("(+) Show Graph Maintenance");
            $($(this).data("tinmaintenance")).slideUp();
        }
    });
    $(".btnShowHidetinecut").click(function () {

        if ($($(this).data("tinecut")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinecut")).slideDown();
        } else {
            $(this).text("(+) Show Graph IT&EC");
            $($(this).data("tinecut")).slideUp();
        }
    });
    $(".btnShowHidetinqc").click(function () {

        if ($($(this).data("tinqc")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinqc")).slideDown();
        } else {
            $(this).text("(+) Show Graph QC");
            $($(this).data("tinqc")).slideUp();
        }
    });
    $(".btnShowHidetindesign").click(function () {

        if ($($(this).data("tinqc")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinqc")).slideDown();
        } else {
            $(this).text("(+) Show Graph Design&Development");
            $($(this).data("tinqc")).slideUp();
        }
    });

    $(".btnShowHidetinMN").click(function () {

        if ($($(this).data("tinmn")).is(":hidden")) {
            $(this).text("(-) Hide Graph");

            $($(this).data("tinmn")).slideDown();
        } else {
            $(this).text("(+) Show Graph Maintenance");
            $($(this).data("tinmn")).slideUp();
        }
    });





}

function loadChartData(_objChart, _CostCenter, _DataDate, _DataMonth) {
    // var DataMonth = new Month(_DataMonth);

    var CostUnit = new Array();
    var AccumCostUnit = new Array();
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



            CostUnit.push([ResponseData[i].CostUnit]);
            AccumCostUnit.push([ResponseData[i].AccumCostUnit]);

            AccumCostUnit.push()
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
                    className: 'Cost/Unit',
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
                    min: 0
                    // showFirstLabel: false

                },
                {

                    className: 'highcharts-color-1',
                    title: {
                        text: 'Prod.Unit',
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
                    min: 0
                    // showFirstLabel: false

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
                pointFormat: '{series.name}: <b>{point.y}</b>'
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
            series: [
            //    {
            //    name: 'Prod.Unit',
            //    color: '#FF0000',
            //    borderColor: '#FF0000',
            //    type: 'line',
            //    width: 10,
            //    data: Prod,

            //    tooltip: {
            //        // valuePrefix: '฿',
            //        valueSuffix: ' Unit'
            //    },
            //    pointPadding: 0.3,
            //    pointPlacement: 0.2,
            //    yAxis: 2

            //}, {

            //    name: 'Accum.CostUnit',
            //    color: '#F3FF00',
            //    borderColor: '#F3FF00',
            //    type: 'line',
            //    width: 10,
            //    data: AccumCostUnit,

            //    tooltip: {
            //        valuePrefix: '฿',
            //        pointformat: '{point.y:,0.2f}',
            //        valueSuffix: 'BHT/Unit'
            //    },
            //    pointPadding: 0.3,
            //    pointPlacement: 0.2,
            //    yAxis: 1
            //},
            //{
            //    name: 'Sum',
            //    color: '#FD0000',
            //    borderColor: '#FD0000',
            //    type: 'line',
            //    width: 5,
            //    data: OverlAllSum,

            //    tooltip: {
            //        valuePrefix: '$',
            //        valueSuffix: ' BHT'
            //    },
            //    pointPadding: 0.3,
            //    pointPlacement: 0.2,
            //    yAxis: 1

            //}, {

            //    name: 'COST',
            //    color: '#FDF600',
            //    borderColor: '#FDF600',
            //    type: 'line',
            //    width: 2,
            //    data: Cost,

            //    tooltip: {
            //        valuePrefix: '$',
            //        valueSuffix: ' BHT'
            //    },
            //    pointPadding: 0.3,
            //    pointPlacement: 0.2,
            //    yAxis: 1

            //}, 
            {

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
            }, {

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

                name: 'CostUnit',
                color: '#F3FF00',
                borderColor: '#F3FF00',
                type: 'line',
                width: 10,
                data: CostUnit,

                tooltip: {
                    valuePrefix: '฿',
                    pointformat: '{point.y:,0.2f}',
                    valueSuffix: 'BHT/Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1
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
                       //[0, '#04F7EC'],
                       //       [1, '#06A59E']
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
                    className: 'highcharts-color-0',
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
                    min: 0
                    //showFirstLabel: false

                }, {

                    className: 'highcharts-color-1',
                    title: {
                        text: 'Prod.Unit',
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
                    min: 0
                    // showFirstLabel: false

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
                pointFormat: '{series.name}: <b>{point.y}</b>'

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
            series: [
                //{
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



                //    name: 'Prod.Unit',
                //    color: '#FF0000',
                //    borderColor: '#FF0000',
                //    type: 'line',
                //    width: 10,
                //    data: Prod,

                //    tooltip: {
                //        // valuePrefix: '฿',
                //        valueSuffix: ' Unit'
                //    },
                //    pointPadding: 0.3,
                //    pointPlacement: 0.2,
                //    yAxis: 2

                //},
                //{

                //name: 'Accum.CostUnit',
                //color: '#F3FF00',
                //borderColor: '#F3FF00',
                //type: 'line',
                //width: 10,
                //data: AccumCostUnit,

                //tooltip: {
                //    valuePrefix: '฿',
                //    pointformat: '{point.y:,0.2f}',
                //    valueSuffix: 'BHT/Unit'
                //},
                //pointPadding: 0.3,
                //pointPlacement: 0.2,
                //yAxis: 1

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

            //}, 
            {

                name: 'OP[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: OPOT1,
                format: '{value:,0.2f} Unit.',
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'OP[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: OPOT15,
                format: '{value:,0.2f} Unit.',
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',

                },
            }, {
                name: 'OP[OT2]',
                color: '#00FE1F',
                borderColor: '#FF0000',
                data: OPOT2,
                format: '{value:,0.2f} Unit.',
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },

            }, {
                name: 'OP[OT3]',
                color: '#FE0000',
                borderColor: '#FE0000',
                data: OPOT3,
                format: '{value:,0.2f} Unit.',
                stack: 'OP', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'LE[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: LEOT1,
                format: '{value:,.2f} Unit.',
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },

            }, {
                name: 'LE[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: LEOT15,
                format: '{value:,.2f} Unit.',
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'LE[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: LEOT2,
                format: '{value:,.2f} Unit.',
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'LE[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: LEOT3,
                format: '{value:,.2f} Unit.',
                stack: 'LE', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'FO[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: FOOT1,
                format: '{value:,.2f} Unit.',
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },

            }, {
                name: 'FO[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: FOOT15,
                format: '{value:,.2f} Unit.',
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'FO[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: FOOT2,
                format: '{value:,.2f} Unit.',
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'FO[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: FOOT3,
                format: '{value:,.2f} Unit.',
                stack: 'FO', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'SU[OT1]',
                color: '#FF00D1',
                borderColor: '#FF00D1',
                data: SUOT1,
                format: '{value:,.2f} Unit.',
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },

            }, {
                name: 'SU[OT15]',
                color: '#001FFE',
                borderColor: '#001FFE',
                data: SUOT15,
                format: '{value:,.2f} Unit.',
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'SU[OT2]',
                color: '#00FE1F',
                borderColor: '#00FE1F',
                data: SUOT2,
                format: '{value:,.2f} Unit.',
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
                name: 'SU[OT3]',
                color: '#FE0000',
                borderColor: '#FF0000',
                data: SUOT3,
                format: '{value:,.2f} Unit.',
                stack: 'SU', tooltip: {
                    valueSuffix: ' Hr.',
                    pointformat: '{point.y:,0.2f}',
                },
            }, {
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
                name: 'CostUnit',
                color: '#F3FF00',
                borderColor: '#F3FF00',
                type: 'line',
                width: 10,
                data: CostUnit,

                tooltip: {
                    valuePrefix: '฿',
                    pointformat: '{point.y:,0.2f}',
                    valueSuffix: 'BHT/Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

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
function loadChartOvelAllFac(_objChart, _CostCenter, _DataDate, _DataMonth) {

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
        //    success: function (ResponseData) {
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
                    className: 'Cost/Unit',
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
                    min: 0
                    //showFirstLabel: false

                }, {

                    className: 'highcharts-color-1',
                    title: {
                        text: 'Prod.Unit',
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
                    min: 0
                    //showFirstLabel: false

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
                pointFormat: '{series.name}: <b>{point.y}</b>'

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
            series: [
                //{
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



            //    name: 'Prod.Unit',
            //    color: '#FF0000',
            //    borderColor: '#FF0000',
            //    type: 'line',
            //    width: 10,
            //    data: Prod,

            //    tooltip: {
            //        // valuePrefix: '฿',
            //        valueSuffix: ' Unit'
            //    },
            //    pointPadding: 0.3,
            //    pointPlacement: 0.2,
            //    yAxis: 2

            //}, {

            //    name: 'Accum.CostUnit',
            //    color: '#F3FF00',
            //    borderColor: '#F3FF00',
            //    type: 'line',
            //    width: 10,
            //    data: AccumCostUnit,

            //    tooltip: {
            //        valuePrefix: '฿',
            //        pointformat: '{point.y:,0.2f}',
            //        valueSuffix: 'BHT/Unit'
            //    },
            //    pointPadding: 0.3,
            //    pointPlacement: 0.2,
            //    yAxis: 1

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

            //},
            {

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
            }, {

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

                name: 'CostUnit',
                color: '#F3FF00',
                borderColor: '#F3FF00',
                type: 'line',
                width: 10,
                data: CostUnit,

                tooltip: {
                    valuePrefix: '฿',
                    pointformat: '{point.y:,0.2f}',
                    valueSuffix: 'BHT/Unit'
                },
                pointPadding: 0.3,
                pointPlacement: 0.2,
                yAxis: 1

            }

            ]
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
function loadChartMPDirectSupport(_objChart, _CostCenter, _DataDate, _DataMonth) {

    var DataMonth = new Date(_DataMonth);
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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMPReqD = new Array();
    var SUMMPReqN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();


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


    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

    if (_CostCenter == "MPALL") {
        dataTitle = "Attendance Statistic Monitor : " + months[d.getMonth()] + "/" + DataDate.getFullYear();

        //--------------------------------DIRECT GROUP ---------------------//
    } else if (_CostCenter == "MPFAC1") {
        dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2") {
        dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3") {
        dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODM") {
        dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev") {
        dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev") {
        dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev") {
        dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev") {
        dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev2") {
        dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev2") {
        dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev2") {
        dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev2") {
        dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev3") {
        dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev3") {
        dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev3") {
        dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev3") {
        dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQS") {

        dataTitle = "Attendance Statistic Monitor : QUALITY CONTROL  " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQSPrev") {
        dataTitle = "Attendance Statistic Monitor : QUALITY CONTROL " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQSPrev2") {
        dataTitle = "Attendance Statistic Monitor : QUALITY CONTROL " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQSPrev3") {
        dataTitle = "Attendance Statistic Monitor : QUALITY CONTROL " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQA") {

        dataTitle = "Direct : QA  " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQAPrev") {
        dataTitle = "Direct : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQAPrev2") {
        dataTitle = "Direct : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQAPrev3") {
        dataTitle = "Direct : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "MPPS") {

        dataTitle = "Direct : PART SUPPLY  " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPPSPrev") {
        dataTitle = "Direct : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPPSPrev2") {
        dataTitle = "Direct : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPPSPrev3") {
        dataTitle = "Direct : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "MPECUT") {

        dataTitle = "Attendance Statistic Monitor : EC " + months[d.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "MPECUTPrev") {
        dataTitle = "Attendance Statistic Monitor : EC " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPECUTPrev2") {
        dataTitle = "Attendance Statistic Monitor : EC " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPECUTPrev3") {
        dataTitle = "Attendance Statistic Monitor : EC " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "MPMTALL") {

        dataTitle = "Attendance Statistic Monitor : MAINTENANCE " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPMTALLPrev") {
        dataTitle = "Attendance Statistic Monitor : MAINTENANCE " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPMTALLPrev2") {
        dataTitle = "Attendance Statistic Monitor : MAINTENANCE " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPMTALLPrev3") {
        dataTitle = "Attendance Statistic Monitor : MAINTENANCE " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();



        //--------------------------------INDIRECT GROUP ---------------------//

        //------ Production & Maintenance ------------------
    } else if (_CostCenter == "INFAC1") {
        dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "INFAC2") {
        dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "INFAC3") {
        dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "INODM") {
        dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }
    else if (_CostCenter == "INMTALL") {

        dataTitle = "Attendance Statistic Monitor : MAINTENANCE " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INMTM") {

        dataTitle = "Attendance Statistic Monitor : MAINTENANCE MACHINE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INMTA") {

        dataTitle = "Attendance Statistic Monitor : MAINTENANCE ASSY. of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

        //-----------------Procurement PU SPU PC
    else if (_CostCenter == "INPU") {

        dataTitle = "Attendance Statistic Monitor : PURCHASING (PU) of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INSPU") {

        dataTitle = "Attendance Statistic Monitor : PURCHASING STRATERGY&DEV of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INPC") {

        dataTitle = "Attendance Statistic Monitor : PURCHASING of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
        //    //---------------Production contron & SCM -------------------------------
    else if (_CostCenter == "INPS") {

        dataTitle = "Attendance Statistic Monitor : PURCHASING of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INPN") {

        dataTitle = "Attendance Statistic Monitor : PRODUCTION PLANNING of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INIM") {

        dataTitle = "Attendance Statistic Monitor : IMPROVEMENT of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INDC") {

        dataTitle = "Attendance Statistic Monitor : DELIVERY CONTROL of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }



        //------------------ Engineer ------------------
    else if (_CostCenter == "INENA") {

        dataTitle = "Attendance Statistic Monitor : ENGINEER of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INENM") {

        dataTitle = "Attendance Statistic Monitor :ENM" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INENMOT") {

        dataTitle = "Attendance Statistic Monitor : ENMOT of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

        // //---------------------- EC UT ----------------------
    else if (_CostCenter == "INUT") {

        dataTitle = "Attendance Statistic Monitor : MAINTENANCE(UT) of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INEC") {

        dataTitle = "Attendance Statistic Monitor : OPERATION (WC) of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
        //------------------------- QC QA QS -------------------------
    else if (_CostCenter == "INQC") {

        dataTitle = "Attendance Statistic Monitor : QUALITY CONTROL  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

    else if (_CostCenter == "INQA") {

        dataTitle = "Attendance Statistic Monitor : QUALITY ASSURANCE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INQS") {

        dataTitle = "Attendance Statistic Monitor : QUALITY SYSTEM AUDIT of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

        //----------------- Design and Develope ---------------------
    else if (_CostCenter == "INDD") {

        dataTitle = "Attendance Statistic Monitor : DESIGN&DEVELOPMENT of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INCD") {

        dataTitle = "Attendance Statistic Monitor : CALORIE&DURABILITY of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
        //    //--------------------------------S.G.A GROUP ---------------------//
    else if (_CostCenter == "INIT") {

        dataTitle = "Attendance Statistic Monitor : INFORMATION TECHNOLOGY of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

    else if (_CostCenter == "INPN") {

        dataTitle = "Attendance Statistic Monitor : PRODUCTION PLANNING of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INWH") {

        dataTitle = "Attendance Statistic Monitor : WAREHOUSE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INDL") {

        dataTitle = "Attendance Statistic Monitor : WAREHOUSE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }


    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
        //$.ajax({
        //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
        //    dataType: 'json',
        //    async: false,
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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


            SUMMPReqD.push([ResponseData[i].SumMPD]);
            SUMMPReqN.push([ResponseData[i].SumMPN]);
            SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
            SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
            SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


            //  SUMMPH.push([ResponseData[i].SumMPH]);
            //  SUMMP.push([ResponseData[i].SumMP]);


            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            // DayWeek = DD + ":" + Dayto;
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column', backgroundColor: '#F2F2F2',
                //backgroundColor: {
                //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                //    stops: [
                //         [0, '#098996'],
                //              [1, '#054C54']
                //       //[0, '#FBFBD4'],
                //       //       [1, '#C7C6A1']
                //    ]
                //},
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '##581845',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: Dayto,
                labels: {
                    style: {
                        color: '##581845',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [{
                className: 'highcharts-color-0',
                title: {

                    text: 'Employee',
                    style: {
                        color: '##581845',
                        fontWeight: 'bold'
                    }
                },
                labels: {
                    format: '{value:,.0f}.',
                    style: {
                        color: '##581845',
                        fontSize: '10px'
                    }
                },
                max: 100,
                min: 0,

                //stackLabels: {
                //    enabled: false,
                //    style: {
                //        fontWeight: 'bold',
                //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                //    }
                //}


            }, {

                title: {
                    text: 'Diff'
                },
                max: 100,
                min: -100,
                opposite: true
            }],

            legend: {
                align: 'right',
                x: -10,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            //legend: {
            //    shadow: false
            //},
            tooltip: {
                shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    borderWidth: 0
                }
            },

            series: [

            //{

            //    name: 'Diff_ManPowerDay',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFD,
            //    //pointPadding: 0.2,
            //    //pointPlacement: -0.2,
            //   // stack: 'D'

            //},
             //{
             //    name: 'MP/Shift',
             //    color:
             //    '#E59866',
             //    borderColor: '#FFD733',
             //    data: MP_Shift,
             //    pointWidth: 30,
             //    //pointPadding: 0.2,
             //    pointPlacement: -0.2,
             //    // stack: 'D'

             //},
            {
                name: 'ManPower Day',
                color:
                '#E59866',
                borderColor: '#E59866',
                data: SUMMPReqD,
                pointWidth: 18,
                //pointPadding: 0.2,
                pointPlacement: -0.2,
                // stack: 'D'

            }, {

                name: 'Actual Day',
                color: '#FC1801',
                borderColor: '#FC1801',
                data: SUMMP_ACTD,
                //pointPadding: 0.3,
                pointWidth: 8,
                pointPlacement: -0.2,
                // stack: 'D'

            },
            //{

            //    name: 'Diff_ManPowerNight',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFN,
            //    //pointPadding: 0.4,
            //    //pointPlacement: -0.2,
            //    stack: 'N'

            //},
              {
                  name: 'ManPowerNight',
                  color: '#5B2C6F',
                  borderColor: '#5B2C6F',
                  data: SUMMPReqN,
                  //pointPadding: 0.2,
                  pointWidth: 18,
                  pointPlacement: 0.2
                  //stack: 'N'
              }, {

                  name: 'Actual Night',
                  color: '#FC1801',
                  borderColor: '#FC1801',
                  data: SUMMP_ACTN,
                  //pointPadding: 0.3,
                  pointWidth: 8,
                  pointPlacement: 0.2,
                  // stack: 'D'

              },
                {
                    type: 'line',
                    name: 'Diff Day',
                    color: '#EB2A10',
                    borderColor: '#EB2A10',
                    data: SUMMP_DIFFD,
                    //pointPadding: 0.2,
                    pointPlacement: -0.2,
                    // stack: 'D'
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                }, {
                    type: 'line',
                    name: 'Diff Night',
                    color: '#8B1EDC',
                    borderColor: '#8B1EDC',
                    data: SUMMP_DIFFN,
                    //pointPadding: 0.4,
                    pointPlacement: 0,
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                },
            ],

        });
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });




}
function loadChartMPINDirectSupport(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMPReqD = new Array();
    var SUMMPReqN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();


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


    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

    if (_CostCenter == "MPALL") {
        dataTitle = "Attendance Statistic Monitor : " + months[d.getMonth()] + "/" + DataDate.getFullYear();

        //--------------------------------DIRECT GROUP ---------------------//
    } else if (_CostCenter == "MPFAC1") {
        dataTitle = "INDIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2") {
        dataTitle = "INDIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3") {
        dataTitle = "INDIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODM") {
        dataTitle = "INDIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev") {
        dataTitle = "INDIRECT : Factory 1 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev") {
        dataTitle = "INDIRECT : Factory 2 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev") {
        dataTitle = "INDIRECT : Factory 3 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev") {
        dataTitle = "INDIRECT : Factory ODM " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev2") {
        dataTitle = "INDIRECT : Factory 1 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev2") {
        dataTitle = "INDIRECT : Factory 2 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev2") {
        dataTitle = "INDIRECT : Factory 3 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev2") {
        dataTitle = "INDIRECT : Factory ODM " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev3") {
        dataTitle = "INDIRECT : Factory 1 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev3") {
        dataTitle = "INDIRECT : Factory 2 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev3") {
        dataTitle = "INDIRECT : Factory 3 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev3") {
        dataTitle = "INDIRECT : Factory ODM " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQS") {

        dataTitle = "INDIRECT : QUALITY CONTROL  " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQSPrev") {
        dataTitle = "INDIRECT : QUALITY CONTROL " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQSPrev2") {
        dataTitle = "INDIRECT : QUALITY CONTROL " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPQCQAQSPrev3") {
        dataTitle = "INDIRECT : QUALITY CONTROL " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "MPECUT") {

        dataTitle = "INDIRECT : EC " + months[d.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "MPECUTPrev") {
        dataTitle = "INDIRECT : EC " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPECUTPrev2") {
        dataTitle = "INDIRECT : EC " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPECUTPrev3") {
        dataTitle = "INDIRECT : EC " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "MPMTALL") {

        dataTitle = "INDIRECT : MAINTENANCE " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPMTALLPrev") {
        dataTitle = "INDIRECT : MAINTENANCE " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPMTALLPrev2") {
        dataTitle = "INDIRECT : MAINTENANCE " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPMTALLPrev3") {
        dataTitle = "INDIRECT : MAINTENANCE " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();



        //--------------------------------INDIRECT GROUP ---------------------//

        //------ Production & Maintenance ------------------
    } else if (_CostCenter == "INFAC1") {
        dataTitle = "INDIRECT: Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "INFAC2") {
        dataTitle = "INDIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "INFAC3") {
        dataTitle = "INDIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "INODM") {
        dataTitle = "INDIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }
    else if (_CostCenter == "INMTALL") {

        dataTitle = "INDIRECT : MAINTENANCE " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INMTM") {

        dataTitle = "INDIRECT : MAINTENANCE MACHINE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INMTA") {

        dataTitle = "INDIRECT : MAINTENANCE ASSY. of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INMTPM") {

        dataTitle = "INDIRECT : PREVENTIVE MAINTENANCE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INMTTPM") {

        dataTitle = "INDIRECT : TPM of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }


        //-----------------Procurement PU SPU PC
    else if (_CostCenter == "INPU") {

        dataTitle = "INDIRECT : PURCHASING (PU) of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INSPU") {

        dataTitle = "INDIRECT : PURCHASING STRATERGY&DEV of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INPC") {

        dataTitle = "INDIRECT : PURCHASING of" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
        //    //---------------Production contron & SCM -------------------------------
    else if (_CostCenter == "INPS") {

        dataTitle = "INDIRECT : PART SUPPLY of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INPN") {

        dataTitle = "INDIRECT : PRODUCTION PLANNING of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INIM") {

        dataTitle = "INDIRECT : IMPROVEMENT of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INDC") {

        dataTitle = "INDIRECT : DELIVERY CONTROL of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }



        //------------------ Engineer ------------------
    else if (_CostCenter == "INENA") {

        dataTitle = "INDIRECT : ENGINEERING ASSEMBLY  of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INENM") {

        dataTitle = "INDIRECT : ENGINEERING MACHINE of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INENMOT") {

        dataTitle = "INDIRECT : ENGINEERING MOTOR of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

        // //---------------------- EC UT ----------------------
    else if (_CostCenter == "INUT") {

        dataTitle = "INDIRECT : MAINTENANCE(UT) of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INEC") {

        dataTitle = "INDIRECT : OPERATION (EC) of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
        //------------------------- QC QA QS -------------------------
    else if (_CostCenter == "INQC") {

        dataTitle = "INDIRECT : QUALITY CONTROL  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

    else if (_CostCenter == "INQA") {

        dataTitle = "INDIRECT : QUALITY ASSURANCE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INQS") {

        dataTitle = "INDIRECT : QUALITY SYSTEM AUDIT of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

        //----------------- Design and Develope ---------------------
    else if (_CostCenter == "INDD") {

        dataTitle = "INDIRECT : DESIGN&DEVELOPMENT of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INCD") {

        dataTitle = "INDIRECT : CALORIE&DURABILITY of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
        //    //--------------------------------S.G.A GROUP ---------------------//
    else if (_CostCenter == "INIT") {

        dataTitle = "INDIRECT : INFORMATION TECHNOLOGY of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }

    else if (_CostCenter == "INPN") {

        dataTitle = "INDIRECT : PRODUCTION PLANNING of " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INWH") {

        dataTitle = "INDIRECT : WAREHOUSE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INDL") {

        dataTitle = "INDIRECT : WAREHOUSE of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INSGA") {

        dataTitle = "INDIRECT : S.G.A of  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INHR") {

        dataTitle = "INDIRECT: HR  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INAC") {

        dataTitle = "INDIRECT : AC  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INGA") {

        dataTitle = "INDIRECT : GA  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INCC") {

        dataTitle = "INDIRECT : CC  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INCB") {

        dataTitle = "INDIRECT : CB  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INTS") {

        dataTitle = "INDIRECT : TS  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INAUDIT") {

        dataTitle = "INDIRECT : AUDIT  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INHRD") {

        dataTitle = "INDIRECT : HRD  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INSF") {

        dataTitle = "INDIRECT : SF  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "INLG") {

        dataTitle = "INDIRECT : LG  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INDCC") {

        dataTitle = "INDIRECT : DCC  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "INTD") {

        dataTitle = "INDIRECT : TD  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }


    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
        //$.ajax({
        //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
        //    dataType: 'json',
        //    async: false,
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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


            SUMMPReqD.push([ResponseData[i].SumMPD]);
            SUMMPReqN.push([ResponseData[i].SumMPN]);
            SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
            SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
            SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


            //  SUMMPH.push([ResponseData[i].SumMPH]);
            //  SUMMP.push([ResponseData[i].SumMP]);


            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            // DayWeek = DD + ":" + Dayto;
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column', backgroundColor: '#F2F2F2',
                //backgroundColor: {
                //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                //    stops: [
                //         [0, '#098996'],
                //              [1, '#054C54']
                //       //[0, '#FBFBD4'],
                //       //       [1, '#C7C6A1']
                //    ]
                //},
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '##581845',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: Dayto,
                labels: {
                    style: {
                        color: '##581845',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [{
                className: 'highcharts-color-0',
                title: {

                    text: 'Employee',
                    style: {
                        color: '##581845',
                        fontWeight: 'bold'
                    }
                },
                labels: {
                    format: '{value:,.0f}.',
                    style: {
                        color: '##581845',
                        fontSize: '10px'
                    }
                },
                max: 100,
                min: 0,

                //stackLabels: {
                //    enabled: false,
                //    style: {
                //        fontWeight: 'bold',
                //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                //    }
                //}


            }, {

                title: {
                    text: 'Diff'
                },
                max: 100,
                min: -100,
                opposite: true
            }],

            legend: {
                align: 'right',
                x: -10,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            //legend: {
            //    shadow: false
            //},
            tooltip: {
                shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    borderWidth: 0
                }
            },

            series: [

            //{

            //    name: 'Diff_ManPowerDay',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFD,
            //    //pointPadding: 0.2,
            //    //pointPlacement: -0.2,
            //   // stack: 'D'

            //},
             //{
             //    name: 'MP/Shift',
             //    color:
             //    '#E59866',
             //    borderColor: '#FFD733',
             //    data: MP_Shift,
             //    pointWidth: 30,
             //    //pointPadding: 0.2,
             //    pointPlacement: -0.2,
             //    // stack: 'D'

             //},
            {
                name: 'ManPower Day',
                color:
                '#E59866',
                borderColor: '#E59866',
                data: SUMMPReqD,
                pointWidth: 18,
                //pointPadding: 0.2,
                pointPlacement: -0.2,
                // stack: 'D'

            }, {

                name: 'Actual Day',
                color: '#FC1801',
                borderColor: '#FC1801',
                data: SUMMP_ACTD,
                //pointPadding: 0.3,
                pointWidth: 8,
                pointPlacement: -0.2,
                // stack: 'D'

            },
            //{

            //    name: 'Diff_ManPowerNight',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFN,
            //    //pointPadding: 0.4,
            //    //pointPlacement: -0.2,
            //    stack: 'N'

            //},
              {
                  name: 'ManPowerNight',
                  color: '#5B2C6F',
                  borderColor: '#5B2C6F',
                  data: SUMMPReqN,
                  //pointPadding: 0.2,
                  pointWidth: 18,
                  pointPlacement: 0.2
                  //stack: 'N'
              }, {

                  name: 'Actual Night',
                  color: '#FC1801',
                  borderColor: '#FC1801',
                  data: SUMMP_ACTN,
                  //pointPadding: 0.3,
                  pointWidth: 8,
                  pointPlacement: 0.2,
                  // stack: 'D'

              },
                {
                    type: 'line',
                    name: 'Diff Day',
                    color: '#EB2A10',
                    borderColor: '#EB2A10',
                    data: SUMMP_DIFFD,
                    //pointPadding: 0.2,
                    pointPlacement: -0.2,
                    // stack: 'D'
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                }, {
                    type: 'line',
                    name: 'Diff Night',
                    color: '#8B1EDC',
                    borderColor: '#8B1EDC',
                    data: SUMMP_DIFFN,
                    //pointPadding: 0.4,
                    pointPlacement: 0,
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                },
            ],

        });
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });




}

function loadChartMPFacOT(_objChart, _CostCenter, _DataDate, _DataMonth) {

    var DataMonth = new Date(_DataMonth);
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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMP_STDD = new Array();
    var SUMMP_STDN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();


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

    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    //var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    //document.getElementById("demo").innerHTML = months[d.getMonth()];


    if (_CostCenter == "OTALL") {
        dataTitle = "ALL DCI :  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC1") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3A") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 ASSY." + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3M") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3APrev") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 ASSY." + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3MPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 Machine" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3APrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 ASSY." + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3MPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 Machine" + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3APrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 ASSY." + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC3MPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 Machine" + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODM") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTMPPS") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "OTMPPSPrev") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTMPPSPrev2") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTMPPSPrev3") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTMPQA") {
        dataTitle = "OverTime Statistic Monitor : QA" + months[d.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "OTMPQAPrev") {
        dataTitle = "OverTime Statistic Monitor : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTMPQAPrev2") {
        dataTitle = "OverTime Statistic Monitor : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTMPQAPrev3") {
        dataTitle = "OverTime Statistic Monitor : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    }
    else if (_CostCenter == "OTECUT") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "OTECUTPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUTPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUTPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQS") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINFAC1") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }
    else if (_CostCenter == "OTINFAC2") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINFAC3") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINODM") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQC") {
        dataTitle = "OverTime Statistic Monitor : Factory QC " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQA") {
        dataTitle = "OverTime Statistic Monitor : Factory QA " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQS") {
        dataTitle = "OverTime Statistic Monitor : Factory QS " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }




    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
        //$.ajax({
        //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
        //    dataType: 'json',
        //    async: false,
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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


            SUMMP_STDD.push([ResponseData[i].SumMPD]);
            SUMMP_STDN.push([ResponseData[i].SumMPN]);

            SUMOTReqD.push([ResponseData[i].SumOT_ReqD]);
            SUMOTReqN.push([ResponseData[i].SumOT_ReqN]);
            SUMOTD.push([ResponseData[i].SumOT_ActD]);
            SUMOTN.push([ResponseData[i].SumOT_ActN]);



            //SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            //SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


            //  SUMMPH.push([ResponseData[i].SumMPH]);
            //  SUMMP.push([ResponseData[i].SumMP]);


            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            // DayWeek = DD + ":" + Dayto;
        }


        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {
            //scrollbar: {
            //    enabled: true
            //},
            chart: {
                zoomType: 'x',
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
                chart: {

                    zoomType: 'xy'
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#FFFFFF',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: Dayto,
                labels: {
                    overflow: 'justify',
                    style: {
                        color: '#EEFDFB',
                        fontSize: '12px'
                    }
                },
                //min: 1,
                //max: 31,
                scrollbar: {
                    enabled: true
                }
            },

            yAxis: [
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'ManPower',
                        style: {
                            color: '#FDFEFE',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f}.',
                        style: {
                            color: '#FDFEFE',
                            fontSize: '10px'
                        }
                    },
                    stackLabels: {
                        enabled: false,
                        style: {
                            fontWeight: 'bold',
                            color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        }
                    }


                }
            ],

            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {

                crosshairs: false,
                //shared: true,
                //headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                //pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                //            '<td style="padding:0;"><b>{point.y}</b></td></tr>',
                //footerFormat: '</table>',
                //shared: true,
                //useHTML: true

                //headerFormat: '<b>{point.x}</b>',
                pointFormat: '{series.name}: <b>{point.y}</b>'

                //headerFormat: '<b>{point.x}</b>',
                //pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
                //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
                //shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    borderWidth: 0
                }
                //column: {
                // stacking: 'normal',
                //    dataLabels: {
                //        enabled: false,
                //        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'White',
                //        grouping: false,
                //        shadow: false,
                //        borderWidth: 0,

                //  pointPadding: 0.2,

                //}
                //}
            },
            series: [

            {
                name: 'Std_ManPowerDay',
                color: '#FFF704',
                borderColor: '#FFF704',
                data: SUMMP_STDD,
                pointPadding: 0.2,
                pointPlacement: -0.2

            }, {
                name: 'Req_ManPowerDay',
                color: '#0418AF',
                borderColor: '#0418AF',
                data: SUMOTReqD,
                pointPadding: 0.3,
                pointPlacement: -0.2
                //tooltip: {
                //    valueSuffix: ' MP.'
                //},
            },
               {

                   name: 'ACT_ManPowerDay',
                   color: '#FC1801',
                   borderColor: '#FC1801',
                   data: SUMOTD,
                   pointPadding: 0.4,
                   pointPlacement: -0.2
                   //tooltip: {
                   //    valueSuffix: ' MP.'
                   //},
               },
                 {

                     name: 'Std_ManPowerNight',
                     color: '#27A009',
                     borderColor: '#27A009',
                     data: SUMMP_STDN,
                     pointPadding: 0.2,
                     pointPlacement: 0.2

                 }, {

                     name: 'REQ_ManPowerNight',
                     color: '#0418AF',
                     borderColor: '#0418AF',
                     data: SUMOTReqN,
                     pointPadding: 0.3,
                     pointPlacement: 0.2
                     //tooltip: {
                     //    valueSuffix: ' MP.'
                     //},
                 }, {

                     name: 'ACT_ManPowerNight',
                     color: '#FC1801',
                     borderColor: '#FC1801',
                     data: SUMOTN,
                     pointPadding: 0.4,
                     pointPlacement: 0.2

                     //stack: 'N'
                     //tooltip: {
                     //    valueSuffix: ' MP.'
                     //},
                 }

            ],

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
function loadChartMPFacOTINDIRECT(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMP_STDD = new Array();
    var SUMMP_STDN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();


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

    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    //var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    //document.getElementById("demo").innerHTML = months[d.getMonth()];



    if (_CostCenter == "OTALL") {
        dataTitle = "OverTime Statistic Monitor :  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC1") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODM") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUT") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "OTECUTPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUTPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUTPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQS") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINFAC1") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }
    else if (_CostCenter == "OTINFAC2") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINFAC3") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINODM") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQC") {
        dataTitle = "OverTime Statistic Monitor : Factory QC " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQA") {
        dataTitle = "OverTime Statistic Monitor : Factory QA " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQS") {
        dataTitle = "OverTime Statistic Monitor : Factory QS " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }




    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
        //$.ajax({
        //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
        //    dataType: 'json',
        //    async: false,
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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


            SUMMP_STDD.push([ResponseData[i].SumMPD]);
            SUMMP_STDN.push([ResponseData[i].SumMPN]);

            SUMOTReqD.push([ResponseData[i].SumOT_ReqD]);
            SUMOTReqN.push([ResponseData[i].SumOT_ReqN]);
            SUMOTD.push([ResponseData[i].SumOT_ActD]);
            SUMOTN.push([ResponseData[i].SumOT_ActN]);



            //SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            //SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


            //  SUMMPH.push([ResponseData[i].SumMPH]);
            //  SUMMP.push([ResponseData[i].SumMP]);


            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            // DayWeek = DD + ":" + Dayto;
        }


        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {
            //scrollbar: {
            //    enabled: true
            //},
            chart: {
                zoomType: 'x',
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
                chart: {

                    zoomType: 'xy'
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#FFFFFF',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: Dayto,
                labels: {
                    overflow: 'justify',
                    style: {
                        color: '#EEFDFB',
                        fontSize: '12px'
                    }
                },
                //min: 1,
                //max: 31,
                scrollbar: {
                    enabled: true
                }
            },

            yAxis: [
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'ManPower',
                        style: {
                            color: '#FDFEFE',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f}.',
                        style: {
                            color: '#FDFEFE',
                            fontSize: '10px'
                        }
                    },
                    max: 15,
                    min: 0,
                    stackLabels: {
                        enabled: false,
                        style: {
                            fontWeight: 'bold',
                            color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        }
                    }


                }
            ],

            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {

                crosshairs: false,
                //shared: true,
                //headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                //pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                //            '<td style="padding:0;"><b>{point.y}</b></td></tr>',
                //footerFormat: '</table>',
                //shared: true,
                //useHTML: true

                //headerFormat: '<b>{point.x}</b>',
                pointFormat: '{series.name}: <b>{point.y}</b>'

                //headerFormat: '<b>{point.x}</b>',
                //pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
                //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
                //shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    borderWidth: 0
                }
                //column: {
                // stacking: 'normal',
                //    dataLabels: {
                //        enabled: false,
                //        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'White',
                //        grouping: false,
                //        shadow: false,
                //        borderWidth: 0,

                //  pointPadding: 0.2,

                //}
                //}
            },
            series: [

            {
                name: 'Std_ManPowerDay',
                color: '#FFF704',
                borderColor: '#FFF704',
                data: SUMMP_STDD,
                pointPadding: 0.2,
                pointPlacement: -0.2

            }, {
                name: 'Req_ManPowerDay',
                color: '#0418AF',
                borderColor: '#0418AF',
                data: SUMOTReqD,
                pointPadding: 0.3,
                pointPlacement: -0.2
                //tooltip: {
                //    valueSuffix: ' MP.'
                //},
            },
               {

                   name: 'ACT_ManPowerDay',
                   color: '#FC1801',
                   borderColor: '#FC1801',
                   data: SUMOTD,
                   pointPadding: 0.4,
                   pointPlacement: -0.2
                   //tooltip: {
                   //    valueSuffix: ' MP.'
                   //},
               },
                 {

                     name: 'Std_ManPowerNight',
                     color: '#27A009',
                     borderColor: '#27A009',
                     data: SUMMP_STDN,
                     pointPadding: 0.2,
                     pointPlacement: 0.2

                 }, {

                     name: 'REQ_ManPowerNight',
                     color: '#0418AF',
                     borderColor: '#0418AF',
                     data: SUMOTReqN,
                     pointPadding: 0.3,
                     pointPlacement: 0.2
                     //tooltip: {
                     //    valueSuffix: ' MP.'
                     //},
                 }, {

                     name: 'ACT_ManPowerNight',
                     color: '#FC1801',
                     borderColor: '#FC1801',
                     data: SUMOTN,
                     pointPadding: 0.4,
                     pointPlacement: 0.2

                     //stack: 'N'
                     //tooltip: {
                     //    valueSuffix: ' MP.'
                     //},
                 }

            ],

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
function loadChartMPFacOTALL(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMP_STDD = new Array();
    var SUMMP_STDN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();


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

    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    //var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    //document.getElementById("demo").innerHTML = months[d.getMonth()];



    if (_CostCenter == "OTALL") {
        dataTitle = "OverTime Statistic Monitor :  " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "OTFAC1") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODM") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev2") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC1Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 1 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC2Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 2 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTFAC3Prev3") {
        dataTitle = "OverTime Statistic Monitor : Factory 3 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTODMPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUT") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "OTECUTPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUTPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTECUTPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory IT&EC " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQS") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev2") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTQCQAQSPrev3") {
        dataTitle = "OverTime Statistic Monitor : Factory QUALITY CONTROL " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINFAC1") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }
    else if (_CostCenter == "OTINFAC2") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINFAC3") {
        dataTitle = "OverTime Statistic Monitor : Factory Factory3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINODM") {
        dataTitle = "OverTime Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQC") {
        dataTitle = "OverTime Statistic Monitor : Factory QC " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQA") {
        dataTitle = "OverTime Statistic Monitor : Factory QA " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTINQS") {
        dataTitle = "OverTime Statistic Monitor : Factory QS " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    }




    $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
        //$.ajax({
        //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
        //    dataType: 'json',
        //    async: false,
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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


            SUMMP_STDD.push([ResponseData[i].SumMPD]);
            SUMMP_STDN.push([ResponseData[i].SumMPN]);

            SUMOTReqD.push([ResponseData[i].SumOT_ReqD]);
            SUMOTReqN.push([ResponseData[i].SumOT_ReqN]);
            SUMOTD.push([ResponseData[i].SumOT_ActD]);
            SUMOTN.push([ResponseData[i].SumOT_ActN]);



            //SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            //SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


            //  SUMMPH.push([ResponseData[i].SumMPH]);
            //  SUMMP.push([ResponseData[i].SumMP]);


            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            // DayWeek = DD + ":" + Dayto;
        }


        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {
            //scrollbar: {
            //    enabled: true
            //},
            chart: {
                zoomType: 'x',
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
                chart: {

                    zoomType: 'xy'
                },
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '#FFFFFF',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: Dayto,
                labels: {
                    overflow: 'justify',
                    style: {
                        color: '#EEFDFB',
                        fontSize: '12px'
                    }
                },
                //min: 1,
                //max: 31,
                scrollbar: {
                    enabled: true
                }
            },

            yAxis: [
                {
                    className: 'highcharts-color-0',
                    title: {
                        text: 'ManPower',
                        style: {
                            color: '#FDFEFE',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f}.',
                        style: {
                            color: '#FDFEFE',
                            fontSize: '10px'
                        },

                    },
                    max: 1500,
                    min: 0,
                    stackLabels: {
                        enabled: false,
                        style: {
                            fontWeight: 'bold',
                            color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        }
                    }


                }
            ],

            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {

                crosshairs: false,
                //shared: true,
                //headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                //pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                //            '<td style="padding:0;"><b>{point.y}</b></td></tr>',
                //footerFormat: '</table>',
                //shared: true,
                //useHTML: true

                //headerFormat: '<b>{point.x}</b>',
                pointFormat: '{series.name}: <b>{point.y}</b>'

                //headerFormat: '<b>{point.x}</b>',
                //pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
                //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
                //shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    borderWidth: 0
                }
                //column: {
                // stacking: 'normal',
                //    dataLabels: {
                //        enabled: false,
                //        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'White',
                //        grouping: false,
                //        shadow: false,
                //        borderWidth: 0,

                //  pointPadding: 0.2,

                //}
                //}
            },
            series: [

            {
                name: 'Std_ManPowerDay',
                color: '#FFF704',
                borderColor: '#FFF704',
                data: SUMMP_STDD,
                pointPadding: 0.2,
                pointPlacement: -0.2

            }, {
                name: 'Req_ManPowerDay',
                color: '#0418AF',
                borderColor: '#0418AF',
                data: SUMOTReqD,
                pointPadding: 0.3,
                pointPlacement: -0.2
                //tooltip: {
                //    valueSuffix: ' MP.'
                //},
            },
               {

                   name: 'ACT_ManPowerDay',
                   color: '#FC1801',
                   borderColor: '#FC1801',
                   data: SUMOTD,
                   pointPadding: 0.4,
                   pointPlacement: -0.2
                   //tooltip: {
                   //    valueSuffix: ' MP.'
                   //},
               },
                 {

                     name: 'Std_ManPowerNight',
                     color: '#27A009',
                     borderColor: '#27A009',
                     data: SUMMP_STDN,
                     pointPadding: 0.2,
                     pointPlacement: 0.2

                 }, {

                     name: 'REQ_ManPowerNight',
                     color: '#0418AF',
                     borderColor: '#0418AF',
                     data: SUMOTReqN,
                     pointPadding: 0.3,
                     pointPlacement: 0.2
                     //tooltip: {
                     //    valueSuffix: ' MP.'
                     //},
                 }, {

                     name: 'ACT_ManPowerNight',
                     color: '#FC1801',
                     borderColor: '#FC1801',
                     data: SUMOTN,
                     pointPadding: 0.4,
                     pointPlacement: 0.2

                     //stack: 'N'
                     //tooltip: {
                     //    valueSuffix: ' MP.'
                     //},
                 }

            ],

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



function loadChartMPFac3Day(_objChart, _CostCenter, _DataDate, _DataMonth) {

    var DataMonth = new Date(_DataMonth);
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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMPReqD = new Array();
    var SUMMPReqN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();
    var MC_MPD = new Array();
    var MC_MPN = new Array();
    var MCACTD = new Array();
    var MCACTN = new Array();
    var MC_Line = new Array();

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


    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

    // var MC = new Array()();

    var DDay = 31;
    var MC_Line = 8;
    //var int ROW = 3, COLUMN = 4;
    //var int score[][] = new int[ROW][COLUMN];
    //var int data = 5;

    // Assigning values
    //    for (int i = 0; i < ROW; i++) {
    //        for (int j = 0; j < COLUMN; j++) {
    //            score[i][j] = data;
    //            data += 5;
    //    }
    //}

    if (_CostCenter == "MPALL") {
        dataTitle = "DIRECT : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC1") {
        dataTitle = "DIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2") {
        dataTitle = "DIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3") {
        dataTitle = "DIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3M") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3CS") {
        dataTitle = "DIRECT : Factory 3 CS " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3A") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3MPrev") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev2") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev2") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev3") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev3") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODM") {
        dataTitle = "DIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev2") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev2") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev2") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev2") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev3") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev3") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev3") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev3") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

    } else if (_CostCenter == "MPMTALL") {
        dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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


            //SUMMPReqD.push([ResponseData[i].SumMPD]);
            //SUMMPReqN.push([ResponseData[i].SumMPN]);
            //SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
            //SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
            //SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            //SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


            //  SUMMPH.push([ResponseData[i].SumMPH]);
            //  SUMMP.push([ResponseData[i].SumMP]);


            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            MC_Line = [ResponseData[i].MC_Name];

            //FAC3AS
            //FAC3CS
            //FAC3FH
            //FAC3FIN
            //FAC3MA
            //FAC3MOT
            //FAC3PI
            //FAC3RH
            //|| (MC_Line = "FAC3CS") ||
            //   (MC_Line = "FAC3FH") || (MC_Line = "FAC3FIN") ||
            //   (MC_Line = "FAC3MA") || (MC_Line = "FAC3MOT") ||
            //   (MC_Line = "FAC3PI") || (MC_Line = "FAC3RH")
            //   for ( i = 0; i < DDay; i++) {
            //    for ( j = 0; j < MC_Line; j++) {
            //        score[i][j] = data;
            //        data += 5;
            //}
            //     }

            //if ((MC_Line = "FAC3AS"))
            //{
            SUMMPReqD.push([ResponseData[i].SumMPD]);
            SUMMPReqN.push([ResponseData[i].SumMPN]);
            SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
            SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
            SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);

            MC_MPD.push([ResponseData[i].MC_MPD]);
            MC_MPN.push([ResponseData[i].MC_MPN]);
            MCACTD.push([ResponseData[i].MCACTD]);
            MCACTN.push([ResponseData[i].MCACTN]);
            //}
            //else
            //{
            //    MC_MPD.push([ResponseData[i].MC_MPD]);
            //    MC_MPN.push([ResponseData[i].MC_MPN]);
            //    MCACTD.push([ResponseData[i].MCACTD]);
            //    MCACTN.push([ResponseData[i].MCACTN]);
            //}






            // DayWeek = DD + ":" + Dayto;
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column', backgroundColor: '#F2F2F2',
                //backgroundColor: {
                //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                //    stops: [
                //         [0, '#098996'],
                //              [1, '#054C54']
                //       //[0, '#FBFBD4'],
                //       //       [1, '#C7C6A1']
                //    ]
                //},
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '##581845',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: Dayto,
                labels: {
                    style: {
                        color: '##581845',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [{
                className: 'highcharts-color-0',
                title: {

                    text: 'Employee',
                    style: {
                        color: '##581845',
                        fontWeight: 'bold'
                    }
                },
                labels: {
                    format: '{value:,.0f}.',
                    style: {
                        color: '##581845',
                        fontSize: '10px'
                    }
                },
                max: 150,
                min: 0,

                //stackLabels: {
                //    enabled: false,
                //    style: {
                //        fontWeight: 'bold',
                //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                //    }
                //}


            }, {

                title: {
                    text: 'Diff'
                },
                max: 120,
                min: -120,
                opposite: true
            }],

            legend: {
                align: 'right',
                x: -10,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            //legend: {
            //    shadow: false
            //},
            tooltip: {
                shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    borderWidth: 0
                }
            },

            series: [

            //{

            //    name: 'Diff_ManPowerDay',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFD,
            //    //pointPadding: 0.2,
            //    //pointPlacement: -0.2,
            //   // stack: 'D'

            //},
             //{
             //    name: 'MP/Shift',
             //    color:
             //    '#E59866',
             //    borderColor: '#FFD733',
             //    data: MP_Shift,
             //    pointWidth: 30,
             //    //pointPadding: 0.2,
             //    pointPlacement: -0.2,
             //    // stack: 'D'

             //},
            {
                name: 'ManPower Day',
                color:
                '#E59866',
                borderColor: '#E59866',
                data: SUMMPReqD,
                pointWidth: 18,
                //pointPadding: 0.2,
                pointPlacement: -0.2,
                // stack: 'D'

            }, {

                name: 'Actual Day',
                color: '#FC1801',
                borderColor: '#FC1801',
                data: SUMMP_ACTD,
                //pointPadding: 0.3,
                pointWidth: 8,
                pointPlacement: -0.2,
                // stack: 'D'

            },
            //{

            //    name: 'Diff_ManPowerNight',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFN,
            //    //pointPadding: 0.4,
            //    //pointPlacement: -0.2,
            //    stack: 'N'

            //},
              {
                  name: 'ManPowerNight',
                  color: '#5B2C6F',
                  borderColor: '#5B2C6F',
                  data: SUMMPReqN,
                  //pointPadding: 0.2,
                  pointWidth: 18,
                  pointPlacement: 0.2
                  //stack: 'N'
              }, {

                  name: 'Actual Night',
                  color: '#FC1801',
                  borderColor: '#FC1801',
                  data: SUMMP_ACTN,
                  //pointPadding: 0.3,
                  pointWidth: 8,
                  pointPlacement: 0.2,
                  // stack: 'D'

              },
                {
                    type: 'line',
                    name: 'Diff Day',
                    color: '#EB2A10',
                    borderColor: '#EB2A10',
                    data: SUMMP_DIFFD,
                    //pointPadding: 0.2,
                    pointPlacement: -0.2,
                    // stack: 'D'
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                }, {
                    type: 'line',
                    name: 'Diff Night',
                    color: '#8B1EDC',
                    borderColor: '#8B1EDC',
                    data: SUMMP_DIFFN,
                    //pointPadding: 0.4,
                    pointPlacement: 0,
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                },
            ],

        });
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });




}
function loadChartMPFac3DrillDown(_objChart, _CostCenter, _DataDate, _DataMonth) {

    var DataMonth = new Date(_DataMonth);
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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMPReqD = new Array();
    var SUMMPReqN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();
    var MC_MPD = new Array();
    var MC_MPN = new Array();
    var MCACTD = new Array();
    var MCACTN = new Array();
    var MC_Line = new Array();

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
    var Score = new Array();

    var PI = new Array();
    var FH = new Array();
    var CS = new Array();
    var CY = new Array();
    var RH = new Array();
    var MOT = new Array();
    var MA = new Array();
    var AS = new Array();
    var FIN = new Array();
    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

    var DayTOO = new Array();
    var DDate = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];

    var ReqDay = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];

    var DiffDay = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];

    var DiffNight = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];


    var ReqNight = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5", "ReqN6", "ReqN7", "ReqN8", "ReqN9", "ReqN10", "ReqN11", "ReqN12", "ReqN13", "ReqN14", "ReqN15", "ReqN16",
"ReqN17", "ReqN18", "ReqN19", "ReqN20", "ReqN21", "ReqN22", "ReqN23", "ReqN24", "ReqN25", "ReqN26", "ReqN27", "ReqN28", "ReqN29", "ReqN30", "ReqN31"];

    var ACTD = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5", "ReqN6", "ReqN7", "ReqN8", "ReqN9", "ReqN10", "ReqN11", "ReqN12", "ReqN13", "ReqN14", "ReqN15", "ReqN16",
"ReqN17", "ReqN18", "ReqN19", "ReqN20", "ReqN21", "ReqN22", "ReqN23", "ReqN24", "ReqN25", "ReqN26", "ReqN27", "ReqN28", "ReqN29", "ReqN30", "ReqN31"];

    var ACTN = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5", "ReqN6", "ReqN7", "ReqN8", "ReqN9", "ReqN10", "ReqN11", "ReqN12", "ReqN13", "ReqN14", "ReqN15", "ReqN16",
"ReqN17", "ReqN18", "ReqN19", "ReqN20", "ReqN21", "ReqN22", "ReqN23", "ReqN24", "ReqN25", "ReqN26", "ReqN27", "ReqN28", "ReqN29", "ReqN30", "ReqN31"];


    var ReqD1, ReqD2, ReqD3, ReqD4, ReqD5, ReqD6, ReqD7, ReqD8, ReqD9, ReqD10, ReqD11, ReqD12, ReqD13, ReqD14, ReqD15, ReqD16, ReqD17, ReqD18, ReqD19, ReqD20, ReqD21, ReqD22, ReqD23, ReqD24, ReqD25,
ReqD26, ReqD27, ReqD28, ReqD29, ReqD30, ReqD31;
    var ReqN1 = 0, ReqN2 = 0, ReqN3 = 0, ReqN4 = 0, ReqN5 = 0, ReqN6 = 0, ReqN7, ReqN8, ReqN9, ReqN10, ReqN11, ReqN12, ReqN13, ReqN14, ReqN15, ReqN16, ReqN17, ReqN18, ReqN19, ReqN20, ReqN21, ReqN22, ReqN23,
ReqN24, ReqN25, ReqN26, ReqN27, ReqN28, ReqN29, ReqN30, ReqN31;

    var ActD1, ActD2, ActD3, ActD4, ActD5, ActD6, ActD7, ActD8, ActD9, ActD10, ActD11, ActD12, ActD13, ActD14, ActD15, ActD16, ActD17, ActD18, ActD19, ActD20, ActD21, ActD22, ActD23, ActD24, ActD25,
ActD26, ActD27, ActD28, ActD29, ActD30, ActD31;

    var ActN1, ActN2, ActN3, ActN4, ActN5, ActN6, ActN7, ActN8, ActN9, ActN10, ActN11, ActN12, ActN13, ActN14, ActN15, ActN16, ActN17, ActN18, ActN19, ActN20, ActN21, ActN22, ActN23, ActN24, ActN25,
ActN26, ActN27, ActN28, ActN29, ActN30, ActN31;

    var DiffD1, DiffD2, DiffD3, DiffD4, DiffD5, DiffD6, DiffD7, DiffD8, DiffD9, DiffD10, DiffD11, DiffD12, DiffD13, DiffD14, DiffD15, DiffD16, DiffD17, DiffD18, DiffD19, DiffD20, DiffD21, DiffD22, DiffD23, DiffD24, DiffD25,
DiffD26, DiffD27, DiffD28, DiffD29, DiffD30, DiffD31;

    var DiffN1, DiffN2, DiffN3, DiffN4, DiffN5, DiffN6, DiffN7, DiffN8, DiffN9, DiffN10, DiffN11, DiffN12, DiffN13, DiffN14, DiffN15, DiffN16, DiffN17, DiffN18, DiffN19, DiffN20, DiffN21, DiffN22, DiffN23, DiffN24, DiffN25,
DiffN26, DiffN27, DiffN28, DiffN29, DiffN30, DiffN31;



    var MCACTD1 = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5"];
    var MCACT1D1, MCACT1D2, MCACT1D3, MCACT1D4, MCACT1D5, MCACT1D6, MCACT1D7, MCACT1D8, MCACT1D9;


    var MCACT2D1, MCACT2D2, MCACT2D3, MCACT2D4, MCACT2D5, MCACT2D6, MCACT2D7, MCACT2D8, MCACT2D9, MCACT2D10;
    var MCACT3D1, MCACT3D2, MCACT3D3, MCACT3D4, MCACT3D5, MCACT3D6, MCACT3D7, MCACT3D8, MCACT3D9, MCACT3D10;
    var MCACT4D1, MCACT4D2, MCACT4D3, MCACT4D4, MCACT4D5, MCACT4D6, MCACT4D7, MCACT4D8, MCACT4D9, MCACT4D10;
    var MCACT5D1, MCACT5D2, MCACT5D3, MCACT5D4, MCACT5D5, MCACT5D6, MCACT5D7, MCACT5D8, MCACT5D9, MCACT5D10;
    var MCACT6D1, MCACT6D2, MCACT6D3, MCACT6D4, MCACT6D5, MCACT6D6, MCACT6D7, MCACT6D8, MCACT6D9, MCACT6D10;
    var MCACT7D1, MCACT7D2, MCACT7D3, MCACT7D4, MCACT7D5, MCACT7D6, MCACT7D7, MCACT7D8, MCACT7D9, MCACT7D10;
    var MCACT8D1, MCACT8D2, MCACT8D3, MCACT8D4, MCACT8D5, MCACT8D6, MCACT8D7, MCACT8D8, MCACT8D9, MCACT8D10;
    var MCACT9D1, MCACT9D2, MCACT9D3, MCACT9D4, MCACT9D5, MCACT9D6, MCACT9D7, MCACT9D8, MCACT9D9, MCACT9D10;
    var MCACT10D1, MCACT10D2, MCACT10D3, MCACT10D4, MCACT10D5, MCACT10D6, MCACT10D7, MCACT10D8, MCACT10D9, MCACT10D10;
    var MCACT11D1, MCACT11D2, MCACT11D3, MCACT11D4, MCACT11D5, MCACT11D6, MCACT11D7, MCACT11D8, MCACT11D9, MCACT11D10;
    var MCACT12D1, MCACT12D2, MCACT12D3, MCACT12D4, MCACT12D5, MCACT12D6, MCACT12D7, MCACT12D8, MCACT12D9, MCACT12D10;
    var MCACT13D1, MCACT13D2, MCACT13D3, MCACT13D4, MCACT13D5, MCACT13D6, MCACT13D7, MCACT13D8, MCACT13D9, MCACT13D10;
    var MCACT14D1, MCACT14D2, MCACT14D3, MCACT14D4, MCACT14D5, MCACT14D6, MCACT14D7, MCACT14D8, MCACT14D9, MCACT14D10;
    var MCACT15D1, MCACT15D2, MCACT15D3, MCACT15D4, MCACT15D5, MCACT15D6, MCACT15D7, MCACT15D8, MCACT15D9, MCACT15D10;
    var MCACT16D1, MCACT16D2, MCACT16D3, MCACT16D4, MCACT16D5, MCACT16D6, MCACT16D7, MCACT16D8, MCACT16D9, MCACT16D10;
    var MCACT17D1, MCACT17D2, MCACT17D3, MCACT17D4, MCACT17D5, MCACT17D6, MCACT17D7, MCACT17D8, MCACT17D9, MCACT17D10;
    var MCACT18D1, MCACT18D2, MCACT18D3, MCACT18D4, MCACT18D5, MCACT18D6, MCACT18D7, MCACT18D8, MCACT18D9, MCACT18D10;
    var MCACT19D1, MCACT19D2, MCACT19D3, MCACT19D4, MCACT19D5, MCACT19D6, MCACT19D7, MCACT19D8, MCACT19D9, MCACT19D10;
    var MCACT20D1, MCACT20D2, MCACT20D3, MCACT20D4, MCACT20D5, MCACT20D6, MCACT20D7, MCACT20D8, MCACT20D9, MCACT20D10;
    var MCACT21D1, MCACT21D2, MCACT21D3, MCACT21D4, MCACT21D5, MCACT21D6, MCACT21D7, MCACT21D8, MCACT21D9, MCACT21D10;
    var MCACT22D1, MCACT22D2, MCACT22D3, MCACT22D4, MCACT22D5, MCACT22D6, MCACT22D7, MCACT22D8, MCACT22D9, MCACT22D10;
    var MCACT23D1, MCACT23D2, MCACT23D3, MCACT23D4, MCACT23D5, MCACT23D6, MCACT23D7, MCACT23D8, MCACT23D9, MCACT23D10;
    var MCACT24D1, MCACT24D2, MCACT24D3, MCACT24D4, MCACT24D5, MCACT24D6, MCACT24D7, MCACT24D8, MCACT24D9, MCACT24D10;
    var MCACT25D1, MCACT25D2, MCACT25D3, MCACT25D4, MCACT25D5, MCACT25D6, MCACT25D7, MCACT25D8, MCACT25D9, MCACT25D10;
    var MCACT26D1, MCACT26D2, MCACT26D3, MCACT26D4, MCACT26D5, MCACT26D6, MCACT26D7, MCACT26D8, MCACT26D9, MCACT26D10;
    var MCACT27D1, MCACT27D2, MCACT27D3, MCACT27D4, MCACT27D5, MCACT27D6, MCACT27D7, MCACT27D8, MCACT27D9, MCACT27D10;
    var MCACT28D1, MCACT28D2, MCACT28D3, MCACT28D4, MCACT28D5, MCACT28D6, MCACT28D7, MCACT28D8, MCACT28D9, MCACT28D10;
    var MCACT29D1, MCACT29D2, MCACT29D3, MCACT29D4, MCACT29D33MCACT29D6, MCACT29D7, MCACT29D8, MCACT29D9, MCACT29D10;
    var MCACT30D1, MCACT30D2, MCACT30D3, MCACT30D4, MCACT30D34MCACT30D6, MCACT30D7, MCACT30D8, MCACT30D9, MCACT30D10;
    var MCACT31D1, MCACT31D2, MCACT31D33MCACT31D34MCACT31D35MCACT31D36MCACT31D7, MCACT31D8, MCACT31D9, MCACT31D10;


    var MCACTN1 = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5"];
    var MCACT1N1, MCACT1N2, MCACT1N3, MCACT1N4, MCACT1N5, MCACT1N6, MCACT1N7, MCACT1N8, MCACT1N9, MCACT1N10;
    var MCACT2N1, MCACT2N2, MCACT2N3, MCACT2N4, MCACT2N5, MCACT2N6, MCACT2N7, MCACT2N8, MCACT2N9, MCACT2N10;

    var j = 0;
    //var MC = new Array()();

    var DDay = 31;
    var MCCount = 10;

    var Loop = new Array();

    //var int ROW = 3, COLUMN = 4;
    //var int score[][] = new int[ROW][COLUMN];
    //var int data = 5;

    // Assigning values
    //    for (int i = 0; i < ROW; i++) {
    //        for (int j = 0; j < COLUMN; j++) {
    //            score[i][j] = data;
    //            data += 5;
    //    }
    //}

    if (_CostCenter == "MPALL") {
        dataTitle = "DIRECT : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC1") {
        dataTitle = "DIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2") {
        dataTitle = "DIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3") {
        dataTitle = "DIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    }
    else if (_CostCenter == "MPFAC3M") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3CS") {
        dataTitle = "DIRECT : Factory 3 CS " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3A") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3MPrev") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev2") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev2") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev3") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev3") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODM") {
        dataTitle = "DIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev2") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev2") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev2") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev2") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev3") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev3") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev3") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev3") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

    } else if (_CostCenter == "MPMTALL") {
        dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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



            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            MC_Line = [ResponseData[i].MC_Name];

            SUMMPReqD.push([ResponseData[i].SumMPD]);
            SUMMPReqN.push([ResponseData[i].SumMPN]);
            SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
            SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
            SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);

            MC_MPD.push([ResponseData[i].MC_MPD]);
            MC_MPN.push([ResponseData[i].MC_MPN]);
            MCACTD.push([ResponseData[i].MCACTD]);
            MCACTN.push([ResponseData[i].MCACTN]);

            Loop.push([ResponseData[i].CountLoop]);



        }








        //  Loop = (ResponseData.length - 2) / MCCount;

        for (i = 0; i < 31; i++) {


            if (Loop[j] != 0 && (j <= ResponseData.length)) {

                DayTOO[i] = Dayto[j];


                ReqDay[i] = SUMMPReqD[j];
                ReqNight[i] = SUMMPReqN[j];
                ACTD[i] = SUMMP_ACTD[j];
                ACTN[i] = SUMMP_ACTN[j];
                
                DiffDay[i] = SUMMP_DIFFD[j];
                DiffNight[i] = SUMMP_DIFFN[j];



                MCACTD1[j] = MCACTD[j];
                MCACTD1[j + 1] = MCACTD[j + 1];
                MCACTD1[j + 2] = MCACTD[j + 2];
                MCACTD1[j + 3] = MCACTD[j + 3];
                MCACTD1[j + 4] = MCACTD[j + 4];
                MCACTD1[j + 5] = MCACTD[j + 5];
                MCACTD1[j + 6] = MCACTD[j + 6];
                MCACTD1[j + 7] = MCACTD[j + 7];
                MCACTD1[j + 8] = MCACTD[j + 8];
                MCACTD1[j + 9] = MCACTD[j + 9];


                MCACTN1[j] = MCACTN[j];
                MCACTN1[j + 1] = MCACTN[j + 1];
                MCACTN1[j + 2] = MCACTN[j + 2];
                MCACTN1[j + 3] = MCACTN[j + 3];
                MCACTN1[j + 4] = MCACTN[j + 4];
                MCACTN1[j + 5] = MCACTN[j + 5];
                MCACTN1[j + 6] = MCACTN[j + 6];
                MCACTN1[j + 7] = MCACTN[j + 7];
                MCACTN1[j + 8] = MCACTN[j + 8];
                MCACTN1[j + 9] = MCACTN[j + 9];



                if (MC_Line = "FAC3AS") {
                    //   MCACTAS[i] = MC_MPD[j];
                }
                if (MC_Line = "FAC3CS") {
                    CS = MC_MPD[1];
                }
                if (MC_Line = "FAC3CY") {
                    CY = MC_MPD[2];
                }
                if (MC_Line = "FAC3FH") {
                    FH = MC_MPD[3];
                }
                if (MC_Line = "FAC3FIN") {
                    FIN = MC_MPD[4];
                }
                if (MC_Line = "FAC3MA") {
                    MOT = MC_MPD[5];
                }
                if (MC_Line = "FAC3MOT") {
                    MOT = MC_MPD[6];
                }
                if (MC_Line = "FAC3PI") {
                    PI = MC_MPD[7];
                }

                if (MC_Line = "FAC3RH") {
                    RH = MC_MPD[8];
                }
            }
            else {
                ReqDay[i] = 0;
                ReqNight[i] = 0;
                ACTD[i] = 0;
                ACTN[i] = 0;

                MC_ACTAS = 0;
                MCACTD[j] = 0;
                MCACTD[j + 1] = 0;
                MCACTD[j + 2] = 0;
                MCACTD[j + 3] = 0;
                MCACTD[j + 4] = 0;
                MCACTD[j + 5] = 0;
                MCACTD[j + 6] = 0;
                MCACTD[j + 7] = 0;
                MCACTD[j + 8] = 0;
                MCACTD[j + 9] = 0;


                MCACTN[j] = 0;
                MCACTN[j + 1] = 0;
                MCACTN[j + 2] = 0;
                MCACTN[j + 3] = 0;
                MCACTN[j + 4] = 0;
                MCACTN[j + 5] = 0;
                MCACTN[j + 6] = 0;
                MCACTN[j + 7] = 0;
                MCACTN[j + 8] = 0;
                MCACTN[j + 9] = 0;


            }
            //}
            j += MCCount;
        }

      //  DayTOO[i]
        DDate1 = DayTOO[0];
        DDate2 = DayTOO[1];
        DDate3 = DayTOO[2];
        DDate4 = DayTOO[3];
        DDate5 = DayTOO[4];
        DDate6 = DayTOO[5];
        DDate7 = DayTOO[6];
        DDate8 = DayTOO[7];
        DDate9 = DayTOO[8];
        DDate10 = DayTOO[9];
        DDate11 = DayTOO[10];
        DDate12 = DayTOO[11];
        DDate13 = DayTOO[12];
        DDate14 = DayTOO[13];
        DDate15 = DayTOO[14];
        DDate16 = DayTOO[15];
        DDate17 = DayTOO[16];
        DDate18 = DayTOO[17];
        DDate19 = DayTOO[18];
        DDate20 = DayTOO[19];
        DDate21 = DayTOO[20];
        DDate22 = DayTOO[21];
        DDate23 = DayTOO[22];
        DDate24 = DayTOO[23];
        DDate25 = DayTOO[24];
        DDate26 = DayTOO[25];
        DDate27 = DayTOO[26];
        DDate28 = DayTOO[27];
        DDate29 = DayTOO[28];
        DDate30 = DayTOO[29];
        DDate31 = DayTOO[30];




        MCACT1D1 = MCACTD[0];
        MCACT1D2 = MCACTD[1];
        MCACT1D3 = MCACTD[2];
        MCACT1D4 = MCACTD[3];
        MCACT1D5 = MCACTD[4];
        MCACT1D6 = MCACTD[5];
        MCACT1D7 = MCACTD[6];
        MCACT1D8 = MCACTD[7];
        MCACT1D9 = MCACTD[8];
        MCACT1D10 = MCACTD[9];

        MCACT2D1 = MCACTD[10];
        MCACT2D2 = MCACTD[11];
        MCACT2D3 = MCACTD[12];
        MCACT2D4 = MCACTD[13];
        MCACT2D5 = MCACTD[14];
        MCACT2D6 = MCACTD[15];
        MCACT2D7 = MCACTD[16];
        MCACT2D8 = MCACTD[17];
        MCACT2D9 = MCACTD[18];
        MCACT2D10 = MCACTD[19];


        MCACT3D1 = MCACTD[20];
        MCACT3D2 = MCACTD[21];
        MCACT3D3 = MCACTD[22];
        MCACT3D4 = MCACTD[23];
        MCACT3D5 = MCACTD[24];
        MCACT3D6 = MCACTD[25];
        MCACT3D7 = MCACTD[26];
        MCACT3D8 = MCACTD[27];
        MCACT3D9 = MCACTD[28];
        MCACT3D10 = MCACTD[29];
        MCACT4D1 = MCACTD[30];
        MCACT4D2 = MCACTD[31];
        MCACT4D3 = MCACTD[32];
        MCACT4D4 = MCACTD[33];
        MCACT4D5 = MCACTD[34];
        MCACT4D6 = MCACTD[35];
        MCACT4D7 = MCACTD[36];
        MCACT4D8 = MCACTD[37];
        MCACT4D9 = MCACTD[38];
        MCACT4D10 = MCACTD[39];
        MCACT5D1 = MCACTD[40];
        MCACT5D2 = MCACTD[41];
        MCACT5D3 = MCACTD[42];
        MCACT5D4 = MCACTD[43];
        MCACT5D5 = MCACTD[44];
        MCACT5D6 = MCACTD[45];
        MCACT5D7 = MCACTD[46];
        MCACT5D8 = MCACTD[47];
        MCACT5D9 = MCACTD[48];
        MCACT5D10 = MCACTD[49];
        MCACT6D1 = MCACTD[50];
        MCACT6D2 = MCACTD[51];
        MCACT6D3 = MCACTD[52];
        MCACT6D4 = MCACTD[53];
        MCACT6D5 = MCACTD[54];
        MCACT6D6 = MCACTD[55];
        MCACT6D7 = MCACTD[56];
        MCACT6D8 = MCACTD[57];
        MCACT6D9 = MCACTD[58];
        MCACT6D10 = MCACTD[59];
        MCACT7D1 = MCACTD[60];
        MCACT7D2 = MCACTD[61];
        MCACT7D3 = MCACTD[62];
        MCACT7D4 = MCACTD[63];
        MCACT7D5 = MCACTD[64];
        MCACT7D6 = MCACTD[65];
        MCACT7D7 = MCACTD[66];
        MCACT7D8 = MCACTD[67];
        MCACT7D9 = MCACTD[68];
        MCACT7D10 = MCACTD[69];
        MCACT8D1 = MCACTD[70];
        MCACT8D2 = MCACTD[71];
        MCACT8D3 = MCACTD[72];
        MCACT8D4 = MCACTD[73];
        MCACT8D5 = MCACTD[74];
        MCACT8D6 = MCACTD[75];
        MCACT8D7 = MCACTD[76];
        MCACT8D8 = MCACTD[77];
        MCACT8D9 = MCACTD[78];
        MCACT8D10 = MCACTD[79];
        MCACT9D1 = MCACTD[80];
        MCACT9D2 = MCACTD[81];
        MCACT9D3 = MCACTD[82];
        MCACT9D4 = MCACTD[83];
        MCACT9D5 = MCACTD[84];
        MCACT9D6 = MCACTD[85];
        MCACT9D7 = MCACTD[86];
        MCACT9D8 = MCACTD[87];
        MCACT9D9 = MCACTD[88];
        MCACT9D10 = MCACTD[89];
        MCACT10D1 = MCACTD[90];
        MCACT10D2 = MCACTD[91];
        MCACT10D3 = MCACTD[92];
        MCACT10D4 = MCACTD[93];
        MCACT10D5 = MCACTD[94];
        MCACT10D6 = MCACTD[95];
        MCACT10D7 = MCACTD[96];
        MCACT10D8 = MCACTD[97];
        MCACT10D9 = MCACTD[98];
        MCACT10D10 = MCACTD[99];
        MCACT11D1 = MCACTD[100];
        MCACT11D2 = MCACTD[101];
        MCACT11D3 = MCACTD[102];
        MCACT11D4 = MCACTD[103];
        MCACT11D5 = MCACTD[104];
        MCACT11D6 = MCACTD[105];
        MCACT11D7 = MCACTD[106];
        MCACT11D8 = MCACTD[107];
        MCACT11D9 = MCACTD[108];
        MCACT11D10 = MCACTD[109];
        MCACT12D1 = MCACTD[110];
        MCACT12D2 = MCACTD[111];
        MCACT12D3 = MCACTD[112];
        MCACT12D4 = MCACTD[113];
        MCACT12D5 = MCACTD[114];
        MCACT12D6 = MCACTD[115];
        MCACT12D7 = MCACTD[116];
        MCACT12D8 = MCACTD[117];
        MCACT12D9 = MCACTD[118];
        MCACT12D10 = MCACTD[119];
        MCACT13D1 = MCACTD[120];
        MCACT13D2 = MCACTD[121];
        MCACT13D3 = MCACTD[122];
        MCACT13D4 = MCACTD[123];
        MCACT13D5 = MCACTD[124];
        MCACT13D6 = MCACTD[125];
        MCACT13D7 = MCACTD[126];
        MCACT13D8 = MCACTD[127];
        MCACT13D9 = MCACTD[128];
        MCACT13D10 = MCACTD[129];
        MCACT14D1 = MCACTD[130];
        MCACT14D2 = MCACTD[131];
        MCACT14D3 = MCACTD[132];
        MCACT14D4 = MCACTD[133];
        MCACT14D5 = MCACTD[134];
        MCACT14D6 = MCACTD[135];
        MCACT14D7 = MCACTD[136];
        MCACT14D8 = MCACTD[137];
        MCACT14D9 = MCACTD[138];
        MCACT14D10 = MCACTD[139];
        MCACT15D1 = MCACTD[140];
        MCACT15D2 = MCACTD[141];
        MCACT15D3 = MCACTD[142];
        MCACT15D4 = MCACTD[143];
        MCACT15D5 = MCACTD[144];
        MCACT15D6 = MCACTD[145];
        MCACT15D7 = MCACTD[146];
        MCACT15D8 = MCACTD[147];
        MCACT15D9 = MCACTD[148];
        MCACT15D10 = MCACTD[149];
        MCACT16D1 = MCACTD[150];
        MCACT16D2 = MCACTD[151];
        MCACT16D3 = MCACTD[152];
        MCACT16D4 = MCACTD[153];
        MCACT16D5 = MCACTD[154];
        MCACT16D6 = MCACTD[155];
        MCACT16D7 = MCACTD[156];
        MCACT16D8 = MCACTD[157];
        MCACT16D9 = MCACTD[158];
        MCACT16D10 = MCACTD[159];
        MCACT17D1 = MCACTD[160];
        MCACT17D2 = MCACTD[161];
        MCACT17D3 = MCACTD[162];
        MCACT17D4 = MCACTD[163];
        MCACT17D5 = MCACTD[164];
        MCACT17D6 = MCACTD[165];
        MCACT17D7 = MCACTD[166];
        MCACT17D8 = MCACTD[167];
        MCACT17D9 = MCACTD[168];
        MCACT17D10 = MCACTD[169];
        MCACT18D1 = MCACTD[170];
        MCACT18D2 = MCACTD[171];
        MCACT18D3 = MCACTD[172];
        MCACT18D4 = MCACTD[173];
        MCACT18D5 = MCACTD[174];
        MCACT18D6 = MCACTD[175];
        MCACT18D7 = MCACTD[176];
        MCACT18D8 = MCACTD[177];
        MCACT18D9 = MCACTD[178];
        MCACT18D10 = MCACTD[179];
        MCACT19D1 = MCACTD[180];
        MCACT19D2 = MCACTD[181];
        MCACT19D3 = MCACTD[182];
        MCACT19D4 = MCACTD[183];
        MCACT19D5 = MCACTD[184];
        MCACT19D6 = MCACTD[185];
        MCACT19D7 = MCACTD[186];
        MCACT19D8 = MCACTD[187];
        MCACT19D9 = MCACTD[188];
        MCACT19D10 = MCACTD[189];
        MCACT20D1 = MCACTD[190];
        MCACT20D2 = MCACTD[191];
        MCACT20D3 = MCACTD[192];
        MCACT20D4 = MCACTD[193];
        MCACT20D5 = MCACTD[194];
        MCACT20D6 = MCACTD[195];
        MCACT20D7 = MCACTD[196];
        MCACT20D8 = MCACTD[197];
        MCACT20D9 = MCACTD[198];
        MCACT20D10 = MCACTD[199];
        MCACT21D1 = MCACTD[200];
        MCACT21D2 = MCACTD[201];
        MCACT21D3 = MCACTD[202];
        MCACT21D4 = MCACTD[203];
        MCACT21D5 = MCACTD[204];
        MCACT21D6 = MCACTD[205];
        MCACT21D7 = MCACTD[206];
        MCACT21D8 = MCACTD[207];
        MCACT21D9 = MCACTD[208];
        MCACT21D10 = MCACTD[209];
        MCACT22D1 = MCACTD[210];
        MCACT22D2 = MCACTD[211];
        MCACT22D3 = MCACTD[212];
        MCACT22D4 = MCACTD[213];
        MCACT22D5 = MCACTD[214];
        MCACT22D6 = MCACTD[215];
        MCACT22D7 = MCACTD[216];
        MCACT22D8 = MCACTD[217];
        MCACT22D9 = MCACTD[218];
        MCACT22D10 = MCACTD[219];
        MCACT23D1 = MCACTD[220];
        MCACT23D2 = MCACTD[221];
        MCACT23D3 = MCACTD[222];
        MCACT23D4 = MCACTD[223];
        MCACT23D5 = MCACTD[224];
        MCACT23D6 = MCACTD[225];
        MCACT23D7 = MCACTD[226];
        MCACT23D8 = MCACTD[227];
        MCACT23D9 = MCACTD[228];
        MCACT23D10 = MCACTD[229];
        MCACT24D1 = MCACTD[230];
        MCACT24D2 = MCACTD[231];
        MCACT24D3 = MCACTD[232];
        MCACT24D4 = MCACTD[233];
        MCACT24D5 = MCACTD[234];
        MCACT24D6 = MCACTD[235];
        MCACT24D7 = MCACTD[236];
        MCACT24D8 = MCACTD[237];
        MCACT24D9 = MCACTD[238];
        MCACT24D10 = MCACTD[239];
        MCACT25D1 = MCACTD[240];
        MCACT25D2 = MCACTD[241];
        MCACT25D3 = MCACTD[242];
        MCACT25D4 = MCACTD[243];
        MCACT25D5 = MCACTD[244];
        MCACT25D6 = MCACTD[245];
        MCACT25D7 = MCACTD[246];
        MCACT25D8 = MCACTD[247];
        MCACT25D9 = MCACTD[248];
        MCACT25D10 = MCACTD[249];
        MCACT26D1 = MCACTD[250];
        MCACT26D2 = MCACTD[251];
        MCACT26D3 = MCACTD[252];
        MCACT26D4 = MCACTD[253];
        MCACT26D5 = MCACTD[254];
        MCACT26D6 = MCACTD[255];
        MCACT26D7 = MCACTD[256];
        MCACT26D8 = MCACTD[257];
        MCACT26D9 = MCACTD[258];
        MCACT26D10 = MCACTD[259];
        MCACT27D1 = MCACTD[260];
        MCACT27D2 = MCACTD[261];
        MCACT27D3 = MCACTD[262];
        MCACT27D4 = MCACTD[263];
        MCACT27D5 = MCACTD[264];
        MCACT27D6 = MCACTD[265];
        MCACT27D7 = MCACTD[266];
        MCACT27D8 = MCACTD[267];
        MCACT27D9 = MCACTD[268];
        MCACT27D10 = MCACTD[269];
        MCACT28D1 = MCACTD[270];
        MCACT28D2 = MCACTD[271];
        MCACT28D3 = MCACTD[272];
        MCACT28D4 = MCACTD[273];
        MCACT28D5 = MCACTD[274];
        MCACT28D6 = MCACTD[275];
        MCACT28D7 = MCACTD[276];
        MCACT28D8 = MCACTD[277];
        MCACT28D9 = MCACTD[278];
        MCACT28D10 = MCACTD[279];
        MCACT29D1 = MCACTD[280];
        MCACT29D2 = MCACTD[281];
        MCACT29D3 = MCACTD[282];
        MCACT29D4 = MCACTD[283];
        MCACT29D5 = MCACTD[284];
        MCACT29D6 = MCACTD[285];
        MCACT29D7 = MCACTD[286];
        MCACT29D8 = MCACTD[287];
        MCACT29D9 = MCACTD[288];
        MCACT29D10 = MCACTD[289];
        MCACT30D1 = MCACTD[290];
        MCACT30D2 = MCACTD[291];
        MCACT30D3 = MCACTD[292];
        MCACT30D4 = MCACTD[293];
        MCACT30D5 = MCACTD[294];
        MCACT30D6 = MCACTD[295];
        MCACT30D7 = MCACTD[296];
        MCACT30D8 = MCACTD[297];
        MCACT30D9 = MCACTD[298];
        MCACT30D10 = MCACTD[299];
        MCACT31D1 = MCACTD[300];
        MCACT31D2 = MCACTD[301];
        MCACT31D3 = MCACTD[302];
        MCACT31D4 = MCACTD[303];
        MCACT31D5 = MCACTD[304];
        MCACT31D6 = MCACTD[305];
        MCACT31D7 = MCACTD[306];
        MCACT31D8 = MCACTD[307];
        MCACT31D9 = MCACTD[308];
        MCACT31D10 = MCACTD[309];



        MCACT1N1 = MCACTN[0];
        MCACT1N2 = MCACTN[1];
        MCACT1N3 = MCACTN[2];
        MCACT1N4 = MCACTN[3];
        MCACT1N5 = MCACTN[4];
        MCACT1N6 = MCACTN[5];
        MCACT1N7 = MCACTN[6];
        MCACT1N8 = MCACTN[7];
        MCACT1N9 = MCACTN[8];
        MCACT1N10 = MCACTN[9];
        MCACT2N1 = MCACTN[10];
        MCACT2N2 = MCACTN[11];
        MCACT2N3 = MCACTN[12];
        MCACT2N4 = MCACTN[13];
        MCACT2N5 = MCACTN[14];
        MCACT2N6 = MCACTN[15];
        MCACT2N7 = MCACTN[16];
        MCACT2N8 = MCACTN[17];
        MCACT2N9 = MCACTN[18];
        MCACT2N10 = MCACTN[19];
        MCACT3N1 = MCACTN[20];
        MCACT3N2 = MCACTN[21];
        MCACT3N3 = MCACTN[22];
        MCACT3N4 = MCACTN[23];
        MCACT3N5 = MCACTN[24];
        MCACT3N6 = MCACTN[25];
        MCACT3N7 = MCACTN[26];
        MCACT3N8 = MCACTN[27];
        MCACT3N9 = MCACTN[28];
        MCACT3N10 = MCACTN[29];
        MCACT4N1 = MCACTN[30];
        MCACT4N2 = MCACTN[31];
        MCACT4N3 = MCACTN[32];
        MCACT4N4 = MCACTN[33];
        MCACT4N5 = MCACTN[34];
        MCACT4N6 = MCACTN[35];
        MCACT4N7 = MCACTN[36];
        MCACT4N8 = MCACTN[37];
        MCACT4N9 = MCACTN[38];
        MCACT4N10 = MCACTN[39];
        MCACT5N1 = MCACTN[40];
        MCACT5N2 = MCACTN[41];
        MCACT5N3 = MCACTN[42];
        MCACT5N4 = MCACTN[43];
        MCACT5N5 = MCACTN[44];
        MCACT5N6 = MCACTN[45];
        MCACT5N7 = MCACTN[46];
        MCACT5N8 = MCACTN[47];
        MCACT5N9 = MCACTN[48];
        MCACT5N10 = MCACTN[49];
        MCACT6N1 = MCACTN[50];
        MCACT6N2 = MCACTN[51];
        MCACT6N3 = MCACTN[52];
        MCACT6N4 = MCACTN[53];
        MCACT6N5 = MCACTN[54];
        MCACT6N6 = MCACTN[55];
        MCACT6N7 = MCACTN[56];
        MCACT6N8 = MCACTN[57];
        MCACT6N9 = MCACTN[58];
        MCACT6N10 = MCACTN[59];
        MCACT7N1 = MCACTN[60];
        MCACT7N2 = MCACTN[61];
        MCACT7N3 = MCACTN[62];
        MCACT7N4 = MCACTN[63];
        MCACT7N5 = MCACTN[64];
        MCACT7N6 = MCACTN[65];
        MCACT7N7 = MCACTN[66];
        MCACT7N8 = MCACTN[67];
        MCACT7N9 = MCACTN[68];
        MCACT7N10 = MCACTN[69];
        MCACT8N1 = MCACTN[70];
        MCACT8N2 = MCACTN[71];
        MCACT8N3 = MCACTN[72];
        MCACT8N4 = MCACTN[73];
        MCACT8N5 = MCACTN[74];
        MCACT8N6 = MCACTN[75];
        MCACT8N7 = MCACTN[76];
        MCACT8N8 = MCACTN[77];
        MCACT8N9 = MCACTN[78];
        MCACT8N10 = MCACTN[79];
        MCACT9N1 = MCACTN[80];
        MCACT9N2 = MCACTN[81];
        MCACT9N3 = MCACTN[82];
        MCACT9N4 = MCACTN[83];
        MCACT9N5 = MCACTN[84];
        MCACT9N6 = MCACTN[85];
        MCACT9N7 = MCACTN[86];
        MCACT9N8 = MCACTN[87];
        MCACT9N9 = MCACTN[88];
        MCACT9N10 = MCACTN[89];
        MCACT10N1 = MCACTN[90];
        MCACT10N2 = MCACTN[91];
        MCACT10N3 = MCACTN[92];
        MCACT10N4 = MCACTN[93];
        MCACT10N5 = MCACTN[94];
        MCACT10N6 = MCACTN[95];
        MCACT10N7 = MCACTN[96];
        MCACT10N8 = MCACTN[97];
        MCACT10N9 = MCACTN[98];
        MCACT10N10 = MCACTN[99];
        MCACT11N1 = MCACTN[100];
        MCACT11N2 = MCACTN[101];
        MCACT11N3 = MCACTN[102];
        MCACT11N4 = MCACTN[103];
        MCACT11N5 = MCACTN[104];
        MCACT11N6 = MCACTN[105];
        MCACT11N7 = MCACTN[106];
        MCACT11N8 = MCACTN[107];
        MCACT11N9 = MCACTN[108];
        MCACT11N10 = MCACTN[109];
        MCACT12N1 = MCACTN[110];
        MCACT12N2 = MCACTN[111];
        MCACT12N3 = MCACTN[112];
        MCACT12N4 = MCACTN[113];
        MCACT12N5 = MCACTN[114];
        MCACT12N6 = MCACTN[115];
        MCACT12N7 = MCACTN[116];
        MCACT12N8 = MCACTN[117];
        MCACT12N9 = MCACTN[118];
        MCACT12N10 = MCACTN[119];
        MCACT13N1 = MCACTN[120];
        MCACT13N2 = MCACTN[121];
        MCACT13N3 = MCACTN[122];
        MCACT13N4 = MCACTN[123];
        MCACT13N5 = MCACTN[124];
        MCACT13N6 = MCACTN[125];
        MCACT13N7 = MCACTN[126];
        MCACT13N8 = MCACTN[127];
        MCACT13N9 = MCACTN[128];
        MCACT13N10 = MCACTN[129];
        MCACT14N1 = MCACTN[130];
        MCACT14N2 = MCACTN[131];
        MCACT14N3 = MCACTN[132];
        MCACT14N4 = MCACTN[133];
        MCACT14N5 = MCACTN[134];
        MCACT14N6 = MCACTN[135];
        MCACT14N7 = MCACTN[136];
        MCACT14N8 = MCACTN[137];
        MCACT14N9 = MCACTN[138];
        MCACT14N10 = MCACTN[139];
        MCACT15N1 = MCACTN[140];
        MCACT15N2 = MCACTN[141];
        MCACT15N3 = MCACTN[142];
        MCACT15N4 = MCACTN[143];
        MCACT15N5 = MCACTN[144];
        MCACT15N6 = MCACTN[145];
        MCACT15N7 = MCACTN[146];
        MCACT15N8 = MCACTN[147];
        MCACT15N9 = MCACTN[148];
        MCACT15N10 = MCACTN[149];
        MCACT16N1 = MCACTN[150];
        MCACT16N2 = MCACTN[151];
        MCACT16N3 = MCACTN[152];
        MCACT16N4 = MCACTN[153];
        MCACT16N5 = MCACTN[154];
        MCACT16N6 = MCACTN[155];
        MCACT16N7 = MCACTN[156];
        MCACT16N8 = MCACTN[157];
        MCACT16N9 = MCACTN[158];
        MCACT16N10 = MCACTN[159];
        MCACT17N1 = MCACTN[160];
        MCACT17N2 = MCACTN[161];
        MCACT17N3 = MCACTN[162];
        MCACT17N4 = MCACTN[163];
        MCACT17N5 = MCACTN[164];
        MCACT17N6 = MCACTN[165];
        MCACT17N7 = MCACTN[166];
        MCACT17N8 = MCACTN[167];
        MCACT17N9 = MCACTN[168];
        MCACT17N10 = MCACTN[169];
        MCACT18N1 = MCACTN[170];
        MCACT18N2 = MCACTN[171];
        MCACT18N3 = MCACTN[172];
        MCACT18N4 = MCACTN[173];
        MCACT18N5 = MCACTN[174];
        MCACT18N6 = MCACTN[175];
        MCACT18N7 = MCACTN[176];
        MCACT18N8 = MCACTN[177];
        MCACT18N9 = MCACTN[178];
        MCACT18N10 = MCACTN[179];
        MCACT19N1 = MCACTN[180];
        MCACT19N2 = MCACTN[181];
        MCACT19N3 = MCACTN[182];
        MCACT19N4 = MCACTN[183];
        MCACT19N5 = MCACTN[184];
        MCACT19N6 = MCACTN[185];
        MCACT19N7 = MCACTN[186];
        MCACT19N8 = MCACTN[187];
        MCACT19N9 = MCACTN[188];
        MCACT19N10 = MCACTN[189];
        MCACT20N1 = MCACTN[190];
        MCACT20N2 = MCACTN[191];
        MCACT20N3 = MCACTN[192];
        MCACT20N4 = MCACTN[193];
        MCACT20N5 = MCACTN[194];
        MCACT20N6 = MCACTN[195];
        MCACT20N7 = MCACTN[196];
        MCACT20N8 = MCACTN[197];
        MCACT20N9 = MCACTN[198];
        MCACT20N10 = MCACTN[199];
        MCACT21N1 = MCACTN[200];
        MCACT21N2 = MCACTN[201];
        MCACT21N3 = MCACTN[202];
        MCACT21N4 = MCACTN[203];
        MCACT21N5 = MCACTN[204];
        MCACT21N6 = MCACTN[205];
        MCACT21N7 = MCACTN[206];
        MCACT21N8 = MCACTN[207];
        MCACT21N9 = MCACTN[208];
        MCACT21N10 = MCACTN[209];
        MCACT22N1 = MCACTN[210];
        MCACT22N2 = MCACTN[211];
        MCACT22N3 = MCACTN[212];
        MCACT22N4 = MCACTN[213];
        MCACT22N5 = MCACTN[214];
        MCACT22N6 = MCACTN[215];
        MCACT22N7 = MCACTN[216];
        MCACT22N8 = MCACTN[217];
        MCACT22N9 = MCACTN[218];
        MCACT22N10 = MCACTN[219];
        MCACT23N1 = MCACTN[220];
        MCACT23N2 = MCACTN[221];
        MCACT23N3 = MCACTN[222];
        MCACT23N4 = MCACTN[223];
        MCACT23N5 = MCACTN[224];
        MCACT23N6 = MCACTN[225];
        MCACT23N7 = MCACTN[226];
        MCACT23N8 = MCACTN[227];
        MCACT23N9 = MCACTN[228];
        MCACT23N10 = MCACTN[229];
        MCACT24N1 = MCACTN[230];
        MCACT24N2 = MCACTN[231];
        MCACT24N3 = MCACTN[232];
        MCACT24N4 = MCACTN[233];
        MCACT24N5 = MCACTN[234];
        MCACT24N6 = MCACTN[235];
        MCACT24N7 = MCACTN[236];
        MCACT24N8 = MCACTN[237];
        MCACT24N9 = MCACTN[238];
        MCACT24N10 = MCACTN[239];
        MCACT25N1 = MCACTN[240];
        MCACT25N2 = MCACTN[241];
        MCACT25N3 = MCACTN[242];
        MCACT25N4 = MCACTN[243];
        MCACT25N5 = MCACTN[244];
        MCACT25N6 = MCACTN[245];
        MCACT25N7 = MCACTN[246];
        MCACT25N8 = MCACTN[247];
        MCACT25N9 = MCACTN[248];
        MCACT25N10 = MCACTN[249];
        MCACT26N1 = MCACTN[250];
        MCACT26N2 = MCACTN[251];
        MCACT26N3 = MCACTN[252];
        MCACT26N4 = MCACTN[253];
        MCACT26N5 = MCACTN[254];
        MCACT26N6 = MCACTN[255];
        MCACT26N7 = MCACTN[256];
        MCACT26N8 = MCACTN[257];
        MCACT26N9 = MCACTN[258];
        MCACT26N10 = MCACTN[259];
        MCACT27N1 = MCACTN[260];
        MCACT27N2 = MCACTN[261];
        MCACT27N3 = MCACTN[262];
        MCACT27N4 = MCACTN[263];
        MCACT27N5 = MCACTN[264];
        MCACT27N6 = MCACTN[265];
        MCACT27N7 = MCACTN[266];
        MCACT27N8 = MCACTN[267];
        MCACT27N9 = MCACTN[268];
        MCACT27N10 = MCACTN[269];
        MCACT28N1 = MCACTN[270];
        MCACT28N2 = MCACTN[271];
        MCACT28N3 = MCACTN[272];
        MCACT28N4 = MCACTN[273];
        MCACT28N5 = MCACTN[274];
        MCACT28N6 = MCACTN[275];
        MCACT28N7 = MCACTN[276];
        MCACT28N8 = MCACTN[277];
        MCACT28N9 = MCACTN[278];
        MCACT28N10 = MCACTN[279];
        MCACT29N1 = MCACTN[280];
        MCACT29N2 = MCACTN[281];
        MCACT29N3 = MCACTN[282];
        MCACT29N4 = MCACTN[283];
        MCACT29N5 = MCACTN[284];
        MCACT29N6 = MCACTN[285];
        MCACT29N7 = MCACTN[286];
        MCACT29N8 = MCACTN[287];
        MCACT29N9 = MCACTN[288];
        MCACT29N10 = MCACTN[289];
        MCACT30N1 = MCACTN[290];
        MCACT30N2 = MCACTN[291];
        MCACT30N3 = MCACTN[292];
        MCACT30N4 = MCACTN[293];
        MCACT30N5 = MCACTN[294];
        MCACT30N6 = MCACTN[295];
        MCACT30N7 = MCACTN[296];
        MCACT30N8 = MCACTN[297];
        MCACT30N9 = MCACTN[298];
        MCACT30N10 = MCACTN[299];
        MCACT31N1 = MCACTN[300];
        MCACT31N2 = MCACTN[301];
        MCACT31N3 = MCACTN[302];
        MCACT31N4 = MCACTN[303];
        MCACT31N5 = MCACTN[304];
        MCACT31N6 = MCACTN[305];
        MCACT31N7 = MCACTN[306];
        MCACT31N8 = MCACTN[307];
        MCACT31N9 = MCACTN[308];
        MCACT31N10 = MCACTN[309];




        ReqD1 = ReqDay[0];
        ReqD2 = ReqDay[1];
        ReqD3 = ReqDay[2];
        ReqD4 = ReqDay[3];
        ReqD5 = ReqDay[4];
        ReqD6 = ReqDay[5];
        ReqD7 = ReqDay[6];
        ReqD8 = ReqDay[7];
        ReqD9 = ReqDay[8];
        ReqD10 = ReqDay[9];
        ReqD11 = ReqDay[10];
        ReqD12 = ReqDay[11];
        ReqD13 = ReqDay[12];
        ReqD14 = ReqDay[13];
        ReqD15 = ReqDay[14];
        ReqD16 = ReqDay[15];
        ReqD17 = ReqDay[16];
        ReqD18 = ReqDay[17];
        ReqD19 = ReqDay[18];
        ReqD20 = ReqDay[19];
        ReqD21 = ReqDay[20];
        ReqD22 = ReqDay[21];
        ReqD23 = ReqDay[22];
        ReqD24 = ReqDay[23];
        ReqD25 = ReqDay[24];
        ReqD26 = ReqDay[25];
        ReqD27 = ReqDay[26];
        ReqD28 = ReqDay[27];
        ReqD29 = ReqDay[28];
        ReqD30 = ReqDay[29];
        ReqD31 = ReqDay[30];

        ActD1 = ACTD[0];
        ActD2 = ACTD[1];
        ActD3 = ACTD[2];
        ActD4 = ACTD[3];
        ActD5 = ACTD[4];
        ActD6 = ACTD[5];
        ActD7 = ACTD[6];
        ActD8 = ACTD[7];
        ActD9 = ACTD[8];
        ActD10 = ACTD[9];
        ActD11 = ACTD[10];
        ActD12 = ACTD[11];
        ActD13 = ACTD[12];
        ActD14 = ACTD[13];
        ActD15 = ACTD[14];
        ActD16 = ACTD[15];
        ActD17 = ACTD[16];
        ActD18 = ACTD[17];
        ActD19 = ACTD[18];
        ActD20 = ACTD[19];
        ActD21 = ACTD[20];
        ActD22 = ACTD[21];
        ActD23 = ACTD[22];
        ActD24 = ACTD[23];
        ActD25 = ACTD[24];
        ActD26 = ACTD[25];
        ActD27 = ACTD[26];
        ActD28 = ACTD[27];
        ActD29 = ACTD[28];
        ActD30 = ACTD[29];
        ActD31 = ACTD[30];

        DiffD1 = DiffDay[0];
        DiffD2 = DiffDay[1];
        DiffD3 = DiffDay[2];
        DiffD4 = DiffDay[3];
        DiffD5 = DiffDay[4];
        DiffD6 = DiffDay[5];
        DiffD7 = DiffDay[6];
        DiffD8 = DiffDay[7];
        DiffD9 = DiffDay[8];
        DiffD10 = DiffDay[9];
        DiffD11 = DiffDay[10];
        DiffD12 = DiffDay[11];
        DiffD13 = DiffDay[12];
        DiffD14 = DiffDay[13];
        DiffD15 = DiffDay[14];
        DiffD16 = DiffDay[15];
        DiffD17 = DiffDay[16];
        DiffD18 = DiffDay[17];
        DiffD19 = DiffDay[18];
        DiffD20 = DiffDay[19];
        DiffD21 = DiffDay[20];
        DiffD22 = DiffDay[21];
        DiffD23 = DiffDay[22];
        DiffD24 = DiffDay[23];
        DiffD25 = DiffDay[24];
        DiffD26 = DiffDay[25];
        DiffD27 = DiffDay[26];
        DiffD28 = DiffDay[27];
        DiffD29 = DiffDay[28];
        DiffD30 = DiffDay[29];
        DiffD31 = DiffDay[30];


        ReqN1 = ReqNight[0];
        ReqN2 = ReqNight[1];
        ReqN3 = ReqNight[2];
        ReqN4 = ReqNight[3];
        ReqN5 = ReqNight[4];
        ReqN6 = ReqNight[5];
        ReqN7 = ReqNight[6];
        ReqN8 = ReqNight[7];
        ReqN9 = ReqNight[8];
        ReqN10 = ReqNight[9];
        ReqN11 = ReqNight[10];
        ReqN12 = ReqNight[11];
        ReqN13 = ReqNight[12];
        ReqN14 = ReqNight[13];
        ReqN15 = ReqNight[14];
        ReqN16 = ReqNight[15];
        ReqN17 = ReqNight[16];
        ReqN18 = ReqNight[17];
        ReqN19 = ReqNight[18];
        ReqN20 = ReqNight[19];
        ReqN21 = ReqNight[20];
        ReqN22 = ReqNight[21];
        ReqN23 = ReqNight[22];
        ReqN24 = ReqNight[23];
        ReqN25 = ReqNight[24];
        ReqN26 = ReqNight[25];
        ReqN27 = ReqNight[26];
        ReqN28 = ReqNight[27];
        ReqN29 = ReqNight[28];
        ReqN30 = ReqNight[29];
        ReqN31 = ReqNight[30];

        ActN1 = ACTN[0];
        ActN2 = ACTN[1];
        ActN3 = ACTN[2];
        ActN4 = ACTN[3];
        ActN5 = ACTN[4];
        ActN6 = ACTN[5];
        ActN7 = ACTN[6];
        ActN8 = ACTN[7];
        ActN9 = ACTN[8];
        ActN10 = ACTN[9];
        ActN11 = ACTN[10];
        ActN12 = ACTN[11];
        ActN13 = ACTN[12];
        ActN14 = ACTN[13];
        ActN15 = ACTN[14];
        ActN16 = ACTN[15];
        ActN17 = ACTN[16];
        ActN18 = ACTN[17];
        ActN19 = ACTN[18];
        ActN20 = ACTN[19];
        ActN21 = ACTN[20];
        ActN22 = ACTN[21];
        ActN23 = ACTN[22];
        ActN24 = ACTN[23];
        ActN25 = ACTN[24];
        ActN26 = ACTN[25];
        ActN27 = ACTN[26];
        ActN28 = ACTN[27];
        ActN29 = ACTN[28];
        ActN30 = ACTN[29];
        ActN31 = ACTN[30];


        DiffN1 = DiffNight[0];
        DiffN2 = DiffNight[1];
        DiffN3 = DiffNight[2];
        DiffN4 = DiffNight[3];
        DiffN5 = DiffNight[4];
        DiffN6 = DiffNight[5];
        DiffN7 = DiffNight[6];
        DiffN8 = DiffNight[7];
        DiffN9 = DiffNight[8];
        DiffN10 = DiffNight[9];
        DiffN11 = DiffNight[10];
        DiffN12 = DiffNight[11];
        DiffN13 = DiffNight[12];
        DiffN14 = DiffNight[13];
        DiffN15 = DiffNight[14];
        DiffN16 = DiffNight[15];
        DiffN17 = DiffNight[16];
        DiffN18 = DiffNight[17];
        DiffN19 = DiffNight[18];
        DiffN20 = DiffNight[19];
        DiffN21 = DiffNight[20];
        DiffN22 = DiffNight[21];
        DiffN23 = DiffNight[22];
        DiffN24 = DiffNight[23];
        DiffN25 = DiffNight[24];
        DiffN26 = DiffNight[25];
        DiffN27 = DiffNight[26];
        DiffN28 = DiffNight[27];
        DiffN29 = DiffNight[28];
        DiffN30 = DiffNight[29];
        DiffN31 = DiffNight[30];

        //  var testValue = ReqD1;


        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column', backgroundColor: '#F2F2F2',
                //backgroundColor: {
                //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                //    stops: [
                //         [0, '#098996'],
                //              [1, '#054C54']
                //       //[0, '#FBFBD4'],
                //       //       [1, '#C7C6A1']
                //    ]
                //},
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '##581845',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                //categories: DayTOO,

                type: 'category',
                // categories: 'Browsers',
                // categories: Dayto,
                labels: {
                    style: {
                        color: '##581845',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [{
                className: 'highcharts-color-0',
                title: {

                    text: 'Employee',
                    style: {
                        color: '##581845',
                        fontWeight: 'bold'
                    }
                },
                labels: {
                    format: '{value:,.0f}.',
                    style: {
                        color: '##581845',
                        fontSize: '10px'
                    }
                },
                max: 150,
                min: 0,

                //stackLabels: {
                //    enabled: false,
                //    style: {
                //        fontWeight: 'bold',
                //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                //    }
                //}


            }
            //, {

            //    title: {
            //        text: 'Diff'
            //    },
            //    max: 120,
            //    min: -120,
            //    opposite: false
            //}
            ],

            legend: {
                align: 'right',
                x: -10,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            //legend: {
            //    shadow: false
            //},
            tooltip: {
                shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    //borderWidth: 0,
                    //pointPadding: 0.2,
                    //borderWidth: 0

                }
            },

            series: [{
                name: "Day",
                colorByPoint: true,
                //pointPadding: 1.0,
                pointWidth: 15,
                pointPlacement: -0.3,
                data: [{
                    name: "1",
                    y: ReqD1[0],
                    drilldown: "D1",
                    color: '#E59866',
                    borderColor: '#E59866',

                },
                  {
                      name: "2",
                      y: ReqD2[0],
                      drilldown: "D2",
                      color: '#E59866',
                      borderColor: '#E59866',

                  },
                  {
                      name: "3",
                      y: ReqD3[0],
                      drilldown: "D3",
                      color: '#E59866',
                      borderColor: '#E59866',

                  },
                  {
                      name: "4",
                      y: ReqD4[0],
                      drilldown: "D4",
                      color: '#E59866',
                      borderColor: '#E59866',

                  },
                  {
                      name: "5",
                      y: ReqD5[0],
                      drilldown: "D5",
                      color: '#E59866',
                      borderColor: '#E59866',

                  },
                  {
                      name: "6",
                      y: ReqD6[0],
                      drilldown: "D6",
                      color: '#E59866',
                      borderColor: '#E59866',

                  },
                  {
                      name: "7",
                      y: ReqD7[0],
                      drilldown: "D7",
                      color: '#E59866',
                      borderColor: '#E59866',

                  },
                   {
                       name: "8",
                       y: ReqD8[0],
                       drilldown: "D8",
                       color: '#E59866',
                       borderColor: '#E59866',

                   },
                   {
                       name: "9",
                       y: ReqD9[0],
                       drilldown: "D9",
                       color: '#E59866',
                       borderColor: '#E59866',

                   },
                  {
                      name: "10",
                      y: ReqD10[0],
                      drilldown: "D10",
                      color: '#E59866',
                      borderColor: '#E59866',

                  },
                    {
                        name: "11",
                        y: ReqD11[0],
                        drilldown: "D11",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "12",
                        y: ReqD12[0],
                        drilldown: "D12",
                        color: '#E59866',
                        borderColor: '#E59866',
                    },
                    {
                        name: "13",
                        y: ReqD13[0],
                        drilldown: "D13",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "14",
                        y: ReqD14[0],
                        drilldown: "D14",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "15",
                        y: ReqD15[0],
                        drilldown: "D15",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "16",
                        y: ReqD16[0],
                        drilldown: "D16",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "17",
                        y: ReqD17[0],
                        drilldown: "D17",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "18",
                        y: ReqD18[0],
                        drilldown: "D18",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "19",
                        y: ReqD19[0],
                        drilldown: "D19",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "20",
                        y: ReqD20[0],
                        drilldown: "D20",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "21",
                        y: ReqD21[0],
                        drilldown: "D21",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "22",
                        y: ReqD22[0],
                        drilldown: "D22",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "23",
                        y: ReqD23[0],
                        drilldown: "D23",
                        color: '#E59866',
                        borderColor: '#E59866',

                    },
                    {
                        name: "24",
                        y: ReqD24[0],
                        drilldown: "D24",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "25",
                        y: ReqD25[0],
                        drilldown: "D25",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "26",
                        y: ReqD26[0],
                        drilldown: "D26",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "27",
                        y: ReqD27[0],
                        drilldown: "D27",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "28",
                        y: ReqD28[0],
                        drilldown: "D28",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "29",
                        y: ReqD29[0],
                        drilldown: "D29",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "30",
                        y: ReqD30[0],
                        drilldown: "D30",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }, {
                        name: "31",
                        y: ReqD31[0],
                        drilldown: "D31",
                        color: '#E59866',
                        borderColor: '#E59866',

                    }]

            }, {
                name: "ActDay",
                colorByPoint: true,
                //pointPadding: 1.0,
                pointWidth: 5,
                pointPlacement: -0.3,
                data: [{
                    name: "1",
                    y: ActD1[0],
                    drilldown: "D1",
                    color: '#FC1801',
                    borderColor: '#FC1801',
                }, {
                    name: "2",
                    y: ActD2[0],
                    drilldown: "D2",
                    color: '#FC1801',
                    borderColor: '#FC1801',
                }, {
                    name: "3",
                    y: ActD3[0],
                    drilldown: "D3",
                    color: '#FC1801',
                    borderColor: '#FC1801',
                }, {
                    name: "4",
                    y: ActD4[0],
                    drilldown: "D4",
                    color: '#FC1801',
                    borderColor: '#FC1801',
                }, {
                    name: "5",
                    y: ActD5[0],
                    drilldown: "D5",
                    color: '#FC1801',
                    borderColor: '#FC1801',
                },
                {
                    name: "6", y: ActD6[0],
                    drilldown: "D6",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "7", y: ActD7[0], drilldown: "D7",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "8", y: ActD8[0], drilldown: "D8",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "9", y: ActD9[0], drilldown: "D9",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "10", y: ActD10[0], drilldown: "D10",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "11", y: ActD11[0], drilldown: "D11",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "12", y: ActD12[0], drilldown: "D12",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "13", y: ActD13[0],
                    drilldown: "D13",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "14", y: ActD14[0],
                    drilldown: "D14",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "15", y: ActD15[0],
                    drilldown: "D15",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "16", y: ActD16[0], drilldown: "D16",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "17", y: ActD17[0], drilldown: "D17",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "18", y: ActD18[0], drilldown: "D18",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "19", y: ActD19[0], drilldown: "D19",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "20", y: ActD20[0], drilldown: "D20",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "21", y: ActD21[0], drilldown: "D21",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "22", y: ActD22[0], drilldown: "D22",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "23", y: ActD23[0], drilldown: "D23",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "24", y: ActD24[0], drilldown: "D24",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "25", y: ActD25[0], drilldown: "D25",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "26", y: ActD26[0], drilldown: "D26",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "27", y: ActD27[0], drilldown: "D27",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "28", y: ActD28[0], drilldown: "D28",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "29", y: ActD29[0], drilldown: "D29",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "30", y: ActD30[0], drilldown: "D30",
                    color: '#FC1801', borderColor: '#FC1801',
                },
                {
                    name: "31", y: ActD31[0], drilldown: "D31",
                    color: '#FC1801', borderColor: '#FC1801',
                }]
            },
         {
             name: "Night",
             colorByPoint: true,

             pointWidth: 15,
             pointPlacement: 0.2,
             data: [{
                 name: "1",
                 y: ReqN1[0],
                 drilldown: "N1",
                 color: '#5B2C6F',
                 borderColor: '#5B2C6F',

             },
               {
                   name: "2",
                   y: ReqN2[0],
                   drilldown: "N2",
                   color: '#5B2C6F',
                   borderColor: '#5B2C6F',
               },
               {
                   name: "3",
                   y: ReqN3[0],
                   drilldown: "N3",
                   color: '#5B2C6F',
                   borderColor: '#5B2C6F',
               },
               {
                   name: "4",
                   y: ReqN4[0],
                   drilldown: "N4",
                   color: '#5B2C6F',
                   borderColor: '#5B2C6F',
               },
               {
                   name: "5",
                   y: ReqN5[0],
                   drilldown: "N5",
                   color: '#5B2C6F',
                   borderColor: '#5B2C6F',
               },
               {
                   name: "6",
                   y: ReqN6[0],
                   drilldown: "N6",
                   color: '#5B2C6F',
                   borderColor: '#5B2C6F',
               },
                  {
                      name: "7",
                      y: ReqN7[0],
                      drilldown: "N7",
                      color: '#5B2C6F',
                      borderColor: '#5B2C6F',
                  },
                {
                    name: "8",
                    y: ReqN8[0],
                    drilldown: "N8",
                    color: '#5B2C6F',
                    borderColor: '#5B2C6F',
                },
                {
                    name: "9",
                    y: ReqN9[0],
                    drilldown: "N9",
                    color: '#5B2C6F',
                    borderColor: '#5B2C6F',
                },
               {
                   name: "10",
                   y: ReqN10[0],
                   drilldown: "N10",
                   color: '#5B2C6F',
                   borderColor: '#5B2C6F',
               },

                 {
                     name: "11",
                     y: ReqN11[0],
                     drilldown: "N11",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',

                 },
                    {
                        name: "12",
                        y: ReqN12[0],
                        drilldown: "N12",
                        color: '#5B2C6F',
                        borderColor: '#5B2C6F',

                    },
                 {
                     name: "13",
                     y: ReqN13[0],
                     drilldown: "N13",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "14",
                     y: ReqN14[0],
                     drilldown: "N14",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "15",
                     y: ReqN15[0],
                     drilldown: "N15",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "16",
                     y: ReqN16[0],
                     drilldown: "N16",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "17",
                     y: ReqN17[0],
                     drilldown: "N17",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "18",
                     y: ReqN18[0],
                     drilldown: "N18",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "19",
                     y: ReqN19[0],
                     drilldown: "N19",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "20",
                     y: ReqN20[0],
                     drilldown: "N20",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "21",
                     y: ReqN21[0],
                     drilldown: "N21",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "22",
                     y: ReqN22[0],
                     drilldown: "N22",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "23",
                     y: ReqN23[0],
                     drilldown: "N23",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 },
                 {
                     name: "24",
                     y: ReqN24[0],
                     drilldown: "N24",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "25",
                     y: ReqN25[0],
                     drilldown: "N25",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "26",
                     y: ReqN26[0],
                     drilldown: "N26",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "27",
                     y: ReqN27[0],
                     drilldown: "N27",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "28",
                     y: ReqN28[0],
                     drilldown: "N28",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "29",
                     y: ReqN29[0],
                     drilldown: "N29",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "30",
                     y: ReqN30[0],
                     drilldown: "N30",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }, {
                     name: "31",
                     y: ReqN31[0],
                     drilldown: "N31",
                     color: '#5B2C6F',
                     borderColor: '#5B2C6F',
                 }]
         }, {
             name: "ActNight",
             colorByPoint: true,
             //pointPadding: 1.0,
             pointWidth: 5,
             pointPlacement: 0.2,
             data: [{
                 name: "1",
                 y: ActN1[0],
                 drilldown: "N1",
                 color: '#FC1801',
                 borderColor: '#FC1801',
             }, {
                 name: "2",
                 y: ActN2[0],
                 drilldown: "N2",
                 color: '#FC1801',
                 borderColor: '#FC1801',
             }, {
                 name: "3",
                 y: ActN3[0],
                 drilldown: "N3",
                 color: '#FC1801',
                 borderColor: '#FC1801',
             }, {
                 name: "4",
                 y: ActN4[0],
                 drilldown: "N4",
                 color: '#FC1801',
                 borderColor: '#FC1801',
             }, {
                 name: "5",
                 y: ActN5[0],
                 drilldown: "N5",
                 color: '#FC1801',
                 borderColor: '#FC1801',
             },
             {
                 name: "6", y: ActN6[0],
                 drilldown: "N6",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "7", y: ActN7[0], drilldown: "N7",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "8", y: ActN8[0], drilldown: "N8",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "9", y: ActN9[0], drilldown: "N9",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "10", y: ActN10[0], drilldown: "N10",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "11", y: ActN11[0], drilldown: "N11",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "12", y: ActN12[0], drilldown: "N12",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "13", y: ActN13[0],
                 drilldown: "N13",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "14", y: ActN14[0],
                 drilldown: "N14",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "15", y: ActN15[0], drilldown: "N15",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "16", y: ActN16[0], drilldown: "N16",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "17", y: ActN17[0], drilldown: "N17",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "18", y: ActN18[0], drilldown: "N18",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "19", y: ActN19[0], drilldown: "N19",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "20", y: ActN20[0], drilldown: "N20",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "21", y: ActN21[0], drilldown: "N21",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "22", y: ActN22[0], drilldown: "N22",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "23", y: ActN23[0], drilldown: "N23",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "24", y: ActN24[0], drilldown: "N24",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "25", y: ActN25[0], drilldown: "N25",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "26", y: ActN26[0], drilldown: "N26",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "27", y: ActN27[0], drilldown: "N27",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "28", y: ActN28[0], drilldown: "N28",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "29", y: ActN29[0], drilldown: "N29",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "30", y: ActN30[0], drilldown: "N30",
                 color: '#FC1801', borderColor: '#FC1801',
             },
             {
                 name: "31", y: ActN31[0], drilldown: "N31",
                 color: '#FC1801', borderColor: '#FC1801',
             }],
             //}, {
             //    //type: 'line',
             //    name: "DiffDay",
             //    yAxis: 1,
             //    colorByPoint: true,
             //    //pointPadding: 1.0,
             //    pointWidth: 10,
             //    pointPlacement: -0.3,
             //    type: 'Line',
             //    data: [{
             //        name: "1",
             //        y: DiffD1[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "2",
             //        y: DiffD2[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "3",
             //        y: DiffD3[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "4",
             //        y: DiffD4[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "5",
             //        y: DiffD5[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    },
             //    {
             //        name: "6", y: DiffD6[0],
             //        drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "7", y: DiffD7[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "8", y: DiffD8[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "9", y: DiffD9[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "10", y: DiffD10[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "11", y: DiffD11[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "12", y: DiffD12[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "13", y: DiffD13[0],
             //        drilldown: "D13",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "14", y: DiffD14[0],
             //        drilldown: "D14",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "15", y: DiffD15[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "16", y: DiffD16[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "17", y: DiffD17[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "18", y: DiffD18[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "19", y: DiffD19[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "20", y: DiffD20[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "21", y: DiffD21[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "22", y: DiffD22[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "23", y: DiffD23[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "24", y: DiffD24[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "25", y: DiffD25[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "26", y: DiffD26[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "27", y: DiffD27[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "28", y: DiffD28[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "29", y: DiffD29[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "30", y: DiffD30[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "31", y: DiffD31[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    }],
             //    dataLabels: {
             //        enabled: true,
             //        formatter: function () {
             //            return Highcharts.numberFormat(this.y, 0);
             //        }
             //    },

             //}, {
             //    type: 'line',
             //    name: "DiffNight",
             //    yAxis: 1,
             //    colorByPoint: true,
             //    //pointPadding: 1.0,
             //    pointWidth: 10,
             //    pointPlacement: -0.3,
             //    data: [{
             //        name: "1",
             //        y: DiffN1[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "2",
             //        y: DiffN2[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "3",
             //        y: DiffN3[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "4",
             //        y: DiffN4[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    }, {
             //        name: "5",
             //        y: DiffN5[0],
             //        drilldown: null,
             //        color: '#FC1801',
             //        borderColor: '#FC1801',
             //    },
             //    {
             //        name: "6", y: DiffN6[0],
             //        drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "7", y: DiffN7[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "8", y: DiffN8[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "9", y: DiffN9[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "10", y: DiffN10[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "11", y: DiffN11[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "12", y: DiffN12[0], drilldown: null,
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "13", y: DiffN13[0],
             //        drilldown: "D13",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "14", y: DiffN14[0],
             //        drilldown: "D14",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "15", y: DiffN15[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "16", y: DiffN16[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "17", y: DiffN17[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "18", y: DiffN18[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "19", y: DiffN19[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "20", y: DiffN20[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "21", y: DiffN21[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "22", y: DiffN22[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "23", y: DiffN23[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "24", y: DiffN24[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "25", y: DiffN25[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "26", y: DiffN26[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "27", y: DiffN27[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "28", y: DiffN28[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "29", y: DiffN29[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "30", y: DiffN30[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    },
             //    {
             //        name: "31", y: DiffN31[0],// drilldown: "A1",
             //        color: '#FC1801', borderColor: '#FC1801',
             //    }]
         }],
            drilldown: {
                series: [
                  {
                      name: "1",
                      id: "D1",
                      data: [
                           [
                         "PI",
                         15,
                         // MCACT1D9[0],
                          12,

                           ],
                              [
                       "FH",
                         MCACT1D5[0]

                              ],
                                [
                          "CS",
                            MCACT1D3[0]

                                ],
                                   [
                         "CY",
                           MCACT1D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT1D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT1D8[0]

                                       ],
 [
                          "CP",
                            MCACT1D2[0]

 ],
                                     [
                         "MA",
                             MCACT1D7[0]

                                     ],
                        [
                            "AS",

                       MCACT1D1[0]

                        ],
                         [
                       "FIN",
                            MCACT1D6[0]

                         ],
                      ]
                  },
                  {
                      name: "1",
                      id: "N1",
                      data: [
                            [
                          "PI",
                           MCACT1N9[0]

                            ],
                               [
                        "FH",
                          MCACT1N5[0]

                               ],
                                 [
                           "CS",
                             MCACT1N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT1N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT1N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT1N8[0]

                                        ],
  [
                           "CP",
                             MCACT1N2[0]

  ],
                                      [
                          "MA",
                              MCACT1N7[0]

                                      ],
                         [
                             "AS",

                        MCACT1N1[0]

                         ],
                          [
                        "FIN",
                             MCACT1N6[0]

                          ],
                      ]
                  }, {
                      name: "2",
                      id: "D2",
                      data: [
                           [
                         "PI",
                          MCACT2D9[0]

                           ],
                              [
                       "FH",
                         MCACT2D5[0]

                              ],
                                [
                          "CS",
                            MCACT2D3[0]

                                ],
                                   [
                         "CY",
                           MCACT2D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT2D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT2D8[0]

                                       ],
 [
                          "CP",
                            MCACT2D2[0]

 ],
                                     [
                         "MA",
                             MCACT2D7[0]

                                     ],
                        [
                            "AS",

                       MCACT2D1[0]

                        ],
                         [
                       "FIN",
                            MCACT2D6[0]

                         ],
                      ]
                  },
                  {
                      name: "2",
                      id: "N2",
                      data: [
                            [
                          "PI",
                           MCACT2N9[0]

                            ],
                               [
                        "FH",
                          MCACT2N5[0]

                               ],
                                 [
                           "CS",
                             MCACT2N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT2N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT2N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT2N8[0]

                                        ],
  [
                           "CP",
                             MCACT2N2[0]

  ],
                                      [
                          "MA",
                              MCACT2N7[0]

                                      ],
                         [
                             "AS",

                        MCACT2N1[0]

                         ],
                          [
                        "FIN",
                             MCACT2N6[0]

                          ],
                      ]
                  }, {
                      name: "3",
                      id: "D3",
                      data: [
                           [
                         "PI",
                          MCACT3D9[0]

                           ],
                              [
                       "FH",
                         MCACT3D5[0]

                              ],
                                [
                          "CS",
                            MCACT3D3[0]

                                ],
                                   [
                         "CY",
                           MCACT3D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT3D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT3D8[0]

                                       ],
 [
                          "CP",
                            MCACT3D2[0]

 ],
                                     [
                         "MA",
                             MCACT3D7[0]

                                     ],
                        [
                            "AS",

                       MCACT3D1[0]

                        ],
                         [
                       "FIN",
                            MCACT3D6[0]

                         ],
                      ]
                  },
                  {
                      name: "3",
                      id: "N3",
                      data: [
                            [
                          "PI",
                           MCACT3N9[0]

                            ],
                               [
                        "FH",
                          MCACT3N5[0]

                               ],
                                 [
                           "CS",
                             MCACT3N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT3N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT3N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT3N8[0]

                                        ],
  [
                           "CP",
                             MCACT3N2[0]

  ],
                                      [
                          "MA",
                              MCACT3N7[0]

                                      ],
                         [
                             "AS",

                        MCACT3N1[0]

                         ],
                          [
                        "FIN",
                             MCACT3N6[0]

                          ],
                      ]
                  }, {
                      name: "4",
                      id: "D4",
                      data: [
                           [
                         "PI",
                          MCACT4D9[0]

                           ],
                              [
                       "FH",
                         MCACT4D5[0]

                              ],
                                [
                          "CS",
                            MCACT4D3[0]

                                ],
                                   [
                         "CY",
                           MCACT4D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT4D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT4D8[0]

                                       ],
 [
                          "CP",
                            MCACT4D2[0]

 ],
                                     [
                         "MA",
                             MCACT4D7[0]

                                     ],
                        [
                            "AS",

                       MCACT4D1[0]

                        ],
                         [
                       "FIN",
                            MCACT4D6[0]

                         ],
                      ]
                  },
                  {
                      name: "4",
                      id: "N4",
                      data: [
                            [
                          "PI",
                           MCACT4N9[0]

                            ],
                               [
                        "FH",
                          MCACT4N5[0]

                               ],
                                 [
                           "CS",
                             MCACT4N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT4N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT4N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT4N8[0]

                                        ],
  [
                           "CP",
                             MCACT4N2[0]

  ],
                                      [
                          "MA",
                              MCACT4N7[0]

                                      ],
                         [
                             "AS",

                        MCACT4N1[0]

                         ],
                          [
                        "FIN",
                             MCACT4N6[0]

                          ],
                      ]
                  }, {
                      name: "5",
                      id: "D5",
                      data: [
                           [
                         "PI",
                          MCACT5D9[0]

                           ],
                              [
                       "FH",
                         MCACT5D5[0]

                              ],
                                [
                          "CS",
                            MCACT5D3[0]

                                ],
                                   [
                         "CY",
                           MCACT5D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT5D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT5D8[0]

                                       ],
 [
                          "CP",
                            MCACT5D2[0]

 ],
                                     [
                         "MA",
                             MCACT5D7[0]

                                     ],
                        [
                            "AS",

                       MCACT5D1[0]

                        ],
                         [
                       "FIN",
                            MCACT5D6[0]

                         ],
                      ]
                  },
                  {
                      name: "5",
                      id: "N5",
                      data: [
                            [
                          "PI",
                           MCACT5N9[0]

                            ],
                               [
                        "FH",
                          MCACT5N5[0]

                               ],
                                 [
                           "CS",
                             MCACT5N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT5N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT5N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT5N8[0]

                                        ],
  [
                           "CP",
                             MCACT5N2[0]

  ],
                                      [
                          "MA",
                              MCACT5N7[0]

                                      ],
                         [
                             "AS",

                        MCACT5N1[0]

                         ],
                          [
                        "FIN",
                             MCACT5N6[0]

                          ],
                      ]
                  }, {
                      name: "6",
                      id: "D6",
                      data: [
                           [
                         "PI",
                          MCACT6D9[0]

                           ],
                              [
                       "FH",
                         MCACT6D5[0]

                              ],
                                [
                          "CS",
                            MCACT6D3[0]

                                ],
                                   [
                         "CY",
                           MCACT6D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT6D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT6D8[0]

                                       ],
 [
                          "CP",
                            MCACT6D2[0]

 ],
                                     [
                         "MA",
                             MCACT6D7[0]

                                     ],
                        [
                            "AS",

                       MCACT6D1[0]

                        ],
                         [
                       "FIN",
                            MCACT6D6[0]

                         ],
                      ]
                  },
                  {
                      name: "6",
                      id: "N6",
                      data: [
                            [
                          "PI",
                           MCACT6N9[0]

                            ],
                               [
                        "FH",
                          MCACT6N5[0]

                               ],
                                 [
                           "CS",
                             MCACT6N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT6N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT6N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT6N8[0]

                                        ],
  [
                           "CP",
                             MCACT6N2[0]

  ],
                                      [
                          "MA",
                              MCACT6N7[0]

                                      ],
                         [
                             "AS",

                        MCACT6N1[0]

                         ],
                          [
                        "FIN",
                             MCACT6N6[0]

                          ],
                      ]
                  }, {
                      name: "7",
                      id: "D7",
                      data: [
                           [
                         "PI",
                          MCACT7D9[0]

                           ],
                              [
                       "FH",
                         MCACT7D5[0]

                              ],
                                [
                          "CS",
                            MCACT7D3[0]

                                ],
                                   [
                         "CY",
                           MCACT7D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT7D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT7D8[0]

                                       ],
 [
                          "CP",
                            MCACT7D2[0]

 ],
                                     [
                         "MA",
                             MCACT7D7[0]

                                     ],
                        [
                            "AS",

                       MCACT7D1[0]

                        ],
                         [
                       "FIN",
                            MCACT7D6[0]

                         ],
                      ]
                  },
                  {
                      name: "7",
                      id: "N7",
                      data: [
                            [
                          "PI",
                           MCACT7N9[0]

                            ],
                               [
                        "FH",
                          MCACT7N5[0]

                               ],
                                 [
                           "CS",
                             MCACT7N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT7N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT7N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT7N8[0]

                                        ],
  [
                           "CP",
                             MCACT7N2[0]

  ],
                                      [
                          "MA",
                              MCACT7N7[0]

                                      ],
                         [
                             "AS",

                        MCACT7N1[0]

                         ],
                          [
                        "FIN",
                             MCACT7N6[0]

                          ],
                      ]
                  }, {
                      name: "8",
                      id: "D8",
                      data: [
                           [
                         "PI",
                          MCACT8D9[0]

                           ],
                              [
                       "FH",
                         MCACT8D5[0]

                              ],
                                [
                          "CS",
                            MCACT8D3[0]

                                ],
                                   [
                         "CY",
                           MCACT8D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT8D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT8D8[0]

                                       ],
 [
                          "CP",
                            MCACT8D2[0]

 ],
                                     [
                         "MA",
                             MCACT8D7[0]

                                     ],
                        [
                            "AS",

                       MCACT8D1[0]

                        ],
                         [
                       "FIN",
                            MCACT8D6[0]

                         ],
                      ]
                  },
                  {
                      name: "8",
                      id: "N8",
                      data: [
                            [
                          "PI",
                           MCACT8N9[0]

                            ],
                               [
                        "FH",
                          MCACT8N5[0]

                               ],
                                 [
                           "CS",
                             MCACT8N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT8N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT8N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT8N8[0]

                                        ],
  [
                           "CP",
                             MCACT8N2[0]

  ],
                                      [
                          "MA",
                              MCACT8N7[0]

                                      ],
                         [
                             "AS",

                        MCACT8N1[0]

                         ],
                          [
                        "FIN",
                             MCACT8N6[0]

                          ],
                      ]
                  }, {
                      name: "9",
                      id: "D9",
                      data: [
                           [
                         "PI",
                          MCACT9D9[0]

                           ],
                              [
                       "FH",
                         MCACT9D5[0]

                              ],
                                [
                          "CS",
                            MCACT9D3[0]

                                ],
                                   [
                         "CY",
                           MCACT9D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT9D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT9D8[0]

                                       ],
 [
                          "CP",
                            MCACT9D2[0]

 ],
                                     [
                         "MA",
                             MCACT9D7[0]

                                     ],
                        [
                            "AS",

                       MCACT9D1[0]

                        ],
                         [
                       "FIN",
                            MCACT9D6[0]

                         ],
                      ]
                  },
                  {
                      name: "9",
                      id: "N9",
                      data: [
                            [
                          "PI",
                           MCACT9N9[0]

                            ],
                               [
                        "FH",
                          MCACT9N5[0]

                               ],
                                 [
                           "CS",
                             MCACT9N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT9N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT9N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT9N8[0]

                                        ],
  [
                           "CP",
                             MCACT9N2[0]

  ],
                                      [
                          "MA",
                              MCACT9N7[0]

                                      ],
                         [
                             "AS",

                        MCACT9N1[0]

                         ],
                          [
                        "FIN",
                             MCACT9N6[0]

                          ],
                      ]
                  }, {
                      name: "10",
                      id: "D10",
                      data: [
                           [
                         "PI",
                          MCACT10D9[0]

                           ],
                              [
                       "FH",
                         MCACT10D5[0]

                              ],
                                [
                          "CS",
                            MCACT10D3[0]

                                ],
                                   [
                         "CY",
                           MCACT10D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT10D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT10D8[0]

                                       ],
 [
                          "CP",
                            MCACT10D2[0]

 ],
                                     [
                         "MA",
                             MCACT10D7[0]

                                     ],
                        [
                            "AS",

                       MCACT10D1[0]

                        ],
                         [
                       "FIN",
                            MCACT10D6[0]

                         ],
                      ]
                  },
                  {
                      name: "10",
                      id: "N10",
                      data: [
                            [
                          "PI",
                           MCACT10N9[0]

                            ],
                               [
                        "FH",
                          MCACT10N5[0]

                               ],
                                 [
                           "CS",
                             MCACT10N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT10N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT10N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT10N8[0]

                                        ],
  [
                           "CP",
                             MCACT10N2[0]

  ],
                                      [
                          "MA",
                              MCACT10N7[0]

                                      ],
                         [
                             "AS",

                        MCACT10N1[0]

                         ],
                          [
                        "FIN",
                             MCACT10N6[0]

                          ],
                      ]
                  }, {
                      name: "11",
                      id: "D11",
                      data: [
                           [
                         "PI",
                          MCACT11D9[0]

                           ],
                              [
                       "FH",
                         MCACT11D5[0]

                              ],
                                [
                          "CS",
                            MCACT11D3[0]

                                ],
                                   [
                         "CY",
                           MCACT11D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT11D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT11D8[0]

                                       ],
 [
                          "CP",
                            MCACT11D2[0]

 ],
                                     [
                         "MA",
                             MCACT11D7[0]

                                     ],
                        [
                            "AS",

                       MCACT11D1[0]

                        ],
                         [
                       "FIN",
                            MCACT11D6[0]

                         ],
                      ]
                  },
                  {
                      name: "11",
                      id: "N11",
                      data: [
                            [
                          "PI",
                           MCACT11N9[0]

                            ],
                               [
                        "FH",
                          MCACT11N5[0]

                               ],
                                 [
                           "CS",
                             MCACT11N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT11N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT11N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT11N8[0]

                                        ],
  [
                           "CP",
                             MCACT11N2[0]

  ],
                                      [
                          "MA",
                              MCACT11N7[0]

                                      ],
                         [
                             "AS",

                        MCACT11N1[0]

                         ],
                          [
                        "FIN",
                             MCACT11N6[0]

                          ],
                      ]
                  }, {
                      name: "12",
                      id: "D12",
                      data: [
                           [
                         "PI",
                          MCACT12D9[0]

                           ],
                              [
                       "FH",
                         MCACT12D5[0]

                              ],
                                [
                          "CS",
                            MCACT12D3[0]

                                ],
                                   [
                         "CY",
                           MCACT12D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT12D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT12D8[0]

                                       ],
 [
                          "CP",
                            MCACT12D2[0]

 ],
                                     [
                         "MA",
                             MCACT12D7[0]

                                     ],
                        [
                            "AS",

                       MCACT12D1[0]

                        ],
                         [
                       "FIN",
                            MCACT12D6[0]

                         ],
                      ]
                  },
                  {
                      name: "12",
                      id: "N12",
                      data: [
                            [
                          "PI",
                           MCACT12N9[0]

                            ],
                               [
                        "FH",
                          MCACT12N5[0]

                               ],
                                 [
                           "CS",
                             MCACT12N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT12N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT12N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT12N8[0]

                                        ],
  [
                           "CP",
                             MCACT12N2[0]

  ],
                                      [
                          "MA",
                              MCACT12N7[0]

                                      ],
                         [
                             "AS",

                        MCACT12N1[0]

                         ],
                          [
                        "FIN",
                             MCACT12N6[0]

                          ],
                      ]
                  }, {
                      name: "13",
                      id: "D13",
                      data: [
                           [
                         "PI",
                          MCACT13D9[0]

                           ],
                              [
                       "FH",
                         MCACT13D5[0]

                              ],
                                [
                          "CS",
                            MCACT13D3[0]

                                ],
                                   [
                         "CY",
                           MCACT13D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT13D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT13D8[0]

                                       ],
 [
                          "CP",
                            MCACT13D2[0]

 ],
                                     [
                         "MA",
                             MCACT13D7[0]

                                     ],
                        [
                            "AS",

                       MCACT13D1[0]

                        ],
                         [
                       "FIN",
                            MCACT13D6[0]

                         ],
                      ]
                  },
                  {
                      name: "13",
                      id: "N13",
                      data: [
                            [
                          "PI",
                           MCACT13N9[0]

                            ],
                               [
                        "FH",
                          MCACT13N5[0]

                               ],
                                 [
                           "CS",
                             MCACT13N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT13N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT13N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT13N8[0]

                                        ],
  [
                           "CP",
                             MCACT13N2[0]

  ],
                                      [
                          "MA",
                              MCACT13N7[0]

                                      ],
                         [
                             "AS",

                        MCACT13N1[0]

                         ],
                          [
                        "FIN",
                             MCACT13N6[0]

                          ],
                      ]
                  }, {
                      name: "14",
                      id: "D14",
                      data: [
                           [
                         "PI",
                          MCACT14D9[0]

                           ],
                              [
                       "FH",
                         MCACT14D5[0]

                              ],
                                [
                          "CS",
                            MCACT14D3[0]

                                ],
                                   [
                         "CY",
                           MCACT14D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT14D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT14D8[0]

                                       ],
 [
                          "CP",
                            MCACT14D2[0]

 ],
                                     [
                         "MA",
                             MCACT14D7[0]

                                     ],
                        [
                            "AS",

                       MCACT14D1[0]

                        ],
                         [
                       "FIN",
                            MCACT14D6[0]

                         ],
                      ]
                  },
                  {
                      name: "14",
                      id: "N14",
                      data: [
                            [
                          "PI",
                           MCACT14N9[0]

                            ],
                               [
                        "FH",
                          MCACT14N5[0]

                               ],
                                 [
                           "CS",
                             MCACT14N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT14N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT14N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT14N8[0]

                                        ],
  [
                           "CP",
                             MCACT14N2[0]

  ],
                                      [
                          "MA",
                              MCACT14N7[0]

                                      ],
                         [
                             "AS",

                        MCACT14N1[0]

                         ],
                          [
                        "FIN",
                             MCACT14N6[0]

                          ],
                      ]
                  }, {
                      name: "15",
                      id: "D15",
                      data: [
                           [
                         "PI",
                          MCACT15D9[0]

                           ],
                              [
                       "FH",
                         MCACT15D5[0]

                              ],
                                [
                          "CS",
                            MCACT15D3[0]

                                ],
                                   [
                         "CY",
                           MCACT15D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT15D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT15D8[0]

                                       ],
              [
                          "CP",
                            MCACT15D2[0]

              ],
                                     [
                         "MA",
                             MCACT15D7[0]

                                     ],
                        [
                            "AS",

                       MCACT15D1[0]

                        ],
                         [
                       "FIN",
                            MCACT15D6[0]

                         ],
                      ]
                  },
                  {
                      name: "15",
                      id: "N15",
                      data: [
                            [
                          "PI",
                           MCACT15N9[0]

                            ],
                               [
                        "FH",
                          MCACT15N5[0]

                               ],
                                 [
                           "CS",
                             MCACT15N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT15N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT15N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT15N8[0]

                                        ],
  [
                           "CP",
                             MCACT15N2[0]

  ],
                                      [
                          "MA",
                              MCACT15N7[0]

                                      ],
                         [
                             "AS",

                        MCACT15N1[0]

                         ],
                          [
                        "FIN",
                             MCACT15N6[0]

                          ],
                      ]
                  }, {
                      name: "16",
                      id: "D16",
                      data: [
                           [
                         "PI",
                          MCACT16D9[0]

                           ],
                              [
                       "FH",
                         MCACT16D5[0]

                              ],
                                [
                          "CS",
                            MCACT16D3[0]

                                ],
                                   [
                         "CY",
                           MCACT16D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT16D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT16D8[0]

                                       ],
              [
                          "CP",
                            MCACT16D2[0]

              ],
                                     [
                         "MA",
                             MCACT16D7[0]

                                     ],
                        [
                            "AS",

                       MCACT16D1[0]

                        ],
                         [
                       "FIN",
                            MCACT16D6[0]

                         ],
                      ]
                  },
                  {
                      name: "16",
                      id: "N16",
                      data: [
                            [
                          "PI",
                           MCACT16N9[0]

                            ],
                               [
                        "FH",
                          MCACT16N5[0]

                               ],
                                 [
                           "CS",
                             MCACT16N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT16N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT16N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT16N8[0]

                                        ],
  [
                           "CP",
                             MCACT16N2[0]

  ],
                                      [
                          "MA",
                              MCACT16N7[0]

                                      ],
                         [
                             "AS",

                        MCACT16N1[0]

                         ],
                          [
                        "FIN",
                             MCACT16N6[0]

                          ],
                      ]
                  }, {
                      name: "17",
                      id: "D17",
                      data: [
                           [
                         "PI",
                          MCACT17D9[0]

                           ],
                              [
                       "FH",
                         MCACT17D5[0]

                              ],
                                [
                          "CS",
                            MCACT17D3[0]

                                ],
                                   [
                         "CY",
                           MCACT17D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT17D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT17D8[0]

                                       ],
              [
                          "CP",
                            MCACT17D2[0]

              ],
                                     [
                         "MA",
                             MCACT17D7[0]

                                     ],
                        [
                            "AS",

                       MCACT17D1[0]

                        ],
                         [
                       "FIN",
                            MCACT17D6[0]

                         ],
                      ]
                  },
                  {
                      name: "17",
                      id: "N17",
                      data: [
                            [
                          "PI",
                           MCACT17N9[0]

                            ],
                               [
                        "FH",
                          MCACT17N5[0]

                               ],
                                 [
                           "CS",
                             MCACT17N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT17N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT17N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT17N8[0]

                                        ],
  [
                           "CP",
                             MCACT17N2[0]

  ],
                                      [
                          "MA",
                              MCACT17N7[0]

                                      ],
                         [
                             "AS",

                        MCACT17N1[0]

                         ],
                          [
                        "FIN",
                             MCACT17N6[0]

                          ],
                      ]
                  }, {
                      name: "18",
                      id: "D18",
                      data: [
                           [
                         "PI",
                          MCACT18D9[0]

                           ],
                              [
                       "FH",
                         MCACT18D5[0]

                              ],
                                [
                          "CS",
                            MCACT18D3[0]

                                ],
                                   [
                         "CY",
                           MCACT18D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT18D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT18D8[0]

                                       ],
              [
                          "CP",
                            MCACT18D2[0]

              ],
                                     [
                         "MA",
                             MCACT18D7[0]

                                     ],
                        [
                            "AS",

                       MCACT18D1[0]

                        ],
                         [
                       "FIN",
                            MCACT18D6[0]

                         ],
                      ]
                  },
                  {
                      name: "18",
                      id: "N18",
                      data: [
                            [
                          "PI",
                           MCACT18N9[0]

                            ],
                               [
                        "FH",
                          MCACT18N5[0]

                               ],
                                 [
                           "CS",
                             MCACT18N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT18N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT18N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT18N8[0]

                                        ],
  [
                           "CP",
                             MCACT18N2[0]

  ],
                                      [
                          "MA",
                              MCACT18N7[0]

                                      ],
                         [
                             "AS",

                        MCACT18N1[0]

                         ],
                          [
                        "FIN",
                             MCACT18N6[0]

                          ],
                      ]
                  }, {
                      name: "19",
                      id: "D19",
                      data: [
                           [
                         "PI",
                          MCACT19D9[0]

                           ],
                              [
                       "FH",
                         MCACT19D5[0]

                              ],
                                [
                          "CS",
                            MCACT19D3[0]

                                ],
                                   [
                         "CY",
                           MCACT19D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT19D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT19D8[0]

                                       ],
              [
                          "CP",
                            MCACT19D2[0]

              ],
                                     [
                         "MA",
                             MCACT19D7[0]

                                     ],
                        [
                            "AS",

                       MCACT19D1[0]

                        ],
                         [
                       "FIN",
                            MCACT19D6[0]

                         ],
                      ]
                  },
                  {
                      name: "19",
                      id: "N19",
                      data: [
                            [
                          "PI",
                           MCACT19N9[0]

                            ],
                               [
                        "FH",
                          MCACT19N5[0]

                               ],
                                 [
                           "CS",
                             MCACT19N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT19N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT19N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT19N8[0]

                                        ],
  [
                           "CP",
                             MCACT19N2[0]

  ],
                                      [
                          "MA",
                              MCACT19N7[0]

                                      ],
                         [
                             "AS",

                        MCACT19N1[0]

                         ],
                          [
                        "FIN",
                             MCACT19N6[0]

                          ],
                      ]
                  }, {
                      name: "20",
                      id: "D20",
                      data: [
                           [
                         "PI",
                          MCACT20D9[0]

                           ],
                              [
                       "FH",
                         MCACT20D5[0]

                              ],
                                [
                          "CS",
                            MCACT20D3[0]

                                ],
                                   [
                         "CY",
                           MCACT20D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT20D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT20D8[0]

                                       ],
              [
                          "CP",
                            MCACT20D2[0]

              ],
                                     [
                         "MA",
                             MCACT20D7[0]

                                     ],
                        [
                            "AS",

                       MCACT20D1[0]

                        ],
                         [
                       "FIN",
                            MCACT20D6[0]

                         ],
                      ]
                  },
                  {
                      name: "20",
                      id: "N20",
                      data: [
                            [
                          "PI",
                           MCACT20N9[0]

                            ],
                               [
                        "FH",
                          MCACT20N5[0]

                               ],
                                 [
                           "CS",
                             MCACT20N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT20N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT20N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT20N8[0]

                                        ],
  [
                           "CP",
                             MCACT20N2[0]

  ],
                                      [
                          "MA",
                              MCACT20N7[0]

                                      ],
                         [
                             "AS",

                        MCACT20N1[0]

                         ],
                          [
                        "FIN",
                             MCACT20N6[0]

                          ],
                      ]
                  }, {
                      name: "21",
                      id: "D21",
                      data: [
                           [
                         "PI",
                          MCACT21D9[0]

                           ],
                              [
                       "FH",
                         MCACT21D5[0]

                              ],
                                [
                          "CS",
                            MCACT21D3[0]

                                ],
                                   [
                         "CY",
                           MCACT21D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT21D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT21D8[0]

                                       ],
              [
                          "CP",
                            MCACT21D2[0]

              ],
                                     [
                         "MA",
                             MCACT21D7[0]

                                     ],
                        [
                            "AS",

                       MCACT21D1[0]

                        ],
                         [
                       "FIN",
                            MCACT21D6[0]

                         ],
                      ]
                  },
                  {
                      name: "21",
                      id: "N21",
                      data: [
                            [
                          "PI",
                           MCACT21N9[0]

                            ],
                               [
                        "FH",
                          MCACT21N5[0]

                               ],
                                 [
                           "CS",
                             MCACT21N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT21N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT21N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT21N8[0]

                                        ],
  [
                           "CP",
                             MCACT21N2[0]

  ],
                                      [
                          "MA",
                              MCACT21N7[0]

                                      ],
                         [
                             "AS",

                        MCACT21N1[0]

                         ],
                          [
                        "FIN",
                             MCACT21N6[0]

                          ],
                      ]
                  }, {
                      name: "22",
                      id: "D22",
                      data: [
                           [
                         "PI",
                          MCACT22D9[0]

                           ],
                              [
                       "FH",
                         MCACT22D5[0]

                              ],
                                [
                          "CS",
                            MCACT22D3[0]

                                ],
                                   [
                         "CY",
                           MCACT22D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT22D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT22D8[0]

                                       ],
              [
                          "CP",
                            MCACT22D2[0]

              ],
                                     [
                         "MA",
                             MCACT22D7[0]

                                     ],
                        [
                            "AS",

                       MCACT22D1[0]

                        ],
                         [
                       "FIN",
                            MCACT22D6[0]

                         ],
                      ]
                  },
                  {
                      name: "22",
                      id: "N22",
                      data: [
                            [
                          "PI",
                           MCACT22N9[0]

                            ],
                               [
                        "FH",
                          MCACT22N5[0]

                               ],
                                 [
                           "CS",
                             MCACT22N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT22N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT22N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT22N8[0]

                                        ],
  [
                           "CP",
                             MCACT22N2[0]

  ],
                                      [
                          "MA",
                              MCACT22N7[0]

                                      ],
                         [
                             "AS",

                        MCACT22N1[0]

                         ],
                          [
                        "FIN",
                             MCACT22N6[0]

                          ],
                      ]
                  }, {
                      name: "23",
                      id: "D23",
                      data: [
                           [
                         "PI",
                          MCACT23D9[0]

                           ],
                              [
                       "FH",
                         MCACT23D5[0]

                              ],
                                [
                          "CS",
                            MCACT23D3[0]

                                ],
                                   [
                         "CY",
                           MCACT23D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT23D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT23D8[0]

                                       ],
              [
                          "CP",
                            MCACT23D2[0]

              ],
                                     [
                         "MA",
                             MCACT23D7[0]

                                     ],
                        [
                            "AS",

                       MCACT23D1[0]

                        ],
                         [
                       "FIN",
                            MCACT23D6[0]

                         ],
                      ]
                  },
                  {
                      name: "23",
                      id: "N23",
                      data: [
                            [
                          "PI",
                           MCACT23N9[0]

                            ],
                               [
                        "FH",
                          MCACT23N5[0]

                               ],
                                 [
                           "CS",
                             MCACT23N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT23N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT23N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT23N8[0]

                                        ],
  [
                           "CP",
                             MCACT23N2[0]

  ],
                                      [
                          "MA",
                              MCACT23N7[0]

                                      ],
                         [
                             "AS",

                        MCACT23N1[0]

                         ],
                          [
                        "FIN",
                             MCACT23N6[0]

                          ],
                      ]
                  }, {
                      name: "24",
                      id: "D24",
                      data: [
                           [
                         "PI",
                          MCACT24D9[0]

                           ],
                              [
                       "FH",
                         MCACT24D5[0]

                              ],
                                [
                          "CS",
                            MCACT24D3[0]

                                ],
                                   [
                         "CY",
                           MCACT24D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT24D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT24D8[0]

                                       ],
              [
                          "CP",
                            MCACT24D2[0]

              ],
                                     [
                         "MA",
                             MCACT24D7[0]

                                     ],
                        [
                            "AS",

                       MCACT24D1[0]

                        ],
                         [
                       "FIN",
                            MCACT24D6[0]

                         ],
                      ]
                  },
                  {
                      name: "24",
                      id: "N24",
                      data: [
                            [
                          "PI",
                           MCACT24N9[0]

                            ],
                               [
                        "FH",
                          MCACT24N5[0]

                               ],
                                 [
                           "CS",
                             MCACT24N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT24N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT24N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT24N8[0]

                                        ],
  [
                           "CP",
                             MCACT24N2[0]

  ],
                                      [
                          "MA",
                              MCACT24N7[0]

                                      ],
                         [
                             "AS",

                        MCACT24N1[0]

                         ],
                          [
                        "FIN",
                             MCACT24N6[0]

                          ],
                      ]
                  }, {
                      name: "25",
                      id: "D25",
                      data: [
                           [
                         "PI",
                          MCACT25D9[0]

                           ],
                              [
                       "FH",
                         MCACT25D5[0]

                              ],
                                [
                          "CS",
                            MCACT25D3[0]

                                ],
                                   [
                         "CY",
                           MCACT25D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT25D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT25D8[0]

                                       ],
              [
                          "CP",
                            MCACT25D2[0]

              ],
                                     [
                         "MA",
                             MCACT25D7[0]

                                     ],
                        [
                            "AS",

                       MCACT25D1[0]

                        ],
                         [
                       "FIN",
                            MCACT25D6[0]

                         ],
                      ]
                  },
                  {
                      name: "25",
                      id: "N25",
                      data: [
                            [
                          "PI",
                           MCACT25N9[0]

                            ],
                               [
                        "FH",
                          MCACT25N5[0]

                               ],
                                 [
                           "CS",
                             MCACT25N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT25N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT25N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT25N8[0]

                                        ],
  [
                           "CP",
                             MCACT25N2[0]

  ],
                                      [
                          "MA",
                              MCACT25N7[0]

                                      ],
                         [
                             "AS",

                        MCACT25N1[0]

                         ],
                          [
                        "FIN",
                             MCACT25N6[0]

                          ],
                      ]
                  }, {
                      name: "26",
                      id: "D26",
                      data: [
                           [
                         "PI",
                          MCACT26D9[0]

                           ],
                              [
                       "FH",
                         MCACT26D5[0]

                              ],
                                [
                          "CS",
                            MCACT26D3[0]

                                ],
                                   [
                         "CY",
                           MCACT26D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT26D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT26D8[0]

                                       ],
              [
                          "CP",
                            MCACT26D2[0]

              ],
                                     [
                         "MA",
                             MCACT26D7[0]

                                     ],
                        [
                            "AS",

                       MCACT26D1[0]

                        ],
                         [
                       "FIN",
                            MCACT26D6[0]

                         ],
                      ]
                  },
                  {
                      name: "26",
                      id: "N26",
                      data: [
                            [
                          "PI",
                           MCACT26N9[0]

                            ],
                               [
                        "FH",
                          MCACT26N5[0]

                               ],
                                 [
                           "CS",
                             MCACT26N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT26N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT26N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT26N8[0]

                                        ],
  [
                           "CP",
                             MCACT26N2[0]

  ],
                                      [
                          "MA",
                              MCACT26N7[0]

                                      ],
                         [
                             "AS",

                        MCACT26N1[0]

                         ],
                          [
                        "FIN",
                             MCACT26N6[0]

                          ],
                      ]
                  }, {
                      name: "27",
                      id: "D27",
                      data: [
                           [
                         "PI",
                          MCACT27D9[0]

                           ],
                              [
                       "FH",
                         MCACT27D5[0]

                              ],
                                [
                          "CS",
                            MCACT27D3[0]

                                ],
                                   [
                         "CY",
                           MCACT27D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT27D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT27D8[0]

                                       ],
              [
                          "CP",
                            MCACT27D2[0]

              ],
                                     [
                         "MA",
                             MCACT27D7[0]

                                     ],
                        [
                            "AS",

                       MCACT27D1[0]

                        ],
                         [
                       "FIN",
                            MCACT27D6[0]

                         ],
                      ]
                  },
                  {
                      name: "27",
                      id: "N27",
                      data: [
                            [
                          "PI",
                           MCACT27N9[0]

                            ],
                               [
                        "FH",
                          MCACT27N5[0]

                               ],
                                 [
                           "CS",
                             MCACT27N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT27N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT27N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT27N8[0]

                                        ],
  [
                           "CP",
                             MCACT27N2[0]

  ],
                                      [
                          "MA",
                              MCACT27N7[0]

                                      ],
                         [
                             "AS",

                        MCACT27N1[0]

                         ],
                          [
                        "FIN",
                             MCACT27N6[0]

                          ],
                      ]
                  }, {
                      name: "28",
                      id: "D28",
                      data: [
                           [
                         "PI",
                          MCACT28D9[0]

                           ],
                              [
                       "FH",
                         MCACT28D5[0]

                              ],
                                [
                          "CS",
                            MCACT28D3[0]

                                ],
                                   [
                         "CY",
                           MCACT28D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT28D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT28D8[0]

                                       ],
              [
                          "CP",
                            MCACT28D2[0]

              ],
                                     [
                         "MA",
                             MCACT28D7[0]

                                     ],
                        [
                            "AS",

                       MCACT28D1[0]

                        ],
                         [
                       "FIN",
                            MCACT28D6[0]

                         ],
                      ]
                  },
                  {
                      name: "28",
                      id: "N28",
                      data: [
                            [
                          "PI",
                           MCACT28N9[0]

                            ],
                               [
                        "FH",
                          MCACT28N5[0]

                               ],
                                 [
                           "CS",
                             MCACT28N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT28N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT28N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT28N8[0]

                                        ],
  [
                           "CP",
                             MCACT28N2[0]

  ],
                                      [
                          "MA",
                              MCACT28N7[0]

                                      ],
                         [
                             "AS",

                        MCACT28N1[0]

                         ],
                          [
                        "FIN",
                             MCACT28N6[0]

                          ],
                      ]
                  }, {
                      name: "29",
                      id: "D29",
                      data: [
                           [
                         "PI",
                          MCACT29D9[0]

                           ],
                              [
                       "FH",
                         MCACT29D5[0]

                              ],
                                [
                          "CS",
                            MCACT29D3[0]

                                ],
                                   [
                         "CY",
                           MCACT29D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT29D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT29D8[0]

                                       ],
              [
                          "CP",
                            MCACT29D2[0]

              ],
                                     [
                         "MA",
                             MCACT29D7[0]

                                     ],
                        [
                            "AS",

                       MCACT29D1[0]

                        ],
                         [
                       "FIN",
                            MCACT29D6[0]

                         ],
                      ]
                  },
                  {
                      name: "29",
                      id: "N29",
                      data: [
                            [
                          "PI",
                           MCACT29N9[0]

                            ],
                               [
                        "FH",
                          MCACT29N5[0]

                               ],
                                 [
                           "CS",
                             MCACT29N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT29N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT29N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT29N8[0]

                                        ],
  [
                           "CP",
                             MCACT29N2[0]

  ],
                                      [
                          "MA",
                              MCACT29N7[0]

                                      ],
                         [
                             "AS",

                        MCACT29N1[0]

                         ],
                          [
                        "FIN",
                             MCACT29N6[0]

                          ],
                      ]
                  }, {
                      name: "30",
                      id: "D30",
                      data: [
                           [
                         "PI",
                          MCACT30D9[0]

                           ],
                              [
                       "FH",
                         MCACT30D5[0]

                              ],
                                [
                          "CS",
                            MCACT30D3[0]

                                ],
                                   [
                         "CY",
                           MCACT30D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT30D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT30D8[0]

                                       ],
              [
                          "CP",
                            MCACT30D2[0]

              ],
                                     [
                         "MA",
                             MCACT30D7[0]

                                     ],
                        [
                            "AS",

                       MCACT30D1[0]

                        ],
                         [
                       "FIN",
                            MCACT30D6[0]

                         ],
                      ]
                  },
                  {
                      name: "30",
                      id: "N30",
                      data: [
                            [
                          "PI",
                           MCACT30N9[0]

                            ],
                               [
                        "FH",
                          MCACT30N5[0]

                               ],
                                 [
                           "CS",
                             MCACT30N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT30N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT30N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT30N8[0]

                                        ],
  [
                           "CP",
                             MCACT30N2[0]

  ],
                                      [
                          "MA",
                              MCACT30N7[0]

                                      ],
                         [
                             "AS",

                        MCACT30N1[0]

                         ],
                          [
                        "FIN",
                             MCACT30N6[0]

                          ],
                      ]
                  }, {
                      name: "31",
                      id: "D31",
                      data: [
                           [
                         "PI",
                          MCACT31D9[0]

                           ],
                              [
                       "FH",
                         MCACT31D5[0]

                              ],
                                [
                          "CS",
                            MCACT31D3[0]

                                ],
                                   [
                         "CY",
                           MCACT31D4[0]

                                   ],
                                    [
                        "RH",
                          MCACT31D10[0]

                                    ],
                                       [
                          "MOT",
                            MCACT31D8[0]

                                       ],
              [
                          "CP",
                            MCACT31D2[0]

              ],
                                     [
                         "MA",
                             MCACT31D7[0]

                                     ],
                        [
                            "AS",

                       MCACT31D1[0]

                        ],
                         [
                       "FIN",
                            MCACT31D6[0]

                         ],
                      ]
                  },
                  {
                      name: "31",
                      id: "N31",
                      data: [
                            [
                          "PI",
                           MCACT31N9[0]

                            ],
                               [
                        "FH",
                          MCACT31N5[0]

                               ],
                                 [
                           "CS",
                             MCACT31N3[0]

                                 ],
                                    [
                          "CY",
                            MCACT31N4[0]

                                    ],
                                     [
                         "RH",
                           MCACT31N10[0]

                                     ],
                                        [
                           "MOT",
                             MCACT31N8[0]

                                        ],
  [
                           "CP",
                             MCACT31N2[0]

  ],
                                      [
                          "MA",
                              MCACT31N7[0]

                                      ],
                         [
                             "AS",

                        MCACT31N1[0]

                         ],
                          [
                        "FIN",
                             MCACT31N6[0]

                          ],
                      ]
                  },
                ]
            }

        });
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });




}
function loadChartMPFac3Direct(_objChart, _CostCenter, _DataDate, _DataMonth) {

    var DataMonth = new Date(_DataMonth);
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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMPReqD = new Array();
    var SUMMPReqN = new Array();
    var SUMLEReqD = new Array();
    var SUMLEReqN = new Array();
    var SUMFOReqD = new Array();
    var SUMFOReqN = new Array();

    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();
    var MC_MPD = new Array();
    var MC_MPN = new Array();
    var MCACTD = new Array();
    var MCACTN = new Array();
    var MC_Line = new Array();

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
    var Score = new Array();

    var PI = new Array();
    var FH = new Array();
    var CS = new Array();
    var CY = new Array();
    var RH = new Array();
    var MOT = new Array();
    var MA = new Array();
    var AS = new Array();
    var FIN = new Array();
    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
    var DayTOO = new Array();

    var PD = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];

    var ReqLEDay = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];

    var ReqLENIGHT = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];
    var ReqFODay = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
 "ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];
    var ReqFONIGHT = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
 "ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];




    var ReqDay = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];

    var DiffDay = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];

    var DiffNight = ["ReqD1", "ReqD2", "ReqD3", "ReqD4", "ReqD5", "ReqD6", "ReqD7", "ReqD8", "ReqD9", "ReqD10", "ReqD11", "ReqD12", "ReqD13", "ReqD14", "ReqD15", "ReqD16",
"ReqD17", "ReqD18", "ReqD19", "ReqD20", "ReqD21", "ReqD22", "ReqD23", "ReqD24", "ReqD25", "ReqD26", "ReqD27", "ReqD28", "ReqD29", "ReqD30", "ReqD31"];


    var ReqNight = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5", "ReqN6", "ReqN7", "ReqN8", "ReqN9", "ReqN10", "ReqN11", "ReqN12", "ReqN13", "ReqN14", "ReqN15", "ReqN16",
"ReqN17", "ReqN18", "ReqN19", "ReqN20", "ReqN21", "ReqN22", "ReqN23", "ReqN24", "ReqN25", "ReqN26", "ReqN27", "ReqN28", "ReqN29", "ReqN30", "ReqN31"];

    var ACTD = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5", "ReqN6", "ReqN7", "ReqN8", "ReqN9", "ReqN10", "ReqN11", "ReqN12", "ReqN13", "ReqN14", "ReqN15", "ReqN16",
"ReqN17", "ReqN18", "ReqN19", "ReqN20", "ReqN21", "ReqN22", "ReqN23", "ReqN24", "ReqN25", "ReqN26", "ReqN27", "ReqN28", "ReqN29", "ReqN30", "ReqN31"];

    var ACTN = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5", "ReqN6", "ReqN7", "ReqN8", "ReqN9", "ReqN10", "ReqN11", "ReqN12", "ReqN13", "ReqN14", "ReqN15", "ReqN16",
"ReqN17", "ReqN18", "ReqN19", "ReqN20", "ReqN21", "ReqN22", "ReqN23", "ReqN24", "ReqN25", "ReqN26", "ReqN27", "ReqN28", "ReqN29", "ReqN30", "ReqN31"];


    var ReqD1, ReqD2, ReqD3, ReqD4, ReqD5, ReqD6, ReqD7, ReqD8, ReqD9, ReqD10, ReqD11, ReqD12, ReqD13, ReqD14, ReqD15, ReqD16, ReqD17, ReqD18, ReqD19, ReqD20, ReqD21, ReqD22, ReqD23, ReqD24, ReqD25,
ReqD26, ReqD27, ReqD28, ReqD29, ReqD30, ReqD31;
    var ReqN1 = 0, ReqN2 = 0, ReqN3 = 0, ReqN4 = 0, ReqN5 = 0, ReqN6 = 0, ReqN7, ReqN8, ReqN9, ReqN10, ReqN11, ReqN12, ReqN13, ReqN14, ReqN15, ReqN16, ReqN17, ReqN18, ReqN19, ReqN20, ReqN21, ReqN22, ReqN23,
ReqN24, ReqN25, ReqN26, ReqN27, ReqN28, ReqN29, ReqN30, ReqN31;


    var ReqLED1, ReqLED2, ReqLED3, ReqLED4, ReqLED5, ReqLED6, ReqLED7, ReqLED8, ReqLED9, ReqLED10, ReqLED11, ReqLED12, ReqLED13, ReqLED14, ReqLED15, ReqLED16, ReqLED17, ReqLED18, ReqLED19, ReqLED20, ReqLED21, ReqLED22, ReqLED23, ReqLED24, ReqLED25,
ReqLED26, ReqLED27, ReqLED28, ReqLED29, ReqLED30, ReqLED31;

    var ReqLEN1, ReqLEN2, ReqLEN3, ReqLEN4, ReqLEN5, ReqLEN6, ReqLEN7, ReqLEN8, ReqLEN9, ReqLEN10, ReqLEN11, ReqLEN12, ReqLEN13, ReqLEN14, ReqLEN15, ReqLEN16, ReqLEN17, ReqLEN18, ReqLEN19, ReqLEN20, ReqLEN21, ReqLEN22, ReqLEN23, ReqLEN24, ReqLEN25,
ReqLEN26, ReqLEN27, ReqLEN28, ReqLEN29, ReqLEN30, ReqLEN31;

    var ReqFOD1, ReqFOD2, ReqFOD3, ReqFOD4, ReqFOD5, ReqFOD6, ReqFOD7, ReqFOD8, ReqFOD9, ReqFOD10, ReqFOD11, ReqFOD12, ReqFOD13, ReqFOD14, ReqFOD15, ReqFOD16, ReqFOD17, ReqFOD18, ReqFOD19, ReqFOD20, ReqFOD21, ReqFOD22, ReqFOD23, ReqFOD24, ReqFOD25,
ReqFOD26, ReqFOD27, ReqFOD28, ReqFOD29, ReqFOD30, ReqFOD31;

    var ReqFON1, ReqFON2, ReqFON3, ReqFON4, ReqFON5, ReqFON6, ReqFON7, ReqFON8, ReqFON9, ReqFON10, ReqFON11, ReqFON12, ReqFON13, ReqFON14, ReqFON15, ReqFON16, ReqFON17, ReqFON18, ReqFON19, ReqFON20, ReqFON21, ReqFON22, ReqFON23, ReqFON24, ReqFON25,
ReqFON26, ReqFON27, ReqFON28, ReqFON29, ReqFON30, ReqFON31;


    var ActD1, ActD2, ActD3, ActD4, ActD5, ActD6, ActD7, ActD8, ActD9, ActD10, ActD11, ActD12, ActD13, ActD14, ActD15, ActD16, ActD17, ActD18, ActD19, ActD20, ActD21, ActD22, ActD23, ActD24, ActD25,
ActD26, ActD27, ActD28, ActD29, ActD30, ActD31;

    var ActN1, ActN2, ActN3, ActN4, ActN5, ActN6, ActN7, ActN8, ActN9, ActN10, ActN11, ActN12, ActN13, ActN14, ActN15, ActN16, ActN17, ActN18, ActN19, ActN20, ActN21, ActN22, ActN23, ActN24, ActN25,
ActN26, ActN27, ActN28, ActN29, ActN30, ActN31;

    var DiffD1, DiffD2, DiffD3, DiffD4, DiffD5, DiffD6, DiffD7, DiffD8, DiffD9, DiffD10, DiffD11, DiffD12, DiffD13, DiffD14, DiffD15, DiffD16, DiffD17, DiffD18, DiffD19, DiffD20, DiffD21, DiffD22, DiffD23, DiffD24, DiffD25,
DiffD26, DiffD27, DiffD28, DiffD29, DiffD30, DiffD31;

    var DiffN1, DiffN2, DiffN3, DiffN4, DiffN5, DiffN6, DiffN7, DiffN8, DiffN9, DiffN10, DiffN11, DiffN12, DiffN13, DiffN14, DiffN15, DiffN16, DiffN17, DiffN18, DiffN19, DiffN20, DiffN21, DiffN22, DiffN23, DiffN24, DiffN25,
DiffN26, DiffN27, DiffN28, DiffN29, DiffN30, DiffN31;



    var MCACTD1 = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5"];
    var MCACT1D1, MCACT1D2, MCACT1D3, MCACT1D4, MCACT1D5, MCACT1D6, MCACT1D7, MCACT1D8, MCACT1D9;


    var MCACT2D1, MCACT2D2, MCACT2D3, MCACT2D4, MCACT2D5, MCACT2D6, MCACT2D7, MCACT2D8, MCACT2D9, MCACT2D10;
    var MCACT3D1, MCACT3D2, MCACT3D3, MCACT3D4, MCACT3D5, MCACT3D6, MCACT3D7, MCACT3D8, MCACT3D9, MCACT3D10;
    var MCACT4D1, MCACT4D2, MCACT4D3, MCACT4D4, MCACT4D5, MCACT4D6, MCACT4D7, MCACT4D8, MCACT4D9, MCACT4D10;
    var MCACT5D1, MCACT5D2, MCACT5D3, MCACT5D4, MCACT5D5, MCACT5D6, MCACT5D7, MCACT5D8, MCACT5D9, MCACT5D10;
    var MCACT6D1, MCACT6D2, MCACT6D3, MCACT6D4, MCACT6D5, MCACT6D6, MCACT6D7, MCACT6D8, MCACT6D9, MCACT6D10;
    var MCACT7D1, MCACT7D2, MCACT7D3, MCACT7D4, MCACT7D5, MCACT7D6, MCACT7D7, MCACT7D8, MCACT7D9, MCACT7D10;
    var MCACT8D1, MCACT8D2, MCACT8D3, MCACT8D4, MCACT8D5, MCACT8D6, MCACT8D7, MCACT8D8, MCACT8D9, MCACT8D10;
    var MCACT9D1, MCACT9D2, MCACT9D3, MCACT9D4, MCACT9D5, MCACT9D6, MCACT9D7, MCACT9D8, MCACT9D9, MCACT9D10;
    var MCACT10D1, MCACT10D2, MCACT10D3, MCACT10D4, MCACT10D5, MCACT10D6, MCACT10D7, MCACT10D8, MCACT10D9, MCACT10D10;
    var MCACT11D1, MCACT11D2, MCACT11D3, MCACT11D4, MCACT11D5, MCACT11D6, MCACT11D7, MCACT11D8, MCACT11D9, MCACT11D10;
    var MCACT12D1, MCACT12D2, MCACT12D3, MCACT12D4, MCACT12D5, MCACT12D6, MCACT12D7, MCACT12D8, MCACT12D9, MCACT12D10;
    var MCACT13D1, MCACT13D2, MCACT13D3, MCACT13D4, MCACT13D5, MCACT13D6, MCACT13D7, MCACT13D8, MCACT13D9, MCACT13D10;
    var MCACT14D1, MCACT14D2, MCACT14D3, MCACT14D4, MCACT14D5, MCACT14D6, MCACT14D7, MCACT14D8, MCACT14D9, MCACT14D10;
    var MCACT15D1, MCACT15D2, MCACT15D3, MCACT15D4, MCACT15D5, MCACT15D6, MCACT15D7, MCACT15D8, MCACT15D9, MCACT15D10;
    var MCACT16D1, MCACT16D2, MCACT16D3, MCACT16D4, MCACT16D5, MCACT16D6, MCACT16D7, MCACT16D8, MCACT16D9, MCACT16D10;
    var MCACT17D1, MCACT17D2, MCACT17D3, MCACT17D4, MCACT17D5, MCACT17D6, MCACT17D7, MCACT17D8, MCACT17D9, MCACT17D10;
    var MCACT18D1, MCACT18D2, MCACT18D3, MCACT18D4, MCACT18D5, MCACT18D6, MCACT18D7, MCACT18D8, MCACT18D9, MCACT18D10;
    var MCACT19D1, MCACT19D2, MCACT19D3, MCACT19D4, MCACT19D5, MCACT19D6, MCACT19D7, MCACT19D8, MCACT19D9, MCACT19D10;
    var MCACT20D1, MCACT20D2, MCACT20D3, MCACT20D4, MCACT20D5, MCACT20D6, MCACT20D7, MCACT20D8, MCACT20D9, MCACT20D10;
    var MCACT21D1, MCACT21D2, MCACT21D3, MCACT21D4, MCACT21D5, MCACT21D6, MCACT21D7, MCACT21D8, MCACT21D9, MCACT21D10;
    var MCACT22D1, MCACT22D2, MCACT22D3, MCACT22D4, MCACT22D5, MCACT22D6, MCACT22D7, MCACT22D8, MCACT22D9, MCACT22D10;
    var MCACT23D1, MCACT23D2, MCACT23D3, MCACT23D4, MCACT23D5, MCACT23D6, MCACT23D7, MCACT23D8, MCACT23D9, MCACT23D10;
    var MCACT24D1, MCACT24D2, MCACT24D3, MCACT24D4, MCACT24D5, MCACT24D6, MCACT24D7, MCACT24D8, MCACT24D9, MCACT24D10;
    var MCACT25D1, MCACT25D2, MCACT25D3, MCACT25D4, MCACT25D5, MCACT25D6, MCACT25D7, MCACT25D8, MCACT25D9, MCACT25D10;
    var MCACT26D1, MCACT26D2, MCACT26D3, MCACT26D4, MCACT26D5, MCACT26D6, MCACT26D7, MCACT26D8, MCACT26D9, MCACT26D10;
    var MCACT27D1, MCACT27D2, MCACT27D3, MCACT27D4, MCACT27D5, MCACT27D6, MCACT27D7, MCACT27D8, MCACT27D9, MCACT27D10;
    var MCACT28D1, MCACT28D2, MCACT28D3, MCACT28D4, MCACT28D5, MCACT28D6, MCACT28D7, MCACT28D8, MCACT28D9, MCACT28D10;
    var MCACT29D1, MCACT29D2, MCACT29D3, MCACT29D4, MCACT29D33MCACT29D6, MCACT29D7, MCACT29D8, MCACT29D9, MCACT29D10;
    var MCACT30D1, MCACT30D2, MCACT30D3, MCACT30D4, MCACT30D34MCACT30D6, MCACT30D7, MCACT30D8, MCACT30D9, MCACT30D10;
    var MCACT31D1, MCACT31D2, MCACT31D33MCACT31D34MCACT31D35MCACT31D36MCACT31D7, MCACT31D8, MCACT31D9, MCACT31D10;


    var MCACTN1 = ["ReqN1", "ReqN2", "ReqN3", "ReqN4", "ReqN5"];
    var MCACT1N1, MCACT1N2, MCACT1N3, MCACT1N4, MCACT1N5, MCACT1N6, MCACT1N7, MCACT1N8, MCACT1N9, MCACT1N10;
    var MCACT2N1, MCACT2N2, MCACT2N3, MCACT2N4, MCACT2N5, MCACT2N6, MCACT2N7, MCACT2N8, MCACT2N9, MCACT2N10;

    var j = 0;
    //var MC = new Array()();

    var DDay = 31;
    var MCCount = 10;

    var Loop = new Array();

    //var int ROW = 3, COLUMN = 4;
    //var int score[][] = new int[ROW][COLUMN];
    //var int data = 5;

    // Assigning values
    //    for (int i = 0; i < ROW; i++) {
    //        for (int j = 0; j < COLUMN; j++) {
    //            score[i][j] = data;
    //            data += 5;
    //    }
    //}

    if (_CostCenter == "MPALL") {
        dataTitle = "DIRECT : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC1") {
        dataTitle = "DIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2") {
        dataTitle = "DIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3") {
        dataTitle = "DIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3M") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3CS") {
        dataTitle = "DIRECT : Factory 3 CS " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3A") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3MPrev") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev2") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev2") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev3") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev3") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODM") {
        dataTitle = "DIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev2") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev2") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev2") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev2") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev3") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev3") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev3") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev3") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

    } else if (_CostCenter == "MPMTALL") {
        dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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



            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            MC_Line = [ResponseData[i].MC_Name];

            SUMMPReqD.push([ResponseData[i].SumMPD]);
            SUMMPReqN.push([ResponseData[i].SumMPN]);

            SUMLEReqD.push([ResponseData[i].SumLED]);
            SUMLEReqN.push([ResponseData[i].SumLEN]);

            SUMFOReqD.push([ResponseData[i].SumFOD]);
            SUMFOReqN.push([ResponseData[i].SumFON]);

            SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
            SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
            SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);

            MC_MPD.push([ResponseData[i].MC_MPD]);
            MC_MPN.push([ResponseData[i].MC_MPN]);
            MCACTD.push([ResponseData[i].MCACTD]);
            MCACTN.push([ResponseData[i].MCACTN]);

            Loop.push([ResponseData[i].CountLoop]);



        }








        //  Loop = (ResponseData.length - 2) / MCCount;

        for (i = 0; i < 31; i++) {


            if (Loop[j] != 0 && (j <= ResponseData.length)) {

                DayTOO[i] = Dayto[j];

                PD[i] = Prod[j];

                ReqDay[i] = SUMMPReqD[j];
                ReqNight[i] = SUMMPReqN[j];

                ReqLEDay[i] = SUMLEReqD[j];
                ReqLENIGHT[i] = SUMLEReqN[j];

                ReqFODay[i] = SUMFOReqD[j];
                ReqFONIGHT[i] = SUMFOReqN[j];


                ACTD[i] = SUMMP_ACTD[j];
                ACTN[i] = SUMMP_ACTN[j];

                DiffDay[i] = SUMMP_DIFFD[j];
                DiffNight[i] = SUMMP_DIFFN[j];



                MCACTD1[j] = MCACTD[j];
                MCACTD1[j + 1] = MCACTD[j + 1];
                MCACTD1[j + 2] = MCACTD[j + 2];
                MCACTD1[j + 3] = MCACTD[j + 3];
                MCACTD1[j + 4] = MCACTD[j + 4];
                MCACTD1[j + 5] = MCACTD[j + 5];
                MCACTD1[j + 6] = MCACTD[j + 6];
                MCACTD1[j + 7] = MCACTD[j + 7];
                MCACTD1[j + 8] = MCACTD[j + 8];
                MCACTD1[j + 9] = MCACTD[j + 9];


                MCACTN1[j] = MCACTN[j];
                MCACTN1[j + 1] = MCACTN[j + 1];
                MCACTN1[j + 2] = MCACTN[j + 2];
                MCACTN1[j + 3] = MCACTN[j + 3];
                MCACTN1[j + 4] = MCACTN[j + 4];
                MCACTN1[j + 5] = MCACTN[j + 5];
                MCACTN1[j + 6] = MCACTN[j + 6];
                MCACTN1[j + 7] = MCACTN[j + 7];
                MCACTN1[j + 8] = MCACTN[j + 8];
                MCACTN1[j + 9] = MCACTN[j + 9];



                if (MC_Line = "FAC3AS") {
                    //   MCACTAS[i] = MC_MPD[j];
                }
                if (MC_Line = "FAC3CS") {
                    CS = MC_MPD[1];
                }
                if (MC_Line = "FAC3CY") {
                    CY = MC_MPD[2];
                }
                if (MC_Line = "FAC3FH") {
                    FH = MC_MPD[3];
                }
                if (MC_Line = "FAC3FIN") {
                    FIN = MC_MPD[4];
                }
                if (MC_Line = "FAC3MA") {
                    MOT = MC_MPD[5];
                }
                if (MC_Line = "FAC3MOT") {
                    MOT = MC_MPD[6];
                }
                if (MC_Line = "FAC3PI") {
                    PI = MC_MPD[7];
                }

                if (MC_Line = "FAC3RH") {
                    RH = MC_MPD[8];
                }
            }
            else {
                ReqDay[i] = 0;
                ReqNight[i] = 0;

                ReqLEDay[i] = 0;
                ReqFONIGHT[i] = 0;

                ReqFODay[i] = 0;
                ReqFONIGHT[i] = 0;


                ACTD[i] = 0;
                ACTN[i] = 0;

                MC_ACTAS = 0;
                MCACTD1[j] = 0;
                MCACTD1[j + 1] = 0;
                MCACTD1[j + 2] = 0;
                MCACTD1[j + 3] = 0;
                MCACTD1[j + 4] = 0;
                MCACTD1[j + 5] = 0;
                MCACTD1[j + 6] = 0;
                MCACTD1[j + 7] = 0;
                MCACTD1[j + 8] = 0;
                MCACTD1[j + 9] = 0;


                MCACTN1[j] = 0;
                MCACTN1[j + 1] = 0;
                MCACTN1[j + 2] = 0;
                MCACTN1[j + 3] = 0;
                MCACTN1[j + 4] = 0;
                MCACTN1[j + 5] = 0;
                MCACTN1[j + 6] = 0;
                MCACTN1[j + 7] = 0;
                MCACTN1[j + 8] = 0;
                MCACTN1[j + 9] = 0;


            }
            //}
            j += MCCount;
        }
        MCACT1D1 = MCACTD[0];
        MCACT1D2 = MCACTD[1];
        MCACT1D3 = MCACTD[2];
        MCACT1D4 = MCACTD[3];
        MCACT1D5 = MCACTD[4];
        MCACT1D6 = MCACTD[5];
        MCACT1D7 = MCACTD[6];
        MCACT1D8 = MCACTD[7];
        MCACT1D9 = MCACTD[8];
        MCACT1D10 = MCACTD[9];

        MCACT2D1 = MCACTD[10];
        MCACT2D2 = MCACTD[11];
        MCACT2D3 = MCACTD[12];
        MCACT2D4 = MCACTD[13];
        MCACT2D5 = MCACTD[14];
        MCACT2D6 = MCACTD[15];
        MCACT2D7 = MCACTD[16];
        MCACT2D8 = MCACTD[17];
        MCACT2D9 = MCACTD[18];
        MCACT2D10 = MCACTD[19];


        MCACT3D1 = MCACTD[20];
        MCACT3D2 = MCACTD[21];
        MCACT3D3 = MCACTD[22];
        MCACT3D4 = MCACTD[23];
        MCACT3D5 = MCACTD[24];
        MCACT3D6 = MCACTD[25];
        MCACT3D7 = MCACTD[26];
        MCACT3D8 = MCACTD[27];
        MCACT3D9 = MCACTD[28];
        MCACT3D10 = MCACTD[29];
        MCACT4D1 = MCACTD[30];
        MCACT4D2 = MCACTD[31];
        MCACT4D3 = MCACTD[32];
        MCACT4D4 = MCACTD[33];
        MCACT4D5 = MCACTD[34];
        MCACT4D6 = MCACTD[35];
        MCACT4D7 = MCACTD[36];
        MCACT4D8 = MCACTD[37];
        MCACT4D9 = MCACTD[38];
        MCACT4D10 = MCACTD[39];
        MCACT5D1 = MCACTD[40];
        MCACT5D2 = MCACTD[41];
        MCACT5D3 = MCACTD[42];
        MCACT5D4 = MCACTD[43];
        MCACT5D5 = MCACTD[44];
        MCACT5D6 = MCACTD[45];
        MCACT5D7 = MCACTD[46];
        MCACT5D8 = MCACTD[47];
        MCACT5D9 = MCACTD[48];
        MCACT5D10 = MCACTD[49];
        MCACT6D1 = MCACTD[50];
        MCACT6D2 = MCACTD[51];
        MCACT6D3 = MCACTD[52];
        MCACT6D4 = MCACTD[53];
        MCACT6D5 = MCACTD[54];
        MCACT6D6 = MCACTD[55];
        MCACT6D7 = MCACTD[56];
        MCACT6D8 = MCACTD[57];
        MCACT6D9 = MCACTD[58];
        MCACT6D10 = MCACTD[59];
        MCACT7D1 = MCACTD[60];
        MCACT7D2 = MCACTD[61];
        MCACT7D3 = MCACTD[62];
        MCACT7D4 = MCACTD[63];
        MCACT7D5 = MCACTD[64];
        MCACT7D6 = MCACTD[65];
        MCACT7D7 = MCACTD[66];
        MCACT7D8 = MCACTD[67];
        MCACT7D9 = MCACTD[68];
        MCACT7D10 = MCACTD[69];
        MCACT8D1 = MCACTD[70];
        MCACT8D2 = MCACTD[71];
        MCACT8D3 = MCACTD[72];
        MCACT8D4 = MCACTD[73];
        MCACT8D5 = MCACTD[74];
        MCACT8D6 = MCACTD[75];
        MCACT8D7 = MCACTD[76];
        MCACT8D8 = MCACTD[77];
        MCACT8D9 = MCACTD[78];
        MCACT8D10 = MCACTD[79];
        MCACT9D1 = MCACTD[80];
        MCACT9D2 = MCACTD[81];
        MCACT9D3 = MCACTD[82];
        MCACT9D4 = MCACTD[83];
        MCACT9D5 = MCACTD[84];
        MCACT9D6 = MCACTD[85];
        MCACT9D7 = MCACTD[86];
        MCACT9D8 = MCACTD[87];
        MCACT9D9 = MCACTD[88];
        MCACT9D10 = MCACTD[89];
        MCACT10D1 = MCACTD[90];
        MCACT10D2 = MCACTD[91];
        MCACT10D3 = MCACTD[92];
        MCACT10D4 = MCACTD[93];
        MCACT10D5 = MCACTD[94];
        MCACT10D6 = MCACTD[95];
        MCACT10D7 = MCACTD[96];
        MCACT10D8 = MCACTD[97];
        MCACT10D9 = MCACTD[98];
        MCACT10D10 = MCACTD[99];
        MCACT11D1 = MCACTD[100];
        MCACT11D2 = MCACTD[101];
        MCACT11D3 = MCACTD[102];
        MCACT11D4 = MCACTD[103];
        MCACT11D5 = MCACTD[104];
        MCACT11D6 = MCACTD[105];
        MCACT11D7 = MCACTD[106];
        MCACT11D8 = MCACTD[107];
        MCACT11D9 = MCACTD[108];
        MCACT11D10 = MCACTD[109];
        MCACT12D1 = MCACTD[110];
        MCACT12D2 = MCACTD[111];
        MCACT12D3 = MCACTD[112];
        MCACT12D4 = MCACTD[113];
        MCACT12D5 = MCACTD[114];
        MCACT12D6 = MCACTD[115];
        MCACT12D7 = MCACTD[116];
        MCACT12D8 = MCACTD[117];
        MCACT12D9 = MCACTD[118];
        MCACT12D10 = MCACTD[119];
        MCACT13D1 = MCACTD[120];
        MCACT13D2 = MCACTD[121];
        MCACT13D3 = MCACTD[122];
        MCACT13D4 = MCACTD[123];
        MCACT13D5 = MCACTD[124];
        MCACT13D6 = MCACTD[125];
        MCACT13D7 = MCACTD[126];
        MCACT13D8 = MCACTD[127];
        MCACT13D9 = MCACTD[128];
        MCACT13D10 = MCACTD[129];
        MCACT14D1 = MCACTD[130];
        MCACT14D2 = MCACTD[131];
        MCACT14D3 = MCACTD[132];
        MCACT14D4 = MCACTD[133];
        MCACT14D5 = MCACTD[134];
        MCACT14D6 = MCACTD[135];
        MCACT14D7 = MCACTD[136];
        MCACT14D8 = MCACTD[137];
        MCACT14D9 = MCACTD[138];
        MCACT14D10 = MCACTD[139];
        MCACT15D1 = MCACTD[140];
        MCACT15D2 = MCACTD[141];
        MCACT15D3 = MCACTD[142];
        MCACT15D4 = MCACTD[143];
        MCACT15D5 = MCACTD[144];
        MCACT15D6 = MCACTD[145];
        MCACT15D7 = MCACTD[146];
        MCACT15D8 = MCACTD[147];
        MCACT15D9 = MCACTD[148];
        MCACT15D10 = MCACTD[149];
        MCACT16D1 = MCACTD[150];
        MCACT16D2 = MCACTD[151];
        MCACT16D3 = MCACTD[152];
        MCACT16D4 = MCACTD[153];
        MCACT16D5 = MCACTD[154];
        MCACT16D6 = MCACTD[155];
        MCACT16D7 = MCACTD[156];
        MCACT16D8 = MCACTD[157];
        MCACT16D9 = MCACTD[158];
        MCACT16D10 = MCACTD[159];
        MCACT17D1 = MCACTD[160];
        MCACT17D2 = MCACTD[161];
        MCACT17D3 = MCACTD[162];
        MCACT17D4 = MCACTD[163];
        MCACT17D5 = MCACTD[164];
        MCACT17D6 = MCACTD[165];
        MCACT17D7 = MCACTD[166];
        MCACT17D8 = MCACTD[167];
        MCACT17D9 = MCACTD[168];
        MCACT17D10 = MCACTD[169];
        MCACT18D1 = MCACTD[170];
        MCACT18D2 = MCACTD[171];
        MCACT18D3 = MCACTD[172];
        MCACT18D4 = MCACTD[173];
        MCACT18D5 = MCACTD[174];
        MCACT18D6 = MCACTD[175];
        MCACT18D7 = MCACTD[176];
        MCACT18D8 = MCACTD[177];
        MCACT18D9 = MCACTD[178];
        MCACT18D10 = MCACTD[179];
        MCACT19D1 = MCACTD[180];
        MCACT19D2 = MCACTD[181];
        MCACT19D3 = MCACTD[182];
        MCACT19D4 = MCACTD[183];
        MCACT19D5 = MCACTD[184];
        MCACT19D6 = MCACTD[185];
        MCACT19D7 = MCACTD[186];
        MCACT19D8 = MCACTD[187];
        MCACT19D9 = MCACTD[188];
        MCACT19D10 = MCACTD[189];
        MCACT20D1 = MCACTD[190];
        MCACT20D2 = MCACTD[191];
        MCACT20D3 = MCACTD[192];
        MCACT20D4 = MCACTD[193];
        MCACT20D5 = MCACTD[194];
        MCACT20D6 = MCACTD[195];
        MCACT20D7 = MCACTD[196];
        MCACT20D8 = MCACTD[197];
        MCACT20D9 = MCACTD[198];
        MCACT20D10 = MCACTD[199];
        MCACT21D1 = MCACTD[200];
        MCACT21D2 = MCACTD[201];
        MCACT21D3 = MCACTD[202];
        MCACT21D4 = MCACTD[203];
        MCACT21D5 = MCACTD[204];
        MCACT21D6 = MCACTD[205];
        MCACT21D7 = MCACTD[206];
        MCACT21D8 = MCACTD[207];
        MCACT21D9 = MCACTD[208];
        MCACT21D10 = MCACTD[209];
        MCACT22D1 = MCACTD[210];
        MCACT22D2 = MCACTD[211];
        MCACT22D3 = MCACTD[212];
        MCACT22D4 = MCACTD[213];
        MCACT22D5 = MCACTD[214];
        MCACT22D6 = MCACTD[215];
        MCACT22D7 = MCACTD[216];
        MCACT22D8 = MCACTD[217];
        MCACT22D9 = MCACTD[218];
        MCACT22D10 = MCACTD[219];
        MCACT23D1 = MCACTD[220];
        MCACT23D2 = MCACTD[221];
        MCACT23D3 = MCACTD[222];
        MCACT23D4 = MCACTD[223];
        MCACT23D5 = MCACTD[224];
        MCACT23D6 = MCACTD[225];
        MCACT23D7 = MCACTD[226];
        MCACT23D8 = MCACTD[227];
        MCACT23D9 = MCACTD[228];
        MCACT23D10 = MCACTD[229];
        MCACT24D1 = MCACTD[230];
        MCACT24D2 = MCACTD[231];
        MCACT24D3 = MCACTD[232];
        MCACT24D4 = MCACTD[233];
        MCACT24D5 = MCACTD[234];
        MCACT24D6 = MCACTD[235];
        MCACT24D7 = MCACTD[236];
        MCACT24D8 = MCACTD[237];
        MCACT24D9 = MCACTD[238];
        MCACT24D10 = MCACTD[239];
        MCACT25D1 = MCACTD[240];
        MCACT25D2 = MCACTD[241];
        MCACT25D3 = MCACTD[242];
        MCACT25D4 = MCACTD[243];
        MCACT25D5 = MCACTD[244];
        MCACT25D6 = MCACTD[245];
        MCACT25D7 = MCACTD[246];
        MCACT25D8 = MCACTD[247];
        MCACT25D9 = MCACTD[248];
        MCACT25D10 = MCACTD[249];
        MCACT26D1 = MCACTD[250];
        MCACT26D2 = MCACTD[251];
        MCACT26D3 = MCACTD[252];
        MCACT26D4 = MCACTD[253];
        MCACT26D5 = MCACTD[254];
        MCACT26D6 = MCACTD[255];
        MCACT26D7 = MCACTD[256];
        MCACT26D8 = MCACTD[257];
        MCACT26D9 = MCACTD[258];
        MCACT26D10 = MCACTD[259];
        MCACT27D1 = MCACTD[260];
        MCACT27D2 = MCACTD[261];
        MCACT27D3 = MCACTD[262];
        MCACT27D4 = MCACTD[263];
        MCACT27D5 = MCACTD[264];
        MCACT27D6 = MCACTD[265];
        MCACT27D7 = MCACTD[266];
        MCACT27D8 = MCACTD[267];
        MCACT27D9 = MCACTD[268];
        MCACT27D10 = MCACTD[269];
        MCACT28D1 = MCACTD[270];
        MCACT28D2 = MCACTD[271];
        MCACT28D3 = MCACTD[272];
        MCACT28D4 = MCACTD[273];
        MCACT28D5 = MCACTD[274];
        MCACT28D6 = MCACTD[275];
        MCACT28D7 = MCACTD[276];
        MCACT28D8 = MCACTD[277];
        MCACT28D9 = MCACTD[278];
        MCACT28D10 = MCACTD[279];
        MCACT29D1 = MCACTD[280];
        MCACT29D2 = MCACTD[281];
        MCACT29D3 = MCACTD[282];
        MCACT29D4 = MCACTD[283];
        MCACT29D5 = MCACTD[284];
        MCACT29D6 = MCACTD[285];
        MCACT29D7 = MCACTD[286];
        MCACT29D8 = MCACTD[287];
        MCACT29D9 = MCACTD[288];
        MCACT29D10 = MCACTD[289];
        MCACT30D1 = MCACTD[290];
        MCACT30D2 = MCACTD[291];
        MCACT30D3 = MCACTD[292];
        MCACT30D4 = MCACTD[293];
        MCACT30D5 = MCACTD[294];
        MCACT30D6 = MCACTD[295];
        MCACT30D7 = MCACTD[296];
        MCACT30D8 = MCACTD[297];
        MCACT30D9 = MCACTD[298];
        MCACT30D10 = MCACTD[299];
        MCACT31D1 = MCACTD[300];
        MCACT31D2 = MCACTD[301];
        MCACT31D3 = MCACTD[302];
        MCACT31D4 = MCACTD[303];
        MCACT31D5 = MCACTD[304];
        MCACT31D6 = MCACTD[305];
        MCACT31D7 = MCACTD[306];
        MCACT31D8 = MCACTD[307];
        MCACT31D9 = MCACTD[308];
        MCACT31D10 = MCACTD[309];



        MCACT1N1 = MCACTN[0];
        MCACT1N2 = MCACTN[1];
        MCACT1N3 = MCACTN[2];
        MCACT1N4 = MCACTN[3];
        MCACT1N5 = MCACTN[4];
        MCACT1N6 = MCACTN[5];
        MCACT1N7 = MCACTN[6];
        MCACT1N8 = MCACTN[7];
        MCACT1N9 = MCACTN[8];
        MCACT1N10 = MCACTN[9];
        MCACT2N1 = MCACTN[10];
        MCACT2N2 = MCACTN[11];
        MCACT2N3 = MCACTN[12];
        MCACT2N4 = MCACTN[13];
        MCACT2N5 = MCACTN[14];
        MCACT2N6 = MCACTN[15];
        MCACT2N7 = MCACTN[16];
        MCACT2N8 = MCACTN[17];
        MCACT2N9 = MCACTN[18];
        MCACT2N10 = MCACTN[19];
        MCACT3N1 = MCACTN[20];
        MCACT3N2 = MCACTN[21];
        MCACT3N3 = MCACTN[22];
        MCACT3N4 = MCACTN[23];
        MCACT3N5 = MCACTN[24];
        MCACT3N6 = MCACTN[25];
        MCACT3N7 = MCACTN[26];
        MCACT3N8 = MCACTN[27];
        MCACT3N9 = MCACTN[28];
        MCACT3N10 = MCACTN[29];
        MCACT4N1 = MCACTN[30];
        MCACT4N2 = MCACTN[31];
        MCACT4N3 = MCACTN[32];
        MCACT4N4 = MCACTN[33];
        MCACT4N5 = MCACTN[34];
        MCACT4N6 = MCACTN[35];
        MCACT4N7 = MCACTN[36];
        MCACT4N8 = MCACTN[37];
        MCACT4N9 = MCACTN[38];
        MCACT4N10 = MCACTN[39];
        MCACT5N1 = MCACTN[40];
        MCACT5N2 = MCACTN[41];
        MCACT5N3 = MCACTN[42];
        MCACT5N4 = MCACTN[43];
        MCACT5N5 = MCACTN[44];
        MCACT5N6 = MCACTN[45];
        MCACT5N7 = MCACTN[46];
        MCACT5N8 = MCACTN[47];
        MCACT5N9 = MCACTN[48];
        MCACT5N10 = MCACTN[49];
        MCACT6N1 = MCACTN[50];
        MCACT6N2 = MCACTN[51];
        MCACT6N3 = MCACTN[52];
        MCACT6N4 = MCACTN[53];
        MCACT6N5 = MCACTN[54];
        MCACT6N6 = MCACTN[55];
        MCACT6N7 = MCACTN[56];
        MCACT6N8 = MCACTN[57];
        MCACT6N9 = MCACTN[58];
        MCACT6N10 = MCACTN[59];
        MCACT7N1 = MCACTN[60];
        MCACT7N2 = MCACTN[61];
        MCACT7N3 = MCACTN[62];
        MCACT7N4 = MCACTN[63];
        MCACT7N5 = MCACTN[64];
        MCACT7N6 = MCACTN[65];
        MCACT7N7 = MCACTN[66];
        MCACT7N8 = MCACTN[67];
        MCACT7N9 = MCACTN[68];
        MCACT7N10 = MCACTN[69];
        MCACT8N1 = MCACTN[70];
        MCACT8N2 = MCACTN[71];
        MCACT8N3 = MCACTN[72];
        MCACT8N4 = MCACTN[73];
        MCACT8N5 = MCACTN[74];
        MCACT8N6 = MCACTN[75];
        MCACT8N7 = MCACTN[76];
        MCACT8N8 = MCACTN[77];
        MCACT8N9 = MCACTN[78];
        MCACT8N10 = MCACTN[79];
        MCACT9N1 = MCACTN[80];
        MCACT9N2 = MCACTN[81];
        MCACT9N3 = MCACTN[82];
        MCACT9N4 = MCACTN[83];
        MCACT9N5 = MCACTN[84];
        MCACT9N6 = MCACTN[85];
        MCACT9N7 = MCACTN[86];
        MCACT9N8 = MCACTN[87];
        MCACT9N9 = MCACTN[88];
        MCACT9N10 = MCACTN[89];
        MCACT10N1 = MCACTN[90];
        MCACT10N2 = MCACTN[91];
        MCACT10N3 = MCACTN[92];
        MCACT10N4 = MCACTN[93];
        MCACT10N5 = MCACTN[94];
        MCACT10N6 = MCACTN[95];
        MCACT10N7 = MCACTN[96];
        MCACT10N8 = MCACTN[97];
        MCACT10N9 = MCACTN[98];
        MCACT10N10 = MCACTN[99];
        MCACT11N1 = MCACTN[100];
        MCACT11N2 = MCACTN[101];
        MCACT11N3 = MCACTN[102];
        MCACT11N4 = MCACTN[103];
        MCACT11N5 = MCACTN[104];
        MCACT11N6 = MCACTN[105];
        MCACT11N7 = MCACTN[106];
        MCACT11N8 = MCACTN[107];
        MCACT11N9 = MCACTN[108];
        MCACT11N10 = MCACTN[109];
        MCACT12N1 = MCACTN[110];
        MCACT12N2 = MCACTN[111];
        MCACT12N3 = MCACTN[112];
        MCACT12N4 = MCACTN[113];
        MCACT12N5 = MCACTN[114];
        MCACT12N6 = MCACTN[115];
        MCACT12N7 = MCACTN[116];
        MCACT12N8 = MCACTN[117];
        MCACT12N9 = MCACTN[118];
        MCACT12N10 = MCACTN[119];
        MCACT13N1 = MCACTN[120];
        MCACT13N2 = MCACTN[121];
        MCACT13N3 = MCACTN[122];
        MCACT13N4 = MCACTN[123];
        MCACT13N5 = MCACTN[124];
        MCACT13N6 = MCACTN[125];
        MCACT13N7 = MCACTN[126];
        MCACT13N8 = MCACTN[127];
        MCACT13N9 = MCACTN[128];
        MCACT13N10 = MCACTN[129];
        MCACT14N1 = MCACTN[130];
        MCACT14N2 = MCACTN[131];
        MCACT14N3 = MCACTN[132];
        MCACT14N4 = MCACTN[133];
        MCACT14N5 = MCACTN[134];
        MCACT14N6 = MCACTN[135];
        MCACT14N7 = MCACTN[136];
        MCACT14N8 = MCACTN[137];
        MCACT14N9 = MCACTN[138];
        MCACT14N10 = MCACTN[139];
        MCACT15N1 = MCACTN[140];
        MCACT15N2 = MCACTN[141];
        MCACT15N3 = MCACTN[142];
        MCACT15N4 = MCACTN[143];
        MCACT15N5 = MCACTN[144];
        MCACT15N6 = MCACTN[145];
        MCACT15N7 = MCACTN[146];
        MCACT15N8 = MCACTN[147];
        MCACT15N9 = MCACTN[148];
        MCACT15N10 = MCACTN[149];
        MCACT16N1 = MCACTN[150];
        MCACT16N2 = MCACTN[151];
        MCACT16N3 = MCACTN[152];
        MCACT16N4 = MCACTN[153];
        MCACT16N5 = MCACTN[154];
        MCACT16N6 = MCACTN[155];
        MCACT16N7 = MCACTN[156];
        MCACT16N8 = MCACTN[157];
        MCACT16N9 = MCACTN[158];
        MCACT16N10 = MCACTN[159];
        MCACT17N1 = MCACTN[160];
        MCACT17N2 = MCACTN[161];
        MCACT17N3 = MCACTN[162];
        MCACT17N4 = MCACTN[163];
        MCACT17N5 = MCACTN[164];
        MCACT17N6 = MCACTN[165];
        MCACT17N7 = MCACTN[166];
        MCACT17N8 = MCACTN[167];
        MCACT17N9 = MCACTN[168];
        MCACT17N10 = MCACTN[169];
        MCACT18N1 = MCACTN[170];
        MCACT18N2 = MCACTN[171];
        MCACT18N3 = MCACTN[172];
        MCACT18N4 = MCACTN[173];
        MCACT18N5 = MCACTN[174];
        MCACT18N6 = MCACTN[175];
        MCACT18N7 = MCACTN[176];
        MCACT18N8 = MCACTN[177];
        MCACT18N9 = MCACTN[178];
        MCACT18N10 = MCACTN[179];
        MCACT19N1 = MCACTN[180];
        MCACT19N2 = MCACTN[181];
        MCACT19N3 = MCACTN[182];
        MCACT19N4 = MCACTN[183];
        MCACT19N5 = MCACTN[184];
        MCACT19N6 = MCACTN[185];
        MCACT19N7 = MCACTN[186];
        MCACT19N8 = MCACTN[187];
        MCACT19N9 = MCACTN[188];
        MCACT19N10 = MCACTN[189];
        MCACT20N1 = MCACTN[190];
        MCACT20N2 = MCACTN[191];
        MCACT20N3 = MCACTN[192];
        MCACT20N4 = MCACTN[193];
        MCACT20N5 = MCACTN[194];
        MCACT20N6 = MCACTN[195];
        MCACT20N7 = MCACTN[196];
        MCACT20N8 = MCACTN[197];
        MCACT20N9 = MCACTN[198];
        MCACT20N10 = MCACTN[199];
        MCACT21N1 = MCACTN[200];
        MCACT21N2 = MCACTN[201];
        MCACT21N3 = MCACTN[202];
        MCACT21N4 = MCACTN[203];
        MCACT21N5 = MCACTN[204];
        MCACT21N6 = MCACTN[205];
        MCACT21N7 = MCACTN[206];
        MCACT21N8 = MCACTN[207];
        MCACT21N9 = MCACTN[208];
        MCACT21N10 = MCACTN[209];
        MCACT22N1 = MCACTN[210];
        MCACT22N2 = MCACTN[211];
        MCACT22N3 = MCACTN[212];
        MCACT22N4 = MCACTN[213];
        MCACT22N5 = MCACTN[214];
        MCACT22N6 = MCACTN[215];
        MCACT22N7 = MCACTN[216];
        MCACT22N8 = MCACTN[217];
        MCACT22N9 = MCACTN[218];
        MCACT22N10 = MCACTN[219];
        MCACT23N1 = MCACTN[220];
        MCACT23N2 = MCACTN[221];
        MCACT23N3 = MCACTN[222];
        MCACT23N4 = MCACTN[223];
        MCACT23N5 = MCACTN[224];
        MCACT23N6 = MCACTN[225];
        MCACT23N7 = MCACTN[226];
        MCACT23N8 = MCACTN[227];
        MCACT23N9 = MCACTN[228];
        MCACT23N10 = MCACTN[229];
        MCACT24N1 = MCACTN[230];
        MCACT24N2 = MCACTN[231];
        MCACT24N3 = MCACTN[232];
        MCACT24N4 = MCACTN[233];
        MCACT24N5 = MCACTN[234];
        MCACT24N6 = MCACTN[235];
        MCACT24N7 = MCACTN[236];
        MCACT24N8 = MCACTN[237];
        MCACT24N9 = MCACTN[238];
        MCACT24N10 = MCACTN[239];
        MCACT25N1 = MCACTN[240];
        MCACT25N2 = MCACTN[241];
        MCACT25N3 = MCACTN[242];
        MCACT25N4 = MCACTN[243];
        MCACT25N5 = MCACTN[244];
        MCACT25N6 = MCACTN[245];
        MCACT25N7 = MCACTN[246];
        MCACT25N8 = MCACTN[247];
        MCACT25N9 = MCACTN[248];
        MCACT25N10 = MCACTN[249];
        MCACT26N1 = MCACTN[250];
        MCACT26N2 = MCACTN[251];
        MCACT26N3 = MCACTN[252];
        MCACT26N4 = MCACTN[253];
        MCACT26N5 = MCACTN[254];
        MCACT26N6 = MCACTN[255];
        MCACT26N7 = MCACTN[256];
        MCACT26N8 = MCACTN[257];
        MCACT26N9 = MCACTN[258];
        MCACT26N10 = MCACTN[259];
        MCACT27N1 = MCACTN[260];
        MCACT27N2 = MCACTN[261];
        MCACT27N3 = MCACTN[262];
        MCACT27N4 = MCACTN[263];
        MCACT27N5 = MCACTN[264];
        MCACT27N6 = MCACTN[265];
        MCACT27N7 = MCACTN[266];
        MCACT27N8 = MCACTN[267];
        MCACT27N9 = MCACTN[268];
        MCACT27N10 = MCACTN[269];
        MCACT28N1 = MCACTN[270];
        MCACT28N2 = MCACTN[271];
        MCACT28N3 = MCACTN[272];
        MCACT28N4 = MCACTN[273];
        MCACT28N5 = MCACTN[274];
        MCACT28N6 = MCACTN[275];
        MCACT28N7 = MCACTN[276];
        MCACT28N8 = MCACTN[277];
        MCACT28N9 = MCACTN[278];
        MCACT28N10 = MCACTN[279];
        MCACT29N1 = MCACTN[280];
        MCACT29N2 = MCACTN[281];
        MCACT29N3 = MCACTN[282];
        MCACT29N4 = MCACTN[283];
        MCACT29N5 = MCACTN[284];
        MCACT29N6 = MCACTN[285];
        MCACT29N7 = MCACTN[286];
        MCACT29N8 = MCACTN[287];
        MCACT29N9 = MCACTN[288];
        MCACT29N10 = MCACTN[289];
        MCACT30N1 = MCACTN[290];
        MCACT30N2 = MCACTN[291];
        MCACT30N3 = MCACTN[292];
        MCACT30N4 = MCACTN[293];
        MCACT30N5 = MCACTN[294];
        MCACT30N6 = MCACTN[295];
        MCACT30N7 = MCACTN[296];
        MCACT30N8 = MCACTN[297];
        MCACT30N9 = MCACTN[298];
        MCACT30N10 = MCACTN[299];
        MCACT31N1 = MCACTN[300];
        MCACT31N2 = MCACTN[301];
        MCACT31N3 = MCACTN[302];
        MCACT31N4 = MCACTN[303];
        MCACT31N5 = MCACTN[304];
        MCACT31N6 = MCACTN[305];
        MCACT31N7 = MCACTN[306];
        MCACT31N8 = MCACTN[307];
        MCACT31N9 = MCACTN[308];
        MCACT31N10 = MCACTN[309];




        ReqD1 = ReqDay[0];
        ReqD2 = ReqDay[1];
        ReqD3 = ReqDay[2];
        ReqD4 = ReqDay[3];
        ReqD5 = ReqDay[4];
        ReqD6 = ReqDay[5];
        ReqD7 = ReqDay[6];
        ReqD8 = ReqDay[7];
        ReqD9 = ReqDay[8];
        ReqD10 = ReqDay[9];
        ReqD11 = ReqDay[10];
        ReqD12 = ReqDay[11];
        ReqD13 = ReqDay[12];
        ReqD14 = ReqDay[13];
        ReqD15 = ReqDay[14];
        ReqD16 = ReqDay[15];
        ReqD17 = ReqDay[16];
        ReqD18 = ReqDay[17];
        ReqD19 = ReqDay[18];
        ReqD20 = ReqDay[19];
        ReqD21 = ReqDay[20];
        ReqD22 = ReqDay[21];
        ReqD23 = ReqDay[22];
        ReqD24 = ReqDay[23];
        ReqD25 = ReqDay[24];
        ReqD26 = ReqDay[25];
        ReqD27 = ReqDay[26];
        ReqD28 = ReqDay[27];
        ReqD29 = ReqDay[28];
        ReqD30 = ReqDay[29];
        ReqD31 = ReqDay[30];


        ReqLED1 = ReqLEDay[0];
        ReqLED2 = ReqLEDay[1];
        ReqLED3 = ReqLEDay[2];
        ReqLED4 = ReqLEDay[3];
        ReqLED5 = ReqLEDay[4];
        ReqLED6 = ReqLEDay[5];
        ReqLED7 = ReqLEDay[6];
        ReqLED8 = ReqLEDay[7];
        ReqLED9 = ReqLEDay[8];
        ReqLED10 = ReqLEDay[9];
        ReqLED11 = ReqLEDay[10];
        ReqLED12 = ReqLEDay[11];
        ReqLED13 = ReqLEDay[12];
        ReqLED14 = ReqLEDay[13];
        ReqLED15 = ReqLEDay[14];
        ReqLED16 = ReqLEDay[15];
        ReqLED17 = ReqLEDay[16];
        ReqLED18 = ReqLEDay[17];
        ReqLED19 = ReqLEDay[18];
        ReqLED20 = ReqLEDay[19];
        ReqLED21 = ReqLEDay[20];
        ReqLED22 = ReqLEDay[21];
        ReqLED23 = ReqLEDay[22];
        ReqLED24 = ReqLEDay[23];
        ReqLED25 = ReqLEDay[24];
        ReqLED26 = ReqLEDay[25];
        ReqLED27 = ReqLEDay[26];
        ReqLED28 = ReqLEDay[27];
        ReqLED29 = ReqLEDay[28];
        ReqLED30 = ReqLEDay[29];
        ReqLED31 = ReqLEDay[30];

        ReqLENIGHT1 = ReqLENIGHT[0];
        ReqLENIGHT2 = ReqLENIGHT[1];
        ReqLENIGHT3 = ReqLENIGHT[2];
        ReqLENIGHT4 = ReqLENIGHT[3];
        ReqLENIGHT5 = ReqLENIGHT[4];
        ReqLENIGHT6 = ReqLENIGHT[5];
        ReqLENIGHT7 = ReqLENIGHT[6];
        ReqLENIGHT8 = ReqLENIGHT[7];
        ReqLENIGHT9 = ReqLENIGHT[8];
        ReqLENIGHT10 = ReqLENIGHT[9];
        ReqLENIGHT11 = ReqLENIGHT[10];
        ReqLENIGHT12 = ReqLENIGHT[11];
        ReqLENIGHT13 = ReqLENIGHT[12];
        ReqLENIGHT14 = ReqLENIGHT[13];
        ReqLENIGHT15 = ReqLENIGHT[14];
        ReqLENIGHT16 = ReqLENIGHT[15];
        ReqLENIGHT17 = ReqLENIGHT[16];
        ReqLENIGHT18 = ReqLENIGHT[17];
        ReqLENIGHT19 = ReqLENIGHT[18];
        ReqLENIGHT20 = ReqLENIGHT[19];
        ReqLENIGHT21 = ReqLENIGHT[20];
        ReqLENIGHT22 = ReqLENIGHT[21];
        ReqLENIGHT23 = ReqLENIGHT[22];
        ReqLENIGHT24 = ReqLENIGHT[23];
        ReqLENIGHT25 = ReqLENIGHT[24];
        ReqLENIGHT26 = ReqLENIGHT[25];
        ReqLENIGHT27 = ReqLENIGHT[26];
        ReqLENIGHT28 = ReqLENIGHT[27];
        ReqLENIGHT29 = ReqLENIGHT[28];
        ReqLENIGHT30 = ReqLENIGHT[29];
        ReqLENIGHT31 = ReqLENIGHT[30];


        ReqFOD1 = ReqFODay[0];
        ReqFOD2 = ReqFODay[1];
        ReqFOD3 = ReqFODay[2];
        ReqFOD4 = ReqFODay[3];
        ReqFOD5 = ReqFODay[4];
        ReqFOD6 = ReqFODay[5];
        ReqFOD7 = ReqFODay[6];
        ReqFOD8 = ReqFODay[7];
        ReqFOD9 = ReqFODay[8];
        ReqFOD10 = ReqFODay[9];
        ReqFOD11 = ReqFODay[10];
        ReqFOD12 = ReqFODay[11];
        ReqFOD13 = ReqFODay[12];
        ReqFOD14 = ReqFODay[13];
        ReqFOD15 = ReqFODay[14];
        ReqFOD16 = ReqFODay[15];
        ReqFOD17 = ReqFODay[16];
        ReqFOD18 = ReqFODay[17];
        ReqFOD19 = ReqFODay[18];
        ReqFOD20 = ReqFODay[19];
        ReqFOD21 = ReqFODay[20];
        ReqFOD22 = ReqFODay[21];
        ReqFOD23 = ReqFODay[22];
        ReqFOD24 = ReqFODay[23];
        ReqFOD25 = ReqFODay[24];
        ReqFOD26 = ReqFODay[25];
        ReqFOD27 = ReqFODay[26];
        ReqFOD28 = ReqFODay[27];
        ReqFOD29 = ReqFODay[28];
        ReqFOD30 = ReqFODay[29];
        ReqFOD31 = ReqFODay[30];

        ReqFONIGHT1 = ReqFONIGHT[0];
        ReqFONIGHT2 = ReqFONIGHT[1];
        ReqFONIGHT3 = ReqFONIGHT[2];
        ReqFONIGHT4 = ReqFONIGHT[3];
        ReqFONIGHT5 = ReqFONIGHT[4];
        ReqFONIGHT6 = ReqFONIGHT[5];
        ReqFONIGHT7 = ReqFONIGHT[6];
        ReqFONIGHT8 = ReqFONIGHT[7];
        ReqFONIGHT9 = ReqFONIGHT[8];
        ReqFONIGHT10 = ReqFONIGHT[9];
        ReqFONIGHT11 = ReqFONIGHT[10];
        ReqFONIGHT12 = ReqFONIGHT[11];
        ReqFONIGHT13 = ReqFONIGHT[12];
        ReqFONIGHT14 = ReqFONIGHT[13];
        ReqFONIGHT15 = ReqFONIGHT[14];
        ReqFONIGHT16 = ReqFONIGHT[15];
        ReqFONIGHT17 = ReqFONIGHT[16];
        ReqFONIGHT18 = ReqFONIGHT[17];
        ReqFONIGHT19 = ReqFONIGHT[18];
        ReqFONIGHT20 = ReqFONIGHT[19];
        ReqFONIGHT21 = ReqFONIGHT[20];
        ReqFONIGHT22 = ReqFONIGHT[21];
        ReqFONIGHT23 = ReqFONIGHT[22];
        ReqFONIGHT24 = ReqFONIGHT[23];
        ReqFONIGHT25 = ReqFONIGHT[24];
        ReqFONIGHT26 = ReqFONIGHT[25];
        ReqFONIGHT27 = ReqFONIGHT[26];
        ReqFONIGHT28 = ReqFONIGHT[27];
        ReqFONIGHT29 = ReqFONIGHT[28];
        ReqFONIGHT30 = ReqFONIGHT[29];
        ReqFONIGHT31 = ReqFONIGHT[30];


        ActD1 = ACTD[0];
        ActD2 = ACTD[1];
        ActD3 = ACTD[2];
        ActD4 = ACTD[3];
        ActD5 = ACTD[4];
        ActD6 = ACTD[5];
        ActD7 = ACTD[6];
        ActD8 = ACTD[7];
        ActD9 = ACTD[8];
        ActD10 = ACTD[9];
        ActD11 = ACTD[10];
        ActD12 = ACTD[11];
        ActD13 = ACTD[12];
        ActD14 = ACTD[13];
        ActD15 = ACTD[14];
        ActD16 = ACTD[15];
        ActD17 = ACTD[16];
        ActD18 = ACTD[17];
        ActD19 = ACTD[18];
        ActD20 = ACTD[19];
        ActD21 = ACTD[20];
        ActD22 = ACTD[21];
        ActD23 = ACTD[22];
        ActD24 = ACTD[23];
        ActD25 = ACTD[24];
        ActD26 = ACTD[25];
        ActD27 = ACTD[26];
        ActD28 = ACTD[27];
        ActD29 = ACTD[28];
        ActD30 = ACTD[29];
        ActD31 = ACTD[30];

        DiffD1 = DiffDay[0];
        DiffD2 = DiffDay[1];
        DiffD3 = DiffDay[2];
        DiffD4 = DiffDay[3];
        DiffD5 = DiffDay[4];
        DiffD6 = DiffDay[5];
        DiffD7 = DiffDay[6];
        DiffD8 = DiffDay[7];
        DiffD9 = DiffDay[8];
        DiffD10 = DiffDay[9];
        DiffD11 = DiffDay[10];
        DiffD12 = DiffDay[11];
        DiffD13 = DiffDay[12];
        DiffD14 = DiffDay[13];
        DiffD15 = DiffDay[14];
        DiffD16 = DiffDay[15];
        DiffD17 = DiffDay[16];
        DiffD18 = DiffDay[17];
        DiffD19 = DiffDay[18];
        DiffD20 = DiffDay[19];
        DiffD21 = DiffDay[20];
        DiffD22 = DiffDay[21];
        DiffD23 = DiffDay[22];
        DiffD24 = DiffDay[23];
        DiffD25 = DiffDay[24];
        DiffD26 = DiffDay[25];
        DiffD27 = DiffDay[26];
        DiffD28 = DiffDay[27];
        DiffD29 = DiffDay[28];
        DiffD30 = DiffDay[29];
        DiffD31 = DiffDay[30];


        ReqN1 = ReqNight[0];
        ReqN2 = ReqNight[1];
        ReqN3 = ReqNight[2];
        ReqN4 = ReqNight[3];
        ReqN5 = ReqNight[4];
        ReqN6 = ReqNight[5];
        ReqN7 = ReqNight[6];
        ReqN8 = ReqNight[7];
        ReqN9 = ReqNight[8];
        ReqN10 = ReqNight[9];
        ReqN11 = ReqNight[10];
        ReqN12 = ReqNight[11];
        ReqN13 = ReqNight[12];
        ReqN14 = ReqNight[13];
        ReqN15 = ReqNight[14];
        ReqN16 = ReqNight[15];
        ReqN17 = ReqNight[16];
        ReqN18 = ReqNight[17];
        ReqN19 = ReqNight[18];
        ReqN20 = ReqNight[19];
        ReqN21 = ReqNight[20];
        ReqN22 = ReqNight[21];
        ReqN23 = ReqNight[22];
        ReqN24 = ReqNight[23];
        ReqN25 = ReqNight[24];
        ReqN26 = ReqNight[25];
        ReqN27 = ReqNight[26];
        ReqN28 = ReqNight[27];
        ReqN29 = ReqNight[28];
        ReqN30 = ReqNight[29];
        ReqN31 = ReqNight[30];

        ActN1 = ACTN[0];
        ActN2 = ACTN[1];
        ActN3 = ACTN[2];
        ActN4 = ACTN[3];
        ActN5 = ACTN[4];
        ActN6 = ACTN[5];
        ActN7 = ACTN[6];
        ActN8 = ACTN[7];
        ActN9 = ACTN[8];
        ActN10 = ACTN[9];
        ActN11 = ACTN[10];
        ActN12 = ACTN[11];
        ActN13 = ACTN[12];
        ActN14 = ACTN[13];
        ActN15 = ACTN[14];
        ActN16 = ACTN[15];
        ActN17 = ACTN[16];
        ActN18 = ACTN[17];
        ActN19 = ACTN[18];
        ActN20 = ACTN[19];
        ActN21 = ACTN[20];
        ActN22 = ACTN[21];
        ActN23 = ACTN[22];
        ActN24 = ACTN[23];
        ActN25 = ACTN[24];
        ActN26 = ACTN[25];
        ActN27 = ACTN[26];
        ActN28 = ACTN[27];
        ActN29 = ACTN[28];
        ActN30 = ACTN[29];
        ActN31 = ACTN[30];


        DiffN1 = DiffNight[0];
        DiffN2 = DiffNight[1];
        DiffN3 = DiffNight[2];
        DiffN4 = DiffNight[3];
        DiffN5 = DiffNight[4];
        DiffN6 = DiffNight[5];
        DiffN7 = DiffNight[6];
        DiffN8 = DiffNight[7];
        DiffN9 = DiffNight[8];
        DiffN10 = DiffNight[9];
        DiffN11 = DiffNight[10];
        DiffN12 = DiffNight[11];
        DiffN13 = DiffNight[12];
        DiffN14 = DiffNight[13];
        DiffN15 = DiffNight[14];
        DiffN16 = DiffNight[15];
        DiffN17 = DiffNight[16];
        DiffN18 = DiffNight[17];
        DiffN19 = DiffNight[18];
        DiffN20 = DiffNight[19];
        DiffN21 = DiffNight[20];
        DiffN22 = DiffNight[21];
        DiffN23 = DiffNight[22];
        DiffN24 = DiffNight[23];
        DiffN25 = DiffNight[24];
        DiffN26 = DiffNight[25];
        DiffN27 = DiffNight[26];
        DiffN28 = DiffNight[27];
        DiffN29 = DiffNight[28];
        DiffN30 = DiffNight[29];
        DiffN31 = DiffNight[30];

        //  var testValue = ReqD1;


        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column', backgroundColor: '#F2F2F2',
                //backgroundColor: {
                //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                //    stops: [
                //         [0, '#098996'],
                //              [1, '#054C54']
                //       //[0, '#FBFBD4'],
                //       //       [1, '#C7C6A1']
                //    ]
                //},
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '##581845',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: DayTOO,
                labels: {
                    style: {
                        color: '##581845',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [{
                className: 'highcharts-color-0',
                title: {

                    text: 'Employee',
                    style: {
                        color: '##581845',
                        fontWeight: 'bold'
                    }
                },
                labels: {
                    format: '{value:,.0f}.',
                    style: {
                        color: '##581845',
                        fontSize: '10px'
                    }
                },
                //max: 150,
                //min: 0,

                //stackLabels: {
                //    enabled: false,
                //    style: {
                //        fontWeight: 'bold',
                //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                //    }
                //}


            }, {

                title: {
                    text: 'Prod'
                },
                //max: 5000,
                //min: -120,
                opposite: true
            }],

            legend: {
                align: 'middle',
                x: -10,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            //legend: {
            //    shadow: false
            //},
            tooltip: {
                shared: true
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    //grouping: false,
                    //shadow: false,
                    //borderWidth: 0
                }
            },

            series: [
                 {
                    // type: 'line',
                     //name: 'PD',
                     //color: '#0034F7',
                     //borderColor: '#E59866',
                     //data: PD,
                  //   stack: '1',

                 },
                  
           {



                name: 'FO_Day',
                color: '#0034F7',
                borderColor: '#E59866',
                data: ReqFODay,
                pointWidth: 18,
                stack: '1',

           }, {

               name: 'LE_Day',
               color: '#F9FF33',
               borderColor: '#E59866',
               data: ReqLEDay,
               pointWidth: 18,
               stack: '1',
          }, {
                name: 'OP',
                color:
                '#E59866',
                borderColor: '#E59866',
                data: ReqDay,
                stack: '1',
          },
         
          {

              name: 'FO_Night',
              color: '#0034F7',
              borderColor: '#E59866',
              data: ReqFONIGHT,
             pointWidth: 18,
              stack: '2',


          }, 
            {

                name: 'LE_Night',
                color: '#F9FF33',
                borderColor: '#E59866',
                data: ReqLENIGHT,
                pointWidth: 18,
                stack: '2',

            },
            {
                name: 'OP',
                color: '#5B2C6F',
                borderColor: '#5B2C6F',
                data: ReqNight,
                stack: '2',

            },
            ]

        });
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });




}



function loadChartMPFac3Machine(_objChart, _CostCenter, _DataDate, _DataMonth) {

    var DataMonth = new Date(_DataMonth);
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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMPReqD = new Array();
    var SUMMPReqN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();


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


    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

    if (_CostCenter == "MPALL") {
        dataTitle = "DIRECT : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC1") {
        dataTitle = "DIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2") {
        dataTitle = "DIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3") {
        dataTitle = "DIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3M") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3CS") {
        dataTitle = "DIRECT : Factory 3 CS " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3A") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3MPrev") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev2") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev2") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev3") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev3") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODM") {
        dataTitle = "DIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev2") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev2") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev2") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev2") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev3") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev3") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev3") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev3") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

    } else if (_CostCenter == "MPMTALL") {
        dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
        //    success: function (ResponseData) {
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

            //OPPosition.push([ResponseData[i].OPPosition]);
            //OPOT1.push([ResponseData[i].OPOT1]);
            //OPOT15.push([ResponseData[i].OPOT15]);
            //OPOT2.push([ResponseData[i].OPOT2]);
            //OPOT3.push([ResponseData[i].OPOT3]);
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


            SUMMPReqD.push([ResponseData[i].SumMPD]);
            SUMMPReqN.push([ResponseData[i].SumMPN]);
            SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
            SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
            SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
            SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


            //  SUMMPH.push([ResponseData[i].SumMPH]);
            //  SUMMP.push([ResponseData[i].SumMP]);


            MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
            MP_ACT.push([ResponseData[i].SumMP_ACT]);



            DD.push([ResponseData[i].Xdate]);
            Dayto.push([ResponseData[i].DatetoDay]);
            MC_Name.push([ResponseData[i].MC_Name]);
            // DayWeek = DD + ":" + Dayto;
        }

        //------------------------- Chart summary direct -----------------------------            
        Highcharts.chart(_objChart, {

            chart: {
                type: 'column', backgroundColor: '#F2F2F2',
                //backgroundColor: {
                //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                //    stops: [
                //         [0, '#098996'],
                //              [1, '#054C54']
                //       //[0, '#FBFBD4'],
                //       //       [1, '#C7C6A1']
                //    ]
                //},
                style: {
                    fontFamily: '\'Unica One\', sans-serif'
                },
                plotBorderColor: '#0A0A0A'
            },
            title: {
                text: dataTitle,
                style: {
                    color: '##581845',
                    fontWeight: 'bold'
                }
            },
            xAxis: {
                categories: MC_Name,
                labels: {
                    style: {
                        color: '##581845',
                        fontSize: '12px'
                    }
                }
            },

            yAxis: [{
                className: 'highcharts-color-0',
                title: {

                    text: 'Employee',
                    style: {
                        color: '##581845',
                        fontWeight: 'bold'
                    }
                },
                labels: {
                    format: '{value:,.0f}.',
                    style: {
                        color: '##581845',
                        fontSize: '10px'
                    }
                },
                max: 15,
                min: 0,

                //stackLabels: {
                //    enabled: false,
                //    style: {
                //        fontWeight: 'bold',
                //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                //    }
                //}


            }, {

                title: {
                    text: 'Diff'
                },
                max: 15,
                min: 0,
                opposite: true
            }],

            legend: {
                align: 'right',
                x: -10,
                verticalAlign: 'top',
                y: 20,
                floating: true,
                color: 'White',
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            //legend: {
            //    shadow: false
            //},
            tooltip: {
                shared: true
            },
            plotOptions: {
                column: {
                    grouping: false,
                    shadow: false,
                    borderWidth: 0
                }
            },

            series: [

            //{

            //    name: 'Diff_ManPowerDay',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFD,
            //    //pointPadding: 0.2,
            //    //pointPlacement: -0.2,
            //   // stack: 'D'

            //},
             //{
             //    name: 'MP/Shift',
             //    color:
             //    '#E59866',
             //    borderColor: '#FFD733',
             //    data: MP_Shift,
             //    pointWidth: 30,
             //    //pointPadding: 0.2,
             //    pointPlacement: -0.2,
             //    // stack: 'D'

             //},
            {
                name: 'ManPower Day',
                color:
                '#E59866',
                borderColor: '#E59866',
                data: SUMMPReqD,
                pointWidth: 18,
                //pointPadding: 0.2,
                pointPlacement: -0.2,
                // stack: 'D'

            }, {

                name: 'Actual Day',
                color: '#FC1801',
                borderColor: '#FC1801',
                data: SUMMP_ACTD,
                //pointPadding: 0.3,
                pointWidth: 8,
                pointPlacement: -0.2,
                // stack: 'D'

            },
            //{

            //    name: 'Diff_ManPowerNight',
            //    color: '#F801FC',
            //    borderColor: '#F801FC',
            //    data: SUMMP_DIFFN,
            //    //pointPadding: 0.4,
            //    //pointPlacement: -0.2,
            //    stack: 'N'

            //},
              {
                  name: 'ManPowerNight',
                  color: '#5B2C6F',
                  borderColor: '#5B2C6F',
                  data: SUMMPReqN,
                  //pointPadding: 0.2,
                  pointWidth: 18,
                  pointPlacement: 0.2
                  //stack: 'N'
              }, {

                  name: 'Actual Night',
                  color: '#FC1801',
                  borderColor: '#FC1801',
                  data: SUMMP_ACTN,
                  //pointPadding: 0.3,
                  pointWidth: 8,
                  pointPlacement: 0.2,
                  // stack: 'D'

              },
                {
                    type: 'line',
                    name: 'Diff Day',
                    color: '#EB2A10',
                    borderColor: '#EB2A10',
                    data: SUMMP_DIFFD,
                    //pointPadding: 0.2,
                    pointPlacement: -0.2,
                    // stack: 'D'
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                }, {
                    type: 'line',
                    name: 'Diff Night',
                    color: '#8B1EDC',
                    borderColor: '#8B1EDC',
                    data: SUMMP_DIFFN,
                    //pointPadding: 0.4,
                    pointPlacement: 0,
                    yAxis: 1,
                    dataLabels: {
                        enabled: true,
                        formatter: function () {
                            return Highcharts.numberFormat(this.y, 0);
                        }
                    }
                },
            ],

        });
        //}//----- Function
    });//---- ajax
    Highcharts.setOptions({
        lang: {
            thousandsSep: ','
        }
    });




}

function loadChartMPFac3Andon(_objChart, _CostCenter, _DataDate, _DataMonth) {

    var DataMonth = new Date(_DataMonth);
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

    var SUMOTReqD = new Array();
    var SUMOTReqN = new Array();
    var SUMOTD = new Array();
    var SUMOTN = new Array();
    var SUMMPH = new Array();
    var SUMMPOT = new Array();

    var SUMMP_DIFFD = new Array();
    var SUMMP_DIFFN = new Array();
    var SUMMPReqD = new Array();
    var SUMMPReqN = new Array();
    var SUMMP_ACTD = new Array();
    var SUMMP_ACTN = new Array();
    var SUMMPD = new Array();
    var SUMMPN = new Array();
    var SUMMPH = new Array();
    var SUMMP = new Array();

    var DD = new Array();
    var Dayto = new Array();
    var DayWeek = new Array();
    var MP_Shift = new Array();
    var MP_ACT = new Array();


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


    var d = new Date();
    var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

    if (_CostCenter == "MPALL") {
        dataTitle = "DIRECT : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC1") {
        dataTitle = "DIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2") {
        dataTitle = "DIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3") {
        dataTitle = "DIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3M") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3CS" ) {
        dataTitle = "DIRECT : Factory 3 CS " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3CSPrev") {
        dataTitle = "DIRECT : Factory 3 CS " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3CSPrev2") {
        dataTitle = "DIRECT : Factory 3 CS " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3CSPrev3") {
        dataTitle = "DIRECT : Factory 3 CS " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3CP" ) {
        dataTitle = "DIRECT : Factory 3 CP " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3CPPrev") {
        dataTitle = "DIRECT : Factory 3 CP " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3CPPrev2") {
        dataTitle = "DIRECT : Factory 3 CP " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3CPPrev3") {
        dataTitle = "DIRECT : Factory 3 CP " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();



    } else if (_CostCenter == "MPFAC3CY" ) {
        dataTitle = "DIRECT : Factory 3 CY " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3CYPrev" ) {
        dataTitle = "DIRECT : Factory 3 CY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3CYPrev2") {
        dataTitle = "DIRECT : Factory 3 CY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3CYPrev3") {
        dataTitle = "DIRECT : Factory 3 CY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "MPFAC3FH" ) {
        dataTitle = "DIRECT : Factory 3 FH " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3FHPrev" ) {
        dataTitle = "DIRECT : Factory 3 FH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3FHPrev2" ) {
        dataTitle = "DIRECT : Factory 3 FH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3FHPrev3") {
        dataTitle = "DIRECT : Factory 3 FH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3RH" ) {
        dataTitle = "DIRECT : Factory 3 RH " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3RHPrev" ) {
        dataTitle = "DIRECT : Factory 3 RH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3RHPrev2" ) {
        dataTitle = "DIRECT : Factory 3 RH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3RHPrev3") {
        dataTitle = "DIRECT : Factory 3 RH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3PI" ) {
        dataTitle = "DIRECT : Factory 3 PI " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3PIPrev" ) {
        dataTitle = "DIRECT : Factory 3 PI " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3PIPrev2" ) {
        dataTitle = "DIRECT : Factory 3 PI " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3PIPrev3") {
        dataTitle = "DIRECT : Factory 3 PI " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3MOT" ) {
        dataTitle = "DIRECT : Factory 3 MOTOR " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MOTPrev" ) {
        dataTitle = "DIRECT : Factory 3 MOTOR " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3MOTPrev2" ) {
        dataTitle = "DIRECT : Factory 3 MOTOR " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3MOTPrev3") {
        dataTitle = "DIRECT : Factory 3 MOTOR " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "MPFAC3MA" ) {
        dataTitle = "DIRECT : Factory 3 MECHA " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3MAPrev") {
        dataTitle = "DIRECT : Factory 3 MECHA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3MAPrev2" ) {
        dataTitle = "DIRECT : Factory 3 MECHA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3MAPrev3") {
        dataTitle = "DIRECT : Factory 3 MECHA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3AS" ) {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3ASPrev" ) {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3ASPrev2" ) {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3ASPrev3") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3FIN" ) {
        dataTitle = "DIRECT : Factory 3 FINISH " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3FINPrev" ) {
        dataTitle = "DIRECT : Factory 3 FINISH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3FINPrev2") {
        dataTitle = "DIRECT : Factory 3 FINISH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();
    } else if ( _CostCenter == "MPFAC3FINPrev3") {
        dataTitle = "DIRECT : Factory 3 FINISH " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    }
    else if (_CostCenter == "MPFAC3A") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3MPrev") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev2") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev2") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3MPrev3") {
        dataTitle = "DIRECT : Factory 3 Machine " + months[d.getMonth()] + "/" + DataDate.getFullYear();
    } else if (_CostCenter == "MPFAC3APrev3") {
        dataTitle = "DIRECT : Factory 3 ASSY. " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODM") {
        dataTitle = "DIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev2") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev2") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev2") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev2") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC1Prev3") {
        dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC2Prev3") {
        dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPFAC3Prev3") {
        dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "MPODMPrev3") {
        dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

    } else if (_CostCenter == "MPMTALL") {
        dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
            //    success: function (ResponseData) {
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

                //OPPosition.push([ResponseData[i].OPPosition]);
                //OPOT1.push([ResponseData[i].OPOT1]);
                //OPOT15.push([ResponseData[i].OPOT15]);
                //OPOT2.push([ResponseData[i].OPOT2]);
                //OPOT3.push([ResponseData[i].OPOT3]);
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


                SUMMPReqD.push([ResponseData[i].SumMPD]);
                SUMMPReqN.push([ResponseData[i].SumMPN]);
                SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                //  SUMMPH.push([ResponseData[i].SumMPH]);
                //  SUMMP.push([ResponseData[i].SumMP]);


                MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
                MP_ACT.push([ResponseData[i].SumMP_ACT]);



                DD.push([ResponseData[i].Xdate]);
                Dayto.push([ResponseData[i].DatetoDay]);
                // DayWeek = DD + ":" + Dayto;
            }

            //------------------------- Chart summary direct -----------------------------            
            Highcharts.chart(_objChart, {

                chart: {
                    type: 'column', backgroundColor: '#F2F2F2',
                    //backgroundColor: {
                    //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                    //    stops: [
                    //         [0, '#098996'],
                    //              [1, '#054C54']
                    //       //[0, '#FBFBD4'],
                    //       //       [1, '#C7C6A1']
                    //    ]
                    //},
                    style: {
                        fontFamily: '\'Unica One\', sans-serif'
                    },
                    plotBorderColor: '#0A0A0A'
                },
                title: {
                    text: dataTitle,
                    style: {
                        color: '##581845',
                        fontWeight: 'bold'
                    }
                },
                xAxis: {
                    categories: Dayto,
                    labels: {
                        style: {
                            color: '##581845',
                            fontSize: '12px'
                        }
                    }
                },

                yAxis: [{
                    className: 'highcharts-color-0',
                    title: {

                        text: 'Employee',
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    labels: {
                        format: '{value:,.0f}.',
                        style: {
                            color: '##581845',
                            fontSize: '10px'
                        }
                    },
                    //max: 30,
                    //min: 0,

                    //stackLabels: {
                    //    enabled: false,
                    //    style: {
                    //        fontWeight: 'bold',
                    //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                    //    }
                    //}


                }
                //, {

                //    title: {
                //        text: 'Diff'
                //    },
                //    max: 30,
                //    min: -15,
                //    opposite: true
                //}
                ],

                legend: {
                    align: 'right',
                    x: -10,
                    verticalAlign: 'top',
                    y: 20,
                    floating: true,
                    color: 'White',
                    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                    borderColor: '#CCC',
                    borderWidth: 1,
                    shadow: false
                },
                //legend: {
                //    shadow: false
                //},
                tooltip: {
                    shared: true
                },
                plotOptions: {
                    column: {
                        grouping: false,
                        shadow: false,
                        borderWidth: 0
                    }
                },

                series: [

                //{

                //    name: 'Diff_ManPowerDay',
                //    color: '#F801FC',
                //    borderColor: '#F801FC',
                //    data: SUMMP_DIFFD,
                //    //pointPadding: 0.2,
                //    //pointPlacement: -0.2,
                //   // stack: 'D'

                //},
                 //{
                 //    name: 'MP/Shift',
                 //    color:
                 //    '#E59866',
                 //    borderColor: '#FFD733',
                 //    data: MP_Shift,
                 //    pointWidth: 30,
                 //    //pointPadding: 0.2,
                 //    pointPlacement: -0.2,
                 //    // stack: 'D'

                 //},
                {
                    name: 'ManPower Day',
                    color:
                    '#E59866',
                    borderColor: '#E59866',
                    data: SUMMPReqD,
                    pointWidth: 18,
                    //pointPadding: 0.2,
                    pointPlacement: -0.2,
                    // stack: 'D'

                }, {

                    name: 'Actual Day',
                    color: '#FC1801',
                    borderColor: '#FC1801',
                    data: SUMMP_ACTD,
                    //pointPadding: 0.3,
                    pointWidth: 8,
                    pointPlacement: -0.2,
                    // stack: 'D'

                },
                //{

                //    name: 'Diff_ManPowerNight',
                //    color: '#F801FC',
                //    borderColor: '#F801FC',
                //    data: SUMMP_DIFFN,
                //    //pointPadding: 0.4,
                //    //pointPlacement: -0.2,
                //    stack: 'N'

                //},
                  {
                      name: 'ManPowerNight',
                      color: '#5B2C6F',
                      borderColor: '#5B2C6F',
                      data: SUMMPReqN,
                      //pointPadding: 0.2,
                      pointWidth: 18,
                      pointPlacement: 0.2
                      //stack: 'N'
                  }, {

                      name: 'Actual Night',
                      color: '#FC1801',
                      borderColor: '#FC1801',
                      data: SUMMP_ACTN,
                      //pointPadding: 0.3,
                      pointWidth: 8,
                      pointPlacement: 0.2,
                      // stack: 'D'
                  }
                  //},
                  //  {
                  //      type: 'line',
                  //      name: 'Diff Day',
                  //      color: '#EB2A10',
                  //      borderColor: '#EB2A10',
                  //      data: SUMMP_DIFFD,
                  //      //pointPadding: 0.2,
                  //      pointPlacement: -0.2,
                  //      // stack: 'D'
                  //      yAxis: 1,
                  //      dataLabels: {
                  //          enabled: true,
                  //          formatter: function () {
                  //              return Highcharts.numberFormat(this.y, 0);
                  //          }
                  //      }
                  //  }, {
                  //      type: 'line',
                  //      name: 'Diff Night',
                  //      color: '#8B1EDC',
                  //      borderColor: '#8B1EDC',
                  //      data: SUMMP_DIFFN,
                  //      //pointPadding: 0.4,
                  //      pointPlacement: 0,
                  //      yAxis: 1,
                  //      dataLabels: {
                  //          enabled: true,
                  //          formatter: function () {
                  //              return Highcharts.numberFormat(this.y, 0);
                  //          }
                  //      }
                  //  },
                ],

            });
            //}//----- Function
        });//---- ajax
        Highcharts.setOptions({
            lang: {
                thousandsSep: ','
            }
        });




    }
        function loadChartMPFac3Other(_objChart, _CostCenter, _DataDate, _DataMonth) {

            var DataMonth = new Date(_DataMonth);
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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

   
            if (_CostCenter == "MPFAC3OTH")  {
                dataTitle = "DIRECT : Factory 3 OTHER " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            }
            else if (_CostCenter == "MPFAC3OTHPrev") {
                dataTitle = "DIRECT : Factory  3 OTHER " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3OTHPrev2") {
                dataTitle = "DIRECT : Factory  3 OTHER " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3OTHPrev3") {
                dataTitle = "DIRECT : Factory  3 OTHER " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            }

            $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
                //$.ajax({
                //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
                //    dataType: 'json',
                //    async: false,
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        //max: 30,
                        //min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }
                    //, {

                    //    title: {
                    //        text: 'Diff'
                    //    },
                    //    max: 30,
                    //    min: -15,
                    //    opposite: true
                    //}
                    ],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'
                      }
                      //},
                      //  {
                      //      type: 'line',
                      //      name: 'Diff Day',
                      //      color: '#EB2A10',
                      //      borderColor: '#EB2A10',
                      //      data: SUMMP_DIFFD,
                      //      //pointPadding: 0.2,
                      //      pointPlacement: -0.2,
                      //      // stack: 'D'
                      //      yAxis: 1,
                      //      dataLabels: {
                      //          enabled: true,
                      //          formatter: function () {
                      //              return Highcharts.numberFormat(this.y, 0);
                      //          }
                      //      }
                      //  }, {
                      //      type: 'line',
                      //      name: 'Diff Night',
                      //      color: '#8B1EDC',
                      //      borderColor: '#8B1EDC',
                      //      data: SUMMP_DIFFN,
                      //      //pointPadding: 0.4,
                      //      pointPlacement: 0,
                      //      yAxis: 1,
                      //      dataLabels: {
                      //          enabled: true,
                      //          formatter: function () {
                      //              return Highcharts.numberFormat(this.y, 0);
                      //          }
                      //      }
                      //  },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }

        function loadChartMPODMDay(_objChart, _CostCenter, _DataDate, _DataMonth) {

            var DataMonth = new Date(_DataMonth);
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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "MPALL") {
                dataTitle = "Attendance Statistic Monitor : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            } else if (_CostCenter == "MPFAC1") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODM") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev2") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev2") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev2") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev2") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev3") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev3") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev3") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev3") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

            } else if (_CostCenter == "MPMTALL") {
                dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 80,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 60,
                        min: -60,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFac2Day(_objChart, _CostCenter, _DataDate, _DataMonth) {

            var DataMonth = new Date(_DataMonth);
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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "MPALL") {
                dataTitle = "DIRECT : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            } else if (_CostCenter == "MPFAC1") {
                dataTitle = "DIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2") {
                dataTitle = "DIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3") {
                dataTitle = "DIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODM") {
                dataTitle = "DIRECT : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev") {
                dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev") {
                dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev") {
                dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev") {
                dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev2") {
                dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev2") {
                dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev2") {
                dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev2") {
                dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev3") {
                dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev3") {
                dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev3") {
                dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev3") {
                dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

            } else if (_CostCenter == "MPMTALL") {
                dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 400,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 300,
                        min: -300,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFac1Day(_objChart, _CostCenter, _DataDate, _DataMonth) {

            var DataMonth = new Date(_DataMonth);
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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "MPALL") {
                dataTitle = "Attendance Statistic Monitor : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            } else if (_CostCenter == "MPFAC1") {
                dataTitle = "DIRECT : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2") {
                dataTitle = "DIRECT : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3") {
                dataTitle = "DIRECT : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODM") {
                dataTitle = "DIRECT: Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev") {
                dataTitle = "DIRECT: Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev") {
                dataTitle = "DIRECT: Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev") {
                dataTitle = "DIRECT: Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev") {
                dataTitle = "DIRECT: Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev2") {
                dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev2") {
                dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev2") {
                dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev2") {
                dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev3") {
                dataTitle = "DIRECT : Factory 1 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev3") {
                dataTitle = "DIRECT : Factory 2 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev3") {
                dataTitle = "DIRECT : Factory 3 " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev3") {
                dataTitle = "DIRECT : Factory ODM " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

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

            } else if (_CostCenter == "MPMTALL") {
                dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].SumMP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 300,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 300,
                        min: -300,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartSummary(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);


                    //LEOT1.push([ResponseData[i].LEOT1]);
                    //LEOT15.push([ResponseData[i].LEOT15]);
                    //LEOT2.push([ResponseData[i].LEOT2]);
                    //LEOT3.push([ResponseData[i].LEOT3]);

                    //FOOT1.push([ResponseData[i].FOOT1]);
                    //FOOT15.push([ResponseData[i].FOOT15]);
                    //FOOT2.push([ResponseData[i].FOOT2]);
                    //FOOT3.push([ResponseData[i].FOOT3]);

                    //SUOT1.push([ResponseData[i].SUOT1]);
                    //SUOT15.push([ResponseData[i].SUOT15]);
                    //SUOT2.push([ResponseData[i].SUOT2]);
                    //SUOT3.push([ResponseData[i].SUOT3]);


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
                            valuePrefix: '฿',
                            valueSuffix: ' BHT'
                        },
                        pointPadding: 0.3,
                        pointPlacement: 0.2,
                        yAxis: 1

                    }, {

                        name: 'COST',
                        color: '#FDF600',
                        borderColor: '#FDF600',
                        type: 'column',
                        width: 2,
                        data: Cost,

                        tooltip: {
                            valuePrefix: '฿',
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
                        type: 'column',
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
                            valuePrefix: '฿',
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
                        type: 'column',
                        width: 10,
                        data: CostUnit,

                        tooltip: {
                            valuePrefix: '฿',
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
                            valuePrefix: '฿',
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
                            valuePrefix: '฿',
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
                            valuePrefix: '฿',
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
                            valuePrefix: '฿',
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

            var cost = _CostCenter.split(',');
            var chart = _objChart.split(',');


            for (i = 0; i < cost.length; i++) {


                $.getJSON("AllManPower.ashx?cc=" + cost[i] + "&Date=" + _DataDate, function (ResponseData) {

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

                        //SumProd.push([ResponseData[i].SumPrd]);
                        //Prod.push([ResponseData[i].Prd]);
                        Cost.push([ResponseData[i].BudgetCost]);
                        OverlAllSum.push([ResponseData[i].OverAllSum]);

                        //OPPosition.push([ResponseData[i].OPPosition]);
                        //OPOT1.push([ResponseData[i].OPOT1]);
                        //OPOT15.push([ResponseData[i].OPOT15]);
                        //OPOT2.push([ResponseData[i].OPOT2]);
                        //OPOT3.push([ResponseData[i].OPOT3]);
                        //OPSumOT.push([ResponseData[i].OPSumOT]);

                        //LEOT1.push([ResponseData[i].LEOT1]);
                        //LEOT15.push([ResponseData[i].LEOT15]);
                        //LEOT2.push([ResponseData[i].LEOT2]);
                        //LEOT3.push([ResponseData[i].LEOT3]);

                        //FOOT1.push([ResponseData[i].FOOT1]);
                        //FOOT15.push([ResponseData[i].FOOT15]);
                        //FOOT2.push([ResponseData[i].FOOT2]);
                        //FOOT3.push([ResponseData[i].FOOT3]);

                        //SUOT1.push([ResponseData[i].SUOT1]);
                        //SUOT15.push([ResponseData[i].SUOT15]);
                        //SUOT2.push([ResponseData[i].SUOT2]);
                        //SUOT3.push([ResponseData[i].SUOT3]);


                    }

                    //------------------------- Chart summary direct -----------------------------            
                    Highcharts.chart(chart[i], {

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
                                    text: 'Cost Man/Hr',
                                    style: {
                                        color: '#10100F',
                                        fontWeight: 'bold'
                                    }
                                },
                                labels: {
                                    format: '{value:,.0f}THB.',
                                    style: {
                                        color: '#10100F',
                                        fontSize: '10px'
                                    }
                                },
                                stackLabels: {
                                    enabled: true,
                                    style: {
                                        fontWeight: 'bold',
                                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'black'
                                    }
                                }



                            }, {
                                className: 'highcharts-color-1',
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
                                    text: 'Accum Cost',
                                    style: {
                                        color: '#FF0000',
                                        fontWeight: 'bold'
                                    }
                                },
                                labels: {
                                    format: '{value:,.2f} THB/Unit.',
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

                            name: 'COST',
                            color: '#FDF600',
                            borderColor: '#FDF600',
                            type: 'column',
                            width: 2,
                            data: Cost,

                            tooltip: {
                                valuePrefix: '฿',
                                valueSuffix: ' BHT'
                            },
                            //pointPadding: 0.3,
                            //pointPlacement: 0.2,
                            //yAxis: 1

                        }, {

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

                            // }, {

                            //    name: 'Prod',
                            //    color: '#09FB01',
                            //    borderColor: '#09FB01',
                            //    type: 'line',
                            //    width: 10,
                            //    data: Prod,

                            //    tooltip: {
                            //        // valuePrefix: '฿',
                            //        valueSuffix: ' Unit'
                            //    },
                            //    pointPadding: 0.3,
                            //    pointPlacement: 0.2,
                            //    yAxis: 2

                            // }, {

                            name: 'Accum.CostUnit',
                            color: '#FF0000',
                            borderColor: '#FF0000',
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

                        }, {

                            name: 'CostUnit',
                            color: '#F3FF00',
                            borderColor: '#F3FF00',
                            type: 'line',
                            width: 10,
                            data: CostUnit,

                            tooltip: {
                                valuePrefix: '฿',
                                pointformat: '{point.y:,0.2f}',
                                valueSuffix: 'BHT/Unit'
                            },
                            pointPadding: 0.3,
                            pointPlacement: 0.2,
                            yAxis: 2

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




            //if (_CostCenter == "ALL") {
            //    dataTitle = "Over All Man Power of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC1") {
            //    dataTitle = "Factory 1 of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC1M") {
            //    dataTitle = "PDM1YC of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC1A") {
            //    dataTitle = "PDA1YC of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC2") {
            //    dataTitle = "Factory 2 of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC2M") {
            //    dataTitle = "PDM2YC of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC2A") {
            //    dataTitle = "PDA2YC of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC3") {
            //    dataTitle = "Factory 3 of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC3M") {
            //    dataTitle = "PDMF3 of " + DataDate.getFullYear();
            //} else if (_CostCenter == "FAC3A") {
            //    dataTitle = "PDAF3 of " + DataDate.getFullYear();
            //} else if (_CostCenter == "ODM") {
            //    dataTitle = "ODM of " + DataDate.getFullYear();
            //}

            //$.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {

            //    for (i = 0; i < ResponseData.length; i++) {
            //        json_PrdTarget.push([ResponseData[i].dataPrdPerUnitTarget]);
            //        json_PrdPerUnit.push([ResponseData[i].dataPrdPerUnit]);
            //        json_SaleAmount.push([ResponseData[i].dataSaleAmount]);
            //        json_SaleRatio.push([ResponseData[i].dataSaleExpRatio]);
            //        json_CostCenter.push([ResponseData[i].dataCostCenter]);
            //        json_Hold.push([ResponseData[i].dataHold]);
            //        json_Result.push([ResponseData[i].dataResult]);

            //        json_YearMonth.push([ResponseData[i].dataYearMonth]);

            //        json_FGHold.push([ResponseData[i].dataFGHold]);
            //        json_LineOut.push([ResponseData[i].dataLineOut]);


            //        CostUnit.push([ResponseData[i].CostUnit]);
            //        AccumCostUnit.push([ResponseData[i].AccumCostUnit]);

            //        //SumProd.push([ResponseData[i].SumPrd]);
            //        //Prod.push([ResponseData[i].Prd]);
            //        Cost.push([ResponseData[i].BudgetCost]);
            //        OverlAllSum.push([ResponseData[i].OverAllSum]);

            //        //OPPosition.push([ResponseData[i].OPPosition]);
            //        //OPOT1.push([ResponseData[i].OPOT1]);
            //        //OPOT15.push([ResponseData[i].OPOT15]);
            //        //OPOT2.push([ResponseData[i].OPOT2]);
            //        //OPOT3.push([ResponseData[i].OPOT3]);
            //        //OPSumOT.push([ResponseData[i].OPSumOT]);

            //        //LEOT1.push([ResponseData[i].LEOT1]);
            //        //LEOT15.push([ResponseData[i].LEOT15]);
            //        //LEOT2.push([ResponseData[i].LEOT2]);
            //        //LEOT3.push([ResponseData[i].LEOT3]);

            //        //FOOT1.push([ResponseData[i].FOOT1]);
            //        //FOOT15.push([ResponseData[i].FOOT15]);
            //        //FOOT2.push([ResponseData[i].FOOT2]);
            //        //FOOT3.push([ResponseData[i].FOOT3]);

            //        //SUOT1.push([ResponseData[i].SUOT1]);
            //        //SUOT15.push([ResponseData[i].SUOT15]);
            //        //SUOT2.push([ResponseData[i].SUOT2]);
            //        //SUOT3.push([ResponseData[i].SUOT3]);


            //    }

            //    //------------------------- Chart summary direct -----------------------------            
            //    Highcharts.chart(_objChart, {

            //        chart: {
            //            type: 'column',
            //            backgroundColor: {
            //                linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
            //                stops: [
            //                     [0, '#098996'],
            //                          [1, '#054C54']
            //                   //[0, '#FBFBD4'],
            //                   //       [1, '#C7C6A1']
            //                ]
            //            },
            //            style: {
            //                fontFamily: '\'Unica One\', sans-serif'
            //            },
            //            plotBorderColor: '#0A0A0A'
            //        },
            //        title: {
            //            text: dataTitle,
            //            style: {
            //                color: '#10100F',
            //                fontWeight: 'bold'
            //            }
            //        },
            //        xAxis: {
            //            categories: json_CostCenter,
            //            labels: {
            //                style: {
            //                    color: '#10100F',
            //                    fontSize: '12px'
            //                }
            //            }
            //        },

            //        yAxis: [
            //            {
            //                className: 'highcharts-color-0',
            //                title: {
            //                    text: 'Cost Man/Hr',
            //                    style: {
            //                        color: '#10100F',
            //                        fontWeight: 'bold'
            //                    }
            //                },
            //                labels: {
            //                    format: '{value:,.0f}THB.',
            //                    style: {
            //                        color: '#10100F',
            //                        fontSize: '10px'
            //                    }
            //                },
            //                stackLabels: {
            //                    enabled: true,
            //                    style: {
            //                        fontWeight: 'bold',
            //                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'black'
            //                    }
            //                }



            //            }, {
            //                className: 'highcharts-color-1',
            //                title: {
            //                    text: 'THB/Unit',
            //                    style: {
            //                        color: '#F3FF00',
            //                        fontWeight: 'bold'
            //                    }
            //                },
            //                labels: {
            //                    format: '{value:,.2f} THB/Unit',
            //                    style: {
            //                        color: '#F3FF00',
            //                        fontSize: '10px'
            //                    }
            //                },
            //                stackLabels: {

            //                    enabled: true,
            //                    style: {

            //                        color: '#FB0101'
            //                    }
            //                },
            //                opposite: true,
            //                showFirstLabel: false

            //            }, {
            //                className: 'highcharts-color-1',
            //                title: {
            //                    text: 'Accum Cost',
            //                    style: {
            //                        color: '#FF0000',
            //                        fontWeight: 'bold'
            //                    }
            //                },
            //                labels: {
            //                    format: '{value:,.2f} THB/Unit.',
            //                    style: {
            //                        color: '#FF0000',
            //                        fontSize: '10px'
            //                    }
            //                },
            //                stackLabels: {
            //                    enabled: true,
            //                    style: {

            //                        color: '#FF0000'
            //                    }
            //                },
            //                opposite: true,
            //                showFirstLabel: false

            //            }
            //        ],

            //        //legend: {
            //        //    align: 'center',
            //        //    x: -30,
            //        //    verticalAlign: 'top',
            //        //    y: 25,
            //        //    floating: true,
            //        //    backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'Gray',
            //        //    borderColor: '#CCC',
            //        //    borderWidth: 1,
            //        //    shadow: false
            //        //},
            //        tooltip: {

            //            crosshairs: true,
            //            //shared: true,
            //            //headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            //            //pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            //            //            '<td style="padding:0;"><b>{point.y}</b></td></tr>',
            //            //footerFormat: '</table>',
            //            //shared: true,
            //            //useHTML: true

            //            //headerFormat: '<b>{point.x}</b>',
            //            pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'

            //            //headerFormat: '<b>{point.x}</b>',
            //            //pointFormat: '{series.name}: <b>{point.y}</b><br/>Total: {point.stackTotal:,.0f}'
            //            //pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>Total :{point.stackTotal}',
            //            //shared: true
            //        },
            //        plotOptions: {
            //            column: {
            //                stacking: 'normal',
            //                dataLabels: {
            //                    enabled: false,
            //                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'Black',
            //                    grouping: false,
            //                    shadow: false,
            //                    borderWidth: 0
            //                }
            //            }
            //        },
            //        series: [{
            //            //    name: 'Accum.Cost',
            //            //    color: '#FD0000',
            //            //    borderColor: '#FD0000',
            //            //    type: 'line',
            //            //    width: 5,
            //            //    data: OverlAllSum,

            //            //    tooltip: {
            //            //        valuePrefix: '฿',
            //            //        valueSuffix: ' BHT'
            //            //    },
            //            //    pointPadding: 0.3,
            //            //    pointPlacement: 0.2,
            //            //    yAxis: 1

            //            //},{

            //                name: 'COST',
            //                color: '#FDF600',
            //                borderColor: '#FDF600',
            //                type: 'column',
            //                width: 2,
            //                data: Cost,

            //                tooltip: {
            //                    valuePrefix: '฿',
            //                    valueSuffix: ' BHT'
            //                },
            //                //pointPadding: 0.3,
            //                //pointPlacement: 0.2,
            //                //yAxis: 1

            //            }, {

            //            //     name: 'Accum.Prod',
            //            //     color: '#03A03C',
            //            //     borderColor: '#03A03C',
            //            //     type: 'line',
            //            //     width: 10,
            //            //     data: SumProd,

            //            //     tooltip: {
            //            //         // valuePrefix: '฿',
            //            //         valueSuffix: ' Unit'
            //            //     },
            //            //     pointPadding: 0.3,
            //            //     pointPlacement: 0.2,
            //            //     yAxis: 2

            //            // }, {

            //            //    name: 'Prod',
            //            //    color: '#09FB01',
            //            //    borderColor: '#09FB01',
            //            //    type: 'line',
            //            //    width: 10,
            //            //    data: Prod,

            //            //    tooltip: {
            //            //        // valuePrefix: '฿',
            //            //        valueSuffix: ' Unit'
            //            //    },
            //            //    pointPadding: 0.3,
            //            //    pointPlacement: 0.2,
            //            //    yAxis: 2

            //            // }, {

            //            name: 'Accum.CostUnit',
            //            color: '#FF0000',
            //            borderColor: '#FF0000',
            //            type: 'line',
            //            width: 10,
            //            data: AccumCostUnit,

            //            tooltip: {
            //                valuePrefix: '฿',
            //                pointformat: '{point.y:,0.2f}',
            //                valueSuffix: 'BHT/Unit'
            //            },
            //            pointPadding: 0.3,
            //            pointPlacement: 0.2,
            //            yAxis: 1

            //        }, {

            //            name: 'CostUnit',
            //            color: '#F3FF00',
            //            borderColor: '#F3FF00',
            //            type: 'line',
            //            width: 10,
            //            data: CostUnit,

            //            tooltip: {
            //                valuePrefix: '฿',
            //                pointformat: '{point.y:,0.2f}',
            //                valueSuffix: 'BHT/Unit'
            //            },
            //            pointPadding: 0.3,
            //            pointPlacement: 0.2,
            //            yAxis: 2

            //        }, {

            //            name: 'OP[OT1]',
            //            color: '#FF00D1',
            //            borderColor: '#FF00D1',
            //            data: OPOT1,
            //            stack: 'OP', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'OP[OT15]',
            //            color: '#001FFE',
            //            borderColor: '#001FFE',
            //            data: OPOT15,
            //            stack: 'OP', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'OP[OT2]',
            //            color: '#00FE1F',
            //            borderColor: '#FF0000',
            //            data: OPOT2,
            //            stack: 'OP', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },

            //        }, {
            //            name: 'OP[OT3]',
            //            color: '#FE0000',
            //            borderColor: '#FE0000',
            //            data: OPOT3,
            //            stack: 'OP', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'LE[OT1]',
            //            color: '#FF00D1',
            //            borderColor: '#FF00D1',
            //            data: LEOT1,
            //            stack: 'LE', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },

            //        }, {
            //            name: 'LE[OT15]',
            //            color: '#001FFE',
            //            borderColor: '#001FFE',
            //            data: LEOT15,
            //            stack: 'LE', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'LE[OT2]',
            //            color: '#00FE1F',
            //            borderColor: '#00FE1F',
            //            data: LEOT2,
            //            stack: 'LE', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'LE[OT3]',
            //            color: '#FE0000',
            //            borderColor: '#FF0000',
            //            data: LEOT3,
            //            stack: 'LE', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'FO[OT1]',
            //            color: '#FF00D1',
            //            borderColor: '#FF00D1',
            //            data: FOOT1,
            //            stack: 'FO', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },

            //        }, {
            //            name: 'FO[OT15]',
            //            color: '#001FFE',
            //            borderColor: '#001FFE',
            //            data: FOOT15,
            //            stack: 'FO', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'FO[OT2]',
            //            color: '#00FE1F',
            //            borderColor: '#00FE1F',
            //            data: FOOT2,
            //            stack: 'FO', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'FO[OT3]',
            //            color: '#FE0000',
            //            borderColor: '#FF0000',
            //            data: FOOT3,
            //            stack: 'FO', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'SU[OT1]',
            //            color: '#FF00D1',
            //            borderColor: '#FF00D1',
            //            data: SUOT1,
            //            stack: 'SU', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },

            //        }, {
            //            name: 'SU[OT15]',
            //            color: '#001FFE',
            //            borderColor: '#001FFE',
            //            data: SUOT15,
            //            stack: 'SU', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'SU[OT2]',
            //            color: '#00FE1F',
            //            borderColor: '#00FE1F',
            //            data: SUOT2,
            //            stack: 'SU', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },
            //        }, {
            //            name: 'SU[OT3]',
            //            color: '#FE0000',
            //            borderColor: '#FF0000',
            //            data: SUOT3,
            //            stack: 'SU', tooltip: {
            //                valueSuffix: ' Hr.'
            //            },


            //        }]
            //    });
            //});
            //Highcharts.setOptions({
            //    lang: {
            //        thousandsSep: ','
            //    }
            //});
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
        function loadChartMPFacDayALL(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "MPALL") {
                dataTitle = "ALL DCI : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            } else if (_CostCenter == "MPFAC1") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODM") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[d.getMonth()] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[d.getMonth() - 1] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev2") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev2") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev2") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev2") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[d.getMonth() - 2] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC1Prev3") {
                dataTitle = "Attendance Statistic Monitor : Factory 1 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC2Prev3") {
                dataTitle = "Attendance Statistic Monitor : Factory 2 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPFAC3Prev3") {
                dataTitle = "Attendance Statistic Monitor : Factory 3 " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

            } else if (_CostCenter == "MPODMPrev3") {
                dataTitle = "Attendance Statistic Monitor : Factory ODM " + months[d.getMonth() - 3] + "/" + DataDate.getFullYear();

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

            } else if (_CostCenter == "MPMTALL") {
                dataTitle = "MAN POWER Maintenance of " + DataDate.getFullYear();
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
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].MP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 1300,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 1300,
                        min: -500,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFacDayDIRECTALL(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "DIRECTALL") {
                dataTitle = "DIRECT DCI : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            }


            $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
                //$.ajax({
                //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
                //    dataType: 'json',
                //    async: false,
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].MP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 2000,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 2000,
                        min: -500,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFacDayOTDIRECTALL(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "OTDIRECTALL") {
                dataTitle = "OVERTIME DIRECT ALL DCI : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            }


            $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
                //$.ajax({
                //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
                //    dataType: 'json',
                //    async: false,
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].MP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 2000,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 2000,
                        min: -500,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#0B5345',
                        borderColor: '#0B5345',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#81BEF7',
                          borderColor: '#81BEF7',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFacDayOTINDIRECTALL(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "OTDIRECTALL") {
                dataTitle = "OVERTIME DIRECT ALL DCI : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            }


            $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
                //$.ajax({
                //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
                //    dataType: 'json',
                //    async: false,
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].MP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 2000,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 2000,
                        min: -500,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#0B5345',
                        borderColor: '#0B5345',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#81BEF7',
                          borderColor: '#81BEF7',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFacDayOTMPSGA(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "OTMPSGA") {
                dataTitle = "OVERTIME S.G.A ALL DCI : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            }


            $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
                //$.ajax({
                //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
                //    dataType: 'json',
                //    async: false,
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].MP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 2000,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 2000,
                        min: -500,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#0B5345',
                        borderColor: '#0B5345',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#81BEF7',
                          borderColor: '#81BEF7',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFacDayINDirectALL(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "INDIRECTALL") {
                dataTitle = "INDIRECT ALL DCI : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            }


            $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
                //$.ajax({
                //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
                //    dataType: 'json',
                //    async: false,
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].MP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 2000,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 2000,
                        min: -500,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }
        function loadChartMPFacDayMPSGA(_objChart, _CostCenter, _DataDate, _DataMonth) {

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

            var SUMOTReqD = new Array();
            var SUMOTReqN = new Array();
            var SUMOTD = new Array();
            var SUMOTN = new Array();
            var SUMMPH = new Array();
            var SUMMPOT = new Array();

            var SUMMP_DIFFD = new Array();
            var SUMMP_DIFFN = new Array();
            var SUMMPReqD = new Array();
            var SUMMPReqN = new Array();
            var SUMMP_ACTD = new Array();
            var SUMMP_ACTN = new Array();
            var SUMMPD = new Array();
            var SUMMPN = new Array();
            var SUMMPH = new Array();
            var SUMMP = new Array();

            var DD = new Array();
            var Dayto = new Array();
            var DayWeek = new Array();
            var MP_Shift = new Array();
            var MP_ACT = new Array();


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


            var d = new Date();
            var months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];

            if (_CostCenter == "MPSGA") {
                dataTitle = "S.G.A DCI : " + months[d.getMonth()] + "/" + DataDate.getFullYear();
            }


            $.getJSON("AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate, function (ResponseData) {
                //$.ajax({
                //    url: "AllManPower.ashx?cc=" + _CostCenter + "&Date=" + _DataDate,
                //    dataType: 'json',
                //    async: false,
                //    success: function (ResponseData) {
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

                    //OPPosition.push([ResponseData[i].OPPosition]);
                    //OPOT1.push([ResponseData[i].OPOT1]);
                    //OPOT15.push([ResponseData[i].OPOT15]);
                    //OPOT2.push([ResponseData[i].OPOT2]);
                    //OPOT3.push([ResponseData[i].OPOT3]);
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


                    SUMMPReqD.push([ResponseData[i].SumMPD]);
                    SUMMPReqN.push([ResponseData[i].SumMPN]);
                    SUMMP_ACTD.push([ResponseData[i].SumMP_ACTD]);
                    SUMMP_ACTN.push([ResponseData[i].SumMP_ACTN]);
                    SUMMP_DIFFD.push([ResponseData[i].SumMP_DIFFD]);
                    SUMMP_DIFFN.push([ResponseData[i].SumMP_DIFFN]);


                    //  SUMMPH.push([ResponseData[i].SumMPH]);
                    //  SUMMP.push([ResponseData[i].SumMP]);


                    MP_Shift.push([ResponseData[i].MP_SHIFT]);
                    MP_ACT.push([ResponseData[i].SumMP_ACT]);



                    DD.push([ResponseData[i].Xdate]);
                    Dayto.push([ResponseData[i].DatetoDay]);
                    // DayWeek = DD + ":" + Dayto;
                }

                //------------------------- Chart summary direct -----------------------------            
                Highcharts.chart(_objChart, {

                    chart: {
                        type: 'column', backgroundColor: '#F2F2F2',
                        //backgroundColor: {
                        //    linearGradient: { x1: 0, y1: 0, x2: 1, y2: 1 },
                        //    stops: [
                        //         [0, '#098996'],
                        //              [1, '#054C54']
                        //       //[0, '#FBFBD4'],
                        //       //       [1, '#C7C6A1']
                        //    ]
                        //},
                        style: {
                            fontFamily: '\'Unica One\', sans-serif'
                        },
                        plotBorderColor: '#0A0A0A'
                    },
                    title: {
                        text: dataTitle,
                        style: {
                            color: '##581845',
                            fontWeight: 'bold'
                        }
                    },
                    xAxis: {
                        categories: Dayto,
                        labels: {
                            style: {
                                color: '##581845',
                                fontSize: '12px'
                            }
                        }
                    },

                    yAxis: [{
                        className: 'highcharts-color-0',
                        title: {

                            text: 'Employee',
                            style: {
                                color: '##581845',
                                fontWeight: 'bold'
                            }
                        },
                        labels: {
                            format: '{value:,.0f}.',
                            style: {
                                color: '##581845',
                                fontSize: '10px'
                            }
                        },
                        max: 2000,
                        min: 0,

                        //stackLabels: {
                        //    enabled: false,
                        //    style: {
                        //        fontWeight: 'bold',
                        //        color: (Highcharts.theme && Highcharts.theme.textColor) || 'Black'
                        //    }
                        //}


                    }, {

                        title: {
                            text: 'Diff'
                        },
                        max: 2000,
                        min: -500,
                        opposite: true
                    }],

                    legend: {
                        align: 'right',
                        x: -10,
                        verticalAlign: 'top',
                        y: 20,
                        floating: true,
                        color: 'White',
                        backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'White',
                        borderColor: '#CCC',
                        borderWidth: 1,
                        shadow: false
                    },
                    //legend: {
                    //    shadow: false
                    //},
                    tooltip: {
                        shared: true
                    },
                    plotOptions: {
                        column: {
                            grouping: false,
                            shadow: false,
                            borderWidth: 0
                        }
                    },

                    series: [

                    //{

                    //    name: 'Diff_ManPowerDay',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFD,
                    //    //pointPadding: 0.2,
                    //    //pointPlacement: -0.2,
                    //   // stack: 'D'

                    //},
                     //{
                     //    name: 'MP/Shift',
                     //    color:
                     //    '#E59866',
                     //    borderColor: '#FFD733',
                     //    data: MP_Shift,
                     //    pointWidth: 30,
                     //    //pointPadding: 0.2,
                     //    pointPlacement: -0.2,
                     //    // stack: 'D'

                     //},
                    {
                        name: 'ManPower Day',
                        color:
                        '#E59866',
                        borderColor: '#E59866',
                        data: SUMMPReqD,
                        pointWidth: 18,
                        //pointPadding: 0.2,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    }, {

                        name: 'Actual Day',
                        color: '#FC1801',
                        borderColor: '#FC1801',
                        data: SUMMP_ACTD,
                        //pointPadding: 0.3,
                        pointWidth: 8,
                        pointPlacement: -0.2,
                        // stack: 'D'

                    },
                    //{

                    //    name: 'Diff_ManPowerNight',
                    //    color: '#F801FC',
                    //    borderColor: '#F801FC',
                    //    data: SUMMP_DIFFN,
                    //    //pointPadding: 0.4,
                    //    //pointPlacement: -0.2,
                    //    stack: 'N'

                    //},
                      {
                          name: 'ManPowerNight',
                          color: '#5B2C6F',
                          borderColor: '#5B2C6F',
                          data: SUMMPReqN,
                          //pointPadding: 0.2,
                          pointWidth: 18,
                          pointPlacement: 0.2
                          //stack: 'N'
                      }, {

                          name: 'Actual Night',
                          color: '#FC1801',
                          borderColor: '#FC1801',
                          data: SUMMP_ACTN,
                          //pointPadding: 0.3,
                          pointWidth: 8,
                          pointPlacement: 0.2,
                          // stack: 'D'

                      },
                        {
                            type: 'line',
                            name: 'Diff Day',
                            color: '#EB2A10',
                            borderColor: '#EB2A10',
                            data: SUMMP_DIFFD,
                            //pointPadding: 0.2,
                            pointPlacement: -0.2,
                            // stack: 'D'
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        }, {
                            type: 'line',
                            name: 'Diff Night',
                            color: '#8B1EDC',
                            borderColor: '#8B1EDC',
                            data: SUMMP_DIFFN,
                            //pointPadding: 0.4,
                            pointPlacement: 0,
                            yAxis: 1,
                            dataLabels: {
                                enabled: true,
                                formatter: function () {
                                    return Highcharts.numberFormat(this.y, 0);
                                }
                            }
                        },
                    ],

                });
                //}//----- Function
            });//---- ajax
            Highcharts.setOptions({
                lang: {
                    thousandsSep: ','
                }
            });




        }