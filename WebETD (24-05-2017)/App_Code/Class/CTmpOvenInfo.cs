using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;


public class CTmpOvenInfo
{
    string[] montharr = { "January", "Fabuary", "March", "April", "May", "June", "July", "Auguest", "September", "October", "November", "December" };

   // private CManpowerInfo oMP = new CManpowerInfo();
    private ConnectDBIoT oConn = new ConnectDBIoT();

    string txtCostCenter = "";






    public CTmpOvenInfo()
    {

    }


    //public DataTable GetMP(string CostCenter)
    //{


    //    DataTable dtMPAll = new DataTable();
    //    dtMPAll.Columns.Add("Time", typeof(string));
    //    dtMPAll.Columns.Add("IDCH", typeof(string));
    //    dtMPAll.Columns.Add("Temp", typeof(decimal));

    //    DateTime strDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

    //    int idx = 1;

    //    DataTable dtManPower = new DataTable();

    //    return dtMPAll;
    //}

    public List<MTmpOvenInfo.MTmpAllChartInfo> GetChartTempOvenScratter(int _Month, DateTime _DataDate, string _Type)
    {

        List<MTmpOvenInfo.MTmpAllChartInfo> oListTempOven = new List<MTmpOvenInfo.MTmpAllChartInfo>();

        DateTime strDate = new DateTime(DateTime.Now.Year, _Month, 1, 0, 0, 0);
        DateTime endDate = strDate.AddMonths(1).Date + new TimeSpan(0, 0, 0);

        DateTime strHr = DateTime.Today + new TimeSpan(08, 00, 00);
        DateTime dateEnd = DateTime.Today + new TimeSpan(20, 00, 00);
        DateTime Endtoday = DateTime.Now;
        string Channel = "";

        //for (DateTime i = strHr; i <= dateEnd; i = i.AddMinutes(30))
        //{
        //    MTmpOvenInfo.MTmpAllChartInfo oItemTempOven1 = new MTmpOvenInfo.MTmpAllChartInfo();
        //    oItemTempOven1.Date = i.ToString("HH:mm:ss");

        if (_Type != "")
        {

            if (_Type == "CH1")
            {
                Channel = "1";

            }
            else if (_Type == "CH2")
            {

                Channel = "2";
            }
            else if (_Type == "CH3")
            {
                Channel = "3";

            }
            else if (_Type == "CH4")
            {
                Channel = "4";

            }
            else if (_Type == "CH5")
            {
                Channel = "5";

            }
            else if (_Type == "CH6")
            {
                Channel = "6";

            }
            else if (_Type == "CH7")
            {
                Channel = "7";

            }
            else if (_Type == "CH8")
            {
                Channel = "8";

            }
            else if (_Type == "CH9")
            {
                Channel = "9";

            }
            else if (_Type == "CH10")
            {
                Channel = "10";

            }
            else if (_Type == "CH11")
            {
                Channel = "11";

            }
            else if (_Type == "CH12")
            {
                Channel = "12";

            }
            // CH1 DataGet
            DataTable dtTempOven1 = new DataTable();
            SqlCommand sqlTempOven1 = new SqlCommand();


            //CH1
            //sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '1'"
            sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '" + Channel + "'"
                     + " and TimeStamp >= '" + strHr + "' and TimeStamp <= '" + Endtoday + "'  order by TimeStamp asc ";
            sqlTempOven1.Parameters.Add(new SqlParameter("@day", strHr.Day.ToString()));
            dtTempOven1 = oConn.SqlGet(sqlTempOven1);



            //for (DateTime i = strHr; i <= Endtoday; i = i.AddMinutes(15))
            //{



            foreach (DataRow row in dtTempOven1.Rows)
            {

                MTmpOvenInfo.MTmpAllChartInfo oItemTempOven1 = new MTmpOvenInfo.MTmpAllChartInfo();
                oItemTempOven1.Date = Convert.ToDateTime(row["TimeStamp"].ToString()).ToString("HH:mm:ss");

                // oItemTempOven1.IDCH = Convert.ToDouble(Channel.ToString());
                oItemTempOven1.CH = Convert.ToDouble(row["Temp"].ToString()) / 10.0;


                oListTempOven.Add(oItemTempOven1);
                // oListTempOven.Add(oItemTempOven);

            }
            // oItemTempOven.Date = i.ToString("HH:mm:ss");
            //}

            /*
                       // CH2 DataGet
                       DataTable dtTempOven2 = new DataTable();
                       SqlCommand sqlTempOven2 = new SqlCommand();

                         // CH2
                          sqlTempOven2.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '2'"
                                       + " and TimeStamp >= '" + strHr + "' and TimeStamp <= '" + dateEnd + "'  order by TimeStamp asc ";
                          sqlTempOven2.Parameters.Add(new SqlParameter("@day", strHr.Day.ToString()));
                          dtTempOven2 = oConn.SqlGet(sqlTempOven2);


                    

                          foreach (DataRow row in dtTempOven2.Rows)
                          {

                              MTmpOvenInfo.MTmpAllChartInfo oItemTempOven2 = new MTmpOvenInfo.MTmpAllChartInfo();
                             // oItemTempOven2.Date = Convert.ToDateTime(row["TimeStamp"].ToString()).ToString("HH:mm:ss");
                              oItemTempOven2.CH2 = Convert.ToDouble(row["Temp"].ToString()) / 10.0;

                              oListTempOven.Add(oItemTempOven2);

                          }*/
            //  oListTempOven.Add(oItemTempOven);
            //}
        }

        return oListTempOven;
    }

