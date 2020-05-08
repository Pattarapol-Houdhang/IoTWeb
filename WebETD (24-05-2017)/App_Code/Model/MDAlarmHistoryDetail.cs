using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDMechaNG
/// </summary>
public class MDAlarmHistoryDetail
{
    public class CMDAlarmHistoryDetail{
        public string MCName { get; set; }
        public string AlarmDetail { get; set; }
        public int Qty { get; set; }
        public string SDate { get; set; }
        public string EDate { get; set; }
    }
    public List<CMDAlarmHistoryDetail> ListOfAlarm;
    public MDAlarmHistoryDetail()
    {
        ListOfAlarm = new List<CMDAlarmHistoryDetail>();
    }
    
}