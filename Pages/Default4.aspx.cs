using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class Pages_Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
protected void btnPrint_Click(object sender, EventArgs e)
    {
        // reset 

        reportviewerAid.Reset();
        // DataSource
        DataTable dt = GetDate();
        ReportDataSource rds = new ReportDataSource("DataSet3", dt);
        reportviewerAid.LocalReport.DataSources.Add(rds);
        // Path
        reportviewerAid.LocalReport.ReportPath = "Pages/Report.rdlc";

        // Parameters
        ReportParameter[] rptParams = new ReportParameter[]
        {
            new ReportParameter("@Beneficiary_No", DropDownName.SelectedValue),
              new ReportParameter("@Aid_Type", DropAidType.SelectedValue),
                new ReportParameter("@Aid_Date", txtlbldate.Text),
                  new ReportParameter("@Account_Type", DropDownAcount.SelectedValue),
                    new ReportParameter("@Pay_type", DropDownpayTaype.SelectedValue),
                    
        };
        reportviewerAid.LocalReport.SetParameters(rptParams);
        // Refresh
        reportviewerAid.LocalReport.Refresh();
    }

    private DataTable GetDate()
    {
        DataTable dt = new DataTable();
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BMPConnectionString"].ConnectionString;
        string Ssql = "select * vAid"
              + DropDownName.SelectedValue + "','" + DropAidType.SelectedValue + "','" +
               DateTime.ParseExact(txtlbldate.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy") + "'," + DropDownpayTaype.SelectedValue + "," +
              DropDownAcount.SelectedValue + ",'" + Session["UserName"].ToString() + "'," + "GetDate(),0)";



        using (SqlConnection cn=new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Beneficiary_No", DropDownName.SelectedValue);
            cmd.Parameters.AddWithValue("@Aid_Type", DropAidType.SelectedValue);
            //cmd.Parameters.AddWithValue("@Amount", txtvalue.Text);
            cmd.Parameters.AddWithValue("@Aid_Date", txtlbldate.Text);
            cmd.Parameters.AddWithValue("@Pay_type", DropDownpayTaype.SelectedValue);
            cmd.Parameters.AddWithValue("@Account_Type", DropDownAcount.SelectedValue);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

        }
        return dt;
    }
}