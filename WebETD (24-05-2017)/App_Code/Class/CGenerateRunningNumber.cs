using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CGenerateRunningNumber
/// </summary>
public class CGenerateRunningNumber
{
    ConnectDB oConn = new ConnectDB();

    /// <summary>
    /// Get RunningNumber Format = PF2017041300001
    /// </summary>
    /// <param name="typeConfig"></param>
    /// <returns></returns>
    public string GetRunningNumber_FormatWithDate(CGeneral.TypeConfig typeConfig)
    {
        CheckCurrentDate(typeConfig);
        string RunningNumber = "";
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT [TypeConfig],[prefix],[year],[month],[day],[RunningNumber],[DigitLength] ");
        sbd.AppendLine("FROM [ConfigRunningNumber] WHERE TypeConfig='" + typeConfig + "'");
        dTable = oConn.Query(sbd.ToString());

        if (dTable.Rows.Count > 0)
        {
            string prefix = dTable.Rows[0]["prefix"].ToString();
            string year = dTable.Rows[0]["year"].ToString();
            string month = dTable.Rows[0]["month"].ToString();
            string day = dTable.Rows[0]["day"].ToString();
            int running = Convert.ToInt32(dTable.Rows[0]["RunningNumber"]);
            int _digit = Convert.ToInt32(dTable.Rows[0]["DigitLength"]);
            string digit = "";
            for (int i = 0; i < _digit; i++)
            {
                digit += "0";
            }
            running++;
            RunningNumber = prefix + year + Convert.ToInt32(month).ToString("00") + Convert.ToInt32(day).ToString("00") + running.ToString(digit);
            UpdateRunningNumber(typeConfig);
        }

        return RunningNumber;
    }

    public string GetRunningNumber(CGeneral.TypeConfig typeConfig)
    {
        CheckCurrentDate(typeConfig);
        string RunningNumber = "";
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT [TypeConfig],[prefix],[year],[month],[day],[RunningNumber],[DigitLength] ");
        sbd.AppendLine("FROM [ConfigRunningNumber] WHERE TypeConfig='" + typeConfig + "'");
        dTable = oConn.Query(sbd.ToString());

        if (dTable.Rows.Count > 0)
        {
            string prefix = dTable.Rows[0]["prefix"].ToString();
            string year = dTable.Rows[0]["year"].ToString();
            string month = dTable.Rows[0]["month"].ToString();
            string day = dTable.Rows[0]["day"].ToString();
            int running = Convert.ToInt32(dTable.Rows[0]["RunningNumber"]);
            int _digit = Convert.ToInt32(dTable.Rows[0]["DigitLength"]);
            string digit = "";
            for (int i = 0; i < _digit; i++)
            {
                digit += "0";
            }
            running++;
            RunningNumber = prefix + year.Substring(2,2) + running.ToString(digit);
            UpdateRunningNumber(typeConfig);
        }

        return RunningNumber;
    }


    private void CheckCurrentDate(CGeneral.TypeConfig typeConfig)
    {
        StringBuilder sbd = new StringBuilder();        
        DataTable dTable = new DataTable();
        sbd = new StringBuilder();
        sbd.AppendLine("SELECT [TypeConfig],[prefix],[year],[month],[day],[RunningNumber],[DigitLength] ");
        sbd.AppendLine("FROM [ConfigRunningNumber] WHERE TypeConfig='" + typeConfig + "'");
        dTable = oConn.Query(sbd.ToString());

        bool resetRunning = false;
        if(dTable.Rows.Count > 0)
        {
            if (dTable.Rows[0]["year"].ToString() != DateTime.Now.Year.ToString())
            {
                resetRunning = true;
            }
            //if (dTable.Rows[0]["month"].ToString() != DateTime.Now.Month.ToString())
            //{
            //    resetRunning = true;
            //}
            //if (dTable.Rows[0]["day"].ToString() != DateTime.Now.Day.ToString())
            //{
            //    resetRunning = true;
            //}
        }

        if (resetRunning)
        {
            sbd = new StringBuilder();
            sbd.AppendLine("UPDATE ConfigRunningNumber SET RunningNumber=0,year='"+ DateTime.Now.Year.ToString() + "'");
            sbd.AppendLine(",month='"+ DateTime.Now.Month.ToString() + "'");
            sbd.AppendLine(",day='" + DateTime.Now.Day.ToString() + "'");
            sbd.AppendLine("WHERE TypeConfig='" + typeConfig + "'");
            oConn.ExecuteCommand(sbd.ToString());
        }
        
    }

    private void UpdateRunningNumber(CGeneral.TypeConfig typeConfig)
    {
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("UPDATE ConfigRunningNumber SET RunningNumber+=1 WHERE TypeConfig='" + typeConfig + "'");
        oConn.ExecuteCommand(sbd.ToString());
    }


}