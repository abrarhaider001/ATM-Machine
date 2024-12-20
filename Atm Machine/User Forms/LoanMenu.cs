using Atm_Machine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atm_Machine.User_Forms
{
    public partial class LoanMenu : Form
    {
        private UserClass currentUser;
        public LoanMenu(UserClass user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoanHistory loanHistory = new LoanHistory(currentUser);
            this.Hide();
            loanHistory.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EasyLoan easyLoan = new EasyLoan(currentUser);
            this.Hide();
            easyLoan.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
