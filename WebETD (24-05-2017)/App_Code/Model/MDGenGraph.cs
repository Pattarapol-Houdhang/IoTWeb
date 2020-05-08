using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDGenGraph
/// </summary>
public class MDGenGraph
{
    public class CMDGenGraph
    {
        public string Date { get; set; }
        public int QtyOK { get; set; }
        public int QtyNG { get; set; }
        public string DataDateStart { get; set; }
        public string DataDateEnd { get; set; }
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string ModelCode { get; set; }        
        public string ModelName { get; set; }
        
    }
    public List<CMDGenGraph> ListOfData;
    public MDGenGraph()
    {
        ListOfData = new List<CMDGenGraph>();
    }
}