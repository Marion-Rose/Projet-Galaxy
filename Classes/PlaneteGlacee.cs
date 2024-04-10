using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    public class PlaneteGlacee : Planete
    {
        public PlaneteGlacee(string nom) : base(nom, TypeRessource.GLACE)
        {
            this.ressource[TypeRessource.GLACE] = 9999;
        }
    }
}
