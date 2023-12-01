using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;

public partial class Pages_AID2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetAid();
            fillDropDowName();
            fillDropDownpayTaype();
            fillDropdownAcount();
            fillAid_Types();
            fillDropAcountTypeDetails();
            fillDropPayTaype();
            fillDropAidDetails();
            fillDropNameDetails();
            btnPrintAdd.Visible = false;
            //btnprintDetails.Visible = false;
        }
    }

    public void GetAid()
    {
        string Ssql = "select * from vAid where Delete_Flag_Code=0";

        SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
        var Result = Core.DataBase.SqlHelper.FindRec(adapter);
        if (Result != null && Result.Count > 0)
        {
            GridView3.DataSource = Result.CopyToDataTable();
            GridView3.DataBind();
            GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        UpdatePanel8.Update();
    }

    private void fillAid_Types()
    {
        string fill = "select * from Aid_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropAidType.DataSource = result.CopyToDataTable();
        DropAidType.DataTextField = "Aid_Desc";
        DropAidType.DataValueField = "Aid_Code";
        DropAidType.DataBind();
        DropAidType.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDropDowName()
    {
        string fill = "select * from Beneficiary where Status=0";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropDownName.DataSource = result.CopyToDataTable();
        DropDownName.DataTextField = "Name";
        DropDownName.DataValueField = "Beneficiary_No";
        DropDownName.DataBind();
        DropDownName.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDropdownAcount()
    {
        string fill = "select * from Account_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropDownAcount.DataSource = result.CopyToDataTable();
        DropDownAcount.DataTextField = "Account_Desc";
        DropDownAcount.DataValueField = "Account_Type";
        DropDownAcount.DataBind();
    }

    private void fillDropDownpayTaype()
    {
        string fill = "select * from Pay_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropDownpayTaype.DataSource = result.CopyToDataTable();
        DropDownpayTaype.DataTextField = "Pay_Desc";
        DropDownpayTaype.DataValueField = "Pay_Type";
        DropDownpayTaype.DataBind();
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int Aid_No = Convert.ToInt32(e.CommandArgument);
        Session["Aid_No"] = Convert.ToInt32(e.CommandArgument);
        string Ssql = "select * from Aid where Delete_Flag=0  and Aid_No = " + Aid_No;
        SqlDataAdapter adapter = new SqlDataAdapter(Ssql, Core.DataBase.ConnectionManager.BMP);
        var Data = Core.DataBase.SqlHelper.FindRec(adapter);
        fillDropAcountTypeDetails();
        fillDropPayTaype();
        fillDropAidDetails();
        fillDropNameDetails();
        DropNameDetails.SelectedValue = Data[0]["Beneficiary_No"].ToString();
        //DropDownpayTaype.SelectedValue = Data[0]["Pay_Type"].ToString();
        txtvalueDetails.Text = Data[0]["Amount"].ToString();
        txtusername.Text = Data[0]["Username"].ToString();
        txtupdate.Text = Data[0]["Last_Update"].ToString();
        txtdateenter.Text = Data[0]["Create_Date"].ToString();  //.Substring(0, 10);
        DropAidDetails.Enabled = false;
        txtvalueDetails.Enabled = false;
        DropNameDetails.Enabled = false;
        txtusername.Enabled = false;
        txtupdate.Enabled = false;
        txtdateenter.Enabled = false;
        btnEdit.Visible = true;
        btnDelete.Visible = true;

        //string dateFormat = "dd-MMM-yyyy";
        //txtDateAid.Text = dr.Field<DateTime>("I_Date").ToString(dateFormat);

        //txtDateAid.Text = Data[0]["Aid_Date"].ToString();

        txtDateAid.Text = Convert.ToDateTime(Data[0]["Aid_Date"]).ToString("dd/MM/yyyy");

        HiddenField1_AidNo.Value = Aid_No.ToString();
        txtDetails.Text = Data[0]["Remarks"].ToString();
        DropAidDetails.SelectedValue = Data[0]["Aid_Type"].ToString();
        DropAcountTypeDetails.SelectedValue = Data[0]["Account_Type"].ToString();
        DropPayTaypeDetails.SelectedValue = Data[0]["Pay_type"].ToString();
        ModalPopupExtender1.Show();

        GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;

        UpdatePanel6.Update();
    }

    private bool ValidateUpdate()
    {
        if (DropDownName.Text == "")
        {
            Alerts.alertWarning(Page, "", "ادخل الاسم");
            return false;
        }

        if (DropAidType.SelectedValue == "-1")
        {
            Alerts.alertWarning(Page, "", "اختار نوع المساعدة");
            return false;
        }
        if (txtvalue.Text == "")
        {
            Alerts.alertWarning(Page, "", "برجاء ادخال القيمه");
            return false;
        }
        if (txtlbldate.Text == "")
        {
            Alerts.alertWarning(Page, "", "برجاء ادخال التاريخ");
            return false;
        }
        if (DropDownpayTaype.SelectedValue == "")
        {
            Alerts.alertWarning(Page, "", "برجاء اختيار طريقه الدفع");
            return false;
        }
        if (DropDownAcount.SelectedValue == "")
        {
            Alerts.alertWarning(Page, "", "برجاء اختيار نوع الحساب");
            return false;
        }

        return true;
    }

    protected void btnAdd2_Click(object sender, EventArgs e)
    {
        ModalPopupExtender9.Show();
        GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
        fillDropDowName();
        fillAid_Types();
        fillDropDownpayTaype();
        fillDropdownAcount();

        UpdatePanel10.Update();
    }

    protected void btnSavepop_Click(object sender, EventArgs e)

    {
        if (ValidateUpdate() == false)
        {
            return;
        }
        //string Ssql = "INSERT INTO Aid (Beneficiary_No,Aid_Type,Amount,Aid_Date,Pay_type,Account_Type,Remarks,"+
        //   " Username,Create_Date,Delete_Flag) VALUES ('"
        //        + DropDownName.SelectedValue + "','" + DropAidType.SelectedValue + "','" +
        //        txtvalue.Text + "','" + DateTime.ParseExact(txtlbldate.Text,"dd/MM/yyyy",null).ToString("MM/dd/yyyy") + "'," + DropDownpayTaype.SelectedValue + "," +
        //        DropDownAcount.SelectedValue + ",'" + txtNote.Text + "','"+Session["UserName"].ToString() + "','" + d_n + "',0)";

        string sSql = "INSERT INTO Aid (Beneficiary_No,Aid_Type,Amount,Aid_Date,Pay_type,Account_Type,Remarks, Username,Create_Date,Delete_Flag) "
            + "VALUES  (@Beneficiary_No,@Aid_Type,@Amount,@Aid_Date,@Pay_type,@Account_Type,@Remarks,@Username,@Create_Date,@Delete_Flag)";
        SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
        cmd.Parameters.AddWithValue("@Beneficiary_No", DropDownName.SelectedValue);
        cmd.Parameters.AddWithValue("@Aid_Type", DropAidType.SelectedValue);
        cmd.Parameters.AddWithValue("@Amount", txtvalue.Text);
        cmd.Parameters.AddWithValue("@Aid_Date", DateTime.ParseExact(txtlbldate.Text, "dd/MM/yyyy", null));
        cmd.Parameters.AddWithValue("@Pay_type", DropDownpayTaype.SelectedValue);
        cmd.Parameters.AddWithValue("@Account_Type", DropDownAcount.SelectedValue);
        cmd.Parameters.AddWithValue("@Remarks", txtNote.Text);
        cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());
        cmd.Parameters.AddWithValue("@Create_Date", DateTime.Now);
        cmd.Parameters.AddWithValue("@Delete_Flag", 0);

        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);

        //"+Session["UserName"].ToString() + "

        //SqlCommand cmd = new SqlCommand(Ssql, Core.DataBase.ConnectionManager.BMP);
        //Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);

        Alerts.alertSuccess(Page, "نجحت العمليه", "تم الاضافة بنجاح");

        //ClearRec();
        //GetAid();
        btnPrintAdd.Visible = btn_Add_new.Visible = true;
        DropDownName.Enabled = false;
        DropAidType.Enabled = false;
        txtvalue.Enabled = false;
        txtlbldate.Enabled = false;
        DropDownpayTaype.Enabled = false;
        DropDownAcount.Enabled = false;
        txtNote.Enabled = false;
        btnSavepop.Visible = false;

        ModalPopupExtender9.Show();

        GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
        UpdatePanel3.Update();
    }

    // private void ClearRec()
    //{
    //    DropDownName.SelectedValue = "-1";
    //    txtlbldate.Text = "";
    //    DropAidType.SelectedValue = "-1";
    //    txtvalue.Text = "";
    //    DropDownpayTaype.SelectedValue = "1";
    //    DropDownAcount.SelectedValue = "1";
    //    txtNote.Text = "";
    //    UpdatePanel5.Update();

    //}

    protected void btnExitpop_Click(object sender, EventArgs e)
    {
        ModalPopupExtender9.Hide();
        clear();
        DropAidType.SelectedValue = "-1";
        txtlbldate.Text = "";
        GetAid();
    }

    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        GetAid();
    }

    protected void GridView3_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        try
        {
            string sSql = "UPDATE Aid SET Beneficiary_No = @Beneficiary_No,Aid_Type = @Aid_Type,Amount = @Amount,Aid_Date = @Aid_Date,Pay_type = @Pay_type,Remarks = @Remarks,Account_Type = @Account_Type,Username = @Username,Last_Update = @Last_Update WHERE Aid_No=@Aid_No";

            SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);
            cmd.Parameters.AddWithValue("@Beneficiary_No", DropDownName.SelectedValue);
            cmd.Parameters.AddWithValue("@Aid_Type", DropAidType.SelectedValue);
            cmd.Parameters.AddWithValue("@Amount", txtvalue.Text);
            cmd.Parameters.AddWithValue("@Aid_Date", txtlbldate.Text);
            cmd.Parameters.AddWithValue("@Pay_type", DropDownpayTaype.SelectedValue);
            cmd.Parameters.AddWithValue("@Account_Type", DropDownAcount.SelectedValue);
            cmd.Parameters.AddWithValue("@Remarks", txtNote.Text);
            cmd.Parameters.AddWithValue("@Username", txtusername.Text);
            cmd.Parameters.AddWithValue("@Last_Update", txtdateenter.Text);

            Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
            GridView3.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
            GetAid();
            Alerts.alertSuccess(Page, "", " تم التعديل  بنجاح");
            ModalPopupExtender9.Hide();
            GetAid();
        }
        catch (Exception x)
        {
            new ExceptionHandler(x);
        }
    }

    private void fillDropNameDetails()
    {
        string fill = "select * from Beneficiary where Status=0";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropNameDetails.DataSource = result.CopyToDataTable();
        DropNameDetails.DataTextField = "Name";
        DropNameDetails.DataValueField = "Beneficiary_No";
        DropNameDetails.DataBind();
        DropNameDetails.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDropAidDetails()
    {
        string fill = "select * from Aid_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropAidDetails.DataSource = result.CopyToDataTable();
        DropAidDetails.DataTextField = "Aid_Desc";
        DropAidDetails.DataValueField = "Aid_Code";
        DropAidDetails.DataBind();
        DropAidDetails.Items.Insert(0, new ListItem("اختر", "-1"));
    }

    private void fillDropPayTaype()
    {
        string fill = "select * from Pay_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropPayTaypeDetails.DataSource = result.CopyToDataTable();
        DropPayTaypeDetails.DataTextField = "Pay_Desc";
        DropPayTaypeDetails.DataValueField = "Pay_Type";
        DropPayTaypeDetails.DataBind();
    }

    private void fillDropAcountTypeDetails()

    {
        string fill = "select * from Account_Types";
        SqlDataAdapter adaptaer = new SqlDataAdapter(fill, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adaptaer);
        DropAcountTypeDetails.DataSource = result.CopyToDataTable();
        DropAcountTypeDetails.DataTextField = "Account_Desc";
        DropAcountTypeDetails.DataValueField = "Account_Type";
        DropAcountTypeDetails.DataBind();
    }

    protected void btnDetails_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Show();
        GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
        fillDropNameDetails();
        fillDropAcountTypeDetails();
        fillDropPayTaype();
        fillDropAidDetails();

        UpdatePanel6.Update();
    }

    protected void btnExitDetails_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        GetAid();
    }

    protected void btnExitAdd_Click(object sender, EventArgs e)
    {
        ModalPopupExtender9.Hide();
        GetAid();
    }

    //private void txtvalueDetails_KeyPress(object sender, KeyPressEventArgs e)
    //{
    //    char ch = e.keychar;
    //    if(ch=46 && txtvalueDetails.Text.IndexOf(',' ! = -1))
    //    {
    //        e.Handled = true;
    //        return;
    //    }
    //    if (! char  is digit(ch) && ch!=8 && ch !=46)
    //            {
    //         e.Handle = true;
    //    }

    //if (!char.IsControl(e.KeyChar)
    //    && !char.IsDigit(e.KeyChar)
    //    && e.KeyChar != '.')
    //{
    //    e.Handled = true;
    //}

    //// only allow one decimal point
    //if (e.KeyChar == '.'
    //    && (sender as TextBox).Text.IndexOf('.') > -1)
    //{
    //    e.Handled = true;
    //}

    protected void btnEdit_Click1(object sender, EventArgs e)
    {
    }

    protected void btnDelete_Click(object sender, EventArgs e)

    {
        string sSql = "UPDATE Aid SET Delete_Flag =1 ,Username =@Username , Last_Update = GetDate() WHERE Aid_No=@Aid_No";

        SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);

        cmd.Parameters.AddWithValue("@Aid_No", HiddenField1_AidNo.Value);
        cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());

        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
        GridView3.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
        GetAid();
        Alerts.alertSuccess(Page, "", " تم الإلغاء بنجاح");
        ModalPopupExtender1.Hide();
        GetAid();
    }

    protected void btnEdit_Click2(object sender, EventArgs e)
    {
        string sSql = "UPDATE Aid SET Beneficiary_No = @Beneficiary_No,Aid_Type = @Aid_Type,Amount = @Amount,Aid_Date = @Aid_Date,"
              + "Pay_type = @Pay_type,Remarks = @Remarks,Account_Type = @Account_Type,Username =@Username  ,"
              + "Last_Update = GetDate() WHERE Aid_No=@Aid_No";

        SqlCommand cmd = new SqlCommand(sSql, Core.DataBase.ConnectionManager.BMP);

        cmd.Parameters.AddWithValue("@Beneficiary_No", DropNameDetails.SelectedValue);
        cmd.Parameters.AddWithValue("@Aid_Type", DropAidDetails.SelectedValue);
        cmd.Parameters.AddWithValue("@Amount", txtvalueDetails.Text);
        cmd.Parameters.AddWithValue("@Aid_Date", DateTime.ParseExact(txtDateAid.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy"));
        cmd.Parameters.AddWithValue("@Pay_type", DropPayTaypeDetails.SelectedValue);
        cmd.Parameters.AddWithValue("@Account_Type", DropAcountTypeDetails.SelectedValue);
        cmd.Parameters.AddWithValue("@Remarks", txtDetails.Text);
        cmd.Parameters.AddWithValue("@Aid_No", HiddenField1_AidNo.Value);
        cmd.Parameters.AddWithValue("@Username", Session["UserName"].ToString());

        Core.DataBase.SqlHelper.ExecuteNonQuery(cmd);
        GridView3.EditIndex = -1; // هيرجع ال رجوع و الحفظ الى وضعيه التعديل
        //GetAid();
        Alerts.alertSuccess(Page, "", " تم التعديل  بنجاح");
        btnEdit.Visible = false;
        btnDelete.Visible = false;
        DropNameDetails.Enabled = false;
        btnprintDetails.Visible = true;
    }

    protected void btnPrintAdd_Click(object sender, EventArgs e)
    {
        // Select From Database
        DataTable dt = new DataTable();

        //string sSql = "select * from vAid where 1=1 and Beneficiary_No ="+ DropDownName.SelectedValue;
        string sSql = "SELECT *  FROM VAid where Aid_No= (select max(Aid_No)  FROM VAid)";

        SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adapter);
        dt = result.CopyToDataTable();
        ReportParameter[] rptParams = new ReportParameter[]
       {
           // new ReportParameter("Beneficiary_No","25")
           // new ReportParameter("Name",txtName.Text)
       };

        try
        {
            GlobalFunction.GenerateTestFile("سند صرف", Server.MapPath("~/Reports/Report_saned.rdlc"), dt, rptParams);
        }
        catch
        {
        }

        GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
        //GlobalFunction.LoadRDLC(Page, "Reports/ReportAid2.rdlc", dt, rptParams);

        ////// reset

        ////ReportViewerAid.Reset();
        ////// DataSource
        ////DataTable dt = Print_Aid();
        ////ReportDataSource rds = new ReportDataSource("DataSet1", dt);
        ////ReportViewerAid.LocalReport.DataSources.Add(rds);
        ////// Path
        ////ReportViewerAid.LocalReport.ReportPath = "Pages/Report.rdlc";

        ////// Parameters
        //////ReportParameter[] rptParams = new ReportParameter[]
        //////{
        //////    new ReportParameter("Name",)
        //////};
        //////ReportViewerAid.LocalReport.SetParameters(rptParams);
        ////// Refresh
        ////ReportViewerAid.LocalReport.Refresh();
    }

    private DataTable Print_Aid()
    {
        try
        {
            string sSql = "select * from Aid ";
            //if (!string.IsNullOrEmpty(AidCode))
            //{
            //    sSql += " and Aid_No=@Aid_No";
            //}
            SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
            //if (!string.IsNullOrEmpty(AidCode))
            //{
            //    adapter.SelectCommand.Parameters.AddWithValue("Aid_No",AidCode );
            //}

            return Core.DataBase.SqlHelper.FindRec(adapter).CopyToDataTable();
        }
        catch (Exception x)
        {
            new ExceptionHandler(x);
            return null;
        }
    }

    protected void btnprintDetails_Click(object sender, EventArgs e)
    {
        // Select From Database
        DataTable dt = new DataTable();
        int Aid_No = Convert.ToInt32(Session["Aid_No"]);
        string sSql = "select * from vAid where Aid_No=" + Aid_No;
        SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
        var result = Core.DataBase.SqlHelper.FindRec(adapter);
        dt = result.CopyToDataTable();
        ReportParameter[] rptParams = new ReportParameter[]
       {
           // new ReportParameter("Name",txtName.Text)
       };

        try
        {
            GlobalFunction.GenerateTestFile("سند صرف", Server.MapPath("~/Reports/Report_saned.rdlc"), dt, rptParams);
        }
        catch
        {
        }
        //  GlobalFunction.LoadRDLC(Page, "Reports/ReportAid2.rdlc", dt, rptParams);
        GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;

        Session["Aid_No"] = "";
    }

    protected void clear()
    {
        DropDownName.Enabled = DropAidType.Enabled = txtvalue.Enabled = txtlbldate.Enabled = DropDownpayTaype.Enabled =
        DropDownAcount.Enabled = txtNote.Enabled = btnSavepop.Visible = true;

        DropDownName.SelectedValue = "-1";
        txtvalue.Text = "";
        //DropAidType.SelectedValue = "-1";
        //txtlbldate.Text = "";
        DropDownpayTaype.SelectedValue = "1";
        DropDownAcount.SelectedValue = "1";
        txtNote.Text = "";
        btn_Add_new.Visible = btnPrintAdd.Visible = false;

        GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
        UpdatePanel3.Update();
    }

    protected void btn_Add_new_Click(object sender, EventArgs e)
    {
        clear();
        ModalPopupExtender9.Show();
        //DropAidType.SelectedValue = "-1";
        //txtlbldate.Text = "";
    }
}