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
        private List<Restaurant> _restaurants = new ();

        public Franchise()
        {
        }

        public Restaurant[] RestaurantsFiliale => _restaurants.Where(restau => restau.IsFiliale).ToArray();

        public void AjouteMenu(Menu menu)
        {
            foreach (Restaurant restaurant in RestaurantsFiliale)
            {
                restaurant.Menu = menu;
            }
        }

        public void AjouterRestaurant(Restaurant restaurant)
        {
            _restaurants.Add(restaurant);
        }


            public void changerPrix(string nom, double prix)
        {
            foreach(Restaurant restaurant in RestaurantsFiliale)
            {
                Plat monPlat = restaurant.Menu.recherchePlat(nom);
                monPlat.Prix = prix;
            }
            
        }
    }
}
