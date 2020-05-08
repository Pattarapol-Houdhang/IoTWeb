using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDMechaNG
/// </summary>
public class MDMechaNG
{
    public class CMDMechaNG{
        public string part_name { get; set; }
        public string part_type { get; set; }
        public string detail { get; set; }
        public int Qty { get; set; }
        public string Model { get; set; }
        public string AVG { get; set; }

    }
    public class CMDMechaNG_partType_Total
    {
        public string part_name { get; set; }
        public string part_type { get; set; }
        public int Total { get; set; }
    }
    public class CMDMechaNGTotal
    {
        public string part_name { get; set; }
        public int Total { get; set; }
    }
    public class CMDMechaNGTotalM
    {
        public string part_name { get; set; }
        public string model { set; get; }
        public int Total { get; set; }
    }
    public class CMDModel
    {
        public string model_name { get; set; }
    }
    public List<CMDMechaNG> ListOfMechaNG;
    public List<CMDMechaNG_partType_Total> ListOfMechaNG_partType_Total;
    public List<CMDMechaNGTotal> ListOfMechaNGTotal;
    public List<CMDMechaNGTotalM> ListOfMechaNGTotalM;
    public List<CMDModel> ListOfModel;
    public MDMechaNG()
    {
        ListOfMechaNG = new List<CMDMechaNG>();
        ListOfMechaNGTotal = new List<CMDMechaNGTotal>();
        ListOfMechaNG_partType_Total = new List<CMDMechaNG_partType_Total>();
        ListOfMechaNGTotalM = new List<CMDMechaNGTotalM>();
        ListOfModel = new List<CMDModel>();
	}
    
}