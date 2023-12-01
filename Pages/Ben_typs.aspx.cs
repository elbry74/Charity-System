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
            fillgrid();
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

    private void fillgrid()
    {
        string Ssql = "select  * from Beneficiary_Types  order by  Type_ID ";

        SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
        var Result = Core.DataBase.SqlHelper.FindRec(adapter);
        if (Result != null && Result.Count > 0)
        {
            GridView1.DataSource = Result.CopyToDataTable();
            GridView1.DataBind();
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        UpdatePanel2.Update();
    }

    protected void Btn_Add_Click(object sender, EventArgs e)
    {
        try
        {
            string f2a, f2a_text, ben_type = "";
            if (Drop_f2a.SelectedValue != "-1")
            {
                if (txt_ben_type.Text != "")
                {
                    ben_type = txt_ben_type.Text;
                }
                else
                {
                    Alerts.alertWarning(Page, "تنبيه", "ادخل نوع المستفيد");
                    return;
                }
            }
            else
            {
                Alerts.alertWarning(Page, "تنبيه", "اختر الفئة");
                return;
            }
            string fill = "select  max(Type_ID) maxx from Beneficiary_Types  ";
            SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
            var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
            int num = Convert.ToInt32(result[0]["maxx"]) + 1;
            f2a = Drop_f2a.SelectedValue;
            f2a_text = Drop_f2a.SelectedItem.Text;

            fill = "insert into Beneficiary_Types(Category_ID,Category_Desc,Type_ID,Type_Desc)values(@Category_ID,@Category_Desc,@Type_ID,@Type_Desc)";
            SqlCommand cmd = new SqlCommand(fill, Core.DataBase.ConnectionManager.BMP);

            cmd.Parameters.AddWithValue("@Category_ID", f2a);
            cmd.Parameters.AddWithValue("@Category_Desc", f2a_text);
            cmd.Parameters.AddWithValue("@Type_ID", num);
            cmd.Parameters.AddWithValue("@Type_Desc", ben_type);

            int res = Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            if (res == 1)
            {
                Alerts.alertSuccess(Page, "تم الإضافه بنجاح", "");
            }
            else
            {
                Alerts.alertError(Page, "خطأ ", "اتصل بالمسؤل");
                return;
            }
            fillgrid();
        }
        catch (Exception x)
        {
            new ExceptionHandler(x);
        }
    }
}