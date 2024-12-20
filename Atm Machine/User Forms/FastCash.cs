using Atm_Machine.Classes;
using Atm_Machine.User_Forms;
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

namespace Atm_Machine
{
    public partial class FastCash : Form
    {
        private UserClass currentUser;
        public FastCash(UserClass user)
        {
            InitializeComponent();
            currentUser = user;
        }

        public void fastCashWithdraw(int amount)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
               "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int id = currentUser.Id;
                    int amountToWithdraw = amount;

                    if (amountToWithdraw <= 0)
                    {
                        MessageBox.Show("Please enter a valid amount greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "SELECT Amount FROM Users WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int currentBalance = reader.GetInt32(0);

                                if (currentBalance <= 0)
                                {
                                    MessageBox.Show("Your current balance is insufficient for this transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (amountToWithdraw > currentBalance)
                                {
                                    MessageBox.Show("Your current balance is less than the requested withdrawal amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                reader.Close();

                                int newBalance = currentBalance - amountToWithdraw;
                                string updateBalanceQuery = "UPDATE Users SET Amount = @Amount WHERE Id = @Id";
                                using (SqlCommand updateCmd = new SqlCommand(updateBalanceQuery, con))
                                {
                                    updateCmd.Parameters.AddWithValue("@Id", id);
                                    updateCmd.Parameters.AddWithValue("@Amount", newBalance);
                                    int rowsAffected = updateCmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Amount successfully withdrawn.", "Transaction Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        try
                                        {
                                            int userId = currentUser.Id;
                                            int amount1 = amountToWithdraw;
                                            string transactionType = "Withdraw";

                                            string query1 = @"INSERT INTO [dbo].[Transactions] ([UserId], [Amount], [TransactionType]) VALUES (@UserId, @Amount, @TransactionType)";
                                            SqlCommand cmd1 = new SqlCommand(query1, con);


                                            cmd1.Parameters.AddWithValue("@UserId", userId);
                                            cmd1.Parameters.AddWithValue("@Amount", amount1);
                                            cmd1.Parameters.AddWithValue("@TransactionType", transactionType);

                                            int rowsAffected1 = cmd1.ExecuteNonQuery();

                                            if (rowsAffected1 > 0)
                                            {
                                                MessageBox.Show("Transaction history added successfully!", "History", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Transaction history not added.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                        MessageBox.Show("Error! Amount not withdrawn.", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("User account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                    TakeCash takeCash = new TakeCash();
                    this.Hide();
                    takeCash.Show();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ProcceedTransaction procceedTransaction = new ProcceedTransaction(currentUser);
            this.Hide();
            procceedTransaction.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string labelData = label1.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            fastCashWithdraw(amount);

        }

        private void label6_Click(object sender, EventArgs e)
        {
            string labelData = label6.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            fastCashWithdraw(amount);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string labelData = label5.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            fastCashWithdraw(amount);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string labelData = label4.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            fastCashWithdraw(amount);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string labelData = label3.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            fastCashWithdraw(amount);
        }
    }
}
