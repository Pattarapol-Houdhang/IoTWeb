using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDQCCS
/// </summary>
public class MDQCCS
{
    public class CMDQCCS
    {
        public string cs_id { get; set; }
        public string Model { get; set; }
        public string m_id { get; set; }
        public decimal cs_fr_f_rank { get; set; }
        public decimal cs_fr_r_rank { get; set; }
        public decimal cs_fr_f_judge_roundness { get; set; }
        public decimal cs_fr_r_judge_roundness { get; set; }
        public decimal cs_fr_f_cylindricity { get; set; }
        public decimal cs_fr_r_cylindricity { get; set; }
        public decimal cs_pin_rank { get; set; }
        public decimal cs_pin_judge_roundness { get; set; }
        public decimal cs_pin_cylindricity { get; set; }
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

    public List<CMDQCCS> ListOfCS;
    public MDQCCS()
    {
        ListOfCS = new List<CMDQCCS>();
    }
}