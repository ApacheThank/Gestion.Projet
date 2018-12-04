using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion.Projet.Bean;
using Gestion.Projet.Service;

namespace Gestion.Projet.Mvc.Controllers
{
    public class JalonController : Controller
    {
        // GET: Jalon
        public ActionResult Index(int id)
        {
            List<Jalon> liste_jalons = FactoryServices.createServices().getJalonsByProjet(id);
            return View(liste_jalons);
        }


    }
}