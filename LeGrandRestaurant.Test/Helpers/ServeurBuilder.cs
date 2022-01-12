using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant.Test.Helpers
{
    internal class ServeurBuilder
    {


        private readonly IList<Commande> _commandesRepository;

        //public ServeurBuilder(bool isIntegration = false)
        //{

        //    _commandesRepository = isIntegration ? new DatabaseCommandeRepository() : new List<Commande>();
        //}

        //public Serveur Build() => new (_commandesRepository);


    }
}
