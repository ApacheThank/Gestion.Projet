using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestion.Projet.Bean;
using Gestion.Projet.Service;

namespace Gestion.Projet.Control
{
    public partial class Projet: System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Project> projets = FactoryServices.createServices().getProjets();
            repeater.DataSource = projets;
            repeater.DataBind();
        }
    }
}