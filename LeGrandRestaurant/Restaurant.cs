using System.Linq;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly Table[] _tables;

        public Restaurant(params Table[] tables)
        {
            _tables = tables;
        }
        
        public Table[] TablesesLibres => _tables.Where(table => table.EstLibre).ToArray();

        public void DébuterService()
        {
        }
    }
}
