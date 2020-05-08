using EmployeeService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DCIManPower : System.Web.UI.Page
{

    private PSNEmployeewebservice oEmpSrv = new PSNEmployeewebservice();
    //private CLineEfficeincy oLineEff = new CLineEfficeincy();
    private CModelInfo oModel = new CModelInfo();
    private CGeneralDDL oGenDDL = new CGeneralDDL();
    //private CMachineInfo oMachine = new CMachineInfo();
    // private CCuttingToolsInfo oCutting = new CCuttingToolsInfo();
    //  private CEnergyInfo oEnergy = new CEnergyInfo();
    private ConnectDBCosty oConn = new ConnectDBCosty();
    private CPDData oPD = new CPDData();
    private CManpowerInfo oMP = new CManpowerInfo();
    //private ConnectDBIoT oConnn = new ConnectDBIoT();
    //private CTempOvenInfo oTempOven = new CTempOvenInfo();

    string BoardId = "", LinkManPower = "", LinkEfficeincy = "", LinkRawMat = "", LinkElectric = "",txtCostCenter="";
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    string[] montharr = { "January", "Fabuary", "March", "April", "May", "June", "July", "Auguest", "September", "October", "November", "December" };
    string Actual = "0";


    protected void Page_Load(object sender, EventArgs e)
    {
            DataTable dtt = new DataTable();

            if (!IsPostBack)
            {
                BoardId = Request.QueryString["BoardID"] != null ? Request.QueryString["BoardID"].ToString() : "301";
                //Cost_Center = Request.QueryString["BoardID"] != null ? Request.QueryString["BoardID"].ToString() : "301";

                if (BoardId == "302")
                {
                    // lbLineName.Text = "Mecha Assembly Line Factory 3";
                }
                //  hdBoard.Value = BoardId;
                ViewState["BoardID"] = BoardId;
                CountEmp();
                LinkManPower = "Manpower.aspx?BoardID=" + BoardId;
                LinkEfficeincy = "Efficeincy.aspx?BoardID=" + BoardId;
                LinkRawMat = "Manpower.aspx?BoardID=" + BoardId;
                LinkElectric = "Manpower.aspx?BoardID=" + BoardId;
                oGenDDL.GetDDLCostCenter(ddtabCostCenter);
                oGenDDL.GetDDLMonth(ddlTabMPMonth);
                oGenDDL.GetDDLYear(ddlTabMPYear);
                GetEmployeeData();
            }
     
    }
    private void CountEmp()
    {
        int CountFO = 0, CountLE = 0, CountOP = 0;
        string MGName = "...........", SUPName = "...........", FOName = "............";


        //----------- Get Data Employee form HR Service -----------
        var arrEmp = oEmpSrv.GetCheckEmployeeWorkingTimeByPDLine(ViewState["BoardID"].ToString(), DateTime.Now);
       
        foreach (EmployeePDWorkTimeInfo item in arrEmp)
        {
            switch (item.DataPosition.ToUpper())
            {
                case "SUP":
                    //SUPName = item.DataFName.ToUpper() + " " + item.DataLName.ToUpper();
                    break;
                case "FO":
                    CountFO++;
                    FOName = item.DataFName.ToUpper() + " " + item.DataLName.ToUpper();
                    break;
                case "LE":
                    CountLE++;
                    break;
                case "OP":
                    CountOP++;
                    break;
            }
        }
        //lbManager.Text = MGName;
        //lbSup.Text = SUPName;
        //   lbFO.Text = FOName;
       // lbSumOT1.Text = CountOP.ToString("N0");
        //lbCountEmp.Text = "FO : " + CountFO + "<br /> LE : " + CountLE + "<br />OP : " + CountOP;
    }
    public void GetEmployeeData()
    {
        //ddlTabMPMonth.SelectedValue = "4";
        int MonthSelect = Convert.ToInt16(ddlTabMPMonth.SelectedValue.ToString());

        //---------------------- Set Header Column MonthName and Colspan ------------------------
        //colMonthName.Attributes.Add("colspan", (DateTime.DaysInMonth(DateTime.Now.Year, MonthSelect) * 2).ToString());
        //colMonthName.Style.Add(HtmlTextWriterStyle.TextAlign, "center");
        //lbTabMpMonthName.Text = montharr[MonthSelect - 1];
        //---------------------- Set Header Column MonthName and Colspan ------------------------

        //---------------------- Create table show accumulate OT miniute -----------------
        lbTabMPHeaderWorkingHour.Text = "Working Hour of : " + montharr[MonthSelect - 1] + " (Minute.)";
        DataTable dtWorkingHour = new DataTable();
        dtWorkingHour.Columns.Add("Position", typeof(string));
        dtWorkingHour.Columns.Add("OT1", typeof(string));
        dtWorkingHour.Columns.Add("OT15", typeof(string));
        dtWorkingHour.Columns.Add("OT2", typeof(string));
        dtWorkingHour.Columns.Add("OT3", typeof(string));
        string[] arrPotition = { "OP", "LE", "FO", "SU" };
        foreach (string item in arrPotition)
        {
            dtWorkingHour.Rows.Add(item, "", "", "", "");
        }

        rptTabMpWorkingHour.DataSource = dtWorkingHour;
        rptTabMpWorkingHour.DataBind();
        //---------------------- Create table show accumulate OT miniute -----------------

 /*       DataTable dtColDay = new DataTable();
        dtColDay.Columns.Add("Day", typeof(string));
        for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, MonthSelect); i++)
        {
            dtColDay.Rows.Add(i.ToString());
        }
        rptTabMpColDay.DataSource = dtColDay;
        rptTabMpColDay.DataBind();

        //------------- Create column header OT  -----------------
        for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, MonthSelect); i++)
        {
            DateTime setDateColOT = new DateTime(DateTime.Now.Year, MonthSelect, i);
            if (setDateColOT.DayOfWeek == DayOfWeek.Saturday || setDateColOT.DayOfWeek == DayOfWeek.Sunday)
            {
                litColOT.Text += "<th id=\"name" + i + "\" style=\"font-size:14px;text-align:center;border-left: 1px solid black;\">1/2</th>" + Environment.NewLine;
                litColOT.Text += "<th id=\"name" + i + ".5\" style=\"font-size:14px;text-align:center;border-left: 1px solid black;\">3</th>" + Environment.NewLine;
            }
            else
            {
                litColOT.Text += "<th id=\"name" + i + "\" style=\"font-size:14px;text-align:center;border-left: 1px solid black;\">1</th>" + Environment.NewLine;
                litColOT.Text += "<th id=\"name" + i + ".5\" style=\"font-size:14px;text-align:center;border-left: 1px solid black;\">1.5</th>" + Environment.NewLine;
            }
        }*/
        //------------- Create column header OT  -----------------

        //---------------- Get Employeee of Line --------------
        DataTable dtEmp = new DataTable();
        dtEmp.Columns.Add("Code", typeof(string));
        dtEmp.Columns.Add("Position", typeof(string));
        DateTime setDate = new DateTime(DateTime.Now.Year, MonthSelect, 1);

        SqlCommand sql = new SqlCommand();
       /* sql.CommandText = "SELECT e.CODE, POSIT FROM [Employee] e " +
        " where ANDON = '" + ViewState["BoardID"].ToString() + "' AND RESIGN IS NULL  ORDER BY e.CODE";*/
        if (ddtabCostCenter.SelectedValue == "ALL")
        {
            txtCostCenter = " < '9000' ";
        }
        else
        {
            txtCostCenter = "= '"+ ddtabCostCenter.SelectedValue.Substring(0, 4) +"'";
        }


        sql.CommandText = "SELECT e.CODE, POSIT FROM [Employee] e " +
        " where [COSTCENTER] " + txtCostCenter + " ORDER BY e.CODE";

        DataTable dt = oConn.SqlGet(sql, "DBDCI");
        foreach (DataRow item in dt.Rows)
        {
            DataRow _rowEmp = dtEmp.NewRow();
            _rowEmp["Code"] = item["CODE"].ToString();
            _rowEmp["Position"] = item["POSIT"].ToString();
            dtEmp.Rows.Add(_rowEmp);
        }
        //  lbMP.Text = dtEmp.Rows.Count.ToString();
        //---------------- Get Employeee of Line --------------        

        //----------------- Create row content Manpower ------------------
        int accuOP1 = 0, accuOP15 = 0, accuOP2 = 0, accuOP3 = 0, CountMPOP = 1;
        int accuLE1 = 0, accuLE15 = 0, accuLE2 = 0, accuLE3 = 0, CountMPLE = 1;
        int accuFO1 = 0, accuFO15 = 0, accuFO2 = 0, accuFO3 = 0, CountMPFO = 1;
        int accuSU1 = 0, accuSU15 = 0, accuSU2 = 0, accuSU3 = 0, CountMPSU = 1;
        if (dtEmp.Rows.Count > 0)
        {
            foreach (DataRow _rowMP in dtEmp.Rows)
            {
                int idxMP = 0;
                //--------------- Get Employee working Time ---------------------
                DataTable dtempWorkingTime = new DataTable();
                dtempWorkingTime = oMP.GetEmployeeWorkTimeOfMonth(_rowMP["Code"].ToString(), setDate.Month);
                //--------------- Get Employee working Time ---------------------

                for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, MonthSelect); i++)
                {
                    setDate = new DateTime(DateTime.Now.Year, MonthSelect, i);
                    //----------------- Fillter Working Time -------------
                    bool Working = false;
                    string OT1 = "-", OT15 = "-", OT2 = "-", OT3 = "-";
                    if (dtempWorkingTime.Rows.Count > 0)
                    {
                        DataRow[] fillWork = dtempWorkingTime.Select("WorkDate = '" + setDate.ToString("yyyy-MM-dd") + "'");
                        if (fillWork.Length > 0)
                        {
                            OT1 = Convert.ToInt16(fillWork[0]["OT1"]) > 0 ? Convert.ToInt16(fillWork[0]["OT1"]).ToString() : "-";
                            OT15 = Convert.ToInt16(fillWork[0]["OT15"]) > 0 ? Convert.ToInt16(fillWork[0]["OT15"]).ToString() : "-";
                            OT2 = Convert.ToInt16(fillWork[0]["OT2"]) > 0 ? Convert.ToInt16(fillWork[0]["OT2"]).ToString() : "-";
                            OT3 = Convert.ToInt16(fillWork[0]["OT3"]) > 0 ? Convert.ToInt16(fillWork[0]["OT3"]).ToString() : "-";
                            Working = true;

                            //-------------------- Get OT Working Summary Each Position ---------------------
                            #region
                            if (_rowMP["Position"].ToString() == "OP" || _rowMP["Position"].ToString() == "OP.S")
                            {
                                accuOP1 += Convert.ToInt16(fillWork[0]["OT1"]) > 0 ? Convert.ToInt16(fillWork[0]["OT1"]) : 0;
                                accuOP15 += Convert.ToInt16(fillWork[0]["OT15"]) > 0 ? Convert.ToInt16(fillWork[0]["OT15"]) : 0;
                                accuOP2 += Convert.ToInt16(fillWork[0]["OT2"]) > 0 ? Convert.ToInt16(fillWork[0]["OT2"]) : 0;
                                accuOP3 += Convert.ToInt16(fillWork[0]["OT3"]) > 0 ? Convert.ToInt16(fillWork[0]["OT3"]) : 0;
                                CountMPOP += 1;
                            }
                            else if (_rowMP["Position"].ToString() == "LE" || _rowMP["Position"].ToString() == "LE.S")
                            {
                                accuLE1 += Convert.ToInt16(fillWork[0]["OT1"]) > 0 ? Convert.ToInt16(fillWork[0]["OT1"]) : 0;
                                accuLE15 += Convert.ToInt16(fillWork[0]["OT15"]) > 0 ? Convert.ToInt16(fillWork[0]["OT15"]) : 0;
                                accuLE2 += Convert.ToInt16(fillWork[0]["OT2"]) > 0 ? Convert.ToInt16(fillWork[0]["OT2"]) : 0;
                                accuLE3 += Convert.ToInt16(fillWork[0]["OT3"]) > 0 ? Convert.ToInt16(fillWork[0]["OT3"]) : 0;
                                CountMPLE += 1;
                            }
                            else if (_rowMP["Position"].ToString() == "FO" || _rowMP["Position"].ToString() == "FO.S")
                            {
                                accuFO1 += Convert.ToInt16(fillWork[0]["OT1"]) > 0 ? Convert.ToInt16(fillWork[0]["OT1"]) : 0;
                                accuFO15 += Convert.ToInt16(fillWork[0]["OT15"]) > 0 ? Convert.ToInt16(fillWork[0]["OT15"]) : 0;
                                accuFO2 += Convert.ToInt16(fillWork[0]["OT2"]) > 0 ? Convert.ToInt16(fillWork[0]["OT2"]) : 0;
                                accuFO3 += Convert.ToInt16(fillWork[0]["OT3"]) > 0 ? Convert.ToInt16(fillWork[0]["OT3"]) : 0;
                                CountMPFO += 1;
                            }
                            else if (_rowMP["Position"].ToString() == "SU" || _rowMP["Position"].ToString() == "SU.S")
                            {
                                accuSU1 += Convert.ToInt16(fillWork[0]["OT1"]) > 0 ? Convert.ToInt16(fillWork[0]["OT1"]) : 0;
                                accuSU15 += Convert.ToInt16(fillWork[0]["OT15"]) > 0 ? Convert.ToInt16(fillWork[0]["OT15"]) : 0;
                                accuSU2 += Convert.ToInt16(fillWork[0]["OT2"]) > 0 ? Convert.ToInt16(fillWork[0]["OT2"]) : 0;
                                accuSU3 += Convert.ToInt16(fillWork[0]["OT3"]) > 0 ? Convert.ToInt16(fillWork[0]["OT3"]) : 0;
                                CountMPSU += 1;
                            }
                            #endregion
                            //-------------------- Get OT Working Summary Each Position ---------------------
                        }
                    }
                    //----------------- Fillter Working Time -------------

                    //    if (idxMP == 0)
                    //    {
                    //        ltiColMPContent.Text += "<tr> " + Environment.NewLine;
                    //        ltiColMPContent.Text += "<td style=\"font-weight:bold;text-align:center\">" + _rowMP["Code"].ToString() + "</td>" + Environment.NewLine;
                    //    }

                    //    if (setDate.DayOfWeek == DayOfWeek.Saturday || setDate.DayOfWeek == DayOfWeek.Sunday)
                    //    {
                    //        ltiColMPContent.Text += "<td style=\"font-weight:bold;text-align:center;background-color:#fbffa0\">" + OT1 + "</td>" + Environment.NewLine;
                    //        ltiColMPContent.Text += "<td style=\"font-weight:bold;text-align:center;background-color:#fbffa0\">" + OT3 + "</td>" + Environment.NewLine;
                    //    }
                    //    else
                    //    {
                    //        if (setDate.Date <= DateTime.Now.Date)
                    //        {
                    //            ltiColMPContent.Text += Working == true ? "<td style=\"font-weight:bold;text-align:center;background-color:#83ff68\">" + OT1 + "</td>" : "<td style=\"font-weight:bold;text-align:center;background-color:#ff7f7f\">" + OT1 + "</td>" + Environment.NewLine;
                    //            ltiColMPContent.Text += Working == true ? "<td style=\"font-weight:bold;text-align:center;background-color:#83ff68\">" + OT15 + "</td>" : "<td style=\"font-weight:bold;text-align:center;background-color:#ff7f7f\">" + OT15 + "</td>" + Environment.NewLine;
                    //        }
                    //        else
                    //        {
                    //            ltiColMPContent.Text += "<td style=\"font-weight:bold;text-align:center\">" + OT1 + "</td>" + Environment.NewLine;
                    //            ltiColMPContent.Text += "<td style=\"font-weight:bold;text-align:center\">" + OT15 + "</td>" + Environment.NewLine;
                    //        }
                    //    }

                    //    idxMP++;
                    //}

                    //ltiColMPContent.Text += "</tr>" + Environment.NewLine;
                }


                double MPOP = 40, MPLE = 50, MPFO = 90, MPSU = 100;
                double totalOP = 0, totalLE = 0, totalFO = 0, totalSU = 0, TotalOT1 = 0, TotalOT15 = 0, TotalOT2 = 0, TotalOT3 = 0, TotalSum = 0;
                double SumTimeOP = 0, SumTimeLE = 0, SumTimeFO = 0, SumTimeSU = 0;
                //-------------------- Get OT Working Summary Each Position ---------------------
                #region
                foreach (RepeaterItem item in rptTabMpWorkingHour.Items)
                {
                    Label lbPosi = item.FindControl("lbPositionWKHr") as Label;
                    Label lpMPC = item.FindControl("lpMPCount") as Label;
                    Label lbOT1 = item.FindControl("lbOT1") as Label;
                    Label lbOT15 = item.FindControl("lbOT15") as Label;
                    Label lbOT2 = item.FindControl("lbOT2") as Label;
                    Label lbOT3 = item.FindControl("lbOT3") as Label;
                    Label lbSumTime = item.FindControl("lbSumTime") as Label;
                    Label lbBudget = item.FindControl("lbBudget") as Label;


                    if (lbPosi.Text == "OP")
                    {
                        lpMPC.Text = CountMPOP.ToString("N0");
                        lbOT1.Text = accuOP1.ToString("N0");
                        lbOT15.Text = accuOP15.ToString("N0");
                        lbOT2.Text = accuOP2.ToString("N0");
                        lbOT3.Text = accuOP3.ToString("N0");
                     

                        totalOP += ((accuOP1/60) * MPOP);
                        totalOP += ((accuOP15/60) * (MPOP * 1.5));
                        totalOP += ((accuOP3/60) * (MPOP * 3));
                        lbBudget.Text = totalOP.ToString("N0");


                        SumTimeOP += (accuOP1);
                        SumTimeOP += (accuOP15);
                        SumTimeOP += (accuOP3);
                        lbSumTime.Text = SumTimeOP.ToString("N0");
                    }
                    else if (lbPosi.Text == "LE")
                    {
                        lpMPC.Text = CountMPLE.ToString("N0");
                        lbOT1.Text = accuLE1.ToString("N0");
                        lbOT15.Text = accuLE15.ToString("N0");
                        lbOT2.Text = accuLE2.ToString("N0");
                        lbOT3.Text = accuLE3.ToString("N0");

                        totalLE += ((accuLE1/60) * MPLE);
                        totalLE += ((accuLE15/60) * (MPLE * 1.5));
                        totalLE += ((accuLE3/60) * (MPLE * 3));
                        lbBudget.Text = totalLE.ToString("N0");

                        SumTimeLE += (accuLE1);
                        SumTimeLE += (accuLE15);
                        SumTimeLE += (accuLE3);
                        lbSumTime.Text = SumTimeLE.ToString("N0");
                    }
                    else if (lbPosi.Text == "FO")
                    {
                        lpMPC.Text = CountMPFO.ToString("N0");
                        lbOT1.Text = accuFO1.ToString("N0");
                        lbOT15.Text = accuFO15.ToString("N0");
                        lbOT2.Text = accuFO2.ToString("N0");
                        lbOT3.Text = accuFO3.ToString("N0");


                        totalFO += ((accuFO1/60) * MPFO);
                        totalFO += ((accuFO15/60) * (MPFO * 1.5));
                        totalFO += ((accuFO3/60) * (MPFO * 3));
                        lbBudget.Text = totalFO.ToString("N0");


                        SumTimeFO += (accuFO1);
                        SumTimeFO += (accuFO15);
                        SumTimeFO += (accuFO3);
                        lbSumTime.Text = SumTimeFO.ToString("N0");
                    }
                    else if (lbPosi.Text == "SU")
                    {
                        lpMPC.Text = CountMPSU.ToString("N0");
                        lbOT1.Text = accuSU1.ToString("N0");
                        lbOT15.Text = accuSU15.ToString("N0");
                        lbOT2.Text = accuSU2.ToString("N0");
                        lbOT3.Text = accuSU3.ToString("N0");


                        totalSU += ((accuSU1/60) * MPSU);
                        totalSU += ((accuSU15/60) * (MPSU * 1.5));
                        totalSU += ((accuSU3/60) * (MPSU * 3));
                        lbBudget.Text = totalSU.ToString("N0");
                        
                        SumTimeSU += (accuSU1);
                        SumTimeSU += (accuSU15);
                        SumTimeSU += (accuSU3);
                        lbSumTime.Text = SumTimeSU.ToString("N0");
                    }
                    
                }
                //TotalOT1 = accuOP1 + accuLE1 + accuFO1 + accuSU1;
                //TotalOT15 = accuOP15 + accuLE15 + accuFO15 + accuSU15;
                //TotalOT3 = accuOP3 + accuLE3 + accuFO3 + accuSU3;
                //TotalSum = SumTimeOP + SumTimeLE + SumTimeFO + SumTimeSU;

                //lbOT1.Text = TotalOT1.ToString("N0");
                //lbOT15.Text = TotalOT15.ToString("N0");
                //lbOT2.Text = "";
                //lbOT3.Text = TotalOT3.ToString("N0");
                //lbSumTime.Text = TotalSum.ToString("N0");
                #endregion
                //-------------------- Get OT Working Summary Each Position ---------------------


                //-------------- Claculate MP Money ---------------

            }
            //----------------- Create row content Manpower ------------------
        }
    }

    protected void rptTabMpColDay_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbDay = e.Item.FindControl("lbColDay") as Label;
            HtmlTableCell day = e.Item.FindControl("dayHead") as HtmlTableCell;
            if (Convert.ToInt16(lbDay.Text) > DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt16(ddlTabMPMonth.SelectedValue.ToString())))
            {
                day.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }
    }

    protected void ddlTabMPMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //rptTabMpColDay.DataSource = null;
        //rptTabMpColDay.DataBind();

        rptTabMpWorkingHour.DataSource = null;
        rptTabMpWorkingHour.DataBind();

        //litColOT.Text = "";
        //ltiColMPContent.Text = "";
        GetEmployeeData();
    }

    protected void ddlTabMPYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        //rptTabMpColDay.DataSource = null;
        //rptTabMpColDay.DataBind();

        rptTabMpWorkingHour.DataSource = null;
        rptTabMpWorkingHour.DataBind();

        //litColOT.Text = "";
        //ltiColMPContent.Text = "";
        GetEmployeeData();
    }
    protected void CBMP_SelectIndexChanged(object sender, EventArgs e)
    {
        //rptTabMpColDay.DataSource = null;
        //rptTabMpColDay.DataBind();

        rptTabMpWorkingHour.DataSource = null;
        rptTabMpWorkingHour.DataBind();

        //litColOT.Text = "";
        //ltiColMPContent.Text = "";
       // GetEmployeeData();
    }

    protected void ddtabCostCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //rptTabMpColDay.DataSource = null;
        //rptTabMpColDay.DataBind();

        rptTabMpWorkingHour.DataSource = null;
        rptTabMpWorkingHour.DataBind();
       
        //litColOT.Text = "";
        //ltiColMPContent.Text = "";
        GetEmployeeData();
    }
    //------------ Get Tab Manpower -------------//
}