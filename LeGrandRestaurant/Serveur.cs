using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Serveur
    {

        private readonly List<Commande> _getCommandes = new();
       
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
