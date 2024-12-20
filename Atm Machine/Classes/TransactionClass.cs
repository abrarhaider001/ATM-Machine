using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm_Machine.Classes
{
    public class TransactionClass
    {
        private int id;
        private string userId;
        private DateTime dateTime;
        private int amount;
        private string type;

        public TransactionClass(int id, string userId, DateTime dateTime, int amount, string type)
        {
            this.id = id;
            this.userId = userId;
            this.dateTime = dateTime;
            this.amount = amount;
            this.type = type;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
            }
        }
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
            }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
            }
        }

    }
}
