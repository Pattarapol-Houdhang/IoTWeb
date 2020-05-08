using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CEnergyInfo
/// </summary>
public class CTempOvenInfo
{
    ConnectDBIoT oConn = new ConnectDBIoT();
   // CPDData oPD = new CPDData();
    //CTargetInfo oTarget = new CTargetInfo();
    public CTempOvenInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetTempOven(string BoardID)
    {
      //  decimal KwhrUnit = 0;

        DataTable dtTempOvenAll = new DataTable();
        dtTempOvenAll.Columns.Add("Time", typeof(string));
        dtTempOvenAll.Columns.Add("IDCH", typeof(string));
        dtTempOvenAll.Columns.Add("Temp", typeof(decimal));

        DateTime strDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

      //  decimal avg = 0, kwhSUM = 0;
        int idx = 1;
       // string meterID = "''";

        DataTable dtTempOven = new DataTable();
      //  SqlCommand sqlTempOven = new SqlCommand();
        //---------------- Get Energy Line Main 301 from Costy ------------
        if (BoardID == "301")
        {

            /*     sqlTempOven.CommandText = "SELECT TOP 1 ((SELECT TOP 1 MAX(kWh) FROM [Scada_kWh] AS SUB1" +
                         " WHERE MONTH(StarmTime) = @month AND YEAR(StarmTime) = @year AND DAY(StarmTime) = @day AND MeterID IN('5')) -" +
                         " (SELECT TOP 1 MIN(kWh) FROM [Scada_kWh] AS SUB1" +
                         " WHERE MONTH(StarmTime) = @month2 AND YEAR(StarmTime) = @year2 AND DAY(StarmTime) = @day2 AND MeterID IN('5')))  AS Kwh" +
                         " FROM [Scada_kWh] WHERE MONTH(StarmTime) = @month3 AND YEAR(StarmTime) = @year3 AND DAY(StarmTime) = @day3 AND MeterID IN('5')";

                 sqlTempOven.Parameters.Add(new SqlParameter("@month", strDate.Month.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@month2", strDate.Month.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@month3", strDate.Month.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@year", strDate.Year.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@year2", strDate.Year.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@year3", strDate.Year.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@day", strDate.Day.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@day2", strDate.Day.ToString()));
                 sqlTempOven.Parameters.Add(new SqlParameter("@day3", strDate.Day.ToString()));*/

            for (int ii = 1; ii <= 2; ii++)
            {

                if (ii == 1)
                {
                    SqlCommand sqlTempOven1 = new SqlCommand();
                    sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '" + ii + "'" +
                  " and MONTH(TimeStamp) " +
              " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day  order by IDCH asc, Temp DESC,TimeStamp desc";

                    sqlTempOven1.Parameters.Add(new SqlParameter("@month", strDate.Month.ToString()));
                    sqlTempOven1.Parameters.Add(new SqlParameter("@year", strDate.Year.ToString()));
                    sqlTempOven1.Parameters.Add(new SqlParameter("@day", strDate.Day.ToString()));


                    dtTempOven = oConn.SqlGet(sqlTempOven1);

                }
                else
                {
                    SqlCommand sqlTempOven2 = new SqlCommand();
                    sqlTempOven2.CommandText = "Select  IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '" + ii + "'" +
   " and MONTH(TimeStamp) " +
" = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day  order by IDCH asc, TimeStamp DESC";

                    sqlTempOven2.Parameters.Add(new SqlParameter("@month", strDate.Month.ToString()));
                    sqlTempOven2.Parameters.Add(new SqlParameter("@year", strDate.Year.ToString()));
                    sqlTempOven2.Parameters.Add(new SqlParameter("@day", strDate.Day.ToString()));


                    dtTempOven = oConn.SqlGet(sqlTempOven2);

                }
              

            
                //---------------- Get TempOven Line Main 301 from Costy ------------

                if (dtTempOven.Rows.Count > 0)
                {
                    double Temp = 0;
                    Temp = Convert.ToDouble(dtTempOven.Rows[0]["Temp"].ToString()) / 10.0;

                    //   kwhSUM = kwh;
                    //   avg = 0;

                    DataRow _rowTempOven = dtTempOvenAll.NewRow();
                    _rowTempOven["Time"] = strDate.ToString("yyyy-MM-dd HH:mm:ss");
                    _rowTempOven["IDCH"] = Convert.ToInt16(dtTempOven.Rows[0]["IDCH"]);
                    _rowTempOven["Temp"] = Temp;
                    dtTempOvenAll.Rows.Add(_rowTempOven);
                    idx++;
                }
            }
        }
        return dtTempOvenAll;
    }

