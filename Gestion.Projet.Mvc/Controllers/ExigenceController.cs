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
    public class ExigenceController : Controller
    {
        // GET: Exigence
        public ActionResult Index(int id)
        {
            if (id != 0 && id != null)
            {
                Session["projet"] = id;
                if (TempData["alert"] != null && TempData["result"] != null)
                {
                    ViewBag.Alert = TempData["alert"].ToString();
                    ViewBag.Result = TempData["result"].ToString();
                }

            }
            else
            {
                id = Convert.ToInt32(Session["projet"]);

            }
            List<Exigence> exigences = FactoryServices.createServices().getExigencesByProjet(id);
            ViewBag.Exigences = exigences;
            return View(exigences);
        }

        // GET: Exigence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Exigence/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exigence/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            int id_projet = Convert.ToInt32(Session["projet"]);
            if (ModelState.IsValid)
            {

                DateTime date_livraison = Convert.ToDateTime(collection["date_livraison"]);
                int type = Convert.ToInt32(collection.Get("type"));
                string type_string;
                string libelle;
                if ( type == 0)
                {
                    libelle = collection.Get("libelle");
                    type_string = "Non fonctionnelle";
                } else
                {
                    libelle = "";
                    type_string = "Fonctionnelle";
                }
                bool res = FactoryServices.createServices().insertExigence(type_string, libelle, id_projet);
                if (res == true)
                {
                    TempData["alert"] = "succes";
                    TempData["result"] = "Exigence a été crée";
                    //return RedirectToAction("Index", "Jalon");
                }
                else
                {
                    TempData["alert"] = "danger";
                    TempData["result"] = "Une erreur est survenue lors de l'ajout";
                }
            }
            return RedirectToAction("Index", "Exigence", new { @id = id_projet });
        }

        // GET: Exigence/Edit/5
        public ActionResult Edit(int id)
        {
            Exigence exigence = FactoryServices.createServices().getExigenceById(id);
            return View(exigence);
        }

        // POST: Exigence/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            int id_projet = Convert.ToInt32(Session["projet"]);
            if (ModelState.IsValid)
            {

                DateTime date_livraison = Convert.ToDateTime(collection["date_livraison"]);
                int type = Convert.ToInt32(collection.Get("type"));
                string type_string;
                string libelle;
                if (type == 0)
                {
                    libelle = collection.Get("libelle");
                    type_string = "Non fonctionnelle";
                }
                else
                {
                    libelle = "";
                    type_string = "Fonctionnelle";
                }
                Debug.Write(type_string);
                Debug.Write(libelle);
                Exigence exigence = FactoryServices.createServices().updateExigence(id, type_string, libelle, id_projet);
                if (exigence.Id !=0)
                {
                    TempData["alert"] = "succes";
                    TempData["result"] = "Exigence modifiée";
                    //return RedirectToAction("Index", "Jalon");
                }
                else
                {
                    TempData["alert"] = "danger";
                    TempData["result"] = "Une erreur est survenue lors de modification";
                }
            }
            return RedirectToAction("Index", "Exigence", new { @id = id_projet });
        }

        // GET: Exigence/Delete/5
        public ActionResult Delete(int id)
        {
            int id_projet = Convert.ToInt32(Session["projet"]);
            bool res = FactoryServices.createServices().deleteExigence(id);
            if (res)
            {
                TempData["alert"] = "success";
                TempData["result"] = "Exigence supprimé";
            }
            else
            {
                TempData["alert"] = "danger";
                TempData["result"] = "Une erreur est survenue lors de suppression";
            }

            return RedirectToAction("Index", "Exigence", new { @id = id_projet });
        }

        // POST: Exigence/Delete/5
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
