using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Monitoring_MCMatching : System.Web.UI.Page
{

    DateTime startDate;
    DateTime endDate;
    double _maxVal;
    double _minVal;
    double _midVal;
    string _model;
    string _modelID;
    string _part;
    string _partID;

    PTHEIService ptheiSer;
    CYHEIService cyheiSer;

    VIModelDetailService viModelDetailSer;
    
    ArrayList _heiData;
    ArrayList _CYheiData;

    DrawCharts dc;
    string receiveText;
    string _lineName;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                _modelID = Request.QueryString["report"].ToString();
               
                if (_modelID == "442")
                {
                    rdModel15.Checked = true;
                }
                else if (_modelID == "444")
                {
                    rdModel20.Checked = true;
                }
                else if (_modelID == "121")
                {
                    rdModel22.Checked = true;
                }
            }
            catch {
                _modelID = "442";
                rdModel15.Checked = true;
            }
                _model = "";
                _part = "";

            if (DateTime.Now.Hour > 8 && DateTime.Now.Hour < 20)
            {
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            }
            else {
                if (DateTime.Now.Hour >= 20) {
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
                    endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, 8, 0, 0);
                } else {
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, 20, 0, 0);
                    endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                }
            }
                _lineName = "MACHINE FACTORY 3";

                if (_lineName == "MECHA LINE 1")
                {
                    ViewState["baseName"] = "ETD_YC";
                    ViewState["baseIP"] = "192.168.226.234";
                }
                else if (_lineName == "MECHA LINE 2")
                {

                }
                else if (_lineName == "MECHA LINE 3")
                {
                    ViewState["baseName"] = "ETD_2YC";
                    ViewState["baseIP"] = "192.168.229.59";
                }
                else if (_lineName == "MACHINE FACTORY 3")
                {
                    ViewState["baseName"] = "ETD_FAC3";
                    ViewState["baseIP"] = "10.194.40.103";
                }

                ViewState["conStr"] = "Data Source=" + ViewState["baseIP"].ToString() + ";Initial Catalog=" + ViewState["baseName"].ToString() + ";Persist Security Info=True;User ID=sa;Password=decjapan";

                _maxVal = 0;
                _minVal = 0;
                _midVal = 0;
                _partID = "2";

                ptheiSer = new PTHEIService();
                cyheiSer = new CYHEIService();
                viModelDetailSer = new VIModelDetailService();
                
                _heiData = ptheiSer.GetPTHEIData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _CYheiData = cyheiSer.GetCYHEIData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                dc = new DrawCharts();
        }
        

    }

    public string resultPTHeight()
    {
        if (_heiData != null)
        {
            string chartScript = "";
            string partType = "HEIGHT";
            VIModelDetailInfo _HEIData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _HEIData.Part_mid + _HEIData.Part_max;
            _minVal = _HEIData.Part_mid + _HEIData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("PTHEI", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _heiData, typeof(PTHEIInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "<center><h3> - - - No Data - - - </h3></center><br/><br/><br/><br/><br/><br/>";
        }
    }


    public string resultCYHeight()
    {
        if (_CYheiData != null)
        {
            string chartScript = "";
            string partType = "HEIGHT";
            VIModelDetailInfo _HEIData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, "3", partType, ViewState["conStr"].ToString());

            _maxVal = _HEIData.Part_mid + _HEIData.Part_max;
            _minVal = _HEIData.Part_mid + _HEIData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("CYHEI", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _CYheiData, typeof(CYHEIInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "<center><h3> - - - No Data - - - </h3></center><br/><br/><br/><br/><br/><br/>";
        }
    }



    protected void rdModel_CheckedChanged(object sender, EventArgs e)
    {
        string _model = "";
        if (rdModel15.Checked) {
            _model = "442";
        } else if (rdModel20.Checked) {
            _model = "444";
        } else if (rdModel22.Checked) {
            _model = "121";
        }
    
        Response.Redirect("MCMatchingCR.aspx?report=" + _model);
    }


}