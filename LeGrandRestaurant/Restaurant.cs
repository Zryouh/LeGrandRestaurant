using System.Linq;

namespace LeGrandRestaurant
{
    public class Restaurant
    {
        private readonly Table[] _tables;
        private readonly Franchise _franchise;

        public Restaurant(params Table[] tables)
        {
            _tables = tables;
        }

        public Restaurant(Franchise franchise, params Table[] tables)
        {
            _tables = tables;
            _franchise = franchise;
        }

        public Table[] TablesesLibres => _tables.Where(table => table.EstLibre).ToArray();

        public void DébuterService()
        {
        }
    }
}
