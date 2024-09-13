using System;
using System.Collections.Generic;
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
            if(!Page.IsPostBack)
            {
                // se è la prima volta che apro la pagina
                lblMessaggio.Text = "Introduci il tuo UserName e Password...";
            }
            else
            {
                // questa parte viene eseguita le volte successive
                lblMessaggio.Text = $"Benvenuto {txtUsername.Text}";
            }
        }
    }
}