using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Core.DataBase;

public partial class Report_Pages_Report_Page_Aid : System.Web.UI.Page
{
    // public DataTable fill_datatable(string stringsql)
    //{
    //    conn = cc.getconect();
    //    DataTable dt = new DataTable();
    //    OracleDataReader dr;
    //     comm = new OracleCommand(stringsql, conn);
    //     try
    //     {
    //         comm.Connection = conn;
    //         conn.Open();
    //         dr = comm.ExecuteReader();
    //         dt.Load(dr);
    //         conn.Close();
    //         return dt;

    //     }
    //     finally
    //     {
    //         conn.Close();
    //     }
    //}

    protected void Page_init(object sender, EventArgs e)
    {
        //try
        //{
        //    int AidType = Convert.ToInt16(Session["AidType"]);
        //    int payTaype = Convert.ToInt32(Session["payTaype"]);
        //    int Acount = Convert.ToInt32(Session["Acount"]);
        //    string StertDate = Session["StertDate"].ToString();
        //    string EndDate = Session["EndDate"].ToString();
        //    ReportDocument crystalReport = new ReportDocument();

        //    string reportCacheKey =
        //  Server.MapPath("~/Report/Aid.rpt");
        //    if (Cache[reportCacheKey] != null)
        //    {
        //        crystalReport = (ReportDocument)Cache[reportCacheKey];
        //    }
        //    else
        //    {
        //        Cache.Insert(reportCacheKey, crystalReport);
        //    }

        //    string xx = Server.MapPath("~/Report/Aid.rpt");
        //    crystalReport.Load(Server.MapPath("~/Report/Aid.rpt"));

        //    //crystalReport.SetDatabaseLogon(conclass.User, conclass.Pass);
        //    DataTable dsCustomers;

        //    string fill = "SELECT * FROM  VAid where Aid_Type=" + AidType + " and Pay_type=" + payTaype + " and Account_Type=" + Acount + " and  Delete_Flag = 0 and Aid_Date between '" + StertDate + "' and '" + EndDate + "'  ";
        //    SqlConnection conn = new SqlConnection();
        //    DataTable dt = new DataTable();
        //    SqlDataReader dr;
        //    conn.ConnectionString = @"Data Source=.;Initial Catalog=Charity;Integrated Security=True";
        //    SqlCommand commeand = new SqlCommand();
        //    commeand.Connection = conn;
        //    commeand.CommandText = fill;

        //    //SqlDataAdapter adapt = new SqlDataAdapter(commeand);
        //    //adapt.Fill(dt);
        //    conn.Open();
        //    dr = commeand.ExecuteReader();
        //    dt.Load(dr);
        //    conn.Close();
        //    int x = dt.Rows.Count;

        //    //string fill = "SELECT * FROM  VAid where Aid_Type=@AidType and Pay_type=@payTaype and Account_Type=@Acount and  Delete_Flag = 0 and Aid_Date between @StertDate and @EndDate  ";
        //    //SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        //    //SqlCommand cmd = new SqlCommand(fill, Core.DataBase.ConnectionManager.BMP);
        //    //cmd.Parameters.AddWithValue("@AidType", AidType);
        //    //cmd.Parameters.AddWithValue("@payTaype", payTaype);
        //    //cmd.Parameters.AddWithValue("@Acount", Acount);
        //    //cmd.Parameters.AddWithValue("@StertDate", StertDate);
        //    //cmd.Parameters.AddWithValue("@EndDate", EndDate);
        //    // var result = Core.DataBase.SqlHelper.FindRec(adaptaer);

        //    //dsCustomers = ec.SELECT_atm_acq_is_rep(from_date, to_date, done_status, rep_type);
        //    //int x = dsCustomers.Rows.Count;
        //    crystalReport.SetDataSource(dt);
        //    crystalReport.SetDatabaseLogon("sa", "sa");
        //    CrystalReportViewer1.ReportSource = crystalReport;
        //    //crystalReport.SetParameterValue("user_name", full_name);
        //    //crystalReport.SetParameterValue("report_header", report_header);
        //    //crystalReport.SetParameterValue("from_date", from_date);
        //    //crystalReport.SetParameterValue("to_date", to_date);
        //    CrystalReportViewer1.DataBind();
        //}
        //catch (Exception x)
        //{
        //    throw;
        //}

        Session["AidType"] = Session["payTaype"] = Session["Acount"] = Session["StertDate"] = Session["EndDate"] = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}