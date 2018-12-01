using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion.Projet.Bean;

namespace Gestion.Projet.Service
{
    public interface ServicesInterface
    {
        List<Project> getProjets();
    }
}
