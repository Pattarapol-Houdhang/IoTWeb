using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;

/// <summary>
/// Summary description for CHistoryData
/// </summary>
public class CHistoryData
{
    ConnectDBIoTServerTon oConnIoTFac3 = new ConnectDBIoTServerTon();
    ConnectDBIoTFac3Costy oConnIoTFac3Costy = new ConnectDBIoTFac3Costy();
    ConnectDBDCI oConnDCI = new ConnectDBDCI();
    ConnectDBIoTServerTon oConnIoT103 = new ConnectDBIoTServerTon();
    ConnectDBIoTFac2Costy oConnIoTFac2Costy = new ConnectDBIoTFac2Costy();
    ConnectDBIoTFac1Costy oConnIoTFac1Costy = new ConnectDBIoTFac1Costy();
    ConnectDBODM oConnODM = new ConnectDBODM();

    ConnectDB oConn = new ConnectDB();
    public DataTable GetDataMESIoTServer(string TableName, string DateStart, string DateEnd, string ModelNo,string Line)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();

        sbd = new StringBuilder();
        sbd.AppendLine("SELECT * FROM " + TableName + " WHERE 1=1");
        if (ModelNo != "")
        {
            sbd.AppendLine("AND ModelNo like '%" + ModelNo + "%'");
        }
        if (DateStart != "" && TableName != "LabelPrinting")
        {
            sbd.AppendLine("AND InsertDate >= '" + DateStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + DateEnd + "'");
            sbd.AppendLine("ORDER BY InsertDate DESC");
        }
        else if (DateStart != "")
        {
            sbd.AppendLine("AND MFGDate >= '" + DateStart + "'");
            sbd.AppendLine("AND MFGDate <= '" + DateEnd + "'");
            sbd.AppendLine("ORDER BY MFGDate DESC");
        }

        dTable = oConnIoTFac3Costy.Query(sbd.ToString());

