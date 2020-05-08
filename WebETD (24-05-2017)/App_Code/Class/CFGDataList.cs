using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ALPHAWinServices;
using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for CFGDataList
/// </summary>
public class CFGDataList
{
    ConnectDB oConDIT = new ConnectDB();
    ConnectDBSCM oConSCM = new ConnectDBSCM();
    ClsALPHA CAlpha = new ClsALPHA();
    OraConnectDB oOraAL1 = new OraConnectDB("ALPHA01");
    public DataTable GetDataFG(string Date, string Line, string Shift)
    {
        string i = "";
        string _Shift = "";
        if (Shift.Split(',')[2] == "D")
        {
            i = "0";
            _Shift = "dataShift in ('D')";
        }
        else if (Shift.Split(',')[2] == "N")
        {
            i = "1";
            _Shift = "dataShift in ('N')";
        }
        else
        {
            i = "1";
            _Shift = "dataShift in ('D','N')";
        }

        DateTime _time1 = new DateTime();
        DateTime _time2 = new DateTime();
        DateTime _time3 = new DateTime();

        _time1 = DateTime.Now;

        DataTable dTable = new DataTable();
        string sql = "";
        //*********** Select No 1 ->> Select from Fn_dataDIT 
        //*********** Select No 2 ->> Select from FN_Datacenter left join PN_compessor
        //*********** Select No 3 ->> Select from FG_ReportDefect
        // Select No 1 FULL OUTER JOIN  Select No 2 FULL OUTER JOIN Select No 3 on modelcode
        sql = @"SELECT case when t1.modelcode is null then case when t2.modelcode is null then t3.dataModelCode else t2.modelcode end else t1.modelcode end  as ModelCode,
                        case when t1.Model is null then case when t2.ModelName is null then t3.dataModel else t2.ModelName end else t1.Model end as Model,
                        case when t1.Qty is null then '0' else t1.Qty end as Production_Qty,
                        case when t2.Qty is null then '0' else t2.Qty end as Relabel,
                        case when t3.Qty is null then '0' else t3.Qty end as Rework,
                        'Coming soon' as RWE,
                        'Coming soon' as RWQ,
                        'Coming soon' as PDT_UWH
                FROM 
                    (SELECT distinct case when len(SerialNo) = 15 then substring(SerialNo,5,3) when len(SerialNo) = 11 then substring(SerialNo,1,4) end as modelcode,
                    FN_DIT.[Model],COUNT(distinct FN_DIT.SerialNo) as Qty
                    FROM [dbIoT].[dbo].[FinalDataDIT] FN_DIT
                    where  SendDate between '" + Date + @" " + Shift.Split(',')[0] + @"' and DATEADD(DAY," + i + @",'" + Date + @"') + ' " + Shift.Split(',')[1] + @"'  and FN_DIT.[LineNo] like '%" + Line + @"%'
                    and SerialNo not in (select SerialNo from [dbIoT].[dbo].[FG_ReportDefect] where len(SerialNo) in (11,15) )
                    group by FN_DIT.Model,case when len(SerialNo) = 15 then substring(SerialNo,5,3) when len(SerialNo) = 11 then substring(SerialNo,1,4) end) t1
                FULL OUTER JOIN
                    (SELECT  case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end as modelcode
                    , PN.[rmk1] as ModelName,count([Serial]) as Qty
                    FROM [dbDCI].[dbo].[FN_DataCenter] FN
                    left join [192.168.226.86].[dbSCM].[dbo].[PN_Compressor] PN on (case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end) = PN.[ModelCode] and FN.Line = PN.line
                    where  FN.Line like '%" + Line + @"%' and FN.ReLabel_Status like '%new' and FN.WC_InsertDate between '" + Date + @" " + Shift.Split(',')[0] + @"' and DATEADD(DAY," + i + @",'" + Date + @"') + ' " + Shift.Split(',')[1] + @"' 
                    group by case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end,PN.[rmk1]) t2
                ON (t1.modelcode = t2.modelcode)

                FULL OUTER JOIN 
                    (SELECT dataModelCode,dataModel,count(distinct SerialNo) as Qty
                    FROM [dbIoT].[dbo].[FG_ReportDefect]
                    where dataDate = '" + Date + @" " + Shift.Split(',')[0] + @"' and  " + _Shift + @" and dataLine like '%" + Line + @"%' and len(SerialNo) <= 15  and len(SerialNo) >= 11 group by dataModelCode,dataModel) t3 
                on t1.modelcode = t3.dataModelCode";
        dTable = oConDIT.Query(sql);

        _time2 = DateTime.Now;



        DataTable dtData = new DataTable();
        dtData.Columns.Add("ModelCode", typeof(string));
        dtData.Columns.Add("Model", typeof(string));
        dtData.Columns.Add("Production_Qty", typeof(string));
        dtData.Columns.Add("Relabel", typeof(string));
        dtData.Columns.Add("Rework", typeof(string));
        dtData.Columns.Add("PDT", typeof(string));
        dtData.Columns.Add("UWH", typeof(string));
        dtData.Columns.Add("RWD", typeof(string));
        dtData.Columns.Add("RWE", typeof(string));
        dtData.Columns.Add("RWQ", typeof(string));


        foreach (DataRow row in dTable.Rows)
        {
            _time3 = DateTime.Now;

            DataRow newRow = dtData.NewRow();
            newRow["ModelCode"] = row["ModelCode"].ToString();
            newRow["Model"] = row["Model"].ToString();
            newRow["Production_Qty"] = row["Production_Qty"].ToString();
            newRow["Relabel"] = row["Relabel"].ToString();
            newRow["Rework"] = row["Rework"].ToString();
            newRow["PDT"] = "Loading";
            newRow["UWH"] = "Loading";
            newRow["RWD"] = "Loading";
            newRow["RWE"] = "Loading";
            newRow["RWq"] = "Loading";
            dtData.Rows.Add(newRow);


        }


        return dtData;
    }
    public DataTable loadDataCustom(string Sdate,string Edate, string Line)
    {
        DataTable dTable = new DataTable();
        string sql = "";
        //*********** Select No 1 ->> Select from Fn_dataDIT 
        //*********** Select No 2 ->> Select from FN_Datacenter left join PN_compessor
        //*********** Select No 3 ->> Select from FG_ReportDefect
        // Select No 1 FULL OUTER JOIN  Select No 2 FULL OUTER JOIN Select No 3 on modelcode
        sql = @"SELECT case when t1.modelcode is null then case when t2.modelcode is null then t3.dataModelCode else t2.modelcode end else t1.modelcode end  as ModelCode,
                            case when t1.Model is null then case when t2.ModelName is null then t3.dataModel else t2.ModelName end else t1.Model end as Model,
                            case when t1.Qty is null then '0' else t1.Qty end as Production_Qty,
                            case when t2.Qty is null then '0' else t2.Qty end as Relabel,
                            case when t3.Qty is null then '0' else t3.Qty end as Rework,
                            'Coming soon' as RWE,
                            'Coming soon' as RWQ,
                            'Coming soon' as PDT_UWH
                            FROM 
                (SELECT distinct case when len(SerialNo) = 15 then substring(SerialNo,5,3) when len(SerialNo) = 11 then substring(SerialNo,1,4) end as modelcode,
                FN_DIT.[Model],COUNT(distinct FN_DIT.SerialNo) as Qty
                FROM [dbIoT].[dbo].[FinalDataDIT] FN_DIT
                where  SendDate between '" + Sdate + @"' and  '" + Edate + @"' and FN_DIT.[LineNo] like '%1%'
                and SerialNo not in (select SerialNo from [dbIoT].[dbo].[FG_ReportDefect] where len(SerialNo) in (11,15) )
                group by FN_DIT.Model,case when len(SerialNo) = 15 then substring(SerialNo,5,3) when len(SerialNo) = 11 then substring(SerialNo,1,4) end) t1
                       FULL OUTER JOIN
                (SELECT  case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end as modelcode
                , PN.[rmk1] as ModelName,count([Serial]) as Qty
                FROM [dbDCI].[dbo].[FN_DataCenter] FN
                left join [192.168.226.86].[dbSCM].[dbo].[PN_Compressor] PN on (case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end) = PN.[ModelCode] and FN.Line = PN.line
                where  FN.Line like '%1%' and FN.ReLabel_Status like '%new' and FN.WC_InsertDate between '" + Sdate + @"' and  '" + Edate + @"'
                group by case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end,PN.[rmk1]) t2
                ON (t1.modelcode = t2.modelcode)

                        FULL OUTER JOIN 
                (SELECT dataModelCode,dataModel,count(distinct SerialNo) as Qty
                FROM [dbIoT].[dbo].[FG_ReportDefect]
                where dataDate between '" + Sdate + @"' and  '" + Edate + @"'  and dataLine like '%1%' and len(SerialNo) <= 15  and len(SerialNo) >= 11 group by dataModelCode,dataModel) t3 
                on t1.modelcode = t3.dataModelCode";
        try
        {
            
        dTable = oConDIT.Query(sql);
        }
        catch (Exception ex )
        {
            return dTable;
        }
        return dTable;
    }
    public string loadSerialCountByWCLineModel(string _wc, string _line, string _model )
    {
        string _result = "0";
        DataTable dtComp = new DataTable();
        string strSQL = @"SELECT COUNT(serial) counts
            FROM SE.FH001@ALPHAPD 
            WHERE TRIM(NWC) = '"+ _wc + "' AND TRIM(LINE) = '"+ _line + "' AND TRIM(MODEL) = '"+ _model + "' ";
        OracleCommand cmdComp = new OracleCommand();
        cmdComp.CommandText = strSQL;
        cmdComp.CommandTimeout = 120;
        dtComp = oOraAL1.Query(cmdComp);
        try
        {
            _result = dtComp.Rows[0]["counts"].ToString();
        }catch { }

        return _result;
    }

