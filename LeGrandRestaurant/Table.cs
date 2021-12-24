using System;

namespace LeGrandRestaurant
{
    public class Table
    {
        private readonly int _nbTable = 3;
        public Table()
        {
            
        }
        public void AffecterA(Client client)
        {
            EstLibre = false;
        }
        public void AffecterM(Master master)
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

        internal bool EstLibre { get; private set; } = true;

    }
}
