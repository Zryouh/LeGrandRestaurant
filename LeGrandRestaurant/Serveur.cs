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

        public Serveur(int Id)
        {
            this._Id = Id;
        }
        public int getId()
        {
            return this._Id;
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
