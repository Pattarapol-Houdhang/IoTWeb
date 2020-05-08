<%@ WebHandler Language="C#" Class="ExportExcel2" %>

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;
using OfficeExcel = Microsoft.Office.Interop.Excel;


public class ExportExcel2 : IHttpHandler {

    F3MechaService meTba = new F3MechaService();
    ConnectDBETD con = new ConnectDBETD();
	
    string Part;
    string Start;
    string End;
    string Con;
    string Name;
    string Base;

    public void ProcessRequest(HttpContext context)
    {

        Part = context.Request.QueryString["Part"].ToString();
        Start = context.Request.QueryString["Start"].ToString();
        End = context.Request.QueryString["End"].ToString();
        Con = context.Request.QueryString["Con"].ToString();
        Base = context.Request.QueryString["Base"].ToString();

        DataTable dTable = new DataTable();
        dTable = GetData();

        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");

        //string Part = context.Request.QueryString["Part"].ToString();
        //string ListType = context.Request.QueryString["ListType"].ToString();
        //string StartDate = context.Request.QueryString["StartDate"].ToString();
        //string EndDate = context.Request.QueryString["EndDate"].ToString();


        //String FilePath = @"C:\testfile.txt";
        //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        //response.ClearContent();
        //response.Clear();


        StringBuilder sb = new StringBuilder();

        string[] columnNames = dTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
        sb.AppendLine(string.Join(",", columnNames));

        foreach (DataRow row in dTable.Rows)
        {
            string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
            sb.AppendLine(string.Join(",", fields));
        }

        //context.Response.Write(sb.ToString());

        //the most easy way as you have type it
        context.Response.Write(sb.ToString());
        context.Response.Flush();
        context.Response.End();
        
    }

