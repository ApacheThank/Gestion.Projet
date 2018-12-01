using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;
using Gestion.Projet.ServiceDA;

namespace Gestion.Projet.Service
{
    public class Services: ServicesInterface
    {

        public List<Project> getProjets()
        {
            return FactoryServicesDA.createProjectServices().getProjets();
        }
    }
}
