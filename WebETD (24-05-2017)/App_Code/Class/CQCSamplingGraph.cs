using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for CQCSamplingGraph
/// </summary>
public class CQCSamplingGraph
{
    ConnectDBFac3ETD oConnETD = new ConnectDBFac3ETD();

    #region Front Head
    public MDQCFHID GetFHIDID(string DateStart, string DateEnd, string RowsQty)
    {
        if (RowsQty != "" && RowsQty != "0")
        {
            RowsQty = "top " + RowsQty;
        }
        else
        {
            RowsQty = "";
        }

        MDQCFHID oMDFH = new MDQCFHID();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "select " + RowsQty + " fhd.fh_id,m_id,fhd.fh_id1,fhd.fh_id3,fh_rank ";
        sql.CommandText += ",fh_roundness1,fh_ronudness3,fh_judge_roundness,fh_cylindricity,fh_perpendicularity,fh_concentricity ";
        sql.CommandText += ",fh.first_stamptime ";
        sql.CommandText += ",qc.PartType,qc.Model,qc.MainPoint,qc.SubPoint,qc.MQMin,qc.MQMax,qc.UCL,qc.CL,qc.LCL ";
        sql.CommandText += "from etd_fh_detail fhd ";
        sql.CommandText += "left join etd_front_head fh on fhd.fh_id = fh.fh_id ";
        sql.CommandText += "inner join [192.168.226.145].dbIoT.dbo.QC_StandardMaster qc on fh.m_id = qc.Model and qc.PartType = 'Front_Head' ";
        sql.CommandText += "where fh.first_stamptime between @DateStart and @DateEnd ";
        sql.CommandText += "and PartType = 'Front_Head' and qc.MainPoint = 'ID'  "; //and qc.SubPoint = 'ID'
        sql.CommandText += "order by fh.first_stamptime desc";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oConnETD.Query(sql);

        dTable.DefaultView.Sort = "first_stamptime asc";
        dTable = dTable.DefaultView.ToTable();

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDQCFHID.CMDFHID oMD = new MDQCFHID.CMDFHID();
                oMD.fh_id = row["fh_id"].ToString();
                oMD.Model = row["Model"].ToString();
                oMD.fh_id1 = row["fh_id1"] != DBNull.Value ? Convert.ToDecimal(row["fh_id1"]) : 0;
                oMD.fh_id3 = row["fh_id3"] != DBNull.Value ? Convert.ToDecimal(row["fh_id3"]) : 0;
                oMD.fh_rank = row["fh_rank"] != DBNull.Value ? Convert.ToDecimal(row["fh_rank"]) : 0;
                oMD.fh_roundness1 = row["fh_roundness1"] != DBNull.Value ? Convert.ToDecimal(row["fh_roundness1"]) : 0;
                oMD.fh_roundness3 = row["fh_ronudness3"] != DBNull.Value ? Convert.ToDecimal(row["fh_ronudness3"]) : 0;
                oMD.fh_judge_roundness = row["fh_judge_roundness"] != DBNull.Value ? Convert.ToDecimal(row["fh_judge_roundness"]) : 0;
                oMD.fh_cylindricity = row["fh_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["fh_cylindricity"]) : 0;
                oMD.fh_perpendicularity = row["fh_perpendicularity"] != DBNull.Value ? Convert.ToDecimal(row["fh_perpendicularity"]) : 0;
                oMD.fh_concentricity = row["fh_concentricity"] != DBNull.Value ? Convert.ToDecimal(row["fh_concentricity"]) : 0;
                oMD.first_stamptime = Convert.ToDateTime(row["first_stamptime"]).ToString("HH:mm:ss");
                oMD.PartType = row["PartType"].ToString();
                oMD.MainPoint = row["MainPoint"].ToString();
                oMD.SubPoint = row["SubPoint"].ToString();
                oMD.MQMin = row["MQMin"] != DBNull.Value ? Convert.ToDecimal(row["MQMin"]) : 0;
                oMD.MQMax = row["MQMax"] != DBNull.Value ? Convert.ToDecimal(row["MQMax"]) : 0;
                oMD.UCL = row["UCL"] != DBNull.Value ? Convert.ToDecimal(row["UCL"]) : 0;
                oMD.CL = row["CL"] != DBNull.Value ? Convert.ToDecimal(row["CL"]) : 0;
                oMD.LCL = row["LCL"] != DBNull.Value ? Convert.ToDecimal(row["LCL"]) : 0;

                oMDFH.ListOfID.Add(oMD);
            }

        }


