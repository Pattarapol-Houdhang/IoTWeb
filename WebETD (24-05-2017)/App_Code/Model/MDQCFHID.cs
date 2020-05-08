using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDQCFHID
/// </summary>
public class MDQCFHID
{
    public class CMDFHID
    {
        public string fh_id { get; set; }
        public string Model { get; set; }
        public decimal fh_id1 { get; set; }
        public decimal fh_id3 { get; set; }
        public decimal fh_rank { get; set; }
        public decimal fh_roundness1 { get; set; }
        public decimal fh_roundness3 { get; set; }
        public decimal fh_judge_roundness { get; set; }
        public decimal fh_cylindricity { get; set; }
        public decimal fh_perpendicularity { get; set; }
        public decimal fh_concentricity { get; set; }
        public string first_stamptime { get; set; }
        public string PartType { get; set; }
        public string MainPoint { get; set; }
        public string SubPoint { get; set; }
        public decimal MQMin { get; set; }
        public decimal MQMax { get; set; }
        public decimal UCL { get; set; }
        public decimal CL { get; set; }
        public decimal LCL { get; set; }

        //public class CMDFHSUB
        //{
            
        //}

        //public List<CMDFHSUB> ListOfSubPoint;

        //public CMDFHID()
        //{
        //    ListOfSubPoint = new List<CMDFHSUB>();
        //}

    }

    public List<CMDFHID> ListOfID;
    public MDQCFHID()
    {
        ListOfID = new List<CMDFHID>();
    }
}