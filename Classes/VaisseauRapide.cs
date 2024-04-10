using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    public class VaisseauRapide : Vaisseau
    {
        public VaisseauRapide(string nom, List<Planete> systemeSolaire) : base(nom, 100, 1, systemeSolaire) { }
    }
}
