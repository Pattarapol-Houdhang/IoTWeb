using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GVSorting
/// </summary>
public class GVSorting
{
    string srtDirection = "";
    string srtExpression = "";
	public GVSorting()
	{
         srtDirection = "ASC";
         srtExpression = "";
		//
		// TODO: Add constructor logic here
		//
	}
    public void SetSorting(string inExpression)
    {
        if ((inExpression.Trim() != srtExpression))
        {
            // If not old expression
            srtExpression = inExpression.Trim();
            srtDirection = "ASC";
        }
        else if ((srtDirection == "ASC"))
        {
            srtDirection = "DESC";
        }
        else
        {
            srtDirection = "ASC";
        }
    }
    public string GetSorting()
    {
        if ((srtExpression == ""))
        {
            return "";
        }
        else
        {
            return (srtExpression + (" " + srtDirection));
        }
    }
}