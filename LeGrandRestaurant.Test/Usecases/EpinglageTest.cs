using LeGrandRestaurant.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeGrandRestaurant.Test.Usecases
{
    public class EpinglageTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un serveur ayant pris une commande " +
                            "QUAND il la déclare comme non-payée " +
                            "ALORS cette commande est marquée comme épinglée")]
        public void CommandeNoPaid_Epingle()
        {
            // ÉTANT DONNE un serveur ayant pris une commande
            var restaurant = new RestaurantBuilder().avecXServeur(1);

            var commande = new Commande();
            var serveur = restaurant.getServeurs()[0];


            serveur.takeOrder(commande);

            // QUAND il la déclare comme non-payée 
            var reponse = serveur.OrderNoPaid(commande);

            // ALORS cette commande est marquée comme épinglée
            var epinglage = new Epinglage(commande, DateTime.Now);
            restaurant.addToEpinglage(epinglage);
            Assert.True(commande.IsEpingle());


        }

        [Fact(DisplayName = "ÉTANT DONNE un serveur ayant épinglé une commande " +
                            "QUAND elle date d'il y a au moins 15 jours " +
                            "ALORS cette commande est marquée comme à transmettre gendarmerie")]
        public void CommandeNoPaid_Gendarmerie()
        {
            // ÉTANT DONNE un serveur ayant épinglé une commande
            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var commande = new Commande();

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];

            var reponse = serveur.OrderNoPaid(commande);
            var epingle = new Epinglage(commande, new DateTime(2021,12,15));
            // QUAND elle date d'il y a au moins 15 jours 
            restaurant.checkDateCommande(epingle);

            // ALORS cette commande est marquée comme à transmettre gendarmerie
            Assert.True(epingle.isSendGendarmerie);
        }

        [Fact(DisplayName = "ÉTANT DONNE une commande à transmettre gendarmerie " +
                            "QUAND on consulte la liste des commandes à transmettre du restaurant " +
                            "ALORS elle y figure")]
        public void CommandeNoPaid_Gendarmerie_List()
        {
            // ÉTANT DONNE une commande Epingler à transmettre gendarmerie 
            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var commande = new Commande();

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];

            var reponse = serveur.OrderNoPaid(commande);
            var epingle = new Epinglage(commande, new DateTime(2021, 12, 15));
            restaurant.addToEpinglage(epingle);

            restaurant.checkDateCommande(epingle);

            //QUAND on consulte la liste des commandes à transmettre du restaurant
            
            var commandesSentAuxPoulets = restaurant.getListOrderGendarmerie;
            
            // ALORS elle y figure
            Assert.Contains(commandesSentAuxPoulets, epingle => epingle._commande == commande);
        }

        [Fact(DisplayName = "ÉTANT DONNE une commande à transmettre gendarmerie " +
                           "QUAND elle est marquée comme transmise à la gendarmerie " +
                           "ALORS elle ne figure plus dans la liste des commandes à transmettre du restaurant")]
        public void CommandeNoPaid_Gendarmerie_NoList()
        {
            // ÉTANT DONNE une commande à transmettre gendarmerie
            var restaurant = new RestaurantBuilder().avecUnServeurEtUneTable();
            var commande = new Commande();

            var serveurs = restaurant.getServeurs();
            var serveur = serveurs[0];

            var reponse = serveur.OrderNoPaid(commande);
            var epingle = new Epinglage(commande, new DateTime(2021, 12, 15));
            restaurant.addToEpinglage(epingle);


            //QUAND elle est marquée comme transmise à la gendarmerie 
            restaurant.checkDateCommande(epingle);

            

            // ALORS elle ne figure plus dans la liste des commandes à transmettre du restaurant
            Assert.DoesNotContain(restaurant.getListOrderATransmettre, epingle => epingle._commande == commande);
        }

    }
}
