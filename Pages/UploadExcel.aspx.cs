using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;
using System.IO;
using OfficeOpenXml;

public partial class Pages_UploadExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = "Data Source=.;Initial Catalog=Charity;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ProcessFile(fileUploadFirst, connection);

                ProcessFile(fileUploadSecond, connection);

                BindGridView();

                btnExportToExcel.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void ProcessFile(FileUpload fileUpload, SqlConnection connection)
    {
        if (fileUpload.HasFile)
        {
            string fileName = Path.GetFileName(fileUpload.FileName);
            string path = Server.MapPath(fileName);
            fileUpload.SaveAs(path);

            string excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 8.0";

            using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
            {
                excelConnection.Open();

                string sheetName = "Sheet1$";

                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", excelConnection))
                {
                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (SheetHasRequiredColumns(dt, "Name", "Age", "Email"))
                        {
                            ProcessFirstFile(connection, dt);
                        }
                        else if (SheetHasRequiredColumns(dt, "Address", "Job"))
                        {
                            ProcessSecondFile(connection, dt);
                        }
                    }
                }
            }
        }
    }

    private bool IsRecordExists(SqlConnection connection, string email)
    {
        string query = "SELECT COUNT(*) FROM ExcelData WHERE Email = @Email";
        using (SqlCommand sqlCommand = new SqlCommand(query, connection))
        {
            sqlCommand.Parameters.AddWithValue("@Email", email);
            int count = (int)sqlCommand.ExecuteScalar();
            return count > 0;
        }
    }

    private void BindGridView()
    {
        string sSql = "SELECT * FROM ExcelData";
        SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
        var Result = Core.DataBase.SqlHelper.FindRec(adapter);
        GridView.DataSource = Result.CopyToDataTable();
        GridView.DataBind();
        GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    //private string GetSheetName(OleDbConnection excelConnection)
    //{
    //    DataTable dtSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //    return dtSchema.Rows[0]["TABLE_NAME"].ToString();
    //}

    private bool SheetHasRequiredColumns(DataTable dt, params string[] columnNames)
    {
        foreach (string columnName in columnNames)
        {
            if (!dt.Columns.Contains(columnName))
            {
                return false;
            }
        }
        return true;
    }

    private void ProcessFirstFile(SqlConnection connection, DataTable dt)
    {
        foreach (DataRow row in dt.Rows)
        {
            int user_id;
            if (row["USER_ID"] != DBNull.Value && int.TryParse(row["USER_ID"].ToString(), out user_id))
            {
            }
            else
            {
                user_id = 0;
            }

            string name = row["Name"] != DBNull.Value ? row["Name"].ToString() : string.Empty;

            int age;
            if (row["Age"] != DBNull.Value && int.TryParse(row["Age"].ToString(), out age))
            {
            }
            else
            {
                age = 0;
            }

            string email = row["Email"] != DBNull.Value ? row["Email"].ToString() : string.Empty;

            if (!IsRecordExists(connection, email))
            {
                if (user_id != 0 && name != string.Empty && age != 0 && email != string.Empty)
                {
                    string query = "INSERT INTO ExcelData (USER_ID, Name, Age, Email) VALUES (@USER_ID, @Name, @Age, @Email)";
                    using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@USER_ID", user_id);
                        sqlCommand.Parameters.AddWithValue("@Name", name);
                        sqlCommand.Parameters.AddWithValue("@Age", age);
                        sqlCommand.Parameters.AddWithValue("@Email", email);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    private void ProcessSecondFile(SqlConnection connection, DataTable dt)
    {
        foreach (DataRow row in dt.Rows)
        {
            int user_id;
            if (row["USER_ID"] != DBNull.Value && int.TryParse(row["USER_ID"].ToString(), out user_id))
            {
            }
            else
            {
                user_id = 0;
            }

            string address = row["Address"] != DBNull.Value ? row["Address"].ToString() : string.Empty;
            string job = row["Job"] != DBNull.Value ? row["Job"].ToString() : string.Empty;

            if (user_id != 0)
            {
                UpdateExistingRecord(connection, user_id, address, job);
            }
        }
    }

    private void UpdateExistingRecord(SqlConnection connection, int user_id, string address, string job)
    {
        string query = "UPDATE ExcelData SET Address = @Address, Job = @Job WHERE USER_ID = @USER_ID";
        using (SqlCommand sqlCommand = new SqlCommand(query, connection))
        {
            sqlCommand.Parameters.AddWithValue("@Address", address);
            sqlCommand.Parameters.AddWithValue("@Job", job);
            sqlCommand.Parameters.AddWithValue("@USER_ID", user_id);

            sqlCommand.ExecuteNonQuery();
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dataTable = GetDataFromDatabase();

            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dataTable.Columns[i - 1].ColumnName;
                }

                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=ExportedData.xlsx");
                Response.BinaryWrite(package.GetAsByteArray());
                Response.End();
            }
        }
        catch (Exception ex)
        {
        }
    }

    private DataTable GetDataFromDatabase()
    {
        DataTable dataTable = new DataTable();

        using (var connection = new SqlConnection("Data Source =.; Initial Catalog = Charity; Integrated Security = True"))
        {
            connection.Open();

            using (var command = new SqlCommand("SELECT Name, Age, Email, Address, Job FROM ExcelData", connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
        }

        return dataTable;
    }
}