using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;

namespace Gestion.Projet.ServiceDA
{
    public interface ProjectInterface
    {
        List<Project> getProjets();
        Project getProjectById(int id);
        bool deleteProjet(int id);
        Project updateProjet(int id, string trigramme, int id_utilisateur);
        bool insertProjet(string trigramme, int id_utilisateur);
        int getEtatProjet(int id_projet);
    }
}