    public DataTable ExportDataFG(string Date, string Line, string Shift)
    {
        string i = "";
        if (Shift.Split(',')[2] == "D")
        {
            i = "0";
        }
        else if (Shift.Split(',')[2] == "N")
        {
            i = "1";
        }
        else
        {
            i = "1";
        }

        DataTable dTable = new DataTable();
        string sql = "";
        sql = @"SELECT distinct case when len(SerialNo) = 15 then substring(SerialNo,5,3) when len(SerialNo) = 11 then substring(SerialNo,1,3) end as modelcode,
                FN_DIT.[Model],FN_DIT.SerialNo
                FROM [dbIoT].[dbo].[FinalDataDIT] FN_DIT
                where SendDate between '" + Date + @" " + Shift.Split(',')[0] + @"' and DATEADD(DAY," + i + @",'" + Date + @"') + ' " + Shift.Split(',')[1] + @"' and FN_DIT.[LineNo] like '%" + Line + @"%'
                and SerialNo not in (select SerialNo from [dbIoT].[dbo].[FG_ReportDefect] where len(SerialNo) in (11,15) )
                order by ModelCode";
        return dTable = oConDIT.Query(sql);
    }
    public DataTable ExportDataRelabel(string Date, string Line, string Shift)
    {
        string i = "";
        if (Shift.Split(',')[2] == "D")
        {
            i = "0";
        }
        else if (Shift.Split(',')[2] == "N")
        {
            i = "1";
        }
        else
        {
            i = "1";
        }

        DataTable dTable = new DataTable();
        string sql = "";
        sql = @"SELECT  [Serial] as New_Serial ,FN.ReLabel_Serial as Old_Serial,
                        case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end as modelcode
                        , PN.[rmk1] as ModelName FROM [dbDCI].[dbo].[FN_DataCenter] FN left join [192.168.226.86].[dbSCM].[dbo].[PN_Compressor] PN on 
                        (case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end) = PN.modelcode 
                        and pn.line = (case when FN.Line = 7 THEN 4 else fn.Line end)
                        where FN.Line like '%" + Line + @"%' and FN.ReLabel_Status like '%new' 
                        and FN.WC_InsertDate between '" + Date + @" " + Shift.Split(',')[0] + @"' 
                        and DATEADD(DAY," + i + @",'" + Date + @"') + ' " + Shift.Split(',')[1] + @"'
                        ";
        return dTable = oConDIT.Query(sql);

    }
    public DataTable ExportDataRework(string Date, string Line, string Shift)
    {
        string i = "";
        string _Shift = "";
        if (Shift.Split(',')[2] == "D")
        {
            i = "0";
            _Shift = "dataShift in ('D')";
        }
        else if (Shift.Split(',')[2] == "N")
        {
            i = "1";
            _Shift = "dataShift in ('N')";
        }
        else
        {
            i = "1";
            _Shift = "dataShift in ('D','N')";
        }

        DataTable dTable = new DataTable();
        string sql = "";
        sql = @"SELECT distinct SerialNo,dataModelCode,dataModel
                  FROM [dbIoT].[dbo].[FG_ReportDefect]
                  where dataDate = '" + Date + @" " + Shift.Split(',')[0] + @"' and  " + _Shift + @" and dataLine like '%" + Line + @"%' 
                  and len(SerialNo) <= 15  and len(SerialNo) >= 11";
        return dTable = oConDIT.Query(sql);


       
    }

