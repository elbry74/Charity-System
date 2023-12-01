using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PopUPMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            GetActiveModName();
            string PageTitle = GlobalFunction.GetPageTitle;
            if (PageTitle != "")
                Page.Title = PageTitle;
            //DataBind();
        }
      
    }

    public void GetActiveModName()
    {
        string ModName = GlobalFunction.GetCurrentModuleName();
        switch (ModName)
        {
            case "Employment":
                {
                    Page.Title = GetLocalResourceObject("Employment").ToString();
                    break;
                }
            case "Personnel":
                {
                    Page.Title = GetLocalResourceObject("Personnel").ToString();
                    break;
                }
            case "Personal Actions":
                {
                    Page.Title = GetLocalResourceObject("PersonalActions").ToString();
                    break;
                }
            case "Payroll":
                {
                    Page.Title =  GetLocalResourceObject("Payroll").ToString();
                    break;
                }
            case "Emp. Basic Data":
                {
                    Page.Title =  GetLocalResourceObject("BasicData").ToString();
                    break;
                }
            case "Employees Documents":
                {
                    GlobalFunction.SetCurrentModuleName("Employment");
                    Page.Title =  GetLocalResourceObject("Employees_Documents").ToString();
                    break;
                }

            default:
                {

                    GlobalFunction.SetCurrentModuleName(GetAvaliableModules()[0]);
                    Page.Title = GetLocalResourceObject(GetAvaliableModules()[0]).ToString();
                    break;
                }
        }
    }

    public static List<string> GetAvaliableModules()
    {
        try
        {
            string sSql = "select distinct app_desc1,app_sequence from vsys_menu where user_id='" + GlobalFunction.GetUserName() + "'" +
            "and executable_id = 'bmp' order by app_sequence";
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
            var result = Core.DataBase.SqlHelper.FindRec(adapter);
            List<string> str = new List<string>();
            if (result == null || result.Count == 0)
                return str;
            foreach (var r in result)
            {
                str.Add(r[0].ToString());
            }

            return str;
        }
        catch (Exception x)
        {
            new ExceptionHandler(x);
            return null;
        }
    }
}
