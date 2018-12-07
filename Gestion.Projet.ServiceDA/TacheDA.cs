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
        public List<Tache> getTachesByJalon(int id_jalon)
        {
            TacheDataTable tacheDataTable = new TacheDataTable();
            List<Tache> taches = new List<Tache>();
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                tacheDataTable = tacheTableAdapter.getTachesByJalon(id_jalon);
                foreach (TacheRow row in tacheDataTable)
                {
                    Tache tache = new Tache(row.id, row.libelle, row.description, row.date_debut, row.duree, row.id_tache_precente, row.id_responsable, row.id_jalon, row.avancement);
                    if(row["date_reelle_debut"] != DBNull.Value)
                    {
                        tache.Date_reelle_debut = row.date_reelle_debut;
                    }
                    taches.Add(tache);
                }
                return taches;
            }
        }

        public List<Tache> getTachesByExigence(int id_exigence)
        {
            TacheDataTable tacheDataTable = new TacheDataTable();
            List<Tache> taches = new List<Tache>();
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                tacheDataTable = tacheTableAdapter.getTachesByExigence(id_exigence);
                foreach (TacheRow row in tacheDataTable)
                {
                    Tache tache = new Tache(row.id, row.libelle, row.description, row.date_debut, row.duree, row.id_tache_precente, row.id_responsable, row.id_jalon, row.avancement);
                    if(row["date_reelle_debut"] != DBNull.Value)
                    {
                        tache.Date_reelle_debut = row.date_reelle_debut;
                    }
                    taches.Add(tache);
                }
                return taches;
            }
        }

        public List<Tache> getTachesByProjet(int id_projet)
        {
            TacheDataTable tacheDataTable = new TacheDataTable();
            List<Tache> taches = new List<Tache>();
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                tacheDataTable = tacheTableAdapter.getTachesByProjet(id_projet);
                foreach (TacheRow row in tacheDataTable)
                {
                    Tache tache = new Tache(row.id, row.libelle, row.description, row.date_debut, row.duree, row.id_tache_precente, row.id_responsable, row.id_jalon, row.avancement);
                    if (row["date_reelle_debut"] != DBNull.Value)
                    {
                        tache.Date_reelle_debut = row.date_reelle_debut;
                    }
                    taches.Add(tache);
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
                Tache tache = new Tache(row.id, row.libelle, row.description, row.date_debut, row.duree, row.id_tache_precente, row.id_responsable, row.id_jalon, row.avancement);
                if (row.id_tache_precente > 0)
                {
                    Tache tache_precedente = FactoryServicesDA.createTacheServices().getTacheById(row.id_tache_precente);
                    tache.Tache_precedente = tache_precedente;
                }
                Utilisateur responsable = FactoryServicesDA.createUtilisateurServices().getUtilisateurById(row.id_responsable);
                tache.Responsable = responsable;
                Jalon jalon = FactoryServicesDA.createJalonServices().getJalonById(row.id_jalon);
                tache.Jalon = jalon;
                return tache;
            }

        }

        public bool deleteTache(int id)
        {
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                int result = tacheTableAdapter.deleteTache(id);
                bool res;
                if (result == 0)
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

        public Tache updateTache(int id, string libelle, string description, DateTime date_debut, DateTime date_reelle_debut, int duree, int id_tache_precente, int id_responsable, int id_jalon, int avancement)
        {
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                tacheTableAdapter.updateTache(id, libelle, description, date_debut, date_reelle_debut, duree, id_tache_precente, id_responsable, id_jalon, avancement);
                Tache tache = new Tache(id,libelle,description,date_debut,duree,id_tache_precente,id_responsable,id_jalon,avancement);
                
                return tache;
            }
        }

        public Tache insertTache(string libelle,string description,DateTime date_debut,int duree,int id_tache_precente,int id_responsable,int id_jalon, int avancement)
        {
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                int id = (int)tacheTableAdapter.insertTache(libelle, description, date_debut,null, duree, id_tache_precente, id_responsable, id_jalon, avancement);
                Tache tache = FactoryServicesDA.createTacheServices().getTacheById(id);
                return tache;
            }
        }

        public bool insertAssoc(int id_exigence, int id_tache)
        {
            using (AssocExiTacheTableAdapter tacheAssocTableAdapter = new AssocExiTacheTableAdapter())
            {
                int id = (int)tacheAssocTableAdapter.insertAssoc(id_exigence, id_tache);
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

        public int getEtatTachesByJalon(int id_jalon)
        {
            //TacheDataTable tacheDataTable = new TacheDataTable();
            using (TacheTableAdapter tacheTableAdapter = new TacheTableAdapter())
            {
                //tacheDataTable =  tacheTableAdapter.getEtatTachesByJalon(id_jalon);
                //TacheRow row = tacheDataTable[0];
                int nb = (int)tacheTableAdapter.getTachesCountByJalon(id_jalon);
                int progression = 0;
                if (nb != 0)
                {
                    int somme = (int)tacheTableAdapter.getTachesSumByJalon(id_jalon);
                    progression = (somme * 50) / nb;
                }
                
                return progression;
            }
        }
    }
}
