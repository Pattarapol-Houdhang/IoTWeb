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

public partial class PDMeeting : System.Web.UI.Page
{
    //CGenControl oGenControl = new CGenControl();
    CGenGraph oGenGraph = new CGenGraph();
    ConnectDB oConn = new ConnectDB();
    ConnectDBIoTServerTon oConnIoT = new ConnectDBIoTServerTon();
    CGetMachineStatus oMCStatus = new CGetMachineStatus();
    PSNEmployeewebservice oEm = new PSNEmployeewebservice();
    ConnectDBSCM oConnSCM = new ConnectDBSCM();
    ConnectDBPDB oConnPDB = new ConnectDBPDB();
    CGetDataGraph oGetDataGraph = new CGetDataGraph();

    private string Event = "";
    private string chDate = "";
    int CycleTime = 30;
    bool Shiptday = true;
    string EffLine = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string Line = Request.QueryString["line"] != null ? Request.QueryString["line"].ToString() : "main";
        if (!IsPostBack)
        {            
            ViewState["line"] = Line;
            ddlLine.Items.Add(new ListItem("Main Assembly", "main"));
            ddlLine.Items.Add(new ListItem("Mecha", "mecha"));
            ddlLine.Items.Add(new ListItem("MC - Rear Head", "3101"));
            ddlLine.Items.Add(new ListItem("MC - Cylinder", "3102"));
            ddlLine.Items.Add(new ListItem("MC - Crank Shaft", "3103"));
            ddlLine.Items.Add(new ListItem("MC - Front Head", "3104"));
            ddlLine.Items.Add(new ListItem("MC - Piston", "3105"));

            if (Line == "main")
            {
                ddlLine.SelectedValue = "main";
            }
            else if (Line == "mecha")
            {
                ddlLine.SelectedValue = "mecha";
                lbtitle.Text = "Production Acheivement Mecha Line Factory 3";
            }
            else if (Line == "3101")
            {
                ddlLine.SelectedValue = "3101";
                lbtitle.Text = "Production Acheivement Rear Head Line Factory 3";
            }
            else if (Line == "3102")
            {
                ddlLine.SelectedValue = "3102";
                lbtitle.Text = "Production Acheivement Cylinder Line Factory 3";
            }
            else if (Line == "3103")
            {
                ddlLine.SelectedValue = "3103";
                lbtitle.Text = "Production Acheivement Crank Shaft Line Factory 3";
            }
            else if (Line == "3104")
            {
                ddlLine.SelectedValue = "3104";
                lbtitle.Text = "Production Acheivement Front Head Factory 3";
            }
            else if (Line == "3105")
            {
                ddlLine.SelectedValue = "3105";
                lbtitle.Text = "Production Acheivement Piston Line Factory 3";
            }


            InitialControl();
            GetPDPlan();
            GetYearMonth();


        }

