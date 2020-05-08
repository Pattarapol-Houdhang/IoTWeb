
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CModelInfo
/// </summary>
public class CModelInfo
{
    ConnectDBSCM oConn = new ConnectDBSCM();

    public CModelInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<MDModelCompressor> GetModelCompressor()
    {
        List<MDModelCompressor> oList = new List<MDModelCompressor>();

        SqlCommand sql = new SqlCommand();
        sql.CommandText = "SELECT DISTINCT Model,ModelCode FROM [PN_Compressor] WHERE Model != '1YC22DXD/3' ORDER BY Model ";
        DataTable dt = oConn.Query(sql);
        foreach  (DataRow item in dt.Rows)
        {
            MDModelCompressor oModel = new MDModelCompressor();
            oModel.Model = item["Model"].ToString();
            oModel.ModelCode = item["ModelCode"].ToString();
            oList.Add(oModel);
        }

        return oList;
    }
}