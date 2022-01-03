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
      

        public bool OrderNoPaid(Commande commande)
        {
            return this.isNotPaid = true;
        }


        public Serveur(int Id )
        {
            this._Id = Id;
            
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
