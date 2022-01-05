using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Commande
    {

        private bool isEpingle = false;
        public readonly List<Plat> _getPlats = new();
        public void makeEpingle()
        {
            this.isEpingle = true;
        }

        public bool IsEpingle()
        {
            return this.isEpingle;
        }

        public void ajouterPlat(Plat plat)
        {
            _getPlats.Add(plat);
        }
    }
}
