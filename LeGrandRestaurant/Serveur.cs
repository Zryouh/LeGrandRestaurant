using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Serveur : TableAffected
    {

        private readonly int _Id;
        private readonly List<Commande> _getCommandes = new();
        private bool isNotPaid = false;
        private Commande _commande { get; set; }
        private  Restaurant _restaurant;
        private double CA { get; set; }
        


        public bool OrderNoPaid(Commande commande)
        {
            return this.isNotPaid = true;
        }
        public Serveur()
        {
            

        }


        public Serveur(int Id )
        {
            this._Id = Id;
            
        }

        public double getCA()
        {
            return this.CA;
        }

        public double ajouterCA(double prix)
        {
            return this.CA += prix;

        }
        public Serveur(Commande commande)
        {
            this._commande = commande;
        }
        public int getId()
        {
            return this._Id;
        }

        public void takeOrder(Commande commande)
        {
            
             _getCommandes.Add(commande);
            foreach(Plat plat in commande._getPlats)
            {
                this.ajouterCA(plat.Prix);
                this._restaurant.ajouterCA_Restaurant(plat.Prix);
            }
            
        }
        

        public  void setRestauant(Restaurant restaurant)
        {
            this._restaurant = restaurant;
        }

        public void getFood(Commande commande)
        {
            _getCommandes.Add(commande);
        }
        public void getDrink(Commande commande)
        {
           
        }
       

        public IEnumerable<Commande> GetCommandes => _getCommandes;

    }
}
