using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeGrandRestaurant
{
    public class Commande
    {
        private string _sendMessage = "transmettre gendarmerie";
        private Epinglage epingle;
        private bool isSendGendarmerie = false;
        public string DateSendGendarmerie(Epinglage epinglage)
        {
            DateTime localDate = DateTime.Now;
            if (localDate.Day - epinglage.GetDate.Day >= 15)
            {
                this.isSendGendarmerie = true;
                return this._sendMessage;
            }
            return "";
            

        }

    }
}
