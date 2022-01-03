using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeGrandRestaurant.Test
{
    public class EpinglageTest
    {
        [Fact(DisplayName = "ÉTANT DONNE un serveur ayant pris une commande " +
                            "QUAND il la déclare comme non-payée " +
                            "ALORS cette commande est marquée comme épinglée")]
        public void CommandeNoPaid_Epingle()
        {
            // ÉTANT DONNE un serveur ayant pris une commande
            var commande = new Commande();
            var serveur = new Serveur(commande);
            var restaurant = new Restaurant(serveur);
            var epinglage = new Epinglage();

            serveur.takeOrder(commande);

            // QUAND il la déclare comme non-payée 
            var reponse = serveur.OrderNoPaid(commande);

            // ALORS cette commande est marquée comme épinglée
            epinglage.OrderEping(reponse);
            Assert.True(reponse);


        }

        [Fact(DisplayName = "ÉTANT DONNE un serveur ayant épinglé une commande " +
                            "QUAND elle date d'il y a au moins 15 jours " +
                            "ALORS cette commande est marquée comme à transmettre gendarmerie")]
        public void CommandeNoPaid_Gendarmerie()
        {
            // ÉTANT DONNE un serveur ayant épinglé une commande

            var commandes = new List<Commande>() { new Commande(), new Commande(), new Commande() };
            var commande1 = new Commande();
            var commande2 = new Commande();
            var commande3 = new Commande();
            var serveur1 = new Serveur(commande1);
            var serveur2 = new Serveur(commande2);
            var serveur3 = new Serveur(commande3);
            var reponse1 = serveur1.OrderNoPaid(commande1);
            var reponse2 = serveur2.OrderNoPaid(commande2);
            var reponse3 = serveur3.OrderNoPaid(commande3);
            var epingle1 = new Epinglage(reponse1, new DateTime(01-01-2022));
            var epingle2 = new Epinglage(reponse2, new DateTime(15-12-2021));
            var epingle3 = new Epinglage(reponse3, new DateTime(01-12-2020));
            

            // QUAND elle date d'il y a au moins 15 jours 
            var reponse = commande1.DateSendGendarmerie(epingle1);

            // ALORS cette commande est marquée comme à transmettre gendarmerie
            Assert.Contains("transmettre gendarmerie", reponse);
        }

    }
}
