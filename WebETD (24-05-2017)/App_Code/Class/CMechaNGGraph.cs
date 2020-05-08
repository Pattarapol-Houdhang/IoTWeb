using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CMechaNGGraph
/// </summary>
public class CMechaNGGraph
{
    ConnectDBIoTServerTonMecha oCon = new ConnectDBIoTServerTonMecha();
    
    public MDMechaNG GetMechaNGGraph(string DateStart, string DateEnd, string Part_Name)
    {
        MDMechaNG oMDMechaNG = new MDMechaNG();
        DataTable dTable = new DataTable();
        SqlCommand sql = new SqlCommand();
        sql.CommandTimeout = 180;
        try
        {

            if (Part_Name == "ALL")
            {
                sql.CommandText = @"select part_name,part_type,detail,COUNT(distinct serial_no) as Qty,case when model_name='' or model_name is null then 'Other' else model_name end as model_name,CAST(AVG([value]) AS DECIMAL(10,4)) as AVG  from [vi_ng_detail] 
                            where insert_datetime between @DateStart and @DateEnd 
                            group by part_name,part_type,detail,model_name";

            }
            else
            {
                sql.CommandText = @"select part_name,part_type,detail,COUNT(distinct serial_no) as Qty,case when model_name='' or model_name is null then 'Other' else model_name end as model_name,CAST(AVG([value]) AS DECIMAL(10,4)) as AVG  from [vi_ng_detail] 
                            where insert_datetime between @DateStart and @DateEnd and part_name = @Part_name
                            group by part_name,part_type,detail,model_name";

                sql.Parameters.Add(new SqlParameter("@Part_name", Part_Name));
            }

            sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
            sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
            dTable = oCon.Query(sql);

        }
        catch (Exception)
        {
            
        }
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMechaNG.CMDMechaNG oCMD = new MDMechaNG.CMDMechaNG();
                oCMD.part_name = row["part_name"].ToString();
                oCMD.part_type = row["part_type"].ToString();
                oCMD.detail = row["detail"].ToString();
                oCMD.Qty = int.Parse(row["Qty"].ToString());
                oCMD.AVG = row["AVG"].ToString();
                oCMD.Model = row["model_name"].ToString().Trim();
                
                oMDMechaNG.ListOfMechaNG.Add(oCMD);
                
            }

        }
        dTable.Clear();
        sql.Parameters.Clear();
        sql = new SqlCommand();
        sql.CommandText = @"select part_name,part_type,COUNT(distinct serial_no) as Total  from [vi_ng_detail] 
                            where insert_datetime between @DateStart and @DateEnd
                            group by part_name,part_type";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oCon.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMechaNG.CMDMechaNG_partType_Total oCMDT = new MDMechaNG.CMDMechaNG_partType_Total();
                oCMDT.part_name = row["part_name"].ToString();
                oCMDT.part_type = row["part_type"].ToString();
                oCMDT.Total = int.Parse(row["Total"].ToString());
                oMDMechaNG.ListOfMechaNG_partType_Total.Add(oCMDT);
            }
        }

        dTable.Clear();
        sql.Parameters.Clear();
        sql = new SqlCommand();
        sql.CommandText = @"select part_name,COUNT(distinct serial_no) as Total  from [vi_ng_detail] 
                            where insert_datetime between @DateStart and @DateEnd
                            group by part_name order by part_name";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oCon.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMechaNG.CMDMechaNGTotal oCMDT = new MDMechaNG.CMDMechaNGTotal();
                oCMDT.part_name = row["part_name"].ToString();
                oCMDT.Total = int.Parse(row["Total"].ToString());
                oMDMechaNG.ListOfMechaNGTotal.Add(oCMDT);
            }
        }

        dTable.Clear();
        sql.Parameters.Clear();
        sql = new SqlCommand();
        sql.CommandText = @"select part_name,model_name as model,COUNT(distinct serial_no) as Total  from [vi_ng_detail] 
                            where insert_datetime between @DateStart and @DateEnd
                            group by part_name,model_name order by part_name";
        sql.Parameters.Add(new SqlParameter("@DateStart", DateStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", DateEnd));
        dTable = oCon.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMechaNG.CMDMechaNGTotalM oCMDT = new MDMechaNG.CMDMechaNGTotalM();
                oCMDT.part_name = row["part_name"].ToString();
                oCMDT.model = row["model"].ToString().Trim();
                oCMDT.Total = int.Parse(row["Total"].ToString());
                oMDMechaNG.ListOfMechaNGTotalM.Add(oCMDT);
            }
        }

        dTable.Clear();
        sql.Parameters.Clear();
        sql = new SqlCommand();
        sql.CommandText = @"select distinct case when model_name='' or model_name is null then 'Other' else model_name end as model_name from vi_ng_detail order by model_name";
        dTable = oCon.Query(sql);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow row in dTable.Rows)
            {
                MDMechaNG.CMDModel oCMDModel = new MDMechaNG.CMDModel();
                oCMDModel.model_name = row["model_name"].ToString().Trim();
                oMDMechaNG.ListOfModel.Add(oCMDModel);
                
            }
        }

        return oMDMechaNG;
    }

}