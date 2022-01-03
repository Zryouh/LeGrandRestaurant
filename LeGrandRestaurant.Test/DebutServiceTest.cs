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
            var tables = new List<Table>() { new Table(), new Table(), new Table() };
            var master1 = new Master(1);
            var restaurant = new Restaurant(tables.ToArray());

            //restaurant.nbrTables(3);

            // QUAND le service commence
            restaurant.DébuterService();
            // ALORS elles sont toutes affectées au Maître d'Hôtel
            foreach (var table in tables)
            {
                table.AffecterM(master1);
            }
            foreach (var table in tables)
            {
                Assert.Equal(table.gettableAffectedMaster().getId(), 1);
            }

            
        }



        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
                             "QUAND le service débute" +
                             "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel")]
        public void AffectationTable_Serveur_Maitre()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables
            var tables = new List<Table>() { new Table(), new Table(), new Table() };
            var master = new Master(1);
            var serveur = new Serveur(1);
            var restaurant = new Restaurant(tables.ToArray());

            //restaurant.nbrTables(3);

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

            Assert.Equal(numTableMaster, 2);
            Assert.Equal(numTableServeur, 1);
        }


        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
                             "QUAND le service débute" +
                             "ALORS il n'est pas possible de modifier le serveur affecté à la table")]
        public void AffectationTable_NoModifServeur()
        {
            // ÉTANT DONNE un restaurant ayant 3 tables
            var tables = new List<Table>() { new Table(), new Table(), new Table() };
            var master = new Master(1);
            var serveur1 = new Serveur(1);
            var serveur2 = new Serveur(2);
            var restaurant = new Restaurant(tables.ToArray());

            //restaurant.nbrTables(3);
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
            // ALORS elles sont toutes affectées au Maître d'Hôtel
            foreach (var table in tables)
            {
                if(table.gettableAffectedServeur() != null)
                    table.AffecterS(serveur2);
            }

            foreach (var table in tables)
            {
                if(table.gettableAffectedServeur() != null)
                    Assert.Equal(table.gettableAffectedServeur().getId(), 1);
            }
           
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur" +
                            "ET ayant débuté son service" +
                            "QUAND le service débute ET qu'une table est affectée à un serveur" +
                            "ALORS la table éditée est affectée au serveur et les deux autres au maître d'hôtel")]
        public void AffectationTable_Serveur_Maitre_ServiceFini()
        {
            // ÉTANT DONNÉ un restaurant ayant 3 tables dont une affectée à un serveur
            var tables = new List<Table>() { new Table(), new Table(), new Table() };
            var master = new Master(1);
            var serveur = new Serveur(1);
            var restaurant = new Restaurant(tables.ToArray());

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

            Assert.Equal(numTableMaster, 2);
            Assert.Equal(numTableServeur, 1);
        }

    }

}
