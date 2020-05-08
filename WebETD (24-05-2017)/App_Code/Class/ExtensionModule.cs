using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Threading;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ExtensionModule
/// </summary>
namespace ExtensionModule
{
    // fgstockweb
    public static class isExtensionModule
    {
        public static string ToStringFormatDatetime(this DateTime inDate)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            //string DateToDB;
            //DateToDB = Convert.ToString(inDate);

            return inDate.ToString("MM/DD/yyyy");
        }

        public static void TodisPlayNone(this Panel inPanel)
        {
            inPanel.Attributes.Add("style", "display:none");
        }

        public static double ToDatetimeForJSON(this DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return ts.TotalMilliseconds;
        }

        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }
    }
}