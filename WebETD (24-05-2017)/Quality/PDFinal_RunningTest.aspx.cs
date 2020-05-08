using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Quality_PDFinal_RunningTest : System.Web.UI.Page
{
    private ConnectDBDCI oConDCI = new ConnectDBDCI();
    //private ConnectDBIoTFac3Costy oConIoTCosty = new ConnectDBIoTFac3Costy();
    //private ConnectDBIoT oConIoT = new ConnectDBIoT();


    ConnectDBFac3 oConIoT = new ConnectDBFac3();
    private string serial_no = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Open();
        }
    }

    private void Open()
    {
        try
        {
            serial_no = Request.QueryString["serial"].Trim().ToString();

            SqlCommand sqlSelect = new SqlCommand();
            sqlSelect.CommandText = "SELECT * FROM PD_FinalHold_Log WHERE prd_serial = @prd_serial ORDER BY HoldDate DESC";
            sqlSelect.Parameters.Add(new SqlParameter("@prd_serial", serial_no));
            sqlSelect.CommandTimeout = 180;
            DataTable dtSerial = oConDCI.Query(sqlSelect);
            if (dtSerial.Rows.Count > 0)
            {
                ltrModelName.Text = dtSerial.Rows[0]["prd_model"].ToString();
                ltrModelCode.Text = dtSerial.Rows[0]["prd_model_code"].ToString();
                ltrSerialNo.Text = dtSerial.Rows[0]["prd_serial"].ToString();
                ltrPipeNo.Text = dtSerial.Rows[0]["prd_pipe_no"].ToString();

            }
            else { }


            SqlCommand sqlSelectRN = new SqlCommand();
            sqlSelectRN.CommandText = "SELECT * FROM FN_RunningTest WHERE PartSerialNo = @prd_serial ORDER BY InsertDate DESC";
            sqlSelectRN.Parameters.Add(new SqlParameter("@prd_serial", serial_no));
            sqlSelectRN.CommandTimeout = 180;
            DataTable dtSerialRN = oConIoT.Query(sqlSelectRN);
            if (dtSerialRN.Rows.Count > 0)
            {
                rptData.DataSource = dtSerialRN;
                rptData.DataBind();
            }
            else
            {
                rptData.DataSource = null;
                rptData.DataBind();
            }

        }
        catch { }
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;

            Literal ltrDateShift = e.Item.FindControl("ltrDateShift") as Literal;
            Literal ltrModelNo = e.Item.FindControl("ltrModelNo") as Literal;
            Literal ltrMachineNo = e.Item.FindControl("ltrMachineNo") as Literal;
            Literal ltrPartSerialNo = e.Item.FindControl("ltrPartSerialNo") as Literal;
            Literal ltrCycleStartTime = e.Item.FindControl("ltrCycleStartTime") as Literal;
            Literal ltrCycleEndTime = e.Item.FindControl("ltrCycleEndTime") as Literal;
            Literal ltrManufacturingTime = e.Item.FindControl("ltrManufacturingTime") as Literal;
            Literal ltrConstantPressedTime = e.Item.FindControl("ltrConstantPressedTime") as Literal;
            Literal ltrConstantJudgement = e.Item.FindControl("ltrConstantJudgement") as Literal;
            Literal ltrRotationFrequencyArrivalTime = e.Item.FindControl("ltrRotationFrequencyArrivalTime") as Literal;
            Literal ltrRotationJudgement = e.Item.FindControl("ltrRotationJudgement") as Literal;
            Literal ltrExhalationTime = e.Item.FindControl("ltrExhalationTime") as Literal;
            Literal ltrExhalationJudgement = e.Item.FindControl("ltrExhalationJudgement") as Literal;
            Literal ltrDrivingCurrent = e.Item.FindControl("ltrDrivingCurrent") as Literal;
            Literal ltrDrivingJudgement = e.Item.FindControl("ltrDrivingJudgement") as Literal;
            Literal ltrVacuumArrivalTime = e.Item.FindControl("ltrVacuumArrivalTime") as Literal;
            Literal ltrVacuumJudgement = e.Item.FindControl("ltrVacuumJudgement") as Literal;
            Literal ltrVacuumHoldtimeJudgement = e.Item.FindControl("ltrVacuumHoldtimeJudgement") as Literal;
            Literal ltrIntegratedJudgementResult = e.Item.FindControl("ltrIntegratedJudgementResult") as Literal;
            Literal ltrInsulationInspectionResult = e.Item.FindControl("ltrInsulationInspectionResult") as Literal;
            Literal ltrResistingPressureInspection = e.Item.FindControl("ltrResistingPressureInspection") as Literal;
            Literal ltrWindingResistanceUV = e.Item.FindControl("ltrWindingResistanceUV") as Literal;
            Literal ltrWindingJudgement = e.Item.FindControl("ltrWindingJudgement") as Literal;
            Literal ltrIntegratedJudgementResult2 = e.Item.FindControl("ltrIntegratedJudgementResult2") as Literal;
            Literal ltrFluxMeasuredValue = e.Item.FindControl("ltrFluxMeasuredValue") as Literal;
            Literal ltrFluxJudgementResult = e.Item.FindControl("ltrFluxJudgementResult") as Literal;
            Literal ltrTempertureSurface = e.Item.FindControl("ltrTempertureSurface") as Literal;
            Literal ltrJudgementSeletedNo = e.Item.FindControl("ltrJudgementSeletedNo") as Literal;
            Literal ltrMachineNumber = e.Item.FindControl("ltrMachineNumber") as Literal;
            Literal ltrInsertDate = e.Item.FindControl("ltrInsertDate") as Literal;
            Literal ltrq_axis_a = e.Item.FindControl("ltrq_axis_a") as Literal;

            ltrDateShift.Text = drv["DateShift"].ToString();
            ltrModelNo.Text = drv["ModelNo"].ToString();
            ltrMachineNo.Text = drv["MachineNo"].ToString();
            ltrPartSerialNo.Text = drv["PartSerialNo"].ToString();
            ltrCycleStartTime.Text = drv["CycleStartTime"].ToString();
            ltrCycleEndTime.Text = drv["CycleEndTime"].ToString();
            ltrManufacturingTime.Text = drv["ManufacturingTime"].ToString();
            ltrConstantPressedTime.Text = drv["ConstantPressedTime"].ToString();
            ltrConstantJudgement.Text = (drv["ConstantJudgement"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["ConstantJudgement"].ToString() + "</span>" : drv["ConstantJudgement"].ToString();
            ltrRotationFrequencyArrivalTime.Text = drv["RotationFrequencyArrivalTime"].ToString();
            ltrRotationJudgement.Text = (drv["RotationJudgement"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["RotationJudgement"].ToString() + "</span>" : drv["RotationJudgement"].ToString();
            ltrExhalationTime.Text = drv["ExhalationTime"].ToString();
            ltrExhalationJudgement.Text = (drv["ExhalationJudgement"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["ExhalationJudgement"].ToString() + "</span>" : drv["ExhalationJudgement"].ToString();
            ltrDrivingCurrent.Text = drv["DrivingCurrent"].ToString();
            ltrDrivingJudgement.Text = (drv["DrivingJudgement"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["DrivingJudgement"].ToString() + "</span>" : drv["DrivingJudgement"].ToString();
            ltrVacuumArrivalTime.Text = drv["VacuumArrivalTime"].ToString();
            ltrVacuumJudgement.Text = (drv["VacuumJudgement"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["VacuumJudgement"].ToString() + "</span>" : drv["VacuumJudgement"].ToString();
            ltrVacuumHoldtimeJudgement.Text = (drv["VacuumHoldtimeJudgement"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["VacuumHoldtimeJudgement"].ToString() + "</span>" : drv["VacuumHoldtimeJudgement"].ToString();
            ltrIntegratedJudgementResult.Text = (drv["IntegratedJudgementResult"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["IntegratedJudgementResult"].ToString() + "</span>" : drv["IntegratedJudgementResult"].ToString();
            ltrInsulationInspectionResult.Text = (drv["InsulationInspectionResult"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["InsulationInspectionResult"].ToString() + "</span>" : drv["InsulationInspectionResult"].ToString();
            ltrResistingPressureInspection.Text = (drv["ResistingPressureInspection"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["ResistingPressureInspection"].ToString() + "</span>" : drv["ResistingPressureInspection"].ToString();
            ltrWindingResistanceUV.Text = drv["WindingResistanceUV"].ToString();
            ltrWindingJudgement.Text = (drv["WindingJudgement"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["WindingJudgement"].ToString() + "</span>" : drv["WindingJudgement"].ToString();
            ltrIntegratedJudgementResult2.Text = (drv["IntegratedJudgementResult2"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;' >" + drv["IntegratedJudgementResult2"].ToString() + "</span>" : drv["IntegratedJudgementResult2"].ToString();
            ltrFluxMeasuredValue.Text = drv["FluxMeasuredValue"].ToString();
            ltrFluxJudgementResult.Text = (drv["FluxJudgementResult"].ToString().ToUpper().Contains("NG")) ? "<span style='font-weight:bold;color:red;'>" + drv["FluxJudgementResult"].ToString() + "</span>" : drv["FluxJudgementResult"].ToString();
            ltrTempertureSurface.Text = drv["TempertureSurface"].ToString();
            ltrJudgementSeletedNo.Text = drv["JudgementSeletedNo"].ToString();
            ltrMachineNumber.Text = drv["MachineNumber"].ToString();
            ltrq_axis_a.Text = drv["q_axis_a"].ToString();
            ltrInsertDate.Text = Convert.ToDateTime(drv["InsertDate"].ToString()).ToString("dd/MM/yyyy HH:mm");
        }
    }




}