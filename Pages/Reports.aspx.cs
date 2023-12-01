using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class Pages_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        DataTable dt = Print_Aid_type((txtName.Text));
        ReportParameter[] rptParams = new ReportParameter[]
        {
            new ReportParameter("Name",txtName.Text)
        };
        GlobalFunction.LoadRDLC(Page, "Reports/Report.rdlc", dt, rptParams);
    }

    private DataTable Print_Aid_type(string AidCode)
    {
        try
        {
            string sSql = "select * from Aid_Types where 1=1 ";
            if (!string.IsNullOrEmpty(AidCode))
            {
                sSql += " and Aid_Code=@Aid_Code";
            }
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
            if (!string.IsNullOrEmpty(AidCode))
            {
                adapter.SelectCommand.Parameters.AddWithValue("Aid_Code", AidCode);
            }
           
            return Core.DataBase.SqlHelper.FindRec(adapter).CopyToDataTable();
        }
        catch (Exception x)
        {

            new ExceptionHandler(x);
            return null;
        }
    }

    protected void BtnAid_Click(object sender, EventArgs e)
    {
         // Select From Database 
        DataTable dt = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter("select * from vAid", Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adapter);
        dt = result.CopyToDataTable();
        ReportParameter[] rptParams = new ReportParameter[]
       {
           // new ReportParameter("Name",txtName.Text)
       };
        GlobalFunction.LoadRDLC(Page, "Reports/ReportAid2.rdlc", dt, rptParams);
    }
}