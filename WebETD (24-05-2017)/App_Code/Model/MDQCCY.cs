using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDQCCY
/// </summary>
public class MDQCCY
{
    public class CMDQCCY
    {
        public string cy_id { get; set; }
        public string Model { get; set; }
        public decimal cy_bo_rank { get; set; }
        public decimal cy_bo_judge_roundness { get; set; }
        public decimal cy_bo_cylindricity { get; set; }
        public decimal cy_bo_perpendicularity { get; set; }
        public decimal cy_bo_concentricity { get; set; }
        public decimal cy_he_rank { get; set; }
        public decimal cy_he_parallism { get; set; }
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

    public List<CMDQCCY> ListOfCY;
    public MDQCCY()
    {
        ListOfCY = new List<CMDQCCY>();
    }
}