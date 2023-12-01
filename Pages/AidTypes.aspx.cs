using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_AidTypes : System.Web.UI.Page
{
    //public object GridView2 { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAidTypes();
        }
    }

    private void GetAidTypes()
    {
        string Ssql = "select * from Aid_Types";
        SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
        var Result = Core.DataBase.SqlHelper.FindRec(adapter);
        if (Result != null && Result.Count > 0)
        {
            GridView12.DataSource = Result.CopyToDataTable();
            GridView12.DataBind();
            GridView12.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        UpdatePanel3.Update();

    }


    protected void btnInsert2_Click(object sender, EventArgs e)
    {

        string Ssql = "INSERT INTO Aid_Types(Aid_Desc)values ('" + txtName1.Text + "')";


        SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);
        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
        if (txtName1.Text =="")
        {
            Alerts.alertWarning(Page, "", "برجاء ادخال نوع المساعدة");
            
        }

        Alerts.alertSuccess(Page, "نجحت العمليه", "تم الاضافة بنجاح");
        ClearRec();
        GetAidTypes();

    }

    private void ClearRec()
    {
     
        txtName1.Text = "";
        UpdatePanel6.Update();
        //throw new NotImplementedException();
    }


    //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    int Aid_code = Convert.ToInt32(e.CommandArgument);
    //    string sSql = "delete from Aid_Types where Aid_Code = " + Aid_code;
    //    SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
    //    Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);

    //    GetAidTypes();
    //    Thread.Sleep(5);
    //    Alerts.alertSuccess(Page, "نجحت العمليه", "تم الالغاء بنجاح");

    //}


    protected void GridView12_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView12.EditIndex = e.NewEditIndex;

        GetAidTypes();
    }

    protected void GridView12_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {


        try
        {

           

            string ssql = "SELECT *  FROM Aid where Aid_Type =@Aid_Type ";
            string Aid_Type = GridView12.DataKeys[e.RowIndex].Value.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter(ssql, Core.DataBase.ConnectionManager.BMP);
            adapter.SelectCommand.Parameters.AddWithValue("@Aid_Type", Aid_Type);
            var result = Core.DataBase.SqlHelper.FindRec(adapter);

            //الطريقة القديمة للربط مع قاعدة البيانات
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BMPConnectionString"].ConnectionString);

           // SqlCommand في حالة اوامر قاعدة البيات ادخال تعديل الغاء
            //SqlCommand cmd = new SqlCommand(ssql, con);
            //cmd.Parameters.AddWithValue("@Aid_Type", Aid_Type);
            //cmd.ExecuteNonQuery();
            //SqlDataAdapter في حالة الاختيار من قاعدة البيانات
            //SqlDataAdapter da = new SqlDataAdapter(cmd);

            //DataTable dt = new DataTable();
            //con.Open();
            //da.Fill(dt);
            //  con.Close();

            if (result.Count > 0)
            {


                GridView12.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
                GetAidTypes();
                Alerts.alertError(Page, "خطأ", "الحساب مستخدم. لا يمكن إلغاء الحساب");


            }
            else
            {
                

                //string Aid_Type = GridView12.DataKeys[e.RowIndex].Value.ToString();
                ssql = "delete from Aid_Types where Aid_Code=@Aid_Type ";
                SqlCommand cmd2 = new SqlCommand(ssql, Core.DataBase.ConnectionManager.BMP);
                cmd2.Parameters.AddWithValue("@Aid_Type", Aid_Type);
                Core.DataBase.SqlHelper.ExecuteNonQuery(cmd2);
                GridView12.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
                GetAidTypes();

                Alerts.alertSuccess(Page, "نجحت العمليه", "تم الالغاء بنجاح");
            }
         

        }
        catch (Exception x)
        {

            new ExceptionHandler(x);
        }





    }

    protected void GridView12_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            GridViewRow row = GridView12.Rows[e.RowIndex];

            //string txt_benif_no = ((TextBox)(row.Cells[0].Controls[0])).Text;
            string txt_aid = GridView12.DataKeys[e.RowIndex].Value.ToString();
            string txt_code = ((TextBox)(row.Cells[0].Controls[0])).Text;
            string txt_desc = ((TextBox)(row.Cells[1].Controls[0])).Text;

            string sSql = "update Aid_Types set  Aid_Desc=@Aid_Desc where Aid_Code=@Aid_Code";
            SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
           // cmd.Parameters.AddWithValue("@code", txt_code);
            cmd.Parameters.AddWithValue("@Aid_Desc", txt_desc);
            cmd.Parameters.AddWithValue("@Aid_Code", txt_aid);

            Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            GridView12.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
            GetAidTypes();
            Alerts.alertSuccess(Page, "", " تم التعديل  بنجاح");
        }
        catch (Exception x)
        {

            new ExceptionHandler(x);
        }

    }

    protected void GridView12_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView12.EditIndex = -1;
        GetAidTypes();
    }
}