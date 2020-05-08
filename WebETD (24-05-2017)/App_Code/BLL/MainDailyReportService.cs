using DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MainDailyReportService
/// </summary>
public class MainDailyReportService
{
    MainDailyReportTableAdapter mainTba;
	public MainDailyReportService()
	{
        mainTba = new MainDailyReportTableAdapter();
	}

    public DataTable GetDailyProduceModel(DateTime startDate, DateTime endDate, string conStr)
    {
        mainTba.Connection.ConnectionString = conStr;
        DataTable dt = mainTba.GetData(startDate, endDate);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }


}