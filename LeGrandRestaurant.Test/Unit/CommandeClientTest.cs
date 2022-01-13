using LeGrandRestaurant.Test.Helpers;
using System.Collections.Generic;
using Xunit;

namespace LeGrandRestaurant.Test.Unit
{
    public class CommandeClientTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un serveur dans un restaurant " +
                            "QUAND il prend une commande de nourriture " +
                            "ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant")]
        public void CommandeClient_ajoutTache()
        {
            // ÉTANT DONNE un serveur dans un restaurant

            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var commande = new Commande();

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];


            // QUAND il prend une commande de nourriture
            serveur.getFood(commande);

            // ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant
            var tacheCuisine = restaurant.TacheCuisine;
            Assert.Contains(commande, tacheCuisine);
        }

        [Fact(DisplayName = "ÉTANT DONNE un serveur dans un restaurant " +
                            "QUAND il prend une commande de boisson " +
                            "ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant")]
        public void CommandeClient_retireTache()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var commande = new Commande();

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];


            // QUAND il prend une commande de boisson
            serveur.getDrink(commande);

            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
            var tacheCuisine = restaurant.TacheCuisine;
            Assert.DoesNotContain(commande, tacheCuisine);
        }
    }
}
