using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Epinglage
    {
        
        private bool _isEping = false;
        private Serveur serveur;
        private Commande command;

      
        public  DateTime date;

        List<Commande> commandeNotPaid = new List<Commande>();


        public Epinglage()
        {
           
        }
        public Epinglage(bool isEping, DateTime date)
        {
            this._isEping = isEping;
            this.date = date;
            
        }
       


        public bool OrderEping(bool isPaid)
        {
            if(isPaid)
                commandeNotPaid.Add(command);

            return isPaid;
            
        }
      
        public DateTime GetDate
        {
            get { return _date; }
            set { _date = value; }
        }

    }
}
