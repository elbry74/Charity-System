using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ReportViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ReportPath"] == null && Session["ReportDataTable"] == null)
            {
                Response.Redirect("/Ben2.aspx");
            }

            string reportPath = Session["ReportPath"].ToString();
            DataTable dt = (DataTable)Session["ReportDataTable"];

            // reset

            ReportViewer1.Reset();
            // DataSource

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            // Path
            ReportViewer1.LocalReport.ReportPath = reportPath;

            // Parameters
            if (Session["ReportParameters"] != null)
            {
                try
                {
                    ReportParameter[] rptparams = (ReportParameter[])Session["ReportParameters"];
                    ReportViewer1.LocalReport.SetParameters(rptparams);
                }
                catch { }
            }

            // Refresh
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ShowZoomControl = true;
            ReportViewer1.ShowFindControls = true;
            ReportViewer1.SizeToReportContent = true;
            ReportViewer1.LocalReport.Refresh();
        }
    }
}