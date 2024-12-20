using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atm_Machine.Classes;
using Atm_Machine.User_Forms;

namespace Atm_Machine
{
    public partial class ProcceedTransaction : Form
    {
        private UserClass currentUser;
        public ProcceedTransaction(UserClass user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void CashWithdrawalClick(object sender, EventArgs e)
        {
            CashWithdrawal cashWithdrawal = new CashWithdrawal(currentUser);
            this.Hide();
            cashWithdrawal.Show();
        }

        private void BalanceInquiryClick(object sender, EventArgs e)
        {
            BalanceInquiry balanceInquiry = new BalanceInquiry(currentUser);
            this.Hide();
            balanceInquiry.Show();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FastCashClick(object sender, EventArgs e)
        {
            FastCash fastCash = new FastCash(currentUser);
            this.Close();
            fastCash.Show();
        }

        private void MiniStatementClick(object sender, EventArgs e)
        {
            MiniStatement miniStatement = new MiniStatement(currentUser);
            this.Close();
            miniStatement.Show();
        }

        private void LoanClick(object sender, EventArgs e)
        {
            LoanMenu loanmenu = new LoanMenu(currentUser);
            loanmenu.Show();
        }
    }
}
