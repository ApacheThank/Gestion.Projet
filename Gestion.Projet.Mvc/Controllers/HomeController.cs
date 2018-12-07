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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["alert"] != null && TempData["result"] != null)
            {
                ViewBag.Alert = TempData["alert"].ToString();
                ViewBag.Result = TempData["result"].ToString();
            }
            List<Project> liste_projets = FactoryServices.createServices().getProjets();
            List<Utilisateur> utilisateurs = FactoryServices.createServices().getUtilisateurs();
            ViewBag.Utilisateurs = utilisateurs;
            return View(liste_projets);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Delete(int id)
        {
            bool res = FactoryServices.createServices().deleteProjet(id);
            if (res)
            {
                TempData["alert"] = "success";
                TempData["result"] = "Projet supprimé";
            }
            else
            {
                TempData["alert"] = "danger";
                TempData["result"] = "Une erreur est survenue lors de suppression";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Project projet = FactoryServices.createServices().getProjectById(id);
            List<Utilisateur> utilisateurs = FactoryServices.createServices().getUtilisateurs();
            ViewBag.Utilisateurs = utilisateurs;
            return View("Edit");
        }

        // POST: Cabinet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string trigramme = collection["trigramme"];
                int id_responsable;
                // si on séléctionne un responsable de la liste
                if (collection.Get("ids_users") == "" || collection.Get("ids_users") == null)
                {
                    string user_trigramme = collection["user_tri"];
                    Utilisateur utilisateur = FactoryServices.createServices().insertUtilisateur(user_trigramme);
                    id_responsable = utilisateur.Id;
                }
                else
                {
                    // si non on crée un nouveau responsable et l'ajoute au nouveau
                    id_responsable = Convert.ToInt32(collection.Get("ids_users"));
                }
                
                Project projet = FactoryServices.createServices().updateProjet(id, trigramme, id_responsable);
                if (projet.Id != 0)
                {
                    TempData["alert"] = "succes";
                    TempData["result"] = "Projet a été modifé";
                    //return RedirectToAction("Index", "Jalon");
                }
                else
                {
                    TempData["alert"] = "danger";
                    TempData["result"] = "Une erreur est survenue lors de modification";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("About");
            }
        }
        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    string trigramme = collection["trigramme"];
                    int id_responsable;
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

                    bool res = FactoryServices.createServices().insertProjet(trigramme, id_responsable);
                    if (res == true)
                    {
                        TempData["alert"] = "succes";
                        TempData["result"] = "Projet a été crée";
                        //return RedirectToAction("Index", "Jalon");
                    }
                    else
                    {
                        TempData["alert"] = "danger";
                        TempData["result"] = "Une erreur est survenue lors de l'ajout";
                    }
                }
                //ViewBag.Alert = "succes";
                //ViewBag.Result = "Medecin a été ajouté";
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                //ViewBag.Alert = "danger";
                //ViewBag.Result = "Une erreur est survenue lors de l'ajout";
                return RedirectToAction("About", "Home");
            }
        }
    }
}