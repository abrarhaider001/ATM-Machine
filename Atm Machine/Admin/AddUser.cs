using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Atm_Machine
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUserClick(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(connectionString);

            string name = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;
            string amount = textBox4.Text;
            string email = textBox5.Text;
            string phone = textBox6.Text;

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                MessageBox.Show("Please enter a valid name with at least 3 alphabetic characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6 )
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(amount, out decimal initialAmount) || initialAmount < 0)
            {
                MessageBox.Show("Please enter a valid initial amount (a positive number).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || email.Length < 9)
            {
                MessageBox.Show("Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(phone) || phone.Length < 10)
            {
                MessageBox.Show("Please enter a valid phone number (at least 10 digits).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password == confirmPassword)
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO Users (Name, Password, Email, Amount, Phone) VALUES (@username, @password, @email, @amount, @phone)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@username", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("User could not be added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Password and Confirmpassword don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BackClick(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Close();
            adminPanel.Show();
        }
    }
}
