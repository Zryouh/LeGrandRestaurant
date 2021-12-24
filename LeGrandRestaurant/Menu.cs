using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Menu
    {
        private List<Plat> _plats { get; set; }

        public Menu()
        {

        }

        public void ajouterPlat(Plat plat)
        {
            _plats.Add(plat);

        }

    }
}
