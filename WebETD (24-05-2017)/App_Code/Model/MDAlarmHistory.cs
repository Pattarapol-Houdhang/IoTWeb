using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDMechaNG
/// </summary>
public class MDAlarmHistory
{
    public class CMAlarmHistory{
        public string MCName { get; set; }
        public string StampDate { get; set; }
        public string Shift { get; set; }
        public int Qty { get; set; }
        public int Timediff { get; set; }

    }
    public class CMMCName
    {
        public string MCname { get; set; }

    }
    public List<CMAlarmHistory> ListOfAlarm;
    public List<CMMCName> ListOfMC;
    public MDAlarmHistory()
    {
        ListOfAlarm = new List<CMAlarmHistory>();
        ListOfMC = new List<CMMCName>();
    }
    
}