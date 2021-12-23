using Xunit;

namespace LeGrandRestaurant.Test
{
    public class InstallationClientTest
    {
        [Fact(DisplayName = "ÉTANT DONNE une table dans un restaurant ayant débuté son service " +
                            "QUAND un client est affecté à une table " +
                            "ALORS cette table n'est plus sur la liste des tables libres du restaurant")]
        public void InstallationClient_RetireLaTable()
        {
            // ÉTANT DONNE une table dans un restaurant ayant débuté son service
            var table = new Table();
            var client = new Client();

            var restaurant = new Restaurant(table);
            restaurant.DébuterService();

            // QUAND un client est affecté à une table
            table.AffecterA(client);

            // ALORS cette table n'est plus sur la liste des tables libres du restaurant
            var tablesLibres = restaurant.TablesesLibres;
            Assert.DoesNotContain(table, tablesLibres);
        }

        [Fact(DisplayName =  "ÉTANT DONNE une table occupée par un client " +
                             "QUAND la table est libérée " +
                             "ALORS cette table appraît sur la liste des tables libres du restaurant")]
        public void DépartClient_RemetLaTable()
        {
            // ÉTANT DONNE une table occupée par un client
            var table = new Table();
            var client = new Client();
            var restaurant = new Restaurant(table);
            table.AffecterA(client);

            // QUAND la table est libérée
            table.Libérer();

            // ALORS cette table appraît sur la liste des tables libres du restaurant
            var tablesLibres = restaurant.TablesesLibres;
            Assert.Contains(table, tablesLibres);
        }
    }
}
