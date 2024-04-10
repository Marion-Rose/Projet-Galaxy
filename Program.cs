using System;
using System.Diagnostics;
using ExoPlanetes;
using ExoPlanetes.Classes;
using ExoPlanetes.Factory;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    /**
     *     * Méthode principale
     *     * @param args
     */
    private static void Main(string[] args)
    {
        List<Vaisseau> flotte = new List<Vaisseau>();
        List<Planete> systemeSolaire = new List<Planete>();
        List<string> nomPlanète = ["Terre", "Venus", "Saturne", "Pluton", "Lune", "Mercure", "Mars", "Jupiter", "Uranus", "Neptune", "Cérès", "Charon", "UB313", "Hoth", "Tatooïne", "Dagobah", "Naboo", "Coruscant", "Mustafar", "Aldérande", "Utapau", "Bespin", "Yavin", "Felucia", "Kamino", "Geonosis", "Endor", "Kashyyyk", "Mygeeto"];
        List<string> nomVaisseau = ["Millennium Falcon", "USS Enterprise", "TIE Fighter", "Serenity", "Battlestar Galactica", "Discovery One", "Nostromo", "USS Voyager", "Normandy SR-2", "SpaceX Crew Dragon"];
        List<string> typePlanete = ["gazeuse", "oceanique", "glacee", "terrestre"];
        int nbTour = 20;

        /**
         *         * Initialisation du système solaire et des vaisseaux
         */
        void Initialisation(int nbPlanete, int nbVaisseau)
        {
            Random aleatoire = new Random();
            int indicePlanete;
            int indiceTypePlanete;
            int indiceVaisseau;
            int indiceTypeVaisseau;

            for (int i = 0; i < nbPlanete; i++)
            {
                indicePlanete = aleatoire.Next(0, nomPlanète.Count);
                indiceTypePlanete = aleatoire.Next(0, typePlanete.Count);
                systemeSolaire.Add(PlaneteFactory.CreerPlanete(typePlanete[indiceTypePlanete], nomPlanète[indicePlanete]));
                nomPlanète.RemoveAt(indicePlanete);
            }

            for (int i = 0; i < nbVaisseau; i++)
            {
                indiceVaisseau = aleatoire.Next(0, nomVaisseau.Count);
                indiceTypeVaisseau = aleatoire.Next(0, 3);
                flotte.Add(VaisseauFactory.CreerVaisseau((TypeVaisseau)indiceTypeVaisseau, nomVaisseau[indiceVaisseau], systemeSolaire));
                nomVaisseau.RemoveAt(indiceVaisseau);
            }

            //foreach (Planete planete in systemeSolaire)
            //{
            //    Console.WriteLine(planete.GetNom() + planete.GetType());
            //}
            //foreach (Vaisseau vaisseau in flotte)
            //{
            //    Console.WriteLine(vaisseau.GetNom() + vaisseau.GetType());
            //}
        }

        /**
         *         * Affiche un dictionnaire
         *         * @param dictionnaire
         */
        void AfficherDictionnaire<TKey, TValue>(Dictionary<TKey, TValue> dictionnaire)
        {
            foreach (var paire in dictionnaire)
            {
                Console.WriteLine($"Clé: {paire.Key}, Valeur: {paire.Value}");
            }
        }

        Initialisation(10,3);

        //Tour de jeu
        for (int i = 0; i < nbTour; i++)
        {
            Console.WriteLine("Tour " + i);
            foreach (Vaisseau vaisseau in flotte)
            {
                vaisseau.Action();
            }
        }

        //Affichage des ressources des planètes et des vaisseaux
        foreach (Planete planete in systemeSolaire)
        {

            Console.WriteLine(planete.GetNom());
            AfficherDictionnaire(planete.GetRessource());
        }
        foreach (Vaisseau vaisseau in flotte)
        {
            Console.WriteLine(vaisseau.GetNom());
            AfficherDictionnaire(vaisseau.GetMarchandise());
        }
    }
}