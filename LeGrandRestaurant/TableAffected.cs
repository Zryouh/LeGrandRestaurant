using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class TableAffected
    {
        List<Table> tableAffected = new List<Table>();
        public void AffecterT(Table table)
        {
            tableAffected.Add(table);
        }

        public int getTableAffecter()
        {
            return tableAffected.Count;
        }

    }
}
