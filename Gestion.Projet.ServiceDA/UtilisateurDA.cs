using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;
using Gestion.Projet.ServiceDA.DataSet1TableAdapters;
using static Gestion.Projet.ServiceDA.DataSet1;

namespace Gestion.Projet.ServiceDA
{
    public class UtilisateurDA: UtilisateurInterface
    {
        public List<Utilisateur> getUtilisateurs()
        {
            UtilisateurDataTable utilisateurDataTable = new UtilisateurDataTable();
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            using (UtilisateurTableAdapter utilisateurTableAdapter = new UtilisateurTableAdapter())
            {
                utilisateurDataTable = utilisateurTableAdapter.getUtilisateurs();
                foreach (UtilisateurRow row in utilisateurDataTable)
                {
                    utilisateurs.Add(new Utilisateur(row.id,row.trigramme));
                }
                return utilisateurs;
            }
        }

        public Utilisateur getUtilisateurById(int id)
        {
            UtilisateurDataTable utilisateurDataTable = new UtilisateurDataTable();

            using (UtilisateurTableAdapter utilisateurTableAdapter = new UtilisateurTableAdapter())
            {
                utilisateurDataTable = utilisateurTableAdapter.getUtilisateurById(id);
                UtilisateurRow row = utilisateurDataTable[0];
                Utilisateur utilisateur = new Utilisateur(row.id, row.trigramme);
                return utilisateur;
            }

        }

        public Utilisateur insertUtilisateur(string trigramme)
        {
            using (UtilisateurTableAdapter utilisateurTableAdapter = new UtilisateurTableAdapter())
            {
                int id = (int)utilisateurTableAdapter.insertUtilisateur(trigramme);
                Utilisateur utilisateur = FactoryServicesDA.createUtilisateurServices().getUtilisateurById(id);
                Debug.Write("Id from ServiceDA-->");
                Debug.Write(utilisateur.Id);
                return utilisateur;
            }
        }
    }
}
