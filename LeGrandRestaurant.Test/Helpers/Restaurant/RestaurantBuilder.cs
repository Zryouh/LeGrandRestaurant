using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant.Test.Helpers
{
    class RestaurantBuilder
    {
        private readonly IList<Table> _tableRepository;
        private readonly IList<Serveur> _serveurRepository;


        public RestaurantBuilder(bool isIntegration = false)
        {
            _tableRepository = isIntegration ? new DatabaseTableRepository() : new List<Table>();
            _serveurRepository = isIntegration ? new DatabaseServeurRepository() : new List<Serveur>();
        }

        public Restaurant Build()
        {
            List<Table> tables = new();
            List<Serveur> serveurs = new();

            Restaurant restaurant = new(tables, serveurs);
            return restaurant;
        }

        public Restaurant avecUnServeurEtUneTable()
        {
            List<Serveur> serveurs = new();
            var serveur = new Serveur(1);
            serveurs.Add(serveur);

            List<Table> tables = new();
            var table = new Table();
            tables.Add(table);

            Restaurant restaurant = new(tables, serveurs);
            return restaurant;
        }

        public Restaurant avecXServeur(int nbr)
        {

            var serveurs = new ServeurGenerator().Generate(nbr).ToList();
            List<Table> tables = new();

            Restaurant restaurant = new(tables, serveurs);
            return restaurant;
        }

        public Restaurant avecXTable(int nbr)
        {

            var tables = new TableGenerator().Generate(nbr).ToList();
            List<Serveur> serveurs = new();

            Restaurant restaurant = new(tables, serveurs);
            return restaurant;
        }

        public Restaurant avecXTableEtXServeur(int nbrTable, int nbrServeur)
        {

            var tables = new TableGenerator().Generate(nbrTable).ToList();
            var serveurs = new ServeurGenerator().Generate(nbrServeur).ToList();

            Restaurant restaurant = new(tables, serveurs);
            return restaurant;
        }

        public Restaurant avecUneTableAffectée()
        {
            Restaurant restaurant = new RestaurantBuilder().avecXTable(1);
            var table = restaurant.getTables()[0];

            var client = new Client();

            table.AffecterA(client);
            return restaurant;
        }
    }
}
