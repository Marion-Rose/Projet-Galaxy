using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    public class VaisseauLourd : Vaisseau
    {
        public VaisseauLourd(string nom, List<Planete> systemeSolaire) : base(nom, 500, 3, systemeSolaire){}
    }
}
