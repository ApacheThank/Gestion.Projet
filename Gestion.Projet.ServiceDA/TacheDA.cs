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
    public class TacheDA: TacheInterface
    {
        public List<Tache> getTaches(int id_jalon)
        {
            TacheDataTable tacheDataTable = new TacheDataTable();
            List<Tache> taches = new List<Tache>();
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                tacheDataTable = tacheTableAdapter.getTachesByJalon(id_jalon);
                foreach (TacheRow row in tacheDataTable)
                {
                    taches.Add(new Tache(row.id,row.libelle,row.description,row.date_debut,row.date_reelle_debut,row.duree,row.id_tache_precente,row.id_responsable,row.id_jalon,row.avancement));
                }
                return taches;
            }
        }

        public Tache getTacheById(int id)
        {
            TacheDataTable tacheDataTable = new TacheDataTable();

            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                tacheDataTable = tacheTableAdapter.getTacheById(id);
                TacheRow row = tacheDataTable[0];
                Tache tache = new Tache(row.id, row.libelle, row.description, row.date_debut, row.date_reelle_debut, row.duree, row.id_tache_precente, row.id_responsable, row.id_jalon, row.avancement);
                return tache;
            }

        }

        public int deleteTache(int id)
        {
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                int res = tacheTableAdapter.deleteTache(id);
                return res;
            }
        }

        public Tache updateTache(int id, string libelle, string description, DateTime date_debut, DateTime date_reelle_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement)
        {
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                tacheTableAdapter.updateTache(id, libelle, description, date_debut, date_reelle_debut, duree, id_tache_precente, id_responsable, id_jalon, avancement);
                Tache tache = new Tache(id,libelle,description,date_debut,date_reelle_debut,duree,id_tache_precente,id_responsable,id_jalon,avancement);
                return tache;
            }
        }

        public bool insertTache(string libelle,string description,DateTime date_debut,DateTime date_reelle_debut,int duree,int id_tache_precente,int id_responsable,int id_jalon, int avancement)
        {
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                int id = tacheTableAdapter.insertTache(libelle, description, date_debut, date_reelle_debut, duree, id_tache_precente, id_responsable, id_jalon, avancement);
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
