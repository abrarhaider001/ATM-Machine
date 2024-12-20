using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace Atm_Machine.Classes
{
    public class UserClass
    {
        private int id;
        private string password;
        private string name;
        private string email;
        private bool isCardActivatedField;
        private int amount;

        public UserClass(int id, string password, string name, string email, bool isCardActivated)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.email = email;
            isCardActivatedField = isCardActivated;
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public bool IsCardActivated
        {
            get { return isCardActivatedField; }
            set { isCardActivatedField = value; }
        }
    }
}
