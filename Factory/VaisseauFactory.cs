using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExoPlanetes.Classes;

namespace ExoPlanetes.Factory
{
    public class VaisseauFactory
    {
        public static Vaisseau CreerVaisseau(TypeVaisseau type, string nom, List<Planete> systemeSolaire)
        {
            Vaisseau vaisseau = null;
            switch (type)
            {
                case TypeVaisseau.RAPIDE:
                    vaisseau = new VaisseauRapide(nom, systemeSolaire);
                    break;
                case TypeVaisseau.MOYEN:
                    vaisseau = new VaisseauMoyen(nom, systemeSolaire);
                    break;
                case TypeVaisseau.LOURD:
                    vaisseau = new VaisseauLourd(nom, systemeSolaire);
                    break;
            }
            return vaisseau;
        }
    }
}
