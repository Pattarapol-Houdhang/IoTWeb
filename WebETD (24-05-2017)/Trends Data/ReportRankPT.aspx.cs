using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportRankPT : System.Web.UI.Page
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

    PTODService ptodSer;
    PTIDService ptidSer;
    PTHEIService ptheiSer;
    PTBLService ptblSer;

    VIModelDetailService viModelDetailSer;

    ArrayList _odData;
    ArrayList _idData;
    ArrayList _heiData;
    ArrayList _blData;

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
                _partID = "2";

                ptodSer = new PTODService();
                ptidSer = new PTIDService();
                ptheiSer = new PTHEIService();
                ptblSer = new PTBLService();
                viModelDetailSer = new VIModelDetailService();

                _odData = ptodSer.GetPTODData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _idData = ptidSer.GetPTIDData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _heiData = ptheiSer.GetPTHEIData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _blData = ptblSer.GetPTBLData(_modelID, startDate, endDate, ViewState["conStr"].ToString());

                dc = new DrawCharts();
            }
        }
    }

    public string resultDate()
    {
        return "<small>Update date : " + DateTime.Now.ToShortDateString() + "</small>";
    }

    public string resultPTOD()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "OD";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_mid + _ODData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("PTOD", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _odData, typeof(PTODInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "";
        }
    }


    public string resultPTODRoundness()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "OD ROUNDNESS";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTODRound", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _odData, typeof(PTODInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTODCylindricity()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "OD CYLINDRICITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTODCy", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _odData, typeof(PTODInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTODPerpen()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "OD PERPENDICULARITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTODPer", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _odData, typeof(PTODInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTID()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_mid + _IDData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("PTID", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _idData, typeof(PTIDInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTIDRoundness()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID ROUNDNESS";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTIDRound", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _idData, typeof(PTIDInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTIDCylindricity()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID CYLINDRICITY";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTIDCy", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _idData, typeof(PTIDInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTIDPerpen()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID PERPENDICULARITY";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTIDPer", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _idData, typeof(PTIDInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTIDConcentric()
    {
        if (_idData != null)
        {
            string chartScript = "";
            string partType = "ID CONCENTRICITY";
            VIModelDetailInfo _IDData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _IDData.Part_mid + _IDData.Part_max;
            _minVal = _IDData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTIDCon", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _idData, typeof(PTIDInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
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
            return "";
        }
    }

    public string resultPTHEIPallism()
    {
        if (_heiData != null)
        {
            string chartScript = "";
            string partType = "HEIGHT PARALLISM";
            VIModelDetailInfo _HEIData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _HEIData.Part_mid + _HEIData.Part_max;
            _minVal = _HEIData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTHEIPall", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _heiData, typeof(PTHEIInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTBlade()
    {
        if (_blData != null)
        {
            string chartScript = "";
            string partType = "BLADE THICKNESS";
            VIModelDetailInfo _BLData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _BLData.Part_mid + _BLData.Part_max;
            _minVal = _BLData.Part_mid + _BLData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("PTBL", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _blData, typeof(PTBLInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTBLPallism()
    {
        if (_blData != null)
        {
            string chartScript = "";
            string partType = "BLADE PARALLISM";
            VIModelDetailInfo _BLData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _BLData.Part_mid + _BLData.Part_max;
            _minVal = _BLData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTBLPall", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _blData, typeof(PTBLInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPTBLPerpen()
    {
        if (_blData != null)
        {
            string chartScript = "";
            string partType = "BLADE PERPENDICULARITY";
            VIModelDetailInfo _BLData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _BLData.Part_mid + _BLData.Part_max;
            _minVal = _BLData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("PTBLPer", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _blData, typeof(PTBLInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }









    public string CheckOD() {
        string strScript = "<script type='text/javascript' > ";
        strScript += "$(document).ready(function(){";
        if (_odData != null)
        {
            strScript += " $('.content_od').fadeIn(0); ";
        }
        else {
            strScript += " $('.content_od').fadeOut(0); ";
        }
        strScript += " });</script>";
        return strScript;
    }

    public string CheckID() {
        string strScript = "<script type='text/javascript' > ";
        strScript += "$(document).ready(function(){";
        if (_idData != null)
        {
            strScript += " $('.content_id').fadeIn(0); ";
        }
        else {
            strScript += " $('.content_id').fadeOut(0); ";
        }
        strScript += " });</script>";
        return strScript;
    }

    public string CheckHeight() {
        string strScript = "<script type='text/javascript' > ";
        strScript += "$(document).ready(function(){";
        if (_heiData != null)
        {
            strScript += " $('.content_hei').fadeIn(0); ";
        }
        else {
            strScript += " $('.content_hei').fadeOut(0); ";
        }
        strScript += " });</script>";
        return strScript;
    }

    public string CheckBlade() {
        string strScript = "<script type='text/javascript' > ";
        strScript += "$(document).ready(function(){";
        if (_blData != null)
        {
            strScript += " $('.content_blade').fadeIn(0); ";
        }
        else {
            strScript += " $('.content_blade').fadeOut(0); ";
        }
        strScript += " });</script>";
        return strScript;
    }




}