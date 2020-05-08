using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MDFactory
/// </summary>
public class MDFactory
{
    public class CMDFactory
    {
        public int FactoryID { get; set; }
        public string FactoryName { get; set; }
        public int TotalLine { get; set; }
        public int TotalMachine { get; set; }
    }

    public List<CMDFactory> ListOfFactory;
    public MDFactory()
    {
        ListOfFactory = new List<CMDFactory>();
    }
}