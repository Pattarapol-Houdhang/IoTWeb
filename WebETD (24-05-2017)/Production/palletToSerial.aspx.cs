using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_palletToSerial : System.Web.UI.Page
{

    CpalletToSerial Cpts = new CpalletToSerial();
    ConnectDB oCon = new ConnectDB();
    DataTable dTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnLoad_Click(object sender, EventArgs e)
    {
        DataTable dTablePLNO = new DataTable();
        string Model = "";
        string sqlPLNO = @"SELECT Serial,[Status],Model,[DataType] FROM [dbIoT].[dbo].[tmpCheckSerial] where Status is null";
        dTablePLNO = oCon.Query(sqlPLNO);
        if (dTablePLNO.Rows.Count > 0)
        {
            foreach (DataRow row in dTablePLNO.Rows)
            {
                Model = "";
                if (row["DataType"].ToString() == "PALLET")
                {
                    dTable = Cpts.LoadSerialFromAlphaByPLNO(row["Serial"].ToString());///Move serial from Alpha To IoT By Pallet No.
                    
                    string sql = "";
                    if (dTable.Rows.Count > 0)
                    {
                        foreach (DataRow rowin in dTable.Rows)
                        {

                            sql = @"INSERT INTO [dbIoT].[dbo].[tmpCheckSerial_PLNO]([PLNO]
                                                                      ,[SERIAL]
                                                                      ,[MODEL]
                                                                      ,[NWC]
                                                                      ,[NDATE]
                                                                      ,[CDATE]
                                                                      ,[CTIME])
                        VALUES('" + rowin["PLNO"].ToString() + "','" + rowin["SERIAL"].ToString() + "','" + rowin["MODEL"].ToString() + "','" + rowin["NWC"].ToString() + "','" + rowin["NDATE"].ToString() + "','" + rowin["CDATE"].ToString() + "','" + rowin["CTIME"].ToString() + "')";
                        var a = oCon.Query(sql);

                        Model = rowin["MODEL"].ToString();
                        }
                    }
                }
                else
                {
                    dTable = Cpts.LoadSerialFromAlpahBySerial(row["Serial"].ToString());///Move serial from Alpha To IoT By Serial.
                    string sql = "";
                    if (dTable.Rows.Count > 0)
                    {
                        foreach (DataRow rowin in dTable.Rows) { 
                            sql = @"INSERT INTO [dbIoT].[dbo].[tmpCheckSerial_PLNO]([PLNO]
                                                                      ,[SERIAL]
                                                                      ,[MODEL]
                                                                      ,[NWC]
                                                                      ,[NDATE]
                                                                      ,[CDATE]
                                                                      ,[CTIME])
                        VALUES('" + rowin["PLNO"].ToString() + "','" + rowin["SERIAL"].ToString() + "','" + rowin["MODEL"].ToString() + "','" + rowin["NWC"].ToString() + "','" + rowin["NDATE"].ToString() + "','" + rowin["CDATE"].ToString() + "','" + rowin["CTIME"].ToString() + "')";
                        oCon.Query(sql);

                        Model = rowin["MODEL"].ToString();
                        }
                    }
                }
                UpdateStatus(row["Serial"].ToString(), Model);
            }

        }
       
    }
    private void UpdateStatus(string Serial ,string Model)
    {
        string sql = "";
        sql = @"UPDATE tmpCheckSerial set [Status] = 'Checked',Model = '" + Model + "' where serial ='" + Serial + "'";
        oCon.Query(sql);
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        dTable = new DataTable();
        string sql = @"SELECT *
                        FROM [dbIoT].[dbo].[tmpCheckSerial_PLNO]";
        dTable = oCon.Query(sql);

        if (dTable.Rows.Count > 0)
        {
            rptData.DataSource = dTable;
            rptData.DataBind();
        }
        else
        {
            dTable = new DataTable();
            dTable.TableName = "null";
            dTable.Columns.Add(" ");
            dTable.Rows.Add("");

            rptData.DataSource = dTable;
            rptData.DataBind();
        }
    }
    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            Repeater headerRepeater = e.Item.FindControl("Header1") as Repeater;
            headerRepeater.DataSource = dTable.Columns;
            headerRepeater.DataBind();
        }

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater columnRepeater = e.Item.FindControl("Item1") as Repeater;
            var row = e.Item.DataItem as System.Data.DataRowView;
            columnRepeater.DataSource = row.Row.ItemArray;
            columnRepeater.DataBind();
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExportExcelSerial.ashx");
    }
}