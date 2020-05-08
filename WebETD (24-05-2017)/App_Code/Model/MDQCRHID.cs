using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDQCRHID
/// </summary>
public class MDQCRHID
{
    public class CMDQCRHID
    {
        public string rh_id { get; set; }
        public string Model { get; set; }
        public string m_id { get; set; }
        public decimal rh_id1 { get; set; }
        public decimal rh_id3 { get; set; }
        public decimal rh_rank { get; set; }
        public decimal rh_roundness1 { get; set; }
        public decimal rh_roundness3 { get; set; }
        public decimal rh_judge_roundness { get; set; }
        public decimal rh_cylindricity { get; set; }
        public decimal rh_perpendicularity { get; set; }
        public string first_stamptime { get; set; }
        public string PartType { get; set; }
        public string MainPoint { get; set; }
        public string SubPoint { get; set; }
        public decimal MQMin { get; set; }
        public decimal MQMax { get; set; }
        public decimal UCL { get; set; }
        public decimal CL { get; set; }
        public decimal LCL { get; set; }

    }


    public List<CMDQCRHID> ListOfRH;
    public MDQCRHID()
    {
        ListOfRH = new List<CMDQCRHID>();
    }
}