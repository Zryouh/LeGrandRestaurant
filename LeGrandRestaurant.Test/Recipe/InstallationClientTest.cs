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
            int nombreDeTables = 10;
            int nombreDeClients = 10;
            int depart = 4; // x clients partent en même temps

            // ÉTANT DONNE X tables dans un restaurant ayant débuté son service
            var tables = new TableGenerator(isIntegration).Generate(nombreDeTables).ToList();
            var clients = new ClientGenerator(isIntegration).Generate(nombreDeClients).ToList();
            Restaurant restaurant = new Restaurant(tables);

            // On affecte une table à chaque client
            for(int i = 0; i < tables.Count(); i++)
            {
                Table table = tables[i];
                Client client = clients[i];

                table.AffecterA(client);
            }

            // Quelques clients partent

            for (int i = 0; i < tables.Count(); i++)
            {
                Table table = tables[i];
                if((i +1) % depart == 0)
                {
                    table.Libérer();
                }

            }

            // Alors il reste "depart % nombreDeTables" libre
            int nombreTablesLibres = restaurant.TablesesLibres.Count();
            int nombreDeDepart = nombreDeClients / depart;
            Assert.Equal(nombreTablesLibres, nombreDeDepart);

        }
    }
}