    public List<MTmpOvenInfo.MTmpAllChartInfo> GetChartTempOven(int _Month, DateTime _DataSDate,DateTime _DataEDate, string _Type)
    {

        List<MTmpOvenInfo.MTmpAllChartInfo> oListTempOven = new List<MTmpOvenInfo.MTmpAllChartInfo>();

        DateTime strDate = new DateTime(DateTime.Now.Year, _Month, 1, 0, 0, 0);
        DateTime endDate = strDate.AddMonths(1).Date + new TimeSpan(0, 0, 0);

        DateTime strHr = _DataSDate + new TimeSpan(08, 00, 00);
        //DateTime strHr = DateTime.Today + new TimeSpan(08, 00, 00);
        DateTime dateEnd = DateTime.Today + new TimeSpan(20, 00, 00);
        DateTime Endtoday = _DataEDate.AddDays(1) + new TimeSpan(08, 00, 00);
        //DateTime Endtoday = DateTime.Now;
        string Channel = "";

        //for (DateTime i = strHr; i <= dateEnd; i = i.AddMinutes(15))
        //{
        //    MTmpOvenInfo.MTmpAllChartInfo oItemTempOven1 = new MTmpOvenInfo.MTmpAllChartInfo();
        //    oItemTempOven1.Date = i.ToString("HH:mm:ss");
        string IDCHSql ="";

        if (_Type != "")
        {

            if (_Type == "ALL")
            {
                Channel = "All";
                IDCHSql = " IDCH = '" + Channel + "'";
            }
            else
            {
                Channel = _Type.Substring(2);
                IDCHSql = " IDCH = '" + Channel + "'";
            }
            
           
            // CH1 DataGet
            DataTable dtTempOven1 = new DataTable();
            SqlCommand sqlTempOven1 = new SqlCommand();


            //CH1
            //sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '1'"
            sqlTempOven1.CommandText = "Select TOP 1000 IDCH,Temp,TimeStamp from  [FN_TempOven] where " + IDCHSql 
                     + " and TimeStamp >= '" + strHr + "' and TimeStamp <= '" + Endtoday + "'  order by TimeStamp ";
         //   sqlTempOven1.Parameters.Add(new SqlParameter("@day", strHr.Day.ToString()));
            dtTempOven1 = oConn.SqlGet(sqlTempOven1);



            //for (DateTime i = strHr; i <= Endtoday; i = i.AddMinutes(15))
            //{
            //int kk = 0;
            //for (kk = 0; kk <= dtTempOven1.Rows.Count;kk++)
            //{


            //}


            //MTmpOvenInfo.MTmpAllChartInfo oItemTempOven = new MTmpOvenInfo.MTmpAllChartInfo();
            //oItemTempOven.Date = i.ToString("HH:mm:ss");
            // string Period = i.ToString("HH:m:ss");


            foreach (DataRow row in dtTempOven1.Rows)
            {


                MTmpOvenInfo.MTmpAllChartInfo oItemTempOven1 = new MTmpOvenInfo.MTmpAllChartInfo();
                oItemTempOven1.Date = Convert.ToDateTime(row["TimeStamp"].ToString()).ToString("dd-MMM HH:mm:ss");

                // oItemTempOven1.IDCH = Convert.ToDouble(Channel.ToString());
                oItemTempOven1.CH = Convert.ToDouble(row["Temp"].ToString()) / 10.0;
                oItemTempOven1.STPoint = 130;
                oItemTempOven1.Max = 150;
                oItemTempOven1.Min= 130;

                oListTempOven.Add(oItemTempOven1);
                // oListTempOven.Add(oItemTempOven);

            }


            // oItemTempOven.Date = i.ToString("HH:mm:ss");
            //}

            /*
                       // CH2 DataGet
                       DataTable dtTempOven2 = new DataTable();
                       SqlCommand sqlTempOven2 = new SqlCommand();

                         // CH2
                          sqlTempOven2.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '2'"
                                       + " and TimeStamp >= '" + strHr + "' and TimeStamp <= '" + dateEnd + "'  order by TimeStamp asc ";
                          sqlTempOven2.Parameters.Add(new SqlParameter("@day", strHr.Day.ToString()));
                          dtTempOven2 = oConn.SqlGet(sqlTempOven2);


                    

                          foreach (DataRow row in dtTempOven2.Rows)
                          {

                             // MTmpOvenInfo.MTmpAllChartInfo oItemTempOven2 = new MTmpOvenInfo.MTmpAllChartInfo();
                             // oItemTempOven2.Date = Convert.ToDateTime(row["TimeStamp"].ToString()).ToString("dd HH:mm:ss");
                              oItemTempOven1.CH2 = Convert.ToDouble(row["Temp"].ToString()) / 10.0;

                              oListTempOven.Add(oItemTempOven1);

                          }*/
            //  oListTempOven.Add(oItemTempOven);
            //}
        }

        return oListTempOven;
    }




}





//public List<MMPMonth> GetChartMPMonth(int Month, int Year, string CostCenter)
//{
//    string[] monthName = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
//    List<MMPMonth> olistMPMonth = new List<MMPMonth>();

//    DateTime strDate = new DateTime(DateTime.Now.Year, Month, 1, 0, 0, 0);
//    DateTime endDate = strDate.AddMonths(1).Date + new TimeSpan(0, 0, 0);



//    return olistMPMonth;
//}
