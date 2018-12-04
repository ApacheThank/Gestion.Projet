using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;

namespace Gestion.Projet.Service
{
    public interface ServicesInterface
    {
        List<Project> getProjets();
        Project getProjectById(int id);
        bool deleteProjet(int id);
        Project updateProjet(int id, string trigramme, int id_utilisateur);
        bool insertProjet(string trigramme, int id_utilisateur);

        List<Utilisateur> getUtilisateurs();
        Utilisateur getUtilisateurById(int id);
        Utilisateur insertUtilisateur(string trigramme);

        List<Jalon> getJalonsByProjet(int id_projet);
        List<Jalon> getJalonsByResponsable(int id_responsable);
        Jalon getJalonById(int id);
        bool deleteJalon(int id);
        Jalon updateJalon(int id, string libelle, DateTime date_livraison, DateTime date_reelle, int id_projet, int id_responsable);
        bool insertProjet(string libelle, DateTime date_livraison, DateTime date_reelle, int id_projet, int id_responsable);

        List<Tache> getTachesByJalon(int id_jalon);
        Tache getTacheById(int id);
        bool deleteTache(int id);
        Tache updateTache(int id, string libelle, string description, DateTime date_debut, DateTime date_reelle_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement);
        bool insertTache(string libelle, string description, DateTime date_debut, DateTime date_reelle_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement);

        List<Exigence> getExigencesByProjet(int id_projet);
        List<Exigence> getExigencesByTache(int id_tache);
        Exigence getExigenceById(int id);
        bool deleteExigence(int id);
        Exigence updateExigence(int id, string type, string libelle, int id_projet);
        bool insertExigence(string type, string libelle, int id_projet);
    }
}
