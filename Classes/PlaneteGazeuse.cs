using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    public class PlaneteGazeuse : Planete
    {
        public PlaneteGazeuse(string nom) : base(nom, TypeRessource.GAZ)
        {
            this.ressource[TypeRessource.GAZ] = 9999;
        }
    }
}
