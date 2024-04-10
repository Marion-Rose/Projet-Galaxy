using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    public class VaisseauMoyen : Vaisseau
    {
        public VaisseauMoyen(string nom, List<Planete> systemeSolaire) : base(nom, 250, 2, systemeSolaire){}
    }
}
