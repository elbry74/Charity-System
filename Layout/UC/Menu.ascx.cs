using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout_UC_Menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGroups();
        }
    }
    private string gsLangType
    {
        get
        {
            if (GlobalFunction.isArabic())
                return "";
            return "1";
                    
        }
    }
    private void FillGroups()
    {
        string ModuleName = GlobalFunction.GetCurrentModuleName();
        string UserName = GlobalFunction.GetUserName();
        if (ModuleName == "" || ModuleName == "Home")
        {
            return;
        }
        string sSql ;
        sSql = "select distinct group_id,group_desc" + gsLangType + ",group_sequence";
        sSql = sSql + " from vsys_menu where user_id='" + UserName + "' and app_desc1" ;
        sSql = sSql + "='" + ModuleName + "' and authority >0 order by group_sequence";
        SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adapter);
        if (result == null || result.Count == 0)
        {
            return;
        }
        string FinalMenu = "";
        foreach (var r in result)
        {
            sSql = "select distinct item_id, item_desc" + gsLangType + ",item_sequence from vsys_menu where ";
            sSql = sSql + " group_id = '" + r[0].ToString() + "' and user_id ='" + UserName + "' and authority> 0  and item_id <>'FRMQVEMPLOYEECOURSES' And item_id <>'FRMAUDITLEVELS' order by item_sequence ";
            adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
            var subResult = Core.DataBase.SqlHelper.FindRec(adapter);
            if (subResult == null || subResult.Count == 0)
            {
                continue;
            }
            FinalMenu += "<li><a href='#' class='dropdown-toggle'> <i class='fa fa-circle'></i> <span>";
            FinalMenu += r[1].ToString()+ "</span>";
            if (GlobalFunction.isArabic())
            {
                FinalMenu += "<i class='fa fa-angle-left drop-icon'></i>";
            }
            else
            {
                FinalMenu += "<i class='fa fa-angle-right drop-icon'></i>";
            }
            FinalMenu += "</a> <ul class='submenu'>";
            foreach(var subr in subResult)
            {
                FinalMenu += "<li>";
                FinalMenu += "<a href='/Forms/" + subr[0].ToString() + ".aspx'>" + subr[1].ToString() + "</a>";
                FinalMenu += "</li>";
            }
            FinalMenu += "</ul></li>";
        }
        Literal1.Text = FinalMenu;
        DataBind();
    }
}