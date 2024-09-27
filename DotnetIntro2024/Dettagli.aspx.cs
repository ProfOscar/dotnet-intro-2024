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
        int index = 0;

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
                    DataRow row = table.Rows[index];
                    lblNome.Text = row["Nome"].ToString();
                    lblCognome.Text = row["Cognome"].ToString();
                    lblClasse.Text = row["Classe"].ToString();
                    lblGenere.Text = row["Genere"].ToString();
                    lblAnnoNascita.Text = row["AnnoNascita"].ToString();
                    if (table.Rows.Count > 1) pnlPrevNext.Visible = true;
                }
                else
                {
                    pnlDatiStudente.Visible = false;
                    pnlNonTrovato.Visible = true;
                }
            }
            else
            {
                if(ViewState["index"] != null) index = (int)ViewState["index"];
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            ViewState["index"] = index;
        }
    }
}