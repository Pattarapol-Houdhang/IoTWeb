using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RunNumberService
/// </summary>
public class RunNumberService
{
	public RunNumberService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    docrunnbrTableAdapter runNbrTba = new docrunnbrTableAdapter();
    public string NextId(string key)
    {
        RunningNumber num = LoadUnique(key);
        runNbrTba.UpdateNextId(num.NextId + 1, DateTime.Now, key);
        return num.ToString(true);
    }

    public RunningNumber LoadUnique(string key)
    {
        try
        {
            RunningNumber item = new RunningNumber();
            DataTable tb = runNbrTba.GetDataByKey(key);
            if (tb.Rows.Count != 0)
            {
                item = (RunningNumber)QueryForObject(tb.Rows[0], typeof(RunningNumber));
                return item;

            }
            return null;
        }
        catch
        {
            return null;

        }
    }
    public object QueryForObject(DataRow row, Type t)
    {
        if (t == typeof(RunningNumber))
        {
            RunningNumber item = new RunningNumber();


            try
            {
                item.Key = Convert.ToString(row["DocKey"]);
            }
            catch { }
            try
            {
                item.Prefix = Convert.ToString(row["DocPrefix"]);
            }
            catch { }
            try
            {
                item.LenYearPrefix = Convert.ToInt32(row["YearNbrPrefix"]);
            }
            catch { }
            try
            {
                item.LenMonthPrefix = Convert.ToInt32(row["MonthNbrPrefix"]);
            }
            catch { }
            try
            {
                item.LenDayPrefix = Convert.ToInt32(row["DayNbrPrefix"]);
            }
            catch { }
            try
            {
                item.LenRunId = Convert.ToInt32(row["FormatNbr"]);
            }
            catch { }
            try
            {
                item.NextId = Convert.ToInt32(row["NextId"]);
            }
            catch { }
            try
            {
                item.ActiveDate = Convert.ToDateTime(row["ActiveDate"]);
            }
            catch { }
            try
            {
                item.Date = Convert.ToDateTime(row["CurDate"]);
            }
            catch { }
            try
            {
                item.Remark = Convert.ToString(row["Remark"]);
            }
            catch { }
            try
            {
                item.ResetOption = Convert.ToString(row["ResetOption"]);
            }
            catch { }
            return item;
        }
        else
        {
            return null;
        }
    }
}