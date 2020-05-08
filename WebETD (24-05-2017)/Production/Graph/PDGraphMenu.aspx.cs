using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Setting_PDGraphMenu : System.Web.UI.Page
{
    ConnectDBIoTServerTon oConTon = new ConnectDBIoTServerTon();
    ConnectDBIoTServerTonMecha oConnTonMecha = new ConnectDBIoTServerTonMecha();
    ConnectDB oConnIoTCosty = new ConnectDB();
    ConnectDBPDB oConPDB = new ConnectDBPDB();
    CGetMachineStatusLastDay oMachineStatus = new CGetMachineStatusLastDay();
    CultureInfo provider = CultureInfo.InvariantCulture;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMahine.Items.Add(new ListItem("Crank Shaft", "Crank Shaft"));
            ddlMahine.Items.Add(new ListItem("Cylinder", "Cylinder"));
            ddlMahine.Items.Add(new ListItem("Piston", "Piston"));
            ddlMahine.Items.Add(new ListItem("Front Head", "Front Head"));
            ddlMahine.Items.Add(new ListItem("Rear Head", "Rear Head"));
            ddlMahine.Items.Add(new ListItem("Cylinder Centering", "Cylinder Centering"));
            ddlMahine.Items.Add(new ListItem("Rear Centering", "Rear Centering"));
            ddlMahine.Items.Add(new ListItem("Tourque Check", "Tourque Check"));
        }
    }

    //public string LoadDDLMachine()
    //{
    //    ddlMahine.Items.Add("dasfsa");
    //    ddlMahine.DataBind();
    //    return "";
    //}

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataTable dtMachineStatusIdle = new DataTable();
        dtMachineStatusIdle.Columns.Add("MachineName", typeof(string));
        dtMachineStatusIdle.Columns.Add("StartTime", typeof(string));
        dtMachineStatusIdle.Columns.Add("EndTime", typeof(string));
        dtMachineStatusIdle.Columns.Add("TotalIdleTime", typeof(TimeSpan));
        dtMachineStatusIdle.Columns.Add("MachineStatus", typeof(string));

        DataTable dtMacStatusRun = new DataTable();

        DateTime strDate = Convert.ToDateTime(txtStrDate.Text);
        DateTime endDate = Convert.ToDateTime(txtEndDate.Text);
        if (ddlShipt.SelectedValue.ToString() == "All")
        {
            strDate = strDate.Date + new TimeSpan(8, 0, 0);
            endDate = endDate.AddDays(1).Date + new TimeSpan(7, 59, 59);
        }
        else if (ddlShipt.SelectedValue.ToString() == "D")
        {
            strDate = strDate.Date + new TimeSpan(8, 0, 0);
            endDate = endDate.Date + new TimeSpan(20, 0, 0);
        }
        else if (ddlShipt.SelectedValue.ToString() == "N")
        {
            strDate = strDate.Date + new TimeSpan(20, 0, 0);
            endDate = endDate.AddDays(1).Date + new TimeSpan(7, 59, 59);
        }

        //------------ Get Data Time Machine Running -----------------
        if (hdModalChoose.Value == "mecha")
        {          
            dtMacStatusRun = GetMachineMechaStatus(strDate, endDate, ddlMahine.SelectedValue.ToString(), true);            
        }
        //------------ Get Data Time Machine Running -----------------

        DateTime DateAcc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
        //-------------- Set Data for Machine not issue product ---------------
        if (dtMacStatusRun.Rows.Count > 0)
        {
            TimeSpan TimeRUN = new TimeSpan();
            TimeSpan TimeIDLE = new TimeSpan();

            if (ddlShipt.SelectedValue.ToString() == "All")
            {
                while (DateAcc < new DateTime(DateTime.Now.AddDays(1).Year, 
                    DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 8, 0, 0))
                {
                    string timeStr = DateAcc.TimeOfDay.ToString().Replace(":", "");
                    string timeEnd = DateAcc.AddSeconds(30).TimeOfDay.ToString().Replace(":", "");
                    DataRow _rowIdle = dtMachineStatusIdle.NewRow();

                    //------------- Search Status RUN by cycle_start and cycle_stop -------------
                    DataRow[] _rowFillStartStop = _rowFillStartStop = dtMacStatusRun.Select("cycle_start_time >= " + timeStr + " AND cycle_end_time < " + timeEnd);

                    TimeSpan TimeDiff = DateAcc.AddSeconds(30).Subtract(DateAcc);
                    if (_rowFillStartStop.Length > 0)
                    {
                        TimeIDLE = new TimeSpan();
                        TimeRUN += TimeDiff;
                        _rowIdle["MachineStatus"] = "RUN";
                        _rowIdle["MachineName"] = ddlMahine.SelectedValue.ToString();
                        _rowIdle["StartTime"] = DateAcc.ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["EndTime"] = DateAcc.AddSeconds(30).ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["TotalIdleTime"] = TimeRUN;
                    }
                    else
                    {
                        TimeRUN = new TimeSpan();
                        TimeIDLE += TimeDiff;
                        _rowIdle["MachineStatus"] = "IDLE";
                        _rowIdle["MachineName"] = ddlMahine.SelectedValue.ToString();
                        _rowIdle["StartTime"] = DateAcc.ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["EndTime"] = DateAcc.AddSeconds(30).ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["TotalIdleTime"] = TimeIDLE;
                    }

                    dtMachineStatusIdle.Rows.Add(_rowIdle);

                    DateAcc = DateAcc.AddSeconds(30);
                }
            }
            else if (ddlShipt.SelectedValue.ToString() == "D")
            {
                while (DateAcc.TimeOfDay < new TimeSpan(20, 0, 0))
                {
                    string timeStr = DateAcc.TimeOfDay.ToString().Replace(":", "");
                    string timeEnd = DateAcc.AddSeconds(30).TimeOfDay.ToString().Replace(":", "");
                    DataRow _rowIdle = dtMachineStatusIdle.NewRow();

                    //------------- Search Status RUN by cycle_start and cycle_stop -------------
                    DataRow[] _rowFillStartStop = _rowFillStartStop = dtMacStatusRun.Select("cycle_start_time >= " + timeStr + " AND cycle_end_time < " + timeEnd);

                    TimeSpan TimeDiff = DateAcc.AddSeconds(30).Subtract(DateAcc);
                    if (_rowFillStartStop.Length > 0)
                    {
                        TimeIDLE = new TimeSpan();
                        TimeRUN += TimeDiff;
                        _rowIdle["MachineStatus"] = "RUN";
                        _rowIdle["MachineName"] = ddlMahine.SelectedValue.ToString();
                        _rowIdle["StartTime"] = DateAcc.ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["EndTime"] = DateAcc.AddSeconds(30).ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["TotalIdleTime"] = TimeRUN;
                    }
                    else
                    {
                        TimeRUN = new TimeSpan();
                        TimeIDLE += TimeDiff;
                        _rowIdle["MachineStatus"] = "IDLE";
                        _rowIdle["MachineName"] = ddlMahine.SelectedValue.ToString();
                        _rowIdle["StartTime"] = DateAcc.ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["EndTime"] = DateAcc.AddSeconds(30).ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["TotalIdleTime"] = TimeIDLE;
                    }

                    dtMachineStatusIdle.Rows.Add(_rowIdle);

                    DateAcc = DateAcc.AddSeconds(30);
                }
            }
            else if (ddlShipt.SelectedValue.ToString() == "N")
            {
                DateAcc = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
                while (DateAcc < new DateTime(DateTime.Now.AddDays(1).Year
                    , DateTime.Now.AddDays(1).Month, DateTime.Now.AddDays(1).Day, 8, 0, 0))
                {
                    string timeStr = DateAcc.TimeOfDay.ToString().Replace(":", "");
                    string timeEnd = DateAcc.AddSeconds(30).TimeOfDay.ToString().Replace(":", "");
                    DataRow _rowIdle = dtMachineStatusIdle.NewRow();

                    //------------- Search Status RUN by cycle_start and cycle_stop -------------
                    DataRow[] _rowFillStartStop = _rowFillStartStop = dtMacStatusRun.Select("cycle_start_time >= " + timeStr + " AND cycle_end_time < " + timeEnd);

                    TimeSpan TimeDiff = DateAcc.AddSeconds(30).Subtract(DateAcc);
                    if (_rowFillStartStop.Length > 0)
                    {
                        TimeIDLE = new TimeSpan();
                        TimeRUN += TimeDiff;
                        _rowIdle["MachineStatus"] = "RUN";
                        _rowIdle["MachineName"] = ddlMahine.SelectedValue.ToString();
                        _rowIdle["StartTime"] = DateAcc.ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["EndTime"] = DateAcc.AddSeconds(30).ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["TotalIdleTime"] = TimeRUN;
                    }
                    else
                    {
                        TimeRUN = new TimeSpan();
                        TimeIDLE += TimeDiff;
                        _rowIdle["MachineStatus"] = "IDLE";
                        _rowIdle["MachineName"] = ddlMahine.SelectedValue.ToString();
                        _rowIdle["StartTime"] = DateAcc.ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["EndTime"] = DateAcc.AddSeconds(30).ToString("yyyy-MM-dd HH:mm:ss");
                        _rowIdle["TotalIdleTime"] = TimeIDLE;
                    }

                    dtMachineStatusIdle.Rows.Add(_rowIdle);

                    DateAcc = DateAcc.AddSeconds(30);
                }
            }
            

            //for (int i = 0; i < TotCol; i++)
            //{
                
            //}
          
        }
        //-------------- Set Data for Machine not issue product ---------------

        string FileName = "DataMachineStatus" + hdModalChoose.Value.ToString().ToUpper() + "_" 
            + ddlMahine.SelectedValue.ToString().Replace(' ', '_') + txtStrDate.Text + ".csv";
        if (dtMachineStatusIdle.Rows.Count > 0)
        {
            GenDataTableToCSV(dtMachineStatusIdle, FileName);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data not found for your selected.')", true);
        }
        
    }

    public DataTable GetMachineMechaStatus(DateTime Start, DateTime Stop, string MCName, bool Lastday)
    {
        string MachineId = "";
        List<MDMachineStatus> oList = new List<MDMachineStatus>();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "";
        //--------- Set Command Query for each Machine -------------
        #region Set Query
        if (MCName == "Crank Shaft")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [crank_shaft_result]";
            sql.CommandText += " WHERE ((replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd) AND replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050042";
        }
        else if (MCName == "Cylinder")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [cylinder_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050029";
        }
        else if (MCName == "Piston")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [piston_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0')) ";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050028";
        }
        else if (MCName == "Front Head")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [front_head_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050044";
        }
        else if (MCName == "Rear Head")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [rear_head_result]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050043";
        }
        else if (MCName == "Cylinder Centering")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [cylinder_centering]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050045";
        }
        else if (MCName == "Rear Centering")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [rear_centering]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050046";
        }
        else if (MCName == "Tourque Check")
        {
            sql.CommandText = "";
            sql.CommandText = "SELECT part_serial_no,[machine_no],replace(cycle_start_time,' ','0') as cycle_start_time";
            sql.CommandText += " ,replace(cycle_end_time,' ','0') as cycle_end_time";
            sql.CommandText += " FROM [torque_check]";
            sql.CommandText += " WHERE replace(cycle_start_time,' ','0') >= @ctStart AND replace(cycle_end_time,' ','0') < @ctEnd AND part_serial_no != ''";
            sql.CommandText += " AND stamp_time >= @strDate AND stamp_time <= @endDate AND part_serial_no != '' AND (replace(cycle_start_time,' ','0') < replace(cycle_end_time,' ','0'))";
            sql.CommandText += " ORDER BY stamp_time ASC";
            MachineId = "MC-17050030";
        }
        #endregion

        DateTime dateNow = Lastday ? DateTime.Now.AddDays(-1) : DateTime.Now;
        bool ShiptDay = true;
        if ((Start.TimeOfDay > TimeSpan.Parse("20:00:00") || Start.TimeOfDay < TimeSpan.Parse("08:00:00")) && !Lastday)
        {
            ShiptDay = false;
        }
        //Stop = Start.AddSeconds(180);
        string timeStr = Start.TimeOfDay.ToString().Replace(":", "");
        //string timeEnd = Stop.TimeOfDay.ToString().Replace(":", "");

        //string[] spTimeStr = timeStr.Split('.');
        //string[] spTimeEnd = timeEnd.Split('.');

        DateTime strDate = new DateTime();
        DateTime endDate = new DateTime();
        if (ShiptDay == true)
        {
            strDate = Start.Date + new TimeSpan(8, 0, 0);
            endDate = Start.Date + new TimeSpan(20, 0, 0);
        }
        else
        {
            strDate = Start.Date + new TimeSpan(20, 0, 0);
            endDate = Start.Date.AddDays(1) + new TimeSpan(8, 0, 0);
        }

        sql.Parameters.Add(new SqlParameter("@ctStart", timeStr));
        if (ShiptDay)
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "200000"));
        }
        else
        {
            sql.Parameters.Add(new SqlParameter("@ctEnd", "080000"));
        }
        sql.Parameters.Add(new SqlParameter("@strDate", strDate.ToString("yyyy-MM-dd HH:mm:ss")));
        sql.Parameters.Add(new SqlParameter("@endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss")));
        DataTable dTable = oConnTonMecha.Query(sql);

        string StatusBreak = GetMachineBreakDown("LN-1701", MachineId, strDate, Stop);
        dTable.Columns.Add("Break", typeof(string));
        if (dTable.Rows.Count > 0)
        {
            dTable.Rows[0]["Break"] = StatusBreak;
        }
        return dTable;
    }

    public string GetMachineBreakDown(string LineId, string MachineId, DateTime StartTime, DateTime EndTime)
    {
        string StatusBreak = "NO";

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT [BreakdownId],[RequestId],[MachineId],[StartTime],[EndTime]" +
            " FROM [PD_LineBreakDownDetail] WHERE MachineId = '" + MachineId + "'" +
            " AND (StartTime >= '" + StartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' AND StartTime <= '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
            " AND EndTime > '" + EndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
        DataTable dtBreak = oConPDB.Query(sql);
        if (dtBreak.Rows.Count > 0)
        {
            StatusBreak = "YES";
        }

        return StatusBreak;
    }

    private void GenDataTableToCSV(DataTable dTable, string FileName)
    {
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/plain";
        response.AddHeader("Content-Disposition", "attachment; filename=" + FileName + ";");

        StringBuilder sb = new StringBuilder();

        string[] columnNames = dTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
        sb.AppendLine(string.Join(",", columnNames));

        foreach (DataRow row in dTable.Rows)
        {
            string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
            sb.AppendLine(string.Join(",", fields));
        }

        // the most easy way as you have type it
        response.Write(sb.ToString());
        response.Flush();
        response.End();

    }

    public DataTable GetDataMatching(string ShiptDay, DateTime strDate, DateTime endDate, string strDateString, string endDateString)
    {
        CultureInfo cl = new CultureInfo("en-US");
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT [date],[time],[matched],[total_matching],[percent_match],[date_time]" +
            " FROM [percent_matching] WHERE date_time >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss", cl) + "'" +
            " AND date_time <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss", cl) + "'" +
            " ORDER BY date_time ASC";

        sql.CommandText = "SELECT [date],[time],[matched],[total_matching],[percent_match],[date_time]" +
             " FROM [percent_matching] WHERE date >= '" + strDateString + "'" +
             " AND date <= '" + endDateString + "'" +
             " ORDER BY date_time ASC";
        DataTable dTable = oConnTonMecha.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            
        }
        return dTable;
    }
}