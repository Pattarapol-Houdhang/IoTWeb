using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CGenControl
/// </summary>
public class CGenControl
{
    ConnectDB oConn = new ConnectDB();
    ConnectDBIoTFac3Costy oConIoTFac3 = new ConnectDBIoTFac3Costy();
    ConnectDBIoTServerTonMecha oConnMecha = new ConnectDBIoTServerTonMecha();
    

    public void GenDDLLineData(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT ld_id,ld_linename,FactoryName FROM LineData ld");
        sbd.AppendLine("LEFT JOIN FactoryData fa ON ld.FactoryID=fa.FactoryID");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["ld_linename"].ToString() + " | " + row["FactoryName"].ToString()
                    , row["ld_id"].ToString()));
            }
        }
    }

    public void GenDDLLineDataByFactoryID(CGeneral.TypeSelect Type, DropDownList obj, int FactoryID)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT ld_id,ld_linename FROM LineData ld");
        sbd.AppendLine("LEFT JOIN FactoryData fd ON ld.FactoryID=fd.FactoryID");
        sbd.AppendLine("WHERE ld.FactoryID=" + FactoryID);
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["ld_linename"].ToString()
                    , row["ld_id"].ToString()));
            }
        }
    }
    public void GenDDLLineDataByManPowerMachineID(CGeneral.TypeSelect Type, DropDownList obj, int LineID)
    {
        //DataTable dTable = new DataTable();
        //StringBuilder sbd = new StringBuilder();
        //if (LineID == 37)
        //{
        //    sbd.AppendLine("SELECT ld_id,ld_linename FROM LineData ld");
        //    sbd.AppendLine("LEFT JOIN FactoryData fd ON ld.FactoryID=fd.FactoryID");
        //    sbd.AppendLine("WHERE ld.ld_id =" + LineID);
        //}
        
       // dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "-ALL-"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        //if (dTable.Rows.Count > 0)
        //{
        //    foreach (DataRow row in dTable.Rows)
        //    {
        //        obj.Items.Add(new ListItem(row["ld_linename"].ToString()
        //            , row["ld_id"].ToString()));
        //    }
        //}
        if (LineID == 37)
        {
           obj.Items.Add(new ListItem("ODM Outdoor Ft1", "37")); 
        }
        else if (LineID == 8)
        {
            obj.Items.Add(new ListItem("Motor", "8"));
        }
        else if (LineID == 4)
        {
            obj.Items.Add(new ListItem("Main Assembly Line 6", "4"));
        }
        else if (LineID == 10)
        {
            obj.Items.Add(new ListItem("Final Line 6", "10"));
        }
        else if (LineID == 11)
        {
            obj.Items.Add(new ListItem("Mecha Line 6", "11"));
        }
        else if (LineID == 1)
        {
            obj.Items.Add(new ListItem("Rear Head Line 6", "1"));
        }
        else if (LineID == 6)
        {
            obj.Items.Add(new ListItem("Cylinder Line 6", "6"));
        }
        else if (LineID == 7)
        {
            obj.Items.Add(new ListItem("Crank Shaft Line 6", "7"));
        }
        else if (LineID == 16)
        {
            obj.Items.Add(new ListItem("Front Head Line 6", "16"));

        }
        else if (LineID == 5)
        {
            obj.Items.Add(new ListItem("Piston Line 6", "5"));
        }
    }

    public void GenDDLMachine(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT mc_code,mc_name FROM machine");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["mc_code"].ToString() + "_" + row["mc_name"].ToString()
                    , row["mc_code"].ToString()));
            }
        }
    }
    public void GenDDLMachineByLine(CGeneral.TypeSelect Type, DropDownList obj, string ld_id)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT mc_code,mc_name FROM machine WHERE ld_id = '" + ld_id + "' and mc_active='1' order by mc_order");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "-ALL-"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            bool FianlLineCheck = false;
            foreach (DataRow row in dTable.Rows)
            {
                //if (row["mc_code"].ToString() != "" && row["mc_code"].ToString().Length >= 16)
                //{
                //    if (row["mc_code"].ToString().Substring(0, 16) == "FN_RunningTestNo" && !FianlLineCheck)
                //    {
                //        obj.Items.Add(new ListItem("Running Test All M/C"
                //        , "FinalRunningTest"));
                //        FianlLineCheck = true;
                //    }
                //}

                obj.Items.Add(new ListItem(row["mc_name"].ToString()
                    , row["mc_code"].ToString()));
            }
        }
    }
    public void GenDDLMachineManpowerByLine(CGeneral.TypeSelect Type, DropDownList obj, string ld_id)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        if (ld_id == "37")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'ODM_OD1'");
        }
        else if (ld_id == "8")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'Motor6'");
        }
        else if (ld_id == "4")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'Main6'");
        }
        else if (ld_id == "10")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'Final6'");
        }
        else if (ld_id == "11")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'Mecha'");
        }
        else if (ld_id == "1")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'MC_RH6'");
        }
        else if (ld_id == "6")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'MC_CY6'");
        }
        else if (ld_id == "16")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'MC_FH6'");
        }
        else if (ld_id == "7")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'MC_CS6'");
        }
        else if (ld_id == "5")
        {
            sbd.AppendLine("SELECT distinct LocationName FROM [ManPowerLog] WHERE Line = 'MC_PT6'");
        }
        dTable = oConIoTFac3.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "-ALL-"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            bool FianlLineCheck = false;
            foreach (DataRow row in dTable.Rows)
            {
                //if (row["mc_code"].ToString() != "" && row["mc_code"].ToString().Length >= 16)
                //{
                //    if (row["mc_code"].ToString().Substring(0, 16) == "FN_RunningTestNo" && !FianlLineCheck)
                //    {
                //        obj.Items.Add(new ListItem("Running Test All M/C"
                //        , "FinalRunningTest"));
                //        FianlLineCheck = true;
                //    }
                //}

                obj.Items.Add(new ListItem(row["LocationName"].ToString()
                    , row["LocationName"].ToString()));
            }
        }
    }

    public void GenDDLModel(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT model_code,model_name FROM model");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["model_code"].ToString() + ", " + row["model_name"].ToString()
                    , row["model_code"].ToString()));
            }
        }
    }

    public void GenDDLModelByMachine(CGeneral.TypeSelect Type, DropDownList obj, string mc_code)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT DISTINCT m.model_code,m.model_name");
        sbd.AppendLine("FROM data d");
        sbd.AppendLine("LEFT JOIN model m ON d.model_id = m.model_id");
        sbd.AppendLine("WHERE mc_code = '" + mc_code + "' ");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["model_code"].ToString() + ", " + row["model_name"].ToString()
                    , row["model_code"].ToString()));
            }
        }
    }

    public void GenDDLHeader(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT header_id,header_detail");
        sbd.AppendLine("FROM headerMaster");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["header_detail"].ToString()
                    , row["header_id"].ToString()));
            }
        }
    }

    public void GenDDLIndexColumn(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT index_id,index_datetime,index_partnumber,index_modelcode,index_result,index_value");
        sbd.AppendLine("FROM IndexColumn");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem("Date:" + row["index_datetime"].ToString() + ", PartNo:" + row["index_partnumber"].ToString()
                    + ", Model:" + row["index_modelcode"].ToString() + ", Result:" + row["index_result"].ToString()
                    + ", Value:" + row["index_value"].ToString()
                    , row["index_id"].ToString()));
            }
        }
    }

    public void GenDDLFactory(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT FactoryID,FactoryName");
        sbd.AppendLine("FROM FactoryData");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["FactoryName"].ToString(), row["FactoryID"].ToString()));
            }
        }
    }

    public void GenDDLLineManual(CGeneral.TypeSelect Type, DropDownList obj)
    {
        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        obj.Items.Add(new ListItem("Main Assembly Line", "1"));
        obj.Items.Add(new ListItem("Rear Head Finish Line", "2"));
        obj.Items.Add(new ListItem("Cylineder Finish Line", "3"));
        obj.Items.Add(new ListItem("Crank Shaft Finish Line", "4"));
        obj.Items.Add(new ListItem("Front Head Finish Line", "5"));
        obj.Items.Add(new ListItem("Piston Line", "6"));
        obj.Items.Add(new ListItem("Casing Pipe Line", "7"));
        //obj.Items.Add(new ListItem("Rotor Line", "8"));
        //obj.Items.Add(new ListItem("Stator Line", "9"));
        obj.Items.Add(new ListItem("Final Line", "10"));

    }

    public void GenDDLMachineManual(CGeneral.TypeSelect Type, DropDownList obj, string LineNo)
    {
        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", "0"));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        switch (LineNo)
        {
            case "1": // Main Assy
                obj.Items.Add(new ListItem("Rotor Yakibame", "1"));
                obj.Items.Add(new ListItem("Magnetize", "2"));
                obj.Items.Add(new ListItem("Pipe Yakibame", "3"));
                obj.Items.Add(new ListItem("Tack Welding", "4"));
                obj.Items.Add(new ListItem("Magnet Center", "5"));
                obj.Items.Add(new ListItem("Air Gap", "6"));
                obj.Items.Add(new ListItem("Connecting Check", "7"));
                obj.Items.Add(new ListItem("Top Bottom Welding", "8"));
                break;
            case "2": // RH
                obj.Items.Add(new ListItem("Laser Marking", "1"));
                break;
            case "3": // CY
                obj.Items.Add(new ListItem("Laser Marking", "1"));
                break;
            case "4": // CS
                obj.Items.Add(new ListItem("Laser Marking", "1"));
                break;
            case "5": // FH
                obj.Items.Add(new ListItem("Laser Marking", "1"));
                break;
            case "6": // PT
                obj.Items.Add(new ListItem("Laser Marking", "1"));
                break;
            case "7": // Pipe
                obj.Items.Add(new ListItem("Laser Marking", "1"));
                obj.Items.Add(new ListItem("Pipe ID Check", "2"));
                break;
            case "8": // Rotor
                //obj.Items.Add(new ListItem("Laser Marking", "1"));
                break;
            case "9": // Stator
                //obj.Items.Add(new ListItem("Laser Marking", "1"));
                break;
            case "10": // Final
                obj.Items.Add(new ListItem("Label Printing", "1"));
                obj.Items.Add(new ListItem("Running Test", "2"));
                obj.Items.Add(new ListItem("Oil Filling", "3"));
                obj.Items.Add(new ListItem("Final Weight Check", "4"));
                break;
            case "11": // Mecha
                obj.Items.Add(new ListItem("Front Head", "1"));
                obj.Items.Add(new ListItem("Rear Head", "2"));
                obj.Items.Add(new ListItem("Crank Shaft", "3"));
                obj.Items.Add(new ListItem("Cylinder", "4"));
                obj.Items.Add(new ListItem("Piston", "5"));
                obj.Items.Add(new ListItem("Matching", "6"));
                obj.Items.Add(new ListItem("Cylinder Centering", "7"));
                obj.Items.Add(new ListItem("Rear Centering", "8"));
                obj.Items.Add(new ListItem("Torque Check", "9"));
                break;
        }


    }

    public void GenDDLAlarmLine(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT DISTINCT LineName");
        sbd.AppendLine("FROM AlarmLineSetting");
        dTable = oConnMecha.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", ""));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["LineName"].ToString(), row["LineName"].ToString()));
            }
        }
    }

    public void GenDDLAlarmMachineByLine(CGeneral.TypeSelect Type, DropDownList obj, string LineName)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT DISTINCT MachineName");
        sbd.AppendLine("FROM AlarmLineSetting");
        sbd.AppendLine("WHERE LineName='" + LineName + "'");
        dTable = oConnMecha.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", ""));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["MachineName"].ToString(), row["MachineName"].ToString()));
            }
        }
    }

    public void GenDDLPartType(CGeneral.TypeSelect Type, DropDownList obj)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT DISTINCT PartType");
        sbd.AppendLine("FROM QC_StandardMaster");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", ""));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["PartType"].ToString().Replace('_', ' '), row["PartType"].ToString()));
            }
        }
    }

    public void GenDDLMainPointByPartType(CGeneral.TypeSelect Type, DropDownList obj, string PartType)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT DISTINCT MainPoint");
        sbd.AppendLine("FROM QC_StandardMaster");
        sbd.AppendLine("WHERE PartType = '" + PartType + "'");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", ""));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["MainPoint"].ToString().Replace('_', ' '), row["MainPoint"].ToString()));
            }
        }
    }

    public void GenDDLSubPointByPartTypeAndMainPoint(CGeneral.TypeSelect Type, DropDownList obj, string PartType, string MainPoint)
    {
        DataTable dTable = new DataTable();
        StringBuilder sbd = new StringBuilder();
        sbd.AppendLine("SELECT DISTINCT SubPoint");
        sbd.AppendLine("FROM QC_StandardMaster");
        sbd.AppendLine("WHERE PartType = '" + PartType + "' and MainPoint = '"+ MainPoint +"'");
        dTable = oConn.Query(sbd.ToString());

        obj.Items.Clear();
        if (Type == CGeneral.TypeSelect.All)
        {
            obj.Items.Add(new ListItem("-ALL-", ""));
        }
        else if (Type == CGeneral.TypeSelect.Please)
        {
            obj.Items.Add(new ListItem("-Please Select-", "0"));
        }

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                obj.Items.Add(new ListItem(row["SubPoint"].ToString().Replace('_', ' '), row["SubPoint"].ToString()));
            }
        }
    }


}