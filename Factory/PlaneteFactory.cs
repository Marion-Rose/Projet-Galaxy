using ExoPlanetes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes
{
    public class PlaneteFactory
    {
        public static Planete CreerPlanete(string type, string nom)
        {
            switch (type)
            {
                case "oceanique":
                    return new PlaneteOceanique(nom);
                case "glacee":
                    return new PlaneteGlacee(nom);
                case "terrestre":
                    return new PlaneteTerrestre(nom);
                case "gazeuse":
                    return new PlaneteGazeuse(nom);
                default:
                    throw new Exception("Type de planète inconnu");
            }
        }
    }
}
