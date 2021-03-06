using LeGrandRestaurant.Test.Helpers;
using Xunit;

namespace LeGrandRestaurant.Test.Usecases
{
	
	public class MenuTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise " +
                            "ET une franchise définissant un menu ayant un plat " +
                            "QUAND la franchise modifie le prix du platt " +
                            "ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise")]
        public void Modification_Prix_Menu()
        {
            // ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise
            var franchise = new FranchiseBuilder().Build();
            var table = new Table();
            var restaurant = new Restaurant(1);
            restaurant.BeFiliale();
            franchise.AjouterRestaurant(restaurant);

            // ET une franchise définissant un menu ayant un plat
            var menu = new Menu();
            var plat = new Plat("Pates au saumon", 15.2);

            menu.ajouterPlat(plat);
            franchise.AjouteMenu(menu);
            //restaurant.Menu = menu;
            // QUAND la franchise modifie le prix du plat
            double Nouveau_prix = 18;
            franchise.changerPrix("Pates au saumon", Nouveau_prix);
            franchise.changerPrixPlatRestaurant("Pates au saumon", 1, 25);
            //ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise
            
            Assert.Equal(18 , franchise.getPricePlatRestaurant("Pates au saumon", 1));
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat " +
                           "ET une franchise définissant un menu ayant le même plat " +
                           "QUAND la franchise modifie le prix du plat " +
                           "ALORS le prix du plat dans le menu du restaurant reste inchangé")]
        public void NoModification_Prix_Menu()
        {
            // ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var franchise = new FranchiseBuilder().Build();
            var table = new Table();
            var restaurant = new Restaurant(1);
          
            franchise.AjouterRestaurant(restaurant);

            // ET une franchise définissant un menu ayant le même plat
            var menu = new Menu();
          
            var plat = new Plat("Pates au saumon", 15.2);

            menu.ajouterPlat(plat);
            franchise.AjouteMenu(menu);
            //restaurant.Menu = menu;
            restaurant.AjouteMenu(menu);
            // QUAND la franchise modifie le prix du plat
            franchise.changerPrixPlatRestaurant("Pates au saumon", 1, 25);
            double Nouveau_prix = 18;
            franchise.changerPrix("Pates au saumon", Nouveau_prix);
            //ALORS le prix du plat dans le menu du restaurant reste inchangé
            
            Assert.Equal(25, franchise.getPricePlatRestaurant("Pates au saumon",1));
        }

        [Fact(DisplayName = "ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat " +
                           "QUAND la franchise ajoute un nouveau plat " +
                           "ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise")]
        public void Restaurant_Carte_Prix()
        {
            // ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
            var franchise = new FranchiseBuilder().Build();
            var table = new Table();
            var restaurant = new Restaurant(1);

            franchise.AjouterRestaurant(restaurant);

            // ET une franchise définissant un menu ayant le même plat
            var menu = new Menu();

            var plat = new Plat("Pates au saumon", 15.2);

            menu.ajouterPlat(plat);
            //QUAND la franchise ajoute un nouveau plat
            var plat2 = new Plat("hamburger", 18);
            menu.ajouterPlat(plat2);

            franchise.AjouteMenu(menu);
            restaurant.AjouteMenu(menu);

           
            //ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise

            Assert.NotEqual(restaurant.Menu.recherchePlat("Pates au saumon").Prix, franchise.getPricePlatRestaurant("hamburger", 1));


        }
    }
}
