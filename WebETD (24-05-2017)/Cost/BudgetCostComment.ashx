<%@ WebHandler Language="C#" Class="BudgetCostComment" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;

public class BudgetCostComment : IHttpHandler {
    ConnectDBBCS oConnBCS = new ConnectDBBCS();

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string Result = "";
        string pMode = context.Request.QueryString["pMode"] != null ? context.Request.QueryString["pMode"].ToString() : "";
        string pCmmtCode = context.Request.QueryString["pCmmtCode"] != null ? context.Request.QueryString["pCmmtCode"].ToString() : "";
        string pYear = context.Request.QueryString["pYear"] != null ? context.Request.QueryString["pYear"].ToString() : "";
        string pMonth = context.Request.QueryString["pMonth"] != null ? context.Request.QueryString["pMonth"].ToString() : "";
        string pBy = context.Request.QueryString["pBy"] != null ? context.Request.QueryString["pBy"].ToString() : "";
        string pCmmtText = context.Request.QueryString["pCmmtText"] != null ? context.Request.QueryString["pCmmtText"].ToString() : "";

        if (pMode == "add"){
            Result = AddComment(pCmmtCode, pYear, pCmmtText, pBy);
        }else if (pMode == "addMonth"){
            Result = AddCommentMonth(pCmmtCode, pYear, pMonth, pCmmtText, pBy);
        }else if(pMode == "get") {
            Result = GetComment(pCmmtCode, pYear);
        }

