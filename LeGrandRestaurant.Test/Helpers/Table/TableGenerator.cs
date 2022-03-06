using System.Collections.Generic;

namespace LeGrandRestaurant.Test.Helpers
{
    class TableGenerator
    {

        private readonly TableBuilder _builder;

        public TableGenerator(bool isIntegration = false)
        {
            _builder = new TableBuilder(isIntegration);
        }

        public IEnumerable<Table> Generate(int nombre)
        {
            for (var i = 0; i < nombre; i++)
            {
                yield return _builder.Build();
            }
        }
    }
}
