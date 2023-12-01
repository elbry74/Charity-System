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
            fillAid_Types();
            fillDropDownpayTaype();
            fillDropdownAcount();
            fillBeneficiar();
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

    private void fillAid_Types()
    {
        string fill = "select * from Aid_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropAidType.DataSource = result.CopyToDataTable();
        DropAidType.DataTextField = "Aid_Desc";
        DropAidType.DataValueField = "Aid_Code";
        DropAidType.DataBind();
        DropAidType.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDropDownpayTaype()
    {
        string fill = "select * from Pay_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropDownpayTaype.DataSource = result.CopyToDataTable();
        DropDownpayTaype.DataTextField = "Pay_Desc";
        DropDownpayTaype.DataValueField = "Pay_Type";
        DropDownpayTaype.DataBind();
        DropDownpayTaype.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDropdownAcount()
    {
        string fill = "select * from Account_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropDownAcount.DataSource = result.CopyToDataTable();
        DropDownAcount.DataTextField = "Account_Desc";
        DropDownAcount.DataValueField = "Account_Type";
        DropDownAcount.DataBind();
        DropDownAcount.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    protected void Btn_Print_Click(object sender, EventArgs e)
    {
        try
        {
            string Aid_Type, Pay_type, Account_Type, StertDate, EndDate, stutes, Beneficiary_No, Type, Category_ID = "";
            string mo7ddat = "";

            if (txt_Enddate.Text == "")
            {
                EndDate = "Aid_Date";
            }
            else
            {
                EndDate = "'" + txt_Enddate.Text + "'";
                mo7ddat += " (تاريخ النهايه : " + txt_Enddate.Text + ")";
            }
            if (txt_Stertdate.Text == "")
            {
                StertDate = "Aid_Date";
            }
            else
            {
                StertDate = "'" + txt_Stertdate.Text + "'";
                mo7ddat += " (تاريخ البدايه : " + txt_Stertdate.Text + ")";
            }
            if (Drop_ben_type.Items.Count != 0)
            {
                if (Drop_ben_type.SelectedValue == "-1")
                {
                    Type = "Type";
                }
                else
                {
                    Type = Drop_ben_type.SelectedValue;
                    mo7ddat += " (نوع المستفيد : " + Drop_ben_type.SelectedItem.Text + ")";
                }
            }
            else
            {
                Type = "Type";
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

            if (DropDownstutes.SelectedValue == "-1")
            {
                stutes = "Delete_Flag_Code";
            }
            else
            {
                stutes = DropDownstutes.SelectedValue;
                mo7ddat += " (الحاله : " + DropDownstutes.SelectedItem.Text + ")";
            }

            if (DropDownAcount.SelectedValue == "-1")
            {
                Account_Type = "Account_Type";
            }
            else
            {
                Account_Type = DropDownAcount.SelectedValue;
                mo7ddat += " (نوع الحساب : " + DropDownAcount.SelectedItem.Text + ")";
            }
            if (DropDownpayTaype.SelectedValue == "-1")
            {
                Pay_type = "Pay_type";
            }
            else
            {
                Pay_type = DropDownpayTaype.SelectedValue;

                mo7ddat += " (طريقه الدفع : " + DropDownpayTaype.SelectedItem.Text + ")";
            }

            if (DropAidType.SelectedValue == "-1")
            {
                Aid_Type = "Aid_Type";
            }
            else
            {
                Aid_Type = DropAidType.SelectedValue;
                mo7ddat += " (نوع المساعدة : " + DropAidType.SelectedItem.Text + ")";
            }
            if (ddBeneficiar.SelectedValue == "-1")
            {
                Beneficiary_No = "Beneficiary_No";
            }
            else
            {
                Beneficiary_No = ddBeneficiar.SelectedValue;
                mo7ddat += "(اسم المستفيد: " + ddBeneficiar.SelectedItem.Text + ")";
            }

            if (mo7ddat == "")
            {
                mo7ddat = " (جميع السجلات) ";
            }
            DataTable dt = new DataTable();

            string sSql = " SELECT * FROM  VAid where   Beneficiary_No= " + Beneficiary_No + " and Aid_Type=" + Aid_Type + " and Pay_type=" +
                Pay_type + " and Account_Type=" + Account_Type + " and  Aid_Date >= " + StertDate + " and  Aid_Date <=" +
                EndDate + " and Delete_Flag_Code= " + stutes + "  and Type=" + Type + " and Category_ID= " + Category_ID + "    order by Aid_no    ";
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
            //GlobalFunction.LoadRDLC(Page, Server.MapPath("~/Reports/Aid_report.rdlc"), dt, rptParams);

            try
            {
                GlobalFunction.GenerateTestFile("تقرير المساعدات", Server.MapPath("~/Reports/Aid_report.rdlc"), dt, rptParams);
            }
            catch
            {
            }
            //GlobalFunction.LoadRDLC(Page, Server.MapPath("~/Reports/Aid_report.rdlc"), dt, rptParams);
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