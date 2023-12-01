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
            lood_grd();
        }
    }

    private void lood_grd()
    {
        try
        {
            string Ssql = "select * from Sys_Users ";

            SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
            var Result = Core.DataBase.SqlHelper.FindRec(adapter);
            if (Result != null && Result.Count > 0)
            {
                GridView1.DataSource = Result.CopyToDataTable();
                GridView1.DataBind();
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception x)
        {
            Alerts.alertError(Page, "", "");
        }
    }

    protected void Btn_Print_Click(object sender, EventArgs e)
    {
        try
        {
            string Pass = "";
            string Password_old = "";
            string Password_new = txt_Confirm_Password.Text.Trim();
            string user_id = txt_usere_id.Text.Trim();
            if (Check_Pass.Checked == true)
            {
                if (!vald_pass())
                {
                    return;
                }

                int Length = Password_new.Length;
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
                Pass = Password_new;
            }
            else
            {
                string Ssql2 = "select * from Sys_Users w where w.Username='" + user_id + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(Ssql2, Core.DataBase.ConnectionManager.BMP);
                var Result = Core.DataBase.SqlHelper.FindRec(adapter);
                Password_old = Result[0]["Password"].ToString();
                Pass = Password_old;
            }

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

            string Ssql = "update Sys_Users set Password=@Password ,Admin=@Admin,Status=@Status where Username=@Username";
            SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);

            cmd.Parameters.AddWithValue("@Username", user_id);
            cmd.Parameters.AddWithValue("@Password", Pass);
            cmd.Parameters.AddWithValue("@Admin", Admin);
            cmd.Parameters.AddWithValue("@Status", Status);

            int x = Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            if (x == 1)
            {
                Alerts.alertSuccess(Page, "نجحت العمليه", "تم التعديل بنجاح");
                lood_grd();
                Panel_grid.Visible = true;
                Panel_data.Visible = false;
                clear();
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

                UpdatePanel1.Update();
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

    private void clear()
    {
        txt_usere_id.Text = txt_Password.Text = txt_Confirm_Password.Text = "";
        Check_Admin.Checked = false; Check_Status.Checked = false;
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel_Pass.Visible = false;
        Check_Pass.Checked = false;
        txt_Confirm_Password.Text = txt_Password.Text = "";
        UpdatePanel3.Update();

        Panel_grid.Visible = false;
        Panel_data.Visible = true;
        UpdatePanel2.Update();

        string user_id = e.CommandArgument.ToString();
        string Ssql = "select * from Sys_Users w where w.Username='" + user_id + "'";

        SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
        var Result = Core.DataBase.SqlHelper.FindRec(adapter);
        txt_usere_id.Text = Result[0]["Username"].ToString();
        int Admin = Convert.ToInt32(Result[0]["Admin"]);
        int Status = Convert.ToInt32(Result[0]["Status"]);
        if (Admin == 0)
        {
            Check_Admin.Checked = true;
        }
        else
        {
            Check_Admin.Checked = false;
        }

        if (Status == 0)
        {
            Check_Status.Checked = true;
        }
        else
        {
            Check_Status.Checked = false;
        }
    }

    protected void btn_retern_Click(object sender, EventArgs e)
    {
        Panel_grid.Visible = true;
        Panel_data.Visible = false;
        clear();
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;

        UpdatePanel1.Update();
    }

    protected void Check_Pass_CheckedChanged(object sender, EventArgs e)
    {
        if (Check_Pass.Checked == true)
        {
            Panel_Pass.Visible = true;
        }
        else
        {
            Panel_Pass.Visible = false;
        }
        txt_Confirm_Password.Text = txt_Password.Text = "";
        UpdatePanel3.Update();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[2];
            if (statusCell.Text == "0")
            {
                statusCell.Text = "Yes";
            }
            if (statusCell.Text == "1")
            {
                statusCell.Text = "No";
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[1];
            if (statusCell.Text == "0")
            {
                statusCell.Text = "Active";
            }
            if (statusCell.Text == "1")
            {
                statusCell.Text = "In Active";
            }
        }
    }

    protected void btn_Add_User_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Pages/add_users.aspx");
    }
}