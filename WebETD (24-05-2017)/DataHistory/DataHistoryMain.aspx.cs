using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeExcel = Microsoft.Office.Interop.Excel;
using System.Globalization;

public partial class DataHistory_DataHistoryMain : System.Web.UI.Page
{
    CGenControl oGenControl = new CGenControl();
    DataTable dt = new DataTable();
    CHistoryData oHis = new CHistoryData();
    bool check;

    CGeneral.SerialType oSerialType = CGeneral.SerialType.Label;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ld_id"] != null)
        {
            ViewState["ld_id"] = Request.QueryString["ld_id"];
        }
        else
        {
            ViewState["ld_id"] = "";
        }

        if (!IsPostBack)
        {
            InitialControl();

            txtDateStart.Text = (DateTime.Now.Date + new TimeSpan(8, 0, 0)).ToString("yyyy/MM/dd HH:mm");
            txtDateEnd.Text = (DateTime.Now.Date + new TimeSpan(20, 0, 0)).ToString("yyyy/MM/dd HH:mm");

            ViewState["DateStart"] = txtDateStart.Text.Trim();
            ViewState["DateEnd"] = txtDateEnd.Text.Trim();
        }

        noteLabel.Visible = false;
        if (ddlLine.SelectedValue == "10")
        {
            noteLabel.Visible = true;
        }
    }

    private void InitialControl()
    {
        oGenControl.GenDDLLineManual(CGeneral.TypeSelect.Selected, ddlLine);

        ddlPDYear.Items.Add(new ListItem("2017", "2017"));
        int yearDiff = 0;
        yearDiff = DateTime.Now.Year - 2017;
        for (int i = 1; i <= yearDiff; i++)
        {
            ddlPDYear.Items.Add(new ListItem((2017 + i).ToString(), (2017 + i).ToString()));
        }

        ddlPDYear.SelectedValue = DateTime.Now.Year.ToString();

        if (ViewState["ld_id"] != "")
        {
            string ld_id = "";
            ld_id = ViewState["ld_id"].ToString();
            if (ld_id == "1") // RH
            {
                ddlLine.SelectedValue = "2";
            }
            else if (ld_id == "2") // Casing Pipe
            {
                ddlLine.SelectedValue = "7";
            }
            else if (ld_id == "4") // Main
            {
                ddlLine.SelectedValue = "1";
            }
            else if (ld_id == "5") // Piston
            {
                ddlLine.SelectedValue = "6";
            }
            else if (ld_id == "6") // Cylinder
            {
                ddlLine.SelectedValue = "3";
            }
            else if (ld_id == "7") // Crank Shaft
            {
                ddlLine.SelectedValue = "4";
            }
            else if (ld_id == "10") // Final
            {
                ddlLine.SelectedValue = "10";
            }
            else if (ld_id == "16") // Front Head
            {
                ddlLine.SelectedValue = "5";
            }
            else
            {

            }

            oGenControl.GenDDLMachineManual(CGeneral.TypeSelect.Selected, ddlMachine, ddlLine.SelectedValue);
        }
    }

    private DataTable GetData()
    {
        dt = new DataTable();
        CGeneral.TableName TableName = CGeneral.TableName.ElectricalConduction;
        string MCName = "";
        string TypeData = "DL";
        if (ddlLine.SelectedValue == "1") // Main Assy
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.Rotor_Yakibame_New;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Mecha or Rotor No.";
                    oSerialType = CGeneral.SerialType.RearAndRotor;
                    break;
                case "2":
                    TableName = CGeneral.TableName.Magnetize;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Mecha No.";
                    oSerialType = CGeneral.SerialType.RearHead;
                    break;
                case "3":
                    TableName = CGeneral.TableName.Pipe_Yakibame;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "4":
                    TableName = CGeneral.TableName.Tack_Welding;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = false;
                    oSerialType = CGeneral.SerialType.None;
                    break;
                case "5":
                    TableName = CGeneral.TableName.MagnetCenter;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe & Rotor No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "6":
                    TableName = CGeneral.TableName.AirGap;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "7":
                    TableName = CGeneral.TableName.ElectricalConduction;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "8":
                    TableName = CGeneral.TableName.TopBottomWelding;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                default:
                    break;
            }


        }
        else if (ddlLine.SelectedValue == "2") // Rear Head Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.MC_LaserMark_RH;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Rear No.";
                    oSerialType = CGeneral.SerialType.RearHead;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "3") // Cylinder Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.MC_LaserMark_CY;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Cylinder No.";
                    oSerialType = CGeneral.SerialType.Cylinder;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "4") // Crank Shaft Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.MC_LaserMark_CS;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Crank Shaft No.";
                    oSerialType = CGeneral.SerialType.CrankShaft;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "5") // Front Head Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.MC_LaserMark_FH;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Front Head No.";
                    oSerialType = CGeneral.SerialType.FrontHead;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "6") // Piston Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.MC_LaserMark_Piston;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Piston No.";
                    oSerialType = CGeneral.SerialType.Piston;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "7") // Pipe Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.PipeMarking;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "2":
                    TableName = CGeneral.TableName.PipeIDCheck2;
                    TypeData = "MES";
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                default:
                    break;
            }
        }
        //else if (ddlLine.SelectedValue == "8") // Rotor Line
        //{
        //    switch (ddlMachine.SelectedValue)
        //    {
        //        case "1":
        //            TableName = "Laser Marking";
        //            TypeData = "MES";
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //else if (ddlLine.SelectedValue == "9") // Stator Line
        //{
        //    switch (ddlMachine.SelectedValue)
        //    {
        //        case "1":
        //            TableName = "Laser Marking";
        //            TypeData = "MES";
        //            break;
        //        default:
        //            break;
        //    }
        //}
        else if (ddlLine.SelectedValue == "10") // Final Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    TableName = CGeneral.TableName.vi_LabelPrinting;
                    TypeData = "MES";
                    break;
                case "2":
                    TableName = CGeneral.TableName.FN_RunningTest;
                    TypeData = "MES";
                    break;
                case "3":
                    TableName = CGeneral.TableName.vi_FN_OilFilling;
                    TypeData = "MES";
                    break;
                case "4":
                    TableName = CGeneral.TableName.FN_WeightCheck;
                    TypeData = "MES";
                    break;
                default:
                    break;
            }
            rbSearchSelect.Items[1].Enabled = true;
            lbSerialType.Text = "Label No.";
            oSerialType = CGeneral.SerialType.Label;
        }


        ViewState["TableName"] = TableName;
        ViewState["DateStart"] = txtDateStart.Text.Trim();
        ViewState["DateEnd"] = txtDateEnd.Text.Trim();
        if (rbSearchSelect.SelectedValue == "1")
        {
            oSerialType = CGeneral.SerialType.None;
        }
        //dt = oHis.GetDataMESIoTServer(TableName, txtDateStart.Text.Trim(), txtDateEnd.Text.Trim(), ddlModel.SelectedValue, oSerialType, txtSerialList.Text.Trim(),ddlPDYear.SelectedValue);


        return dt;
    }

    private void showData()
    {

        try
        {
            //Populating a DataTable from database.
            btnExcel.Enabled = true;

            dt = GetData();
            lblError.Text += "\r\n" + dt.Rows.Count.ToString();
            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            //Table start.
            //html.Append("<table class='dataTables table table-bordered stats-tbl-theme' >"); table table-striped table-advance table-hover
            //table data-tbl-boxy
            

            //Building the Header row.

            ArrayList arrHideColumn = new ArrayList();

            if (dt.Rows.Count > 0)
            {
                html.Append("<table id='example' class='table data-tbl-boxy'>");
                foreach (DataRow row in dt.Rows)
                {
                    if (check)
                    {
                        html.Append("<thead>");
                        html.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            //if (row[column.ColumnName].ToString() != "")
                            //{
                            html.Append("<th>");
                            html.Append(column.ColumnName);
                            html.Append("</th>");
                            //}
                            //else
                            //{
                            //    arrHideColumn.Add(column.ColumnName);
                            //}
                        }

                        html.Append("</tr>");
                        html.Append("</thead>");
                        html.Append("<tbody>");
                        check = false;
                    }

                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        //if (!(arrHideColumn.Contains(column.ColumnName)))
                        //{
                        html.Append("<td>");
                        html.Append(row[column.ColumnName].ToString());
                        html.Append("</td>");
                        //}
                    }
                    html.Append("</tr>");

                }
                html.Append("</tbody>");
                //Table end.
                html.Append("</table>");
            }
            else
            {
                
                html.Append("No Data!!");
            }

           

            //Append the HTML string to Placeholder.
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

        }
        catch
        {
            lblError.Text += "\r\n Error.";
        }
    }

    protected void ddlLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        //oGenControl.GenDDLMachineByLine(CGeneral.TypeSelect.Selected, ddlMachine, ddlLine.SelectedValue);
        oGenControl.GenDDLMachineManual(CGeneral.TypeSelect.Selected, ddlMachine, ddlLine.SelectedValue);
        noteLabel.Visible = false;
        if (ddlLine.SelectedValue == "10")
        {
            noteLabel.Visible = true;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        check = true;
        string result;
        result = txtSerialList.Text;
        string[] stringSeparators = new string[] { "\r\n" };
        string[] spl = result.Split(stringSeparators, StringSplitOptions.None);
        showData();

    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ExportExcelDataHistoryMain.ashx?TableName=" + ViewState["TableName"].ToString()
                + "&DateStart=" + ViewState["DateStart"].ToString() + "&DateEnd=" + ViewState["DateEnd"].ToString());
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Can't export data to excel.')", true);
        }
    }
    protected void rbSearchSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbSearchSelect.SelectedItem.Value == "1")
        {
            // Datetime
            panelDatetime.Visible = true;
            panelSerial.Visible = false;
            oSerialType = CGeneral.SerialType.None;
        }
        else
        {
            // Serial
            panelDatetime.Visible = false;
            panelSerial.Visible = true;
        }

        noteLabel.Visible = false;
        if (ddlLine.SelectedValue == "10")
        {
            noteLabel.Visible = true;
        }
    }
    protected void ddlMachine_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (ddlLine.SelectedValue == "1") // Main Assy
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Mecha or Rotor No.";
                    oSerialType = CGeneral.SerialType.RearAndRotor;
                    break;
                case "2":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Mecha No.";
                    oSerialType = CGeneral.SerialType.RearHead;
                    break;
                case "3":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "4":
                    rbSearchSelect.SelectedIndex = 0;
                    panelDatetime.Visible = true;
                    panelSerial.Visible = false;
                    rbSearchSelect.Items[1].Enabled = false;
                    oSerialType = CGeneral.SerialType.None;
                    break;
                case "5":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe & Rotor No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "6":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "7":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "8":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                default:
                    break;
            }


        }
        else if (ddlLine.SelectedValue == "2") // Rear Head Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Rear No.";
                    oSerialType = CGeneral.SerialType.RearHead;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "3") // Cylinder Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Cylinder No.";
                    oSerialType = CGeneral.SerialType.Cylinder;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "4") // Crank Shaft Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Crank Shaft No.";
                    oSerialType = CGeneral.SerialType.CrankShaft;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "5") // Front Head Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Front Head No.";
                    oSerialType = CGeneral.SerialType.FrontHead;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "6") // Piston Finish Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Piston No.";
                    oSerialType = CGeneral.SerialType.Piston;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "7") // Pipe Line
        {
            switch (ddlMachine.SelectedValue)
            {
                case "1":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                case "2":
                    rbSearchSelect.Items[1].Enabled = true;
                    lbSerialType.Text = "Pipe No.";
                    oSerialType = CGeneral.SerialType.Pipe;
                    break;
                default:
                    break;
            }
        }
        else if (ddlLine.SelectedValue == "10") // Final Line
        {
            rbSearchSelect.Items[1].Enabled = true;
            lbSerialType.Text = "Label No.";
            oSerialType = CGeneral.SerialType.Label;
            
        }
    }
}