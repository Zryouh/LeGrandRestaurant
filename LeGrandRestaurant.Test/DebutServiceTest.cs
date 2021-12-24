using System.Collections.Generic;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class DebutServiceTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant 3 tables " +
                            "QUAND le service commence " +
                            "ALORS elles sont toutes affectées au Maître d'Hôtel")]
        public void AffectationTable_Maitre()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables
            var table = new Table();
            var master = new Master();
            var restaurant = new Restaurant(table);

            //restaurant.nbrTables(3);

            // QUAND le service commence
            restaurant.DébuterService();
            // ALORS elles sont toutes affectées au Maître d'Hôtel
            table.AffecterM(master);
            var nbrTalbes = restaurant.NbrTables;
            //Assert.Equal(table.AffecterM(master), nbrTalbes);

        }

    }

        //[Fact(DisplayName =  "ÉTANT DONNE une table occupée par un client " +
        //                     "QUAND la table est libérée " +
        //                     "ALORS cette table appraît sur la liste des tables libres du restaurant")]
        //public void DépartClient_RemetLaTable()
        //{
        //    // ÉTANT DONNE une table occupée par un client
        //    var table = new Table();
        //    var client = new Client();
        //    var restaurant = new Restaurant(table);
        //    table.AffecterA(client);

        //    // QUAND la table est libérée
        //    table.Libérer();

        //    // ALORS cette table appraît sur la liste des tables libres du restaurant
        //    var tablesLibres = restaurant.TablesesLibres;
        //    Assert.Contains(table, tablesLibres);
        //}
    
}
