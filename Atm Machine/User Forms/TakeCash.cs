using System;
using System.Windows.Forms;

namespace Atm_Machine.User_Forms
{
    public partial class TakeCash : Form
    {
        private System.Windows.Forms.Timer timer;

        public TakeCash()
        {
            InitializeComponent();

            timer = new System.Windows.Forms.Timer();
        }

        private void TakeCash_Load(object sender, EventArgs e)
        {
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose(); 

            Initial initial = new Initial();
            initial.Show();

            this.Close();
        }
    }
}
