using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EnergyLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["type"] != null)
        {
            ViewState["type"] = Request.QueryString["type"];

            if (Request.QueryString["type"] == "Electrical")
            {
                Electrical();
            }
            else if (Request.QueryString["type"] == "Water")
            {
                Water();
            }
            else if (Request.QueryString["type"] == "AirCompressor")
            {
                AirCompressor();
            }
            else if (Request.QueryString["type"] == "SSUControl")
            {
                SSUControl();
            }
        }
    }


    private void Electrical()
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

    private void Water()
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

    private void AirCompressor()
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

    private void SSUControl()
    {
        try
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
            tw.WriteLine("viewonly=0");
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
        catch (Exception ex) { }
    }

}