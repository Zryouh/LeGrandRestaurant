using System.Collections.Generic;
using System.Linq;

namespace LeGrandRestaurant.Test.Helpers
{
    class FranchiseBuilder
    {
        private readonly IList<Restaurant> _restaurantRepository;


        public FranchiseBuilder(bool isIntegration = false)
        {
            _restaurantRepository = isIntegration ? new DatabaseRestaurantRepository() : new List<Restaurant>();
        }

        public Franchise Build()
        {
            List<Restaurant> restaurants = new();
            Franchise franchise = new Franchise(restaurants);
            return franchise;
        }

        public Franchise avecXRestaurantXTableEtXServeur(int nbrRestaurant, int nbrTable, int nbrServeur)
        {
            List<Restaurant> restaurants = new();
            var tables = new TableGenerator().Generate(nbrTable).ToList();
            var serveurs = new ServeurGenerator().Generate(nbrServeur).ToList();

            for (int i = 0; i < nbrRestaurant; i++)
            {
                Restaurant restaurant = new(tables, serveurs);
                restaurants.Add(restaurant);

            }

            Franchise franchise = new(restaurants);

            return franchise;
        }
    }
}
