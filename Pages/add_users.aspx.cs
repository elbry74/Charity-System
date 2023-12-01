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
            //txt_usere_id.Text = txt_Password.Text = txt_Confirm_Password.Text = "";
            txt_usere_id.Focus();
        }
    }

    protected void Btn_Print_Click(object sender, EventArgs e)
    {
        try
        {
            if (!vald_usere())
            {
                return;
            }
            if (!vald_pass())
            {
                return;
            }

            string Password = txt_Confirm_Password.Text.Trim();

            int Length = Password.Length;
            if (Length < 6)
            {
                Alerts.alertWarning(Page, "تنبيه", "كلمة السر يجب ان تكون اكبر من 6 حروف");
                return;
            }

            if (Length > 16)
            {
                Alerts.alertWarning(Page, "تنبيه", "كلمة السر يجب ان تكون اصغر من 16 حروف");
                return;
            }
            string user_id = txt_usere_id.Text.Trim();
            int Admin = 1;
            int Status = 1;
            if (Check_Admin.Checked == true)
            {
                Admin = 0;
            }
            if (Check_Status.Checked == true)
            {
                Status = 0;
            }

            string Ssql = "insert into Sys_Users (Username,Password,Admin,Status) values (@Username,@Password,@Admin,@Status)";
            SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);

            cmd.Parameters.AddWithValue("@Username", user_id);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Admin", Admin);
            cmd.Parameters.AddWithValue("@Status", Status);

            int x = Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            if (x == 1)
            {
                Alerts.alertSuccess(Page, "نجحت العمليه", "تم الاضافة بنجاح");
                clear();
            }
            else
            {
                Alerts.alertError(Page, "Error", "");
            }
        }
        catch (Exception x)
        {
            Alerts.alertError(Page, "", "");
        }
    }

    protected void txt_usere_TextChanged(object sender, EventArgs e)
    {
        // vald_usere();
    }

    protected void txt_Confirm_Password_TextChanged(object sender, EventArgs e)
    {
        vald_pass();
    }

    private bool vald_pass()
    {
        try
        {
            if (txt_Password.Text.Trim() == "" || txt_Password.Text.Trim() == null)
            {
                Alerts.alertWarning(Page, "تنبيه ", "ادخل كلمه السر ثم تأكيد كلمه السر");
                txt_Confirm_Password.Text = txt_Password.Text = "";
                return false;
            }
            if (txt_Confirm_Password.Text != txt_Password.Text)
            {
                Alerts.alertWarning(Page, "تنبيه ", "كلمه السر غير متطابقة");
                txt_Confirm_Password.Text = "";
                return false;
            }
            return true;
        }
        catch (Exception x)
        {
            return false;
        }
    }

    private bool vald_usere()
    {
        try
        {
            //if (txt_usere_id.Text.Trim().Contains(""))
            //{
            //    Alerts.alertWarning(Page, "تنبيه", "اسم المستخدم يجب ان لا يحتوى على مسافه");
            //    txt_usere_id.Text = "";
            //    return;
            //}
            string user_id = txt_usere_id.Text.Trim();
            string Ssql = "select * from Sys_Users w where w.Username='" + user_id + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
            var Result = Core.DataBase.SqlHelper.FindRec(adapter);
            if (Result.Count > 0)
            {
                Alerts.alertWarning(Page, "تنبيه", " اسم المستخدم " + user_id + " موجود بالفعل ");
                txt_usere_id.Text = "";
                return false;
            }
            return true;
        }
        catch (Exception x)
        {
            return false;
        }
    }

    private void clear()
    {
        txt_usere_id.Text = txt_Password.Text = txt_Confirm_Password.Text = "";
        Check_Admin.Checked = false;
    }

    protected void Btn_Exit_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Pages/ediet_users.aspx");
    }
}