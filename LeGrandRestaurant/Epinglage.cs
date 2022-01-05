using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Epinglage
    {
        public Commande _commande;
        public DateTime _date;
        public bool isSendGendarmerie = true;
       
       
        public Epinglage(Commande commande, DateTime date)
        {
            commande.makeEpingle();
            this._commande = commande;
            this._date = date;
        }

        public DateTime GetDate
        {
            get { return _date; }
            set { _date = value; }
        }

        

    }
}

