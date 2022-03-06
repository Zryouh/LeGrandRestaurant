using System.Collections.Generic;

namespace LeGrandRestaurant.Test.Helpers
{
    class ClientGenerator
    {

        private readonly ClientBuilder _builder;

        public ClientGenerator(bool isIntegration = false)
        {
            _builder = new ClientBuilder(isIntegration);
        }

        public IEnumerable<Client> Generate(int nombre)
        {
            for (var i = 0; i < nombre; i++)
            {
                yield return _builder.Build();
            }
        }
    }
}
