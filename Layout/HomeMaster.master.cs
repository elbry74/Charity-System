using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserName"] != null)
            {
                lbl_namee.Text = Session["UserName"].ToString();
            }
            else
            {
                Response.Redirect("/Pages/loginpage.aspx");
            }

            if (GlobalFunction.isArabic())
            {
                plcssEnglish.Visible = false;
                pljsEnglish.Visible = false;
                pljsArabic.Visible = true;
                plcssArabic.Visible = true;
            }
            else
            {
                plcssEnglish.Visible = true;
                pljsEnglish.Visible = true;
                pljsArabic.Visible = false;
                plcssArabic.Visible = false;
            }
            loadMenu();
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
    }

    protected void btnLangEn_Click(object sender, EventArgs e)
    {
        LanguageCls cls = new LanguageCls();
        cls.SetLanguage(Resources.AppConfig.en);
        Response.Redirect(Request.Path);
    }

    protected void btnLangAr_Click(object sender, EventArgs e)
    {
        LanguageCls cls = new LanguageCls();
        cls.SetLanguage(Resources.AppConfig.ar);
        Response.Redirect(Request.Path);
    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        HttpCookie cookie = new HttpCookie("ModName");
        cookie.Expires = DateTime.Now.AddDays(-1d);
        Response.SetCookie(cookie);
        Response.Redirect("~/Pages/loginpage.aspx");
    }

    private void loadMenu()
    {
        try
        {
            String usere_id = Session["UserName"].ToString();
            string Ssql = "select Admin from Sys_Users w where w.Username='" + usere_id + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
            var Result = Core.DataBase.SqlHelper.FindRec(adapter);
            int admin = Convert.ToInt32(Result[0][0].ToString());
            if (admin == 0)
            {
                //Li1.Visible = true;
                Li2.Visible = true;
            }
            else
            {
                //Li1.Visible = false;
                Li2.Visible = false;
            }
        }
        catch (Exception x)
        {
        }
    }
}