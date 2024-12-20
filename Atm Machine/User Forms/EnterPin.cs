using System;
using System.Windows.Forms;
using Atm_Machine.Classes;

namespace Atm_Machine
{
    public partial class EnterPin : Form
    {
        private UserClass currentUser;
        private bool isAdmin;
        private string actualPin = "";

        public EnterPin(UserClass user, bool adminMode = false)
        {
            InitializeComponent();
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.DeselectAll();

            currentUser = user;
            isAdmin = adminMode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string enteredPin = actualPin;

            if (isAdmin && enteredPin == "admin")
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
            }
            else if (currentUser != null && enteredPin == currentUser.Password)
            {
                Menu menu = new Menu(currentUser);
                this.Close();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Invalid PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int newLength = richTextBox1.Text.Length;

            if (newLength > actualPin.Length)
            {
                actualPin += richTextBox1.Text.Substring(actualPin.Length);
            }
            else if (newLength < actualPin.Length)
            {
                actualPin = actualPin.Substring(0, newLength);
            }

            richTextBox1.Text = new string('*', actualPin.Length);
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }

    }
}
