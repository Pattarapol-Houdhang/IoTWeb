<%@ WebHandler Language="C#" Class="ExportExcelProductivity" %>

using System;
using System.Web;
using System.Text;

public class ExportExcelProductivity : IHttpHandler
{
    CProductivity oPro = new CProductivity();
    string _Month;
    string _Year;
    string Name = "";

    public void ProcessRequest(HttpContext context)
    {
        _Month = context.Request.QueryString["Month"].ToString();
        _Year = context.Request.QueryString["Year"].ToString();
        MDProcductivity oMDPro = new MDProcductivity();

        oMDPro = oPro.GetProductivityByMonth(Convert.ToInt16(_Month), Convert.ToInt16(_Year));
        Name = "DataProductivity_" + GetMonth() + "_" + DateTime.Now.Year.ToString()
            + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;

        context.Response.ContentType = "text/plain";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + Name + ".csv;");


        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Line,Process," + GetMonth() + "");

        int days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        string result = ",";
        for (int day = 1; day <= days; day++)
        {
            result += "," + day + ",";
        }
        //sb.AppendLine(",,1,,2,,");
        sb.AppendLine(result);

        result = ",";
        for (int day = 1; day <= days; day++)
        {
            result += ",D,N";
        }
        sb.AppendLine(result);

        if (oMDPro.ListOfProductivity.Count > 0)
        {
            for (int i = 0; i < oMDPro.ListOfProductivity.Count; i++)
            {

                result = oMDPro.ListOfProductivity[i].LineName + ",Plan";
                for (int day = 1; day <= days; day++)
                {
                    result += "," + oMDPro.ListOfProductivity[i].ListOfQty[day - 1].PlanD + "," + oMDPro.ListOfProductivity[i].ListOfQty[day - 1].PlanN;
                }
                sb.AppendLine(result);

                result = ",Start";
                for (int day = 1; day <= days; day++)
                {
                    result += "," + oMDPro.ListOfProductivity[i].ListOfQty[day - 1].StartD + "," + oMDPro.ListOfProductivity[i].ListOfQty[day - 1].StartN;
                }
                sb.AppendLine(result);
                result = ",Last";
                for (int day = 1; day <= days; day++)
                {
                    result += "," + oMDPro.ListOfProductivity[i].ListOfQty[day - 1].LastD + "," + oMDPro.ListOfProductivity[i].ListOfQty[day - 1].LastN;
                }


                sb.AppendLine(result);
            }

        }




        //context.Response.Write(sb.ToString());

        //the most easy way as you have type it
        context.Response.Write(sb.ToString());
        context.Response.Flush();
        context.Response.End();






    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    private string GetMonth()
    {
        switch (Convert.ToInt16(_Month))
        {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
            default:
                return "";
        }
    }

}