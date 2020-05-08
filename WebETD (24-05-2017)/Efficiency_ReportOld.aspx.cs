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

public partial class Efficiency_ReportOld : System.Web.UI.Page
{
    //CGenControl oGenControl = new CGenControl();
    CGenGraph oGenGraph = new CGenGraph();
    ConnectDB oConn = new ConnectDB();
    ConnectDBIoTServerTon oConnIoT = new ConnectDBIoTServerTon();
    CGetMachineStatus oMCStatus = new CGetMachineStatus();
    private string Event = "";
    private string chDate = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Event = Request.QueryString["Event"] != null ? Request.QueryString["Event"].ToString() : "";
            chDate = Request.QueryString["Date"] != null ? Request.QueryString["Date"].ToString() : "";
            datepicker.Text = chDate;
            lbTime.Text = "Data On " + chDate;

            InitialControl();

            int CycleTime = 30;
            ViewState["ct"] = CycleTime;
            DataTable dt = GetMachineMain();
            rptMachine.DataSource = GetMachineMain();
            rptMachine.DataBind();

            bool Shiptday = true;
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
            ViewState["ShipDay"] = Shiptday;

            if (Event != "old")
            {                
                GetMachineStatus();
            }
            else
            {
                GetMachineStausPast();
            }                        
        }
    }

    private void InitialControl()
    {
    }

    private DataTable SetTable(int ct,string mc_name)
    {
        DataTable dtSetTable = new DataTable();
        dtSetTable.Columns.Add("Col", typeof(string));
        dtSetTable.Columns.Add("MC", typeof(string));

        int TotCol = ((3600 / ct) * 12) / 3;
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
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT DISTINCT mc_code,mc_name,mc_process FROM [dbIoT].[dbo].[Machine] where mc_code like 'main0%'";
        dtMachine = oConn.Query(sql);

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

            rptMac.DataSource = SetTable(Convert.ToInt16(ViewState["ct"].ToString()),hdName.Value);
            rptMac.DataBind();            
        }
    }

    private void GetMachineStatus() 
    {
        DateTime DateCurr = DateTime.Now.AddDays(-1);
        DateTime DateAcc = DateCurr.Date + new TimeSpan(8, 0, 0);
        if (DateCurr.TimeOfDay > TimeSpan.Parse("20:00:00"))
        {
            DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
        }

        for (int i = 0; i < rptMachine.Items.Count; i++)
        {
            List<MDMachineStatus> oList = new List<MDMachineStatus>();
            Repeater rptCol = rptMachine.Items[i].FindControl("rptTableMachine") as Repeater;
            HiddenField hdMC = rptMachine.Items[i].FindControl("hdmcName") as HiddenField;   

            DateAcc = DateCurr.Date + new TimeSpan(8, 0, 0);
            if (DateCurr.TimeOfDay > TimeSpan.Parse("20:00:00"))
            {
                DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
            }

            //---------- Get Machine Status -------------
            for (int j = 0; j < rptCol.Items.Count; j++)
            {
                oList = oMCStatus.GetMachineStatus(DateAcc, DateCurr, hdMC.Value);
                if (DateAcc > DateCurr)
                {
                    break;
                }
                else
                {
                    HtmlTableCell td = (HtmlTableCell)rptCol.Items[j].FindControl("col");
                    if (oList.Count > 0)
                    {
                        if (oList[0].Status == "TRUE")
                        {
                            td.Attributes.Add("style", "background-color:#45f960;");
                        }
                        else
                        {
                            td.Attributes.Add("style", "background-color:#e5a943;");
                        }
                    }
                    else
                    {
                        td.Attributes.Add("style", "background-color:#e5a943;");
                    }
                }
                DateAcc = DateAcc.AddSeconds(90);
            }
        }   
    }

    private void GetMachineStausPast()
    {
       // Timer1.Interval = 1000;
        DateTime DateCurr = Convert.ToDateTime(chDate) + new TimeSpan(8, 0, 0);
        DateTime DateAcc = DateCurr.Date + new TimeSpan(8, 0, 0);
        if (DateCurr.TimeOfDay > TimeSpan.Parse("20:00:00"))
        {
            DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
        }
        bool shipDay = true;

        for (int i = 0; i < rptMachine.Items.Count; i++)
        {
            List<MDMachineStatus> oList = new List<MDMachineStatus>();
            Repeater rptCol = rptMachine.Items[i].FindControl("rptTableMachine") as Repeater;
            HiddenField hdMC = rptMachine.Items[i].FindControl("hdmcName") as HiddenField;

            DateAcc = DateCurr.Date + new TimeSpan(8, 0, 0);
            if (DateCurr.TimeOfDay > TimeSpan.Parse("20:00:00"))
            {
                DateAcc = DateCurr.Date + new TimeSpan(20, 0, 0);
            }

            //---------- Get Machine Status -------------
            for (int j = 0; j < rptCol.Items.Count; j++)
            {
                oList = oMCStatus.GetMachineStatus(DateAcc, DateCurr, hdMC.Value);
                if (DateAcc.TimeOfDay > TimeSpan.Parse("20:00:00"))
                {
                    break;
                }
                else
                {
                    HtmlTableCell td = (HtmlTableCell)rptCol.Items[j].FindControl("col");
                    if (oList.Count > 0)
                    {
                        if (oList[0].Status == "TRUE")
                        {
                            td.Attributes.Add("style", "background-color:#45f960;");
                        }
                        else
                        {
                            td.Attributes.Add("style", "background-color:#e5a943;");
                        }
                    }
                    else
                    {
                        td.Attributes.Add("style", "background-color:#e5a943;");
                    }
                }
                DateAcc = DateAcc.AddSeconds(90);
            }
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
        string chDate = datepicker.Text;
        DateTime dateChoose = Convert.ToDateTime(chDate);

        Response.Redirect("Efficiency_Report.aspx");

    }
}