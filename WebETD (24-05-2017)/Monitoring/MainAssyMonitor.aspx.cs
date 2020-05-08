using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Monitoring_MainAssyMonitor : System.Web.UI.Page
{
    GVSorting gSorting1 = new GVSorting();
    ConnectDBIoTServerTon oConn = new ConnectDBIoTServerTon();
    ConnectDBPDB oConnPDB = new ConnectDBPDB();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            InitialVariable();
            InitialControl();
            LoadData();
        }
    }

    private void InitialVariable()
    {

    }

    private void InitialControl()
    {

    }

    private void LoadData()
    {
        GetModel();
        GetPlan();
        LoadSumOfNG();
        LoadSumOfTotal();
        LoadSumOfOK();
    }

    private void GetPlan()
    {
        string Shift = "D";
        string _Date = "";
        if (txtDate.Text.Trim() == "")
        {
            _Date = DateTime.Now.ToString("yyyy/MM/dd");
        }
        else
        {
            _Date = txtDate.Text.Trim();
        }

        if (ddlShift.SelectedValue == "DAY")
        {
            Shift = "D";
        }
        else
        {
            Shift = "N";
        }
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT TOP 1 DailyPlan FROM DataLog WHERE BoardId='301' AND Shift='" + Shift + "' AND Convert(date,LogTime) = '" + _Date + "' ORDER BY LogTime DESC");
        dTable = oConnPDB.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            lbPlan.Text = dTable.Rows[0]["DailyPlan"].ToString() + " PCS";
        }
        else
        {
            lbPlan.Text = "0 PCS";
        }
        if (txtDate.Text.Trim() == "")
        {
            lbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        else
        {
            lbDate.Text = txtDate.Text.Trim();
        }
                
    }
    
    private void GetModel()
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT TOP 1 ModelNo FROM Rotor_Yakibame ORDER BY InsertDate DESC");
        dTable = oConn.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            if (dTable.Rows[0]["ModelNo"].ToString() == "121")
            {
                lbModel.Text = "1YC22DXD";
            }
            else if (dTable.Rows[0]["ModelNo"].ToString() == "442")
            {
                lbModel.Text = "1YC15BXD";
            }
            else if (dTable.Rows[0]["ModelNo"].ToString() == "444")
            {
                lbModel.Text = "1YC20HXD";
            }
            else
            {
                lbModel.Text = dTable.Rows[0]["ModelNo"].ToString();
            }
            
        }
        else
        {
            lbModel.Text = "-";
        }
    }

    private string GetModel(string ModelNo)
    {
        if (ModelNo == "121")
        {
            return "1YC22DXD";
        }
        else if (ModelNo == "442" || ModelNo == "441")
        {
            return "1YC15BXD";
        }
        else if (ModelNo == "444")
        {
            return "1YC20HXD";
        }
        else
        {
            return ModelNo;
        }
    }

    private void LoadSumOfNG()
    {
        string DateStart = "";
        string DateEnd = "";
        string _Date = "";
        if (txtDate.Text.Trim() == "")
        {
            _Date = DateTime.Now.ToString("yyyy/MM/dd");
        }
        else
        {
            _Date = txtDate.Text.Trim();
        }


        if (ddlShift.SelectedValue == "DAY")
        {
            DateStart = _Date + " " + " 08:00:00";
            DateEnd = _Date + " " + " 20:00:00";
        }
        else
        {
            DateStart = _Date + " " + " 20:00:00";
            DateEnd = Convert.ToDateTime(_Date).AddDays(1).ToString("yyyy/MM/dd") + " " + " 08:00:00";
        }

        lbRYNG.Text = "0";
        lbMGNG.Text = "0";
        lbPYNG.Text = "0";
        lbMCNG.Text = "0";
        lbAGNG.Text = "0";
        lbCCNG.Text = "0";

        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("exec dbo.GetNGSummaryAllMC_MainAssy '" + DateStart + "','" + DateEnd + "'");
        dTable = oConn.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                if (row["ProcessNG"].ToString() == CGeneral.ModeData.RotorYakibame.ToString())
                {
                    lbRYNG.Text = row["NGTotal"].ToString();
                }
                else if (row["ProcessNG"].ToString() == CGeneral.ModeData.Magnetize.ToString())
                {
                    lbMGNG.Text = row["NGTotal"].ToString();
                }
                else if (row["ProcessNG"].ToString() == CGeneral.ModeData.PipeYakibame.ToString())
                {
                    lbPYNG.Text = row["NGTotal"].ToString();
                }
                else if (row["ProcessNG"].ToString() == CGeneral.ModeData.MagnetCenter.ToString())
                {
                    lbMCNG.Text = row["NGTotal"].ToString();
                }
                else if (row["ProcessNG"].ToString() == CGeneral.ModeData.AG.ToString())
                {
                    lbAGNG.Text = row["NGTotal"].ToString();
                }
                else if (row["ProcessNG"].ToString() == CGeneral.ModeData.ElectricalConduction.ToString())
                {
                    lbCCNG.Text = row["NGTotal"].ToString();
                }

                //else if (row["ProcessNG"].ToString() == CGeneral.ModeData.TackWelding.ToString())
                //{
                //    lbNGTackWelding.Text = row["NGTotal"].ToString();
                //}
            }
        }
        else
        {
            lbRYNG.Text = "0";
            lbMGNG.Text = "0";
            lbPYNG.Text = "0";
            lbMCNG.Text = "0";
            lbAGNG.Text = "0";
            lbCCNG.Text = "0";
        }
    }

    private void LoadSumOfTotal()
    {
        // Check shift of day
        string DateStart = "";
        string DateEnd = "";
        string _Date = "";
        if (txtDate.Text.Trim() == "")
        {
            _Date = DateTime.Now.ToString("yyyy/MM/dd");
        }
        else
        {
            _Date = txtDate.Text.Trim();
        }


        if (ddlShift.SelectedValue == "DAY")
        {
            DateStart = _Date + " " + " 08:00:00";
            DateEnd = _Date + " " + " 20:00:00";
        }
        else
        {
            DateStart = _Date + " " + " 20:00:00";
            DateEnd = Convert.ToDateTime(_Date).AddDays(1).ToString("yyyy/MM/dd") + " " + " 08:00:00";
        }

        lbRYQty.Text = "0";
        lbMGQty.Text = "0";
        lbPYQty.Text = "0";
        lbMCQty.Text = "0";
        lbAGQty.Text = "0";
        lbCCQty.Text = "0";
        lbTWQty.Text = "0";
        lbTBWQty1.Text = "0";
        lbTBWQty2.Text = "0";

        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("exec GetOKSummaryAllMC_Main '" + DateStart + "','" + DateEnd + "'");
        dTable = oConn.Query(sbd.ToString());
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                if (row["ProcessOK"].ToString() == CGeneral.ModeData.RotorYakibame.ToString())
                {
                    lbRYQty.Text = row["TotalQty"].ToString();
                    lbRYModel.Text = GetModel(row["model"].ToString());
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.Magnetize.ToString())
                {
                    lbMGQty.Text = row["TotalQty"].ToString();
                    lbMGModel.Text = GetModel(row["model"].ToString());
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.PipeYakibame.ToString())
                {
                    lbPYQty.Text = row["TotalQty"].ToString();
                    lbPYModel.Text = GetModel(row["model"].ToString());
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.MagnetCenter.ToString())
                {
                    lbMCQty.Text = row["TotalQty"].ToString();
                    lbMCModel.Text = GetModel(row["model"].ToString());
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.AG.ToString())
                {
                    lbAGQty.Text = row["TotalQty"].ToString();
                    lbAGModel.Text = GetModel(row["model"].ToString());
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.ElectricalConduction.ToString())
                {
                    lbCCQty.Text = row["TotalQty"].ToString();
                    lbCCModel.Text = GetModel(row["model"].ToString());
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.TackWelding.ToString())
                {
                    lbTWQty.Text = row["TotalQty"].ToString();
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.TopBottomWeldingNo1.ToString())
                {
                    lbTBWQty1.Text = row["TotalQty"].ToString();
                    lbTBWModel1.Text = GetModel(row["model"].ToString());
                }
                else if (row["ProcessOK"].ToString() == CGeneral.ModeData.TopBottomWeldingNo2.ToString())
                {
                    lbTBWQty2.Text = row["TotalQty"].ToString();
                    lbTBWModel2.Text = GetModel(row["model"].ToString());
                }
            }
        }
        else
        {
            lbRYQty.Text = "0";
            lbMGQty.Text = "0";
            lbPYQty.Text = "0";
            lbMCQty.Text = "0";
            lbAGQty.Text = "0";
            lbCCQty.Text = "0";
            lbTWQty.Text = "0";
            lbTBWQty1.Text = "0";
            lbTBWQty2.Text = "0";

        }
    }

    private void LoadSumOfOK()
    {
        lbRYOK.Text = Convert.ToString(Convert.ToInt32(lbRYQty.Text.Trim()) - Convert.ToInt32(lbRYNG.Text.Trim()));
        lbMGOK.Text = Convert.ToString(Convert.ToInt32(lbMGQty.Text.Trim()) - Convert.ToInt32(lbMGNG.Text.Trim()));
        lbPYOK.Text = Convert.ToString(Convert.ToInt32(lbPYQty.Text.Trim()) - Convert.ToInt32(lbPYNG.Text.Trim()));
        lbTWOK.Text = Convert.ToString(Convert.ToInt32(lbTWQty.Text.Trim()));
        lbMCOK.Text = Convert.ToString(Convert.ToInt32(lbMCQty.Text.Trim()) - Convert.ToInt32(lbMCNG.Text.Trim()));
        lbAGOK.Text = Convert.ToString(Convert.ToInt32(lbAGQty.Text.Trim()) - Convert.ToInt32(lbAGNG.Text.Trim()));
        lbCCOK.Text = Convert.ToString(Convert.ToInt32(lbCCQty.Text.Trim()) - Convert.ToInt32(lbCCNG.Text.Trim()));
        lbTBWOK1.Text = lbTBWQty1.Text.Trim();
        lbTBWOK2.Text = lbTBWQty2.Text.Trim();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadData();
    }
}