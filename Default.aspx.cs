using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void btnPrintAid_click(object sender, EventArgs e)
    //{
    //    // reset 

    //    ReportViewerAid.Reset();
    //    // DataSource
    //    DataTable dt =Print_Aid();
    //    ReportDataSource rds = new ReportDataSource("DataSet3", dt);
    //    ReportViewerAid.LocalReport.DataSources.Add(rds);
    //    // Path
    //    ReportViewerAid.LocalReport.ReportPath = "Pages/ReportAid.rdlc";

    //    // Parameters
    //    //ReportParameter[] rptParams = new ReportParameter[]
    //    //{
    //    //    new ReportParameter("Name",txtName.Text)
    //    //};
    //    //ReportViewerAid.LocalReport.SetParameters(rptParams);
    //    // Refresh
    //    ReportViewerAid.LocalReport.Refresh();
    //}

    //private DataAid  Print_Aid()
    //{
    //    try
    //    {
    //        string sSql = "select * from Aid ";
    //        //if (!string.IsNullOrEmpty(AidCode))
    //        //{
    //        //    sSql += " and Aid_Code=@Aid_Code";
    //        //}
    //        SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
    //        //if (!string.IsNullOrEmpty(AidCode))
    //        //{
    //        //    adapter.SelectCommand.Parameters.AddWithValue("Aid_Code", AidCode);
    //        //}
    //        return Core.DataBase.SqlHelper.FindRec(adapter).CopyToDataTable();
    //        //return Core.DataBase.SqlHelper.FindRec(adapter).CopyToDataTable();
    //    }
    //    catch (Exception x)
    //    {

    //        new ExceptionHandler(x);
    //        return null;
    //    }
    //}
}