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
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Globalization;

public partial class Efficiency_Report : System.Web.UI.Page
{
    //CGenControl oGenControl = new CGenControl();
    CGenGraph oGenGraph = new CGenGraph();
    ConnectDB oConn = new ConnectDB();
    ConnectDBCosty oConCosty = new ConnectDBCosty();
    ConnectDBIoTServerTon oConnIoT = new ConnectDBIoTServerTon();
    CGetMachineStatus oMCStatus = new CGetMachineStatus();
    PSNEmployeewebservice oEm = new PSNEmployeewebservice();
    CGetMachineStatusLastDay oMCStatusLastDay = new CGetMachineStatusLastDay();
    CultureInfo cu = new CultureInfo("en-US");

    private string Event = "";
    private string chDate = "";
    int CycleTime = 30;
    bool Shiptday = true;
    string EffLine = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        EffLine = Request.QueryString["line"] != null ? Request.QueryString["line"].ToString() : "";
        string Create = Request.QueryString["create"] != null ? Request.QueryString["create"].ToString() : "NO";
        ViewState["line"] = EffLine;
        ViewState["create"] = Create;

        if (!IsPostBack)
        {
            InitialControl();

            //GetEmployeeOfLine();

            CycleTime = 30;
            if (ViewState["line"] != null)
            {
                if (ViewState["line"].ToString() == "mecha")
                {
                    hdLine.Text = "Line Efficiency Mecha Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
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

        lbTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        lbLastUpdate.Text = "Last Update : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
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


    //------------- Get Machine Name and Order Process form Scada_Alarm_MCMst -------------
    private DataTable GetMcNameMachine (string Line)
    {
        DataTable dtMachine = new DataTable();
        dtMachine.Columns.Add("mc_code", typeof(string));
        dtMachine.Columns.Add("mc_name", typeof(string));
        dtMachine.Columns.Add("mc_name_link", typeof(string));
        dtMachine.Columns.Add("mc_process", typeof(string));

        SqlCommand sqlMC = new SqlCommand();
        sqlMC.CommandText = "SELECT [McNo],ms.Mc_Name,ms.[Location],[McProcessOrder] FROM [Scada_AlarmMC_Order] mco"+
            " RIGHT JOIN [Scada_AlarmMC_mst] ms ON mco.McNo = ms.Mc_No WHERE ms.Location = '"+Line+"' ORDER BY ms.Location,mco.McProcessOrder";
        DataTable dt = oConCosty.SqlGet(sqlMC, "DBIOTFAC3");
        foreach (DataRow _row in dt.Rows)
        {
            DataRow _rowMC = dtMachine.NewRow();
            _rowMC["mc_code"] = _row["McNo"].ToString();
            _rowMC["mc_name"] = _row["Mc_Name"].ToString().Replace("_"," ");
            _rowMC["mc_name_link"] = _row["McNo"].ToString();
            _rowMC["mc_process"] = _row["Mc_Name"].ToString().Replace("_", " ");
            dtMachine.Rows.Add(_rowMC);
        }

        //------- Insert Model Change --------
        DataRow _rowModel = dtMachine.NewRow();
        _rowModel["mc_code"] = "Model Change";
        _rowModel["mc_name"] = "Model Change";
        _rowModel["mc_name_link"] = "";
        _rowModel["mc_process"] = "";
        dtMachine.Rows.InsertAt(_rowModel, 0);

        return dtMachine;
    }
    //------------- Get Machine Name and Order Process form Scada_Alarm_MCMst -------------

    private DataTable GetMachineMain()
    {
        DataTable dtMachine = new DataTable();
        if (ViewState["line"].ToString() == "mecha")
        {
            string[] MCMecha = { "Model Change","Washing Machine", "Piston", "Cylinder", "Crank Shaft", "Rear Head", "Front Head", "Cylinder Centering", "Rear Centering", "Tourque Check" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_name_link", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));

            for (int i = 0; i < MCMecha.Length; i++)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = i;
                _row["mc_name"] = MCMecha[i];
                _row["mc_name_link"] = _row["mc_name"].ToString().Replace(" ", "_");
                _row["mc_process"] = MCMecha[i];

                dtMachine.Rows.Add(_row);
            }
        }
        else if (ViewState["line"].ToString() == "casing")
        {
            string[] MCMecha = { "Pipe Marking", "Pipe Plasma Welding", "Pipe Punch Machine", "Pipe ID Check" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_name_link", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            for (int i = 0; i < MCMecha.Length; i++)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = i;
                _row["mc_name"] = MCMecha[i];
                _row["mc_name_link"] = _row["mc_name"].ToString().Replace(" ", "_");
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
            dtMachine.Columns.Add("mc_name_link", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_name_link"] = _row["mc_name"].ToString().Replace(" ", "_");
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "piston")
        {
            string[] MCMotor = { "Model Change","Laser Marking", "Surface","Blade grinding No 1", "Blade grinding No 2"
                    , "Blade grinding No 3", "Blade grinding No 4","External 1","External 2","External 3","External 4"
                    , "Internal 1", "Internal 2","Horning", "Brush" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_name_link", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_name_link"] = _row["mc_name"].ToString().Replace(" ", "_");
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else if (ViewState["line"].ToString() == "fh" || ViewState["line"].ToString() == "cs" || ViewState["line"].ToString() == "cd" || ViewState["line"].ToString() == "rh")
        {
            //---------- Get Mc Name from Alarm Master ---------------
            string Line = "";
            switch (ViewState["line"].ToString())
            {
                case "fh": Line = "FH";
                    break;
                case "cs": Line = "CS";
                    break;
                case "cd": Line = "CY";
                    break;
                case "rh": Line = "RH";
                    break;
                default:
                    break;
            }
            dtMachine = new DataTable();
            dtMachine = GetMcNameMachine(Line);
        }
        else if (ViewState["line"].ToString() == "fn")
        {
            //-----------Final Line ---------------
            string[] MCMotor = { "Model Change", "Label Printing", "Oil Filling", "Running Test No 1", "Running Test No 2", "Running Test No 3", "Running Test No 4", "Running Test No 5"
                , "Running Test No 6", "Running Test No 7", "Running Test No 8", "Weight Check" };
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_name_link", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            int idxRow = 0;
            foreach (string item in MCMotor)
            {
                DataRow _row = dtMachine.NewRow();
                _row["mc_code"] = idxRow;
                _row["mc_name"] = item;
                _row["mc_name_link"] = _row["mc_name"].ToString().Replace(" ", "_");
                _row["mc_process"] = item;
                dtMachine.Rows.Add(_row);
                idxRow++;
            }
        }
        else
        {
            //SqlCommand sql = new SqlCommand();
            //sql.CommandText = "SELECT DISTINCT mc_code,mc_name,mc_process FROM [Machine] where mc_code like 'main0%'";

            //dtMachine = oConn.Query(sql);
            //if (dtMachine.Rows.Count > 0)
            //{
            //    dtMachine.Rows[dtMachine.Rows.Count - 1]["mc_name"] = "Top Bottom Welding 1";
            //    DataRow _rowMachine = dtMachine.NewRow();
            //    _rowMachine["mc_code"] = "main08";
            //    _rowMachine["mc_name"] = "Top Bottom Welding 2";
            //    _rowMachine["mc_process"] = "TBW";
            //    dtMachine.Rows.Add(_rowMachine);
            //}
            dtMachine.Columns.Add("mc_code", typeof(string));
            dtMachine.Columns.Add("mc_name", typeof(string));
            dtMachine.Columns.Add("mc_name_link", typeof(string));
            dtMachine.Columns.Add("mc_process", typeof(string));
            dtMachine.Rows.Add("main08", "Model Change", "Rotor_Yakibame", "TBW");
            dtMachine.Rows.Add("main08", "Rotor Yakibame", "Rotor_Yakibame", "TBW");
            dtMachine.Rows.Add("main08", "Magnetize", "Magnetize", "TBW");
            dtMachine.Rows.Add("main08", "Pipe Yakibame", "Pipe_Yakibame", "TBW");
            dtMachine.Rows.Add("main08", "TackWelding", "TackWelding", "TBW");
            dtMachine.Rows.Add("main08", "Magnet Center", "Magnet_Center", "TBW");
            dtMachine.Rows.Add("main08", "Air Gap", "Air_Gap", "TBW");
            dtMachine.Rows.Add("main08", "Electrical Check", "Electrical_Check", "TBW");
            dtMachine.Rows.Add("main08", "Top Bottom Welding 1", "Top_Bottom_Welding_1", "TBW");
            dtMachine.Rows.Add("main08", "Top Bottom Welding 2", "Top_Bottom_Welding_2", "TBW");
            dtMachine.Rows.Add("main08", "Top Bottom Welding 3", "Top_Bottom_Welding_3", "TBW");
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
            HiddenField hdCode = e.Item.FindControl("hdMcCode") as HiddenField;
            Label lbModelRun = e.Item.FindControl("ModelRun") as Label;

            HtmlTableCell th = (HtmlTableCell)e.Item.FindControl("HeadModel");

            if (hdName.Value == "Model Change" || ViewState["line"].ToString() == "" || ViewState["line"].ToString() == "mecha" || ViewState["line"].ToString() == "main")
            {
                th.Attributes.Add("style", "display:none");
            }
            else
            {
                //-------------- Get Model Running -------------
                SqlCommand sqlModelRun = new SqlCommand();
                sqlModelRun.CommandText = "SELECT TOP (1) [Mc_No],[Program_No],[Program_Name],[UpdateLog]" +
                    " FROM [Scada_Mc_Model_Running] WHERE Mc_No = '" + hdCode.Value + "' ORDER BY UpdateLog DESC";
                DataTable dtModel = oConCosty.SqlGet(sqlModelRun, "DBIOTFAC3");
                if (dtModel.Rows.Count > 0)
                {
                    lbModelRun.Text = dtModel.Rows[0]["Program_Name"].ToString();
                }
                else
                {
                    lbModelRun.Text = "No Data.";
                }
            }

            

            rptMac.DataSource = SetTable(Convert.ToInt16(ViewState["ct"].ToString()), hdName.Value);
            rptMac.DataBind();
        }
    }

    public string ConvertDataTabletoString(DataTable dt)
    {
        JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        foreach (DataRow dr in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName == "AlarmStatus")
                {
                    row.Add(col.ColumnName, dr[col].ToString().Trim());
                }
                else if (col.ColumnName == "StartAlarm" || col.ColumnName == "EndAlarm")
                {
                    DateTime start = Convert.ToDateTime(dr[col].ToString());
                    row.Add(col.ColumnName, start.ToString("yyyy-MM-dd HH:mm:ss").Trim());
                }
                else
                {
                    row.Add(col.ColumnName, dr[col].ToString());
                }
            }
            rows.Add(row);
        }
        serializer.MaxJsonLength = 500000000;
        return serializer.Serialize(rows);
    }

    public string GetMachineStatus()
    {
        //--------------- Data Plan Eff Actual ------------------
        CGetDataGraph oTarget = new CGetDataGraph();
        List<MDataGraph> oListData = new List<MDataGraph>();
        //oListData = oTarget.GetPlan(300, "", ViewState["line"].ToString(), "", "", "", "");
        //--------------- Data Plan Eff Actual ------------------

        DataTable dtMCBreakDown = new DataTable();

        string Shift = "D";
        DateTime DateCurr = DateTime.Now;
        DateTime DateAcc = DateCurr.Date;
        
        if (DateCurr.Hour >= 8 && DateCurr.Hour < 20)
        {
            // ---- Day Shift ----
            DateAcc = DateCurr.Date + new TimeSpan(8, 0, 0);
            Shift = "D";
        }
        else
        {
            if (DateCurr.Hour >= 0 && DateCurr.Hour <= 7)
            {
                DateAcc = DateCurr.AddDays(-1).Date + new TimeSpan(20, 0, 0);
                Shift = "N";
            }
            else if (DateCurr.Hour >= 20 && DateCurr.Hour <= 23)
            {
                DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
                Shift = "N";
            }
        }

        //----------- Craete Source Status Lamp ----------------
        string JsonLampStatus = "";
        bool CreatedFile = false;
        try
        {
            JsonLampStatus = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Production/EffSource/Lamp"+ Shift + ViewState["line"].ToString() + ".json"));
        }
        catch { }

        DataTable dtLamp = new DataTable();
        if (ViewState["create"].ToString() == "YES")
        {
            dtLamp = new DataTable();
            dtLamp.Columns.Add("MC", typeof(string));
            dtLamp.Columns.Add("index", typeof(int));
            dtLamp.Columns.Add("Lamp", typeof(string));
            dtLamp.Columns.Add("MCNo", typeof(string));
        }
        else
        {
            //----------- Convert JSON to DataTable ------------------
            dtLamp = (DataTable)JsonConvert.DeserializeObject(JsonLampStatus, (typeof(DataTable)));
        }
        
        //if (dtLamp == null)
        //{
        //    dtLamp = new DataTable();
        //    dtLamp.Columns.Add("MC", typeof(string));
        //    dtLamp.Columns.Add("index", typeof(int));
        //    dtLamp.Columns.Add("Lamp", typeof(string));
        //}
        //else
        //{
        //    CreatedFile = true;
        //}        
        // ------ Get Break Down Lamp Status -------
        dtMCBreakDown = oMCStatusLastDay.GetDTMachineBreakDown(Shift, DateCurr, ViewState["line"].ToString());

        SqlConnection conn = new SqlConnection("Data Source=costy;Initial Catalog=dbIoTFac3;Persist Security Info=True;User ID=sa;Password=decjapan;");
        SqlCommand sql = new SqlCommand();
        sql.Connection = conn;
        int idxRowLamp = 0, idxColLamp = 0;
        for (int i = 0; i < rptMachine.Items.Count; i++)
        {
            List<MDMachineStatus> oList = new List<MDMachineStatus>();
            Repeater rptCol = rptMachine.Items[i].FindControl("rptTableMachine") as Repeater;
            HiddenField hdMC = rptMachine.Items[i].FindControl("hdmcName") as HiddenField;
            HiddenField hdMCCode = rptMachine.Items[i].FindControl("hdMcCode") as HiddenField;
            
            string LineName = "";

            // ---- Day Shift ----
            if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
            {
                DateAcc = DateTime.Now.Date + new TimeSpan(8, 0, 0);
            }
            // ---- Night Shift ----
            else
            {
                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
                {
                    DateAcc = DateTime.Now.AddDays(-1).Date + new TimeSpan(20, 0, 0);
                }
                else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
                {
                    DateAcc = DateTime.Now.Date + new TimeSpan(20, 0, 0);
                }
            }

            DataTable dtMCStatus = new DataTable();

            if (hdMC.Value != "Washing Machine")
            {
                #region Get Machine Status have Work for ASsy Line 
                if (ViewState["line"].ToString() == "mecha")
                {
                    dtMCStatus = oMCStatusLastDay.GetMachineMechaStatus(DateAcc, DateCurr, hdMC.Value, false);
                    LineName = "3AME5";
                }
                else if (ViewState["line"].ToString() == "casing")
                {
                    dtMCStatus = oMCStatusLastDay.GetMachineCasingStatus(DateAcc, DateCurr, hdMC.Value, false);
                    LineName = "3ACP5";
                }
                else if (ViewState["line"].ToString() == "motor")
                {
                    dtMCStatus = oMCStatusLastDay.GetMachineMotorStatus(DateAcc, DateCurr, hdMC.Value, false);
                    LineName = "3AST3";
                }
                else if (ViewState["line"].ToString() == "piston")
                {
                    if (hdMC.Value == "Model Change")
                    {
                        //------------- Get Status Piston Model Change -------------
                        dtMCStatus = oMCStatusLastDay.GetMachinePistonStatus(DateAcc, DateCurr, hdMC.Value, false);
                    }                    
                    LineName = "3MPI11";
                }
                else if (ViewState["line"].ToString() == "fh")
                {
                    LineName = "3MFH5";
                    if (hdMC.Value == "Model Change")
                    {
                        dtMCStatus = oMCStatusLastDay.GetMachineFrontheadStatus(DateAcc, DateCurr, hdMC.Value, false);
                    }
                }
                else if (ViewState["line"].ToString() == "cs")
                {
                    LineName = "3MCS9";
                    if (hdMC.Value == "Model Change")
                    {
                        dtMCStatus = oMCStatusLastDay.GetMachineCrankshaftStatus(DateAcc, DateCurr, hdMC.Value, false);
                    }
                }
                else if (ViewState["line"].ToString() == "cd")
                {
                    LineName = "3MCY12";
                    if (hdMC.Value == "Model Change")
                    {
                        dtMCStatus = oMCStatusLastDay.GetMachineCylinderStatus(DateAcc, DateCurr, hdMC.Value, false);
                    }
                }
                else if (ViewState["line"].ToString() == "rh")
                {
                    LineName = "3MRH5";
                    if (hdMC.Value == "Model Change")
                    {
                        dtMCStatus = oMCStatusLastDay.GetMachineRearheadStatus(DateAcc, DateCurr, hdMC.Value, false);
                    }                    
                }
                else if (ViewState["line"].ToString() == "fn")
                {
                    LineName = "3AFI9";
                    dtMCStatus = oMCStatusLastDay.GetMachineFinalStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                else
                {
                    LineName = "3AMA5";
                    dtMCStatus = oMCStatusLastDay.GetMachineStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                #endregion
            }            

            //---------- Get Machine Status -------------
            string StatusStatus = "RUN";
            string StatusLamp = "";
            for (int j = 0; j < rptCol.Items.Count; j++)
            {
                HtmlTableCell td = (HtmlTableCell)rptCol.Items[j].FindControl("col");

                //--------- Get Cycle start stop -----------
                string timeStr = DateAcc.TimeOfDay.ToString().Replace(":", "");
                string timeComma = DateAcc.ToString("HH:mm:ss");
                string timeEnd = DateAcc.AddSeconds(180).TimeOfDay.ToString().Replace(":", "");
                string timeEndComma = DateAcc.AddSeconds(180).ToString("HH:mm:ss");
                //if (dtMCStatus.Rows.Count > 0 || hdMC.Value == "Washing Machine")
                if (ViewState["line"].ToString() == "fn" || ViewState["line"].ToString() == "main" || ViewState["line"].ToString() == "mecha" || ViewState["line"].ToString() == "" || ViewState["line"].ToString() == "casing")
                {
                    #region Get Status Breakdown and Create Json Yes
                    //---------- Get Status Breakdown -----------
                    string MachineId = "";
                    string LineId = "";
                    string StatusBreak = "NO";
                    string ColorLamp = "";

                    McAndLine oMcNameAndLineId = new McAndLine();
                    oMcNameAndLineId = GetMachineIDAndLineId(hdMC.Value);
                    MachineId = oMcNameAndLineId.Mc;
                    LineId = oMcNameAndLineId.Line;

                    //----------------- Get Machine RUN and have product ---------------------
                    DataRow[] _rowFillTime = new DataRow[] { };

                    if (hdMC.Value != "Washing Machine" && ViewState["create"].ToString() == "YES")
                    {
                        if (ViewState["line"].ToString() == "mecha")
                        {
                            if (hdMC.Value != "Model Change")
                            {
                                _rowFillTime = dtMCStatus.Select("cycle_start_time >= " + timeStr + " AND cycle_end_time < " + timeEnd);
                            }
                            else
                            {
                                _rowFillTime = dtMCStatus.Select("cycle_start_time < " + timeStr + " AND cycle_end_time > " + timeEnd);
                            }
                            
                        }
                        else if (ViewState["line"].ToString() == "casing" || ViewState["line"].ToString() == "motor")
                        {
                            string dateEnd = DateCurr.ToString("yyyy/MM/dd") + " " + DateTime.Now.ToString("HH:mm:ss");
                            try
                            {
                                _rowFillTime = dtMCStatus.Select("data_mfgdate >= " + DateAcc);
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                if (hdMC.Value != "Model Change")
                                {
                                    _rowFillTime = dtMCStatus.Select("CycleStartTime >= " + timeStr + " AND CycleEndTime < " + timeEnd);
                                }
                                else
                                {
                                    _rowFillTime = dtMCStatus.Select("cycle_start_time < " + timeStr + " AND cycle_end_time > " + timeEnd);
                                }
                                
                            }
                            catch { }
                        }
                    }
                    
                    if (_rowFillTime.Length > 0 && ViewState["create"].ToString() == "YES")
                    {
                        ColorLamp = "#45f960";
                        if (hdMC.Value == "Model Change")
                        {
                            ColorLamp = "#2d38d1";
                        }
                        td.Attributes.Add("style", "background-color:"+ ColorLamp + ";");
                        StatusStatus = "RUN";
                    }
                    else if (_rowFillTime.Length <= 0 && ViewState["create"].ToString() == "YES")
                    {
                        //------------Get Status Alarm-----------------
                        string MCNameWhere = "";

                        if (ViewState["line"].ToString() == "mecha" || ViewState["line"].ToString() == "" || ViewState["line"].ToString() == "main")
                        {
                            switch (hdMC.Value)
                            {
                                case "Washing Machine": MCNameWhere = "Washing"; break;
                                case "Crank Shaft": MCNameWhere = "CS_MEASURING"; break;
                                case "Cylinder": MCNameWhere = "CY_MEASURING"; break;
                                case "Piston": MCNameWhere = "PT_MEASURING"; break;
                                case "Front Head": MCNameWhere = "FH_MEASURING"; break;
                                case "Rear Head": MCNameWhere = "RH_MEASURING"; break;
                                case "Cylinder Centering": MCNameWhere = "CYLINDER_CENTERING"; break;
                                case "Rear Centering": MCNameWhere = "REAR_CENTERING"; break;
                                case "Tourque Check": MCNameWhere = ""; break;
                                case "Rotor Yakibame": MCNameWhere = "Rotor Yaki : AMA-0120"; break;
                                case "Magnetize": MCNameWhere = "Magnetzing : AMA-0122"; break;
                                case "Pipe Yakibame": MCNameWhere = "PIPE YAKI : AMA-0117"; break;
                                case "TackWelding": MCNameWhere = "Tack Welding : AMA-0130"; break;
                                case "Magnet Center": MCNameWhere = "Megnet_Center"; break;
                                case "Air Gap": MCNameWhere = ""; break;
                                case "Electrical Check": MCNameWhere = "Connecting Check : AMA-0132"; break;
                                case "Top Bottom Welding 1": MCNameWhere = "Bottom&Top Welding No1"; break;
                                case "Top Bottom Welding 2": MCNameWhere = "Bottom&Top Welding No2"; break;
                                case "Top Bottom Welding 3": MCNameWhere = "Bottom&Top Welding No3"; break;
                            }
                        }
                        
                        if (dtMCBreakDown.Rows.Count > 0)
                        {
                            DataRow[] drMCBreakDown = dtMCBreakDown.Select(" MCName = '" + MCNameWhere + "' AND (StartAlarm >= '" + DateAcc.ToString("yyyy-MM-dd HH:mm:ss")
                                + "' AND EndAlarm <= '" + DateAcc.AddSeconds(180).ToString("yyyy-MM-dd HH:mm:ss") + "') AND AlarmStatus = '0' ");
                            if (drMCBreakDown.Count() > 0)
                            {
                                StatusStatus = "BREAK";
                            }
                            else
                            {
                                if (MCNameWhere == "Washing")
                                {
                                    StatusStatus = "IDLE";
                                }
                            }
                        }

                        if (StatusStatus == "RUN")
                        {                            
                            ColorLamp = "#e5a943";
                            if (hdMC.Value == "Model Change")
                            {
                                ColorLamp = "#ffffff"; //----------- color for Model Change
                            }
                            td.Attributes.Add("style", "background-color:"+ ColorLamp + ";");
                        }
                        else
                        {
                            //------------ Check Breakdown -----------
                            if (MCNameWhere != "Washing")
                            {
                                td.Attributes.Add("style", "background-color:#d2322d;");
                                ColorLamp = "#d2322d";
                            }
                            else if (MCNameWhere == "Washing")
                            {
                                if (StatusStatus == "BREAK")
                                {
                                    td.Attributes.Add("style", "background-color:#d2322d;");
                                    ColorLamp = "#d2322d";
                                }
                                else
                                {
                                    if (DateAcc > new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 20, 0))
                                    {
                                        td.Attributes.Add("style", "background-color:#45f960;");
                                        ColorLamp = "#45f960";
                                    }
                                    else
                                    {
                                        td.Attributes.Add("style", "background-color:#e5a943;");
                                        ColorLamp = "#e5a943";
                                    }
                                }
                            }
                        }
                    } // end check run
                    #endregion
                    if (ViewState["create"].ToString() == "YES")
                    {
                        dtLamp.Rows.Add(hdMC.Value, j, ColorLamp,hdMCCode.Value);
                    }
                    else
                    {
                        DataRow[] fillLamp = dtLamp.Select("MC = '" + hdMC.Value + "' AND index = '" + j + "'");
                        td.Attributes.Add("style", "background-color:" + fillLamp[0]["Lamp"].ToString() + "; ");
                    }
                    
                }//<-------- End If dtMCStatus for Mecha and Main ----------------
                else
                {                    
                    string MCNameWhere = "", McNo = "";
                    //-------------- Status Line Machine Rear Head ------------------
                    if (ViewState["line"].ToString() == "rh" || ViewState["line"].ToString() == "fh" || ViewState["line"].ToString() == "piston" || ViewState["line"].ToString() == "cd"
                         || ViewState["line"].ToString() == "cs")
                    {
                        #region fillter Machine name Lamp Status
                        //if (ViewState["line"].ToString() == "rh")
                        //{
                        //    switch (hdMC.Value)
                        //    {
                        //        case "Laser Marking": MCNameWhere = "Rear_Head_LaserMarking"; McNo = "1"; break;
                        //        case "Surface": MCNameWhere = "Rear_Head_Surface"; McNo = "4"; break;
                        //        case "Brush": MCNameWhere = "Rear_Head_Brushing"; McNo = "5"; break;
                        //        case "Internal 1": MCNameWhere = "Rear_Head_Internal_1"; McNo = "2"; break;
                        //        case "Internal 2": MCNameWhere = "Rear_Head_Internal_2"; McNo = "3"; break;
                        //        case "Honing": MCNameWhere = "*"; McNo = "0"; break;
                        //    }
                        //}
                        if (ViewState["line"].ToString() == "fh" || ViewState["line"].ToString() == "cd" || ViewState["line"].ToString() == "cs" || ViewState["line"].ToString() == "rh")
                        {
                            McNo = hdMCCode.Value;
                            //switch (hdMC.Value)
                            //{
                            //    case "Laser Marking": MCNameWhere = "Front_Head_Laser"; McNo = "7"; break;
                            //    case "Surface": MCNameWhere = "Front_Head_Surface"; McNo = "6"; break;
                            //    case "Brush": MCNameWhere = "Front_Head_Brushing"; McNo = "10"; break;
                            //    case "Internal 1": MCNameWhere = "Front_Head_Internal_No_1"; McNo = "8"; break;
                            //    case "Internal 2": MCNameWhere = "Front_Head_Internal_No_2"; McNo = "9"; break;
                            //    case "Horning": MCNameWhere = ""; McNo = "0"; break;
                            //}
                        }
                        else if (ViewState["line"].ToString() == "piston")
                        {
                            switch (hdMC.Value)
                            {
                                case "Laser Marking": MCNameWhere = "Piston_Laser"; McNo = "11"; break;
                                case "Surface": MCNameWhere = "Piston_Surface"; McNo = "12"; break;
                                case "Blade grinding No 1": MCNameWhere = ""; McNo = "0"; break;
                                case "Blade grinding No 2": MCNameWhere = ""; McNo = "0"; break;
                                case "Blade grinding No 3": MCNameWhere = ""; McNo = "0"; break;
                                case "Blade grinding No 4": MCNameWhere = ""; McNo = "0"; break;
                                case "Brush": MCNameWhere = "Piston_Brushing"; McNo = "15"; break;
                                case "External 1": MCNameWhere = ""; McNo = "0"; break;
                                case "External 2": MCNameWhere = ""; McNo = "0"; break;
                                case "External 3": MCNameWhere = ""; McNo = "0"; break;
                                case "External 4": MCNameWhere = ""; McNo = "0"; break;
                                case "Internal 1": MCNameWhere = "Piston_Internal_No_1"; McNo = "13"; break;
                                case "Internal 2": MCNameWhere = "Piston_Internal_No_2"; McNo = "14"; break;
                                case "Horning": MCNameWhere = ""; McNo = "0"; break;
                            }
                        }
                        //else if (ViewState["line"].ToString() == "cd")
                        //{
                            //McNo = hdMCCode.Value;
                            //switch (hdMC.Value)
                            //{
                            //    case "Cylinder Laser Marking": MCNameWhere = "Cylinder_Laser_Marking"; McNo = "18"; break;
                            //    case "Cylinder Surface Grinding No 1": MCNameWhere = "Cylinder_Surface_No_1"; McNo = "19"; break;
                            //    case "Cylinder Surface Grinding No 2": MCNameWhere = "Cylinder_Surface_No_2"; McNo = "20"; break;
                            //    case "Cylinder BoreID Grinding No 1": MCNameWhere = "Cylinder_BoreID_No_1"; McNo = "29"; break;
                            //    case "Cylinder BoreID Grinding No 2": MCNameWhere = "Cylinder_BoreID_No_2"; McNo = "30"; break;
                            //    case "Cylinder Bush Hole Grinding No 1": MCNameWhere = "Cylinder_Brushing_No_1"; McNo = "16"; break;
                            //    case "Cylinder Bush Hole Grinding No 2": MCNameWhere = "Cylinder_Brushing_No_2"; McNo = "17"; break;
                            //    case "Cylinder Bush Hole Grinding No 3": MCNameWhere = "Cylinder_Bush_Hole_Grinding_No_3"; McNo = "31"; break;
                            //    case "Cylinder_Brushing": MCNameWhere = "Cylinder_Brushing"; McNo = "32"; break;
                            //}
                        //}
                        //else if (ViewState["line"].ToString() == "cs")
                        //{
                            //McNo = hdMCCode.Value;
                            //switch (hdMC.Value)
                            //{
                            //    case "Crankshaft Laser Marking": MCNameWhere = "Crankshaft_Laser_Marking"; McNo = "21"; break;
                            //    case "Hardening": MCNameWhere = "*"; McNo = "33"; break;
                            //    case "Crankshaft Centerless Grinding No 1": MCNameWhere = "Crankshaft_Centerless_No_1"; McNo = "22"; break;
                            //    case "Crankshaft Centerless Grinding No 2": MCNameWhere = "Crankshaft_Centerless_No_2"; McNo = "23"; break;
                            //    case "Crankshaft Centerless Grinding No 3": MCNameWhere = "Crankshaft_Centerless_No_3"; McNo = "28"; break;
                            //    case "Pin grinding No 1": MCNameWhere = "Crankshaft_Pin_Grinding_No_1"; McNo = "26"; break;
                            //    case "Pin grinding No 2": MCNameWhere = "Crankshaft_Pin_Grinding_No_2"; McNo = "27"; break;
                            //    case "Crankshaft Thrust Grinding No 1": MCNameWhere = "Crankshaft_Thrust_Grinding_No_1"; McNo = "24"; break;
                            //    case "Crankshaft Thrust Grinding No 2": MCNameWhere = "Crankshaft_Thrust_Grinding_No_2"; McNo = "25"; break;
                            //}
                        //}
                        #endregion
                        
                        //------------- If check create Json Source Lamp YES -----------------
                        if (dtMCBreakDown.Rows.Count > 0 && ViewState["create"].ToString() == "YES")
                        {
                            #region Create Json YES 
                            string lastLamp2 = "";
                            DataRow[] _rowFillTime = new DataRow[] { };
                            if (hdMC.Value == "Model Change")
                            {
                                _rowFillTime = dtMCStatus.Select("cycle_start_time < " + timeStr + " AND cycle_end_time > " + timeEnd);
                                if (_rowFillTime.Length > 0)
                                {
                                    StatusLamp = "#2d38d1";
                                }
                                else
                                {
                                    StatusLamp = "#ffffff";
                                }
                            }
                            else
                            {
                                #region Fillter Status Lamp
                                string a = hdMC.Value;
                                string b = MCNameWhere;
                                //------------ Fillter Lamp Status -----------------
                                DataRow[] drMCBreakDown = dtMCBreakDown.Select("(UpdateLog >= '" + DateAcc.ToString("yyyy-MM-dd HH:mm:ss") + "' AND UpdateLog <= '"
                                    + DateAcc.AddSeconds(180).ToString("yyyy-MM-dd HH:mm:ss") + "') AND Mc_No = '" + McNo + "'", "UpdateLog DESC");

                                if (drMCBreakDown.Length > 0)
                                {
                                    //---- Check Manual Mode ---------
                                    if (drMCBreakDown[drMCBreakDown.Length - 1]["Mode_"].ToString() == "0") // Manual Mode is 0
                                    {
                                        StatusLamp = "#e5a943";// Orange
                                    }
                                    else
                                    {
                                        //--------- Auto Mode -----------
                                        switch (drMCBreakDown[drMCBreakDown.Length - 1]["Lamp_Status"].ToString())
                                        {
                                            case "0":
                                                StatusLamp = "#e5a943";// Orange
                                                break;
                                            case "1":
                                                StatusLamp = "#45f960";// Green
                                                break;
                                            case "2":
                                                StatusLamp = "#d2322d";// Red
                                                break;
                                        }
                                    }

                                    //-------- Check if 1 round time is more 1 Lamp status (1 Round have More than 1 Status) ------------
                                    if (drMCBreakDown.Length > 1)
                                    {
                                        //---- Check Manual Mode ---------
                                        if (drMCBreakDown[0]["Mode_"].ToString() == "0") // Manual Mode is 0
                                        {
                                            StatusLamp = "#e5a943";// Orange
                                        }
                                        else
                                        {
                                            //--------- Auto Mode -----------
                                            switch (drMCBreakDown[0]["Lamp_Status"].ToString())
                                            {
                                                case "0":
                                                    lastLamp2 = "#e5a943";
                                                    break;
                                                case "1":
                                                    lastLamp2 = "#45f960";
                                                    break;
                                                case "2":
                                                    lastLamp2 = "#d2322d";
                                                    break;
                                            }
                                        }                                        
                                    }
                                }
                                else
                                {
                                    #region Get Lamp last Day 
                                    if (DateAcc.TimeOfDay <= new TimeSpan(8, 30, 0))
                                    {
                                        //----------------- Get Lamp Status On Start Day form last Shift -------------------                                    
                                        sql.CommandText = "SELECT TOP (1) [Lamp_Status],[UpdateLog],al.[Mc_No],mstr.Mc_Name" +
                                            " FROM [Scada_AlarmMC] al LEFT JOIN [Scada_AlarmMC_mst] mstr ON al.Mc_No = mstr.Mc_No" +
                                            " WHERE (UpdateLog >= '" + (DateTime.Now.Date + new TimeSpan(7, 59, 59)).AddHours(-8).ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                                            " AND UpdateLog <= '" + (DateTime.Now.Date + new TimeSpan(7, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') AND mstr.Mc_No = '" + McNo + "'" +
                                            " order by UpdateLog DESC";
                                        sql.CommandTimeout = 2000;
                                        DataTable dt = new DataTable();
                                        SqlDataAdapter da = new SqlDataAdapter(sql);
                                        DataSet ds = new DataSet();
                                        try
                                        {
                                            da.Fill(ds, "table0");
                                            dt = ds.Tables["table0"];
                                        }
                                        catch { }

                                        if (dt.Rows.Count > 0)
                                        {
                                            switch (dt.Rows[0]["Lamp_Status"].ToString())
                                            {
                                                case "0":
                                                    StatusLamp = "#e5a943";
                                                    break;
                                                case "1":
                                                    StatusLamp = "#45f960";
                                                    break;
                                                case "2":
                                                    StatusLamp = "#d2322d";
                                                    break;
                                            }
                                        }
                                        //----------------- Get Lamp Status On Start Day form last Shift -------------------
                                    }
                                    #endregion
                                }
                                #endregion
                            }

                            //-------- DataTable Lamp for Create Json Source File -----------------
                            dtLamp.Rows.Add(hdMC.Value, j, StatusLamp,hdMCCode.Value);
                            td.Attributes.Add("style", "background-color:" + StatusLamp + ";");
                            StatusLamp = lastLamp2 != "" ? lastLamp2 : StatusLamp;
                            #endregion
                        }//------------- End If check create Json Source Lamp YES -----------------
                        else
                        {
                            DataRow[] fillLamp = dtLamp.Select("MCNo = '" + hdMCCode.Value + "' AND index = '" + j + "'");
                            td.Attributes.Add("style", "background-color:" + fillLamp[0]["Lamp"].ToString() + ";");
                        }                                                
                    }                   
                }

                if (DateAcc.TimeOfDay > DateTime.Now.TimeOfDay)
                {
                    td.Attributes.Add("style", "background-color:#ffffff;");
                }
                
                DateAcc = DateAcc.AddSeconds(180);

                idxColLamp++;
            }

            idxRowLamp++;
        }

        //----------- Create Json Source ---------------
        if (ViewState["create"].ToString() == "YES")
        {
            string JsonLamp = oMCStatusLastDay.ConvertDataTabletoString(dtLamp);
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/Production/EffSource/Lamp"+ Shift + ViewState["line"].ToString() + ".json"), JsonLamp);
        }
        return "";
    }

    /*
    public string GenMachineStatus()
    {
        //--------------- Data Plan Eff Actual ------------------
        CGetDataGraph oTarget = new CGetDataGraph();
        List<MDataGraph> oListData = new List<MDataGraph>();
        //oListData = oTarget.GetPlan(300, "", ViewState["line"].ToString(), "", "", "", "");
        //--------------- Data Plan Eff Actual ------------------

        DataTable dtMCBreakDown = new DataTable();

        string Shift = "D";
        DateTime DateCurr = DateTime.Now;
        DateTime DateAcc = DateCurr.Date;
        // ---- Day Shift ----
        if (DateTime.Now.Hour >= 8 && DateTime.Now.Hour < 20)
        {
            DateAcc = DateCurr + new TimeSpan(8, 0, 0);
            Shift = "D";
        }
        // ---- Night Shift ----
        else
        {
            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
            {
                DateAcc = DateCurr.AddDays(-1).Date + new TimeSpan(20, 0, 0);
                Shift = "N";
            }
            else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
            {
                DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
                Shift = "N";
            }
        }

        //----------- Craete Source Status Lamp ----------------
        string JsonLampStatus = "";
        bool CreatedFile = false;
        DataTable dtLamp = new DataTable();
        dtLamp.Columns.Add("MC", typeof(string));
        dtLamp.Columns.Add("index", typeof(int));
        dtLamp.Columns.Add("Lamp", typeof(string));

        // ------ Get Break Down Lamp Status -------
        dtMCBreakDown = oMCStatusLastDay.GetDTMachineBreakDown(Shift, DateCurr, ViewState["line"].ToString());

        SqlConnection conn = new SqlConnection("Data Source=costy;Initial Catalog=dbIoTFac3;Persist Security Info=True;User ID=sa;Password=decjapan;");
        SqlCommand sql = new SqlCommand();
        sql.Connection = conn;
        int idxRowLamp = 0, idxColLamp = 0;
        for (int i = 0; i < rptMachine.Items.Count; i++)
        {
            List<MDMachineStatus> oList = new List<MDMachineStatus>();
            Repeater rptCol = rptMachine.Items[i].FindControl("rptTableMachine") as Repeater;
            HiddenField hdMC = rptMachine.Items[i].FindControl("hdmcName") as HiddenField;
            string LineName = "";
            
            if (Shift == "D")
            {
                DateAcc = DateTime.Now.Date + new TimeSpan(8, 0, 0);
            }
            else
            {
                if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 7)
                {
                    DateAcc = DateTime.Now.AddDays(-1).Date + new TimeSpan(20, 0, 0);
                }
                else if (DateTime.Now.Hour >= 20 && DateTime.Now.Hour <= 23)
                {
                    DateAcc = DateTime.Now.Date + new TimeSpan(20, 0, 0);
                }
            }

            DataTable dtMCStatus = new DataTable();

            if (hdMC.Value != "Washing Machine")
            {
                #region Get Machine Status have Work for ASsy Line 
                if (ViewState["line"].ToString() == "mecha")
                {
                    dtMCStatus = oMCStatusLastDay.GetMachineMechaStatus(DateAcc, DateCurr, hdMC.Value, false);
                    LineName = "3AME5";
                }
                else if (ViewState["line"].ToString() == "casing")
                {
                    dtMCStatus = oMCStatusLastDay.GetMachineCasingStatus(DateAcc, DateCurr, hdMC.Value, false);
                    LineName = "3ACP5";
                }
                else if (ViewState["line"].ToString() == "motor")
                {
                    dtMCStatus = oMCStatusLastDay.GetMachineMotorStatus(DateAcc, DateCurr, hdMC.Value, false);
                    LineName = "3AST3";
                }
                else if (ViewState["line"].ToString() == "piston")
                {
                    //dtMCStatus = oMCStatusLastDay.GetMachinePistonStatus(DateAcc, DateCurr, hdMC.Value, false);
                    LineName = "3MPI11";
                }
                else if (ViewState["line"].ToString() == "fh")
                {
                    LineName = "3MFH5";
                    //dtMCStatus = oMCStatusLastDay.GetMachineFrontheadStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                else if (ViewState["line"].ToString() == "cs")
                {
                    LineName = "3MCS9";
                    //dtMCStatus = oMCStatusLastDay.GetMachineCrankshaftStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                else if (ViewState["line"].ToString() == "cd")
                {
                    LineName = "3MCY12";
                    //dtMCStatus = oMCStatusLastDay.GetMachineCylinderStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                else if (ViewState["line"].ToString() == "rh")
                {
                    LineName = "3MRH5";
                    //dtMCStatus = oMCStatusLastDay.GetMachineRearheadStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                else if (ViewState["line"].ToString() == "fn")
                {
                    LineName = "3AFI9";
                    dtMCStatus = oMCStatusLastDay.GetMachineFinalStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                else
                {
                    LineName = "3AMA5";
                    dtMCStatus = oMCStatusLastDay.GetMachineStatus(DateAcc, DateCurr, hdMC.Value, false);
                }
                #endregion
            }

            //---------- Get Machine Status -------------
            string StatusStatus = "RUN";
            string StatusLamp = "";
            for (int j = 0; j < rptCol.Items.Count; j++)
            {
                HtmlTableCell td = (HtmlTableCell)rptCol.Items[j].FindControl("col");

                //--------- Get Cycle start stop -----------
                string timeStr = DateAcc.TimeOfDay.ToString().Replace(":", "");
                string timeEnd = DateAcc.AddSeconds(180).TimeOfDay.ToString().Replace(":", "");
                //if (dtMCStatus.Rows.Count > 0 || hdMC.Value == "Washing Machine")
                if (ViewState["line"].ToString() == "main" || ViewState["line"].ToString() == "mecha" || ViewState["line"].ToString() == "" || ViewState["line"].ToString() == "casing")
                {
                    #region
                    //---------- Get Status Breakdown -----------
                    string MachineId = "";
                    string LineId = "";
                    string StatusBreak = "NO";
                    string ColorLamp = "";

                    McAndLine oMcNameAndLineId = new McAndLine();
                    oMcNameAndLineId = GetMachineIDAndLineId(hdMC.Value);
                    MachineId = oMcNameAndLineId.Mc;
                    LineId = oMcNameAndLineId.Line;

                    //----------------- Get Machine RUN and have product ---------------------
                    DataRow[] _rowFillTime = new DataRow[] { };

                    if (hdMC.Value != "Washing Machine")
                    {
                        if (ViewState["line"].ToString() == "mecha")
                        {
                            _rowFillTime = dtMCStatus.Select("cycle_start_time >= " + timeStr + " AND cycle_end_time < " + timeEnd);
                        }
                        else if (ViewState["line"].ToString() == "casing" || ViewState["line"].ToString() == "motor")
                        {
                            string dateEnd = DateCurr.ToString("yyyy/MM/dd") + " " + DateTime.Now.ToString("HH:mm:ss");
                            try
                            {
                                _rowFillTime = dtMCStatus.Select("data_mfgdate >= " + DateAcc);
                            }
                            catch { }
                        }
                        else
                        {
                            try
                            {
                                _rowFillTime = dtMCStatus.Select("CycleStartTime >= " + timeStr + " AND CycleEndTime < " + timeEnd);
                            }
                            catch { }
                        }
                    }

                    if (_rowFillTime.Length > 0)
                    {
                        ColorLamp = "#45f960";
                        //td.Attributes.Add("style", "background-color:#45f960;");
                        StatusStatus = "RUN";
                    }
                    else
                    {
                        //------------Get Status Alarm-----------------
                        string MCNameWhere = "";

                        if (ViewState["line"].ToString() == "mecha" || ViewState["line"].ToString() == "" || ViewState["line"].ToString() == "main")
                        {
                            switch (hdMC.Value)
                            {
                                case "Washing Machine": MCNameWhere = "Washing"; break;
                                case "Crank Shaft": MCNameWhere = "CS_MEASURING"; break;
                                case "Cylinder": MCNameWhere = "CY_MEASURING"; break;
                                case "Piston": MCNameWhere = "PT_MEASURING"; break;
                                case "Front Head": MCNameWhere = "FH_MEASURING"; break;
                                case "Rear Head": MCNameWhere = "RH_MEASURING"; break;
                                case "Cylinder Centering": MCNameWhere = "CYLINDER_CENTERING"; break;
                                case "Rear Centering": MCNameWhere = "REAR_CENTERING"; break;
                                case "Tourque Check": MCNameWhere = ""; break;
                                case "Rotor Yakibame": MCNameWhere = "Rotor Yaki : AMA-0120"; break;
                                case "Magnetize": MCNameWhere = "Magnetzing : AMA-0122"; break;
                                case "Pipe Yakibame": MCNameWhere = "PIPE YAKI : AMA-0117"; break;
                                case "TackWelding": MCNameWhere = "Tack Welding : AMA-0130"; break;
                                case "Magnet Center": MCNameWhere = "Megnet_Center"; break;
                                case "Air Gap": MCNameWhere = ""; break;
                                case "Electrical Check": MCNameWhere = "Connecting Check : AMA-0132"; break;
                                case "Top Bottom Welding 1": MCNameWhere = "Bottom&Top Welding No1"; break;
                                case "Top Bottom Welding 2": MCNameWhere = "Bottom&Top Welding No2"; break;
                            }
                        }

                        if (dtMCBreakDown.Rows.Count > 0)
                        {
                            DataRow[] drMCBreakDown = dtMCBreakDown.Select(" MCName = '" + MCNameWhere + "' AND (StartAlarm >= '" + DateAcc.ToString("yyyy-MM-dd HH:mm:ss")
                                + "' AND EndAlarm <= '" + DateAcc.AddSeconds(180).ToString("yyyy-MM-dd HH:mm:ss") + "') AND AlarmStatus = '0' ");
                            if (drMCBreakDown.Count() > 0)
                            {
                                StatusStatus = "BREAK";
                            }
                            else
                            {
                                if (MCNameWhere == "Washing")
                                {
                                    StatusStatus = "IDLE";
                                }
                            }
                        }

                        if (StatusStatus == "RUN")
                        {
                            //td.Attributes.Add("style", "background-color:#e5a943;");
                            ColorLamp = "#e5a943";
                        }
                        else
                        {
                            if (MCNameWhere != "Washing")
                            {
                                //td.Attributes.Add("style", "background-color:#d2322d;");
                                ColorLamp = "#d2322d";
                            }
                            else if (MCNameWhere == "Washing")
                            {
                                if (StatusStatus == "BREAK")
                                {
                                    //td.Attributes.Add("style", "background-color:#d2322d;");
                                    ColorLamp = "#d2322d";
                                }
                                else
                                {
                                    if (DateAcc > new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 20, 0))
                                    {
                                        //td.Attributes.Add("style", "background-color:#45f960;");
                                        ColorLamp = "#45f960";
                                    }
                                    else
                                    {
                                       // td.Attributes.Add("style", "background-color:#e5a943;");
                                        ColorLamp = "#e5a943";
                                    }
                                }
                            }
                        }
                    } // end check run
                    #endregion
                    if (!CreatedFile)
                    {
                        dtLamp.Rows.Add(hdMC.Value, j, ColorLamp);
                    }
                    else
                    {
                        //DataRow[] fillLamp = dtLamp.Select("MC = '" + hdMC.Value + "' AND index = '" + j + "'");
                        //td.Attributes.Add("style", "background-color:" + fillLamp[0]["Lamp"].ToString() + "; ");
                    }

                }//<-------- End If dtMCStatus for Mecha and Main ----------------
                else
                {
                    string MCNameWhere = "";
                    //-------------- Status Line Machine Rear Head ------------------
                    if (ViewState["line"].ToString() == "rh" || ViewState["line"].ToString() == "fh" || ViewState["line"].ToString() == "piston" || ViewState["line"].ToString() == "cd"
                         || ViewState["line"].ToString() == "cs")
                    {
                        #region fillter Machine name 
                        if (ViewState["line"].ToString() == "rh")
                        {
                            switch (hdMC.Value)
                            {
                                case "Laser Marking": MCNameWhere = "RH_LaserMarking"; break;
                                case "Surface": MCNameWhere = "RH_Surface"; break;
                                case "Brush": MCNameWhere = "RH_Brushing"; break;
                                case "Internal 1": MCNameWhere = "RH_Internal1"; break;
                                case "Internal 2": MCNameWhere = "RH_Internal2"; break;
                            }
                        }
                        else if (ViewState["line"].ToString() == "fh")
                        {
                            switch (hdMC.Value)
                            {
                                case "Laser Marking": MCNameWhere = "FH_Laser"; break;
                                case "Surface": MCNameWhere = "FH_Surface"; break;
                                case "Brush": MCNameWhere = "FH_Brushing"; break;
                                case "Internal 1": MCNameWhere = "FH_Internal_No1"; break;
                                case "Internal 2": MCNameWhere = "FH_Internal_No2"; break;
                            }
                        }
                        else if (ViewState["line"].ToString() == "piston")
                        {
                            switch (hdMC.Value)
                            {
                                case "Laser Marking": MCNameWhere = "PI_Laser"; break;
                                case "Surface": MCNameWhere = "PI_Surface"; break;
                                case "Brush": MCNameWhere = "PI_Brushing"; break;
                                case "Internal 1": MCNameWhere = "PI_Internal_No1"; break;
                                case "Internal 2": MCNameWhere = "PI_Internal_No2"; break;
                            }
                        }
                        else if (ViewState["line"].ToString() == "cd")
                        {
                            switch (hdMC.Value)
                            {
                                case "Cylinder Laser Marking": MCNameWhere = "CY_Laser"; break;
                                case "Cylinder Surface Grinding No 1": MCNameWhere = "CY_Surface_No1"; break;
                                case "Cylinder Surface Grinding No 2": MCNameWhere = "CY_Surface_No2"; break;
                                case "Cylinder BoreID Grinding No 1": MCNameWhere = ""; break;
                                case "Cylinder BoreID Grinding No 2": MCNameWhere = ""; break;
                                case "Cylinder Bush Hole Grinding No 1": MCNameWhere = "CY_Brushing_No1"; break;
                                case "Cylinder Bush Hole Grinding No 2": MCNameWhere = "CY_Brushing_No2"; break;
                                case "Cylinder Bush Hole Grinding No 3": MCNameWhere = ""; break;
                                case "Cylinder_Brushing": MCNameWhere = ""; break;
                            }
                        }
                        else if (ViewState["line"].ToString() == "cs")
                        {
                            switch (hdMC.Value)
                            {
                                case "Crankshaft Laser": MCNameWhere = "CS_Laser"; break;
                                case "Hardening": MCNameWhere = "*"; break;
                                case "Crankshaft Centerless Grinding No 1": MCNameWhere = "CS_Centerless_No1"; break;
                                case "Crankshaft Centerless Grinding No 2": MCNameWhere = "CS_Centerless_No2"; break;
                                case "Crankshaft Centerless Grinding No 3": MCNameWhere = "*"; break;
                                case "Pin grinding No 1": MCNameWhere = "*"; break;
                                case "Pin grinding No 2": MCNameWhere = "*"; break;
                                case "Crankshaft Thrust Grinding No 1": MCNameWhere = "*"; break;
                                case "Crankshaft Thrust Grinding No 2": MCNameWhere = "*"; break;
                                case "Crankshaft Brushing": MCNameWhere = "*"; break;
                            }
                        }
                        #endregion

                        if (dtMCBreakDown.Rows.Count > 0 && !CreatedFile)
                        {
                            //------------ Fillter Lamp Status -----------------
                            DataRow[] drMCBreakDown = dtMCBreakDown.Select("UpdateLog >= '" + DateAcc.ToString("yyyy-MM-dd HH:mm:ss") + "' AND UpdateLog <= '"
                                + DateAcc.AddSeconds(180).ToString("yyyy-MM-dd HH:mm:ss") + "' AND Mc_Name = '" + MCNameWhere + "'", "UpdateLog DESC");

                            if (drMCBreakDown.Length > 0)
                            {
                                switch (drMCBreakDown[0]["Lamp_Status"].ToString())
                                {
                                    case "0":
                                        StatusLamp = "#e5a943";
                                        break;
                                    case "1":
                                        StatusLamp = "#45f960";
                                        break;
                                    case "2":
                                        StatusLamp = "#d2322d";
                                        break;
                                }
                            }
                            else
                            {
                                if (DateAcc.TimeOfDay <= new TimeSpan(8, 30, 0))
                                {
                                    //----------------- Get Lamp Status On Start Day form last Shift -------------------                                    
                                    sql.CommandText = "SELECT TOP (1) [Lamp_Status],[UpdateLog],al.[Mc_No],mstr.Mc_Name" +
                                        " FROM [Scada_AlarmMC] al LEFT JOIN [Scada_AlarmMC_mst] mstr ON al.Mc_No = mstr.Mc_No" +
                                        " WHERE (UpdateLog >= '" + (DateTime.Now.Date + new TimeSpan(7, 59, 59)).AddHours(-5).ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                                        " AND UpdateLog <= '" + (DateTime.Now.Date + new TimeSpan(7, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') AND mstr.Mc_Name = '" + MCNameWhere + "'" +
                                        " order by UpdateLog DESC";
                                    sql.CommandTimeout = 2000;
                                    DataTable dt = new DataTable();
                                    SqlDataAdapter da = new SqlDataAdapter(sql);
                                    DataSet ds = new DataSet();
                                    try
                                    {
                                        da.Fill(ds, "table0");
                                        dt = ds.Tables["table0"];
                                    }
                                    catch { }

                                    if (dt.Rows.Count > 0)
                                    {
                                        switch (dt.Rows[0]["Lamp_Status"].ToString())
                                        {
                                            case "0":
                                                StatusLamp = "#e5a943";
                                                break;
                                            case "1":
                                                StatusLamp = "#45f960";
                                                break;
                                            case "2":
                                                StatusLamp = "#d2322d";
                                                break;
                                        }
                                    }
                                    //----------------- Get Lamp Status On Start Day form last Shift -------------------
                                }
                            }


                            dtLamp.Rows.Add(hdMC.Value, j, StatusLamp);
                            //td.Attributes.Add("style", "background-color:" + StatusLamp + ";");
                        }
                        else
                        {
                            //DataRow[] fillLamp = dtLamp.Select("MC = '" + hdMC.Value + "' AND index = '" + j + "'");
                            //td.Attributes.Add("style", "background-color:" + fillLamp[0]["Lamp"].ToString() + "; ");
                        }
                    }
                    //-------------- Status Line Machine -----------------
                    //else
                    //{
                    //    td.Attributes.Add("style", "background-color:#e5a943;");
                    //}                    
                }

                if (DateAcc > DateTime.Now)
                {
                    //td.Attributes.Add("style", "background-color:#ffffff;");
                }

                DateAcc = DateAcc.AddSeconds(180);

                idxColLamp++;
            }

            idxRowLamp++;
        }

        string JsonLamp = oMCStatusLastDay.ConvertDataTabletoString(dtLamp);
        File.WriteAllText(HttpContext.Current.Server.MapPath("~/Production/EffSource/Lamp" + Shift + "" + ViewState["line"].ToString() + ".json"), JsonLamp);
        return "";
    }
    */

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lbLastUpdate.Text = "Last Update : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        if (DateTime.Now.TimeOfDay >= TimeSpan.Parse("20:00:01") && DateTime.Now.TimeOfDay <= TimeSpan.Parse("20:05:00"))
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        else if (DateTime.Now.TimeOfDay >= TimeSpan.Parse("08:00:01") && DateTime.Now.TimeOfDay <= TimeSpan.Parse("08:05:00"))
        {
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        else
        {
            GetMachineStatus();
        }
    }
    protected void Timer2_Tick(object sender, EventArgs e)
    {
    }
    protected void rptTableMachine_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

        }
    }
    //--------- Model for get value MachineId And LineId ------------
    class McAndLine
    {
        public string Mc { get; set; }
        public string Line { get; set; }
    }
    private McAndLine GetMachineIDAndLineId(string MachineName)
    {
        McAndLine McLine = new McAndLine();

        if (ViewState["line"].ToString() == "mecha")
        {
            #region
            if (MachineName == "Crank Shaft")
            {
                McLine.Mc = "MC-17050042";
            }
            else if (MachineName == "Cylinder")
            {
                McLine.Mc = "MC-17050029";
            }
            else if (MachineName == "Piston")
            {
                McLine.Mc = "MC-17050028";
            }
            else if (MachineName == "Front Head")
            {
                McLine.Mc = "MC-17050044";
            }
            else if (MachineName == "Rear Head")
            {
                McLine.Mc = "MC-17050043";
            }
            else if (MachineName == "Cylinder Centering")
            {
                McLine.Mc = "MC-17050045";
            }
            else if (MachineName == "Rear Centering")
            {
                McLine.Mc = "MC-17050046";
            }
            else if (MachineName == "Tourque Check")
            {
                McLine.Mc = "MC-17050030";
            }
            McLine.Line = "LN-1701";
            #endregion
        }
        else if (ViewState["line"].ToString() == "casing")
        {
            #region
            if (MachineName == "Pipe Marking")
            {
                McLine.Mc = "MC-17050004";
            }
            else if (MachineName == "Pipe Plasma Welding")
            {
                McLine.Mc = "MC-17050007";
            }
            else if (MachineName == "Pipe Punch Machine")
            {
                McLine.Mc = "MC-99999999999";
            }
            else if (MachineName == "Pipe ID Check")
            {
                McLine.Mc = "MC-99999999999";
            }
            McLine.Line = "LN-1709";
            #endregion
        }
        else if (ViewState["line"].ToString() == "motor")
        {
            #region
            if (MachineName == "Stator Transport Unit Input Side")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Stator Transport Unit Discharge Side")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Stator Common Transport Input Side")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Stator Common Transport Discharg Side")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Stator Insulator Laser Marking")
            {
                McLine.Mc = "MC-17060036";
            }
            else if (MachineName == "Stator Transport Winding Input Side")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Stator Winding No1")
            {
                McLine.Mc = "MC-17060037";
            }
            else if (MachineName == "Stator Charecteristic Measurement")
            {
                McLine.Mc = "MC-17060040";
            }
            McLine.Line = "LN-1708";
            #endregion
        }
        else if (ViewState["line"].ToString() == "piston")
        {
            #region
            if (MachineName == "Piston Laser")
            {
                McLine.Mc = "999999999";
            }
            else if (MachineName == "Piston Surface Grinding")
            {
                McLine.Mc = "MC-17060022";
            }
            else if (MachineName == "Piston Blade Grinding 1")
            {
                McLine.Mc = "MC-17060023";
            }
            else if (MachineName == "Piston Blade Grinding 2")
            {
                McLine.Mc = "MC-17060024";
            }
            else if (MachineName == "Piston Brushing")
            {
                McLine.Mc = "MC-17060029";
            }
            McLine.Line = "LN-1705";
            #endregion
        }
        else if (ViewState["line"].ToString() == "fh")
        {
            #region
            if (MachineName == "Front Head Laser")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Front Head Internal Grinding No 1")
            {
                McLine.Mc = "MC-17060014";
            }
            else if (MachineName == "Front Head Internal Grinding No 2")
            {
                McLine.Mc = "MC-17060015";
            }
            else if (MachineName == "Front Head Surface Grinding")
            {
                McLine.Mc = "MC-17060013";
            }
            else if (MachineName == "Front Head Brushing")
            {
                McLine.Mc = "MC-17060016";
            }
            McLine.Line = "LN-1713";
            #endregion
        }
        else if (ViewState["line"].ToString() == "cs")
        {
            #region
            if (MachineName == "Crankshaft Laser")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Crankshaft Thrust Grinding No 1")
            {
                McLine.Mc = "MC-17060006";
            }
            else if (MachineName == "Crankshaft Thrust Grinding No 2")
            {
                McLine.Mc = "MC-9999999";
            }
            else if (MachineName == "Crankshaft Centerless Grinding No 1")
            {
                McLine.Mc = "MC-17060003";
            }
            else if (MachineName == "Crankshaft Centerless Grinding No 2")
            {
                McLine.Mc = "MC-17060004";
            }
            else if (MachineName == "Crankshaft Brushing")
            {
                McLine.Mc = "MC-9999999";
            }
            McLine.Line = "LN-1702";
            #endregion
        }
        else if (ViewState["line"].ToString() == "cd")
        {
            #region
            if (MachineName == "Cylinder Laser Marking")
            {
                McLine.Mc = "999999";
            }
            else if (MachineName == "Cylinder Surface Grinding No 1")
            {
                McLine.Mc = "MC-17060007";
            }
            else if (MachineName == "Cylinder Surface Grinding No 2")
            {
                McLine.Mc = "MC-999999";
            }
            else if (MachineName == "Cylinder BoreID Grinding No 1")
            {
                McLine.Mc = "MC-17060008";
            }
            else if (MachineName == "Cylinder BoreID Grinding No 2")
            {
                McLine.Mc = "MC-17060009";
            }
            else if (MachineName == "Cylinder Bush Hole Grinding No 1")
            {
                McLine.Mc = "MC-17060010";
            }
            else if (MachineName == "Cylinder Bush Hole Grinding No 2")
            {
                McLine.Mc = "MC-17060011";
            }
            else if (MachineName == "Cylinder Bush Hole Grinding No 3")
            {
                McLine.Mc = "MC-999999";
            }
            else if (MachineName == "Cylinder_Brushing")
            {
                McLine.Mc = "MC-17060012";
            }
            McLine.Line = "LN-1703";
            #endregion
        }
        else if (ViewState["line"].ToString() == "rh")
        {
            #region
            if (MachineName == "Rear Head Laser")
            {
                McLine.Mc = "99999";
            }
            else if (MachineName == "Rear Head Surface")
            {
                McLine.Mc = "MC-17060030";
            }
            else if (MachineName == "Rear Head Brush")
            {
                McLine.Mc = "MC-17060033";
            }
            McLine.Line = "LN-1706";
            #endregion
        }
        else if (ViewState["line"].ToString() == "fn")
        {
            #region
            if (MachineName == "Running Test No 1")
            {
                McLine.Mc = "MC-17060052";
            }
            else if (MachineName == "Running Test No 2")
            {
                McLine.Mc = "MC-17060044";
            }
            else if (MachineName == "Running Test No 3")
            {
                McLine.Mc = "MC-17060049";
            }
            else if (MachineName == "Running Test No 4")
            {
                McLine.Mc = "MC-17060051";
            }
            else if (MachineName == "Oil Filling")
            {
                McLine.Mc = "MC-17060048";
            }
            else if (MachineName == "Weight Check")
            {
                McLine.Mc = "MC-9999999";
            }
            McLine.Line = "LN-1710";
            #endregion
        }
        else
        {
            #region
            if (MachineName == "Rotor Yakibame")
            {
                McLine.Mc = "MC-17060056";
            }
            else if (MachineName == "Pipe Yakibame")
            {
                McLine.Mc = "MC-17060053";
            }
            else if (MachineName == "Magnetize")
            {
                McLine.Mc = "MC-17060058";
            }
            else if (MachineName == "Magnet Center")
            {
                McLine.Mc = "MC-17060059";
            }
            else if (MachineName == "Air Gap")
            {
                McLine.Mc = "MC-999999999";
            }
            else if (MachineName == "Electrical Check")
            {
                McLine.Mc = "MC-999999999";
            }
            else if (MachineName == "TackWelding")
            {
                McLine.Mc = "MC-999999999";
            }
            else if (MachineName == "Top Bottom Welding")
            {
                McLine.Mc = "MC-999999999";
            }
            else
            {
                McLine.Mc = "MC-999999999";
            }
            McLine.Line = "LN-1701";
            #endregion
        }

        return McLine;
    }    
    public void InsertEfficeincyLog (string DataType,int Data,string DataOther,DateTime TimeIns,string Line)
    {
        string Shift = "D";
        string TimeRange = TimeIns.ToString("HH:mm") + "-" + TimeIns.AddMinutes(3).ToString("HH:mm");
        if (TimeIns.Hour >= 8 && TimeIns.Hour < 20)
        {
            Shift = "D";
        }
        else
        {
            Shift = "N";
        }

        if (TimeIns.AddMinutes(3) <= DateTime.Now)
        {
            //------------- Get Data Time Header (T001 - T240) ------------
            string ColT = "T001";
            SqlCommand sqlTimeHeader = new SqlCommand();
            sqlTimeHeader.CommandText = "SELECT * FROM [EfficeincyTimeHeader] WHERE Shift = '" + Shift + "' AND Time = '" + TimeRange + "'";
            DataTable dtHead = QueryIoTFac3Costy(sqlTimeHeader);
            if (dtHead.Rows.Count > 0)
            {
                ColT = dtHead.Rows[0]["TimeId"].ToString();
            }

            SqlCommand sqlCheck = new SqlCommand();
            sqlCheck.CommandText = "SELECT [Date] FROM [EfficeincyLog] WHERE Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND DataType = '" + DataType + "'"+
                " AND Line = '" + Line + "' AND Shift = '" + Shift + "'";
            DataTable dtCheck = QueryIoTFac3Costy(sqlCheck);
            if (dtCheck.Rows.Count > 0)
            {
                SqlCommand sqlDuppicate = new SqlCommand();
                sqlCheck.CommandText = "SELECT [Date] FROM [EfficeincyLog] WHERE Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND " + ColT + " != ''"+
                    " AND DataType = '" + DataType + "' Line = '" + Line + "' AND Shift = '" + Shift + "'";
                DataTable dtDup = QueryIoTFac3Costy(sqlDuppicate);
                if (dtDup.Rows.Count <= 0)
                {
                    //---------------- Update log -----------------
                    SqlCommand sqlUpdate = new SqlCommand();
                    sqlUpdate.CommandText = "UPDATE [EfficeincyLog] SET DataType = '" + DataType + "'," + ColT + " = '" + Data + "' "+
                        " WHERE DataType = '" + DataType + "' AND Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND Line = '" + Line + "' AND Shift = '" + Shift + "'";
                    ExcecuteIoTFac3(sqlUpdate);
                }                
            }
            else
            {
                //-------------- Insert new log ---------------
                SqlCommand sqlIns = new SqlCommand();
                sqlIns.CommandText = "INSERT INTO [EfficeincyLog] (Date,Line,DataType,Shift,"+ColT+") VALUES "+
                    "('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Line + "', '" + DataType + "','" + Shift + "','" + Data + "')";
                ExcecuteIoTFac3(sqlIns);
            }
        }        
    
    }

    SqlConnection connFac3Costy = new SqlConnection("Data Source=costy;Initial Catalog=dbIoTFac3;Persist Security Info=True;User ID=sa;Password=decjapan;");
    private DataTable QueryIoTFac3Costy(SqlCommand sql)
    {                
        sql.Connection = connFac3Costy;
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        try
        {
            da.Fill(ds, "table0");
            dt = ds.Tables["table0"];
        }
        catch { }

        return dt;
    }

    private void ExcecuteIoTFac3(SqlCommand sql)
    {
        sql.Connection = connFac3Costy;
        connFac3Costy.Open();
        sql.ExecuteNonQuery();
        connFac3Costy.Close();
    }
    //private List<Emp> GetEmployeeOfLine()
    //{
    //    string BoardID = "301";
    //    if (ViewState["line"] != null)
    //    {
    //        if (ViewState["line"].ToString() == "mecha")
    //        {
    //            BoardID = "302";
    //        }
    //        else if (ViewState["line"].ToString() == "casing")
    //        {
    //            BoardID = "312";
    //        }
    //        else if (ViewState["line"].ToString() == "motor")
    //        {
    //            BoardID = "310";
    //        }
    //        else if (ViewState["line"].ToString() == "piston")
    //        {
    //            BoardID = "308";
    //        }
    //        else if (ViewState["line"].ToString() == "fh")
    //        {
    //            BoardID = "307";
    //        }
    //        else if (ViewState["line"].ToString() == "cs")
    //        {
    //            BoardID = "306";
    //        }
    //        else if (ViewState["line"].ToString() == "cd")
    //        {
    //            BoardID = "305";
    //        }
    //        else if (ViewState["line"].ToString() == "rh")
    //        {
    //            BoardID = "304";
    //        }
    //        else if (ViewState["line"].ToString() == "fn")
    //        {
    //            BoardID = "303";
    //        }
    //        else
    //        {
    //            BoardID = "301";
    //        }
    //    }

    //    //---------------- get employee info from service HR ------------------
    //    var AryMan = oEm.GetCheckEmployeeWorkingTimeByPDLine(BoardID, DateTime.Now);
    //    List<Emp> oListEmp = new List<Emp>();

    //    foreach (EmployeePDWorkTimeInfo _EmpInfo in AryMan)
    //    {           
    //        if (_EmpInfo.DataWStatus == "TRUE")
    //        {
    //            Emp _Item = new Emp();
    //            _Item.EmpCode = _EmpInfo.DataEmpCode;
    //            _Item.FirstName = _EmpInfo.DataFName + "." + _EmpInfo.DataLName.Substring(0, 1) + " (" + _EmpInfo.DataPosition + ")";
    //            _Item.LastName = _EmpInfo.DataLName;
    //            _Item.Position = _EmpInfo.DataPosition;
    //            _Item.WorkDate = _EmpInfo.DataWDate;
    //            _Item.Status = _EmpInfo.DataWStatus == "TRUE" ? "WORK" : "LEAVE";
    //            _Item.LinkPic = "http://dcidmc.dci.daikin.co.jp/PICTURE/" + _EmpInfo.DataEmpCode + ".JPG";
    //            oListEmp.Add(_Item);   
    //        }            
    //    }

    //    if (oListEmp.Count > 0)
    //    {
    //        rptEmp.DataSource = oListEmp;
    //        rptEmp.DataBind();
    //    }
    //    return oListEmp;
    //}

    
}