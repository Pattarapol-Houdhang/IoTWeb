using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for CGenData
/// </summary>
public class CGenData
{
    CHeaderIndexUsed oHeaderInx = new CHeaderIndexUsed();
    public DataTable GetDataTable(string mc_code, string Model, DateTime DateStart, DateTime DateEnd)
    {
        DataTable dTable = new DataTable();
        dTable.TableName = "ExportData";

        MDHeaderIndexUsed oMDExport = new MDHeaderIndexUsed();
        oMDExport = oHeaderInx.GetDataWithHeaderInx(mc_code, Model, DateStart, DateEnd);

        
        if (oMDExport.ListOfHeaderIndexUsed.Count > 0)
        {
            string[] splColumn = oMDExport.ListOfHeaderIndexUsed[0].ColumnName.Split(',');
            if (splColumn.Length > 0)
            {
                foreach (string ColumnName in splColumn)
                {
                    dTable.Columns.Add(ColumnName, typeof(string));
                }
                //dTable.Columns.Add("Result");
            }


            for (int i = 0; i < oMDExport.ListOfHeaderIndexUsed.Count; i++)
            {
                bool CheckIndex = false;
                int countDetail = 0;
                string[] splDetail = oMDExport.ListOfHeaderIndexUsed[i].data_detail.Split(',');
                countDetail = splDetail.Length;

                DataRow dRow;
                dRow = dTable.NewRow();

                string[] splIndex = oMDExport.ListOfHeaderIndexUsed[i].field_index.Split(',');
                int CountColumn = 0;

                for (int j = 0; j < countDetail; j++)
                {
                    CheckIndex = false;
                    int inxResult = 0;
                    if (splIndex.Length > 0)
                    {

                        foreach (string index in splIndex)
                        {
                            inxResult++;
                            if (j == Convert.ToInt32(index))
                            {
                                CheckIndex = true;
                                if (index == oMDExport.ListOfHeaderIndexUsed[i].result_index)
                                {

                                }
                                break;
                            }
                        }
                    }

                    if (CheckIndex)
                    {
                        //dRow["Result"] = oMDExport.ListOfHeaderIndexUsed[i].Result;
                        dRow[CountColumn] = splDetail[j];
                        CountColumn++;
                    }

                }
                
                dTable.Rows.Add(dRow);

            }
        }
        else
        {
            //DataRow dRow;
            //dRow = dTable.NewRow();
            //dRow["CanEdit"] = false;
            //dRow["CanDel"] = false;
            //dTable.Rows.Add(dRow);
        }

        return dTable;
    }




}