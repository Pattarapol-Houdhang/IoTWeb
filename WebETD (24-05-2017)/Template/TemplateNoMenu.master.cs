using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template_TemplateNoMenu : System.Web.UI.MasterPage
{
    string LinkManPower = "";
    string BoardId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         //   BoardId = Request.QueryString["BoardID"] != null ? Request.QueryString["BoardID"].ToString() : "";
            BoardId = "301";
           LinkManPower = "default2.aspx?BoardID=" + BoardId;
        }
    }

    public string LinkMP()
    {
        return LinkManPower;
    }
}
