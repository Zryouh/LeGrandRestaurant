using LeGrandRestaurant.Test.Helpers;
using System.Collections.Generic;
using Xunit;

namespace LeGrandRestaurant.Test.Unit
{
    public class DebutServiceTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant 3 tables " +
                            "QUAND le service commence " +
                            "ALORS elles sont toutes affectées au Maître d'Hôtel")]
        public void AffectationTable_Maitre()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables
            var master1 = new Master(1);
            var restaurant = new RestaurantBuilder().avecXTable(3);
            var tables = restaurant.getTables();


            //restaurant.nbrTables(3);

            // QUAND le service commence
            restaurant.DébuterService();
            // ALORS elles sont toutes affectées au Maître d'Hôtel
            foreach (var table in tables)
            {
                table.AffecterM(master1);
            }

            Assert.All(tables, item => Assert.Equal(item.gettableAffectedMaster().getId(), master1.getId()));
        }



        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
                             "QUAND le service débute" +
                             "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel")]
        public void AffectationTable_Serveur_Maitre()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables
            var master = new Master(1);
            var restaurant = new RestaurantBuilder().avecXTableEtXServeur(3, 1);
            var tables = restaurant.getTables();
            var serveur = restaurant.getServeurs()[0];

            // QUAND le service commence
            restaurant.DébuterService();

            // ALORS elles sont toutes affectées au Maître d'Hôtel
            var i = 0;
            foreach (var table in tables)
            {
                if (i < 2)
                {
                    table.AffecterM(master);
                    i++;
                } 
                else
                    table.AffecterS(serveur);
            }

            var numTableMaster = 0;
            var numTableServeur = 0;

            foreach (var table in tables)
            {
                if(table.gettableAffectedMaster() != null)
                    numTableMaster++;
                else if(table.gettableAffectedServeur() != null)
                    numTableServeur++;

            }

            Assert.Equal(2, numTableMaster);
            Assert.Equal(1, numTableServeur);
        }


        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
                             "QUAND le service débute" +
                             "ALORS il n'est pas possible de modifier le serveur affecté à la table")]
        public void AffectationTable_NoModifServeur()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables
            var master = new Master(1);

            var restaurant = new RestaurantBuilder().avecXTableEtXServeur(3, 2);
            var tables = restaurant.getTables();
            var serveur1 = restaurant.getServeurs()[0];
            var serveur2 = restaurant.getServeurs()[1];


            var i = 0;
            // QUAND le service commence
            foreach (var table in tables)
            {
                if ( i < 2) {  
                    table.AffecterM(master);
                    i++;
                }
                else
                    table.AffecterS(serveur1);
            }
            restaurant.DébuterService();
            // ALORS il n'est pas possible de modifier le serveur affecté à la table
            foreach (var table in tables)
            {
                table.AffecterS(serveur2);
            }

            Assert.Equal(tables[2].gettableAffectedServeur().getId(), serveur1.getId());
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
                            "ET ayant débuté son service" +
                            "QUAND le service débute ET qu'une table est affectée à un serveur" +
                            "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel")]
        public void AffectationTable_Serveur_Maitre_ServiceFini()
        {
            // ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
            var master = new Master(1);
            var restaurant = new RestaurantBuilder().avecXTableEtXServeur(3, 2);
            var tables = restaurant.getTables();
            var serveur = restaurant.getServeurs()[0];

            restaurant.DébuterService();
            

            // QUAND le service se termine
            restaurant.FinService();

            //ET qu'une table est affectée à un serveur
            var j = 0;
            foreach(var table in tables )
            {
                if (j == 1)
                    table.AffecterS(serveur);
            }

            // ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel
            var i = 0;
            foreach (var table in tables)
            {
                if (i < 2)
                {
                    table.AffecterM(master);
                    i++;
                }
                else
                    table.AffecterS(serveur);
            }

            var numTableMaster = 0;
            var numTableServeur = 0;

            foreach (var table in tables)
            {
                if (table.gettableAffectedMaster() != null)
                    numTableMaster++;
                else if (table.gettableAffectedServeur() != null)
                    numTableServeur++;

            }

            Assert.Equal(2, numTableMaster);
            Assert.Equal(1, numTableServeur);
        }

    }

}
