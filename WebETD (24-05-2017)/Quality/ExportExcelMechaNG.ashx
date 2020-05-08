<%@ WebHandler Language="C#" Class="ExportExcelMechaNG" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelMechaNG : IHttpHandler
{
    //CHistoryData oHis = new CHistoryData();
    ConnectDBIoTServerTonMecha oCon = new ConnectDBIoTServerTonMecha();
    string dtStart = "";
    string dtEnd = "";
    string Name = "";
    string Part_Name = "";
    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        dtStart = context.Request.QueryString["DateStart"].ToString();
        dtEnd = context.Request.QueryString["DateEnd"].ToString();
        Part_Name = context.Request.QueryString["Part_Name"].ToString();
        //DataTable dTable = new DataTable();




        DataTable dt = new DataTable();
        ////// Get Data
        SqlCommand sql = new SqlCommand();
        if (Part_Name == "ALL")
        {
            sql.CommandText = @"SELECT [serial_no]
                                              ,[part_name]
                                              ,[part_type]
                                              ,[detail]
                                              ,convert(varchar, [insert_datetime] , 20) as insert_date
                                              ,[model_name]
                                              ,[value]
                                          FROM [MECHA_FAC3].[dbo].[vi_ng_detail]
                                          where insert_datetime between @DateStart and @DateEnd 
                                          group by [part_name],[part_type],[detail],[insert_datetime],[serial_no],[model_name],[value]";

        }
        else
        {
            sql.CommandText = @"SELECT [serial_no]
                                              ,[part_name]
                                              ,[part_type]
                                              ,[detail]
                                              ,convert(varchar, [insert_datetime] , 20) as insert_date
                                              ,[model_name]
                                              ,[value]
                                          FROM [MECHA_FAC3].[dbo].[vi_ng_detail]
                                          where insert_datetime between @DateStart and @DateEnd and part_name = @Part_Name
                                          group by [part_name],[part_type],[detail],[insert_datetime],[serial_no],[model_name],[value]";
            sql.Parameters.Add(new SqlParameter("@Part_Name", Part_Name));
        }


        sql.Parameters.Add(new SqlParameter("@DateStart", dtStart));
        sql.Parameters.Add(new SqlParameter("@DateEnd", dtEnd));
        dt = oCon.Query(sql);
        if (dt.Rows.Count <= 0)
        {
            return;
        }


        /////

        Name = "IoTData_" + "Mecha_Fac3_" + DateTime.Now.Year.ToString()
                + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00")
                + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00")
                ;


        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");

        StringBuilder sb = new StringBuilder();
        // Set Header
        string Header = "";
        if (dt.Rows.Count > 0)
        {
            foreach (DataColumn column in dt.Columns)
            {
                Header += column.ColumnName + ",";
            }
        }
        sb.AppendLine(Header);


        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Detail = "";

                foreach (object data in dt.Rows[i].ItemArray)
                {

                    Detail += data + ",";

                }
                sb.AppendLine(Detail);
            }
        }

        //context.Response.Write(sb.ToString());

        //the most easy way as you have type it
        context.Response.Write(sb.ToString());
        context.Response.Flush();
        context.Response.End();


    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }




}