using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Plat
    {
        private readonly string _nom;
        private readonly double _prix;

        public Plat(string nom, double prix)
        {
            _nom = nom;
            _prix = prix;
        }

    }
}
