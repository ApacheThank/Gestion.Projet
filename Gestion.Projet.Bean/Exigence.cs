﻿using System;
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

        public Exigence(int id, string type, string libelle)
        {
            this.id = id;
            this.type = type;
            this.libelle = libelle;
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

    }
}