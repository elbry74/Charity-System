using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class Pages_ReportAid2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillDrop_f2a();
        }
    }

    private void fillDrop_f2a()
    {
        string fill = "select * from VBen_Cat ";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        Drop_f2a.DataSource = result.CopyToDataTable();
        Drop_f2a.DataTextField = "Category_Desc";
        Drop_f2a.DataValueField = "Category_ID";
        Drop_f2a.DataBind();
        Drop_f2a.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDrop_ben_type(int Category_ID)
    {
        Drop_ben_type.Enabled = true;
        string fill = "select  Type_ID,Type_Desc  from Beneficiary_Types  where Category_ID= " + Category_ID;
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        Drop_ben_type.DataSource = result.CopyToDataTable();
        Drop_ben_type.DataTextField = "Type_Desc";
        Drop_ben_type.DataValueField = "Type_ID";
        Drop_ben_type.DataBind();
        Drop_ben_type.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    protected void Btn_Print_Click(object sender, EventArgs e)
    {
        try
        {
            string type, Category_ID = "";

            string mo7ddat = "";

            string sSql;

            if (Drop_ben_type.Items.Count != 0)
            {
                if (Drop_ben_type.SelectedValue == "-1")
                {
                    type = "type";
                }
                else
                {
                    type = Drop_ben_type.SelectedValue;
                    mo7ddat += " (نوع المستفيد : " + Drop_ben_type.SelectedItem.Text + ")";
                }
            }
            else
            {
                type = "type";
            }

            if (Drop_f2a.SelectedValue == "-1")
            {
                Category_ID = "Category_ID";
            }
            else
            {
                Category_ID = Drop_f2a.SelectedValue;
                mo7ddat += " (فئة المستفيد : " + Drop_f2a.SelectedItem.Text + ")";
            }

            sSql = "SELECT * FROM VBeneficiary where  Category_ID=" + Category_ID + " and type =" + type;

            if (mo7ddat == "")
            {
                mo7ddat = " (جميع السجلات) ";
            }
            DataTable dt = new DataTable();

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
               new ReportParameter("userid", Session["UserName"].ToString()),
               new ReportParameter("mo7ddat",mo7ddat)
             };
            //GlobalFunction.LoadRDLC(Page, Server.MapPath("~/Reports/Report_Ben.rdlc"), dt, rptParams);
            try
            {
                GlobalFunction.GenerateTestFile("تقرير المستفيدين", Server.MapPath("~/Reports/Report_Ben.rdlc"), dt, rptParams);
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

    protected void Drop_f2a_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Drop_f2a.SelectedValue != "-1")
            {
                int xx = Convert.ToInt32(Drop_f2a.SelectedValue);
                fillDrop_ben_type(xx);
            }
            else
            {
                Drop_ben_type.Enabled = false;
                Drop_ben_type.Items.Clear();
            }
        }
        catch (Exception x)
        {
            Alerts.alertError(Page, "", "");
        }
    }
}