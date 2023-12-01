using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Beneficiary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCharity();
    }
    private void GetCharity()
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

    }
}