using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Projet.Service
{
    public class FactoryServices
    {
        public static ServicesInterface createServices()
        {
            return new Services();
        }
    }
}
