using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PdLineProductInfo
/// </summary>
public class PdLineProductInfo
{
    public PdLineProductInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private DateTime dataDate;
    private string shift = "";
    private string lineCode = "";
    private string lineName = "";
    private string boardId = "";
    private decimal planDay = 0;
    private decimal actualDay = 0;
    private decimal diffDay = 0;
    private decimal totalNgDay = 0;
    private decimal planNight = 0;
    private decimal actualNight = 0;
    private decimal diffNight = 0;
    private decimal totalNgNight = 0;

    public DateTime DataDate
    {
        get
        {
            return dataDate;
        }

        set
        {
            dataDate = value;
        }
    }

    public string Shift
    {
        get
        {
            return shift;
        }

        set
        {
            shift = value;
        }
    }

    public string LineCode
    {
        get
        {
            return lineCode;
        }

        set
        {
            lineCode = value;
        }
    }

    public string LineName
    {
        get
        {
            return lineName;
        }

        set
        {
            lineName = value;
        }
    }

    public string BoardId
    {
        get
        {
            return boardId;
        }

        set
        {
            boardId = value;
        }
    }

    public decimal PlanDay
    {
        get
        {
            return planDay;
        }

        set
        {
            planDay = value;
        }
    }

    public decimal ActualDay
    {
        get
        {
            return actualDay;
        }

        set
        {
            actualDay = value;
        }
    }

    public decimal DiffDay
    {
        get
        {
            return diffDay;
        }

        set
        {
            diffDay = value;
        }
    }

    public decimal TotalNgDay
    {
        get
        {
            return totalNgDay;
        }

        set
        {
            totalNgDay = value;
        }
    }

    public decimal PlanNight
    {
        get
        {
            return planNight;
        }

        set
        {
            planNight = value;
        }
    }

    public decimal ActualNight
    {
        get
        {
            return actualNight;
        }

        set
        {
            actualNight = value;
        }
    }

    public decimal DiffNight
    {
        get
        {
            return diffNight;
        }

        set
        {
            diffNight = value;
        }
    }

    public decimal TotalNgNight
    {
        get
        {
            return totalNgNight;
        }

        set
        {
            totalNgNight = value;
        }
    }
}

public class AndonDataLog
{
    private string boardId = "";
    private decimal dailyPlan = 0;
    private decimal actual = 0;
    private decimal diff = 0;

    public string BoardId
    {
        get
        {
            return boardId;
        }

        set
        {
            boardId = value;
        }
    }

    public decimal DailyPlan
    {
        get
        {
            return dailyPlan;
        }

        set
        {
            dailyPlan = value;
        }
    }

    public decimal Actual
    {
        get
        {
            return actual;
        }

        set
        {
            actual = value;
        }
    }

    public decimal Diff
    {
        get
        {
            return diff;
        }

        set
        {
            diff = value;
        }
    }
}