        return oMDFH;
    }


    public MDQCRHID GetRHID(string DateStart, string DateEnd, string RowsQty)
    {
        if (RowsQty != "" && RowsQty != "0")
        {
            RowsQty = "top " + RowsQty;
        }
        else
        {
            RowsQty = "";
        }
        MDQCRHID oMDRH = new MDQCRHID();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "select " + RowsQty + " rhd.rh_id,m_id,rhd.rh_id1,rhd.rh_id3,rh_rank  ";
        sql.CommandText += ",rh_roundness1,rh_roundness3,rh_judge_roundness,rh_cylindricity,rh_perpendicularity ";
        sql.CommandText += ",rh.first_stamptime ";
        sql.CommandText += ",qc.PartType,qc.Model,qc.MainPoint,qc.SubPoint,qc.MQMin,qc.MQMax,qc.UCL,qc.CL,qc.LCL  ";
        sql.CommandText += "from etd_rh_detail rhd ";
        sql.CommandText += "left join etd_rear_head rh on rhd.rh_id = rh.rh_id ";
        sql.CommandText += "inner join [192.168.226.145].dbIoT.dbo.QC_StandardMaster qc on rh.m_id = qc.Model ";
        sql.CommandText += "where rh.first_stamptime between @DateStart and @DateEnd ";
        sql.CommandText += "and PartType = 'Rear_Head' and qc.MainPoint = 'ID' ";
        sql.CommandText += "order by rh.first_stamptime desc";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oConnETD.Query(sql);

        dTable.DefaultView.Sort = "first_stamptime asc";
        dTable = dTable.DefaultView.ToTable();

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDQCRHID.CMDQCRHID oMD = new MDQCRHID.CMDQCRHID();
                oMD.rh_id = row["rh_id"].ToString();
                oMD.Model = row["Model"].ToString();
                oMD.rh_id1 = row["rh_id1"] != DBNull.Value ? Convert.ToDecimal(row["rh_id1"]) : 0;
                oMD.rh_id3 = row["rh_id3"] != DBNull.Value ? Convert.ToDecimal(row["rh_id3"]) : 0;
                oMD.rh_rank = row["rh_rank"] != DBNull.Value ? Convert.ToDecimal(row["rh_rank"]) : 0;
                oMD.rh_roundness1 = row["rh_roundness1"] != DBNull.Value ? Convert.ToDecimal(row["rh_roundness1"]) : 0;
                oMD.rh_roundness3 = row["rh_roundness3"] != DBNull.Value ? Convert.ToDecimal(row["rh_roundness3"]) : 0;
                oMD.rh_judge_roundness = row["rh_judge_roundness"] != DBNull.Value ? Convert.ToDecimal(row["rh_judge_roundness"]) : 0;
                oMD.rh_cylindricity = row["rh_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["rh_cylindricity"]) : 0;
                oMD.rh_perpendicularity = row["rh_perpendicularity"] != DBNull.Value ? Convert.ToDecimal(row["rh_perpendicularity"]) : 0;
                oMD.first_stamptime = row["first_stamptime"].ToString() != "" ? Convert.ToDateTime(row["first_stamptime"]).ToString("HH:mm:ss") : "";
                oMD.PartType = row["PartType"].ToString();
                oMD.MainPoint = row["MainPoint"].ToString();
                oMD.SubPoint = row["SubPoint"].ToString();
                oMD.MQMin = row["MQMin"] != DBNull.Value ? Convert.ToDecimal(row["MQMin"]) : 0;
                oMD.MQMax = row["MQMax"] != DBNull.Value ? Convert.ToDecimal(row["MQMax"]) : 0;
                oMD.UCL = row["UCL"] != DBNull.Value ? Convert.ToDecimal(row["UCL"]) : 0;
                oMD.CL = row["CL"] != DBNull.Value ? Convert.ToDecimal(row["CL"]) : 0;
                oMD.LCL = row["LCL"] != DBNull.Value ? Convert.ToDecimal(row["LCL"]) : 0;

                oMDRH.ListOfRH.Add(oMD);
            }

        }


        return oMDRH;
    }

    public MDQCCS GetCS(string DateStart, string DateEnd, string RowsQty)
    {
        if (RowsQty != "" && RowsQty != "0")
        {
            RowsQty = "top " + RowsQty;
        }
        else
        {
            RowsQty = "";
        }
        MDQCCS oMDCS = new MDQCCS();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "select " + RowsQty + " fr.cs_id,cs_fr_f_rank,cs_fr_r_rank,cs_fr_f_judge_roundness,cs_fr_r_judge_roundness ";
        sql.CommandText += ",cs_fr_f_cylindricity,cs_fr_r_cylindricity,cs_pin_rank,cs_pin_judge_roundness,cs_pin_cylindricity,cs.first_stamptime ";
        sql.CommandText += ",qc.PartType,qc.Model,qc.MainPoint,qc.SubPoint,qc.MQMin,qc.MQMax,qc.UCL,qc.CL,qc.LCL ";
        sql.CommandText += "from etd_cs_od_fr fr ";
        sql.CommandText += "left join etd_cs_od_pin pin on fr.cs_id = pin.cs_id ";
        sql.CommandText += "left join etd_crank_shaft cs on fr.cs_id = cs.cs_id ";
        sql.CommandText += "inner join[192.168.226.145].dbIoT.dbo.QC_StandardMaster qc on cs.m_id = qc.Model ";
        sql.CommandText += "where cs.first_stamptime between @DateStart and @DateEnd ";
        sql.CommandText += "and PartType = 'Crank_Shaft' and qc.SubPoint = 'Roundness' ";
        sql.CommandText += "order by cs.first_stamptime desc";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oConnETD.Query(sql);

        dTable.DefaultView.Sort = "first_stamptime asc";
        dTable = dTable.DefaultView.ToTable();

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDQCCS.CMDQCCS oMD = new MDQCCS.CMDQCCS();
                oMD.cs_id = row["cs_id"].ToString();
                oMD.Model = row["Model"].ToString();
                oMD.cs_fr_f_rank = row["cs_fr_f_rank"] != DBNull.Value ? Convert.ToDecimal(row["cs_fr_f_rank"]) : 0;
                oMD.cs_fr_r_rank = row["cs_fr_r_rank"] != DBNull.Value ? Convert.ToDecimal(row["cs_fr_r_rank"]) : 0;
                oMD.cs_fr_f_judge_roundness = row["cs_fr_f_judge_roundness"] != DBNull.Value ? Convert.ToDecimal(row["cs_fr_f_judge_roundness"]) : 0;
                oMD.cs_fr_r_judge_roundness = row["cs_fr_r_judge_roundness"] != DBNull.Value ? Convert.ToDecimal(row["cs_fr_r_judge_roundness"]) : 0;
                oMD.cs_fr_f_cylindricity = row["cs_fr_f_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["cs_fr_f_cylindricity"]) : 0;
                oMD.cs_fr_r_cylindricity = row["cs_fr_r_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["cs_fr_r_cylindricity"]) : 0;
                oMD.cs_pin_rank = row["cs_pin_rank"] != DBNull.Value ? Convert.ToDecimal(row["cs_pin_rank"]) : 0;
                oMD.cs_pin_judge_roundness = row["cs_pin_judge_roundness"] != DBNull.Value ? Convert.ToDecimal(row["cs_pin_judge_roundness"]) : 0;
                oMD.cs_pin_cylindricity = row["cs_pin_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["cs_pin_cylindricity"]) : 0;
                oMD.first_stamptime = row["first_stamptime"].ToString() != "" ? Convert.ToDateTime(row["first_stamptime"]).ToString("HH:mm:ss") : "";
                oMD.PartType = row["PartType"].ToString();
                oMD.MainPoint = row["MainPoint"].ToString();
                oMD.SubPoint = row["SubPoint"].ToString();
                oMD.MQMin = row["MQMin"] != DBNull.Value ? Convert.ToDecimal(row["MQMin"]) : 0;
                oMD.MQMax = row["MQMax"] != DBNull.Value ? Convert.ToDecimal(row["MQMax"]) : 0;
                oMD.UCL = row["UCL"] != DBNull.Value ? Convert.ToDecimal(row["UCL"]) : 0;
                oMD.CL = row["CL"] != DBNull.Value ? Convert.ToDecimal(row["CL"]) : 0;
                oMD.LCL = row["LCL"] != DBNull.Value ? Convert.ToDecimal(row["LCL"]) : 0;

                oMDCS.ListOfCS.Add(oMD);
            }

        }


        return oMDCS;
    }


    public MDQCPT GetPT(string DateStart, string DateEnd, string RowsQty)
    {
        if (RowsQty != "" && RowsQty != "0")
        {
            RowsQty = "top " + RowsQty;
        }
        else
        {
            RowsQty = "";
        }
        MDQCPT oMDPT = new MDQCPT();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "select " + RowsQty + " pt.pt_id,pt_id_rank,pt_id_roundness,pt_id_cylindricity,pt_id_perpendicularity,pt_id_concentricity  ";
        sql.CommandText += ",pt_od_rank,pt_od_judge_roundness,pt_od_cylindricity,pt_od_perpendicularity  ";
        sql.CommandText += ",pt_bl_rank,pt_bl_parallism,pt_bl_perpendicularity  ";
        sql.CommandText += ",pt_he_rank,pt_he_parallism,pt.first_stamptime  ";
        sql.CommandText += ",qc.PartType,qc.Model,qc.MainPoint,qc.SubPoint,qc.MQMin,qc.MQMax,qc.UCL,qc.CL,qc.LCL  ";
        sql.CommandText += "from etd_pt_id ptid  ";
        sql.CommandText += "left join etd_pt_od ptod on ptid.pt_id = ptod.pt_id  ";
        sql.CommandText += "left join etd_pt_blade ptb on ptid.pt_id = ptb.pt_id  ";
        sql.CommandText += "left join etd_pt_height pth on ptid.pt_id = pth.pt_id  ";
        sql.CommandText += "left join etd_piston pt on ptid.pt_id = pt.pt_id  ";
        sql.CommandText += "inner join[192.168.226.145].dbIoT.dbo.QC_StandardMaster qc on pt.m_id = qc.Model  ";
        sql.CommandText += "where pt.first_stamptime between @DateStart and @DateEnd  ";
        sql.CommandText += "and PartType = 'Piston' ";
        sql.CommandText += "order by first_stamptime desc";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oConnETD.Query(sql);

        dTable.DefaultView.Sort = "first_stamptime asc";
        dTable = dTable.DefaultView.ToTable();

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDQCPT.CMDQCPT oMD = new MDQCPT.CMDQCPT();
                oMD.pt_id = row["pt_id"].ToString();
                oMD.Model = row["Model"].ToString();
                oMD.pt_id_rank = row["pt_id_rank"] != DBNull.Value ? Convert.ToDecimal(row["pt_id_rank"]) : 0;
                oMD.pt_id_roundness = row["pt_id_roundness"] != DBNull.Value ? Convert.ToDecimal(row["pt_id_roundness"]) : 0;
                oMD.pt_id_cylindricity = row["pt_id_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["pt_id_cylindricity"]) : 0;
                oMD.pt_id_perpendicularity = row["pt_id_perpendicularity"] != DBNull.Value ? Convert.ToDecimal(row["pt_id_perpendicularity"]) : 0;
                oMD.pt_id_concentricity = row["pt_id_concentricity"] != DBNull.Value ? Convert.ToDecimal(row["pt_id_concentricity"]) : 0;
                oMD.pt_od_rank = row["pt_od_rank"] != DBNull.Value ? Convert.ToDecimal(row["pt_od_rank"]) : 0;
                oMD.pt_od_judge_roundness = row["pt_od_judge_roundness"] != DBNull.Value ? Convert.ToDecimal(row["pt_od_judge_roundness"]) : 0;
                oMD.pt_od_cylindricity = row["pt_od_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["pt_od_cylindricity"]) : 0;
                oMD.pt_od_perpendicularity = row["pt_od_perpendicularity"] != DBNull.Value ? Convert.ToDecimal(row["pt_od_perpendicularity"]) : 0;
                oMD.pt_bl_rank = row["pt_bl_rank"] != DBNull.Value ? Convert.ToDecimal(row["pt_bl_rank"]) : 0;
                oMD.pt_bl_parallism = row["pt_bl_parallism"] != DBNull.Value ? Convert.ToDecimal(row["pt_bl_parallism"]) : 0;
                oMD.pt_bl_perpendicularity = row["pt_bl_perpendicularity"] != DBNull.Value ? Convert.ToDecimal(row["pt_bl_perpendicularity"]) : 0;
                oMD.pt_he_rank = row["pt_he_rank"] != DBNull.Value ? Convert.ToDecimal(row["pt_he_rank"]) : 0;
                oMD.pt_he_parallism = row["pt_he_parallism"] != DBNull.Value ? Convert.ToDecimal(row["pt_he_parallism"]) : 0;
                oMD.first_stamptime = row["first_stamptime"].ToString() != "" ? Convert.ToDateTime(row["first_stamptime"]).ToString("HH:mm:ss") : "";
                oMD.PartType = row["PartType"].ToString();
                oMD.MainPoint = row["MainPoint"].ToString();
                oMD.SubPoint = row["SubPoint"].ToString();
                oMD.MQMin = row["MQMin"] != DBNull.Value ? Convert.ToDecimal(row["MQMin"]) : 0;
                oMD.MQMax = row["MQMax"] != DBNull.Value ? Convert.ToDecimal(row["MQMax"]) : 0;
                oMD.UCL = row["UCL"] != DBNull.Value ? Convert.ToDecimal(row["UCL"]) : 0;
                oMD.CL = row["CL"] != DBNull.Value ? Convert.ToDecimal(row["CL"]) : 0;
                oMD.LCL = row["LCL"] != DBNull.Value ? Convert.ToDecimal(row["LCL"]) : 0;

                oMDPT.ListOfPT.Add(oMD);
            }

        }


        return oMDPT;
    }


    public MDQCCY GetCY(string DateStart, string DateEnd, string RowsQty)
    {
        if (RowsQty != "" && RowsQty != "0")
        {
            RowsQty = "top " + RowsQty;
        }
        else
        {
            RowsQty = "";
        }
        MDQCCY oMDCY = new MDQCCY();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandText = "select " + RowsQty + " cy.cy_id,cyb.cy_bo_rank,cy_bo_judge_roundness,cy_bo_cylindricity,cy_bo_perpendicularity,cy_bo_concentricity  ";
        sql.CommandText += ",cy_he_rank,cy_he_parallism,first_stamptime  ";
        sql.CommandText += ",qc.PartType,qc.Model,qc.MainPoint,qc.SubPoint,qc.MQMin,qc.MQMax,qc.UCL,qc.CL,qc.LCL   ";
        sql.CommandText += "from etd_cy_id_bore cyb  ";
        sql.CommandText += "inner join etd_cy_height cyh on cyb.cy_id=cyh.cy_id  ";
        sql.CommandText += "inner join etd_cylinder cy on cyb.cy_id=cy.cy_id  ";
        sql.CommandText += "inner join [192.168.226.145].dbIoT.dbo.QC_StandardMaster qc on cy.m_id = qc.Model  ";
        sql.CommandText += "where cy.first_stamptime between @DateStart and @DateEnd   ";
        sql.CommandText += "and PartType = 'Cylinder' ";
        sql.CommandText += "order by first_stamptime desc";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oConnETD.Query(sql);

        dTable.DefaultView.Sort = "first_stamptime asc";
        dTable = dTable.DefaultView.ToTable();

        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDQCCY.CMDQCCY oMD = new MDQCCY.CMDQCCY();
                oMD.cy_id = row["cy_id"].ToString();
                oMD.Model = row["Model"].ToString();
                oMD.cy_bo_rank = row["cy_bo_rank"] != DBNull.Value ? Convert.ToDecimal(row["cy_bo_rank"]) : 0;
                oMD.cy_bo_judge_roundness = row["cy_bo_judge_roundness"] != DBNull.Value ? Convert.ToDecimal(row["cy_bo_judge_roundness"]) : 0;
                oMD.cy_bo_cylindricity = row["cy_bo_cylindricity"] != DBNull.Value ? Convert.ToDecimal(row["cy_bo_cylindricity"]) : 0;
                oMD.cy_bo_perpendicularity = row["cy_bo_perpendicularity"] != DBNull.Value ? Convert.ToDecimal(row["cy_bo_perpendicularity"]) : 0;
                oMD.cy_bo_concentricity = row["cy_bo_concentricity"] != DBNull.Value ? Convert.ToDecimal(row["cy_bo_concentricity"]) : 0;
                oMD.cy_he_rank = row["cy_he_rank"] != DBNull.Value ? Convert.ToDecimal(row["cy_he_rank"]) : 0;
                oMD.cy_he_parallism = row["cy_he_parallism"] != DBNull.Value ? Convert.ToDecimal(row["cy_he_parallism"]) : 0;
                oMD.first_stamptime = row["first_stamptime"].ToString() != "" ? Convert.ToDateTime(row["first_stamptime"]).ToString("HH:mm:ss") : "";
                oMD.PartType = row["PartType"].ToString();
                oMD.MainPoint = row["MainPoint"].ToString();
                oMD.SubPoint = row["SubPoint"].ToString();
                oMD.MQMin = row["MQMin"] != DBNull.Value ? Convert.ToDecimal(row["MQMin"]) : 0;
                oMD.MQMax = row["MQMax"] != DBNull.Value ? Convert.ToDecimal(row["MQMax"]) : 0;
                oMD.UCL = row["UCL"] != DBNull.Value ? Convert.ToDecimal(row["UCL"]) : 0;
                oMD.CL = row["CL"] != DBNull.Value ? Convert.ToDecimal(row["CL"]) : 0;
                oMD.LCL = row["LCL"] != DBNull.Value ? Convert.ToDecimal(row["LCL"]) : 0;

                oMDCY.ListOfCY.Add(oMD);
            }

        }


        return oMDCY;
    }



    #endregion
}