    public List<MTempOvenInfo> GetChartTempOven(int Month, string BoardID)
    {
        List<MTempOvenInfo> oListTempOven = new List<MTempOvenInfo>();

        DateTime strDate = new DateTime(DateTime.Now.Year, Month, 1, 0, 0, 0);
        DateTime endDate = strDate.AddMonths(1).Date + new TimeSpan(0, 0, 0);

        DateTime strHr = DateTime.Today + new TimeSpan(08, 00, 00);
        DateTime dateEnd = DateTime.Today + new TimeSpan(20, 00, 00);
        DateTime Endtoday = DateTime.Now;

        //  DataTable dtActual = oPD.GetDataActualOfMonth(BoardID, Month, DateTime.Now.Year);

        //for (DateTime i = strHr; i <= Endtoday; i = i.AddMinutes(15))
        //{
            // MTempOvenInfo oItemTempOven = new MTempOvenInfo();
            //   oItemTempOven.Date = i.ToString("dd");
            //  oItemTempOven.CostKwhTarget = Convert.ToDecimal(oTarget.GetTargetChart("Daily", "Energy Cost"));

           // DateTime dateEnd = i.Date + new TimeSpan(23, 59, 59);

            //   DataTable dtTempOven = new DataTable();
            //   SqlCommand sqlTempOven = new SqlCommand();
            DateTime Sqlstrdate = DateTime.Now;
          
       //     if (i == (DateTime.Today))
        //    {
                

             
                   // MTempOvenInfo oItemTempOven = new MTempOvenInfo();
                 //   oItemTempOven.Date = i.ToString("HH:mm:ss");
                    DataTable dtTempOven1 = new DataTable();
                    DataTable dtTempOven2 = new DataTable();
                    DataTable dtTempOven3 = new DataTable();
                    DataTable dtTempOven4 = new DataTable();
                    DataTable dtTempOven5 = new DataTable();
                    DataTable dtTempOven6 = new DataTable();
                    DataTable dtTempOven7 = new DataTable();
                    DataTable dtTempOven8 = new DataTable();
                    DataTable dtTempOven9 = new DataTable();
                    DataTable dtTempOven10 = new DataTable();
                    DataTable dtTempOven11 = new DataTable();
                    DataTable dtTempOven12 = new DataTable();


                    SqlCommand sqlTempOven1 = new SqlCommand();
                    SqlCommand sqlTempOven2 = new SqlCommand();
                    SqlCommand sqlTempOven3= new SqlCommand();
                    SqlCommand sqlTempOven4 = new SqlCommand();
                    SqlCommand sqlTempOven5 = new SqlCommand();
                    SqlCommand sqlTempOven6 = new SqlCommand();
                    SqlCommand sqlTempOven7 = new SqlCommand();
                    SqlCommand sqlTempOven8 = new SqlCommand();
                    SqlCommand sqlTempOven9 = new SqlCommand();
                    SqlCommand sqlTempOven10 = new SqlCommand();
                    SqlCommand sqlTempOven11 = new SqlCommand();
                    SqlCommand sqlTempOven12 = new SqlCommand();

             

               //CH1
                      //  sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '1'" +
                                  sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where " +
                             " MONTH(TimeStamp) " +
            " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day Order by TimeStamp asc";
                        sqlTempOven1.Parameters.Add(new SqlParameter("@month", strHr.Month.ToString()));
                        sqlTempOven1.Parameters.Add(new SqlParameter("@year", strHr.Year.ToString()));
                        sqlTempOven1.Parameters.Add(new SqlParameter("@day", strHr.Day.ToString()));

                        dtTempOven1 = oConn.SqlGet(sqlTempOven1);
                        if (dtTempOven1.Rows.Count > 0)
                        {


                            int IDCH = 0;
                          //  oItemTempOven.Temp1 = Convert.ToDouble(dtTempOven.Rows[0]["Temp"].ToString()) / 10.0;
                         //   dtTempOven1.Select("IDCH=1");
                            //foreach (DataRow row in dtTempOven1.Select("IDCH=1"))
                            //{ 
                        
                            foreach (DataRow row in dtTempOven1.Select("IDCH=1"))
                            {
                                MTempOvenInfo oItemTempOven = new MTempOvenInfo();
                              //  DateTime PP = Convert.ToDateTime(row["TimeStamp"]);
                              //  DateTime ii = i.AddMinutes(5);
                         //       if (ii ==  Convert.ToDateTime(row["TimeStamp"]))
                         //       {
                             
                             //  IDCH = Convert.ToInt16(row["IDCH"]);
                                  oItemTempOven.Date = Convert.ToDateTime(row["TimeStamp"].ToString()).ToString("dd-MMM HH:mm:ss");
                                
                                    oItemTempOven.Temp1 = Convert.ToDouble(row["Temp"].ToString()) / 10.0;
                               
                         //       }
                                
                                oListTempOven.Add(oItemTempOven);
                            }
                         //   foreach (DataRow row in dtTempOven1.Select("IDCH=2"))
                         //   {
                              //  MTempOvenInfo oItemTempOven = new MTempOvenInfo();
                                //  DateTime PP = Convert.ToDateTime(row["TimeStamp"]);
                                //  DateTime ii = i.AddMinutes(5);
                                //       if (ii ==  Convert.ToDateTime(row["TimeStamp"]))
                                //       {

                              //  IDCH = Convert.ToInt16(row["IDCH"]);
                         //       oItemTempOven.Date = Convert.ToDateTime(row["TimeStamp"].ToString()).ToString("dd-MMM HH:mm:ss");

                          //      oItemTempOven.Temp2 = Convert.ToDouble(row["Temp"].ToString()) / 10.0;

                                //       }

                          //      oListTempOven.Add(oItemTempOven);
                          //  }
                           
                           
                        }
        
              /*
                //CH2
                      sqlTempOven2.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '2'" +
                                          " and MONTH(TimeStamp) " +
                                " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by TimeStamp asc";
                                        sqlTempOven2.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven2.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven2.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                          dtTempOven2 = oConn.SqlGet(sqlTempOven2);
                        if (dtTempOven2.Rows.Count > 0)
                                {
                                         //   oItemTempOven.Temp2 = Convert.ToDouble(dtTempOven2.Rows[0]["Temp"].ToString()) / 10.0;
                             foreach (DataRow row2 in dtTempOven2.Rows)
                                            {
                                               MTempOvenInfo oItemTempOven = new MTempOvenInfo();
                                                oItemTempOven.Date = Convert.ToDateTime(row2["TimeStamp"].ToString()).ToString("dd-MMM HH:mm:ss");
                                                oItemTempOven.Temp2 = Convert.ToDouble(row2["Temp"].ToString()) / 10.0; 
                                                oListTempOven.Add(oItemTempOven);
                                            }

                                  }
                        
                    
                          //CH3
                                       sqlTempOven3.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '3'" +
                                          " and MONTH(TimeStamp) " +
                                " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                       sqlTempOven3.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                       sqlTempOven3.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                       sqlTempOven3.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven3 = oConn.SqlGet(sqlTempOven3);
                                        if (dtTempOven3.Rows.Count > 0)
                                        {
                                    //        oItemTempOven.Temp3 = Convert.ToDouble(dtTempOven3.Rows[0]["Temp"].ToString()) / 10.0;


                                            foreach (DataRow row3 in dtTempOven3.Rows)
                                            {
                                             oItemTempOven.Temp3 = Convert.ToDouble(row3["Temp"].ToString()) / 10.0; 
                                            }

                                  }
                                        

                                //CH4
                                        sqlTempOven4.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '4'" +
                                          " and MONTH(TimeStamp) " +
                                " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven4.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven4.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven4.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven4 = oConn.SqlGet(sqlTempOven4);
                                        if (dtTempOven4.Rows.Count > 0)
                                        {
                                           // oItemTempOven.Temp4 = Convert.ToDouble(dtTempOven4.Rows[0]["Temp"].ToString()) / 10.0;
    
                                         foreach (DataRow row4 in dtTempOven4.Rows)
                                            {
                                             oItemTempOven.Temp4 = Convert.ToDouble(row4["Temp"].ToString()) / 10.0; 
                                            }
                                        }


                                     //CH5
                                        sqlTempOven5.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '5'" +
                                           " and MONTH(TimeStamp) " +
                                 " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven5.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven5.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven5.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven5 = oConn.SqlGet(sqlTempOven5);
                                        if (dtTempOven5.Rows.Count > 0)
                                        {
                                           // oItemTempOven.Temp5 = Convert.ToDouble(dtTempOven5.Rows[0]["Temp"].ToString()) / 10.0;
                                            foreach (DataRow row5 in dtTempOven5.Rows)
                                            {
                                             oItemTempOven.Temp5 = Convert.ToDouble(row5["Temp"].ToString()) / 10.0; 
                                            }
                                        }

                                        //CH6
                                        sqlTempOven6.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '6'" +
                                          " and MONTH(TimeStamp) " +
                                " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven6.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven6.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven6.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven6 = oConn.SqlGet(sqlTempOven6);
                                        if (dtTempOven6.Rows.Count > 0)
                                        {
                                          //  oItemTempOven.Temp6 = Convert.ToDouble(dtTempOven6.Rows[0]["Temp"].ToString()) / 10.0;
                                           foreach (DataRow row6 in dtTempOven6.Rows)
                                            {
                                             oItemTempOven.Temp6 = Convert.ToDouble(row6["Temp"].ToString()) / 10.0; 
                                            }                                    
                                        }


 

                                        //CH7
                                        sqlTempOven7.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '7'" +
                                          " and MONTH(TimeStamp) " +
                                " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven7.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven7.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven7.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven7 = oConn.SqlGet(sqlTempOven7);
                                        if (dtTempOven7.Rows.Count > 0)
                                        {
                                            //oItemTempOven.Temp7 = Convert.ToDouble(dtTempOven7.Rows[0]["Temp"].ToString()) / 10.0;
                                            foreach (DataRow row7 in dtTempOven7.Rows)
                                            {
                                             oItemTempOven.Temp7 = Convert.ToDouble(row7["Temp"].ToString()) / 10.0; 
                                            }
                                        }


                                        //CH8
                                        sqlTempOven8.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '8'" +
                                           " and MONTH(TimeStamp) " +
                                 " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven8.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven8.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven8.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven8 = oConn.SqlGet(sqlTempOven8);
                                        if (dtTempOven8.Rows.Count > 0)
                                        {
                                          //  oItemTempOven.Temp8 = Convert.ToDouble(dtTempOven8.Rows[0]["Temp"].ToString()) / 10.0;
                                             foreach (DataRow row8 in dtTempOven8.Rows)
                                            {
                                             oItemTempOven.Temp8 = Convert.ToDouble(row8["Temp"].ToString()) / 10.0; 
                                            }
                                        }

                                        //CH9
                                        sqlTempOven9.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '9'" +
                                          " and MONTH(TimeStamp) " +
                                " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven9.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven9.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven9.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven9 = oConn.SqlGet(sqlTempOven9);
                                        if (dtTempOven9.Rows.Count > 0)
                                        {
                                           // oItemTempOven.Temp9 = Convert.ToDouble(dtTempOven9.Rows[0]["Temp"].ToString()) / 10.0;
                                        foreach (DataRow row9 in dtTempOven9.Rows)
                                            {
                                             oItemTempOven.Temp9 = Convert.ToDouble(row9["Temp"].ToString()) / 10.0; 
                                            }
                                        }


                                        //CH10
                                        sqlTempOven10.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '10'" +
                                           " and MONTH(TimeStamp) " +
                                 " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven10.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven10.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven10.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven10 = oConn.SqlGet(sqlTempOven10);
                                        if (dtTempOven10.Rows.Count > 0)
                                        {
                                          //  oItemTempOven.Temp10 = Convert.ToDouble(dtTempOven10.Rows[0]["Temp"].ToString()) / 10.0;
                                         foreach (DataRow row10 in dtTempOven10.Rows)
                                            {
                                             oItemTempOven.Temp10 = Convert.ToDouble(row10["Temp"].ToString()) / 10.0; 
                                            }
                                            }


                                        //CH11
                                        sqlTempOven11.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '11'" +
                                          " and MONTH(TimeStamp) " +
                                " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven11.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven11.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven11.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven11 = oConn.SqlGet(sqlTempOven11);
                                        if (dtTempOven11.Rows.Count > 0)
                                        {
                                           // oItemTempOven.Temp11 = Convert.ToDouble(dtTempOven11.Rows[0]["Temp"].ToString()) / 10.0;
                                          foreach (DataRow row11 in dtTempOven11.Rows)
                                            {
                                             oItemTempOven.Temp11 = Convert.ToDouble(row11["Temp"].ToString()) / 10.0; 
                                            }

                                        }


                                        //CH12
                                        sqlTempOven12.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where IDCH = '12'" +
                                           " and MONTH(TimeStamp) " +
                                 " = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";
                                        sqlTempOven12.Parameters.Add(new SqlParameter("@month", Sqlstrdate.Month.ToString()));
                                        sqlTempOven12.Parameters.Add(new SqlParameter("@year", Sqlstrdate.Year.ToString()));
                                        sqlTempOven12.Parameters.Add(new SqlParameter("@day", Sqlstrdate.Day.ToString()));

                                        dtTempOven12 = oConn.SqlGet(sqlTempOven12);
                                        if (dtTempOven12.Rows.Count > 0)
                                        {
                                          //  oItemTempOven.Temp12 = Convert.ToDouble(dtTempOven12.Rows[0]["Temp"].ToString()) / 10.0;
                                          foreach (DataRow row12 in dtTempOven12.Rows)
                                            {
                                             oItemTempOven.Temp12 = Convert.ToDouble(row12["Temp"].ToString()) / 10.0; 
                                            }
                                        }*/
                           
                    
           
              
         //   }
       
       // }
        return oListTempOven;
    }
   
