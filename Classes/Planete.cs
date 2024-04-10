using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoPlanetes.Classes
{
    /**
     *    * Classe abstraite Planete
     */
    public abstract class Planete
    {
        protected string nom;
        protected Dictionary<TypeRessource, int> ressource;
        protected TypeRessource type;

        /**
         *         * Constructeur de la classe Planete
         *         * @param nom : nom de la planete
         *         * @param type : type de la planete
         */
        public Planete(string nom, TypeRessource type)
        {
            this.nom = nom;
            this.ressource = new Dictionary<TypeRessource, int>();
            this.ressource.Add(TypeRessource.GAZ, 0);
            this.ressource.Add(TypeRessource.GLACE, 0);
            this.ressource.Add(TypeRessource.EAU, 0);
            this.ressource.Add(TypeRessource.TERRE, 0);
            this.type = type;
        }

        public void SetNom  (string nom) { this.nom = nom;}
        public string GetNom() { return this.nom; }
        public void SetRessource(Dictionary<TypeRessource, int> ressource) { this.ressource = ressource; }
        public Dictionary<TypeRessource, int> GetRessource() { return this.ressource; }
        public TypeRessource GetType() { return this.type; }
        public override string ToString() { return "Nom : " + this.nom + " Ressource : " + this.ressource;}

        /**
         *         * Methode qui permet d'ajouter une ressource a la planete
         *         * @param type : type de la ressource
         *         * @param quantite : quantite de la ressource
         */
        public void AjouterRessource(TypeRessource type, int quantite)
        {
            this.ressource[type] += quantite;
        }

        /**
         *         * Methode qui permet de retirer une ressource a la planete
         *         * @param type : type de la ressource
         *         * @param quantite : quantite de la ressource
         */
        public void RetirerRessource(TypeRessource type, int quantite)
        {
            this.ressource[type] -= quantite;
        }
    }
}
