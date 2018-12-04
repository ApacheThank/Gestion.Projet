using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestion.Projet.Bean;
using Gestion.Projet.Service;

namespace Gestion.Projet.Control
{
    public partial class JalonControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string nom = Request.QueryString["nom"];
            id_label.InnerText = id;
            projet_trigramme.InnerText += nom;
            int id_projet = Convert.ToInt32(id);
            List<Jalon> jalons = FactoryServices.createServices().getJalonsByProjet(id_projet);
            repeater.DataSource = jalons;
            repeater.DataBind();
        }
    }
}