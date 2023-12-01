using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Pages_Ben_Update : System.Web.UI.Page
{
    public object GridView2 { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetBeneficiary();
        }
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Benif_No = Convert.ToInt32(e.CommandArgument);
        string sSql = "select * from Beneficiary where Beneficiary_No = " + Benif_No;
        SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
        var Data = Core.DataBase.SqlHelper.FindRec(adapter);
        fillDropdown();

        txtName1.Text= Data[0]["Name"].ToString();
        txtMobile1.Text = Data[0]["Tell"].ToString();
        txtCivil1.Text = Data[0]["Civil_ID"].ToString();
        txtinfo.Text = Data[0]["Info"].ToString();
        DDLIST.SelectedValue= Data[0]["Type"].ToString();
        HiddenField1_BenfNo.Value = Benif_No.ToString();
        if (Data[0]["Status"].ToString() == "0")
        {
            CheckBox1.Checked = true;
        }
        else
        {
            CheckBox1.Checked = false;
        }


        ModalPopupExtender1.Show();
        
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        UpdatePanel4.Update();
    }
   
    protected void btnExit_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        ModalPopupExtender3.Hide();

    }

    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
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

            string sSql = "update Beneficiary set Name=@Name ,  Tell=@Tell ,civil=@Civil_ID, where Beneficiary_No=@Beneficiary_No";
            SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
            cmd.Parameters.AddWithValue("@Name", txt_Name);
            cmd.Parameters.AddWithValue("@Tell", txt_Tel);
            cmd.Parameters.AddWithValue("@Beneficiary_No", txt_benif_no);
            cmd.Parameters.AddWithValue("@civil", txtCivil1);
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

    
    private bool ValidateUpdate()
    {
        if (txtName1.Text == "")
        {
            Alerts.alertWarning(Page, "", "ادخل الاسم");
            return false;
        }

        if (txtMobile1.Text == "")
        {
            Alerts.alertWarning(Page, "", "ادخل رقم التليفون");
            return false;
        }
        if (txtCivil1.Text == "")
        {
            Alerts.alertWarning(Page, "", "ادخل رقم البطاقه المدنيه");
            return false;
        }
        if (txtCivil1.Text == "")
        {
            Alerts.alertWarning(Page, "", "اختر نوع المستفيد");
            return false;
        }
        if (DDLIST.SelectedValue == "-1")
        {
            Alerts.alertWarning(Page, "", "برجاء اختيار نوع المستفيد");
            return false;

        }
        return true;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (ValidateUpdate() == false)
        {
            return;
        }
        string sSql = "update Beneficiary set Name=@Name ,  Tell=@Mobile ,Civil_ID=@Civil_ID , info=@info,Status=@Status,Type=@Type where Beneficiary_No=@Beneficiary_No";
        SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
        cmd.Parameters.AddWithValue("@Name", txtName1.Text);
        cmd.Parameters.AddWithValue("@Mobile", txtMobile1.Text);
        cmd.Parameters.AddWithValue("@Beneficiary_No", HiddenField1_BenfNo.Value);
        cmd.Parameters.AddWithValue("@Civil_ID", txtCivil1.Text);
        cmd.Parameters.AddWithValue("@Type",DDLIST.SelectedValue);
       
        cmd.Parameters.AddWithValue("@info", txtinfo.Text);
        if (CheckBox1.Checked)
        {
            cmd.Parameters.AddWithValue("@Status",0);
        }
        else
        {
            cmd.Parameters.AddWithValue("@Status", 1);
        }
        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
        GridView1.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
        GetBeneficiary();
        Alerts.alertSuccess(Page, "", " تم التعديل  بنجاح");
        ModalPopupExtender1.Hide();
    }

    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        ModalPopupExtender3.Show();
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        fillDropdown2();
        UpdatePanel3.Update();


    }

    private bool ValidateData()
    {
        if (txtlabelname.Text == "")
        {
            Alerts.alertWarning(Page, "", "ادخل الاسم");
            return false;
        }

        if (txtlabelnum.Text == "")
        {
            Alerts.alertWarning(Page, "", "ادخل رقم التيليفون");
            return false;
        }
        if (txtlabelcivil.Text == "")
        {
            Alerts.alertWarning(Page, "", "ادخل رقم البطاقه المدنيه");
            return false;
        }
        //if (txtCivil.Text == "")
        //{
        //    Alerts.alertWarning(Page, "", "اختر نوع المستفيد");
        //    return false;
        //}
        if (DropDownList1.SelectedValue == "-1")
        {
            Alerts.alertWarning(Page, "", "برجاء اختيار نوع المستفيد");
            return false;

        }
        return true;
    }

  

    private void fillDropdown2()
    {

        string fill = "select  *  from Beneficiary_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropDownList1.DataSource = result.CopyToDataTable();
        DropDownList1.DataTextField = "Type_Desc";
        DropDownList1.DataValueField = "Type_ID";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    protected void btnAddSave_Click(object sender, EventArgs e)
      {

        if (ValidateData())
        {
            int status = 0;
            if (CheckBox2.Checked==true)    
            {
                status = 0;
            }
            else
            {
                status =1;
            }

            string Ssql = "INSERT INTO Beneficiary (Name, Tell, Civil_ID,info,status,Type) VALUES ('" 
                + txtlabelname.Text+ "','" + txtlabelnum.Text+ "','" + txtlabelcivil.Text+ "','" +
                txtlabelinfo.Text+ "'," + status + "," + DropDownList1.SelectedValue + ")";


            SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);
            Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
       
            Alerts.alertSuccess(Page, "نجحت العمليه", "تم الاضافة بنجاح");
            //ClearRec();

            GetBeneficiary();
           
            ModalPopupExtender3.Hide();

        }
    }



    protected void btnExit2_Click(object sender, EventArgs e)
    {

        ModalPopupExtender3.Hide();
    }

    //protected void Button4_Click(object sender, EventArgs e)
    //{
    //    //    ModalPopup.Show();
    //    //    GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
    //    //    fillDropDown();


    //    Response.Redirect("~/Pages/AID.aspx");
    //}

    private void fillDropDown()
    {
        throw new NotImplementedException();
    }
         protected void Save_Click(object sender, EventArgs e)
    {


        if (ValidateUpdate() == false)
        {
            return;
        }
        string Ssql = "INSERT INTO Aid (Name,Aid_Desc,Amount,Aid_Date,Pay_Desc,Account_Desc) VALUES ('" + txtlabelname.Text + "','" + Droppop.SelectedValue + "','" + txtvalue.Text + "','" + txtlbldate.Text + "'," + txtpaytype.Text + "," + txtaccount.Text + ")";


        SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);
        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);

        Alerts.alertSuccess(Page, "نجحت العمليه", "تم الاضافة بنجاح");

        GetAid();
        ModalPopup.Hide();

    }

    private void GetAid()
    {
        throw new NotImplementedException();
    }
}


