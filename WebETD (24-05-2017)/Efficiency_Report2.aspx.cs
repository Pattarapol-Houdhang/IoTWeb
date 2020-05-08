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

public partial class Efficiency_Report2 : System.Web.UI.Page
{
    //CGenControl oGenControl = new CGenControl();
    CGenGraph oGenGraph = new CGenGraph();
    ConnectDB oConn = new ConnectDB();
    ConnectDBIoTServerTon oConnIoT = new ConnectDBIoTServerTon();
    CGetMachineStatus oMCStatus = new CGetMachineStatus();
    PSNEmployeewebservice oEm = new PSNEmployeewebservice();
    CGetMachineStatusLastDay oMCStatusLastDay = new CGetMachineStatusLastDay();

    private string Event = "";
    private string chDate = "";
    int CycleTime = 30;
    bool Shiptday = true;
    string EffLine = "";

    //--------------- Structure of Emplyee data -------------------
    struct Emp
    {
        public string EmpCode { get; set; }
        public string LinkPic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string WorkDate { get; set; }
        public string Status { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private void InitialControl()
    {
    }

    private DataTable SetTable(int ct, string mc_name)
    {
        DataTable dtSetTable = new DataTable();
        
        return dtSetTable;
    }

    private DataTable GetMachineMain()
    {
        DataTable dtMachine = new DataTable();
        if (ViewState["line"].ToString() == "mecha")
        {
            string[] MCMecha = { "Crank Shaft", "Cylinder", "Piston", "Front Head", "Rear Head", "Cylinder Centering", "Rear Centering", "Tourque Check" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));

            for (int i = 0; i < MCMecha.Length; i++)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = i;
                _row["mc_name"] = MCMecha[i];
                _row["mc_process"] = MCMecha[i];

                dtMachine.Rows.Add(_row);
            }
        }
        else if (ViewState["line"].ToString() == "casing")
        {
            string[] MCMecha = { "Pipe Marking", "Pipe Plasma Welding", "Pipe Punch Machine", "Pipe ID Check" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            for (int i = 0; i < MCMecha.Length; i++)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = i;
                _row["mc_name"] = MCMecha[i];
                _row["mc_process"] = MCMecha[i];

                dtMachine.Rows.Add(_row);
            }
        }
        else if (ViewState["line"].ToString() == "motor")
        {
            string[] MCMotor = { "Stator Transport Unit Input S  ide", "Stator Transport Unit Discharge Side", "Stator Common Transport Input Side", "Stator Common Transport Discharg Side",
                                   "Stator Insulator Laser Marking","Stator Transport Winding Input Side","Stator Winding No1","Stator Charecteristic Measurement"};
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "piston")
        {
            string[] MCMotor = { "Piston Laser", "Piston Surface Grinding", "Piston Blade Grinding 1", "Piston Blade Grinding 2", "Piston Brushing" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "fh")
        {
            string[] MCMotor = { "Front Head Laser", "Front Head Internal Grinding No 1", "Front Head Internal Grinding No 2", "Front Head Surface Grinding", "Front Head Brushing" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "cs")
        {
            string[] MCMotor = { "Crankshaft Laser", "Crankshaft Thrust Grinding No 1", "Crankshaft Thrust Grinding No 2", "Crankshaft Centerless Grinding No 1", "Crankshaft Centerless Grinding No 2", "Crankshaft Brushing" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "cd")
        {
            string[] MCMotor = { "Cylinder Laser", "Cylinder Surface Grinding No 1", "Cylinder Surface Grinding No 2", "Cylinder BoreID Grinding No 1", "Cylinder BoreID Grinding No 2", "Cylinder Bush Hole Grinding No 1", "Cylinder Bush Hole Grinding No 2", "Cylinder Bush Hole Grinding No 3", "Cylinder_Brushing" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "rh")
        {
            string[] MCMotor = { "Rear Head Laser", "Rear Head Surface", "Rear Head Brush" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "fn")
        {
            string[] MCMotor = { "Running Test No 1", "Running Test No 2", "Running Test No 3", "Running Test No 4", "Oil Filling", "Weight Check" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "SELECT DISTINCT mc_code,mc_name,mc_process FROM [Machine] where mc_code like 'main0%'";
            dtMachine = oConn.Query(sql);
        }


        return dtMachine;
    }

    protected void rptMachine_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DateTime DateCurr = DateTime.Now;
            DateTime DateAcc = DateCurr.Date + new TimeSpan(8, 0, 0);

            Repeater rptMac = e.Item.FindControl("rptTableMachine") as Repeater;
            HiddenField hdName = e.Item.FindControl("hdmcName") as HiddenField;

            rptMac.DataSource = SetTable(Convert.ToInt16(ViewState["ct"].ToString()), hdName.Value);
            rptMac.DataBind();
        }
    }

    private void GetMachineStatus()
    {
        
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (DateTime.Now.TimeOfDay == TimeSpan.Parse("20:00:01") || DateTime.Now.TimeOfDay == TimeSpan.Parse("20:01:00"))
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        else if (DateTime.Now.TimeOfDay >= TimeSpan.Parse("08:00:01") && DateTime.Now.TimeOfDay <= TimeSpan.Parse("08:01:00"))
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        else
        {
            GetMachineStatus();
        }
    }

    protected void rptTableMachine_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

        }
    }

    protected void btnSetDate_Click(object sender, EventArgs e)
    {
    }
    
}