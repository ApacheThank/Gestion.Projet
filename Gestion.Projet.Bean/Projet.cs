﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Projet.Bean
{
    public class Projet
    {
        private int id;
        private string trigramme;
        private int id_responsable;
        private Utilisateur responsable;

        public Projet(int id, string trigramme, int id_responsable)
        {
            this.id = id;
            this.trigramme = trigramme;
            this.id_responsable = id_responsable;
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

    }
}
