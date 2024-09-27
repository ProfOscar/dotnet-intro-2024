using DotnetIntro2024.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotnetIntro2024
{
    public partial class Dettagli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbPath = Server.MapPath("App_Data/Registro.mdf");
            string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            DbTools dbTools = new DbTools(connStr);
            if (!Page.IsPostBack)
            {
                string cogn = Request.QueryString["Cognome"];
                string sql = dbTools.GetBaseSelectAllStudents();
                sql += $" AND Cognome='{cogn}'";
                DataTable table = dbTools.GetDataTable(sql);
                if (table.Rows.Count > 0)
                {
                    lblNome.Text = table.Rows[0]["Nome"].ToString();
                    lblCognome.Text = table.Rows[0]["Cognome"].ToString();
                    lblClasse.Text = table.Rows[0]["Classe"].ToString();
                    lblGenere.Text = table.Rows[0]["Genere"].ToString();
                    lblAnnoNascita.Text = table.Rows[0]["AnnoNascita"].ToString();
                }
                else
                {
                    pnlDatiStudente.Visible = false;
                    pnlNonTrovato.Visible = true;
                }
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}