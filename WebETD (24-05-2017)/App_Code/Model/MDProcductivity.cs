using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDProcductivity
/// </summary>
public class MDProcductivity
{
    public class CMDProductivity
    {
        public string LineName { get; set; }

        public class CMDListQty
        {
            public string PlanD { get; set; }
            public string PlanN { get; set; }
            public string StartD { get; set; }
            public string StartN { get; set; }
            public string LastD { get; set; }
            public string LastN { get; set; }
            public string Date { get; set; }
            public int Day { get; set; }
        }

        public List<CMDListQty> ListOfQty;
        public CMDProductivity()
        {
            ListOfQty = new List<CMDListQty>();
        }
    }

    public List<CMDProductivity> ListOfProductivity;
    public MDProcductivity()
    {
        ListOfProductivity = new List<CMDProductivity>();
    }
}