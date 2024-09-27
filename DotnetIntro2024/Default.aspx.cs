using DotnetIntro2024.App_Code;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotnetIntro2024
{
    public partial class Default : System.Web.UI.Page
    {
        DbTools dbTools;

        protected void Page_Load(object sender, EventArgs e)
        {
            string dbPath = Server.MapPath("App_Data/Registro.mdf");
            string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            dbTools = new DbTools(connStr);
            if (!Page.IsPostBack)
            {
                // se è la prima volta che apro la pagina
                // lblMessaggio.Text = "Introduci il tuo UserName e Password...";

                // Riempio la combo
                cmbClasse.DataValueField = "Id";
                cmbClasse.DataTextField = "Classe";
                cmbClasse.DataSource = dbTools.GetDataTable("SELECT * FROM Classi ORDER BY Classe");
                cmbClasse.DataBind();
                cmbClasse.Items.Insert(0, "- TUTTE -");

                // Riempio la griglia
                string sql = getBaseSelectAllStudents();
                gridStudenti.DataSource = dbTools.GetDataTable(sql);
                gridStudenti.DataBind();
            }
            else
            {
                // questa parte viene eseguita le volte successive
                // lblMessaggio.Text = $"Benvenuto {txtUsername.Text}";
            }
        }

        private string getBaseSelectAllStudents()
        {
            return @"SELECT Cognome, Nome, Classe, AnnoNascita, Genere FROM Studenti, Classi
                                WHERE Studenti.Id_Classe = Classi.Id";
        }

        private void showFilteredStudents(int idClasse, string gender)
        {
            string sql = getBaseSelectAllStudents();
            if (idClasse > 0)
            {
                sql += " AND Classi.ID=" + cmbClasse.SelectedValue;
            }
            if (gender != "ALL")
            {
                sql += $" AND Genere='{gender}'";
            }
            gridStudenti.DataSource = dbTools.GetDataTable(sql);
            gridStudenti.DataBind();
        }

        protected void cmbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gender = rbFemale.Checked ? "F" : rbMale.Checked ? "M" : "ALL";
            showFilteredStudents(cmbClasse.SelectedIndex, gender);
        }

        protected void rbGender_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            showFilteredStudents(cmbClasse.SelectedIndex, rb.Text);
        }
    }
}