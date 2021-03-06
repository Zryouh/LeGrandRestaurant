using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly List<Table> _tables ;
        private List<Serveur> _serveurs { get; set; }
        private Menu _menu { get; set; }
        private bool isFiliale = false;
        private readonly int _Id;
       
        public List<Epinglage> epinglages = new List<Epinglage>();

        public List<Epinglage> sentPoulet = new List<Epinglage>();
        public double CA_Restaurant { get; set; }


        public Restaurant(int Id)
        {
            this._Id = Id;
        }

        public List<Table> getTables()
        {
            return _tables;
        }

        public int getId()
        {
            return this._Id;
        }
        public List<Serveur> getServeurs()
        {
            return this._serveurs;
        }
        public void addServeurs(List<Serveur> serveurs)
        {
            foreach(Serveur serveur in serveurs)
            {
                this._serveurs.Concat(serveurs);
            }
        }

        public Restaurant(List<Table> tables)
        {
            _tables = tables;
        }

        public Restaurant(List<Table> tables, List<Serveur> serveurs)
        {
            _tables = tables;

            foreach (Serveur serveur in serveurs)
            {
                serveur.setRestauant(this);
            }
            _serveurs = serveurs;
        }
     
        public void ajouterCA_Restaurant(double prix)
        {
            this.CA_Restaurant += prix;
        }

        public Menu Menu
        {
            get => _menu;
            set => _menu = value;
        }

        public void BeFiliale()
        {
            isFiliale = true;
        }
        public bool getisFiliale()
        {
            return isFiliale;
        }
        public void changePricePlat(string nomPlat, double newPrice)
        {
            var plats = _menu.getPlat();
            foreach(Plat plat in plats)
            {
                if (plat.Nom == nomPlat)
                    plat.Prix = newPrice;
            }
        }

        public bool IsFiliale => isFiliale; 

        public List<Table> TablesesLibres => _tables.Where(table => table.EstLibre).ToList();

        public IEnumerable<Commande> TacheCuisine => _serveurs.SelectMany(serveur => serveur.GetCommandes);

        public IEnumerable<Table> NbrTables => _tables.Where(table => table.EstLibre).ToArray();

        public void DébuterService()
        {

        }
        public void nbrTables(int table)
        {
           
        }
        public void AjouteMenu(Menu menu)
        {
            _menu = menu;
            
        }

        public void FinService()
        {
           
        }
        public void addToEpinglage(Epinglage epinglage)
        {
            epinglages.Add(epinglage);
        }
        public void checkDateCommande(Epinglage epeingle)
        {
            DateTime today = DateTime.Now;
            DateTime limit = epeingle.GetDate.AddDays(15);
            if (today >= limit)
            {
                epeingle.isSendGendarmerie = true;
                this.addToSentPoulet(epeingle);
            }


        }
        public void addToSentPoulet(Epinglage epinglage)
        {
            sentPoulet.Add(epinglage);
            this.removeFromEpinglage(epinglage);
        }

        public void removeFromEpinglage(Epinglage epinglage)
        {
            epinglages.Remove(epinglage);
        }

        public IEnumerable<Epinglage> getListOrderGendarmerie => sentPoulet;
        public IEnumerable<Epinglage> getListOrderATransmettre => epinglages;



    }
}