        return dTable;
    }

    public DataTable GetDataMESIoTServer(CGeneral.TableName TableName, string DateStart, string DateEnd
        , string ModelNo, CGeneral.SerialType oSerialType, string ListOfSerial, CGeneral.DBName DB
        , string LineNo, string Line, string Machine)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();

        sbd = new StringBuilder();
        sbd.AppendLine("SELECT * FROM " + TableName.ToString() + " WHERE 1=1");
        if (oSerialType == CGeneral.SerialType.None)
        {
            if (DateStart != "" && TableName == CGeneral.TableName.vi_LabelPrinting)
            {
                sbd.AppendLine("AND MFGDate >= '" + DateStart + "'");
                sbd.AppendLine("AND MFGDate <= '" + DateEnd + "'");
                //sbd.AppendLine("AND DateMC like '%" + PDYear + "%'");
            }
            else if (DateStart != "" && (TableName == CGeneral.TableName.PD_LabelLine4 || TableName == CGeneral.TableName.PD_LabelLine3 || TableName == CGeneral.TableName.PD_LabelLine5
                || TableName == CGeneral.TableName.PD_LabelLine1 || TableName == CGeneral.TableName.PD_LabelLine2))
            {
                sbd.AppendLine("AND LocalDate >= '" + DateStart + "'");
                sbd.AppendLine("AND LocalDate <= '" + DateEnd + "'");
                //sbd.AppendLine("AND DateMC like '%" + PDYear + "%'");
            }
            else if (DateStart != "" && (TableName == CGeneral.TableName.vi_Leak_Check || TableName == CGeneral.TableName.ManPowerLog))
            {
                sbd.AppendLine("AND StampTime >= '" + DateStart + "'");
                sbd.AppendLine("AND StampTime <= '" + DateEnd + "'");
            }
            else if (DateStart != "" && TableName == CGeneral.TableName.vi_leak_rework)
            {
                sbd.AppendLine("AND insert_time >= '" + DateStart + "'");
                sbd.AppendLine("AND insert_time <= '" + DateEnd + "'");
            }
            else if((DateStart != "" && TableName == CGeneral.TableName.vi_leak_NG_monitor))
            {
                sbd = new StringBuilder();
                sbd.AppendLine("select distinct [serial_no],SUBSTRING(serial_no,2,3) as ModelCode,pn.rmk1 as ModelName,[rework_line],[point_leak] "+
                               " ,[top_view_position],[side_view_position] "+
                               ",[ng_description],lmc.ngcode_name_EN,[insert_time],[rework_emp],[bazzing_emp],[line_out],[status_record] "+
                              
                              
                               
                               " ,CASE WHEN tbw.MachineNo is null then 'Unknow' else 'MC No. ' + tbw.MachineNo end as TBWMCNO "+
                               " ,CASE WHEN tw.MachineNo is null then 'Unknow' else 'MC No. ' + tw.MachineNo end as TWMCNO "+
                               " from vi_leak_rework lr "+
                               " left join etd_leak_mst_leak_name lmn on point_leak=lmn.leak_name "+
                               " left join etd_leak_mst_code_ng lmc on lr.ng_description=lmc.ngcode_name "+
                               " left join etd_leak_mst_posi_top lmt on lr.top_view_position=lmt.point "+
                               " left join etd_leak_mst_posi_side lms on lr.side_view_position=lms.point "+
                               " left join [192.168.226.86].dbSCM.dbo.PN_Compressor pn  "+
                               " on pn.ModelCode COLLATE Thai_CI_AS = SUBSTRING([serial_no],2,3)  COLLATE Thai_CI_AS "+
                               " and pn.[Status] = 'ACTIVE' "+
                               " left join dbIoTFac3.dbo.TopBottomWelding tbw on lr.serial_no=tbw.PartSerialNo "+
                               " left join dbIoTFac3.dbo.Tack_Welding tw on lr.serial_no=tw.PartSerialNo "+
                               " where status_record = 'in' "+
                               " and insert_time between '" + DateStart + "' and '" + DateEnd + "'");
            }
            else if (DateStart != "" && (TableName == CGeneral.TableName.ODM_Demagnetize_No1 || TableName == CGeneral.TableName.ODM_Demagnetize_No2
                || TableName == CGeneral.TableName.ODM_Demagnetize_No3 || TableName == CGeneral.TableName.ODM_Demagnetize_No4))
            {
                sbd.AppendLine("AND Date_Insert >= '" + DateStart + "'");
                sbd.AppendLine("AND Date_Insert <= '" + DateEnd + "'");
            }
            else if (TableName == CGeneral.TableName.ODM_FinalInspection_No2 || TableName == CGeneral.TableName.ODM_FinalInspection_No1)
            {
                sbd.AppendLine("AND ServerTime >= '" + DateStart + "'");
                sbd.AppendLine("AND ServerTime <= '" + DateEnd + "'");
            }
            else if (DateStart != "" && TableName == CGeneral.TableName.ODM_Magnetize)
            {
                sbd.AppendLine("AND Datetime_Insert >= '" + DateStart + "'");
                sbd.AppendLine("AND Datetime_Insert <= '" + DateEnd + "'");
            }
            else if (DateStart != "" && (TableName == CGeneral.TableName.vi_cs || TableName == CGeneral.TableName.vi_cy
                || TableName == CGeneral.TableName.vi_fh || TableName == CGeneral.TableName.vi_pt || TableName == CGeneral.TableName.vi_rh))
            {
                string ColumnNameDate = "";
                string[] spl = TableName.ToString().Split('_');
                ColumnNameDate = spl[1] + "_date";
                sbd.AppendLine("AND " + ColumnNameDate + " >= '" + DateStart + "'");
                sbd.AppendLine("AND " + ColumnNameDate + " <= '" + DateEnd + "'");


            }
            else if (DateStart != "" && (TableName == CGeneral.TableName.vi_MC_cs || TableName == CGeneral.TableName.vi_MC_cy
                || TableName == CGeneral.TableName.vi_MC_fh || TableName == CGeneral.TableName.vi_MC_pt
                || TableName == CGeneral.TableName.vi_MC_rh))
            {
                string ColumnNameDate = "";
                string[] spl = TableName.ToString().Split('_');
                ColumnNameDate = spl[2] + "_date";
                sbd.AppendLine("AND " + ColumnNameDate + " >= '" + DateStart + "'");
                sbd.AppendLine("AND " + ColumnNameDate + " <= '" + DateEnd + "'");
            }
            else if (DateStart != "" && TableName == CGeneral.TableName.vi_torque_check)
            {
                sbd.AppendLine("AND [Datetime] >= '" + DateStart + "'");
                sbd.AppendLine("AND [Datetime] <= '" + DateEnd + "'");
            }
            else if (DateStart != "" && TableName == CGeneral.TableName.etd_match_result_2)
            {
                sbd.AppendLine("AND [date_time] >= '" + DateStart + "'");
                sbd.AppendLine("AND [date_time] <= '" + DateEnd + "'");
            }
            else if (DateStart != "" && TableName == CGeneral.TableName.etd_match_result_2)
            {
                sbd.AppendLine("AND [cs_date] >= '" + DateStart + "'");
                sbd.AppendLine("AND [cs_date] <= '" + DateEnd + "'");
            }
            else if (DateStart != "" && TableName == CGeneral.TableName.vi_Appearance_Detail)
            {
                sbd.AppendLine("AND InsertDate >= '" + DateStart + "'");
                sbd.AppendLine("AND InsertDate <= '" + DateEnd + "'");
                sbd.AppendLine("AND [LineNO] = '" + Line + "'");

            }
            else
            {
                sbd.AppendLine("AND InsertDate >= '" + DateStart + "'");
                sbd.AppendLine("AND InsertDate <= '" + DateEnd + "'");
            }

            if (TableName == CGeneral.TableName.vi_torque_check && LineNo == "14")
            {
                sbd.AppendLine("AND Remark = '3'");
            }
            else if (TableName == CGeneral.TableName.vi_torque_check && LineNo == "35")
            {
                sbd.AppendLine("AND Remark = '6'");
            }
        }
        else
        {
            string[] stringSeparators = new string[] { "\n" };
            string[] spl = ListOfSerial.Split(stringSeparators, StringSplitOptions.None);
            ListOfSerial = "";
            for (int i = 0; i < spl.Length; i++)
            {
                if (spl.Length == i + 1)
                {
                    ListOfSerial += "'" + spl[i] + "'";
                }
                else
                {
                    ListOfSerial += "'" + spl[i] + "',";
                }
            }

            // By Serial
            if (TableName == CGeneral.TableName.AirGap || TableName == CGeneral.TableName.ElectricalConduction
                || TableName == CGeneral.TableName.FN_RunningTest || TableName == CGeneral.TableName.FN_WeightCheck || TableName == CGeneral.TableName.TopBottomWelding
                || TableName == CGeneral.TableName.PipeIDCheck2 || TableName == CGeneral.TableName.PipeMarking)
            {
                // [PartSerialNo]
                sbd.AppendLine("AND PartSerialNo in (" + ListOfSerial + ")");

            }
            else if (TableName == CGeneral.TableName.MC_LaserMark_CS || TableName == CGeneral.TableName.MC_LaserMark_CY || TableName == CGeneral.TableName.MC_LaserMark_FH ||
                TableName == CGeneral.TableName.MC_LaserMark_Piston || TableName == CGeneral.TableName.MC_LaserMark_RH)
            {
                // PartSerialNumber
                sbd.AppendLine("AND PartSerialNumber in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.Rotor_Yakibame_New)
            {
                sbd.AppendLine("AND (MechaAssyNumber in (" + ListOfSerial + ") OR RotorNumber in (" + ListOfSerial + "))");
            }
            else if (TableName == CGeneral.TableName.Magnetize)
            {
                sbd.AppendLine("AND MechaAssyNumber in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.Pipe_Yakibame)
            {
                sbd.AppendLine("AND PipeNumber in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.MagnetCenter)
            {
                sbd.AppendLine("AND (PipeNumber in (" + ListOfSerial + ") OR RotorNumber in (" + ListOfSerial + "))");
            }
            else if (TableName == CGeneral.TableName.vi_LabelPrinting || TableName == CGeneral.TableName.vi_FN_OilFilling || TableName == CGeneral.TableName.PD_LabelLine4
                 || TableName == CGeneral.TableName.PD_LabelLine3 || TableName == CGeneral.TableName.PD_LabelLine5)
            {
                sbd.AppendLine("AND SerialNumber in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.MainScroll_HousingPress || TableName == CGeneral.TableName.vi_Leak_Check)
            {
                sbd.AppendLine("AND SerialNo in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.vi_leak_rework )
            {
                sbd.AppendLine("AND serial_no in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.vi_Appearance_Detail || TableName == CGeneral.TableName.Scada_Main_Assy_FG)
            {
                sbd.AppendLine("AND Serial_No in (" + ListOfSerial + ") and [LineNO] = '" + Line + "'");
            }
            else if (TableName == CGeneral.TableName.ODM_Demagnetize_No1 || TableName == CGeneral.TableName.ODM_Demagnetize_No2 || TableName == CGeneral.TableName.ODM_Demagnetize_No3
                || TableName == CGeneral.TableName.ODM_Demagnetize_No4 || TableName == CGeneral.TableName.ODM_FinalInspection_No1 || TableName == CGeneral.TableName.ODM_FinalInspection_No2 || TableName == CGeneral.TableName.ODM_Magnetize)
            {
                sbd.AppendLine("AND Marking_Data in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.ODM_Magnetize)
            {
                sbd.AppendLine("AND Marking in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.PipeL4_PipeCheckEquipment)
            {
                sbd.AppendLine("AND Pipe_Number in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.vi_cs)
            {
                sbd.AppendLine("AND cs_id in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.vi_cy)
            {
                sbd.AppendLine("AND cy_id in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.vi_fh)
            {
                sbd.AppendLine("AND fh_id in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.vi_pt)
            {
                sbd.AppendLine("AND pt_id in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.vi_rh)
            {
                sbd.AppendLine("AND rh_id in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.odm_od_marker)////////////////////////ODM Outdoor Ft1
            {
                sbd.AppendLine("AND Mark_Lot_Number in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.odm_od_soundcheck)
            {
                sbd.AppendLine("AND Lot_No in (" + ListOfSerial + ")");
            }
            else if (TableName == CGeneral.TableName.odm_od_SRC)
            {
                sbd.AppendLine("AND (Stator_Serial_QR_Code in (" + ListOfSerial + ") OR Rotor_Serial_QR_Code in (" + ListOfSerial + "))");
            }
            else if (TableName == CGeneral.TableName.odm_od_stator_assy)
            {
                sbd.AppendLine("AND Group_Lot_Number in (" + ListOfSerial + ")");
            }

        }

        if (ModelNo != "")
        {
            if (TableName == CGeneral.TableName.vi_LabelPrinting)
            {
                sbd.AppendLine("AND Model like '%" + ModelNo + "%'");
            }
            else
            {
                sbd.AppendLine("AND ModelNo like '%" + ModelNo + "%'");
            }

        }
        if (TableName == CGeneral.TableName.vi_Leak_Check)
        {
            sbd.AppendLine("AND [Line] = '" + LineNo + "'");
        }
        if (TableName == CGeneral.TableName.vi_leak_rework)
        {
            sbd.AppendLine("AND [rework_line] = '" + LineNo + "'");
        }
        if (TableName == CGeneral.TableName.vi_leak_NG_monitor)
        {
            sbd.AppendLine("and rework_line = 6 and pn.rmk1 is not null and lmn.no is not null ");
            sbd.AppendLine("order by insert_time desc");
        }
        if (TableName == CGeneral.TableName.ManPowerLog)
        {
            sbd.AppendLine("AND Line = '" + Line + "'");
            if (Machine != "ALL")
            {
                sbd.AppendLine("AND LocationName = '" + Machine + "'");
            }

        }

        if (LineNo == "14" && (TableName == CGeneral.TableName.vi_cs || TableName == CGeneral.TableName.vi_cy
                || TableName == CGeneral.TableName.vi_fh || TableName == CGeneral.TableName.vi_pt || TableName == CGeneral.TableName.vi_rh))
        {
            sbd.AppendLine("AND [line] like '%3%'");
        }
        else if (LineNo == "35" && (TableName == CGeneral.TableName.vi_cs || TableName == CGeneral.TableName.vi_cy
                || TableName == CGeneral.TableName.vi_fh || TableName == CGeneral.TableName.vi_pt || TableName == CGeneral.TableName.vi_rh))
        {
            sbd.AppendLine("AND [line] like '%7%'");
        }

        if (DB == CGeneral.DBName.dbDCI)
        {
            dTable = oConnDCI.Query(sbd.ToString());
        }
        else if (DB == CGeneral.DBName.dbIoT)
        {
            dTable = oConn.Query(sbd.ToString());
        }
        else if (DB == CGeneral.DBName.dbIoTFac3)
        {
            dTable = oConnIoTFac3Costy.Query(sbd.ToString());
        }
        else if (DB == CGeneral.DBName.dbIoT_103)
        {
            dTable = oConnIoT103.Query(sbd.ToString());
        }
        else if (DB == CGeneral.DBName.dbIoTFac2)
        {
            dTable = oConnIoTFac2Costy.Query(sbd.ToString());
        }
        else if (DB == CGeneral.DBName.dbIoTFac1)
        {
            dTable = oConnIoTFac1Costy.Query(sbd.ToString());
        }
        else if (DB == CGeneral.DBName.dbODM)
        {
            dTable = oConnODM.Query(sbd.ToString());
        }
        else
        {
            dTable = oConnIoTFac3Costy.Query(sbd.ToString());
        }

        return dTable;
    }

    public DataTable GetDataDataLogger(string mc_code, string DateStart, string DateEnd, string ModelNo)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();

        sbd = new StringBuilder();
        sbd.AppendLine("SELECT * FROM Data WHERE ");
        sbd.AppendLine("mc_code like '%" + mc_code + "%'");
        if (DateStart != "")
        {
            sbd.AppendLine("AND data_mfgdate >= '" + DateStart + "'");
            sbd.AppendLine("AND data_mfgdate <= '" + DateEnd + "'");
        }
        if (ModelNo != "")
        {
            sbd.AppendLine("AND model_id like '%" + ModelNo + "%'");
        }

        dTable = oConn.Query(sbd.ToString());

        return dTable;
    }


}