    private DataTable GetData()
    {
        DataTable getdt = new DataTable();
        if (Part == "1") //CS
        {
            Name = "MECHA-CS-FAC3 (" + Start + ") to (" + End + ")";
            //getdt = meTba.getCSResultF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));
            
            DataTable dtCS = new DataTable();
            string StrCS = "SELECT [part_serial_no], [date_shift], [model_no], [model_name], [fs_od_rank_val], [fs_od_rank_char], "
                + " [fs_roundness], [fs_cylindric], [fs_od1], [fs_od2], [fs_od3], [fs_od1_remain], [fs_od2_remain], [fs_od3_remain], "
                + " [rs_od_rank_val], [rs_od_rank_char], [rs_roundness], [rs_cylindric], [rs_od1], [rs_od2], [rs_od1_remain], [rs_od2_remain], "
                + " [pin_od_rank_val], [pin_od_rank_char], [pin_roundness], [pin_cylindric], [pin_od1], [pin_od2], [pin_od3], [pin_od1_remain], "
                + " [pin_od2_remain], [pin_od3_remain], [a_max], [eccentric], [total_judgement], [stamp_time], [cycle_start_time], [cycle_end_time], "
                + " [production_count], [daily_counter] "
                + " FROM [" + Base + "].[dbo].[vi_crank_shaft_result] "
                + " WHERE stamp_time between '" + Start + "' and '" + End + " '"
                + " ORDER BY  stamp_time asc ";

            SqlCommand qrCS = new SqlCommand();
            qrCS.CommandText = StrCS;
            dtCS = con.Query(qrCS, Con);

            getdt = dtCS;
        }


        else if (Part == "2")//PT
        {
            Name = "MECHA-PT-FAC3 (" + Start + ") to (" + End + ")";
            //getdt = meTba.getPTResultF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));

            DataTable dtPT = new DataTable();
            string StrPT = "SELECT part_serial_no, date_shift, model_no, model_name, id_rank_val, id_rank_char, id_roundness, id_cylindric, id_perpen, id_rank1, id_rank2, od_rank_val, "
                + " od_rank_char, od_roundness, od_cylindric, od_perpen, od_rank1, od_rank2, bt_rank_val, bt_rank_char, bt_parallism, bs_perpen, bd_perpen, bt_rank1, bt_rank2, "
                + " bt_rank3, bt_rank4, hi_rank_val, hi_rank_char, parallism_sur, hi_rank1, hi_rank2, hi_rank3, hi_rank4, hi_rank5, b1, b2, b3, b4, b_max_min, total_judgement, "
                + " stamp_time, cycle_start_time, cycle_end_time, production_count, daily_counter "
                + " FROM [" + Base + "].[dbo].[vi_piston_result] "
                + " WHERE stamp_time between '" + Start + "' and '" + End + " '"
                + " ORDER BY  stamp_time asc ";

            SqlCommand qrPT = new SqlCommand();
            qrPT.CommandText = StrPT;
            dtPT = con.Query(qrPT, Con);

            getdt = dtPT;
        }

        else if (Part == "3")//CY
        {
            Name = "MECHA-CY-FAC3 (" + Start + ") to (" + End + ")";
            //getdt = meTba.getCYResultF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));

            DataTable dtCY = new DataTable();
            string StrCY = "SELECT part_serial_no, date_shift, model_no, model_name, id_bo_rank_val, id_bo_rank_char, id_bo_roundness, id_bo_cylindric, id_bo_concen, id_bo_perpen, "
                + " id_bo_rank1, id_bo_rank2, id_bu_rank_val, id_bu_rank_char, id_bu_roundness, id_bu_cylindric, id_bu_perpen, id_bu_rank1, id_bu_rank2, hi_rank_val, "
                + " hi_rank_char, hi_parallism, hi_rank1, hi_rank2, hi_rank3, hi_rank4, hi_rank5, hi_rank6, total_judgement, stamp_time, cycle_start_time, cycle_end_time, "
                + " production_count, daily_counter "
                + " FROM [" + Base + "].[dbo].[vi_cylinder_result] "
                + " WHERE stamp_time between '" + Start + "' and '" + End + " '"
                + " ORDER BY  stamp_time asc ";

            SqlCommand qrCY = new SqlCommand();
            qrCY.CommandText = StrCY;
            dtCY = con.Query(qrCY, Con);

            getdt = dtCY;
        }

        else if (Part == "4")//FH
        {
             Name = "MECHA-FH-FAC3 (" + Start + ") to (" + End + ")";
            //getdt = meTba.getFHResultF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));

            DataTable dtFH = new DataTable();
            string StrFH = "SELECT [part_serial_no], [date_shift], [model_no], [model_name], [id_rank_val], [id_rank_char], "
                + " [id_roundness], [id_cylindric], [id_concentric], [id_perpen], [id_rank_val1], [id_rank_val2], [total_judgement], "
                + " [stamp_time], [cycle_start_time], [cycle_end_time], [production_count], [daily_counter] "
                + " FROM [" + Base + "].[dbo].[vi_front_head_result] "
                + " WHERE stamp_time between '" + Start + "' and '" + End + " '"
                + " ORDER BY  stamp_time asc ";

            SqlCommand qrFH = new SqlCommand();
            qrFH.CommandText = StrFH;
            dtFH = con.Query(qrFH, Con);

            getdt = dtFH;
        }

        else if (Part == "5")//RH
        {
            Name = "MECHA-RH-FAC3 (" + Start + ") to (" + End + ")";
            //getdt = meTba.getRHResultF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));

            DataTable dtRH = new DataTable();
            string StrRH = "SELECT part_serial_no, date_shift, model_no, model_name, id_rank_val, id_rank_char, id_roundness, id_cylindric, id_perpen, total_judgement, stamp_time, "
                + " cycle_start_time, cycle_end_time, production_count, daily_counter "
                + " FROM [" + Base + "].[dbo].[vi_rear_head_result] "
                + " WHERE stamp_time between '" + Start + "' and '" + End + " '"
                + " ORDER BY stamp_time asc ";

            SqlCommand qrRH = new SqlCommand();
            qrRH.CommandText = StrRH;
            dtRH = con.Query(qrRH, Con);

            getdt = dtRH;
        }

        else if (Part == "6")//MATCHING
        {
            Name = "MECHA-MATCHING-FAC3 (" + Start + ") to (" + End + ")";
            getdt = meTba.getMatchingData(Convert.ToDateTime(Start), Convert.ToDateTime(End));
        }

        else if (Part == "7")//Front Head Riveting
        {
            Name = "MECHA-FH-RIVET-FAC3 (" + Start + ") to (" + End + ")";
            getdt = meTba.getFHRivetingF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));
        }

        else if (Part == "8")//Rear Centering
        {
            Name = "MECHA-RCEN-FAC3 (" + Start + ") to (" + End + ")";
            getdt = meTba.getRCenteringF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));
        }

        else if (Part == "9")//Cylinder Centering
        {
            Name = "MECHA-CYCEN-FAC3 (" + Start + ") to (" + End + ")";
            getdt = meTba.getCYCenteringF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));
        }

        else if (Part == "10")//Torque Check
        {
            Name = "MECHA-Torque-FAC3 (" + Start + ") to (" + End + ")";
            getdt = meTba.getTorqueF3(Convert.ToDateTime(Start), Convert.ToDateTime(End));
        }

        return getdt;
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}