using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class Pages_task1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Drop_bentype();
            Drop_currtype();
            Drop_acctype();
        }
    }

    private void Drop_bentype()
    {
        string fill = "select * from Aid_Types ";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropList_ben_type.DataSource = result.CopyToDataTable();
        DropList_ben_type.DataValueField = "Aid_Code";
        DropList_ben_type.DataTextField = "Aid_Desc";
        DropList_ben_type.DataBind();
        DropList_ben_type.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void Drop_currtype()
    {
        string fill = "SELECT * FROM Pay_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropList_cur_type.DataSource = result.CopyToDataTable();
        DropList_cur_type.DataTextField = "Pay_Desc";
        DropList_cur_type.DataValueField = "Pay_Type";
        DropList_cur_type.DataBind();
        DropList_cur_type.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void Drop_acctype()
    {
        string fill = "select * from Account_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropList_acc_type.DataSource = result.CopyToDataTable();
        DropList_acc_type.DataTextField = "Account_Desc";
        DropList_acc_type.DataValueField = "Account_Type";
        DropList_acc_type.DataBind();
        DropList_acc_type.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    protected void Btn_Show_Click(object sender, EventArgs e)
    {
        try
        {
            string DropList_ben_value, DropList_cur_value, DropList_acc_value = "";

            string sSql = "select * from VTask where 1=1 ";

            if (DropList_ben_type.SelectedIndex != 0)
            {
                DropList_ben_value = DropList_ben_type.SelectedValue;
                sSql += "and Aid_Type= " + DropList_ben_value;
            }

            if (DropList_cur_type.SelectedIndex != 0)
            {
                DropList_cur_value = DropList_cur_type.SelectedValue;
                sSql += "and Pay_type= " + DropList_cur_value;
            }

            if (DropList_acc_type.SelectedIndex != 0)
            {
                DropList_acc_value = DropList_acc_type.SelectedValue;
                sSql += "and Account_Type= " + DropList_acc_value;
            }
            SqlDataAdapter adaptaer = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
            var Result = Core.DataBase.SqlHelper.FindRec(adaptaer);
            GridView.DataSource = Result.CopyToDataTable();
            GridView.DataBind();
            GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception x)
        {
            Alerts.alertError(Page, "", "");
        }
        Button2.Enabled = true;
    }

    protected void Btn_Print_Click(object sender, EventArgs e)
    {
        try
        {
            string DropList_ben_value, DropList_cur_value, DropList_acc_value = "";

            string mo7ddat = "";

            string sSql = "select * from Aid where 1=1 ";

            if (DropList_ben_type.SelectedIndex != 0)
            {
                DropList_ben_value = DropList_ben_type.SelectedValue;
                sSql += "and Aid_Type= " + DropList_ben_value;
                mo7ddat += " (نوع المستفيد : " + DropList_ben_type.SelectedItem.Text + ")";
            }

            if (DropList_cur_type.SelectedIndex != 0)
            {
                DropList_cur_value = DropList_cur_type.SelectedValue;
                sSql += "and Pay_type= " + DropList_cur_value;
                mo7ddat += " (نوع العمله : " + DropList_cur_type.SelectedItem.Text + ")";
            }

            if (DropList_acc_type.SelectedIndex != 0)
            {
                DropList_acc_value = DropList_acc_type.SelectedValue;
                sSql += "and Account_Type= " + DropList_acc_value;
                mo7ddat += " (نوع الحساب : " + DropList_acc_type.SelectedItem.Text + ")";
            }
            DataTable dt = new DataTable();
            SqlDataAdapter adaptaer = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
            var Result = Core.DataBase.SqlHelper.FindRec(adaptaer);
            dt = Result.CopyToDataTable();
            ReportParameter[] rptParams = new ReportParameter[]
          {
               //new ReportParameter("userid", Session["UserName"].ToString()),
               new ReportParameter("mo7ddat",mo7ddat)
          };

            try
            {
                GlobalFunction.GenerateTestFile("تقرير المستفيدين", Server.MapPath("~/Reports/TaskReport.rdlc"), dt, rptParams);
            }
            catch (Exception x)
            {
                Alerts.alertError(Page, "", "");
            }
        }
        catch (Exception x)
        {
            Alerts.alertError(Page, "", "");
        }
    }
}