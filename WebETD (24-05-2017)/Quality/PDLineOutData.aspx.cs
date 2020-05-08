using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProductionServices;


public partial class Quality_PDLineOutData : System.Web.UI.Page
{
    ConnectDBDCIMax oConn = new ConnectDBDCIMax();
    ConnectDBDCI oConDCI = new ConnectDBDCI();
    ConnectDB oConCostyIoT = new ConnectDB();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    DateTime strDate = new DateTime();
    DateTime endDate = new DateTime();
    ProductionService srvProd = new ProductionService();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Attributes.Add("readonly", "readonly");
            GetData();
        }
    }
    



    public string GetData()
    {
        string SerialLike = "%", ModelLike = "%", ConditionStatus = "", PalletNo = "", ConditionLine = "";

        PalletNo = txtPalletNo.Text != "" ? "%" + txtPalletNo.Text.Trim() + "%" : "%";
        ModelLike = txtModel.Text != "" ? "%" + txtModel.Text.Trim() + "%" : "%";

        if (ddlStatus.SelectedValue.ToString() == "ALL")
        {
            ConditionStatus = " AND prd_status IN ('HOLD','REQUEST','LINEOUT', 'ALLOW') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "HOLD")
        {
            ConditionStatus = " AND prd_status IN ('HOLD','REQUEST') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "LINEOUT")
        {
            ConditionStatus = " AND prd_status IN ('LINEOUT') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "REQUEST")
        {
            ConditionStatus = " AND prd_status IN ('REQUEST') ";
        }
        else if (ddlStatus.SelectedValue.ToString() == "ALLOW")
        {
            ConditionStatus = " AND prd_status IN ('ALLOW') ";
        }
        else
        {
            ConditionStatus = "";
        }


        //*********************************
        //         Line Master
        //*********************************
        
        string LineMstr = "";
        if (ddlProdLine.SelectedValue.ToString() == "1YC")
        {
            ConditionLine = " AND prd_model LIKE '1YC%' ";
            LineMstr = "1YC FINAL"; 
        }
        else if (ddlProdLine.SelectedValue.ToString() == "2YC")
        {
            ConditionLine = " AND prd_model LIKE '2YC%' ";
            LineMstr = "2YC FINAL"; 
        }
        else if (ddlProdLine.SelectedValue.ToString() == "SCR")
        {
            ConditionLine = " AND prd_model LIKE 'J%' ";
            LineMstr = "SCROLL FINAL"; 
        }
        else if (ddlProdLine.SelectedValue.ToString() == "ODM")
        {
            ConditionLine = " AND (prd_model LIKE '1P%' OR prd_model LIKE '2P%') ";
            LineMstr = "ODM FINAL"; 
        }
        

        DataTable dtLineMstr = new DataTable();
        string StrLineMstr = @"SELECT ProcessCode, ProcessName FROM PD_Hold_Mstr WHERE Line=@Line ORDER BY ProcessOrder ASC ";
        SqlCommand cmdLineMstr = new SqlCommand();
        cmdLineMstr.CommandText = StrLineMstr;
        cmdLineMstr.CommandTimeout = 180;
        cmdLineMstr.Parameters.Add(new SqlParameter("@Line", LineMstr));
        dtLineMstr = oConDCI.Query(cmdLineMstr);
        //*********************************


        string _html = "<table class='table table-striped table-advance table-hover' id='example' width='100%'>";
        _html += "<thead><tr><th align='center'>Production Line</th><th align='center'>Serial No</th><th align='center'>Pallet No</th>";
        _html += "<th align='center'>ModelCode</th><th align='center'>Model</th>";
        if (dtLineMstr.Rows.Count > 0) {
            foreach (DataRow drMstr in dtLineMstr.Rows) {
                _html += "<th align='center'>" + drMstr["ProcessName"].ToString() + "</th>";
            }
        }
        _html += "<th align='center'>LineOut By</th><th align='center'>LineOut Date</th>";
        _html += "<th align='center'>Status</th></tr></thead>";
        _html += "<tbody>";

        SqlCommand sql = new SqlCommand();
        string strSQL = @"SELECT HoldNbr, LotUnholdNbr, LotNbr, prd_serial, prd_line, prd_model_code, 
                    prd_model, pl_no, prd_pipe_no, HoldBy, HoldDate, prd_status, RequestBy, 
                    RequestDate, AllowBy, AllowDate, remark1, remark2, remark3 
            FROM PD_Hold ";
        strSQL += " WHERE prd_model LIKE '" + ModelLike + "' " + ConditionStatus + ConditionLine;
        sql.CommandText = strSQL;
        if (txtDate.Text != "")
        {
            string[] spOutDate = txtDate.Text.Split('-');
            if (spOutDate.Length > 0)
            {
                strDate = DateTime.ParseExact(spOutDate[0].Replace(" ", ""), "dd/MM/yyyy", culture);
                strDate = strDate.Date + new TimeSpan(0, 0, 0);
                endDate = DateTime.ParseExact(spOutDate[1].Replace(" ", ""), "dd/MM/yyyy", culture);
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                strSQL += " AND (HoldDate >= '" + strDate.ToString("yyyy-MM-dd HH:mm:ss") + "' AND HoldDate <= '" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            }
        }
        else
        {
            strSQL += " AND (HoldDate >= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00' AND HoldDate <= '" + DateTime.Now.ToString("yyyy-MM-dd") + " 20:00:00')";
        }
        strSQL += " ORDER BY HoldDate DESC ";
        sql.CommandText = strSQL;
        DataTable dtHead = new DataTable();
        dtHead = oConDCI.Query(sql);
        if (dtHead.Rows.Count > 0) {
            foreach (DataRow drHead in dtHead.Rows)
            {
                string EmpName = "";
                DataTable dtEmp = new DataTable();
                string StrEmp = @"SELECT CODE,NAME,SURN,POSIT FROM Employee WHERE CODE=@CODE ";
                SqlCommand cmdEmp = new SqlCommand();
                cmdEmp.CommandText = StrEmp;
                cmdEmp.CommandTimeout = 180;
                cmdEmp.Parameters.Add(new SqlParameter("@CODE", drHead["HoldBy"].ToString()));
                dtEmp = oConDCI.Query(cmdEmp);
                try { 
                    EmpName = (dtEmp.Rows.Count > 0) ? dtEmp.Rows[0]["NAME"].ToString()+"."+ dtEmp.Rows[0]["SURN"].ToString().Substring(0,1) : drHead["HoldBy"].ToString();
                }
                catch { EmpName = drHead["HoldBy"].ToString(); }


                _html += "<tr>";
                _html += "<td>"+ LineMstr.Replace("FINAL",": Line ") + drHead["prd_line"].ToString() + "</td>";
                _html += "<td align='center'>"+ drHead["prd_serial"].ToString() + "</td>";
                _html += "<td align='center'>"+ drHead["pl_no"].ToString() + "</td>";
                _html += "<td align='center'>"+ drHead["prd_model_code"].ToString() + "</td>";
                _html += "<td>"+ drHead["prd_model"].ToString() + "</td>";

                //******** LineOut Detial ********
                foreach (DataRow drMstr in dtLineMstr.Rows)
                {
                    DataTable dtLineDet = new DataTable();
                    string StrLineDet = @"SELECT ProcessStatus,ProcessDate,UpdateBy,UpdateDate 
                        FROM PD_Hold_Detail 
                        WHERE HoldNbr=@HoldNbr AND ProcessCode=@ProcessCode ";
                    SqlCommand cmdLineDet = new SqlCommand();
                    cmdLineDet.CommandText = StrLineDet;
                    cmdLineDet.CommandTimeout = 180;
                    cmdLineDet.Parameters.Add(new SqlParameter("@HoldNbr", drHead["HoldNbr"].ToString()));
                    cmdLineDet.Parameters.Add(new SqlParameter("@ProcessCode", drMstr["ProcessCode"].ToString()));
                    dtLineDet = oConDCI.Query(cmdLineDet);
                    if (dtLineDet.Rows.Count > 0)
                    {
                        _html += "<td align='center'>" + dtLineDet.Rows[0]["ProcessStatus"].ToString() + "</td>";
                    }
                    else {
                        _html += "<td></td>";
                    }
                }
                //******** LineOut Detial ********
                string _Status = (drHead["prd_status"].ToString() == "ALLOW") ? "UNHOLD" : drHead["prd_status"].ToString();
                _html += "<td>"+ EmpName + "</td>";
                _html += "<td align='center'>"+ drHead["HoldDate"].ToString() + "</td>";
                _html += "<td align='center'>"+ _Status + "</td>";
                _html += "</tr>";
            }
        }

        _html += "</tbody></table>";


        return _html;
        
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetData();
    }
    

    public string GetFactory(string _LabelNo, string _Model)
    {
        string result = "";

        //******* 1YC *******
        if (_Model.Substring(0, 3) == "1YC")
        {
            if (_LabelNo.StartsWith("8"))
            {
                result = "1";
            }
            else if (_LabelNo.StartsWith("3") || _LabelNo.StartsWith("4"))
            {
                result = "1";
            }
            else if (_LabelNo.StartsWith("9") || _LabelNo.StartsWith("0"))
            {
                result = "3";
            }
        }
        //******* 2YC *******
        else if (_Model.Substring(0, 3) == "2YC")
        {
            if (_LabelNo.StartsWith("1") || _LabelNo.StartsWith("2"))
            {
                result = "2";
            }
            else if (_LabelNo.StartsWith("3") || _LabelNo.StartsWith("4"))
            {
                result = "2";
            }
        }
        //******* SRC *******
        else
        {
            result = "2";
        } // end check model

        return result;
    }

    

}