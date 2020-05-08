using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDMachine
/// </summary>
public class MDMachine
{
    public class CMDMachine
    {
        public int mc_id { get; set; }
        public string mc_code { get; set; }
        public string mc_name { get; set; }
        public string mc_process { get; set; }
        public int ld_id { get; set; }
        public string ld_linename { get; set; }
        public string FactoryName { get; set; }
        public string mc_createby { get; set; }
        public string mc_createdate { get; set; }
        public string mc_updateby { get; set; }
        public string mc_updatedate { get; set; }
        public int QtyOK { get; set; }
        public int QtyNG { get; set; }
    }

    public List<CMDMachine> ListOfmachine;
    public MDMachine()
    {
        ListOfmachine = new List<CMDMachine>();
    }
}