using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDLogData
/// </summary>
public class MDLogData
{
    public class CMDLogData
    {
        public string LogID { get; set; }
        public string username { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public string Action { get; set; }
        public string PageUrl { get; set; }
        public string LogDate { get; set; }
    }
    public List<CMDLogData> ListOfLog;
    public MDLogData()
    {
        ListOfLog = new List<CMDLogData>();
    }
}