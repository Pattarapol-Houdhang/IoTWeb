using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CLineOut
/// </summary>
public class CLineOut
{

    ConnectDBDCI oConDCI = new ConnectDBDCI();


    public CLineOut()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    string[] ArryPeriod = {"LastYear", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC", "JAN", "FEB", "MAR" };
    int[] ArryMonth = { 4, 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3 };

    public List<CLineOut.LineOutChartInfo> GetModelHoldLineOutMonthReport(string PrdModel, string DataDate) {
        List<CLineOut.LineOutChartInfo> oAryResult = new List<CLineOut.LineOutChartInfo>();
        DateTime DataStart = new DateTime();
        DateTime DataEnd = new DateTime();
        DataStart = new DateTime(Convert.ToDateTime(DataDate).Year, Convert.ToDateTime(DataDate).Month, 1, 0, 0, 1);
        DataEnd = new DateTime(Convert.ToDateTime(DataDate).Year, Convert.ToDateTime(DataDate).Month, DateTime.DaysInMonth(Convert.ToDateTime(DataDate).Year, Convert.ToDateTime(DataDate).Month), 23, 59, 59);

        string ConditionModel = "";
        switch (PrdModel) {
            case "1YC": ConditionModel = " AND prd_model LIKE '1YC%' "; break;
            case "2YC": ConditionModel = " AND prd_model LIKE '2YC%' "; break;
            case "SCROLL": ConditionModel = " AND prd_model LIKE 'J%' "; break;
            case "ODM": ConditionModel = " AND (prd_model LIKE '1P%' OR prd_model LIKE '2P%')  "; break;
        }

        //****** 1YC Factory 3 *******
        if (PrdModel == "1YC/3")
        {
            //***** COUNT ALL *****
            DataTable dtCount3 = new DataTable();
            string strCount3 = "SELECT COUNT(prd_serial) AS COUNTS " +
                " FROM PD_FinalHold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') "+
                "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdCount3 = new SqlCommand();
            cmdCount3.CommandText = strCount3;
            cmdCount3.CommandTimeout = 180;
            cmdCount3.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdCount3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdCount3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtCount3 = oConDCI.Query(cmdCount3);
            int _counts3 = 0;
            try
            {
                _counts3 = Convert.ToInt32(dtCount3.Rows[0]["COUNTS"].ToString());
            }
            catch { }


            DataTable dtModel3 = new DataTable();
            string strModel3 = "SELECT DISTINCT prd_model_code,prd_model " +
                " FROM PD_FinalHold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdModel3 = new SqlCommand();
            cmdModel3.CommandText = strModel3;
            cmdModel3.CommandTimeout = 180;
            cmdModel3.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdModel3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdModel3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtModel3 = oConDCI.Query(cmdModel3);

            // if check have model data
            if (dtModel3.Rows.Count > 0)
            {
                foreach (DataRow drModel in dtModel3.Rows)
                {
                    //******** HOLD *********
                    DataTable dtHold = new DataTable();
                    string strHold = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_FinalHold " +
                        " WHERE prd_status IN ('HOLD', 'REQUEST') "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd " +
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdHold = new SqlCommand();
                    cmdHold.CommandText = strHold;
                    cmdHold.CommandTimeout = 180;
                    cmdHold.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdHold.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdHold.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtHold = oConDCI.Query(cmdHold);

                    //******** LINEOUT *********
                    DataTable dtLineOut = new DataTable();
                    string strLineOut = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_FinalHold " +
                        " WHERE prd_status IN ( 'LINEOUT' ) "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd " +
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdLineOut = new SqlCommand();
                    cmdLineOut.CommandText = strLineOut;
                    cmdLineOut.CommandTimeout = 180;
                    cmdLineOut.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdLineOut.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdLineOut.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtLineOut = oConDCI.Query(cmdLineOut);


                    //******** MODEL HOLD/LINEOUT *********
                    CLineOut.LineOutChartInfo mData = new CLineOut.LineOutChartInfo();
                    mData.dataModel = drModel["prd_model"].ToString();
                    mData.dataModelCode = drModel["prd_model_code"].ToString();
                    mData.dataCountLineOut = int.Parse(dtLineOut.Rows[0]["COUNTS"].ToString());
                    mData.dataCountHold = int.Parse(dtHold.Rows[0]["COUNTS"].ToString());
                    try
                    {
                        double dd1 = Convert.ToDouble(dtHold.Rows[0]["COUNTS"].ToString()) + Convert.ToDouble(dtLineOut.Rows[0]["COUNTS"].ToString());
                        double dd2 = Convert.ToDouble(_counts3);
                        double dd3 = dd1 / dd2;
                        double dd4 = dd3 * 100;

                        mData.dataRatio = dd4;
                    }
                    catch { mData.dataRatio = 0; }

                    oAryResult.Add(mData);
                    
                } // end foraech
            } // end if check have model data
           

        }
        //****** ELSE IF OVERALL *******
        else if (PrdModel == "OVERALL")
        {

            //****** COUNT ******
            DataTable dtCount = new DataTable();
            string strCount = "SELECT COUNT(prd_serial) AS COUNTS " +
                " FROM PD_Hold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') "+
                "    AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdCount = new SqlCommand();
            cmdCount.CommandText = strCount;
            cmdCount.CommandTimeout = 180;
            cmdCount.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdCount.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdCount.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtCount = oConDCI.Query(cmdCount);
            int _counts = 0;
            try
            {
                _counts = Convert.ToInt32(dtCount.Rows[0]["COUNTS"].ToString());
            }
            catch { }

            DataTable dtCount3 = new DataTable();
            string strCount3 = "SELECT COUNT(prd_serial) AS COUNTS " +
                " FROM PD_FinalHold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') "+
                "    AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdCount3 = new SqlCommand();
            cmdCount3.CommandText = strCount3;
            cmdCount3.CommandTimeout = 180;
            cmdCount3.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdCount3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdCount3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtCount3 = oConDCI.Query(cmdCount3);
            int _counts3 = 0;
            try
            {
                _counts3 = Convert.ToInt32(dtCount3.Rows[0]["COUNTS"].ToString());
            }
            catch { }


            // **** Get Model DataTable ****
            DataTable dtModel = new DataTable();
            
            DataTable dtModel1 = new DataTable();
            string strModel1 = "SELECT DISTINCT prd_model_code,prd_model " +
                " FROM PD_Hold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') "+
                "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdModel1 = new SqlCommand();
            cmdModel1.CommandText = strModel1;
            cmdModel1.CommandTimeout = 180;
            cmdModel1.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdModel1.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdModel1.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtModel1 = oConDCI.Query(cmdModel1);

            //(prd_model + '/F3') AS prd_model
            DataTable dtModel3 = new DataTable();
            string strModel3 = "SELECT DISTINCT prd_model_code,prd_model " +
                " FROM PD_FinalHold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') "+
                "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdModel3 = new SqlCommand();
            cmdModel3.CommandText = strModel3;
            cmdModel3.CommandTimeout = 180;
            cmdModel3.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdModel3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdModel3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtModel3 = oConDCI.Query(cmdModel3);

            dtModel = dtModel1.Copy();
            dtModel.Merge(dtModel3);
            dtModel = dtModel.AsEnumerable().Distinct().CopyToDataTable();
            // **** End Get Model DataTable ****


            // if check have model data
            if (dtModel.Rows.Count > 0)
            {
                foreach (DataRow drModel in dtModel.Rows)
                {

                    #region Factory 3
                    //******** HOLD *********
                    DataTable dtHold3 = new DataTable();
                    string strHold3 = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_FinalHold " +
                        " WHERE prd_status IN ('HOLD', 'REQUEST') "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + 
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdHold3 = new SqlCommand();
                    cmdHold3.CommandText = strHold3;
                    cmdHold3.CommandTimeout = 180;
                    cmdHold3.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdHold3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdHold3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtHold3 = oConDCI.Query(cmdHold3);

                    //******** LINEOUT *********
                    DataTable dtLineOut3 = new DataTable();
                    string strLineOut3 = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_FinalHold " +
                        " WHERE prd_status IN ( 'LINEOUT' ) "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd " +
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdLineOut3 = new SqlCommand();
                    cmdLineOut3.CommandText = strLineOut3;
                    cmdLineOut3.CommandTimeout = 180;
                    cmdLineOut3.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdLineOut3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdLineOut3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtLineOut3 = oConDCI.Query(cmdLineOut3);
                    #endregion


                    #region  Other
                    DataTable dtHold = new DataTable();
                    string strHold = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_Hold " +
                        " WHERE prd_status IN ( 'HOLD', 'REQUEST') "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd " +
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdHold = new SqlCommand();
                    cmdHold.CommandText = strHold;
                    cmdHold.CommandTimeout = 180;
                    cmdHold.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdHold.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdHold.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtHold = oConDCI.Query(cmdHold);

                    DataTable dtLineOut = new DataTable();
                    string strLineOut = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_Hold " +
                        " WHERE prd_status IN ( 'LINEOUT' ) "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd " +
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdLineOut = new SqlCommand();
                    cmdLineOut.CommandText = strLineOut;
                    cmdLineOut.CommandTimeout = 180;
                    cmdLineOut.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdLineOut.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdLineOut.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtLineOut = oConDCI.Query(cmdLineOut);
                    #endregion


                    //******** MODEL HOLD/LINEOUT *********
                    CLineOut.LineOutChartInfo mData = new CLineOut.LineOutChartInfo();
                    mData.dataModel = drModel["prd_model"].ToString();
                    mData.dataModelCode = drModel["prd_model_code"].ToString();
                    mData.dataCountLineOut = int.Parse(dtLineOut.Rows[0]["COUNTS"].ToString()) + int.Parse(dtLineOut3.Rows[0]["COUNTS"].ToString());
                    mData.dataCountHold = int.Parse(dtHold.Rows[0]["COUNTS"].ToString()) + int.Parse(dtHold3.Rows[0]["COUNTS"].ToString());
                    try
                    {
                        double dd1 = Convert.ToDouble(dtHold.Rows[0]["COUNTS"].ToString()) + Convert.ToDouble(dtLineOut.Rows[0]["COUNTS"].ToString());
                        dd1 += Convert.ToDouble(dtHold3.Rows[0]["COUNTS"].ToString()) + Convert.ToDouble(dtLineOut3.Rows[0]["COUNTS"].ToString());
                        double dd2 = Convert.ToDouble(_counts) + Convert.ToDouble(_counts3);
                        double dd3 = dd1 / dd2;
                        double dd4 = dd3 * 100;

                        mData.dataRatio = dd4;
                    }
                    catch { mData.dataRatio = 0; }

                    oAryResult.Add(mData);

                } // end foreach
            }// end if check have model data

            



        }
        //****** ELSE *******
        else {

            //***** COUNT ALL *****
            DataTable dtCount = new DataTable();
            string strCount = "SELECT COUNT(prd_serial) AS COUNTS " +
                " FROM PD_Hold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') "+
                "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdCount = new SqlCommand();
            cmdCount.CommandText = strCount;
            cmdCount.CommandTimeout = 180;
            cmdCount.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdCount.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdCount.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtCount = oConDCI.Query(cmdCount);
            int _counts = 0;
            try
            {
                _counts = Convert.ToInt32(dtCount.Rows[0]["COUNTS"].ToString());
            }
            catch { }

            DataTable dtModel = new DataTable();
            string strModel = "SELECT DISTINCT prd_model_code,prd_model " +
                " FROM PD_Hold " +
                " WHERE prd_status IN ('LINEOUT','HOLD', 'REQUEST') "+
                "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdModel = new SqlCommand();
            cmdModel.CommandText = strModel;
            cmdModel.CommandTimeout = 180;
            cmdModel.Parameters.Add(new SqlParameter("@prd_model", PrdModel));
            cmdModel.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdModel.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtModel = oConDCI.Query(cmdModel);

            // if check have model data
            if (dtModel.Rows.Count > 0)
            {
                foreach (DataRow drModel in dtModel.Rows)
                {
                    DataTable dtHold = new DataTable();
                    string strHold = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_Hold " +
                        " WHERE prd_status IN ( 'HOLD', 'REQUEST' ) "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd " +
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdHold = new SqlCommand();
                    cmdHold.CommandText = strHold;
                    cmdHold.CommandTimeout = 180;
                    cmdHold.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdHold.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdHold.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtHold = oConDCI.Query(cmdHold);

                    DataTable dtLineOut = new DataTable();
                    string strLineOut = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS " +
                        " FROM PD_Hold " +
                        " WHERE prd_status IN ( 'LINEOUT' ) "+
                        "   AND HoldDate BETWEEN @DateStart AND @DateEnd  " +
                        "   AND prd_model_code=@prd_model ";
                    SqlCommand cmdLineOut = new SqlCommand();
                    cmdLineOut.CommandText = strLineOut;
                    cmdLineOut.CommandTimeout = 180;
                    cmdLineOut.Parameters.Add(new SqlParameter("@prd_model", drModel["prd_model_code"].ToString()));
                    cmdLineOut.Parameters.Add(new SqlParameter("@DateStart", DataStart));
                    cmdLineOut.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
                    dtLineOut = oConDCI.Query(cmdLineOut);


                    //******** MODEL HOLD/LINEOUT *********
                    CLineOut.LineOutChartInfo mData = new CLineOut.LineOutChartInfo();
                    mData.dataModel = drModel["prd_model"].ToString();
                    mData.dataModelCode = drModel["prd_model_code"].ToString();
                    mData.dataCountLineOut = int.Parse(dtLineOut.Rows[0]["COUNTS"].ToString());
                    mData.dataCountHold = int.Parse(dtHold.Rows[0]["COUNTS"].ToString());
                    try
                    {
                        double dd1 = Convert.ToDouble(dtHold.Rows[0]["COUNTS"].ToString()) + Convert.ToDouble(dtLineOut.Rows[0]["COUNTS"].ToString());
                        double dd2 = Convert.ToDouble(_counts);
                        double dd3 = dd1 / dd2;
                        double dd4 = dd3 * 100;

                        mData.dataRatio = dd4;
                    }
                    catch { mData.dataRatio = 0; }

                    oAryResult.Add(mData);

                } // end foreach
            } // end if check have model data

        } // end else

        oAryResult = oAryResult.OrderByDescending(i => i.dataRatio).ToList();

        return oAryResult;
    }
    

    public List<CLineOut.ProcessHoldLineOutInfo> GetProcessHoldLineOutMonthReport(string PrdModel, string DataDate)
    {
        List<CLineOut.ProcessHoldLineOutInfo> oAryResult = new List<CLineOut.ProcessHoldLineOutInfo>();
        DateTime DataStart = new DateTime();
        DateTime DataEnd = new DateTime();
        DataStart = new DateTime(Convert.ToDateTime(DataDate).Year, Convert.ToDateTime(DataDate).Month, 1, 0, 0, 1);
        DataEnd = new DateTime(Convert.ToDateTime(DataDate).Year, Convert.ToDateTime(DataDate).Month, DateTime.DaysInMonth(Convert.ToDateTime(DataDate).Year, Convert.ToDateTime(DataDate).Month), 23, 59, 59);

        string ConditionModel = "";
        switch (PrdModel)
        {
            case "1YC": ConditionModel = " AND h.prd_model LIKE '1YC%' "; break;
            case "2YC": ConditionModel = " AND h.prd_model LIKE '2YC%' "; break;
            case "SCROLL": ConditionModel = " AND h.prd_model LIKE 'J%' "; break;
            case "ODM": ConditionModel = " AND (h.prd_model LIKE '1P%' OR h.prd_model LIKE '2P%')  "; break;
        }

        



        //****** 1YC Factory 3 *******
        if (PrdModel == "1YC/3")
        {
            #region 1YC/3
            DataTable dtData1 = new DataTable();
            string strData1 = "SELECT 'FAC301' AS ProcessCode, '1. OIL CHARGING' AS ProcessName, " +
                "      COUNT(DISTINCT prd_serial) AS COUNTS "+
                " FROM PD_FinalHold "+
                " WHERE HoldDate BETWEEN @DateStart AND @DateEnd AND prd_status IN('LINEOUT') AND OilingStatus IN ('NG','NO') ";
            SqlCommand cmdData1 = new SqlCommand();
            cmdData1.CommandText = strData1;
            cmdData1.CommandTimeout = 180;
            cmdData1.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData1.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData1 = oConDCI.Query(cmdData1);

            DataTable dtData2 = new DataTable();
            string strData2 = "SELECT 'FAC301' AS ProcessCode, '2. RUNNING TEST' AS ProcessName, " +
                "      COUNT(DISTINCT prd_serial) AS COUNTS " +
                " FROM PD_FinalHold " +
                " WHERE HoldDate BETWEEN @DateStart AND @DateEnd AND prd_status IN('LINEOUT') AND RunningTestStatus IN ('NG','NO') ";
            SqlCommand cmdData2 = new SqlCommand();
            cmdData2.CommandText = strData2;
            cmdData2.CommandTimeout = 180;
            cmdData2.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData2.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData2 = oConDCI.Query(cmdData2);

            DataTable dtData3 = new DataTable();
            string strData3 = "SELECT 'FAC301' AS ProcessCode, '3. WEIGHT CHECK' AS ProcessName, " +
                "      COUNT(DISTINCT prd_serial) AS COUNTS " +
                " FROM PD_FinalHold " +
                " WHERE HoldDate BETWEEN @DateStart AND @DateEnd AND prd_status IN('LINEOUT') AND WeightCheckStatus IN ('NG','NO') ";
            SqlCommand cmdData3 = new SqlCommand();
            cmdData3.CommandText = strData3;
            cmdData3.CommandTimeout = 180;
            cmdData3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData3 = oConDCI.Query(cmdData3);

            DataTable dtDataAll = new DataTable();
            dtDataAll.Columns.Add("ProcessCode", typeof(string));
            dtDataAll.Columns.Add("ProcessName", typeof(string));
            dtDataAll.Columns.Add("COUNTS", typeof(int));

            int data1 = Convert.ToInt32(dtData1.Rows[0]["COUNTS"].ToString());
            int data2 = Convert.ToInt32(dtData2.Rows[0]["COUNTS"].ToString());
            int data3 = Convert.ToInt32(dtData3.Rows[0]["COUNTS"].ToString());

            if (data1 > 0) {
                dtDataAll.Rows.Add(dtData1.Rows[0]["ProcessCode"].ToString(), dtData1.Rows[0]["ProcessName"].ToString(), data1);
            }

            if (data2 > 0)
            {
                dtDataAll.Rows.Add(dtData2.Rows[0]["ProcessCode"].ToString(), dtData2.Rows[0]["ProcessName"].ToString(), data2);
            }

            if (data3 > 0)
            {
                dtDataAll.Rows.Add(dtData3.Rows[0]["ProcessCode"].ToString(), dtData3.Rows[0]["ProcessName"].ToString(), data3);
            }
            
            //---- Sort Data ------
            DataView dv = dtDataAll.DefaultView;
            dv.Sort = "COUNTS DESC";
            dtDataAll = dv.ToTable();




            int _counts = 0;
            try
            {
                _counts = data1 + data2 + data3;
            }
            catch { }


            if (dtDataAll.Rows.Count > 0)
            {
                foreach (DataRow drData in dtDataAll.Rows)
                {
                    CLineOut.ProcessHoldLineOutInfo mData = new CLineOut.ProcessHoldLineOutInfo();
                    mData.dataProcessCode = drData["ProcessCode"].ToString();
                    mData.dataProcessName = drData["ProcessName"].ToString();
                    mData.dataCountLineOut = int.Parse(drData["COUNTS"].ToString());
                    try
                    {
                        double dd1 = Convert.ToDouble(drData["COUNTS"].ToString());
                        double dd2 = Convert.ToDouble(_counts);
                        double dd3 = dd1 / dd2;
                        double dd4 = dd3 * 100;

                        mData.dataRatio = dd4;
                    }
                    catch { mData.dataRatio = 0; }

                    oAryResult.Add(mData);
                }
            }

            #endregion


        }
        //****** OVERALL *******
        else if (PrdModel == "OVERALL")
        {
            #region Other
            DataTable dtData = new DataTable();
            //string strData = "SELECT d.ProcessCode, " +
            //    "   (convert(varchar, m.ProcessOrder) +'. ' + m.ProcessName) AS ProcessName, " +
            //    "   COUNT(DISTINCT h.prd_serial) AS COUNTS " +
            //    " FROM dbDCI.dbo.PD_Hold_Detail_Log AS d " +
            //    " LEFT JOIN dbDCI.dbo.PD_Hold_Mstr AS m ON d.ProcessCode = m.ProcessCode " +
            //    " LEFT JOIN dbDCI.dbo.PD_Hold AS h ON h.HoldNbr = d.HoldNbr " +
            //    " WHERE prd_model IS NOT NULL AND prd_status = 'LINEOUT' " +
            //    "   AND ProcessDate BETWEEN @DateStart AND @DateEnd " + ConditionModel +
            //    " GROUP BY d.ProcessCode,(convert(varchar, m.ProcessOrder) +'. ' + m.ProcessName) " +
            //    " ORDER BY COUNT(DISTINCT h.prd_serial) DESC ";

            string strData = "SELECT dd.ProcessCode, "+
                "   (convert(varchar, m.ProcessOrder) +'. ' + m.ProcessName) AS ProcessName, "+
                "   COUNT(DISTINCT h.prd_serial) AS COUNTS "+
                " FROM dbDCI.dbo.PD_Hold AS h " +
                " OUTER APPLY(SELECT TOP 1 d.ProcessCode FROM dbDCI.dbo.PD_Hold_Detail AS d WHERE d.HoldNbr = h.HoldNbr ORDER BY d.UpdateDate DESC) AS dd " +
                " LEFT JOIN dbDCI.dbo.PD_Hold_Mstr AS m ON dd.ProcessCode = m.ProcessCode " +
                " WHERE prd_model IS NOT NULL AND prd_status = 'LINEOUT' " +
                "     AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel +
                " GROUP BY dd.ProcessCode, (convert(varchar, m.ProcessOrder) + '. ' + m.ProcessName) "+
                " ORDER BY COUNT(DISTINCT h.prd_serial) DESC ";
            
            SqlCommand cmdData = new SqlCommand();
            cmdData.CommandText = strData;
            cmdData.CommandTimeout = 180;
            cmdData.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData = oConDCI.Query(cmdData);



            DataTable dtCount = new DataTable();
            string strCount = "SELECT COUNT(DISTINCT h.prd_serial) AS COUNTS " +
               " FROM dbDCI.dbo.PD_Hold AS h " +
               " OUTER APPLY (SELECT TOP 1 d.ProcessCode FROM dbDCI.dbo.PD_Hold_Detail AS d WHERE d.HoldNbr = h.HoldNbr ORDER BY d.UpdateDate DESC) AS dd " +
               " WHERE prd_model IS NOT NULL AND prd_status = 'LINEOUT' " +
               "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdCount = new SqlCommand();
            cmdCount.CommandText = strCount;
            cmdCount.CommandTimeout = 180;
            cmdCount.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdCount.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtCount = oConDCI.Query(cmdCount);
            int _counts = 0;
            try
            {
                _counts = Convert.ToInt32(dtCount.Rows[0]["COUNTS"].ToString());
            }
            catch { }

            #endregion

            #region 1YC/3
            DataTable dtData1 = new DataTable();
            string strData1 = "SELECT 'FAC301' AS ProcessCode, '1. OIL CHARGING F3' AS ProcessName, " +
                "      COUNT(DISTINCT prd_serial) AS COUNTS " +
                " FROM PD_FinalHold " +
                " WHERE HoldDate BETWEEN @DateStart AND @DateEnd AND prd_status IN('LINEOUT') AND OilingStatus IN ('NG','NO') ";
            SqlCommand cmdData1 = new SqlCommand();
            cmdData1.CommandText = strData1;
            cmdData1.CommandTimeout = 180;
            cmdData1.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData1.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData1 = oConDCI.Query(cmdData1);

            DataTable dtData2 = new DataTable();
            string strData2 = "SELECT 'FAC301' AS ProcessCode, '2. RUNNING TEST F3' AS ProcessName, " +
                "      COUNT(DISTINCT prd_serial) AS COUNTS " +
                " FROM PD_FinalHold " +
                " WHERE HoldDate BETWEEN @DateStart AND @DateEnd AND prd_status IN('LINEOUT') AND RunningTestStatus IN ('NG','NO') ";
            SqlCommand cmdData2 = new SqlCommand();
            cmdData2.CommandText = strData2;
            cmdData2.CommandTimeout = 180;
            cmdData2.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData2.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData2 = oConDCI.Query(cmdData2);

            DataTable dtData3 = new DataTable();
            string strData3 = "SELECT 'FAC301' AS ProcessCode, '3. WEIGHT CHECK F3' AS ProcessName, " +
                "      COUNT(DISTINCT prd_serial) AS COUNTS " +
                " FROM PD_FinalHold " +
                " WHERE HoldDate BETWEEN @DateStart AND @DateEnd AND prd_status IN('LINEOUT') AND WeightCheckStatus IN ('NG','NO') ";
            SqlCommand cmdData3 = new SqlCommand();
            cmdData3.CommandText = strData3;
            cmdData3.CommandTimeout = 180;
            cmdData3.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData3.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData3 = oConDCI.Query(cmdData3);

            DataTable dtDataAll = new DataTable();
            dtDataAll.Columns.Add("ProcessCode", typeof(string));
            dtDataAll.Columns.Add("ProcessName", typeof(string));
            dtDataAll.Columns.Add("COUNTS", typeof(int));

            int data1 = Convert.ToInt32(dtData1.Rows[0]["COUNTS"].ToString());
            int data2 = Convert.ToInt32(dtData2.Rows[0]["COUNTS"].ToString());
            int data3 = Convert.ToInt32(dtData3.Rows[0]["COUNTS"].ToString());

            if (data1 > 0)
            {
                dtDataAll.Rows.Add(dtData1.Rows[0]["ProcessCode"].ToString(), dtData1.Rows[0]["ProcessName"].ToString(), data1);
            }

            if (data2 > 0)
            {
                dtDataAll.Rows.Add(dtData2.Rows[0]["ProcessCode"].ToString(), dtData2.Rows[0]["ProcessName"].ToString(), data2);
            }

            if (data3 > 0)
            {
                dtDataAll.Rows.Add(dtData3.Rows[0]["ProcessCode"].ToString(), dtData3.Rows[0]["ProcessName"].ToString(), data3);
            }

            //---- Sort Data ------
            DataView dv = dtDataAll.DefaultView;
            dv.Sort = "COUNTS DESC";
            dtDataAll = dv.ToTable();
            #endregion

            //---- Merge Data ------
            DataTable dtOverAll = new DataTable();
            dtOverAll = dtData.Copy();
            dtOverAll.Merge(dtDataAll);

            //---- Sort Data ------
            DataView dv2 = dtOverAll.DefaultView;
            dv2.Sort = "COUNTS DESC";
            dtOverAll = dv2.ToTable();

            if (dtOverAll.Rows.Count > 0)
            {
                foreach (DataRow drData in dtOverAll.Rows)
                {
                    CLineOut.ProcessHoldLineOutInfo mData = new CLineOut.ProcessHoldLineOutInfo();
                    mData.dataProcessCode = drData["ProcessCode"].ToString();
                    mData.dataProcessName = drData["ProcessName"].ToString();
                    mData.dataCountLineOut = int.Parse(drData["COUNTS"].ToString());
                    try
                    {
                        double dd1 = Convert.ToDouble(drData["COUNTS"].ToString());
                        double dd2 = Convert.ToDouble(_counts) + Convert.ToDouble(data1) + Convert.ToDouble(data2) + Convert.ToDouble(data3);
                        double dd3 = dd1 / dd2;
                        double dd4 = dd3 * 100;

                        mData.dataRatio = dd4;
                    }
                    catch { mData.dataRatio = 0; }

                    oAryResult.Add(mData);
                }
            }


        }
        //****** ELSE *******
        else
        {
            #region Else
            DataTable dtData = new DataTable();
            //string strData = "SELECT d.ProcessCode, " +
            //    "   (convert(varchar, m.ProcessOrder) +'. ' + m.ProcessName) AS ProcessName, " +
            //    "   COUNT(DISTINCT h.prd_serial) AS COUNTS " +
            //    " FROM dbDCI.dbo.PD_Hold_Detail AS d " +
            //    " LEFT JOIN dbDCI.dbo.PD_Hold_Mstr AS m ON d.ProcessCode = m.ProcessCode " +
            //    " LEFT JOIN dbDCI.dbo.PD_Hold AS h ON h.HoldNbr = d.HoldNbr " +
            //    " WHERE prd_model IS NOT NULL AND prd_status = 'LINEOUT' " +
            //    "    AND ProcessDate BETWEEN @DateStart AND @DateEnd " + ConditionModel +
            //    " GROUP BY d.ProcessCode,(convert(varchar, m.ProcessOrder) +'. ' + m.ProcessName) " +
            //    " ORDER BY COUNT(DISTINCT h.prd_serial) DESC ";

            string strData = "SELECT dd.ProcessCode, " +
                "   (convert(varchar, m.ProcessOrder) +'. ' + m.ProcessName) AS ProcessName, " +
                "   COUNT(DISTINCT h.prd_serial) AS COUNTS " +
                " FROM dbDCI.dbo.PD_Hold AS h " +
                " OUTER APPLY(SELECT TOP 1 d.ProcessCode FROM dbDCI.dbo.PD_Hold_Detail AS d WHERE d.HoldNbr = h.HoldNbr ORDER BY d.UpdateDate DESC) AS dd " +
                " LEFT JOIN dbDCI.dbo.PD_Hold_Mstr AS m ON dd.ProcessCode = m.ProcessCode " +
                " WHERE prd_model IS NOT NULL AND prd_status = 'LINEOUT' " +
                "     AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel +
                " GROUP BY dd.ProcessCode, (convert(varchar, m.ProcessOrder) + '. ' + m.ProcessName) " +
                " ORDER BY COUNT(DISTINCT h.prd_serial) DESC ";

            SqlCommand cmdData = new SqlCommand();
            cmdData.CommandText = strData;
            cmdData.CommandTimeout = 180;
            cmdData.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdData.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtData = oConDCI.Query(cmdData);

            


            DataTable dtCount = new DataTable();
            string strCount = "SELECT COUNT(DISTINCT h.prd_serial) AS COUNTS " +
               " FROM dbDCI.dbo.PD_Hold AS h " +
               " OUTER APPLY (SELECT TOP 1 d.ProcessCode FROM dbDCI.dbo.PD_Hold_Detail AS d WHERE d.HoldNbr = h.HoldNbr ORDER BY d.UpdateDate DESC) AS dd " +
               " WHERE prd_model IS NOT NULL AND prd_status = 'LINEOUT' " +
               "   AND HoldDate BETWEEN @DateStart AND @DateEnd " + ConditionModel;
            SqlCommand cmdCount = new SqlCommand();
            cmdCount.CommandText = strCount;
            cmdCount.CommandTimeout = 180;
            cmdCount.Parameters.Add(new SqlParameter("@DateStart", DataStart));
            cmdCount.Parameters.Add(new SqlParameter("@DateEnd", DataEnd));
            dtCount = oConDCI.Query(cmdCount);
            int _counts = 0;
            try
            {
                _counts = Convert.ToInt32(dtCount.Rows[0]["COUNTS"].ToString());
            }
            catch { }

            #endregion


            if (dtData.Rows.Count > 0)
            {
                foreach (DataRow drData in dtData.Rows)
                {
                    CLineOut.ProcessHoldLineOutInfo mData = new CLineOut.ProcessHoldLineOutInfo();
                    mData.dataProcessCode = drData["ProcessCode"].ToString();
                    mData.dataProcessName = drData["ProcessName"].ToString();
                    mData.dataCountLineOut = int.Parse(drData["COUNTS"].ToString());
                    try
                    {
                        double dd1 = Convert.ToDouble(drData["COUNTS"].ToString());
                        double dd2 = Convert.ToDouble(_counts);
                        double dd3 = dd1 / dd2;
                        double dd4 = dd3 * 100;

                        mData.dataRatio = dd4;
                    }
                    catch { mData.dataRatio = 0; }

                    oAryResult.Add(mData);
                }
            }
        } // end if


            return oAryResult;
    }


    public List<CLineOut.HoldLineOutInfo> GetLineOutData(string PrdModel, string pdataDate) {
        List<CLineOut.HoldLineOutInfo> AryData = new List<HoldLineOutInfo>();
        foreach (string _Month in ArryPeriod)
        {
            string PeriodData = _Month;
            DateTime dataStart = new DateTime();
            DateTime dataEnd = new DateTime();
            DateTime dataDate = Convert.ToDateTime(pdataDate);
            #region Start / End Date
            if (dataDate.Month >= 4)
            {
                switch (_Month)
                {
                    case "APR":
                        dataStart = new DateTime(dataDate.Year, 4, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 4, DateTime.DaysInMonth(dataDate.Year, 4), 23, 59, 59);
                        break;
                    case "MAY":
                        dataStart = new DateTime(dataDate.Year, 5, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 5, DateTime.DaysInMonth(dataDate.Year, 5), 23, 59, 59);
                        break;
                    case "JUN":
                        dataStart = new DateTime(dataDate.Year, 6, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 6, DateTime.DaysInMonth(dataDate.Year, 6), 23, 59, 59);
                        break;
                    case "JUL":
                        dataStart = new DateTime(dataDate.Year, 7, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 7, DateTime.DaysInMonth(dataDate.Year, 7), 23, 59, 59);
                        break;
                    case "AUG":
                        dataStart = new DateTime(dataDate.Year, 8, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 8, DateTime.DaysInMonth(dataDate.Year, 8), 23, 59, 59);
                        break;
                    case "SEP":
                        dataStart = new DateTime(dataDate.Year, 9, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 9, DateTime.DaysInMonth(dataDate.Year, 9), 23, 59, 59);
                        break;
                    case "OCT":
                        dataStart = new DateTime(dataDate.Year, 10, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 10, DateTime.DaysInMonth(dataDate.Year, 10), 23, 59, 59);
                        break;
                    case "NOV":
                        dataStart = new DateTime(dataDate.Year, 11, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 11, DateTime.DaysInMonth(dataDate.Year, 11), 23, 59, 59);
                        break;
                    case "DEC":
                        dataStart = new DateTime(dataDate.Year, 12, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 12, DateTime.DaysInMonth(dataDate.Year, 12), 23, 59, 59);
                        break;
                    case "JAN":
                        dataStart = new DateTime(dataDate.AddYears(1).Year, 1, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(1).Year, 1, DateTime.DaysInMonth(dataDate.AddYears(1).Year, 1), 23, 59, 59);
                        break;
                    case "FEB":
                        dataStart = new DateTime(dataDate.AddYears(1).Year, 2, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(1).Year, 2, DateTime.DaysInMonth(dataDate.AddYears(1).Year, 2), 23, 59, 59);
                        break;
                    case "MAR":
                        dataStart = new DateTime(dataDate.AddYears(1).Year, 3, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(1).Year, 3, DateTime.DaysInMonth(dataDate.AddYears(1).Year, 3), 23, 59, 59);
                        break;
                }

                if (_Month == "LastYear")
                {
                    PeriodData = dataDate.AddYears(-1).Year.ToString();
                    dataStart = new DateTime(dataDate.AddYears(-1).Year, 4, 1, 0, 0, 1);
                    dataEnd = new DateTime(dataDate.Year, 4, 1, 0, 0, 1);
                }
            }
            else {
                switch (_Month)
                {
                    case "APR":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 4, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 4, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 4), 23, 59, 59);
                        break;
                    case "MAY":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 5, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 5, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 5), 23, 59, 59);
                        break;
                    case "JUN":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 6, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 6, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 6), 23, 59, 59);
                        break;
                    case "JUL":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 7, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 7, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 7), 23, 59, 59);
                        break;
                    case "AUG":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 8, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 8, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 8), 23, 59, 59);
                        break;
                    case "SEP":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 9, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 9, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 9), 23, 59, 59);
                        break;
                    case "OCT":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 10, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 10, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 10), 23, 59, 59);
                        break;
                    case "NOV":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 11, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 11, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 11), 23, 59, 59);
                        break;
                    case "DEC":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 12, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 12, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 12), 23, 59, 59);
                        break;
                    case "JAN":
                        dataStart = new DateTime(dataDate.Year, 1, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 1, DateTime.DaysInMonth(dataDate.Year, 1), 23, 59, 59);
                        break;
                    case "FEB":
                        dataStart = new DateTime(dataDate.Year, 2, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 2, DateTime.DaysInMonth(dataDate.Year, 2), 23, 59, 59);
                        break;
                    case "MAR":
                        dataStart = new DateTime(dataDate.Year, 3, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 3, DateTime.DaysInMonth(dataDate.Year, 3), 23, 59, 59);
                        break;
                }

                if (_Month == "LastYear")
                {
                    PeriodData = dataDate.AddYears(-2).Year.ToString();
                    dataStart = new DateTime(dataDate.AddYears(-2).Year, 4, 1, 0, 0, 1);
                    dataEnd = new DateTime(dataDate.AddYears(-1).Year, 4, 1, 0, 0, 1);
                }
            }
            #endregion


            string ConditionModel = "";
            switch (PrdModel)
            {
                case "1YC": ConditionModel = " AND prd_model LIKE '1YC%' "; break;
                case "2YC": ConditionModel = " AND prd_model LIKE '2YC%' "; break;
                case "SCROLL": ConditionModel = " AND prd_model LIKE 'J%' "; break;
                case "ODM": ConditionModel = " AND (prd_model LIKE '1P%' OR prd_model LIKE '2P%')  "; break;
            }



            if (PrdModel == "1YC/3")
            {
                DataTable dtHold = new DataTable();
                string strCountHold = "SELECT COUNT(prd_serial) AS COUNTS FROM PD_FinalHold WHERE prd_status IN ('HOLD','REQUEST') AND HoldDate BETWEEN @StartDate AND @EndDate ";
                string strCountLineOut = "SELECT COUNT(prd_serial) AS COUNTS FROM PD_FinalHold WHERE prd_status = 'LINEOUT' AND HoldDate BETWEEN @StartDate AND @EndDate ";
                SqlCommand cmdHold = new SqlCommand();
                cmdHold.CommandText = strCountHold;
                cmdHold.CommandTimeout = 180;
                cmdHold.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                cmdHold.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                dtHold = oConDCI.Query(cmdHold);

                DataTable dtLineOut = new DataTable();
                SqlCommand cmdLine = new SqlCommand();
                cmdLine.CommandText = strCountLineOut;
                cmdLine.CommandTimeout = 180;
                cmdLine.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                cmdLine.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                dtLineOut = oConDCI.Query(cmdLine);

                if (_Month == "LastYear")
                {
                    CLineOut.HoldLineOutInfo mData = new HoldLineOutInfo();
                    try
                    {
                        mData.dataCountHold = Convert.ToInt32(Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()) / 12);
                    }
                    catch { mData.dataCountHold = 0; }
                    try
                    {
                        mData.dataCountLineOut = Convert.ToInt32(Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()) / 12);
                    }
                    catch { mData.dataCountLineOut = 0; }
                    mData.dataPeriod = PeriodData;
                    AryData.Add(mData);
                }
                else
                {
                    CLineOut.HoldLineOutInfo mData = new HoldLineOutInfo();
                    try
                    {
                        mData.dataCountHold = Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString());
                    }
                    catch { mData.dataCountHold = 0; }
                    try
                    {
                        mData.dataCountLineOut = Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString());
                    }
                    catch { mData.dataCountLineOut = 0; }
                    mData.dataPeriod = PeriodData;
                    AryData.Add(mData);
                }

            }
            else {
                DataTable dtHold = new DataTable();
                string strCountHold = "SELECT COUNT(prd_serial) AS COUNTS FROM PD_Hold WHERE prd_status IN ('HOLD','REQUEST') AND HoldDate BETWEEN @StartDate AND @EndDate " + ConditionModel;
                string strCountLineOut = "SELECT COUNT(prd_serial) AS COUNTS FROM PD_Hold WHERE prd_status = 'LINEOUT' AND HoldDate BETWEEN @StartDate AND @EndDate " + ConditionModel;
                SqlCommand cmdHold = new SqlCommand();
                cmdHold.CommandText = strCountHold;
                cmdHold.CommandTimeout = 180;
                cmdHold.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                cmdHold.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                dtHold = oConDCI.Query(cmdHold);

                DataTable dtLineOut = new DataTable();
                SqlCommand cmdLine = new SqlCommand();
                cmdLine.CommandText = strCountLineOut;
                cmdLine.CommandTimeout = 180;
                cmdLine.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                cmdLine.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                dtLineOut = oConDCI.Query(cmdLine);

                if (_Month == "LastYear")
                {
                    CLineOut.HoldLineOutInfo mData = new HoldLineOutInfo();
                    try
                    {
                        mData.dataCountHold = Convert.ToInt32(Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()) / 12);
                    }
                    catch { mData.dataCountHold = 0; }
                    try
                    {
                        mData.dataCountLineOut = Convert.ToInt32(Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()) / 12);
                    }
                    catch { mData.dataCountLineOut = 0; }
                    mData.dataPeriod = PeriodData;
                    AryData.Add(mData);
                }
                else
                {
                    CLineOut.HoldLineOutInfo mData = new HoldLineOutInfo();
                    try
                    {
                        mData.dataCountHold = Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString());
                    }
                    catch { mData.dataCountHold = 0; }
                    try
                    {
                        mData.dataCountLineOut = Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString());
                    }
                    catch { mData.dataCountLineOut = 0; }
                    mData.dataPeriod = PeriodData;
                    AryData.Add(mData);
                }
            }

            
            
        }

        return AryData;
    }




    public List<CLineOut.HoldLineOutAllInfo> GetHoldLineOutAll(string pdataDate) {
        string[] AryFactory = new string[] { "FAC1","FAC2","FAC3","ODM" };
        List<CLineOut.HoldLineOutAllInfo> AryData = new List<HoldLineOutAllInfo>();
        foreach (string _Month in ArryPeriod)
        {
            CLineOut.HoldLineOutAllInfo mData = new HoldLineOutAllInfo();
            string PeriodData = _Month;
            DateTime dataStart = new DateTime();
            DateTime dataEnd = new DateTime();
            DateTime dataDate = Convert.ToDateTime(pdataDate);
            #region Start / End Date
            if (dataDate.Month >= 4)
            {
                switch (_Month)
                {
                    case "APR":
                        dataStart = new DateTime(dataDate.Year, 4, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 4, DateTime.DaysInMonth(dataDate.Year, 4), 23, 59, 59);
                        break;
                    case "MAY":
                        dataStart = new DateTime(dataDate.Year, 5, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 5, DateTime.DaysInMonth(dataDate.Year, 5), 23, 59, 59);
                        break;
                    case "JUN":
                        dataStart = new DateTime(dataDate.Year, 6, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 6, DateTime.DaysInMonth(dataDate.Year, 6), 23, 59, 59);
                        break;
                    case "JUL":
                        dataStart = new DateTime(dataDate.Year, 7, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 7, DateTime.DaysInMonth(dataDate.Year, 7), 23, 59, 59);
                        break;
                    case "AUG":
                        dataStart = new DateTime(dataDate.Year, 8, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 8, DateTime.DaysInMonth(dataDate.Year, 8), 23, 59, 59);
                        break;
                    case "SEP":
                        dataStart = new DateTime(dataDate.Year, 9, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 9, DateTime.DaysInMonth(dataDate.Year, 9), 23, 59, 59);
                        break;
                    case "OCT":
                        dataStart = new DateTime(dataDate.Year, 10, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 10, DateTime.DaysInMonth(dataDate.Year, 10), 23, 59, 59);
                        break;
                    case "NOV":
                        dataStart = new DateTime(dataDate.Year, 11, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 11, DateTime.DaysInMonth(dataDate.Year, 11), 23, 59, 59);
                        break;
                    case "DEC":
                        dataStart = new DateTime(dataDate.Year, 12, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 12, DateTime.DaysInMonth(dataDate.Year, 12), 23, 59, 59);
                        break;
                    case "JAN":
                        dataStart = new DateTime(dataDate.AddYears(1).Year, 1, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(1).Year, 1, DateTime.DaysInMonth(dataDate.AddYears(1).Year, 1), 23, 59, 59);
                        break;
                    case "FEB":
                        dataStart = new DateTime(dataDate.AddYears(1).Year, 2, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(1).Year, 2, DateTime.DaysInMonth(dataDate.AddYears(1).Year, 2), 23, 59, 59);
                        break;
                    case "MAR":
                        dataStart = new DateTime(dataDate.AddYears(1).Year, 3, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(1).Year, 3, DateTime.DaysInMonth(dataDate.AddYears(1).Year, 3), 23, 59, 59);
                        break;
                }

                if (_Month == "LastYear")
                {
                    PeriodData = dataDate.AddYears(-1).Year.ToString();
                    dataStart = new DateTime(dataDate.AddYears(-1).Year, 4, 1, 0, 0, 1);
                    dataEnd = new DateTime(dataDate.Year, 4, 1, 0, 0, 1);
                }
            }
            else
            {
                switch (_Month)
                {
                    case "APR":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 4, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 4, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 4), 23, 59, 59);
                        break;
                    case "MAY":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 5, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 5, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 5), 23, 59, 59);
                        break;
                    case "JUN":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 6, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 6, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 6), 23, 59, 59);
                        break;
                    case "JUL":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 7, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 7, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 7), 23, 59, 59);
                        break;
                    case "AUG":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 8, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 8, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 8), 23, 59, 59);
                        break;
                    case "SEP":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 9, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 9, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 9), 23, 59, 59);
                        break;
                    case "OCT":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 10, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 10, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 10), 23, 59, 59);
                        break;
                    case "NOV":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 11, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 11, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 11), 23, 59, 59);
                        break;
                    case "DEC":
                        dataStart = new DateTime(dataDate.AddYears(-1).Year, 12, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.AddYears(-1).Year, 12, DateTime.DaysInMonth(dataDate.AddYears(-1).Year, 12), 23, 59, 59);
                        break;
                    case "JAN":
                        dataStart = new DateTime(dataDate.Year, 1, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 1, DateTime.DaysInMonth(dataDate.Year, 1), 23, 59, 59);
                        break;
                    case "FEB":
                        dataStart = new DateTime(dataDate.Year, 2, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 2, DateTime.DaysInMonth(dataDate.Year, 2), 23, 59, 59);
                        break;
                    case "MAR":
                        dataStart = new DateTime(dataDate.Year, 3, 1, 0, 0, 1);
                        dataEnd = new DateTime(dataDate.Year, 3, DateTime.DaysInMonth(dataDate.Year, 3), 23, 59, 59);
                        break;
                }

                if (_Month == "LastYear")
                {
                    PeriodData = dataDate.AddYears(-2).Year.ToString();
                    dataStart = new DateTime(dataDate.AddYears(-2).Year, 4, 1, 0, 0, 1);
                    dataEnd = new DateTime(dataDate.AddYears(-1).Year, 4, 1, 0, 0, 1);
                }
            }
            #endregion


            // loop data
            foreach (string oFactory in AryFactory) {

                //********************************************
                //********* CHECK CONDITION FACTORY **********
                //********************************************
                if (oFactory == "FAC1" || oFactory == "FAC2" || oFactory == "ODM") {
                    string ConditionModel = "";
                    switch (oFactory)
                    {
                        case "FAC1": ConditionModel = " AND prd_model LIKE '1YC%' "; break;
                        case "FAC2": ConditionModel = " AND (prd_model LIKE '2YC%' OR prd_model LIKE 'J%') "; break;
                        case "ODM": ConditionModel = " AND (prd_model LIKE '1P%' OR prd_model LIKE '2P%')  "; break;
                    }

                    DataTable dtHold = new DataTable();
                    string strCountHold = "SELECT COUNT(prd_serial) AS COUNTS FROM PD_Hold WHERE prd_status IN ('HOLD','REQUEST') AND HoldDate BETWEEN @StartDate AND @EndDate " + ConditionModel;
                    string strCountLineOut = "SELECT COUNT(prd_serial) AS COUNTS FROM PD_Hold WHERE prd_status = 'LINEOUT' AND HoldDate BETWEEN @StartDate AND @EndDate " + ConditionModel;
                    SqlCommand cmdHold = new SqlCommand();
                    cmdHold.CommandText = strCountHold;
                    cmdHold.CommandTimeout = 180;
                    cmdHold.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                    cmdHold.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                    dtHold = oConDCI.Query(cmdHold);

                    DataTable dtLineOut = new DataTable();
                    SqlCommand cmdLine = new SqlCommand();
                    cmdLine.CommandText = strCountLineOut;
                    cmdLine.CommandTimeout = 180;
                    cmdLine.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                    cmdLine.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                    dtLineOut = oConDCI.Query(cmdLine);

                    //***** CHECK LAST YEAR ******
                    if (_Month == "LastYear")
                    {
                        switch (oFactory)
                        {
                            case "FAC1":
                                try { mData.dataFac1Hold = Convert.ToInt32(Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataFac1Hold = 0; }
                                try { mData.dataFac1LineOut = Convert.ToInt32(Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataFac1LineOut = 0; }
                                break;
                            case "FAC2":
                                try { mData.dataFac2Hold = Convert.ToInt32(Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataFac2Hold = 0; }
                                try { mData.dataFac2LineOut = Convert.ToInt32(Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataFac2LineOut = 0; }
                                break;
                            case "ODM":
                                try { mData.dataODMHold = Convert.ToInt32(Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataODMHold = 0; }
                                try { mData.dataODMLineOut = Convert.ToInt32(Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataODMLineOut = 0; }
                                break;
                        }
                    }
                    else
                    {
                        switch (oFactory)
                        {
                            case "FAC1":
                                try { mData.dataFac1Hold = Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()); } catch { mData.dataFac1Hold = 0; }
                                try { mData.dataFac1LineOut = Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()); } catch { mData.dataFac1LineOut = 0; }
                                break;
                            case "FAC2":
                                try { mData.dataFac2Hold = Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()); } catch { mData.dataFac2Hold = 0; }
                                try { mData.dataFac2LineOut = Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()); } catch { mData.dataFac2LineOut = 0; }
                                break;
                            case "ODM":
                                try { mData.dataODMHold = Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()); } catch { mData.dataODMHold = 0; }
                                try { mData.dataODMLineOut = Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()); } catch { mData.dataODMLineOut = 0; }
                                break;
                        }
                    }

                }
                //********* CHECK CONDITION FACTORY **********
                else if (oFactory == "FAC3") {
                    DataTable dtHold = new DataTable();
                    string strCountHold = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS FROM PD_FinalHold WHERE prd_status IN ('HOLD','REQUEST') AND HoldDate BETWEEN @StartDate AND @EndDate ";
                    string strCountLineOut = "SELECT COUNT(DISTINCT prd_serial) AS COUNTS FROM PD_FinalHold WHERE prd_status = 'LINEOUT' AND HoldDate BETWEEN @StartDate AND @EndDate ";
                    SqlCommand cmdHold = new SqlCommand();
                    cmdHold.CommandText = strCountHold;
                    cmdHold.CommandTimeout = 180;
                    cmdHold.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                    cmdHold.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                    dtHold = oConDCI.Query(cmdHold);

                    DataTable dtLineOut = new DataTable();
                    SqlCommand cmdLine = new SqlCommand();
                    cmdLine.CommandText = strCountLineOut;
                    cmdLine.CommandTimeout = 180;
                    cmdLine.Parameters.Add(new SqlParameter("@StartDate", dataStart));
                    cmdLine.Parameters.Add(new SqlParameter("@EndDate", dataEnd));
                    dtLineOut = oConDCI.Query(cmdLine);

                    if (_Month == "LastYear")
                    {
                        try { mData.dataFac3Hold = Convert.ToInt32(Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataFac3Hold = 0; }
                        try { mData.dataFac3LineOut = Convert.ToInt32(Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()) / 12); } catch { mData.dataFac3LineOut = 0; }
                    }
                    else {
                        try { mData.dataFac3Hold = Convert.ToInt32(dtHold.Rows[0]["COUNTS"].ToString()); } catch { mData.dataFac3Hold = 0; }
                        try { mData.dataFac3LineOut = Convert.ToInt32(dtLineOut.Rows[0]["COUNTS"].ToString()); } catch { mData.dataFac3LineOut = 0; }
                    }
                }
                //********************************************
                //********* CHECK CONDITION FACTORY **********
                //********************************************
                
            }//End Foreach Factory


            mData.dataPeriod = PeriodData;
            AryData.Add(mData);
        } // End Foreach Period

        return AryData;
    }









    public class HoldLineOutAllInfo
    {
        public int? dataFac1Hold { get; set; }
        public int? dataFac2Hold { get; set; }
        public int? dataFac3Hold { get; set; }
        public int? dataODMHold { get; set; }
        public int? dataFac1LineOut { get; set; }
        public int? dataFac2LineOut { get; set; }
        public int? dataFac3LineOut { get; set; }
        public int? dataODMLineOut { get; set; }
        public string dataPeriod { get; set; }

        public HoldLineOutAllInfo() {
            dataFac1Hold = 0;
            dataFac2Hold = 0;
            dataFac3Hold = 0;
            dataODMHold = 0;
            dataFac1LineOut = 0;
            dataFac2LineOut = 0;
            dataFac3LineOut = 0;
            dataODMLineOut = 0;
            dataPeriod = "";
        }
    }
    
    public class HoldLineOutInfo
    {
        public int? dataCountHold { get; set; }
        public int? dataCountLineOut { get; set; }
        public string dataPeriod { get; set; }

        public HoldLineOutInfo()
        {
            dataCountHold = 0;
            dataCountLineOut = 0;
            dataPeriod = "";
        }
    }
    
    public class ProcessHoldLineOutInfo
    {
        public int? dataCountLineOut { get; set; }
        public string dataProcessCode { get; set; }
        public string dataProcessName { get; set; }
        public double dataRatio { get; set; }

        public ProcessHoldLineOutInfo()
        {
            dataCountLineOut = 0;
            dataProcessCode = "";
            dataProcessName = "";
            dataRatio = 0;
        }
    }

    public class LineOutChartInfo
    {
        public int? dataCountLineOut { get; set; }
        public int? dataCountHold { get; set; }
        public string dataModelCode { get; set; }
        public string dataModel { get; set; }
        public double dataRatio { get; set; }

        public LineOutChartInfo()
        {
            dataCountLineOut = 0;
            dataCountHold = 0;
            dataModelCode = "";
            dataModel = "";
            dataRatio = 0;
        }
    }



}