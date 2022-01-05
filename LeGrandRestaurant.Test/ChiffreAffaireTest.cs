using Xunit;

namespace LeGrandRestaurant.Test
{
    public class ChiffreAffaireTest
    {
        // SCOPE SERVEUR
        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur " +
                            "QUAND on récupére son chiffre d'affaires " +
                            "ALORS celui-ci est à 0")]
        public void ChiffreAffaireAtZero()
        {
            //ÉTANT DONNÉ un nouveau serveur
            var serveur = new Serveur(1);
            var restaurant = new Restaurant();


            //QUAND on récupére son chiffre d'affaires

            var servCA = serveur.getCA();

            //ALORS celui-ci est à 0

            Assert.Equal(0, servCA);
        }

        [Fact(DisplayName = "ÉTANT DONNÉ un nouveau serveur " +
                            "QUAND il prend une commande " +
                            "ALORS son chiffre d'affaires est le montant de celle-ci")]

        public void ChiffreAffaireAtOrder()
        {
            //ÉTANT DONNÉ un nouveau serveur
            var serveur = new Serveur(1);
            var restaurant = new Restaurant();
            var commande = new Commande();
            var menu = new Menu();
            var plat = new Plat("Pates au saumon", 15.2);
            //QUAND il prend une commande
            menu.ajouterPlat(plat);
            restaurant.AjouteMenu(menu);
            //ALORS son chiffre d'affaires est le montant de celle-ci
            Assert.Equal(serveur.getCA(), plat.Prix);

        }
        [Fact(DisplayName = "ÉTANT DONNÉ un serveur ayant déjà pris une commande " +
                           "QUAND il prend une nouvelle commande " +
                           "ALORS son chiffre d'affaires est la somme des deux commandes")]

        public void ChiffreAffaireSomme()
        {
            //ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var serveur = new Serveur(1);
            var restaurant = new Restaurant();
            var commande = new Commande();
            var menu = new Menu();
            var plat = new Plat("Pates au saumon", 15.2);
            menu.ajouterPlat(plat);
            restaurant.AjouteMenu(menu);
            //QUAND il prend une nouvelle commande
            var plat2 = new Plat("Pates au thon", 18);
            menu.ajouterPlat(plat2);
            restaurant.AjouteMenu(menu);

            commande.ajouterPlat(plat);
            commande.ajouterPlat(plat2);


            serveur.takeOrder(commande);

            serveur.getCA();
          
            //ALORS son chiffre d'affaires est la somme des deux commandes
            Assert.Equal(serveur.getCA(), plat.Prix + plat2.Prix);

        }

        // SCOPE RESTAURANT
        [Fact(DisplayName = "ÉTANT DONNÉ un restaurant ayant X serveurs " +
                            "QUAND tous les serveurs prennent une commande d'un montant Y " +
                            "ALORS le chiffre d'affaires de la franchise est X * Y")]
        public void ChiffreAffaireAtRestaurant()
        {
            //ÉTANT DONNÉ un restaurant ayant X serveurs
            
            //QUAND tous les serveurs prennent une commande d'un montant Y

            //ALORS le chiffre d'affaires de la franchise est X * Y

           
        }

    }
}
