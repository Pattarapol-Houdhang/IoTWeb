using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cost_CostDIExpSummary : System.Web.UI.Page
{
    ConnectDBBCS oConnBCS = new ConnectDBBCS();
    ConnectDBDCIMax oConnDCI = new ConnectDBDCIMax();
    IFormatProvider culture = CultureInfo.CreateSpecificCulture("en-US");
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    
        try
        {
            bool isPermission = false;
            MDUserLoginData UserData = new MDUserLoginData();
            UserData = (MDUserLoginData)Session["UserLoginData"];
            foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
            {
                if (UsrGroup.GroupID == 12)
                {
                    isPermission = true;
                }
            }

            if (!isPermission) {
                Response.Redirect(ResolveClientUrl("~/Cost/CostDIExpSummary.aspx"));
            }
        }
        catch {
            Response.Redirect(ResolveClientUrl("~/Cost/CostDIExpSummary.aspx"));
        }
    }
    
    


}