﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Quality_PDLineOutChartAll : System.Web.UI.Page
{
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    
    

}