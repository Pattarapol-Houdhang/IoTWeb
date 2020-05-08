using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDModel
/// </summary>
public class MDModel
{
    public class CMDModel
    {
        public string model_id { get; set; }
        public string model_code { get; set; }
        public string model_name { get; set; }
        public string model_type { get; set; }
        public string model_updateby { get; set; }
        public string model_updatedate { get; set; }
    }
    public List<CMDModel> ListOfModel;
    public MDModel()
    {
        ListOfModel = new List<CMDModel>();
    }
}