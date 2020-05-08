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
    var _YearPrev = new Date(CurDate.getFullYear()-1, CurDate.getMonth(), CurDate.getDay());
    var _YearPrev2 = new Date(CurDate.getFullYear() - 2, CurDate.getMonth(), CurDate.getDay());
    var _YearPrev3 = new Date(CurDate.getFullYear() - 3, CurDate.getMonth(), CurDate.getDay());


  

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


    ////------------------------------------------------------
    ////                           DIRECT Factory1
    ////------------------------------------------------------
    $("#gpMPFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac1Day('gpMPFAC1', 'MPFAC1', formatDate(date), formatDate(month));

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


    //////------------------------------------------------------
    //////                           DIRECT Factory2
    //////------------------------------------------------------
    $("#gpMPFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac2Day('gpMPFAC2', 'MPFAC2', formatDate(date), formatDate(month));

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
    loadChartMPFac3Day('gpMPFAC3', 'MPFAC3', formatDate(date), formatDate(month));

    $("#gpOTFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC3', 'OTFAC3', formatDate(date), formatDate(month));

    $("#gpMPFAC3Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Day('gpMPFAC3Prev', 'MPFAC3Prev', formatDate(_YearPrev), formatDate(month1));

    $("#gpOTFAC3Prev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC3Prev', 'OTFAC3Prev', formatDate(_YearPrev), formatDate(month1));

    $("#gpMPFAC3Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Day('gpMPFAC3Prev2', 'MPFAC3Prev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpOTFAC3Prev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC3Prev2', 'OTFAC3Prev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpMPFAC3Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFac3Day('gpMPFAC3Prev3', 'MPFAC3Prev3', formatDate(_YearPrev3), formatDate(month3));

    $("#gpOTFAC3Prev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTFAC3Prev3', 'OTFAC3Prev3', formatDate(_YearPrev3), formatDate(month3));


    //////////------------------------------------------------------
    //////////                           DIRECT ODM
    //////////------------------------------------------------------
    $("#gpMPODM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPODMDay('gpMPODM', 'MPODM', formatDate(date), formatDate(month));

    $("#gpOTODM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTODM', 'OTODM', formatDate(date), formatDate(month));

    $("#gpMPODMPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPODMDay('gpMPODMPrev', 'MPODMPrev', formatDate(_YearPrev), formatDate(month1));

    $("#gpOTODMPrev").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTODMPrev', 'OTODMPrev', formatDate(_YearPrev), formatDate(month1));

    $("#gpMPODMPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPODMDay('gpMPODMPrev2', 'MPODMPrev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpOTODMPrev2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTODMPrev2', 'OTODMPrev2', formatDate(_YearPrev2), formatDate(month2));

    $("#gpMPODMPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPODMDay('gpMPODMPrev3', 'MPODMPrev3', formatDate(_YearPrev3), formatDate(month3));

    $("#gpOTODMPrev3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOT('gpOTODMPrev3', 'OTODMPrev3', formatDate(_YearPrev3), formatDate(month3));


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
    $("#gpINMAN").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINMAN', 'INMAN', formatDate(date), formatDate(month));

    $("#gpINIE").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINIE', 'INIE', formatDate(date), formatDate(month));

    $("#gpOTINMAN").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTINDIRECT('gpOTINMAN', 'OTINMAN', formatDate(date), formatDate(month));



    //////////------------------------------------------------------
    //////////                           INDIRECT Factory1
    //////////------------------------------------------------------
    $("#gpINFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINFAC1', 'INFAC1', formatDate(date), formatDate(month));

    $("#gpOTINFAC1").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTINDIRECT('gpOTINFAC1', 'OTINFAC1', formatDate(date), formatDate(month));





    ////////------------------------------------------------------
    ////////                           INDIRECT Factory2
    ////////------------------------------------------------------
    $("#gpINFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINFAC2', 'INFAC2', formatDate(date), formatDate(month));

    $("#gpOTINFAC2").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTINDIRECT('gpOTINFAC2', 'OTINFAC2', formatDate(date), formatDate(month));


    ////////------------------------------------------------------
    ////////                           INDIRECT Factory3
    ////////------------------------------------------------------
    $("#gpINFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINFAC3', 'INFAC3', formatDate(date), formatDate(month));

    $("#gpOTINFAC3").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTINDIRECT('gpOTINFAC3', 'OTINFAC3', formatDate(date), formatDate(month));



    //////------------------------------------------------------
    //////                           INDIRECT ODM
    //////------------------------------------------------------
    $("#gpINODM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINODM', 'INODM', formatDate(date), formatDate(month));

    $("#gpOTINODM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTINDIRECT('gpOTINODM', 'OTINODM', formatDate(date), formatDate(month));


    ////////----------------------------------------------------------------------------
    ////////                          INDIRECT PROCUREMENT 
    ////////----------------------------------------------------------------------------

    $("#gpINPU").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINPU', 'INPU', formatDate(date), formatDate(month));

    $("#gpINSPU").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINSPU', 'INSPU', formatDate(date), formatDate(month));

    $("#gpINPC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINPC', 'INPC', formatDate(date), formatDate(month));

    $("#gpINSP").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINSP', 'INSP', formatDate(date), formatDate(month));

 


    //////----------------------------------------------------------------------------
    //////                      INDIRECT Production Control and SCM IM PN PS DS SP
    //////----------------------------------------------------------------------------

    $("#gpINIM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINIM', 'INIM', formatDate(date), formatDate(month));

    $("#gpINPS").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINPS', 'INPS', formatDate(date), formatDate(month));


    //////----------------------------------------------------------------------------
    //////                     INDIRECT ENGINEER
    //////----------------------------------------------------------------------------

    $("#gpINENA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINENA', 'INENA', formatDate(date1), formatDate(month));


    $("#gpINENM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINENM', 'INENM', formatDate(date1), formatDate(month));


    $("#gpINENMOT").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINENMOT', 'INENMOT', formatDate(date1), formatDate(month));


    ////////----------------------------------------------------------------------------
    ////////                    INDIRECT IT&EC
    ////////----------------------------------------------------------------------------

    $("#gpINIT").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINIT', 'INIT', formatDate(date), formatDate(month));

    $("#gpINUT").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINUT', 'INUT', formatDate(date), formatDate(month));

    $("#gpINEC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINEC', 'INEC', formatDate(date), formatDate(month));

    ////////----------------------------------------------------------------------------
    ////////                 INDIRECT QUALITY CONTROL
    ////////----------------------------------------------------------------------------

    $("#gpINQC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINQC', 'INQC', formatDate(date), formatDate(month));

    $("#gpINQA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINQA', 'INQA', formatDate(date), formatDate(month));

    $("#gpINQS").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINQS', 'INQS', formatDate(date), formatDate(month));


    ////////----------------------------------------------------------------------------
    ////////                   INDIRECT Design and Development
    ////////----------------------------------------------------------------------------

    $("#gpINDD").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINDD', 'INDD', formatDate(date), formatDate(month));

    $("#gpINCD").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINCD', 'INCD', formatDate(date), formatDate(month));




    ////////----------------------------------------------------------------------------
    ////////                  INDIRECT MAINTENANCE
    ////////----------------------------------------------------------------------------

   
    $("#gpINMTM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINMTM', 'INMTM', formatDate(date), formatDate(month));

    $("#gpINMTA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINMTA', 'INMTA', formatDate(date), formatDate(month));

    $("#gpINMTTPM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINMTTPM', 'INMTTPM', formatDate(date), formatDate(month));

    $("#gpINMTPM").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINMTPM', 'INMTPM', formatDate(date), formatDate(month));



    ////////-------------------------------END OF  INDIRECT ---------------------------------------



    ////////---------------------------------------------------------------------------------
    ////////                                  S.G.A SUPPORT 
    ////////--------------------------------------------------------------------------------- 


    $("#gpINDC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINDC', 'INDC', formatDate(date), formatDate(month));

    $("#gpINPN").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINPN', 'INPN', formatDate(date), formatDate(month));

    $("#gpINWH").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINWH', 'INWH', formatDate(date), formatDate(month));

    $("#gpINHR").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINHR', 'INHR', formatDate(date), formatDate(month));

    $("#gpINAC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINAC', 'INAC', formatDate(date), formatDate(month));

    $("#gpINCC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINCC', 'INCC', formatDate(date), formatDate(month));

    $("#gpINGA").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINGA', 'INGA', formatDate(date), formatDate(month));

    $("#gpINCB").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINCB', 'INCB', formatDate(date), formatDate(month));

    $("#gpINTS").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINTS', 'INTS', formatDate(date), formatDate(month));

    $("#gpINAUDIT").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINAUDIT', 'INAUDIT', formatDate(date), formatDate(month));

    $("#gpINHRD").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINHRD', 'INHRD', formatDate(date), formatDate(month));

    $("#gpINSF").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINSF', 'INSF', formatDate(date), formatDate(month));

    $("#gpINLG").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINLG', 'INLG', formatDate(date), formatDate(month));

    $("#gpINDCC").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINDCC', 'INDCC', formatDate(date), formatDate(month));

    $("#gpINTD").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPINDirectSupport('gpINTD', 'INTD', formatDate(date), formatDate(month));

    $("#gpOTINTD").html("<img src='../images/loading/gears.gif' border='0' />");
    loadChartMPFacOTINDIRECT('gpOTINTD', 'OTINTD', formatDate(date), formatDate(month));

   


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

    }else if (_CostCenter == "OTMPPS") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();


    } else if (_CostCenter == "OTMPPSPrev") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    } else if (_CostCenter == "OTMPPSPrev2") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    }  else if (_CostCenter == "OTMPPSPrev3") {
        dataTitle = "OverTime Statistic Monitor : PART SUPPLY " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

    }  else if (_CostCenter == "OTMPQA") {
    dataTitle = "OverTime Statistic Monitor : QA" + months[d.getMonth()] + "/" + DataDate.getFullYear();


} else if (_CostCenter == "OTMPQAPrev") {
    dataTitle = "OverTime Statistic Monitor : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

} else if (_CostCenter == "OTMPQAPrev2") {
    dataTitle = "OverTime Statistic Monitor : QA " + months[DataMonth.getMonth()] + "/" + DataDate.getFullYear();

}  else if (_CostCenter == "OTMPQAPrev3") {
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