    public DataTable ExportDataFGC(string Date, string Line, string Shift)
    {

        string Sdate = Date.Split('-')[0].Replace('_', '-');
        string Edate = Date.Split('-')[1].Replace('_', '-');

        DataTable dTable = new DataTable();
        string sql = "";
        sql = @"SELECT distinct case when len(SerialNo) = 15 then substring(SerialNo,5,3) when len(SerialNo) = 11 then substring(SerialNo,1,3) end as modelcode,
                FN_DIT.[Model],FN_DIT.SerialNo
                FROM [dbIoT].[dbo].[FinalDataDIT] FN_DIT
                where SendDate between '" + Sdate + @"' and '" + Edate + @"' and FN_DIT.[LineNo] like '%" + Line + @"%'
                and SerialNo not in (select SerialNo from [dbIoT].[dbo].[FG_ReportDefect] where len(SerialNo) in (11,15) )
                order by ModelCode";
        return dTable = oConDIT.Query(sql);
    }
    public DataTable ExportDataRelabelC(string Date, string Line, string Shift)
    {
        string Sdate = Date.Split('-')[0].Replace('_', '-');
        string Edate = Date.Split('-')[1].Replace('_', '-');
        DataTable dTable = new DataTable();
        string sql = "";
        sql = @"SELECT  [Serial] as New_Serial ,FN.ReLabel_Serial as Old_Serial,
                        case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end as modelcode
                        , PN.[rmk1] as ModelName FROM [dbDCI].[dbo].[FN_DataCenter] FN left join [192.168.226.86].[dbSCM].[dbo].[PN_Compressor] PN on 
                        (case when len(Serial) = 15 then substring(Serial,5,3) when len(Serial) = 11 then substring(Serial,1,4) end) = PN.modelcode 
                        and pn.line = (case when FN.Line = 7 THEN 4 else fn.Line end)
                        where FN.Line like '%" + Line + @"%' and FN.ReLabel_Status like '%new' 
                        and FN.WC_InsertDate between '" + Sdate + @"' 
                        and '" + Edate + @"'
                        ";
        return dTable = oConDIT.Query(sql);

    }
    public DataTable ExportDataReworkC(string Date, string Line, string Shift)
    {
        string Sdate = Date.Split('-')[0].Replace('_', '-');
        string Edate = Date.Split('-')[1].Replace('_', '-');

        DataTable dTable = new DataTable();
        string sql = "";
        sql = @"SELECT distinct SerialNo,dataModelCode,dataModel
                  FROM [dbIoT].[dbo].[FG_ReportDefect]
                  where dataDate between '" + Sdate + @"' and '" + Edate + @"' and dataLine like '%" + Line + @"%' 
                  and len(SerialNo) <= 15  and len(SerialNo) >= 11";
        return dTable = oConDIT.Query(sql);



    }

