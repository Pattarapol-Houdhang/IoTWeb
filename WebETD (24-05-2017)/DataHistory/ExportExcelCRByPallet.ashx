<%@ WebHandler Language="C#" Class="ExportExcelCRByPallet" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;



public class ExportExcelCRByPallet : IHttpHandler
{
    //CHistoryData oHis = new CHistoryData();
    ConnectDBDCI oConnDCI = new ConnectDBDCI();
    ConnectDBFac3 oConnFac3 = new ConnectDBFac3();
    string TableName = "";
    string dtStart = "";
    string dtEnd = "";
    string Model = "";
    string Name = "";
    string PalletNo = "";

    public void ProcessRequest(HttpContext context)
    {
        //TableName = context.Request.QueryString["TableName"].ToString();
        //dtStart = context.Request.QueryString["DateStart"].ToString();
        //dtEnd = context.Request.QueryString["DateEnd"].ToString();
        PalletNo = context.Request.QueryString["Pallet"].ToString();

        //DataTable dTable = new DataTable();

        //dTable = oHis.GetDataMESIoTServer(TableName, dtStart, dtEnd, Model);
        if (PalletNo != "")
        {
            SqlCommand sql = new SqlCommand();
            DataTable dTablePallet = new DataTable();
            dTablePallet.TableName = "Pallet";
            sql.CommandText = "SELECT pl_no,pl_date,pck_no,prd_serial,prd_cd,prd_date,wh_recieve FROM vi_Pack_Pallet";
            sql.CommandText += " WHERE pl_no = @Pallet AND line_cd=6";
            sql.Parameters.Add(new SqlParameter("@Pallet", PalletNo));
            dTablePallet = oConnDCI.Query(sql);

            DataTable dTable = new DataTable();
            dTable.TableName = "CR";
            if (dTablePallet.Rows.Count > 0)
            {
                foreach (DataRow _row in dTablePallet.Rows)
                {
                    DataTable _dTable = new DataTable();
                    sql = new SqlCommand();
                    sql.CommandText = "exec GetDataCRByLabelNo @LabelNo,@Model";
                    sql.Parameters.Add(new SqlParameter("@LabelNo", _row["prd_serial"].ToString().Substring(7, 8)));
                    sql.Parameters.Add(new SqlParameter("@Model", _row["prd_serial"].ToString().Substring(3, 4)));
                    _dTable = oConnFac3.Query(sql);

                    if (dTable.Columns.Count != _dTable.Columns.Count)
                    {
                        dTable = _dTable.Clone();
                    }

                    if (_dTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in _dTable.Rows)
                        {

                            dTable.Rows.Add(row.ItemArray);
                        }
                    }
                }
            }


            Name = "DataCR_" + DateTime.Now.Year.ToString()
                + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;

            context.Response.ContentType = "text/plain";
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");

            StringBuilder sb = new StringBuilder();
            // Set Header
            string Header = "";
            if (dTable.Rows.Count > 0)
            {
                foreach (DataColumn column in dTable.Columns)
                {
                    Header += column.ColumnName + ",";
                }
            }
            sb.AppendLine(Header);


            if (dTable.Rows.Count > 0)
            {
                for (int i = 0; i < dTable.Rows.Count - 1; i++)
                {
                    string Detail = "";

                    foreach (object data in dTable.Rows[i].ItemArray)
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
        
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    


}