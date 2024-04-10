using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    public class PlaneteOceanique : Planete
    {
        public PlaneteOceanique(string nom) : base(nom, TypeRessource.EAU)
        {
            this.ressource[TypeRessource.EAU] = 9999;
        }
    }

}
