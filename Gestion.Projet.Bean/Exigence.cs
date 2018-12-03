using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Projet.Bean
{
    public class Exigence
    {

        private int id;
        private string type;
        private string libelle;
        private int id_projet;
        private Project projet;

        public Exigence(int id, string type, string libelle,int id_projet)
        {
            this.id = id;
            this.type = type;
            this.libelle = libelle;
            this.id_projet = id_projet;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public string Libelle
        {
            get { return this.libelle; }
            set { this.libelle = value; }
        }

        public int Id_projet
        {
            get { return this.id_projet; }
            set { this.id_projet = value; }
        }

        public Project Projet
        {
            get { return this.projet; }
            set { this.projet = value; }
        }

    }
}