        context.Response.Write(Result);
    }

    public string GetComment(string dCmmtCode, string dYear ) {
        string StrResult = "";
        DataTable dtResult = new DataTable();
        string StrSelect = @"SELECT Cost_Center, Focal_year, AccGroup, CMMT_APR, CMMT_MAY, 
               CMMT_JUN, CMMT_JUL, CMMT_AUG, CMMT_SEP, CMMT_OCT, CMMT_NOV, CMMT_DEC, CMMT_JAN, 
               CMMT_FEB, CMMT_MAR, Remark, upd_by, upd_dt
            FROM BC_REPORT_COMMENT 
            WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year 
                AND AccGroup=@AccGroup  ";
        SqlCommand cmdSelect = new SqlCommand();
        cmdSelect.CommandText = StrSelect;
        cmdSelect.CommandTimeout = 180;
        cmdSelect.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
        cmdSelect.Parameters.Add(new SqlParameter("@Focal_year", dYear));
        cmdSelect.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
        dtResult = oConnBCS.Query(cmdSelect);
        if (dtResult.Rows.Count > 0) {
            StrResult += dtResult.Rows[0]["CMMT_APR"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_MAY"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_JUN"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_JUL"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_AUG"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_SEP"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_OCT"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_NOV"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_DEC"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_JAN"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_FEB"].ToString()+"|";
            StrResult += dtResult.Rows[0]["CMMT_MAR"].ToString();
        }else {
            StrResult = "|||||||||||";
        }
        return StrResult;
    }


    public string AddCommentMonth(string dCmmtCode, string dYear, string dMonth, string dCmmtText, string dBy) {
        string StrResult = "";

        DataTable dtCheck = new DataTable();
        string StrCheck = @"SELECT Cost_Center, Focal_year, AccGroup 
            FROM BC_REPORT_COMMENT 
            WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year AND AccGroup=@AccGroup ";
        SqlCommand cmdCheck = new SqlCommand();
        cmdCheck.CommandText = StrCheck;
        cmdCheck.CommandTimeout = 180;
        cmdCheck.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
        cmdCheck.Parameters.Add(new SqlParameter("@Focal_year", dYear));
        cmdCheck.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
        dtCheck = oConnBCS.Query(cmdCheck);


        if (dtCheck.Rows.Count == 0)
        {
            string StrInsert = @"INSERT INTO BC_REPORT_COMMENT (Cost_Center, Focal_year, AccGroup, 
               CMMT_APR, CMMT_MAY, CMMT_JUN, CMMT_JUL, CMMT_AUG, CMMT_SEP, CMMT_OCT, CMMT_NOV, 
               CMMT_DEC, CMMT_JAN, CMMT_FEB, CMMT_MAR, Remark, upd_by, upd_dt) VALUES 
               ( @Cost_Center, @Focal_year, @AccGroup, @CMMT_APR, @CMMT_MAY, @CMMT_JUN, @CMMT_JUL, 
                @CMMT_AUG, @CMMT_SEP, @CMMT_OCT, @CMMT_NOV, @CMMT_DEC, @CMMT_JAN, @CMMT_FEB, @CMMT_MAR, 
               @Remark, @upd_by, @upd_dt) ";
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = StrInsert;
            cmdInsert.CommandTimeout = 180;
            cmdInsert.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
            cmdInsert.Parameters.Add(new SqlParameter("@Focal_year", dYear));
            cmdInsert.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_APR", (dMonth=="APR") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_MAY", (dMonth=="MAY") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_JUN", (dMonth=="JUN") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_JUL", (dMonth=="JUL") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_AUG", (dMonth=="AUG") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_SEP", (dMonth=="SEP") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_OCT", (dMonth=="OCT") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_NOV", (dMonth=="NOV") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_DEC", (dMonth=="DEC") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_JAN", (dMonth=="JAN") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_FEB", (dMonth=="FEB") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_MAR", (dMonth=="MAR") ? dCmmtText : "" ));
            cmdInsert.Parameters.Add(new SqlParameter("@Remark", ""));
            cmdInsert.Parameters.Add(new SqlParameter("@upd_by", dBy));
            cmdInsert.Parameters.Add(new SqlParameter("@upd_dt", DateTime.Now));
            oConnBCS.ExecuteCommand(cmdInsert);
        }
        else {

            SqlCommand cmdUpdate = new SqlCommand();
            string UpdateData = "";
            switch (dMonth) {
                case "APR":
                    UpdateData = " CMMT_APR=@CMMT_APR ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_APR", dCmmtText));
                    break;
                case "MAY":
                    UpdateData = " CMMT_MAY=@CMMT_MAY ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_MAY", dCmmtText));
                    break;
                case "JUN":
                    UpdateData = " CMMT_JUN=@CMMT_JUN ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_JUN", dCmmtText));
                    break;
                case "JUL":
                    UpdateData = " CMMT_JUL=@CMMT_JUL ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_JUL", dCmmtText));
                    break;
                case "AUG":
                    UpdateData = " CMMT_AUG=@CMMT_AUG ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_AUG", dCmmtText));
                    break;
                case "SEP":
                    UpdateData = " CMMT_SEP=@CMMT_SEP ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_SEP", dCmmtText));
                    break;
                case "OCT":
                    UpdateData = " CMMT_OCT=@CMMT_OCT ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_OCT", dCmmtText));
                    break;
                case "NOV":
                    UpdateData = " CMMT_NOV=@CMMT_NOV ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_NOV", dCmmtText));
                    break;
                case "DEC":
                    UpdateData = " CMMT_DEC=@CMMT_DEC ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_DEC", dCmmtText));
                    break;
                case "JAN":
                    UpdateData = " CMMT_JAN=@CMMT_JAN ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_JAN", dCmmtText));
                    break;
                case "FEB":
                    UpdateData = " CMMT_FEB=@CMMT_FEB ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_FEB", dCmmtText));
                    break;
                case "MAR":
                    UpdateData = " CMMT_MAR=@CMMT_MAR ";
                    cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_MAR", dCmmtText));
                    break;
            }

            string StrUpdate = @"UPDATE BC_REPORT_COMMENT SET upd_by=@upd_by, upd_dt=@upd_dt, " + UpdateData +
                " WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year AND AccGroup=@AccGroup ";

            cmdUpdate.CommandText = StrUpdate;
            cmdUpdate.CommandTimeout = 180;
            cmdUpdate.Parameters.Add(new SqlParameter("@upd_by", dBy));
            cmdUpdate.Parameters.Add(new SqlParameter("@upd_dt", DateTime.Now));
            cmdUpdate.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
            cmdUpdate.Parameters.Add(new SqlParameter("@Focal_year", dYear));
            cmdUpdate.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
            oConnBCS.ExecuteCommand(cmdUpdate);
        }

        DataTable dtResult = new DataTable();
        string StrSelect = @"SELECT Cost_Center, Focal_year, AccGroup, CMMT_APR, CMMT_MAY, 
               CMMT_JUN, CMMT_JUL, CMMT_AUG, CMMT_SEP, CMMT_OCT, CMMT_NOV, CMMT_DEC, CMMT_JAN, 
               CMMT_FEB, CMMT_MAR, Remark, upd_by, upd_dt
            FROM BC_REPORT_COMMENT 
            WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year 
                AND AccGroup=@AccGroup  ";
        SqlCommand cmdSelect = new SqlCommand();
        cmdSelect.CommandText = StrSelect;
        cmdSelect.CommandTimeout = 180;
        cmdSelect.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
        cmdSelect.Parameters.Add(new SqlParameter("@Focal_year", dYear));
        cmdSelect.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
        dtResult = oConnBCS.Query(cmdSelect);
        if (dtResult.Rows.Count > 0)
        {
            StrResult += dtResult.Rows[0]["CMMT_APR"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_MAY"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_JUN"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_JUL"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_AUG"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_SEP"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_OCT"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_NOV"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_DEC"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_JAN"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_FEB"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_MAR"].ToString();
        }
        else {
            StrResult = "|||||||||||";
        }

        return StrResult;
    }


    public string AddComment(string dCmmtCode, string dYear, string dCmmtText, string dBy) {
        string StrResult = "";

        string[] CmmtTxt = dCmmtText.Split('|');

        DataTable dtCheck = new DataTable();
        string StrCheck = @"SELECT Cost_Center, Focal_year, AccGroup 
            FROM BC_REPORT_COMMENT 
            WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year AND AccGroup=@AccGroup ";
        SqlCommand cmdCheck = new SqlCommand();
        cmdCheck.CommandText = StrCheck;
        cmdCheck.CommandTimeout = 180;
        cmdCheck.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
        cmdCheck.Parameters.Add(new SqlParameter("@Focal_year", dYear));
        cmdCheck.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
        dtCheck = oConnBCS.Query(cmdCheck);


        if (dtCheck.Rows.Count == 0)
        {
            string StrInsert = @"INSERT INTO BC_REPORT_COMMENT (Cost_Center, Focal_year, AccGroup, 
               CMMT_APR, CMMT_MAY, CMMT_JUN, CMMT_JUL, CMMT_AUG, CMMT_SEP, CMMT_OCT, CMMT_NOV, 
               CMMT_DEC, CMMT_JAN, CMMT_FEB, CMMT_MAR, Remark, upd_by, upd_dt) VALUES 
               ( @Cost_Center, @Focal_year, @AccGroup, @CMMT_APR, @CMMT_MAY, @CMMT_JUN, @CMMT_JUL, 
                @CMMT_AUG, @CMMT_SEP, @CMMT_OCT, @CMMT_NOV, @CMMT_DEC, @CMMT_JAN, @CMMT_FEB, @CMMT_MAR, 
               @Remark, @upd_by, @upd_dt) ";
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = StrInsert;
            cmdInsert.CommandTimeout = 180;
            cmdInsert.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
            cmdInsert.Parameters.Add(new SqlParameter("@Focal_year", dYear));
            cmdInsert.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_APR", CmmtTxt[0]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_MAY", CmmtTxt[1]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_JUN", CmmtTxt[2]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_JUL", CmmtTxt[3]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_AUG", CmmtTxt[4]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_SEP", CmmtTxt[5]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_OCT", CmmtTxt[6]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_NOV", CmmtTxt[7]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_DEC", CmmtTxt[8]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_JAN", CmmtTxt[9]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_FEB", CmmtTxt[10]));
            cmdInsert.Parameters.Add(new SqlParameter("@CMMT_MAR", CmmtTxt[11]));
            cmdInsert.Parameters.Add(new SqlParameter("@Remark", ""));
            cmdInsert.Parameters.Add(new SqlParameter("@upd_by", dBy));
            cmdInsert.Parameters.Add(new SqlParameter("@upd_dt", DateTime.Now));
            oConnBCS.ExecuteCommand(cmdInsert);
        }
        else {
            string StrUpdate = @"UPDATE BC_REPORT_COMMENT SET 
                  CMMT_APR=@CMMT_APR, CMMT_MAY=@CMMT_MAY, CMMT_JUN=@CMMT_JUN, CMMT_JUL=@CMMT_JUL, 
                  CMMT_AUG=@CMMT_AUG, CMMT_SEP=@CMMT_SEP, CMMT_OCT=@CMMT_OCT, CMMT_NOV=@CMMT_NOV, 
                  CMMT_DEC=@CMMT_DEC, CMMT_JAN=@CMMT_JAN, CMMT_FEB=@CMMT_FEB, CMMT_MAR=@CMMT_MAR, 
                  upd_by=@upd_by, upd_dt=@upd_dt 
                WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year AND AccGroup=@AccGroup ";
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandText = StrUpdate;
            cmdUpdate.CommandTimeout = 180;
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_APR", CmmtTxt[0]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_MAY", CmmtTxt[1]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_JUN", CmmtTxt[2]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_JUL", CmmtTxt[3]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_AUG", CmmtTxt[4]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_SEP", CmmtTxt[5]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_OCT", CmmtTxt[6]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_NOV", CmmtTxt[7]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_DEC", CmmtTxt[8]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_JAN", CmmtTxt[9]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_FEB", CmmtTxt[10]));
            cmdUpdate.Parameters.Add(new SqlParameter("@CMMT_MAR", CmmtTxt[11]));
            cmdUpdate.Parameters.Add(new SqlParameter("@upd_by", dBy));
            cmdUpdate.Parameters.Add(new SqlParameter("@upd_dt", DateTime.Now));
            cmdUpdate.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
            cmdUpdate.Parameters.Add(new SqlParameter("@Focal_year", dYear));
            cmdUpdate.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
            oConnBCS.ExecuteCommand(cmdUpdate);
        }

        DataTable dtResult = new DataTable();
        string StrSelect = @"SELECT Cost_Center, Focal_year, AccGroup, CMMT_APR, CMMT_MAY, 
               CMMT_JUN, CMMT_JUL, CMMT_AUG, CMMT_SEP, CMMT_OCT, CMMT_NOV, CMMT_DEC, CMMT_JAN, 
               CMMT_FEB, CMMT_MAR, Remark, upd_by, upd_dt
            FROM BC_REPORT_COMMENT 
            WHERE Cost_Center=@Cost_Center AND Focal_year=@Focal_year 
                AND AccGroup=@AccGroup  ";
        SqlCommand cmdSelect = new SqlCommand();
        cmdSelect.CommandText = StrSelect;
        cmdSelect.CommandTimeout = 180;
        cmdSelect.Parameters.Add(new SqlParameter("@Cost_Center", dCmmtCode));
        cmdSelect.Parameters.Add(new SqlParameter("@Focal_year", dYear));
        cmdSelect.Parameters.Add(new SqlParameter("@AccGroup", "EXP"));
        dtResult = oConnBCS.Query(cmdSelect);
        if (dtResult.Rows.Count > 0)
        {
            StrResult += dtResult.Rows[0]["CMMT_APR"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_MAY"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_JUN"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_JUL"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_AUG"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_SEP"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_OCT"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_NOV"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_DEC"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_JAN"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_FEB"].ToString() + "|";
            StrResult += dtResult.Rows[0]["CMMT_MAR"].ToString();
        }
        else {
            StrResult = "|||||||||||";
        }

        return StrResult;
    }



    public bool IsReusable {
        get {
            return false;
        }
    }

}