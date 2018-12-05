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
    public class JalonController : Controller
    {
        // GET: Jalon
        public ActionResult Index(int id)
        {
            if(id != 0 && id != null)
            {
                Session["projet"] = FactoryServices.createServices().getProjectById(id);
                if (TempData["alert"] != null && TempData["result"] != null)
                {
                    ViewBag.Alert = TempData["alert"].ToString();
                    ViewBag.Result = TempData["result"].ToString();
                }

            } else
            {
                Project projet = Session["projet"] as Project;
                id = projet.Id;
                
            }
            List<Jalon> liste_jalons = FactoryServices.createServices().getJalonsByProjet(id);
            List<Utilisateur> utilisateurs = FactoryServices.createServices().getUtilisateurs();
            ViewBag.Utilisateurs = utilisateurs;
            return View(liste_jalons);
        }


        // POST: Jalon/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Project projet = Session["projet"] as Project;
            int id_projet = projet.Id;
            if (ModelState.IsValid)
            {
                string libelle = collection["libelle"];
                int id_responsable;

                DateTime date_livraison = Convert.ToDateTime(collection["date_livraison"]);
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

                bool res = FactoryServices.createServices().insertJalon(libelle, date_livraison, id_projet, id_responsable);

                if (res == true)
                {
                    TempData["alert"] = "succes";
                    TempData["result"] = "Jalon a été crée";
                    //return RedirectToAction("Index", "Jalon");
                } else
                {
                    TempData["alert"] = "danger";
                    TempData["result"] = "Une erreur est survenue lors de l'ajout";
                }       
            }
            return RedirectToAction("Index", "Jalon", new { @id = id_projet });
        }

        public ActionResult Edit(int id)
        {
            Jalon jalon = FactoryServices.createServices().getJalonById(id);
            List<Utilisateur> utilisateurs = FactoryServices.createServices().getUtilisateurs();
            ViewBag.Utilisateurs = utilisateurs;
            return View("Edit");
        }

        // POST: Cabinet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Project projet = Session["projet"] as Project;
            int id_projet = projet.Id;
            
            if (ModelState.IsValid)
            {
                string libelle = collection["libelle"];
                int id_responsable;

                DateTime date_livraison = Convert.ToDateTime(collection["date_livraison"]);
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

                DateTime date_reelle;
                if (collection.Get("date_reelle") == "" || collection.Get("date_reelle") == null)
                {
                     date_reelle = Convert.ToDateTime("");
                } else {  date_reelle = Convert.ToDateTime(collection.Get("date_reelle")); }
                Jalon jalon = FactoryServices.createServices().updateJalon(id, libelle, date_livraison, date_reelle, id_projet, id_responsable);
                if (jalon.Id!=0)
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
            return RedirectToAction("Index", "Jalon", new { @id = id_projet });
        }


        public ActionResult Delete(int id)
        {
            bool res = FactoryServices.createServices().deleteJalon(id);
            if (res)
            {
                TempData["alert"] = "success";
                TempData["result"] = "Jalon supprimé";
            } else
            {
                TempData["alert"] = "danger";
                TempData["result"] = "Une erreur est survenue lors de suppression";
            }
            
            return RedirectToAction("Index");
        }
    }
}