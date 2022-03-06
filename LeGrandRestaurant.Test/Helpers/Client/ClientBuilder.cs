using System.Collections.Generic;

namespace LeGrandRestaurant.Test.Helpers
{
    class ClientBuilder
    {
        private readonly IList<Client> _clientRepository;

        public ClientBuilder(bool isIntegration = false)
        {
            _clientRepository = isIntegration ? new DatabaseClientRepository() : new List<Client>();
        }

        public Client Build() => new();
    }
}