    public DataTable ExportDataAlpha(string _wc,string _line)
    {
        DataTable dtComp = new DataTable();
        string strSQL = @"SELECT MODEL,SERIAL,NWC AS STATUS,TO_CHAR(NDATE, 'yyyyMMdd') AS STATUS_DATE,TO_CHAR(CDATE, 'yyyyMMdd') AS PRD_DATE,CTIME AS PRD_TIME,LINE,MPTYPE as TYPE
            FROM SE.FH001@ALPHAPD 
            WHERE TRIM(NWC) = '" + _wc + "' AND TRIM(LINE) = '" + _line + "'";
        OracleCommand cmdComp = new OracleCommand();
        cmdComp.CommandText = strSQL;
        cmdComp.CommandTimeout = 120;
        dtComp = oOraAL1.Query(cmdComp);

        return dtComp;
    }
    public DataTable getPlan(string _line,string _date)
    {
        DataTable dTable = new DataTable();
        string sql = @"SELECT    [WCNO]
                                ,[MODEL]
                                ,[DATA_TYPE]
                                ,[QTY]
                                ,[USERID]
                                ,FORMAT(CONVERT(date,PRDYMD),'yyyy-MM-dd') as Production_Date
                                ,FORMAT(CDATE,'yyyy-MM-dd HH:mm:ss') as CDATE
                                ,FORMAT(UDATE,'yyyy-MM-dd HH:mm:ss') as UDATE
                            FROM [dbSCM].[dbo].[AL_GSD_ACTPLN]
                            where WCNO = '90" + _line+"' and PRDYMD='"+_date+"'";
        dTable = oConSCM.Query(sql);
        return dTable;
    }