    public List<MTempOvenInfo> GetChartTempOvenCH(int Month, string BoardID)
    {
        List<MTempOvenInfo> oListTempOven = new List<MTempOvenInfo>();
     
        DateTime strDate = new DateTime(DateTime.Now.Year, Month, 1, 0, 0, 0);
        DateTime endDate = strDate.AddMonths(1).Date + new TimeSpan(0, 0, 0);
      
            DateTime strHr = DateTime.Today+ new TimeSpan(08, 00, 00);
            DateTime dateEnd = DateTime.Today + new TimeSpan(23, 59, 59);
        

        for (DateTime i = strHr;dateEnd.CompareTo(i) > 0; i = i.AddDays(1))
        {


            DataTable dtTempOven1 = new DataTable();
            SqlCommand sqlTempOven1 = new SqlCommand();

            DateTime ChDate = strDate;
   //         if (strHr <= dateEnd)
   //         {
                MTempOvenInfo oItemTempOven = new MTempOvenInfo();
                oItemTempOven.Date = i.ToString("HH:mm:ss");

                sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where "
                       + "TimeStamp >= '" + strHr + "' and TimeStamp <= '" + dateEnd + "'  order by TimeStamp asc ";


//                sqlTempOven1.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where " +
//      " MONTH(TimeStamp) " +
//" = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day Order by TimeStamp asc";
//                sqlTempOven1.Parameters.Add(new SqlParameter("@month", strHr.Month.ToString()));
//                sqlTempOven1.Parameters.Add(new SqlParameter("@year", strHr.Year.ToString()));
//                sqlTempOven1.Parameters.Add(new SqlParameter("@day", strHr.Day.ToString()));

                dtTempOven1 = oConn.SqlGet(sqlTempOven1);

               // dtTempOven = oConn.SqlGet(sqlTempOven);

            int IDCH=0;

                for (int ii = 1; ii <= 701; ii++)//---------- Loop for 1 Min - 701 Min Is 8:20 - 20:00 ------------
                {
                  
                    //oItemTempOven.Date = i.ToString("HH:mm:ss");
                    if (dtTempOven1.Rows.Count > 0)
                    {
                       // MTempOvenInfo oItemTempOven1 = new MTempOvenInfo();
                        //MTempOvenInfo oItemTempOven1 = new MTempOvenInfo();
                        //oItemTempOven.Date = i.ToString("HH:mm:ss");
                    //    IDCH = Convert.ToInt16(dtTempOven1.Rows[ii]["IDCH"].ToString());
                        foreach (DataRow row1 in dtTempOven1.Select("IDCH=1"))
                        {
                            MTempOvenInfo oItemTempOven1 = new MTempOvenInfo();
                            oItemTempOven1.Temp1 = Convert.ToDouble(row1["Temp"].ToString()) / 10.0;
                            oListTempOven.Add(oItemTempOven1);
                       
                        }
                        foreach (DataRow row2 in dtTempOven1.Select("IDCH=2"))
                        {
                            MTempOvenInfo oItemTempOven2 = new MTempOvenInfo();
                            oItemTempOven2.Temp2 = Convert.ToDouble(row2["Temp"].ToString()) / 10.0;
                            oListTempOven.Add(oItemTempOven2);
                       
                        }

                       //oListTempOven.Add(oItemTempOven1);
                       
                    }
                    
                }
     //      }
           
       }
        return oListTempOven;
    }

