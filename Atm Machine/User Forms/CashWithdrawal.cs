using Atm_Machine.Classes;
using Atm_Machine.User_Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Atm_Machine
{
    public partial class CashWithdrawal : Form
    {
        private UserClass currentUser;

        public CashWithdrawal(UserClass user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private void ConfirmClick(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            string input = richTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a value. The field cannot be empty.", "Empty Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    int id = currentUser.Id;
                    int amountToWithdraw = int.TryParse(input, out int parsedAmount) ? parsedAmount : -1;

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
                                            int amount = amountToWithdraw;
                                            string transactionType = "Withdraw";

                                            string query1 = @"INSERT INTO [dbo].[Transactions] ([UserId], [Amount], [TransactionType]) VALUES (@UserId, @Amount, @TransactionType)";
                                            SqlCommand cmd1 = new SqlCommand(query1, con);


                                            cmd1.Parameters.AddWithValue("@UserId", userId);
                                            cmd1.Parameters.AddWithValue("@Amount", amount);
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

        private void HomeClick(object sender, EventArgs e)
        {
            Menu menu = new Menu(currentUser);
            this.Hide();
            menu.Show();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
