using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult Index(int mode,int id)
        {
            List<Tache> liste_taches;
            int id_projet = Convert.ToInt32(Session["projet"]);
            // on fait la requête selon le menu selectionné si le paramètre passe est 1 alors ce sont les tâches de l'exigence
            if (mode == 1)
            {
                ViewBag.Title = "Liste des tâches de l'exigence";
                Session["exigence"] = id;
                liste_taches = FactoryServices.createServices().getTachesByExigence(id);
            }
            else
            {
                ViewBag.Title = "Liste des tâches du jalon";
                Session.Remove("exigence");
                // sinon c'est l'affichage par le jalon
                if (id != 0 && id != null)
                {
                    Session["jalon"] = id;
                }
                else
                {
                    id = Convert.ToInt32(Session["jalon"]);
                }
                liste_taches = FactoryServices.createServices().getTachesByJalon(id);
                List<Exigence> exigences = FactoryServices.createServices().getExigencesByProjet(id_projet);
                ViewBag.Exigences = exigences;

            }
            if (TempData["alert"] != null && TempData["result"] != null)
            {
                ViewBag.Alert = TempData["alert"].ToString();
                ViewBag.Result = TempData["result"].ToString();
            }
            
            List<Utilisateur> utilisateurs = FactoryServices.createServices().getUtilisateurs();
            
            List<Tache> taches = FactoryServices.createServices().getTachesByProjet(id_projet);
            ViewBag.Utilisateurs = utilisateurs;
            ViewBag.Taches = taches;
            return View(liste_taches);
        }

        // GET: Tache/Details/5
        public ActionResult Details(int id)
        {
            Tache tache = FactoryServices.createServices().getTacheById(id);
            List<Exigence> exigences = FactoryServices.createServices().getExigencesByTache(id);
            ViewBag.Exigences = exigences;
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
            int id_jalon = Convert.ToInt32(Session["jalon"]);
            int mode = 2;
            int id_redirect = id_jalon;
            if (ModelState.IsValid)
            {
                string libelle = collection["libelle"];
                string description = collection["description"];
                int duree = Convert.ToInt32(collection["duree"]);
                int tache_precedente = Convert.ToInt32(collection.Get("tache_precedente"));
                int id_responsable;
                string res_chk_exigence = collection["checkbox_exigence"];
                string res_chk_new = collection["checkbox_new"];

                DateTime date_debut = Convert.ToDateTime(collection["date_debut"]);
                if (res_chk_new == "on")
                {
                    string user_trigramme = collection["user_tri"];
                    Utilisateur utilisateur = FactoryServices.createServices().insertUtilisateur(user_trigramme);
                    id_responsable = utilisateur.Id;
                }
                else
                {
                    id_responsable = Convert.ToInt32(collection.Get("ids_users"));
                }
                int avancement = 0; // tâche non démarré par défaut
                Tache tache= FactoryServices.createServices().insertTache(libelle, description, date_debut, duree, tache_precedente, id_responsable, id_jalon, avancement);
                int id_exigence = 0;
                if (Session["exigence"] != null)
                {
                    id_exigence = Convert.ToInt32(Session["exigence"]);
                    id_redirect = id_exigence;
                    mode = 1;

                }
                else
                {
                    if (res_chk_exigence == "on")
                    {
                        id_exigence = Convert.ToInt32(collection.Get("ids_exigences"));
                    }
                }
                if(id_exigence != 0)
                {
                    bool res = FactoryServices.createServices().insertAssoc(id_exigence, tache.Id);
                }

                if (tache.Id != 0)
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
            return RedirectToAction("Index", "Tache", new { @mode = mode, @id = id_redirect });
        }

        // GET: Tache/Edit/5
        public ActionResult Edit(int id)
        {
            int id_projet = Convert.ToInt32(Session["projet"]);
            int id_jalon = Convert.ToInt32(Session["jalon"]);
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
            int id_jalon = Convert.ToInt32(Session["jalon"]);
            int mode = 2;
            int id_redirect = id_jalon;

            if (ModelState.IsValid)
            {
                string libelle = collection["libelle"];
                string description = collection["description"];
                int duree = Convert.ToInt32(collection["duree"]);
                int id_tache_precente = Convert.ToInt32(collection.Get("tache_precedente"));
                int avancement = Convert.ToInt32(collection.Get("avancement"));
                int id_responsable;
                string res_chk_exigence = collection["checkbox_exigence"];

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
                else {
                    date_reelle_debut = Convert.ToDateTime(collection.Get("date_reelle"));
                    if (avancement == 0)
                    {
                        avancement = 1; // on considère que dès qu'on a une date réelle la tâche est en cours
                    }
                }
                int id_exigence = 0;
                if (Session["exigence"] != null)
                {
                    id_exigence = Convert.ToInt32(Session["exigence"]);
                    id_redirect = id_exigence;
                    mode = 1;

                }
                else
                {
                    if (res_chk_exigence == "on")
                    {
                        id_exigence = Convert.ToInt32(collection.Get("ids_exigences"));
                    }
                }
                
                Tache tache = FactoryServices.createServices().updateTache(id, libelle, description, date_debut, date_reelle_debut, duree, id_tache_precente, id_responsable, id_jalon, avancement);
                int id_tache = tache.Id;
                if (id_exigence != 0)
                {
                    Debug.Write("Id exigence ---->");
                    Debug.Write(id_exigence);
                    Debug.Write("Id tache ---->");
                    Debug.Write(id_tache);
                    bool res = FactoryServices.createServices().insertAssoc(id_exigence,id_tache);
                }
                if (tache.Id != 0)
                {
                    TempData["alert"] = "succes";
                    TempData["result"] = "Tâche a été modifé";
                    //return RedirectToAction("Index", "Jalon");
                }
                else
                {
                    TempData["alert"] = "danger";
                    TempData["result"] = "Une erreur est survenue lors de modification";
                }
            }
            return RedirectToAction("Index", "Tache", new { @mode = mode, @id = id_redirect });
        }

        // GET: Tache/Delete/5
        public ActionResult Delete(int id)
        {
            int id_jalon = Convert.ToInt32(Session["jalon"]);
            bool res = FactoryServices.createServices().deleteTache(id);
            if (res)
            {
                TempData["alert"] = "success";
                TempData["result"] = "Tâche supprimé";
            }
            else
            {
                TempData["alert"] = "danger";
                TempData["result"] = "Une erreur est survenue lors de suppression";
            }

            return RedirectToAction("Index", "Tache", new { @id = id_jalon });
        }

    }
}
