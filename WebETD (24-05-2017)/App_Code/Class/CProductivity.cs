using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

/// <summary>
/// Summary description for CProductivity
/// </summary>
public class CProductivity
{
    ConnectDBFac3 oConnFac3 = new ConnectDBFac3();
    ConnectDBIoTServerTonMecha oConnMecha = new ConnectDBIoTServerTonMecha();
    ConnectDBPDB oConnPDB = new ConnectDBPDB();
    ConnectDBFac3ETD oConnETD = new ConnectDBFac3ETD();

    public MDProcductivity GetProductivityNow(DateTime inDate, string inShift)
    {
        MDProcductivity oMDProduc = new MDProcductivity();
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        DateTime dtStart = new DateTime();
        DateTime dtEnd = new DateTime();

        string DateStart = "";
        string DateEnd = "";
        //if (DateTime.Now < Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.Day.ToString() + " 08:00:00") || DateTime.Now >= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.Day.ToString() + " 20:00:00"))
        //{
        //    // Night Shift
        //    DateStart = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.Day.ToString() + " 20:00:00";

        //    DateEnd = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.AddDays(1).Day.ToString() + " 08:00:00";

        //}
        //else if (DateTime.Now <= Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.Day.ToString() + " 20:00:00"))
        //{
        //    // Day Shift
        //    DateStart = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.Day.ToString() + " 08:00:00";

        //    DateEnd = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.Day.ToString() + " 20:00:00";
        //}
        //else
        //{
        //    DateStart = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //   + "-" + DateTime.Now.Day.ToString() + " 20:00:00";

        //    DateEnd = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString()
        //    + "-" + DateTime.Now.AddDays(1).Day.ToString() + " 08:00:00";
        //}

        if (inShift == "DAY")
        {
            DateStart = inDate.Year.ToString() + "-" + inDate.Month.ToString()
           + "-" + inDate.Day.ToString() + " 08:00:00";

            DateEnd = inDate.Year.ToString() + "-" + inDate.Month.ToString()
            + "-" + inDate.Day.ToString() + " 20:00:00";
        }
        else
        {
            DateStart = inDate.Year.ToString() + "-" + inDate.Month.ToString()
          + "-" + inDate.Day.ToString() + " 20:00:00";

            DateEnd = inDate.AddDays(1).Year.ToString() + "-" + inDate.AddDays(1).Month.ToString()
            + "-" + inDate.AddDays(1).Day.ToString() + " 08:00:00";
        }

        MDProcductivity.CMDProductivity oMDRH = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDCY = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDCS = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDFH = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDPS = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDMecha = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDPipe = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDMain = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDFinal = new MDProcductivity.CMDProductivity();

        MDProcductivity.CMDProductivity.CMDListQty oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM MC_LaserMark_RH");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDRH.LineName = "Rear Head";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '304'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }

        }
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(DISTINCT [rh_id]) as Qty");
        sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_rear_head]");
        sbd.AppendLine("where rh_line = 'RH_ID_FL_FAC3'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE rh_date END) >= '" + dtStart + "'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE rh_date END) <= '" + dtEnd + "'");
        sbd.AppendLine("and rh_judgement = 'OK'");
        dTable = oConnETD.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "0";
        }
        oMDRH.ListOfQty.Add(oMDList);

        // Cylinder
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM MC_LaserMark_CY");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDCY.LineName = "Cylinder";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '305'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }

        }
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(DISTINCT [cy_id]) as Qty");
        sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_cylinder]");
        sbd.AppendLine("where cy_line = 'CY_HEI_FAC3'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cy_date END) >= '" + dtStart + "'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cy_date END) <= '" + dtEnd + "'");
        sbd.AppendLine("and cy_judgement = 'OK'");
        dTable = oConnETD.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "0";
        }
        oMDCY.ListOfQty.Add(oMDList);

        // Crank Shaft
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM MC_LaserMark_CS");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDCS.LineName = "Crank Shaft";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '306'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }

        }
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(DISTINCT [cs_id]) as Qty");
        sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_crank_shaft]");
        sbd.AppendLine("where cs_line = 'CS_PE_FAC3'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cs_date END) >= '" + dtStart + "'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cs_date END) <= '" + dtEnd + "'");
        sbd.AppendLine("and cs_judgement = 'OK'");
        dTable = oConnETD.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "0";
        }
        oMDCS.ListOfQty.Add(oMDList);

        // Front Head
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM MC_LaserMark_FH");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDFH.LineName = "Front Head";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '307'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            //sbd.AppendLine("order by LogTime desc");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }

        }
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(DISTINCT [fh_id]) as Qty");
        sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_front_head]");
        sbd.AppendLine("where fh_line = 'FH_FINISH_FAC3'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE fh_date END) >= '" + dtStart + "'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE fh_date END) <= '" + dtEnd + "'");
        sbd.AppendLine("and fh_judgement = 'OK'");
        dTable = oConnETD.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "0";
        }
        oMDFH.ListOfQty.Add(oMDList);

        // Piston
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM MC_LaserMark_Piston");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDPS.LineName = "Piston";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '308'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            //sbd.AppendLine("order by LogTime desc");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }

        }
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(DISTINCT [pt_id]) as Qty");
        sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_piston]");
        sbd.AppendLine("where pt_line = 'PT_HEI_FAC3'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE pt_date END) >= '" + dtStart + "'");
        sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE pt_date END) <= '" + dtEnd + "'");
        sbd.AppendLine("and pt_judgement = 'OK'");
        dTable = oConnETD.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "0";
        }
        oMDPS.ListOfQty.Add(oMDList);

        // Mecha
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM mecha_matching_result");
        sbd.AppendLine("WHERE date_time >= '" + dtStart + "'");
        sbd.AppendLine("AND date_time <= '" + dtEnd + "'");
        dTable = oConnMecha.Query(sbd.ToString());
        oMDMecha.LineName = "Mecha";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '302'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            //sbd.AppendLine("order by LogTime desc");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }
        }
        // Last Data
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM torque_check");
        sbd.AppendLine("WHERE stamp_time >= '" + dtStart + "'");
        sbd.AppendLine("AND stamp_time <= '" + dtEnd + "'");
        dTable = oConnMecha.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "0";
        }
        oMDMecha.ListOfQty.Add(oMDList);

        // Pipe
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM PipeMarking");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDPipe.LineName = "Pipe";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '312'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            //sbd.AppendLine("order by LogTime desc");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }
        }
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM PipeIDCheck2");
        sbd.AppendLine("WHERE CONVERT(datetime,RTRIM(DateShift_yyyy) + '-' + RTRIM(DateShift_mm) + '-' + RTRIM(DateShift_dd) ");
        sbd.AppendLine("+ ' ' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),1,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),3,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),5,2))");
        sbd.AppendLine(">= '" + dtStart + "'");
        sbd.AppendLine("AND CONVERT(datetime,RTRIM(DateShift_yyyy) + '-' + RTRIM(DateShift_mm) + '-' + RTRIM(DateShift_dd) ");
        sbd.AppendLine("+ ' ' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),1,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),3,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),5,2))");
        sbd.AppendLine("<= '" + dtEnd + "'");
        dTable = oConnFac3.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "";
        }
        oMDPipe.ListOfQty.Add(oMDList);

        // Main Assy
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(RY_ID) as Qty");
        sbd.AppendLine("FROM Rotor_Yakibame_Split");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        sbd.AppendLine("AND RotorNumber != ''");
        sbd.AppendLine("AND Result = 'OK'");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDMain.LineName = "Main Assy";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;

            //sbd = new StringBuilder();
            //sbd.AppendLine("SELECT COUNT(No2_RotorNumber) as Qty");
            //sbd.AppendLine("FROM Rotor_Yakibame");
            //sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            //sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            //sbd.AppendLine("AND No2_RotorNumber != ''");
            //sbd.AppendLine("AND No2_Result = 'OK'");
            //dTable = oConnFac3.Query(sbd.ToString());
            //if (dTable.Rows.Count > 0)
            //{
            //    oMDList.StartD = (Convert.ToInt16(oMDList.StartD) + Convert.ToInt16(dTable.Rows[0]["Qty"].ToString())).ToString();
            //}

            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '301'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            //sbd.AppendLine("order by LogTime desc");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }

        }
        // Last Data
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM ElectricalConduction");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        sbd.AppendLine("AND EC_UV='OK'");
        sbd.AppendLine("AND [EC_VW]='OK'");
        sbd.AppendLine("AND [EC_WU]='OK'");
        sbd.AppendLine("AND [IntegratedJudgementResult]='OK'");
        dTable = oConnFac3.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "";
        }
        oMDMain.ListOfQty.Add(oMDList);

        // Final
        oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
        dtStart = Convert.ToDateTime(DateStart);
        dtEnd = Convert.ToDateTime(DateEnd);
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(DISTINCT LabelNo) as Qty");
        sbd.AppendLine("FROM LabelPrinting");
        sbd.AppendLine("WHERE MFGDate >= '" + dtStart + "'");
        sbd.AppendLine("AND MFGDate <= '" + dtEnd + "'");
        sbd.AppendLine("AND [PipeNumber] != ''");
        dTable = oConnFac3.Query(sbd.ToString());
        oMDFinal.LineName = "Final";
        if (dTable.Rows.Count > 0)
        {
            oMDList.Date = dtStart.ToString("yyyy-MM-dd");
            oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
            oMDList.Day = DateTime.Now.Day;
            // Get Plan
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
            sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
            sbd.AppendLine("WHERE BoardId = '303'");
            sbd.AppendLine("and LogTime >= '" + dtStart + "'");
            sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
            sbd.AppendLine("and DailyPlan != '0'");
            //sbd.AppendLine("order by LogTime desc");
            dTable = oConnPDB.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
            }
            else
            {
                oMDList.PlanD = "0";
            }
        }
        // Last Data
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT COUNT(*) as Qty");
        sbd.AppendLine("FROM FN_WeightCheck");
        sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
        sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
        sbd.AppendLine("AND [IntegratedJudgement]='OK'");
        dTable = oConnFac3.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
        }
        else
        {
            oMDList.LastD = "";
        }
        oMDFinal.ListOfQty.Add(oMDList);

        oMDProduc.ListOfProductivity.Add(oMDRH);
        oMDProduc.ListOfProductivity.Add(oMDCY);
        oMDProduc.ListOfProductivity.Add(oMDCS);
        oMDProduc.ListOfProductivity.Add(oMDFH);
        oMDProduc.ListOfProductivity.Add(oMDPS);
        oMDProduc.ListOfProductivity.Add(oMDMecha);
        oMDProduc.ListOfProductivity.Add(oMDPipe);
        oMDProduc.ListOfProductivity.Add(oMDMain);
        oMDProduc.ListOfProductivity.Add(oMDFinal);

        return oMDProduc;
    }


    public MDProcductivity GetProductivityByMonth(int Month, int Year)
    {
        MDProcductivity oMDProduc = new MDProcductivity();
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        int days = DateTime.DaysInMonth(Year, Month);
        DateTime dtStart = new DateTime();
        DateTime dtEnd = new DateTime();

        MDProcductivity.CMDProductivity oMDRH = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDCY = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDCS = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDFH = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDPS = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDMecha = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDPipe = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDMain = new MDProcductivity.CMDProductivity();
        MDProcductivity.CMDProductivity oMDFinal = new MDProcductivity.CMDProductivity();

        for (int day = 1; day <= days; day++)
        {
            // Rear head
            // Day Shift
            MDProcductivity.CMDProductivity.CMDListQty oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_RH");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDRH.LineName = "Rear Head";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '304'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [rh_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_rear_head]");
            sbd.AppendLine("where rh_line = 'RH_ID_FL_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE rh_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE rh_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and rh_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastD = "0";
            }

            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_RH");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '304'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [rh_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_rear_head]");
            sbd.AppendLine("where rh_line = 'RH_ID_FL_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE rh_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE rh_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and rh_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastN = "0";
            }
            oMDRH.ListOfQty.Add(oMDList);


            // Cylinder
            // Day Shift
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_CY");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDCY.LineName = "Cylinder";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '305'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [cy_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_cylinder]");
            sbd.AppendLine("where cy_line = 'CY_HEI_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cy_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cy_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and cy_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_CY");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '305'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }

                oMDList.LastN = "0";
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [cy_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_cylinder]");
            sbd.AppendLine("where cy_line = 'CY_HEI_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cy_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cy_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and cy_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastN = "0";
            }
            oMDCY.ListOfQty.Add(oMDList);


            // Crank Shaft
            // Day Shift
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_CS");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDCS.LineName = "Crank Shaft";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '306'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [cs_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_crank_shaft]");
            sbd.AppendLine("where cs_line = 'CS_PE_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cs_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cs_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and cs_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_CS");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '306'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }

            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [cs_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_crank_shaft]");
            sbd.AppendLine("where cs_line = 'CS_PE_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cs_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE cs_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and cs_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastN = "0";
            }
            oMDCS.ListOfQty.Add(oMDList);


            // Front Head
            // Day Shift 
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_FH");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDFH.LineName = "Front Head";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '307'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [fh_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_front_head]");
            sbd.AppendLine("where fh_line = 'FH_FINISH_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE fh_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE fh_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and fh_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_FH");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '307'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [fh_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_front_head]");
            sbd.AppendLine("where fh_line = 'FH_FINISH_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE fh_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE fh_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and fh_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastN = "0";
            }
            oMDFH.ListOfQty.Add(oMDList);


            // Piston
            // Day Shift
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_Piston");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDPS.LineName = "Piston";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '308'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [pt_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_piston]");
            sbd.AppendLine("where pt_line = 'PT_HEI_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE pt_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE pt_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and pt_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM MC_LaserMark_Piston");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '308'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }
            }
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT [pt_id]) as Qty");
            sbd.AppendLine("FROM [ETD_FAC3].[dbo].[etd_piston]");
            sbd.AppendLine("where pt_line = 'PT_HEI_FAC3'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE pt_date END) >= '" + dtStart + "'");
            sbd.AppendLine("and (CASE WHEN first_stamptime is not null THEN first_stamptime ELSE pt_date END) <= '" + dtEnd + "'");
            sbd.AppendLine("and pt_judgement = 'OK'");
            dTable = oConnETD.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            else
            {
                oMDList.LastN = "0";
            }
            oMDPS.ListOfQty.Add(oMDList);


            // Mecha
            // Day Shift
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM mecha_matching_result");
            sbd.AppendLine("WHERE date_time >= '" + dtStart + "'");
            sbd.AppendLine("AND date_time <= '" + dtEnd + "'");
            dTable = oConnMecha.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDMecha.LineName = "Mecha";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '302'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }

                //oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM mecha_matching_result");
            sbd.AppendLine("WHERE date_time >= '" + dtStart + "'");
            sbd.AppendLine("AND date_time <= '" + dtEnd + "'");
            dTable = oConnMecha.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '302'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }

                //oMDList.LastN = "0";
            }
            // Last Data
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM torque_check");
            sbd.AppendLine("WHERE stamp_time >= '" + dtStart + "'");
            sbd.AppendLine("AND stamp_time <= '" + dtEnd + "'");
            dTable = oConnMecha.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();

            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM torque_check");
            sbd.AppendLine("WHERE stamp_time >= '" + dtStart + "'");
            sbd.AppendLine("AND stamp_time <= '" + dtEnd + "'");
            dTable = oConnMecha.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            oMDMecha.ListOfQty.Add(oMDList);


            // Pipe
            // Day Shift
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM PipeMarking");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDPipe.LineName = "Pipe";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '312'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }

                //oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM PipeMarking");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '312'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }

                //oMDList.LastN = "0";
            }
            // Last Data
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM PipeIDCheck2");
            //sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            //sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("WHERE CONVERT(datetime,RTRIM(DateShift_yyyy) + '-' + RTRIM(DateShift_mm) + '-' + RTRIM(DateShift_dd) ");
            sbd.AppendLine("+ ' ' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),1,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),3,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),5,2))");
            sbd.AppendLine(">= '" + dtStart + "'");
            sbd.AppendLine("AND CONVERT(datetime,RTRIM(DateShift_yyyy) + '-' + RTRIM(DateShift_mm) + '-' + RTRIM(DateShift_dd) ");
            sbd.AppendLine("+ ' ' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),1,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),3,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),5,2))");
            sbd.AppendLine("<= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();

            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM PipeIDCheck2");
            //sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            //sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("WHERE CONVERT(datetime,RTRIM(DateShift_yyyy) + '-' + RTRIM(DateShift_mm) + '-' + RTRIM(DateShift_dd) ");
            sbd.AppendLine("+ ' ' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),1,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),3,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),5,2))");
            sbd.AppendLine(">= '" + dtStart + "'");
            sbd.AppendLine("AND CONVERT(datetime,RTRIM(DateShift_yyyy) + '-' + RTRIM(DateShift_mm) + '-' + RTRIM(DateShift_dd) ");
            sbd.AppendLine("+ ' ' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),1,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),3,2) + ':' + SUBSTRING(REPLACE(CycleEndTime,' ','0'),5,2))");
            sbd.AppendLine("<= '" + dtEnd + "'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            oMDPipe.ListOfQty.Add(oMDList);


            // Main Assy
            // Day Shift
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(RY_ID) as Qty");
            sbd.AppendLine("FROM Rotor_Yakibame_Split");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND RotorNumber != ''");
            sbd.AppendLine("AND Result = 'OK'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDMain.LineName = "Main Assy";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;

                //sbd = new StringBuilder();
                //sbd.AppendLine("SELECT COUNT(No2_RotorNumber) as Qty");
                //sbd.AppendLine("FROM Rotor_Yakibame");
                //sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
                //sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
                //sbd.AppendLine("AND No2_RotorNumber != ''");
                //sbd.AppendLine("AND No2_Result = 'OK'");
                //dTable = oConnFac3.Query(sbd.ToString());
                //if (dTable.Rows.Count > 0)
                //{
                //    oMDList.StartD = (Convert.ToInt16(oMDList.StartD) + Convert.ToInt16(dTable.Rows[0]["Qty"].ToString())).ToString();
                //}

                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '301'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }

                //oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(RY_ID) as Qty");
            sbd.AppendLine("FROM Rotor_Yakibame_Split");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND RotorNumber != ''");
            sbd.AppendLine("AND Result = 'OK'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();

                //sbd = new StringBuilder();
                //sbd.AppendLine("SELECT COUNT(No2_RotorNumber) as Qty");
                //sbd.AppendLine("FROM Rotor_Yakibame");
                //sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
                //sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
                //sbd.AppendLine("AND No2_RotorNumber != ''");
                //sbd.AppendLine("AND No2_Result = 'OK'");
                //dTable = oConnFac3.Query(sbd.ToString());
                //if (dTable.Rows.Count > 0)
                //{
                //    oMDList.StartN = (Convert.ToInt16(oMDList.StartN) + Convert.ToInt16(dTable.Rows[0]["Qty"].ToString())).ToString();
                //}

                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '301'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }

                //oMDList.LastN = "0";
            }
            // Last Data
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM ElectricalConduction");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND EC_UV='OK'");
            sbd.AppendLine("AND [EC_VW]='OK'");
            sbd.AppendLine("AND [EC_WU]='OK'");
            sbd.AppendLine("AND [IntegratedJudgementResult]='OK'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();

            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(*) as Qty");
            sbd.AppendLine("FROM ElectricalConduction");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND EC_UV='OK'");
            sbd.AppendLine("AND [EC_VW]='OK'");
            sbd.AppendLine("AND [EC_WU]='OK'");
            sbd.AppendLine("AND [IntegratedJudgementResult]='OK'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            oMDMain.ListOfQty.Add(oMDList);


            // Final
            // Day Shift
            oMDList = new MDProcductivity.CMDProductivity.CMDListQty();
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT SerialNumber) as Qty");
            sbd.AppendLine("FROM vi_LabelPrinting");
            sbd.AppendLine("WHERE MFGDate >= '" + dtStart + "'");
            sbd.AppendLine("AND MFGDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND [PipeNumber] != ''");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDFinal.LineName = "Final";
                oMDList.Date = dtStart.ToString("yyyy-MM-dd");
                oMDList.StartD = dTable.Rows[0]["Qty"].ToString();
                oMDList.Day = day;
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '303'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanD = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanD = "0";
                }

                //oMDList.LastD = "0";
            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(DISTINCT SerialNumber) as Qty");
            sbd.AppendLine("FROM vi_LabelPrinting");
            sbd.AppendLine("WHERE MFGDate >= '" + dtStart + "'");
            sbd.AppendLine("AND MFGDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND [PipeNumber] != ''");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.StartN = dTable.Rows[0]["Qty"].ToString();
                // Get Plan
                sbd = new StringBuilder();
                sbd.AppendLine("SELECT TOP 1 [DailyPlan]");
                sbd.AppendLine("FROM [dbPDB].[dbo].[DataLog]");
                sbd.AppendLine("WHERE BoardId = '303'");
                sbd.AppendLine("and LogTime >= '" + dtStart + "'");
                sbd.AppendLine("and LogTime <= '" + dtEnd + "'");
                sbd.AppendLine("and DailyPlan != '0'");
                //sbd.AppendLine("order by LogTime desc");
                dTable = oConnPDB.Query(sbd.ToString());
                if (dTable.Rows.Count > 0)
                {
                    oMDList.PlanN = dTable.Rows[0]["DailyPlan"].ToString();
                }
                else
                {
                    oMDList.PlanN = "0";
                }

                //oMDList.LastN = "0";
            }
            // Last Data
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(PartSerialNo) as Qty");
            sbd.AppendLine("FROM vi_FN_WeightCheck");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND [IntegratedJudgement]='OK'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastD = dTable.Rows[0]["Qty"].ToString();

            }
            // Night Shift
            dtStart = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 20:00");
            dtEnd = Convert.ToDateTime(Year.ToString() + "-" + Month.ToString("00") + "-" + day.ToString("00") + " 08:00");
            dtEnd = dtEnd.AddDays(1);
            sbd = new StringBuilder();
            sbd.AppendLine("SELECT COUNT(PartSerialNo) as Qty");
            sbd.AppendLine("FROM vi_FN_WeightCheck");
            sbd.AppendLine("WHERE InsertDate >= '" + dtStart + "'");
            sbd.AppendLine("AND InsertDate <= '" + dtEnd + "'");
            sbd.AppendLine("AND [IntegratedJudgement]='OK'");
            dTable = oConnFac3.Query(sbd.ToString());
            if (dTable.Rows.Count > 0)
            {
                oMDList.LastN = dTable.Rows[0]["Qty"].ToString();
            }
            oMDFinal.ListOfQty.Add(oMDList);


        }

        oMDProduc.ListOfProductivity.Add(oMDRH);
        oMDProduc.ListOfProductivity.Add(oMDCY);
        oMDProduc.ListOfProductivity.Add(oMDCS);
        oMDProduc.ListOfProductivity.Add(oMDFH);
        oMDProduc.ListOfProductivity.Add(oMDPS);
        oMDProduc.ListOfProductivity.Add(oMDMecha);
        oMDProduc.ListOfProductivity.Add(oMDPipe);
        oMDProduc.ListOfProductivity.Add(oMDMain);
        oMDProduc.ListOfProductivity.Add(oMDFinal);


        return oMDProduc;
    }

}