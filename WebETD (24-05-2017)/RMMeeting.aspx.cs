using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EmployeeService;
using System.Collections;

public partial class RMMeeting : System.Web.UI.Page
{
    //CGenControl oGenControl = new CGenControl();
    CGenGraph oGenGraph = new CGenGraph();
    ConnectDB oConn = new ConnectDB();
    ConnectDBIoTServerTon oConnIoT = new ConnectDBIoTServerTon();
    CGetMachineStatus oMCStatus = new CGetMachineStatus();
    PSNEmployeewebservice oEm = new PSNEmployeewebservice();

    private string Event = "";
    private string chDate = "";
    int CycleTime = 30;
    bool Shiptday = true;
    string EffLine = "";

    

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private void InitialControl()
    {
    }

    
}