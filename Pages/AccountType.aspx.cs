using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Account_Type : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAccount();
        }
    }

    private void GetAccount()
    {
        string Ssql = "select * from Account_Types";
        SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
        var Result = Core.DataBase.SqlHelper.FindRec(adapter);
        if (Result != null && Result.Count > 0)
        {
            GridViewAccount.DataSource = Result.CopyToDataTable();
            GridViewAccount.DataBind();
            GridViewAccount.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        UpdatePanel3.Update();
    }

    protected void GridViewAccount_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridViewAccount.EditIndex = e.NewEditIndex;

        GetAccount();
    }

    protected void GridViewAccount_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //try
        //{
        //    //\\\\\

        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BMPConnectionString"].ConnectionString);
        //    con.Open();

        //    string ssql = "SELECT Account_Type  FROM Aid where Account_Type =@Account_Type ";
        //    string Account_Type = GridViewAccount.DataKeys[e.RowIndex].Value.ToString();

        //    SqlCommand cmd = new SqlCommand(ssql, con);
        //    cmd.Parameters.AddWithValue("@Account_Type", Account_Type);

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    if (dt.Rows.Count > 0)
        //    {
        //        GridViewAccount.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
        //        GetAccount();
        //        Alerts.alertError(Page, "خطأ", "الحساب مستخدم. لا يمكن إلغاء الحساب");

        //    }
        //    else
        //    {
        //        string sSql2 = "delete from Account_Types where Account_Type =@Account_Type ";

        //        SqlCommand cmd2 = new SqlCommand(sSql2, Core.DataBase.ConnectionManager.BMP);
        //        cmd2.Parameters.AddWithValue("@Account_Type", Account_Type);
        //        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd2);

        //        GridViewAccount.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
        //        GetAccount();

        //        Alerts.alertSuccess(Page, "نجحت العمليه", "تم الالغاء بنجاح");

        //    }

        //    //\\\\\

        //    con.Close();
        //}
        //catch (Exception x)
        //{
        //    new ExceptionHandler(x);
        //}
    }

    protected void GridViewAccount_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
    }

    protected void GridViewAccount_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = GridViewAccount.Rows[e.RowIndex];

            //string txt_benif_no = ((TextBox)(row.Cells[0].Controls[0])).Text;
            string txt_account = GridViewAccount.DataKeys[e.RowIndex].Value.ToString();
            string txt_code = ((TextBox)(row.Cells[0].Controls[0])).Text;
            string txt_desc = ((TextBox)(row.Cells[1].Controls[0])).Text;

            string sSql = "update Account_Types set  Account_Desc=@Account_Desc where Account_Type =@Account_Type";
            SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
            // cmd.Parameters.AddWithValue("@code", txt_code);
            cmd.Parameters.AddWithValue("@Account_Desc", txt_desc);
            cmd.Parameters.AddWithValue("@Account_Type", txt_code);

            Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            GridViewAccount.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
            GetAccount();
            Alerts.alertSuccess(Page, "", " تم التعديل  بنجاح");
        }
        catch (Exception x)
        {
            new ExceptionHandler(x);
        }
    }

    protected void GridViewAccount_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridViewAccount.EditIndex = -1;
        GetAccount();
    }

    protected void btnInsertAccount_Click(object sender, EventArgs e)
    {
        string Ssql = "INSERT INTO Account_Types(Account_Desc) values ('" + txtAccount.Text + "')";

        SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);
        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
        if (txtAccount.Text == "")
        {
            Alerts.alertWarning(Page, "", "برجاء ادخال نوع الحساب");
        }

        Alerts.alertSuccess(Page, "نجحت العمليه", "تم الاضافة بنجاح");
        ClearRec();
        GetAccount();
    }

    private void ClearRec()
    {
        txtAccount.Text = "";
        UpdatePanel6.Update();
    }
}