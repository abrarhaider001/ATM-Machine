using Atm_Machine.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Atm_Machine
{
    public partial class EasyLoan : Form
    {
        UserClass currentUser;
        public EasyLoan(UserClass userClass)
        {
            InitializeComponent();
            this.currentUser = userClass;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string labelData = label1.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            int userId = currentUser.Id;
            putLoanRequest(userId,amount);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string labelData = label2.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            int userId = currentUser.Id;
            putLoanRequest(userId, amount);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string labelData = label3.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            int userId = currentUser.Id;
            putLoanRequest(userId, amount);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string labelData = label4.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            int userId = currentUser.Id;
            putLoanRequest(userId, amount);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            string labelData = label5.Text.Replace(",", "");
            int amount = int.Parse(labelData);
            int userId = currentUser.Id;
            putLoanRequest(userId, amount);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void putLoanRequest(int userId, decimal loanAmount)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Atm;Integrated Security=True;" +
                                      "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
                                      "Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    string checkQuery = "SELECT COUNT(*) FROM LoanRequests WHERE UserId = @UserId AND Status = 'Pending'";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@UserId", userId);

                        int existingRequests = (int)checkCmd.ExecuteScalar();

                        if (existingRequests > 0)
                        {
                            MessageBox.Show("A pending loan request already exists for this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = @"INSERT INTO LoanRequests (UserId, LoanAmount) VALUES (@UserId, @LoanAmount)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@LoanAmount", loanAmount);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Loan request added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to add loan request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
