using DotnetIntro2024.App_Code;
using System;
using System.Data;
using System.Web.UI;

namespace DotnetIntro2024
{
    public partial class Dettagli : System.Web.UI.Page
    {
        DataTable table;
        int index = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string dbPath = Server.MapPath("App_Data/Registro.mdf");
            string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            DbTools dbTools = new DbTools(connStr);

            // Gestisco la data e ora di connessione
            if (Session["OraConnessione"] == null)
            {
                string oraConnessione = DateTime.Now.ToLongTimeString();
                lblConnectionTime.Text = oraConnessione;
                Session["OraConnessione"] = oraConnessione;
            }
            else
            {
                lblConnectionTime.Text = Session["OraConnessione"].ToString();
            }

            if (!Page.IsPostBack)
            {
                string cogn = Request.QueryString["Cognome"];
                string sql = dbTools.GetBaseSelectAllStudents();
                sql += $" AND Cognome='{cogn}'";
                table = dbTools.GetDataTable(sql);
                if (table.Rows.Count > 0)
                {
                    AssignData();
                    if (table.Rows.Count > 1) pnlPrevNext.Visible = true;
                }
                else
                {
                    pnlDatiStudente.Visible = false;
                    pnlNonTrovato.Visible = true;
                }
                ViewState["StudentTable"] = table;
            }
            else
            {
                if (ViewState["StudentTable"] != null) table = (DataTable)ViewState["StudentTable"];
                if (ViewState["index"] != null) index = (int)ViewState["index"];
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            index--;
            AssignData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            AssignData();
        }

        private void AssignData()
        {
            DataRow row = table.Rows[index];
            lblNome.Text = row["Nome"].ToString();
            lblCognome.Text = row["Cognome"].ToString();
            lblClasse.Text = row["Classe"].ToString();
            lblGenere.Text = row["Genere"].ToString();
            lblAnnoNascita.Text = row["AnnoNascita"].ToString();
            btnPrev.Enabled = index > 0;
            btnNext.Enabled = (index < table.Rows.Count - 1);
            ViewState["index"] = index;
        }
    }
}