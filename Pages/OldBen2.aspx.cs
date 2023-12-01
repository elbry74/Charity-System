using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Pages_Ben2 : System.Web.UI.Page
{
       

    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            //GridView1.DataSource = GetData("SELECT Type_ID ,Type_Desc FROM Beneficiary_Types");
            //GridView1.DataBind();
          
            GetBeneficiary();

            fillDropdown();
        }

    }

   
    private void GetBeneficiary()
    {
        string Ssql = "select * from VBeneficiary";

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
   

   

     private bool ValidateData()
    {
        if (DDLIST.SelectedValue == "-1")
        {
            Alerts.alertWarning(Page, "", "");
            return false; 
        }
        return true;
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {

        if (ValidateData())
        {
            int status = 0;
            if (CheckBox1.Checked)
            {
                status = 1;
            }

            string Ssql = "INSERT INTO Beneficiary (Name, Tell, Civil_ID,info,status,Type) VALUES ('" + txtName1.Text + "','" + txtMobile1.Text + "','" + txtCivil1.Text + "','" + txtinfo.Text + "'," + status + "," + DDLIST.SelectedValue + ")";


            SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);
            Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);



            Alerts.alertSuccess(Page, "نجحت العمليه", "تم الاضافة بنجاح");
            ClearRec();
            GetBeneficiary();
        }
        
       

    } 


    private void ClearRec()
    {
        txtName1.Text = txtMobile1.Text = txtCivil1.Text =txtinfo.Text = "";
        DDLIST.SelectedValue = "-1";
        CheckBox1.Checked = false;
        UpdatePanel1.Update();
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Beneficiary_No = Convert.ToInt32(e.CommandArgument);

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GetBeneficiary();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GetBeneficiary();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];

            //string txt_benif_no = ((TextBox)(row.Cells[0].Controls[0])).Text;
            string txt_benif_no = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string txt_Name = ((TextBox)(row.Cells[1].Controls[0])).Text;
            string txt_Tel = ((TextBox)(row.Cells[2].Controls[0])).Text;

            string sSql = "update Beneficiary set Name=@Name ,  Tell=@Tell where Beneficiary_No=@Beneficiary_No";
            SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
            cmd.Parameters.AddWithValue("@Name", txt_Name);
            cmd.Parameters.AddWithValue("@Tell", txt_Tel);
            cmd.Parameters.AddWithValue("@Beneficiary_No", txt_benif_no);

            Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            GridView1.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
            GetBeneficiary();
            Alerts.alertSuccess(Page, "", " تم التعديل  بنجاح");
        }
        catch (Exception x)
        {

            new ExceptionHandler(x);
        }


    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string Beneficiary_No = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string sSql = "delete from Beneficiary where Beneficiary_No =@Beneficiary_No ";
            SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
            cmd.Parameters.AddWithValue("@Beneficiary_No", Beneficiary_No);
            Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            GridView1.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
            GetBeneficiary();

            Alerts.alertSuccess(Page, "نجحت العمليه", "تم الالغاء بنجاح");
        }
        catch (Exception x)
        {

            new ExceptionHandler(x);
        }
    }
   

 


  

    private DataSet GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["BMPConnectionString"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        string fill = "select * from Beneficiary_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
       // DropDownList1.SelectedItem.Text.ToString();

       
       // DropDownList1.Itemes.Add("select * from Beneficiary_Types");
    }



    



   
    private void fillDropdown()
    {
        string fill = "select  *  from Beneficiary_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DDLIST.DataSource = result.CopyToDataTable();
        DDLIST.DataTextField = "Type_Desc";
        DDLIST.DataValueField = "Type_ID";
        DDLIST.DataBind();
        DDLIST.Items.Insert(0, new ListItem("اختر", "-1"));
    }
    protected void DDLIST_SelectedIndexChanged(object sender, EventArgs e)
    {
       


    }
}


