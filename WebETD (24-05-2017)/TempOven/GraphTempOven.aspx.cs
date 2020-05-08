using System;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class GraphTempOven : System.Web.UI.Page
{


    private CGeneralDDL oGenDDL = new CGeneralDDL();
    private ConnectDBCosty oConn = new ConnectDBCosty();
    private ConnectDBIoT oConnn = new ConnectDBIoT();
    private CTempOvenInfo oTempOven = new CTempOvenInfo();
      string BoardID = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BoardID = Request.QueryString["BoardID"] != null ? Request.QueryString["BoardID"].ToString() : "301";

       //     oGenDDL.GetDDLChannel(ddlTabTempOvenCH);
            oGenDDL.GetDDLMonth(ddlTabTempOvenMonth);
        //    oGenDDL.GetDDLMonth(ddlTabTempOvenMonth);
            
           // oGenDDL.GetDDLYear(ddlTapTempOvenYear);
            GetDataTempOven("301");
            //   GetDataTempOvenDay("301");
            //  GetTarget();
        }
    }

    private void GetDataTempOven(string BoardID)
    {
        DataTable dt = oTempOven.GetTempOven(BoardID);
        if (dt.Rows.Count > 0)
        {

      //      rptTempCH.DataSource = dt;
      //      rptTempCH.DataBind();

            //   if (oPD.GetActual(BoardID, false) > 0)
            //   {
            //       decimal kwhunit = Convert.ToDecimal(dt.Rows[0]["Temp"].ToString());// / oPD.GetActual(BoardID, false);
            //      lbTabEGKWR.Text = "Usage/Unit : " + Math.Round(kwhunit, 2).ToString() + " KWH";

            // double cost = (Convert.ToDouble(dt.Rows[0]["Kwh"].ToString()) / oPD.GetActualByDate(BoardID, (DateTime.Now.Date + new TimeSpan(0, 0, 0)))) * 3.86;
            // lbTabEGCost.Text = "Cost/Unit : " + Math.Round(cost, 2).ToString() + " Bath";
            //    }

        }
    }

    

    //------------- Get Tab TempOven -------------------//
}