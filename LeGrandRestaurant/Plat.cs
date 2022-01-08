using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Plat
    {
        private string _nom { get; set; }
        private double _prix { get; set; }
        public Plat()
        {
        
        }
        public Plat(string nom, double prix)
        {
            _nom = nom;
            _prix = prix;
        }


        public double Prix
        {
            get => _prix;
            set => _prix = value;
        }

        public void changerPrix(int prix)
        {
            _prix = prix;
        }
        public string Nom => _nom;
        

    }
}
