using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportRankCS : System.Web.UI.Page
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

    CSODService csodSer;
    CSPINService cspinSer;
    CSECCService cseccSer;
    VIModelDetailService viModelDetailSer;

    ArrayList _odData;
    ArrayList _pinData;
    ArrayList _eccData;

    DrawCharts dc;
    string receiveText;
    string _lineName;
    CultureInfo culr = new CultureInfo("en-US");

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

                startDate = DateTime.ParseExact(dataDateTime[0] + " " + dataDateTime[1], "yyyy/MM/dd HH:mm:ss", null);
                endDate = DateTime.ParseExact(dataDateTime[3] + " " + dataDateTime[4], "yyyy/MM/dd HH:mm:ss", null);

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
                _partID = "1";

                csodSer = new CSODService();
                cspinSer = new CSPINService();
                cseccSer = new CSECCService();
                viModelDetailSer = new VIModelDetailService();

                _odData = csodSer.GetCSODData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _pinData = cspinSer.GetCSPINData(_modelID, startDate, endDate, ViewState["conStr"].ToString());
                _eccData = cseccSer.GetCSECCData(_modelID, startDate, endDate, ViewState["conStr"].ToString());

                dc = new DrawCharts();
            }
        }
    }

    public string resultDate()
    {
        return "<small>Update date : " + DateTime.Now.ToShortDateString() + "</small>";
    }

    public string resultODF()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "FRONT OD";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_mid + _ODData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("CSODF", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _odData, typeof(CSODInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultODR()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "REAR OD";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_mid + _ODData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("CSODR", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _odData, typeof(CSODInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultODFRoundness()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "FRONT ROUNDNESS";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CSODFR", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _odData, typeof(CSODInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultODRRoundness()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "REAR ROUNDNESS";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CSODRR", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _odData, typeof(CSODInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultODRCylindricity()
    {
        if (_odData != null)
        {
            string chartScript = "";
            string partType = "REAR CYLINDRICITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CSODRC", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _odData, typeof(CSODInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultODFCylindricity()
    {
        txtData.Text = "START";

        if (_odData != null)
        {
            txtData.Text += "1";
            string chartScript = "";
            string partType = "FRONT CYLINDRICITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());
            txtData.Text += "2";
            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;
            txtData.Text += "3";

            chartScript += dc.SetLineChartHeaderMax("CSODFC", partType, startDate + " to " + endDate, _maxVal, _minVal);
            txtData.Text += "4";
            chartScript += dc.SetLineChartSeriesDataMax(partType, _odData, typeof(CSODInfo), _maxVal);
            txtData.Text += "5";
            chartScript += dc.SetFooterChart();
            txtData.Text += "6";

            return chartScript;
        }
        else
        {
            return "";
        }
        
    }

    public string resultPINOD()
    {
        
        if (_pinData != null)
        {
            string chartScript = "";
            string partType = "PIN OD";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_mid + _ODData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            txtData.Text += "-IN-";

            foreach (CSPINInfo mData in _pinData)
            {
                txtData.Text += mData.Pin_datetime.ToString("yyyy-MM-dd HH:mm:ss");
            }

            txtData.Text += "-OUT-";
            chartScript += dc.SetLineChartHeader("CSPIN", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _pinData, typeof(CSPINInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

            return chartScript;
        }
        else
        {
            txtData.Text += "END";
            return "";
        }
    }

    public string resultPINRoundness()
    {
        if (_pinData != null)
        {
            string chartScript = "";
            string partType = "PIN ROUNDNESS";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CSPINR", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _pinData, typeof(CSPINInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultPINCylindricity()
    {
        if (_pinData != null)
        {
            string chartScript = "";
            string partType = "PIN CYLINDRICITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_min;

            chartScript += dc.SetLineChartHeaderMax("CSPINC", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesDataMax(partType, _pinData, typeof(CSPINInfo), _maxVal);
            chartScript += dc.SetFooterChart();

            return chartScript;
        }
        else
        {
            return "";
        }
    }

    public string resultECC()
    {
        if (_eccData != null)
        {
            string chartScript = "";
            string partType = "ECCENTRICITY";
            VIModelDetailInfo _ODData = viModelDetailSer.GetModelDetailDataByModelIDANDPartIDAndPartTypeName(_modelID, _partID, partType, ViewState["conStr"].ToString());

            _maxVal = _ODData.Part_mid + _ODData.Part_max;
            _minVal = _ODData.Part_mid + _ODData.Part_min;
            _midVal = ((_maxVal + _minVal) / 2);

            chartScript += dc.SetLineChartHeader("CSECC", partType, startDate + " to " + endDate, _maxVal, _minVal);
            chartScript += dc.SetLineChartSeriesData(partType, _eccData, typeof(CSECCInfo), _maxVal, _midVal, _minVal);
            chartScript += dc.SetFooterChartRank(partType);

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


    public string CheckPIN()
    {
        string strScript = "<script type='text/javascript' > ";
        strScript += "$(document).ready(function(){";
        if (_pinData != null)
        {
            strScript += " $('.content_pin').fadeIn(0); ";
        }
        else
        {
            strScript += " $('.content_pin').fadeOut(0); ";
        }
        strScript += " });</script>";
        return strScript;
    }

    public string CheckECCEN()
    {
        string strScript = "<script type='text/javascript' > ";
        strScript += "$(document).ready(function(){";
        if (_eccData != null)
        {
            strScript += " $('.content_eccen').fadeIn(0); ";
        }
        else
        {
            strScript += " $('.content_eccen').fadeOut(0); ";
        }
        strScript += " });</script>";
        return strScript;
    }
    


}