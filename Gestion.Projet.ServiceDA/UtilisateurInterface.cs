using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;

namespace Gestion.Projet.ServiceDA
{
    public interface UtilisateurInterface
    {
        List<Utilisateur> getUtilisateurs();
        Utilisateur getUtilisateurById(int id);
        bool insertUtilisateur(string trigramme);

    }
}
