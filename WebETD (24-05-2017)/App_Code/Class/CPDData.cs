using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CPDData
/// </summary>
public class CPDData
{
    ConnectDBCosty oConn = new ConnectDBCosty();
    ConnectDBIoT oConnIoT = new ConnectDBIoT();
    CultureInfo cu = new CultureInfo("en-US");
    public CPDData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int GetActual (string BoardID,bool LastDay)
    {
        int Actual = 0;
        

        if (LastDay)
        {
            DateTime dateD = new DateTime(DateTime.Now.AddDays(-1).Year, DateTime.Now.AddDays(-1).Month, DateTime.Now.AddDays(-1).Day, 20, 0, 0);
            DateTime dateN = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 59, 59);
            
            //-------------------- Get Actual shipt D and N Sum ----------------------
            SqlCommand sqlD = new SqlCommand();
            sqlD.CommandText = "SELECT TOP 1 * FROM [DataLog] WHERE BoardID = '" + BoardID + "' AND LogTime <= '"+ dateD.ToString("yyyy-MM-dd HH:mm:ss") + "' Order by LogTime DESC";
            DataTable dtD = oConn.SqlGet(sqlD, "DBPDB");
            if (dtD.Rows.Count > 0)
            {
                Actual = Convert.ToInt32(dtD.Rows[0]["Actual"].ToString());
            }

            SqlCommand sqlN = new SqlCommand();
            sqlN.CommandText = "SELECT TOP 1 * FROM [DataLog] WHERE BoardID = '" + BoardID + "' AND LogTime <= '"+ dateN.ToString("yyyy-MM-dd HH:mm:ss") + "' Order by LogTime DESC";
            DataTable dtN = oConn.SqlGet(sqlN, "DBPDB");
            if (dtN.Rows.Count > 0)
            {
                Actual += Convert.ToInt32(dtN.Rows[0]["Actual"].ToString());
            }
        }
        else
        {
            SqlCommand sqlActual = new SqlCommand();
            //---------------------- Get Actual Current -------------------------
            sqlActual.CommandText = "SElECT * FROM [BoardData] WHERE BoardId = '" + BoardID + "'";
            DataTable dtActual = oConn.SqlGet(sqlActual, "DBPDB");
            if (dtActual.Rows.Count > 0)
            {
                try
                {
                    Actual = Convert.ToInt32(dtActual.Rows[0]["Actual"].ToString());
                }
                catch { }
            }
        }
        
        
        return Actual;
    }

    public int GetActualByDate(string BoardID, DateTime DateSearch)
    {
        int Actual = 0;


        DateTime dateD = new DateTime(DateSearch.Year, DateSearch.Month, DateSearch.Day, 20, 0, 0);
        DateTime dateN = new DateTime(DateSearch.AddDays(1).Year, DateSearch.AddDays(1).Month, DateSearch.AddDays(1).Day, 7, 59, 00);

        //-------------------- Get Actual shipt D and N Sum ----------------------
        SqlCommand sqlD = new SqlCommand();
        sqlD.CommandText = "SELECT TOP 1 * FROM [DataLog] WHERE BoardID = '" + BoardID + "' AND LogTime <= '" + dateD.ToString("yyyy-MM-dd HH:mm:ss") + "' Order by LogTime DESC";
        DataTable dtD = oConn.SqlGet(sqlD, "DBPDB");
        if (dtD.Rows.Count > 0)
        {
            Actual = Convert.ToInt32(dtD.Rows[0]["Actual"].ToString());
        }

        SqlCommand sqlN = new SqlCommand();
        sqlN.CommandText = "SELECT TOP 1 * FROM [DataLog] WHERE BoardID = '" + BoardID + "' AND LogTime <= '" + dateN.ToString("yyyy-MM-dd HH:mm:ss") + "' Order by LogTime DESC";
        DataTable dtN = oConn.SqlGet(sqlN, "DBPDB");
        if (dtN.Rows.Count > 0)
        {
            Actual += Convert.ToInt32(dtN.Rows[0]["Actual"].ToString());
        }

        return Actual;
    }

    public DataTable GetDataActualOfMonth (string BoardID, int Month, int Year)
    {
        DataTable dtActual = new DataTable();
        dtActual.Columns.Add("Date", typeof(string));
        dtActual.Columns.Add("Actual", typeof(int));

        for (int i = 1; i < DateTime.DaysInMonth(Year,Month); i++)
        {
            DateTime startDate = new DateTime(Year, Month, i, 19, 59, 59);
            DateTime endDate = new DateTime(Year, Month, i).AddDays(1) + new TimeSpan(07, 59, 59);

            SqlCommand sql = new SqlCommand();
            sql.CommandText = "SELECT TOP(1) ((SELECT TOP (1) [Actual] FROM [DataLog] where BoardId = MainData.BoardId and LogTime <= @strDate ORDER BY LogTime DESC) + " +
                " (SELECT TOP(1)[Actual] FROM [DataLog] where BoardId = MainData.BoardId and LogTime <= @endDate ORDER BY LogTime DESC)) AS Actual" +
                " , MainData.LogTime FROM [DataLog]" +
                " AS MainData WHERE MainData.BoardId = @Board AND MainData.LogTime <= @strDate2  ORDER BY MainData.LogTime DESC";
            sql.Parameters.Add(new SqlParameter("strDate", startDate));
            sql.Parameters.Add(new SqlParameter("endDate", endDate));
            sql.Parameters.Add(new SqlParameter("strDate2", startDate));
            sql.Parameters.Add(new SqlParameter("Board", BoardID));
            DataTable dt = oConn.SqlGet(sql, "DBPDB");
            if (dt.Rows.Count > 0)
            {
                dtActual.Rows.Add(Convert.ToDateTime(dt.Rows[0]["LogTime"].ToString()).ToString("dd"), Convert.ToInt16(dt.Rows[0]["Actual"].ToString()));
            }
        }

        return dtActual;
    }
    

    //----------------------- Get Actual Line Main Fac 3 from IoT -----------------------
    public Tuple<int,int> GetActualMainAssyIoT(string BoardID,DateTime Date)
    {
        //-------------------- Get Actual OK,NG -------------------
        Tuple<int, int> Actual = new Tuple<int, int>(0,0);

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();

        strDate = new DateTime(Date.Year, Date.Month, Date.Day, 8, 0, 0);
        endDate = new DateTime(Date.AddDays(1).Year, Date.AddDays(1).Month, Date.AddDays(1).Day, 7, 59, 59);

        //------------------------ Get Data OK ---------------------
        SqlCommand sqlOK = new SqlCommand();
        sqlOK.CommandText = "SELECT [EC_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as CycleStartTime,"+
            " replace([CycleEndTime],' ','0') as CycleEndTime,[IntegratedJudgementResult]"+
            " ,[EC_UV],[EC_VW],[EC_WU],[InsertDate]"+
            " FROM [ElectricalConduction] WHERE[InsertDate] >= '"+ strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND[InsertDate] <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PartSerialNo != '' " +
            "AND replace([CycleEndTime],' ','0') != '000000' AND IntegratedJudgementResult = 'OK' ORDER BY[InsertDate] ASC";

        //------------------------ Get Data NG ---------------------
        SqlCommand sqlNG = new SqlCommand();
        sqlNG.CommandText = "SELECT [EC_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as CycleStartTime," +
            " replace([CycleEndTime],' ','0') as CycleEndTime,[IntegratedJudgementResult]" +
            " ,[EC_UV],[EC_VW],[EC_WU],[InsertDate]" +
            " FROM [ElectricalConduction] WHERE[InsertDate] >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND[InsertDate] <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PartSerialNo != '' " +
            "AND replace([CycleEndTime],' ','0') != '000000' AND IntegratedJudgementResult != 'OK' ORDER BY[InsertDate] ASC";

        DataTable dtOK = oConnIoT.SqlGet(sqlOK);
        DataTable dtNG = oConnIoT.SqlGet(sqlNG);

        Actual = new Tuple<int, int>(dtOK.Rows.Count,dtNG.Rows.Count);

        return Actual;
    }
    //----------------------- Get Actual Line Main Fac 3 from IoT -----------------------

    //--------------------- Get data model production on Main fac 3 by Date ---------------------
    public List<MModelPDMainFac3> GetModelProductionFromMainFac3(DateTime Date)
    {
        List<MModelPDMainFac3> ModelPD = new List<MModelPDMainFac3>();

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();

        strDate = new DateTime(Date.Year, Date.Month, Date.Day, 8, 0, 0);
        endDate = new DateTime(Date.AddDays(1).Year, Date.AddDays(1).Month, Date.AddDays(1).Day, 7, 59, 59);

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT DISTINCT ModelNo FROM [ElectricalConduction] WHERE [InsertDate] >= '"+ strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' "+
            " AND [InsertDate] <= '"+ endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PartSerialNo != '' ";
        DataTable dtModel = oConnIoT.SqlGet(sql);
        foreach (DataRow item in dtModel.Rows)
        {
            MModelPDMainFac3 itemModel = new MModelPDMainFac3();
            itemModel.Model = item["ModelNo"].ToString();
            ModelPD.Add(itemModel);
        }

        return ModelPD;
    }
    //--------------------- Get data model production on Main fac 3 by Date ---------------------


    //----------------------- Get Actual Line Main Fac 3 from IoT -----------------------
    public DataTable GetDataMainFac3(string BoardID, DateTime Date)
    {
        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();

        strDate = new DateTime(Date.Year, Date.Month, Date.Day, 8, 0, 0);
        endDate = new DateTime(Date.AddDays(1).Year, Date.AddDays(1).Month, Date.AddDays(1).Day, 7, 59, 59);

        //------------------------ Get Data OK ---------------------
        SqlCommand sqlOK = new SqlCommand();
        sqlOK.CommandText = "SELECT [EC_ID],[DateShift],[ModelNo],[MachineNo],[PartSerialNo],replace([CycleStartTime],' ','0') as CycleStartTime," +
            " replace([CycleEndTime],' ','0') as CycleEndTime,[IntegratedJudgementResult]" +
            " ,[EC_UV],[EC_VW],[EC_WU],[InsertDate]" +
            " FROM [ElectricalConduction] WHERE[InsertDate] >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND[InsertDate] <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PartSerialNo != '' " +
            "AND replace([CycleEndTime],' ','0') != '000000' ORDER BY[InsertDate] ASC";
        

        DataTable dt = oConnIoT.SqlGet(sqlOK);

        return dt;
    }
    //----------------------- Get Actual Line Main Fac 3 from IoT -----------------------


    //--------------- Get Data Main Assy OK NG By Date -------------------
    public DataTable GetDataMainFac3OKNG(string Status,DateTime DateSearch)
    {
        int Result = 0;
        DataTable dtFinal = new DataTable();
        DateTime DateNow = DateTime.Now;

        DateTime dateStart = new DateTime(DateSearch.Year, DateSearch.Month, DateSearch.Day, 8, 0, 0);
        DateTime dateEnd = new DateTime(DateSearch.AddDays(1).Year, DateSearch.AddDays(1).Month, DateSearch.AddDays(1).Day, 8, 0, 0);

        //------------ Get Actual Final OK ---------------
        SqlCommand sqlFinal = new SqlCommand();
        if (Status == "OK")
        {
            sqlFinal.CommandText = "SELECT DISTINCT PartSerialNo,ModelNo FROM [ElectricalConduction] WHERE InsertDate >= @strDate AND InsertDate <= @endDate AND " +
                "(PartSerialNo IS NULL OR PartSerialNo != '') AND IntegratedJudgementResult = 'OK' ";
        }
        else
        {
            sqlFinal.CommandText = "SELECT DISTINCT PartSerialNo,ModelNo FROM [ElectricalConduction] WHERE InsertDate >= @strDate AND InsertDate <= @endDate AND " +
                "(PartSerialNo IS NULL OR PartSerialNo != '') AND IntegratedJudgementResult != 'OK' ";
        }
        sqlFinal.Parameters.Add(new SqlParameter("@strDate", dateStart.ToString("yyyy-MM-dd HH:mm:ss")));
        sqlFinal.Parameters.Add(new SqlParameter("@endDate", dateEnd.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dtTable = oConnIoT.SqlGet(sqlFinal);
        //Result = dtTable.Rows.Count > 0 ? Convert.ToInt16(dtTable.Rows[0]["ACTUAL"].ToString()) : 0;

        return dtTable;
    }

    //---------------- Get Actual Main Fac 3 of Month ---------------------
    public int GetActualMainFac3ofMonth (int Month,int Year)
    {
        int Actual = 0;

        DateTime strDate = new DateTime(Year, Month, 1) + new TimeSpan(0, 0, 0);
        DateTime endDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year,Month)) + new TimeSpan(23, 59, 59);

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT COUNT(DISTINCT [PartSerialNo]) AS Actual FROM [ElectricalConduction] WHERE InsertDate >= '"+ strDate.ToString("yyyy-MM-dd HH:mm:ss") +
            "' AND InsertDate <= '"+endDate.ToString("yyyy-MM-dd HH:mm:ss")+ "' AND PartSerialNo != '' ";
        DataTable dtActual = oConnIoT.SqlGet(sql);

        if (dtActual.Rows.Count > 0)
        {
            Actual = Convert.ToInt32(dtActual.Rows[0]["Actual"].ToString());
        }

        return Actual;
    }

    public DataTable GetActualMainFac3ofMonthEachModel(int Month, int Year)
    {
        int Actual = 0;

        DateTime strDate = new DateTime(Year, Month, 1) + new TimeSpan(0, 0, 0);
        DateTime endDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)) + new TimeSpan(23, 59, 59);

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT [PartSerialNo],[ModelNo] FROM [ElectricalConduction] WHERE InsertDate >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") +
            "' AND InsertDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND PartSerialNo != '' ";
        DataTable dtActual = oConnIoT.SqlGet(sql);
        

        return dtActual;
    }

    public DataTable GetActualMainFac3EachHour (string BoardID,DateTime date)
    {
        DataTable dtActualEachHour = new DataTable();

        return dtActualEachHour;
    }
}