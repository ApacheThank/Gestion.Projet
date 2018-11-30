using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Projet.Bean
{
    public class Utilisateur
    {
        private int id;
        private string trigramme;

        public Utilisateur(int id, string trigramme)
        {
            this.id = id;
            this.trigramme = trigramme;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Trigramme
        {
            get { return this.trigramme; }
            set { this.trigramme = value; }
        }
    }
}
