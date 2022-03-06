using System;
using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Table
    {
        private readonly int _nbTable = 3;
        Master tableAffectedMaster = null;
        Serveur tableAffectedServeur = null;
        internal bool EstLibre { get; private set; } = true;



        public Table()
        {
            
            
        }
        public void AffecterA(Client client)
        {
            EstLibre = false;
        }
        public void Libérer()
        {
            EstLibre = true;
        }
        public void NbrTables(int nbrTable)
        {
            
        }
   
        public void AffecterM(Master master)
        {
            tableAffectedMaster = master;
        }

        public Master gettableAffectedMaster()
        {
            return tableAffectedMaster;
        }
        public void AffecterS(Serveur serveur)
        {
            if(tableAffectedServeur == null)
                tableAffectedServeur = serveur;
        }

        public Serveur gettableAffectedServeur()
        {
            return tableAffectedServeur;
        }

        public bool libre()
        {
            return EstLibre;
        }


    }
}
