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
    public class JalonDA: JalonInterface
    {
        public List<Jalon> getJalonsByProjet(int id_projet)
        {
            JalonDataTable jalonDataTable = new JalonDataTable();
            List<Jalon> jalons = new List<Jalon>();
            using (JalonTableAdapter jalonTableAdapter = new JalonTableAdapter())
            {
                jalonDataTable = jalonTableAdapter.getJalonsByProjet(id_projet);
                foreach (JalonRow row in jalonDataTable)
                {
                    jalons.Add(new Jalon(row.id,row.libelle,row.date_livraison,row.id_projet,row.id_responsable));
                }
                return jalons;
            }
        }

        public List<Jalon> getJalonsByResponsable(int id_responsable)
        {
            JalonDataTable jalonDataTable = new JalonDataTable();
            List<Jalon> jalons = new List<Jalon>();
            using (JalonTableAdapter jalonTableAdapter = new JalonTableAdapter())
            {
                jalonDataTable = jalonTableAdapter.getJalonsByResponsable(id_responsable);
                foreach (JalonRow row in jalonDataTable)
                {
                    jalons.Add(new Jalon(row.id,row.libelle,row.date_livraison,row.id_projet,row.id_responsable));
                }
                return jalons;
            }
        }

        public Jalon getJalonById(int id)
        {
            JalonDataTable jalonDataTable = new JalonDataTable();

            using (JalonTableAdapter jalonTableAdapter = new JalonTableAdapter())
            {
                jalonDataTable = jalonTableAdapter.getJalonById(id);
                JalonRow row = jalonDataTable[0];
                Jalon jalon = new Jalon(row.id, row.libelle, row.date_livraison, row.id_projet, row.id_responsable);
                return jalon;
            }

        }

        public bool deleteJalon(int id)
        {
            using (JalonTableAdapter jalonTableAdapter = new JalonTableAdapter())
            {
                int result = jalonTableAdapter.deleteJalon(id);
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

        public Jalon updateJalon(int id, string libelle, DateTime date_livraison,DateTime date_reelle,int id_projet,int id_responsable)
        {
            using (JalonTableAdapter jalonTableAdapter = new JalonTableAdapter())
            {
                jalonTableAdapter.updateJalon(id, libelle, date_livraison,date_reelle,id_projet, id_responsable);
                Jalon jalon = new Jalon(id,libelle,date_livraison,id_projet,id_responsable);
                return jalon;
            }
        }

        public bool insertJalon(string libelle, DateTime date_livraison, int id_projet, int id_responsable)
        {
            using (JalonTableAdapter jalonTableAdapter = new JalonTableAdapter())
            {
                int id = jalonTableAdapter.insertJalon(libelle, date_livraison,null, id_projet, id_responsable);
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
