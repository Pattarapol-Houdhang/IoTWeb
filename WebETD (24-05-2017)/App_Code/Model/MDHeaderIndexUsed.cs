using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDHeaderIndexUsed
/// </summary>
public class MDHeaderIndexUsed
{
    public class CMDHeaderIndexUsed
    {
        public int hiu_id { get; set; }
        public string mc_code { get; set; }
        public string mc_name { get; set; }
        public string header_id { get; set; }
        public string header_detail { get; set; }
        public string field_index { get; set; }
        public string ColumnName { get; set; }
        public string result_index { get; set; }
        public string datetime_index { get; set; }
        public string partnumber_index { get; set; }
        public string model_index { get; set; }
        public string data_detail { get; set; }
        public string Result { get; set; }
    }

    public List<CMDHeaderIndexUsed> ListOfHeaderIndexUsed;
    public MDHeaderIndexUsed()
    {
        ListOfHeaderIndexUsed = new List<CMDHeaderIndexUsed>();
    }
}