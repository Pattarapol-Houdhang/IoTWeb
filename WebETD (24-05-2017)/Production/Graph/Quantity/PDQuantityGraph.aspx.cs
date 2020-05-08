using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Production_Graph_Quantity_PDQuantityGraph : System.Web.UI.Page
{
    CGenGraph oGenGraph = new CGenGraph();
    CGenControl oGenControl = new CGenControl();
    CFactory oFactory = new CFactory();
    CLineData oLineData = new CLineData();
    CMachine oMachine = new CMachine();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["FactoryID"] != "")
        {
            ViewState["FactoryID"] = Request.QueryString["FactoryID"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/Production/Graph/Quantity/PDQuantityGraphFactory.aspx"));
        }

        if (Request.QueryString["ld_id"] != "")
        {
            ViewState["ld_id"] = Request.QueryString["ld_id"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/Production/Graph/Quantity/PDQuantityGraphLine.aspx?FactoryID=" + ViewState["FactoryID"].ToString()));
        }

        if (Request.QueryString["mc_code"] != "")
        {
            ViewState["mc_code"] = Request.QueryString["mc_code"];
        }
        else
        {
            Response.Redirect(ResolveClientUrl("~/Production/Graph/Quantity/PDQuantityGraphMachine.aspx?FactoryID=" + ViewState["FactoryID"].ToString() + "&ld_id=" + ViewState["ld_id"].ToString()));
        }

        if (!IsPostBack)
        {
            InitialControl();
            txtDateStart.Text = DateTime.Now.ToString();
            txtDateEnd.Text = DateTime.Now.ToString();
        }
    }

    private void InitialControl()
    {
        oGenControl.GenDDLModel(CGeneral.TypeSelect.Please, ddlModel);

        MDFactory oMDFactory = new MDFactory();
        MDLineData oMDLineData = new MDLineData();
        MDMachine oMDMachine = new MDMachine();

        oMDFactory = oFactory.GetFactoryByFactoryID(ViewState["FactoryID"].ToString());
        oMDLineData = oLineData.GetLineDataByLineID(Convert.ToInt32(ViewState["ld_id"]));
        oMDMachine = oMachine.GetMachineBymc_code(ViewState["mc_code"].ToString());

        if(oMDFactory.ListOfFactory.Count > 0)
        {
            lbFactory.Text = oMDFactory.ListOfFactory[0].FactoryName;
        }
        if(oMDLineData.ListOfLine.Count > 0)
        {
            lbPDLine.Text = oMDLineData.ListOfLine[0].ld_linename;
        }
        if(oMDMachine.ListOfmachine.Count > 0)
        {
            lbMachine.Text = oMDMachine.ListOfmachine[0].mc_code + " " + oMDMachine.ListOfmachine[0].mc_name;
        }
    }

    public string LoadGraph()
    {
        string result = "";
        MDGenGraph oMDGenGraph = new MDGenGraph();
        oMDGenGraph = oGenGraph.GenGraph(ViewState["mc_code"].ToString(), ddlModel.SelectedValue, txtDateStart.Text.Trim(), txtDateEnd.Text.Trim());
        if (oMDGenGraph.ListOfData.Count > 0)
        {
            string Title = "";//ddlLine.SelectedItem.Text + " : " + ddlMachine.SelectedItem.Text;
            Title = lbPDLine.Text + " : " + lbMachine.Text;
            string SubTitle = "Model: " + ddlModel.SelectedItem.Text + " : From " + oMDGenGraph.ListOfData[0].DataDateStart + " To " + oMDGenGraph.ListOfData[0].DataDateEnd;
            
            result += @"				<script>" + Environment.NewLine;
            result += @"                    Highcharts.chart('container', {" + Environment.NewLine;
            result += @"                        chart: {" + Environment.NewLine;
            result += @"                            type: 'column'" + Environment.NewLine;
            result += @"                        }," + Environment.NewLine;
            result += @"                        title: {" + Environment.NewLine;
            result += @"                            text: '" + Title + "'" + Environment.NewLine;
            result += @"                        }," + Environment.NewLine;
            result += @"                        subtitle: {" + Environment.NewLine;
            result += @"                            text: '" + SubTitle + "'" + Environment.NewLine;
            result += @"                        }," + Environment.NewLine;
            result += @"                        xAxis: {" + Environment.NewLine;
            result += @"                            categories: [" + Environment.NewLine;

            for (int i = 0; i < oMDGenGraph.ListOfData.Count; i++)
            {
                if (i == oMDGenGraph.ListOfData.Count)
                {
                    result += @"                                '" + Convert.ToDateTime(oMDGenGraph.ListOfData[i].Date).ToString("dd MMM yyyy") + "'" + Environment.NewLine;
                }
                else
                {
                    result += @"                                '" + Convert.ToDateTime(oMDGenGraph.ListOfData[i].Date).ToString("dd MMM yyyy") + "'," + Environment.NewLine;
                }
            }

            result += @"                            ]," + Environment.NewLine;
            result += @"                            crosshair: true" + Environment.NewLine;
            result += @"                        }," + Environment.NewLine;
            result += @"                        yAxis: {" + Environment.NewLine;
            result += @"                            min: 0," + Environment.NewLine;
            result += @"                            title: {" + Environment.NewLine;
            result += @"                                text: 'Quantity (PCS)'" + Environment.NewLine;
            result += @"                            }" + Environment.NewLine;
            result += @"                        }," + Environment.NewLine;
            result += @"                        tooltip: {" + Environment.NewLine;
            result += @"                            headerFormat: '<span style=""font-size:10px/"">{point.key}</span><table>'," + Environment.NewLine;
            result += @"                            pointFormat: '<tr><td style=""color: {series.color}; padding: 0"">{series.name}: </td>' +" + Environment.NewLine;
            result += @"                            '<td style=""padding: 0""><b>{point.y}</b></td></tr>'," + Environment.NewLine;
            result += @"                            footerFormat: '</table>'," + Environment.NewLine;
            result += @"                            shared: true," + Environment.NewLine;
            result += @"                            useHTML: true" + Environment.NewLine;
            result += @"                        }," + Environment.NewLine;
            result += @"                        plotOptions: {" + Environment.NewLine;
            result += @"                            column: {" + Environment.NewLine;
            result += @"                                pointPadding: 0.2," + Environment.NewLine;
            result += @"                                borderWidth: 0" + Environment.NewLine;
            result += @"                            }," + Environment.NewLine;
            result += @"                            series: {" + Environment.NewLine;
            result += @"                                borderWidth: 0," + Environment.NewLine;
            result += @"                                dataLabels: {" + Environment.NewLine;
            result += @"                                enabled: true," + Environment.NewLine;
            result += @"                                format: '{point.y}'" + Environment.NewLine;
            result += @"                            }" + Environment.NewLine;
            result += @"                          }" + Environment.NewLine;
            result += @"                        }," + Environment.NewLine;


            result += @"                        series: [{" + Environment.NewLine;
            result += @"                            name: 'OK'," + Environment.NewLine;

            result += @"                            data: [" + Environment.NewLine;
            for (int i = 0; i < oMDGenGraph.ListOfData.Count; i++)
            {
                if (i == oMDGenGraph.ListOfData.Count)
                {
                    result += @"                                " + oMDGenGraph.ListOfData[i].QtyOK + "";
                }
                else
                {
                    result += @"                            " + oMDGenGraph.ListOfData[i].QtyOK + "," + Environment.NewLine;
                }
            }

            result += @"                            ]" + Environment.NewLine;



            result += @"                        }, {" + Environment.NewLine;
            result += @"                            name: 'NG'," + Environment.NewLine;



            result += @"                            data: [" + Environment.NewLine;
            for (int i = 0; i < oMDGenGraph.ListOfData.Count; i++)
            {
                if (i == oMDGenGraph.ListOfData.Count)
                {
                    result += @"                                " + oMDGenGraph.ListOfData[i].QtyNG + "";
                }
                else
                {
                    result += @"                            " + oMDGenGraph.ListOfData[i].QtyNG + "," + Environment.NewLine;
                }
            }

            result += @"                            ]" + Environment.NewLine;




            result += @"                        }]" + Environment.NewLine;
            result += @"                    });" + Environment.NewLine;
            result += @"                </script>" + Environment.NewLine;
        }
        else
        {
            result += @"<div><h4>No Data!</h4></div>" + Environment.NewLine;
        }


        return result;
    }

    protected void btBackPreviousPage_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveClientUrl("~/Production/Graph/Quantity/PDQuantityGraphMachine.aspx?FactoryID=" + ViewState["FactoryID"].ToString() + "&ld_id=" + ViewState["ld_id"].ToString()));
    }

    protected void btSearch_Click(object sender, EventArgs e)
    {
        LoadGraph();
    }
}