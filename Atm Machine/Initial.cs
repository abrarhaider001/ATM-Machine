using System;
using System.Windows.Forms;

namespace Atm_Machine
{
    public partial class Initial : Form
    {
        private System.Windows.Forms.Timer progressTimer;

        public Initial()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;

            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 100;
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 4;
            }
            else
            {
                progressTimer.Stop();

                Cursor = Cursors.Default;
                EnterCard form2 = new EnterCard();
                form2.Show();
                this.Hide();
            }
        }

    }
}
