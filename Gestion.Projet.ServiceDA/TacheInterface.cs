using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;

namespace Gestion.Projet.ServiceDA
{
    public interface TacheInterface
    {
        List<Tache> getTachesByJalon(int id_jalon);
        List<Tache> getTachesByExigence(int id_exigence);
        List<Tache> getTachesByProjet(int id_projet);
        Tache getTacheById(int id);
        bool deleteTache(int id);
        Tache updateTache(int id, string libelle, string description, DateTime date_debut, DateTime date_reelle_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement);
        Tache insertTache(string libelle, string description, DateTime date_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement);
        bool insertAssoc(int id_exigence, int id_tache);
        int getEtatTachesByJalon(int id_jalon);
    }
}
