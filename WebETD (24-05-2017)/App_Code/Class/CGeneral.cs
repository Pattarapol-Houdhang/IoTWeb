using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CGeneral
/// </summary>
public class CGeneral
{
    public CGeneral()
    {

    }

    public static string Home = "Home.aspx";
    public static string Test = "test.aspx";

    public enum TypeSelect
    {
        All,
        Selected,
        Please
    }

    public enum NotifyType
    {
        Success,
        Error,
        Info,
        Warning,
        Dark
    }

    public enum TypeConfig
    {
        Log
    }

    public enum SerialType
    {
        None,
        Label,
        Pipe,
        Rotor,
        Stator,
        RearHead,
        CrankShaft,
        Cylinder,
        Piston,
        FrontHead,
        RearAndRotor,
        SerialNo,
        IMS

    }

    public enum ModeData
    {
        ALL,
        RotorYakibame,
        Magnetize,
        PipeYakibame,
        MagnetCenter,
        AG,
        ElectricalConduction,
        TackWelding,
        TopBottomWelding,
        TopBottomWeldingNo1,
        TopBottomWeldingNo2

    }

    public enum SelectProcess
    {
        TorqueCheck,
        RotorYakibame,
        Magnetize,
        PipeYakibame,
        MagnetCenter,
        AirGap,
        ConnectingCheck,
        TopBottomWelding
    }

    public enum DBName
    {
        dbIoT,
        dbIoTFac3,
        dbDCI,
        dbIoT_103,
        dbIoTFac2,
        dbIoTFac1,
        dbETDFac3,
        dbODM
    }

    public enum TableName
    {
        None,
        Rotor_Yakibame_New,
        Magnetize,
        Pipe_Yakibame,
        Tack_Welding,
        MagnetCenter,
        AirGap,
        ElectricalConduction,
        TopBottomWelding,
        MC_LaserMark_RH,
        MC_LaserMark_CY,
        MC_LaserMark_CS,
        MC_LaserMark_FH,
        MC_LaserMark_Piston,
        PipeMarking,
        PipeIDCheck2,
        vi_LabelPrinting,
        FN_RunningTest,
        vi_FN_OilFilling,
        FN_WeightCheck,
        vi_FN_WeightCheck,
        front_head_result,
        rear_head_result,
        crank_shaft_result,
        cylinder_result,
        piston_result,
        mecha_matching_result,
        cylinder_centering,
        rear_centering,
        torque_check,
        PD_LabelLine4,
        SCR_OilCharge,
        SCR_runningtest,
        SCR_LowVoltage,
        SCR_N2LeakCheck,
        SCR_WeightCheck,
        MainAssemblyLine3,
        PipeCheckEquipmentLine3,
        PD_LabelLine3,
        PD_LabelLine5,
        MainScroll_HousingPress,
        Stator_LaserMarking,
        Stator_Characteristic,
        RotorLaserMarking,
        Rotor_Riveting,
        PD_LabelLine1,
        PD_LabelLine2,
        Line1_HVTest,
        Line1_OilCharge,
        Line1_RunningTest,
        Line1_WeightCheck,
        Line2_HVTest,
        Line2_OilCharge,
        Line2_RunningTest,
        Line2_WeightCheck,
        Line3_HVTest,
        Line3_OilCharge,
        Line3_RunningTest,
        Line3_WeightCheck,
        Line5_HVTest,
        Line5_OilCharge,
        Line5_RunningTest,
        Line5_WeightCheck,
        vi_Leak_Check,
        vi_leak_rework,
        ODM_Demagnetize_No1,
        ODM_Demagnetize_No2,
        ODM_Demagnetize_No3,
        ODM_Demagnetize_No4,
        ODM_Magnetize,
        ODM_FinalInspection_No1,
        ODM_FinalInspection_No2,
        vi_cs,
        vi_cy,
        vi_fh,
        vi_pt,
        vi_rh,
        vi_MC_cs,
        vi_MC_cy,
        vi_MC_fh,
        vi_MC_pt,
        vi_MC_rh,
        vi_torque_check,
        etd_match_result_2,
        PipeL4_PipeCheckEquipment,
        vi_Appearance_Detail,
        vi_model_detail,
        vi_MC_model_detail,
        vi_leak_NG_monitor,
        odm_od_marker,
        odm_od_soundcheck,
        odm_od_SRC,
        odm_od_stator_assy,
        ManPowerLog,
        Scada_Main_Assy_FG,
        vi_ManpowerLog
    }
}