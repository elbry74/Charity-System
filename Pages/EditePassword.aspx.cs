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
        }
    }

    protected void Btn_Print_Click(object sender, EventArgs e)
    {
        try
        {
            string Password = "";

            if (txt_Password.Text.Trim() != txt_Confirm_Password.Text.Trim())
            {
                Alerts.alertWarning(Page, "تنبيه", "كمة السر غير متطابقه");
                return;
            }
            else
            {
                Password = txt_Confirm_Password.Text.Trim();
            }
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

            string sSql = " UPDATE Sys_Users SET Password = @Password where Username=@Username";
            SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());

            int x = Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            if (x == 1)
            {
                Alerts.alertSuccess(Page, "Done", "");

                //Response.Redirect("~/Pages/loginpage.aspx");
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
}