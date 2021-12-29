

using System.Collections.Generic;

namespace LeGrandRestaurant
{
    public class Master : TableAffected
    {
        private readonly int _Id;
      

        public Master(int Id)
        {
            this._Id = Id;
        }
        public int getId()
        {
            return this._Id;
        }


    }
}
