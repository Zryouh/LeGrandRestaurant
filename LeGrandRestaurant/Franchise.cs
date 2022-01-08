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
        private List<Restaurant> _restaurants = new();
        


        public Franchise()
        {
        }


        public Restaurant[] RestaurantsFiliale => _restaurants.Where(restau => restau.IsFiliale).ToArray();

        public void AjouteMenu(Menu menu)
        {
            _menu = menu;
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
            foreach (Restaurant restaurant in RestaurantsFiliale)
            {
                if(restaurant.IsFiliale)
                restaurant.changePricePlat(nom, prix);
               
            }
            //var plats = _menu.getPlat();
            //foreach (Plat plat in plats)
            //{
            //    if (plat.Nom == nom)
            //        plat.Prix = prix;
            //}

        }
        public void changerPrixPlatRestaurant(string nomPlat, int idRestaurant, double newPrice)
        {
            foreach (Restaurant restaurant in _restaurants)
            {
                if (restaurant.getId() == idRestaurant && !restaurant.getisFiliale())
                {
                    restaurant.changePricePlat(nomPlat, newPrice);
                }
            }

        }

        public double getPricePlatRestaurant(string nomPlat, int IdRestaurant)
        {
            double price = 0;
            foreach(Restaurant restaurant in _restaurants)
            {
                if(restaurant.getId() == IdRestaurant)
                {
                    var plats = restaurant.Menu.getPlat();
                    foreach(Plat plat in plats)
                    {
                        if (plat.Nom == nomPlat)
                            price = plat.Prix;
                    }
                }
            }
            return price;
        }

        public double getCA()
        {
            double total = 0;
            foreach(Restaurant restaurant in _restaurants)
            {
                total += restaurant.CA_Restaurant;
            }
            return total;
        }
    }
}
