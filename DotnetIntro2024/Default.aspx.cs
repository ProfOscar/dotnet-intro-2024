using DotnetIntro2024.App_Code;
using System;
using System.Web.UI;

namespace DotnetIntro2024
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dbPath = Server.MapPath("App_Data/Registro.mdf");
            string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            DbTools dbTools = new DbTools(connStr);
            if (!Page.IsPostBack)
            {
                // se è la prima volta che apro la pagina
                // lblMessaggio.Text = "Introduci il tuo UserName e Password...";
                string sql = @"SELECT Cognome, Nome, Classe, AnnoNascita, Genere FROM Studenti, Classi
                                WHERE Studenti.Id_Classe = Classi.Id";
                gridStudenti.DataSource = dbTools.GetDataTable(sql);
                gridStudenti.DataBind();
            }
            else
            {
                // questa parte viene eseguita le volte successive
                // lblMessaggio.Text = $"Benvenuto {txtUsername.Text}";
            }
        }
    }
}