using Xunit;

namespace LeGrandRestaurant.Test
{
	//ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
	//ET une franchise définissant un menu ayant le même plat
	//QUAND la franchise modifie le prix du plat
	//ALORS le prix du plat dans le menu du restaurant reste inchangé
	//
	//ÉTANT DONNE un restaurant appartenant à une franchise et définissant un menu ayant un plat
	//QUAND la franchise ajoute un nouveau plat
	//ALORS la carte du restaurant propose le premier plat au prix du restaurant et le second au prix de la franchise
	public class MenuTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise " +
                            "ET une franchise définissant un menu ayant un plat " +
                            "QUAND la franchise modifie le prix du platt " +
                            "ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise")]
        public void Modification_Prix_Menu()
        {
            // ÉTANT DONNE un restaurant ayant le statut de filiale d'une franchise
            var franchise = new Franchise();
            var table = new Table();
            var restaurant = new Restaurant(1);
            restaurant.Franchiser();
            franchise.AjouterRestaurant(restaurant);

            // ET une franchise définissant un menu ayant un plat
            var menu = new Menu();
            var plat = new Plat("Pates au saumon", 15.2);

            menu.ajouterPlat(plat);
            franchise.AjouteMenu(menu);
            restaurant.Menu = menu;
            // QUAND la franchise modifie le prix du plat
            double Nouveau_prix = 18;
            franchise.changerPrix("Pates au saumon", Nouveau_prix);
            franchise.changerPrixPlatRestaurant("Pates au saumon", 1, 25);
            //ALORS le prix du plat dans le menu du restaurant est celui défini par la franchise
            
            Assert.Equal(franchise.getPricePlatRestaurant("Pates au saumon", 1),18 );
        }
    }
}
