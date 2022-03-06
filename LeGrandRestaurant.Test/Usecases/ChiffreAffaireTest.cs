using LeGrandRestaurant.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeGrandRestaurant.Test.Usecases
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

            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var commande = new Commande();

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];


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
            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var menu = new Menu();
            var plat = new Plat("Pates au saumon", 15.2);
            menu.ajouterPlat(plat);
            restaurant.AjouteMenu(menu);

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];

            //QUAND il prend une commande
            var commande = new Commande();
            commande.ajouterPlat(plat);
            serveur.takeOrder(commande);
            
            //ALORS son chiffre d'affaires est le montant de celle-ci
            Assert.Equal(serveur.getCA(), plat.Prix);

        }
        [Fact(DisplayName = "ÉTANT DONNÉ un serveur ayant déjà pris une commande " +
                           "QUAND il prend une nouvelle commande " +
                           "ALORS son chiffre d'affaires est la somme des deux commandes")]

        public void ChiffreAffaireSomme()
        {
            //ÉTANT DONNÉ un serveur ayant déjà pris une commande
            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var commande = new Commande();

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];

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

            Random rdn = new Random();
            var plat = new Plat("pates au saumon", rdn.Next(10, 50)) ;
            var commande = new Commande();
            commande.ajouterPlat(plat);

            var nbrServeurs = 100;


            var restaurant = new RestaurantBuilder().avecXServeur(nbrServeurs);
            var serveurs = restaurant.getServeurs();

            //QUAND tous les serveurs prennent une commande d'un montant Y

            foreach (Serveur serveur in serveurs)
            {
                serveur.takeOrder(commande);
            }
            //ALORS le chiffre d'affaires de la franchise est X * Y

            Assert.Equal(nbrServeurs * plat.Prix, restaurant.CA_Restaurant);

        }

        // SCOPE Franchise
        [Fact(DisplayName = "ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacuns " +
                            "QUAND tous les serveurs prennent une commande d'un montant Z " +
                            "ALORS le chiffre d'affaires de la franchise est X * Y * Z" +
                            "CAS(X = 0; X = 1; X = 2; X = 1000)" +
                            "CAS(Y = 0; Y = 1; Y = 2; Y = 1000)" +
                            "CAS(Z = 1.0)" )]
        public void ChiffreAffaireAtRestaurantAtServeur()
        {
            //ÉTANT DONNÉ une franchise ayant X restaurants de Y serveurs chacuns
            Random rdn = new Random();
            var plat = new Plat("pates au saumon", rdn.Next(10, 50));
            var commande = new Commande();
            commande.ajouterPlat(plat);

            var nbrResto = 100;
            var nbrServ = 100;

            var franchise = new FranchiseBuilder().avecXRestaurantXTableEtXServeur(nbrResto, 1, nbrServ);
            var restaurants = franchise.getRestaurants();


            //QUAND tous les serveurs prennent une commande d'un montant Z
            foreach (Restaurant restaurant in restaurants)
            {
                List<Serveur> serveurs = restaurant.getServeurs();
                foreach (Serveur serveur in serveurs)
                {
                    serveur.takeOrder(commande);
                }
            }
            
            //ALORS le chiffre d'affaires de la franchise est X * Y * Z
            Assert.Equal(nbrResto * nbrServ * plat.Prix, franchise.getCA());

            //CAS(X = 0; X = 1; X = 2; X = 1000)
            //CAS(Y = 0; Y = 1; Y = 2; Y = 1000)
            //CAS(Z = 1.0)



        }

    }
}