    public List<MTempOvenMonth> GetChartTempOvenMonth(int Month, int Year, string BoardID)
    {
        string[] monthName = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
        List<MTempOvenMonth> olistTempOvenMonth = new List<MTempOvenMonth>();

        DateTime strDate = new DateTime(DateTime.Now.Year, Month, 1, 0, 0, 0);
        DateTime endDate = strDate.AddMonths(1).Date + new TimeSpan(0, 0, 0);

        for (int i = 1; i <= 12; i++)
        {
           // int Actual = oPD.GetActualMainFac3ofMonth(i, Year);

            MTempOvenMonth oitemTempOven = new MTempOvenMonth();
            oitemTempOven.Month = monthName[i - 1];
          //  oitemTempOven.TargetElec = Convert.ToDecimal(oTarget.GetTargetChart("Monthly", "Energy Cost"));

            DateTime strMonth = new DateTime(Year, i, 1) + new TimeSpan(0, 0, 0);
            DateTime endMonth = new DateTime(Year, i, DateTime.DaysInMonth(Year, i)) + new TimeSpan(23, 59, 59);

            SqlCommand sqlMonth = new SqlCommand();
            DataTable dtTempOvenMonth = new DataTable();
            //---------------- Get Energy Line Main 301 from Costy ------------
           // if (BoardID == "301")
          //  {
          /*      sqlMonth.CommandText = "SELECT TOP 1 ((SELECT TOP 1 MAX(kWh) FROM [Scada_kWh] AS SUB1" +
                    " WHERE MONTH(StarmTime) = @month AND YEAR(StarmTime) = @year AND MeterID IN('5')) -" +
                    " (SELECT TOP 1 MIN(kWh) FROM [Scada_kWh] AS SUB1" +
                    " WHERE MONTH(StarmTime) = @month2 AND YEAR(StarmTime) = @year2 AND MeterID IN('5')))  AS Kwh" +
                    " FROM [Scada_kWh] WHERE MONTH(StarmTime) = @month3 AND YEAR(StarmTime) = @year3 AND MeterID IN('5')";

                sqlMonth.Parameters.Add(new SqlParameter("@month", strMonth.Month.ToString()));
                sqlMonth.Parameters.Add(new SqlParameter("@month2", strMonth.Month.ToString()));
                sqlMonth.Parameters.Add(new SqlParameter("@month3", strMonth.Month.ToString()));
                sqlMonth.Parameters.Add(new SqlParameter("@year", strMonth.Year.ToString()));
                sqlMonth.Parameters.Add(new SqlParameter("@year2", strMonth.Year.ToString()));
                sqlMonth.Parameters.Add(new SqlParameter("@year3", strMonth.Year.ToString()));*/

                sqlMonth.CommandText = "Select IDCH,Temp,TimeStamp from  [FN_TempOven] where MONTH(TimeStamp) " +
" = @month AND YEAR(TimeStamp) = @year AND DAY(TimeStamp) = @day order by IDCH asc, TimeStamp DESC";

                sqlMonth.Parameters.Add(new SqlParameter("@month", strDate.Month.ToString()));
                sqlMonth.Parameters.Add(new SqlParameter("@year", strDate.Year.ToString()));
                sqlMonth.Parameters.Add(new SqlParameter("@day", strDate.Day.ToString()));

   

                sqlMonth.CommandTimeout = 600;
                dtTempOvenMonth = oConn.SqlGet(sqlMonth);
          //  }
            //---------------- Get Energy Line Main 301 from Costy ------------

            if (dtTempOvenMonth.Rows.Count > 0)
            {

                oitemTempOven.TempValue = Convert.ToDouble(dtTempOvenMonth.Rows[0]["Temp"].ToString()) / 10.0;
                if (Year == DateTime.Now.Year && i > DateTime.Now.Month)
                {
                   // oitemTempOven.CostEnergy = null;
                }
                else
                {
                    decimal costEnergyMonth = 0;
                    try
                    {
                    
                        costEnergyMonth = Convert.ToDecimal(dtTempOvenMonth.Rows[0]["Temp"].ToString()) * 2;
                   //     oitemTempOven.CostEnergy = Math.Round(costEnergyMonth, 2);
                   //     oitemTempOven.CostEnergyUnit = Math.Round(((Convert.ToDecimal(dtTempOvenMonth.Rows[0]["Temp"].ToString()) * 2) ), 2);
                    }
                    catch { }
                }
            }

            olistTempOvenMonth.Add(oitemTempOven);
        }

        return olistTempOvenMonth;
    }
}