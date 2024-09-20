using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotnetIntro2024
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbPath = Server.MapPath("App_Data/Registro.mdf");
            string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            if (!Page.IsPostBack)
            {
                // se è la prima volta che apro la pagina
                // lblMessaggio.Text = "Introduci il tuo UserName e Password...";
                string sql = "SELECT * FROM Studenti";
                using (SqlConnection sqlConnection = new SqlConnection(connStr))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            gridStudenti.DataSource = dataTable;
                            gridStudenti.DataBind();
                        }
                    }
                }
            }
            else
            {
                // questa parte viene eseguita le volte successive
                // lblMessaggio.Text = $"Benvenuto {txtUsername.Text}";
            }
        }
    }
}