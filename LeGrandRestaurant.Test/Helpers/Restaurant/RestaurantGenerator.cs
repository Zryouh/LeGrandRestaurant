using System.Collections.Generic;

namespace LeGrandRestaurant.Test.Helpers
{
    internal class RestaurantGenerator
    {
        public IEnumerable<Restaurant> Generate(int nombre)
        {
            List<Table> tables = new();
            List<Serveur> serveur = new();

            for (int i = 0; i < nombre; i++)
            {
                yield return new Restaurant(tables, serveur);
            }

        }
    }
}
