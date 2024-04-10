using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    public class PlaneteTerrestre : Planete
    {
        public PlaneteTerrestre(string nom) : base(nom, TypeRessource.TERRE)
        {
            this.ressource[TypeRessource.TERRE] = 9999;
        }
    }
}
