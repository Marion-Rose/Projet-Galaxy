using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    /**
     *     * <summary>
     *     * Classe abstraite Vaisseau
     *     * </summary>
     */
    public abstract class Vaisseau
    {
        private string nom;
        private int capaciteMax;
        protected Dictionary<TypeRessource, int> marchandise;
        private int deplacement;
        private List<Planete> route;
        
        private Planete lieu; // Lieu actuel du vaisseau
        private bool aDecharger; // Indique si le vaisseau doit décharger
        private int compteur; // Compteur pour le déplacement
        private int indexRoute; // Definit le lieu actuel ou suivant

        /**
         *         * <summary>
         *                 * Constructeur de la classe Vaisseau
         *         * </summary>
         *         * <param name="nom">Nom du vaisseau</param>
         *         * <param name="capaciteMax">Capacité maximale de stockage du vaisseau</param>
         *         * <param name="deplacement">Temps de déplacement maximal du vaisseau</param>
         *         * <param name="systemeSolaire">Liste des planètes du système solaire</param>
         */
        public Vaisseau(string nom, int capaciteMax, int deplacement, List<Planete> systemeSolaire)
        {
            this.nom = nom;
            this.capaciteMax = capaciteMax;
            this.deplacement = deplacement;

            this.marchandise = new Dictionary<TypeRessource, int>();
            this.marchandise.Add(TypeRessource.GAZ, 0);
            this.marchandise.Add(TypeRessource.GLACE, 0);
            this.marchandise.Add(TypeRessource.EAU, 0);
            this.marchandise.Add(TypeRessource.TERRE, 0);

            this.route = new List<Planete>();
            GenererRouteAleatoire(systemeSolaire);

            this.indexRoute = 0;
            lieu= route[indexRoute];

            aDecharger = false;
            this.compteur = 0;
        }

        public void SetNom(string nom) { this.nom = nom;}
        public string GetNom() { return this.nom; }
        public int GetCapaciteMax() { return capaciteMax; }
        public void SetCapaciteMax(int capaciteMax) { this.capaciteMax = capaciteMax; }
        public int GetDeplacement() { return deplacement; }
        public void SetDeplacement(int deplacement) { this.deplacement = deplacement; }
        public void SetMarchandise(Dictionary<TypeRessource, int> marchandise) { this.marchandise = marchandise; }
        public Dictionary<TypeRessource, int> GetMarchandise() { return this.marchandise; }
        public List<Planete> GetRoute() { return this.route; }
        public void SetLieu(Planete lieu) { this.lieu = lieu; }
        public Planete GetLieu()
        {
            if (this.lieu == null)
            {
                return null;
            }
            else
            {
                return this.lieu;
            }
        }
        public bool GetADecharger() { return this.aDecharger; }
        public override string ToString()
        {
            return "Vaisseau : " + this.nom + ", Capacité : " + this.capaciteMax + ", Deplacement : " + this.deplacement + ", Route :" + this.route.ToString();
        }

        /**
         *         * <summary>
         *              * Méthode pour charger de la marchandise
         *         * </summary>
         *         * <param name="type">Type de ressource</param>
         *         * <param name="quantite">Quantité de ressource</param>
         */
        public void ChargerMarchandise(TypeRessource type, int quantite)
        {
            //Verifie si la capacité maximale du vaisseau est atteinte
            if (marchandise.Values.Sum() != this.capaciteMax)
            {
                //vérifie si la planète a assez de ressource pour remplir la calle
                if (this.lieu.GetRessource()[type] >= quantite)
                {
                    //Ajoute la marchandise dans la calle
                    this.marchandise[type] += quantite;
                    //Retire la marchandise de la planète
                    this.lieu.RetirerRessource(type, quantite);

                    Console.WriteLine("Le vaisseau " + this.nom + " a chargé " + quantite + " unités de " + type + " sur " + this.lieu.GetNom());
                }
                else
                {
                    Console.WriteLine("Le vaisseau " + this.nom + " n'a pas pu chargé de " + type + " sur " + this.lieu.GetNom() + " car il n'y en a pas assez sur la Planète");
                }
            }
            else {
                Console.WriteLine("Le vaisseau " + this.nom + " n'a pas pu chargé de " + type + " sur " + this.lieu.GetNom() + " car ses calles sont pleines");
            }

            this.indexRoute++;
            if (this.indexRoute == this.route.Count) { this.indexRoute = 0; }
        }

        /**
         *         * <summary>
         *              * Méthode pour décharger de la marchandise
         *         * </summary>
         */
        public void DechargerMarchandise()
        {
            //décharge toutes les marchandises sauf celle de la planète actuelle
            foreach (KeyValuePair<TypeRessource, int> marchandise in this.marchandise)
            {
                if(marchandise.Key != lieu.GetType() && marchandise.Value != 0)
                {
                    //Ajoute la marchandise dans la planète
                    this.lieu.AjouterRessource(marchandise.Key, marchandise.Value);
                    //Retire la marchandise de la calle
                    this.marchandise[marchandise.Key] = 0;

                    Console.WriteLine("Le vaisseau " + this.nom + " a déchargé " + marchandise.Value + "unités de " + marchandise.Key +" sur " + this.lieu.GetNom());
                }
            }
            
        }

        /**
         *         * <summary>
         *              * Méthode pour générer une route aléatoire
         *         * </summary>
         *         * <param name="planetes">Liste des planètes du système solaire</param>
         */
        public void GenererRouteAleatoire(List<Planete> planetes)
        {
            Random random = new Random();
            int indexPlanetePred = -1;

            //Ajoute 5 planètes aléatoires à la route
            for (int i = 0; i < 5; i++)
            {
                int indexPlanete;

                do
                {
                    indexPlanete = random.Next(planetes.Count);
                } while (indexPlanete == indexPlanetePred);//Verifie que la planète à ajoutée n'est pas la même que la précédente

                this.route.Add(planetes[indexPlanete]);
                indexPlanetePred = indexPlanete;
            }
        }

        /**
         *         *         * <summary>
         *                 *              * Méthode pour afficher la route
         *                         *         * </summary>
         *                                 */
        public void AfficherRoute()
        {
            foreach (Planete planete in this.route)
            {
                Console.WriteLine(planete.GetNom());
            }
        }

        /**
         *         * <summary>
         *              * Méthode pour avancer le vaisseau
         *         * </summary>
         */
        public void Avancer() { 
            //Avance le vaisseau sur la route en vérifiant que le compteur soit inférieur à son temps de déplacement
            if(this.compteur < this.deplacement-1)
            {
                compteur++;
            }
            else //Si le compteur est égal à son temps de déplacement, le vaisseau arrive à la planète suivante
            {
                this.lieu = this.route[this.indexRoute];
                this.compteur = 0;
                this.aDecharger = true;
            }
        }

        /**
         *         * <summary>
         *              * Méthode pour effectuer une action sur le vaisseau
         *         * </summary>
         */
        public void Action()
        {
            //Si le vaisseau est à quai
            if (this.lieu != null)
            {
                //Si le vaisseau doit décharger
                if (this.aDecharger)
                {
                    DechargerMarchandise();
                    ChargerMarchandise(this.lieu.GetType(), this.capaciteMax);
                    
                    this.aDecharger = false;
                    this.lieu = null;//Il quitte la Planète
                }
                else //Si le vaisseau ne peut pas décharger
                {
                    ChargerMarchandise(this.lieu.GetType(), this.capaciteMax);
                    this.aDecharger = false;
                    this.lieu = null;//Il quitte la Planète
                }
            }
            else //Si le vaisseau est en route, il continue d'avancer
            {
                Avancer();
                Console.WriteLine("Le vaisseau " + this.nom + " est en chemin");
            }
        }
    }
}
