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
    public class ExigenceDA: ExigenceInterface
    {
        public List<Exigence> getExigencesByProjet(int id_projet)
        {
            ExigenceDataTable exigenceDataTable = new ExigenceDataTable();
            List<Exigence> exigences = new List<Exigence>();
            using (ExigenceTableAdapter exigenceTableAdapter = new ExigenceTableAdapter())
            {
                exigenceDataTable = exigenceTableAdapter.getExigencesByProjet(id_projet);
                foreach (ExigenceRow row in exigenceDataTable)
                {
                    exigences.Add(new Exigence(row.id, row.type, row.libelle));
                }
                return exigences;
            }
        }

        public List<Exigence> getExigencesByTache(int id_tache)
        {
            ExigenceDataTable exigenceDataTable = new ExigenceDataTable();
            List<Exigence> exigences = new List<Exigence>();
            using (ExigenceTableAdapter exigenceTableAdapter = new ExigenceTableAdapter())
            {
                exigenceDataTable = exigenceTableAdapter.getExigencesByTache(id_tache);
                foreach (ExigenceRow row in exigenceDataTable)
                {
                    exigences.Add(new Exigence(row.id, row.type,row.libelle));
                }
                return exigences;
            }
        }

        public Exigence getExigenceById(int id)
        {
            ExigenceDataTable exigenceDataTable = new ExigenceDataTable();

            using (ExigenceTableAdapter exigenceTableAdapter = new ExigenceTableAdapter())
            {
                exigenceDataTable = exigenceTableAdapter.getExigenceById(id);
                ExigenceRow row = exigenceDataTable[0];
                Exigence jalon = new Exigence(row.id,row.type,row.libelle);
                return jalon;
            }

        }  
    }
}
