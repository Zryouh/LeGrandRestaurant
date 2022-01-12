using LeGrandRestaurant;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplicationJsonSerialisation
{
    class Program
    {
        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, 2);
        }
        static void Main(string[] args)
        {
            
            //Création de l'objet
            {
                //Client client = new Client() {Nom="durand", Prenom="paul", Mail="durand.paul@gmail.com" };

                //string jsonSerializeObj = JsonConvert.SerializeObject(client);

                //File.WriteAllText(@"d:\monfichierResultat.json", jsonSerializeObj);
                

                List<Commande> commandes = new List<Commande>() {};
               
                for(int i = 1; i < 30; i++)
                {
                    Plat plat = new Plat("Plat N°" + i, GetRandomNumber(10.0, 100.0));
                    Commande commande = new Commande();
                    commande.ajouterPlat(plat);
                    commandes.Add(commande);
                }

                string jsonSerializeObj = JsonConvert.SerializeObject(commandes);

                File.WriteAllText(@"d:\monfichierResultat.json", jsonSerializeObj);

            }
        }
    }
}
