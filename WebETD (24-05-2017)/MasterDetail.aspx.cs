using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterDetail : System.Web.UI.Page
{
    private string bufId;
    private string _OffsetID;
    private string _ModelID;
    private string _PartID;
    private string _PartTypeID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            if ((bufId = Request.QueryString["id"]) != null)
            {
                //lblStatus.Text = "(EDIT)";
                Session["editState"] = true;

                var bufSplit = bufId.Split(',');

                if (bufSplit != null)
                {
                    _OffsetID = bufSplit[0];
                    _ModelID = bufSplit[1];
                    _PartID = bufSplit[2];
                    _PartTypeID = bufSplit[3];
                }

                if (_PartID == "1")//crank shaft
                {
                    if(_PartTypeID == "1")//OD
                    {
                        Response.Redirect("OffsetCSOD.aspx?id=" + bufId);
                    }
                    else if(_PartTypeID == "4")//pin od
                    {
                        Response.Redirect("OffsetCSPIN.aspx?id=" + bufId);
                    }
                    else if(_PartTypeID == "12")//eccentricity
                    {
                        Response.Redirect("OffsetCSECC.aspx?id=" + bufId);
                    }
                    else
                    { 
                        //error
                    }
                }
                else if (_PartID == "2" || _PartID == "7")//piston up or piston low
                {
                    if (_PartTypeID == "1")//OD
                    {
                        Response.Redirect("OffsetPTOD.aspx?id=" + bufId);
                    }
                    else if (_PartTypeID == "5")//ID
                    {
                        Response.Redirect("OffsetPTID.aspx?id=" + bufId);
                    }
                    else if (_PartTypeID == "10")//height
                    {
                        Response.Redirect("OffsetPTHEI.aspx?id=" + bufId);
                    }
                    else if (_PartTypeID == "15")//blade
                    {
                        Response.Redirect("OffsetPTBL.aspx?id=" + bufId);
                    }
                    else
                    {
                        //error
                    }
                }
                else if (_PartID == "3" || _PartID == "8")//cylinder up or cylinder low
                {
                    if(_PartTypeID == "8")//ID bore
                    {
                        Response.Redirect("OffsetCYBO.aspx?id=" + bufId);
                    }
                    else if(_PartTypeID == "9")//ID bush
                    {
                        Response.Redirect("OffsetCYBU.aspx?id=" + bufId);
                    }
                    else if (_PartTypeID == "10")//height
                    {
                        Response.Redirect("OffsetCYHEI.aspx?id=" + bufId);
                    }
                    else 
                    {
                        //error
                    }
                }
                else if (_PartID == "4")//front head
                {
                    if (_PartTypeID == "5")//ID
                    {
                        Response.Redirect("OffsetFH.aspx?id=" + bufId);
                    }
                    else
                    {
                        //error
                    }
                }
                else if (_PartID == "5")//rear head
                {
                    if (_PartTypeID == "5")//ID
                    {
                        Response.Redirect("OffsetRH.aspx?id=" + bufId);
                    }
                    else
                    {
                        //error
                    }
                }
                else if (_PartID == "6" || _PartID == "9")//swing bush up or swing bush low
                {
                    if (_PartTypeID == "13")//TH
                    {
                        Response.Redirect("OffsetSB.aspx?id=" + bufId);
                    }
                    else
                    {
                        //error
                    }
                }
                else
                {
                    //error
                }
            }
            else
            {
                //lblStatus.Text = "(NEW)";
                Session["editState"] = false;
            }
        }
    }
}