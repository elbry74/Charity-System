using Microsoft.Reporting.WebForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Pages_ReportAid2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillBeneficiar();
            fillDate();
        }
    }

    private void fillBeneficiar()
    {
        string fill = "select * from VBeneficiary";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        ddBeneficiar.DataSource = result.CopyToDataTable();
        ddBeneficiar.DataTextField = "Name";
        ddBeneficiar.DataValueField = "Beneficiary_No";
        ddBeneficiar.DataBind();
        ddBeneficiar.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDate()
    {
        DateTime date_n = DateTime.Now;

        txt_Stertdate.Text = date_n.Year + "-01-01";
        txt_Enddate.Text = date_n.ToString("yyyy-MM-dd");
    }

    protected void Btn_Print_Click(object sender, EventArgs e)
    {
        try
        {
            string Beneficiary, StertDate, EndDate, name = "";

            if (ddBeneficiar.SelectedValue == "-1")
            {
                Alerts.alertWarning(Page, "تنبيه", "أختر اسم المستفيد");
                return;
            }
            else
            {
                Beneficiary = ddBeneficiar.SelectedValue;
                name = ddBeneficiar.SelectedItem.Text;
            }

            if (txt_Stertdate.Text == "")
            {
                StertDate = "Aid_Date";
            }
            else
            {
                StertDate = "'" + txt_Stertdate.Text + "'";
            }
            if (txt_Enddate.Text == "")
            {
                EndDate = "Aid_Date";
            }
            else
            {
                EndDate = "'" + txt_Enddate.Text + "'";
            }

            DataTable dt = new DataTable();

            string sSql = " SELECT * FROM  VAid where Beneficiary_No =" + Beneficiary + " and  Aid_Date >= " + StertDate + " and  Aid_Date <=" + EndDate + "  and Delete_Flag_Code=0  order by Aid_no";
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);

            var result = Core.DataBase.SqlHelper.FindRec(adapter);

            if (result.Count <= 0)
            {
                Alerts.alertWarning(Page, "تنبيه", "لا توجد بيانات");
                return;
            }
            dt = result.CopyToDataTable();
            ReportParameter[] rptParams = new ReportParameter[]
           {
               new ReportParameter("pr_name",name),
               new ReportParameter("pr_form_date",txt_Stertdate.Text),
               new ReportParameter("pr_to_date",txt_Enddate.Text),
               new ReportParameter("userid", Session["UserName"].ToString())
           };

            // GlobalFunction.LoadRDLC(Page, Server.MapPath("~/Reports/Aid_report_kashf.rdlc"), dt, rptParams);

            try
            {
                GlobalFunction.GenerateTestFile("كشف حساب", Server.MapPath("~/Reports/Aid_report_kashf.rdlc"), dt, rptParams);
            }
            catch
            {
            }
        }
        catch (Exception x)
        {
            Alerts.alertError(Page, "", "");
        }
    }
}