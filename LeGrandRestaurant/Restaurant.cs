﻿using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly Table[] _tables ;
        private readonly Serveur[] _serveurs;
      
        public Restaurant(params Table[] tables)
        {
            _tables = tables;
        }
        public Restaurant(params Serveur[] serveurs)
        {
            _serveurs = serveurs;
        }

        public Table[] TablesesLibres => _tables.Where(table => table.EstLibre).ToArray();

        public IEnumerable<Commande> TacheCuisine => _serveurs.SelectMany(serveur => serveur.GetCommandes);

        public IEnumerable<Table> NbrTables => _tables.Where(table => table.EstLibre).ToArray();

        public void DébuterService()
        {

        }
        public void nbrTables(int table)
        {
           
        }
    }
}