        ViewState["ct"] = CycleTime;
        ViewState["ShipDay"] = Shiptday;

        
    }

    private void InitialControl()
    {
        //----------- Loop Header Column 1-7 ----------------
        for (int i = 1; i <= 7; i++)
        {
            int day = 0;
            int month = 0;
            int year = 0;
            DateTime date = new DateTime();
            switch (i)
            {
                case 1: day = DateTime.Now.AddDays(-3).Day;
                    month = DateTime.Now.AddDays(-3).Month;
                    year = DateTime.Now.AddDays(-3).Year;
                    date = DateTime.Now.AddDays(-3);
                    break;
                case 2: day = DateTime.Now.AddDays(-2).Day;
                    month = DateTime.Now.AddDays(-2).Month;
                    year = DateTime.Now.AddDays(-2).Year;
                    date = DateTime.Now.AddDays(-2);
                    break;
                case 3: day = DateTime.Now.AddDays(-1).Day;
                    month = DateTime.Now.AddDays(-1).Month;
                    year = DateTime.Now.AddDays(-1).Year;
                    date = DateTime.Now.AddDays(-1);
                    break;
                case 4: day = DateTime.Now.Day;
                    month = DateTime.Now.Month;
                    year = DateTime.Now.Year;
                    date = DateTime.Now;
                    break;
                case 5: day = DateTime.Now.AddDays(1).Day;
                    month = DateTime.Now.AddDays(1).Month;
                    year = DateTime.Now.AddDays(1).Year;
                    date = DateTime.Now.AddDays(1);
                    break;
                case 6: day = DateTime.Now.AddDays(2).Day;
                    month = DateTime.Now.AddDays(2).Month;
                    year = DateTime.Now.AddDays(2).Year;
                    date = DateTime.Now.AddDays(2);
                    break;
                case 7: day = DateTime.Now.AddDays(3).Day;
                    month = DateTime.Now.AddDays(3).Month;
                    year = DateTime.Now.AddDays(3).Year;
                    date = DateTime.Now.AddDays(3);
                    break;
            }

            if (i == 1)
            {
                //rowHeaderDay.Cells[i].Attributes.Add("style", "background-color:#f9dc00;text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;");

                //rowHeaderDN.Cells[(i * 2) - 1].Attributes.Add("style", "background-color:#f9dc00;text-align: center; border-left: 1px solid #111;");
                //rowHeaderDN.Cells[(i * 2)].Attributes.Add("style", "background-color:#f9dc00;text-align: center; border-left: 1px solid #111;");
            }
            else
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    rowHeaderDay.Cells[i].Attributes.Add("style", "background-color:#f9dc00;text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;");

                    rowHeaderDN.Cells[(i * 2) - 1].Attributes.Add("style", "background-color:#f9dc00;text-align: center; border-left: 1px solid #111;");
                    rowHeaderDN.Cells[(i * 2)].Attributes.Add("style", "background-color:#f9dc00;text-align: center; border-left: 1px solid #111;");
                }
                else
                {
                    rowHeaderDay.Cells[i].Attributes.Add("style", "text-align: center; border-left: 1px solid #111;border-bottom: 1px solid #111;border-top: 1px solid #111;");

                    rowHeaderDN.Cells[(i * 2) - 1].Attributes.Add("style", "text-align: center; border-left: 1px solid #111;");
                    rowHeaderDN.Cells[(i * 2)].Attributes.Add("style", "text-align: center; border-left: 1px solid #111;");
                }

                //if (day <= DateTime.DaysInMonth(year, month))
                //{
                //    //DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                   
                //}
                //else
                //{
                //    rowHeaderDay.Cells[i].Attributes.Add("style", "display:none;");

                //    rowHeaderDN.Cells[(i * 2) - 1].Attributes.Add("style", "display:none;");
                //    rowHeaderDN.Cells[(i * 2)].Attributes.Add("style", "display:none;");
                //}
            }
                        
        }

        //------------ Set Header lbDay 7 Days ------------
        lbDay1.Text = DateTime.Now.AddDays(-3).Day.ToString();
        lbDay2.Text = DateTime.Now.AddDays(-2).Day.ToString();
        lbDay3.Text = DateTime.Now.AddDays(-1).Day.ToString();
        lbDay4.Text = DateTime.Now.Day.ToString();
        lbDay5.Text = DateTime.Now.AddDays(1).Day.ToString();
        lbDay6.Text = DateTime.Now.AddDays(2).Day.ToString();
        lbDay7.Text = DateTime.Now.AddDays(3).Day.ToString();
    }

    private void GetPDPlan()
    {
        string[] arrHeadRow = { "Plan", "Actual", "Diff.", "Accu. Diff.", "Achievement","Stop Time (Min)"};

        lbLastUpdate.Text = "Last Update: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        DataTable dtPDMeeting = new DataTable();
        dtPDMeeting.Columns.Add("Model", typeof(string));
        dtPDMeeting.Columns.Add("ModelCode", typeof(string));
        dtPDMeeting.Columns.Add("HeadRow", typeof(string));
        dtPDMeeting.Columns.Add("NO", typeof(int));
        #region Create Column data 31 
        dtPDMeeting.Columns.Add("D1_D", typeof(string));
        dtPDMeeting.Columns.Add("D1_N", typeof(string));
        dtPDMeeting.Columns.Add("D2_D", typeof(string));
        dtPDMeeting.Columns.Add("D2_N", typeof(string));
        dtPDMeeting.Columns.Add("D3_D", typeof(string));
        dtPDMeeting.Columns.Add("D3_N", typeof(string));
        dtPDMeeting.Columns.Add("D4_D", typeof(string));
        dtPDMeeting.Columns.Add("D4_N", typeof(string));
        dtPDMeeting.Columns.Add("D5_D", typeof(string));
        dtPDMeeting.Columns.Add("D5_N", typeof(string));

        dtPDMeeting.Columns.Add("D6_D", typeof(string));
        dtPDMeeting.Columns.Add("D6_N", typeof(string));
        dtPDMeeting.Columns.Add("D7_D", typeof(string));
        dtPDMeeting.Columns.Add("D7_N", typeof(string));
        dtPDMeeting.Columns.Add("D8_D", typeof(string));
        dtPDMeeting.Columns.Add("D8_N", typeof(string));
        dtPDMeeting.Columns.Add("D9_D", typeof(string));
        dtPDMeeting.Columns.Add("D9_N", typeof(string));
        dtPDMeeting.Columns.Add("D10_D", typeof(string));
        dtPDMeeting.Columns.Add("D10_N", typeof(string));

        dtPDMeeting.Columns.Add("D11_D", typeof(string));
        dtPDMeeting.Columns.Add("D11_N", typeof(string));
        dtPDMeeting.Columns.Add("D12_D", typeof(string));
        dtPDMeeting.Columns.Add("D12_N", typeof(string));
        dtPDMeeting.Columns.Add("D13_D", typeof(string));
        dtPDMeeting.Columns.Add("D13_N", typeof(string));
        dtPDMeeting.Columns.Add("D14_D", typeof(string));
        dtPDMeeting.Columns.Add("D14_N", typeof(string));
        dtPDMeeting.Columns.Add("D15_D", typeof(string));
        dtPDMeeting.Columns.Add("D15_N", typeof(string));

        dtPDMeeting.Columns.Add("D16_D", typeof(string));
        dtPDMeeting.Columns.Add("D16_N", typeof(string));
        dtPDMeeting.Columns.Add("D17_D", typeof(string));
        dtPDMeeting.Columns.Add("D17_N", typeof(string));
        dtPDMeeting.Columns.Add("D18_D", typeof(string));
        dtPDMeeting.Columns.Add("D18_N", typeof(string));
        dtPDMeeting.Columns.Add("D19_D", typeof(string));
        dtPDMeeting.Columns.Add("D19_N", typeof(string));
        dtPDMeeting.Columns.Add("D20_D", typeof(string));
        dtPDMeeting.Columns.Add("D20_N", typeof(string));

        dtPDMeeting.Columns.Add("D21_D", typeof(string));
        dtPDMeeting.Columns.Add("D21_N", typeof(string));
        dtPDMeeting.Columns.Add("D22_D", typeof(string));
        dtPDMeeting.Columns.Add("D22_N", typeof(string));
        dtPDMeeting.Columns.Add("D23_D", typeof(string));
        dtPDMeeting.Columns.Add("D23_N", typeof(string));
        dtPDMeeting.Columns.Add("D24_D", typeof(string));
        dtPDMeeting.Columns.Add("D24_N", typeof(string));
        dtPDMeeting.Columns.Add("D25_D", typeof(string));
        dtPDMeeting.Columns.Add("D25_N", typeof(string));

        dtPDMeeting.Columns.Add("D26_D", typeof(string));
        dtPDMeeting.Columns.Add("D26_N", typeof(string));
        dtPDMeeting.Columns.Add("D27_D", typeof(string));
        dtPDMeeting.Columns.Add("D27_N", typeof(string));
        dtPDMeeting.Columns.Add("D28_D", typeof(string));
        dtPDMeeting.Columns.Add("D28_N", typeof(string));
        dtPDMeeting.Columns.Add("D29_D", typeof(string));
        dtPDMeeting.Columns.Add("D29_N", typeof(string));
        dtPDMeeting.Columns.Add("D30_D", typeof(string));
        dtPDMeeting.Columns.Add("D30_N", typeof(string));

        dtPDMeeting.Columns.Add("D31_D", typeof(string));
        dtPDMeeting.Columns.Add("D31_N", typeof(string));
        #endregion
        
        //------------- Get Data PD Achieve Line Main Fac 3 ----------------
        SqlCommand sqlPDAch = new SqlCommand();
        SqlCommand sqlPDAchLastMonth = new SqlCommand();
        SqlCommand sqlPDAchNextMonth = new SqlCommand();
        if (ViewState["line"].ToString() == "main")
        {
            sqlPDAch.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", "3AMA5", DateTime.Now.Month, DateTime.Now.Year);
            sqlPDAchLastMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", "3AMA5", DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year);
            sqlPDAchNextMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", "3AMA5", DateTime.Now.AddMonths(1).Month, DateTime.Now.AddMonths(1).Year);
        }
        else if (ViewState["line"].ToString() == "mecha")
        {
            sqlPDAch.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", "3AME5", DateTime.Now.Month, DateTime.Now.Year);
            sqlPDAchLastMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", "3AME5", DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year);
            sqlPDAchNextMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", "3AME5", DateTime.Now.AddMonths(1).Month, DateTime.Now.AddMonths(1).Year);
        }
        else
        {
            //----------- Machine Line ------------
            sqlPDAch.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", ViewState["line"].ToString(), DateTime.Now.Month, DateTime.Now.Year);
            sqlPDAchLastMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", ViewState["line"].ToString(), DateTime.Now.AddMonths(-1).Month, DateTime.Now.AddMonths(-1).Year);
            sqlPDAchNextMonth.CommandText = String.Format("SELECT * FROM [PD_Achievement] WHERE ProductionLine = '{0}' AND DataMonth = {1} AND DataYear = {2} ", ViewState["line"].ToString(), DateTime.Now.AddMonths(1).Month, DateTime.Now.AddMonths(1).Year);

            //sqlPDAch.CommandText = "";
        }
        
        DataTable dtAch = oConnSCM.Query(sqlPDAch);
        DataTable dtAchLastMonth = oConnSCM.Query(sqlPDAchLastMonth);
        DataTable dtAchNextMonth = oConnSCM.Query(sqlPDAchNextMonth);

        int idxRow = 0;
        int[] arrPlanD = new int[32];
        int[] arrPlanN = new int[32];
        int[] arrActualD = new int[32];
        int[] arrActualN = new int[32];
        int[] arrAccuDiffD = new int[32];
        int[] arrAccuDiffN = new int[32];
        int[] arrStopD = new int[32];
        int[] arrStopN = new int[32];

        foreach (string itemHead in arrHeadRow)
        {
            idxRow += 1;
            DataRow _rowPD = dtPDMeeting.NewRow();
            _rowPD["HeadRow"] = itemHead;
            _rowPD["NO"] = idxRow;
            if (itemHead == "Plan")
            {
                //----------------- for loop get data plan 31 days ----------------
                for (int i = 1; i <= 7; i++)
                {
                    int day = 0;
                    int CheckMonth = 0;
                    int CheckYear = 0;
                    switch (i)
                    {
                        case 1: day = DateTime.Now.AddDays(-3).Day;
                            CheckMonth = DateTime.Now.AddDays(-3).Month;
                            CheckYear = DateTime.Now.AddDays(-3).Year;
                            break;
                        case 2: day = DateTime.Now.AddDays(-2).Day;
                            CheckMonth = DateTime.Now.AddDays(-2).Month;
                            CheckYear = DateTime.Now.AddDays(-2).Year;
                            break;
                        case 3: day = DateTime.Now.AddDays(-1).Day;
                            CheckMonth = DateTime.Now.AddDays(-1).Month;
                            CheckYear = DateTime.Now.AddDays(-1).Year;
                            break;
                        case 4: day = DateTime.Now.Day;
                            CheckMonth = DateTime.Now.Month;
                            CheckYear = DateTime.Now.Year;
                            break;
                        case 5: day = DateTime.Now.AddDays(1).Day;
                            CheckMonth = DateTime.Now.AddDays(1).Month;
                            CheckYear = DateTime.Now.AddDays(1).Year;
                            break;
                        case 6: day = DateTime.Now.AddDays(2).Day;
                            CheckMonth = DateTime.Now.AddDays(2).Month;
                            CheckYear = DateTime.Now.AddDays(2).Year;
                            break;
                        case 7: day = DateTime.Now.AddDays(3).Day;
                            CheckMonth = DateTime.Now.AddDays(3).Month;
                            CheckYear = DateTime.Now.AddDays(3).Year;
                            break;
                    }

                    int PlanD = 0;
                    int PlanN = 0;

                    if (dtAch.Rows.Count > 0)
                    {
                        int dayNew = day;
                        if (CheckYear == DateTime.Now.Year)
                        {
                            if (CheckMonth < DateTime.Now.Month)
                            {
                                PlanD = dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Plan"] != 
                                    DBNull.Value ? Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Plan"].ToString()) : 0;
                                PlanN = dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Plan"] != 
                                    DBNull.Value ? Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Plan"].ToString()) : 0;
                            }
                            else if (CheckMonth > DateTime.Now.Month)
                            {
                                PlanD = dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Plan"] != 
                                    DBNull.Value ? Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Plan"].ToString()) : 0;
                                PlanN = dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Plan"] != 
                                    DBNull.Value ? Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Plan"].ToString()) : 0;
                            }
                            else
                            {
                                PlanD = dtAch.Rows[0]["Day" + dayNew + "D_Plan"] != 
                                    DBNull.Value ? Convert.ToInt32(dtAch.Rows[0]["Day" + dayNew + "D_Plan"].ToString()) : 0;
                                PlanN = dtAch.Rows[0]["Day" + dayNew + "N_Plan"] != 
                                    DBNull.Value ? Convert.ToInt32(dtAch.Rows[0]["Day" + dayNew + "N_Plan"].ToString()) : 0;
                            }
                        }
                        else if(CheckYear > DateTime.Now.Year)
                        {
                            PlanD = dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Plan"] != 
                                DBNull.Value ? Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Plan"].ToString()) : 0;
                            PlanN = dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Plan"] != 
                                DBNull.Value ? Convert.ToInt32(dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Plan"].ToString()) : 0;
                        }
                        else
                        {
                            PlanD = dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Plan"] != 
                                DBNull.Value ? Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Plan"].ToString()) : 0;
                            PlanN = dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Plan"] != 
                                DBNull.Value ? Convert.ToInt32(dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Plan"].ToString()) : 0;
                        }
                                                
                    }

                    arrPlanD[i] = PlanD;
                    arrPlanN[i] = PlanN;
                    _rowPD["D" + i + "_D"] = PlanD == 0 ? "0" : PlanD.ToString("N0");
                    _rowPD["D" + i + "_N"] = PlanN == 0 ? "0" : PlanN.ToString("N0");                                        
                }
            }
            else if (itemHead == "Actual")
            {
                for (int i = 1; i <= 7; i++)
                {
                    int day = 0;
                    int CheckMonth = 0;
                    int CheckYear = 0;
                    switch (i)
                    {
                        case 1: day = DateTime.Now.AddDays(-3).Day;
                            CheckMonth = DateTime.Now.AddDays(-3).Month;
                            CheckYear = DateTime.Now.AddDays(-3).Year;
                            break;
                        case 2: day = DateTime.Now.AddDays(-2).Day;
                            CheckMonth = DateTime.Now.AddDays(-2).Month;
                            CheckYear = DateTime.Now.AddDays(-2).Year;
                            break;
                        case 3: day = DateTime.Now.AddDays(-1).Day;
                            CheckMonth = DateTime.Now.AddDays(-1).Month;
                            CheckYear = DateTime.Now.AddDays(-1).Year;
                            break;
                        case 4: day = DateTime.Now.Day;
                            CheckMonth = DateTime.Now.Month;
                            CheckYear = DateTime.Now.Year;
                            break;
                        case 5: day = DateTime.Now.AddDays(1).Day;
                            CheckMonth = DateTime.Now.AddDays(1).Month;
                            CheckYear = DateTime.Now.AddDays(1).Year;
                            break;
                        case 6: day = DateTime.Now.AddDays(2).Day;
                            CheckMonth = DateTime.Now.AddDays(2).Month;
                            CheckYear = DateTime.Now.AddDays(2).Year;
                            break;
                        case 7: day = DateTime.Now.AddDays(3).Day;
                            CheckMonth = DateTime.Now.AddDays(3).Month;
                            CheckYear = DateTime.Now.AddDays(3).Year;
                            break;
                    }

                    if (dtAch.Rows.Count > 0)
                    {
                        int dayNew = day;
                        if (CheckYear == DateTime.Now.Year)
                        {
                            if (CheckMonth < DateTime.Now.Month)
                            {
                                _rowPD["D" + i + "_D"] = dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Actual"] !=
                                    DBNull.Value ? dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Actual"].ToString() : "";
                                _rowPD["D" + i + "_N"] = dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Actual"] !=
                                    DBNull.Value ? dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Actual"].ToString() : "";
                            }
                            else if (CheckMonth > DateTime.Now.Month)
                            {
                                _rowPD["D" + i + "_D"] = dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Actual"] !=
                                    DBNull.Value ? dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Actual"].ToString() : "";
                                _rowPD["D" + i + "_N"] = dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Actual"] !=
                                    DBNull.Value ? dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Actual"].ToString() : "";
                            }
                            else
                            {
                                _rowPD["D" + i + "_D"] = dtAch.Rows[0]["Day" + dayNew + "D_Actual"] != 
                                    DBNull.Value ? dtAch.Rows[0]["Day" + dayNew + "D_Actual"].ToString() : "";
                                _rowPD["D" + i + "_N"] = dtAch.Rows[0]["Day" + dayNew + "N_Actual"] != 
                                    DBNull.Value ? dtAch.Rows[0]["Day" + dayNew + "N_Actual"].ToString() : "";
                            }
                        }
                        else if (CheckYear > DateTime.Now.Year)
                        {
                            _rowPD["D" + i + "_D"] = dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Actual"] !=
                                DBNull.Value ? dtAchNextMonth.Rows[0]["Day" + dayNew + "D_Actual"].ToString() : "";
                            _rowPD["D" + i + "_N"] = dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Actual"] !=
                                DBNull.Value ? dtAchNextMonth.Rows[0]["Day" + dayNew + "N_Actual"].ToString() : "";
                        }
                        else
                        {
                            _rowPD["D" + i + "_D"] = dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Actual"] !=
                                DBNull.Value ? dtAchLastMonth.Rows[0]["Day" + dayNew + "D_Actual"].ToString() : "";
                            _rowPD["D" + i + "_N"] = dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Actual"] !=
                                DBNull.Value ? dtAchLastMonth.Rows[0]["Day" + dayNew + "N_Actual"].ToString() : "";
                        }

                    }

                    arrActualD[i] = Convert.ToInt32(_rowPD["D" + i + "_D"].ToString() == "" ? 0 : Convert.ToInt32(_rowPD["D" + i + "_D"].ToString()));
                    arrActualN[i] = Convert.ToInt32(_rowPD["D" + i + "_N"].ToString() == "" ? 0 : Convert.ToInt32(_rowPD["D" + i + "_N"].ToString()));                 
                }
            }
            else if (itemHead == "Diff.")
            {
                int AccuDiffD = 0;
                int AccuDiffN = 0;
                int[] SumDiff = new int[15];
                SumDiff[1] = arrActualD[1] - arrPlanD[1];
                SumDiff[2] = SumDiff[1] + arrActualN[1] - arrPlanN[1];
                SumDiff[3] = SumDiff[2] + arrActualD[2] - arrPlanD[2];
                SumDiff[4] = SumDiff[3] + arrActualN[2] - arrPlanN[2];
                SumDiff[5] = SumDiff[4] + arrActualD[3] - arrPlanD[3];
                SumDiff[6] = SumDiff[5] + arrActualN[3] - arrPlanN[3];
                SumDiff[7] = SumDiff[6] + arrActualD[4] - arrPlanD[4];

                for (int i = 1; i <= 7; i++)
                {                    
                    int diffD = arrActualD[i] - arrPlanD[i];
                    int diffN = arrActualN[i] - arrPlanN[i];
                    _rowPD["D" + i + "_D"] = diffD == 0 ? "0" : diffD.ToString("N0");
                    _rowPD["D" + i + "_N"] = diffN == 0 ? "0" : diffN.ToString("N0");

                    //------------ Set Accu Diff Each Day Of Month ---------------
                    AccuDiffD += diffD;
                    AccuDiffN += diffD + diffN;

                    arrAccuDiffD[i] = SumDiff[i];
                    arrAccuDiffN[i] += AccuDiffN;

                    arrAccuDiffD[i] = _rowPD["D" + i + "_D"].ToString() == "" ? 0 : arrAccuDiffD[i];
                    arrAccuDiffN[i] = _rowPD["D" + i + "_N"].ToString() == "" ? 0 : arrAccuDiffN[i];  
                }
            }
            else if (itemHead == "Accu. Diff.")
            {
                //for (int i = 1; i <= 7; i++)
                //{
                //    _rowPD["D" + i + "_D"] = arrAccuDiffD[i] == 0 ? "0" : arrAccuDiffD[i].ToString("N0");
                //    _rowPD["D" + i + "_N"] = arrAccuDiffD[i + 1] == 0 ? "0" : arrAccuDiffD[i + 1].ToString("N0");                
                //}
                _rowPD["D1_D"] = arrAccuDiffD[1] == 0 ? "0" : arrAccuDiffD[1].ToString("N0");
                _rowPD["D1_N"] = arrAccuDiffD[2] == 0 ? "0" : arrAccuDiffD[2].ToString("N0");
                _rowPD["D2_D"] = arrAccuDiffD[3] == 0 ? "0" : arrAccuDiffD[3].ToString("N0");
                _rowPD["D2_N"] = arrAccuDiffD[4] == 0 ? "0" : arrAccuDiffD[4].ToString("N0");
                _rowPD["D3_D"] = arrAccuDiffD[5] == 0 ? "0" : arrAccuDiffD[5].ToString("N0");
                _rowPD["D3_N"] = arrAccuDiffD[6] == 0 ? "0" : arrAccuDiffD[6].ToString("N0");
                _rowPD["D4_D"] = arrAccuDiffD[7] == 0 ? "0" : arrAccuDiffD[7].ToString("N0");
            }
            else if (itemHead == "Stop Time (Min)")
            {
                for (int i = 1; i <= 7; i++)
                {
                    //_rowPD["D" + i + "_D"] = dtAch.Rows[0]["Problem" + i + "Time"] != DBNull.Value ? Convert.ToInt32(dtAch.Rows[0]["Problem" + i + "Time"].ToString()) : 0;
                    //_rowPD["D" + i + "_N"] = "-";

                    if (i == 1)
                    {
                        //_rowPD["D" + i + "_D"] = 0;
                    }

                    if (i == 3 )
                    {
                        //_rowPD["D" + i + "_D"] = 15;
                    }
                }
            }
            else if (itemHead == "Achievement")
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (i > DateTime.Now.Day)
                    {
                        _rowPD["D" + i + "_D"] = "";
                        _rowPD["D" + i + "_N"] = "";
                    }
                    else
                    {
                        if (arrPlanD[i] == arrActualD[i] && arrPlanD[i] != 0)
                        {
                            _rowPD["D" + i + "_D"] = "100%";
                        }
                        else if (arrPlanD[i] > 0)
                        {
                            decimal AchD = (arrActualD[i] * 100) / arrPlanD[i];
                            _rowPD["D" + i + "_D"] = AchD.ToString() + "%";
                        }
                        else
                        {
                            _rowPD["D" + i + "_D"] = "";
                        }

                        if (arrPlanN[i] == arrActualN[i] && arrPlanN[i] != 0)
                        {
                            _rowPD["D" + i + "_N"] = "100%";
                        }
                        else if (arrPlanN[i] > 0)
                        {
                            decimal AchN = (arrActualN[i] * 100) / arrPlanN[i];
                            AchN = AchN > 100 ? 100 : AchN;
                            _rowPD["D" + i + "_N"] = AchN.ToString() + "%";
                        }
                        else
                        {
                            _rowPD["D" + i + "_N"] = "";
                        }
                    }                                                                                                    
                }
            }
            dtPDMeeting.Rows.Add(_rowPD);
        }

        DataView dv = dtPDMeeting.DefaultView;
        dv.Sort = "NO ASC";
        DataTable sortedDT = dv.ToTable();

        rptPDMeeting.DataSource = sortedDT;
        rptPDMeeting.DataBind();

    }

    private void UpdateDataPlanActual(string LineGroup)
    {
        //--------------- Get Data from Monthly Plan 1ST and 2ND from Planning System ------------
        SqlCommand sqlPlan = new SqlCommand();
        sqlPlan.CommandText = "SELECT [MonthlyId],m.[ModelCode],m.[Model],[DataType],[DataYear],[DataMonth],[DataHalfMonth],[Revision],[RevisionOnMake],[RevisionDetail],[RevisionDate]" +
            " ,[D1],[D2],[D3],[D4],[D5],[D6],[D7],[D8],[D9],[D10],[D11],[D12],[D13],[D14],[D15],[D16],[D17],[D18],[D19],[D20],[D21],[D22],[D23],[D24],[D25],[D26]" +
            " ,[D27],[D28],[D29],[D30],[D31],[SUM_Model],m.[CreateBy],m.[CreateDate],m.[UpdateBy],m.[UpdateDate],[Comment],[Remark],m.[Status],m.[Line]" +
            " FROM [PN_MonthlyPlan] m" +
            " LEFT JOIN PN_Compressor c ON m.Model = c.Model AND m.Line = c.Line" +
            " WHERE m.Status = 'ACTIVE' AND DataMonth = '" + DateTime.Now.Month + "' AND DataYear = '" + DateTime.Now.Year + "' AND m.Line = '6' AND DataType = '1:PLAN'";
        DataTable dtPlan = oConnSCM.Query(sqlPlan);

        //-------------- Update Data Plan Assy Group ---------------
        SqlCommand sqlUpdatePlan = new SqlCommand();
        sqlUpdatePlan.CommandText = "Update [PD_Achievement] SET Day1D_Plan = @Day,Day2D_Plan = @Day,Day3D_Plan = @Day,Day4D_Plan = @Day,Day5D_Plan = @Day,Day6D_Plan = @Day" +
          " ,Day7D_Plan = @Day,Day8D_Plan = @Day,Day9D_Plan = @Day,Day10D_Plan = @Day,Day11D_Plan = @Day,Day12D_Plan = @Day,Day13D_Plan = @Day,Day14D_Plan = @Day,Day15D_Plan = @Day,Day16D_Plan = @Day" +
          " ,Day17D_Plan = @Day,Day18D_Plan = @Day,Day19D_Plan = '',Day20D_Plan = '',Day21D_Plan = '',Day22D_Plan = '',Day23D_Plan = '',Day24D_Plan = '',Day25D_Plan = '',Day26D_Plan = ''" +
          " ,Day27D_Plan = @Day,Day28D_Plan = @Day,Day29D_Plan = '',Day30D_Plan = '',Day31D_Plan = '',UpdateBy = 'System',UpdateDate = ''" +
          " WHERE ProductionLine = '3AMA5'";
    }

    protected void rptPDMeeting_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbHeadRow = e.Item.FindControl("lbHeadRow") as Label;

            for (int i = 1; i <= 7; i++)
            {
                int day = 0;

                DateTime dateCheck = new DateTime();
                switch (i)
                {
                    case 1: day = DateTime.Now.AddDays(-3).Day;
                        dateCheck = DateTime.Now.AddDays(-3);
                        break;
                    case 2: day = DateTime.Now.AddDays(-2).Day;
                        dateCheck = DateTime.Now.AddDays(-2);
                        break;
                    case 3: day = DateTime.Now.AddDays(-1).Day;
                        dateCheck = DateTime.Now.AddDays(-1);
                        break;
                    case 4: day = DateTime.Now.Day;
                        dateCheck = DateTime.Now;
                        break;
                    case 5: day = DateTime.Now.AddDays(1).Day;
                        dateCheck = DateTime.Now.AddDays(1);
                        break;
                    case 6: day = DateTime.Now.AddDays(2).Day;
                        dateCheck = DateTime.Now.AddDays(2);
                        break;
                    case 7: day = DateTime.Now.AddDays(3).Day;
                        dateCheck = DateTime.Now.AddDays(3);
                        break;
                }

                HtmlTableCell tdD = (HtmlTableCell)e.Item.FindControl("tdD" + i);
                HtmlTableCell tdN = (HtmlTableCell)e.Item.FindControl("tdN" + i);

                if (dateCheck.DayOfWeek == DayOfWeek.Saturday || dateCheck.DayOfWeek == DayOfWeek.Sunday)
                {
                    tdD.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                    tdN.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                }
                else
                {
                    tdD.Attributes.Add("style", "text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                    tdN.Attributes.Add("style", "text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                }

                //if (day == 1)
                //{
                //    //tdD.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                //    //tdN.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                //}
                //else
                //{
                //    if (day <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
                //    {
                //        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                //        if (dateCheck.DayOfWeek == DayOfWeek.Saturday || dateCheck.DayOfWeek == DayOfWeek.Sunday)
                //        {
                //            tdD.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                //            tdN.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                //        }
                //        else
                //        {
                //            tdD.Attributes.Add("style", "text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                //            tdN.Attributes.Add("style", "text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
                //        }
                //    }
                //    else
                //    {
                //        tdD.Attributes.Add("style", "display:none;");
                //        tdN.Attributes.Add("style", "display:none;");
                //    }
                //}
                
            }
        }
    }

    protected void rptDayHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {        
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    Label lbDay = (Label)e.Item.FindControl("lbDay");
        //    HtmlTableCell th = (HtmlTableCell)e.Item.FindControl("thCell");

        //    if ((Convert.ToInt32(lbDay.Text) <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) && lbDay.Text != "1")
        //    {
        //        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(lbDay.Text));
        //        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)//&& Convert.ToInt32(lbDay.Text) != 1
        //        {
        //            th.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
        //        }
        //        else if (Convert.ToInt32(lbDay.Text) == 1)
        //        {
        //            //th.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
        //        }
        //        else
        //        {
        //            th.Attributes.Add("style", "text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
        //        }
        //    }
        //    else if (lbDay.Text == "1")
        //    {
        //        //th.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-left: 1px solid #111;border-bottom: 1px solid #111;");
        //    }            
        //}
    }

    protected void rptDN_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    HiddenField hdDay = (HiddenField)e.Item.FindControl("hdDay");
        //    HtmlTableCell thD = (HtmlTableCell)e.Item.FindControl("thCellD");
        //    HtmlTableCell thN = (HtmlTableCell)e.Item.FindControl("thCellN");

        //    if (Convert.ToInt32(hdDay.Value) <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
        //    {
        //        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(hdDay.Value));
        //        if ((date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday))
        //        {
        //            thD.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-right: 1px solid #111;");
        //            thN.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-right: 1px solid #111;");
        //        }
        //        else if (hdDay.Value.ToString() == "1")
        //        {
        //            //thD.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-right: 1px solid #111;");
        //            //thN.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-right: 1px solid #111;");
        //        }
        //        else
        //        {
        //            thD.Attributes.Add("style", "text-align:center;border-right: 1px solid #111;");
        //            thN.Attributes.Add("style", "text-align:center;border-right: 1px solid #111;");
        //        }
        //    }
        //    else
        //    {
        //        //thD.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-right: 1px solid #111;");
        //       // thN.Attributes.Add("style", "background-color:#f9dc00;text-align:center;border-right: 1px solid #111;");
        //    }
        //}
    }

    protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        Page.Response.Redirect("PDMeeting.aspx?line=" + ddlLine.SelectedValue, true);
        //if (ddlLine.SelectedValue == "mecha")
        //{
        //    Page.Response.Redirect("PDMeeting.aspx?line=mecha", true);
        //}
        //else
        //{
        //    Page.Response.Redirect("PDMeeting.aspx?line=main", true);
        //}
    }
    protected void btnEditPlan_Click(object sender, EventArgs e)
    {
        //Server.Transfer("PDMeetingEditPlan.aspx", true);

        Response.Redirect("PDMeetingEditPlan.aspx");
    }

    private void GetYearMonth()
    {
        for (int idxYear = 2017; idxYear <= DateTime.Now.Year; idxYear++)
        {
            ddlYear.Items.Add(idxYear.ToString());
        }
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();

        for (int idxMonth = 1; idxMonth <= 12; idxMonth++)
        {
            ddlMonth.Items.Add(idxMonth.ToString());
        }
        ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
    }



}