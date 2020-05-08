using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportRankCY : System.Web.UI.Page
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

    CYBOService cyboSer;
    CYBUService cybuSer;
    CYHEIService cyheiSer;

    VIModelDetailService viModelDetailSer;

    ArrayList _boData;
    ArrayList _buData;
    ArrayList _heiData;

    DrawCharts dc;
    string receiveText;
    string _lineName;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((receiveText = Request.QueryString["report"]) != null)
            {
                var dataSplit = receiveText.Split(',');

                _modelID = dataSplit[0];
                _model = dataSplit[1];
                _part = dataSplit[2];

                string dateTime = dataSplit[3];
                var dataDateTime = dateTime.Split(' ');

                startDate = DateTime.ParseExact(dataDateTime[0] + " " + dataDateTime[1], "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
                endDate = DateTime.ParseExact(dataDateTime[3] + " " + dataDateTime[4], "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);

                _lineName = dataSplit[4];

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

                ViewState["conStr"] = "Data Source=" + ViewState["baseIP"].ToString() + ";Initial Catalog=" + ViewState["baseName"].ToString() + ";Persist Security Info=True;User ID=etd;Password=dcitosei";

                lblLine.Text = _lineName;

                lblPartName.Text = _part;
                lblModelName.Text = "Model: " + _model;

                _maxVal = 0;
                _minVal = 0;
                _midVal = 0;
                _partID = "3";

                cyboSer = new CYBOService();
                cybuSer = new CYBUService();
                cyheiSer = new CYHEIService();
                viModelDetailSer = new VIModelDetailService();

                _boData = cyboSer.GetCYBOData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _buData = cybuSer.GetCYBUData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _heiData = cyheiSer.GetCYHEIData(_modelID, startDate, endDate, ViewState["conStr"].ToString());

                dc = new DrawCharts();
            }
        }
    }

    public string resultDate()
    {
        return "<small>Update date : " + DateTime.Now.ToShortDateString() + "</small>";
    }

    public string resultCYBO()
    {
        if (_boData != null)
        {
            string chartScript = "";
            string partType = "BORE ID";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_mid + _ODData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("CYBO", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _boData, typeof(CYBOInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }


    public string resultCYBORoundness()
    {
        if (_boData != null)
        {
            string chartScript = "";
            string partType = "BORE ID ROUNDNESS";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CYBORound", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _boData, typeof(CYBOInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultCYBOCylindricity()
    {
        if (_boData != null)
        {
            string chartScript = "";
            string partType = "BORE ID CYLINDRICITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CYBOCy", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _boData, typeof(CYBOInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultCYBOPerpen()
    {
        if (_boData != null)
        {
            string chartScript = "";
            string partType = "BORE ID PERPENDICULARITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CYBOPer", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _boData, typeof(CYBOInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultCYBOConcentric()
    {
        if (_boData != null)
        {
            string chartScript = "";
            string partType = "BORE ID CONCENTRICITY";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CYBOCon", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _boData, typeof(CYBOInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultCYBU()
    {
        if (_buData != null)
        {
            string chartScript = "";
            string partType = "BUSH ID";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_mid + _IDData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("CYBU", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _buData, typeof(CYBUInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultCYBURoundness()
    {
        if (_buData != null)
        {
            string chartScript = "";
            string partType = "BUSH ID ROUNDNESS";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CYBURound", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _buData, typeof(CYBUInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultCYBUPerpen()
    {
        if (_buData != null)
        {
            string chartScript = "";
            string partType = "BUSH ID PERPENDICULARITY";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CYBUPer", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _buData, typeof(CYBUInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }


    public string resultCYHeight()
    {
        if (_heiData != null)
        {
            string chartScript = "";
            string partType = "HEIGHT";
            VIModelDetailInfo _HEIData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _HEIData.Part_mid + _HEIData.Part_max;
            _minVal = _HEIData.Part_mid + _HEIData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("CYHEI", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _heiData, typeof(CYHEIInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultCYHEIPallism()
    {
        if (_heiData != null)
        {
            string chartScript = "";
            string partType = "HEIGHT PARALLISM";
            VIModelDetailInfo _HEIData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _HEIData.Part_mid + _HEIData.Part_max;
            _minVal = _HEIData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CYHEIPall", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _heiData, typeof(CYHEIInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

}