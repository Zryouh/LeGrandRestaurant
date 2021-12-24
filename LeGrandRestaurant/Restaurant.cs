using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly Table[] _tables ;
        private readonly Serveur[] _serveurs;
        private Menu _menu { get; set; }

        internal bool isFiliale { get; private set; } = true;

        public Restaurant()
        {

        }

        public Restaurant(params Table[] tables)
        {
            _tables = tables;
        }
        public Restaurant(params Serveur[] serveurs)
        {
            _serveurs = serveurs;
        }

        public Menu Menu
        {
            get => _menu;
            set => _menu = value;
        }

        public void Franchiser()
        {
            isFiliale = false;
        }

        public bool IsFiliale => isFiliale;

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
