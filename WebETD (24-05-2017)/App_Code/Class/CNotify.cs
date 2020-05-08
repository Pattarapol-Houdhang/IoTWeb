using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for CNotify
/// </summary>
public class CNotify
{
    public string GetNotifyAutoHide(string title, string text, CGeneral.NotifyType notifyType)
    {
        
        // now you have access to the current page...
        string type = "";
        switch (notifyType)
        {
            case CGeneral.NotifyType.Success:
                type = ",type: 'success'";
                break;
            case CGeneral.NotifyType.Error:
                type = ",type: 'error'";
                break;
            case CGeneral.NotifyType.Info:
                type = ",type: 'info'";
                break;
            case CGeneral.NotifyType.Dark:
                type = ",type: 'dark'";
                break;
            default:
                type = "";
                break;
        }

        string jquery = "$(document).ready(function() { new PNotify({title: '" + title + "',text: '" + text + "'" + type + ",styling: 'bootstrap3',delay:5000 }); }); ";

        return jquery;
    }

    public string GetNotify(string title, string text, CGeneral.NotifyType notifyType)
    {
        
        // now you have access to the current page...
        string type = "";
        switch (notifyType)
        {
            case CGeneral.NotifyType.Success:
                type = ",type: 'success'";
                break;
            case CGeneral.NotifyType.Error:
                type = ",type: 'error'";
                break;
            case CGeneral.NotifyType.Info:
                type = ",type: 'info'";
                break;
            case CGeneral.NotifyType.Dark:
                type = ",type: 'Dark'";
                break;
            default:
                type = "";
                break;
        }

        string jquery = "$(document).ready(function() { new PNotify({title: '" + title + "',text: '" + text + "'" + type + ",hide: false,styling: 'bootstrap3' }); }); ";

        return jquery;
    }

}