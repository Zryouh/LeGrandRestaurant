using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using LeGrandRestaurant.Test.Helpers;


namespace LeGrandRestaurant.Test.Recipe
{
    public class InstallationClientTest
    {
        [Theory(DisplayName = "Simulation des tables réservées")]
        [InlineData(true)]
        [InlineData(false)]

        public void ReservationTable(bool isIntegration)
        {
            // ÉTANT DONNE X tables dans un restaurant ayant débuté son service
            var tables = new TableGenerator(isIntegration).Generate(10).ToArray();


            // QUAND toutes les tables sont occuppés

            // ALORS la liste des tables libres du restaurant est vide
        }
    }
}
