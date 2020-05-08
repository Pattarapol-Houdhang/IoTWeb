using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDMachineHeader
/// </summary>
public class MDMachineHeader
{
    public class CMDMachineHeader
    {
        public string mhi_id { get; set; }
        public string mc_code { get; set; }
        public string mc_name { get; set; }
        public string index_id { get; set; }
        public string index_datetime { get; set; }
        public string index_partnumber { get; set; }
        public string index_modelcode { get; set; }
        public string index_result { get; set; }
        public string index_value { get; set; }
        public string header_id { get; set; }
        public string header_detail { get; set; }
        public string mhi_createby { get; set; }
        public string mhi_createdate { get; set; }
        public string mhi_updateby { get; set; }
        public string mhi_updatedate { get; set; }
    }
    public List<CMDMachineHeader> ListOfMachineHeader;
    public MDMachineHeader()
    {
        ListOfMachineHeader = new List<CMDMachineHeader>();
    }
}