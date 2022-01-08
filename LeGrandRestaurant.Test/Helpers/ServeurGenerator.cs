

using System.Collections.Generic;

namespace LeGrandRestaurant.Test.Helpers
{
    internal class ServeurGenerator
    {

        public IEnumerable<Serveur> Generate(int nombre)
        {

            for(int i = 0; i < nombre; i++)
            {
                yield return new Serveur();
            }


        }



    }
}
