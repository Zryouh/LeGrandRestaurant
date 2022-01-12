using Xunit;

namespace LeGrandRestaurant.Test
{
    public class CommandeClientTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un serveur dans un restaurant " +
                            "QUAND il prend une commande de nourriture " +
                            "ALORS cette commande apparaît dans la liste de tâches de la cuisine de ce restaurant")]
        public void CommandeClient_ajoutTache()
        {
            // ÉTANT DONNE un serveur dans un restaurant
            var serveur = new Serveur(1);
            var commande = new Commande();
            var restaurant = new Restaurant(serveur);


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
            var serveur = new Serveur(1);
            var commande = new Commande();
            var restaurant = new Restaurant(serveur);


            // QUAND il prend une commande de boisson
            serveur.getDrink(commande);

            // ALORS cette commande n'apparaît pas dans la liste de tâches de la cuisine de ce restaurant
            var tacheCuisine = restaurant.TacheCuisine;
            Assert.DoesNotContain(commande, tacheCuisine);
        }

        //SCENARIO DE TEST DE RECETTE
        // Le client entre dans le restaurant,
        // le serveur lui attribue sa table ,
        // le client prend commande auprés du serveur et il lui donne le plat.  

    }
}
