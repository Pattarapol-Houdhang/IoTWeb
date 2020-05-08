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

public partial class PDMeetingProductAllLine : System.Web.UI.Page
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
        EffLine = Request.QueryString["line"] != null ? Request.QueryString["line"].ToString() : "";
        ViewState["line"] = EffLine;

        if (!IsPostBack)
        {
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
                    hdLine.Text = "Production Achive Plan Main Assembly Factory 3";
                    linechoose.Text = ViewState["line"].ToString();
                }
            }
            else
            {
                hdLine.Text = "Production Achive Plan Main Assembly Factory 3";
                linechoose.Text = ViewState["line"].ToString();
            }

            InitialControl();
            GetPDPlanAssyLine();

        }

        ViewState["ct"] = CycleTime;
        ViewState["ShipDay"] = Shiptday;
    }

    private void InitialControl()
    {
    }

    private void GetPDPlanAssyLine()
    {
        string[] arrHeadRow = { "Plan", "Actual", "Diff.", "Accu. Diff.", "Achievement","Line Stop" };

        DataTable dtPDMeeting = new DataTable();
        dtPDMeeting.Columns.Add("Model", typeof(string));
        dtPDMeeting.Columns.Add("ModelCode", typeof(string));
        dtPDMeeting.Columns.Add("HeadRow", typeof(string));
        dtPDMeeting.Columns.Add("Data", typeof(string));

        //------------- Get Line Master is Assembly or Machine -------------
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT * FROM [PD_LineMstr] WHERE Factory = '3' and LineGroup = 'Assembly' and BoardId != '-' ORDER BY BoardId asc";
        DataTable dtLineMstr = oConnPDB.Query(sql);

        if (dtLineMstr.Rows.Count > 0)
        {
            //------------ Foreach data line assy -------------
            //foreach (DataRow _line in dtLineMstr.Rows)
            //{
                //---------- foreach data PD Achieve ------------
                #region
                foreach (string itemHead in arrHeadRow)
                {
                    DataRow _rowPD = dtPDMeeting.NewRow();
                    _rowPD["HeadRow"] = itemHead;

                    if (itemHead == "Plan")
                    {
                    }
                    else if (itemHead == "Actual")
                    {
                    }
                    else if (itemHead == "Diff.")
                    {
                    }
                    else if (itemHead == "Accu. Diff.")
                    {
                    }
                    else if (itemHead == "Achievement")
                    {
                    }
                    else if (itemHead == "Line Stop")
                    {

                    }
                    dtPDMeeting.Rows.Add(_rowPD);
                }
                #endregion
                //-------- End foreach data PD Achieve ------------
            //}
        }        
        rptPDMeeting.DataSource = dtPDMeeting;
        rptPDMeeting.DataBind();

    }

    private DataTable GetPlan(string BoardId)
    {
        DateTime strDate = DateTime.Now.AddDays(-1);

        DataTable dtPlan = new DataTable();
        dtPlan.Columns.Add("PlanD", typeof(string));
        dtPlan.Columns.Add("PlanN", typeof(string));
        dtPlan.Columns.Add("ActualD", typeof(string));
        dtPlan.Columns.Add("ActualN", typeof(string));

        //--------------- Get Plan on ship day --------------
        SqlCommand sqlD = new SqlCommand();
        sqlD.CommandText = "SELECT * FROM [DataLog] where BoardId = @BoardId and LogTime >= @StrDate and LogTime <= @EndDate order by LogTime DESC";
        sqlD.Parameters.Add(new SqlParameter("@BoardId", BoardId));
        sqlD.Parameters.Add(new SqlParameter("@StrDate", strDate.ToString("yyyy-MM-dd") + " 08:00:00"));
        sqlD.Parameters.Add(new SqlParameter("@EndDate", strDate.ToString("yyyy-MM-dd") + " 19:59:59"));
        DataTable dTableD = oConnPDB.Query(sqlD);

        //--------------- Get Plan Ship Night ----------------
        SqlCommand sqlN = new SqlCommand();
        sqlN.CommandText = "SELECT * FROM [DataLog] where BoardId = @BoardId and LogTime >= @StrDate and LogTime <= @EndDate order by LogTime DESC";
        sqlN.Parameters.Add(new SqlParameter("@BoardId", BoardId));
        sqlN.Parameters.Add(new SqlParameter("@StrDate", strDate.ToString("yyyy-MM-dd") + " 20:00:00"));
        sqlN.Parameters.Add(new SqlParameter("@EndDate", DateTime.Now.ToString("yyyy-MM-dd") + " 07:59:59"));
        DataTable dTableN = oConnPDB.Query(sqlN);

        if (dTableD.Rows.Count > 0)
        {
            DataRow _rowPlan = dtPlan.NewRow();
            _rowPlan["PlanD"] = dTableD.Rows[0]["Plan_"].ToString();

            if (dTableN.Rows.Count > 0)
            {
                _rowPlan["PlanN"] = dTableN.Rows[0]["Plan_"].ToString();
            }

            dtPlan.Rows.Add(_rowPlan);
        }

        return dtPlan;
    }

    private DataTable GetActual(string LineId)
    {
        DataTable dtActual = new DataTable();

        return dtActual;
    }

    protected void rptPDMeeting_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }

    protected void rptDayHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }

    protected void rptDN_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    }
}