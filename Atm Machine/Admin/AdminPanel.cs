using Atm_Machine.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atm_Machine
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AddUserClick(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            this.Close();
            addUser.Show();
        }

        private void RemoveUserClick(object sender, EventArgs e)
        {
            RemoveUser removeUser = new RemoveUser();
            this.Close();
            removeUser.Show();
        }

        private void UpdateUser(object sender, EventArgs e)
        {
            UpdateUser updateUser = new UpdateUser();
            this.Close();
            updateUser.Show();
        }

        private void ViewUserClick(object sender, EventArgs e)
        {
            ViewUser viewUser = new ViewUser();
            this.Close();
            viewUser.Show();
        }

        private void TransactionHistoryClick(object sender, EventArgs e)
        {
            TransactionHistory transactionHistory = new TransactionHistory();
            this.Close();
            transactionHistory.Show();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            EnterCard enterCardNo = new EnterCard();
            this.Close();
            enterCardNo.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ViewLoanRequests view = new ViewLoanRequests();
            this.Hide();
            view.Show();
        }
    }
}
