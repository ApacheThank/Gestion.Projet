using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;
using Gestion.Projet.ServiceDA.DataSet1TableAdapters;
using static Gestion.Projet.ServiceDA.DataSet1;

namespace Gestion.Projet.ServiceDA
{
    public class ProjectDA: ProjectInterface
    {
        public List<Project> getProjets()
        {
            ProjetDataTable projetDataTable = new ProjetDataTable();
            List<Project> projets = new List<Project>();
            using (ProjetTableAdapter projetTableAdapter = new ProjetTableAdapter())
            {
                projetDataTable = projetTableAdapter.getProjets();
                foreach (ProjetRow row in projetDataTable)
                {
                    projets.Add(new Project(row.id, row.trigramme,row.id_utilisateur));
                }
                return projets;
            }
        }

        public Project getProjectById(int id)
        {
            ProjetDataTable projetDataTable = new ProjetDataTable();

            using (ProjetTableAdapter projetTableAdapter = new ProjetTableAdapter())
            {
                projetDataTable = projetTableAdapter.getProjetById(id);
                ProjetRow row = projetDataTable[0];
                Project projet = new Project(row.id, row.trigramme,row.id_utilisateur);
                return projet;
            }

        }

        public int deleteMedecin(int id)
        {
            using (ProjetTableAdapter projetTableAdapter = new ProjetTableAdapter())
            {
                int res = projetTableAdapter.deleteProjet(id);
                return res;
            }
        }

        public Project updateMedecin(int id, string trigramme, int id_utilisateur)
        {
            using (ProjetTableAdapter projetTableAdapter = new ProjetTableAdapter())
            {
                projetTableAdapter.updateProjet(id, trigramme, id_utilisateur);
                Project projet = new Project(id, trigramme, id_utilisateur);
                return projet;
            }
        }

        public bool insertProjet(string trigramme,int id_utilisateur)
        {
            using (ProjetTableAdapter projetTableAdapter = new ProjetTableAdapter())
            {
                int id = projetTableAdapter.insertProjet(trigramme, id_utilisateur);
                bool res;
                if (id == 0)
                {
                    res = false;
                }
                else
                {
                    res = true;
                }
                return res;
            }
        }
    }
}
