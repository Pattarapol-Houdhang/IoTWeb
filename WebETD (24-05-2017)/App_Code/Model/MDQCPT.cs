using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDQCPT
/// </summary>
public class MDQCPT
{
    public class CMDQCPT
    {
        public string pt_id { get; set; }
        public string Model { get; set; }
        public string m_id { get; set; }
        public decimal pt_id_rank { get; set; }
        public decimal pt_id_roundness { get; set; }
        public decimal pt_id_cylindricity { get; set; }
        public decimal pt_id_perpendicularity { get; set; }
        public decimal pt_id_concentricity { get; set; }
        public decimal pt_od_rank { get; set; }
        public decimal pt_od_judge_roundness { get; set; }
        public decimal pt_od_cylindricity { get; set; }
        public decimal pt_od_perpendicularity { get; set; }
        public decimal pt_bl_rank { get; set; }
        public decimal pt_bl_parallism { get; set; }
        public decimal pt_bl_perpendicularity { get; set; }
        public decimal pt_he_rank { get; set; }
        public decimal pt_he_parallism { get; set; }
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

    public List<CMDQCPT> ListOfPT;
    public MDQCPT()
    {
        ListOfPT = new List<CMDQCPT>();
    }
}