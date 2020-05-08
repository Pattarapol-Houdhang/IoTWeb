using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DailyProductivity : System.Web.UI.Page
{
    private ConnectDBPDB conPDB = new ConnectDBPDB();
    private ConnectDBIoTServerTon conIoT = new ConnectDBIoTServerTon();
    private List<PdLineProductInfo> products = new List<PdLineProductInfo>();
    private DateTime selectDate = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
			
			selectDate = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

			DateTime startDateDay = new DateTime();
			DateTime endDateDay = new DateTime();
			DateTime startDateNight = new DateTime();
			DateTime endDateNight = new DateTime();

			startDateDay = Convert.ToDateTime(selectDate.ToString("yyyy-MM-dd") + " 08:00:00.000");
			endDateDay = Convert.ToDateTime(selectDate.ToString("yyyy-MM-dd") + " 19:59:59.000");
			startDateNight = Convert.ToDateTime(selectDate.ToString("yyyy-MM-dd") + " 20:00:00.000");
			endDateNight = Convert.ToDateTime(selectDate.AddDays(1).ToString("yyyy-MM-dd") + " 07:59:00.000");

			// Load DataTable of Fac 3 Line
			DataTable dtLine = new DataTable();
			SqlCommand sqlSelect = new SqlCommand();
			sqlSelect.CommandText = "SELECT Line.LineId, Line.LineCode, Line.LineName, board.BoardId FROM PD_LineMstr AS Line INNER JOIN BoardData AS board ON Line.BoardId = board.BoardId WHERE Line.Factory ='3' ORDER BY board.BoardId ASC";
			sqlSelect.CommandTimeout = 180;
			dtLine = conPDB.Query(sqlSelect);
			if (dtLine.Rows.Count > 0)
			{
				foreach (DataRow row in dtLine.Rows)
				{
					// Get BoardId
					string boardId = row["BoardId"].ToString();

					// Get ACTUAL
					AndonDataLog dataLogDay = GetActual(boardId, startDateDay, endDateDay);
					AndonDataLog dataLogNight = GetActual(boardId, startDateNight, endDateNight);

					PdLineProductInfo product = new PdLineProductInfo();
					product.BoardId = boardId;
					product.LineCode = row["LineCode"].ToString();
					product.LineName = row["LineName"].ToString();
					product.DataDate = startDateDay;
					// DAY
					product.ActualDay = dataLogDay.Actual;
					product.DiffDay = dataLogDay.Diff;
					product.PlanDay = dataLogDay.DailyPlan;
					
					// NIGHT
					product.ActualNight = dataLogNight.Actual;
					product.DiffNight = dataLogNight.Diff;
					product.PlanNight = dataLogNight.DailyPlan;

					if (boardId == "301")
					{
						product.TotalNgDay = GetTotalMainAssyNg(startDateDay, endDateDay);
						product.TotalNgNight = GetTotalMainAssyNg(startDateNight, endDateNight);
					}
					else
					{
						product.TotalNgDay = 0;
						product.TotalNgNight = 0;
					}

					products.Add(product);
				}
			}

			if (products.Count > 0)
			{
				rptData.DataSource = products;
				rptData.DataBind();
			}
			else
			{
				rptData.DataSource = null;
				rptData.DataBind();
			}
        }
    }

    protected void rptData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            PdLineProductInfo product = e.Item.DataItem as PdLineProductInfo;

            Literal ltrLineCode = e.Item.FindControl("ltrLineCode") as Literal;
            Literal ltrLineName = e.Item.FindControl("ltrLineName") as Literal;
            Literal ltrBoardId = e.Item.FindControl("ltrBoardId") as Literal;
            Literal ltrPlanDay = e.Item.FindControl("ltrPlanDay") as Literal;
            Literal ltrActualDay = e.Item.FindControl("ltrActualDay") as Literal;
            Literal ltrDiffDay = e.Item.FindControl("ltrDiffDay") as Literal;
            Literal ltrTotalNgDay = e.Item.FindControl("ltrTotalNgDay") as Literal;
            Literal ltrPlanNight = e.Item.FindControl("ltrPlanNight") as Literal;
            Literal ltrActualNight = e.Item.FindControl("ltrActualNight") as Literal;
            Literal ltrDiffNight = e.Item.FindControl("ltrDiffNight") as Literal;
            Literal ltrTotalNgNight = e.Item.FindControl("ltrTotalNgNight") as Literal;

            ltrBoardId.Text = product.BoardId;
            ltrLineCode.Text = product.LineCode;
            ltrLineName.Text = product.LineName;
            ltrPlanDay.Text = product.PlanDay.ToString("#,##0");
            ltrActualDay.Text = product.ActualDay.ToString("#,##0");
			
			if(product.TotalNgDay > 0){
				ltrTotalNgDay.Text = product.TotalNgDay.ToString("#,##0");
			}else{
				ltrTotalNgDay.Text = "";
			}
            
            ltrPlanNight.Text = product.PlanNight.ToString("#,##0");
            ltrActualNight.Text = product.ActualNight.ToString("#,##0");
            if(product.TotalNgNight > 0){
				ltrTotalNgNight.Text = product.TotalNgNight.ToString("#,##0");
			}else{
				ltrTotalNgNight.Text = "";
			}
			

            if (product.DiffDay < 0)
            {
                ltrDiffDay.Text = "<span style='color: red;'>" + product.DiffDay.ToString("#,##0") + "</span>";
            }
            else if (product.DiffDay > 0)
            {
                ltrDiffDay.Text = "<span style='color: green;'>" + product.DiffDay.ToString("#,##0") + "</span>";
            }
            else
            {
                ltrDiffDay.Text = "0";
            }

            if (product.DiffNight < 0)
            {
                ltrDiffNight.Text = "<span style='color: red;'>" + product.DiffNight.ToString("#,##0") + "</span>";
            }
            else if (product.DiffNight > 0)
            {
                ltrDiffNight.Text = "<span style='color: green;'>" + product.DiffNight.ToString("#,##0") + "</span>";
            }
            else
            {
                ltrDiffNight.Text = "0";
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        selectDate = DateTime.ParseExact(txtDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        DateTime startDateDay = new DateTime();
        DateTime endDateDay = new DateTime();
        DateTime startDateNight = new DateTime();
        DateTime endDateNight = new DateTime();

        startDateDay = Convert.ToDateTime(selectDate.ToString("yyyy-MM-dd") + " 08:00:00.000");
        endDateDay = Convert.ToDateTime(selectDate.ToString("yyyy-MM-dd") + " 19:59:59.000");
        startDateNight = Convert.ToDateTime(selectDate.ToString("yyyy-MM-dd") + " 20:00:00.000");
        endDateNight = Convert.ToDateTime(selectDate.AddDays(1).ToString("yyyy-MM-dd") + " 07:59:00.000");

        // Load DataTable of Fac 3 Line
        DataTable dtLine = new DataTable();
        SqlCommand sqlSelect = new SqlCommand();
        sqlSelect.CommandText = "SELECT Line.LineId, Line.LineCode, Line.LineName, board.BoardId FROM PD_LineMstr AS Line INNER JOIN BoardData AS board ON Line.BoardId = board.BoardId WHERE Line.Factory ='3' ORDER BY board.BoardId ASC";
        sqlSelect.CommandTimeout = 180;
        dtLine = conPDB.Query(sqlSelect);
        if (dtLine.Rows.Count > 0)
        {
            foreach (DataRow row in dtLine.Rows)
            {
                // Get BoardId
                string boardId = row["BoardId"].ToString();

                // Get ACTUAL
                AndonDataLog dataLogDay = GetActual(boardId, startDateDay, endDateDay);
                AndonDataLog dataLogNight = GetActual(boardId, startDateNight, endDateNight);

                PdLineProductInfo product = new PdLineProductInfo();
                product.BoardId = boardId;
                product.LineCode = row["LineCode"].ToString();
                product.LineName = row["LineName"].ToString();
                product.DataDate = startDateDay;
                // DAY
                product.ActualDay = dataLogDay.Actual;
                product.DiffDay = dataLogDay.Diff;
                product.PlanDay = dataLogDay.DailyPlan;
                
                // NIGHT
                product.ActualNight = dataLogNight.Actual;
                product.DiffNight = dataLogNight.Diff;
                product.PlanNight = dataLogNight.DailyPlan;

                if (boardId == "301")
                {
                    product.TotalNgDay = GetTotalMainAssyNg(startDateDay, endDateDay);
                    product.TotalNgNight = GetTotalMainAssyNg(startDateNight, endDateNight);
                }
                else
                {
                    product.TotalNgDay = 0;
                    product.TotalNgNight = 0;
                }

                products.Add(product);
            }
        }

        if (products.Count > 0)
        {
            rptData.DataSource = products;
            rptData.DataBind();
        }
        else
        {
            rptData.DataSource = null;
            rptData.DataBind();
        }
    
	
	
	}

    private AndonDataLog GetActual(string boardId, DateTime startDate, DateTime endDate)
    {
        AndonDataLog dataLog = new AndonDataLog();

        DataTable dtLine = new DataTable();
        SqlCommand sqlSelect = new SqlCommand();
        sqlSelect.CommandText = "SELECT TOP 1 BoardId, DailyPlan, Actual, Diff FROM DataLog WHERE BoardId = @BoardId AND Shift != '-' AND LogTime BETWEEN @StartDate AND @EndDate ORDER BY LogTime DESC";
        sqlSelect.CommandTimeout = 180;
        sqlSelect.Parameters.Add(new SqlParameter("@BoardId", boardId));
        sqlSelect.Parameters.Add(new SqlParameter("@StartDate", startDate));
        sqlSelect.Parameters.Add(new SqlParameter("@EndDate", endDate));
        dtLine = conPDB.Query(sqlSelect);
        if (dtLine.Rows.Count > 0)
        {
            dataLog.Actual = Convert.ToDecimal(dtLine.Rows[0]["Actual"].ToString());
            dataLog.BoardId = dtLine.Rows[0]["BoardId"].ToString();
            dataLog.DailyPlan = Convert.ToDecimal(dtLine.Rows[0]["DailyPlan"].ToString());
            dataLog.Diff = Convert.ToDecimal(dtLine.Rows[0]["Diff"].ToString());
        }

        return dataLog;
    }

    private decimal GetTotalMainAssyNg(DateTime starDate, DateTime endDate)
    {
        decimal totalNg = 0;

        // GET NG FROM IOT DATABASE
        DataTable dtSelect = new DataTable();
        SqlCommand sqlSelect = new SqlCommand();
        sqlSelect.CommandText = "GetNGSummaryAllMC_MainAssy";
        sqlSelect.CommandType = CommandType.StoredProcedure;
        sqlSelect.CommandTimeout = 180;
        sqlSelect.Parameters.Add(new SqlParameter("@DateStart", starDate));
        sqlSelect.Parameters.Add(new SqlParameter("@DateEnd", endDate));
        dtSelect = conIoT.Query(sqlSelect);
        if (dtSelect.Rows.Count > 0)
        {
            foreach (DataRow row in dtSelect.Rows)
            {
                decimal ng_count = Convert.ToDecimal(row["NGTotal"].ToString());
                totalNg += ng_count;
            }
        }

        return totalNg;
        
    }
}