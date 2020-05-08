<%@ WebHandler Language="C#" Class="BudgetCostTarget" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class BudgetCostTarget : IHttpHandler {

    ConnectDBBCS oConnBCS = new ConnectDBBCS();

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string Result = "";

        string pMode = context.Request.QueryString["pMode"] != null ? context.Request.QueryString["pMode"].ToString() : "";
        string pType = context.Request.QueryString["pType"] != null ? context.Request.QueryString["pType"].ToString() : "";
        string pYear = context.Request.QueryString["pYear"] != null ? context.Request.QueryString["pYear"].ToString() : "";
        string pBy = context.Request.QueryString["pBy"] != null ? context.Request.QueryString["pBy"].ToString() : "";
        string pStart = context.Request.QueryString["pStart"] != null ? context.Request.QueryString["pStart"].ToString() : "";
        string pEnd = context.Request.QueryString["pEnd"] != null ? context.Request.QueryString["pEnd"].ToString() : "";

        if (pMode == "add")
        {
            Result = AddTarget(pType, pYear, pBy, pStart, pEnd);

        }else if(pMode == "get") {
            Result = GetTarget(pType, pYear);
        }

        context.Response.Write(Result);
    }

    public string GetTarget(string pType, string pYear) {
        string StrResult = "";
        DataTable dtCheck = new DataTable();
        string StrCheck = "SELECT Cost_Center, Focal_year, AccGroup, TG_APR, TG_MAY, TG_JUN,  "+
                "   TG_JUL, TG_AUG, TG_SEP, TG_OCT, TG_NOV, TG_DEC, TG_JAN, TG_FEB, TG_MAR "+
                " FROM BC_TARGET "+
                " WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year AND "+
                "   AccGroup=@AccGroup  ";
        SqlCommand cmdCheck = new SqlCommand();
        cmdCheck.CommandText = StrCheck;
        cmdCheck.CommandTimeout = 180;
        cmdCheck.Parameters.Add(new SqlParameter("@Cost_Center", pType));
        cmdCheck.Parameters.Add(new SqlParameter("@Focal_year", pYear));
        cmdCheck.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
        dtCheck = oConnBCS.Query(cmdCheck);
        if (dtCheck.Rows.Count > 0) {
            StrResult = dtCheck.Rows[0]["TG_APR"].ToString()+"|"+dtCheck.Rows[0]["TG_MAR"].ToString();
        }
        return StrResult;
    }



    public string AddTarget(string pType, string pYear, string pBy, string pStart, string pEnd) {
        string StrResult = "";

        DataTable dtCheck = new DataTable();
        string StrCheck = "SELECT Cost_Center, Focal_year, AccGroup, TG_APR, TG_MAY, TG_JUN,  "+
                "   TG_JUL, TG_AUG, TG_SEP, TG_OCT, TG_NOV, TG_DEC, TG_JAN, TG_FEB, TG_MAR "+
                " FROM BC_TARGET "+
                " WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year AND "+
                "   AccGroup=@AccGroup  ";
        SqlCommand cmdCheck = new SqlCommand();
        cmdCheck.CommandText = StrCheck;
        cmdCheck.CommandTimeout = 180;
        cmdCheck.Parameters.Add(new SqlParameter("@Cost_Center", pType));
        cmdCheck.Parameters.Add(new SqlParameter("@Focal_year", pYear));
        cmdCheck.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
        dtCheck = oConnBCS.Query(cmdCheck);

        decimal _dStart = 0;
        decimal _dEnd = 0;
        decimal _dDiff = 0;
        decimal _dDiffSplit = 0;
        decimal[] _dDataTarget = new decimal[12];

        try {
            _dStart = Convert.ToDecimal(pStart);
        } catch { _dStart = 0; }

        try {
            _dEnd = Convert.ToDecimal(pEnd);
        } catch { _dEnd = 0; }



        if (_dStart > 0 && _dEnd > 0)
        {
            _dDiff = _dStart - _dEnd;
            _dDiffSplit = _dDiff / 12;

            decimal _dLoopData = 0;
            _dLoopData = _dStart;
            for (int i = 0; i < _dDataTarget.Length; i++)
            {
                _dDataTarget[i] = _dLoopData;
                _dLoopData = _dLoopData - _dDiffSplit;
            }

            _dDataTarget[0] = _dStart;
            _dDataTarget[11] = _dEnd;
        }
        else {
            for (int i = 0; i < _dDataTarget.Length; i++)
            {
                _dDataTarget[i] = 0;
            }
        }



        if (dtCheck.Rows.Count == 0)
        {
            string StrInsert = "INSERT INTO BC_TARGET (Cost_Center, Focal_year, AccGroup, "+
                "   TG_APR, TG_MAY, TG_JUN, TG_JUL, TG_AUG, TG_SEP, TG_OCT, TG_NOV, "+
                "   TG_DEC, TG_JAN, TG_FEB, TG_MAR, Remark, upd_by, upd_dt) " +
                " VALUES (@Cost_Center, @Focal_year, @AccGroup, @TG_APR, "+
                " @TG_MAY, @TG_JUN, @TG_JUL, @TG_AUG, @TG_SEP, @TG_OCT, @TG_NOV, @TG_DEC, @TG_JAN, "+
                " @TG_FEB, @TG_MAR, @Remark, @upd_by, @upd_dt) ";
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = StrInsert;
            cmdInsert.CommandTimeout = 180;
            cmdInsert.Parameters.Add(new SqlParameter("@TG_APR", _dDataTarget[0]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_MAY", _dDataTarget[1]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_JUN", _dDataTarget[2]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_JUL", _dDataTarget[3]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_AUG", _dDataTarget[4]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_SEP", _dDataTarget[5]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_OCT", _dDataTarget[6]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_NOV", _dDataTarget[7]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_DEC", _dDataTarget[8]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_JAN", _dDataTarget[9]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_FEB", _dDataTarget[10]));
            cmdInsert.Parameters.Add(new SqlParameter("@TG_MAR", _dDataTarget[11]));
            cmdInsert.Parameters.Add(new SqlParameter("@Remark", ""));
            cmdInsert.Parameters.Add(new SqlParameter("@Cost_Center", pType));
            cmdInsert.Parameters.Add(new SqlParameter("@Focal_year", pYear));
            cmdInsert.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
            cmdInsert.Parameters.Add(new SqlParameter("@upd_by", pBy));
            cmdInsert.Parameters.Add(new SqlParameter("@upd_dt", DateTime.Now));
            oConnBCS.ExecuteCommand(cmdInsert);

            StrResult = "insert";
        }
        else {
            string StrUpdate = "UPDATE BC_TARGET SET "+
                "   TG_APR=@TG_APR, TG_MAY=@TG_MAY, TG_JUN=@TG_JUN, TG_JUL=@TG_JUL, "+
                "   TG_AUG=@TG_AUG, TG_SEP=@TG_SEP, TG_OCT=@TG_OCT, TG_NOV=@TG_NOV, TG_DEC=@TG_DEC, "+
                "   TG_JAN=@TG_JAN, TG_FEB=@TG_FEB, TG_MAR=@TG_MAR, Remark=@Remark, upd_by=@upd_by, upd_dt=@upd_dt " +
                " WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year AND AccGroup=@AccGroup  ";
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = StrUpdate;
            cmdUpdate.CommandTimeout = 180;
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_APR", _dDataTarget[0]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_MAY", _dDataTarget[1]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_JUN", _dDataTarget[2]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_JUL", _dDataTarget[3]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_AUG", _dDataTarget[4]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_SEP", _dDataTarget[5]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_OCT", _dDataTarget[6]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_NOV", _dDataTarget[7]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_DEC", _dDataTarget[8]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_JAN", _dDataTarget[9]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_FEB", _dDataTarget[10]));
            cmdUpdate.Parameters.Add(new SqlParameter("@TG_MAR", _dDataTarget[11]));
            cmdUpdate.Parameters.Add(new SqlParameter("@Remark", ""));
            cmdUpdate.Parameters.Add(new SqlParameter("@Cost_Center", pType));
            cmdUpdate.Parameters.Add(new SqlParameter("@Focal_year", pYear));
            cmdUpdate.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
            cmdUpdate.Parameters.Add(new SqlParameter("@upd_by", pBy));
            cmdUpdate.Parameters.Add(new SqlParameter("@upd_dt", DateTime.Now));
            oConnBCS.ExecuteCommand(cmdUpdate);

            StrResult = "update";
        }


        return StrResult;
    }




    public bool IsReusable {
        get {
            return false;
        }
    }

}