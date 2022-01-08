﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly Table[] _tables ;
        private readonly Serveur[] _serveurs;
        private Menu _menu { get; set; }
        private bool isFiliale = false;
        private readonly int _Id;
        private readonly IEnumerable<Serveur> _serveurss;
        public List<Epinglage> epinglages = new List<Epinglage>();

        public List<Epinglage> sentPoulet = new List<Epinglage>();
        public double CA_Restaurant { get; set; }


        public Restaurant(int Id)
        {
            this._Id = Id;
        }
        public int getId()
        {
            return this._Id;
        }


        public Restaurant()
        {

        }

        public Restaurant(params Table[] tables)
        {
            _tables = tables;
        }
        public Restaurant(params Serveur[] serveurs)
        {
            _serveurs = serveurs;
        }
        public Restaurant(IEnumerable<Serveur> serveurs)
        {
            foreach(Serveur serveur in _serveurss)
            {
                serveur.setRestauant(this);
            }

            _serveurss = serveurs;
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

        public Table[] TablesesLibres => _tables.Where(table => table.EstLibre).ToArray();

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
