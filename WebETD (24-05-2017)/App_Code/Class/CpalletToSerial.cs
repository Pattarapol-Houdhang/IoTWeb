using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ALPHAWinServices;
using Oracle.ManagedDataAccess.Client;
/// <summary>
/// <summary>
/// Summary description for CpalletToSerial
/// </summary>
public class CpalletToSerial
{
    ConnectDB oConDIT = new ConnectDB();
    ConnectDBSCM oConSCM = new ConnectDBSCM();
    ClsALPHA CAlpha = new ClsALPHA();
    OraConnectDB oOraAL1 = new OraConnectDB("ALPHA01");

    public DataTable LoadSerialFromAlphaByPLNO(string PLNO)
    {
        DataTable dTable = new DataTable();
        string strSQL = @"SELECT PLNO,SERIAL,MODEL,NWC,NDATE,CDATE,CTIME
            FROM SE.FH001@ALPHAPD WHERE TRIM(PLNO)='" + PLNO.Substring(0,PLNO.Length-1) + "'";
        OracleCommand cmdComp = new OracleCommand();
        cmdComp.CommandText = strSQL;
        cmdComp.CommandTimeout = 120;
        dTable = oOraAL1.Query(cmdComp);
        return dTable;
    }
    public DataTable LoadSerialFromAlpahBySerial(string Serial)
    {
        DataTable dTable = new DataTable();
        string strSQL = @"SELECT PLNO,SERIAL,MODEL,NWC,NDATE,CDATE,CTIME
            FROM SE.FH001@ALPHAPD WHERE TRIM(SERIAL)='" + Serial + "'";
        OracleCommand cmdComp = new OracleCommand();
        cmdComp.CommandText = strSQL;
        cmdComp.CommandTimeout = 120;
        dTable = oOraAL1.Query(cmdComp);
        return dTable;
    }
}