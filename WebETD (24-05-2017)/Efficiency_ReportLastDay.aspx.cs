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

public partial class Efficiency_ReportLastDay : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        EffLine = Request.QueryString["line"] != null ? Request.QueryString["line"].ToString() : "";
        ViewState["line"] = EffLine;

        if (!IsPostBack)
        {
            InitialControl();

            //GetEmployeeOfLine();
            ddlLineName.Items.Add(new ListItem("Main Assembly", "main"));
            ddlLineName.Items.Add(new ListItem("Mecha", "mecha"));

            CycleTime = 30;
            if (ViewState["line"] != null)
            {
                if (ViewState["line"].ToString() == "mecha")
                {
                    hdLine.Text = "Line Efficiency Mecha Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                    ddlLineName.SelectedIndex = 1;
                }
                else if (ViewState["line"].ToString() == "casing")
                {
                    hdLine.Text = "Line Efficiency Casing Line Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else if (ViewState["line"].ToString() == "motor")
                {
                    hdLine.Text = "Line Efficiency Motor Line Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else if (ViewState["line"].ToString() == "piston")
                {
                    hdLine.Text = "Line Efficiency Piston Line Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else if (ViewState["line"].ToString() == "fh")
                {
                    hdLine.Text = "Line Efficiency Front head Line Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else if (ViewState["line"].ToString() == "cs")
                {
                    hdLine.Text = "Line Efficiency Crankshaft Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else if (ViewState["line"].ToString() == "cd")
                {
                    hdLine.Text = "Line Efficiency Cylinder Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else if (ViewState["line"].ToString() == "rh")
                {
                    hdLine.Text = "Line Efficiency Rear Head Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else if (ViewState["line"].ToString() == "fn")
                {
                    hdLine.Text = "Line Efficiency Final Line Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
                else
                {
                    hdLine.Text = "Line Efficiency Main Assembly Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                    ddlLineName.SelectedIndex = 0;
                }
            }
            else
            {
                hdLine.Text = "Line Efficiency Main Assembly Factory 3";
                linechoose.Text = ViewState["line"].ToString();
            }            
        }



        if (DateTime.Now.TimeOfDay > TimeSpan.Parse("20:00:00"))
        {
            Shiptday = false;
            DateTime SetTime = DateTime.Now.Date + new TimeSpan(20, 0, 0);
            lbTime1.Text = SetTime.ToString("HH:mm") + " - " + SetTime.AddMinutes(59).ToString("HH:mm");
            lbTime2.Text = SetTime.AddHours(1).ToString("HH:mm") + " - " + SetTime.AddHours(1).AddMinutes(59).ToString("HH:mm");
            lbTime3.Text = SetTime.AddHours(2).ToString("HH:mm") + " - " + SetTime.AddHours(2).AddMinutes(59).ToString("HH:mm");
            lbTime4.Text = SetTime.AddHours(3).ToString("HH:mm") + " - " + SetTime.AddHours(3).AddMinutes(59).ToString("HH:mm");
            lbTime5.Text = SetTime.AddHours(4).ToString("HH:mm") + " - " + SetTime.AddHours(4).AddMinutes(59).ToString("HH:mm");
            lbTime6.Text = SetTime.AddHours(5).ToString("HH:mm") + " - " + SetTime.AddHours(5).AddMinutes(59).ToString("HH:mm");
            lbTime7.Text = SetTime.AddHours(6).ToString("HH:mm") + " - " + SetTime.AddHours(6).AddMinutes(59).ToString("HH:mm");
            lbTime8.Text = SetTime.AddHours(7).ToString("HH:mm") + " - " + SetTime.AddHours(7).AddMinutes(59).ToString("HH:mm");
            lbTime9.Text = SetTime.AddHours(8).ToString("HH:mm") + " - " + SetTime.AddHours(8).AddMinutes(59).ToString("HH:mm");
            lbTime10.Text = SetTime.AddHours(9).ToString("HH:mm") + " - " + SetTime.AddHours(9).AddMinutes(59).ToString("HH:mm");
            lbTime11.Text = SetTime.AddHours(10).ToString("HH:mm") + " - " + SetTime.AddHours(10).AddMinutes(59).ToString("HH:mm");
            lbTime12.Text = SetTime.AddHours(11).ToString("HH:mm") + " - " + SetTime.AddHours(11).AddMinutes(59).ToString("HH:mm");
        }

        ViewState["ct"] = CycleTime;
        rptMachine.DataSource = GetMachineMain();
        rptMachine.DataBind();
        ViewState["ShipDay"] = Shiptday;
        GetMachineStatus();

        //lbTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        lbLastUpdate.Text = "Last Update : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        lbLastDay.Text = "Data On " + DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
    }

    private void InitialControl()
    {
    }

    private DataTable SetTable(int ct, string mc_name)
    {
        DataTable dtSetTable = new DataTable();
        dtSetTable.Columns.Add("Col", typeof(string));
        dtSetTable.Columns.Add("MC", typeof(string));

        int TotCol = ((3600 / ct) * 12) / 6;
        hdTotalCol.Value = TotCol.ToString();
        for (int i = 0; i < TotCol; i++)
        {
            DataRow _row = dtSetTable.NewRow();
            _row["Col"] = i.ToString();
            _row["MC"] = mc_name;
            dtSetTable.Rows.Add(_row);
        }

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
            if (dtMachine.Rows.Count > 0)
            {
                dtMachine.Rows[dtMachine.Rows.Count - 1]["mc_name"] = "Top Bottom Welding 1";
                DataRow _rowMachine = dtMachine.NewRow();
                _rowMachine["mc_code"] = "main08";
                _rowMachine["mc_name"] = "Top Bottom Welding 2";
                _rowMachine["mc_process"] = "TBW";
                dtMachine.Rows.Add(_rowMachine);
            }
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
        DateTime DateCurr = DateTime.Now.AddDays(-1);
        DateTime DateAcc = DateCurr.Date;
        if (DateCurr.TimeOfDay > TimeSpan.Parse("20:00:00"))
        {
            DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            DateAcc = DateCurr + new TimeSpan(8, 0, 0);
        }

        for (int i = 0; i < rptMachine.Items.Count; i++)
        {
            List<MDMachineStatus> oList = new List<MDMachineStatus>();
            Repeater rptCol = rptMachine.Items[i].FindControl("rptTableMachine") as Repeater;
            HiddenField hdMC = rptMachine.Items[i].FindControl("hdmcName") as HiddenField;

            DateAcc = DateCurr.Date;
            if (DateCurr.TimeOfDay > TimeSpan.Parse("20:00:00"))
            {
                DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
            }
            else
            {
                DateAcc = DateCurr.Date + new TimeSpan(8, 0, 0);
            }

            DataTable dtMCStatus = new DataTable();

            //-------------- Get Mechine each Line ----------------
            if (ViewState["line"].ToString() == "mecha")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineMechaStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "casing")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineCasingStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "motor")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineMotorStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "piston")
            {
                dtMCStatus = oMCStatusLastDay.GetMachinePistonStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "fh")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineFrontheadStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "cs")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineCrankshaftStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "cd")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineCylinderStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "rh")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineRearheadStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else if (ViewState["line"].ToString() == "fn")
            {
                dtMCStatus = oMCStatusLastDay.GetMachineFinalStatus(DateAcc, DateCurr, hdMC.Value, true);
            }
            else
            {
                dtMCStatus = oMCStatusLastDay.GetMachineStatus(DateAcc, DateCurr, hdMC.Value,true);
            }

            //---------- Get Machine Status -------------
            for (int j = 0; j < rptCol.Items.Count; j++)
            {
                HtmlTableCell td = (HtmlTableCell)rptCol.Items[j].FindControl("col");

                string timeStr = DateAcc.TimeOfDay.ToString().Replace(":", "");
                string timeEnd = DateAcc.AddSeconds(180).TimeOfDay.ToString().Replace(":", "");

                if (dtMCStatus.Rows.Count > 0)
                {
                    if (dtMCStatus.Rows[0]["Break"].ToString().ToUpper() == "YES")//--------- Check if this M/C is Breakdown --------
                    {
                        td.Attributes.Add("style", "background-color:#d2322d;");
                    }
                    else
                    {
                        DataRow[] _rowFillTime = new DataRow[dtMCStatus.Rows.Count];
                        if (ViewState["line"].ToString() == "mecha")
                        {
                            _rowFillTime = dtMCStatus.Select("cycle_start_time >= " + timeStr + " AND cycle_end_time < " + timeEnd);
                        }
                        else if (ViewState["line"].ToString() == "casing" || ViewState["line"].ToString() == "motor" || ViewState["line"].ToString() == "piston"
                                || ViewState["line"].ToString() == "fh" || ViewState["line"].ToString() == "cs" || ViewState["line"].ToString() == "cd"
                                || ViewState["line"].ToString() == "rh" || ViewState["line"].ToString() == "fn")
                        {
                            string dateEnd = DateCurr.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss");

                            _rowFillTime = dtMCStatus.Select("data_mfgdate >= " + DateAcc.ToString("yyyy-MM-dd HH:mm:ss") + " AND data_mfgdate < " + dateEnd);
                        }
                        else
                        {
                            _rowFillTime = dtMCStatus.Select("CycleStartTime >= " + timeStr + " AND CycleEndTime < " + timeEnd);
                        }

                        if (_rowFillTime.Length > 0)
                        {
                            td.Attributes.Add("style", "background-color:#45f960;");
                        }
                        else
                        {
                            td.Attributes.Add("style", "background-color:#e5a943;");
                        }
                    }
                }
                
                DateAcc = DateAcc.AddSeconds(180);
            }
        }

    }

    protected void rptTableMachine_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

        }
    }

    protected void ddlLineName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLineName.SelectedValue == "mecha")
        {
            Page.Response.Redirect("Efficiency_ReportLastDay.aspx?line=mecha", true);
        }
        else
        {
            Page.Response.Redirect("Efficiency_ReportLastDay.aspx?line=main", true);
        }
        
    }
}