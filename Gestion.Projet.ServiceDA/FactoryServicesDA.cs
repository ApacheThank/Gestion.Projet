using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Projet.ServiceDA
{
    public class FactoryServicesDA
    {
        public static ProjectInterface createProjectServices()
        {
            return new ProjectDA();
        }

        public static UtilisateurInterface createUtilisateurServices()
        {
            return new UtilisateurDA();
        }

        public static JalonInterface createJalonServices()
        {
            return new JalonDA();
        }

        public static ExigenceInterface createExigenceServices()
        {
            return new ExigenceDA();
        }

        public static TacheInterface createTacheServices()
        {
            return new TacheDA();
        }
    }
}
