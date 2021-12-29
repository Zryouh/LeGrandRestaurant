using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Menu
    {
        private List<Plat> _plats { get; set; } = new List<Plat>();

        public Menu()
        {

        }

        public void ajouterPlat(Plat plat)
        {
            _plats.Add(plat);

        }

        public Plat recherchePlat(string nom)
        {
            return (Plat)_plats.Where(plat => plat.Nom == nom);
        }

        public List<Plat> getPlat()
        {
            return this._plats;
        }
    }
}