    public DataTable getActualLine7(string date)
    {
        try
        {

            DataTable dTable = new DataTable();
            string sql = @"SELECT *
                           FROM (
	                            SELECT COUNT(distinct serial_no) as Actual
	                            FROM [dbIoT].[dbo].[Scada_Main_Assy_FG]
	                            where InsertDate between " + date + @"
	                            and Serial_No is not null and Serial_No != 'ERROR'
	                            ) t1,
	                            (
	                            SELECT COUNT(serial_no) as Error
	                            FROM [dbIoT].[dbo].[Scada_Main_Assy_FG]
	                            where InsertDate between " + date + @"
	                            and Serial_No = 'ERROR'
	                            ) t2";
            dTable = oConDIT.Query(sql);


            return dTable;
        }
        catch (Exception ex)
        {

            return new DataTable();
        }
    }
    public DataTable loadSerialCountByWCLineModel(string _wc, string _line)
    {
        DataTable dtComp = new DataTable();
        string strSQL = @"SELECT MODEL,COUNT(serial) counts,'Loading' UWH,'Loading' RWD,'Loading' RWE,'Loading' RWQ
            FROM SE.FH001@ALPHAPD 
            WHERE TRIM(NWC) = '" + _wc + "' AND TRIM(LINE) = '" + _line + "' GROUP by MODEL";
        OracleCommand cmdComp = new OracleCommand();
        cmdComp.CommandText = strSQL;
        cmdComp.CommandTimeout = 120;
        dtComp = oOraAL1.Query(cmdComp);
        
        return dtComp;
    }

}
