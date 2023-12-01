using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

public partial class Pages_task2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindGridView();
    }

    protected void Btn_export_CSV(object sender, EventArgs e)
    {
        ExportData("ExportedData.csv", "~");
    }

    protected void Btn_export_TextFile(object sender, EventArgs e)
    {
        ExportData("ExportedData.txt", "|");
    }

    private void ExportData(string fileName, string delimiter)
    {
        try
        {
            string connectionString = "Data Source=.;Initial Catalog=Charity;Integrated Security=True";

            string filePath = @"D:\Charity\Source_old\CSV\" + fileName;

            ExportAIDData(filePath, connectionString, delimiter);

            Response.Clear();
            Response.ContentType = GetContentType(fileName);
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.TransmitFile(filePath);
            Response.End();
        }
        catch (Exception ex)
        {
        }
    }

    private string GetContentType(string fileName)
    {
        switch (Path.GetExtension(fileName).ToLower())
        {
            case ".csv":
                return "text/csv";

            case ".txt":
                return "text/plain";

            default:
                return "application/octet-stream";
        }
    }

    private void ExportAIDData(string filePath, string connectionString, string delimiter)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ExportAIDData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter filePathParam = new SqlParameter("@FilePath", SqlDbType.NVarChar, 4000);
                    filePathParam.Value = filePath;
                    command.Parameters.Add(filePathParam);

                    SqlParameter delimiterParam = new SqlParameter("@Delimiter", SqlDbType.NVarChar, 10);
                    delimiterParam.Value = delimiter;
                    command.Parameters.Add(delimiterParam);

                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void BindGridView()
    {
        string sSql = "SELECT * FROM Aid";
        SqlDataAdapter adapter = new SqlDataAdapter(sSql, Core.DataBase.ConnectionManager.BMP);
        var Result = Core.DataBase.SqlHelper.FindRec(adapter);
        GridView.DataSource = Result.CopyToDataTable();
        GridView.DataBind();
        GridView.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void btnTxtfileUpload_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionString = "Data Source=.;Initial Catalog=Charity;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ProcessFile(TxtfileUpload, connection);
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
            try
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string path = Server.MapPath(fileName);
                fileUpload.SaveAs(path);

                string[] rows = File.ReadAllLines(path);

                foreach (string row in rows)
                {
                    InsertRowIntoDatabase(row, path, connection);

                    ProcessRawData(row, connection);
                }
            }
            catch (Exception ex)
            {
            }
        }
        else
        {
        }
    }

    private void InsertRowIntoDatabase(string rowData, string filePath, SqlConnection connection)
    {
        try
        {
            string query = "INSERT INTO RawDataTxtFile (RowData, FilePath) VALUES (@RowData, @FilePath)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RowData", rowData.Replace("~", "|"));
                command.Parameters.AddWithValue("@FilePath", filePath);

                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void ProcessRawData(string rowData, SqlConnection connection)
    {
        try
        {
            using (SqlCommand command = new SqlCommand("ProcessRawData", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@RowData", rowData);

                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Error processing raw data: " + ex.Message);
        }
    }
}