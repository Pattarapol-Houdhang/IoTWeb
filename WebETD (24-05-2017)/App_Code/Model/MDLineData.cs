using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDLineData
/// </summary>
public class MDLineData
{
    public class CMDLineData
    {
        public int ld_id { get; set; }
        public string ld_linename { get; set; }
        public int FactoryID { get; set; }
        public string FactoryName { get; set; }
        public int ld_order { get; set; }
        public string ld_createby { get; set; }
        public string ld_createdate { get; set; }
        public string ld_updateby { get; set; }
        public string ld_updatedate { get; set; }
        public int MachineTotal { get; set; }

    }

    public List<CMDLineData> ListOfLine;

    public MDLineData()
    {
        ListOfLine = new List<CMDLineData>();
    }

}