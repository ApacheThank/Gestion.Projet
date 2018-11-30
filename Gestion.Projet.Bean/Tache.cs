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
        private DateTime date_fin;
        private int id_responsable;
        private int id_jalon;
        private Utilisateur responsable;
        private Jalon jalon;
        private Tache tache_precedente;


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

        public DateTime Date_fin
        {
            get { return this.date_fin; }
            set { this.date_fin = value; }
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
