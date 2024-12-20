using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Atm_Machine
{
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void UpdateUserClick(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(connectionString);

            string name = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            string amountToDeposit = textBox4.Text;
            string phone = textBox5.Text;
            string id = textBox6.Text;


            string transactionType = "Deposit";

            if (string.IsNullOrWhiteSpace(id) || id.Length < 3)
            {
                MessageBox.Show("Please enter a valid Id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                MessageBox.Show("Please enter a valid name with at least 3 alphabetic characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(amountToDeposit, out decimal initialAmount) || initialAmount < 0)
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


            try
            {
                int previousAmount = 0;
                int amountForTransactionHistory = 0;

                con.Open();

                string queryRetrieveAmount = "SELECT Amount FROM Users WHERE Id = @id";
                SqlCommand cmdRetrieveAmount = new SqlCommand(queryRetrieveAmount, con);
                cmdRetrieveAmount.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmdRetrieveAmount.ExecuteReader();

                if (reader.Read())
                {
                    previousAmount = int.Parse(reader["Amount"].ToString());
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                    return;
                }

                string queryUpdateUser = @"UPDATE Users 
                                    SET Name = @name, 
                                   Password = @password, 
                                   Amount = @amount, 
                                   Email = @email, 
                                   Phone = @phone
                               WHERE Id = @id";
                SqlCommand cmdUpdateUser = new SqlCommand(queryUpdateUser, con);

                int amountDeposit = int.Parse(amountToDeposit);
                int amountForUpdateUser = amountDeposit + previousAmount;

                cmdUpdateUser.Parameters.AddWithValue("@name", name);
                cmdUpdateUser.Parameters.AddWithValue("@password", password);
                cmdUpdateUser.Parameters.AddWithValue("@amount", amountForUpdateUser);
                cmdUpdateUser.Parameters.AddWithValue("@email", email);
                cmdUpdateUser.Parameters.AddWithValue("@id", id);
                cmdUpdateUser.Parameters.AddWithValue("@phone", phone);

                int rowsAffected = cmdUpdateUser.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    int amountSelected = int.Parse(amountToDeposit);
                    //amountForTransactionHistory = amountSelected - previousAmount;

                    string queryInsertTransaction = @"INSERT INTO [dbo].[Transactions] ([UserId], [Amount], [TransactionType]) 
                                          VALUES (@UserId, @Amount, @TransactionType)";
                    SqlCommand cmdInsertTransaction = new SqlCommand(queryInsertTransaction, con);

                    cmdInsertTransaction.Parameters.AddWithValue("@UserId", id);
                    cmdInsertTransaction.Parameters.AddWithValue("@Amount", amountSelected);
                    cmdInsertTransaction.Parameters.AddWithValue("@TransactionType", transactionType);

                    int rowsInserted = cmdInsertTransaction.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Transaction history added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Transaction history not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MessageBox.Show("User updated successfully for Id: " + id);
                }
                else
                {
                    MessageBox.Show("User not found, not updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void BackClick(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Close();
            adminPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                string id = textBox6.Text;

                string query = "SELECT Amount FROM Users WHERE Id = @id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string retrievedAmount = reader["Amount"].ToString();
                    MessageBox.Show("UserID: " + id + "\nAmount: " + retrievedAmount, "User Details", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
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
    }
}
