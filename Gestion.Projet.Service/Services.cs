using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;
using Gestion.Projet.ServiceDA;

namespace Gestion.Projet.Service
{
    public class Services: ServicesInterface
    {
        #region Projet
        public List<Project> getProjets()
        {
            return FactoryServicesDA.createProjectServices().getProjets();
        }

        public Project getProjectById(int id)
        {
            return FactoryServicesDA.createProjectServices().getProjectById(id);
        }

        public bool deleteProjet(int id)
        {
            return FactoryServicesDA.createProjectServices().deleteProjet(id);
        }

        public Project updateProjet(int id, string trigramme, int id_utilisateur)
        {
            return FactoryServicesDA.createProjectServices().updateProjet(id, trigramme, id_utilisateur);
        }

        public bool insertProjet(string trigramme, int id_utilisateur)
        {
            return FactoryServicesDA.createProjectServices().insertProjet(trigramme, id_utilisateur);
        }

        #endregion
        #region Utilisateur
        public List<Utilisateur> getUtilisateurs()
        {
            return FactoryServicesDA.createUtilisateurServices().getUtilisateurs();
        }

        public Utilisateur getUtilisateurById(int id)
        {
            return FactoryServicesDA.createUtilisateurServices().getUtilisateurById(id);
        }

        public bool insertUtilisateur(string trigramme)
        {
            return FactoryServicesDA.createUtilisateurServices().insertUtilisateur(trigramme);
        }

        #endregion
        #region Jalon
        public List<Jalon> getJalonsByProjet(int id_projet)
        {
            return FactoryServicesDA.createJalonServices().getJalonsByProjet(id_projet);
        }

        public List<Jalon> getJalonsByResponsable(int id_responsable)
        {
            return FactoryServicesDA.createJalonServices().getJalonsByResponsable(id_responsable);
        }

        public Jalon getJalonById(int id)
        {
            return FactoryServicesDA.createJalonServices().getJalonById(id);
        }

        public bool deleteJalon(int id)
        {
            return FactoryServicesDA.createJalonServices().deleteJalon(id);
        }

        public Jalon updateJalon(int id, string libelle, DateTime date_livraison, DateTime date_reelle, int id_projet, int id_responsable)
        {
            Jalon jalon = FactoryServicesDA.createJalonServices().updateJalon(id, libelle, date_livraison, date_reelle, id_projet, id_responsable);
            return jalon;
        }

        public bool insertProjet(string libelle, DateTime date_livraison, DateTime date_reelle, int id_projet, int id_responsable)
        {
            bool res = FactoryServicesDA.createJalonServices().insertProjet(libelle, date_livraison, date_reelle, id_projet, id_responsable);
            return res;
        }

        #endregion
        #region Tache

        public List<Tache> getTachesByJalon(int id_jalon)
        {
            return FactoryServicesDA.createTacheServices().getTachesByJalon(id_jalon);
        }

        public Tache getTacheById(int id)
        {
            return FactoryServicesDA.createTacheServices().getTacheById(id);
        }

        public bool deleteTache(int id)
        {
            return FactoryServicesDA.createTacheServices().deleteTache(id);
        }

        public Tache updateTache(int id, string libelle, string description, DateTime date_debut, DateTime date_reelle_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement)
        {
            return FactoryServicesDA.createTacheServices().updateTache(id, libelle, description, date_debut, date_reelle_debut, duree, id_tache_precente, id_responsable, id_jalon, avancement);
        }

        public bool insertTache(string libelle, string description, DateTime date_debut, DateTime date_reelle_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement)
        {
            bool res = FactoryServicesDA.createTacheServices().insertTache(libelle, description, date_debut, date_reelle_debut, duree, id_tache_precente, id_responsable, id_jalon, avancement);
            return res;
        }

        #endregion
        #region Exigence

        public List<Exigence> getExigencesByProjet(int id_projet)
        {
            return FactoryServicesDA.createExigenceServices().getExigencesByProjet(id_projet);
        }

        public List<Exigence> getExigencesByTache(int id_tache)
        {
            return FactoryServicesDA.createExigenceServices().getExigencesByTache(id_tache);
        }

        public Exigence getExigenceById(int id)
        {
            return FactoryServicesDA.createExigenceServices().getExigenceById(id);
        }

        public bool deleteExigence(int id)
        {
            return FactoryServicesDA.createExigenceServices().deleteExigence(id);
        }

        public Exigence updateExigence(int id, string type, string libelle, int id_projet)
        {
            return FactoryServicesDA.createExigenceServices().updateExigence(id, type, libelle, id_projet);
        }

        public bool insertExigence(string type, string libelle, int id_projet)
        {
            return FactoryServicesDA.createExigenceServices().insertExigence(type, libelle, id_projet);
        }

        #endregion
    }
}
