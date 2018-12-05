using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gestion.Projet.Bean;
using Gestion.Projet.Service;

namespace Gestion.Projet.Mvc.Controllers
{
    public class TacheController : Controller
    {
        // GET: Tache
        public ActionResult Index(int id)
        {
            if (id != 0 && id != null)
            {
                Session["jalon"] = FactoryServices.createServices().getJalonById(id);
                if (TempData["alert"] != null && TempData["result"] != null)
                {
                    ViewBag.Alert = TempData["alert"].ToString();
                    ViewBag.Result = TempData["result"].ToString();
                }

            }
            else
            {
                Jalon jalon = Session["jalon"] as Jalon;
                id = jalon.Id;
            }
            List<Tache> liste_taches = FactoryServices.createServices().getTachesByJalon(id);
            List<Utilisateur> utilisateurs = FactoryServices.createServices().getUtilisateurs();
            ViewBag.Utilisateurs = utilisateurs;
            return View(liste_taches);
        }

        // GET: Tache/Details/5
        public ActionResult Details(int id)
        {
            Tache tache = FactoryServices.createServices().getTacheById(id);
            return View(tache);
        }

        // GET: Tache/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tache/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Jalon jalon = Session["jalon"] as Jalon;
            int id_jalon = jalon.Id;
            if (ModelState.IsValid)
            {
                string libelle = collection["libelle"];
                string description = collection["description"];
                int duree = Convert.ToInt32(collection["duree"]);
                int tache_precedente = Convert.ToInt32(collection.Get("tache_precedente"));
                int id_responsable;

                DateTime date_debut = Convert.ToDateTime(collection["date_debut"]);
                if (collection.Get("ids_users") == "" || collection.Get("ids_users") == null)
                {
                    string user_trigramme = collection["user_tri"];
                    Utilisateur utilisateur = FactoryServices.createServices().insertUtilisateur(user_trigramme);
                    id_responsable = utilisateur.Id;
                }
                else
                {
                    id_responsable = Convert.ToInt32(collection.Get("ids_users"));
                }
                int avancement = 0; // tâche non démarré
                bool res = FactoryServices.createServices().insertTache(libelle, description, date_debut, duree, tache_precedente, id_responsable, id_jalon, avancement);

                if (res == true)
                {
                    TempData["alert"] = "succes";
                    TempData["result"] = "Nouvelle tâche ajoutée";
                    //return RedirectToAction("Index", "Jalon");
                }
                else
                {
                    TempData["alert"] = "danger";
                    TempData["result"] = "Une erreur est survenue lors de l'ajout";
                }
            }
            return RedirectToAction("Index", "Tache", new { @id = id_jalon });
        }

        // GET: Tache/Edit/5
        public ActionResult Edit(int id)
        {
            Project projet = Session["projet"] as Project;
            Jalon jalon = Session["jalon"] as Jalon;
            int id_projet = projet.Id;
            int id_jalon = jalon.Id;
            List<Utilisateur> utilisateurs = FactoryServices.createServices().getUtilisateurs();
            List<Exigence> exigences = FactoryServices.createServices().getExigencesByProjet(id_projet);
            List<Tache> taches = FactoryServices.createServices().getTachesByJalon(id_jalon);
            Tache tache = FactoryServices.createServices().getTacheById(id);
            ViewBag.Utilisateurs = utilisateurs;
            Tuple<List<Utilisateur>, List<Tache>, List<Exigence>,Tache> tuple = new Tuple<List<Utilisateur>, List<Tache>, List<Exigence>,Tache>
                (utilisateurs, taches, exigences,tache);
            return View(tuple);
        }


        // POST: Tache/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Jalon jalon = Session["jalon"] as Jalon;
            int id_jalon = jalon.Id;

            if (ModelState.IsValid)
            {
                string libelle = collection["libelle"];
                string description = collection["description"];
                int duree = Convert.ToInt32(collection["duree"]);
                int id_tache_precente = Convert.ToInt32(collection.Get("tache_precedente"));
                int avancement = Convert.ToInt32(collection.Get("avancement"));
                int id_responsable;

                DateTime date_debut = Convert.ToDateTime(collection["date_debut"]);
                if (collection.Get("ids_users") == "" || collection.Get("ids_users") == null)
                {
                    string user_trigramme = collection["user_tri"];
                    Utilisateur utilisateur = FactoryServices.createServices().insertUtilisateur(user_trigramme);
                    id_responsable = utilisateur.Id;
                }
                else
                {
                    id_responsable = Convert.ToInt32(collection.Get("ids_users"));
                }

                DateTime date_reelle_debut;
                if (collection.Get("date_reelle") == "" || collection.Get("date_reelle") == null)
                {
                    date_reelle_debut = Convert.ToDateTime("");
                }
                else { date_reelle_debut = Convert.ToDateTime(collection.Get("date_reelle")); }
                Tache tache = FactoryServices.createServices().updateTache(id, libelle, description, date_debut, date_reelle_debut, duree, id_tache_precente, id_responsable, id_jalon, avancement);
                if (tache.Id != 0)
                {
                    TempData["alert"] = "succes";
                    TempData["result"] = "Jalon a été modifé";
                    //return RedirectToAction("Index", "Jalon");
                }
                else
                {
                    TempData["alert"] = "danger";
                    TempData["result"] = "Une erreur est survenue lors de modification";
                }
            }
            return RedirectToAction("Index", "Tache", new { @id = id_jalon });
        }

        // GET: Tache/Delete/5
        public ActionResult Delete(int id)
        {
            bool res = FactoryServices.createServices().deleteTache(id);
            if (res)
            {
                TempData["alert"] = "success";
                TempData["result"] = "Jalon supprimé";
            }
            else
            {
                TempData["alert"] = "danger";
                TempData["result"] = "Une erreur est survenue lors de suppression";
            }

            return RedirectToAction("Index");
        }

        // POST: Tache/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
