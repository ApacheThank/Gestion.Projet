using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Projet.Bean
{
    public class Tache
    {
        private int id;
        private string libelle;
        private string description;
        private DateTime date_debut;
        private DateTime date_reelle_debut;
        private int duree;
        private int id_tache_precedente;
        private int id_responsable;
        private int id_jalon;
        private int avancement;
        private Utilisateur responsable;
        private Jalon jalon;
        private Tache tache_precedente;

        public Tache(int id, string libelle, string description, DateTime date_debut, int duree, int id_tache_precedente, int id_responsable, int id_jalon, int avancement)
        {
            this.id = id;
            this.libelle = libelle;
            this.description = description;
            this.date_debut = date_debut;
            this.duree = duree;
            this.id_tache_precedente = id_tache_precedente;
            this.id_responsable = id_responsable;
            this.id_jalon = id_jalon;
            this.avancement = avancement;
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

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public DateTime Date_debut
        {
            get { return this.date_debut; }
            set { this.date_debut = value; }
        }

        public DateTime Date_reelle_debut
        {
            get { return this.date_reelle_debut; }
            set { this.date_reelle_debut = value; }
        }

        public int Duree
        {
            get { return this.duree; }
            set { this.duree = value; }
        }

        public int Id_tache_precedente
        {
            get { return this.id_tache_precedente; }
            set { this.id_tache_precedente = value; }
        }

        public int Id_responsable
        {
            get { return this.id_responsable; }
            set { this.id_responsable = value; }
        }

        public int Id_jalon
        {
            get { return this.id_jalon; }
            set { this.id_jalon = value; }
        }

        public int Avancement
        {
            get { return this.avancement; }
            set { this.avancement = value; }
        }

        public Utilisateur Responsable
        {
            get { return this.responsable; }
            set { this.responsable = value; }
        }

        public Jalon Jalon
        {
            get { return this.jalon; }
            set { this.jalon = value; }
        }

        public Tache Tache_precedente
        {
            get { return this.tache_precedente; }
            set { this.tache_precedente = value; }
        }

    }
}
