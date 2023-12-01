using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.Security;

public partial class Pages_Default3 : System.Web.UI.Page
{
    //private object adaptaer;
    //private string query;

    //public object Ben_Update { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void cmdOK_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUserName.Text.Trim() == "")
            {
                Alerts.alertError(Page, "Error", "برجاء ادخال اسم المستخدم");
            }
            if (txtPassword.Text.Trim() == "")
            {
                Alerts.alertError(Page, "Error", "برجاء ادخال كلمه المرور");
            }

            string Ssql2 = "select * from Sys_Users  w where w.Username='" + txtUserName.Text.Trim() + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(Ssql2, Core.DataBase.ConnectionManager.BMP);
            var Result = Core.DataBase.SqlHelper.FindRec(adapter);
            if (Result.Count > 0)
            {
                int x = Convert.ToInt32(Result[0]["Status"]);
                string pass = Result[0]["Password"].ToString();
                if (pass != txtPassword.Text.Trim())
                {
                    Alerts.alertError(Page, "كلمه السر خطأ", "");
                    return;
                }

                if (x != 0)
                {
                    Alerts.alertWarning(Page, "تنبيه", "المستخدم غير فعال");
                    return;
                }
                Session["UserName"] = txtUserName.Text;
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
            }
            else
            {
                Alerts.alertError(Page, "اسم المستخدم خطأ", "");
            }
        }
        catch (Exception x)
        {
            new ExceptionHandler(x);
            Alerts.alertError(Page, "Error", "System Error! Please Contact Your Admin");
        }
    }
}