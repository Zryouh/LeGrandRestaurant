using System.Collections.Generic;

namespace LeGrandRestaurant.Test.Helpers
{
    class TableBuilder
    {
        private readonly IList<Table> _tableRepository;

        public TableBuilder(bool isIntegration = false)
        {
            _tableRepository = isIntegration ? new DatabaseTableRepository() : new List<Table>();
        }

        public Table Build() => new();
    }
}
