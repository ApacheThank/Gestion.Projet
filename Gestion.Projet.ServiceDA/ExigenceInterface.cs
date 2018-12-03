using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;

namespace Gestion.Projet.ServiceDA
{
    public interface ExigenceInterface
    {
        List<Exigence> getExigencesByProjet(int id_projet);
        List<Exigence> getExigencesByTache(int id_tache);
        Exigence getExigenceById(int id);
        bool deleteExigence(int id);
        Exigence updateExigence(int id, string type, string libelle, int id_projet);
        bool insertExigence(string type, string libelle, int id_projet);
    }
}
