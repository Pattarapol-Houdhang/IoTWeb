using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DefaultVer2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    public string GetBudgetMenu()
    {
        string result = "";

        try
        {
            if (Session["UserName"].ToString() != "")
            {
                MDUserLoginData UserData = new MDUserLoginData();
                UserData = (MDUserLoginData)Session["UserLoginData"];
                bool _Permission = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
                {
                    if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11)
                    {
                        _Permission = true;
                    }
                }

                if (_Permission)
                {
                    result += "<div class='col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator CO Hover' data-navi='http://192.168.226.19/linecost/Default2.aspx?Line=com'>";
                    result += "    <img src='StyleMax/icon/Cost.png' class='imgicon' /><div class='count textMonitor'>Line Cost Control</div>";
                    result += "</div>";


                    result += "<div class='col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator CO Hover' data-navi='http://192.168.226.19/iotweb/Cost/CostDIExpSummary.aspx'>";
                    result += "    <img src='StyleMax/icon/Cost.png' class='imgicon' /><div class='count textMonitor'>Budget Cost</div>";
                    result += "</div>";

                    //divQCSampling.Visible = true;

                }
            }
        }
        catch (Exception ex) { }

        result += "<div class='col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator CO Hover' data-navi='http://192.168.226.19/linecost/Default2_CTSP.aspx?Line=mc'>";
        result += "    <img src='StyleMax/icon/fund.png' class='imgicon' /><div class='count textMonitor'>Cutting Tools Cost</div>";
        result += "</div>";

        return result;
    }

    public string GetLinkQCSampling()
    {
        string result = "";

        try
        {
            if (Session["UserName"].ToString() != "")
            {
                MDUserLoginData UserData = new MDUserLoginData();
                UserData = (MDUserLoginData)Session["UserLoginData"];
                bool _Permission = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
                {
                    if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11 || UsrGroup.GroupID == 1 || UsrGroup.GroupID == 2)
                    {
                        _Permission = true;
                    }
                }

                if (_Permission)
                {
                    result += " <div class='col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator QC Hover' data-navi='Quality/QCSamplingMenu.aspx'>";
                    result += " <img src='StyleMax/icon/trend.png' class='imgicon' /><div class='count textMonitor'>QC Graph Monitor</div>";
                    result += " </div>";


                    //divQCSampling.Visible = true;

                }
            }
        }
        catch (Exception ex) { }


        return result;
    }

    public string GetSSUControlMenu()
    {
        string result = "";

        try
        {
            if (Session["UserName"].ToString() != "")
            {
                MDUserLoginData UserData = new MDUserLoginData();
                UserData = (MDUserLoginData)Session["UserLoginData"];
                bool _Permission = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
                {
                    if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11)
                    {
                        _Permission = true;
                    }
                }

                if (_Permission)
                {
                    //divSSUControlMenu.Visible = true;
                    result += "<div class='col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator EG Hover' data-navi='http://192.168.226.19/iotweb/EnergyLink.aspx?type=SSUControl'>";
                    result += "   <img src = 'StyleMax/icon/Gear-0.5s-200px.gif' class=imgicon width='70' /><div class='count textMonitor'>SSU Control</div>";
                    result += "</div>";
                }
            }
        }
        catch (Exception ex) { }

        return result;
    }


    public string GetManPowerMenu()
    {
        string result = "";

        try
        {
            if (Session["UserName"].ToString() != "")
            {
                MDUserLoginData UserData = new MDUserLoginData();
                UserData = (MDUserLoginData)Session["UserLoginData"];
                bool _Permission = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
                {
                    if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11)
                    {
                        _Permission = true;
                    }
                }

                if (_Permission)
                {
                    result += "<div class='col-lg-5 col-md-5 col-sm-12 col-xs-12 lnkNavigator MP Hover' data-navi='http://192.168.226.19/iotweb/ManPower/DCIManPower.aspx'>";
                    result += "    <img src='StyleMax/icon/bars.png' class='imgicon' width='64px' height='64px' /><div class='count textMonitor'>Summarize</div>";
                    result += "</div>";
                }
            }
        }
        catch (Exception ex) { }

        return result;
    }



    protected void menuElectrical_Click(object sender, ImageClickEventArgs e)
    {
        string ip = "172.31.149.21";

        MemoryStream ms = new MemoryStream();
        TextWriter tw = new StreamWriter(ms);
        tw.WriteLine("[connection]");
        tw.WriteLine("host=" + ip);
        tw.WriteLine("port=5900");
        tw.WriteLine("[options]");
        tw.WriteLine("use_encoding_1=1");
        tw.WriteLine("copyrect=1");
        tw.WriteLine("viewonly=1");
        tw.WriteLine("fullscreen=0");
        tw.WriteLine("8bit=0");
        tw.WriteLine("shared=1");
        tw.WriteLine("belldeiconify=0");
        tw.WriteLine("disableclipboard=0");
        tw.WriteLine("swapmouse=0");
        tw.WriteLine("fitwindow=0");
        tw.WriteLine("cursorshape=1");
        tw.WriteLine("noremotecursor=0");
        tw.WriteLine("preferred_encoding=7");
        tw.WriteLine("compresslevel=-1");
        tw.WriteLine("quality=9");
        tw.WriteLine("localcursor=1");
        tw.WriteLine("scale_den=1");
        tw.WriteLine("scale_num=1");
        tw.WriteLine("local_cursor_shape=1");
        tw.Flush();
        byte[] bytes = ms.ToArray();
        ms.Close();

        Response.Clear();
        Response.ContentType = "text/plain";
        Response.AddHeader("content-disposition", "attachment;    filename=" + "IoT_Electrical.vnc");
        Response.BinaryWrite(bytes);
        Response.End();
    }

    protected void menuWater_Click(object sender, ImageClickEventArgs e)
    {
        string ip = "172.31.149.136";

        MemoryStream ms = new MemoryStream();
        TextWriter tw = new StreamWriter(ms);
        tw.WriteLine("[connection]");
        tw.WriteLine("host=" + ip);
        tw.WriteLine("port=5900");
        tw.WriteLine("[options]");
        tw.WriteLine("use_encoding_1=1");
        tw.WriteLine("copyrect=1");
        tw.WriteLine("viewonly=1");
        tw.WriteLine("fullscreen=0");
        tw.WriteLine("8bit=0");
        tw.WriteLine("shared=1");
        tw.WriteLine("belldeiconify=0");
        tw.WriteLine("disableclipboard=0");
        tw.WriteLine("swapmouse=0");
        tw.WriteLine("fitwindow=0");
        tw.WriteLine("cursorshape=1");
        tw.WriteLine("noremotecursor=0");
        tw.WriteLine("preferred_encoding=7");
        tw.WriteLine("compresslevel=-1");
        tw.WriteLine("quality=9");
        tw.WriteLine("localcursor=1");
        tw.WriteLine("scale_den=1");
        tw.WriteLine("scale_num=1");
        tw.WriteLine("local_cursor_shape=1");
        tw.Flush();
        byte[] bytes = ms.ToArray();
        ms.Close();

        Response.Clear();
        Response.ContentType = "text/plain";
        Response.AddHeader("content-disposition", "attachment;    filename=" + "IoT_Water.vnc");
        Response.BinaryWrite(bytes);
        Response.End();
    }

    protected void menuAirCom_Click(object sender, ImageClickEventArgs e)
    {
        string ip = "172.31.149.203";

        MemoryStream ms = new MemoryStream();
        TextWriter tw = new StreamWriter(ms);
        tw.WriteLine("[connection]");
        tw.WriteLine("host=" + ip);
        tw.WriteLine("port=5900");
        tw.WriteLine("[options]");
        tw.WriteLine("use_encoding_1=1");
        tw.WriteLine("copyrect=1");
        tw.WriteLine("viewonly=1");
        tw.WriteLine("fullscreen=0");
        tw.WriteLine("8bit=0");
        tw.WriteLine("shared=1");
        tw.WriteLine("belldeiconify=0");
        tw.WriteLine("disableclipboard=0");
        tw.WriteLine("swapmouse=0");
        tw.WriteLine("fitwindow=0");
        tw.WriteLine("cursorshape=1");
        tw.WriteLine("noremotecursor=0");
        tw.WriteLine("preferred_encoding=7");
        tw.WriteLine("compresslevel=-1");
        tw.WriteLine("quality=9");
        tw.WriteLine("localcursor=1");
        tw.WriteLine("scale_den=1");
        tw.WriteLine("scale_num=1");
        tw.WriteLine("local_cursor_shape=1");
        tw.Flush();
        byte[] bytes = ms.ToArray();
        ms.Close();

        Response.Clear();
        Response.ContentType = "text/plain";
        Response.AddHeader("content-disposition", "attachment;    filename=" + "IoT_AirCom.vnc");
        Response.BinaryWrite(bytes);
        Response.End();
    }

    protected void menuSSUControl_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (Session["UserName"].ToString() != "")
            {
                MDUserLoginData UserData = new MDUserLoginData();
                UserData = (MDUserLoginData)Session["UserLoginData"];
                bool _Permission = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
                {
                    if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11)
                    {
                        _Permission = true;
                    }
                }

                if (_Permission)
                {
                    string ip = "192.168.229.24";

                    MemoryStream ms = new MemoryStream();
                    TextWriter tw = new StreamWriter(ms);
                    tw.WriteLine("[connection]");
                    tw.WriteLine("host=" + ip);
                    tw.WriteLine("port=5900");
                    tw.WriteLine("[options]");
                    tw.WriteLine("use_encoding_1=1");
                    tw.WriteLine("copyrect=1");
                    tw.WriteLine("viewonly=1");
                    tw.WriteLine("fullscreen=0");
                    tw.WriteLine("8bit=0");
                    tw.WriteLine("shared=1");
                    tw.WriteLine("belldeiconify=0");
                    tw.WriteLine("disableclipboard=0");
                    tw.WriteLine("swapmouse=0");
                    tw.WriteLine("fitwindow=0");
                    tw.WriteLine("cursorshape=1");
                    tw.WriteLine("noremotecursor=0");
                    tw.WriteLine("preferred_encoding=7");
                    tw.WriteLine("compresslevel=-1");
                    tw.WriteLine("quality=High");
                    tw.WriteLine("localcursor=1");
                    tw.WriteLine("scale_den=1");
                    tw.WriteLine("scale_num=1");
                    tw.WriteLine("local_cursor_shape=1");
                    tw.Flush();
                    byte[] bytes = ms.ToArray();
                    ms.Close();

                    Response.Clear();
                    Response.ContentType = "text/plain";
                    Response.AddHeader("content-disposition", "attachment;    filename=" + "IoT_SSUControl.vnc");
                    Response.BinaryWrite(bytes);
                    Response.End();

                }
                else
                {
                    // Alert Message
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Alert('You don't have permission for this menu. Please Login.')", true);
                }
            }
        }
        catch (Exception ex) { }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserName"].ToString() != "")
            {
                MDUserLoginData UserData = new MDUserLoginData();
                UserData = (MDUserLoginData)Session["UserLoginData"];
                bool _Permission = false;

                foreach (MDUserLoginData.CMDUserLoginData.CGroup UsrGroup in UserData.ListOfUser[0].ListOfGroup)
                {
                    if (UsrGroup.GroupID == 10 || UsrGroup.GroupID == 11)
                    {
                        _Permission = true;
                    }
                }

                if (_Permission)
                {
                    string ip = "192.168.229.24";

                    MemoryStream ms = new MemoryStream();
                    TextWriter tw = new StreamWriter(ms);
                    tw.WriteLine("[connection]");
                    tw.WriteLine("host=" + ip);
                    tw.WriteLine("port=5900");
                    tw.WriteLine("[options]");
                    tw.WriteLine("use_encoding_1=1");
                    tw.WriteLine("copyrect=1");
                    tw.WriteLine("viewonly=1");
                    tw.WriteLine("fullscreen=0");
                    tw.WriteLine("8bit=0");
                    tw.WriteLine("shared=1");
                    tw.WriteLine("belldeiconify=0");
                    tw.WriteLine("disableclipboard=0");
                    tw.WriteLine("swapmouse=0");
                    tw.WriteLine("fitwindow=0");
                    tw.WriteLine("cursorshape=1");
                    tw.WriteLine("noremotecursor=0");
                    tw.WriteLine("preferred_encoding=7");
                    tw.WriteLine("compresslevel=-1");
                    tw.WriteLine("quality=High");
                    tw.WriteLine("localcursor=1");
                    tw.WriteLine("scale_den=1");
                    tw.WriteLine("scale_num=1");
                    tw.WriteLine("local_cursor_shape=1");
                    tw.Flush();
                    byte[] bytes = ms.ToArray();
                    ms.Close();

                    Response.Clear();
                    Response.ContentType = "text/plain";
                    Response.AddHeader("content-disposition", "attachment;    filename=" + "IoT_SSUControl.vnc");
                    Response.BinaryWrite(bytes);
                    Response.End();

                }
                else
                {
                    // Alert Message
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Alert('You don't have permission for this menu. Please Login.')", true);
                }
            }
        }
        catch (Exception ex) { }
    }
}