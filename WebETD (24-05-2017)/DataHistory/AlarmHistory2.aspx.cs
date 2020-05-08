using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AlarmHistory2_PackingTracking : System.Web.UI.Page
{
    ConnectDBIoTFac3Costy oConnFac3Costy = new ConnectDBIoTFac3Costy();
    ConnectDBIoTServerTon oConnIoTFac3 = new ConnectDBIoTServerTon();
    ConnectDBIoTServerTonMecha oConnMecha = new ConnectDBIoTServerTonMecha();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    CGenControl oGenControl = new CGenControl();
    CGeneral oGen = new CGeneral();

    DataTable dt = new DataTable();
    CHistoryData oHis = new CHistoryData();
    bool check;

    CGeneral.SerialType oSerialType = CGeneral.SerialType.Label;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["FactoryID"] != null)
        {
            ViewState["FactoryID"] = Request.QueryString["FactoryID"];
        }
        else
        {
            ViewState["FactoryID"] = "0";
        }

        if (Request.QueryString["ld_id"] != null)
        {
            ViewState["ld_id"] = Request.QueryString["ld_id"];
        }
        else
        {
            ViewState["ld_id"] = "0";
        }

        if (!IsPostBack)
        {
            txtPrdDate.Attributes.Add("readonly", "readonly");
            InitialControl();
        }
    }

    private void InitialControl()
    {
        oGenControl.GenDDLAlarmLine(CGeneral.TypeSelect.Selected, ddlLine);
        oGenControl.GenDDLAlarmMachineByLine(CGeneral.TypeSelect.All, ddlMachine, ddlLine.SelectedValue);
    }

    public void LoadGrid()
    {
        dt = new DataTable();
        dt.TableName = "CR";
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT MCName,StampDate,Shift,LastAlarmDate,CountAlarm FROM LogAlarmMC lam";
        sql.CommandText += " INNER JOIN AlarmLineSetting als ON lam.MCName=als.MachineName";
        sql.CommandText += " where als.LineName = @LineName";
        sql.CommandText += " and lam.StampDate >= @DateStart";
        sql.CommandText += " and lam.StampDate <= @DateEnd";
        if (ddlShift.SelectedValue != "")
        {
            sql.CommandText += " and lam.Shift = @Shift";
        }
        if (ddlMachine.SelectedValue != "")
        {
            sql.CommandText += " and lam.MCName=@MCName";
        }
        sql.Parameters.Add(new SqlParameter("@DateStart", txtPrdDate.Text.Trim().Split('-')[0].Trim()));
        sql.Parameters.Add(new SqlParameter("@DateEnd", txtPrdDate.Text.Trim().Split('-')[1].Trim()));
        sql.Parameters.Add(new SqlParameter("@Shift", ddlShift.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@LineName", ddlLine.SelectedValue));
        sql.Parameters.Add(new SqlParameter("@MCName", ddlMachine.SelectedValue));
        dt = oConnMecha.Query(sql);

        

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //rptData.DataSource = null;
        //rptData.DataBind();
        //SqlCommand sql = new SqlCommand();

        //if (rbSearchSelect.SelectedValue == "0") // Datetime
        //{

        //}
        //else // Serial
        //{

        //}

        //sql.CommandTimeout = 0;
        //DataTable dt = oConnDCI.SqlGet(sql);
        //rptData.DataSource = dt;
        //rptData.DataBind();
        LoadGrid();
        GenHeader();
        GenDataRow();
    }

    public string GenHeader()
    {
        string result = "";
        result = "<tr>";

        //result += "                                        <th>Serial No</th>";
        //result += "                                        <th>Model</th>";
        //result += "                                        <th>ModelCode</th>";
        //result += "                                        <th>Pipe No</th>";
        //result += "                                        <th>Oil Charge</th>";
        //result += "                                        <th>Running Test</th>";
        //result += "                                        <th>Weight Check</th>";
        //result += "                                        <th>Hold By</th>";
        //result += "                                        <th>Hold Date</th>";
        //result += "                                        <th>Status</th>";

        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn col in dt.Columns)
            {
                result += "<th>" + col.Caption + "</th>" + Environment.NewLine;
            }
        }
        else
        {
            result += "<th></th>";
        }

        result += "</tr>";
        return result;
    }

    public string GenDataRow()
    {
        string result = "";
        

        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";
        //result += "                                        <td>";
        //result += "                                            test";
        //result += "                                        </td>";

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                result += "<tr>";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    result += "<td>" + row[i].ToString() + "</td>" + Environment.NewLine;
                }
                result += "</tr>";
            }
        }
        else
        {
            result += "<td></td>";
        }


        

        return result;
    }


    
    protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        oGenControl.GenDDLAlarmMachineByLine(CGeneral.TypeSelect.All, ddlMachine, ddlLine.SelectedValue);
        
    }
    protected void rptHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void ddlMachine_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}