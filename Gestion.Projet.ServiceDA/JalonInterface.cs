using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;

namespace Gestion.Projet.ServiceDA
{
    public interface JalonInterface
    {
        List<Jalon> getJalonsByProjet(int id_projet);
        List<Jalon> getJalonsByResponsable(int id_responsable);
        Jalon getJalonById(int id);
        int deleteMedecin(int id);
        Jalon updateMedecin(int id, string libelle, DateTime date_livraison, DateTime date_reelle, int id_projet, int id_responsable);
        bool insertProjet(string libelle, DateTime date_livraison, DateTime date_reelle, int id_projet, int id_responsable);
    }
}
