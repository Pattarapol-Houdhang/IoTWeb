using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportRankFH : System.Web.UI.Page
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

    FHIDService ptidSer;

    VIModelDetailService viModelDetailSer;

    ArrayList _idData;

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

                startDate = DateTime.ParseExact(dataDateTime[0] + " " + dataDateTime[1], "yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture);
                endDate = DateTime.ParseExact(dataDateTime[3] + " " + dataDateTime[4], "yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture);

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

                ViewState["conStr"] = "Data Source=" + ViewState["baseIP"].ToString() + ";Initial Catalog=" + ViewState["baseName"].ToString() + ";Persist Security Info=True;User ID=sa;Password=decjapan";

                lblLine.Text = _lineName;

                lblPartName.Text = _part;
                lblModelName.Text = "Model: " + _model;

                _maxVal = 0;
                _minVal = 0;
                _midVal = 0;
                _partID = "4";

                ptidSer = new FHIDService();
                viModelDetailSer = new VIModelDetailService();

                _idData = ptidSer.GetFHIDData(_modelID, startDate, endDate, ViewState["conStr"].ToString());

                dc = new DrawCharts();
            }
        }
    }

    public string resultDate()
    {
        return "<small>Update date : " + DateTime.Now.ToShortDateString() + "</small>";
    }

    public string resultFHID()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_mid + _IDData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("FHID", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _idData, typeof(FHIDInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultFHIDRoundness()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID ROUNDNESS";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("FHIDRound", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _idData, typeof(FHIDInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultFHIDCylindricity()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID CYLINDRICITY";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("FHIDCy", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _idData, typeof(FHIDInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultFHIDPerpen()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID PERPENDICULARITY";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("FHIDPer", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _idData, typeof(FHIDInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

}