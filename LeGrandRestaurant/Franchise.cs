using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Franchise
    {
        
        private Menu _menu { get; set; }
        public Franchise()
        {
        }

        public void AjouteMenu(Menu menu)
        {
            _menu = menu;
        }
    }
}
