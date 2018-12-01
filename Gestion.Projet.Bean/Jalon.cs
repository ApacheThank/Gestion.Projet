using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Projet.Bean
{
    public class Jalon
    {
        private int id;
        private string libelle;
        private DateTime date_livraison;
        private DateTime date_reelle;
        private int etat;
        private int id_projet;
        private int id_responsable;
        private Utilisateur responsable;
        private Project projet;
        private List<Tache> list_taches;

        public Jalon(int id, string libelle, DateTime date_livraison,int id_projet, int id_responsable)
        {
            this.id = id;
            this.libelle = libelle;
            this.date_livraison = date_livraison;
            this.id_projet = id_projet;
            this.id_responsable = id_responsable;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Libelle
        {
            get { return this.libelle; }
            set { this.libelle = value; }
        }

        public DateTime Date_livraison
        {
            get { return this.date_livraison; }
            set { this.date_livraison = value; }
        }

        public DateTime Date_reelle
        {
            get { return this.date_reelle; }
            set { this.date_reelle = value; }
        }

        public int Etat
        {
            get { return this.etat; }
            set { this.etat = value; }
        }

        public int Id_projet
        {
            get { return this.id_projet; }
            set { this.id_projet = value; }
        }

        public int Id_responsable
        {
            get { return this.id_responsable; }
            set { this.id_responsable = value; }
        }

        public Utilisateur Responsable
        {
            get { return this.responsable; }
            set { this.responsable = value; }
        }

        public Project Projet
        {
            get { return this.projet; }
            set { this.projet = value; }
        }

        public List<Tache> List_taches
        {
            get { return this.list_taches; }
            set { this.list_taches = value; }
        }
    }
}
